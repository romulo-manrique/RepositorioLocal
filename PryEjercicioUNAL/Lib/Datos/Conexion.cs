using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Conexion
    {
        //Server Local Desarrollo
        public static string CnSeguridad = "Data Source=INFORMATICA-23;Initial Catalog=bdSeguridad;User ID=sa";
        public static string CnPersonas = "Data Source=INFORMATICA-23;Initial Catalog=bdPersonas111;User ID=sa";
        public static string CnEventos = "Data Source=INFORMATICA-23;Initial Catalog=bdGestionEmpleados111;User ID=sa";

        //Server Produccion 

        //public static string CnSeguridad = "Data Source=INF068\\MSSQLSERVER2014;Initial Catalog=bdSeguridad;User ID=sa";
        //public static string CnPersonas = "Data Source=INF068\\MSSQLSERVER2014;Initial Catalog=bdPersonas;User ID=sa";
        //public static string CnEventos = "Data Source=INF068\\MSSQLSERVER2014;Initial Catalog=bdGestionEmpleados;User ID=sa";

    }
}
