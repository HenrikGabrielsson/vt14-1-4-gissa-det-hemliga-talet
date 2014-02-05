<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GuessSecretNumber.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gissa talet</title>
</head>
<body>

    <form id="form" runat="server">
    
        <div id="errorDiv">
            <asp:ValidationSummary ID="ValidationSummary" runat="server" />           
        </div>

    <div>
        <%-- Input --%>
        <label for="GuessBox">Ange ett tal mellan 1 och 100: </label>
        <asp:TextBox ID="GuessBox" runat="server"></asp:TextBox>
        
        <%-- Validering --%>
        <asp:RangeValidator ID="RangeValidator" runat="server" ErrorMessage="Inmatningen måste vara ett heltal mellan 1 -100." Display="Dynamic" Text="*" ControlToValidate="GuessBox" MaximumValue="100" MinimumValue="1" Type="Integer"></asp:RangeValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ErrorMessage="Du får inte lämna fältet tomt!" Text="*" ControlToValidate="GuessBox"></asp:RequiredFieldValidator>

        <asp:Button ID="GuessButton" runat="server" Text="Slumpa nytt hemligt tal" OnClick="GuessButton_Click" />

    </div>
    </form>
    <div id="resultDiv">
        <%-- Output --%>
        <asp:Label ID="GuessOutcome" runat="server"></asp:Label>
        <asp:Label ID="GuessesMade" runat="server"></asp:Label>
    </div>
</body>
</html>
