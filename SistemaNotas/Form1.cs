using SistemaNotas.Modelo_de_clases;
using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace SistemaNotas
{
    public partial class Form1 : Form
    {
        //private FileManager fileManager = new FileManager();
        private Validaciones validaciones = new Validaciones();
        public Form1()
        {
            InitializeComponent();
            // Configura el color de fondo cuando el mouse está sobre el botón
            btnInciarSeccion.FlatAppearance.MouseOverBackColor = Color.Lime;

            // Configura el color de fondo cuando el botón se presiona
            btnInciarSeccion.FlatAppearance.MouseDownBackColor = Color.Green;

            // Configura el color del borde del botón
            btnInciarSeccion.FlatAppearance.BorderColor = Color.Black;

            // Establece el estilo plano para el botón
            btnInciarSeccion.FlatStyle = FlatStyle.Flat;
        }

        private void btnInciarSeccion_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            if (validaciones.ValidarLogin(usuario, contraseña))
            {
                // Inicio de sesión exitoso
                MessageBox.Show("Inicio de sesión exitoso");

                // Oculta el formulario actual

                this.Hide();

                // Muestra el formulario principal
                interfaz formPrincipal = new interfaz();
                formPrincipal.ShowDialog();

                // Cierra la aplicación cuando se cierre el formulario principal
                this.Close();
            }
            else
            {
                // Mostrar un mensaje de error
                MessageBox.Show("Error en el inicio de sesión. Verifica tus credenciales.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // Agregar controles al FlowLayoutPanel
            flowLayoutPanel1.Controls.Add(label1); // Label 1
            flowLayoutPanel1.Controls.Add(txtUsuario); // TextBox 1
            flowLayoutPanel1.Controls.Add(label2); // Label 2
            flowLayoutPanel1.Controls.Add(txtContraseña); // TextBox 2
            flowLayoutPanel1.Controls.Add(btnInciarSeccion); // Botón

            // Maximiza el formulario en pantalla completa al cargarlo.
            this.WindowState = FormWindowState.Maximized;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11)
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.WindowState = FormWindowState.Normal; // Salir de pantalla completa
                }
                else
                {
                    this.WindowState = FormWindowState.Maximized; // Entrar en pantalla completa
                }
            }
        }
    }
}
