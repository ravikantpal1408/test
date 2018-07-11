<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Waste_Mgmnt.Master" AutoEventWireup="true" CodeBehind="AllotVehicle.aspx.cs" Inherits="WebApplication1.AllotVehicals" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

   

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 <style>

        th {

            text-align:center !important;
        }


    </style>


      <br />
   <div class="row">
        <div class="col-sm-2"></div>
          <div class="col-sm-8">
              <center><span style="font-size:x-large;color:#523f6d"> Default Allocation</span></center>
              <hr/>
              <asp:GridView runat="server" ID="grdDefault" AutoGenerateColumns="false" Width="100%"  HeaderStyle-BorderWidth="5px" RowStyle-BorderWidth="3px" >
                  <Columns>
                       <asp:TemplateField HeaderText="Allocation ID" Visible="true"  HeaderStyle-BackColor="#523f6d" HeaderStyle-Height="40px" HeaderStyle-ForeColor="White" HeaderStyle-BorderWidth="3px">
                               <ItemTemplate >
                                   
                                    <asp:Label ID="lblAllotmentId" runat="server" Text='<%#Bind("AllotmentId") %>'></asp:Label>
                                   
                                </ItemTemplate>
                                <ControlStyle  />
                        
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                       <asp:TemplateField HeaderText="Driver" Visible="true"  HeaderStyle-BackColor="#523f6d" HeaderStyle-Height="40px" HeaderStyle-ForeColor="White" HeaderStyle-BorderWidth="3px">
                               <ItemTemplate >
                                   
                                    <asp:Label ID="lbldrivername" runat="server" Text='<%#Bind("drivername") %>'></asp:Label>
                                   
                                </ItemTemplate>
                                <ControlStyle  />
                        
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                      <asp:TemplateField HeaderText="Vehicle"  Visible="true"  HeaderStyle-BackColor="#523f6d" HeaderStyle-Height="40px" HeaderStyle-ForeColor="White" HeaderStyle-BorderWidth="3px">
                               <ItemTemplate >
                                   
                                    <asp:Label ID="lblvehicletype" runat="server" Text='<%#Bind("vehicletype") %>'></asp:Label>
                                   
                                </ItemTemplate>
                                <ControlStyle  />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                       <asp:TemplateField HeaderText="Route"  Visible="true"  HeaderStyle-BackColor="#523f6d" HeaderStyle-Height="40px" HeaderStyle-ForeColor="White" HeaderStyle-BorderWidth="3px">
                               <ItemTemplate >
                                   
                                    <asp:Label ID="lblRoute" runat="server" Text='<%#Bind("Routename") %>'></asp:Label>
                                   
                                </ItemTemplate>
                                <ControlStyle  />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
              <%--         <asp:TemplateField HeaderText="Allocation Date"  Visible="true"  HeaderStyle-BackColor="#523f6d" HeaderStyle-Height="40px" HeaderStyle-ForeColor="White" HeaderStyle-BorderWidth="3px">
                               <ItemTemplate >
                                   
                                    <asp:Label ID="lbldate" runat="server" Text='<%#Bind("date") %>'></asp:Label>
                                   
                                </ItemTemplate>
                                <ControlStyle  />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>--%>

                       <asp:TemplateField HeaderText=""  Visible="true"  HeaderStyle-BackColor="#523f6d" HeaderStyle-Height="40px" HeaderStyle-ForeColor="White" HeaderStyle-BorderWidth="3px">
                               <ItemTemplate >
                                   
                                <asp:ImageButton runat="server" ID="grvbtndelete" ImageUrl="~/img/delete-xxl.png" Width="30px" Height="30px" OnClick="grvbtndelete_Click" />
                                </ItemTemplate>
                                <ControlStyle  />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                  </Columns>

              </asp:GridView>

          </div>
          <div class="col-sm-2"></div>
         </div>
    <br /> <br /> <br /> <br /> 
<div class="row">

    <div class="col-sm-4">

 <h4>Select Zone :</h4>

    <asp:DropDownList runat="server" ID="ddlZone" OnSelectedIndexChanged="ddlZone_SelectedIndexChanged" CssClass="form-control" Width="200px" AutoPostBack="true">

    </asp:DropDownList>
    </div>
     <div class="col-sm-4">

          <h4>Select Ward :</h4>
    <asp:DropDownList runat="server" ID="ddlWard" OnSelectedIndexChanged="ddlWard_SelectedIndexChanged" CssClass="form-control" Width="200px" AutoPostBack="true" ></asp:DropDownList>
     </div>
     <div class="col-sm-4">

 <h4>Select Route :</h4>
     <asp:DropDownList runat="server" ID="ddlRoute" OnSelectedIndexChanged="ddlRoute_SelectedIndexChanged" CssClass="form-control" Width="200px" AutoPostBack="true" ></asp:DropDownList>
 
     </div>
</div>
 
   

    <br /> <br /> <br />


     <div class="row" runat="server" id="divlistbox" visible="false">
            
              <div class="col-sm-3">
               <div class="list-group" >
                <div class="list-group-item active">
                  <b class="list-group-item-heading">Select Driver</b>
                    <span class="list-group-item-heading" style="font-size:12px">(One at a time)</span>
    
              </div>
       
                    </div>
                              <asp:ListBox ID="ListLeft" runat="server" SelectionMode="Single" Height="211px" Width="100%" CssClass="form-control" >
              </asp:ListBox>
                  </div>
              <div class="col-sm-1"></div>
              
           

              <div class="col-sm-3">

                   <div class="list-group" >
                     <div class="list-group-item active">
                         <b class="list-group-item-heading">Select Vehicle</b>
                      <span class="list-group-item-heading" style="font-size:12px">(One at a time)</span>
                         </div>
                    </div>

                  <asp:ListBox  ID="ListRight" runat="server" SelectionMode="Single" Height="211px" Width="100%"  CssClass="form-control" >
                     

                  </asp:ListBox>

                 
                  </div>
          <div class="col-sm-1">

              <asp:Button runat="server" ID="btnsave" Text="Allocate" CssClass="btn-success"  style="margin-top:220px" OnClick="btnsave_Click" />
          </div>

          <div class="col-sm-3">

                   <div class="list-group" >
                     <div class="list-group-item active">
                         <b class="list-group-item-heading">Allocation </b>
                     
                         </div>
                    </div>

                  <asp:ListBox  ID="ListBoxAllotment" runat="server" SelectionMode="Single" Height="211px" Width="100%" CssClass="form-control" >
                     

                  </asp:ListBox>
             
                 
                  </div>
          <div class="col-sm-1">
               <%--   <asp:Button runat="server" ID="btndelete" CssClass="btn-danger" Text="Delete" style="margin-top:220px" OnClick="btndelete_Click"/>--%>
              </div>

              </div>

    <br/>
      <br/>
      <br/>
    <div class="row">
        <div class="col-sm-4"></div>
         <div class="col-sm-4">

            <%--  <asp:Button runat="server" ID="btnDetails" Text="All Allocation Details" CssClass="form-control btn-success" OnClick="btnDetails_Click" />--%>
         </div>
         <div class="col-sm-4"></div>
 
        </div>
    <br/>
     <div class="row" id="dvgrvDetails" runat="server">
        <div class="col-sm-2"></div>
          <div class="col-sm-8">
               <center><span style="font-size:x-large;color:#523f6d"> Today's Allocation</span></center>
              <hr/>
              <asp:GridView runat="server" ID="grvDetails" AutoGenerateColumns="false" AllowPaging="true" PageIndex="1" PageSize="10" Width="100%"  HeaderStyle-BorderWidth="5px" RowStyle-BorderWidth="3px" >
                  <Columns>
                       <asp:TemplateField HeaderText="Allocation ID" Visible="true"  HeaderStyle-BackColor="#523f6d" HeaderStyle-Height="40px" HeaderStyle-ForeColor="White" HeaderStyle-BorderWidth="3px">
                               <ItemTemplate >
                                   
                                    <asp:Label ID="lblAllotmentId" runat="server" Text='<%#Bind("AllotmentId") %>'></asp:Label>
                                   
                                </ItemTemplate>
                                <ControlStyle  />
                        
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                       <asp:TemplateField HeaderText="Driver" Visible="true"  HeaderStyle-BackColor="#523f6d" HeaderStyle-Height="40px" HeaderStyle-ForeColor="White" HeaderStyle-BorderWidth="3px">
                               <ItemTemplate >
                                   
                                    <asp:Label ID="lbldrivername" runat="server" Text='<%#Bind("drivername") %>'></asp:Label>
                                   
                                </ItemTemplate>
                                <ControlStyle  />
                        
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                      <asp:TemplateField HeaderText="Vehicle"  Visible="true"  HeaderStyle-BackColor="#523f6d" HeaderStyle-Height="40px" HeaderStyle-ForeColor="White" HeaderStyle-BorderWidth="3px">
                               <ItemTemplate >
                                   
                                    <asp:Label ID="lblvehicletype" runat="server" Text='<%#Bind("vehicletype") %>'></asp:Label>
                                   
                                </ItemTemplate>
                                <ControlStyle  />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                       <asp:TemplateField HeaderText="Route"  Visible="true"  HeaderStyle-BackColor="#523f6d" HeaderStyle-Height="40px" HeaderStyle-ForeColor="White" HeaderStyle-BorderWidth="3px">
                               <ItemTemplate >
                                   
                                    <asp:Label ID="lblRoute" runat="server" Text='<%#Bind("Routename") %>'></asp:Label>
                                   
                                </ItemTemplate>
                                <ControlStyle  />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                       <asp:TemplateField HeaderText="Allocation Date"  Visible="true"  HeaderStyle-BackColor="#523f6d" HeaderStyle-Height="40px" HeaderStyle-ForeColor="White" HeaderStyle-BorderWidth="3px">
                               <ItemTemplate >
                                   
                                    <asp:Label ID="lbldate" runat="server" Text='<%#Bind("date") %>'></asp:Label>
                                   
                                </ItemTemplate>
                                <ControlStyle  />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                       <asp:TemplateField HeaderText=""  Visible="true"  HeaderStyle-BackColor="#523f6d" HeaderStyle-Height="40px" HeaderStyle-ForeColor="White" HeaderStyle-BorderWidth="3px">
                               <ItemTemplate >
                                   
                                <asp:ImageButton runat="server" ID="grvbtndelete" ImageUrl="~/img/delete-xxl.png" Width="30px" Height="30px" OnClick="grvbtndelete_Click" />
                                </ItemTemplate>
                                <ControlStyle  />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                  </Columns>

              </asp:GridView>

          </div>
          <div class="col-sm-2"></div>
         </div>
  

</asp:Content>