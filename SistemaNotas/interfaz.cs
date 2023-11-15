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
    public partial class interfaz : Form
    {
        public interfaz()
        {
            InitializeComponent();
            //Boton ver Notas Por Estudiantes
            btnVerNotasE.FlatAppearance.MouseOverBackColor = Color.Lime;

            // Configura el color de fondo cuando el botón se presiona

            btnVerNotasE.FlatAppearance.MouseDownBackColor = Color.Green;

            // Configura el color del borde del botón
            btnVerNotasE.FlatAppearance.BorderColor = Color.Black;

            // Establece el estilo plano para el botón
            btnVerNotasE.FlatStyle = FlatStyle.Flat;

            //Boton ver Notas Por Materias
            btnVerNotasM.FlatAppearance.MouseOverBackColor = Color.Lime;

            // Configura el color de fondo cuando el botón se presiona

            btnVerNotasM.FlatAppearance.MouseDownBackColor = Color.Green;

            // Configura el color del borde del botón
            btnVerNotasM.FlatAppearance.BorderColor = Color.Black;

            // Establece el estilo plano para el botón
            btnVerNotasM.FlatStyle = FlatStyle.Flat;

            //Registro Estudiantes

            btnRegistroE.FlatAppearance.MouseOverBackColor = Color.Lime;

            // Configura el color de fondo cuando el botón se presiona
            btnRegistroE.FlatAppearance.MouseDownBackColor = Color.Green;

            // Configura el color del borde del botón
            btnRegistroE.FlatAppearance.BorderColor = Color.Black;

            // Establece el estilo plano para el botón
            btnRegistroE.FlatStyle = FlatStyle.Flat;

            //Registro Mtaerias

            btnRegistrarMateria.FlatAppearance.MouseOverBackColor = Color.Lime;

            // Configura el color de fondo cuando el botón se presiona

            btnRegistrarMateria.FlatAppearance.MouseDownBackColor = Color.Green;

            // Configura el color del borde del botón
            btnRegistrarMateria.FlatAppearance.BorderColor = Color.Black;

            // Establece el estilo plano para el botón
            btnRegistrarMateria.FlatStyle = FlatStyle.Flat;

            //Registro Notas
            btnRegistrarNotas.FlatAppearance.MouseOverBackColor = Color.Lime;

            // Configura el color de fondo cuando el botón se presiona

            btnRegistrarNotas.FlatAppearance.MouseDownBackColor = Color.Green;

            // Configura el color del borde del botón
            btnRegistrarNotas.FlatAppearance.BorderColor = Color.Black;

            // Establece el estilo plano para el botón
            btnRegistrarNotas.FlatStyle = FlatStyle.Flat;

            //Imprimir Boletin
            btnImprimirB.FlatAppearance.MouseOverBackColor = Color.Lime;

            // Configura el color de fondo cuando el botón se presiona

            btnImprimirB.FlatAppearance.MouseDownBackColor = Color.Green;

            // Configura el color del borde del botón
            btnImprimirB.FlatAppearance.BorderColor = Color.Black;

            // Establece el estilo plano para el botón
            btnImprimirB.FlatStyle = FlatStyle.Flat;


        }
        private void btnVerNotasE_Click(object sender, EventArgs e)
        {

            VerNotasE formVerNotasE = new VerNotasE();
            formVerNotasE.ShowDialog();
        }
        private void btnVerNotasM_Click(object sender, EventArgs e)
        {
            VerNotasxM formVerNotasxM = new VerNotasxM();
            formVerNotasxM.ShowDialog();
        }
        private void interfaz_Load(object sender, EventArgs e)
        {
            // Maximiza el formulario en pantalla completa al cargarlo.
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnRegistroE_Click(object sender, EventArgs e)
        {
            Registro formRegistroU = new Registro();
            formRegistroU.ShowDialog();
        }

        private void btnRegistrarMateria_Click(object sender, EventArgs e)
        {
            RegistroMaterias formRegistroM = new RegistroMaterias();
            formRegistroM.ShowDialog();
        }

        private void btnRegistrarNotas_Click(object sender, EventArgs e)
        {
            RegistroNotas formRegistroN = new RegistroNotas();
            formRegistroN.ShowDialog();
        }

        private void btnImprimirB_Click(object sender, EventArgs e)
        {  
            // Obtiene la lista de estudiantes desde alguna fuente de datos.
            ImprimirB imprimirBForm = new ImprimirB(); // Pasa la lista de estudiantes al abrir el formulario.
            imprimirBForm.ShowDialog();
        }
    }
}
    
