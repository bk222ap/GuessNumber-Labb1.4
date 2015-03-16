<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GuessNumber.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            Denna skriver inte ut Meddelandet!-> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ett tal måste anges" ControlToValidate="GuessTextBox" Display="Dynamic" CssClass="field-validation-error"></asp:RequiredFieldValidator>
            <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Ange ett tal mellan 1 och 100" Type="Integer" MaximumValue="100" MinimumValue="1" ControlToValidate="GuessTextBox" CssClass="field-validation-error"></asp:RangeValidator>

        </div>

        <div>
            <asp:Label ID="InfoLabel" runat="server" Text="Ange ett tal mellan 1 och 100"></asp:Label> 
            <asp:TextBox ID="GuessTextBox" runat="server"></asp:TextBox> 
            <asp:Button ID="SubmitGuessButton" runat="server" Text="Skicka Gissning" OnClick="Button1_Click" style="height: 26px" />
        </div>

        <div>
            <asp:Label ID="SubmitedGuessesLabel" runat="server" Text="Guesses:" Visible="True"></asp:Label> 
            <asp:Label ID="ClientMessageLabel" runat="server" Text="" Visible="True"></asp:Label>
        </div>
        <div>  
            <asp:PlaceHolder ID="NewGamePlaceHolder" runat="server"  Visible="False">
                 <asp:Button ID="NewGameButton" OnClick="NewGame" runat="server" Text="Slumpa nytt hemligt tal" />
            </asp:PlaceHolder> 
           
        </div>    
        </div>
    </form>
     <script type="text/javascript">
         var textBox = document.getElementById("GuessTextBox");
         GuessTextBox.focus();
         GuessTextBox.select();
    </script>
</body>
</html>
