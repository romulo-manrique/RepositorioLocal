using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NCargos
    {
        public static DataTable Selecciona(int Id)
        {
            DCargos Obj = new DCargos();

            Obj.id = Id;

            return Obj.Seleccionar(Obj);
        }
    } 
}
