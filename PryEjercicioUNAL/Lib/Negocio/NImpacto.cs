using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NImpacto
    {
        public static DataTable GetImpacto(int Id)
        {
            DImpacto Obj = new DImpacto();

            Obj.Id = Id;

            return Obj.SeleccionarImpacto(Obj);
        }

        public static DataTable GetNivelImpacto(int Id)
        {
            DImpacto Obj = new DImpacto();

            Obj.Id = Id;

            return Obj.SeleccionarNivelImpacto(Obj);
        }
    }
}
