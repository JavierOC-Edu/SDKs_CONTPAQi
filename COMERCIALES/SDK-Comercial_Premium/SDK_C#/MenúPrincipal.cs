using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConexiónSDKComercial
{
    public partial class MenúPrincipal : Form
    {
        public MenúPrincipal()
        {
            InitializeComponent();
        }

        private void facturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDocumentosMovimientos vDocumentosMovimientos = new FormDocumentosMovimientos();
            vDocumentosMovimientos.Show();
            //this.Hide();
        }

        private void pagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDocumentosMovimientos vDocumentosMovimientos = new FormDocumentosMovimientos();
            vDocumentosMovimientos.Show();
            //this.Hide();
        }

        private void documentosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void conceptosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cotizaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InterfazConexionSDK.CotizacionEditBajoN();
        }
    }
}
