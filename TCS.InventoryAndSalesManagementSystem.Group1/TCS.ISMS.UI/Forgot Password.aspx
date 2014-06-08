<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forgot Password.aspx.cs" Inherits="TCS.ISMS.UI.Forgot_Password" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body style=" background-color:Silver;">
<h1 style="text-align:center;">Forgot Password</h1>
    <form id="form1" runat="server">
    <div>
    <table>
    <tr>
    <td>
        <asp:Label ID="lblMessage" runat="server" ForeColor="#FF3300"></asp:Label>
        <br />
        <br />
    <asp:Label ID="lblEmployeeID" runat="server" text="Enter your Employee ID"></asp:Label>
    </td>
    <td>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="txtEmployeeID" ErrorMessage="Enter Valid Employee ID" 
            ForeColor="#FF3300" ValidationExpression="^\d+$" 
            ValidationGroup="validation"></asp:RegularExpressionValidator>
        <br />
        <br />
    <asp:TextBox ID="txtEmployeeID" runat="server" Text="" BackColor="Transparent" 
            MaxLength="6"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txtEmployeeID" ErrorMessage=" Please Enter Employee ID" 
            ForeColor="#FF3300" ValidationGroup="validation"></asp:RequiredFieldValidator>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
            ValidationGroup="validation" onclick="btnSubmit_Click"/></td>
    <td>
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click" />
        </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="lblSecurityQuestion" runat="server" Text="Security Question:" 
            Visible="False"></asp:Label></td>
      <td>  <asp:Label ID="lblQuestion" runat="server" Text="What is your Nickname?" 
            Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="lblAnswer" runat="server" Text="Security Answer" Visible="False"></asp:Label></td>
    <td><asp:TextBox ID="txtAnsr" runat="server" Text="" Visible="False" 
            BackColor="Transparent" MaxLength="15"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtAnsr" ErrorMessage="Please enter the answer" 
            ForeColor="#FF3300" ValidationGroup="validation1"></asp:RequiredFieldValidator>
    </td>
    </tr>
    <tr>
    <td>
    <asp:Button ID="btnSubmt" runat="server" Text="Submit" 
            ValidationGroup="validation1" Visible="False" onclick="btnSubmt_Click" />
    </td>
    </tr>
    <tr>
    <td>
    <asp:Label ID="lblNewPaswrd" runat="server" Text="New Password" Visible="False"></asp:Label></td><td>
    <asp:TextBox ID="txtNewPassword" runat="server" Text="" Visible="False" 
            MaxLength="14" TextMode="Password" BackColor="Transparent" 
          
          ></asp:TextBox>
    </td>
    </tr>
    <tr>
    <td>
     <asp:Label ID="lblConfirmPasswrd" runat="server" Text="Confirm Password" 
            Visible="False"></asp:Label></td><td>
    <asp:TextBox ID="txtConfirmPassword" runat="server" Text="" Visible="False" 
            MaxLength="14" TextMode="Password" BackColor="Transparent"></asp:TextBox>
        
        <asp:CompareValidator ID="CompareValidator1" runat="server"  
            ErrorMessage="Password Should Match" ControlToCompare="txtNewPassword" 
            ControlToValidate="txtConfirmPassword" ForeColor="#FF3300" 
            ValidationGroup="validation2"></asp:CompareValidator>
        
    </td>
    </tr>
    <tr>
    <td>
     <asp:Button ID="btnSave" runat="server" Text="Save" 
            ValidationGroup="validation2" Visible="False" onclick="btnSave_Click" /></td><td>
        <asp:Button ID="btnCancel2" runat="server" Text="Cancel" onclick="btnCancel2_Click" 
                Visible="False" />
    </td>
    </tr>
    </table>
    
    </div>
    </form>
</body>
</html>
