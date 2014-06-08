<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IMViewReportOfItemNotAvailable.aspx.cs" Inherits="TCS.ISMS.UI.IMViewReportOfItemNotAvailable" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id = "rightContainer" style = "width : 70%; height : 70%; float:right">
<h1 >Items Not Available In Inventory </h1><br /><br />
<asp:GridView ID="gvItemDetailList" runat="server" AutoGenerateColumns="False" 
        onselectedindexchanged="gvItemDetailList_SelectedIndexChanged1" >
        <Columns>
        
            <asp:BoundField HeaderText="Item ID" DataField="ItemID" />
            <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
             <asp:BoundField HeaderText="Category Name" DataField="CategoryName" />

            <asp:BoundField HeaderText="Item Price" DataField="ItemPrice" />
            <asp:BoundField HeaderText="Item Quantity" DataField="ItemQuantity" />
            
        </Columns>
    </asp:GridView>
</div>
</asp:Content>
