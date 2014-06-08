<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="TCS.ISMS.UI.AddItem" %>

<script runat="server">

</script>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- // File Summary  : Add Item Page
// ---------------------------------------------------------------------------------
// File Summary  : Add Item Page
// Date Created  : 25 April, 2013
// Author   : Suman Pradhan, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// Change History :
// Change Description# : Added Validations  to the add item page 
// Changed By  : Suman Pradhan
// Date Modified  : 25 April, 2013
/////////////////////////////////////////////////////////////////////////////////////////////////		-->	
    <style type="text/css">
        .style1
        {
            height: 29px;
        }
        .style2
        {
            height: 31px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" ID="ScriptManager1" ScriptMode="Debug" CombineScripts="false" />
    <div id = "rightContainer" style = "float : right; width : 70%; height : 70%;">
<h1>
    Add/ Update Item Details
</h1>
<br />
<table style = "width :70%; height : 70%; border : 2">
<tr>
    <td>
        <asp:Label ID="lblShowMessage" runat="server" ForeColor="Red"></asp:Label>
    </td>
</tr>
<tr>
    <td>
        <asp:Label ID="lblShowItemId" runat="server" ForeColor="#009900"></asp:Label>
    </td>
</tr>
<tr>
    <td>
        <asp:Label ID="lblItemName" runat="server" Text="Item Name"></asp:Label><sup style = "color : Red;">*</sup>
    </td>
    <td>
        <asp:TextBox ID="txtItemName" runat="server" class="textbox"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvItemName" runat="server" 
            ControlToValidate="txtItemName" Display="Dynamic" 
            ErrorMessage="Item Name Cannot Be Blank" ForeColor="Red" 
            ValidationGroup="validationInputs"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" 
            ControlToValidate="txtItemName" Display="Dynamic" 
            ErrorMessage="Numerics are not allowed" ForeColor="Red" 
            ValidationExpression="^[a-z A-Z]+$" ValidationGroup="validationInputs"></asp:RegularExpressionValidator>
    </td>
</tr>
<tr>
    <td>
        <asp:Label ID="lblItemCategory" runat="server" Text="Item Category"></asp:Label><sup style = "color : Red;">*</sup>
    </td>
    <td>
        <asp:DropDownList ID="ddlCategory" runat="server"  AutoPostBack="true" AppendDataBoundItems="true" 
            Height="22px" Width="152px" 
            onselectedindexchanged="ddlCategory_SelectedIndexChanged1" 
            class="dropDown"> 
            
            <asp:ListItem Text="---Select---" Value="0"></asp:ListItem>
              <asp:ListItem Text="New Category" Value="1"></asp:ListItem>
        </asp:DropDownList>
        <asp:RequiredFieldValidator ID="rfvCategory" runat="server" 
            ControlToValidate="ddlCategory" Display="Dynamic" 
            ErrorMessage="Select Item Category" ForeColor="Red" 
            ValidationGroup="validationInputs" InitialValue="0"></asp:RequiredFieldValidator>
        </td>
</tr>
<tr>
<td>
<asp:Label ID="lblNewCat" runat="server" Text="Add New Category" Visible="False"></asp:Label>
</td>
<td>
<asp:TextBox ID="txtnewCat" runat="server" Text="" Visible="False"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtnewCat" ErrorMessage="Please enter Category Name" 
        ForeColor="#FF3300" ValidationGroup="valid"></asp:RequiredFieldValidator>
</td>
</tr>
<tr>
<td>
<asp:Button ID="btnCat" runat="server" Text="Submit" Visible="False" 
        onclick="btnCat_Click" ValidationGroup="valid" class="button"/>
</td>
</tr>
<tr>

    <td>
        <asp:Label ID="lblItemPrice" runat="server" Text="Item Price(in Rs)"></asp:Label><sup style = "color : Red;">*</sup>
    </td>
    <td>
        <asp:TextBox ID="txtItemPrice" runat="server" MaxLength="5" class="textbox"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvItemPrice" runat="server" 
            ControlToValidate="txtItemPrice" Display="Dynamic" 
            ErrorMessage="Item Price Cannot Be Blank" ForeColor="Red" 
            ValidationGroup="validationInputs"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
            ControlToValidate="txtItemPrice" Display="Dynamic" 
            ErrorMessage="Characters are not allowed" ForeColor="Red" 
            ValidationExpression="^\d+$" ValidationGroup="validationInputs"></asp:RegularExpressionValidator>
    </td>
</tr>
<tr>
    <td>
        <asp:Label ID="lblItemQuantity" runat="server" Text="Item Quantity"></asp:Label><sup style = "color : Red;">*</sup>
    </td>
    <td>
        <asp:TextBox ID="txtItemQuantity" runat="server" class="textbox" MaxLength="5"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvItemQuantity" runat="server" 
            ControlToValidate="txtItemQuantity" Display="Dynamic" 
            ErrorMessage="Item Quantity Cannot Be Blank" ForeColor="Red" 
            ValidationGroup="validationInputs"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" 
            ControlToValidate="txtItemQuantity" Display="Dynamic" 
            ErrorMessage="Characters are not allowed" ForeColor="Red" 
            ValidationExpression="^\d+$" ValidationGroup="validationInputs"></asp:RegularExpressionValidator>
    </td>
</tr>

<tr>
    <td>
        <asp:Label ID="lblItemDiscount" runat="server" Text="Item Discount (in %)"></asp:Label><sup style = "color : Red;">*</sup>
    </td>
    <td>
        <asp:TextBox ID="txtItemDiscount" runat="server" class="textbox" MaxLength="2" 
            ontextchanged="txtItemDiscount_TextChanged"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvItemDiscount" runat="server" 
            ErrorMessage="Discount cannot be blank" Display="Dynamic" 
            ValidationGroup="validationInputs" ControlToValidate="txtItemDiscount" 
            ForeColor="Red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
            ControlToValidate="txtItemDiscount" Display="Dynamic" 
            ErrorMessage="Characters Are Not Allowed" ForeColor="Red" ValidationExpression="^\d+$"
            ValidationGroup="validationInputs"></asp:RegularExpressionValidator>
    </td>
</tr>
<tr>
    <td>
        <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click"  
            ValidationGroup="validationInputs" Width="75px" class="button" />&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnReset" runat="server" Text="Reset" 
            onclick="btnReset_Click" Width="75px" class="button"/>&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
            onclick="btnCancel_Click" Width="75px" class="button"/>
    </td>
</tr>

</table></div>
</asp:Content>
