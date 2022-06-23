using SDKCONTPAQNGLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKContabilidadBancos
{
    class BancosFunciones
    {
        #region VARIABLES

        private static int lResult;
        private static string mensajeError;

        #endregion

        #region OBJETOS

        #endregion

        #region CREAR DOCUMENTO INGRESO

        public void DocIngreso(ref TSdkSesion tSdkSesion)
        {   //instanciamos nuestro objeto para crear nuesto ingreso
            TSdkIngreso tSDKIngreso = new TSdkIngreso();

            tSDKIngreso.setSesion(tSdkSesion);
            tSDKIngreso.iniciarInfo();

            tSDKIngreso.TipoDocumento = "42";
            tSDKIngreso.Fecha = DateTime.Today; //Fecha de emisión del documento.
            tSDKIngreso.Ejercicio = Convert.ToInt32(DateTime.Today.ToString("yyyy")); //Ejercicio del documento bancario con base en su emisión.
            tSDKIngreso.Periodo = Convert.ToInt32(DateTime.Today.ToString("MM")); //Periodo del documento bancario con base en su emisión.
            tSDKIngreso.FechaAplicacion = DateTime.Today; //Fecha de aplicación del documento.
            tSDKIngreso.EjercicioAp = Convert.ToInt32(DateTime.Today.ToString("yyyy")); //Ejercicio de aplicación
            tSDKIngreso.PeriodoAp = Convert.ToInt32(DateTime.Today.ToString("MM")); //Periodo del documento bancario con base en su aplicación.
            tSDKIngreso.CodigoPersona = "100200"; //Código Beneficiario/Pagador
            tSDKIngreso.BeneficiarioPagador = "BPparaSDK"; //Nombre del Beneficiario/Pagor
            tSDKIngreso.IdCuentaCheques = 1; //Identificador de la cuenta bancaria.
            tSDKIngreso.CodigoMonedaTipoCambio = "1";
            tSDKIngreso.TipoCambio = 0;
            tSDKIngreso.Total = 1; //Importe total aplicado al documento bancario
            tSDKIngreso.Referencia = "SDK Bancos";
            tSDKIngreso.Concepto = "Prueba de ingreso por SDK";
            tSDKIngreso.MetodoDePago = "03";
            tSDKIngreso.BancoOrigen = 21;
            tSDKIngreso.PosibilidadPago = 0;
            /* Indica la posibilidad de pago del documento:
                 * 0 = Alta
                 * 1 = Media
                 * 2 = Baja */

            tSDKIngreso.EsProyectado = 0;
            /* Indica si el documento es proyectado:
                True = Proyectado (no afecta saldos).
                False = Real (afecta saldos). */


            lResult = tSDKIngreso.crea();
            if (lResult == 0)
            {
                mensajeError = tSDKIngreso.getMensajeError();
            }
            else
            {
                mensajeError = "Documento bancario generado";
            }

            Console.WriteLine("Ingreso : " + mensajeError);


        }

        #endregion

        #region CREAR DOCUMENTO EGRESO ASOC XML //NO ES POSIBLE ASOCIAR XML A DOCS BANCARIOS
        public void DocEgresoAsocXML(ref TSdkSesion tSdkSesion)
        {
            TSdkEgreso lsdkEgreso = new TSdkEgreso();

            lsdkEgreso.setSesion(tSdkSesion);
            lsdkEgreso.iniciarInfo();


            lsdkEgreso.TipoDocumento = "45";
            lsdkEgreso.Fecha = DateTime.Today; //Fecha de emisión del documento.
            lsdkEgreso.Ejercicio = Convert.ToInt32(DateTime.Today.ToString("yyyy")); //Ejercicio del documento bancario con base en su emisión.
            lsdkEgreso.Periodo = Convert.ToInt32(DateTime.Today.ToString("MM")); //Periodo del documento bancario con base en su emisión.
            lsdkEgreso.FechaAplicacion = DateTime.Today; //Fecha de aplicación del documento.
            lsdkEgreso.EjercicioAp = Convert.ToInt32(DateTime.Today.ToString("yyyy")); //Ejercicio de aplicación
            lsdkEgreso.PeriodoAp = Convert.ToInt32(DateTime.Today.ToString("MM")); //Periodo del documento bancario con base en su aplicación.
            lsdkEgreso.CodigoPersona = "100200"; //Código Beneficiario/Pagador
            lsdkEgreso.BeneficiarioPagador = "BPparaSDK"; //Nombre del Beneficiario/Pagor
            lsdkEgreso.IdCuentaCheques = 1; //Identificador de la cuenta bancaria.
            lsdkEgreso.CodigoMonedaTipoCambio = "1"; //Código de la moneda usada por el tipo de cambio del documento.
            lsdkEgreso.TipoCambio = 1;//Tipo de cambio asignado al documento bancario.
            lsdkEgreso.Total = 100; //Importe total aplicado al documento bancario
            lsdkEgreso.Referencia = "SDK Bancos";
            lsdkEgreso.Concepto = "Prueba de Egredo por SDK";
            /*
            lsdkEgreso.EjercicioPol = Convert.ToInt32(DateTime.Today.ToString("yyyy")); //Ejercicio de la póliza.
            lsdkEgreso.PeriodoPol = Convert.ToInt32(DateTime.Today.ToString("MM")); //Periodo de la póliza.
            lsdkEgreso.TipoPol = 1;// este campo comprende el tipo de poliza - Egresos -
            lsdkEgreso.NumPol = 1;//este campo es variable corresponde al folio de la poliza
            lsdkEgreso.IdPoliza = 1; //Identificador de la póliza asignada al documento.
            */
            lsdkEgreso.Origen = 11; // sistema origen 11 = CONTPAQ i® CONTABILIDAD 201 = CONTPAQ i® BANCOS
            lsdkEgreso.BancoDestino = 21;
            lsdkEgreso.CuentaDestino = "1234567890123456";
            lsdkEgreso.MetodoDePago = "03";

            lResult = lsdkEgreso.crea();
            if (lResult == 0)
            {
                mensajeError = lsdkEgreso.getMensajeError();
                Console.WriteLine("Egreso : " + mensajeError);
            }
            else
            {
                mensajeError = "Documento bancario generado";
                Console.WriteLine("Egreso : " + mensajeError);
                //inicializamos el objeto de asociación
                TSdkAsocCFDI asocCFDI = new TSdkAsocCFDI();
                asocCFDI.setSesion(tSdkSesion);

                //asociamos Guid a UUID
                asocCFDI.iniciarInfo();
                asocCFDI.GuidDocumento = lsdkEgreso.Guid;//guidDoc;
                asocCFDI.TipoAsoc = ETIPOASOCCFDI.TIPOASOC_CHEQUE;//ETIPOASOCCFDI.TIPOASOC_MOVTOPOLIZA;
                asocCFDI.agregaUUID("00000000-2fd0-4d62-81b7-86d4af34bd9f");//UUID del XML que se asociara
                lResult = asocCFDI.crea();

                if (lResult == 0)
                {
                    Console.WriteLine("Asoc Error: " + asocCFDI.getMensajeError());
                }
                else
                {
                    Console.WriteLine("Se Generó Asociación");
                }
            }
            
        }

        #endregion

        #region CREAR DOCUMENTO EGRESO

        public void DocEgreso(ref TSdkSesion tSdkSesion)
        {
            TSdkEgreso lsdkEgreso = new TSdkEgreso();

            lsdkEgreso.setSesion(tSdkSesion);
            lsdkEgreso.iniciarInfo();


            lsdkEgreso.TipoDocumento = "45";
            lsdkEgreso.Fecha = DateTime.Today; //Fecha de emisión del documento.
            lsdkEgreso.Ejercicio = Convert.ToInt32(DateTime.Today.ToString("yyyy")); //Ejercicio del documento bancario con base en su emisión.
            lsdkEgreso.Periodo = Convert.ToInt32(DateTime.Today.ToString("MM")); //Periodo del documento bancario con base en su emisión.
            lsdkEgreso.FechaAplicacion = DateTime.Today; //Fecha de aplicación del documento.
            lsdkEgreso.EjercicioAp = Convert.ToInt32(DateTime.Today.ToString("yyyy")); //Ejercicio de aplicación
            lsdkEgreso.PeriodoAp = Convert.ToInt32(DateTime.Today.ToString("MM")); //Periodo del documento bancario con base en su aplicación.
            lsdkEgreso.CodigoPersona = "100200"; //Código Beneficiario/Pagador
            lsdkEgreso.BeneficiarioPagador = "BPparaSDK"; //Nombre del Beneficiario/Pagor
            lsdkEgreso.IdCuentaCheques = 1; //Identificador de la cuenta bancaria.
            lsdkEgreso.CodigoMonedaTipoCambio = "1"; //Código de la moneda usada por el tipo de cambio del documento.
            lsdkEgreso.TipoCambio = 1;//Tipo de cambio asignado al documento bancario.
            lsdkEgreso.Total = 100; //Importe total aplicado al documento bancario
            lsdkEgreso.Referencia = "SDK Bancos";
            lsdkEgreso.Concepto = "Prueba de Egredo por SDK";
            /*
            lsdkEgreso.EjercicioPol = Convert.ToInt32(DateTime.Today.ToString("yyyy")); //Ejercicio de la póliza.
            lsdkEgreso.PeriodoPol = Convert.ToInt32(DateTime.Today.ToString("MM")); //Periodo de la póliza.
            lsdkEgreso.TipoPol = 1;// este campo comprende el tipo de poliza - Egresos -
            lsdkEgreso.NumPol = 1;//este campo es variable corresponde al folio de la poliza
            lsdkEgreso.IdPoliza = 1; //Identificador de la póliza asignada al documento.
            */
            lsdkEgreso.Origen = 11; // sistema origen 11 = CONTPAQ i® CONTABILIDAD 201 = CONTPAQ i® BANCOS
            lsdkEgreso.BancoDestino = 21;
            lsdkEgreso.CuentaDestino = "1234567890123456";
            lsdkEgreso.MetodoDePago = "03";

            lResult = lsdkEgreso.crea();
            if (lResult == 0)
            {
                mensajeError = lsdkEgreso.getMensajeError();
            }
            else
            {
                mensajeError = "Documento bancario generado";
            }

            Console.WriteLine("Egreso : " + mensajeError);
        }

        #endregion

        #region CREAR DOCUMENTO EGRESO-PAGO

        public void DocIngresoPago(ref TSdkSesion tSdkSesion, int idPoliza, int aEjercicio, int aPeriodo, int aNumero)
        {
            TSdkEgreso lsdkEgreso = new TSdkEgreso();

            lsdkEgreso.setSesion(tSdkSesion);
            lsdkEgreso.iniciarInfo();


            lsdkEgreso.TipoDocumento = "45";
            lsdkEgreso.Fecha = DateTime.Today; //Fecha de emisión del documento.
            lsdkEgreso.Ejercicio = 2020; //Ejercicio del documento bancario con base en su emisión.
            lsdkEgreso.Periodo = 10; //Periodo del documento bancario con base en su emisión.
            lsdkEgreso.FechaAplicacion = DateTime.Today; //Fecha de aplicación del documento.
            lsdkEgreso.EjercicioAp = 2020; //Ejercicio de aplicación
            lsdkEgreso.PeriodoAp = 10; //Periodo del documento bancario con base en su aplicación.
            lsdkEgreso.CodigoPersona = "100200"; //Código Beneficiario/Pagador
            lsdkEgreso.BeneficiarioPagador = "BPparaSDK"; //Nombre del Beneficiario/Pagor
            lsdkEgreso.IdCuentaCheques = 1; //Identificador de la cuenta bancaria.
            lsdkEgreso.CodigoMonedaTipoCambio = "1"; //Código de la moneda usada por el tipo de cambio del documento.
            lsdkEgreso.TipoCambio = 1;//Tipo de cambio asignado al documento bancario.
            lsdkEgreso.Total = 100; //Importe total aplicado al documento bancario
            lsdkEgreso.Referencia = "SDK Bancos";
            lsdkEgreso.Concepto = "Prueba de Egreso por SDK";

            //Datos de la poliza asociada
            lsdkEgreso.EjercicioPol = aEjercicio; //Ejercicio de la póliza.
            lsdkEgreso.PeriodoPol = aPeriodo; //Periodo de la póliza.
            lsdkEgreso.TipoPol = 2; // este campo comprende el tipo de póliza - Egresos –
            lsdkEgreso.NumPol = aNumero; //este campo es variable corresponde al folio de la póliza
            lsdkEgreso.IdPoliza = idPoliza; //Identificador de la póliza asignada al documento.
            lsdkEgreso.Origen = 11; // sistema origen 11 = CONTPAQ i® CONTABILIDAD 201 = CONTPAQ i® BANCOS
            lsdkEgreso.PosibilidadPago = 0; //0 = Alta 1 = Media 2 = Baja
            lsdkEgreso.EsProyectado = 0;


            lResult = lsdkEgreso.crea();
            if (lResult == 0)
            {
                mensajeError = lsdkEgreso.getMensajeError();
            }
            else
            {
                mensajeError = "Documento bancario generado";
            }
            Console.WriteLine("id Poliza : " + idPoliza);
            Console.WriteLine("Ejercicio : " + aEjercicio);
            Console.WriteLine("Periodo : " + aPeriodo);
            Console.WriteLine("Numero : " + aNumero);
            Console.WriteLine("Egreso : " + mensajeError);
        }

        #endregion

        #region EDITAR BENEFICIARIO-PROVEEDOR

        public void EditarBeneficiarioProv(ref TSdkSesion tSdkSesion)
        {   //codigo de proveedor a buscar
            string codigoProv = "100200";
            //variable para detectar errores
            int errores = 0;
            //instanciamos un nuevo objeto de beneficiario/proveedor
            TSdkProveedor proveedor = new TSdkProveedor();

            //iniciamos el objeto
            proveedor.setSesion(tSdkSesion);//recibe la sesión con la que iniciamos el sistema
            proveedor.iniciarInfo();

            //realizamos la busqueda del proveedor con el codigo correspondiente
            errores = proveedor.buscaPorCodigo(codigoProv);
            //si existe el proveedor nos respondera con un 1
            if (errores == 1)
            {
                proveedor.CodigoCuenta = "0000000000000000";//asignamos el numero de cuenta
                proveedor.setCuenta = 111222;
                proveedor.modifica();
                mensajeError = "cambios realizados";
            }
            else
            {
                mensajeError = "error en busqueda de proveedor : " + proveedor.getMensajeError();

            }

            Console.WriteLine("Actualización Beneficiario-Proveedor : " + mensajeError);

        }
        #endregion

        #region REGISTRAR PROVEEDOR
        public void RegistrarProveedor (ref TSdkSesion tSdkSesion )
        {   //reestablecemos el valor de lResult a 0
            //instanciamos un nuevo objeto de beneficiario/proveedor
            TSdkProveedor proveedor = new TSdkProveedor();
            //Pasarla sesióna los Objetos del Proveedor
            proveedor.setSesion(tSdkSesion);
            
            //Iniciarcarga
            proveedor.iniciarInfo();
            //Llenarlas propiedades del objeto
            proveedor.EsProveedor = 1;
            proveedor.Codigo = proveedor.getSiguienteCodigo().Trim();
            proveedor.Nombre = "ProveedorSDK";
            proveedor.RFC = "XAXX010101000";
            proveedor.CURP = "CURP073613PRUEBA80";
            proveedor.CodigoCuenta = "1030015";
            proveedor.TipoTercero = ETIPOTERCERO.TIPOTER_PROVNACIONAL;
            proveedor.TipoOperacion = ETIPOOPERACION.TIPOOPE_PRESERVPRO;
            proveedor.Nacionalidad = "Mexicana";
            proveedor.TasaAsumida = ETASAASUMIDAPROV.TAASUPRO_TASA16;
            proveedor.IdFiscal = "2";
            proveedor.FechaRegistro= DateTime.Now;
            proveedor.UsaTasaIVA16 = 1;

            proveedor.agregaProveedor(proveedor);
            //Cargar El objeto para agregar al
            lResult = proveedor.crea();     
            // Crear Proveedor
            if(lResult == 0)
            {
                Console.WriteLine(proveedor.getMensajeError());
            }else{
                Console.WriteLine("Proveedor registrado correctamente");
            }
           
        }
        #endregion
    }
}
