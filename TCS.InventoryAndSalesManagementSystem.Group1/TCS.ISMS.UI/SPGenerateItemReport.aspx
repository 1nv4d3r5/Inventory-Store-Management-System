<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SPGenerateItemReport.aspx.cs" Inherits="TCS.ISMS.UI.SPGenerateItemReport" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 <!-- // File Summary  : Shows Report of Not Available Items
// ---------------------------------------------------------------------------------
// File Summary  : Generate Report of Not Available Items
// Date Created  : 24'April'2013
// Author   : Naincy Jain, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// Change History :
// Change Description# : Added Validations to the Page
// Changed By  : NAincy Jain
// Date Modified  : 01' May'2013
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
       <strong><u> ITEM REPORT</u></strong> </h1>
    <br />
    <p style = "color :Red; float : left;"> * indicates manadatory</p><br /><br />
<table style="height: 70%; width: 70%;float:left">
<tr><td>
<asp:Label ID="LblMessage" runat="server" ForeColor="Red"></asp:Label>
</td></tr>
<tr>

<td valign ="top" class="style1">
                   
               <asp:Label ID="lblItemCategory" runat="server" Text="Select Item Category:"></asp:Label><sup style = "color : Red;">*</sup>
                </td>
                <td valign ="top">
                <asp:DropDownList ID="ddlCategory" runat="server" Height="25px" Width="188px" 
                        onselectedindexchanged="ddlCategory_SelectedIndexChanged"
                        AppendDataBoundItems="true" AutoPostBack="true" class="dropDown">
                  <asp:ListItem text = "Select Category" value = "0"></asp:ListItem>       
                    </asp:DropDownList>
               
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="ddlCategory" Display="Dynamic" 
                        ErrorMessage="Select item category" ForeColor="Red" 
                        ValidationGroup="validationInputs"></asp:RequiredFieldValidator>
                    </td>                 
</tr>


<tr>
<td class="style1">
                <asp:GridView ID="gvshowInventoryList" runat="server" AutoGenerateColumns="false" 
                    Width="172%" Float="left" class="gridView">
               <Columns>
               <asp:TemplateField HeaderText="Select" >
                <ItemTemplate>
                    <asp:CheckBox ID="chkItems" name="chkItems" runat="server" value='<%#Eval("ItemId") %>' AutoPostBack="False" />
                </ItemTemplate>
            </asp:TemplateField>
                <asp:BoundField HeaderText="Item ID" DataField="ItemId" />
                <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
                <asp:BoundField HeaderText="Item Price" DataField="ItemPrice" />
                <asp:BoundField HeaderText="Quantity" DataField="ItemQuantity" />
                 <asp:BoundField HeaderText="Category Name" DataField="CategoryName" />
                 <asp:BoundField HeaderText="Category ID" DataField="ItemCategory" />
                </Columns>
                </asp:GridView>
                </td></tr>
              <tr><td class="style1"></td></tr>
                  
                <tr>
                    <td class="style1" colspan="2">
                        <asp:Button ID="btnaddToReport" runat="server" Text="Add To Report" 
                method="post" ValidationGroup="validationInputs" Float="right" onclick="addToReport_Click" class="button"/>
                          
                          <asp:Button ID="BtnGenerateReport" runat="server" Text="Generate Report" 
                            onclick="BtnGenerateReport_Click" class="button"/> 
                         <asp:Button ID="btnReset" runat="server" Text="Reset List" 
           onclick="btnReset_Click" class="button"/>
                    </td>
    </tr> 
    <asp:GridView ID="gvSPnotAvailableItems" runat="server" AutoGenerateColumns="false"  Width="92%" Float="right" class="gridView">
               <Columns>
                <asp:BoundField HeaderText="Item ID" DataField="ItemID" />
            <asp:BoundField HeaderText="Item Name" DataField="ItemName" />
            
            <asp:BoundField HeaderText="Item Price" DataField="ItemPrice" />
            <asp:BoundField HeaderText="Item Quantity" DataField="ItemQuantity" />
            <asp:BoundField HeaderText="Category Name" DataField="CategoryName" />
            </Columns>
                </asp:GridView>
               
                  
                </table>
                 
                &nbsp;</div>
               
                
</asp:Content>
