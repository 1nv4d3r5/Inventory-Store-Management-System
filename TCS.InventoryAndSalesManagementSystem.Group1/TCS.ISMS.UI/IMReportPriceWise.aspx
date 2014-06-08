<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IMReportPriceWise.aspx.cs" Inherits="TCS.ISMS.UI.IMReportPriceWise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" ID="ScriptManager1" ScriptMode="Debug" CombineScripts="false" />
<div id = "main" style = "width : 70%;height : 70%; ">
<h1 style=" text-align:center">
View Report Price Wise
</h1>
<table style = "width : 70%;height:70%; float : right;">
<tr>
<td>
<asp:GridView ID="gvPriceWiseReport" runat="server" AutoGenerateColumns="false" class="gridView"  AllowPaging="true" PageSize="10" PagerSettings-Mode="Numeric" 
 PageButtonCount="3" OnPageIndexChanging="gvPriceWiseReport_PageIndexChanging">
<Columns>

<asp:BoundField HeaderText="Price Range" DataField="Range" />
<asp:BoundField HeaderText="Stock Available" DataField="TotalAvailable" />
</Columns>
</asp:GridView>
</td>
</tr>
<tr>
<td>
<asp:Button ID="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click" class="button" />
</td>
</tr>
<!--<table style = "width : 70%;height :  70%; float : right;">
<tr> <td><strong>Sr. No.</strong></td><td class="style3"><strong>Price</strong></td><td class="style2"> <strong>Total availability(item count)</strong></td></tr>
<tr> <td>135</td><td class="style3"><1000</td><td>1000</td></tr>
<tr> <td>pqr</td><td class="style3">1000 to 3000</td><td>1000</td></tr>
<tr> <td class="style1">xyz </td><td class="style3">>3000</td><td class="style1">1000</td></tr>

<tr>
<td>
<asp:Button ID="btnback" runat="server" Text="Back" />
</td>
</tr></table>-->
</table></div>
</asp:Content>
