<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Waste_Mgmnt.Master" AutoEventWireup="true" CodeBehind="vehicle_driver.aspx.cs" Inherits="WebApplication1.vehicle_driver" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="row">
    <div id="grd_vw" class="col-sm-3">
      <asp:GridView ID="grid_vehicle" style="width:30%" class="table table-bordered table-striped" runat="server" AutoGenerateColumns="False">
        <EmptyDataTemplate>
            <asp:Label ID="Label8" runat="server" Text="No Data Found"  ForeColor="Red"></asp:Label>
        </EmptyDataTemplate>
        <Columns>
            
            <asp:TemplateField HeaderText="Vehicle ID">
                <ItemTemplate>
                     <asp:Label ID="Label4" runat="server" Text='<%# Eval("vehicle_num") %>'></asp:Label>
                    
                </ItemTemplate>
            </asp:TemplateField>
        
            <asp:TemplateField HeaderText="Vehicle">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("vehicle_type") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="select">
                <ItemTemplate>
                   <asp:LinkButton ID="LinkDel" runat="server"  style="color:#1d9f75"><i class="fa fa-trash-o" aria-hidden="true" style="font-size:30px;"></i></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        
        </Columns>
    </asp:GridView>



  </div>
    <div class="col-sm-3"></div>



    <div id="Div1" class="col-sm-3">
      <asp:GridView ID="grid_driver" style="width:30%" class="table table-bordered table-striped" runat="server" AutoGenerateColumns="False">
        <EmptyDataTemplate>
            <asp:Label ID="Label8" runat="server" Text="No Data Found"  ForeColor="Red"></asp:Label>
        </EmptyDataTemplate>
        <Columns>
            
            <asp:TemplateField HeaderText="S.no">
                <ItemTemplate>
                     <asp:LinkButton ID="LinkDel" runat="server"  style="color:#1d9f75"><i class="fa fa-trash-o" aria-hidden="true" style="font-size:30px;"></i></asp:LinkButton>
                    
                    
                </ItemTemplate>
            </asp:TemplateField>
        
            <asp:TemplateField HeaderText="Driver ID">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("DriverID") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Driver Name">
                <ItemTemplate>
                   <asp:Label ID="Label4" runat="server" Text='<%# Eval("DriverName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        
        </Columns>
    </asp:GridView>



  </div>
    </div>
    

</asp:Content>
