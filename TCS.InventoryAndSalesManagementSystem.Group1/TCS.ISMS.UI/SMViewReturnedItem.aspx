<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SMViewReturnedItem.aspx.cs" Inherits="TCS.ISMS.UI.SMViewReturnedItem" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" ID="ScriptManager1" ScriptMode="Debug" CombineScripts="false" />
<div id = "rightContainer" style = " width : 70%; height : 70%;">
<h1 style = "text-align : center;">
View Returned Items
</h1>
<br />
<p style = "color :Red; float : left;"> * indicates manadatory</p><br /><br />
<table style = "width : 70%;height:70%; float : right;">
<tr>
<td>
<asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
</td></tr>
<tr>
<td>
<asp:Label ID="lblCancelledBill" runat="server" Text="Select Date"></asp:Label><sup style = "color : Red;">*</sup>
</td>
<td>
    <asp:TextBox ID="txtDate" runat="server" OnTextChanged="txtDate_TextChanged" 
        AutoPostBack="True" ></asp:TextBox>
    <asp:ImageButton runat="Server" ID="imgCalender" 
            ImageUrl="~/images/Calendar_scheduleHS.png" 
            AlternateText="Click to show calendar" /><br />
        <ajaxToolkit:CalendarExtender ID="calendarButtonExtender" runat="server" TargetControlID="txtDate" 
            PopupButtonID="imgCalender" />
</td>
</tr><!--
<tr>

<td colspan="4">
<asp:Button ID="btnViewCanceleldBill" runat="server" Text="Submit" 
         />
<asp:Button ID="btnCancel" runat="server" Text="Cancel" />
</td>
</tr>-->
</table>

<asp:GridView ID="gvShowReturnedItemList" runat="server" AutoGenerateColumns="false" Width="70%" 
AllowPaging="true" PageSize="2" PagerSettings-Mode="Numeric"  PageButtonCount="3"
 OnPageIndexChanging="gvReturnedItems_PageIndexChanging"  >
 
      
        <Columns>

        <asp:BoundField HeaderText="Bill No." DataField="BillNo" />
        <asp:BoundField HeaderText="Item ID" DataField="ItemID" />
            <asp:BoundField HeaderText="Item Name" DataField="Name" />
            <asp:BoundField HeaderText="Quantity Returned" DataField="Quantity" />
            <asp:BoundField HeaderText="Remarks" DataField="Remarks" />
         
            
            
           
        </Columns>
    </asp:GridView>
</div>
</asp:Content>
