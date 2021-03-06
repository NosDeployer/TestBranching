﻿<%@ Page Language="C#" MasterPageFile="../../mForm6.master" AutoEventWireup="true" Codebehind="subcontractor_hours_summary.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.subcontractor_hours_summary" Title="LFS Live" %>
    
<asp:Content ID="Content4" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" SkinID="LabelPageTitle1" Text="Subcontractor Hours Summary" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 2px">
                </td>
            </tr>            
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content1" ContentPlaceHolderID="LeftMenuPlaceHolder" runat="server">
    <!-- LEFT MENU -->
    <div style="width: 190px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadPanelBar ID="tkrpbLeftMenuMyTimesheets" runat="server" SkinID="RadPanelBar" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Subcontractor Hours" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddHoursBySubcontractor" Text="Add Hours by Subcontractor"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mAddHoursByClientProject" Text="Add Hours by Client and Project"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSearch" Text="Search"></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>                        
            <tr>
                <td style="height: 15px">
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadPanelBar id="tkrpbLeftMenuTools" runat="server" SkinID="RadPanelBar2" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Tools" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddSubcontractors" Text="Add Subcontractors" ></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>
            <tr>
                <td style="height: 15px">
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadPanelBar id="tkrpbLeftMenuReports" runat="server" SkinID="RadPanelBar2" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="False" Text="Reports" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mSubcontractorHoursReport" Text="Print Subcontractor Hours" ></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>                      
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>
        </table>
    </div>   
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ToolbarPlaceHolder" runat="server">
    <!-- TOOLBAR -->
    <div style="width: 750px">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick">                        
                        <Items>
                            <telerik:RadMenuItem Value="mEdit" Text="EDIT" />
                                                       
                            <telerik:RadMenuItem Value="mDelete" Text="DELETE" />
                        </Items>                        
                    </telerik:RadMenu>
                </td>
                <td align="right">
                    <telerik:RadMenu ID="tkrmTopNavigation" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick" style="float:right !important;" >                       
                        <Items>
                            <telerik:RadMenuItem Value="mPrevious" Text="PREVIOUS" ToolTip="Previous record" />    
                                                    
                            <telerik:RadMenuItem Value="mNext" Text="NEXT" ToolTip="Next record" />
                            
                            <telerik:RadMenuItem Value="mLastSearch" Text="LAST SEARCH" />
                        </Items>
                    </telerik:RadMenu>
                </td>
                <td style=" width:10px;">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 750px">
        <!-- Page element: 4 columns -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="width: 187px;">
                    <asp:Label ID="lblSubcontractro" runat="server" SkinID="Label" Text="Subcontractor" EnableViewState="False"></asp:Label>
                </td>
                <td style="width: 187px;">
                </td>
                <td style="width: 187px;">
                </td>
                <td style="width: 187px;">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="tbxSubcontractor" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Width="365px" EnableViewState="False"></asp:TextBox>
                </td>
                <td>
                </td>
                <td>
                    <asp:TextBox ID="tbxState" runat="server" ReadOnly="true" SkinID="TextBoxSpecialWhite" Width="175px" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblClient" runat="server" SkinID="Label" Text="Client" EnableViewState="False"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:Label ID="lblProject" runat="server" SkinID="Label" Text="Project" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="tbxClient" runat="server" SkinID="TextBoxReadOnly" Text='' Width="365px"
                        ReadOnly="True" EnableViewState="False"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="tbxProject" runat="server" SkinID="TextBoxReadOnly" Text='' Width="365px"
                        ReadOnly="True" EnableViewState="False"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDate" runat="server" EnableViewState="False" SkinID="Label" Text="Date"></asp:Label></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxDate" runat="server" SkinID="TextBoxReadOnly" 
                        Width="177px" ReadOnly="True" EnableViewState="False"></asp:TextBox></td>                
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblQuantity" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Quantity"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblRate" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Rate"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTotal" runat="server" EnableViewState="False" SkinID="Label" Text="Total"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxQuantity" runat="server" SkinID="TextBoxReadOnly"
                        Width="177px" ReadOnly="True" EnableViewState="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxRate" runat="server" SkinID="TextBoxReadOnly"
                        Width="177px" ReadOnly="True" EnableViewState="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxTotal" runat="server" SkinID="TextBoxReadOnly"
                        Width="177px" ReadOnly="True" EnableViewState="False"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>            
            <tr>
                <td style="height: 7px">
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:Label ID="lblComments" runat="server" SkinID="Label" Text="Comments" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:TextBox ID="tbxComments" runat="server" Height="65px" 
                        SkinID="TextBoxReadOnly" TextMode="MultiLine" Width="740px" ReadOnly="True" EnableViewState="False"></asp:TextBox>
                </td>
            </tr>
        </table>
        
        <!-- Page element : Hidden values -->
        <table>
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />                    
                    <asp:HiddenField ID="hdfRefId" runat="server" />
                    <asp:HiddenField ID="hdfProjectId" runat="server" />
                </td>
            </tr>
        </table>
        
        <!-- Page element : Footer separation -->
        <table  runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%" >
            <tr>
                <td style="height: 60px">
                </td>
            </tr>
        </table>

    </div>
</asp:Content>