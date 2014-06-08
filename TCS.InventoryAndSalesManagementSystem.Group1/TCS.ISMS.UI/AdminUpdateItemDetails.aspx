<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminUpdateItemDetails.aspx.cs" Inherits="TCS.ISMS.UI.AdminUpdateItemDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div id = "ItemListContainer" style = "width : 70%; height : 70%; " >
   <h1 style = "text-align : center;> Update Item Details</h1>
                <table style="height: 70%; width: 70%; float : right;">
                <tr>
                    <td>
                                    <asp:Label ID="LblSearchCategory" runat="server" Text="Category"></asp:Label>
                                    
                    </td>
                    <td>
                            <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>-----</asp:ListItem>
                            <asp:ListItem>Soap</asp:ListItem>
                            <asp:ListItem>Detergent</asp:ListItem>
                            <asp:ListItem>Shampoo</asp:ListItem>
                            <asp:ListItem>Hand Wash</asp:ListItem>
                            </asp:DropDownList>
                    </td>
                </tr>
                <tr><td><b>Item ID</b></td>
                <td><b>Item Name</b></td>
                <td><b>Item Category</b></td>
                <td><b>Quantity</b></td>
                <td><b>Item Price</b></td>
            
                </tr>
                <tr>
                <td>1001</td> 
                <td>Colgate</td>
                <td>Toothpaste</td>
                <td>300</td>
                <td>45</td>
                <td>
                    <asp:Button ID="btnEditItems1" runat="server" Text="Edit" />
                 </td>
                </tr>
                <tr>
                <td>1002</td> 
                <td>Pepsodent</td>
                <td>Toothpaste</td>
                <td>350</td>
                <td>40</td>
                 <td>
                    <asp:Button ID="btnEditItems2" runat="server" Text="Edit" />
                 </td>
                </tr>
                <tr>
                <td>1003</td> 
                <td>Close Up</td>
                <td>Toothpaste</td>
                <td>250</td>
                <td>20</td>
                 <td>
                    <asp:Button ID="btnEditItems3" runat="server" Text="Edit" />
                 </td>
                </tr>
                <tr>
                <td>1004</td> 
                <td>Cibaca</td>
                <td>Toothpaste</td>
                <td>400</td>
                <td>20</td>
                 <td>
                    <asp:Button ID="btnEditItems4" runat="server" Text="Edit" />
                 </td>
                </tr>
                </table>
 </div>
</asp:Content>
