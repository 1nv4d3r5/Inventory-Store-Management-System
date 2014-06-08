<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IMCheckStatus.aspx.cs" Inherits="TCS.ISMS.UI.IMCheckStatus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
 <!-- // File Summary  : Check Status Page
// ---------------------------------------------------------------------------------
//
// Change History :
// Change Description# : Added Gridview to the page 
// Changed By          : Suman Pradhan
// Date Modified       : 1 May, 2013
//-----------------------------------------------------------------------------------
// Change History :
// Change Description# : Added Validations  to the check status page 
// Changed By          : Suman Pradhan
// Date Modified       : 7 May, 2013
/////////////////////////////////////////////////////////////////////////////////////////////////		-->	
</asp:Content>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<!--<ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" ID="ScriptManager1" ScriptMode="Debug" CombineScripts="false" />-->
<div id = "rightContainer" style = " width : 70%; height : 70%;">
<h1 style = "text-align : center;">Check Status Of Items In Inventory</h1>
<table style = "width : 70%; height : 70%; float:right">
<tr>
<td >
<asp:Label ID="lblItemName" runat="server" Text="Item Category"></asp:Label>
  </td>
  <td >
   <asp:DropDownList ID="ddlCategory" runat="server" Height="29px" Width="188px" 
             AutoPostBack="true" AppendDataBoundItems="true" class="dropDown">
              <asp:ListItem Text="---Select---" Value="0"></asp:ListItem></asp:DropDownList>
                       <asp:RequiredFieldValidator ID="rfvCategory" runat="server" 
                        ControlToValidate="ddlCategory" Display="Dynamic" 
                        ErrorMessage="Item category cannot be Blank" ForeColor="Red" 
          InitialValue="0" ValidationGroup="validationInputs" 
                        ></asp:RequiredFieldValidator>
               
  </td>
</tr>
<tr>
<td colspan="4">
<asp:Button ID="btnCheckStatus" runat="server" Text="Check Status" 
        onclick="btnCheckStatus_Click" ValidationGroup="validationInputs" class="button"/>
<asp:Button ID="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click" class="button" />
   
</td>
</tr>
<tr><td>
<!--<ajaxToolkit:Accordion
    ID="MyAccordion"
    runat="Server"
    SelectedIndex="0"
    HeaderCssClass="accordionHeader"
    HeaderSelectedCssClass="accordionHeaderSelected"
    ContentCssClass="accordionContent"
    AutoSize="None"
    FadeTransitions="true"
    TransitionDuration="250"
    FramesPerSecond="40"
    RequireOpenedPane="false"
    SuppressHeaderPostbacks="true">          
    <HeaderTemplate>...</HeaderTemplate>
    <ContentTemplate>...</ContentTemplate>
</ajaxToolkit:Accordion>-->
            <asp:GridView ID="showItemList" runat="server" AutoGenerateColumns="false" 
                    Width="140%" class="gridView">
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
<!--<table width="100%" border="2">
<tr> <td>Item ID </td><td>Item Name </td><td> Item Category</td><td>Item Quantity </td><td>Item Price </td></tr>
<tr> <td>100 </td><td>Colgate </td><td> ToothPaste</td><td>4 </td><td>50 </td></tr>
<tr> <td>101</td><td>Pepsodent </td><td> ToothPaste</td><td>5 </td><td>60 </td></tr>
</table>-->
</asp:Content>
