using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Datos
{
   public class DUsuarios
    {
        public int idUsuario { get; set; }
        public string Usuario { get; set; }
        public string Password { get; set; }
        public string Cedula { get; set; }
        public int CodEmpleado { get; set; }
        public DateTime Registro { get; set; }
        public string Correo { get; set; }
        public DateTime Acceso { get; set; }
        public bool Estado { get; set; }


        public DataTable ValidarUsuario(DUsuarios obj)
        {
            DataTable dt = new DataTable("tbl");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.CnSeguridad))
                {
                    using (SqlCommand cmd = new SqlCommand("spValidaUsuario", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Usuario", obj.Usuario);
                        cmd.Parameters.AddWithValue("@Clave", obj.Password);

                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        };

                        SqlDataAdapter sqlDat = new SqlDataAdapter(cmd);
                        sqlDat.Fill(dt);
                    }
                }
            }

            catch(Exception e)
            {
                string mensaje = e.Message.ToString();
                    dt = null;
            }

            return dt;
        }

        public DataTable ValidarCorreo(string correo)
        {
            DataTable dt = new DataTable("tbl");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.CnSeguridad))
                {
                    using (SqlCommand cmd = new SqlCommand("spValidaCorreo", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@correo", correo);
                       

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

        public DataTable RecuperaInf(string correo)
        {
            DataTable dt = new DataTable("tbl");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.CnSeguridad))
                {
                    using (SqlCommand cmd = new SqlCommand("spRecuperaClave", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@correo", correo);


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

        public string CambioClave(string usuario, string clave)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            using (SqlConnection con = new SqlConnection(Conexion.CnSeguridad))
            {
                using (SqlCommand cmd = new SqlCommand("spCambiaPassword", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@Clave", clave);

                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        };

                        rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se realizó la acción correctamente !!!";

                    }
                    catch (Exception ex)
                    {
                        rpta = ex.Message;

                    }
                    finally
                    {
                        if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
                    }
                }

                return rpta;
            }
        }

    }
}
