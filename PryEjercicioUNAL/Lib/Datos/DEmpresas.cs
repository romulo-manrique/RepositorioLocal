using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DEmpresas
    {
        public int id { get; set; }
        public string Descripcion { get; set; }

        public DataTable Seleccionar(DEmpresas obj)
        {
            DataTable dt = new DataTable("tbl");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.CnPersonas))
                {
                    using (SqlCommand cmd = new SqlCommand("spSelEmpresas", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", obj.id);


                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        };

                        SqlDataAdapter sqlDat = new SqlDataAdapter(cmd);
                        sqlDat.Fill(dt);
                    }
                }
            }

            catch (Exception e)
            {
                string mensaje = e.Message.ToString();
                dt = null;
            }

            return dt;
        }

    }
}
