using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKFacturaElectronica
{
    class ItfFunciones
    {
        #region CONSTANTES

        string rutaBinarios = @"C:\Program Files (x86)\Compacw\Facturacion\";
        string sistema = "CONTPAQ I Facturacion";
        string rutaEmpresas = @"C:\Compacw\Empresas\";
        string empresa = "FAC_Pruebas";
        string rutaDoctosTimbrados = @"C:\Compacw\Empresas\FAC_Pruebas\Doctos\Timbrados\";
        string claveCSD = "12345678a";
        string szRegKeySistema = "SOFTWARE\\Computación en Acción, SA CV\\CONTPAQ I Facturacion";
        string sNombrePAQ = "CONTPAQ I Facturacion";
        #endregion

        #region OBJETOS

        #endregion

        #region FUNCIONES DE TIMBRADO Y CANCELACIÓN

        #region TIMBRAR NOMINA
        private void TimbrarXMLNomina()
        {
            string concepto = "NOMINA"; //Codigo de concepto previamente configurado en el sistema para poder timbrar CFDIs
            string UUID = "";//UUID del XML a timbrar


            MGW_SDK_F.lError = MGW_SDK_F.fInicializaLicenseInfo(1);//se inicializa licencia para confirmar que haya una disponible
            Console.WriteLine("LICENCIA: " + MGW_SDK_F.lError);
            //Se intenta el timbrado del XML (nómina) enviando la ruta del XML, Concepto, UUID, ruta donde se guardara el XML-PDF, Clave de los CSDs configurados al concepto y ruta+plantilla HTM a utilizar
            //MGW_SDK_F.lError = MGW_SDK_F.fTimbraNominaXML(@"C:\Compacw\Empresas\FAC_Pruebas\Doctos\XMLsSinSello\XMLBase.xml", concepto, UUID, "", rutaDoctosTimbrados, claveCSD,
            //        @"C:\Compacw\Empresas\Reportes\Facturacion\Plantilla_Factura_cfdi_1.htm");
            //fTimbraXML
            MGW_SDK_F.lError = MGW_SDK_F.fTimbraXML(@"C:\Compacw\Empresas\FAC_Pruebas\Doctos\XMLsSinSello\Regimen13-2.xml", concepto, ref UUID, "", rutaDoctosTimbrados, claveCSD,
                    @"C:\Compacw\Empresas\Reportes\Facturacion\Plantilla_Factura_cfdi_1.htm");

            /*MGW_SDK_F.lError = MGW_SDK_F.fTimbraNominaXML(@"C:\Compacw\Empresas\FAC_Pruebas\Doctos\XMLsSinSello\Regimen13-2.xml", concepto, UUID, "", rutaDoctosTimbrados, claveCSD,
                    "");
            */
            if (MGW_SDK_F.lError != 0)//se valida que no exista error
            {
                Console.WriteLine("----------------------- XML SIN Timbrar -----------------------");//se indidca que no se puedo realizar el timbrado
                Console.WriteLine($"UUID: {UUID.ToString()}");//Se muestra el UUID que no se timbro
                Console.WriteLine("Error : " + MGW_SDK_F.lError.ToString()); //se imprime el número de error en consola
                DescripcionError(MGW_SDK_F.lError);//se imprime la descrición del codigo de error
            }
            else
            {
                //se confirma que el XML se timbro con éxito y se muestra el UUID timbrado
                Console.WriteLine("----------------------- XML Timbrado -----------------------");
                Console.WriteLine($"UUID: {UUID.ToString()}");
            }
        }
        #endregion

        #region CANCELAR XML
        public void CancelarXML()
        {
            #region VARIABLES INTERNAS
            string UUID = "DA149B66-9B08-475A-A7C0-8BAC175B8A4A";
            string rfcReceptor = "XAXX010101000";
            double total = 116;
            string idConcepto = "5";//
            int statusCancelacion = 0;
            string aMotivoCancelacion = "";
            string aUUIDReemplaza = "C24IYY19-098S-976D-ALL2-JFG486DH998S";
            #endregion
            #region cancelación
            MGW_SDK_F.lError = MGW_SDK_F.fInicializaLicenseInfo(1);//se inicializa licencia para confirmar que haya una disponible
            if (MGW_SDK_F.lError == 0)
            {
                //Se intenta la cancelación 
                MGW_SDK_F.lError = MGW_SDK_F.fCancelaUUID40(UUID, aMotivoCancelacion, aUUIDReemplaza, rfcReceptor, total, idConcepto, claveCSD, ref statusCancelacion);
                Console.WriteLine(MGW_SDK_F.lError);
                DescripcionError(MGW_SDK_F.lError);

                /*
                 *  MGW_SDK_F.lError = MGW_SDK_F.fCancelaUUID33(UUID, rfcReceptor, total, idConcepto, claveCSD, ref statusCancelacion);

                 * 
                 */
            }
            else
            {
                Console.WriteLine("No se pudo levantar la licencia. ");
                DescripcionError(MGW_SDK_F.lError);
            }

            #endregion
        }
        #endregion

        #region Timbrado de Pagos

        #region COMPLEMENTOPAGOXML

        private static void TimbrarXMLconComplementoPago()
        {
            //Variables que irán como parametro
            string aRutaXML = @"C:\Compacw\Empresas\FAC_Pruebas\Doctos\DoctosPruebas\Pv33_04sintfd.xml";
            string aCodConcepto = "PAGOS";
            StringBuilder aUUID = new StringBuilder("");
            string aRutaDDA = "";
            string aRutaResultado = @"C:\Compacw\Empresas\FAC_Pruebas\Doctos\Timbrados\";
            string aPass = "12345678a";
            string aRutaFormato = @"C:\Compacw\Empresas\Reportes\Facturacion\Plantilla_REP_1.htm";

            MGW_SDK_F.lError = MGW_SDK_F.fInicializaLicenseInfo(1);
            Console.WriteLine("leer licencia : " + MGW_SDK_F.lError + " Descripción : " + MGW_SDK_F.lError);
            int lError = MGW_SDK_F.fTimbraComplementoPagoXML(aRutaXML, aCodConcepto, aUUID, aRutaDDA, aRutaResultado, aPass, aRutaFormato);

            if (lError != 0)
            {
                Console.WriteLine("Timbrado Error : " + lError);
                Console.Read();
                Console.WriteLine("Descripción : " + MGW_SDK_F.fErrorDescripcion(lError));
                Console.Read();
            }
            else
            {
                Console.WriteLine("XML Timbrado en : " + aRutaResultado);
                Console.WriteLine("UUID : " + aUUID);
            }
        }


        #endregion

        #region COMPLEMENTOXML
        private static void TimbrarXMLconComplemento()
        {
            //Variables que irán como parametro
            string aRutaXML = @"C:\Compacw\Empresas\FAC_Pruebas\Doctos\DoctosPruebas\sinTFD_complemento.xml";
            string aCodConcepto = "FCCE";
            StringBuilder aUUID = new StringBuilder("");
            string aRutaDDA = "";
            string aRutaResultado = @"C:\Compacw\Empresas\FAC_Pruebas\Doctos\Timbrados\";
            string aPass = "12345678a";
            string aRutaFormato = @"C:\Compacw\Empresas\Reportes\Facturacion\Plantilla_REP_1.htm";

            MGW_SDK_F.lError = MGW_SDK_F.fInicializaLicenseInfo(1);
            Console.WriteLine("leer licencia : " + MGW_SDK_F.lError + " Descripción : " + MGW_SDK_F.lError);
            int lError = MGW_SDK_F.fTimbraComplementoXML(aRutaXML, aCodConcepto, aUUID, aRutaDDA, aRutaResultado, aPass, aRutaFormato,2);

            if (lError != 0)
            {
                Console.WriteLine("Timbrado Error : " + lError);
                Console.Read();
                Console.WriteLine("Descripción : " + MGW_SDK_F.fErrorDescripcion(lError));
                Console.Read();
            }
            else
            {
                Console.WriteLine("XML Timbrado en : " + aRutaResultado);
                Console.WriteLine("UUID : " + aUUID);
            }
        }
        #endregion

        #region XML
        private static void TimbrarXML()
        {
            //Variables que irán como parametro
            string aRutaXML = @"C:\Compacw\Empresas\FAC_Pruebas\Doctos\DoctosPruebas\F33.xml";
            string aCodConcepto = "F4";
            string aUUID = "";
            string aRutaDDA = "";//@"C:\Compacw\Empresas\FAC_Pruebas\Doctos\DDA\vacio.DDA";
            string aRutaResultado = @"C:\Compacw\Empresas\FAC_Pruebas\Doctos\Timbrados\";
            string aPass = "12345678a";
            string aRutaFormato = @"C:\Compacw\Empresas\Reportes\Facturacion\Plantilla_REP_1.htm";

            MGW_SDK_F.lError = MGW_SDK_F.fInicializaLicenseInfo(1);
            Console.WriteLine("leer licencia : " + MGW_SDK_F.lError + " Descripción : " + MGW_SDK_F.lError);
            MGW_SDK_F.lError = MGW_SDK_F.fTimbraXML(aRutaXML, aCodConcepto, ref aUUID, aRutaDDA, aRutaResultado, aPass, aRutaFormato);

            if (MGW_SDK_F.lError != 0)
            {
                Console.WriteLine("Timbrado Error : " + MGW_SDK_F.lError);
                Console.WriteLine("Descripción : " + MGW_SDK_F.fErrorDescripcion(MGW_SDK_F.lError));
            }
            else
            {
                Console.WriteLine("XML Timbrado en : " + aRutaResultado);
                Console.WriteLine("UUID : " + aUUID);
            }
        }

        #endregion


        #endregion

        #endregion

        #region FUNCIONES NECESARIAS PARA SDK

        #region INICIALIZAR SISTEMA
        public void InicializarSDK()
        {
            fAbreSDK();
            AbrirEmpresa();
        }
        #endregion

        #region INICIAR CONEXIÓN SDK
        private void IniciaConexionSDK()
        {
            MGW_SDK_F.lError = MGW_SDK_F.SetCurrentDirectory(rutaBinarios);//validamos que exista el directorio
            Console.WriteLine("Leer binarios" + MGW_SDK_F.lError);
            MGW_SDK_F.lError = MGW_SDK_F.fSetNombrePAQ(sistema);//verificamos que no exista error
            Console.WriteLine("Leer sistema" + MGW_SDK_F.lError);
            if (MGW_SDK_F.lError != 0)//si no hay un error imprimimos problema, numero de error y la descripción del código de error
            {
                Console.WriteLine("------------------------- No se puedo iniciar conexión sdk -----------------------------");
                Console.WriteLine("Error : " + MGW_SDK_F.lError);
                DescripcionError(MGW_SDK_F.lError);
            }
        }

        public static void fAbreSDK()
        {

            //int iSistema; // 0 = AdminPAQ, 1 = CONTPAQ i FACTURA ELECTRÓNICA, 2 = CONTPAQ i COMERCIAL
            string szRegKeySistema = "SOFTWARE\\Computación en Acción, SA CV\\CONTPAQ I Facturacion";
            string sNombrePAQ = "CONTPAQ I Facturacion";

            UIntPtr HKEY_LOCAL_MACHINE = new UIntPtr(0x80000002u);
            UIntPtr hRegKey;
            StringBuilder sNombreEmpresa = new StringBuilder(255);
            StringBuilder sDirectorioEmpresa = new StringBuilder(255);

            // Abrimos la sección de AdminPAQ en el registry
            MGW_SDK_F.lError = MGW_SDK_F.RegOpenKeyEx(HKEY_LOCAL_MACHINE, szRegKeySistema, 0, 1, out hRegKey);
            if (MGW_SDK_F.lError != 0)
            {
                Console.WriteLine("Error al abrir el Registry");
            }


            // Leemos el directorio Base archivos de programa\compacw\adminpaq
            uint pvSize = 1024;
            StringBuilder lEntrada = new System.Text.StringBuilder(1024);
            uint pdwType = 0;

            MGW_SDK_F.lError = MGW_SDK_F.RegQueryValueEx(hRegKey, "DirectorioBase", 0, out pdwType, lEntrada, ref pvSize);

            if (MGW_SDK_F.lError != 0)
            {
                MGW_SDK_F.lError = MGW_SDK_F.RegCloseKey(hRegKey);
            }

            // SetCurrentDirectory
            MGW_SDK_F.lError = MGW_SDK_F.SetCurrentDirectory(lEntrada.ToString());
            MGW_SDK_F.fSetNombrePAQ(sNombrePAQ);

        }
        #endregion

        #region ABRIR EMPRESA
        private void AbrirEmpresa()
        {
            MGW_SDK_F.lError = MGW_SDK_F.fAbreEmpresa(rutaEmpresas + empresa);
            if (MGW_SDK_F.lError != 0)
            {
                Console.WriteLine("----------------- Error al Abrir Empresa ---------------");
                Console.WriteLine("Empresa : " + empresa);
                Console.WriteLine(" Error : " + MGW_SDK_F.lError);
                DescripcionError(MGW_SDK_F.lError);
            }
            else
            {
                Console.WriteLine(" Empresa Cargada ");
            }
        }
        #endregion

        #region CERRAR CONEXIÓN SDK
        private void CerrarConexionSDK()
        {

        }
        #endregion

        #region CERRAR EMPRESA
        private void CerrarEmpresa()
        {
            MGW_SDK_F.fCierraEmpresa();
        }
        #endregion

        #endregion

        #region FUNCIONES PARA ERRORES

        #region DESCRIPCIÓN DEL ERROR
        private static void DescripcionError(int iError)
        {
            StringBuilder sMensaje = new StringBuilder(512);

            if (iError != 0)
            {
                MGW_SDK_F.fError(iError, sMensaje, 512);
                Console.WriteLine("Descripción : " + sMensaje);
            }
        }
        #endregion

        #endregion

        #region FUNCIONES DE CATALOGOS

        #region UNIDADES DE MEDIDA

        //alta de unidad de medida
        private void NuevaUnidadVenta()
        {   //creamos la estructura de unidad
            MGW_SDK_F.tUnidad Unidad = new MGW_SDK_F.tUnidad();
            //asignamos valores a las variables disponibles
            int idUnidad = 0;
            Unidad.cAbreviatura = "kg";
            Unidad.cNombreUnidad = "Kilo";
            Unidad.cDespliegue = "kg";
            //damos de alta la unidad
            MGW_SDK_F.lError = MGW_SDK_F.fAltaUnidad(ref idUnidad, ref Unidad);
            //en caso de que todo este correcto nos retornara un 0
            if (MGW_SDK_F.lError == 0)
            {
                //Para poder asignar una clave SAT es necesario editar la unidad ya que por defecto
                //// no existe una variable en la estructura para este dato, los campos correspondientes son:
                ///cCLAVEINT = clave SAT Anexo 20        cClaveSAT = clave sat para CCE

                //buscamos la unidad a editar, recibe cmo parametro el ID
                MGW_SDK_F.fBuscaIdUnidad(idUnidad);
                //Deamos la unidad en uso para edición
                MGW_SDK_F.fEditaUnidad();
                //Asignamo el valor en los campos necesarios
                //recibe campo de la BDD, valor del campo que se asignara
                MGW_SDK_F.fSetDatoUnidad("cCLAVEINT", "E4");
                MGW_SDK_F.fSetDatoUnidad("cClaveSAT", "E4");
                //Guardamos cambios
                MGW_SDK_F.lError = MGW_SDK_F.fGuardaUnidad();

                if (MGW_SDK_F.lError == 0)
                {
                    Console.WriteLine("Unidad agregada.");
                }
            }
        }

        #endregion

        #region PRODUCTO
        private void NuevoServicio()
        {
            //creamos la estructura de producto
            MGW_SDK_F.tProducto Producto = new MGW_SDK_F.tProducto();
            //asignamos valores a las variables disponibles
            //solo el nombre y el codigo son obligatorios
            //puedes asignar cualquier variable que se encuentre en la estructura de producto.
            //Recordar que Factura electronica solo trabaja con servicios por lo que para este caso tambien es neceario indicar que es de tipo servicio
            int idProducto = 0;
            Producto.cCodigoProducto = "pruebaSDKfac";
            Producto.cNombreProducto = "pruebaSDKfac";
            Producto.cTipoProducto = 3;
            //damos de alta el producto
            MGW_SDK_F.lError = MGW_SDK_F.fAltaProducto(ref idProducto, ref Producto);
            //en caso de que todo este correcto nos retornara un 0
            if (MGW_SDK_F.lError == 0)
            {
                //Para poder asignar una clave SAT es necesario editar el prducto ya que por defecto
                //// no existe una variable en la estructura para este dato, los campos correspondientes son:
                ///cCLAVEINT = clave SAT Anexo 20        cClaveSAT = clave sat para CCE

                //buscamos el producto a editar, recibe cmo parametro el ID
                MGW_SDK_F.fBuscaIdProducto(idProducto);
                Console.WriteLine(MGW_SDK_F.lError);
                //dejamos el producto en uso para edición
                MGW_SDK_F.fEditaProducto();
                Console.WriteLine(MGW_SDK_F.lError);
                //Asignamo el valor en los campos necesarios
                //recibe campo de la BDD, valor del campo que se asignara
                MGW_SDK_F.fSetDatoProducto("cclavesat", "81111500");
                Console.WriteLine(MGW_SDK_F.lError);
                //Guardamos cambios
                MGW_SDK_F.lError = MGW_SDK_F.fGuardaProducto();

                if (MGW_SDK_F.lError == 0)
                {
                    Console.WriteLine("producto agregado.");
                }
            }
            else
            {
                Console.WriteLine(MGW_SDK_F.lError);
                Console.WriteLine( MGW_SDK_F.fErrorDescripcion( MGW_SDK_F.lError));
            }
        }
        #endregion

        #region CLIENTES/BROVEEDORES


        #region ALTA / REGISTRO
        private void NuevoClienteProveedor()
        {
            MGW_SDK_F.tCteProv Cliente = new MGW_SDK_F.tCteProv();

            Cliente.cCodigoCliente = "PGEN";
            Cliente.cRazonSocial = "PUBLICO EN GENERAL";
            Cliente.cRFC = "XAXX010101000";
            Cliente.cTipoCliente = 2; //1 = cliente, 2 = cliente/proveedor, 3 = proveedor

            int aIdCliente = 0;

            MGW_SDK_F.lError = MGW_SDK_F.fAltaCteProv( ref aIdCliente, ref Cliente);

        }
        
        #endregion


        #endregion

        #region DIRECCIONES


        #region ALTA / REGISTRO

        #endregion

        #endregion

        #endregion

        #region FUNCIONES DE DOCUMENTOS

        #region NUEVO DOCUMENTO
        private static void NuevoDocumento(int Numdoc)
        {
            MGW_SDK_F.tDocumento Documento = new MGW_SDK_F.tDocumento();

            StringBuilder serie = new StringBuilder("");
            string concepto = "FPRUEBA3.3";  //F4 = Factura v4.0   FPRUEBA3.3 = factura v3.3
            double folio = 0;
            Documento.aNumMoneda = 1;
            Documento.aTipoCambio = 0;
            Documento.aImporte = 1000;
            Documento.aDescuentoDoc1 = 0;
            Documento.aDescuentoDoc2 = 0;
            Documento.aSistemaOrigen = 202;
            /* Numero de sistema Origen
             *  205 = CONTPAQi® Comercial Premium.
                101 = CONTPAQi® Punto de venta.
                202 = CONTPAQi® Factura electrónica.
            */
            Documento.aCodConcepto = concepto;
            Documento.aSerie = serie + "";
            Documento.aFecha = DateTime.Now.ToString("MM/dd/yyyy");
            Documento.aCodigoCteProv = "CTEPESO";
            Documento.aCodigoAgente = "";
            Documento.aReferencia = "";
            Documento.aAfecta = 0;
            Documento.aGasto1 = 0;
            Documento.aGasto2 = 0;
            Documento.aGasto3 = 0;
            MGW_SDK_F.fSiguienteFolio(concepto, serie, ref folio);


            int idDocumento = 0;
            MGW_SDK_F.lError = MGW_SDK_F.fAltaDocumento(ref idDocumento, ref Documento);
            if (MGW_SDK_F.lError == 0)
            {
                //MessageBox.Show(MGWServicios.rError(codigoDeError) + " documento ");

                MGW_SDK_F.lError = NuevoMovimiento(idDocumento);
                if (MGW_SDK_F.lError == 0)
                {
                    Console.WriteLine("Documento creado"); ;
                }
                else
                {
                    Console.WriteLine("Error movimiento");
                    Console.WriteLine("" + MGW_SDK_F.fErrorDescripcion(MGW_SDK_F.lError));
                }
            }
            else
            {
                Console.WriteLine("Error documento");
                Console.WriteLine("" + MGW_SDK_F.fErrorDescripcion(MGW_SDK_F.lError));
            }

        }

        #endregion

        #region NUEVO MOVIMIENTO
        private static int NuevoMovimiento(int idDocumento)
        {
            int idMovimiento = 0;

            MGW_SDK_F.tMovimiento Movimiento = new MGW_SDK_F.tMovimiento();

            Movimiento.aConsecutivo = 1;
            Movimiento.aUnidades = 1;
            Movimiento.aPrecio = 1000;
            Movimiento.aCosto = 0;
            Movimiento.aCodProdSer = "S001";
            Movimiento.aCodAlmacen = "ALM003SDK";
            Movimiento.aReferencia = "";
            Movimiento.aCodClasificacion = "";

            return MGW_SDK_F.fAltaMovimiento(idDocumento, ref idMovimiento, ref Movimiento);
        }

        #endregion

        #region NUEVO PAGO/NOTA CREDITO
        private static void NuevoDocumentoAbono()
        {   //Este codigo funciona para cualquier documento de tipo ABONO ya sean pagos y/o notas de credifo por ejemplo.


            MGW_SDK_F.tDocumento DoctoAbono = new MGW_SDK_F.tDocumento(); //Creamos un Struc Documento para utilizar
            //asignamos los valores necesarios a las variables del documento de cargo/abono
            DoctoAbono.aCodConcepto = "PC001";
            DoctoAbono.aFolio = 28;//Folio del pago
            DoctoAbono.aSerie = "";//serie del pago
            DoctoAbono.aFecha = DateTime.Today.ToString("MM/dd/yyyy");//Fecha del pago
            DoctoAbono.aCodigoCteProv = "CLL001";//codigo del cliente/proveedor que abona
            DoctoAbono.aNumMoneda = 1;//1 =  MXN, 2 = USD
            DoctoAbono.aTipoCambio = 1;//tipo de cambio
            DoctoAbono.aImporte = 120;//importe del Pago
            DoctoAbono.aReferencia = "Pago Generado por SDK";//Referencia del pago

            //Ralizamos el Alta del nuevo Documento de cargo/abono
            MGW_SDK_F.lError = MGW_SDK_F.fAltaDocumentoCargoAbono(ref DoctoAbono);
            if (MGW_SDK_F.lError != 0) //si no se dio de alta el pago mostramos la causa 
            {
                Console.WriteLine("se genero el siguiente error: " + MGW_SDK_F.fErrorDescripcion(MGW_SDK_F.lError));
            }
            else
            {
                //una vez que se confirma el alta del pago/o nota de credito continuamos agregando los datos referentes al pago
                MGW_SDK_F.fEditarDocumento();//abrimos el documento para edición
                //Estas ediciones son de Bajo nivel por lo que se aplican en los campos de la base de datos que se le indique
                MGW_SDK_F.fErrorDescripcion(MGW_SDK_F.lError = MGW_SDK_F.fSetDatoDocumento("CMETODOPAG", "01")); //METODO DE PAGO
                MGW_SDK_F.fErrorDescripcion(MGW_SDK_F.lError = MGW_SDK_F.fSetDatoDocumento("CCANTPARCI", "1"));//CANTIDAD DE PARCIALIDADES
                MGW_SDK_F.fErrorDescripcion(MGW_SDK_F.lError = MGW_SDK_F.fSetDatoDocumento("CNUMPARCIA", "1"));//NUMERO DE PARCIALIDAD

                MGW_SDK_F.fErrorDescripcion(MGW_SDK_F.lError = MGW_SDK_F.fSetDatoDocumento("CUSUBAN03", "17:10:00"));//Nombre del usuario de CONTPAQi® Bancos 
                /* que tiene el tercer permiso de autorización para pagar CFDI. Varchar: 20 caracteres.
                */
                MGW_SDK_F.fErrorDescripcion(MGW_SDK_F.lError = MGW_SDK_F.fSetDatoDocumento("CIDMONEDCA", "1"));//ID DE TIPO DE MONEDA, 1 = MXN, 2 = USD
                //guardamos el documento con las ediciones echas
                MGW_SDK_F.fErrorDescripcion(MGW_SDK_F.lError = MGW_SDK_F.fGuardaDocumento());



                //A partir de esta linea de codigo lo demás corresponde a los documentos a saldar
                //para este ejemplo solo será uno, en caso de que sean mas se deberá ejecutar de manera recurrente
                //con los datos de todos los documentos a saldar según sea el caso.



                //generamos una nueva llave para localizar el documento a saldar (CARGO).
                MGW_SDK_F.tLlaveDoc regDoctoSaldar = new MGW_SDK_F.tLlaveDoc();
                //asignamos los valores de busqueda para el documento a saldar.
                regDoctoSaldar.aCodConcepto = "FPRUEBA3.3"; //codigo de concepto
                regDoctoSaldar.aSerie = ""; //Serie del documento
                regDoctoSaldar.aFolio = 1;//Folio del documento

                //generamos una nueva llave para localizar el documento de Abono con el cual se va a saldar, en este ejemplo es el mismo que se acaba de generar
                MGW_SDK_F.tLlaveDoc regDoctoAbono = new MGW_SDK_F.tLlaveDoc();
                //asignamos los valores de busqueda para el documento de Abono.
                regDoctoAbono.aCodConcepto = DoctoAbono.aCodConcepto; //codigo de concepto
                regDoctoAbono.aSerie = DoctoAbono.aSerie; //Serie del documento
                regDoctoAbono.aFolio = DoctoAbono.aFolio;//Folio del documento


                //también se pasa el valor del importe a pagar, se puede pagar el total del documento o solo una parte en caso de que el abono salde mas de un documento
                double ImportePagar = 100;
                //Moneda con la cual se registrara el abono, 1=MXN, 2=USD
                int idMoneda = 1;
                //por ultimo se pasa el valor de la fecha en el que se hace el abono
                string fechaAbono = DateTime.Now.ToString("MM/dd/yyyy");
                //relizamos el registro del pago en la tabla asocCargoAbono para relacionar el abono al documentode cargo pasando como referencia el abono y el cargo
                MGW_SDK_F.lError = MGW_SDK_F.fSaldarDocumento( regDoctoSaldar,  regDoctoAbono, ImportePagar, idMoneda, fechaAbono);

                if (MGW_SDK_F.lError != 0)

                {
                    Console.WriteLine("se genero un error " + MGW_SDK_F.fErrorDescripcion(MGW_SDK_F.lError));
                }
                else
                {
                    Console.WriteLine("Abono generado y relacionado ");
                }
            }
        }
        #endregion

        #region NUEVA NOTA DE CREDITO
        static private void NotaCreditoIVA()
        {
            MGW_SDK_F.tDocumento NotaCredito = new MGW_SDK_F.tDocumento(); //Creamos un Struc Documento para utilizar
            //asignamos los valores necesarios a las variables del documento de cargo/abono
            NotaCredito.aCodConcepto = "NT2";
            NotaCredito.aFolio = 10;//Folio de la nota de credito
            NotaCredito.aSerie = "";//serie de la nota de credito
            NotaCredito.aFecha = DateTime.Today.ToString("MM/dd/yyyy");//Fecha de la nota de credito
            NotaCredito.aCodigoCteProv = "CLL001";//codigo del cliente/proveedor que abona
            NotaCredito.aNumMoneda = 1;//1 =  MXN, 2 = USD
            NotaCredito.aTipoCambio = 1;//tipo de cambio
            NotaCredito.aImporte = 200.0;//importe NETO de la nota de credito
            NotaCredito.aReferencia = "Nota de credito por SDK";//Referencia de la nota de credito
            NotaCredito.aSistemaOrigen = 205;

            //Ralizamos el Alta del nuevo Documento de cargo/abono
            MGW_SDK_F.lError = MGW_SDK_F.fAltaDocumentoCargoAbono(ref NotaCredito);
            if (MGW_SDK_F.lError != 0) //si no se dio de alta de la nota de credito mostramos la causa 
            {
                Console.WriteLine("se genero el siguiente error: " + MGW_SDK_F.fErrorDescripcion(MGW_SDK_F.lError));
            }
            else
            {
                //una vez que se confirma el alta de la nota de credito habra que editar los campos que correspondan al impuesto
                MGW_SDK_F.fEditarDocumento();//abrimos el documento para edición
                //Estas ediciones son de Bajo nivel por lo que se aplican en los campos de la base de datos que se le indique
                MGW_SDK_F.fErrorDescripcion(MGW_SDK_F.lError = MGW_SDK_F.fSetDatoDocumento("CPORCENTAJEIMPUESTO1", "4")); //Porcentaje del impuesto 1
                Console.WriteLine("cambios porcentaje " + MGW_SDK_F.fErrorDescripcion(MGW_SDK_F.lError));
                //MGWServicios.rError(codigoDeError = MGWServicios.fSetDatoDocumento("CIMPUESTO1", "8")); //importe del impuesto
                //MessageBox.Show("cambios impuesto " + MGWServicios.rError(codigoDeError));

                //guardamos el documento con las ediciones echas
                MGW_SDK_F.fErrorDescripcion(MGW_SDK_F.fGuardaDocumento());
                Console.WriteLine("Documento generado con éxito" + MGW_SDK_F.fErrorDescripcion(MGW_SDK_F.lError));
            }
            //MessageBox.Show(MGWServicios.rError( NuevoMovimiento( idDocumento )) + " movimiento ");
        }

        #endregion

        #region EDITAR REGIMEN DE UN DOCUMENTO
        private static void EditarRegimen()
        {
            #region Variables 
            //DOCUMENTO
            StringBuilder cidDocumento = new StringBuilder("");
            string aCodConcepto = "F4";//codigo de concepto del documento
            string aSerie = "";//serie del documento
            string aFolio = "20";//folio del documento
            int aLong = 76;//longitud de caracteres que se van a leer.
            #endregion

            #region BUSCAR DOCUMENTO
            //Realizamos la busqueda del documento, esto mediante Concepto, Serie, Folio, debes ser todos string 
            MGW_SDK_F.lError = MGW_SDK_F.fBuscarDocumento(aCodConcepto, aSerie, aFolio);
            if (MGW_SDK_F.lError == 0)
            {
                MGW_SDK_F.lError = MGW_SDK_F.fEditarDocumento();
                Console.WriteLine("Editando: "+ MGW_SDK_F.lError);
                MGW_SDK_F.lError = MGW_SDK_F.fSetDatoDocumento("CDESCAUT03", "601");// es el nombre del campo que lleva el tipo de regimen del documento, 601 el valor que se le dará
                Console.WriteLine("Campos asignados: " + MGW_SDK_F.lError);
                Console.WriteLine("Campos asignados: " + MGW_SDK_F.fErrorDescripcion( MGW_SDK_F.lError));
                MGW_SDK_F.lError = MGW_SDK_F.fGuardaDocumento();
                Console.WriteLine("Guardado: " + MGW_SDK_F.lError);
            }
            else
            {
                Console.WriteLine("Error al buscar documento");
            }
            #endregion
        }
        #endregion

        #region RELACIONAR DOCUMENTO POR UUID
        private static void RelacionarDocumentoUUID()
        {
            //variales que se mandaran como parametro de la relación
            string aCodigoConcepto = "F4";
            string aSerie = "R";
            string aFolio = "12";
            string aTipoRelacion = "02";
            string aUUIDrelacionar = "48857287-D639-4326-8FB4-9E723226A457";//UUID que se asignara como relación
            //mandamos los datos a relacionar
            MGW_SDK_F.lError = MGW_SDK_F.fAgregarRelacionCFDI2(aCodigoConcepto,  aSerie,  aFolio,  aTipoRelacion, aUUIDrelacionar);
            if (MGW_SDK_F.lError == 0)
            {
                Console.WriteLine("Relación asignada");
            }else
            {
                Console.WriteLine("No se pudo asignar la relación");
                Console.WriteLine("Error: " + MGW_SDK_F.lError + " Descripcion: "+MGW_SDK_F.fErrorDescripcion(MGW_SDK_F.lError));
            }
        }
        #endregion


        #endregion

        #region TRABAJO DEL SISTEMA
        public void TrabajarSistema()
        {
            TimbrarXMLconComplemento();
            Console.Read();
            CerrarEmpresa();
        }
        #endregion
    }
}
