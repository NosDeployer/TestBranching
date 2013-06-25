<%@ Page Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" CodeBehind="units_state.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_state" Title="LFS Live" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" Text="Vehicle Information" SkinID="LabelPageTitle1"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="LeftMenuPlaceHolder" runat="server">
    <!-- LEFT MENU -->
    <div style="width: 190px;">
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
                            <telerik:RadMenuItem Value="mActivate" Text="YES, ACTIVATE" />
                            
                            <telerik:RadMenuItem Value="mDispose" Text="YES, DISPOSE" />
                            
                            <telerik:RadMenuItem Value="mArchive" Text="YES, ARCHIVE" />
                            
                            <telerik:RadMenuItem Value="mCancel" Text="CANCEL" />
                        </Items>
                    </telerik:RadMenu>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- TOOLBAR -->
    <div style="width: 750px">
        
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblState" runat="server" SkinID="Label" Text="Are you sure you want change the state of the service request?" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
            </tr>
            <tr>
                <td>                                                                                    
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfActiveTab" runat="server" />
                    <asp:HiddenField ID="hdfUnitId" runat="server" />
                    <asp:HiddenField ID="hdfUnitType" runat="server" />
                    <asp:HiddenField ID="hdfUnitState" runat="server" />
                    <asp:HiddenField ID="hdfNewUnitState" runat="server" />
                    <asp:HiddenField ID="hdfLoginId" runat="server" />
               </td>
            </tr>
        </table>
    </div>

</asp:Content>