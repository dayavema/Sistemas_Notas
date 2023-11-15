using SistemaNotas.Modelo_de_clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaNotas
{
    public partial class RegistroNotas : Form
    {
        public RegistroNotas()
        {
            InitializeComponent();
            btnGuardarNota.FlatAppearance.MouseOverBackColor = Color.Lime;

            // Configura el color de fondo cuando el botón se presiona

            btnGuardarNota.FlatAppearance.MouseDownBackColor = Color.Green;

            // Configura el color del borde del botón
            btnGuardarNota.FlatAppearance.BorderColor = Color.Black;

            // Establece el estilo plano para el botón
            btnGuardarNota.FlatStyle = FlatStyle.Flat;

            CargarNotas();
        }
        private List<Nota> notas = new List<Nota>();
        private void CargarNotas()
        {
            string rutaArchivo = "notas.txt";

            if (File.Exists(rutaArchivo))
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);
                foreach (string linea in lineas)
                {
                    // Parsea cada línea y crea instancias de Nota
                    string[] partes = linea.Split(';'); // Asume que los datos están separados por punto y coma
                    if (partes.Length >= 4)
                    {
                        Nota nota = new Nota
                        {
                            Estudiante = partes[0],
                            Materia = partes[1],
                            Valor = double.Parse(partes[2]),
                            Fecha = DateTime.Parse(partes[3])
                            // Agrega más propiedades según sea necesario
                        };

                        notas.Add(nota);
                    }
                }
            }
        }
        public void GuardarNota(Nota nota)
        {
            string rutaArchivo = "notas.txt";
            string notaString = $"{nota.Estudiante};{nota.Materia};{nota.Valor};{nota.Fecha.ToString()}";

            if (NotaRepetida(nota))
            {
                MessageBox.Show("La nota ya existe para este estudiante y materia.");
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
                {
                    writer.WriteLine(notaString);
                }

                notas.Add(nota); // Agrega la nota a la lista local
                MessageBox.Show("La nota se ha registrado exitosamente.");
            }
        }

        private bool NotaRepetida(Nota nota)
        {
            // Verifica si ya existe una nota con el mismo estudiante y materia
            foreach (Nota existente in notas)
            {
                if (existente.Estudiante == nota.Estudiante && existente.Materia == nota.Materia)
                {
                    return true;
                }
            }
            return false;
        }
        private void btnGuardarNota_Click(object sender, EventArgs e)
        {
            // Crear instancia de Nota
            Nota nota = new Nota
            {
                Estudiante = txtEstudiante.Text,
                Materia = txtMateria.Text,
                Valor = double.Parse(txtValor.Text),
                Fecha = DateTime.Now
                // Agrega más propiedades según sea necesario
            };

            // Guardar en archivo
            GuardarNota(nota);

            // Limpiar los campos después de guardar
            LimpiarCamposNota();
        }

        private void LimpiarCamposNota()
        {
            // Limpiar los TextBox u otros controles después de guardar
            txtEstudiante.Text = "";
            txtMateria.Text = "";
            txtValor.Text = "";
            // Limpiar otros controles según sea necesario
        }

        private void RegistroNotas_Load(object sender, EventArgs e)
        {
            // Maximiza el formulario en pantalla completa al cargarlo.
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
    