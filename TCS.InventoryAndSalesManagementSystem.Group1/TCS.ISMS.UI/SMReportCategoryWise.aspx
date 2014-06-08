 <%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SMReportCategoryWise.aspx.cs" Inherits="TCS.ISMS.UI.SMReportCategoryWise" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <!-- // File Summary  : Report Category Wise Page
// ---------------------------------------------------------------------------------
// Change History :
// Change Description# : Added Gridview to the Report Category Wise page 
// Changed By  : Susmita Rana
// Date Modified  : 3 May, 2013
//----------------------------------------------------------------------------------
// Change History :
// Change Description# : Added Ajax controls to the Report Category Wise page 
// Changed By  : Susmita Rana
// Date Modified  : 6 May, 2013
//----------------------------------------------------------------------------------
// Change History :
// Change Description# : Added Validations to the Report Category Wise page 
// Changed By  : Susmita Rana
// Date Modified  : 7 May, 2013
/////////////////////////////////////////////////////////////////////////////////////////////////		-->	

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" ID="ScriptManager1" ScriptMode="Debug" CombineScripts="false" />
<div id = "main" style = "width : 70%;height : 70%; ">
<h1 style=" text-align:center">
View Report Category Wise
</h1><br />
<p style = "color : Red; float : left;" > * indicates mandatory</p>
<br />
<table style = "width : 70%;height:70%; float : right;">
<tr><td><asp:Label ID="lblMessage" runat="server" class="label" ForeColor="Red"></asp:Label> </td></tr></table>
<table class="table" style = "width : 70%;height:70%; float : right;">
<tr>
<td>
<asp:Label ID="lblFrom" runat="server" class="label" Text="From Date: (mm/dd/yyyy)"></asp:Label><sup style = "color : Red;">*</sup>
</td>
<td>
    <asp:TextBox ID="txtFrom" runat="server" AutoPostBack="True" class="textBox"></asp:TextBox>
    <asp:ImageButton runat="Server" ID="imgCalender" 
            ImageUrl="~/images/Calendar_scheduleHS.png" 
            AlternateText="Click to show calendar" /><br />
            <asp:RequiredFieldValidator ID="rfvDateFrom" runat="server" 
        ErrorMessage="Date cannot be blank" class="errorMessages" ControlToValidate="txtFrom" 
        Display="Dynamic" ForeColor="Red" ValidationGroup="validateInputs"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revDateFrom" runat="server" class="errorMessages"
        ErrorMessage="Characters are not allowed" ControlToValidate="txtFrom" 
        Display="Dynamic" ForeColor="Red" ValidationExpression="^([1-9]|0[1-9]|1[0-2])[- / .]([1-9]|0[1-9]|1[0-9]|2[0-9]|3[0-1])[- / .](1[9][0-9][0-9]|2[0][0-9][0-9])$" 
        ValidationGroup="validateInputs"></asp:RegularExpressionValidator>
        <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtFrom"
            PopupButtonID="imgCalender" />
</td>
</tr>
<tr>
<td class="style1">
<asp:Label ID="lblTo" runat="server" class="label" Text="To Date: (mm/dd/yyyy)"></asp:Label><sup style = "color : Red;">*</sup>
</td>
<td>
 <asp:TextBox ID="txtTo" runat="server"
        AutoPostBack="True" class="textBox"></asp:TextBox>
    <asp:ImageButton runat="Server" ID="ImageCalender" 
            ImageUrl="~/images/Calendar_scheduleHS.png" 
            AlternateText="Click to show calendar" /><br />
            <asp:RequiredFieldValidator ID="rfvDateTo" runat="server" class="errorMessages"
        ErrorMessage="Date cannot be blank" ControlToValidate="txtTo" 
        Display="Dynamic" ForeColor="Red" ValidationGroup="validateInputs"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revDateTo" runat="server" class="errorMessages"
        ErrorMessage="Characters are not allowed" ControlToValidate="txtTo" 
        Display="Dynamic" ForeColor="Red" 
        ValidationExpression="^([1-9]|0[1-9]|1[0-2])[- / .]([1-9]|0[1-9]|1[0-9]|2[0-9]|3[0-1])[- / .](1[9][0-9][0-9]|2[0][0-9][0-9])$" 
        ValidationGroup="validateInputs"></asp:RegularExpressionValidator>
        <ajaxToolkit:CalendarExtender ID="calendarButtonExtender1" runat="server" TargetControlID="txtTo" 
            PopupButtonID="ImageCalender" />
</td>
</tr>
<tr>
<td>
<asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" 
        ValidationGroup="validateInputs" class="button"/>
</td>
<td>
<asp:Button ID="btnReset" runat="server" Text="Reset" 
        onclick="btnReset_Click" class="button" />
</td>
</tr>
</table>
<table style = "width : 70%;height:70%; float : right; border:3">
<tr><td>
                <asp:GridView ID="gvShowReportCategoryWise" runat="server" AutoGenerateColumns="false" 
                    Width="70%" class="gridView"
                     AllowPaging="true" PagerSettings-Mode="Numeric" 
        PageButtonCount="3"  PageSize="5" OnPageIndexChanging="gvShowReportCategoryWise_PageIndexChanging">
               <Columns>
                <asp:BoundField HeaderText="Bill Date" DataField="Date" />
                <asp:BoundField HeaderText="Category Name" DataField="CategoryName" />
                <asp:BoundField HeaderText="Total Sales(in Rupees)" DataField="TotalSales" />
                </Columns>
                </asp:GridView>
                </td></tr>

</table></div>
</asp:Content>
