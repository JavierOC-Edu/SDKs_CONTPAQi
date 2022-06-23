using SDKCONTPAQNGLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConexiónSDKComercial
{
    class InterfazConexionSDK
    {
        #region CONSTANTES COMERCIALES
        static int codigoDeError = 0;
        static StringBuilder sMensaje = new StringBuilder(512);//variable para mostrar el error
        static string sistema = "CONTPAQ I COMERCIAL";//nombre del sistema
        static string ruta = @"C:\Program Files (x86)\Compac\COMERCIAL\";//ubicación de los binarios
        public static string directorioEmpresa = @"C:\Compac\Empresas\adSDKPruebas";
        static int empresaComercialAbierta = 0;
        #endregion

        #region INICIAR CONEXION SDK COMERIAL - INICIA INTERFAZ CONTABLE
        public static void IniciarConexionSDK(ref ListView listVListaEmpresa)
        {//metodo para iniciar una conexión de SDK
            codigoDeError = 0;//se inicializa el error
            MGWServicios.SetCurrentDirectory(ruta);//validamos que exista el directorio
            if (codigoDeError != 0)//si no hay un error retornamos el mensaje
            {
                Console.WriteLine("error e ruta");
            }
            codigoDeError = MGWServicios.fSetNombrePAQ(sistema);//verificamos que no exista error

            if (codigoDeError != 0)//si no hay un error retornamos el mensaje
            {
                MGWServicios.fError(codigoDeError, sMensaje, 512);
                MessageBox.Show(sMensaje.ToString(), "Error de conexión", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else
            {
                Console.WriteLine("conexión exitosa de SDK Comercial");
                //llenamos el listado de empresas
                LeerListaDeEmpresas(listVListaEmpresa);
                //MessageBox.Show("Conexión exitosa");

            }
        }
        #endregion

        #region DETENER CONEXION SDKCOMERCIAL
        public static void DetenerConexionSDK()
        {//metodo para detenet una conexion de SDK
            MGWServicios.fTerminaSDK();
        }
        #endregion

        #region OTHERS 2
        private static void LeerListaDeEmpresas(ListView listVListaEmpresa)
        {//Metodo para ller el listado de empresas
            //variables para almacenar los nombres de empresas
            int idEmpresa = 0;//id de la empresa
            StringBuilder nombreEmpresa = new StringBuilder(255);//nombre de la empresa
            StringBuilder urlEmpresa = new StringBuilder(255);//direción de la empresa

            //inicializamos el codigo de error 
            codigoDeError = 0;
            listVListaEmpresa.Items.Clear();

            do
            {
                //almacenamos el codigo de eror
                codigoDeError = MGWServicios.fPosSiguienteEmpresa(ref idEmpresa, nombreEmpresa, urlEmpresa);
                if (codigoDeError != 0)
                {
                    break;
                }
                //creamos un item y le asignamos el nombre de la empresa
                ListViewItem empresa = new ListViewItem(nombreEmpresa.ToString());
                //asignamos la dirección de la empresa en eun subitem
                empresa.SubItems.Add(urlEmpresa.ToString());
                //agregamos el item al listview que se recibe
                listVListaEmpresa.Items.Add(empresa);
            } while (codigoDeError == 0);
        }
        #endregion

        #region ABRIR EMPRESA COMERCIAL
        public static void AbrirEmpresa(string directorio)
        {//sistema = 1 comercial 2 contabilidad

            codigoDeError = MGWServicios.fAbreEmpresa(directorio);
            if (codigoDeError != 0)
            {
                MessageBox.Show(sMensaje.ToString(), "Error al abrir empresa", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            }
            else
            {
                empresaComercialAbierta = 1;
                Console.WriteLine("Empresa Abierta");
                //MessageBox.Show("Cargando Empresa");
                directorioEmpresa = directorio;
            }
        }
        #endregion

        #region CERRAR EMPRESA COMERCIAL
        public static void CerrarEmpresa()
        {
            MGWServicios.fCierraEmpresa();
            empresaComercialAbierta = 0;
        }
        #endregion

        #region NUEVO DOCUMENTO EDITANDDO MOVIMIENTO
        //proceso con estructuras de documento y movimiento
        public static void NuevoDocumentoEditaMovi()
        {
            //Se genera la estructura de documento
            MGWServicios.tDocumento Documento = new MGWServicios.tDocumento();
            //se asignan valores a las variables del documento
            Documento.aFolio = 55;
            Documento.aNumMoneda = 2;
            Documento.aTipoCambio = 19.34;
            Documento.aImporte = 300;
            Documento.aDescuentoDoc1 = 0;
            Documento.aDescuentoDoc2 = 0;
            Documento.aSistemaOrigen = 205;
            /* Numero de sistema Origen
             *  205 = CONTPAQi® Comercial Premium.
                101 = CONTPAQi® Punto de venta.
                202 = CONTPAQi® Factura electrónica.
            */
            Documento.aCodConcepto = "1";//CODIGO DEL CONCEPTO 
            Documento.aSerie = "";
            Documento.aFecha = DateTime.Now.ToString("MM/dd/yyyy");
            Documento.aCodigoCteProv = "CLL001";//codigo del cliente proveedor
            Documento.aCodigoAgente = "";
            Documento.aReferencia = "PRUEBA DESDE SDK";//referencia del documento
            Documento.aAfecta = 0;
            Documento.aGasto1 = 0;
            Documento.aGasto2 = 0;
            Documento.aGasto3 = 0;
           

            int idDocumento = 0;
            //se da de alta el documento
            codigoDeError = MGWServicios.fAltaDocumento(ref idDocumento, ref Documento);
            MessageBox.Show(MGWServicios.rError(codigoDeError) + " documento ");
            //si no existen errores continuamos con el proceso de registro de los movimientos que llevara y la insersión de las observaciones a nivel movimiento
            if (codigoDeError == 0)
            {
                #region OBSERVACION A NIVEL MOVIMIENTO
                //Realizamos la busqueda del documento, esto mediante Concepto, Serie, Folio, debes ser todos string por lo que se cartea el folio
                MGWServicios.fBuscarDocumento( Documento.aCodConcepto, Documento.aSerie, Documento.aFolio+"");
                //si se localiza el documento continuamos
                if (codigoDeError == 0)
                {
                    //abrimos el doc para edición
                    MGWServicios.fEditarDocumento();
                    //realizamos los cambios
                    MGWServicios.fSetDatoDocumento("COBSERVACIONES","PRUEBA DESDE SDK");
                    MGWServicios.fSetDatoDocumento("CMENSAJERIA", "MENSAJERIA DESDE SDK");
                    //guardamos los cambios echos
                    MGWServicios.fGuardaDocumento();
                }
                #endregion

                #region MOVIMIENTOS DEL DOCUMENTO
                int idMovimiento = 0;
                //se genera estructura de movimiento
                MGWServicios.tMovimiento Movimiento = new MGWServicios.tMovimiento();

                Movimiento.aCodAlmacen = "ALM003SDK";//codigo del almacen de donde se tomara el producto
                Movimiento.aCodClasificacion = "";
                Movimiento.aCodProdSer = "SDK";//codigo del producto/servicio
                Movimiento.aConsecutivo = 1;//numero/posición del movimiento
                Movimiento.aCosto = 40;//costo del producto
                Movimiento.aPrecio = 50;//precio del producto
                Movimiento.aReferencia = "Ref SDK";
                Movimiento.aUnidades = 1;//numero de unidades 

                //se da de alta el movimiento dentro del documento
                codigoDeError = MGWServicios.fAltaMovimiento(idDocumento, ref idMovimiento, ref Movimiento);
                //si el movimiento se registro sin problema lo editaremos para agregar las observaciones
                if (codigoDeError == 0)
                {   //se busca mediante el ID del movimiento
                    MGWServicios.fBuscarIdMovimiento(idMovimiento);
                    //Abrimos sesión para edición
                    MGWServicios.fEditarMovimiento();
                    //modificamos los valores, en este caso la observacion
                    MGWServicios.fSetDatoMovimiento("COBSERVAMOV", "PRUEBA DESDE SDK");
                    //Guardamos los cambios
                    MGWServicios.fGuardaMovimiento();
                }
                #endregion

            }
        }
        #endregion

        #region NUEVA COTIZACION EDICION BAJO NIVEL
        public static void CotizacionEditBajoN()
        {   //Variables locales, nos ayudaran a manipular mejor el documento
            double folio = 0;
            StringBuilder serie = new StringBuilder("");
            int idDocto = 0;
            string codConcepto = "1";
            //funcion para detectar el folio que asignaremos (no es necesaria pero se usa para agilizar)
            MGWServicios.fSiguienteFolio(codConcepto, serie, ref folio);
            //generamos struct de documentos
            MGWServicios.tDocumento documento = new MGWServicios.tDocumento();
            //capturamos los valores a las distintas  variables de nuentro struc documento
            documento.aCodConcepto = codConcepto;
            documento.aFolio = folio;
            documento.aSerie = "";
            documento.aImporte = 2;
            documento.aAfecta = 1;
            documento.aCodigoCteProv = "CLSDK";
            documento.aFecha = DateTime.Today.ToString("MM/dd/yyyy");
            //damos de alta el nuevo documento en la BDD/Sistema
            codigoDeError = MGWServicios.fAltaDocumento(ref idDocto, ref documento);
            if (codigoDeError != 0)
            {
                Console.WriteLine("Error en Alta del documento: " + MGWServicios.rError(codigoDeError));
            }
            else
            {   //Se abre el puntero de edición en el documento actual (documento recien registrado)
                codigoDeError = MGWServicios.fEditarDocumento();
                //comenzamos con las ediciones de bajo nivel
                //la función fSetDatoDocumento editara en la base de datos
                //el campo que se pase como primer parametro y asignara el valor que se envie como segundo parametro
                //se pueden consultar los campos en el documento Estructura de la BDD
                codigoDeError = MGWServicios.fSetDatoDocumento("CREFERENCIA", "REF SDK");
                codigoDeError = MGWServicios.fSetDatoDocumento("COBSERVACIONES", "OBSERVACIONES DOCTO");

                //Pestaña Envio
                codigoDeError = MGWServicios.fSetDatoDocumento("CDESTINATARIO", "DESTINATARIO SDK");
                codigoDeError = MGWServicios.fSetDatoDocumento("CNUMEROGUIA", "NUM GUIA SDK");
                codigoDeError = MGWServicios.fSetDatoDocumento("CMENSAJERIA", "MENSAJERIA SDK");
                codigoDeError = MGWServicios.fSetDatoDocumento("CCUENTAMENSAJERIA", "CUENTA MENSAJERIA SDK");
                codigoDeError = MGWServicios.fSetDatoDocumento("CNUMEROCAJAS", "521.00");
                codigoDeError = MGWServicios.fSetDatoDocumento("CPESO", "111.00");

                //Pestaña Usuario
                codigoDeError = MGWServicios.fSetDatoDocumento("CTEXTOEXTRA1", "Extra SDK 1");
                codigoDeError = MGWServicios.fSetDatoDocumento("CTEXTOEXTRA2", "Extra SDK 2");
                codigoDeError = MGWServicios.fSetDatoDocumento("CTEXTOEXTRA2", "Extra SDK 3");
                codigoDeError = MGWServicios.fSetDatoDocumento("CFECHAEXTRA", DateTime.Today.ToString("MM/dd/yyyy"));
                codigoDeError = MGWServicios.fSetDatoDocumento("CIMPORTEEXTRA1", "10");
                codigoDeError = MGWServicios.fSetDatoDocumento("CIMPORTEEXTRA2", "20.00");
                codigoDeError = MGWServicios.fSetDatoDocumento("CIMPORTEEXTRA3", "30.00");
                codigoDeError = MGWServicios.fSetDatoDocumento("CIMPORTEEXTRA4", "40");
                codigoDeError = MGWServicios.fSetDatoDocumento("CIMPORTEEXTRA5", "50");
                //guardamos los cambios de edición realizados anteriormente
                codigoDeError = MGWServicios.fGuardaDocumento();
                if (codigoDeError != 0)
                {
                    Console.WriteLine("Error al guardar: " + MGWServicios.rError(codigoDeError) );
                }
                else
                {//si todo se guardo correctamente continuamos con la generación de movimientos de este documento
                    Console.WriteLine("Documento generado");
                    
                    int idMovimiento = 0;
                    #region MOVIMIENTOS DEL DOCUMENTO
                    //En caso de que el documento requiera más de un movimiento se deberá repetir
                    //la ejecución de esta región tantas veces como movimientos se requieran.

                    //se genera estructura de movimiento
                    MGWServicios.tMovimiento Movimiento = new MGWServicios.tMovimiento();
                    //Asignamos valores a las variables del Struc Movimiento
                    Movimiento.aCodAlmacen = "ALM003SDK";//codigo del almacen de donde se tomara el producto
                    Movimiento.aCodClasificacion = "";
                    Movimiento.aCodProdSer = "SDK";//codigo del producto/servicio
                    Movimiento.aConsecutivo = 1;//numero/posición del movimiento
                    Movimiento.aCosto = 40;//costo del producto
                    Movimiento.aPrecio = 50;//precio del producto
                    Movimiento.aReferencia = "Ref SDK";
                    Movimiento.aUnidades = 1;//numero de unidades 

                    //se da de alta el movimiento dentro del documento
                    codigoDeError = MGWServicios.fAltaMovimiento(idDocto, ref idMovimiento, ref Movimiento);
                    //si el movimiento se registro sin problema lo editaremos para agregar las observaciones
                    if (codigoDeError == 0)
                    {   //se busca mediante el ID del movimiento
                        MGWServicios.fBuscarIdMovimiento(idMovimiento);
                        //Abrimos sesión para edición
                        MGWServicios.fEditarMovimiento();
                        //modificamos los valores, en este caso la observacion
                        MGWServicios.fSetDatoMovimiento("COBSERVAMOV", "PRUEBA DESDE SDK");
                        MGWServicios.fSetDatoMovimiento("CREFERENCIA", "PRUEBA DESDE SDK"); 
                        //Guardamos los cambios
                        MGWServicios.fGuardaMovimiento();
                    }
                    #endregion
                }
            }
        }
        #endregion

        #region EDITAR DIRECCIÓN DE UN DOCUMENTO
        public static void EditarDireccion()
        {
            #region Variables 
            //CLIENTE
            StringBuilder aCodClienteProv = new StringBuilder("");
            StringBuilder idClienteProv = new StringBuilder("");
            //DIRECCION
            MGWServicios.tDireccion nDireccion = new MGWServicios.tDireccion();
            int idDirección = 0;
            int cTipoCatalogo = 3; //3 = documentos
            int cTipoDireccion = 1;//1 = envío ,  0 = fiscal
            StringBuilder cNombreCalle = new StringBuilder("");
            StringBuilder cNumeroExterior = new StringBuilder("");
            StringBuilder cColonia = new StringBuilder("");
            StringBuilder cCodigoPostal = new StringBuilder("");
            StringBuilder cCiudad = new StringBuilder("");
            StringBuilder cEstado = new StringBuilder("");
            StringBuilder cPaís = new StringBuilder("");
            StringBuilder cMunicipio = new StringBuilder("");
            //DOCUMENTO
            StringBuilder cidDocumento = new StringBuilder("");
            string aCodConcepto = "FPRUEBA3.3";//codigo de concepto del documento
            string aSerie = "";//serie del documento
            string aFolio = "62";//folio del documento
            int aLong = 76;//longitud de caracteres que se van a leer.
            #endregion

            #region BUSCAR DOCUMENTO
            //Realizamos la busqueda del documento, esto mediante Concepto, Serie, Folio, debes ser todos string 
            codigoDeError = MGWServicios.fBuscarDocumento(aCodConcepto, aSerie, aFolio);
            if (codigoDeError == 0)
            {   //tomaremos del documento encontrado el ID y el ID del cliente por que los necesitaremos mas adelante.
                codigoDeError = MGWServicios.fLeeDatoDocumento("CIDDOCUMENTO", cidDocumento, aLong);
                codigoDeError = MGWServicios.fLeeDatoDocumento("CIDCLIENTEPROVEEDOR", idClienteProv, aLong);
                Console.WriteLine("ID Doc: " + cidDocumento);
                Console.WriteLine("ID cliente: " + idClienteProv);
            }
            else
            {
                Console.WriteLine("Error al buscar documento");
            }
            #endregion

            #region BUSCAMOS EL CODIGO DEL CLIENTE
            //ya que solo conocemos el id por el documento
            codigoDeError = MGWServicios.fBuscaIdCteProv(Int32.Parse(idClienteProv+""));
            if (codigoDeError == 0)
            {
                MGWServicios.fLeeDatoCteProv("CCODIGOCLIENTE", aCodClienteProv, 76);
                Console.WriteLine("Codigo cliente: "+aCodClienteProv);
            }
            else
            {
                Console.WriteLine("Error al buscar cliente");
            }
            #endregion

            #region BUSCAR DIRECCIÓN DEL CLIENTE
            codigoDeError = MGWServicios.fBuscaDireccionCteProv( aCodClienteProv+"", byte.Parse(0+""));
            if (codigoDeError == 0)
            {
                ///*
                
                //si se encuentra la dirección fiscal se toman los datos de la misma
                codigoDeError = MGWServicios.fLeeDatoDireccion("CNOMBRECALLE", cNombreCalle, 60);
                codigoDeError = MGWServicios.fLeeDatoDireccion("CNUMEROEXTERIOR", cNumeroExterior, 60);
                codigoDeError = MGWServicios.fLeeDatoDireccion("CCOLONIA", cColonia, 60);
                codigoDeError = MGWServicios.fLeeDatoDireccion("CCODIGOPOSTAL", cCodigoPostal, 60);
                codigoDeError = MGWServicios.fLeeDatoDireccion("CCIUDAD", cCiudad, 60);
                codigoDeError = MGWServicios.fLeeDatoDireccion("CESTADO", cEstado, 60);
                codigoDeError = MGWServicios.fLeeDatoDireccion("CPAIS", cPaís, 60);
                codigoDeError = MGWServicios.fLeeDatoDireccion("CMUNICIPIO", cMunicipio, 60);
                //CTIPOCATALOGO
                StringBuilder tipoCat = new StringBuilder("3");
                codigoDeError = MGWServicios.fLeeDatoDireccion("CTIPOCATALOGO", tipoCat, 60);

                #region AGREGAR DIRECCIÓN
                //se genera una struct de dirección

                nDireccion.cNombreCalle = cNombreCalle+"";
                    nDireccion.cNumeroExterior = cNumeroExterior + "";
                    nDireccion.cColonia = cColonia + "";
                    nDireccion.cCodigoPostal = cCodigoPostal + "";
                    nDireccion.cCiudad = cCiudad + "";
                    nDireccion.cEstado = cEstado + "";
                    nDireccion.cPais = cPaís + "";
                    nDireccion.cMunicipio = cMunicipio + "";
                    #endregion

                    // Se da de alta la direccion
                    codigoDeError = MGWServicios.fAltaDireccion(ref idDirección, ref nDireccion);

                 

                    if(codigoDeError == 0)
                    {
                        Console.WriteLine("Alta exitosa");
                    // /*
                    MGWServicios.fEditaDireccion();
                    codigoDeError = MGWServicios.fSetDatoDireccion("CIDCATALOGO", cidDocumento + "");
                    codigoDeError = MGWServicios.fSetDatoDireccion("CTIPOCATALOGO", cTipoCatalogo + "");
                    codigoDeError = MGWServicios.fSetDatoDireccion("CTIPODIRECCION", cTipoDireccion + "");
                    MGWServicios.fGuardaDireccion();
                    // */
                //EDITAMOS LA DIRECCIÓN NUEVA PARA HACERLA DE DOCUMENTO
                // /*
            }
            else
            {
                Console.WriteLine("Error en el alta de direccion");
            }

            if (codigoDeError == 0)
            {
                Console.WriteLine("Edición exitosa");
            }
                //*/
                /*
                    MGWServicios.fEditaDireccion();
                    codigoDeError = MGWServicios.fSetDatoDireccion("CIDCATALOGO", cidDocumento + "");
                    codigoDeError = MGWServicios.fSetDatoDireccion("CTIPOCATALOGO", cTipoCatalogo + "");
                    codigoDeError = MGWServicios.fSetDatoDireccion("CTIPODIRECCION", cTipoDireccion + "");
                    MGWServicios.fGuardaDireccion();
                    if (codigoDeError == 0)
                    {
                        Console.WriteLine("Edición exitosa");
                    }
                */
            }
            else
            {
                Console.WriteLine("Error al buscar direccion");
            }
            
            #endregion
        }
        #endregion

        #region BUSCAR DIRECCION DE TRANSPORTISTA

        public static void BuscarDireccionTrasnportista(string CodigoAgente)
        {
            //buscamos el agente por su codigo
            codigoDeError = MGWServicios.fBuscaAgente(CodigoAgente);
            if(codigoDeError == 0)//si el agente es encontrado continuamos
            {
                //extraemos el ID del agente
                StringBuilder idAgente = new StringBuilder();
                codigoDeError = MGWServicios.fLeeDatoAgente("CIDAGENTE", idAgente, 100);
                if(codigoDeError == 0)//si se logro leer el ID del agente, continuamos
                {
                    //localizamos  ID de la ultima direccion registrada en la tabla correspondiente
                    MGWServicios.fPosUltimaDireccion();
                    StringBuilder IdUltDireccion = new StringBuilder("");
                    MGWServicios.fLeeDatoDireccion("CIDDIRECCION", IdUltDireccion, 100);
                    //Colocamos el puntero en la primera direccion de la tabla
                    MGWServicios.fPosPrimerDireccion();
                    //Utilizaremos unas variables para comparar IDs 
                    StringBuilder IdDireccionActual = new StringBuilder("");
                    StringBuilder tipoCatalogo = new StringBuilder("");
                    StringBuilder cidCatalogo = new StringBuilder("");
                    StringBuilder cidcatalogoTransportista = new StringBuilder("7");
                    StringBuilder cidTipoDirección = new StringBuilder("7"); //0 = fiscal, 1 = envío

                    //StringBuilder idAgenteSB = new StringBuilder(idAgente);

                    Console.WriteLine("CID ultima Dir : " + IdUltDireccion);
                    do
                    {
                        //Leemos CTIPOCATALOGO para verificar que sea = 7 que corresponde a Figura Trasnportista
                        MGWServicios.fLeeDatoDireccion("CTIPOCATALOGO", tipoCatalogo, 100);
                        //Console.WriteLine("CTIPOCATALOGO : " + tipoCatalogo);
                        if (tipoCatalogo.Equals(cidcatalogoTransportista))
                        {
                            //leemos CIDCATALOGO para comparar si corresponde al Agente que buscamos
                            MGWServicios.fLeeDatoDireccion("CIDCATALOGO", cidCatalogo, 100);
                            Console.WriteLine("CIDCATALOGO : " + cidCatalogo + " AGENTE : "+ idAgente);
                            if (cidCatalogo.Equals(idAgente))//verificamos que el CIDCATALOGO sea igual al IDAGENTE para confirmar que sea la direccion que buscamos
                            {//leemos los datos necesarios de la direccion
                                StringBuilder Calle = new StringBuilder("");
                                StringBuilder Numero = new StringBuilder("");
                                MGWServicios.fLeeDatoDireccion("CNOMBRECALLE", Calle, 100);
                                MGWServicios.fLeeDatoDireccion("CNUMEROEXTERIOR", Numero, 100);
                                Console.WriteLine(" Direccion : "+Calle+" "+Numero);
                            }
                        }

                        //verificamos que no estemos en la ultima direccion de la tabla
                        MGWServicios.fLeeDatoDireccion("CIDDIRECCION", IdDireccionActual, 100);
                        if ( IdDireccionActual.Equals(IdUltDireccion))
                        {
                            Console.WriteLine("ULTIMA DIRECCION");
                            break;
                        }
                        else
                        {
                            //Console.WriteLine(" ID Dir Actual : "+IdDireccionActual);
                            MGWServicios.fPosSiguienteDireccion();
                        }
                        
                    } while (true);
                }
                else
                {
                    Console.WriteLine("No se logro estraer el ID del Agente");
                }
            }
            else
            {
                Console.WriteLine("¡Agente no encontrado!");
            }
        }
        #endregion

        #region ASOCIAR UUID A DEVOLUCIÓN SOBRE COMPRA
        public static void DevolucionSobreCompraAsocUUID()
        {
            string concepto = "NC2021";
            string serie = "";
            int folio = 3;
            string CUUID = "00000000-7e6f-41c4-a6f9-a0e32ace9870";

            //Se genera la estructura de documento
            MGWServicios.tDocumento Documento = new MGWServicios.tDocumento();
            //se asignan valores a las variables del documento
            Documento.aFolio = folio;
            Documento.aNumMoneda = 2;
            Documento.aTipoCambio = 19.34;
            Documento.aImporte = 300;
            Documento.aCodConcepto = concepto;//CODIGO DEL CONCEPTO 
            Documento.aSerie = "";
            Documento.aFecha = DateTime.Now.ToString("MM/dd/yyyy");
            Documento.aCodigoCteProv = "CLL001";//codigo del cliente proveedor
            Documento.aReferencia = "PRUEBA DESDE SDK";//referencia del documento

            int idDocumento = 0;
            //se da de alta el documento
            codigoDeError = MGWServicios.fAltaDocumento(ref idDocumento, ref Documento);
            MessageBox.Show(MGWServicios.rError(codigoDeError) + " documento ");
            //si no existen errores continuamos con el proceso de registro de los movimientos que llevara y la insersión de las observaciones a nivel movimiento
            if (codigoDeError == 0)
            {
                #region MOVIMIENTOS DEL DOCUMENTO
                int idMovimiento = 0;
                //se genera estructura de movimiento
                MGWServicios.tMovimiento Movimiento = new MGWServicios.tMovimiento();

                Movimiento.aCodAlmacen = "ALM003SDK";//codigo del almacen de donde se tomara el producto
                Movimiento.aCodClasificacion = "";
                Movimiento.aCodProdSer = "SDK";//codigo del producto/servicio
                Movimiento.aConsecutivo = 1;//numero/posición del movimiento
                Movimiento.aPrecio = 50;//precio del producto
                Movimiento.aReferencia = "Ref SDK";
                Movimiento.aUnidades = 1;//numero de unidades 

                //se da de alta el movimiento dentro del documento
                codigoDeError = MGWServicios.fAltaMovimiento(idDocumento, ref idMovimiento, ref Movimiento);
                #endregion


                #region ASOCIAR UUID AL DOCUMENTO
                //Realizamos la busqueda del documento, esto mediante Concepto, Serie, Folio, debes ser todos string por lo que se cartea el folio
                MGWServicios.fBuscarDocumento(Documento.aCodConcepto, Documento.aSerie, Documento.aFolio + "");
                //si se localiza el documento continuamos
                if (codigoDeError == 0)
                {
                    codigoDeError = MGWServicios.fBuscarDocumento(concepto, serie, folio + "");
                    if (codigoDeError == 0)
                    {
                        //una vez que se confirma el alta del pago continuamos agregando los datos referentes al pago
                        Console.WriteLine("Editar : " + MGWServicios.rError(MGWServicios.fEditarDocumento()));//abrimos el documento para edición
                                                                                                              //Estas ediciones son de Bajo nivel por lo que se aplican en los campos de la base de datos que se le indique
                        Console.WriteLine("Set UUID : " + MGWServicios.rError(codigoDeError = MGWServicios.fSetDatoDocumento("CUUID", CUUID))); //METODO DE PAGO
                        MGWServicios.fGuardaDocumento();
                    }
                    else
                    {

                        Console.WriteLine("Busqueda: " + MGWServicios.rError(codigoDeError));
                    }
                }
                #endregion
            }
        }
        #endregion

        #region ENTREGA EN DISCO

            public static void EntregarFormatoDisco()
        {
            string Concepto = "19";//"FPRUEBA3.3";//codigo de concepto del documento.
            string serie = "";//serie del documento
            double folio = 67;//folio del documento
            int formato = 1;//1 = PDF 0 = XML
            //ruta de la plantilla
            string formatoAmigable = @"C:\Compac\Empresas\Reportes\Formatos Digitales\reportes_Servidor\Comercial\Facturav33.rdl";

            codigoDeError = MGWServicios.fEntregEnDiscoXML(Concepto, serie, folio, formato, formatoAmigable);
            if(codigoDeError == 0)
            {
                Console.WriteLine("archivo entregado PDF");
            }
            else
            {
                Console.WriteLine(" Error : "+ codigoDeError);
                Console.WriteLine( "Descripción : "+MGWServicios.rError(codigoDeError));
            }

            codigoDeError = MGWServicios.fEntregEnDiscoXML(Concepto, serie, folio, 0, formatoAmigable);
            if (codigoDeError == 0)
            {
                Console.WriteLine("archivo entregado XMLC");
            }
            else
            {
                Console.WriteLine(" Error : " + codigoDeError);
                Console.WriteLine("Descripción : " + MGWServicios.rError(codigoDeError));
            }
        }
        #endregion

        #region NUEVO DOCUMENTO EDITANDO MOVIMIENTO BAJO NIVEL
        //proceso con estructuras de documento y movimiento
        public static void NuevoDocumentoEditaMoviBajoNivel()
        {
            StringBuilder aSerie = new StringBuilder("");
            //Se genera la estructura de documento
            MGWServicios.tDocumento Documento = new MGWServicios.tDocumento();



            //se asignan valores a las variables del documento
            MGWServicios.fSiguienteFolio("FPRUEBA3.3", aSerie, ref Documento.aFolio); //folio siguiente
            Documento.aNumMoneda = 2;
            Documento.aTipoCambio = 19.34;
            Documento.aImporte = 300;
            Documento.aDescuentoDoc1 = 0;
            Documento.aDescuentoDoc2 = 0;
            Documento.aSistemaOrigen = 205;
            /* Numero de sistema Origen
             *  205 = CONTPAQi® Comercial Premium.
                101 = CONTPAQi® Punto de venta.
                202 = CONTPAQi® Factura electrónica.
            */
            Documento.aCodConcepto = "FPRUEBA3.3";//CODIGO DEL CONCEPTO 
            Documento.aSerie = "";
            Documento.aFecha = DateTime.Now.ToString("MM/dd/yyyy");
            Documento.aCodigoCteProv = "CLL001";//codigo del cliente proveedor
            Documento.aCodigoAgente = "";
            Documento.aReferencia = "PRUEBA DESDE SDK";//referencia del documento
            Documento.aAfecta = 0;
            Documento.aGasto1 = 0;
            Documento.aGasto2 = 0;
            Documento.aGasto3 = 0;

            int idDocumento = 0;
            //se da de alta el documento
            codigoDeError = MGWServicios.fAltaDocumento(ref idDocumento, ref Documento);
            MessageBox.Show(MGWServicios.rError(codigoDeError) + " documento ");
            //si no existen errores continuamos con el proceso de registro de los movimientos que llevara y la insersión de las observaciones a nivel movimiento
            if (codigoDeError == 0)
            {
                #region OBSERVACION A NIVEL MOVIMIENTO
                //Realizamos la busqueda del documento, esto mediante Concepto, Serie, Folio, debes ser todos string por lo que se cartea el folio
                MGWServicios.fBuscarDocumento(Documento.aCodConcepto, Documento.aSerie, Documento.aFolio + "");
                //si se localiza el documento continuamos
                if (codigoDeError == 0)
                {
                    //abrimos el doc para edición
                    MGWServicios.fEditarDocumento();
                    //realizamos los cambios
                    MGWServicios.fSetDatoDocumento("COBSERVACIONES", "PRUEBA DESDE SDK");
                    //guardamos los cambios echos
                    MGWServicios.fGuardaDocumento();
                }
                #endregion

                #region MOVIMIENTOS DEL DOCUMENTO
                //int idMovimiento = 0;
                //se genera estructura de movimiento
                MGWServicios.tMovimiento Movimiento = new MGWServicios.tMovimiento();

                Movimiento.aCodAlmacen = "ALM003SDK";//codigo del almacen de donde se tomara el producto
                Movimiento.aCodClasificacion = "";
                Movimiento.aCodProdSer = "SDK";//codigo del producto/servicio
                Movimiento.aConsecutivo = 1;//numero/posición del movimiento
                Movimiento.aCosto = 40;//costo del producto
                Movimiento.aPrecio = 50;//precio del producto
                Movimiento.aReferencia = "Ref SDK";
                Movimiento.aUnidades = 1;//numero de unidades 
                int idMovimiento = 0;

                MGWServicios.fAltaMovimiento(idDocumento, ref idMovimiento, ref Movimiento);
                #endregion

            }
        }
        #endregion

        #region NUEVO DOCUMENTO
        public static void NuevoDocumento( int Numdoc)
        {
            MGWServicios.tDocumento Documento = new MGWServicios.tDocumento();

            StringBuilder serie = new StringBuilder("");
            string concepto = "FPRUEBA3.3";  //F4 = Factura v4.0   FPRUEBA3.3 = factura v3.3
            double folio = 0;
            Documento.aNumMoneda = 1;
            Documento.aTipoCambio = 0;
            Documento.aImporte = 1000;
            Documento.aDescuentoDoc1 = 0;
            Documento.aDescuentoDoc2 = 0;
            Documento.aSistemaOrigen = 205;
            /* Numero de sistema Origen
             *  205 = CONTPAQi® Comercial Premium.
                101 = CONTPAQi® Punto de venta.
                202 = CONTPAQi® Factura electrónica.
            */
            Documento.aCodConcepto = concepto;
            Documento.aSerie = serie+"";
            Documento.aFecha = DateTime.Now.ToString("MM/dd/yyyy");
            Documento.aCodigoCteProv = "CTEPESO";
            Documento.aCodigoAgente = "";
            Documento.aReferencia = "";
            Documento.aAfecta = 0;
            Documento.aGasto1 = 0;
            Documento.aGasto2 = 0;
            Documento.aGasto3 = 0;
            MGWServicios.fSiguienteFolio(concepto, serie, ref folio);


            int idDocumento = 0;
            codigoDeError = MGWServicios.fAltaDocumento(ref idDocumento, ref Documento);
            if (codigoDeError == 0)
            {
                //MessageBox.Show(MGWServicios.rError(codigoDeError) + " documento ");

                codigoDeError = NuevoMovimiento(idDocumento);
                if (codigoDeError == 0)
                {
                    EmitirDocumento(Documento.aCodConcepto, Documento.aFolio, Documento.aSerie, "12345678a");
                }
                else
                {
                    Console.WriteLine("Error movimiento");
                    Console.WriteLine("" + MGWServicios.rError(codigoDeError));
                }
            }
            else
            {
                Console.WriteLine("Error documento");
                Console.WriteLine(""+ MGWServicios.rError(codigoDeError));
            }

        }

        #endregion

        #region NUEVO MOVIMIENTO
        public static int NuevoMovimiento(int idDocumento)
        {
            int idMovimiento = 0;

            MGWServicios.tMovimiento Movimiento = new MGWServicios.tMovimiento();

            Movimiento.aConsecutivo = 1;
            Movimiento.aUnidades = 1;
            Movimiento.aPrecio = 1000;
            Movimiento.aCosto = 0;
            Movimiento.aCodProdSer = "S001";
            Movimiento.aCodAlmacen = "ALM003SDK";
            Movimiento.aReferencia = "";
            Movimiento.aCodClasificacion = "";

            return MGWServicios.fAltaMovimiento(idDocumento, ref idMovimiento, ref Movimiento);
        }

        #endregion

        #region NUEVO PAGO
        public static void NuevoDocumentoPago()
        {   //verificamos que exista el numero de cuenta de empresa al que se asiganara el pago
            codigoDeError = MGWServicios.fCuentaBancariaEmpresaDoctos("1234567890123456");
            MGWServicios.tDocumento DoctoCargoAbono = new MGWServicios.tDocumento(); //Creamos un Struc Documento para utilizar
            //asignamos los valores necesarios a las variables del documento de cargo/abono
            DoctoCargoAbono.aCodConcepto = "PC001";
            DoctoCargoAbono.aFolio = 28;//Folio del pago
            DoctoCargoAbono.aSerie = "";//serie del pago
            DoctoCargoAbono.aFecha = DateTime.Today.ToString("MM/dd/yyyy");//Fecha del pago
            DoctoCargoAbono.aCodigoCteProv = "CLL001";//codigo del cliente/proveedor que abona
            DoctoCargoAbono.aNumMoneda = 1;//1 =  MXN, 2 = USD
            DoctoCargoAbono.aTipoCambio = 1;//tipo de cambio
            DoctoCargoAbono.aImporte = 120;//importe del Pago
            DoctoCargoAbono.aReferencia = "Pago Generado por SDK";//Referencia del pago

            //Ralizamos el Alta del nuevo Documento de cargo/abono
            codigoDeError = MGWServicios.fAltaDocumentoCargoAbono(ref DoctoCargoAbono);
            if (codigoDeError != 0) //si no se dio de alta el pago mostramos la causa 
            {
                MessageBox.Show("se genero el siguiente error: " + MGWServicios.rError(codigoDeError));
            }
            else
            {
                //una vez que se confirma el alta del pago continuamos agregando los datos referentes al pago
                MGWServicios.fEditarDocumento();//abrimos el documento para edición
                //Estas ediciones son de Bajo nivel por lo que se aplican en los campos de la base de datos que se le indique
                MGWServicios.rError(codigoDeError = MGWServicios.fSetDatoDocumento("CMETODOPAG", "01")); //METODO DE PAGO
                MGWServicios.rError(codigoDeError = MGWServicios.fSetDatoDocumento("CCANTPARCI", "1"));//CANTIDAD DE PARCIALIDADES
                MGWServicios.rError(codigoDeError = MGWServicios.fSetDatoDocumento("CNUMPARCIA", "1"));//NUMERO DE PARCIALIDAD

                MGWServicios.rError(codigoDeError = MGWServicios.fSetDatoDocumento("CUSUBAN03", "17:10:00"));//Nombre del usuario de CONTPAQi® Bancos 
                /* que tiene el tercer permiso de autorización para pagar CFDI. Varchar: 20 caracteres.
                */
                MGWServicios.rError(codigoDeError = MGWServicios.fSetDatoDocumento("CIDMONEDCA", "1"));//ID DE TIPO DE MONEDA, 1 = MXN, 2 = USD
                //guardamos el documento con las ediciones echas
                MGWServicios.rError(codigoDeError = MGWServicios.fGuardaDocumento());

                //generamos una nueva llave para localizar el documento a saldar (CARGO).
                MGWServicios.RegLlaveDoc regDoctoSaldar = new MGWServicios.RegLlaveDoc();
                //asignamos los valores de busqueda para el documento a saldar.
                regDoctoSaldar.aCodConcepto = "FPRUEBA3.3"; //codigo de concepto
                regDoctoSaldar.aSerie = ""; //Serie del documento
                regDoctoSaldar.folio = 1;//Folio del documento

                //generamos una nueva llave para localizar el documento de Abono con el cual se va a saldar, en este ejemplo es el mismo que se acaba de generar
                MGWServicios.RegLlaveDoc regDoctoAbono = new MGWServicios.RegLlaveDoc();
                //asignamos los valores de busqueda para el documento de Abono.
                regDoctoAbono.aCodConcepto = DoctoCargoAbono.aCodConcepto; //codigo de concepto
                regDoctoAbono.aSerie = DoctoCargoAbono.aSerie; //Serie del documento
                regDoctoAbono.folio = DoctoCargoAbono.aFolio;//Folio del documento


                //también se pasa el valor del importe a pagar, se puede pagar el total del documento o solo una parte en caso de que el abono salde mas de un documento
                double ImportePagar = 100;
                //Moneda con la cual se registrara el abono, 1=MXN, 2=USD
                int idMoneda = 1;
                //por ultimo se pasa el valor de la fecha en el que se hace el abono
                string fechaAbono = DateTime.Now.ToString("MM/dd/yyyy");
                //relizamos el registro del pago en la tabla asocCargoAbono para relacionar el abono al documentode cargo pasando como referencia el abono y el cargo
                codigoDeError = MGWServicios.fSaldarDocumento(ref regDoctoSaldar, ref regDoctoAbono, ImportePagar, idMoneda, fechaAbono);

                if (codigoDeError != 0)

                {
                    MessageBox.Show("se genero un error " + MGWServicios.rError(codigoDeError));
                }
                else
                {
                    string aPassword = "12345678a"; //contraseña del CSD
                    codigoDeError = MGWServicios.fEmitirDocumento(DoctoCargoAbono.aCodConcepto, DoctoCargoAbono.aSerie, DoctoCargoAbono.aFolio, aPassword, "");

                    if (codigoDeError != 0)
                    {
                        MessageBox.Show("se genero el error " + MGWServicios.rError(codigoDeError));
                    }
                    else
                    {
                        MessageBox.Show("Documento timbrado");


                    }
                }
            }
        }

        #endregion

        #region Cancelar Documento (Motivo de cancelación)
        public static void CancelarDocumento()
        {
            #region Variables 

            //DOCUMENTO
            string aCodConcepto = "F4";//codigo de concepto al que pertenece el documento a cancelar
            string aSerie = "v4";//serie del documento
            string aFolio = "1";//folio del documento
            string aMotivo = "01";//clave del motivo de cancelación
            string aUUID = "00000000-ce39-4431-9b2e-b13949b9bb2c";//UUID del CFDI que remplaza al que será cancelado
            string aPass = "12345678a"; //contraseña del CSD
            
            #endregion

            #region BUSCAR DOCUMENTO
            //Realizamos la busqueda del documento, esto mediante Concepto, Serie, Folio, debes ser todos string por lo que se cartea el folio
            codigoDeError = MGWServicios.fBuscarDocumento(aCodConcepto, aSerie, aFolio);
            if (codigoDeError == 0)
            {
                Console.WriteLine(" Doc: " + aFolio + " encontrado ");
                //pasamos la contraseña del CSD asignado
                MGWServicios.fCancelaDoctoInfo(aPass);
                //realizamos la cancelación
                codigoDeError = MGWServicios.fCancelaDocumentoConMotivo(aMotivo, aUUID);
                if (codigoDeError == 0)
                {
                    Console.WriteLine(" Doc: " + aFolio + " cancelado ");

                }
                else
                {
                    Console.WriteLine("Error al cancelar documento");
                    Console.WriteLine(" Error : " + codigoDeError);
                    Console.WriteLine(MGWServicios.rError(codigoDeError));
                }
            }
            else
            {
                Console.WriteLine("Error al buscar documento");
            }
            #endregion
        }
#endregion

        #region NUEVO ALMACEN
public static void AddAlmacen()
        {   ///datos del nuevo almacen
            string fechaAlta = DateTime.Now.ToString("MM/dd/yyyy");
            string codAlmacen = "ALM003SDK";
            string nombreAlmacen = "AlmacenSDK";
            //generamos el nuevo registro en blanco
            codigoDeError = MGWServicios.fInsertaAlmacen();
            //validamos que se genero el registro con éxito
            if (codigoDeError == 0)
            {
                //posicionamos el puntero en el ultimo regustro, agregado anteriormente
                MGWServicios.fPosUltimoAlmacen();

                //abrimos el puntero de edición
                MGWServicios.fEditaAlmacen();
                //asignamos el código del almacen
                MGWServicios.fSetDatoAlmacen("CCODIGOALMACEN", codAlmacen);
                //asignamos el nombre del almacen
                MGWServicios.fSetDatoAlmacen("CNOMBREALMACEN", nombreAlmacen);
                //asignamos la fecha de alta del almacen
                MGWServicios.fSetDatoAlmacen("CFECHAALTAALMACEN", fechaAlta);


                //GUARDAMOS LOS CAMBIOS
                MGWServicios.fGuardaAlmacen();

                MessageBox.Show("Almacen " + nombreAlmacen + " registrado exitosamente ");
            }
            else
            {
                MessageBox.Show("Error al registrar Almacén. " + " error n: " + codigoDeError + " " + MGWServicios.rError(codigoDeError));

            }
        }
        #endregion

        #region BUSCAR CONCEPTOS
        public static void BuscarConceptos(string codigoConcepto, int posConcepto)
        {
            codigoDeError = MGWServicios.fBuscaConceptoDocto(codigoConcepto);
            if (codigoDeError != 0)
            {
                MessageBox.Show("posicion : " + posConcepto + " se genero el error " + MGWServicios.rError(codigoDeError) + " en el concepto " + codigoConcepto);
            }
            else
            {
                MessageBox.Show("posicion : " + posConcepto + " concepto " + codigoConcepto + " éxito");
            }
        }
        #endregion

        #region BUSCAR PRODUCTO POR CODIGO
        //función para sacar el nombre de un producto con solo su codigo, se recibe el parametro (string)
        public static void GetNombreProducto(string codigoProducto)
        {   //buscamos el producto del cual queremos sacar el dato, en este caso con ayuda del codigo de producto
            codigoDeError = MGWServicios.fBuscaProducto(codigoProducto);
            //si se encuentra el producto el codigo sera 0 indicando que no existe error
            if (codigoDeError == 0)
            {
                //creamos un stringbuilder para almacenar el nombre del producto
                StringBuilder nombreProducto = new StringBuilder();
                //leemos el dato que se almacena en el campo XXX de la tabla de productos en la base de datos
                //asignamos ese valor a la variable nombreProducto la cual se pasa como parametro
                codigoDeError = MGWServicios.fLeeDatoProducto("CNOMBREPRODUCTO", nombreProducto, 255);

                //paramatro 1 = nombre del campo en la tabla de productos
                //parametro 2 = parametro donde se asignara el campo leido
                //parametro 3 = tamaño maximo de la variable

                //Imprimimos la variable nombreProducto para confirmar que en efecto la variable ahora contiene el nombre del producto
                Console.WriteLine("Nombre : " + nombreProducto);
            }
        }
        #endregion

        #region ENTRADA DE ALMACEN
        public static void NuevaEntradaDeAlmacen()
        {   //-------------------------------------------------------------------
            //variables privadas de documento
            int codigoDeError = 0;
            int idDocumento = 0;
            double folioDocumento = 0;
            StringBuilder aSerie = new StringBuilder("");//serie del documento (en mi caso no manejo series por ello dejo en blanco)
            string codigoConceptoDeCompra = "21";//codigo de concepto de entrada
            //string codigoConceptoDeEntrada = "34";//codigo de concepto de entrada
            //fin variables privadas
            //-------------------------------------------------------------------

            //obtenemos el siguiente folio del concepto con codigo *34* (entrada de Almacén y lo referenciamos a *folioDocumento*
            //MGWServicios.fSiguienteFolio(codigoConceptoDeEntrada, aSerie, ref folioDocumento);
            MGWServicios.fSiguienteFolio(codigoConceptoDeCompra, aSerie, ref folioDocumento);
            //generamos un nuevo struct de DOCUMENTO
            MGWServicios.tDocumento documento = new MGWServicios.tDocumento();
            //-----------------------------------------------------------------
            //se asignan los valores correspondientes a las distintas variables privadas a utilizar en el documento
            documento.aFolio = folioDocumento;//folio del documento
            documento.aFecha = DateTime.Now.ToString("MM/dd/yyyy");//fecha del día
            documento.aSerie = "";//serie del documento (se castea a STRING)
            documento.aNumMoneda = 1;//id de la MONEDA del documento, 1=MXN 2=USD
            documento.aAfecta = 1;//valiable que determina si afecta existencias el documento, 1=Entradas 2=Salidas 3=Ninguno
            documento.aCodConcepto = codigoConceptoDeCompra;//codigo del concepto
            documento.aCodigoCteProv = "CTEPESO";//codigo del proveedor
            documento.aAfecta = 1;//varible que indica que el documento afecta existencias
            //-----------------------------------------------------------------     
            //Se da de alta el documento 
            codigoDeError = MGWServicios.fAltaDocumento(ref idDocumento, ref documento);
            //si no existe error al dar de alta el documento continuamos
            if (codigoDeError == 0)
            {
                //variables privadas de movimiento
                int idMovimiento = 0;//id del movimiento
                int aConsecutivo = 1;//consecutivo de movimiento para identificar que movimiento va primero en caso de tener mas de uno en el documento
                Double aUnidades = 2;//numero de unidades en el movimiento
                double aCosto = 5;//costo del producto para este movimiento
                String codigoProducto = "PR001";//codigo del producto registrado en el movimiento
                String aCodAlmacen = "ALM003SDK";//codigo del almacen al que entrara el producto de este movimiento
                //variables privadas de movimiento

                //creamos un STRUCT de movimiento
                MGWServicios.tMovimiento movimiento = new MGWServicios.tMovimiento();
                ////se asignan los valores correspondientes a las distintas variables privadas a utilizar en el movimiento
                movimiento.aConsecutivo = aConsecutivo;
                movimiento.aCodProdSer = codigoProducto;
                movimiento.aCodAlmacen = aCodAlmacen;
                movimiento.aCosto = aCosto;
                movimiento.aUnidades = aUnidades;

                //damos de alta el nuevo movimiento
                //referenciamos el movimiento y su ID y se pasa como parametro el id del documento al que se asignara
                codigoDeError = MGWServicios.fAltaMovimiento(idDocumento, ref idMovimiento, ref movimiento);

                if (codigoDeError != 0)
                {
                    MessageBox.Show(MGWServicios.rError(codigoDeError) + " movimiento ");

                }
                else
                {
                    MessageBox.Show("Documento registrado");
                }
            }
            else
            {
                MessageBox.Show(MGWServicios.rError(codigoDeError) + " documento ");
            }
        }
        #endregion

        #region DOCUMENTO PAQUETES
        static public void DoctoPaquetes()
        {
            double folioDocumento = 0;
            StringBuilder aSerie = new StringBuilder("");//serie del documento (en mi caso no manejo series por ello dejo en blanco)
            string codigoConcepto = "FPRUEBA3.3";//codigo del concepto Salida de Almacen
            //fin variables privadas
            //-------------------------------------------------------------------

            //obtenemos el siguiente folio del concepto con codigo *35* (Salida de Almacén y lo referenciamos a *folioDocumento*
            MGWServicios.fSiguienteFolio(codigoConcepto, aSerie, ref folioDocumento);
            int lErrorDocto;
            int lErrorMovto;
            int idDocto = 0;
            int idMovto = 0;
            MGWServicios.tDocumento documento = new MGWServicios.tDocumento();
            documento.aCodConcepto = "FPRUEBA3.3";
            documento.aFecha = DateTime.Now.ToString("MM/dd/yyyy");
            documento.aSerie = "";
            documento.aFolio = folioDocumento;
            //MessageBox.Show("folio: "+folioDocumento);
            documento.aNumMoneda = 2;
            documento.aTipoCambio = 19.98;
            documento.aCodigoCteProv = "CLL001";
            documento.aAfecta = 1;

            lErrorDocto = MGWServicios.fAltaDocumento(ref idDocto, ref documento);
            if (lErrorDocto == 0)
            {
                //for (int i = 0; i < 5; i++)
                //{
                MGWServicios.tMovimiento movimiento = new MGWServicios.tMovimiento();
                movimiento.aCodProdSer = "PR001";
                movimiento.aPrecio = 200;
                movimiento.aCodAlmacen = "ALM003SDK";
                movimiento.aUnidades = 1;

                lErrorMovto = MGWServicios.fAltaMovimiento(idDocto, ref idMovto, ref movimiento);
                if (idMovto != 0)
                {
                    MessageBox.Show("movimiento creado con exito");

                }
                else
                {
                    MessageBox.Show("no se pudo generar movimiento");
                    MessageBox.Show(MGWServicios.rError(lErrorDocto) + " movimiento : " + idMovto);
                }
                //}
            }
            else
            {
                MessageBox.Show("no se pudo generar documento");
                MessageBox.Show(MGWServicios.rError(lErrorDocto) + " documento ");
            }
        }
        #endregion

        #region NUEVA SALIDA
        public static void NuevaSalidaDeAlmacen()
        {
            //-------------------------------------------------------------------
            //variables privadas de documento
            int codigoDeError = 0;
            int idDocumento = 0;
            double folioDocumento = 0;
            StringBuilder aSerie = new StringBuilder("");//serie del documento (en mi caso no manejo series por ello dejo en blanco)
            string codigoConceptoDeSalida = "35";//codigo del concepto Salida de Almacen
            //fin variables privadas
            //-------------------------------------------------------------------
            //obtenemos el siguiente folio del concepto con codigo *35* (Salida de Almacén y lo referenciamos a *folioDocumento*
            MGWServicios.fSiguienteFolio(codigoConceptoDeSalida, aSerie, ref folioDocumento);
            //generamos un nuevo struct de DOCUMENTO
            MGWServicios.tDocumento documento = new MGWServicios.tDocumento();
            //-----------------------------------------------------------------
            //se asignan los valores correspondientes a las distintas variables privadas a utilizar en el documento
            documento.aFolio = folioDocumento;//folio del documento
            documento.aFecha = DateTime.Now.ToString("MM/dd/yyyy");//fecha del día
            documento.aSerie = "";//serie del documento (se castea a STRING)
            documento.aNumMoneda = 1;//id de la MONEDA del documento, 1=MXN 2=USD
            documento.aAfecta = 2;//valiable que determina si afecta existencias el documento, 1=Entradas 2=Salidas 3=Ninguno
            documento.aCodConcepto = codigoConceptoDeSalida;//codigo del concepto
            documento.aReferencia = "DocSDK";//referencia que indica que el documento se genero por SDK, dato informativo.
            //-----------------------------------------------------------------     
            //Se da de alta el documento 
            codigoDeError = MGWServicios.fAltaDocumento(ref idDocumento, ref documento);
            //si no existe error al dar de alta el documento continuamos
            if (codigoDeError == 0)
            {
                //variables privadas de movimiento
                int idMovimiento = 0;//id del movimiento
                int aConsecutivo = 1;//consecutivo de movimiento para identificar que movimiento va primero en caso de tener mas de uno en el documento
                Double aUnidades = 1;//numero de unidades en el movimiento
                String codigoProducto = "SDKPEPS";//codigo del producto registrado en el movimiento
                String aCodAlmacen = "ALM003SDK";//codigo del almacen de donde se tomaran las unidades del producto
                //variables privadas de movimiento

                //creamos un STRUCT de movimiento
                MGWServicios.tMovimiento movimiento = new MGWServicios.tMovimiento();
                ////se asignan los valores correspondientes a las distintas variables privadas a utilizar en el movimiento
                movimiento.aConsecutivo = aConsecutivo;
                movimiento.aCodProdSer = codigoProducto;
                movimiento.aCodAlmacen = aCodAlmacen;
                movimiento.aUnidades = aUnidades;
                movimiento.aCosto = 100;

                //damos de alta el nuevo movimiento
                //referenciamos el movimiento y su ID y se pasa como parametro el id del documento al que se asignara
                codigoDeError = MGWServicios.fAltaMovimiento(idDocumento, ref idMovimiento, ref movimiento);

                if (codigoDeError != 0)
                {
                    MessageBox.Show(MGWServicios.rError(codigoDeError) + " movimiento ");

                }
                else
                {
                    MessageBox.Show("Documento registrado");
                }

            }
            else
            {
                MessageBox.Show(MGWServicios.rError(codigoDeError) + " documento ");
            }
        }
        #endregion

        #region NUEVO TRASPASO
        public static void NuevoTraspasoAlmacenes()
        {
            //-------------------------------------------------------------------
            //variables privadas de documento
            int codigoDeError = 0;
            int idDocumento = 0;
            double folioDocumento = 0;
            StringBuilder aSerie = new StringBuilder("");//serie del documento (en mi caso no manejo series por ello dejo en blanco)
            string codigoConceptoDeTraspaso = "36";//codigo del concepto Traspaso de Almacen
            //fin variables privadas
            //-------------------------------------------------------------------

            //obtenemos el siguiente folio del concepto con codigo *35* (Salida de Almacén y lo referenciamos a *folioDocumento*
            MGWServicios.fSiguienteFolio(codigoConceptoDeTraspaso, aSerie, ref folioDocumento);
            //generamos un nuevo struct de DOCUMENTO
            MGWServicios.tDocumento documento = new MGWServicios.tDocumento();
            //-----------------------------------------------------------------
            //se asignan los valores correspondientes a las distintas variables privadas a utilizar en el documento
            documento.aFolio = folioDocumento;//folio del documento
            documento.aFecha = DateTime.Now.ToString("MM/dd/yyyy");//fecha del día
            documento.aSerie = "";//serie del documento (se castea a STRING)
            documento.aNumMoneda = 1;//id de la MONEDA del documento, 1=MXN 2=USD
            documento.aAfecta = 2;//valiable que determina si afecta existencias el documento, 1=Entradas 2=Salidas 3=Ninguno
            documento.aCodConcepto = codigoConceptoDeTraspaso;//codigo del concepto
            //-----------------------------------------------------------------     
            //Se da de alta el documento 
            codigoDeError = MGWServicios.fAltaDocumento(ref idDocumento, ref documento);
            //si no existe error al dar de alta el documento continuamos
            if (codigoDeError == 0)
            {

                //creamos un STRUCT de movimiento
                MGWServicios.tMovimiento movimientoSalida = new MGWServicios.tMovimiento();

                //variables privadas de movimiento
                int nUnidades = 2;//numero de unidades que se van a traspasar
                string cProducto = "COM001"; //codigo del producto que se traspasa
                ////se asignan los valores correspondientes a las distintas variables privadas a utilizar en el movimiento
                int idMovimientoSalida = 0;//id del movimiento
                movimientoSalida.aConsecutivo = 1;//consecutivo de movimiento para identificar que movimiento va primero en caso de tener mas de uno en el documento
                movimientoSalida.aUnidades = nUnidades;//numero de unidades en el movimiento
                movimientoSalida.aCodProdSer = cProducto;//codigo del producto registrado en el movimiento
                movimientoSalida.aCodAlmacen = "02";//codigo del almacen de donde se tomaran las unidades del producto para el traspaso (SALIDA)
                //variables privadas de movimiento


                //damos de alta el nuevo movimiento
                //referenciamos el movimiento y su ID y se pasa como parametro el id del documento al que se asignara
                codigoDeError = MGWServicios.fAltaMovimiento(idDocumento, ref idMovimientoSalida, ref movimientoSalida);

                if (codigoDeError != 0)
                {
                    MessageBox.Show(MGWServicios.rError(codigoDeError) + " movimiento ");

                }
                else
                {
                    //En caso de que se pueda dar de alta el primero movimiento (SALIDA) ahora debemos registrar la entrada al almacen a donde se traspasa
                    //creamos un STRUCT de movimiento
                    MGWServicios.tMovimiento movimientoOcultoEntrada = new MGWServicios.tMovimiento();//variables privadas de movimiento
                    ////se asignan los valores correspondientes a las distintas variables privadas a utilizar en el movimiento
                    int idMovimientoOcultoEntrada = 0;//id del movimiento
                    movimientoOcultoEntrada.aConsecutivo = 0;//consecutivo de movimiento para identificar que movimiento va primero en caso de tener mas de uno en el documento
                    movimientoOcultoEntrada.aUnidades = nUnidades;//numero de unidades en el movimiento
                    movimientoOcultoEntrada.aCodProdSer = cProducto;//codigo del producto registrado en el movimiento
                    movimientoOcultoEntrada.aCodAlmacen = "1";//codigo del almacen a donde entrara el producto de traspaso
                                                              //variables privadas de movimiento


                    //damos de alta el nuevo movimiento
                    //referenciamos el movimiento y su ID y se pasa como parametro el id del documento al que se asignara
                    codigoDeError = MGWServicios.fAltaMovimiento(idDocumento, ref idMovimientoOcultoEntrada, ref movimientoOcultoEntrada);

                    //Una ves que damos de alta el movimiento hay que editar algunos campos ya que debe registrarse como un 
                    //movimiento oculto que dependera del movimiento anterior de salida
                    //abrimos el movimiento para su edición
                    MGWServicios.fEditarMovimiento();

                    MGWServicios.fSetDatoMovimiento("CIDDOCUMENTO", "0");
                    MGWServicios.fSetDatoMovimiento("CNUMEROMOVIMIENTO", "0");
                    MGWServicios.fSetDatoMovimiento("CIDALMACEN", "2");//ID del Almacen, no hay función que saque este dato
                    MGWServicios.fSetDatoMovimiento("CAFECTADOSALDOS", "0");
                    MGWServicios.fSetDatoMovimiento("CMOVTOOCULTO", "1");
                    MGWServicios.fSetDatoMovimiento("CIDMOVTOOWNER", idMovimientoSalida.ToString());//ID del movimiento padre de salida
                    MGWServicios.fSetDatoMovimiento("CTIPOTRASPASO", "3");//el tipo de traspaso que es, como es oculto el movimiento se indica 3

                    MGWServicios.fGuardaMovimiento();

                    MessageBox.Show("taspaso registrado ");
                }
            }
            else
            {
                MessageBox.Show(MGWServicios.rError(codigoDeError) + " documento ");
            }
        }
        #endregion

        #region VER ERROR
        static public void VerCodigoError(int codigoError)
        {
            MGWServicios.fError(codigoError, sMensaje, 512);
            MessageBox.Show(sMensaje.ToString(), "Error de conexión", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
        }
        #endregion

        #region NOTA DE CREDITO CON IVA
        static public void NotaCreditoIVA()
        {
            //verificamos que exista el numero de cuenta de empresa al que se asiganara la nota de credito
            codigoDeError = MGWServicios.fCuentaBancariaEmpresaDoctos("1234567890123456");
            MGWServicios.tDocumento DoctoCargoAbono = new MGWServicios.tDocumento(); //Creamos un Struc Documento para utilizar
            //asignamos los valores necesarios a las variables del documento de cargo/abono
            DoctoCargoAbono.aCodConcepto = "NT2";
            DoctoCargoAbono.aFolio = 10;//Folio de la nota de credito
            DoctoCargoAbono.aSerie = "";//serie de la nota de credito
            DoctoCargoAbono.aFecha = DateTime.Today.ToString("MM/dd/yyyy");//Fecha de la nota de credito
            DoctoCargoAbono.aCodigoCteProv = "CLL001";//codigo del cliente/proveedor que abona
            DoctoCargoAbono.aNumMoneda = 1;//1 =  MXN, 2 = USD
            DoctoCargoAbono.aTipoCambio = 1;//tipo de cambio
            DoctoCargoAbono.aImporte = 200.0;//importe NETO de la nota de credito
            DoctoCargoAbono.aReferencia = "Nota de credito por SDK";//Referencia de la nota de credito
            DoctoCargoAbono.aSistemaOrigen = 205;

            //Ralizamos el Alta del nuevo Documento de cargo/abono
            codigoDeError = MGWServicios.fAltaDocumentoCargoAbono(ref DoctoCargoAbono);
            if (codigoDeError != 0) //si no se dio de alta de la nota de credito mostramos la causa 
            {
                MessageBox.Show("se genero el siguiente error: " + MGWServicios.rError(codigoDeError));
            }
            else
            {
                //una vez que se confirma el alta de la nota de credito habra que editar los campos que correspondan al impuesto
                MGWServicios.fEditarDocumento();//abrimos el documento para edición
                //Estas ediciones son de Bajo nivel por lo que se aplican en los campos de la base de datos que se le indique
                MGWServicios.rError(codigoDeError = MGWServicios.fSetDatoDocumento("CPORCENTAJEIMPUESTO1", "4")); //Porcentaje del impuesto 1
                MessageBox.Show("cambios porcentaje " + MGWServicios.rError(codigoDeError));
                //MGWServicios.rError(codigoDeError = MGWServicios.fSetDatoDocumento("CIMPUESTO1", "8")); //importe del impuesto
                //MessageBox.Show("cambios impuesto " + MGWServicios.rError(codigoDeError));

                //guardamos el documento con las ediciones echas
                MGWServicios.rError(codigoDeError = MGWServicios.fGuardaDocumento());
                MessageBox.Show("Documento generado con éxito" + MGWServicios.rError(codigoDeError));
            }
            //MessageBox.Show(MGWServicios.rError( NuevoMovimiento( idDocumento )) + " movimiento ");
        }

        #endregion

        #region PRUEBA SERIESCAPAS
        static public void pruebaSDKDatosSeriesCapas()
        {
            int aIdSeriesCapas = 1;
            int aIdMovimiento = 1;
            double aUnidades = 1;
            double aTipoCambio = 1;
            string aSeries = "";
            string aPedimento = "";
            string aAgencia = "";
            string aFechaPedimento = "";
            string aNumeroLote = "";
            string aFechaFabricacion = "";
            string aFechaCaducidad = "";


            codigoDeError = MGWServicios.mSDKDatosSeriesCapas(aIdSeriesCapas, aIdMovimiento, aUnidades, aTipoCambio, aSeries, aPedimento, aAgencia, aFechaPedimento, aNumeroLote, aFechaFabricacion, aFechaCaducidad);

            MessageBox.Show("Error " + codigoDeError + " descripcion " + MGWServicios.rError(codigoDeError));
            MessageBox.Show(
                "idserie " + aIdSeriesCapas +
            "\n idMov " + aIdMovimiento +
            "\n Unidades " + aUnidades +
            "\n TipoCambio " + aTipoCambio +
            "\n Serie " + aSeries +
            "\n pedimento" + aPedimento +
            "\n agencia " + aAgencia +
            "\n Fpedi" + aFechaPedimento +
            "\n nLote" + aNumeroLote +
            "\n fFabri" + aFechaFabricacion +
            "\n fCad" + aFechaCaducidad);
        }

        #endregion

        #region RELACIONAR PAGO
        public static void RelacionarPago()
        {
            string concepto = "PC001";
            string serie = "";
            int folio = 4;

            codigoDeError = MGWServicios.fBuscarDocumento(concepto, serie, folio + "");
            if (codigoDeError == 0)
            {

                //una vez que se confirma el alta del pago continuamos agregando los datos referentes al pago
                MGWServicios.fEditarDocumento();//abrimos el documento para edición
                                                //Estas ediciones son de Bajo nivel por lo que se aplican en los campos de la base de datos que se le indique
                MGWServicios.rError(codigoDeError = MGWServicios.fSetDatoDocumento("CMETODOPAG", "01")); //METODO DE PAGO
                MGWServicios.rError(codigoDeError = MGWServicios.fSetDatoDocumento("CCANTPARCI", "1"));//CANTIDAD DE PARCIALIDADES
                MGWServicios.rError(codigoDeError = MGWServicios.fSetDatoDocumento("CNUMPARCIA", "1"));//NUMERO DE PARCIALIDAD

                MGWServicios.rError(codigoDeError = MGWServicios.fSetDatoDocumento("CUSUBAN03", "17:10:00"));//Nombre del usuario de CONTPAQi® Bancos 
                /* que tiene el tercer permiso de autorización para pagar CFDI. Varchar: 20 caracteres.
                */
                MGWServicios.rError(codigoDeError = MGWServicios.fSetDatoDocumento("CIDMONEDCA", "1"));//ID DE TIPO DE MONEDA, 1 = MXN, 2 = USD
                                                                                                       //guardamos el documento con las ediciones echas
                MGWServicios.rError(codigoDeError = MGWServicios.fGuardaDocumento());

                //generamos una nueva llave para localizar el documento a saldar (CARGO).
                MGWServicios.RegLlaveDoc regDoctoSaldar = new MGWServicios.RegLlaveDoc();
                //asignamos los valores de busqueda para el documento a saldar.
                regDoctoSaldar.aCodConcepto = "FPRUEBA3.3"; //codigo de concepto
                regDoctoSaldar.aSerie = ""; //Serie del documento
                regDoctoSaldar.folio = 1;//Folio del documento

                //generamos una nueva llave para localizar el documento de Abono con el cual se va a saldar, en este ejemplo es el mismo que se acaba de generar
                MGWServicios.RegLlaveDoc regDoctoAbono = new MGWServicios.RegLlaveDoc();
                //asignamos los valores de busqueda para el documento de Abono.
                regDoctoAbono.aCodConcepto = concepto; //codigo de concepto
                regDoctoAbono.aSerie = serie; //Serie del documento
                regDoctoAbono.folio = folio;//Folio del documento


                //también se pasa el valor del importe a pagar, se puede pagar el total del documento o solo una parte en caso de que el abono salde mas de un documento
                double ImportePagar = 100;
                //Moneda con la cual se registrara el abono, 1=MXN, 2=USD
                int idMoneda = 1;
                //por ultimo se pasa el valor de la fecha en el que se hace el abono
                string fechaAbono = DateTime.Now.ToString("MM/dd/yyyy");
                //relizamos el registro del pago en la tabla asocCargoAbono para relacionar el abono al documentode cargo pasando como referencia el abono y el cargo
                codigoDeError = MGWServicios.fSaldarDocumento(ref regDoctoSaldar, ref regDoctoAbono, ImportePagar, idMoneda, fechaAbono);

                if (codigoDeError != 0)

                {
                    MessageBox.Show("se genero un error " + MGWServicios.rError(codigoDeError));
                }
                else
                {
                    string aPassword = "12345678a"; //contraseña del CSD
                    codigoDeError = MGWServicios.fEmitirDocumento(concepto, serie, folio, aPassword, "");

                    if (codigoDeError != 0)
                    {
                        MessageBox.Show("se genero el error " + MGWServicios.rError(codigoDeError));
                    }
                    else
                    {
                        MessageBox.Show("Documento timbrado");
                    }
                }
            }
            else
            {
                MessageBox.Show("error :" + codigoDeError);
            }

        }
        #endregion


        #region EDITAR REGIMEN DE UN DOCUMENTO
        public static void EditarRegimen()
        {
            #region Variables 
            //DOCUMENTO
            StringBuilder cidDocumento = new StringBuilder("");
            string aCodConcepto = "F4";//codigo de concepto del documento
            string aSerie = "v4";//serie del documento
            string aFolio = "7";//folio del documento
            int aLong = 76;//longitud de caracteres que se van a leer.
            #endregion

            #region BUSCAR DOCUMENTO
            //Realizamos la busqueda del documento, esto mediante Concepto, Serie, Folio, debes ser todos string 
            codigoDeError = MGWServicios.fBuscarDocumento(aCodConcepto, aSerie, aFolio);
            if (codigoDeError == 0)
            {
                codigoDeError = MGWServicios.fEditarDocumento();
                codigoDeError = MGWServicios.fSetDatoDocumento("CDESCAUT03", "601");// es el nombre del campo que lleva el tipo de regimen del documento, 601 el valor que se le dará
                codigoDeError = MGWServicios.fGuardaDocumento();

            }
            else
            {
                Console.WriteLine("Error al buscar documento");
            }
            #endregion
        }
        #endregion

        #region RELACIONAR 
        public static void RelacionarCFDI()
        {

        }

        #endregion

        #region EMITIR DOCUMENTO
        public static void EmitirDocumento( string aCodigoConcepto, double aFolio, string aSerie, string aContraseña)
        {
            //variables
            // Palabra Complemento  posteriormente el caractar : y a continuación la ruta donde se encuentra la información del complemento seguida del nombre y extensión del archivo
            string aArchivoAdicional = @"Complemento:C:\Compac\Empresas\Esquemas\COMERCIAL\CartaPorte.ini"; 
            codigoDeError = MGWServicios.fEmitirDocumento(aCodigoConcepto, aSerie, aFolio, aContraseña, aArchivoAdicional);

            //en caso de que la función retorne un codigo diferente de 0 indicara que no se ejecuto con éxito
            if (codigoDeError == 0)
            {
                Console.WriteLine("Se genero el error " + codigoDeError);
                Console.WriteLine("Descripción: " + MGWServicios.rError(codigoDeError));
            }
            else
            {
                Console.WriteLine("Documento emitido");
            }
        }
        #endregion

        #region FiltrosMovimineto
        public static void FiltrarMovimiento()
        {
            int aIdDocumento = 11;
            StringBuilder aIdMovimiento = new StringBuilder("");
            string aCampo = "CIDMOVIMIENTO";
            int aLen = 10;

            codigoDeError = MGWServicios.fSetFiltroMovimiento(aIdDocumento);
            Console.WriteLine("Respuesta de filto : " + codigoDeError);

            codigoDeError = MGWServicios.fPosPrimerMovimiento();
            Console.WriteLine("Respuesta primera posición : " + codigoDeError);

            if (codigoDeError == 0)
            {
                do
                {
                    codigoDeError = 0;
                    codigoDeError = MGWServicios.fLeeDatoMovimiento(aCampo, aIdMovimiento, aLen);
                    Console.WriteLine("Respuesta LeeDato : " + codigoDeError);
                    if (codigoDeError != 0) { Console.WriteLine("descripción : " + MGWServicios.rError(codigoDeError)); }
                    Console.WriteLine("idMovimiento : " + aIdMovimiento);
                    codigoDeError = MGWServicios.fPosSiguienteMovimiento();
                    Console.WriteLine("Respuesta sigMovi : " + codigoDeError);
                    if (codigoDeError != 0) { Console.WriteLine("descripción : " + MGWServicios.rError(codigoDeError)); }
                } while (codigoDeError == 0);
                Console.WriteLine("Se han leido todos los movimientos");
            }
            

        }
        #endregion
    }
}



