<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="EmployeeViewProfile.aspx.cs" Inherits="TCS.ISMS.UI.EmployeeViewProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <div id = "main" style = "width : 70%;  height : 70%; float :right;">
 <h1>
View Profile
</h1><br /><br />

<table id = "viewTable"  runat = "server" style = "width :  70%;height :  70%;">

<tr>
    <td>
        <asp:Label ID="lblEmployeeId" runat="server" Text="EmployeeId"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblEmployeeIdDynamic" runat="server"></asp:Label>
    </td>
   
</tr><tr><td></td></tr>
<tr>
    <td>
        <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblFirstNamedynamic" runat="server"></asp:Label>
    </td>
    
</tr><tr><td></td></tr>
<tr>
    <td>
        <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblLastNamedynamic" runat="server"></asp:Label>
    </td>
   
    
</tr><tr><td></td></tr>
<tr>
    <td>
        <asp:Label ID="lblRoleTag" runat="server" Text="Role"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblRoleTagDynamic" runat="server"></asp:Label>
    </td>
    

</tr><tr><td></td></tr>
<tr>
 <td>
     <asp:Label ID="lblDOB" runat="server" Text="Date Of Birth"></asp:Label>   
    </td>
    <td>
        <asp:Label ID="lblDOBDynamic" runat="server"></asp:Label>
    </td>
   
  
</tr><tr><td></td></tr>

<tr>
 <td>
     <asp:Label ID="lblDOJ" runat="server" Text="Date Of Joining"></asp:Label>  
    </td>
    <td>
        <asp:Label ID="lblDOJDynamic" runat="server"></asp:Label>
    </td>
   
</tr><tr><td></td></tr>
<tr>
    <td>
        <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblAddressDynamic" runat="server"></asp:Label>
    </td>
   
</tr><tr><td></td></tr>

<tr>
    <td>
        <asp:Label ID="lblstate" runat="server" Text="State"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblStateDynamic" runat="server"></asp:Label>
    </td>
   
</tr><tr><td></td></tr>
<tr>
    <td>
        <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblCityDynamic" runat="server"></asp:Label>
    </td>
    
</tr><tr><td></td></tr>
<tr>
    <td>
        <asp:Label ID="lblContact" runat="server" Text="Conatct Number"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblContactDynamic" runat="server"></asp:Label>
    </td>
   
</tr>
</table>
     <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

     <br /><br />
<table id = "updateTable"  runat = "server"   style = "width :  70%; height :  70%; ">

<tr>
    <td>
        <asp:Label ID="lblEmployeeId2" runat="server" Text="EmployeeId"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblEmployeeIdDynamic2" runat="server"></asp:Label>
    </td>
   
</tr><tr><td></td></tr>
<tr>
    <td>
        <asp:Label ID="lblFirstName2" runat="server" Text="First Name"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblFirstNamedynamic2" runat="server"></asp:Label>
    </td>
    
</tr><tr><td></td></tr>
<tr>
    <td>
        <asp:Label ID="lblLastName2" runat="server" Text="Last Name"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblLastNamedynamic2" runat="server"></asp:Label>
    </td>
   
    
</tr><tr><td></td></tr>
<tr>
    <td>
        <asp:Label ID="lblRoleTag2" runat="server" Text="Role"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblRoleTagDynamic2" runat="server"></asp:Label>
    </td>
    

</tr><tr><td></td></tr>
<tr>
 <td>
     <asp:Label ID="lblDOB2" runat="server" Text="Date Of Birth"></asp:Label>   
    </td>
    <td>
        <asp:Label ID="lblDOBDynamic2" runat="server"></asp:Label>
    </td>
   
  
</tr><tr><td></td></tr>

<tr>
 <td>
     <asp:Label ID="lblDOJ2" runat="server" Text="Date Of Joining"></asp:Label>  
    </td>
    <td>
        <asp:Label ID="lblDOJDynamic2" runat="server"></asp:Label>
    </td>
   
</tr><tr><td></td></tr>
<tr>
    <td>
        <asp:Label ID="lblAddress2" runat="server" Text="Address"></asp:Label><sup style = "color : Red;">*</sup>
    </td>
    <td>
        <asp:TextBox ID="txtAddress2" runat="server" TextMode="MultiLine" class = "textArea"></asp:TextBox>
    </td>
   

 <td>
        <asp:RequiredFieldValidator ID="rvfAddress" runat="server" 
            ErrorMessage="Address cannot be blank" ControlToValidate="txtAddress2" 
            Display="Dynamic" ForeColor="Red" ValidationGroup="validateInput"></asp:RequiredFieldValidator>
    </td></tr>
<tr><td></td></tr>

<tr>
    <td>
        <asp:Label ID="lblstate2" runat="server" Text="State"></asp:Label><sup style = "color : Red;">*</sup>
    </td>
    <td>
        <asp:DropDownList ID="ddlState2" runat="server" class = "dropDown" AutoPostBack = "true"
            onselectedindexchanged="ddlState2_SelectedIndexChanged1">
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
         <asp:RequiredFieldValidator ID="rfvState" runat="server" 
            ErrorMessage="Select a State" Display="Dynamic" ControlToValidate="ddlState2" 
            ValidationGroup="validateInput" ForeColor = "red" InitialValue="0"></asp:RequiredFieldValidator>
    </td></tr>
<tr><td></td></tr>
<tr>
    <td>
        <asp:Label ID="lblCity2" runat="server" Text="City"></asp:Label><sup style = "color : Red;">*</sup>
    </td>
    <td>
        <asp:DropDownList ID="ddlCity2" runat="server" class = "dropDown">
         <asp:ListItem Selected = "True" Value = "0" Text = "----------"></asp:ListItem></asp:DropDownList>
       
    </td>
    

 <td>
             <asp:RequiredFieldValidator ID="rvfCity" runat="server" 
            ErrorMessage="Select a City" Display="Dynamic" ControlToValidate="ddlCity2" 
            ValidationGroup="validateInput" ForeColor = "red" InitialValue="0"></asp:RequiredFieldValidator>
           </td></tr>
<tr><td></td></tr>
<tr>
    <td>
        <asp:Label ID="lblContact2" runat="server" Text="Conatct Number"></asp:Label><sup style = "color : Red;">*</sup>
    </td>
    <td>
        <asp:TextBox ID="txtContact2" runat="server" class = "textBox"></asp:TextBox>
    </td>
     <td>
        <asp:RequiredFieldValidator ID="rfvContact" runat="server" 
            ErrorMessage="Contact number cannot be blank" ControlToValidate="txtContact2" 
            Display="Dynamic" ForeColor="Red" ValidationGroup="validateInput"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revContact" runat="server" 
            ControlToValidate="txtContact2" Display="Dynamic" 
            ErrorMessage="Invalid contact number" ForeColor="Red" 
            ValidationExpression="^[0-9]{10}" ValidationGroup="validateInput"></asp:RegularExpressionValidator>
    </td>
   
</tr>

</table>
<asp:Button ID="btnEdit" runat="server" Text="Edit"  onclick="btnEdit_Click"  class = "button" />
     <asp:Button ID="btnReset" runat="server" Text="Reset" class = "button" 
         onclick="btnReset_Click" />
     <asp:Button ID="btnUpdate" runat="server" Text="Update"  ValidationGroup="validateInput" class = "button"
         onclick="btnUpdate_Click" /> 
 </div>
</asp:Content>
