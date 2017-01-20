<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/HomeMaster.Master" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="View_Default2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="form-horizontal" >
                 <div class="container">
        <div class="col-lg-12">
            <div class="col-lg-12">
                <h2>Lista de Eventos</h2>
            </div>
            <br />
            <div class="col-lg-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title"> Filtro </h3>
                    </div>
                        <div class="panel-body">                                                    
                            <div class="form-group">                                                        
                                <div class="col-md-3">
                                    <asp:Label ID="Label5" runat="server" Text="Fecha Inicial"></asp:Label>                           
                                    <div>
                                        <input type="date" name="Doj" id="fInicial" class="form-control datepicker" required="" />
                                    </div>                                                  
                                </div>
                                <div class="col-md-3">
                                    <asp:Label ID="Label6" runat="server" Text="Fecha Final"></asp:Label>                           
                                    <div>
                                        <input type="date" name="Doj" id="fFinal" class="form-control datepicker" required="" />
                                    </div>                                                  
                                </div>  
                                <div class="col-md-2 col-md-offset-4">
                                    <asp:Label ID="Label9" runat="server" Text=" " CssClass="label"></asp:Label>                                  
                                    <div>
                                        <asp:Button ID="Button1" runat="server" Text="Buscar" CssClass="form-control btn btn-primary" OnClientClick="return showDialog('You are doing it in the right way', 'Message', 'eliminar')" />    
                                        <input id="btnPrueba" type="button" class =" form-control btn btn-primary" />                                                               
                                    </div>
                                </div>
                                
                               </div>                          
                            </div>                            
                </div>
            </div>
            <div class="col-lg-12">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h3 class="panel-title"> Eventos </h3>
                    </div>
                        <div class="panel-body">
                            <div class="row">
                                    <div class="table-responsive">
                                        <table id="dataTables-example" class="table table-striped table-bordered table-hover dataTable no-footer" role="grid" aria-describedby="dataTables-example_info">
                                            <thead>
                                                <tr role="row">
                                                    <th class="sorting_asc" tabindex="0" aria-controls="dataTables-example" rowspan="1" colspan="1" style="width: 175px;" aria-sort="ascending" aria-label="Rendering engine: activate to sort column descending">Nro</th>
                                                    <th class="sorting" tabindex="0" aria-controls="dataTables-example" rowspan="1" colspan="1" style="width: 203px;" aria-label="Browser: activate to sort column ascending">Empleado</th>
                                                    <th class="sorting" tabindex="0" aria-controls="dataTables-example" rowspan="1" colspan="1" style="width: 203px;" aria-label="Browser: activate to sort column ascending">Evento</th>
                                                    <th class="sorting" tabindex="0" aria-controls="dataTables-example" rowspan="1" colspan="1" style="width: 184px;" aria-label="Platform(s): activate to sort column ascending">Registrado por</th>
                                                    <th class="sorting" tabindex="0" aria-controls="dataTables-example" rowspan="1" colspan="1" style="width: 150px;" aria-label="Engine version: activate to sort column ascending">Fecha</th>
                                                    <th class="sorting" tabindex="0" aria-controls="dataTables-example" rowspan="1" colspan="1" style="width: 108px;" aria-label="CSS grade: activate to sort column ascending">Revisado</th>                                                   
                                                  
                                                </tr>
                                            </thead>
                                            <tbody>
                                               <%-- <% for (var data = 0; data < TableData.Rows.Count; data++)
                                                   { %>
                                                <tr class="gradeA odd" role="row">
                                                    <td class="sorting_1"><%=TableData.Rows[data]["FName"]%>  <%=TableData.Rows[data]["LName"]%></td>
                                                    <td><%=TableData.Rows[data]["EMail"]%></td>
                                                    <td><%=TableData.Rows[data]["Telephone"]%></td>
                                                    <td><%=TableData.Rows[data]["Mobile"]%></td>
                                                    <td><%=TableData.Rows[data]["DOJ"]%></td>
                                                    <td><%=TableData.Rows[data]["DOB"]%></td>
                                                    <td>
                                                        <input type="button" class="btn btn-primary editButton" data-id="<%=TableData.Rows[data]["EmpId"] %>" data-toggle="modal" data-target="#myModal" name="submitButton" id="btnEdit" value="Edit" /></td>
                                                    <td>
                                                        <input type="button" class="btn btn-primary deleteButton" data-id="<%=TableData.Rows[data]["EmpId"] %>" name="submitButton" id="btnDelete" value="Delete" /></td>
                                                </tr>
                                                <% } %>--%>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                        </div> 
                 </div> 
             </div> 
        </div>        


             <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
             <script type="text/javascript" src="http://cdn.jsdelivr.net/json2/0.1/json2.js"></script>
           </div>
       </div>               


    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript" src="http://cdn.jsdelivr.net/json2/0.1/json2.js"></script>
    <script type="text/javascript">
        $(function () {    

            $('#btnPrueba2').click(function (e) {
                alert("Entro por aqui");
            });

            $('#btnPrueba').click(function (e) {
                alert("Entro por aqui 2");
            });
        });

    </script>
    <script src="../Content/js/jquery.dataTables.js"></script>
</asp:Content>

