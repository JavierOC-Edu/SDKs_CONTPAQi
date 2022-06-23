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
    public partial class PrincipalForm : Form
    {
        public PrincipalForm()
        {
            InitializeComponent();
        }

        private void bttnIniciarConexion_Click(object sender, EventArgs e)
        {
            InterfazConexionSDK.IniciarConexionSDK( ref listVListaDeEmpresas );

        }

        private void bttnDetenerConexion_Click(object sender, EventArgs e)
        {//metodo para cerrar o detener la conexión a SDK
            InterfazConexionSDK.CerrarEmpresa();
            InterfazConexionSDK.DetenerConexionSDK();

        }
        private void PrincipalForm_FormClosing(object sender, FormClosingEventArgs e)
        {//metodo que se ejecuta al cerrar la ventana
            //InterfazConexionSDK.CerrarEmpresa();
            //InterfazConexionSDK.DetenerConexionSDK();
        }

        private void listVListaDeEmpresas_SelectedIndexChanged(object sender, EventArgs e)
        {
            InterfazConexionSDK.AbrirEmpresa( listVListaDeEmpresas.SelectedItems[0].SubItems[1].Text)  ;

            MenúPrincipal vMenuPrincupal = new MenúPrincipal();
            vMenuPrincupal.Show();
            this.Hide();
        }

        private void bttnVerError_Click(object sender, EventArgs e)
        {
            InterfazConexionSDK.VerCodigoError( Int32.Parse(tboxCodigoError.Text) ) ;
        }
    }
}
