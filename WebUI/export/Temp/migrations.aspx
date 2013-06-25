<%@ Page Language="C#" MasterPageFile="./../../mWizard2.Master" AutoEventWireup="true" CodeBehind="migrations.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.migrations" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 700px; height: 1024px;">

        <table border="0" cellpadding="0" cellspacing="0" width="700">
            <tr>
                <td style=" Width:100px;">
                    <asp:Button ID="btnJlDataMigration" runat="server" Height="22px" SkinID="Button" Text="JL Migration" Width="90px" EnableViewState="false" OnClientClick="return BtnJlDataMigrationClick();"/>
                </td>
                <td>
                    <asp:Label SkinID="Label" ID="lblJlDataMigration" runat="server" Text="Press JL Migration Button to migrate JL Data">
                    </asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>