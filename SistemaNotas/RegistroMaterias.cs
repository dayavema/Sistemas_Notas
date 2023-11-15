using SistemaNotas.Modelo_de_clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaNotas
{
    public partial class RegistroMaterias : Form
    {
        public RegistroMaterias()
        {
            InitializeComponent();
            btnGuardar.FlatAppearance.MouseOverBackColor = Color.Lime;
            // Configura el color de fondo cuando el botón se presiona
            btnGuardar.FlatAppearance.MouseDownBackColor = Color.Green;
            // Configura el color del borde del botón
            btnGuardar.FlatAppearance.BorderColor = Color.Black;
            // Establece el estilo plano para el botón
            btnGuardar.FlatStyle = FlatStyle.Flat;

            CargarMaterias();
        }
        private List<Materias> materias = new List<Materias>();
        private void CargarMaterias()
        {
            string rutaArchivo = "materias.txt";

            if (File.Exists(rutaArchivo))
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);
                foreach (string linea in lineas)
                {
                    string[] partes = linea.Split(';'); // Asume que los datos están separados por punto y coma
                    if (partes.Length >= 2)
                    {
                        Materias materia = new Materias
                        {
                            Nombre = partes[0],
                            Creditos = int.Parse(partes[1])
                        };

                        materias.Add(materia);
                        //// Agrega el nombre de la materia al ComboBox
                        //comboBoxMaterias.Items.Add(materia.Nombre);
                    }
                }
            }
        }


        public void GuardarMateria(Materias materia)
        {
            string rutaArchivo = "materias.txt";
            string materiaString = $"{materia.Nombre};{materia.Creditos}";

            if (MateriaExisteEnArchivo(rutaArchivo, materiaString))
            {
                MessageBox.Show("La materia ya existe en el archivo.");
            }
            else
            {
                using (StreamWriter writer = new StreamWriter(rutaArchivo, true))
                {
                    writer.WriteLine(materiaString);
                }

                materias.Add(materia); // Agrega la materia a la lista local
                MessageBox.Show("La materia se ha registrado exitosamente.");
            }
        }

        private bool MateriaExisteEnArchivo(string rutaArchivo, string materiaString)
        {
            if (File.Exists(rutaArchivo))
            {
                string[] lineas = File.ReadAllLines(rutaArchivo);
                foreach (string linea in lineas)
                {
                    if (linea == materiaString)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Crear instancia de Materia
            Materias materia = new Materias
            {
                Nombre = txtNombreMateria.Text,
                Creditos = Convert.ToInt32(txtCreditosMateria.Text),
                // Agrega más propiedades según sea necesario
            };

            // Guardar en archivo y agregar a DataManager
            GuardarMateria(materia);
            //DataManager.AgregarEstudiante(estudiante);

            // Limpiar los campos después de guardar
            LimpiarCamposMateria();

            // Actualizar DataGridView en ImprimirB
            //DataManager.OnDatosActualizados();
        }

        private void LimpiarCamposMateria()
        {
            // Limpiar los TextBox u otros controles después de guardar una materia
            txtNombreMateria.Text = "";
            txtCreditosMateria.Text = "";
            // Limpiar otros controles según sea necesario
        }

        private void RegistroMaterias_Load(object sender, EventArgs e)
        {
            // Maximiza el formulario en pantalla completa al cargarlo.
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
