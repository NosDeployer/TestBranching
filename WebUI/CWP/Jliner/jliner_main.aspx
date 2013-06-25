<%@ Page Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" CodeBehind="jliner_main.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.Jliner.jliner_main" Title="LFS Live" %>


<asp:Content ID="Content3" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="2">
                    <asp:Label ID="Label1" runat="server" Text="Select A Client" SkinID="LabelPageTitle1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 2px">
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td style="text-align: right">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content1" ContentPlaceHolderID="LeftMenuPlaceHolder" runat="server">
    <div style="width: 190px; height: 295px">
    </div>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 750px">
        
        <!-- Page element: Title -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="width: 230px">
                    <asp:Label ID="lblClient" runat="server" SkinID="Label" Text="Client" EnableViewState="False"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlClient" runat="server" SkinID="DropDownList" Width="220px">
                    </asp:DropDownList></td>
                <td>
                    <asp:Button ID="btnSelect" runat="server" OnClick="btnSelect_Click" SkinID="Button"
                        Text="Select" Width="100px" EnableViewState="False" /></td>
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="rfvClient" runat="server" ControlToValidate="ddlClient"
                        EnableViewState="False" ErrorMessage="Please select a client" InitialValue="-1"
                        SkinID="Validator"></asp:RequiredFieldValidator></td>
                <td>
                </td>
            </tr>
        </table>
        
    </div>
</asp:Content>
