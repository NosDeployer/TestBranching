<%@ Page Title="LFS Live" Language="C#" MasterPageFile="./../../mReport1.Master" AutoEventWireup="true" CodeBehind="jl_lateral_location_sheet_report.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.Common.jl_lateral_location_sheet_report" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCurrentClientId" runat="server" />
                    <asp:HiddenField ID="hdfCurrentProjectId" runat="server" />
                    <asp:HiddenField ID="hdfCurrentCompanyId" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>