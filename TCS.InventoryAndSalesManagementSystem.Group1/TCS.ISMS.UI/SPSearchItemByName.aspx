<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SPSearchItemByName.aspx.cs" Inherits="TCS.ISMS.UI.SPSearchItemByName" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<!--
/*///////////////////////////////////////////////////////////////////////////////////
//
//	File Description	: This file contains an GUI for Sales Person to Search Item by Name.
// ---------------------------------------------------------------------------------
//	Date Created		: April 27, 2013
//	Author			    : Amit Nadkarni, Tata Consultancy Services
// ---------------------------------------------------------------------------------*/
// ---------------------------------------------------------------------------------
//
// -->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id = "rightContainer" style = "width : 70%; height : 70%;">
<table style = "width : 70%; height : 70%; float : right;">
<tr>
<td>
<asp:Label ID="lblItemName" runat="server" Text="Enter Item Name"></asp:Label>
</td>
<td>
<asp:TextBox ID="txtName" runat="server" Text=""></asp:TextBox>
</td>
</tr>
<tr>
<td>
<asp:Button ID="btnSearch" runat="server" Text="Search" onclick="btnSearch_Click" />
</td>
<td>
<asp:Button ID="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click" />
</td>
</tr>
</table>
</div>
<asp:GridView ID="gvItemSearch" runat="server" AutoGenerateColumns="false" 
    Width="70%" onselectedindexchanged="gvItemSearch_SelectedIndexChanged" >
        <Columns>
            <asp:BoundField HeaderText="Item ID" DataField="ItemID" />
            <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
            <asp:BoundField HeaderText="Item Category" DataField="ItemCategory" />
            <asp:BoundField HeaderText="Item Quantity" DataField="ItemQuantity" />
            <asp:BoundField HeaderText="Item Price" DataField="ItemPrice" />
            <asp:BoundField HeaderText="Item Closing Count " DataField="ItemClosingCount" />
            <asp:BoundField HeaderText="Item Discount " DataField="ItemDiscount" />
        </Columns>
    </asp:GridView>
</asp:Content>
