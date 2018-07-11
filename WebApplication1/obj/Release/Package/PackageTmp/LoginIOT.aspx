<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginIOT.aspx.cs" Inherits="WebApplication1.LoginIOT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Form</title>
  
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/normalize/5.0.0/normalize.min.css">
  <link rel="stylesheet" href="cssL/style.css">
    <script type="text/javascript" language="javascript">
        function DisableBackButton() {
            window.history.forward()
        }
        DisableBackButton();
        window.onload = DisableBackButton;
        window.onpageshow = function (evt) { if (evt.persisted) DisableBackButton() }
        window.onunload = function () { void (0) }
 </script>
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
    <style>
        body {
        /*background-image:url("map_img/city.jpg");
        background-size:100% 100%;
        background-repeat: repeat-y;*/
        }
    </style>
</head>

<body>
    <div class="row" style="opacity:0.5">
        <center><h1>Smart Waste Management</h1></center>
        </div>
    <form id="form1" runat="server">
    
   <div class="login">
  <h2>Log In</h2>
  <fieldset>
    <input id="Uid" type="email" required="" placeholder="EmailID" runat="server"/>
  	<input id="pass" type="password" required="" placeholder="Password" runat="server"/>
  </fieldset> 
       <br />
<%--<asp:RadioButtonList ID="Utype" runat="server" RepeatLayout="Flow">
    <asp:ListItem Value="A">Admin</asp:ListItem>
    <asp:ListItem Value="U">User</asp:ListItem>
</asp:RadioButtonList>--%>
     <%--  <br />--%>
       <br />
       <asp:Button ID="submit" Text="Login" class="submit" runat="server" Width="300px" OnClick="submit_Click" />
  <div class="utilities">
    <a href="#">Forgot Password?</a>
    <a href="#">Sign Up &rarr;</a>
  </div>
    </form>
    <script type="text/javascript" src="tcal.js"></script> 
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="vendor/metisMenu/metisMenu.min.js"></script>
    <script src="vendor/raphael/raphael.js"></script>
    <script src="vendor/morrisjs/morris.min.js"></script>
    <script src="data/morris-data.js"></script>
    <script src="dist/js/sb-admin-2.js"></script>
    <script src="js/toggle.js"></script>
</body>
</html>
