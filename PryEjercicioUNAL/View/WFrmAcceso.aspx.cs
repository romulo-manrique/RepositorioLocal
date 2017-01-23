using System;
//using Negocio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class View_WFrmAcceso : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        //NUsuarios Usuario = new NUsuarios();

        DataTable dt = new DataTable();

        //dt = NUsuarios.ValidaUsuario(txtLogin.Text.ToString(), txtPassword.Text.ToString());       

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow dr = dt.Rows[i];
            if (dr["Resp"].ToString().Equals("OK"))
            {
                Session["gsUsuario"] = dr["sUsuario"].ToString();
                Session["_usuario"] = dr["nIdUsuario"].ToString();
                Session["_cedula"] = dr["sCedula"].ToString();
                Session["_codEmpleado"] = dr["nCodigoEmp"].ToString();
                Session["_respuesta"] = dr["Resp"].ToString();
                Session["_correo"] = dr["sCorreoE"].ToString();
                Session["_estatus"] = dr["bEstado"].ToString();
                Session["_registro"] = dr["fRegistro"].ToString();
                Session["_ultimoAcceso"] = dr["fAcceso"].ToString();
                Session["_Roll"] = dr["nIdRol"].ToString();
                Session["_nombreUsuario"] = dr["nombreUsuario"].ToString();
                Session["_idGerencia"] = dr["idGerencia"].ToString();
                Response.Redirect("Default.aspx", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "mensaje('Usuario y/o Clave invalida !!!')", true);
                
            }
        }

    }
}