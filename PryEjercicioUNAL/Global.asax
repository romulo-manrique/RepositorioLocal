<%@ Application Language="C#" %>

<script runat="server">
        

    void Application_Start(object sender, EventArgs e) 
    {
        

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        Session["gsUsuario"] = string.Empty;
        Session["_usuario"] = string.Empty;
        Session["_cedula"] = string.Empty;
        Session["_codEmpleado"] = 0;
        Session["_respuesta"] = string.Empty;
        Session["_correo"] = string.Empty;
        Session["_estatus"] = false;
        Session["_registro"] = null;
        Session["_ultimoAcceso"] = null;
        Session["_Roll"] = null;

        Session["_NombreEmpG"] = null;
        Session["_CodigoEmpG"] = null;
    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Código que se ejecuta cuando se produce un error sin procesar

    }

    void Session_Start(object sender, EventArgs e) 
    {
        Session["gsUsuario"] = "";
        Session["_usuario"] = string.Empty;
        Session["_cedula"] = string.Empty;
        Session["_codEmpleado"] = 0;
        Session["_respuesta"] = string.Empty;
        Session["_correo"] = string.Empty;
        Session["_estatus"] = false;
        Session["_registro"] = null;
        Session["_ultimoAcceso"] = null;
        Session["_Roll"] = null;
        Session["_NombreEmpG"] = null;
        Session["_CodigoEmpG"] = null;
    }

    void Session_End(object sender, EventArgs e) 
    {
       Session["gsUsuario"] = "";
        Session["_usuario"] = string.Empty;
        Session["_cedula"] = string.Empty;
        Session["_codEmpleado"] = 0;
        Session["_respuesta"] = string.Empty;
        Session["_correo"] = string.Empty;
        Session["_estatus"] = false;
        Session["_registro"] = null;
        Session["_ultimoAcceso"] = null;
        Session["_Roll"] = null;
        Session["_NombreEmpG"] = null;
        Session["_CodigoEmpG"] = null;
    }
       
</script>
