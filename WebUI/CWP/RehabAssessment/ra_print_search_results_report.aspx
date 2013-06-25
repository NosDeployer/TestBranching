<%@ Page Language="C#" MasterPageFile="./../../mReport1.Master" AutoEventWireup="true" CodeBehind="ra_print_search_results_report.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.RehabAssessment.ra_print_search_results_report" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfCurrentClientId" runat="server" />
                </td>
            </tr>
        </table>
</asp:Content>


