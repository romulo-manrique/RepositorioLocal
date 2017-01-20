using Datos ;
using System.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NUsuarios
    {
        public static DataTable ValidaUsuario(string Usuario, string Password)
        {
            DUsuarios Obj = new DUsuarios();

            Obj.Usuario = Usuario;
            Obj.Password = Password;

            return Obj.ValidarUsuario(Obj);
        }

        public static DataTable ValidaCorreo(string correo)
        {
            DUsuarios Obj = new DUsuarios();
            return Obj.ValidarCorreo(correo);
        }

        public static void RecuperaInf(string correo)
        {
            DUsuarios Obj = new DUsuarios();
            Obj.RecuperaInf(correo);
        }

        public static string CambioClave(string Usuario, string Clave)
        {
            DUsuarios Obj = new DUsuarios();

            return Obj.CambioClave(Usuario, Clave);
        }

    }
}
