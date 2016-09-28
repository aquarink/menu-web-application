<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TambahMenu.aspx.cs" Inherits="JnyMenuWebApplication1.TambahMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Add Menu</title>
    <link href="../../Layout/Dist/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="../../Layout/Dist/css/navbar-fixed-top.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Layout/Dist/js/jquery.min.js"></script>
    <script type="text/javascript">        window.jQuery || document.write('<script src="../../Layout/Assets/js/vendor/jquery.min.js"><\/script>')</script>
    <script type="text/javascript" src="../../Layout/Dist/js/bootstrap.min.js"></script>
</head>
<body>
    <div class="container">
        <div class="col-md-4">
        </div>
        <div class="col-md-4">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <div class="panel-body">
                        <form id="loginForm" runat="server">
                        <h2 class="form-signin-heading">
                            Add JNY Web Menu</h2>
                        <label for="TxtEmail" class="sr-only">
                            Nama Menu</label>
                        <asp:TextBox ID="TxtNamaMenu" runat="server" CssClass="form-control" placeholder="Nama Menu (maximum 25 character)"
                            required="required" autofocus="autofocus" MaxLength="25"></asp:TextBox>
                        <hr />
                        <label for="TxtEmail" class="sr-only">
                            Department</label>
                        <asp:DropDownList ID="DepartmentDropDownList" runat="server" 
                            CssClass="form-control" DataSourceID="DepartmentDS" DataTextField="namaDept" 
                            DataValueField="idDept">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="DepartmentDS" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:JNYWebMenuConnectionString %>" 
                            SelectCommand="SELECT [idDept], [namaDept] FROM [DepartmentTable]">
                        </asp:SqlDataSource>
                        <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
                        <hr />
                        <label for="TxtEmail" class="sr-only">
                            Link Address</label>
                        <asp:TextBox ID="TextLinkAddress" runat="server" CssClass="form-control" placeholder="Folder Source"
                            required="required" autofocus="autofocus">http://66.96.251.203/</asp:TextBox>
                        <hr />
                        <label for="inputPassword" class="sr-only">
                            Logo</label>
                        <asp:FileUpload ID="LogoFileUpload" runat="server" CssClass="form-control"/>
                        <hr />
                        <asp:Label ID="msgLabel" runat="server" BackColor="#FF3300" ForeColor="White"></asp:Label>
                        <hr />
                        <asp:Button ID="Button1" runat="server" Text="Save Menu" 
                            CssClass="btn btn-lg btn-primary btn-block" onclick="Button1_Click" />
                        </form>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-4">
        </div>
    </div>
</body>
</html>