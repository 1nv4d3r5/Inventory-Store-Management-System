<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SPCancelBill.aspx.cs" Inherits="TCS.ISMS.UI.SPCancelBill" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
  <!-- // File Summary  : Cancel Bill Page
 // ---------------------------------------------------------------------------------
//	Date Created		:2 May, 2013
//	Author			    :Susmita Rana, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// Change History :
// Change Description# : Added Gridview and validations to the Cancel Bill page
// Changed By          : Susmita Rana
// Date Modified       : 2 May, 2013
//----------------------------------------------------------------------------------
// Change History :
// Change Description# : Added Remark Textbox in the Cancel Bill page 
// Changed By          : Susmita Rana
// Date Modified       : 6 May, 2013
//
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
        <strong><u>CANCEL BILL</u></strong></h1>
    <br />
    <p style = "color : Red; float : left;" > * indicates mandatory</p>
<br />

<table style="height: 70%; width: 70%; float:right">
<tr><td>
    <asp:Label ID="lblMessage" runat="server" class="label"
        ForeColor="#009900" Width="180px"></asp:Label></td></tr>
<tr><td><asp:Label ID="lblErrorMessage" runat="server" class="errorMessages" ForeColor="Red"></asp:Label></td>
</tr>
<tr>
<td valign ="top" class="style1">
    <asp:Label ID="lblBillNumber" runat="server" class="label" Text="Select Bill Number:"></asp:Label><sup style = "color : Red;">*</sup>
</td>
<td>
    <asp:TextBox ID="txtBillNumber" runat="server" class="textBox" MaxLength="4" 
        Height="23px"></asp:TextBox>
   </td>
<td>
    <asp:Button ID="btnSearch" Text="SEARCH" runat="server" class="button" 
        onclick="btnSearch_Click" ValidationGroup="validateInput" />
</td></tr>
<tr><td></td><td><asp:RequiredFieldValidator ID="rfvBillNumber" runat="server" class="errorMessages"
        ControlToValidate="txtBillNumber" Display="Dynamic" 
        ErrorMessage="Bill number cannot be blank" ForeColor="Red" 
        ValidationGroup="validateInput"></asp:RequiredFieldValidator>
   </td></tr>
   <tr><td></td><td> <asp:RegularExpressionValidator ID="revBillNumber" runat="server" class="errorMessages"
        ControlToValidate="txtBillNumber" Display="Dynamic" 
        ErrorMessage="Characters are not allowed" ForeColor="Red" 
        ValidationExpression="^\d+$" ValidationGroup="validateInput"></asp:RegularExpressionValidator>
</td></tr>
<tr><td></td><td>
<asp:RangeValidator ID="RangeValidator1" runat="server" class="errorMessages"
        ErrorMessage="Invalid Bill Number" ControlToValidate="txtBillNumber" 
        Display="Dynamic" ForeColor="Red" MaximumValue="3000" MinimumValue="1000" 
        ValidationGroup="validateInputs"></asp:RangeValidator>
</td>
</tr>
<tr><td class="style1" style="height:30px">
                <asp:GridView ID="gvShowBillList" runat="server" class="gridView" AutoGenerateColumns="false" Float="right"
                    Width="160%">
               <Columns>
                <asp:BoundField HeaderText="Bill Number" DataField="BillNumber" />
                <asp:BoundField HeaderText="Employee ID" DataField="EmployeeID" />
                <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" />
                <asp:BoundField HeaderText="Bill Date" DataField="BillDate" />
                <asp:BoundField HeaderText="Total Bill Amount" DataField="TotalBillAmount" />
                <asp:TemplateField HeaderText="Remark" >
                <ItemTemplate>
                    <asp:TextBox ID="txtRemark" name="txtRemark" runat="server" /><tr><td></td><td></td><td></td><td></td><td></td><td>
                    <asp:RequiredFieldValidator ID="rfvRemark" runat="server" class="errorMessages" ErrorMessage="Remark cannot be blank" ValidationGroup="validateInput" Display="Dynamic" ControlToValidate="txtRemark" ForeColor="Red"></asp:RequiredFieldValidator>
                </td></tr>
                </ItemTemplate>
            </asp:TemplateField>
                </Columns>
                </asp:GridView>
 </td></tr>
   <tr>
      <td align="center">
      <asp:Button ID="btnCancel" Text="CANCEL BILL" runat="server" class="button"
              onclick="btnCancel_Click" ValidationGroup="validateInput" 
              Visible="False" />
     </td>
     <td>
      <asp:Button ID="btnReset" Text="RESET" runat="server" class="button" 
             onclick="btnReset_Click" Visible="False" />
      </td>
  </tr>

</table>
</div>        

</asp:Content>
