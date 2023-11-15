using SistemaNotas.Modelo_de_clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace SistemaNotas
{
    public partial class VerNotasxM : Form
    {
        public VerNotasxM()
        {
            InitializeComponent();
            CargarMaterias(); // Asegúrate de que esta línea esté presente
            CargarNotas();
        }
        private List<Materias> materias = new List<Materias>();
        private List<Nota> notas = new List<Nota>();

        private void CargarMaterias()
        {
            string rutaArchivo = "materias.txt";

            if (File.Exists(rutaArchivo))
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);
                HashSet<string> materiasUnicas = new HashSet<string>(); // Usamos un HashSet para evitar duplicados

                foreach (string linea in lineas)
                {
                    string[] partes = linea.Split(';');
                    if (partes.Length >= 2)
                    {
                        string nombreMateria = partes[0];

                        // Verifica si la materia ya existe en el HashSet
                        if (!materiasUnicas.Contains(nombreMateria))
                        {
                            materiasUnicas.Add(nombreMateria); // Agrega la materia al HashSet
                            comboBoxMaterias.Items.Add(nombreMateria); // Agrega la materia al ComboBox
                        }
                    }
                }
            }
        }
        private bool MateriaExisteEnLista(string nombreMateria)
        {
            return materias.Any(m => m.Nombre == nombreMateria);
        }
        private void CargarNotas()
        {
            // Configura las columnas del DataGridView
            dataGridViewNotas.ColumnCount = 5;
            dataGridViewNotas.Columns[0].Name = "Estudiante";
            dataGridViewNotas.Columns[1].Name = "Materia";
            dataGridViewNotas.Columns[2].Name = "Nota";
            dataGridViewNotas.Columns[3].Name = "Fecha";
            dataGridViewNotas.Columns[4].Name = "Resultado";

            dataGridViewNotas.AutoResizeColumns();

            // Carga las notas desde un archivo
            string rutaArchivo = "notas.txt";

            if (File.Exists(rutaArchivo))
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);
                foreach (string linea in lineas)
                {
                    string[] partes = linea.Split(';');
                    if (partes.Length >= 4)
                    {
                        Nota nota = new Nota
                        {
                            Estudiante = partes[0],
                            Materia = partes[1],
                            Valor = double.Parse(partes[2]),
                            Fecha = DateTime.Parse(partes[3])
                        };
                        notas.Add(nota);
                    }
                }
            }

            // Carga las notas en el DataGridView
            CargarNotasEnDataGridView();
        }
        private void AjustarTamañoDataGridView()
        {
            // Desactiva la configuración automática del tamaño de las columnas y filas
            dataGridViewNotas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dataGridViewNotas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;

            // Ajusta el ancho de las columnas al contenido
            foreach (DataGridViewColumn col in dataGridViewNotas.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                col.Width = col.GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true);
            }

            // Ajusta la altura de las filas al contenido
            foreach (DataGridViewRow row in dataGridViewNotas.Rows)
            {
                int maxHeight = 0;
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null)
                    {
                        int cellHeight = TextRenderer.MeasureText(cell.Value.ToString(), dataGridViewNotas.Font, cell.Size, TextFormatFlags.WordBreak).Height;
                        if (cellHeight > maxHeight)
                        {
                            maxHeight = cellHeight;
                        }
                    }
                }
                row.Height = maxHeight;
            }

            // Vuelve a activar la configuración automática del tamaño si lo deseas
            dataGridViewNotas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dataGridViewNotas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void CargarNotasEnDataGridView()
        {
            dataGridViewNotas.Rows.Clear();

            if (comboBoxMaterias.SelectedItem != null)
            {
                string materiaSeleccionada = comboBoxMaterias.SelectedItem.ToString();

                var notasMateria = notas.Where(nota => nota.Materia == materiaSeleccionada).ToList();

                foreach (Nota nota in notasMateria)
                {
                    string resultado = nota.Valor >= 3.0 ? "Aprobado" : "Reprobado";
                    dataGridViewNotas.Rows.Add(nota.Estudiante, nota.Materia, nota.Valor, nota.Fecha, resultado);
                }

                // Calcula el promedio de las notas de la materia
                double sumaNotas = notasMateria.Sum(nota => nota.Valor);
                int contador = notasMateria.Count;
                double promedio = contador > 0 ? sumaNotas / contador : 0.0;

                string resultadoMateria = promedio >= 3.0 ? "Aprobado" : "Reprobado";

                // Agrega una fila para mostrar el promedio de las notas de la materia
                dataGridViewNotas.Rows.Add("", materiaSeleccionada, promedio, "", resultadoMateria);
            }
        }

        public string GetNotaMContent()
        {
            if (dataGridViewNotas != null && dataGridViewNotas.Rows.Count > 0)
            {
                string notaM = string.Empty;

                foreach (DataGridViewRow row in dataGridViewNotas.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        notaM += row.Cells[0].Value.ToString() + Environment.NewLine;
                    }
                }

                return notaM;
            }
            else
            {
                return "No hay datos en el DataGridView de NotasxM.";
            }
        }

        private void comboBoxMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarNotasEnDataGridView();
        }

        private void VerNotasxM_Load(object sender, EventArgs e)
        {
            // Maximiza el formulario en pantalla completa al cargarlo.
            this.WindowState = FormWindowState.Maximized;
        }

        private void dataGridViewNotas_SizeChanged(object sender, EventArgs e)
        {
            AjustarTamañoDataGridView();
        }
    }
}
    

