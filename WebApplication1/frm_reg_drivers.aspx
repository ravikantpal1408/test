<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Waste_Mgmnt.Master" AutoEventWireup="true" CodeBehind="frm_reg_drivers.aspx.cs" Inherits="WebApplication1.frm_reg_drivers" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" EnablePageMethods="true"  runat="server"></asp:ScriptManager>
  <link href="css/bootstrap-theme.min.css" rel="stylesheet" />
    
    <style>
        body{
            background-color: #525252;
        }
        .centered-form{
	        margin-top: 20px;
            
        }

        .centered-form .panel{
	        background: rgba(255, 255, 255, 0.8);
	        box-shadow: rgba(0, 0, 0, 0.3) 20px 20px 20px;
        }
        .textbox{
        height:50px;
        }
        html {
            overflow-y: hidden;
        }
     </style>
    <script>



    </script>
<fieldset><legend><h1>Driver's Registration</h1></legend></fieldset>
   
        			
			    		    <div class="form-group">
                                Name:
                                <asp:TextBox required="required" ID="txt_name" class="form-control" runat="server"></asp:TextBox>
                                   
			    				<br />
			    		
                                   Licence:
                                   <asp:TextBox required="required" ID="txt_licence" class="form-control" runat="server"></asp:TextBox>
                                   
			    				
			    	<br />
                           
                                 Permanent Address:
                                 <asp:TextBox required="required" ID="txt_p_add" class="form-control" runat="server"></asp:TextBox>
                                 
			    				
			    		<br />

                               Residential Address:
                               <asp:TextBox required="required" ID="txt_c_add" class="form-control" runat="server"></asp:TextBox>
                               
			    				
			    	<br />
                                Email:
                                 <asp:TextBox required="required" ID="txt_email" class="form-control" runat="server"></asp:TextBox>
                                
			    				<asp:RequiredFieldValidator ID="rfvEmail" runat="server"  ErrorMessage="*" ControlToValidate="txt_email" ValidationGroup="vgSubmit" ForeColor="Red"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Please Enter Valid Email ID"   ValidationGroup="vgSubmit" ControlToValidate="txt_email"  CssClass="requiredFieldValidateStyle"  ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                </asp:RegularExpressionValidator>
			   <br />

			    			<div class="row">
			    				<div class="col-xs-6 col-sm-6 col-md-6">
			    					<div class="form-group">
                                        Mobile:
                                        <asp:TextBox required="required" ID="txt_mbl" class="form-control" runat="server"></asp:TextBox>
                                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_mbl" ErrorMessage="RegularExpressionValidator"  ValidationExpression="[0-9]{10}"></asp:RegularExpressionValidator> 
			    					</div>
			    				</div>
			    				<div class="col-xs-6 col-sm-6 col-md-6">
			    					<div class="form-group">
                                        Date Of Birth:
                                        <asp:TextBox required="required" ID="txt_dob" class="form-control" runat="server"></asp:TextBox>
			    						
                                        <cc1:CalendarExtender ID="txtFrom_CalendarExtender" runat="server" Enabled="True" Format="dd-MM-yyyy" TargetControlID="txt_dob">
                </cc1:CalendarExtender>
			    					</div>
			    				</div>
			    			</div>
							
                        <h3><asp:Label ID="Label8" runat="server" Text="TypesOf vehicle Capable of Driving :"></asp:Label></h3>
                            <asp:Label ID="lbl_msg" runat="server" style="font-size:20px" Text="" Visible="false"></asp:Label>
                            <asp:CheckBoxList required="" ID="chk_veh" runat="server">
                                <asp:ListItem>Dumper</asp:ListItem>
                                <asp:ListItem>TROLLER</asp:ListItem>
                                <asp:ListItem>TRUCK</asp:ListItem>

                         </asp:CheckBoxList>
			    			
			    			<center><asp:Button class="btn btn-info  textbox" ID="udpt" runat="server" Text="Update" Visible="false" OnClick="udpt_Click1"></asp:Button><asp:Button class="btn btn-info  textbox" ID="bt_sbt" runat="server" Text="Register"  OnClick="bt_sbt_Click"></asp:Button>
                            <asp:Button class="btn btn-danger  textbox" ID="bt_cncl" runat="server" Text="Cancel"></asp:Button>
						    


 







</asp:Content>
