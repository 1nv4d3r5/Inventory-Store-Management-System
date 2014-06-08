
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SPGenerateBill.aspx.cs" Inherits="TCS.ISMS.UI.SPGenerateBill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!--
///////////////////////////////////////////////////////////////////////////////////////////////
//
// File Summary  : Generate bill page
// ---------------------------------------------------------------------------------
// Date Created  : Apr 25, 2013
// Author   : Arshin Saluja, Tata Consultancy Services
// ---------------------------------------------------------------------------------
//  Change History : <List of Dev(s) making the change> 
// Change Description# : Added textboxes, buttons, edited gridview. 
// Changed By  : Sandeep Kothawade
// Date Modified  : Apr 29, 2013
// Change Description# : <Change description in Details>  
// Changed By  : <Person Changing>
// Date Modified  : <Modification Date>
//
///////////////////////////////////////////////////////////////////////////////////////////////
-->

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id = "rightContainer" style = " width : 70%; height : 70%;">
       <h1 style = "text-align : center;">Generate Bill</h1>
    <br />
    <table style = "width : 70%; float : right;">
   
     <tr>
 
 <asp:Label ID="lblMessage1" runat="server" ForeColor="Red"></asp:Label>
 </tr>
    <tr>
        <td>
            <asp:Label ID="lblBillNumberLabel" runat="server" Text="Bill Number" ForeColor="Red"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblBillNumber" runat="server" Text="" ForeColor="Red"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblBillDate" runat="server" Text="Bill Date"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblBillsDate" runat="server" Text=""></asp:Label>
        </td>
    </tr>
     <tr>
    
    <td></td>
    <td></td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="lblSalesPerson" runat="server" Text="Sales Person Id"></asp:Label>
           </td>
           <td>
               <asp:Label ID="lblSalesPersonID"  runat="server" ></asp:Label>
           </td>
          <td>
        <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name *"></asp:Label>
    </td>
    <td>
        <asp:TextBox ID="txtCustomerName" runat="server" ValidationGroup="valBill" class="textBox" MaxLength="20"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvCustomerName" runat="server" 
            ErrorMessage="Customer name can not be blank" ForeColor="Red" 
            ControlToValidate="TxtCustomerName" Display="Dynamic" ValidationGroup="valBill"></asp:RequiredFieldValidator>
        <asp:RegularExpressionValidator ID="revCustomerName" runat="server" 
            ControlToValidate="txtCustomerName" Display="Dynamic" 
            ErrorMessage="Invalid Customer Name" ForeColor="Red" 
            ValidationExpression="^[a-z A_Z]+$" ValidationGroup="valBill"></asp:RegularExpressionValidator>
    </td>
    </tr>
    <tr>
    
    <td></td>
    
    </tr>
    <tr>
        <td>
            <asp:Label ID="LblItemName" runat="server" Text="Item Name"></asp:Label>
        </td>
    
        <td>
            <asp:TextBox ID="txtItemName" runat="server" class="textBox" MaxLength="10"></asp:TextBox>
        </td>
        <td>
            <asp:Label ID="LblSearchCategory" runat="server" Text="Item Category"></asp:Label>
        </td>
    
        <td>
            <asp:DropDownList ID="ddlCategory" runat="server" AppendDataBoundItems="true"
                >
                <Items>
       <asp:ListItem Text="Select Category" Value="0" />
   </Items>

            </asp:DropDownList>
        </td>
        <td>
            <asp:Button ID="btnSearch" runat="server" Text="Search" 
                onclick="BtnSearch_Click" class="button"/>
        </td>
        
    </tr>
            
    <tr>
    
    <td></td>
    <td>
        &nbsp;</td>
    </tr>
    </table>

                

  
                

                 <asp:GridView ID="gvshowItemList" runat="server" AutoGenerateColumns="false" Width="70%" >
      
        <Columns>

        <asp:TemplateField HeaderText="Select" >
                <ItemTemplate>
                    <asp:CheckBox ID="chkItemID" name="chkItemID" runat="server" value='<%#Eval("ItemID") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Item ID" DataField="ItemID" />
            <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
          
            <asp:BoundField HeaderText="Available Quantity" DataField="ItemQuantity" />
            <asp:BoundField HeaderText="Price" DataField="ItemPrice" />
            <asp:BoundField HeaderText="Discount (%)" DataField="ItemDiscount" />
           
          
        </Columns>
    </asp:GridView>



                
                <table style = "width : 70%; float : right;">
                <tr><td>
                    <asp:Button ID="btnAddItemToBill" runat="server" Text="ADD TO BILL" 
                method="post" onclick="AddItemToBill_click" class="button"/>&nbsp;
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                    </td>
                </tr>
               </table>
                
                 <asp:GridView ID="gvBillWindow" runat="server" AutoGenerateColumns="false" Width="70%">
      
        <Columns>
            <asp:TemplateField HeaderText="Select" >
                <ItemTemplate>
                    <asp:CheckBox ID="chkItemID" name="chkItemID" runat="server" value='<%#Eval("ItemID") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Item ID" DataField="ItemID" />
            <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
          
          
            <asp:BoundField HeaderText="Price" DataField="ItemPrice" />
            <asp:BoundField HeaderText="Discount (%)" DataField="ItemDiscount" />

            <asp:TemplateField HeaderText="Order Quantity" >
                <ItemTemplate>
                    <asp:TextBox ID="txtOrderQuantity" name="txtOrderQuantity" MaxLength="3" runat="server" class="textBox"/>
                    <asp:RequiredFieldValidator ID="rfvItemQuantity" runat="server" ErrorMessage="Quantity can not be blank" ValidationGroup="validateInputs" Display="Dynamic" ControlToValidate="txtOrderQuantity" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revItemQuantity" runat="server" ErrorMessage="Numeric Value only" ControlToValidate="txtOrderQuantity" Display="Dynamic" ValidationGroup="validateInputs" Visible="True" ValidationExpression="[[+\d]*" ForeColor="Red"></asp:RegularExpressionValidator>
                </ItemTemplate>
            </asp:TemplateField>
  

        </Columns>
    </asp:GridView>

                <table style = "width : 70%; float : right;">
                <tr>
                <td>
                    <asp:Button ID="btnDelete" runat="server" Text="Delete" 
                        onclick="BtnDelete_Click" class="button"/>
                &nbsp;&nbsp;
                    <asp:Button ID="btnCalcBill" runat="server" onclick="CalculateTotal" 
                        Text="Calculate Bill Amount" ValidationGroup="validateInputs" class="button"/>
                    </td>
                <td>
                    <asp:Label ID="lblTotalPriceLabel" runat="server" Text="Total Price:" ></asp:Label>
                    <asp:Label ID="lblTotalPrice" runat="server" ></asp:Label>
                    </td>
                </tr>
                 <tr>
    
                <td></td>
                <td></td>
                </tr>
                <tr>
                <td>
            <asp:Label ID="lblMoneyIn" runat="server" Text="Money In *"></asp:Label>
           </td>
           <td>
               <asp:TextBox ID="txtMoneyIn" runat="server" AutoPostBack="True" 
                   ontextchanged="txtMoneyIn_TextChanged" class="textBox"></asp:TextBox>
               <asp:RequiredFieldValidator ID="rfvMoenyIn" runat="server" 
                   ControlToValidate="txtMoneyIn" Display="Dynamic" 
                   ErrorMessage="Money In field can not be blank" ForeColor="Red" 
                   ValidationGroup="valBill"></asp:RequiredFieldValidator>
           </td>
            
                </tr>
                 <tr>
                <td>
            <asp:Label ID="lblReturnAmountLabel" runat="server" Text="Amount To be Returned"></asp:Label>
           </td>
           <td>
               <asp:Label ID="lblReturnAmount" runat="server"
                   class="textBox" ></asp:Label>
           </td>
           </tr>
            <tr>
    
                <td>
                    <asp:Label ID="lblErrorMsg" runat="server" ForeColor="Red"></asp:Label>
                </td>
                <td></td>
                </tr>

                </table>
            
                <center>
                <table style = "width : 70%; float : right;">
                <tr><td>
                    <asp:Button ID="btnGenerateButton" runat="server" Text="Generate Bill" 
                method="post" ValidationGroup="valBill" onclick="GenerateButton_Click" class="button"/></td>
                 <td>
                    <asp:Button ID="btnReset" runat="server" Text="Reset" onclick="BtnReset_Click" class="button"/>
                </td>
                <td>
                    &nbsp;</td>
                <td align="center">
                    <asp:Button ID="btncancelButton" runat="server" Text="Cancel" 
                method="post" onclick="cancelButton_Click" class="button"/></td></tr>
               </table></center>
               </div>
</asp:Content>
