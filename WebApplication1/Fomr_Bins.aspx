<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Waste_Mgmnt.Master" AutoEventWireup="true" CodeBehind="Fomr_Bins.aspx.cs" Inherits="WebApplication1.Fomr_Bins" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <fieldset style="margin-top:40px">
            <legend>
                <h3><a style="color:black">Bins</a>/<a style="color:black">Processing Units</a>/<a style="color:black">Feeders</a></h3></legend></fieldset>

     </div>
       <div class="row">
        <div class="col-sm-2" style=" height:40px;background-color:lavender;border:1px solid;"><h4>Serial No.s</h4></div>
        <div class="col-sm-5" style="height:40px;background-color:lavender;border:1px solid;"><h4>Bins Details</h4></div>
        <div class="col-sm-5" style="height:40px;background-color:lavender;border:1px solid"><h4>Status</h4></div>
     </div>

    
   
    

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField></asp:TemplateField>
            <asp:TemplateField></asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
