<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="JnyCardWebApplication._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>JNY Information System Department Menu</title>
    <link href="../../Layout/Dist/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../Layout/Dist/css/navbar-fixed-top.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Layout/Dist/js/jquery.min.js"></script>
    <script type="text/javascript">        window.jQuery || document.write('<script src="../../Layout/Assets/js/vendor/jquery.min.js"><\/script>')</script>
    <script type="text/javascript" src="../../Layout/Dist/js/bootstrap.min.js"></script>
</head>
<body>
    <div class="container">
        <div class="row">
            <asp:PlaceHolder ID="DeptDataPlaceHolder" runat="server"></asp:PlaceHolder>
        </div>
    </div>
</body>
</html>
