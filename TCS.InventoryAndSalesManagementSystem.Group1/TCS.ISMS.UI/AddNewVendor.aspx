<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true"
    CodeBehind="AddNewVendor.aspx.cs" Inherits="TCS.ISMS.UI.AddNewVendor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <!-- // File Summary  : Add Vendor Page
// ---------------------------------------------------------------------------------
// File Summary  : Add Vendor Page
// Date Created  : 24'April'2013
// Author   : Naincy Jain, Tata Consultancy Services
// ---------------------------------------------------------------------------------
// Change History :
// Change Description# : Added Validations  to the add vendor page 
// Changed By  : NAincy Jain
// Date Modified  : 25'April'2013
/////////////////////////////////////////////////////////////////////////////////////////////////		-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="rightContainer" style="width: 70%; height: 70%;">
        <h1 style="text-align: center;">
            Vendor Details</h1>
        <br />
        <table style="width: 70%; height: 70%; float: right;">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
             <tr>
                <td colspan="2">
                    <asp:Label ID="lblMessage2" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblOrganization" runat="server" Text="Name of Organization"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtOrganization" runat="server" MaxLength="30" class="textBox"></asp:TextBox> </td>
                   <td> <asp:RequiredFieldValidator ID="rfvOrganization" runat="server" ControlToValidate="txtOrganization"
                        Display="Dynamic" ErrorMessage="Organization Name cannot be Blank" ForeColor="Red"
                        ValidationGroup="vg1"></asp:RequiredFieldValidator>
                  
                    <asp:RegularExpressionValidator ID="revOrganization" runat="server" ControlToValidate="txtOrganization"
                        Display="Dynamic" ErrorMessage="Invalid Organization Name" ForeColor="Red" ValidationExpression="^[a-zA-Z.\s]{1,20}$"
                        ValidationGroup="vg1"></asp:RegularExpressionValidator></td>
                
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblVendorcategory" runat="server" Text="Item Category"></asp:Label>
                </td>
                <td>
               
               <div style="overflow:scroll; WIDTH:55%; HEIGHT:100px">

                    <asp:CheckBoxList ID="chkVendorItemCategory" runat="server" >
                    </asp:CheckBoxList></div>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblName" runat="server" Text="Name of Contact Person"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtName" runat="server" MaxLength="30" style="height: 22px" 
                        class="textBox"></asp:TextBox> </td>
                    <td><asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                        ErrorMessage="Name cannot be blank" ForeColor="Red" ValidationGroup="vg1" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revName" runat="server" ControlToValidate="txtName"
                        Display="Dynamic" ErrorMessage="Invalid Name" ForeColor="Red" ValidationExpression="^[a-zA-Z.\s]{1,30}$"
                        ValidationGroup="vg1"></asp:RegularExpressionValidator>
                        </td>
                
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" class="textBox"
                         TextMode="MultiLine" MaxLength="100"></asp:TextBox> </td>
                   <td> <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
                        Display="Dynamic" ErrorMessage="Address cannot be Blank" ForeColor="Red" ValidationGroup="vg1"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblState" runat="server" Text="State"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlState" runat="server" OnSelectedIndexChanged="ddlState_SelectedIndexChanged"
                        AutoPostBack="true" class="dropDown">
                        <asp:ListItem Selected="True" Value="-1">-Select-</asp:ListItem>
                        <asp:ListItem Value="0">Chhattisgarh</asp:ListItem>
                        <asp:ListItem Value="1">Maharashtra</asp:ListItem>
                        <asp:ListItem Value="2">Gujrat</asp:ListItem>
                        <asp:ListItem Value="5">Madhya Pradesh</asp:ListItem>
                    </asp:DropDownList>
                    <td><asp:RequiredFieldValidator ID="rfvState" runat="server" ControlToValidate="ddlState"
                        Display="Dynamic" ErrorMessage="Select a State" ForeColor="Red" InitialValue="-1"
                        ValidationGroup="vg1"></asp:RequiredFieldValidator>
                </td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlCity" runat="server" class="dropDown">
                        <asp:ListItem Selected="True" Value="-1" >-Select-</asp:ListItem>
                    </asp:DropDownList>
                    <td><asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="ddlCity"
                        Display="Dynamic" ErrorMessage="Select a City" ForeColor="#FF3300" InitialValue="-1"
                        ValidationGroup="vg1"></asp:RequiredFieldValidator>
                </td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblContact" runat="server" Text="Contact Number"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtContact" runat="server" MaxLength="10" class="textBox"></asp:TextBox>
                   </td>  <td>
                    <asp:RequiredFieldValidator ID="rfvContact" runat="server" ControlToValidate="txtContact"
                        Display="Dynamic" ErrorMessage="Contact Number cannot be Blank" ForeColor="#FF3300"
                        ValidationGroup="vg1"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="revContact" runat="server" ControlToValidate="txtContact"
                        Display="Dynamic" ErrorMessage="Invalid Contact Number" ForeColor="Red" ValidationExpression="[+\d]*"
                        ValidationGroup="vg1"></asp:RegularExpressionValidator>
                       
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEmail" runat="server" Text="Email Address"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" class="textBox" MaxLength="30"></asp:TextBox> </td>
                    <td><asp:RequiredFieldValidator ID="rfvemail" runat="server" ControlToValidate="txtEmail"
                        Display="Dynamic" ErrorMessage="Email Adress cannot be Blank" ForeColor="Red"
                        ValidationGroup="vg1"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Invalid Email Id" 
                        ForeColor="Red" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                        ValidationGroup="vg1"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbltypeVendor" runat="server" Text="Type of Vendor" ></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddlType" runat="server" class="dropDown">
                        <asp:ListItem Value="-1">-Select-</asp:ListItem>
                        <asp:ListItem Value="0">Dealer</asp:ListItem>
                        <asp:ListItem Value="1">WholeSaler</asp:ListItem>
                        <asp:ListItem Value="2">Manufacturer</asp:ListItem>
                        <asp:ListItem Value="3">Retailer</asp:ListItem>
                    </asp:DropDownList> </td>
                    <td><asp:RequiredFieldValidator ID="rfvType" runat="server" ControlToValidate="ddlType"
                        Display="Dynamic" ErrorMessage="Select a Vendor Type" ForeColor="Red" ValidationGroup="vg1"
                        InitialValue="-1" class="dropDown"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnSave" runat="server" Text="Save" ValidationGroup="vg1" OnClick="btnSave_Click" class="button"/>
                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                    <asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnreset_Click" class="button" />
                    &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" class="button" />
                    
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
