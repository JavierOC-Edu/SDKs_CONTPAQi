using SDKCONTPAQNGLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDKContabilidadBancos
{
    public class Sesion
    {
        #region VARIABLES

        public TSdkSesion tSdkSesion;
        private static string NombreEmpresa = "ct01__empresa_2_pruebas";
        //private static int lResult;
        //private static string mensajeError;
        private static string usuario = "SUPERVISOR";
        private static string password = "";

        #endregion

        #region INICIAR SESION

        public void Iniciar()
        {
            //Instanciamos nuestro objeto
            tSdkSesion = new TSdkSesion();
            //Validamos que no exista una sesión activa
            if (tSdkSesion.conexionActiva == 0)
            { //iniciamos conexión si no se tiene una
                tSdkSesion.iniciaConexion();
            }

            //Validamos que exista sesión activa y que no haya registro de usuario
            if (tSdkSesion.conexionActiva == 1 && tSdkSesion.ingresoUsuario == 00)
            {//si se cumple la validcion nos logeamos con el usuario
                //tSdkSesion.firmaUsuario();
                tSdkSesion.firmaUsuarioParams(usuario, password);
            }

            if (tSdkSesion.conexionActiva != 1 || tSdkSesion.ingresoUsuario != 1)
            {
                Console.WriteLine("No se pudo iniciar sesión SDK : " + tSdkSesion.UltimoMsjError);
            }
            
        }

        #endregion INICIO DE SESIÓN

        #region ABRIR EMPRESA

        public  void Abrir( )
        {
            //identificamos que todo de haya aplicado de manera correcta
            if (tSdkSesion.conexionActiva != 1 || tSdkSesion.ingresoUsuario != 1)
            {
                Console.WriteLine("Empresa: No existe una sesión iniciada");
            }
            else
            {
                tSdkSesion.abreEmpresa(NombreEmpresa);
                Console.WriteLine("Empresa Activa");
            }

        }

        #endregion
    }
}
