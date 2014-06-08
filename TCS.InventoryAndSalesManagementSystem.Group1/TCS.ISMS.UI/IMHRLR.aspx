<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IMHRLR.aspx.cs" Inherits="TCS.ISMS.UI.IMHRLR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <!-- // File Summary  : Shows Report of Highest and Lowest Rolling Items
// ---------------------------------------------------------------------------------
// File Summary  : Highest And Lowest Rolling Items
// Date Created  : 24'April'2013
// Author   : Naincy Jain, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// Change History :
// Change Description# : Added Validations to the Page
// Changed By  : NAincy Jain
// Date Modified  : 25'April'2013
// ---------------------------------------------------------------------------------
// Change History :
// Change Description# : Added Ajax Calender
// Changed By  : NAincy Jain
// Date Modified  : 03'May'2013
/////////////////////////////////////////////////////////////////////////////////////////////////		-->
<ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" ID="ScriptManager1" ScriptMode="Debug" CombineScripts="false" />
<div id = "rightContainer" style = "width : 70%;height : 70%; ">
<h1 style=" text-align:center">
Highest Rolling/Lowest Rolling Items
</h1>
<br /><br />
 <table style = "width : 70%;height :  70%; float:right">
 <tr>
 <td>
 <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
 </td></tr>
<tr>
<td>
<asp:Label ID="lblFrom" runat="server" Text="From Date (mm/dd/yyyy)"></asp:Label>
</td>
<td>
<asp:TextBox ID="txtFrom" runat="server" Text="" 
        ontextchanged="txtFrom_TextChanged" class="textBox" MaxLength="8"></asp:TextBox>
<asp:ImageButton runat="Server" ID="imgCalenderDOB" 
            ImageUrl="~/images/Calendar_scheduleHS.png" 
            AlternateText="Click to show calendar" />
    <asp:RequiredFieldValidator ID="rfvFromDate" runat="server" 
        ControlToValidate="txtFrom" Display="Dynamic" ErrorMessage="Select A Date" 
        ForeColor="Red" ValidationGroup="vg1"></asp:RequiredFieldValidator>
    <br />
        <ajaxToolkit:CalendarExtender ID="calendarFromDate" runat="server" TargetControlID="txtFrom" 
            PopupButtonID="imgCalenderDOB"  />
</td>
</tr>
<tr>
<td>
<asp:Label ID="lblTo" runat="server" Text="To Date (mm/dd/yyyy)"></asp:Label>
</td>
<td>
<asp:TextBox ID="txtTo" runat="server" Text="" ontextchanged="txtTo_TextChanged" 
        class="textBox" MaxLength="8"></asp:TextBox>
<asp:ImageButton runat="Server" ID="ImageButton1" 
            ImageUrl="~/images/Calendar_scheduleHS.png" 
            AlternateText="Click to show calendar" />
    <asp:RequiredFieldValidator ID="rfvToDate" runat="server" 
        ControlToValidate="txtTo" Display="Dynamic" ErrorMessage="Select A Date" 
        ForeColor="Red" ValidationGroup="vg1"></asp:RequiredFieldValidator>
    <br />
        <ajaxToolkit:CalendarExtender ID="calendarToDate" runat="server" TargetControlID="txtTo" 
            PopupButtonID="ImageButton1"  />
</td>
</tr>
<tr>
<td colspan="2">
<asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" 
        ValidationGroup="vg1" class="button" />
<asp:Button ID="btnReset" runat="server" Text="Reset" 
        onclick="btnReset_Click" class="button"/>
</td>
</tr>
<tr>
<td colspan="4" align="center">
    
<asp:Label ID="lblHigh" runat="server" Text="Highest Rolling"></asp:Label>
</td>
</tr>
<tr>
<td colspan="4" align="center">
<asp:GridView ID="gvHighestRolling" runat="server" AutoGenerateColumns="false" class="gridView">
<Columns>
<asp:BoundField HeaderText="Item Name" DataField="ItemName" />
<asp:BoundField HeaderText="Item Category" DataField="ItemCategory" />
<asp:BoundField HeaderText="Item Sold" DataField="ItemSold" />
</Columns>
</asp:GridView>
</td></tr>

<!--Top 5 Highest and Lowest Rolling Items-->
<br />

<tr>
<td colspan="4" align="center">
<asp:Label ID="lblLow" runat="server" Text="Lowest Rolling"></asp:Label>
</td>
</tr>
<tr>
<td colspan="4" align="center">
<!--Top 5 Highest and Lowest Rolling Items-->
<asp:GridView ID="gvLowestRolling" runat='server'  AutoGenerateColumns="false" class="gridView" >
<Columns>
<asp:BoundField HeaderText="Item Name" DataField="ItemName" />
<asp:BoundField HeaderText="Item Category" DataField="ItemCategory" />
<asp:BoundField HeaderText="Item Sold" DataField="ItemSold" />
</Columns>
</asp:GridView>
</td></tr>
</table>
</div>
</asp:Content>
