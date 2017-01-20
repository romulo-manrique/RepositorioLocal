using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public  class DImpacto
    {
        public int Id { get; set; }
        public int Descripcion { get; set; }

        public DataTable SeleccionarImpacto(DImpacto obj)
        {
            DataTable dt = new DataTable("tbl");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.CnEventos))
                {
                    using (SqlCommand cmd = new SqlCommand("spSelImpacto", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", obj.Id);

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

        public DataTable SeleccionarNivelImpacto (DImpacto obj)
        {
            DataTable dt = new DataTable("tbl");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.CnEventos))
                {
                    using (SqlCommand cmd = new SqlCommand("spSelNivelImpacto", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", obj.Id);

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
