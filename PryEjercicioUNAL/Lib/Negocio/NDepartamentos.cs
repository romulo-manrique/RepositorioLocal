using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NDepartamentos
    {
        public static DataTable GetDepartamentos (int Id)
        {
            DDepartamentos Obj = new DDepartamentos();

            Obj.id = Id;

            return Obj.Seleccionar(Obj);
        }
    }
}
