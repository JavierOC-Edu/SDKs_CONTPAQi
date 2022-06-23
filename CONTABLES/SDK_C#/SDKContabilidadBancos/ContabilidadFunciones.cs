using SDKCONTPAQNGLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKContabilidadBancos
{
    class ContabilidadFunciones
    {
        #region VARIABLES

        private static int lResult;
        //private static string mensajeError;
        //SISTEMA PRUEBAS
        /*
        private static string uuidAbono = "00000000-02a0-4c45-9b70-58ac26392aca";
        private static string uuidCargo = "00000000-de59-411e-8221-2090c3e63338";
        private static string uuidPoliza = "00000000-e3d0-4d8e-8600-db9ac43f15a7";
        */
        //RESPALDO
        private static string uuidAbono = "783DFD33-051C-437D-89D8-5FE9D2131C24";
        private static string uuidCargo = "0BAE0F18-A202-457A-B0DB-A07C855DFF09";
        //private static string uuidPoliza = "00000000-e3d0-4d8e-8600-db9ac43f15a7";
        

        #endregion

        #region OBJETOS
        public  TSdkPoliza lSdkPoliza;
        static TSdkMovimientoPoliza lSdkMovto;
        static TSdkAsocCFDI asocCFDI;

        #endregion

    #region CREAR POLIZA DE DIARIO

        public void CrearPolizaDiario(ref TSdkSesion lSdkSesion)
        {

            #region SetSesion Poliza

            //Pasamos sesion a los objetos de Poliza
            lSdkPoliza = new TSdkPoliza();
            lSdkPoliza.setSesion(lSdkSesion);

            #endregion

            #region Inicializar Poliza
            // iniciamos carga
            lSdkPoliza.iniciarInfo();


            //Llenamos las Propiedades del objeto
            lSdkPoliza.Tipo = ETIPOPOLIZA.TIPO_DIARIO;
            lSdkPoliza.Clase = ECLASEPOLIZA.CLASE_AFECTAR;
            lSdkPoliza.Impresa = 0;
            //lSdkPoliza.Fecha = DateTime.Now;//Parse("25/12/2015");
            lSdkPoliza.Fecha = new DateTime(2020, 10, 10); //DateTime.Now;//Parse("25/12/2015");
            lSdkPoliza.Diario = 0;
            lSdkPoliza.SistOrigen = ESISTORIGEN.ORIG_CONTPAQNG;
            lSdkPoliza.Ajuste = 0;
            lSdkPoliza.Concepto = "SDK_CONTA_DIARIO";
            lSdkPoliza.Guid = Guid.NewGuid().ToString().ToUpper();

            #endregion


            #region AGREGAR CARGO & ABONO
            //generamos los movimientos de cargo y abono
            /*
            TSdkMovimientoPoliza cargoMvto = CrearMovimientoPoliza(ref lSdkSesion, "102010", "2030.00",1, ETIPOIMPORTEMOVPOLIZA.MOVPOLIZA_CARGO);
            TSdkMovimientoPoliza abonoMvto = CrearMovimientoPoliza(ref lSdkSesion, "501080", "2030.00",1, ETIPOIMPORTEMOVPOLIZA.MOVPOLIZA_ABONO);
            */
            TSdkMovimientoPoliza cargoMvto = CrearMovimientoPoliza(ref lSdkSesion, "4110004", "943.28", 1, ETIPOIMPORTEMOVPOLIZA.MOVPOLIZA_CARGO);
            TSdkMovimientoPoliza abonoMvto = CrearMovimientoPoliza(ref lSdkSesion, "5010003", "102.5", 1, ETIPOIMPORTEMOVPOLIZA.MOVPOLIZA_ABONO);

            //Cargamos los movimientos a la poliza
            lResult = lSdkPoliza.agregaMovimiento(cargoMvto);//Cargamos el Movimiento
            if (lResult == 0)
            {
                Console.WriteLine("CARGO: " + lSdkPoliza.getMensajeError());
            }else
            {
                Console.WriteLine("CARGO: " + cargoMvto.CodigoCuenta);
            }

            //MOVIMIENTO ABONO
            lResult = lSdkPoliza.agregaMovimiento(abonoMvto);//Cargamos el Movimiento
            if (lResult == 0)
            {
                Console.WriteLine("ABONO : " + lSdkPoliza.getMensajeError());
            }
            else
            {
                Console.WriteLine("ABONO: " + abonoMvto.CodigoCuenta);
            }

            #endregion

            #region Crear Poliza

            lResult = lSdkPoliza.crea();
            if (lResult == 0)
            {
                Console.WriteLine("Movtos: " + lSdkPoliza.getMensajeError());
            }
            else
            {
                Console.WriteLine("Se Generó la póliza ");

                #region ASOCIAR XMLs
                //Asociamos el documento
                //AsociarXML(ref lSdkSesion, lSdkPoliza.Guid, uuidPoliza.ToUpper(), ETIPOASOCCFDI.TIPOASOC_POLIZA);
                AsociarXML(ref lSdkSesion, lSdkPoliza.Guid, uuidCargo.ToUpper(), ETIPOASOCCFDI.TIPOASOC_POLIZA);
                AsociarXML(ref lSdkSesion, lSdkPoliza.Guid, uuidAbono.ToUpper(), ETIPOASOCCFDI.TIPOASOC_POLIZA);
                //Asociamos el cargo
                AsociarXML(ref lSdkSesion, cargoMvto.Guid, uuidCargo.ToUpper(), ETIPOASOCCFDI.TIPOASOC_MOVTOPOLIZA);
                //Asociamos el Abono
                AsociarXML(ref lSdkSesion, abonoMvto.Guid, uuidAbono.ToUpper(), ETIPOASOCCFDI.TIPOASOC_MOVTOPOLIZA);
                #endregion

            }//Fin else crearPoliza
            #endregion
        }

    #endregion

    #region ASOCIAR XML
        private static void AsociarXML(ref TSdkSesion lSdkSesion, string guid, string uuid, ETIPOASOCCFDI tipoAsociacion)
        {
            //inicializamos el objeto de asociación
            asocCFDI = new TSdkAsocCFDI();
            asocCFDI.setSesion(lSdkSesion);

            //asociamos Guid a UUID
            asocCFDI.iniciarInfo();
            asocCFDI.GuidDocumento = guid;//guidDoc;
            asocCFDI.TipoAsoc = tipoAsociacion;//ETIPOASOCCFDI.TIPOASOC_MOVTOPOLIZA;
            asocCFDI.agregaUUID(uuid);
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
    #endregion

    #region CREAR MOVIMIENTO
        private static TSdkMovimientoPoliza CrearMovimientoPoliza(ref TSdkSesion lSdkSesion, string codCuenta, string importe, int nMovto, ETIPOIMPORTEMOVPOLIZA tipoMovto)
        {
            //Creamos y pasamos sesión al movimiento
            lSdkMovto = new TSdkMovimientoPoliza();
            lSdkMovto.setSesion(lSdkSesion);

            //------------------------- Propiedades Movimiento Cargo ----------------------------------------------        

            //Iniciamos Carga
            lSdkMovto.iniciarInfo();

            //Propiedades Movimiento
            lSdkMovto.NumMovto = nMovto;
            lSdkMovto.CodigoCuenta = codCuenta;
            lSdkMovto.TipoMovto = tipoMovto;
            lSdkMovto.Importe = decimal.Parse(importe);
            lSdkMovto.ImporteME = 0;
            lSdkMovto.Diario = 0;
            lSdkMovto.SegmentoNegocio = "1";
            lSdkMovto.Guid = Guid.NewGuid().ToString().ToUpper();

            Console.WriteLine(" cuenta : " + lSdkMovto.CodigoCuenta);

            return lSdkMovto;

        }
        #endregion

        #region CREAR POLIZA

        public int CrearPoliza(ref TSdkSesion lSdkSesion)
        {

            #region SetSesion Poliza

            //Pasamos sesion a los objetos de Poliza
            lSdkPoliza = new TSdkPoliza();
            lSdkPoliza.setSesion(lSdkSesion);

            #endregion

            #region Inicializar Poliza
            // iniciamos carga
            lSdkPoliza.iniciarInfo();


            //Llenamos las Propiedades del objeto
            lSdkPoliza.Tipo = ETIPOPOLIZA.TIPO_EGRESOS;//tipo EGRESO
            lSdkPoliza.Clase = ECLASEPOLIZA.CLASE_AFECTAR;
            lSdkPoliza.Impresa = 0;
            //lSdkPoliza.Fecha = DateTime.Now;//Parse("25/12/2015");
            lSdkPoliza.Fecha = new DateTime(2020, 10, 10); //DateTime.Now;//Parse("25/12/2015");
            lSdkPoliza.Diario = 0;
            lSdkPoliza.SistOrigen = ESISTORIGEN.ORIG_CONTPAQNG;
            lSdkPoliza.Ajuste = 0;
            lSdkPoliza.Concepto = "SDK_CONTA_EGRESO";
            lSdkPoliza.Guid = Guid.NewGuid().ToString().ToUpper();

            #endregion


            #region AGREGAR CARGO & ABONO
            //generamos los movimientos de cargo y abono
            
            TSdkMovimientoPoliza cargoMvto = CrearMovimientoPoliza(ref lSdkSesion, "102010", "30.00",1, ETIPOIMPORTEMOVPOLIZA.MOVPOLIZA_CARGO);
            TSdkMovimientoPoliza abonoMvto = CrearMovimientoPoliza(ref lSdkSesion, "501080", "30.00",1, ETIPOIMPORTEMOVPOLIZA.MOVPOLIZA_ABONO);
            
            /*
            TSdkMovimientoPoliza cargoMvto = CrearMovimientoPoliza(ref lSdkSesion, "4110004", "943.28", 1, ETIPOIMPORTEMOVPOLIZA.MOVPOLIZA_CARGO);
            TSdkMovimientoPoliza abonoMvto = CrearMovimientoPoliza(ref lSdkSesion, "5010003", "102.5", 1, ETIPOIMPORTEMOVPOLIZA.MOVPOLIZA_ABONO);
            */
            //Cargamos los movimientos a la poliza
            lResult = lSdkPoliza.agregaMovimiento(cargoMvto);//Cargamos el Movimiento
            if (lResult == 0)
            {
                Console.WriteLine("CARGO: " + lSdkPoliza.getMensajeError());
            }
            else
            {
                Console.WriteLine("CARGO: " + cargoMvto.CodigoCuenta);
            }

            //MOVIMIENTO ABONO
            lResult = lSdkPoliza.agregaMovimiento(abonoMvto);//Cargamos el Movimiento
            if (lResult == 0)
            {
                Console.WriteLine("ABONO : " + lSdkPoliza.getMensajeError());
            }
            else
            {
                Console.WriteLine("ABONO: " + abonoMvto.CodigoCuenta);
            }

            #endregion

            #region Crear Poliza

            lResult = lSdkPoliza.crea();
            if (lResult == 0)
            {
                Console.WriteLine("Movtos: " + lSdkPoliza.getMensajeError());

                return 0;
            }
            else
            {
                Console.WriteLine("Se Generó la póliza ");

                return lSdkPoliza.Id;

            }//Fin else crearPoliza
            #endregion
        }

        #endregion

        #region EDITAR CLIENTE

        public void EditarCLiente(ref TSdkSesion lSdkSesion)
        {
            TSdkCliente lsdkCliente = new TSdkCliente();

            lsdkCliente.setSesion(lSdkSesion);

            lsdkCliente.iniciarInfo();

            int cl = lsdkCliente.buscaPorCodigo("20020");

            if (cl == 0){
                Console.WriteLine("No se encontro el cliente");
            }
            else
            {
                Console.WriteLine("----------- Antes de modificar ---------------");
                Console.WriteLine("Cliente encontrado: " + lsdkCliente.Nombre);
                Console.WriteLine("CURP: " + lsdkCliente.CURP);
                Console.WriteLine("Codigo : "+lsdkCliente.Codigo);

                //lsdkCliente.CodigoCuenta = "";

                //lsdkCliente.Nombre = "";

                //lsdkCliente.RFC = "";
                lsdkCliente.CURP = "OICJ886543";
                lsdkCliente.Nombre = "FUNCIONA";
                int modifica = lsdkCliente.modifica();

                Console.WriteLine("----------- Despues de modificar ---------------");

                Console.WriteLine("Cliente encontrado: " + lsdkCliente.Nombre);
                Console.WriteLine("CURP: " + lsdkCliente.CURP);
                Console.WriteLine("Codigo : " + lsdkCliente.Codigo);

                if (modifica == 0)

                {
                    Console.WriteLine("Error: no se modifico el cliente");
                }
                else
                {
                    Console.WriteLine("EXITO! Cliente modificado");
                }

            }
        }
        #endregion
    }
}
