<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IMPlaceOrder.aspx.cs" Inherits="TCS.ISMS.UI.IMPlaceOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!--//File Description	: This file Contains an interface for Inventory Manager to Place Order.
// ---------------------------------------------------------------------------------
//  Date Created    : April 25, 2013
//  Author          : Amit Nadkarni, Tata Consultancy Services
//----------------------------------------------------------------------------------
// Change History :
// Change Description# : Added Functionalities Place Order page 
// Changed By  : Amit Nadkarni
// Date Modified  : 2'May'2013
/////////////////////////////////////////////////////////////////////////////////////////////////-->	
    <style type="text/css">
        .style1
        {
            width: 412px;
        }
        .style2
        {
            width: 274px;
        }
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id = "rightContainer" style = "width : 70%; height : 70%;">
<h1 style = "text-align : center;"><b>Place Order</b></h1>
<table>
<tr>
<td>
<asp:Label ID="lblDate" runat="server" Text="Order Date"></asp:Label>
<asp:Label ID="lblDisplayDate" runat="server" Text=""></asp:Label>
</td>
</tr>
</table>
<asp:GridView ID="gvItemDetailList" runat="server" AutoGenerateColumns="False" 

            AllowPaging="true" PagerSettings-Mode="Numeric" 
        PageButtonCount="3"  PageSize="4" 
        OnPageIndexChanging="gvItemDetailList_PageIndexChanging">
        <Columns>
        <asp:TemplateField HeaderText="Select" >
                <ItemTemplate>
                    <asp:CheckBox ID="chkItemID" name="chkItemID" runat="server" value='<%#Eval("ItemId") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Item ID" DataField="ItemID" />
            <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
            <asp:BoundField HeaderText="Item Category" DataField="ItemCategory" />
            <asp:BoundField HeaderText="Item Price" DataField="ItemPrice" />
            <asp:BoundField HeaderText="Item Quantity" DataField="ItemQuantity" />
             
        </Columns>
    </asp:GridView>
    
                <asp:Button ID="btnAddCart" runat="server" Text="Add to Cart" 
            onclick="btnAddCart_Click" />

                <asp:Label ID="lblMessage" runat="server" Text="Label" Visible="False" 
            ForeColor="#FF3300"></asp:Label>

                <asp:GridView ID="gvShowItems" runat="server" AutoGenerateColumns="False"  OnRowDataBound="OnGridViewDataBinding" >
        <Columns>
        <asp:TemplateField HeaderText="Select" >
                <ItemTemplate>
                    <asp:CheckBox ID="chkItemID" name="chkItemID" runat="server" value='<%#Eval("ItemId") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Item ID" DataField="ItemID" />
            <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
            <asp:BoundField HeaderText="Item Categoty" DataField="ItemCategory" />
            <asp:BoundField HeaderText="Item Price" DataField="ItemPrice" />
           <asp:TemplateField HeaderText="Order Quantity" >
                <ItemTemplate>
                    <asp:TextBox ID="txtOrderQuantity" name="txtOrderQuantity" runat="server" />
                     <asp:RequiredFieldValidator ID="rfvItemQuantity" runat="server" ErrorMessage="Quantity can not be blank" ValidationGroup="validateInputs" Display="Dynamic" ControlToValidate="txtOrderQuantity" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revItemQuantity" runat="server" ErrorMessage="Numeric Value only" ControlToValidate="txtOrderQuantity" Display="Dynamic" ValidationGroup="validateInputs" Visible="True" ValidationExpression="[[+\d]*" ForeColor="Red"></asp:RegularExpressionValidator>
                     </ItemTemplate>
            </asp:TemplateField>
              <asp:TemplateField HeaderText="Vendors Available" >
                <ItemTemplate>
                    <asp:DropDownList ID="ddlVendor" name="ddlVendor" runat="server" />
                     </ItemTemplate>
            </asp:TemplateField>
            
        </Columns>
    </asp:GridView>
    <asp:Button ID="btnPlaceOrder" runat="server" Text="Place Order" Visible="False" 
            onclick="btnPlaceOrder_Click" ValidationGroup="validateInputs" />
                
               
      

                <asp:Button ID="btnReset" runat="server" onclick="btnReset_Click" 
            Text="Reset Cart" Visible="False" />
        <asp:Button ID="btnDelete" runat="server" onclick="btnDelete_Click" 
            Text="Remove From Cart" Visible="False" />

               
      

        <asp:Button ID="btnCalcAmnt" runat="server" onclick="Button1_Click" 
            Text="Calculate Bill Amount" Visible="False" 
            ValidationGroup="validateInputs" />

               
      

        <asp:Button ID="btnCancel" runat="server" onclick="Button1_Click1" 
            Text="Cancel" Visible="False" />

               
      

        <br />

                <asp:Label ID="lbltotalAmount" runat="server" Text="Total Amount is Rs:" 
            Visible="False"></asp:Label>
        <asp:Label ID="lbltotalAmnt" runat="server" Visible="False"></asp:Label>

               
      

        <asp:Label ID="LabelMessage" runat="server" Text="Label" Visible="False"></asp:Label>

               
      

</div>

</asp:Content>
