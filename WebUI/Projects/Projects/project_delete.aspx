<%@ Page Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" Codebehind="project_delete.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Projects.Projects.project_delete" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblHeaderTitle" runat="server" Text="Project" SkinID="LabelPageTitle1" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="height: 2px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTitleClientName" runat="server" Text="Client:" SkinID="LabelPageTitle2"></asp:Label>
                    <asp:Label ID="lblTitleProject" runat="server" Text="Project:" SkinID="LabelPageTitle2" EnableViewState="False"></asp:Label>
                    <asp:Label ID="lblTitleProjectName" runat="server" Text="> Project: Town Of Markham (01KV456782)" SkinID="LabelPageTitle2"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content> 



<asp:Content ID="Content2" ContentPlaceHolderID="LeftMenuPlaceHolder" runat="server">
    <div style="width: 190px">
    </div>
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarPlaceHolder" runat="server">
    <!-- TOOLBAR -->
    <div style="width: 750px">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick">                        
                        <Items>
                            <telerik:RadMenuItem Value="mDelete" Text="YES, DELETE" />
                            
                            <telerik:RadMenuItem Value="mCancel" Text="CANCEL" />
                        </Items>
                    </telerik:RadMenu>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 750px;">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblDelete" runat="server" Text="Are you sure you want to delete this project?"
                    SkinID="Label" EnableViewState="False"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:CustomValidator ID="cvDelete" runat="server" Display="Dynamic" ErrorMessage="ErrorMessage"
                        SkinID="Validator" EnableViewState="False"></asp:CustomValidator></td>
            </tr>
        </table>
        <!-- Page element : Footer separation -->
        <table id="Table1" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%" >
            <tr>
                <td style="height: 60px">
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hdfProjectId" runat="server" />
        <asp:HiddenField ID="hdfCompanyId" runat="server" />
    </div>
</asp:Content>
