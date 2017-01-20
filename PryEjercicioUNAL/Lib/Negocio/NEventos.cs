using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NEventos
    {
        public static string Insertar(int Id, int idUsuario ,int idCargo, int idDepartamento, int idEmpresa, int idGerencia, int idTipo, int codigoEmpreado, int codigoSupervisor, string titulo, string descripcion, string actividades, string logros, bool Estastus, int[] mGerencias, int[] mCompetencias, int impacto, int nivelImpacto)
        {
            DEventos Obj = new DEventos();

            Obj.Id = Id;
            Obj.idUsuario = idUsuario;
            Obj.idCargo = idCargo;
            Obj.idDepartamento = idDepartamento;
            Obj.idEmpresa = idEmpresa;
            Obj.idGerencia = idGerencia;
            Obj.idTipo = idTipo;
            Obj.codigoEmpleado = codigoEmpreado;
            Obj.codigoSupervisor = codigoSupervisor;
            Obj.Titulo = titulo;
            Obj.Descripcion = descripcion;
            Obj.Actividades = actividades;
            Obj.Logros = logros;
            Obj.Estatus = Estastus;
            Obj.Impacto = impacto;
            Obj.NivelImpacto = nivelImpacto;

            return Obj.Insertar(Obj, mGerencias, mCompetencias);
        }

        public static string Actualizar(int Id, int idUsuario, int idCargo, int idDepartamento, int idEmpresa, int idGerencia, int idTipo, int codigoEmpreado, int codigoSupervisor, string titulo, string descripcion, string actividades, string logros, bool Estastus, int impacto, int nivelImpacto)
        {
            DEventos Obj = new DEventos();

            Obj.Id = Id;
            Obj.idUsuario = idUsuario;
            Obj.idCargo = idCargo;
            Obj.idDepartamento = idDepartamento;
            Obj.idEmpresa = idEmpresa;
            Obj.idGerencia = idGerencia;
            Obj.idTipo = idTipo;
            Obj.codigoEmpleado = codigoEmpreado;
            Obj.codigoSupervisor = codigoSupervisor;
            Obj.Titulo = titulo;
            Obj.Descripcion = descripcion;
            Obj.Actividades = actividades;
            Obj.Logros = logros;
            Obj.Estatus = Estastus;
            Obj.Impacto = impacto;
            Obj.NivelImpacto = nivelImpacto;

            return Obj.Actalizar(Obj);
        }

        public static DataTable getEventos(int idUsuario, int idRoll, int codigoEmpleado)
        {
            DEventos Obj = new DEventos();

            return Obj.GetComentarios(idUsuario, idRoll, codigoEmpleado);
        }

        public static DataTable getEventoId (int idEvento)
        {
            DEventos Obj = new DEventos();

            return Obj.GetEventoId(idEvento);
        }
        public static DataTable getEventoComentarioId (int idEvento, int idGerencia)
        {
            DEventos Obj = new DEventos();

            return Obj.GetEventoComentarioId(idEvento, idGerencia);
        }
        public static DataTable getComentarioCliente(int idEvento, int codSupervisor)
        {
            DEventos Obj = new DEventos();

            return Obj.GetComentarioCliente(idEvento, codSupervisor);
        }
        public static DataTable listaEventos(int codigoEmpleado)
        {
            DEventos Obj = new DEventos();

            return Obj.ListEventos(codigoEmpleado);
        }
        public static DataTable ValidaComentarioEvento(int id )
        {
            DEventos Obj = new DEventos();

            return Obj.ValidaComentarioEvento(id);
        }
        public static string AnulaEvento(int id)
        {
            DEventos Obj = new DEventos();

            return Obj.AnulaEvento(id).ToString();
        }
        public static string ActualizaComentario(int idEvento, string comentario, int impacto, int nivelImapcto, int idGerencia)
        {
            DEventos Obj = new DEventos();

            return Obj.ActualizaComentario(idEvento, comentario, impacto, nivelImapcto, idGerencia);                
        }

        public static DataTable filtroEventos(string nombreEmpleado, int codigoEmpleado, int GcodEmpleado)
        {
            DEventos Obj = new DEventos();
            return Obj.FiltarEventos(nombreEmpleado, codigoEmpleado, GcodEmpleado);
        }

        public static DataTable EventosGerencias(int idGerencia)
        {
            DEventos Obj = new DEventos();
            return Obj.GetEventosporGerencia(idGerencia);
        }

        public static DataTable GetRepEventos(string opc, int idEvento, int codigoEmpleado)
        {
            DEventos Obj = new DEventos();
            return Obj.GetRepEventos(opc, idEvento, codigoEmpleado);
        }

        public static string guardaComentarioCliente(int idEvento, int codSupervisor, string comentario, int impacto, int nImpacto)
        {
            DEventos Obj = new DEventos();
            return Obj.InsertarComentarioCliente(idEvento, codSupervisor, comentario, impacto, nImpacto);
        }

        public static DataTable GetRepComentariosClientes(int idEvento)
        {
            DEventos Obj = new DEventos();
            return Obj.GetRepComentariosClientes(idEvento);
        }

        public static DataTable GetDatosPersona(string search)
        {
            DEventos Obj = new DEventos();
            return Obj.GetDatosPersonas(search);  
        }

    }
}
