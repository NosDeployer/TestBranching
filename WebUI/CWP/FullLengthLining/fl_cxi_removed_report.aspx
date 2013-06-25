<%@ Page Language="C#" MasterPageFile="./../../mReport1.Master" AutoEventWireup="true" CodeBehind="fl_cxi_removed_report.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.FullLengthLining.fl_cxi_removed_report" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
        <tr>
            <td>
                <asp:Label ID="lblCountry" runat="server" Text="Country" SkinID="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:dropdownlist id="ddlCountry" SkinID="DropDownList" tabIndex="1" runat="server" Width="160px">
                    <asp:ListItem Value="(All)">(All)</asp:ListItem>    
                    <asp:ListItem Value="2">USA</asp:ListItem>    
                    <asp:ListItem Value="1">Canada</asp:ListItem> 
	            </asp:dropdownlist>
            </td>
        </tr>
    </table>
    
    <!-- Page element : Tag page -->
    <div>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />                    
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
