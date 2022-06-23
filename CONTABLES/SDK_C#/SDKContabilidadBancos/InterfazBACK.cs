using SDKCONTPAQNGLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKContabilidadBancos
{
    class InterfazBACK
    {
        #region OBJETOS

        ContabilidadFunciones Conta = new ContabilidadFunciones();
        BancosFunciones Bancos = new BancosFunciones();
        #endregion

        #region CREAR POLIZA CON PAGO ASOCIADO(EGRESO)
        public void CrearPolizaPago (ref TSdkSesion tSdkSesion)
        {
            //GENERAMOS LA POLIZA Y ASIGNAMOS NUESTRO OBJETO A DICHA POLIZA POR MEDIO DE LA BUSQUEDA POR ID
            Conta.CrearPoliza(ref tSdkSesion);

;
            //GENERAMOS EL DOCUMENTO EGRESO
            Bancos.DocIngresoPago(ref tSdkSesion, Conta.lSdkPoliza.Id, Conta.lSdkPoliza.Ejercicio, Conta.lSdkPoliza.Periodo, 4);

        }
        #endregion

        #region CREAR EGRESO CON ASOCIACION DE XML
        public void CrearEgresoAsocXML(ref TSdkSesion tSdkSesion)
        {
            Bancos.DocEgresoAsocXML(ref tSdkSesion);
        }
        #endregion
    }
}
