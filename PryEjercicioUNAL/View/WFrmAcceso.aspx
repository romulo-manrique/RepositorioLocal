<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WFrmAcceso.aspx.cs" Inherits="View_WFrmAcceso" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">           
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Bitácora Empleados</title>
    <meta name="viewport" content="width=device-width, initial-scale=1" /> 
    <link href="../Content/css/bootstrap.css" rel="stylesheet" />
    <script src="../Content/js/bootstrap.min.js"></script>  
    
    <style type="text/css">
        body{padding-top:20px;}
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
         <div class="container"  >
            <div class="row">
		        <div class="col-md-4 col-md-offset-4 centered">
    		        <div class="panel panel-default">
			  	        <div class="panel-heading">
			    	        <h3 class="panel-title">[Login] Ejercicio UNAL (romulo.manrique - 42382) </h3>
			 	        </div>
			  	        <div class="panel-body">
			    	
                            <fieldset>
			    	  	        <div class="form-group">
                                      <asp:TextBox class="form-control"  ID="txtLogin" placeholder="Ingrese Usuario"  runat="server" required=""></asp:TextBox>
			    		        </div>

			    		        <div class="form-group">			    			
                                    <asp:TextBox class="form-control"  placeholder="Ingrese Clave" ID="txtPassword" runat="server" TextMode="Password" required=""></asp:TextBox>
			    		        </div>
                       	
			    		        <asp:Button class="btn btn-default btn-primary" ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" />
                                <br />
                                <br />
                               <%-- <div class="form-group">
                                    <asp:HyperLink  NavigateUrl="~/View/WFRecuperaInf.aspx" ID="HyperLink1" runat="server" >Recuperar Clave </asp:HyperLink>
                                </div>     --%>                   

			    	        </fieldset>
			     
			            </div>
			        </div>
		        </div>
	        </div>
        </div>	
        <script type="text/javascript" language="javascript">

          function mensaje(mensaje)
          {
                alert(mensaje)
          }

          function showAlert(message, type, closeDelay) {
              if ($("#alerts-container").length == 0) {                 
                  $("body")
                      .append($('<div id="alerts-container" style="position: fixed; width: 50%; left: 25%; top: 40%;">'));
              }                         
              type = type || "info";
             
              var alert = $('<div class="alert alert-' + type + ' fade in">')
                  .append(
                      $('<button type="button" class="close" data-dismiss="alert">')
                      .append("&times;")
                  )
                  .append(message);

              
              $("#alerts-container").prepend(alert);              
              if (closeDelay)
                  window.setTimeout(function () { alert.alert("close") }, closeDelay);
          }
       </script>
    </form>
    </body>
</html>
