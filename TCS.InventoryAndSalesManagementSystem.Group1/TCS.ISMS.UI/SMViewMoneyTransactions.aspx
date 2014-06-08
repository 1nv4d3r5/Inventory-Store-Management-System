<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="SMViewMoneyTransactions.aspx.cs" Inherits="TCS.ISMS.UI.SMViewMoneyTransactions" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- // File Summary  : View Money Transaction Page
// ---------------------------------------------------------------------------------
//
// Change History :
// Change Description# : Added grid view to the page
// Changed By          : Suman Pradhan
// Date Modified       : 2 May, 2013
// ---------------------------------------------------------------------------------
//
// Change History :
// Change Description# : Added Ajax Control to the page
// Changed By          : Suman Pradhan
// Date Modified       : 7 May, 2013
// ---------------------------------------------------------------------------------
//
// Change History :
// Change Description# : Added validations to the page
// Changed By          : Suman Pradhan
// Date Modified       : 7 May, 2013
/////////////////////////////////////////////////////////////////////////////////////////////////		-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
        EnableScriptLocalization="true" ID="ScriptManager1" ScriptMode="Debug" CombineScripts="false" />
    <div id="rightContainer" style="width: 70%; height: 70%;">
        <h1 style="text-align: center;">
            View Money Transactions
        </h1>
        <br />
        <table>
            <tr>
                <td>
                    <asp:Label ID="lblDate" runat="server" Text="Select Date"></asp:Label><sup style="color: Red;">*</sup>
                </td>
                <td>
                    <asp:TextBox ID="txtDate" runat="server" AutoPostBack="True" class="textBox" MaxLength="10"></asp:TextBox>
                    <asp:ImageButton runat="Server" ID="imgCalender" ImageUrl="~/images/Calendar_scheduleHS.png"
                        AlternateText="Click to show calendar" />
                    <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="txtDate"
                        Display="Dynamic" ErrorMessage="Date cannot be blank" ForeColor="Red" ValidationGroup="validationInputs"></asp:RequiredFieldValidator>
                    <br />
                    <ajaxToolkit:CalendarExtender ID="calendarMoney" runat="server" TargetControlID="txtDate"
                        PopupButtonID="imgCalender" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnViewMoneyTransaction" runat="server" Text="Submit" OnClick="btnViewMoneyTransaction_Click"
                        class="button" ValidationGroup="validationInputs" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"
                        class="button" />
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <td>
                    <asp:GridView ID="gvShowBillDetails" runat="server" AutoGenerateColumns="false"
                        class="gridView"  AllowPaging="true" PagerSettings-Mode="Numeric" 
        PageButtonCount="3"  PageSize="10" 
        OnPageIndexChanging="gvShowBillDetails_PageIndexChanging" >
                        <Columns>
                            <asp:BoundField HeaderText="Bill Number" DataField="BillNo" />
                            <asp:BoundField HeaderText="Amount Received" DataField="AmountReceived" />
                            <asp:BoundField HeaderText="Amount Returned" DataField="AmountReturned" />
                            <asp:BoundField HeaderText="Total Amount" DataField="TotalPrice" />
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLineTotal" runat="server" Text="Line Total:"></asp:Label>
                    <b>
                        <asp:Label ID="lbllinetotals" runat="server" BorderStyle="None"></asp:Label></b>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblNumberBills" runat="server" Text="Number of Bills Generated:"></asp:Label>
                    <b>
                        <asp:Label ID="lblnumberbill" runat="server"></asp:Label></b>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
