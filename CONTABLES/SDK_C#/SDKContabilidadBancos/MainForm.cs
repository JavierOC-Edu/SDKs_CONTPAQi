using SDKCONTPAQNGLib;
using System;
using System.Windows.Forms;

namespace SDKContabilidadBancos
{
    public partial class MainForm : Form
    {

        #region OBJETOS

        Sesion SdkSesion = new Sesion();
        BancosFunciones Bancos = new BancosFunciones();
        ContabilidadFunciones Contabilidad = new ContabilidadFunciones();
        InterfazBACK Interfaz = new InterfazBACK();
        #endregion

        #region INICIALIZAR SISTEMA - EMPRESA
        public MainForm()
        {

            InitializeComponent();

            SdkSesion.Iniciar();
            SdkSesion.Abrir();

        }

        #endregion



        private void bttnEgreso_Click(object sender, EventArgs e)
        {
            Bancos.DocEgreso( ref SdkSesion.tSdkSesion);
        }

        private void bttnIngreso_Click(object sender, EventArgs e)
        {
            Bancos.DocIngreso(ref SdkSesion.tSdkSesion);
        }

        private void bttnBeneficiarioProveedor_Click(object sender, EventArgs e)
        {
            Bancos.EditarBeneficiarioProv(ref SdkSesion.tSdkSesion);
        }

        private void btnPolizaDiario_Click(object sender, EventArgs e)
        {
            Contabilidad.CrearPolizaDiario(ref SdkSesion.tSdkSesion);
        }

        private void bttnEgresoPoliza_Click(object sender, EventArgs e)
        {
            Interfaz.CrearPolizaPago( ref SdkSesion.tSdkSesion);
        }

        private void bttnEditaCliente_Click(object sender, EventArgs e)
        {
            Contabilidad.EditarCLiente(ref SdkSesion.tSdkSesion);
        }

        private void bttnRegistrarProveedor_Click(object sender, EventArgs e)
        {
            Bancos.RegistrarProveedor(ref SdkSesion.tSdkSesion );
        }

        private void bttnEgresoAsoc_Click(object sender, EventArgs e)
        {
            Bancos.DocEgresoAsocXML(ref SdkSesion.tSdkSesion);
        }
    }
}
