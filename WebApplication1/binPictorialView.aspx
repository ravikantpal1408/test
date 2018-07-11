<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="binPictorialView.aspx.cs" Inherits="WebApplication1.binPictorialView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <apex:page  contentType="application/json">

    <title></title>
   <style>
        #bincontainer{
            width: 96px;
            padding:0;
            
        }
        #mainbin {
            background-image: url("map_img/2.png");
            height:130px;
            width:96px;
            background-repeat:no-repeat;
            position: absolute;
            z-index:99;
            
        }
        #filledspace{
           
            width:90px;
            height: 90px;
        }
        #emptyspace{
            background-color:white;
            
            width:90px;
            position: absolute;
        }
        #bintop
        {
            height: 35px;
            width: 38%;
            padding-top: 15px;
            margin: 0 auto;
            text-align:center;
        }
        .bintext
        {
            font-size: 10px;
            color: cornflowerblue;
        }
    </style>
    <%--<link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/bootstrap-reset.css" rel="stylesheet" />--%>
</head>
<body>
    <form id="form1" runat="server">
  <div id="bincontainer">
        <div id="mainbin" runat="server"></div>
        <div id="bintop" runat="server">
            <asp:Label ID="lbl_binPercent" Text="" runat="server" CssClass="bintext" ></asp:Label>
        </div>
        <div id="emptyspace" runat="server"></div>
        <div id="filledspace" runat="server"></div>   
    </div>
    </form>
</body>
</html>
