<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ManageEmployee.aspx.cs" Inherits="TCS.ISMS.UI.ManageEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 324px;
        }
        .style2
        {
            width: 426px;
        }
        .style3
        {
            width: 235px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id = "rightContainer" style = " width : 70%; height : 70%; float : left;">
<h1>Manage Employee</h1><br />
<asp:Label ID="lblMessage" runat="server" ForeColor="red" 
            Visible="true"></asp:Label>
            <table>
            <tr>
            <td class="style3">
            <asp:Label ID="lblSearch" runat="server" Text="Search Employee" class="label"></asp:Label>
            </td>
            <td>
            <asp:TextBox ID="txtSearchBox" runat="server" class="textBox" Height="21px" MaxLength="10"></asp:TextBox>
            </td>
            <td class="style2">
                <asp:RequiredFieldValidator ID="rfvSearchBox" runat="server" 
                    ErrorMessage="Employee name can not be blank" class="errorMessage" 
                    ControlToValidate="txtSearchBox" Display="Dynamic" ForeColor="Red" 
                    ValidationGroup="validateSearch"></asp:RequiredFieldValidator>
            </td>
            <td class="style1">
                <asp:Button ID="btnSearch" runat="server" Text="Search" class="button" 
                    ValidationGroup="validateSearch" onclick="btnSearch_Click"/>
            </td>
            </tr>
            </table>
<asp:GridView ID="gvManageEmployee" runat="server" AutoGenerateColumns="false"  class = "gridView"  AllowPaging="true" PagerSettings-Mode="Numeric" 
        PageButtonCount="3"  PageSize="10" 
        OnPageIndexChanging="gvManageEmployee_PageIndexChanging" >
        <Columns>
         <asp:TemplateField HeaderText="Select">
             <ItemTemplate>
                    <asp:CheckBox ID="chkSelect" name="chkSelect" runat="server"   />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Employee ID" DataField="EmployeeId" />
            <asp:BoundField HeaderText="Employee First Name" DataField="FirstName" />
            <asp:BoundField HeaderText="Employee Last Name" DataField="LastName" />
           <asp:TemplateField HeaderText="Role Tag">
             <ItemTemplate>
                   <asp:Label ID="lblRole" runat="server" Text = '<%#Bind("RoleName")%>'></asp:Label>
                </ItemTemplate>
                
            </asp:TemplateField>
            
            <asp:BoundField HeaderText="Contact number" DataField="MobileNumber" />
        </Columns>
    </asp:GridView>

    <asp:GridView ID="gvshowItems" runat="server" AutoGenerateColumns="False"  OnRowDataBound="OnGridViewDataBinding"
    class = "gridView">
        <Columns>
           <asp:BoundField HeaderText="Employee ID" DataField="EmployeeId" />
            <asp:BoundField HeaderText="Employee First Name" DataField="FirstName" />
            <asp:BoundField HeaderText="Employee Last Name" DataField="LastName" />
                         <asp:TemplateField HeaderText="New Role" >
                <ItemTemplate>
                    <asp:DropDownList ID="ddlNewRole" name="ddlNewRole" runat="server" AppendDataBoundItems="true"/>
                    <asp:RequiredFieldValidator ID="rfvRole" runat="server" ErrorMessage="Please select Role" ControlToValidate="ddlNewRole" Display="Dynamic" InitialValue="0" ValidationGroup="valUpdate" ForeColor="red"></asp:RequiredFieldValidator>
                     </ItemTemplate>
            </asp:TemplateField>
             <asp:BoundField HeaderText="Contact Number" DataField="MobileNumber" />
            
        </Columns>
    </asp:GridView>
<table>
<tr>
    <td style = "text-align : center;">
        <asp:Button ID="btnUP" runat="server" Text="Update" class = "button"  onclick="btnUP_Click" ValidationGroup="valUpdate"/>
        <asp:Button ID="btnUpdate" runat="server" Text="Update"  class = "button"
            onclick="btnUpdate_Click"  />&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" class = "button"  Text="Delete" onclick="btnDelete_Click" 
             />&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID = "btnReset" runat = "server" Text = "Reset" class = "button" 
            onclick="btnReset_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnCancel" runat="server"  Text="Cancel" 
            onclick="btnCancel_Click" class="button" />
    </td>
</tr>
</table>
   </div>
</asp:Content>
