<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/HomeMaster.Master" AutoEventWireup="true" CodeFile="WFCalculaMayor.aspx.cs" Inherits="View_WFCalculaMayor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <script type="text/javascript"> 
         function calcular() {
             total = 0             i = 0                         $(".valor").each(                 function (index, value) {
                     total = total + eval($(this).val());                   
                 }             );   
         }         function nueva_linea() {
             $("#lineas").append('<div class="col-md-11"> <input type="number" class="form-control valor" value="0" min="1" max ="99999"/> <br/> </div> ');
         }                </script>

    <div class="form-horizontal">
        <div class="container">
        <div class="row">
        <div class="col-md-12">
            <div class="col-lg-12">
                <h2>Cálculo de Mayor valor</h2>
            </div>

    <div = class="form-group">    
        <div class="col-md-12">
            <div class="panel-group" id="accordion">
                <div class="panel panel-info">
                    <div class="panel-heading">
                        <h4 class="panel-title">
                            <a data-toggle="collapse" data-parent="#accordion" href="#collapse12">
                                Agregue valores positivos mayores a cero (0), este realiza la permutación de todos los valores posibles e imprime el de mayor de denominación.-
                            </a>
                        </h4>
                    </div>
                <div id="collapse12" class="panel-collapse collapse">
            <div class="panel-body">
           <div class="container">
        <div class="row">
            <div class="table-responsive">
                <div id="lineas">                    <div class="col-md-11"> 		            <input type="number" class="form-control valor" value="0" min="1" max ="99999"/><br/>	            </div>                    </div>                <div class="col-md-11">	                <label for="total">Total: <input type="text" id="total" value="0" class="form-control"  readonly="readonly"/> </label> <br/>	            </div>                <div class="col-md-11">                    <input type="button" class="btn btn-primary" value="Nueva l&iacute;nea" onclick="nueva_linea()"/>	                <input type="button" class="btn btn-primary" value="Calcular" onclick="calcular()" id="btnGuardar"/>                </div>             </div>          </div>        </div>    </div>    </div>    </div>
    </div>
</div>

</div>

</div>
</div>
</div>
</div>
    

<script src="../Content/js/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="http://cdn.jsdelivr.net/json2/0.1/json2.js"></script>
<script type="text/javascript">   
    $('#btnGuardar').click(function () {
        i = 0        var valores = new Array()        $(".valor").each(            function (index, value) {
                total = total + eval($(this).val());
                valores.push(eval($(this).val()));
            }        );
        var permite = true;
        var user = {};
        for (var i = 0; i < valores.length; i++) {
            if (valores[i] < 0)
            {               
                permite = false
            }
        }

        if (permite) {
            $.ajax({
                type: "POST",
                url: "WFCalculaMayor.aspx/CalculaValor",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({
                    valores: valores
                }),
                dataType: "json",
                success: function (result) {                   
                    var dataEventoComenatrio = $.parseJSON(result.d);
                    $("#total").val(Math.floor(result.d));
                },
                error: function (result) {
                    showAlert("Error de app !!!", "danger", 4500);
                }
            });
        } else {
          
            showAlert("Existe un valor no permitido en los datos de entrada !!!", "danger", 4500);
        }
    });
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
</asp:Content>

