<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GuessSecretNumber.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gissa talet</title>
</head>
<body>
    <form id="form" runat="server">
    <div>
        <%-- Input --%>
        <label for="GuessBox">Ange ett tal mellan 1 och 100: </label>
        <asp:TextBox ID="GuessBox" runat="server"></asp:TextBox>

        <asp:Button ID="GuessButton" runat="server" Text="Gissa" OnClick="GuessButton_Click" />
        <asp:Label ID="GuessOutcome" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
