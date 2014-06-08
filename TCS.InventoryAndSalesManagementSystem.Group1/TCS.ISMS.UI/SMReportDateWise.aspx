<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SMReportDateWise.aspx.cs" Inherits="TCS.ISMS.UI.SMReportDateWise" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- // File Summary  : Report DateWise Page
// ---------------------------------------------------------------------------------
// Change History :
// Change Description# : Added Gridview to the report datewise page 
// Changed By          : Suman Pradhan
// Date Modified       : 2 May, 2013
//----------------------------------------------------------------------------------
// Change History :
// Change Description# : Added ajax controls  to the report datewise page 
// Changed By          : Suman Pradhan
// Date Modified       : 6 May, 2013
//----------------------------------------------------------------------------------
// Change History :
// Change Description# : Added validations to the report datewise page 
// Changed By          : Suman Pradhan
// Date Modified       : 7 May, 2013
/////////////////////////////////////////////////////////////////////////////////////////////////		-->
    <style type="text/css">
        .style1
        {
            width: 38%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" ID="ScriptManager1" ScriptMode="Debug" CombineScripts="false" />
<div id = "rightContainer" style = "float: left; width : 70%; height : 70%; ">
<h1 style=" text-align:center">
View Report Date Wise
</h1><br />
<p style = "color : Red; float : left;" > * indiactes manadatory</p>
<br />
<table style = "width : 70%;height:70%; float : right;">
<tr><td><asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label> </td></tr>
<tr>
<td >
<asp:Label ID="lblFrom" runat="server" Text="From Date (mm/dd/yyyy)"></asp:Label><sup style = "color : Red;">*</sup>
</td>
<td>
    <asp:TextBox ID="txtFrom" runat="server" AutoPostBack="True"  class="textbox"></asp:TextBox>
    <asp:ImageButton runat="Server" ID="imgCalender" 
            ImageUrl="~/images/Calendar_scheduleHS.png" 
            AlternateText="Click to show calendar" />
    <asp:RequiredFieldValidator ID="rfvFromDate" runat="server" 
        ControlToValidate="txtFrom" Display="Dynamic" 
        ErrorMessage="Date cannot be blank" ForeColor="Red" 
        ValidationGroup="validationInputs"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revFromDate" runat="server" 
        ErrorMessage="Characters are not allowed" ControlToValidate="txtFrom" 
        Display="Dynamic" ForeColor="Red" ValidationExpression="^([1-9]|0[1-9]|1[0-2])[- / .]([1-9]|0[1-9]|1[0-9]|2[0-9]|3[0-1])[- / .](1[9][0-9][0-9]|2[0][0-9][0-9])$" 
        ValidationGroup="validateInputs"></asp:RegularExpressionValidator>
    <br />
        <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtFrom"
            PopupButtonID="imgCalender" />
</td>
</tr>
<tr>
<td class="style1">
<asp:Label ID="lblTo" runat="server" Text="To Date (mm/dd/yyyy)"></asp:Label><sup style = "color : Red;">*</sup>
</td>
<td>
 <asp:TextBox ID="txtTo" runat="server"
        AutoPostBack="True" class="textbox"></asp:TextBox>
    <asp:ImageButton runat="Server" ID="ImageCalender" 
            ImageUrl="~/images/Calendar_scheduleHS.png" 
            AlternateText="Click to show calendar" />
    <asp:RequiredFieldValidator ID="rfvToDate" runat="server" 
        ControlToValidate="txtTo" Display="Dynamic" ErrorMessage="Date cannot be blank" 
        ForeColor="Red" ValidationGroup="validationInputs"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revToDate" runat="server" 
        ErrorMessage="Characters are not allowed" ControlToValidate="txtTo" 
        Display="Dynamic" ForeColor="Red" ValidationExpression="^([1-9]|0[1-9]|1[0-2])[- / .]([1-9]|0[1-9]|1[0-9]|2[0-9]|3[0-1])[- / .](1[9][0-9][0-9]|2[0][0-9][0-9])$" 
        ValidationGroup="validateInputs"></asp:RegularExpressionValidator>
    <br />
        <ajaxToolkit:CalendarExtender ID="calendarButtonExtender1" runat="server" TargetControlID="txtTo" 
            PopupButtonID="ImageCalender" />
</td>
</tr>
<tr>
<td class="style1">
<asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" 
        ValidationGroup="validationInputs" class="button"/></td>
<td><asp:Button ID="btnReset" runat="server" Text="Reset" 
        onclick="btnReset_Click1" class="button" />
</td></tr>
</table>
<table style = "width : 70%;height:70%; float : right;">
<tr><td style="width:60%">

                <asp:GridView ID="gvShowReport" runat="server" AutoGenerateColumns="false" 
                    Width="100%"  AllowPaging="true" PagerSettings-Mode="Numeric" 
        PageButtonCount="3"  PageSize="5" class = "gridView"
        OnPageIndexChanging="gvShowReport_PageIndexChanging">
               <Columns>
                <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
                <asp:BoundField HeaderText="Date" DataField="Date" />
                <asp:BoundField HeaderText="Total Sales(in rupees)" DataField="TotalSales" />
                </Columns>
                </asp:GridView>
                </td></tr>
              
</table></div>
</asp:Content>
