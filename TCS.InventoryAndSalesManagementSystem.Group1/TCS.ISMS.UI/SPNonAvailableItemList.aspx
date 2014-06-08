<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SPNonAvailableItemList.aspx.cs" Inherits="TCS.ISMS.UI.SPNonAvailableItemList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id = "rightContainer" style = "float : left; width : 70%; height : 70%">
    
       <h1 style="text-align:center">
       <strong><u> LIST OF NON-AVAILABLE ITEMS</u></strong> </h1>
    <br />
    <table style="height: 70%; width: 70%;float:right">
    <tr>
    <td valign ="top" class="style1">
     <asp:GridView ID="gvnotAvailableItems" runat="server" AutoGenerateColumns="false"  Width="92%" Float="right">
               <Columns>
                <asp:BoundField HeaderText="Item ID" DataField="ItemId" />
                <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
                <asp:BoundField HeaderText="Category" DataField="Category" />
                <asp:BoundField HeaderText="Quantity Available" DataField="QuantityAvailable" />
                </Columns>
                </asp:GridView>
                </td></tr></table>
                </div>
</asp:Content>
