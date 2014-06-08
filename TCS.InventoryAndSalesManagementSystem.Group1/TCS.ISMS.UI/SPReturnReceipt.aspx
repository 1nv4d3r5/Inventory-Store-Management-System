<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SPReturnReceipt.aspx.cs" Inherits="TCS.ISMS.UI.SPReturnReceipt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 103px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">       
    <div id = "rightContainer" style = "float : left; width : 80%">
    <h1 style="text-align:center">
        <strong><u>CUSTOMER RETURN ITEM RECEIPT</u></strong></h1>
    <br />
    <p style = "color :Red; float : left;"> * indicates manadatory</p><br /><br />
<table>
            <tr>
                <td>
                    <asp:Label ID="lblBillNo" runat="server" Text="Bill Number:"></asp:Label><sup style = "color : Red;">*</sup>
                </td>
                <td>
                    <asp:TextBox ID="txtBillNo" runat="server" MaxLength="6"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="revBillNo" runat="server" 
                        ControlToValidate="txtBillNo" Display="Dynamic" 
                        ErrorMessage="Invalid Bill Number" ForeColor="Red" 
                        ValidationExpression="^[0-9]{0,5}" ValidationGroup="validationInputs"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rfvBillNo" runat="server" 
                        ControlToValidate="txtBillNo" Display="Dynamic" ErrorMessage="Enter Bill Number" 
                        ForeColor="red" ValidationGroup="validationInputs"></asp:RequiredFieldValidator>
                        </td>
                
                <td><asp:Button ID="btnSubmit" runat="server" Text="Submit" class = "button"
                method="post" ValidationGroup="validationInputs" onclick="btnSubmit_Click"/></td>
                </tr>
                
                </table>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                <asp:GridView ID="gvshowBillItems" runat="server"  class = "gridView" AutoGenerateColumns="false" Width="100%" Float="right">
               <Columns>

               <asp:TemplateField HeaderText="Select">
             <ItemTemplate>
                    <asp:CheckBox ID="chkSelect" name="chkSelect" runat="server"   />
                </ItemTemplate>
            </asp:TemplateField>

                <asp:BoundField HeaderText="Item ID" DataField="ItemID" />
                <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
                <asp:BoundField HeaderText="Line Total" DataField="LineTotal" />
                <asp:BoundField HeaderText="Quantity" DataField="QuantityPurchased" />
                </Columns>
                </asp:GridView>
                <br />
                 

                  <asp:GridView ID="gvSelectedItems" runat="server" class = "gridView" AutoGenerateColumns="false" Width="100%" Float="right">
               <Columns>

                <asp:BoundField HeaderText="Item ID" DataField="ItemID" />
                <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
                
                <asp:BoundField HeaderText="Line Total" DataField="LineTotal" />
                <asp:BoundField HeaderText="Quantity" DataField="QuantityPurchased" />
                
                 <asp:TemplateField HeaderText = "Returned Quantity">
                 <ItemTemplate>
                     <asp:TextBox ID="txtReturnedItemQuantity" MaxLength="3" runat="server"></asp:TextBox>
                 </ItemTemplate>
                 </asp:TemplateField>

                 <asp:TemplateField HeaderText = "Return total">
                 <ItemTemplate>
                     <asp:Label ID="lblReturnTotal" runat="server"></asp:Label>
                 </ItemTemplate>
                 </asp:TemplateField>

                 <asp:TemplateField HeaderText = "Remarks">
                 <ItemTemplate>
                     <asp:TextBox ID="txtRemarks" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvRemarks"  runat="server" ErrorMessage="Please enter remark" Display="Dynamic" ValidationGroup="validate" ControlToValidate="txtRemarks">
                     </asp:RequiredFieldValidator>
                 </ItemTemplate>
                     
                 </asp:TemplateField>
              
                </Columns>
                </asp:GridView>
                <table>
                <tr><td><asp:Button ID="btnEdit" runat="server" Text="Edit" class = "button"
                method="post" ValidationGroup="validationInputs" 
        onclick="btnEdit_Click"/></td>
       <td>
           <asp:Button ID="btnSubmitGridView" runat="server" Text="Submit"  class = "button"
               onclick="btnSubmitGridView_Click" ValidationGroup="validate" />
       </td>
       <td>
           <asp:Button ID="btnCalculate" runat="server" Text="Calaulate Return Amount"  
               class = "button" onclick="btnCalculate_Click" />
       </td>
                <td align="center">
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" class = "button"
                method="post" onclick="btnCancel_Click"/></td></tr></table>
               
               </div>
              
</asp:Content>
