<%@ Page Language="C#" MasterPageFile="./../../mReport1.Master" AutoEventWireup="true" CodeBehind="detailed_work_on_hand_report.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Projects.Projects.detailed_work_on_hand_report" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- CONTENT -->
    <div>
        <!-- Page element: Range data 2 columns -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:Label ID="lblCountry" runat="server" Text="Select Country" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlCountry" runat="server" Width="160px" SkinID="DropDownList">
                        <asp:ListItem Value="(All)">(All)</asp:ListItem>
                        <asp:ListItem Value="1">Canada</asp:ListItem>
                        <asp:ListItem Value="2">USA</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 7px;">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCurrency" runat="server" Text="Select Currency" SkinID="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlCurrency" runat="server" Width="160px" SkinID="DropDownList">
                        <asp:ListItem>CAD</asp:ListItem>
                        <asp:ListItem>USD</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>                
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblExchangeRate" runat="server" Text="Exchange (CAD to USD)" SkinID="Label"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxExchangeRate" runat="server" Width="160px" SkinID="TextBox">1.00</asp:TextBox></td>
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="rfvExchangeRate" runat="server" ControlToValidate="tbxExchangeRate"
                        Display="Dynamic" ErrorMessage="Please provide an exchange rate" SkinID="Validator"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvExchangeRate" runat="server" ControlToValidate="tbxExchangeRate"
                        Display="Dynamic" ErrorMessage="Invalid data (use #.## format)" Operator="DataTypeCheck"
                        SkinID="Validator" Type="Currency"></asp:CompareValidator></td>
            </tr>
        </table>
    </div>
    
</asp:Content>

