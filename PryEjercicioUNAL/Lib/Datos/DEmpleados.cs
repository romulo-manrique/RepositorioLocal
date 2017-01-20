using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DEmpleados
    {
        public int codigo { get; set; }
        public string apellido { get; set; }
        public string nombre { get; set; }
        public string nacionalidad { get; set; }
        public string cedula { get; set; }
        public DateTime fIngreso { get; set; }
        public int codigoSupervisor { get; set; }
        public int idEmpresa { get; set; }
        public int idDepartamento { get; set; }
        public int idCargo{ get; set; }
        public int idTipo { get; set; }
        public string Correo { get; set; }

        public DataTable GetSupervisados(int codigoSupervisor)
        {
            DataTable dt = new DataTable("tbl");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.CnPersonas))
                {
                    using (SqlCommand cmd = new SqlCommand("spSelSupervisados", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@codigo", codigoSupervisor);
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

        public DataTable SelEmpleado (int codigo)
        {
            DataTable dt = new DataTable("tbl");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.CnPersonas))
                {
                    using (SqlCommand cmd = new SqlCommand("spSelEmpleado", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@codigo", codigo);
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
