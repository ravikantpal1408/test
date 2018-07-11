<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Waste_Mgmnt.Master" AutoEventWireup="true" CodeBehind="masterview.aspx.cs" Inherits="WebApplication1.masterview" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>

        body { padding-top:20px; }
.panel-body .btn:not(.btn-block) { width:120px;margin-bottom:10px; }
    </style>
    <script>

        function addbins() {

            $("#addbins").show();
            $("#viewbins").hide();
            $("#addfeeders").hide();
            $("#viewfeeders").hide();
            $("#addpu").hide();
            $("#viewpu").hide();





        }

        function viewbins() {

            $("#addbins").hide();
            $("#viewbins").show();
            $("#addfeeders").hide();
            $("#viewfeeders").hide();
            $("#addpu").hide();
            $("#viewpu").hide();





        }
        function addfeeder() {

            $("#addbins").hide();
            $("#viewbins").hide();
            $("#addfeeders").show();
            $("#viewfeeders").hide();
            $("#addpu").hide();
            $("#viewpu").hide();





        }
        function viewfeeder() {

            $("#addbins").hide();
            $("#viewbins").hide();
            $("#addfeeders").hide();
            $("#viewfeeders").show();
            $("#addpu").hide();
            $("#viewpu").hide();





        }
        function addpu() {

            $("#addbins").hide();
            $("#viewbins").hide();
            $("#addfeeders").hide();
            $("#viewfeeders").hide();
            $("#addpu").show();
            $("#viewpu").hide();





        }

        function viewpu() {

            $("#addbins").hide();
            $("#viewbins").hide();
            $("#addfeeders").hide();
            $("#viewfeeders").hide();
            $("#addpu").hide();
            $("#viewpu").show();





        }






    </script>




                    <div class="row">
                        <div class="col-xs-9 col-md-9">
                          <a href="#" onclick="addbins();" class="btn btn-danger btn-lg" role="button"><span class="fa fa-trash fa-1x"></span> <br/>Add Bins</a>
                          <a href="#" onclick="viewbins();" class="btn btn-warning btn-lg" role="button"><span class="fa fa-trash fa-1x"></span> <br/>View Bins</a>
                          <a href="#" onclick="addfeeder();" class="btn btn-info btn-lg" role="button"><span class="glyphicon glyphicon-signal"></span> <br/>Add Feeder</a>
                          <a href="#" onclick="viewfeeder();" class="btn btn-primary btn-lg" role="button"><span class="glyphicon glyphicon-signal"></span> <br/>View Feeder</a>
                   
                          <a href="#" onclick="addpu();" class="btn btn-success btn-lg" role="button"><span class="fa fa-cog fa-1x"></span> <br/>Add PU</a>
                          <a href="#" onclick="viewpu();" class="btn btn-info btn-lg" role="button"><span class="fa fa-cog fa-1x"></span> <br/>View PU</a>
                       
                        </div>
                    </div>


    
         <iframe id="addbins" style="display:none;width:100%;height:800px;border:0px" src="addbins1.aspx" ></iframe>
         <iframe id="viewbins" style="display:none;width:100%;height:800px;border:0px" src="viewbins1.aspx" ></iframe>
         <iframe id="addfeeders" style="display:none;width:100%;height:800px;border:0px" src="addfeeders1.aspx" ></iframe>
         <iframe id="viewfeeders" style="display:none;width:100%;height:800px;border:0px" src="viewfeeders1.aspx" ></iframe>
         <iframe id="addpu" style="display:none;width:100%;height:800px;border:0px" src="pu1.aspx" ></iframe>
         <iframe id="viewpu" style="display:none;width:100%;height:800px;border:0px" src="viewpu1.aspx" ></iframe>
        





</asp:Content>
