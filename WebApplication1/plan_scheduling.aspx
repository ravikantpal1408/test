<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Waste_Mgmnt.Master" AutoEventWireup="true" CodeBehind="plan_scheduling.aspx.cs" Inherits="WebApplication1.plan_scheduling" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <script src="dist1/sweetalert-dev.js"></script>
     <link href="dist1/sweetalert.css" rel="stylesheet" />

    <div class="row">
        <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
         <div style="margin-top:20px"><fieldset><legend><h2>Plan Schedule</h2></legend></fieldset></div>
              <div class="col-sm-2" style="margin-top:10px" >
                   <h4>Zone </h4>
                   
               </div>
          <div class="col-sm-3" style="margin-top:10px">
                  <asp:DropDownList ID="ddl_zone" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_zone_SelectedIndexChanged"  ></asp:DropDownList>
                   
               </div>

                   <div class="col-sm-2" style="margin-top:10px">
                        &nbsp;
                        </div>
                            <div class="col-sm-2" style="margin-top:10px" >
                               <h4>Ward </h4>
                  
                           </div>

    <div class="col-sm-3" style="margin-top:10px">
              <asp:DropDownList ID="ddl_ward" class="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddl_ward_SelectedIndexChanged" ></asp:DropDownList>
               <br/>
              </div>
   
        </div>

    <br />
    <br />
    <br />
   <div class="container">
       
          <div class="row">
            
              <div class="col-sm-3">
               <div class="list-group" style="height:50%">
                <div class="list-group-item active">
                  <h4 class="list-group-item-heading">Select Bins</h4>
                    <h5 class="list-group-item-heading">Select One at a time. </h5>
    
              </div>
       
                    </div>
                              <asp:ListBox ID="ListLeft" runat="server" SelectionMode="Multiple" Height="311px" Width="100%" OnSelectedIndexChanged="ListLeft_SelectedIndexChanged">
              </asp:ListBox>
                  </div>
              <div class="col-sm-1"></div>
              <div class="col-sm-2" style="margin-top:15%">


                  <br />


                  <asp:Button ID="btnLeft" runat="server" Text=">>" OnClick="btnLeft_Click" />
                  <br /><br />
                  <asp:Button ID="btnRight" runat="server" Text="<<" OnClick="btnRight_Click" />
                  <br /><br />
                   <asp:Button ID="Remove" runat="server" Text="Remove" OnClick="Remove_Click" Visible="False" />

                  <br />

              </div>
           

              <div class="col-sm-3">

                   <div class="list-group" >
                     <div class="list-group-item active">
                         <h4 class="list-group-item-heading">Selected </h4>
                       <h5 class="list-group-item-heading">Bins</h5>
                         </div>
                    </div>

                  <asp:ListBox  ID="ListRight" runat="server" SelectionMode="Multiple" Height="311px" Width="100%" OnSelectedIndexChanged="ListRight_SelectedIndexChanged">
                     

                  </asp:ListBox>

                  </div>

              </div>


     
       <div class="row">
                     <script>
                         function rightlistcheck()
                         {
                             var ListBox = document.getElementById('<%=ListRight.ClientID %>');
                             var len = ListBox.length;
                             if (len == null || len == "" || len == 0)
                             {

                                 sweetAlert("Oops...", "RIGHT LIST IS EMPTY !", "error");

                             }


                         }

                    </script>
           <asp:Button ID="sbt_plan" Class="btn-primary"   runat="server" Text="Submit Plan" style="margin-top:50px;margin-left:20%" OnClientClick="rightlistcheck();" OnClick="sbt_plan_Click"/>

           <asp:Button ID="btn_view" Class="btn-primary"   runat="server" Text="View" style="margin-top:50px;margin-left:1%" OnClick="btn_view_Click" />
            
           <asp:Button ID="btn_edit_schedule" Class="btn-primary"   runat="server" Text="Edit Schedule" style="margin-top:50px;margin-left:1%" OnClick="btn_edit_schedule_Click" />

           <asp:Button ID="btn_update" Class="btn-primary"   runat="server" Text="Update" style="margin-top:50px;margin-left:1%" OnClick="btn_update_Click" Visible="False" />
       
       </div>


    </div>
            
       

</asp:Content>
