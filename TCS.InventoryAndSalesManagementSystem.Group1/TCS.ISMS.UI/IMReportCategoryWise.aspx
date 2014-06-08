<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="IMReportCategoryWise.aspx.cs" Inherits="TCS.ISMS.UI.IMReportCategoryWise" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <div id = "main" style = "width : 70%;height : 70%; float : left; ">
<h1>
View Report Category Wise
</h1>
<br /><br />
<asp:GridView ID="gvReportCategoryWise" runat="server" AutoGenerateColumns="false" class = "gridView" AllowPaging="true" PageSize="10" PagerSettings-Mode="Numeric" 
 PageButtonCount="3" OnPageIndexChanging="gvReportCategoryWise_PageIndexChanging"   >
        <Columns>
            <asp:BoundField HeaderText="Category" DataField="CategoryName" />
            <asp:BoundField HeaderText="Total Availability(Item Count)" DataField="TotalAvailableItems" />
        </Columns>
    </asp:GridView>
   
</div>
</asp:Content>
