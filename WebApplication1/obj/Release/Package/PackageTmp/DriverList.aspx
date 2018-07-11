<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Waste_Mgmnt.Master" AutoEventWireup="true" CodeBehind="DriverList.aspx.cs" Inherits="WebApplication1.DriverList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" width="60%"><fieldset><legend><h1>Driver's List</h1></legend> </fieldset>
    <asp:GridView ID="grdDriver" class="table table-bordered table-striped"  runat="server" AutoGenerateColumns="False">
        <EmptyDataTemplate>
            <asp:Label ID="Label9" runat="server" Text="No Data Found"  ForeColor="Red"></asp:Label>
        </EmptyDataTemplate>
        <Columns>
            
            <asp:TemplateField HeaderText="LICENCE NUMBER">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("licence_n") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="NAME">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <%--   <asp:TemplateField HeaderText="PERMANENT ADDRESS">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("p_address") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="RESIDENTIAL ADDRESS">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("r_address") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="EMAIL">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("email") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="MOBILE">
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("mobile") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DATE OF BIRTH">
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("dob") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
           <%-- <asp:TemplateField HeaderText="Zone Name">
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("Zoneid") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
           <%-- <asp:TemplateField HeaderText="Ward Name">
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("ward_nam") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="VEHICLES CAPABLE OF DRIVING">
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Eval("typeOFveh") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Edit/Delete">
                <ItemTemplate>
                    <asp:LinkButton ID="LnkEdit" style="color:#1d9f75" runat="server" OnClick="LnkEdit_Click" ><i class="fa fa-pencil-square-o" aria-hidden="true" style="font-size:30px;"></i></asp:LinkButton>&nbsp; /&nbsp;<asp:LinkButton ID="LinkDel" style="color:#1d9f75" runat="server" OnClick="LinkDel_Click" ><i class="fa fa-trash-o" aria-hidden="true" style="font-size:30px;"></i></asp:LinkButton>&nbsp
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
       
        </div>
</asp:Content>
