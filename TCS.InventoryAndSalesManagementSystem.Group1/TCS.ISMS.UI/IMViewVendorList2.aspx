

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IMViewVendorList2.aspx.cs" Inherits="TCS.ISMS.UI.IMViewVendorList2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
<!--//File Description	: This page is for Viewing a Vendor Details
// ---------------------------------------------------------------------------------
//  Date Created    : April 25, 2013
//  Author          : Amit Nadkarni, Tata Consultancy Services
//
//-->

    <style type="text/css">
        .style1
        {
            width: 159px;
        }
        .style2
        {
            width: 192px;
        }
    </style>.
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:GridView ID="gvVendorDetailList" runat="server" AutoGenerateColumns="false" 
        Width="76%" AllowPaging="true" PagerSettings-Mode="Numeric" 
        PageButtonCount="3"  PageSize="4" 
        OnPageIndexChanging="gvVendorDetailList_PageIndexChanging">
       
        <Columns>
        <asp:TemplateField HeaderText="Select" >
                <ItemTemplate>
                    <asp:CheckBox ID="chkVendorID" name="chkVendorID" runat="server" value='<%#Eval("VendorId") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Vendor ID" DataField="VendorId" />
            <asp:BoundField HeaderText="Name Of Organization" DataField="NameOfOrganisation" />
        
            <asp:BoundField HeaderText="Name Of Contact Person" DataField="NameOfContactPerson" />
            <asp:BoundField HeaderText="Vendor Address" DataField="Address" />
            <asp:BoundField HeaderText="City" DataField="City" />
            <asp:BoundField HeaderText="State/Province" DataField="State" />
            <asp:BoundField HeaderText="Contact Number" DataField="ContactNumber" />
            <asp:BoundField HeaderText="Vendor Type" DataField="VendorType" />
        </Columns>
    </asp:GridView>
    <table>
    <tr>
    <td>
    <asp:Button ID="btnAddVendor" runat="server" Text="Add Vendor" 
            onclick="btnAddVendor_Click" />
    </td>
    <td>
    <asp:Button ID="btnUpdateVendor" runat="server" Text="Update Vendor" 
            onclick="btnUpdateVendor_Click" ValidationGroup="validation" />
    </td>
    <td class="style2">
     <asp:Button ID="btndelVendor" runat="server" Text="Delete Vendor" 
            onclick="btndelVendor_Click" />
     <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
            onclick="btnCancel_Click" />
    </td>
    
    <td class="style1">
        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="red" 
            Visible="true"></asp:Label>
    </td>
    </tr>
    </table>
</asp:Content>
