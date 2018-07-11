<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Waste_Mgmnt.Master" AutoEventWireup="true" CodeBehind="Grid_View_bins.aspx.cs" Inherits="WebApplication1.Grid_View_bins" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
    <div>
        <h2>Bin Details</h2>
       
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
            
            <asp:TemplateField HeaderText="BinId">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Binid") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Bin Name">
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Eval("BinName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
               <asp:TemplateField HeaderText="Area Name">
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Eval("Area_Name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Latitude">
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Latitude") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Longitude">
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Eval("Longitude") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Zone Name">
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Eval("ZoneName") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Ward Name">
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Eval("Ward_Name") %>'></asp:Label>
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
            <asp:TemplateField HeaderText="Serial ID">
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("SerialId") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Edit/Delete">
                <ItemTemplate>
                    <asp:LinkButton ID="LnkEdit" style="color:#1d9f75" runat="server" OnClick="LnkEdit_Click"><i class="fa fa-pencil-square-o" aria-hidden="true" style="font-size:30px;"></i></asp:LinkButton>&nbsp; /&nbsp;<asp:LinkButton ID="LinkDel" style="color:#1d9f75" runat="server" OnClick="LinkDel_Click"><i class="fa fa-trash-o" aria-hidden="true" style="font-size:30px;"></i></asp:LinkButton>&nbsp
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
