<%@ Page Title="LFS Live" Language="C#" MasterPageFile="./../../mReport1.Master" AutoEventWireup="true" CodeBehind="project_costing_sheets_preview.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Projects.Projects.project_costing_sheets_preview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfCostingSheetId" runat="server" />
                    <asp:HiddenField ID="hdfType" runat="server" />                    
                </td>
            </tr>
        </table>
</asp:Content>