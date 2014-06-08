
 																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																																									


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddNewEmployee.aspx.cs" Inherits="TCS.ISMS.UI.AddNewEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<!-- 
///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : Add New Employee Page
// ---------------------------------------------------------------------------------
// Date Created  : April 24, 2013
// Author   : Arshin Saluja, Tata Consultancy Services
// ---------------------------------------------------------------------------------
//  Change History :
// Change Description# : Added validation.
// Changed By  : Arshin Saluja
// Date Modified  : April 25, 2013
// 
///////////////////////////////////////////////////////////////////////////////////////////////		-->




   
</asp:Content>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" ID="ScriptManager1" ScriptMode="Debug" CombineScripts="false" />
    <div id = "main" style = "width : 70%;  height : 70%; float :right;">
<h1>
Add/Update Employee Details
</h1><br /><br />
<p style = "color :Red; float : left;"> * indicates manadatory</p><br /><br />
<table class = "table">
<tr>
    <td>
        <asp:Label ID="lblMessage" runat="server" class = "labelMessage"></asp:Label>
    </td>
</tr>
<tr>
    <td>
        <asp:Label ID="lblFirstName" runat="server" Text="First Name" class = "label"></asp:Label><sup style = "color : Red;">*</sup>
    </td>
    <td>
        <asp:TextBox ID="txtFirstName" runat="server" MaxLength="30" class = "textBox"></asp:TextBox>
    </td>
    <td>
        <asp:RequiredFieldValidator ID="rfvEployeeFirstName" runat="server" class = "errorMessages" ErrorMessage="First name cannot be blank" Display="Dynamic" ControlToValidate="txtFirstName" ValidationGroup="validateInput" ForeColor = "red"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revEmployeeFirstName" runat="server" 
            ErrorMessage="Invalid Employee Name" class = "errorMessages" ControlToValidate="txtFirstName" 
            Display="Dynamic" ForeColor="Red" ValidationExpression="^[a-zA-Z]+$" 
            ValidationGroup="validateInput"></asp:RegularExpressionValidator>
    </td>
</tr>
<tr>
    <td>
        <asp:Label ID="lblLastName" runat="server" Text="Last Name" class = "label"></asp:Label><sup style = "color : Red;">*</sup>
    </td>
    <td>
        <asp:TextBox ID="txtLastName" runat="server" class = "textBox"></asp:TextBox>
    </td>
     <td>
        <asp:RequiredFieldValidator ID="rfvEmployeeLastName" runat="server" 
             ErrorMessage="Last name cannot be blank" Display="Dynamic" 
             ControlToValidate="txtLastName" ValidationGroup="validateInput" class = "errorMessages"
             ForeColor = "red"></asp:RequiredFieldValidator>
         <asp:RegularExpressionValidator ID="LastName" runat="server" 
             ControlToValidate="txtLastName" Display="Dynamic" 
             ErrorMessage="Invalid Employee Name" ForeColor="Red" class = "errorMessages"
             ValidationExpression="^[A-Z a-z]+$" ValidationGroup="validateInput"></asp:RegularExpressionValidator>
    </td>
</tr>
<tr>
    <td>
        <asp:Label ID="lblRoleTag" runat="server" Text="Role" class = "label"></asp:Label><sup style = "color : Red;">*</sup>
    </td>
    <td>
        <asp:DropDownList ID="ddlRole" runat="server" AutoPostBack="True" AppendDataBoundItems = "true" class = "dropDown">
        <asp:ListItem text = "Select Role" value = "0"></asp:ListItem>
        </asp:DropDownList>
        <!-- <asp:ListItem Value = "0" Text = "----------"></asp:ListItem>
            <asp:ListItem Value = "1" Text = "Sales Person"></asp:ListItem>
            <asp:ListItem Value = "2" Text = "Sales Manager"></asp:ListItem>
            <asp:ListItem Value = "3" Text = "Inventory Manager"></asp:ListItem>
            <asp:ListItem Value = "4" Text = "Admin"></asp:ListItem>-->
       
    </td>
    <td>
        <asp:RequiredFieldValidator ID="rfvRoleTag" runat="server" class = "errorMessages"
            ErrorMessage="Select a Role Tag" Display="Dynamic" ControlToValidate="ddlRole" 
            ValidationGroup="validateInput" ForeColor = "red" InitialValue="0"></asp:RequiredFieldValidator>
    </td>

</tr>
<tr>
 <td>
     <asp:Label ID="lblDOB" runat="server" Text="Date Of Birth" class = "label"></asp:Label> <sup style = "color : Red;">*</sup>   
    </td>
    <td>
        <asp:TextBox ID="txtDOB" runat="server" class = "textBox"></asp:TextBox>
        <asp:ImageButton runat="Server" ID="imgCalenderDOB" 
            ImageUrl="~/images/Calendar_scheduleHS.png" 
            AlternateText="Click to show calendar" /><br />
        <ajaxToolkit:CalendarExtender ID="calenderDOB" runat="server" TargetControlID="txtDOB" 
            PopupButtonID="imgCalenderDOB"/>
    </td>
   <td>
       <asp:RequiredFieldValidator ID="rfvDOB" runat="server" class = "errorMessages" ErrorMessage="Select Date of Birth" Display="Dynamic" Font-Bold="False" ForeColor = "red" ControlToValidate="txtDOB" ValidationGroup="validateInput"></asp:RequiredFieldValidator>
       
   </td>
</tr>

<tr>
 <td>
     <asp:Label ID="lblDOJ" runat="server" Text="Date Of Joining" class = "label"></asp:Label> <sup style = "color : Red;">*</sup>   
    </td>
    <td>
         <asp:TextBox ID="txtDOJ" runat="server" class = "textBox"></asp:TextBox>
        <asp:ImageButton runat="Server" ID="imgCalenderDOJ" 
             ImageUrl="~/images/Calendar_scheduleHS.png" 
             AlternateText="Click to show calendar"/><br />
        <ajaxToolkit:CalendarExtender ID="calenderDOJ" runat="server" TargetControlID="txtDOJ" 
            PopupButtonID="imgCalenderDOJ" />
    </td>
    <td>
       <asp:RequiredFieldValidator ID="rfvDOJ" runat="server" class = "errorMessages" ErrorMessage="Select Date of Joining" Display="Dynamic" Font-Bold="False" ForeColor = "red" ControlToValidate="txtDOJ" ValidationGroup="validateInput"></asp:RequiredFieldValidator>

   </td>
</tr>
<tr>
    <td>
        <asp:Label ID="lblAddress" runat="server" Text="Address" class = "label"></asp:Label><sup style = "color : Red;">*</sup>
    </td>
    <td>
        <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" class = "textArea"></asp:TextBox>
    </td>
    <td>
        <asp:RequiredFieldValidator ID="rvfAddress" runat="server" class = "errorMessages"
            ErrorMessage="Address cannot be blank" ControlToValidate="txtAddress" 
            Display="Dynamic" ForeColor="Red" ValidationGroup="validateInput"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="revAddress" runat="server" 
             ControlToValidate="txtAddress" Display="Dynamic" 
             ErrorMessage="Invalid addresss" ForeColor="Red" 
             ValidationExpression="^[A-Z a-z 0-9 - -/]+$" ValidationGroup="validateInput"></asp:RegularExpressionValidator>
    </td>
    
</tr>

<tr>
    <td>
        <asp:Label ID="lblstate" runat="server" Text="State" class = "label"></asp:Label><sup style = "color : Red;">*</sup>
    </td>
    <td>
        <asp:DropDownList ID="ddlState" runat="server"  AutoPostBack="true"  onselectedindexchanged="ddlState_SelectedIndexChanged" class = "dropDown" >
            <asp:ListItem Selected="True" Value = "0" Text = "----------"></asp:ListItem>
            <asp:ListItem Value = "1" Text = "Maharashtra"></asp:ListItem>
            <asp:ListItem Value = "2" Text = "Gujrat"></asp:ListItem>
            <asp:ListItem Value = "3" Text = "Chhattisgarh"></asp:ListItem>
            <asp:ListItem Value = "4" Text = "Andhra Pradesh"></asp:ListItem>
            <asp:ListItem Value = "5" Text = "Madhya Pradesh"></asp:ListItem>
            <asp:ListItem Value = "6" Text = "Punjab"></asp:ListItem>
            
        </asp:DropDownList>
    </td>
    <td>
         <asp:RequiredFieldValidator ID="rfvState" runat="server" class = "errorMessages"
            ErrorMessage="Select a State" Display="Dynamic" ControlToValidate="ddlState" 
            ValidationGroup="validateInput" ForeColor = "red" InitialValue="0"></asp:RequiredFieldValidator>
    </td>
</tr>
<tr>
    <td>
        <asp:Label ID="lblCity" runat="server" Text="City" class = "label"></asp:Label><sup style = "color : Red;">*</sup>
    </td>
    <td>
        <asp:DropDownList ID="ddlCity" runat="server" class = "dropDown">
            <asp:ListItem Selected = "True" Value = "0" Text = "----------"></asp:ListItem></asp:DropDownList></td>
           <td>
             <asp:RequiredFieldValidator ID="rvfCity" runat="server" class = "errorMessages"
            ErrorMessage="Select a City" Display="Dynamic" ControlToValidate="ddlCity" 
            ValidationGroup="validateInput" ForeColor = "red" InitialValue="0"></asp:RequiredFieldValidator>
           </td>
</tr>
<tr>
    <td>
        <asp:Label ID="lblContact" runat="server" Text="Conatct Number" class = "label"></asp:Label><sup style = "color : Red;">*</sup>
    </td>
    <td>
        <asp:TextBox ID="txtContact" runat="server" class = "textBox" MaxLength = "10"></asp:TextBox>
    </td>
    <td>
        <asp:RequiredFieldValidator ID="rfvContact" runat="server" class = "errorMessages"
            ErrorMessage="Contact number cannot be blank" ControlToValidate="txtContact" 
            Display="Dynamic" ForeColor="Red" ValidationGroup="validateInput"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revContact" runat="server" class = "errorMessages"
            ControlToValidate="txtContact" Display="Dynamic"  ValidationGroup="validateInput"
            ErrorMessage="Invalid contact number" ForeColor="Red" 
            ValidationExpression="^[0-9]{10}"></asp:RegularExpressionValidator>
    </td>
</tr>
<tr><td>&nbsp;</td>
</tr><tr><td>&nbsp;</td></tr>
<tr>
    <td style = "text-align : center;">
        <asp:Button ID="BtnSave" runat="server" Text="Save" class = "button"
            ValidationGroup="validateInput" onclick="BtnSave_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnReset" runat="server" Text="Reset" class = "button"
            onclick="BtnReset_Click" />&nbsp;&nbsp;&nbsp;
        <asp:Button ID="BtnCancel" runat="server" Text="Cancel"  class = "button"
            onclick="BtnCancel_Click" />
    </td>
</tr>
</table>
</div>
</asp:Content>
