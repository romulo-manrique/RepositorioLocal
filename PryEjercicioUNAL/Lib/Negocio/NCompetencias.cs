using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Negocio
{
    public class NCompetencias
    {
        public static DataTable GetCompetencias(int Id)
        {
            DCompetencias Obj = new DCompetencias();

            return Obj.GetCompetencias(Id);
        }
    }
}
