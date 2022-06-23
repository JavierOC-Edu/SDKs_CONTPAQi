using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKFacturaElectronica
{
    class Program
    {
        #region OBJETOS
        static ItfFunciones interfaz = new ItfFunciones();
        #endregion
        static void Main(string[] args)
        {
            interfaz.InicializarSDK();

            interfaz.TrabajarSistema();
        }
    }
}
