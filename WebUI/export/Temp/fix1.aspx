<%@ Page Language="C#" MasterPageFile="../../mWizard.Master" AutoEventWireup="true" CodeBehind="fix1.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.fix1" Title="Fix1" Theme="Standard" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 700px; height: 1024px;">

        <table border="0" cellpadding="0" cellspacing="0" width="700">
            <tr>
                <td style=" width:100px; ">
                    <asp:Button ID="btnPreview" runat="server" Height="22px" OnClick="btnPreview_Click"
                        SkinID="DialogButton" Text="Fix Sections" Width="90px" 
                        EnableViewState="False" />
                </td>
                <td>
                    <asp:Label SkinID="Label" ID="lblPreview" runat="server" Text="Press Fix Sections Button to update LFS_MASTER_AREA table (NotLinedYed, AllMeasured, NumLats, IssueWithLaterals, NotMeasuredYet, NotDeliveredYet columns)">
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height:7px;"> 
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style=" Width:100px;">
                    <asp:Button ID="btnFixCommentsAndHistory" runat="server" Height="22px" 
                        SkinID="DialogButton" Text="Fix Laterals" Width="90px" EnableViewState="false" 
                        OnClick="btnFixCommentsAndHistory_Click" />
                </td>
                <td>
                    <asp:Label SkinID="Label" ID="lblFixCommentsAndHistory" runat="server" Text="Press Fix Laterals Button to update LFS_JUNCTION_LINER2 table (Comments and History columns)">
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height:7px;"> 
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style=" Width:100px;">
                    <asp:Button ID="btnDataMigration" runat="server" Height="22px" 
                        SkinID="DialogButton" Text="Migration" Width="90px" EnableViewState="false" 
                        OnClientClick="return BtnDataMigrationClick();"/>
                </td>
                <td>
                    <asp:Label SkinID="Label" ID="lblDataMigrations" runat="server" Text="Press Migration Button to migrate sections">
                    </asp:Label>
                </td>
            </tr>
            <tr>
                <td style=" Width:100px;">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style=" Width:100px;">
                    <asp:Button ID="btnAvailableToLine" runat="server" Height="22px" 
                        SkinID="DialogButton" Text="AvailableToLine" Width="90px" EnableViewState="false" 
                        OnClick="btnAvailableToLine_Click" />                      
                </td>
                <td>
                    <asp:Label SkinID="Label" ID="lblAvailableToLine" runat="server" 
                        Text="Fix Available to line for jl laterals/eSewers Junction Lining"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>