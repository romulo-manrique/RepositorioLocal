using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NGerencias
    {
        public static DataTable GetGerencias(int Id)
        {
            DGerencias Obj = new DGerencias();

            Obj.id = Id;

            return Obj.Seleccionar(Obj);
        }
    }
}
