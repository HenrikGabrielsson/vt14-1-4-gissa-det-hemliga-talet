<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SecretNumber.Default" ViewStateMode="Disabled"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gissa det hemliga talet</title>
</head>
<body>
    <form id="form" runat="server">
    <div>
        <asp:TextBox ID="GuessBox" runat="server"></asp:TextBox> 
        <asp:Button ID="GuessButton" runat="server" Text="Button" OnClick="GuessButton_Click" />        

    </div>
    </form>
</body>
</html>
