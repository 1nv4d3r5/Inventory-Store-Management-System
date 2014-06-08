<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="TCS.ISMS.UI.LoginPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title><link href="~/Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id = "MainContainer" style = "width : 100%; background-color:#ffffcc; height: 790px;"  > <img src="Page-logo.png" height="250px" width="1100px" />
    
    <br /><br />    <br /><br />    <br /><br />    
    <div id = "PanelContainer" style = "width : 100%;">
   <center>
        <asp:Panel ID="Panel1" Width = "60%" runat="server" GroupingText = "Log In" Font-Size ="Large"  Font-Names = "cambria"  
            Height="60%" BorderStyle="None" BorderWidth="5px">
    <center>
    <table>
    <tr>
        <td>
            <asp:Label ID="lblMessage" runat="server" class = "labelMessage"></asp:Label>
        </td>
    </tr>
<tr>
    <td>
        <asp:Label ID="lblUserName" runat="server" Text="User Name" class = "label"></asp:Label>   
    </td>
    <td>
       <asp:TextBox ID="txtUserName" runat="server" class = "textBox" MaxLength="20" ></asp:TextBox> 
    </td>
    <td>
        <asp:RequiredFieldValidator ID="rfvUserName" runat="server" class = "errorMessages"
            ErrorMessage="User Name cannot be blank." ControlToValidate="txtUserName" 
            Display="Dynamic" ValidationGroup="validateInput" ForeColor = "red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revUsername" runat="server" class = "errorMessages" ErrorMessage="Invalid User Name" ControlToValidate="txtUserName" Display="Dynamic" ValidationExpression="[\d]*" ValidationGroup="validateInput"></asp:RegularExpressionValidator>
    </td>
</tr>

<tr>
    <td>
       <asp:Label ID="lblPassword" runat="server" Text="Password"  class = "label"></asp:Label>    
    </td>
    <td>
        <asp:TextBox ID="txtPassword" runat="server" TextMode = "Password" class = "textBox"
            MaxLength="20"></asp:TextBox> 
    </td>
    <td>
        <asp:RequiredFieldValidator ID="rfvPassword" runat="server" class = "errorMessages" ErrorMessage="Password cannot be blank"
        ForeColor = "red" ControlToValidate="txtPassword" ValidationGroup="validateInput" Display="Dynamic"></asp:RequiredFieldValidator>
    </td>

</tr>
<tr>
    <td colspan = '2'>
        <asp:Button ID="btnLogIn" runat="server" Text="Login" 
             ValidationGroup="validateInput" onclick="btnLogIn_Click1" class = "button" />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
            onclick="btnCancel_Click1" class = "button"/>
    </td>
</tr>
</table>
 <a href="~/Forgot Password.aspx" ID="forgotPassword" runat="server"><i>Forgot Password</i></a>
  </center>     </asp:Panel></center>
    </div></div>
    </form>
</body>
</html>
