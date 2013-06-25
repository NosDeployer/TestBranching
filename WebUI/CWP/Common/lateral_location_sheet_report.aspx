<%@ Page Language="C#" MasterPageFile="./../../mReport1.Master" AutoEventWireup="true" CodeBehind="lateral_location_sheet_report.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.Common.lateral_location_sheet_report" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCurrentClientId" runat="server" />
                    <asp:HiddenField ID="hdfCurrentProjectId" runat="server" />
                    <asp:HiddenField ID="hdfCurrentCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfCurrentAssetId" runat="server" />
                    <asp:HiddenField ID="hdfCurrentWorkId" runat="server" />
                    <asp:HiddenField ID="hdfMeasuredFrom" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

