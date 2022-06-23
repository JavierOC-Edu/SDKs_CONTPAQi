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
    public partial class FormDocumentosMovimientos : Form
    {
        public FormDocumentosMovimientos()
        {
            InitializeComponent();
        }

        private void bttnNuevoDocumento_Click(object sender, EventArgs e)
        { 
                    InterfazConexionSDK.EditarRegimen();     
        }

        private void bttnNuevoPago_Click(object sender, EventArgs e)
        {
            InterfazConexionSDK.NuevoDocumentoPago();
        }

        private void bttnSalidaAlmacen_Click(object sender, EventArgs e)
        {
            InterfazConexionSDK.NuevaSalidaDeAlmacen();
        }

        private void bttnEntradaAlmacen_Click(object sender, EventArgs e)
        {
            InterfazConexionSDK.NuevaEntradaDeAlmacen();
        }

        private void bttnTraspasoAlmacen_Click(object sender, EventArgs e)
        {
            InterfazConexionSDK.NuevoTraspasoAlmacenes();
        }

        private void GetNombreProducto_Click(object sender, EventArgs e)
        {
            InterfazConexionSDK.GetNombreProducto("L001");
        }

        private void bttnPruebaConcepts_Click(object sender, EventArgs e)
        {
            
        }

        private void bttnBuscaConcepto_Click(object sender, EventArgs e)
        {
            InterfazConexionSDK.BuscarConceptos("00243",1);
        }

        private void bttnNuevoAlmacen_Click(object sender, EventArgs e)
        {
            InterfazConexionSDK.AddAlmacen();
        }

        private void bttnPaquetes_Click(object sender, EventArgs e)
        {
            InterfazConexionSDK.DoctoPaquetes();
        }

        private void bttnNotaCredito_Click(object sender, EventArgs e)
        {
            InterfazConexionSDK.NotaCreditoIVA();
        }

        private void bttnSDKDatosSerieCapas_Click(object sender, EventArgs e)
        {
            InterfazConexionSDK.pruebaSDKDatosSeriesCapas();
        }

        private void bttnRelacionPago_Click(object sender, EventArgs e)
        {
            InterfazConexionSDK.RelacionarPago();
        }

        private void bttnDoctoAddenda_Click(object sender, EventArgs e)
        {

        }

        private void bttnDirTransportista_Click(object sender, EventArgs e)
        {
            InterfazConexionSDK.BuscarDireccionTrasnportista("OP01");
        }

        private void bttnEntregaDisco_Click(object sender, EventArgs e)
        {
            InterfazConexionSDK.EntregarFormatoDisco();
        }

        private void bttnAsocDevCompra_Click(object sender, EventArgs e)
        {
            InterfazConexionSDK.DevolucionSobreCompraAsocUUID();
        }

        private void bttnAsigDir_Click(object sender, EventArgs e)
        {
            InterfazConexionSDK.EditarDireccion();
        }

        private void bttnCotizacion_Click(object sender, EventArgs e)
        {
            InterfazConexionSDK.CotizacionEditBajoN();
        }

        private void bttnCancela_Click(object sender, EventArgs e)
        {
            InterfazConexionSDK.CancelarDocumento();
        }

        private void bttnFiltroMovimiento_Click(object sender, EventArgs e)
        {
            InterfazConexionSDK.FiltrarMovimiento();
        }
    }
}
