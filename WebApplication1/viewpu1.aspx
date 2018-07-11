<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewpu1.aspx.cs" Inherits="WebApplication1.viewpu1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <link href="~/tcal.css" rel="stylesheet" />
	<link href="tcal.css" rel="stylesheet" />  
    <link rel="stylesheet" type="text/css" href="tcal.css" />
	<script type="text/javascript" src="tcal.js"></script>  
    <link rel="stylesheet" href="css/datepicker.css"/>
    <link href="~/vendor/bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="~/vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <link href="~/Custom%20CSS/Custom.css" rel="stylesheet" />
    <link href="~/Custom%20CSS/map.css" rel="stylesheet" />
    <link href="~/vendor/morrisjs/morris.css" rel="stylesheet" />
    <link href="~/vendor/metisMenu/metisMenu.css" rel="stylesheet" />
    <link href="~/vendor/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="~/vendor/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <link href="~/dist/css/sb-admin-2.min.css" rel="stylesheet" />
    <link href="~/dist/css/sb-admin-2.css" rel="stylesheet" />
    <link href="~/Custom%20CSS/toggle.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">

         <div class="row">
  <div>
        <h2>Processing Unit Details</h2>
       
               <hr/>
               <div class="col-sm-2">
                   <h4>Zone Wise</h4>
                   
               </div>
          <div class="col-sm-3">
                  <asp:DropDownList ID="Ddlzone" AutoPostBack="true" class="form-control" runat="server" OnSelectedIndexChanged="Ddlzone_SelectedIndexChanged"></asp:DropDownList>
                   
               </div>
        <div class="col-sm-2">
            &nbsp;
            </div>
                <div class="col-sm-2">
                   <h4>Ward Wise</h4>
                  
               </div>
         <div class="col-sm-3">
              <asp:DropDownList ID="Ddlword" AutoPostBack="true" class="form-control" runat="server" OnSelectedIndexChanged="Ddlword_SelectedIndexChanged"></asp:DropDownList>
               <br/>
              </div>
        </div>
     <hr/>
        </div>
    <asp:GridView ID="GridView1" class="table table-bordered table-striped" runat="server" AutoGenerateColumns="False">
         <EmptyDataTemplate>
            <asp:Label ID="Label8" runat="server" Text="No Data Found"  ForeColor="Red"></asp:Label>
        </EmptyDataTemplate>
        <Columns>
            <asp:TemplateField HeaderText="Feeder Id">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Feeder Name">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="Area Name">
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("AreaName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Latitude">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("lat") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Longitude">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("lon") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Zone Name">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("Zone_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ward Name">
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("ward_name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Edit/Delete">
               <ItemTemplate>
                    <asp:LinkButton ID="LinkEdit" style="color:#1d9f75" runat="server" OnClick="LinkEdit_Click"><i class="fa fa-pencil-square-o" aria-hidden="true" style="font-size:30px;"></i></asp:LinkButton>&nbsp
                    /&nbsp<asp:LinkButton ID="LinkDel" style="color:#1d9f75" runat="server" OnClick="LinkDel_Click"><i class="fa fa-trash-o" aria-hidden="true" style="font-size:30px;"></i></asp:LinkButton>&nbsp
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    
    </div>
    </form>
</body>
</html>
