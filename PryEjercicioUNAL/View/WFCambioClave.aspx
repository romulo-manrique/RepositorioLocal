<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/HomeMaster.Master" AutoEventWireup="true" CodeFile="WFCambioClave.aspx.cs" Inherits="View_WFCambioClave" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <h4> Registro de Usuario</h4>
        <hr />        
        <div class="form-horizontal">
            <div class ="container">
           <div class="col-lg-6">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title"> Cambio de Password:  </h3>
                    </div>
                        <div class="panel-body">
                            <asp:ValidationSummary runat="server" CssClass="text-danger" />
                            <div class="form-group">
                                
                                <div class="col-md-12">
                                    <asp:TextBox runat="server" ID="PasswordActual" TextMode="Password" CssClass="form-control" placeholder="Password Actual" required=""  />
                                   
                                </div>
                            </div>
                            <div class="form-group">
                              
                                <div class="col-md-12">
                                    <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" placeholder="Password" required=""  />
                                  
                                </div>
                            </div>
                            <div class="form-group">
                               
                                <div class="col-md-12">
                                    <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" placeholder="Confirme Password" required=""  />
                                   
                                </div>
                            </div>                        

                              <div class="form-group">
                                    <div class="col-md-offset-5 col-md-12">
                                        <asp:Button runat="server" Text="Enviar" CssClass="btn btn-primary" OnClick="Unnamed_Click" />
                                    </div>
                              </div>
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
        
     </script>
</asp:Content>

