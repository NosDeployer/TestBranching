<%@ Page Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" CodeBehind="checklist_rules_summary.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.ChecklistRules.checklist_rules_summary" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" Text="Checklist Rule Information" SkinID="LabelPageTitle1"></asp:Label>
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
    <div style="width: 190px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadPanelBar ID="tkrpbLeftMenu" runat="server" SkinID="RadPanelBar" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Checklist Rules" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddChecklistRule" Text="Add Checklist Rule"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSearch" Text="Search" ></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mCategories" Text="Categories" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mCompanyLevels" Text="Company Levels" ></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>
        </table>
    </div>                        
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ToolbarPlaceHolder" runat="server">
    <!-- TOOLBAR-->
    <div style="width: 750px">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick">                        
                        <Items>
                            <telerik:RadMenuItem Value="mEdit" Text="EDIT" />
                            
                            <telerik:RadMenuItem Value="mDelete" Text="DELETE" />
                            
                            <telerik:RadMenuItem Value="mLastSearch" Text="NAVIGATOR" />
                        </Items>                        
                    </telerik:RadMenu>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div style="width: 750px">        
    
        <!-- Table element: 1 columns - Checklist Rule Details Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblChecklistRuleDetails" runat="server" SkinID="LabelTitle1" Text="Checklist Rule Details" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 6 columns - Checklist Rule Details Title -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 125px"></td>
                <td style="width: 125px"></td>
                <td style="width: 125px"></td>
                <td style="width: 125px"></td>
                <td style="width: 125px"></td>
                <td style="width: 125px"></td>                
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblName" runat="server" EnableViewState="False" Text="Name" SkinID="Label"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:Label runat="server" ID="lblMtoDot" SkinID="Label" Text="Government Rule (Fixed Date)"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                </td>               
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox id="tbxName" runat="server" SkinID="TextBoxReadOnly" Width="240px" ReadOnly="True" EnableViewState="False"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:CheckBox ID="cbxMtoDot" runat="server" onclick="return cbxClick();" SkinID="CheckBox" />
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="height: 7px" colspan="6">
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Label ID="lblDescription" runat="server" EnableViewState="False" SkinID="Label" Text="Description"></asp:Label>
                </td>                
            </tr>
            <tr>
                <td colspan="6" rowspan="4">
                    <asp:TextBox ID="tbxDescription" runat="server" Height="61px" ReadOnly="True" SkinID="TextBoxReadOnly" TextMode="MultiLine" Width="740px" EnableViewState="False"></asp:TextBox>
                </td>                
            </tr>
        </table>
        
        <!-- Page element : Horizontal Rule -->
        <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
            <tr>
                <td style="height: 30px">
                </td>
            </tr>
            <tr>
                <td style="height: 2px" class="Background_Separator">
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 1 columns - Checklist Rule Details 2 Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblSchedulingOptions" runat="server" SkinID="LabelTitle1" Text="Scheduling Options" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 6 columns - Checklist Rule Details 2 -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 125px">
                    <asp:Label runat="server" ID="lblFrequency" SkinID="Label" Text="Frequency"></asp:Label>
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox id="tbxFrecuency" runat="server" SkinID="TextBoxReadOnly" Width="240px" ReadOnly="True" EnableViewState="False"></asp:TextBox>
                </td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td style="height: 7px" colspan="6">
                </td>
            </tr>            
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblGenerateServiceRequest" Text="Generate Service Request?" runat="server" SkinID="Label"></asp:Label>
                </td>
                <td>
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
                    <table>
                        <tr>
                            <td>
                                <asp:TextBox runat="server" ID="tbxServicesRequestDaysBefore" SkinID="TextBoxReadOnly" ReadOnly="true" Width="40px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label runat="server" ID="lblServicesRequestDaysBefore" SkinID="Label" Text="days before"></asp:Label>
                            </td>
                        </tr>
                    </table>                                            
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>        
        </table>
        
        <!-- Page element : Horizontal Rule -->
        <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
            <tr>
                <td style="height: 30px">
                </td>
            </tr>
            <tr>
                <td style="height: 2px" class="Background_Separator">
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 1 columns - Checklist Rule Details 3 Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblApplied" runat="server" SkinID="LabelTitle1" Text="Applied Options" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 6 columns - Checklist Rule Details 3 -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 125px">
                    <asp:Label runat="server" ID="lblCategory" SkinID="Label" Text="Category"></asp:Label>
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                    <asp:Label runat="server" ID="lblCompanyLevel" SkinID="Label" Text="Working Location"></asp:Label>
                </td>
                <td style="width: 125px">
                </td>
                <td style="width: 125px">
                </td>
            </tr>            
            <tr>
                <td colspan="3">
                    <asp:Panel ID="pnlCategories" Width="365px" Height="300px" runat="server" SkinID="PanelReadOnly">
                        <asp:TreeView ID="tvCategoriesRoot" runat="server" SkinID="SimpleTreeView" onclick="return cbxTreeViewClick(event);">
                        </asp:TreeView>
                    </asp:Panel>
                </td>
                <td colspan="3">
                    <asp:Panel ID="pnlCompanyLevels" Width="365px" Height="300px" runat="server" SkinID="PanelReadOnly">
                        <asp:TreeView ID="tvCompanyLevelsRoot" runat="server" SkinID="SimpleTreeView" onclick="return cbxTreeViewClick(event);">                                                    
                        </asp:TreeView>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td colspan="6" style="height: 7px">
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Label runat="server" ID="lblUnits" SkinID="Label" Text="Units"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Panel ID="pnlUnits" runat="server"  SkinID="Panel" Width="365px" Height="265px">
                        <asp:CheckBoxList ID="cbxlUnitsSelected" runat="server" onclick="return cbxClick();" SkinID="CheckBoxListWithoutBorder" >
                        </asp:CheckBoxList>
                    </asp:Panel>
                </td>
                <td colspan="3">
                </td>
            </tr>
            <tr>
                <td colspan="6">
                    <asp:Label runat="server" ID="lblTotalUnits" SkinID="Label" Text="Units"></asp:Label>
                </td>                                     
            </tr>
        </table>
                   
        <!-- Page element : Footer separation -->
        <table id="Table1" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="height: 60px">
                </td>
            </tr>
        </table>     
        
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfRuleId" runat="server" />
                </td>
            </tr>
        </table>
           
    </div>
</asp:Content>