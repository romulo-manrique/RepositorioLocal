using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Services;
using Newtonsoft.Json;
//using Negocio;
//using Datos;
using System.Web.UI;

public partial class View_WFCambioClave : System.Web.UI.Page
{
    string lUsuario;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["_usuario"].Equals(""))
            {
                Response.Redirect("WFrmAcceso.aspx", true);
            }
            else
            {
                lUsuario = Session["gsUsuario"].ToString();
                if (Session["_Roll"].Equals("4"))
                {
                }
            }
        }
    }

    protected  bool ValidaUsuario(string Usuario, string Password)
    {
        string Resp= string.Empty;
        DataTable DT = new DataTable();
        //DT = NUsuarios.ValidaUsuario(Usuario, Password);

        for (int i = 0; i < DT.Rows.Count; i++)
        {
            DataRow dr = DT.Rows[i];
            Resp = dr["Resp"].ToString();         
        }

        if (Resp.ToString().Equals("OK"))
        {
            return true;
        }
        else
        {
            return false;
        }        
    }

    protected void Unnamed_Click(object sender, EventArgs e)
    {
        if (!Password.Text.ToString().Equals("") && !PasswordActual.Text.ToString().Equals("") && !ConfirmPassword.Text.ToString().Equals(""))
        {
            if (!ValidaUsuario(Session["gsUsuario"].ToString(), PasswordActual.Text.ToString()))
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "mensaje('El Password actual no coincide con el registrado en la bases de Datos !!!')", true);
                return;
            }

            if (!Password.Text.ToString().Equals(ConfirmPassword.Text.ToString()))
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "mensaje('El nuevo password y la confirmación del mismo son diferentes !!!')", true);
                return;
            }


            //if (CambiaClave(Session["gsUsuario"].ToString(), Password.Text.ToString()).ToString().Equals("OK"))
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "mensaje('Registro de clave Exitoso, se le ha enviado un mensaje a su correo coorporativo con la confirmación del cambio, por favor verifique su bandeja de entrada !!!')", true);
            //    return;
            //}
            //else
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "mensaje('Error en la acción de actualizar Clave, comuniquese con su administrador del sistema !!! ')", true);
            //    return;
            //}

        }
        else
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "mensaje('Debe completar todos los datos solicitados !!!')", true);
        }
    }

    //protected string CambiaClave(string usuario, string clave)
    //{
    //    //return NUsuarios.CambioClave(usuario, clave);        
    //}

   
}