using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Data;

namespace Negocio
{
   public class NTipoEvento
   {
        public static DataTable GetTipoEvento(int Id)
        {
            DTipoEvento Obj = new DTipoEvento();

            return Obj.GetTipoEvento(Id);
        }
    }
}
