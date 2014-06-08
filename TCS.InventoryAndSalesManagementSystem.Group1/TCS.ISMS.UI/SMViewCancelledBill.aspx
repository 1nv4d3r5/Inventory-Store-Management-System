<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SMViewCancelledBill.aspx.cs" Inherits="TCS.ISMS.UI.SMViewCancelledBill" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" ID="ScriptManager1" ScriptMode="Debug" CombineScripts="false" />
    <div id = "main" style = "width : 70%;height : 70%; ">
<h1 style = "text-align : center;">
View Cancelled Bills
</h1>
<br />
<table style = "width : 70%;height:70%; float : right;">
<asp:Label id="lblMessage" runat="server" ForeColor='Red' />
<tr>
<td>
<asp:Label ID="lblCancelledBill" runat="server" Text="Select Date"></asp:Label>
</td>
<td>
    <asp:TextBox ID="txtDate" runat="server" OnTextChanged="txtDate_TextChanged" 
        AutoPostBack="True" class="textBox"></asp:TextBox>
    <asp:ImageButton runat="Server" ID="imgCalender" 
            ImageUrl="~/images/Calendar_scheduleHS.png" 
            AlternateText="Click to show calendar" /><br />
        <ajaxToolkit:CalendarExtender ID="calendarCancelBill" runat="server" TargetControlID="txtDate" 
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
<asp:GridView ID="gvShowCancelledBills" runat="server" AutoGenerateColumns="false" Width="70%" class="gridView" BackColor = "white"
 CellPadding = "10" CellSpacing = "10" AllowPaging = "true"  AllowSorting = "true" BorderColor = "Black" BorderWidth = "2" EditRowStyle-BorderColor = "Black"
  HeaderStyle-BackColor = "AliceBlue" GridLines = "None">
      
        <Columns>

        <asp:BoundField HeaderText="Bill No." DataField="billNumber"  />
            <asp:BoundField HeaderText="Bill Date" DataField="billDate" />
            <asp:BoundField HeaderText="Customer Name" DataField="customerName" />
            <asp:BoundField HeaderText="Bill Amount" DataField="totalBillAmount"/>
            <asp:BoundField HeaderText="Sales Person Id" DataField="EmployeeId"/>
            
            
           
        </Columns>
    </asp:GridView></div>

</asp:Content>
