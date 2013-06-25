<%@ Page Title="LFS Live" Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" CodeBehind="timesheet_state.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.timesheet_state" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" Text="Approve Project Times" SkinID="LabelPageTitle1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 2px">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

    
<asp:Content ID="Content2" ContentPlaceHolderID="LeftMenuPlaceHolder" runat="server">
    <div style="width: 200px">
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
                            <telerik:RadMenuItem Value="mApprove" Text="YES, APPROVE" />
                            
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
    <div style="width: 750px">
        <!-- Page element : Action -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td >
                    <asp:Label ID="lblDelete" runat="server" SkinID="Label" Text="Are you sure you want to approve project times?" EnableViewState="False"></asp:Label>
                </td>
            </tr>
        </table>
            
        <!-- Page element : Footer separation -->
        <table id="Table1" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%" >
            <tr>
                <td style="height: 60px">
                </td>
            </tr>
        </table>                        
    </div>
</asp:Content>