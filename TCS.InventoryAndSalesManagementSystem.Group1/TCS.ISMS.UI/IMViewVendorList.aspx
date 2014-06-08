<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IMViewVendorList.aspx.cs" Inherits="TCS.ISMS.UI.IMViewVendorList" %>

<script runat="server">

    protected void gvVendorDetailList_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
</script>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h3 align="center">View Vendor Details</h3>
<asp:GridView ID="gvVendorDetailList" runat="server" AutoGenerateColumns="false" 
        Width="76%" 
        onselectedindexchanged="gvVendorDetailList_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Vendor ID" DataField="VendorID" />
            <asp:BoundField HeaderText="Name Of Organization" DataField="NameOfOrganization" />
            <asp:BoundField HeaderText="Item Category" DataField="ItemCategory" />
            <asp:BoundField HeaderText="Name Of Contact Person" DataField="NameOfContactPerson" />
            <asp:BoundField HeaderText="Vendor Address" DataField="VendorAddress" />
            <asp:BoundField HeaderText="City" DataField="City" />
            <asp:BoundField HeaderText="State/Province" DataField="State" />
            <asp:BoundField HeaderText="Contact Number" DataField="ContactNumber" />
            <asp:BoundField HeaderText="Vendor Type" DataField="VendorType" />
        </Columns>
    </asp:GridView>

</asp:Content>
