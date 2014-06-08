<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SMViewBillDetails.aspx.cs" Inherits="TCS.ISMS.UI.SMViewBillDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<!-- 
///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : View Bill Details Page
// ---------------------------------------------------------------------------------
//  Change History :
// Change Description# : Added Grid View to the page.
// Changed By          : Susmita Rana
// Date Modified       : May 1, 2013
// ---------------------------------------------------------------------------------
//  Change History :
// Change Description# : Added Ajax Controls and Validations to the page.
// Changed By          : Susmita Rana
// Date Modified       : May 7, 2013
// 
///////////////////////////////////////////////////////////////////////////////////////////////		-->
<style type="text/css">
        .style1
        {
            width: 18%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" ID="ScriptManager1" ScriptMode="Debug" CombineScripts="false" />
<div id = "rightContainer" style = "float : left; width : 70%; height : 70%">
<h1 style = "text-align : center;">
View Bill Details
</h1>
<br />
<p style = "color : Red; float : left;" > * indicates mandatory</p>
<br />
<table style = "width : 70%;height:70%; float : right;">
<tr><td><asp:Label ID="lblMessage" runat="server" class="label" ForeColor="Red" 
        Width="150px"></asp:Label>
</td></tr>
<tr>
<td class="style1">
<asp:Label ID="lblViewBill" runat="server" class="label" Text="Select Date"></asp:Label><sup style = "color : Red;">*</sup>
</td>
<td>
<asp:TextBox ID="txtDate" runat="server" 
        AutoPostBack="True" class="textBox" ontextchanged="txtDate_TextChanged" 
        Height="17px"></asp:TextBox>
    <asp:ImageButton runat="Server" ID="imgCalender" 
            ImageUrl="~/images/Calendar_scheduleHS.png" 
            AlternateText="Click to show calendar" /><br />
            <asp:RequiredFieldValidator ID="rfvDate" runat="server" class="errorMessages"
        ControlToValidate="txtDate" Display="Dynamic" 
        ErrorMessage="Date cannot be blank" ForeColor="Red" 
        ValidationGroup="validateInputs"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revDate" runat="server" class="errorMessages"
        ErrorMessage="Characters are not allowed" ControlToValidate="txtDate" 
        Display="Dynamic" ForeColor="Red" ValidationExpression="^([1-9]|0[1-9]|1[0-2])[- / .]([1-9]|0[1-9]|1[0-9]|2[0-9]|3[0-1])[- / .](1[9][0-9][0-9]|2[0][0-9][0-9])$" 
        ValidationGroup="validateInputs"></asp:RegularExpressionValidator>
        <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtDate" 
            PopupButtonID="imgCalender" />

    <!--<asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>-->
</td>
</tr>
<tr>
<td colspan="2" class="style1">
<asp:Button ID="btnViewBill" runat="server" class="button" Text="Submit" 
        onclick="btnViewBill_Click" ValidationGroup="validateInputs" />
<asp:Button ID="btnReset" runat="server" class="button" Text="Reset" onclick="btnReset_Click" 
         />
<asp:Button ID="btnCancel" runat="server" class="button" Text="Cancel" onclick="btnCancel_Click" />
</td>
</tr>

</table>
<table style = "width : 70%;height:70%; float : right;">
<tr><td class="style1">
                <asp:GridView ID="gvShowBillList" runat="server" class="gridView" AutoGenerateColumns="false" 
                    Width="80%"  AllowPaging="true" PagerSettings-Mode="Numeric" 
        PageButtonCount="3"  PageSize="4" 
        OnPageIndexChanging="gvShowBillList_PageIndexChanging">
               <Columns>
                <asp:BoundField HeaderText="Bill Number" DataField="BillNumber" />
                <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" />
                <asp:BoundField HeaderText="Amount" DataField="TotalBillAmount" />
                </Columns>
                </asp:GridView>
                </td></tr>
<tr>
<td>
<asp:Label ID="lblNumberBills" runat="server" class="label" Text="Number of Bills Generated:"></asp:Label>
<b><asp:Label ID="lblnumberbill" runat="server"></asp:Label></b></td>
</tr>
</table>
</div>
</asp:Content>
