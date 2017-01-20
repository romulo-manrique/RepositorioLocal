using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
   public class DEventos
    {
        public double Id { get; set; }
        public int periodo { get; set; }
        public int idUsuario { get; set; }
        public int idCargo { get; set; }
        public int idDepartamento { get; set; }
        public int idEmpresa { get; set; }
        public int idGerencia { get; set; }
        public int idTipo { get; set; }
        public int codigoEmpleado { get; set; }
        public int codigoSupervisor { get; set; }
        public  DateTime Registro { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Actividades { get; set; }
        public string Logros { get; set; }
        public bool Estatus { get; set; }
        public int Impacto { get; set; }
        public int NivelImpacto { get; set; }
        public string EmpleadoEvento { get; set; }
        public string UsuarioRegistra { get; set; }
        public string fRegistro { get; set; }

        public string Actalizar (DEventos obj)
        {
            string rpta = "";
            DateTime Hoy = DateTime.Today;
            SqlConnection sqlCon = new SqlConnection();
           

            using (SqlConnection con = new SqlConnection(Conexion.CnEventos))
            {
                using (SqlCommand cmd = new SqlCommand("spInsUpdEventos", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@idUsuario", obj.idUsuario);
                        cmd.Parameters.AddWithValue("@idCargo", obj.idCargo);
                        cmd.Parameters.AddWithValue("@idDepartamento", obj.idDepartamento);
                        cmd.Parameters.AddWithValue("@idEmpresa", obj.idEmpresa);
                        cmd.Parameters.AddWithValue("@idGerencia", obj.idGerencia);
                        cmd.Parameters.AddWithValue("@idTipo", obj.idTipo);
                        cmd.Parameters.AddWithValue("@codigoEmpleado", obj.codigoEmpleado);
                        cmd.Parameters.AddWithValue("@codigoSupervisor", obj.codigoSupervisor);
                        cmd.Parameters.AddWithValue("@titulo", obj.Titulo);
                        cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                        cmd.Parameters.AddWithValue("@Actividades", obj.Actividades);
                        cmd.Parameters.AddWithValue("@Logros", obj.Logros);
                        cmd.Parameters.AddWithValue("@Estatus", obj.Estatus);
                        cmd.Parameters.AddWithValue("@Impacto", obj.Impacto);
                        cmd.Parameters.AddWithValue("@NivelImpacto", obj.NivelImpacto);

                        SqlParameter IdEventoOut = new SqlParameter("@IdEventoOut", 0);
                        IdEventoOut.Direction = ParameterDirection.Output;

                        cmd.Parameters.Add(IdEventoOut);

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
        public string Insertar(DEventos obj, int[] mGerencias, int[] mCompetencias)
        {
            string rpta = "";
            DateTime Hoy = DateTime.Today;
            SqlConnection sqlCon = new SqlConnection();
            int nIdEventoOut = 0;
            
            using (SqlConnection con = new SqlConnection(Conexion.CnEventos))
            {
                using (SqlCommand cmd = new SqlCommand("spInsUpdEventos", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Id", obj.Id);
                        cmd.Parameters.AddWithValue("@idUsuario", obj.idUsuario);
                        cmd.Parameters.AddWithValue("@idCargo", obj.idCargo);
                        cmd.Parameters.AddWithValue("@idDepartamento", obj.idDepartamento);
                        cmd.Parameters.AddWithValue("@idEmpresa", obj.idEmpresa);
                        cmd.Parameters.AddWithValue("@idGerencia", obj.idGerencia);
                        cmd.Parameters.AddWithValue("@idTipo", obj.idTipo);
                        cmd.Parameters.AddWithValue("@codigoEmpleado", obj.codigoEmpleado);
                        cmd.Parameters.AddWithValue("@codigoSupervisor", obj.codigoSupervisor);
                        cmd.Parameters.AddWithValue("@titulo", obj.Titulo);
                        cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                        cmd.Parameters.AddWithValue("@Actividades", obj.Actividades);
                        cmd.Parameters.AddWithValue("@Logros", obj.Logros);
                        cmd.Parameters.AddWithValue("@Estatus", obj.Estatus);
                        cmd.Parameters.AddWithValue("@Impacto", obj.Impacto);
                        cmd.Parameters.AddWithValue("@NivelImpacto", obj.NivelImpacto);


                        SqlParameter IdEventoOut = new SqlParameter("@IdEventoOut", 0);
                        IdEventoOut.Direction = ParameterDirection.Output;

                        cmd.Parameters.Add(IdEventoOut);

                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        };

                        rpta = cmd.ExecuteNonQuery() == 1 ? "OK" : "No se realizó la acción correctamente !!!";

                        nIdEventoOut = Int32.Parse(cmd.Parameters["@IdEventoOut"].Value.ToString());

                        // Abre comentario para evaluación del Supervisor
                        if (nIdEventoOut != 0)
                        { 
                            InsertarAbreComentario(0, nIdEventoOut, obj.codigoSupervisor, Hoy, string.Empty, 0, 0, false, 0, 0);
                        }

                        if (nIdEventoOut != 0)
                        {
                            // Abre los comentarios para las Gerencias Beneficiadas
                            foreach (int i in mGerencias)
                            {
                                InsertarAbreComentario(0,nIdEventoOut, obj.codigoSupervisor, Hoy , string.Empty, 0, 0, false, 1, i );
                            }
                            // Guarda las competencias seleccionadas
                            foreach (int i in mCompetencias)
                            {
                                InsertarDetalleCompetencias(nIdEventoOut, i);                               
                            }
                        }
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
        public string InsertarDetalleCompetencias(int idEvento, int idCompetencia)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            using (SqlConnection con = new SqlConnection(Conexion.CnEventos))
            {
                using (SqlCommand cmd = new SqlCommand("spInsUpdDetalleCompetencias", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdEvento", idEvento);
                        cmd.Parameters.AddWithValue("@idCompetencia", idCompetencia);                        

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
        public string InsertarAbreComentario(int id, int idEvento,  int codigoSupervisor, DateTime fComentario, string Comentario, int Impacto, int NivelImpacto, bool Estatus, int TipoComentario, int idGerencia)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            using (SqlConnection con = new SqlConnection(Conexion.CnEventos))
            {
                using (SqlCommand cmd = new SqlCommand("spInsUpdAbreEventoComentario", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@idEvento", idEvento);
                        cmd.Parameters.AddWithValue("@codigoSupervisor", codigoSupervisor);
                        cmd.Parameters.AddWithValue("@fComentario", fComentario);
                        cmd.Parameters.AddWithValue("@Comentario", Comentario);
                        cmd.Parameters.AddWithValue("@Impacto", Impacto);
                        cmd.Parameters.AddWithValue("@NivelImpacto", NivelImpacto);
                        cmd.Parameters.AddWithValue("@Estatus", Estatus);
                        cmd.Parameters.AddWithValue("@TipoComentario", TipoComentario);
                        cmd.Parameters.AddWithValue("@idGerencia", idGerencia);

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
        public DataTable GetComentarios (int idUsuario, int Roll, int codigoEmpleado)
        {
            DataTable dt = new DataTable("tbl");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.CnEventos))
                {
                    using (SqlCommand cmd = new SqlCommand("spSelEventos", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                        cmd.Parameters.AddWithValue("@idRoll", Roll);
                        cmd.Parameters.AddWithValue("@codigoEmpleado", codigoEmpleado);

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
        public DataTable GetEventoComentarioId(int IdEvento, int idGerencia)
        {
            DataTable dt = new DataTable("tbl");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.CnEventos))
                {
                    using (SqlCommand cmd = new SqlCommand("spSelEventoComenatrioId", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idEvento", IdEvento);
                        cmd.Parameters.AddWithValue("@IdGerencia", idGerencia);

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
        public DataTable GetComentarioCliente (int idEvento, int codSupervisor)
        {
            DataTable dt = new DataTable("tbl");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.CnEventos))
                {
                    using (SqlCommand cmd = new SqlCommand("spSelComentarioCliente", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idEvento", idEvento);
                        cmd.Parameters.AddWithValue("@codSupervisor", codSupervisor);

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
        public DataTable GetEventoId(int IdEvento)
        {
            DataTable dt = new DataTable("tbl");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.CnEventos))
                {
                    using (SqlCommand cmd = new SqlCommand("spSelEventoId", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", IdEvento);                      

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
        public DataTable ValidaComentarioEvento (int IdEvento)
        {
            DataTable dt = new DataTable("tbl");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.CnEventos))
                {
                    using (SqlCommand cmd = new SqlCommand("spValidaComentariosEvento", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", IdEvento);

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
        public string AnulaEvento (int id)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            using (SqlConnection con = new SqlConnection(Conexion.CnEventos))
            {
                using (SqlCommand cmd = new SqlCommand("spAnulaEvento", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Id", id);                       

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
        public string ActualizaComentario(int idEvento, string comentario, int impacto, int nivelImpacto, int idGerencia)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            using (SqlConnection con = new SqlConnection(Conexion.CnEventos))
            {
                using (SqlCommand cmd = new SqlCommand("spActualizaComentarioEvento", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@idEvento", idEvento);
                        cmd.Parameters.AddWithValue("@comentario", comentario);
                        cmd.Parameters.AddWithValue("@Impacto", impacto);
                        cmd.Parameters.AddWithValue("@nivelImpacto", nivelImpacto);
                        cmd.Parameters.AddWithValue("@idGerencia", idGerencia);

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
        public DataTable ListEventos (int codigoEmpleado)
        {
            DataTable dt = new DataTable("tbl");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.CnEventos))
                {
                    using (SqlCommand cmd = new SqlCommand("spListaEventos", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodEmpleado", codigoEmpleado);

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
        public DataTable ListEventos(int idGerencia, int idDepartamento, string nombreEmpleado, DateTime Fi, DateTime Ff, int codigoEmpleado, int impacto, int comentada)
        {
            DataTable dt = new DataTable("tbl");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.CnEventos))
                {
                    using (SqlCommand cmd = new SqlCommand("spListaEventosM", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@CodEmpleado", codigoEmpleado);
                        cmd.Parameters.AddWithValue("@CodEmpleado", codigoEmpleado);
                        cmd.Parameters.AddWithValue("@CodEmpleado", codigoEmpleado);
                        cmd.Parameters.AddWithValue("@CodEmpleado", codigoEmpleado);
                        cmd.Parameters.AddWithValue("@CodEmpleado", codigoEmpleado);
                        cmd.Parameters.AddWithValue("@CodEmpleado", codigoEmpleado);
                        cmd.Parameters.AddWithValue("@CodEmpleado", codigoEmpleado);
                        cmd.Parameters.AddWithValue("@CodEmpleado", codigoEmpleado);

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
        public DataTable FiltarEventos(string nombreEmpleado, int codigoEmpleado, int GcodEmpleado)
        {
            DataTable dt = new DataTable("tbl");
            SqlConnection sqlCon = new SqlConnection();           

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.CnEventos))
                {
                    using (SqlCommand cmd = new SqlCommand("spSelFiltroEventos", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombreEmpleado", nombreEmpleado);
                        cmd.Parameters.AddWithValue("@codigoEmpleado", codigoEmpleado);
                        cmd.Parameters.AddWithValue("@codSupervisor", GcodEmpleado);


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
        public DataTable GetEventosporGerencia(int idGerencia)
        {
            DataTable dt = new DataTable("tbl");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.CnEventos))
                {
                    using (SqlCommand cmd = new SqlCommand("spSelEventosGerencia", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idGerencia", idGerencia);
                    
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
        public DataTable GetRepEventos(string opc, int idEvento, int codigoEmpleado)
        {



            DataTable dt = new DataTable("tbl");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.CnEventos))
                {
                    using (SqlCommand cmd = new SqlCommand("spSelRPTEventosInd", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Opcion", opc);
                        cmd.Parameters.AddWithValue("@idEvento", idEvento);
                        cmd.Parameters.AddWithValue("@codEmpleado", codigoEmpleado);

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
        public string InsertarComentarioCliente(int idEvento , int codSupervisor , string comentario, int impacto, int nImpacto)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            using (SqlConnection con = new SqlConnection(Conexion.CnEventos))
            {
                using (SqlCommand cmd = new SqlCommand("spInsComentarioCliente", con))
                {
                    try
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdEvento", idEvento);
                        cmd.Parameters.AddWithValue("@codSupervisor", codSupervisor);
                        cmd.Parameters.AddWithValue("@comentario", comentario);
                        cmd.Parameters.AddWithValue("@impacto", impacto);
                        cmd.Parameters.AddWithValue("@nImpacto", nImpacto);

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
        public DataTable GetRepComentariosClientes(int idEvento)

        {
            DataTable dt = new DataTable("tbl");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.CnEventos))
                {
                    using (SqlCommand cmd = new SqlCommand("spSelComentariosClientes", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idEvento", idEvento);
                        
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

        public DataTable GetDatosPersonas(string search)

        {
            DataTable dt = new DataTable("tbl");
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.CnEventos))
                {
                    using (SqlCommand cmd = new SqlCommand("spAutoCompletarEmpleado", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@search", search);

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
