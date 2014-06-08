<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SPShowItem.aspx.cs" Inherits="TCS.ISMS.UI.SPShowItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- // File Summary  : Show Item Page
// ---------------------------------------------------------------------------------
// File Summary  : Added Show Item Page
// Date Created  : 26'April'2013
// Author   : Susmita Rana, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// Change History :
// Change Description# : Added Validations  to the Show Item page 
// Changed By  : Susmita Rana
// Date Modified  : 27'April'2013
// ---------------------------------------------------------------------------------
// Change History :
// Change Description# : Added Category Name in grid view in place of Category ID  to the Show Item page 
// Changed By  : Susmita Rana
// Date Modified  : 6' May'2013
/////////////////////////////////////////////////////////////////////////////////////////////////		-->	
<style type="text/css">
        .style1
        {
            width: 38%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id = "rightContainer" style = "float : left; width : 70%; height : 70%">
    <h1 style="text-align:center">
        <strong><u>ITEMS AVAILABLE</u></strong></h1>
    <br />
<table style="height: 70%; width: 70%; float:right">
<tr><td><asp:Label ID="lblMessage" runat="server" class="label" ForeColor="Red" 
        ></asp:Label></td></tr>
 <tr>
        <td>
            <asp:Label ID="lblItemName" runat="server" class="label" Text="Item Name:"></asp:Label>
        </td>
    
        <td>
            <asp:TextBox ID="txtItemName" runat="server" class="textBox"
                Height="23px" ontextchanged="txtItemName_TextChanged" ></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="txtItemName" Display="Dynamic" 
                ErrorMessage="Numerics are not allowed" ForeColor="Red" 
                ValidationExpression="^[a-zA-Z0-9]+$" ValidationGroup="validateInputs"></asp:RegularExpressionValidator>
        </td>
        <td></td>
        <td>
            <asp:Label ID="lblSearchCategory" runat="server" class="label" Text="Item Category:"></asp:Label>
        </td>
    
        <td>
            <asp:DropDownList ID="ddlCategory" runat="server" AppendDataBoundItems="true" 
                class = "dropDown" onselectedindexchanged="ddlCategory_SelectedIndexChanged" >
                <Items>
       <asp:ListItem Text="Select Category" Value="0" />
   </Items>
            </asp:DropDownList>
        </td>
        <tr>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="Search" 
                onclick="btnSearch_Click" class = "button"/></td>   
         <td><asp:Button ID="btnReset" runat="server" Text="Reset" 
                class = "button" onclick="btnReset_Click"/>
        </td>
           </tr>
   </table>
    <table style="height: 50%; width: 75%; float:right">
<tr><td class="style1">
                <asp:GridView ID="gvShowItemList" runat="server" AutoGenerateColumns="false"  
                    class = "gridView"  AllowPaging="true" PagerSettings-Mode="Numeric" 
        PageButtonCount="3"  PageSize="2"
        OnPageIndexChanging="gvShowItemList_PageIndexChanging" Height="250px">
               <Columns>
                <asp:BoundField HeaderText="Item ID" DataField="ItemId" />
                <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
                <asp:BoundField HeaderText="Category Name" DataField="CategoryName" />
                <asp:BoundField HeaderText="Quantity" DataField="ItemQuantity" />
                <asp:BoundField HeaderText="Item Price" DataField="ItemPrice" />
                </Columns>
                </asp:GridView>
                </td></tr>
                </table>
                 
 </div>
 
</asp:Content>
