<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DeleteItem.aspx.cs" Inherits="TCS.ISMS.UI.DeleteItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- // File Summary  : Delete Item Page
// ---------------------------------------------------------------------------------
// File Summary  : Delete Item Page
// Date Created  : 27 April, 2013
// Author   : Suman Pradhan, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// Change History :
// Change Description# : Added Validations  to the delete item page 
// Changed By  : Suman Pradhan
// Date Modified  : 27 April, 2013
/////////////////////////////////////////////////////////////////////////////////////////////////		-->	

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id = "rightContainer" style = " width : 70%; height : 70%;">
<h1 style = "text-align : center;">View Items</h1><br />
        
           
            <table style="Height:70%;width:70%; float:right">
            <tr>
            <td><asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label></td>
            </tr>
                <tr>

                    <td width="20%" valign ="top" class="style1">
                       <asp:Label ID="lblSearchCategory" runat="server" Text="Category"></asp:Label><sup style = "color : Red;">*</sup>
                    </td>
                    <td width="30%" valign ="top">
                            <asp:DropDownList ID="ddlCategory" runat="server" class="dropDown" AutoPostBack="true"
                             OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" 
                                AppendDataBoundItems="True">
                             <Items>
                              <asp:ListItem Text="Select Category" Value="0" />
                            </Items>
                             </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rvfCategory" runat="server" 
                                ControlToValidate="ddlCategory" Display="Dynamic" 
                                ErrorMessage="Please select a category" ForeColor="Red" 
                                ValidationGroup="validationInputs" InitialValue="0"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                <td>
                 
                 <asp:GridView ID="gvItemList" runat="server" AutoGenerateColumns="false" 
                    Width="169%" class="gridView">
               <Columns>
               <asp:TemplateField HeaderText="Select">
               <ItemTemplate>
               <asp:CheckBox ID="chkItem" name = "chkItem" runat="server" value='<%Eval("ItemID") %>' />
               </ItemTemplate>
               </asp:TemplateField>
                <asp:BoundField HeaderText="Item ID" DataField="ItemID" />
                <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
                
                <asp:BoundField HeaderText="Quantity" DataField="ItemQuantity" />
                <asp:BoundField HeaderText="Item Price" DataField="ItemPrice" />
                </Columns>
        
        </asp:GridView>
               
                </td></tr>
               </table>
               <table style="width:70%; float:right">
                <tr align=left>
    <td>
        <asp:Button ID="btnUpdate" runat="server" Text="Update" 
            onclick="btnUpdate_Click" class ="button" />
        
        &nbsp;&nbsp;&nbsp;
        
         
        <asp:Button ID="btnDelete" runat="server" Text="Delete" 
            onclick="btnDelete_Click" ValidationGroup="validationInputs" class ="button" />
        &nbsp;&nbsp;&nbsp;
            
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
            onclick="btnCancel_Click" class ="button" />
            &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnReset" runat="server" Text="Reset" onclick="btnReset_Click" class="button"/>
    </td>
</tr>
</table>
</div>
</asp:Content>
