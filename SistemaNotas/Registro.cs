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
    public partial class Registro : Form
    {
        public Registro()
        {
            InitializeComponent();
            // Cargar datos existentes al iniciar la aplicación
            CargarEstudiantes();

            btnGuardar.FlatAppearance.MouseOverBackColor = Color.Lime;
            // Configura el color de fondo cuando el botón se presiona
            btnGuardar.FlatAppearance.MouseDownBackColor = Color.Green;
            // Configura el color del borde del botón
            btnGuardar.FlatAppearance.BorderColor = Color.Black;
            // Establece el estilo plano para el botón
            btnGuardar.FlatStyle = FlatStyle.Flat;
        }

        private List<Estudiante> estudiantes = new List<Estudiante>();

        private void CargarEstudiantes()
        {
            string rutaArchivo = "estudiantes.txt";

            if (File.Exists(rutaArchivo))
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);
                foreach (string linea in lineas)
                {
                    // Parsea cada línea y crea instancias de Estudiante
                    string[] partes = linea.Split(';'); // Asume que los datos están separados por punto y coma
                    if (partes.Length >= 6)
                    {
                        Estudiante estudiante = new Estudiante
                        {
                            Nombre = partes[0],
                            Apellidos = partes[1],
                            Edad = int.Parse(partes[2]),
                            Cedula = partes[3],
                            Correo = partes[4],
                            Telefono = partes[5]
                        };

                        estudiantes.Add(estudiante);
                    }
                }
            }
        }

        public void GuardarEstudiante(Estudiante estudiante)
        {
            string rutaArchivo = "estudiantes.txt";
            string estudianteString = $"{estudiante.Nombre};{estudiante.Apellidos};{estudiante.Edad};{estudiante.Cedula};{estudiante.Correo};{estudiante.Telefono}";

            if (EstudianteExisteEnArchivo(rutaArchivo, estudianteString))
            {
                MessageBox.Show("El estudiante ya existe en el archivo.");
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
                {
                    writer.WriteLine(estudianteString);
                }

                estudiantes.Add(estudiante); // Agrega el estudiante a la lista local
                MessageBox.Show("El estudiante se ha registrado exitosamente.");
            }
        }

        private bool EstudianteExisteEnArchivo(string rutaArchivo, string estudianteString)
        {
            if (File.Exists(rutaArchivo))
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);
                foreach (string linea in lineas)
                {
                    if (linea == estudianteString)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Crear instancia de Estudiante
            Estudiante estudiante = new Estudiante
            {
                Nombre = txtNombre.Text,
                Apellidos = txtApellidos.Text,
                Edad = Convert.ToInt32(txtEdad.Text),
                Cedula = txtCedula.Text,
                Correo = txtCorreo.Text,
                Telefono = txtTelefono.Text,   

                // Agrega más propiedades según sea necesario
            };

            // Guardar en archivo
            GuardarEstudiante(estudiante);

            // Limpiar los campos después de guardar
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            // Limpiar los TextBox u otros controles después de guardar
            txtNombre.Text = "";
            txtApellidos.Text = "";
            txtEdad.Text = "";
            txtCedula.Text = "";
            txtCorreo.Text= "";
            txtTelefono.Text = ""; 
            // Limpiar otros controles según sea necesario
        }

        private void Registro_Load(object sender, EventArgs e)
        {
            // Maximiza el formulario en pantalla completa al cargarlo.
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
