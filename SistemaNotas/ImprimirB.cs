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
    public partial class ImprimirB : Form
    {
        private class Estudiante
        {
            public string Nombre { get; set; }
            public string Apellidos { get; set; }
            public int Edad { get; set; }
            public string Cedula { get; set; }
            public string Correo { get; set; }
            public string Telefono { get; set; }
            public List<Nota> Notas { get; set; } = new List<Nota>();
        }

        private class Nota
        {
            public string Materia { get; set; }
            public double Valor { get; set; }
            public DateTime Fecha { get; set; }
        }

        private List<Estudiante> estudiantes;
        public ImprimirB()
        {
            InitializeComponent();
        }
     
        private void ImprimirB_Load(object sender, EventArgs e)
        {
            //Maximiza el formulario en pantalla completa al cargarlo.
            this.WindowState = FormWindowState.Maximized;
        }
    }
}






