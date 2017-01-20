using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NEmpleados
    {
        public static DataTable GetSupervisados(int codigoSupervisor)
        {
           DEmpleados Obj = new DEmpleados();
           return Obj.GetSupervisados(codigoSupervisor);
        }

        public static DataTable SelEmpleado(int codigo )
        {
            DEmpleados Obj = new DEmpleados();
            return Obj.SelEmpleado(codigo);
        }
    }
}
