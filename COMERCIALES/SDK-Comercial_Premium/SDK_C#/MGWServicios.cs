using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace ConexiónSDKComercial
{
    class MGWServicios
    {
        #region CONSTANTES
        public class constantes // Declaración de constantes
        {
            public const int kLongFecha = 24;
            public const int kLongSerie = 12;
            public const int kLongCodigo = 31;
            public const int kLongNombre = 61;
            public const int kLongReferencia = 21;
            public const int kLongDescripcion = 61;
            public const int kLongCuenta = 101;
            public const int kLongMensaje = 3001;
            public const int kLongNombreProducto = 256;
            public const int kLongAbreviatura = 4;
            public const int kLongCodValorClasif = 4;
            public const int kLongDenComercial = 51;
            public const int kLongRepLegal = 51;
            public const int kLongTextoExtra = 51;
            public const int kLongRFC = 21;
            public const int kLongCURP = 21;
            public const int kLongDesCorta = 21;
            public const int kLongNumeroExtInt = 7;
            public const int kLongNumeroExpandido = 31;
            public const int kLongCodigoPostal = 7;
            public const int kLongTelefono = 16;
            public const int kLongEmailWeb = 51;
            public const int kLongSelloSat = 176;
            public const int kLonSerieCertSAT = 21;
            public const int kLongFechaHora = 36;
            public const int kLongSelloCFDI = 176;
            public const int kLongCadOrigComplSAT = 501;
            public const int kLongitudUUID = 37;
            public const int kLongitudRegimen = 101;
            public const int kLongitudMoneda = 61;
            public const int kLongitudFolio = 17;
            public const int kLongitudMonto = 31;
            public const int kLogitudLugarExpedicion = 401;
        }
        #endregion

        #region ESTRUCTURA DE DOCUMENTOS
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct tDocumento
        {
            public Double aFolio;
            public int aNumMoneda;
            public Double aTipoCambio;
            public Double aImporte;
            public Double aDescuentoDoc1;
            public Double aDescuentoDoc2;
            public int aSistemaOrigen;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public String aCodConcepto;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongSerie)]
            public String aSerie;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongFecha)]
            public String aFecha;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public String aCodigoCteProv;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public String aCodigoAgente;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongReferencia)]
            public String aReferencia;
            public int aAfecta;
            public double aGasto1;
            public double aGasto2;
            public double aGasto3;
        }



        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct RegLlaveDoc
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public String aCodConcepto;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongSerie)]
            public String aSerie;
            public double folio;
        }
        #endregion

        #region ESTRUCUTRA DIRECCION 
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct tDireccion
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public string cCodCteProv;
            public int cTipoCatalogo; // 1=Clientes y 2=Proveedores
            public int cTipoDireccion; // 1=Domicilio Fiscal, 2=Domicilio Envio
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongDescripcion)]
            public string cNombreCalle;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongNumeroExtInt)]
            public string cNumeroExterior;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongNumeroExtInt)]
            public string cNumeroInterior;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongDescripcion)]
            public string cColonia;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigoPostal)]
            public string cCodigoPostal;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongTelefono)]
            public string cTelefono1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongTelefono)]
            public string cTelefono2;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongTelefono)]
            public string cTelefono3;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongTelefono)]
            public string cTelefono4;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongEmailWeb)]
            public string cEmail;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongEmailWeb)]
            public string cDireccionWeb;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongDescripcion)]
            public string cCiudad;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongDescripcion)]
            public string cEstado;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongDescripcion)]
            public string cPais;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongDescripcion)]
            public string cTextoExtra;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongDescripcion)]
            public string cMunicipio;
        }
        #endregion

        #region ESTRUCTURA DE MOVIMIENTOS
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct tMovimiento
        {
            public int aConsecutivo;
            public Double aUnidades;
            public Double aPrecio;
            public Double aCosto;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public String aCodProdSer;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public String aCodAlmacen;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongReferencia)]
            public String aReferencia;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public String aCodClasificacion;
        }
        #endregion

        #region ESTRUCTURA DE PRODUCTOS
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct tProduto
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public string cCodigoProducto;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongNombre)]
            public string cNombreProducto;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongNombreProducto)]
            public string cDescripcionProducto;
            public int cTipoProducto;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongFecha)]
            public string cFechaAltaProducto;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongFecha)]
            public string cFechaBaja;
            public int cStatusProducto;
            public int cControlExistencia;
            public int cMetodoCosteo;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public string cCodigoUnidadBase;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public string cCodigoUnidadNoConvertible;
            public double cPrecio1;
            public double cPrecio2;
            public double cPrecio3;
            public double cPrecio4;
            public double cPrecio5;
            public double cPrecio6;
            public double cPrecio7;
            public double cPrecio8;
            public double cPrecio9;
            public double cPrecio10;
            public double cImpuesto1;
            public double cImpuesto2;
            public double cImpuesto3;
            public double cRetencion1;
            public double cRetencion2;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongNombre)]
            public string cNombreCaracteristica1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongNombre)]
            public string cNombreCaracteristica2;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongNombre)]
            public string cNombreCaracteristica3;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public string cCodigoValorClasificacion1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public string cCodigoValorClasificacion2;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public string cCodigoValorClasificacion3;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public string cCodigoValorClasificacion4;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public string cCodigoValorClasificacion5;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public string cCodigoValorClasificacion6;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongTextoExtra)]
            public string cTextoExtra1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongTextoExtra)]
            public string cTextoExtra2;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongTextoExtra)]
            public string cTextoExtra3;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongFecha)]
            public string cFechaExtra;
            public double cImporteExtra1;
            public double cImporteExtra2;
            public double cImporteExtra3;
            public double cImporteExtra4;
        }
        #endregion

        #region ESTRUCTURA DE CLIENTES PROVEEDORES
        // cliente proveedor
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct tCteProv
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public String cCodigoCliente;//[ kLongCodigo + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongNombre)]
            public String cRazonSocial;//[ kLongNombre + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongFecha)]
            public String cFechaAlta;//[ kLongFecha + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongRFC)]
            public String cRFC;//[ kLongRFC + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCURP)]
            public String cCURP;//[ kLongCURP + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongDenComercial)]
            public String cDenComercial;//[ kLongDenComercial + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongRepLegal)]
            public String cRepLegal;//[ kLongRepLegal + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongNombre)]
            public String cNombreMoneda;//[ kLongNombre + 1 ];
            public int cListaPreciosCliente;
            public double cDescuentoMovto;
            public int cBanVentaCredito; // 0 = No se permite venta a crédito, 1 = Se permite venta a crédito
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public String cCodigoValorClasificacionCliente1;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public String cCodigoValorClasificacionCliente2;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public String cCodigoValorClasificacionCliente3;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public String cCodigoValorClasificacionCliente4;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public String cCodigoValorClasificacionCliente5;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public String cCodigoValorClasificacionCliente6;//[ kLongCodValorClasif + 1 ];
            public int cTipoCliente; // 1 - Cliente, 2 - Cliente/Proveedor, 3 - Proveedor
            public int cEstatus; // 0. Inactivo, 1. Activo
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongFecha)]
            public String cFechaBaja;//[ kLongFecha + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongFecha)]
            public String cFechaUltimaRevision;//[ kLongFecha + 1 ];
            public double cLimiteCreditoCliente;
            public int cDiasCreditoCliente;
            public int cBanExcederCredito; // 0 = No se permite exceder crédito, 1 = Se permite exceder el crédito
            public double cDescuentoProntoPago;
            public int cDiasProntoPago;
            double cInteresMoratorio;
            public int cDiaPago;
            public int cDiasRevision;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongDesCorta)]
            public String cMensajeria;//[ kLongDesCorta + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongDescripcion)]
            public String cCuentaMensajeria;//[ kLongDescripcion + 1 ];
            public int cDiasEmbarqueCliente;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public String cCodigoAlmacen;//[ kLongCodigo + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public String cCodigoAgenteVenta;//[ kLongCodigo + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public String cCodigoAgenteCobro;//[ kLongCodigo + 1 ];
            public int cRestriccionAgente;
            public double cImpuesto1;
            public double cImpuesto2;
            public double cImpuesto3;
            public double cRetencionCliente1;
            public double cRetencionCliente2;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public String cCodigoValorClasificacionProveedor1;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public String cCodigoValorClasificacionProveedor2;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public String cCodigoValorClasificacionProveedor3;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public String cCodigoValorClasificacionProveedor4;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public String cCodigoValorClasificacionProveedor5;//[ kLongCodValorClasif + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodValorClasif)]
            public String cCodigoValorClasificacionProveedor6;//[ kLongCodValorClasif + 1 ];
            public double cLimiteCreditoProveedor;
            public int cDiasCreditoProveedor;
            public int cTiempoEntrega;
            public int cDiasEmbarqueProveedor;
            public double cImpuestoProveedor1;
            public double cImpuestoProveedor2;
            public double cImpuestoProveedor3;
            public double cRetencionProveedor1;
            public double cRetencionProveedor2;
            public int cBanInteresMoratorio; // 0 = No se le calculan intereses moratorios al cliente, 1 = Si se le calculan intereses moratorios al cliente.
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongTextoExtra)]
            public String cTextoExtra1;//[ kLongTextoExtra + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongTextoExtra)]
            public String cTextoExtra2;//[ kLongTextoExtra + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongTextoExtra)]
            public String cTextoExtra3;//[ kLongTextoExtra + 1 ];
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongTextoExtra)]
            public String cFechaExtra;//[ kLongFecha + 1 ];
            public double cImporteExtra1;
            public double cImporteExtra2;
            public double cImporteExtra3;
            public double cImporteExtra4;
        }
        #endregion

        #region ESTRUCTURA DE SERIES/CAPAS
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct tSeriesCapas
        {
            public double aUnidades;
            public double aTipoCambio;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public string aSeries;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongDescripcion)]
            public string aPedimento;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongDescripcion)]
            public string aAgencia;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongFecha)]
            public string aFechaPedimento;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongDescripcion)]
            public string aNumeroLote;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongFecha)]
            public string aFechaFabricacion;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongFecha)]
            public string aFechaCaducidad;

        }
        #endregion



        [DllImport("MGWServicios.dll")]
        public static extern Int32 fRegresaExistencia(string aCodigoProducto,
                                             string aCodigoAlmacen,
                                             string aAnio,
                                             string aMes,
                                             string aDia,
                                             ref double aExistencia
                                             );
        

        #region FUNCIONES ALTA AGENTE 
        [DllImport("MGWServicios.DLL")]
        public static extern int fBuscaIdAgente(int aIdAgente);


        [DllImport("MGWServicios.DLL")]
        public static extern int fBuscaAgente(string aCodigoAgente);


        [DllImport("MGWServicios.DLL")]
        public static extern int fInsertaAgente();


        [DllImport("MGWServicios.DLL")]
        public static extern int fEditaAgente();


        [DllImport("MGWServicios.DLL")]
        public static extern int fGuardaAgente();


        [DllImport("MGWServicios.DLL")]
        public static extern int fLeeDatoAgente(string aCampo, StringBuilder aValor, int aLen);


        [DllImport("MGWServicios.DLL")]
        public static extern int fSetDatoAgente(string aCampo, string aValor);


        #endregion

        #region FUNCIONES GENERALES
        [DllImport("KERNEL32")]
        public static extern int SetCurrentDirectory(string pPtrDirActual);

        [DllImport("MGWServicios.DLL")]
        public static extern int fSetNombrePAQ(String aNombrePAQ);

        [DllImport("MGWServicios.DLL")]
        public static extern void fInicioSesionSDK(string aUsuario, string aContrasenia);

        [DllImport("MGWServicios.DLL")]
        public static extern void fTerminaSDK();

        [DllImport("MGWServicios.DLL")]
        public static extern void fError(int NumeroError, StringBuilder Mensaje, int Longitud);

        #endregion

        #region FUNCIONES DE EMPRESAS

        [DllImport("MGWServicios.DLL")]
        public static extern int fAbreEmpresa(string Directorio);



        [DllImport("MGWServicios.DLL")]
        public static extern void fCierraEmpresa();

        [DllImport("MGWServicios.DLL")]
        public static extern int fPosPrimerEmpresa(ref int vaIdEmpresa, StringBuilder aNombreEmpresa, StringBuilder aDirectorioEmpresa);

        [DllImport("MGWServicios.DLL")]
        public static extern int fPosSiguienteEmpresa(ref int vaIdEmpresa, StringBuilder aNombreEmpresa, StringBuilder aDirectorioEmpresa);

        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fEntregEnDiscoXML([MarshalAs(UnmanagedType.LPStr)] string aCodConcepto, [MarshalAs(UnmanagedType.LPStr)] string aSerie, double aFolio, int aFormato, string aFormatoAmigable);

        #endregion

        #region FUNCIONES DE CONCEPTO

        [DllImport("MGWServicios.DLL")]
        public static extern int fPosPrimerConceptoDocto();

        [DllImport("MGWServicios.DLL")]
        public static extern int fPosUltimaConceptoDocto();

        [DllImport("MGWServicios.DLL")]
        public static extern int fPosSiguienteConceptoDocto();

        [DllImport("MGWServicios.DLL")]
        public static extern int fLeeDatoConceptoDocto(string aCampo, StringBuilder aValor, int aLen);

        [DllImport("MGWServicios.DLL")]
        public static extern int fBuscaConceptoDocto(string aCodConcepto);


        #endregion

        #region FUNCIONES DE CLIENTES

        [DllImport("MGWServicios.DLL")]
        public static extern int fPosPrimerCteProv();

        [DllImport("MGWServicios.DLL")]
        public static extern int fPosUltimoCteProv();

        [DllImport("MGWServicios.DLL")]
        public static extern int fPosSiguienteCteProv();

        [DllImport("MGWServicios.DLL")]
        public static extern int fLeeDatoCteProv(string aCampo, StringBuilder aValor, int aLen);

        [DllImport("MGWServicios.DLL")]
        public static extern int fBuscaCteProv(string codigo);

        [DllImport("MGWServicios.dll")]
        public static extern int fBuscaIdCteProv(int aIdCteProv);

        [DllImport("MGWServicios.DLL")]
        public static extern int fAltaCteProv(ref int aIdCteProv, ref tCteProv astCteProv);

        [DllImport("MGWServicios.DLL")]
        public static extern int fAltaCuentaBancariaCliente(ref int aIdCtaBancaria, string aCuentaBancaria, string aNombreCuenta, string aNombreMoneda, string aClaveBanco, string aCLABE, string aRFCBanco, string aNombreBancoExtranjero, string aCodigoCliente);




        #endregion

        #region FUNCIONES DE PRODUCTOS

        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fPosPrimerProducto();

        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fPosSiguienteProducto();

        [DllImport("MGWServicios.DLL")]
        public static extern int fBuscaProducto(string Codigo);

        [DllImport("MGWServicios.DLL")]
        public static extern int fLeeDatoProducto(string aCampo, StringBuilder aValor, int aLen);

        [DllImport("MGWServicios.DLL")]
        public static extern int fAltaProducto(ref int aIdProducto, ref tProduto astProducto);

        [DllImport("MGWServicios.DLL")]
        public static extern int fInsertaProducto();

        [DllImport("MGWServicios.DLL")]
        public static extern int fEditaProducto();
        [DllImport("MGWServicios.DLL")]
        public static extern int fGuardaProducto();

        [DllImport("MGWServicios.DLL")]
        public static extern int fSetDatoProducto(string aCampo, string aValor);

        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fRecosteoProducto(string aCodigoProducto, int aEjercicio, int aPeriodo, string aCodigoClasificacion1,
             string aCodigoClasificacion2, string aCodigoClasificacion3, string aCodigoClasificacion4, string aCodigoClasificacion5,
             string aCodigoClasificacion6, string aNombreBitacora, int aSobreEscribirBitacora, int aEsCalculoArimetico);

        #endregion



        #region UNIDADES DE MEDIDA Y PESO


        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fBuscaIdUnidad(int aIdUnidad);

        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fLeeDatoUnidad(string aCampo, StringBuilder aValor, int aLen);

        #endregion

        #region DIRECCIONES


        [DllImport("MGWServicios.DLL")]
        public static extern int fAltaDireccion(ref int aIdDireccion, ref tDireccion astDireccion);

        [DllImport("MGWServicios.DLL")]
        public static extern int fInsertaDireccion();

        [DllImport("MGWServicios.DLL")]
        public static extern int fSetDatoDireccion(string aCampo, string aValor);

        [DllImport("MGWServicios.DLL")]
        public static extern int fGuardaDireccion();

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fLeeDatoDireccion(string aCampo, StringBuilder aValor, int aLen);

        [DllImport("MGWServicios.DLL")]
        public static extern int fPosUltimaDireccion();

        [DllImport("MGWServicios.DLL")]
        public static extern int fPosSiguienteDireccion();

        [DllImport("MGWServicios.DLL")]
        public static extern int fPosPrimerDireccion();




        #endregion

        #region FUNCIONES DE DOCUMENTOS

        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fSiguienteFolio([MarshalAs(UnmanagedType.LPStr)] string aCodigoConcepto,
                                                   [MarshalAs(UnmanagedType.LPStr)] StringBuilder aSerie, ref double aFolio);

        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fEmitirDocumento(
            [MarshalAs(UnmanagedType.LPStr)] string aCodConcepto,
            [MarshalAs(UnmanagedType.LPStr)] string aSerie, double aFolio,
            [MarshalAs(UnmanagedType.LPStr)] string aPassword,
            [MarshalAs(UnmanagedType.LPStr)] string aArchivoAdicional);

        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fAltaDocumento(ref Int32 aIdDocumento, ref tDocumento atDocumento);

        [DllImport("MGWServicios.DLL")]
        public static extern int fCuentaBancariaEmpresaDoctos(string aCuentaBancaria);

        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fAltaDocumentoCargoAbono(ref tDocumento atDocumento);

        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fAltaMovimiento(Int32 aIdDocumento, ref Int32 aIdMovimiento, ref tMovimiento astMovimiento);

        [DllImport("MGWServicios.DLL")]
        public static extern int fInsertarMovimiento();

        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fBorraMovimiento(Int32 aIdDocumento, Int32 aIdMovimiento);


        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fAltaMovimientoSeriesCapas(int aIdMovimiento, ref tSeriesCapas lSeries);


        [DllImport("MGWServicios.DLL")]
        public static extern int fInicializaLicenseInfo(byte aSistema);

        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fEditarDocumento();

        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fEditaCteProv();

        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fSetDatoCteProv(string aCampo, string aValor);

        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fGuardaCteProv();
        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fGuardaDocumento();


        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fGuardaMovimiento();

        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fBuscarIdMovimiento(Int32 aIdMovimiento);

        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fSetDatoDocumento(string aCampo, string aValor);

        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fBuscarDocumento(string aCodConcepto, string aSerie, string aFolio);

        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fBuscarIdDocumento(Int32 aIdDocumento);

        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fSaldarDocumento(ref RegLlaveDoc astDocAPagar,
                                                    ref RegLlaveDoc astDocPago,
                                                    double importe,
                                                    int moneda,
                                                    string aFecha);
        [DllImport("MGWServicios.dll")] 
        public static extern Int32 mSDKDatosSeriesCapas(int aIdSeriesCapas, 
                                                        int aIdMovimiento, 
                                                        double aUnidades, 
                                                        double aTipoCambio, 
                                                        string aSeries, 
                                                        string aPedimento, 
                                                        string aAgencia, 
                                                        string aFechaPedimento, 
                                                        string aNumeroLote, 
                                                        string aFechaFabricacion, 
                                                        string aFechaCaducidad );



        [DllImport("MGWServicios.dll")]
        public static extern Int32 fSetFiltroMovimiento(Int32 aIdDocumento);


        [DllImport("MGWServicios.dll")]
        public static extern Int32 fPosPrimerMovimiento();

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fPosSiguienteMovimiento();

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fLeeDatoMovimiento(string aCampo, StringBuilder aValor, int aLen);

        [DllImport("MGWServicios.DLL")]
        public static extern int fEditaDireccion();

        [DllImport("MGWServicios.dll")]
        public static extern Int32 fBuscaDireccionEmpresa();

        [DllImport("MGWServicios.DLL")]
        public static extern int fBuscaDireccionCteProv(String lCodCteProv, Byte lTipoDireccion);


        [DllImport("MGWServicios.dll")]
        public static extern int fGetTamSelloDigitalYCadena(
            [MarshalAs(UnmanagedType.LPStr)] string atPtrPassword,
            ref int aEspSelloDig,
            ref int aEspCadOrig);


        [DllImport("MGWServicios.dll")]
        public static extern int fGetSelloDigitalYCadena(
            [MarshalAs(UnmanagedType.LPStr)] string atPtrPassword,
             ref string atPtrSelloDigital,
            ref string atPtrCadenaOriginal);


        [DllImport("MGWServicios.DLL")]
        public static extern int fInsertaDatoAddendaDocto(int aIdAddenda, int aIdCatalogo,
        int aNumCampo, string dato);




        //[DllImport("MGWServicios.dll")]
        //public static extern int fGetTamSelloDigitalYCadena(
        // [MarshalAs(UnmanagedType.LPStr)] string atPtrPassword,
        // [MarshalAs(UnmanagedType.LPStr)] Int32 aEspSelloDig,
        // [MarshalAs(UnmanagedType.LPStr)] Int32 aEspCadOrig);


        [DllImport("MGWServicios.dll")]
        public static extern int femitirXML(
                                                string aRutaXML, 
                                                string aCodConcepto, 
                                                StringBuilder aUUID, 
                                                string aRutaDDA,
                                                string aRutaResultado, 
                                                string aPass, 
                                                string aRutaFormato);


        [DllImport("MGWServicios.dll")]
        public static extern int fRegresaUltimoCosto(
                                                     string aCodigoProducto,
                                                     string aCodigoAlmacen,
                                                     string aAnio,
                                                     string aMes,
                                                     string aDia,
                                                    StringBuilder aUltimoCosto);


        [DllImport("MGWServicios.dll")]
        public static extern int fPosPrimerDocumento();

        [DllImport("MGWServicios.dll")]
        public static extern int fPosSiguienteDocumento();


        [DllImport("MGWServicios.dll")]
        public static extern int fLeeDatoDocumento(string aCampo, StringBuilder aValor, int aLen);
        #endregion





        #region FUNCIONES MOVIMIENTOS

        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fEditarMovimiento();

        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fSetDatoMovimiento([MarshalAs(UnmanagedType.LPStr)] string aCampo, [MarshalAs(UnmanagedType.LPStr)] string aValor);



        [DllImport("MGWServicios.DLL")]
        public static extern Int32 fSaldarDocumento_Param([MarshalAs(UnmanagedType.LPStr)] string aCodConcepto_Pagar,
                                                          [MarshalAs(UnmanagedType.LPStr)] string aSerie_Pagar,
                                                          double aFolio_Pagar,
                                                          [MarshalAs(UnmanagedType.LPStr)] string aCodConcepto_Pago,
                                                          [MarshalAs(UnmanagedType.LPStr)] string aSerie_Pago,
                                                          double aFolio_Pago,
                                                          double aImporte,
                                                          int aIdMoneda,
                                                          [MarshalAs(UnmanagedType.LPStr)] string aFecha);
        #endregion

        #region Estructura Almacén

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 4)]
        public struct tAlmacen
        {
            public int aId;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongNombre)]
            public String aNombre;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = constantes.kLongCodigo)]
            public String aCodAlmacen;

        }

        #endregion



        #region
        //Funciones Catalogo de Almacenes

        [DllImport("MGWServicios.dll", EntryPoint = "fBuscaAlmacen")]
        public static extern int fBuscaAlmacen(string aCodigoAlmacen);

        [DllImport("MGWServicios.dll", EntryPoint = "fBuscaIdAlmacen")]
        public static extern int fBuscaIdAlmacen(int aIdAlmacen);

        [DllImport("MGWServicios.dll", EntryPoint = "fCancelarModificacionAlmacen")]
        public static extern int fCancelarModificacionAlmacen();

        [DllImport("MGWServicios.dll", EntryPoint = "fEditaAlmacen")]
        public static extern int fEditaAlmacen();

        [DllImport("MGWServicios.dll", EntryPoint = "fGuardaAlmacen")]
        public static extern int fGuardaAlmacen();

        [DllImport("MGWServicios.dll", EntryPoint = "fInsertaAlmacen")]
        public static extern int fInsertaAlmacen();

        [DllImport("MGWServicios.dll", EntryPoint = "fLeeDatoAlmacen")]
        public static extern int fLeeDatoAlmacen(string aCampo, StringBuilder aValor, int aLen);

        [DllImport("MGWServicios.dll", EntryPoint = "fPosAnteriorAlmacen")]
        public static extern int fPosAnteriorAlmacen();

        [DllImport("MGWServicios.dll", EntryPoint = "fPosBOFAlmacen")]
        public static extern int fPosBOFAlmacen();

        [DllImport("MGWServicios.dll", EntryPoint = "fPosEOFAlmacen")]
        public static extern int fPosEOFAlmacen();

        [DllImport("MGWServicios.dll", EntryPoint = "fPosPrimerAlmacen")]
        public static extern int fPosPrimerAlmacen();

        [DllImport("MGWServicios.dll", EntryPoint = "fPosSiguienteAlmacen")]
        public static extern int fPosSiguienteAlmacen();

        [DllImport("MGWServicios.dll", EntryPoint = "fPosUltimoAlmacen")]
        public static extern int fPosUltimoAlmacen();

        [DllImport("MGWServicios.dll", EntryPoint = "fSetDatoAlmacen")]
        public static extern int fSetDatoAlmacen(string aCampo, string aValor);
        #endregion


        #region CANCELACIONES

        [DllImport("MGWServicios.dll", EntryPoint = "fCancelaCambiosMovimiento")]
        public static extern int fCancelaCambiosMovimiento();

        [DllImport("MGWServicios.dll", EntryPoint = "fCancelaDocumento")]
        public static extern int fCancelaDocumento();

        [DllImport("MGWServicios.dll", EntryPoint = "fCancelaDocumento_CW")]
        public static extern int fCancelaDocumento_CW();

        [DllImport("MGWServicios.dll", EntryPoint = "fCancelaDocumentoConMotivo")]
        public static extern int fCancelaDocumentoConMotivo(string aMotivo, string aUUIDRemplaza);

        [DllImport("MGWServicios.dll", EntryPoint = "fCancelaDoctoInfo")]
        public static extern int fCancelaDoctoInfo(string aPass);



        [DllImport("MGWServicios.dll", EntryPoint = "fCancelaFiltroDocumento")]
        public static extern int fCancelaFiltroDocumento();

        [DllImport("MGWServicios.dll", EntryPoint = "fCancelaFiltroMovimiento")]
        public static extern int fCancelaFiltroMovimiento();

        [DllImport("MGWServicios.dll", EntryPoint = "fCancelaNominaUUID")]
        public static extern int fCancelaNominaUUID(string aUUID, string aIdDConcepto, string aPass);

        [DllImport("MGWServicios.dll", EntryPoint = "fCancelarModificacionAgente")]
        public static extern int fCancelarModificacionAgente();

        [DllImport("MGWServicios.dll", EntryPoint = "fCancelarModificacionClasificacion")]
        public static extern int fCancelarModificacionClasificacion();

        [DllImport("MGWServicios.dll", EntryPoint = "fCancelarModificacionCteProv")]
        public static extern int fCancelarModificacionCteProv();

        [DllImport("MGWServicios.dll", EntryPoint = "fCancelarModificacionDireccion")]
        public static extern int fCancelarModificacionDireccion();

        [DllImport("MGWServicios.dll", EntryPoint = "fCancelarModificacionDocumento")]
        public static extern int fCancelarModificacionDocumento();

        [DllImport("MGWServicios.dll", EntryPoint = "fCancelarModificacionProducto")]
        public static extern int fCancelarModificacionProducto();

        [DllImport("MGWServicios.dll", EntryPoint = "fCancelarModificacionUnidad")]
        public static extern int fCancelarModificacionUnidad();

        [DllImport("MGWServicios.dll", EntryPoint = "fCancelarModificacionValorClasif")]
        public static extern int fCancelarModificacionValorClasif();

        [DllImport("MGWServicios.dll", EntryPoint = "fCancelaUUID")]
        public static extern int fCancelaUUID(string aUUID, string aIdDConcepto, string aPass);



        #endregion



        #region RELACIONES

        [DllImport("MGWServicios.dll", EntryPoint = "fRecuperarRelacionesCFDIs")]
        public static extern int fRecuperarRelacionesCFDIs(string aCodConcepto, string aSerie, string aFolio, string aTipoRelacion, StringBuilder aUUIDs, string aRutaNombreArchivoInfo);

        [DllImport("MGWServicios.dll", EntryPoint = "fAgregarRelacionCFDI")]
        public static extern int fAgregarRelacionCFDI(string aCodConcepto, string aSerie, string aFolio, string aTipoRelacion, string aConceptoRelacionar, string aSerieRelacionar, string aFolioRelacionar);

        [DllImport("MGWServicios.dll", EntryPoint = "fAgregarRelacionCFDI2")]
        public static extern int fAgregarRelacionCFDI2(string aCodConcepto, string aSerie, string aFolio, string aTipoRelacion, string aUUID);

        [DllImport("MGWServicios.dll", EntryPoint = "fEliminarRelacionesCFDIs")]
        public static extern int fEliminarRelacionesCFDIs(string aCodConcepto, string aSerie, string aFolio);


        #endregion
        public static string rError(int iError)
        {
            StringBuilder sMensaje = new StringBuilder(512);
                fError(iError, sMensaje, 512);
            return sMensaje.ToString();
        }

    }
}
