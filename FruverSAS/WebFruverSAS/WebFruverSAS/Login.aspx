<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebFruverSAS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
</head>
<body>
    <form id="formLogin" runat="server">
        <div class ="form-control">
            <div>
                <asp:Label cass="heading-section" ID = "lblBienvenido" runat ="server" Text="Fruver SAS" ></asp:Label>
            </div>
            <div>
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" placeholder ="Usario">Nombre Usuario</asp:TextBox>
            </div>

            <div>
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" placeholder ="Password">Contrasena</asp:TextBox>
            </div>

        </div>
    </form>
</body>
</html>
