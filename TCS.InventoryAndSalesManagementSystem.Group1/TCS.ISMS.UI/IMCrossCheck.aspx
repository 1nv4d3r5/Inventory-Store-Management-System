<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IMCrossCheck.aspx.cs" Inherits="TCS.ISMS.UI.IMCrossCheck" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div id = "rightContainer" style = "float : right; width : 70%;height : 70%; ">

<h1>
Cross Check Inventory Against Sales made by The Sales Person
</h1>
<br />
<br />
<table style = "width : 90%;height :  70%; float : right;">
<asp:GridView ID="gvCrossCheck" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="2" PagerSettings-Mode="Numeric"  PageButtonCount="3" OnPageIndexChanging="gvCrossCheck_PageIndexChanging"  >

<Columns>
<asp:BoundField HeaderText="Item Name" DataField="ItemName" />
<asp:BoundField HeaderText="Today's Closing Count" DataField="ItemCount" />
<asp:BoundField HeaderText="Last Day's Closing Count" DataField="LastSale" />
<asp:BoundField HeaderText="Item Sold" DataField="ItemSold" />
<asp:BoundField HeaderText="Difference" DataField="Difference" />
<asp:BoundField HeaderText="Items added by Admin" DataField="AddedByAdmin" />
</Columns>
</asp:GridView>
</table>
</div>
</asp:Content>
