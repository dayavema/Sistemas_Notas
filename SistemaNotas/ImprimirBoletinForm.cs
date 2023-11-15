using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaNotas
{
    public partial class ImprimirBoletinForm : Form
    {
        private string contenidoBoletin;
        public ImprimirBoletinForm(string contenido)
        {
            InitializeComponent();
            contenidoBoletin = contenido;
        }

        private void ImprimirBoletinForm_Load(object sender, EventArgs e)
        {

            // Configura el contenido del boletín en un PrintDocument
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(ImprimirBoletin);

            // Asigna el PrintDocument al PrintPreviewControl
            printPreviewControl1.Document = pd;
        }

        private void ImprimirBoletin(object sender, PrintPageEventArgs e)
        {
            // Aquí puedes personalizar el contenido del boletín y dibujarlo en la página de impresión.
            // Por ejemplo, puedes utilizar e.Graphics.DrawString para agregar texto al documento de impresión.

            e.Graphics.DrawString(contenidoBoletin, new Font("Arial", 12), Brushes.Black, 50, 50);
        }
    }
}


