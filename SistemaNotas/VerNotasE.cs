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

namespace SistemaNotas
{
    
    public partial class VerNotasE : Form
    {
        public VerNotasE()
        {
            InitializeComponent();
            CargarNotas();
        }
        private List<Nota> notas = new List<Nota>();
        private void CargarNotas()
        {
            // Configura las columnas del DataGridView
            dataGridViewNotas.ColumnCount = 6;
            dataGridViewNotas.Columns[0].Name = "Estudiante";
            dataGridViewNotas.Columns[1].Name = "Materia";
            dataGridViewNotas.Columns[2].Name = "Valor";
            dataGridViewNotas.Columns[3].Name = "Fecha";
            dataGridViewNotas.Columns[4].Name = "Resultado";
            dataGridViewNotas.Columns[5].Name = "Promedio";


            // Asegura que las columnas se ajusten automáticamente al contenido
            dataGridViewNotas.AutoResizeColumns();

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

            // Calcular y mostrar el promedio
            CalcularPromedio();
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

            double sumaNotas = 0.0;
            int contador = 0;

            foreach (Nota nota in notas)
            {
                string resultado = nota.Valor >= 3.0 ? "Aprobado" : "Reprobado";
                dataGridViewNotas.Rows.Add(nota.Estudiante, nota.Materia, nota.Valor, nota.Fecha, resultado);

                // Sumar las notas para el cálculo del promedio
                sumaNotas += nota.Valor;
                contador++;
            }

            // Calcular el promedio
            double promedio = contador > 0 ? sumaNotas / contador : 0.0;
            dataGridViewNotas.Rows.Add("", "", "", "", "Promedio", promedio);
        }

        public string GetNotaEContent()
        {

            if (dataGridViewNotas != null && dataGridViewNotas.Rows.Count > 0)
            {
                string notaE = string.Empty;

                foreach (DataGridViewRow row in dataGridViewNotas.Rows)
                {
                    if (row.Cells[0].Value != null)
                    {
                        notaE += row.Cells[0].Value.ToString() + Environment.NewLine;
                    }
                }

                return notaE;
            }
            else
            {
                return "No hay datos en el DataGridView de NotasE.";
            }
        }
        private void CalcularPromedio()
        {
            // Calcula el promedio de notas y muestra el resultado en el DataGridView
            CargarNotasEnDataGridView();
        }

        private void VerNotasE_Load(object sender, EventArgs e)
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

