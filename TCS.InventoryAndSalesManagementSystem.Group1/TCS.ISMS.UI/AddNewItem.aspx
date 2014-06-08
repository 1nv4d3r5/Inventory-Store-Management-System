<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddNewItem.aspx.cs" Inherits="TCS.ISMS.UI.AddNewItem" %>

<script runat="server">

    
</script>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id = "rightContainer" style = "float : right; width : 70%; height : 70%;">
<h1>
    Add/ Update Item Details
</h1>
<br />
<table style = "width :70%; height : 70%; border : 2">
<tr>
    <td>
        <asp:Label ID="lblShowItemId" runat="server" Text="Item Successfully added. The Item Id is : "></asp:Label>
    </td>
</tr>
<tr>
    <td>
        <asp:Label ID="lblItemName" runat="server" Text="Item Name"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtItemName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
            ControlToValidate="txtItemName" Display="Dynamic" 
            ErrorMessage="Item Name Cannot Be Blank" ForeColor="Red" 
            ValidationGroup="validationInputs"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
    <td>
        <asp:Label ID="lblItemCategory" runat="server" Text="Item Category"></asp:Label>
    </td>
    <td>
        <asp:DropDownList ID="ddlState" runat="server">
            <asp:ListItem>Soap</asp:ListItem>
            <asp:ListItem>Detergent</asp:ListItem>
            <asp:ListItem>Shampoo</asp:ListItem>
            <asp:ListItem>Hand Wash</asp:ListItem>
        </asp:DropDownList>
        </td>
</tr>
<tr>
    <td>
        <asp:Label ID="lblItemPrice" runat="server" Text="Item Price"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtItemPrice" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
            ControlToValidate="txtItemPrice" Display="Dynamic" 
            ErrorMessage="Item Price Cannot Be Blank" ForeColor="Red" 
            ValidationGroup="validationInputs"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
    <td>
        <asp:Label ID="lblItemQuantity" runat="server" Text="Item Quantity"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="TxtItemQuantity" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
            ControlToValidate="TxtItemQuantity" Display="Dynamic" 
            ErrorMessage="Item Quantity Cannot Be Blank" ForeColor="Red" 
            ValidationGroup="validationInputs"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
    <td>
        <asp:Label ID="lblItemClosingCount" runat="server" Text="Item Closing Count"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtItemClosingCount" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
            ControlToValidate="txtItemClosingCount" Display="Dynamic" 
            ErrorMessage="Characters Are Not Allowed" ForeColor="Red" 
            ValidationGroup="validationInputs"></asp:RegularExpressionValidator>
    </td>
</tr>

<tr>
    <td>
        <asp:Label ID="lblItemDiscount" runat="server" Text="Item Discount(in %)"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtItemDiscount" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
            ControlToValidate="txtItemDiscount" Display="Dynamic" 
            ErrorMessage="Characters Are Not Allowed" ForeColor="Red" 
            ValidationGroup="validationInputs"></asp:RegularExpressionValidator>
    </td>
</tr>

<tr>
    <td colspan = "2" style = "text-align : center;">
        <asp:Button ID="BtnSave" runat="server" Text="Save" onclick="BtnSave_Click" />&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnReset" runat="server" Text="Reset" />&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnCancel" runat="server" Text="Cancel" />
    </td>
</tr>
</table></div>
</asp:Content>
