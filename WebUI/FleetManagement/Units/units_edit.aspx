<%@ Page Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" CodeBehind="units_edit.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_edit" Title="LFS Live" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    
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
    <div style="width: 190px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadPanelBar ID="tkrpbLeftMenuUnits" runat="server" SkinID="RadPanelBar" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Units" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddUnit" Text="Add Unit"></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mUnitsInformationReport" Text="Units Information Report" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mUnitsChecklistReport" Text="Units Checklists Report" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mUnitsWithAlarmsReport" Text="Units With Alarms Report" ></telerik:RadPanelItem>
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
                            <telerik:RadMenuItem Value="mSave" Text="SAVE" ToolTip="save and close" />
                            
                            <telerik:RadMenuItem Value="mApply" Text="APPLY" ToolTip="save and continue" />
                            
                            <telerik:RadMenuItem Value="mCancel" Text="CANCEL" ToolTip="close without saving" />
                        </Items>
                    </telerik:RadMenu>
                </td>
                <td align="right">
                    <telerik:RadMenu ID="tkrmTopNavigation" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick" style="float:right !important;">  
                        <Items>
                            <telerik:RadMenuItem Value="mPrevious" Text="PREVIOUS" ToolTip="Previous record" />
                            
                            <telerik:RadMenuItem Value="mNext" Text="NEXT" ToolTip="Next record" />
                        </Items>
                    </telerik:RadMenu>
                </td>
                <td style=" width:10px;">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <div style="width: 750px">
        
        <!-- Table element: 1 columns - Section Details Title -->
       <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblBasicInformation" runat="server" SkinID="LabelTitle1" Text="Basic Information"
                        EnableViewState="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 4 columns - Unit Details -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 185px"></td>
                <td style="width: 185px"></td>
                <td style="width: 185px"></td>
                <td style="width: 185px">
                    <asp:TextBox ID="tbxUnitState" runat="server" EnableViewState="True" ReadOnly="True" SkinID="TextBoxSpecialWhite" Style="width: 175px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 7px"></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCode" runat="server" EnableViewState="True" SkinID="Label" Text="Code"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDescription" runat="server" EnableViewState="True" SkinID="Label" Text="Description"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <asp:Label ID="lblVinSn" runat="server" EnableViewState="True" SkinID="Label" Text="VIN/SN"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxCode" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 175px"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="tbxDescription" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 360px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxVinSn" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 175px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="tbxCode"
                        Display="Dynamic" ErrorMessage="Please provide a code." SkinID="Validator" EnableViewState="True" ValidationGroup="general">
                    </asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvCode" runat="server" ControlToValidate="tbxCode" Display="Dynamic"
                        EnableViewState="False" ErrorMessage="Code for the unit is already in use. Please provide other code." 
                        OnServerValidate="cvCode_ServerValidate" SkinID="Validator" ValidationGroup="general">
                    </asp:CustomValidator>
                </td>
                <td colspan="2">
                    <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="tbxDescription"
                        Display="Dynamic" ErrorMessage="Please provide a description." SkinID="Validator"
                        ValidationGroup="general" EnableViewState="False">
                    </asp:RequiredFieldValidator>
                </td>                                       
                <td></td>
            </tr>          
            <tr>
                <td style="height: 7px"></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblManufacturer" SkinID="Label" Text="Manufacturer"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblModel" SkinID="Label" Text="Model"></asp:Label>
                </td>
                <td>
                    <asp:Label runat="server" ID="lblYear" SkinID="Label" Text="Year"></asp:Label>                                            
                </td>
                <td>
                    <asp:Label runat="server" ID="lblIsTowable" SkinID="Label" Text="Is Towable?"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxManufacturer" runat="server" SkinID="TextBox" Style="width: 175px" Autocomplete="Off"></asp:TextBox>                    
                    <cc1:AutoCompleteExtender ID="aceManufacturer" runat="server" SkinID="AutoCompleteExtender" TargetControlID="tbxManufacturer" ServicePath="./wsUnits.asmx" ServiceMethod="GetManufacturerList" MinimumPrefixLength="2" CompletionSetCount="12" UseContextKey="True" DelimiterCharacters="" Enabled="True">
                    </cc1:AutoCompleteExtender>
                </td> 
                <td>
                    <asp:TextBox ID="tbxModel" runat="server" Style="width: 175px" SkinID="Textbox" ></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxYear" runat="server" Style="width: 175px" SkinID="TextBox" ></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="cbxIsTowable" runat="server" SkinID="CheckBox" />
                </td>
            </tr>
            <tr>
                <td></td>
                <td></td>
                <td>
                    <asp:CustomValidator ID="cvForDateRange" runat="server" ControlToValidate="tbxYear" Display="Dynamic"
                        EnableViewState="True" ErrorMessage="Invalid date. (use a date over 1900)" OnServerValidate="cvForDateRange_ServerValidate"
                        SkinID="Validator" ValidationGroup="general"></asp:CustomValidator>
                </td>
                <td></td>
            </tr>
            <tr>
                <td style="height: 7px"></td>
                <td></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblInsuranceClass" SkinID="Label" Text="Insurance Class"></asp:Label>
                </td>
                <td>
                    <asp:UpdatePanel ID="upnlRyderSpecifiedLabel" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Label runat="server" ID="lblRyderSpecified" SkinID="Label" Text="Ryder Specified" Visible="false"></asp:Label>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>                                                              
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="upnlInsuranceClass" runat="server">
                        <contenttemplate>
                            <asp:DropDownList style="width: 175px" ID="ddlInsuranceClass" runat="server" SkinID="DropDownList" AutoPostBack="True" OnSelectedIndexChanged="ddlInsuranceClass_SelectedIndexChanged">
                                <asp:ListItem Value="(Select)">(Select)</asp:ListItem>
                                <asp:ListItem Value="Fleet">Fleet</asp:ListItem>
                                <asp:ListItem Value="Specified">Specified</asp:ListItem>
                                <asp:ListItem Value="Contractors Equipment">Contractors Equipment</asp:ListItem>
                                <asp:ListItem Value="Ryder Specified">Ryder Specified</asp:ListItem>
                            </asp:DropDownList>
                        </contenttemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="upnlRyderSpecified" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="width: 175px">
                                            <asp:TextBox ID="tbxRyderSpecified" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 175px" Visible="false"></asp:TextBox>
                                        </td>
                                        <td style="vertical-align: middle">
                                            <asp:UpdateProgress ID="upRyderSpecified" runat="server" AssociatedUpdatePanelID="upnlInsuranceClass">
                                                <ProgressTemplate>
                                                    <asp:Image ID="imAjaxRyderSpecified" runat="server" SkinID="Ajax_Grey"></asp:Image>
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>                    
                        </contenttemplate>
                        <triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlInsuranceClass" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                        </triggers>
                    </asp:UpdatePanel>
                </td>
                <td>                   
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="rfvInsuranceClass" runat="server" ControlToValidate="ddlInsuranceClass"
                        Display="Dynamic" ErrorMessage="Please provide an insurance class." SkinID="Validator"
                        InitialValue="(Select)" ValidationGroup="general">
                    </asp:RequiredFieldValidator>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvRyderSpecified" runat="server" ControlToValidate="tbxRyderSpecified" 
                        Display="Dynamic" ErrorMessage="Please provide a ryder specified." SkinID="Validator"
                        InitialValue="" ValidationGroup="generalSpecial">
                    </asp:RequiredFieldValidator>
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
        
        <!-- Table element: 4 columns - Detailed information title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblDetailedInformation" runat="server" SkinID="LabelTitle1" Text="Detailed Information" EnableViewState="True"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 1 columns - Tab Control -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>                
                    <!-- Page element : Tab control -->
                    <cc1:TabContainer ID="tcDetailedInformation" Width="730px" runat="server" ActiveTabIndex="1" CssClass="ajax_tabcontainer">
        
                        <cc1:TabPanel ID="tpGeneralData" runat="server" HeaderText="General" OnClientClick="tpGeneralDataClientClick" >                            
                            <HeaderTemplate>
                                General
                            </HeaderTemplate>
                            <ContentTemplate>
                                <div style="width: 710px; height: 410px; overflow-y: auto;">
                                
                                    <asp:UpdatePanel ID="upnlGeneralDataEdit" UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>
                                            <!-- Table element: 4 columns  -->
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width: 177px; height: 10px;">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblCategory" runat="server" SkinID="Label" Text="Category"></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblCompanyLevel" runat="server" SkinID="Label" Text="Working Location"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Panel ID="pnlCategories" runat="server" Height="200px" SkinID="Panel" Width="344px">
                                                            <asp:TreeView ID="tvCategoriesRoot" runat="server" SkinID="SimpleTreeView">
                                                            </asp:TreeView>
                                                        </asp:Panel>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Panel ID="pnlCompanyLevels" runat="server" Height="200px" SkinID="Panel" Width="344px">
                                                            <asp:TreeView ID="tvCompanyLevelsRoot" runat="server" SkinID="SimpleTreeView">
                                                            </asp:TreeView>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:CustomValidator ID="cvCategories" runat="server" SkinID="Validator" Display="Dynamic" ErrorMessage="You must select at least one category."
                                                        OnServerValidate="cvCategories_ServerValidate" ValidationGroup="general"></asp:CustomValidator>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:CustomValidator ID="cvCompanyLevels" runat="server" SkinID="Validator" Display="Dynamic" ErrorMessage="You can select only one company level leave."
                                                        OnServerValidate="cvCompanyLevels_ServerValidate" ValidationGroup="general"></asp:CustomValidator>
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
                                            
                                            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width: 177px;">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblAcquisitionDate" runat="server" SkinID="Label" Text="Acquisition Date"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPurchasePrice" runat="server" SkinID="Label" Text="Purchase Price"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    
                                                </tr>                                        
                                                <tr>
                                                    <td>
                                                        <telerik:RadDatePicker ID="tkrdpAcquisitionDate" runat="server" SkinID="RadDatePicker" Width="167px">
                                                            <calendar daynameformat="Short" showrowheaders="False" usecolumnheadersasselectors="False" userowheadersasselectors="False" viewselectortext="x">
                                                            </calendar>                                                 
                                                        </telerik:RadDatePicker>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="tbxPurchasePrice" runat="server" SkinID="TextBox" Style="width: 167px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:CompareValidator ID="cvPurchasePrice" runat="server" ControlToValidate="tbxPurchasePrice" Display="Dynamic"
                                                            EnableViewState="True" ErrorMessage="Invalid data. (use #.## format)" Operator="DataTypeCheck"
                                                            SkinID="Validator" Type="Currency" ValidationGroup="general"></asp:CompareValidator>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </td>
                                                <tr>
                                                    <td colspan="4" style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblScrapDate" runat="server" SkinID="Label" Text="Scrap Date"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSaleProceeds" runat="server" SkinID="Label" Text="Sale Proceeds"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <telerik:RadDatePicker ID="tkrdpScrapDate" runat="server" SkinID="RadDatePicker" Width="167px">
                                                            <calendar daynameformat="Short" showrowheaders="False" usecolumnheadersasselectors="False" userowheadersasselectors="False" viewselectortext="x">
                                                            </calendar>                                                 
                                                        </telerik:RadDatePicker>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="tbxSaleProceeds" runat="server" SkinID="TextBox" Style="width: 167px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:CompareValidator ID="cvSaleProceeds" runat="server" ControlToValidate="tbxSaleProceeds" Display="Dynamic"
                                                            EnableViewState="True" ErrorMessage="Invalid data. (use #.## format)" Operator="DataTypeCheck"
                                                            SkinID="Validator" Type="Currency" ValidationGroup="general"></asp:CompareValidator>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </td>
                                                <tr>
                                                    <td colspan="4" style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblDispositionDate" runat="server" SkinID="Label" Text="Disposition Date"></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblDispositionReason" runat="server" SkinID="Label" Text="Disposition Reason"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <telerik:RadDatePicker ID="tkrdpDispositionDate" runat="server" SkinID="RadDatePicker" Width="167px">
                                                            <calendar daynameformat="Short" showrowheaders="False" usecolumnheadersasselectors="False" userowheadersasselectors="False" viewselectortext="x">
                                                            </calendar>
                                                        </telerik:RadDatePicker>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="tbxDispositionReason" runat="server" SkinID="TextBox" Style="width: 344px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>  
                                         </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
                                    <asp:UpdatePanel ID="upnlGeneralDataSummary" UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width: 177px; height: 10px;">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblCategorySummary" runat="server" Text="Category" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblWorkingLocationSummary" runat="server" Text="Working Location" SkinID="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Panel ID="pnlCategoriesSummary" Width="344px" Height="200px" runat="server" SkinID="PanelReadOnly">
                                                            <asp:TreeView ID="tvCategoriesRootSummary" runat="server" SkinID="SimpleTreeView" onclick="return cbxTreeViewClick(event);">
                                                            </asp:TreeView>
                                                        </asp:Panel>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Panel ID="pnlCompanyLevelsSummary" Width="344px" Height="200px" runat="server" SkinID="PanelReadOnly">
                                                            <asp:TreeView ID="tvCompanyLevelsRootSummary" runat="server" SkinID="SimpleTreeView" onclick="return cbxTreeViewClick(event);">                                                    
                                                            </asp:TreeView>
                                                        </asp:Panel>
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
                                            
                                            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width: 177px;">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblAcquisitinDateSummary" runat="server" SkinID="Label" Text="Acquisition Date"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblPurchasePriceSummary" runat="server" SkinID="Label" Text="Purchase Price"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="tbxAcquisitionDateSummary" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="tbxPurchasePriceSummary" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblScarpDateSummary" runat="server" SkinID="Label" Text="Scrap Date"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSaleProceedsSumamry" runat="server" SkinID="Label" Text="Sale Proceeds"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="tbxScrapDateSummary" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="tbxSaleProceedsSummary" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4" style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblDispositionDateSummary" runat="server" SkinID="Label" Text="Disposition Date"></asp:Label>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblDispositionReasonSummary" runat="server" SkinID="Label" Text="Disposition Reason"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="tbxDispositionDateSummary" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="tbxDispositionReasonSummary" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 344px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table> 
                                         </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
                                    <!-- Table element: 4 columns - Bottom space -->                                    
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 177px; height: 30px;">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                        </tr>
                                    </table>                                                                      
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>                        
                        
                       
                        
                        <cc1:TabPanel ID="tpPlateData" runat="server" HeaderText="Plate" OnClientClick="tpPlateDataClientClick">
                            <HeaderTemplate>
                                Plate
                            </HeaderTemplate>
                            <ContentTemplate>
                                <div style="width: 710px; height: 410px; overflow-y: auto;">
                                
                                    <asp:UpdatePanel ID="upnlPlateDataEdit" UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>
                                            <!-- Table element: 4 columns  -->
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width: 177px; height: 10px;">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblLicenseCountry" runat="server" SkinID="Label" Text="License Country"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblLicenseState" runat="server" SkinID="Label" Text="License State"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="upnlCountry" runat="server">
                                                            <ContentTemplate>
                                                                <asp:DropDownList ID="ddlLicenseCountry" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlLicenseCountry_SelectedIndexChanged" SkinID="DropDownList" Width="167px">
                                                                </asp:DropDownList>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td>
                                                        <asp:UpdatePanel ID="upLicenseState" runat="server">
                                                            <contenttemplate>
                                                                 <asp:TextBox ID="tbxLicenseState" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 167px"></asp:TextBox>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td>                                                
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
                                                    <td colspan="2">
                                                        <asp:Label ID="lblLicensePlateNumber" runat="server" SkinID="Label" Text="License Plate Number"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="tbxLicensePlateNumber" runat="server" SkinID="TextBox" Style="width: 344px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table> 
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
                                    <asp:UpdatePanel ID="upnlPlateDataSummary" UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>
                                            <!-- Table element: 4 columns  -->
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width: 177px; height: 10px;">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblLicenseCountrySummary" runat="server" Text="License Country" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblLicenseStateSummary" runat="server" Text="License State" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="tbxLicenseCountrySummary" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="tbxLicenseStateSummary" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:Label ID="lblLicensePlateNumberSummary" runat="server" Text="License Plate Number" SkinID="Label"></asp:Label>
                                                    </td>                                            
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="tbxLicensePlateNumberSummary" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 344px"></asp:TextBox>
                                                    </td>                                            
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
                                    <!-- Table element: 4 columns - Bottom space -->                                    
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 177px; height: 30px;">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                        </tr>
                                    </table>
                                    
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpTechnical" runat="server" HeaderText="Technical" OnClientClick="tpTechnicalClientClick">                            
                            <ContentTemplate>
                                <div style="width: 710px; height: 410px; overflow-y: auto;">
                                    
                                    <asp:UpdatePanel ID="upnlTechnicalEdit" UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>
                                            <!-- Table element: 4 columns  -->
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width: 177px; height: 10px;">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblActualWeight" runat="server" Text="Actual Weight" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblRegisteredWeight" runat="server" Text="Registered Weight" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="tbxActualWeight" runat="server" SkinID="TextBox" Style="width: 167px" EnableViewState="true">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="tbxRegisteredWeight" runat="server" SkinID="TextBox" Style="width: 167px" EnableViewState="true">
                                                        </asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
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
                                            
                                            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width: 177px;">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblTireSizeFront" runat="server" Text="Tire Size Front" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblTireSizeBack" runat="server" Text="Tire Size Back" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="tbxTireSizeFront" runat="server" SkinID="TextBox" Style="width: 167px" EnableViewState="true"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="tbxTireSizeBack" runat="server" SkinID="TextBox" Style="width: 167px" EnableViewState="true"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
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
                                            
                                            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width: 177px;">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblNumberOfAxes" runat="server" Text="Number Of Axes" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblFuelType" runat="server" Text="Fuel Type" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblBeginningOdometer" runat="server" Text="Beginning Odometer" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlNumberOfAxes" runat="server" SkinID="DropDownList" Style="width: 167px" EnableViewState="True" DataMember="DefaultView" DataSourceID="odsNumberOfAxes" DataTextField="NumberOfAxes" DataValueField="NumberOfAxes">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlFuelType" runat="server" SkinID="DropDownList" Style="width: 167px" EnableViewState="True" DataMember="DefaultView" DataSourceID="odsFuelType" DataTextField="FuelType" DataValueField="FuelType">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="tbxBeginningOdometer" runat="server" SkinID="TextBox" Style="width: 167px"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px"></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblIsReeferEquipped" runat="server" Text="Is Reefer Equipped?" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblIsPtoEquipped" runat="server" Text="Is PTO Equipped?" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="cbxIsReeferEquipped" runat="server" SkinID="CheckBox" />
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="cbxIsPtoEquipped" runat="server" SkinID="CheckBox" />
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                                                                
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
                                    <asp:UpdatePanel ID="upnlTechnicalSummary" UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>
                                            <!-- Table element: 4 columns  -->
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width: 177px; height: 10px;">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblActualWeightSummary" runat="server" Text="Actual Weight" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblRegisteresWeightSummary" runat="server" Text="Registered Weight" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="tbxActualWeightSummary" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="tbxRegisteredWeightSummary" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
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
                                            
                                            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width: 177px;">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblTireSizeFromSummary" runat="server" Text="Tire Size Front" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblTireSizeBackSummary" runat="server" Text="Tire Size Back" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="tbxTireSizeFrontSummary" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="tbxTireSizeBackSummary" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
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
                                            
                                            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width: 177px;">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblNumberOfAxesSummary" runat="server" Text="Number Of Axes" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblFuelTypeSummary" runat="server" Text="Fuel Type" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblBeginningOdometerSummary" runat="server" Text="Beginning Odometer" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="tbxNumberOfAxesSummary" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="tbxFuelTypeSummary" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="tbxBeginningOdometerSummary" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblIsRefeerEquippedSummary" runat="server" Text="Is Reefer Equipped?" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblIsPtoEquippedSummary" runat="server" Text="Is PTO Equipped?" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="cbxIsReeferEquippedSummary" runat="server" SkinID="CheckBox" onclick="return cbxClick();" />
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="cbxIsPtoEquippedSummary" runat="server" SkinID="CheckBox" onclick="return cbxClick();" />
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <!-- Table element: 4 columns - Bottom space -->                                    
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 30px">
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table> 
                                    
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpOwnership" runat="server" HeaderText="Ownership" OnClientClick="tpOwnershipClientClick">
                            <ContentTemplate>
                                <div style="width: 710px; height: 410px; overflow-y: auto;">
                                
                                    <asp:UpdatePanel ID="upnlOwnershipEdit" UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>
                                            <!-- Table element: 4 columns  -->
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width: 177px; height: 10px;">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblOwnerType" runat="server" Text="Owner Type" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblOwnerCountry" runat="server" Text="Owner Country" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblOwnerState" runat="server" Text="Owner State" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlOwnerType" runat="server" SkinID="DropDownList" Style="width: 167px" EnableViewState="True" DataMember="DefaultView" DataSourceID="odsOwnerType" DataTextField="OwnerType" DataValueField="OwnerType">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:UpdatePanel ID="upnlOwnerCountry" runat="server">
                                                            <contenttemplate>
                                                                <asp:DropDownList id="ddlOwnerCountry" runat="server" SkinID="DropDownList" Width="167px" AutoPostBack="True" OnSelectedIndexChanged="ddlOwnerCountry_SelectedIndexChanged">
                                                                </asp:DropDownList> 
                                                            </contenttemplate>
                                                        </asp:UpdatePanel>                                            
                                                    </td>
                                                    <td>
                                                        <asp:UpdatePanel ID="upnlOwnerProvince" runat="server">
                                                            <contenttemplate>
                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="width: 167px">
                                                                                <asp:DropDownList ID="ddlOwnerState" runat="server" SkinID="DropDownList" Width="167px">
                                                                                </asp:DropDownList>
                                                                            </td>
                                                                            <td style="vertical-align: middle">
                                                                                <asp:UpdateProgress ID="upOwnerProvince" runat="server" AssociatedUpdatePanelID="upnlOwnerCountry">
                                                                                    <ProgressTemplate>
                                                                                        <asp:Image ID="imAjaxOwnerProvince" runat="server" SkinID="Ajax_Grey"></asp:Image>
                                                                                    </ProgressTemplate>
                                                                                </asp:UpdateProgress>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </contenttemplate>
                                                            <triggers>
                                                                <asp:AsyncPostBackTrigger ControlID="ddlOwnerCountry" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                            </triggers>
                                                        </asp:UpdatePanel>                                            
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px"></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Label ID="lblOwnerName" runat="server" Text="Owner Name" SkinID="Label"></asp:Label>
                                                    </td>                                            
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="tbxOwnerName" runat="server" SkinID="TextBox" Style="width: 521px"></asp:TextBox>
                                                    </td>                                            
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px"></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Label ID="lblOwnerContact" runat="server" Text="Contact Info" SkinID="Label"></asp:Label>
                                                    </td>                                            
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="tbxOwnerContact" runat="server" SkinID="TextBox" Rows="4" TextMode="MultiLine" Style="width: 521px"></asp:TextBox>
                                                    </td>                                            
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
                                    <asp:UpdatePanel ID="upnlOwnershipSummary" UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>
                                            <!-- Table element: 4 columns  -->
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width: 177px; height: 10px;">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblOwnerTypeSummary" runat="server" Text="Owner Type" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblOwnerCountrySummary" runat="server" Text="Owner Country" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblOwnerStateSummary" runat="server" Text="Owner State" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="tbxOwnerTypeSummary" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="tbxOwnerCountrySummary" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="tbxOwnerStateSummary" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                                    </td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Label ID="lblOwnerNameSummary" runat="server" Text="Owner Name" SkinID="Label"></asp:Label>
                                                    </td>                                            
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="tbxOwnerNameSummary" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 521px"></asp:TextBox>
                                                    </td>                                            
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Label ID="lblContactInfoSummary" runat="server" Text="Contact Info" SkinID="Label"></asp:Label>
                                                    </td>                                            
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:TextBox ID="tbxContactInfoSummary" runat="server" SkinID="TextBoxReadOnly" Rows="4" ReadOnly="True" TextMode="MultiLine" Style="width: 521px"></asp:TextBox>
                                                    </td>                                            
                                                    <td></td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
                                    <!-- Table element: 4 columns - Bottom space -->                                    
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 30px">
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table> 
                                    
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpChecklist" runat="server" HeaderText="Checklist" OnClientClick="tpChecklistClientClick">
                            <ContentTemplate>
                                <div style="width: 710px; height: 410px; overflow-y: auto;">
                                
                                    <asp:UpdatePanel ID="upnlChecklistEdit" UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>
                                            <!-- Table element: 4 columns  -->
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width: 177px; height: 10px;">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:UpdatePanel id="upnlChecklistRulesInformation" runat="server">
                                                            <contenttemplate>
                                                                <asp:GridView ID="grdChecklistRulesInformation" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="13" SkinID="GridViewInTabs" AllowSorting="true"
                                                                    Width="700px" OnDataBound="grdChecklistRulesInformation_DataBound" DataSourceID="odsChecklistRulesInformation" DataKeyNames="RuleID" 
                                                                    OnPageIndexChanging="grdChecklistRulesInformation_PageIndexChanging" DataMember="DefaultView" >
                                                                    <Columns>
                                                                        <asp:BoundField ReadOnly="True" DataField="RuleID" Visible="False" SortExpression="RuleID" HeaderText="RuleID"></asp:BoundField>
                                                                        
                                                                        <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                                                            <HeaderStyle Width="180px"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblColumn" runat="server" Width="180px" Style="width: 180px" SkinID="Label" Text='<%# Bind("Name") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="Frequency" SortExpression="Frequency">
                                                                            <HeaderStyle Width="120px"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblFrequency" runat="server" Width="120px" Style="width: 120px" SkinID="Label" Text='<%# Bind("Frequency") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="Last Service" SortExpression="LastService">
                                                                            <HeaderStyle Width="135px"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblLastService" runat="server" Width="135px" Style="width: 135px" SkinID="Label" Text='<%# Bind("LastService", "{0:d}") %>'></asp:Label>                                                                
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="Next Due" SortExpression="NextDue">
                                                                            <HeaderStyle Width="135px"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblNextDue" runat="server" Width="135px" Style="width: 135px" SkinID="Label" Text='<%# Bind("NextDue", "{0:d}") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="Done" SortExpression="Done">
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                            <HeaderStyle Width="30px"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="cbxDone" runat="server" Checked='<%# Eval("Done") %>' onclick="return cbxClick();" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="State" SortExpression="State">
                                                                            <HeaderStyle Width="80px"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblState" runat="server" Width="80px" Style="width: 80px" SkinID="Label" Text='<%# Bind("State") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                    </Columns>
                                                                </asp:GridView>   
                                                            </contenttemplate>        
                                                        </asp:UpdatePanel>                                                     
                                                    </td>                                  
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel id="upnlComments" runat="server">
                                                            <contenttemplate>
                                                                <asp:Button id="btnChecklist" onclick="btnChecklistOnClick" runat="server" SkinID="Button" Text="Update" EnableViewState="True" Width="80px"></asp:Button> 
                                                            </contenttemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                    <td colspan="3"></td>
                                                </tr>    
                                                <tr>
                                                    <td colspan="4">
                                                        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:ObjectDataSource ID="odsChecklistRulesInformation" runat="server" SelectMethod="GetChecklistRulesInformation"
                                                                        TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_edit"></asp:ObjectDataSource>
                                                                </td>
                                                            </tr>
                                                        </table>    
                                                    </td>
                                                </tr>                     
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
                                    <asp:UpdatePanel ID="upnlChecklistSummary" UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>
                                            <!-- Table element: 4 columns  -->
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width: 177px; height: 10px;">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:UpdatePanel id="upnlChecklistRulesSummary" runat="server">
                                                            <contenttemplate>
                                                                <asp:GridView ID="grdChecklistRulesInformationSummary" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="13" SkinID="GridViewInTabs" Width="700px" AllowSorting="true" 
                                                                    OnDataBound="grdChecklistRulesInformation_DataBound" DataSourceID="odsChecklistRulesInformationSummary" DataKeyNames="RuleID" OnPageIndexChanging="grdChecklistRulesInformation_PageIndexChanging" 
                                                                    DataMember="DefaultView" >
                                                                    <Columns>
                                                                        <asp:BoundField ReadOnly="True" DataField="RuleID" Visible="False" SortExpression="RuleID" HeaderText="RuleID"></asp:BoundField>
                                                                        
                                                                        <asp:TemplateField HeaderText="Name" SortExpression="Name">
                                                                            <HeaderStyle Width="180px"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblColumn" runat="server" Width="180px" Style="width: 180px" SkinID="Label" Text='<%# Bind("Name") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="Frequency" SortExpression="Frequency">
                                                                            <HeaderStyle Width="120px"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblFrequency" runat="server" Width="120px" Style="width: 120px" SkinID="Label" Text='<%# Bind("Frequency") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="Last Service" SortExpression="LastService">
                                                                            <HeaderStyle Width="135px"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblLastService" Width="135px" Style="width: 135px" runat="server" SkinID="Label" Text='<%# Bind("LastService", "{0:d}") %>'></asp:Label>                                                                
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="Next Due" SortExpression="NextDue">
                                                                            <HeaderStyle Width="135px"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblNextDue" Width="135px" Style="width: 135px" runat="server" SkinID="Label" Text='<%# Bind("NextDue", "{0:d}") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="Done" SortExpression="Done">
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                            <HeaderStyle Width="30px"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="cbxDone" runat="server" Checked='<%# Eval("Done") %>' onclick="return cbxClick();" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="State" SortExpression="State">
                                                                            <HeaderStyle Width="80px"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblState" Width="80px" Style="width: 80px" runat="server" SkinID="Label" Text='<%# Bind("State") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </contenttemplate>
                                                        </asp:UpdatePanel>
                                                    </td>                                   
                                                </tr>                                                
                                                <tr>
                                                    <td colspan="4">
                                                        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:ObjectDataSource ID="odsChecklistRulesInformationSummary" runat="server" SelectMethod="GetChecklistRulesInformation"
                                                                        TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_edit"></asp:ObjectDataSource>
                                                                </td>
                                                            </tr>
                                                        </table>    
                                                    </td>
                                                </tr>                     
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
                                    <!-- Table element: 4 columns - Bottom space -->                                    
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 30px">
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table> 
                                    
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpService" runat="server" HeaderText="Services" OnClientClick="tpServiceClientClick">
                            <ContentTemplate>
                                <div style="width: 710px; height: 410px; overflow-y: auto;">
                                                                    
                                    <!-- Table element: 4 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 177px; height: 10px;">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                            <td style="width: 177px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:UpdatePanel id="upnlServices" runat="server">
                                                    <contenttemplate>
                                                        <asp:GridView ID="grdServices" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="13" SkinID="GridViewInTabs" Width="700px" AllowSorting="true"
                                                            OnDataBound="grdServices_DataBound" DataSourceID="odsServices" DataKeyNames="ServiceID" OnPageIndexChanging="grdServices_PageIndexChanging" DataMember="DefaultView" >
                                                            <Columns>
                                                                <asp:BoundField ReadOnly="True" DataField="ServiceID" Visible="False" SortExpression="ServiceID" HeaderText="ServiceID"></asp:BoundField>
                                                                
                                                                <asp:TemplateField ShowHeader="False">
                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                        <HeaderStyle Width="30px"></HeaderStyle>
                                                                        <ItemTemplate>
                                                                            <asp:CheckBox ID="cbxSelectedService" runat="server" Checked='<%# Eval("Selected") %>' onclick="return cbxSelectedClick(this);"/>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Service Number" SortExpression="ServiceID">
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    <HeaderStyle Width="100px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblNumber" runat="server" Width="100px" SkinID="Label" Style="width: 100px" Text='<%# Bind("Number") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Date" SortExpression="DateTime_">
                                                                    <HeaderStyle Width="150px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDate" runat="server" SkinID="Label" Width="150px" Style="width: 150px" Text='<%# Bind("DateTime_") %>'></asp:Label>                                                                
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Description" SortExpression="Description">
                                                                    <HeaderStyle Width="270px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblDescription" runat="server" SkinID="Label" Width="270px" Style="width: 270px" Text='<%# Bind("Description") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>                                                        
                                                                                                                       
                                                                <asp:TemplateField HeaderText="State" SortExpression="State">
                                                                    <HeaderStyle Width="150px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblState" runat="server" SkinID="Label" Width="150px" Style="width: 150px" Text='<%# Bind("State") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="ServiceID" Visible="false">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblServiceID" runat="server" SkinID="Label" Text='<%# Bind("ServiceID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                                                                                
                                                        </asp:GridView> 
                                                    </contenttemplate>        
                                                </asp:UpdatePanel>                                                       
                                            </td>                                   
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel id="upnlOpenService" runat="server">
                                                    <contenttemplate>
                                                        <asp:Button id="btnOpenService" onclick="btnOpenServiceOnClick" runat="server" SkinID="Button" Text="Open" EnableViewState="True" Width="80px"></asp:Button> 
                                                    </contenttemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                            <td colspan="3"></td>
                                        </tr>     
                                        <tr>
                                            <td colspan="4">
                                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                    <tr>
                                                        <td>
                                                            <asp:ObjectDataSource ID="odsServices" runat="server" SelectMethod="GetServicesInformation"
                                                                TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_edit"></asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                </table>    
                                            </td>
                                        </tr>                     
                                    </table>                                        
                                                                        
                                    <!-- Table element: 4 columns - Bottom space -->                                    
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 30px">
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table> 
                                    
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpInspection" runat="server" HeaderText="Inspections" OnClientClick="tpInspectionClientClick">
                            <ContentTemplate>
                                <div style="width: 710px;">
                                
                                    <asp:UpdatePanel ID="upnlInspectionEdit" UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                <tr>
                                                    <td style="width: 142px; height: 10px;">
                                                    </td>
                                                    <td style="width: 142px">
                                                    </td>
                                                    <td style="width: 142px">
                                                    </td>
                                                    <td style="width: 142px">
                                                    </td>
                                                    <td style="width: 142px">
                                                    </td>
                                                </tr>              
                                                <tr>
                                                    <td colspan="5">                          
                                                        <asp:UpdatePanel id="upnlInspections" runat="server">
                                                            <contenttemplate>
                                                                <!-- Page element: 1 column - Grid Inspections -->
                                                                <asp:GridView id="grdInspections" runat="server" SkinID="GridViewInTabs" ShowFooter="True"
                                                                 PageSize="2" DataSourceID="odsInspections" OnDataBound="grdInspections_DataBound" 
                                                                 OnRowCommand="grdInspections_RowCommand" OnRowEditing="grdInspections_RowEditing"
                                                                 OnRowUpdating="grdInspections_RowUpdating" OnRowDeleting="grdInspections_RowDeleting"
                                                                  OnRowDataBound="grdInspections_RowDataBound" AutoGenerateColumns="False" AllowPaging="True" 
                                                                  DataKeyNames="InspectionID" width="700px">
                                                                <Columns> 
                                                                                                                    
                                                                    <asp:TemplateField HeaderText="InspectionID" SortExpression="InspectionID" Visible="False">
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblInspectionId" runat="server" Text='<%# Eval("InspectionID") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:Label ID="lblInspectionIdEdit" runat="server" Text='<%# Eval("InspectionID") %>'></asp:Label>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                                                                   
                                                                    <asp:TemplateField HeaderText="Inspections" SortExpression="InspectionID">
                                                                        <HeaderStyle Width="660px" />
                                                                        
                                                                        <EditItemTemplate>
                                                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 660px">
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px"></td>
                                                                                    <td style="width: 107px"></td>
                                                                                    <td style="width: 107px"></td>
                                                                                    <td style="width: 107px"></td>
                                                                                    <td style="width: 107px"></td>
                                                                                    <td style="width: 107px"></td>
                                                                                    <td style="width: 107px"></td>
                                                                                    <td style="width: 8px"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblInspectionDateEdit" runat="server" Text="Inspection Date" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblCountryEdit" runat="server" Text="Country" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblStateEdit" runat="server" Text="State" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label id="lblTypeEdit" runat="server" Text="Type" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblResultEdit" runat="server" Text="Result" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblRepairCostEdit" runat="server" Text="Repair Cost" SkinID="Label"></asp:Label>
                                                                                    </td>                                                                    
                                                                                    <td></td>
                                                                                </tr>    
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <telerik:RadDatePicker ID="tkrdpInspectionDateEdit" runat="server" Width="97px" SkinID="RadDatePicker" DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "Date_") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                        </telerik:RadDatePicker>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:UpdatePanel ID="upnlInspectionCountryEdit" runat="server">
                                                                                            <contenttemplate>
                                                                                                <asp:DropDownList id="ddlCountryEdit" runat="server" SkinID="DropDownList" Width="97px" AutoPostBack="True" OnSelectedIndexChanged="ddlCountryEdit_SelectedIndexChanged" DataSourceID="odsCountry" DataTextField="Name" DataValueField="CountryID" >
                                                                                                </asp:DropDownList> 
                                                                                            </contenttemplate>
                                                                                        </asp:UpdatePanel>                                            
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:UpdatePanel ID="upnlInspectionProvinceEdit" runat="server">
                                                                                            <contenttemplate>
                                                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td style="width: 97px">
                                                                                                                <asp:DropDownList ID="ddlStateEdit" runat="server" SkinID="DropDownList" Width="97px">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                            <td style="vertical-align: middle">
                                                                                                                <asp:UpdateProgress ID="upInspectionProvinceEdit" runat="server" AssociatedUpdatePanelID="upnlInspectionCountryEdit">
                                                                                                                    <ProgressTemplate>
                                                                                                                        <asp:Image ID="imAjaxInspectionProvinceEdit" runat="server" SkinID="Ajax_Grey"></asp:Image>
                                                                                                                    </ProgressTemplate>
                                                                                                                </asp:UpdateProgress>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </contenttemplate>
                                                                                            <triggers>
                                                                                                <asp:AsyncPostBackTrigger ControlID="ddlCountryEdit" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                                                            </triggers>
                                                                                        </asp:UpdatePanel>                                            
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList style="width: 97px" id="ddlTypeEdit" runat="server" SkinID="DropDownList" SelectedValue='<%# Eval("Type") %>' >
                                                                                            <asp:ListItem Value=""></asp:ListItem>
                                                                                            <asp:ListItem Value="(Empty)">(Empty)</asp:ListItem>
                                                                                            <asp:ListItem Value="Annual">Annual</asp:ListItem>
                                                                                            <asp:ListItem Value="Roadside">Roadside</asp:ListItem>
                                                                                        </asp:DropDownList>                                                                        
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList style="width: 97px" id="ddlResultEdit" runat="server" SkinID="DropDownList" SelectedValue='<%# Eval("Result") %>' >
                                                                                            <asp:ListItem Value=""></asp:ListItem>
                                                                                            <asp:ListItem Value="Fail">Fail</asp:ListItem>
                                                                                            <asp:ListItem Value="Pass">Pass</asp:ListItem>                                                                            
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxRepairCostEdit" runat="server" Width="97px" Text='<%# Eval("Cost", "{0:f2}") %>' SkinID="TextBox" ></asp:TextBox>
                                                                                    </td>                                                                    
                                                                                    <td></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvInspectionDateEdit" runat="server" ControlToValidate="tkrdpInspectionDateEdit" ErrorMessage="Please select a date" ValidationGroup="inspectionsEdit" 
                                                                                             SkinID="Validator" Display="Dynamic" InitialValue="" >
                                                                                         </asp:RequiredFieldValidator>                                                                        
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvCountryEdit" runat="server" SkinID="Validator" EnableViewState="True" ErrorMessage="Please select a country" Display="Dynamic" ControlToValidate="ddlCountryEdit" InitialValue="-1" ValidationGroup="inspectionsEdit"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvStateEdit" runat="server" SkinID="Validator" EnableViewState="True" ErrorMessage="Please select a state" Display="Dynamic" ControlToValidate="ddlStateEdit" InitialValue="" ValidationGroup="inspectionsEdit"></asp:RequiredFieldValidator>
                                                                                        <asp:RequiredFieldValidator ID="ffvStateEdit2" runat="server" SkinID="Validator" EnableViewState="True" ErrorMessage="Please select a state" Display="Dynamic" ControlToValidate="ddlStateEdit" InitialValue="-1" ValidationGroup="inspectionsEdit"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvTypeEdit" runat="server" SkinID="Validator" EnableViewState="True" ErrorMessage="Please select a type" Display="Dynamic" ControlToValidate="ddlTypeEdit" InitialValue="" ValidationGroup="inspectionsEdit"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:CompareValidator ID="cvRepairCostEdit" runat="server" ControlToValidate="tbxRepairCostEdit" Display="Dynamic"
                                                                                            EnableViewState="True" ErrorMessage="Invalid data (use #.## format)" Operator="DataTypeCheck"
                                                                                            SkinID="Validator" Type="Currency" ValidationGroup="inspectionsEdit"></asp:CompareValidator>
                                                                                    </td>
                                                                                    <td></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height:7px"></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                </tr>                                                                
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td colspan="6">
                                                                                        <asp:Label ID="lblNotesEdit" runat="server" Text="Notes" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td colspan="6">
                                                                                        <asp:TextBox ID="tbxNotesEdit" runat="server" EnableViewState="True" Rows="4" SkinID="TextBox" Style="width: 632px" Text='<%# Eval("Notes") %>' TextMode="MultiLine"></asp:TextBox>
                                                                                    </td>
                                                                                    <td></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height:7px"></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                </tr>                                                                
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td colspan="6">
                                                                                        <asp:Label ID="lblInspectedByEdit" runat="server" Text="Inspected By" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td colspan="6">
                                                                                        <asp:TextBox ID="tbxInspectedByEdit" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 632px" Text='<%# Eval("InspectedBy") %>' ></asp:TextBox>
                                                                                    </td>
                                                                                    <td></td>
                                                                                </tr>                                                                
                                                                                <tr>
                                                                                    <td style="height: 30px"></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                </tr>                                                                
                                                                            </table>                                                  
                                                                        </EditItemTemplate>                                                      
                                                                                                                                                                                       
                                                                        <ItemTemplate>
                                                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 660px">
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px"></td>
                                                                                    <td style="width: 107px"></td>
                                                                                    <td style="width: 107px"></td>
                                                                                    <td style="width: 107px"></td>
                                                                                    <td style="width: 107px"></td>
                                                                                    <td style="width: 107px"></td>
                                                                                    <td style="width: 107px"></td>
                                                                                    <td style="width: 8px"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblInspectionDate" runat="server" Text="Inspection Date" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblCountry" runat="server" Text="Country" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblState" runat="server" Text="State" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label id="lblType" runat="server" Text="Type" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblResult" runat="server" Text="Result" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblRepairCost" runat="server" Text="Repair Cost" SkinID="Label"></asp:Label>
                                                                                    </td>                                                                    
                                                                                    <td></td>
                                                                                </tr>    
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxInspectionDate" runat="server" Width="97px" Text='<%# Eval("Date_", "{0:d}") %>' SkinID="TextBoxReadOnly" ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxCountry" runat="server" Width="97px" Text='<%# GetCountry(Eval("Country")) %>' SkinID="TextBoxReadOnly" ReadOnly="true"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxState" runat="server" Width="97px" Text='<%# GetState(Eval("State")) %>' SkinID="TextBoxReadOnly" ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxType" runat="server" Width="97px" Text='<%# Eval("Type") %>' SkinID="TextBoxReadOnly" ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxResult" runat="server" Width="97px" Text='<%# Eval("Result") %>' SkinID="TextBoxReadOnly" ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxRepairCost" runat="server" Width="97px" Text='<%# Eval("Cost", "{0:f2}") %>' SkinID="TextBoxReadOnly" ReadOnly="True"></asp:TextBox>
                                                                                    </td>                                                                    
                                                                                    <td></td>
                                                                                </tr>                                                       
                                                                                <tr>
                                                                                    <td style="height:7px"></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                </tr>                                                                
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td colspan="6">
                                                                                        <asp:Label ID="lblNotes" runat="server" Text="Notes" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td colspan="6">
                                                                                        <asp:TextBox ID="tbxNotes" runat="server" EnableViewState="True" ReadOnly="True"
                                                                                        Rows="4" SkinID="TextBoxReadOnly" Style="width: 632px" Text='<%# Eval("Notes") %>'  TextMode="MultiLine"></asp:TextBox>
                                                                                    </td>
                                                                                    <td></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height:7px"></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                </tr>                                                                
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td colspan="6">
                                                                                        <asp:Label ID="lblInspectedBy" runat="server" Text="Inspected By" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td colspan="6">
                                                                                        <asp:TextBox ID="tbxInspectedBy" runat="server" EnableViewState="True" ReadOnly="True"
                                                                                        SkinID="TextBoxReadOnly" Style="width: 632px" Text='<%# Eval("InspectedBy") %>' ></asp:TextBox>
                                                                                    </td>
                                                                                    <td></td>
                                                                                </tr>                                                               
                                                                                <tr>
                                                                                    <td style="height: 30px"></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                </tr>                                                                
                                                                            </table>                                                        
                                                                        </ItemTemplate>
                                                                        
                                                                        <FooterTemplate>
                                                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 660px">
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px"></td>
                                                                                    <td style="width: 107px"></td>
                                                                                    <td style="width: 107px"></td>
                                                                                    <td style="width: 107px"></td>
                                                                                    <td style="width: 107px"></td>
                                                                                    <td style="width: 107px"></td>
                                                                                    <td style="width: 107px"></td>
                                                                                    <td style="width: 8px"></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblInspectionDateNew" runat="server" Text="Inspection Date" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblCountryNew" runat="server" Text="Country" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblStateNew" runat="server" Text="State" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label id="lblTypeNew" runat="server" Text="Type" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblResultNew" runat="server" Text="Result" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblRepairCostNew" runat="server" Text="Repair Cost" SkinID="Label"></asp:Label>
                                                                                    </td>                                                                    
                                                                                    <td></td>
                                                                                </tr>    
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <telerik:RadDatePicker ID="tkrdpInspectionDateNew" runat="server" Width="97px" SkinID="RadDatePicker" DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "Date_") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                                        </telerik:RadDatePicker>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:UpdatePanel ID="upnlInspectionCountryNew" runat="server">
                                                                                            <contenttemplate>
                                                                                                <asp:DropDownList id="ddlCountryNew" runat="server" SkinID="DropDownList" Width="97px" AutoPostBack="True" OnSelectedIndexChanged="ddlCountryNew_SelectedIndexChanged" DataSourceID="odsCountry" DataTextField="Name" DataValueField="CountryID" >
                                                                                                </asp:DropDownList>                                                                                
                                                                                            </contenttemplate>
                                                                                        </asp:UpdatePanel>                                            
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:UpdatePanel ID="upnlInspectionProvinceNew" runat="server">
                                                                                            <contenttemplate>
                                                                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td style="width: 97px">
                                                                                                                <asp:DropDownList ID="ddlStateNew" runat="server" SkinID="DropDownList" Width="97px">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                            <td style="vertical-align: middle">
                                                                                                                <asp:UpdateProgress ID="upInspectionProvinceNew" runat="server" AssociatedUpdatePanelID="upnlInspectionCountryNew">
                                                                                                                    <ProgressTemplate>
                                                                                                                        <asp:Image ID="imAjaxInspectionProvinceNew" runat="server" SkinID="Ajax_Grey"></asp:Image>
                                                                                                                    </ProgressTemplate>
                                                                                                                </asp:UpdateProgress>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </contenttemplate>
                                                                                            <triggers>
                                                                                                <asp:AsyncPostBackTrigger ControlID="ddlCountryNew" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                                                            </triggers>
                                                                                        </asp:UpdatePanel>                                            
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList style="width: 97px" id="ddlTypeNew" runat="server" SkinID="DropDownList" SelectedValue='<%# Eval("Type") %>' >
                                                                                            <asp:ListItem Value=""></asp:ListItem>
                                                                                            <asp:ListItem Value="(Empty)">(Empty)</asp:ListItem>
                                                                                            <asp:ListItem Value="Annual">Annual</asp:ListItem>
                                                                                            <asp:ListItem Value="Roadside">Roadside</asp:ListItem>
                                                                                        </asp:DropDownList>                                                                        
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:DropDownList style="width: 97px" id="ddlResultNew" runat="server" SkinID="DropDownList" SelectedValue='<%# Eval("Result") %>' >
                                                                                            <asp:ListItem Value=""></asp:ListItem>
                                                                                            <asp:ListItem Value="Fail">Fail</asp:ListItem>
                                                                                            <asp:ListItem Value="Pass">Pass</asp:ListItem>                                                                            
                                                                                        </asp:DropDownList>                                                                        
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxRepairCostNew" runat="server" Width="97px" Text='<%# Eval("Cost", "{0:f2}") %>' SkinID="TextBox" ></asp:TextBox>
                                                                                    </td>                                                                    
                                                                                    <td></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvInspectionDateNew" runat="server" SkinID="Validator" EnableViewState="True" ErrorMessage="Please select a date." Display="Dynamic" ControlToValidate="tkrdpInspectionDateNew" InitialValue="" ValidationGroup="inspections"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvCountryNew" runat="server" SkinID="Validator" EnableViewState="True" ErrorMessage="Please select a country." Display="Dynamic" ControlToValidate="ddlCountryNew" InitialValue="-1" ValidationGroup="inspections"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvStateNew" runat="server" SkinID="Validator" EnableViewState="True" ErrorMessage="Please select a state." Display="Dynamic" ControlToValidate="ddlStateNew" InitialValue="" ValidationGroup="inspections"></asp:RequiredFieldValidator>
                                                                                        <asp:RequiredFieldValidator ID="ffvStateNew2" runat="server" SkinID="Validator" EnableViewState="True" ErrorMessage="Please select a state." Display="Dynamic" ControlToValidate="ddlStateNew" InitialValue="-1" ValidationGroup="inspections"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvTypeNew" runat="server" SkinID="Validator" EnableViewState="True" ErrorMessage="Please select a type." Display="Dynamic" ControlToValidate="ddlTypeNew" InitialValue="" ValidationGroup="inspections"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:CompareValidator ID="cvRepairCostNew" runat="server" ControlToValidate="tbxRepairCostNew" Display="Dynamic"
                                                                                            EnableViewState="True" ErrorMessage="Invalid data. (use #.## format)" Operator="DataTypeCheck"
                                                                                            SkinID="Validator" Type="Currency" ValidationGroup="inspections"></asp:CompareValidator>
                                                                                    </td>
                                                                                    <td></td>
                                                                                </tr>                                                       
                                                                                <tr>
                                                                                    <td style="height:7px"></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                </tr>                                                                
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td colspan="6">
                                                                                        <asp:Label ID="lblNotesNew" runat="server" Text="Notes" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td colspan="6">
                                                                                        <asp:TextBox ID="tbxNotesNew" runat="server" EnableViewState="True" Rows="4" SkinID="TextBox" Style="width: 632px" Text='<%# Eval("Notes") %>' TextMode="MultiLine"></asp:TextBox>
                                                                                    </td>
                                                                                    <td></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height:7px"></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                </tr>                                                                
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td colspan="6">
                                                                                        <asp:Label ID="lblInspectedByNew" runat="server" Text="Inspected By" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td colspan="6">
                                                                                        <asp:TextBox ID="tbxInspectedByNew" runat="server" EnableViewState="True" SkinID="TextBox" Style="width: 632px" Text='<%# Eval("InspectedBy") %>' ></asp:TextBox>
                                                                                    </td>
                                                                                    <td></td>
                                                                                </tr>                                                                
                                                                                <tr>
                                                                                    <td style="height: 30px"></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                    <td></td>
                                                                                </tr>                                                                
                                                                            </table>                                                  
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    
                                                                    <asp:TemplateField>
                                                                            <EditItemTemplate>
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 50%">
                                                                                                <asp:ImageButton ID="ibtnAccept" ToolTip="Accept" runat="server" SkinID="GridView_Update" ImageUrl="./../../App_Themes/LFS2/images/gridview/update.png"
                                                                                                    CommandName="Update"></asp:ImageButton>
                                                                                            </td>
                                                                                            <td style="width: 50%">
                                                                                                <asp:ImageButton ID="ibtnCancel" ToolTip="Cancel" runat="server" SkinID="GridView_Cancel" ImageUrl="./../../App_Themes/LFS2/images/gridview/cancel.png"
                                                                                                    CommandName="Cancel"></asp:ImageButton>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>                                                            
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="height: 12px">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:ImageButton ID="ibtnAdd" ToolTip="Add" runat="server" SkinID="GridView_Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png"
                                                                                                    CommandName="Add"></asp:ImageButton>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>                                                            
                                                                            </FooterTemplate>
                                                                            <ItemTemplate>
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 50%">
                                                                                                <asp:ImageButton ID="ibtnEdit" ToolTip="Edit" runat="server" SkinID="GridView_Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png"
                                                                                                    CommandName="Edit"></asp:ImageButton>
                                                                                            </td>
                                                                                            <td style="width: 50%">
                                                                                                <asp:ImageButton ID="ibtnDelete" ToolTip="Delete" runat="server" SkinID="GridView_Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png"
                                                                                                    CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this inspection?");'>
                                                                                                </asp:ImageButton>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>                                                            
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="40px"></HeaderStyle>
                                                                        </asp:TemplateField>
                                                                    
                                                                   </Columns>
                                                                </asp:GridView> 
                                                            </contenttemplate>
                                                        </asp:UpdatePanel>
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
                                            
                                            <!-- Table element: 1 columns - Qualification information title -->
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblQualificationInformation" runat="server" SkinID="LabelTitle1" Text="Qualification Information"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 10px">
                                                    </td>
                                                </tr>
                                            </table>
                                            
                                             <!-- Table element: 4 columns  -->
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblQualifiedDate" runat="server" SkinID="Label" Text="Qualified Date"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNotQualifiedDate" runat="server" SkinID="Label" Text="Not Qualified Date"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>                                            
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <telerik:RadDatePicker ID="tkrdpQualifiedDate" runat="server" Width="167px" SkinID="RadDatePicker">
                                                            <Calendar DayNameFormat="Short" ShowRowHeaders="False" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                            </Calendar>
                                                        </telerik:RadDatePicker>
                                                    </td>
                                                    <td>
                                                        <telerik:RadDatePicker ID="tkrdpNotQualifiedDate" runat="server" Width="167px" SkinID="RadDatePicker">
                                                            <Calendar DayNameFormat="Short" ShowRowHeaders="False" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                            </Calendar>
                                                        </telerik:RadDatePicker>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px"></td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblIfNotQualifiedExplain" runat="server" SkinID="Label" Text="If Not Qualified Explain"></asp:Label>
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
                                                        <asp:TextBox ID="tbxIfNotQualifiedExplain" runat="server" SkinID="TextBox" Rows="4" TextMode="MultiLine" Style="width: 700px"></asp:TextBox>
                                                    </td>  
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
                                    <asp:UpdatePanel ID="upnlInspectionSummary" UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                <tr>
                                                    <td style="width: 142px; height: 10px;">
                                                    </td>
                                                    <td style="width: 142px">
                                                    </td>
                                                    <td style="width: 142px">
                                                    </td>
                                                    <td style="width: 142px">
                                                    </td>
                                                    <td style="width: 142px">
                                                    </td>
                                                </tr>              
                                                <tr>
                                                    <td colspan="5">                                 
                                                        <!-- Page element: 1 column - Grid Inspections -->
                                                        <asp:GridView id="grdInspectionsSummary" runat="server" SkinID="GridViewInTabs" PageSize="2" 
                                                        DataSourceID="odsInspectionsSummary" OnDataBound="grdInspectionsSummary_DataBound"                                                
                                                        AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="InspectionID" width="700px" >
                                                        <Columns> 
                                                                                                            
                                                            <asp:TemplateField HeaderText="InspectionID" SortExpression="InspectionID" Visible="False">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblInspectionId" runat="server" Text='<%# Eval("InspectionID") %>'></asp:Label>
                                                                </ItemTemplate>                                                        
                                                            </asp:TemplateField>
                                                                                                           
                                                            <asp:TemplateField HeaderText="Inspections" SortExpression="InspectionID">
                                                                <HeaderStyle Width="660px" />                                                        
                                                                <ItemTemplate>
                                                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 660px">
                                                                        <tr>
                                                                            <td style="width: 10px; height: 10px"></td>
                                                                            <td style="width: 107px"></td>
                                                                            <td style="width: 107px"></td>
                                                                            <td style="width: 107px"></td>
                                                                            <td style="width: 107px"></td>
                                                                            <td style="width: 107px"></td>
                                                                            <td style="width: 107px"></td>
                                                                            <td style="width: 8px"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td></td>
                                                                            <td>
                                                                                <asp:Label ID="lblInspectionDate" runat="server" Text="Inspection Date" SkinID="Label"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblCountry" runat="server" Text="Country" SkinID="Label"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblState" runat="server" Text="State" SkinID="Label"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label id="lblType" runat="server" Text="Type" SkinID="Label"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblResult" runat="server" Text="Result" SkinID="Label"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblRepairCost" runat="server" Text="Repair Cost" SkinID="Label"></asp:Label>
                                                                            </td>                                                                    
                                                                            <td></td>
                                                                        </tr>    
                                                                        <tr>
                                                                            <td></td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxInspectionDate" runat="server" Width="97px" Text='<%# Eval("Date_", "{0:d}") %>' SkinID="TextBoxReadOnly" ReadOnly="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxCountry" runat="server" Width="97px" Text='<%# GetCountry(Eval("Country")) %>' SkinID="TextBoxReadOnly" ReadOnly="true"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxState" runat="server" Width="97px" Text='<%# GetState(Eval("State")) %>' SkinID="TextBoxReadOnly" ReadOnly="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxType" runat="server" Width="97px" Text='<%# Eval("Type") %>' SkinID="TextBoxReadOnly" ReadOnly="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxResult" runat="server" Width="97px" Text='<%# Eval("Result") %>' SkinID="TextBoxReadOnly" ReadOnly="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxRepairCost" runat="server" Width="97px" Text='<%# Eval("Cost", "{0:f2}") %>' SkinID="TextBoxReadOnly" ReadOnly="True"></asp:TextBox>
                                                                            </td>                                                                    
                                                                            <td></td>
                                                                        </tr>                                                       
                                                                        <tr>
                                                                            <td style="height:7px"></td>
                                                                            <td></td>
                                                                            <td></td>
                                                                            <td></td>
                                                                            <td></td>
                                                                            <td></td>
                                                                            <td></td>
                                                                            <td></td>
                                                                        </tr>                                                                
                                                                        <tr>
                                                                            <td></td>
                                                                            <td colspan="6">
                                                                                <asp:Label ID="lblNotes" runat="server" Text="Notes" SkinID="Label"></asp:Label>
                                                                            </td>
                                                                            <td></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td></td>
                                                                            <td colspan="6">
                                                                                <asp:TextBox ID="tbxNotes" runat="server" EnableViewState="True" ReadOnly="True"
                                                                                Rows="4" SkinID="TextBoxReadOnly" Style="width: 632px" Text='<%# Eval("Notes") %>'  TextMode="MultiLine"></asp:TextBox>
                                                                            </td>
                                                                            <td></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height:7px"></td>
                                                                            <td></td>
                                                                            <td></td>
                                                                            <td></td>
                                                                            <td></td>
                                                                            <td></td>
                                                                            <td></td>
                                                                            <td></td>
                                                                        </tr>                                                                
                                                                        <tr>
                                                                            <td></td>
                                                                            <td colspan="6">
                                                                                <asp:Label ID="lblInspectedBy" runat="server" Text="Inspected By" SkinID="Label"></asp:Label>
                                                                            </td>
                                                                            <td></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td></td>
                                                                            <td colspan="6">
                                                                                <asp:TextBox ID="tbxInspectedBy" runat="server" EnableViewState="True" ReadOnly="True"
                                                                                SkinID="TextBoxReadOnly" Style="width: 632px" Text='<%# Eval("InspectedBy") %>' ></asp:TextBox>
                                                                            </td>
                                                                            <td></td>
                                                                        </tr>                                                                
                                                                        <tr>
                                                                            <td style="height: 30px"></td>
                                                                            <td></td>
                                                                            <td></td>
                                                                            <td></td>
                                                                            <td></td>
                                                                            <td></td>
                                                                            <td></td>
                                                                            <td></td>
                                                                        </tr>                                                                
                                                                    </table>                                                        
                                                                </ItemTemplate>                                                        
                                                            </asp:TemplateField>
                                                            
                                                           </Columns>
                                                        </asp:GridView>
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
                                            
                                            <!-- Table element: 1 columns - Qualification information title -->
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblQualificationInformationSummary" runat="server" SkinID="LabelTitle1" Text="Qualification Information"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 10px">
                                                    </td>
                                                </tr>
                                            </table>
                                            
                                             <!-- Table element: 4 columns  -->
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                    <td style="width: 177px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblQuealifiedDateSummary" runat="server" SkinID="Label" Text="Qualified Date"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNotQualifiedDateSummary" runat="server" SkinID="Label" Text="Not Qualified Date"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>                                            
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="tbxQualifiedDateSummary" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="tbxNotQualifiedDateSummary" runat="server" SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 167px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td> 
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px" colspan="4">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblIfNotQualifiedExplainSummary" runat="server" SkinID="Label" Text="If Not Qualified Explain"></asp:Label>
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
                                                        <asp:TextBox ID="tbxIfNotQualifiedExplainSummary" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Rows="4" TextMode="MultiLine" Style="width: 700px"></asp:TextBox>
                                                    </td>  
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    
                                    <!-- Table element: 4 columns - Bottom space -->                                    
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 30px">
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>                                    
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpCosts" runat="server" HeaderText="Costs" OnClientClick="tpCostsClientClick">
                            <ContentTemplate>
                                <div style="width: 710px">
                                
                                    <asp:UpdatePanel ID="upnlCostsEdit" UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>
                                            <!-- Table element: 1 column  -->
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width: 700px; height: 10px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblCostHistory" runat="server" SkinID="Label" Text="Cost History"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="upCosts" runat="server">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="grdCosts" runat="server" AllowPaging="True" ShowFooter="True" OnRowCommand="grdCosts_RowCommand" 
                                                                    OnRowUpdating="grdCosts_RowUpdating" OnRowDeleting="grdCosts_RowDeleting" OnRowEditing="grdCosts_RowEditing"
                                                                    AutoGenerateColumns="False" DataKeyNames="CostID" DataMember="DefaultView" OnRowDataBound="grdCosts_RowDataBound" 
                                                                    DataSourceID="odsCosts" OnDataBound="grdCosts_DataBound" PageSize="13" 
                                                                    SkinID="GridViewInTabs" Width="450px">
                                                                    <Columns>
                                                                        <asp:TemplateField ShowHeader="False">
                                                                            <HeaderStyle Width="30px" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="cbxSelected" runat="server" AutoPostBack="True"
                                                                                    OnCheckedChanged="cbxSelectedCost_CheckedChanged" Width="25px" />
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="Date">
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                            <HeaderStyle Width="100px" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDate" runat="server" SkinID="Label" Text='<%# Bind("Date", "{0:d}") %>'
                                                                                    Style="width: 100px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <telerik:RadDatePicker ID="tkrdpDateEdit" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "Date") %>' Calendar-ShowRowHeaders="false"
                                                                                                Calendar-DayNameFormat="Short">
                                                                                            </telerik:RadDatePicker>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="rfvDateEdit" runat="server" ControlToValidate="tkrdpDateEdit"
                                                                                                Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator" ValidationGroup="EditCost">
                                                                                            </asp:RequiredFieldValidator>
                                                                                            <asp:CustomValidator ID="cvEditDate" runat="server" SkinID="Validator" Display="Dynamic"
                                                                                                ValidationGroup="EditCost" ControlToValidate="tkrdpDateEdit" ErrorMessage="You cannot add cost in that date."
                                                                                                OnServerValidate="cvEditDate_ServerValidate" ValidateEmptyText="True">
                                                                                            </asp:CustomValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <telerik:RadDatePicker ID="tkrdpDateNew" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "Date") %>' Calendar-ShowRowHeaders="false"
                                                                                                Calendar-DayNameFormat="Short">
                                                                                            </telerik:RadDatePicker>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="rfvDateNew" runat="server" ControlToValidate="tkrdpDateNew" InitialValue=""
                                                                                                Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator" ValidationGroup="AddCost">
                                                                                            </asp:RequiredFieldValidator>
                                                                                            <asp:CustomValidator ID="cvAddDate" runat="server" SkinID="Validator" Display="Dynamic"
                                                                                                ValidationGroup="AddCost" ControlToValidate="tkrdpDateNew" ErrorMessage="You cannot add cost in that date."
                                                                                                OnServerValidate="cvAddDate_ServerValidate" ValidateEmptyText="True">
                                                                                            </asp:CustomValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="Unit of Measurement">
                                                                            <HeaderStyle Width="70px" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblUnitOfMeasurement" runat="server" SkinID="Label" 
                                                                                    Text='<%# Bind("UnitOfMeasurement") %>' Style="width: 70px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                 <asp:DropDownList ID="ddlUnitOfMeasurementUnitsEdit" runat="server" 
                                                                                    DataSourceID="odsUnitsOfMeasurementUnits" DataTextField="Description" 
                                                                                    DataValueField="Description" EnableViewState="True" SkinID="DropDownListLookup" 
                                                                                    Width="70px">
                                                                                </asp:DropDownList>                                                                         
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>                                                                       
                                                                                <asp:DropDownList ID="ddlUnitOfMeasurementUnitsNew" runat="server" 
                                                                                    DataSourceID="odsUnitsOfMeasurementUnits" DataTextField="Description" 
                                                                                    DataValueField="Description" EnableViewState="True" SkinID="DropDownListLookup" 
                                                                                    Width="70px">
                                                                                </asp:DropDownList>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="Cost (CAD)">
                                                                            <HeaderStyle Width="80px" />
                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCostCad" runat="server" SkinID="Label" Text='<%# GetRound(Eval("CostCad"),2) %>'
                                                                                    Style="width: 80px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:TextBox Style="width: 80px" ID="tbxCostCadEdit" runat="server" SkinID="TextBox"
                                                                                                Text='<%# GetRound(Eval("CostCad"),2) %>'></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="rfvCostCadEdit" runat="server" ControlToValidate="tbxCostCadEdit"
                                                                                                ValidationGroup="EditCost" Display="Dynamic" ErrorMessage="Please provide a cost."
                                                                                                SkinID="Validator">
                                                                                            </asp:RequiredFieldValidator>
                                                                                            <asp:CompareValidator ID="cvCostCadEdit" runat="server" ControlToValidate="tbxCostCadEdit"
                                                                                                Display="Dynamic" ValidationGroup="EditCost" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                            </asp:CompareValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:TextBox Style="width: 80px" ID="tbxCostCadNew" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="rfvCostCadNew" runat="server" ControlToValidate="tbxCostCadNew"
                                                                                                ValidationGroup="AddCost" Display="Dynamic" ErrorMessage="Please provide a cost."
                                                                                                SkinID="Validator">
                                                                                            </asp:RequiredFieldValidator>
                                                                                            <asp:CompareValidator ID="cvCostCadNew" runat="server" ControlToValidate="tbxCostCadNew"
                                                                                                Display="Dynamic" ValidationGroup="AddCost" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                            </asp:CompareValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="Cost (USD)">
                                                                            <HeaderStyle Width="80px" />
                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCostUsd" runat="server" SkinID="Label" Text='<%# GetRound(Eval("CostUsd"),2) %>'
                                                                                    Style="width: 80px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:TextBox Style="width: 80px" ID="tbxCostUsdEdit" runat="server" SkinID="TextBox"
                                                                                                Text='<%# GetRound(Eval("CostUsd"),2) %>'></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="rfvCostUsdEdit" runat="server" ControlToValidate="tbxCostUsdEdit"
                                                                                                ValidationGroup="EditCost" Display="Dynamic" ErrorMessage="Please provide a cost."
                                                                                                SkinID="Validator">
                                                                                            </asp:RequiredFieldValidator>
                                                                                            <asp:CompareValidator ID="cvCostUsdEdit" runat="server" ControlToValidate="tbxCostUsdEdit"
                                                                                                Display="Dynamic" ValidationGroup="EditCost" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                            </asp:CompareValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:TextBox Style="width: 80px" ID="tbxCostUsdNew" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="rfvCostUsdNew" runat="server" ControlToValidate="tbxCostUsdNew"
                                                                                                ValidationGroup="AddCost" Display="Dynamic" ErrorMessage="Please provide a cost."
                                                                                                SkinID="Validator">
                                                                                            </asp:RequiredFieldValidator>
                                                                                            <asp:CompareValidator ID="cvCostUsdNew" runat="server" ControlToValidate="tbxCostUsdNew"
                                                                                                Display="Dynamic" ValidationGroup="AddCost" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                            </asp:CompareValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </FooterTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="CostID" Visible="false">
                                                                            <HeaderStyle Width="0px" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCostID" runat="server" SkinID="Label" 
                                                                                    Text='<%# Bind("CostID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblCostIDEdit" runat="server" SkinID="Label" 
                                                                                    Text='<%# Bind("CostID") %>'></asp:Label>
                                                                            </EditItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <%--Buttons--%>
                                                                        <asp:TemplateField>
                                                                            <EditItemTemplate>
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 50%">
                                                                                                <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" __designer:wfdid="w78"
                                                                                                    CommandName="Update" ToolTip="Update" ImageUrl="./../../App_Themes/LFS2/images/gridview/update.png">
                                                                                                </asp:ImageButton>
                                                                                            </td>
                                                                                            <td style="width: 50%">
                                                                                                <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" __designer:wfdid="w79"
                                                                                                    CommandName="Cancel" ToolTip="Cancel" ImageUrl="./../../App_Themes/LFS2/images/gridview/cancel.png">
                                                                                                </asp:ImageButton>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="height: 12px">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" __designer:wfdid="w80"
                                                                                                    CommandName="Add" ToolTip="Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png">
                                                                                                </asp:ImageButton>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </FooterTemplate>
                                                                            <HeaderStyle Width="60px"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 50%">
                                                                                                <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" __designer:wfdid="w76"
                                                                                                    CommandName="Edit" ToolTip="Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png">
                                                                                                </asp:ImageButton>
                                                                                            </td>
                                                                                            <td style="width: 50%">
                                                                                                <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" __designer:wfdid="w77"
                                                                                                    CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this cost?");'
                                                                                                    ToolTip="Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png">
                                                                                                </asp:ImageButton>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 10px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblCostExceptions" runat="server" SkinID="Label" Text="Cost Exceptions"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td >
                                                        <asp:UpdatePanel ID="upCostsExceptions" runat="server">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="grdCostsExceptions" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="CostID,RefID" DataMember="DefaultView" 
                                                                    DataSourceID="odsCostsExceptions" ShowFooter="True" OnRowCommand="grdCostsExceptions_RowCommand" OnRowUpdating="grdCostsExceptions_RowUpdating" OnRowDeleting="grdCostsExceptions_RowDeleting"
                                                                    OnRowEditing = "grdCostsExceptions_RowEditing" OnDataBound="grdCostsExceptions_DataBound" OnRowDataBound="grdCostsExceptions_RowDataBound" PageSize="13" SkinID="GridViewInTabs">
                                                                    <Columns>
                                                                    
                                                                        <asp:TemplateField HeaderText="Type of Work">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExceptionWork" runat="server" SkinID="Label" Style="width: 100px"
                                                                                    Text='<%# Bind("Work_") %>' Width="100px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:DropDownList Style="width: 100px" ID="ddlExceptionWorkEdit" runat="server" SkinID="DropDownList"
                                                                                                DataSourceID="odsWork_" DataTextField="Work_" DataValueField="Work_">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="rfvExceptionWorkEdit" runat="server" ControlToValidate="ddlExceptionWorkEdit"
                                                                                                Display="Dynamic" ErrorMessage="Please provide a type of work" SkinID="Validator"
                                                                                                InitialValue="(Select)" ValidationGroup="EditCostException">
                                                                                            </asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:DropDownList Style="width: 100px" ID="ddlExceptionWorkNew" runat="server" SkinID="DropDownList"
                                                                                                DataSourceID="odsWork_" DataTextField="Work_" DataValueField="Work_">
                                                                                            </asp:DropDownList>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="rfvExceptionWorkNew" runat="server" ControlToValidate="ddlExceptionWorkNew"
                                                                                                Display="Dynamic" ErrorMessage="Please provide a type of work" SkinID="Validator"
                                                                                                InitialValue="(Select)" ValidationGroup="AddCostException">
                                                                                            </asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </FooterTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="Unit of Measurement">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExceptionUnitOfMeasurement" runat="server" SkinID="Label" 
                                                                                    Style="width: 70px" Text='<%# Bind("UnitOfMeasurement") %>' Width="70px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                 <asp:DropDownList ID="ddlExceptionUnitOfMeasurementUnitsEdit" runat="server" 
                                                                                    DataSourceID="odsUnitsOfMeasurementUnits" DataTextField="Description" 
                                                                                    DataValueField="Description" EnableViewState="True" SkinID="DropDownListLookup" 
                                                                                    Width="70px">
                                                                                </asp:DropDownList>
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <asp:DropDownList ID="ddlExceptionUnitOfMeasurementUnitsNew" runat="server" 
                                                                                    DataSourceID="odsUnitsOfMeasurementUnits" DataTextField="Description" 
                                                                                    DataValueField="Description" EnableViewState="True" SkinID="DropDownListLookup" 
                                                                                    Width="70px">
                                                                                </asp:DropDownList>
                                                                            </FooterTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                            <HeaderStyle Width="70px" />
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="Cost (CAD)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExceptionCostCad" runat="server" SkinID="Label" Style="width: 80px"
                                                                                    Text='<%# GetRound(Eval("CostCad"),2) %>' Width="80px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:TextBox Style="width: 80px" ID="tbxExceptionCostCadEdit" runat="server" SkinID="TextBox"
                                                                                                Text='<%# GetRound(Eval("CostCad"),2) %>'></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="rfvExceptionCostCadEdit" runat="server" ControlToValidate="tbxExceptionCostCadEdit"
                                                                                                ValidationGroup="EditCostException" Display="Dynamic" ErrorMessage="Please provide a cost."
                                                                                                SkinID="Validator">
                                                                                            </asp:RequiredFieldValidator>
                                                                                            <asp:CompareValidator ID="cvExceptionCostCadEdit" runat="server" ControlToValidate="tbxExceptionCostCadEdit"
                                                                                                Display="Dynamic" ValidationGroup="EditCostException" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                            </asp:CompareValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:TextBox Style="width: 80px" ID="tbxExceptionCostCadNew" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="rfvExceptionCostCadNew" runat="server" ControlToValidate="tbxExceptionCostCadNew"
                                                                                                ValidationGroup="AddCostException" Display="Dynamic" ErrorMessage="Please provide a cost."
                                                                                                SkinID="Validator">
                                                                                            </asp:RequiredFieldValidator>
                                                                                            <asp:CompareValidator ID="cvExceptionCostCadNew" runat="server" ControlToValidate="tbxExceptionCostCadNew"
                                                                                                Display="Dynamic" ValidationGroup="AddCostException" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                            </asp:CompareValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </FooterTemplate>
                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                            <HeaderStyle Width="80px" />
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="Cost (USD)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExceptionCostUSD" runat="server" SkinID="Label" Style="width: 80px"
                                                                                    Text='<%# GetRound(Eval("CostUsd"),2) %>' Width="80px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:TextBox Style="width: 80px" ID="tbxExceptionCostUsdEdit" runat="server" SkinID="TextBox"
                                                                                                Text='<%# GetRound(Eval("CostUsd"),2) %>'></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="rfvExceptionCostUsdEdit" runat="server" ControlToValidate="tbxExceptionCostUsdEdit"
                                                                                                ValidationGroup="EditCostException" Display="Dynamic" ErrorMessage="Please provide a cost."
                                                                                                SkinID="Validator">
                                                                                            </asp:RequiredFieldValidator>
                                                                                            <asp:CompareValidator ID="cvExceptionCostUsdEdit" runat="server" ControlToValidate="tbxExceptionCostUsdEdit"
                                                                                                Display="Dynamic" ValidationGroup="EditCostException" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                            </asp:CompareValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <table>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:TextBox Style="width: 80px" ID="tbxExceptionCostUsdNew" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="rfvExceptionCostUsdNew" runat="server" ControlToValidate="tbxExceptionCostUsdNew"
                                                                                                ValidationGroup="AddCostException" Display="Dynamic" ErrorMessage="Please provide a cost."
                                                                                                SkinID="Validator">
                                                                                            </asp:RequiredFieldValidator>
                                                                                            <asp:CompareValidator ID="cvExceptionCostUsdNew" runat="server" ControlToValidate="tbxExceptionCostUsdNew"
                                                                                                Display="Dynamic" ValidationGroup="AddCostException" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                            </asp:CompareValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </FooterTemplate>
                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                            <HeaderStyle Width="80px" />
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="CostID" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExceptionCostID" runat="server" SkinID="Label" 
                                                                                    Text='<%# Bind("CostID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblExceptionCostIDEdit" runat="server" SkinID="Label" 
                                                                                    Text='<%# Bind("CostID") %>'></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <HeaderStyle Width="0px" />
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="RefID" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExceptionRefID" runat="server" SkinID="Label" 
                                                                                    Text='<%# Bind("RefID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblExceptionRefIDEdit" runat="server" SkinID="Label" 
                                                                                    Text='<%# Bind("RefID") %>'></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <HeaderStyle Width="0px" />
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="Work_" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExceptionWork_" runat="server" SkinID="Label" 
                                                                                    Text='<%# Bind("Work_") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <EditItemTemplate>
                                                                                <asp:Label ID="lblExceptionWork_Edit" runat="server" SkinID="Label" 
                                                                                    Text='<%# Bind("Work_") %>'></asp:Label>
                                                                            </EditItemTemplate>
                                                                            <HeaderStyle Width="0px" />
                                                                        </asp:TemplateField>                                                                                                                              
                                                                        
                                                                        <%--Buttons--%>
                                                                        <asp:TemplateField>
                                                                            <EditItemTemplate>
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 50%">
                                                                                                <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" __designer:wfdid="w78"
                                                                                                    CommandName="Update" ToolTip="Update" ImageUrl="./../../App_Themes/LFS2/images/gridview/update.png">
                                                                                                </asp:ImageButton>
                                                                                            </td>
                                                                                            <td style="width: 50%">
                                                                                                <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" __designer:wfdid="w79"
                                                                                                    CommandName="Cancel" ToolTip="Cancel" ImageUrl="./../../App_Themes/LFS2/images/gridview/cancel.png">
                                                                                                </asp:ImageButton>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="height: 12px">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                                <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" __designer:wfdid="w80"
                                                                                                    CommandName="Add" ToolTip="Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png">
                                                                                                </asp:ImageButton>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </FooterTemplate>
                                                                            <HeaderStyle Width="60px"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 50%">
                                                                                                <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" __designer:wfdid="w76"
                                                                                                    CommandName="Edit" ToolTip="Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png">
                                                                                                </asp:ImageButton>
                                                                                            </td>
                                                                                            <td style="width: 50%">
                                                                                                <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" __designer:wfdid="w77"
                                                                                                    CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this exception?");'
                                                                                                    ToolTip="Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png">
                                                                                                </asp:ImageButton>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>                                        
                                            </table>
                                        </ContentTemplate>                                        
                                    </asp:UpdatePanel>
                                    
                                        
                                        
                                    <asp:UpdatePanel ID="upnlCostsSummary" UpdateMode="Conditional" runat="server">
                                        <ContentTemplate>
                                            <!-- Table element: 1 column  -->
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width: 700px; height: 10px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblCostHistorySummary" runat="server" SkinID="Label" Text="Cost History"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="upnlCostHistorySummary" runat="server">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="grdCostsSummary" runat="server" AllowPaging="True" 
                                                                    AutoGenerateColumns="False" DataKeyNames="CostID" DataMember="DefaultView" 
                                                                    DataSourceID="odsCostsSummary" OnDataBound="grdCostsSummary_DataBound" PageSize="13" 
                                                                    SkinID="GridViewInTabs" Width="450px">
                                                                    <Columns>
                                                                        <asp:TemplateField ShowHeader="False">
                                                                            <HeaderStyle Width="30px" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                            <ItemTemplate>
                                                                                <asp:CheckBox ID="cbxSelected" runat="server" AutoPostBack="True"
                                                                                    OnCheckedChanged="cbxSelectedCostSummary_CheckedChanged" Width="25px" />
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="Date">
                                                                            <HeaderStyle Width="100px" />
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblDate" runat="server" SkinID="Label" 
                                                                                    Text='<%# Bind("Date", "{0:d}") %>' Width="100px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="Unit of Measurement">
                                                                            <HeaderStyle Width="70px" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblUnitOfMeasurement" runat="server" SkinID="Label" 
                                                                                    Text='<%# Bind("UnitOfMeasurement") %>' Width="70px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="Cost (CAD)">
                                                                            <HeaderStyle Width="80px" />
                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCostCad" runat="server" SkinID="Label" 
                                                                                    Text='<%# GetRound(Eval("CostCad"),2) %>' Width="80px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="Cost (USD)">
                                                                            <HeaderStyle Width="80px" />
                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCostUsd" runat="server" SkinID="Label" 
                                                                                    Text='<%# GetRound(Eval("CostUsd"),2) %>' Width="80px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="CostID" Visible="false">
                                                                            <HeaderStyle Width="0px" />
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCostID" runat="server" SkinID="Label" 
                                                                                    Text='<%# Bind("CostID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>                                            
                                                </tr>
                                                <tr>
                                                    <td style="height: 10px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblCostExceptionsSummary" runat="server" SkinID="Label" Text="Cost Exceptions"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:UpdatePanel ID="upnlCostExceptionsSummary" runat="server">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="grdCostsExceptionsSummary" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="CostID,RefID" 
                                                                    DataMember="DefaultView" DataSourceID="odsCostsExceptionsSummary" OnDataBound="grdCostsExceptionsSummary_DataBound" PageSize="13" SkinID="GridViewInTabs">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Type of Work">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExceptionWork" runat="server" SkinID="Label" 
                                                                                    Style="width: 200px" Text='<%# Bind("Work_") %>' Width="200px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                            <HeaderStyle Width="200px" />
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="Unit of Measurement">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExceptionUnitOfMeasurement" runat="server" SkinID="Label" 
                                                                                    Style="width: 90px" Text='<%# Bind("UnitOfMeasurement") %>' Width="90px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Left" />
                                                                            <HeaderStyle Width="90px" />
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="Cost (CAD)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExceptionCostCad" runat="server" SkinID="Label" 
                                                                                    Style="width: 75px" Text='<%# GetRound(Eval("CostCad"),2) %>' Width="75px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                            <HeaderStyle Width="75px" />
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="Cost (USD)">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExceptionCostUSD" runat="server" SkinID="Label" 
                                                                                    Style="width: 75px" Text='<%# GetRound(Eval("CostUsd"),2) %>' Width="75px"></asp:Label>
                                                                            </ItemTemplate>
                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                            <HeaderStyle Width="75px" />
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="CostID" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExceptionCostID" runat="server" SkinID="Label" 
                                                                                    Text='<%# Bind("CostID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="0px" />                                                                    
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField HeaderText="RefID" Visible="False">
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblExceptionRefID" runat="server" SkinID="Label" 
                                                                                    Text='<%# Bind("RefID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                            <HeaderStyle Width="0px" />
                                                                        </asp:TemplateField>
                                                                                                                                        
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>                                                
                                            </table>
                                        
                                        </ContentTemplate>                                        
                                    </asp:UpdatePanel>
                                    
                                    <!-- Table element: 4 columns - Bottom space -->                                    
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 30px">
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>    
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpNotesData" runat="server" HeaderText="Notes" OnClientClick="tpNotesDataClientClick">
                            <ContentTemplate>
                               <div style="width: 710px;">
                                
                                    <!-- Table element: 5 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 142px; height: 10px;">
                                            </td>
                                            <td style="width: 142px">
                                            </td>
                                            <td style="width: 142px">
                                            </td>
                                            <td style="width: 142px">
                                            </td>
                                            <td style="width: 142px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td rowspan="5" colspan="5">
                                                <asp:UpdatePanel id="upnlNotes" runat="server">
                                                    <contenttemplate>
                                                        <asp:GridView ID="grdNotes" runat="server" SkinID="GridViewInTabs" Width="700px" OnRowDataBound="grdNotes_RowDataBound"
                                                            ShowFooter="True" DataSourceID="odsNotes" OnDataBound="grdNotes_DataBound" OnRowEditing="grdNotes_RowEditing"
                                                            OnRowCommand="grdNotes_RowCommand" OnRowUpdating="grdNotes_RowUpdating" OnRowDeleting="grdNotes_RowDeleting"
                                                            AutoGenerateColumns="False" DataKeyNames="UnitID, RefID" __designer:wfdid="w96">
                                                            <Columns>
                                                                <asp:TemplateField SortExpression="UnitID" Visible="False" HeaderText="UnitID">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblUnitID" runat="server" Text='<%# Eval("UnitID") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblUnitID" runat="server" Text='<%# Eval("UnitID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField SortExpression="RefID" Visible="False" HeaderText="RefID">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblRefIDEdit" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRefID" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField Visible="False" HeaderText="FileName">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblFileNameEdit" runat="server" Text='<%# Eval("FILENAME") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblFileName" runat="server" Text='<%# Eval("FILENAME") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField Visible="False" HeaderText="LIBRARY_FILES_ID">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblLibraryFileIdEdit" runat="server" Text='<%# Eval("LIBRARY_FILES_ID") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblLibraryFileId" runat="server" Text='<%# Eval("LIBRARY_FILES_ID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField SortExpression="Subject" HeaderText="Information">
                                                                    <EditItemTemplate>
                                                                        <!-- Page element : 2 columns - Notes Information -->
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteSubjectEdit" runat="server" SkinID="Label" Text="Subject" EnableViewState="False"
                                                                                            __designer:wfdid="w135"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteSubjectEdit" runat="server" SkinID="TextBox"
                                                                                            Text='<%# Eval("Subject") %>' EnableViewState="True" __designer:wfdid="w136"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvNoteSubjectEdit" runat="server" SkinID="Validator"
                                                                                            EnableViewState="False" ValidationGroup="notesDataEdit" ErrorMessage="Please provide a subject."
                                                                                            Display="Dynamic" ControlToValidate="tbxNoteSubjectEdit" __designer:wfdid="w137"></asp:RequiredFieldValidator>
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
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteDateEdit" runat="server" SkinID="Label" Text="Date" EnableViewState="False"
                                                                                            __designer:wfdid="w138"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteCreatedByEdit" runat="server" SkinID="Label" Text="Created By"
                                                                                            EnableViewState="False" __designer:wfdid="w139"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="width: 145px" ID="tbxNoteDateEdit" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# Eval("DateTime_") %>' EnableViewState="True" ReadOnly="True" __designer:wfdid="w140"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="width: 145px" ID="tbxNoteCreatedByEdit" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# GetNoteCreatedBy(Eval("UserID")) %>' EnableViewState="True" ReadOnly="True"
                                                                                            __designer:wfdid="w141"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px">
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <!-- Page element : 3 columns - Notes Information -->
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteSubjectNew" runat="server" SkinID="Label" Text="Subject" EnableViewState="False"
                                                                                            __designer:wfdid="w142"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteSubjectNew" runat="server" SkinID="TextBox"
                                                                                            Text='<%# Eval("Subject") %>' EnableViewState="True" __designer:wfdid="w143"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvNoteSubjectNew" runat="server" SkinID="Validator"
                                                                                            EnableViewState="False" ValidationGroup="notesDataAdd" ErrorMessage="Please provide a subject"
                                                                                            Display="Dynamic" ControlToValidate="tbxNoteSubjectNew" __designer:wfdid="w144"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px">
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    
                                                                    <HeaderStyle Width="320px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <!-- Page element : 3 columns - Notes Information -->
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteSubject" runat="server" SkinID="Label" Text="Subject" EnableViewState="False"
                                                                                            __designer:wfdid="w129"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteSubject" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# Eval("Subject") %>' EnableViewState="True" ReadOnly="True" __designer:wfdid="w130"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px">
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteDate" runat="server" SkinID="Label" Text="Date" EnableViewState="False"
                                                                                            __designer:wfdid="w131"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteCreatedBy" runat="server" SkinID="Label" Text="Created By"
                                                                                            EnableViewState="False" __designer:wfdid="w132"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="width: 145px" ID="tbxNoteDate" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# Eval("DateTime_") %>' EnableViewState="True" ReadOnly="True" __designer:wfdid="w133"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="width: 145px" ID="tbxNoteCreatedBy" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# GetNoteCreatedBy(Eval("UserID")) %>' EnableViewState="True" ReadOnly="True"
                                                                                            __designer:wfdid="w134"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px">
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField SortExpression="NoteAttachment" HeaderText="Note &amp; Attachment">
                                                                    <EditItemTemplate>
                                                                        <!-- Page element : 3 columns - Notes information -->
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 220px">
                                                                                    </td>
                                                                                    <td style="width: 90px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteNoteEdit" runat="server" SkinID="Label" Text="Note" EnableViewState="False"
                                                                                            __designer:wfdid="w123"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteNoteEdit" runat="server" SkinID="TextBox"
                                                                                            Text='<%# Eval("Note") %>' EnableViewState="True" TextMode="MultiLine" Rows="4"
                                                                                            __designer:wfdid="w124"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvNoteNoteEdit" runat="server" SkinID="Validator"
                                                                                            EnableViewState="False" ValidationGroup="notesDataEdit" ErrorMessage="Please provide a note."
                                                                                            Display="Dynamic" ControlToValidate="tbxNoteNoteEdit" __designer:wfdid="w125"></asp:RequiredFieldValidator>
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
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteAttachmentEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                                            Text="Attachment"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td style="vertical-align: top;">
                                                                                        <asp:TextBox ID="tbxNoteAttachmentEdit" runat="server" Rows="1" SkinID="TextBoxReadOnly"
                                                                                            Style="width: 210px" Text='<%# Eval("ORIGINAL_FILENAME") %>' Width="220px" ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Button ID="btnNoteDeleteEdit" CommandName="DeleteAttachmentEdit" CommandArgument='<%# Eval("RefID") %>'
                                                                                            Width="80px" runat="server" SkinID="Button" Text="Delete" />
                                                                                        <asp:Button ID="btnNoteAddEdit" CommandName="AddAttachmentEdit" CommandArgument='<%# Eval("RefID") %>'
                                                                                            Width="80px" runat="server" SkinID="Button" Text="Add" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px">
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <!-- Page element : 3 columns - Notes information -->
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 220px">
                                                                                    </td>
                                                                                    <td style="width: 90px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteNoteNew" runat="server" SkinID="Label" Text="Note" EnableViewState="False"
                                                                                            __designer:wfdid="w126"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteNoteNew" runat="server" SkinID="TextBox"
                                                                                            Text='<%# Eval("Note") %>' EnableViewState="True" Rows="1" __designer:wfdid="w127"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvNoteNoteNew" runat="server" SkinID="Validator"
                                                                                            EnableViewState="False" ValidationGroup="notesDataAdd" ErrorMessage="Please provide a note."
                                                                                            Display="Dynamic" ControlToValidate="tbxNoteNoteNew" __designer:wfdid="w128"></asp:RequiredFieldValidator>
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
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteAttachmentNew" runat="server" EnableViewState="False" SkinID="Label"
                                                                                            Text="Attachment"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxNoteAttachmentNew" runat="server" Rows="1" SkinID="TextBoxReadOnly"
                                                                                            Style="width: 210px" Text='<%# Eval("ORIGINAL_FILENAME") %>' ReadOnly="True"></asp:TextBox>
                                                                                        <asp:Label ID="lblFileNameNoteAttachmentNew" runat="server" SkinID="Label" Text='<%# Eval("FILENAME") %>'
                                                                                            Visible="False" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Button ID="btnAddFooter" Width="80px" runat="server" SkinID="Button" Text="Add"
                                                                                            TabIndex="4" CommandName="AddAttachmentAdd" CommandArgument='<%# Eval("RefID") %>' />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px">
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    <HeaderStyle Width="320px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <!-- Page element : 3 columns - Notes information -->
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 220px">
                                                                                    </td>
                                                                                    <td style="width: 90px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteNote" runat="server" SkinID="Label" Text="Note" EnableViewState="False"
                                                                                            __designer:wfdid="w121"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteNote" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# Eval("Note") %>' EnableViewState="True" ReadOnly="True" TextMode="MultiLine"
                                                                                            Rows="4" __designer:wfdid="w122"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px">
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteAttachment" runat="server" EnableViewState="False" SkinID="Label"
                                                                                            Text="Attachment"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxNoteAttachment" runat="server" Rows="1" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# Eval("ORIGINAL_FILENAME") %>' Width="210px" ReadOnly="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="vertical-align: top">
                                                                                        <asp:Button ID="btnNoteDownload" CommandName="DownloadAttachment" CommandArgument='<%# Eval("RefID") %>'
                                                                                            Width="80px" runat="server" SkinID="Button" Text="Download" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px">
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField>
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnAccept" ToolTip="Accept" runat="server" SkinID="GridView_Update"
                                                                                            ImageUrl="./../../App_Themes/LFS2/images/gridview/update.png" CommandName="Update">
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnCancel" ToolTip="Cancel" runat="server" SkinID="GridView_Cancel"
                                                                                            ImageUrl="./../../App_Themes/LFS2/images/gridview/cancel.png" CommandName="Cancel">
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="height: 12px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:ImageButton ID="ibtnAdd" ToolTip="Add" runat="server" SkinID="GridView_Add"
                                                                                            ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png" CommandName="Add">
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    
                                                                    <HeaderStyle Width="60px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnEdit" ToolTip="Edit" runat="server" SkinID="GridView_Edit"
                                                                                            ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png" CommandName="Edit">
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnDelete" ToolTip="Delete" runat="server" SkinID="GridView_Delete"
                                                                                            ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png" CommandName="Delete"
                                                                                            OnClientClick='return confirm("Are you sure you want to delete this note?");'>
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView> 
                                                    </contenttemplate>        
                                                </asp:UpdatePanel>
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
        
                                    <!-- Page element: Section title - Resource Centre -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblResourceCentre" runat="server" SkinID="LabelTitle1" Text="Resource Centre" EnableViewState="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                        </tr>
                                    </table>
        
                                    <!-- Table element: 5 columns - Resource Centre -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 620px">
                                                <asp:Label ID="lblCategoryAssociated" runat="server" Text="Associated Category" SkinID="Label" EnableViewState="False"></asp:Label>
                                            </td>
                                            <td style=" width: 90px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxCategoryAssocited" Width="610px" ReadOnly="True" runat="server" SkinID="TextBoxReadOnly"></asp:TextBox>
                                            </td>
                                            <td style=" width: 88px">
                                                <asp:Button ID="btnAssociate" runat="server" SkinID="Button" Text="Associate" OnClick="btnAssociate_Click" OnClientClick="return btnAssociateClick();" Width="80px" TabIndex="8" />
                                                <asp:Button ID="btnUnassociate" runat="server" SkinID="Button" Text="Unassociate" OnClick="btnUnassociate_Click" OnClientClick="return btnUnassociateClick();" Width="80px" TabIndex="9" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px">
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <!-- Table element: 6 columns - Bottom space -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 30px">
                                            </td>
                                            <td>
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
                                </div>
                            </ContentTemplate>
                            <HeaderTemplate>
                                Notes &amp; Attachment
                            </HeaderTemplate>
                        </cc1:TabPanel>
                                        
                    </cc1:TabContainer>
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
        
        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                <asp:ObjectDataSource ID="odsCosts" runat="server" FilterExpression="(Deleted = 0)"
                        SelectMethod="GetCostsNew" 
                        TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_edit"
                        DeleteMethod="DummyCostsNew" InsertMethod="DummyCostsNew" UpdateMethod="DummyCostsNew">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsCostsExceptions" runat="server"
                        SelectMethod="GetCostsExceptionsNew" 
                        TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_edit"
                        DeleteMethod="DummyCostsExceptionsNew" InsertMethod="DummyCostsExceptionsNew" UpdateMethod="DummyCostsExceptionsNew"
                        filterexpression="Deleted=0">            
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsCostsSummary" runat="server" SelectMethod="GetCostsNew" filterexpression="Deleted=0" 
                        TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_edit">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsCostsExceptionsSummary" runat="server" SelectMethod="GetCostsExceptionsNew" filterexpression="Deleted=0"
                        TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_edit">
                    </asp:ObjectDataSource>
                                                                    
                    <asp:ObjectDataSource ID="odsWork_" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTimeWorkList"
                        OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select)" Name="work" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsNumberOfAxes" runat="server" CacheDuration="120"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.FleetManagement.Units.UnitVehicleNumberOfAxesList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="" Name="numberOfAxes" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsFuelType" runat="server" CacheDuration="120"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.FleetManagement.Units.UnitVehicleFuelTypeList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="" Name="fuelType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsOwnerType" runat="server" CacheDuration="120"
                        EnableCaching="True" OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.FleetManagement.Units.UnitOwnerTypeList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="" Name="ownerType" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>                   
                                        
                    <asp:ObjectDataSource ID="odsInspections" runat="server" SelectMethod="GetInspectionsInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_edit" DeleteMethod="DummyInspectionsAddInspections"
                        FilterExpression="(Deleted = 0)" UpdateMethod="DummyInspectionsAddInspections" InsertMethod="DummyInspectionsAddInspections">                        
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsInspectionsSummary" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetInspectionsInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_edit">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsCountry" runat="server" CacheDuration="120"
                        EnableCaching="True" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Company.Organization.CountryList" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="countryId" Type="Int64" />
                            <asp:Parameter DefaultValue="(Select a country)" Name="name" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsNotes" runat="server"
                        FilterExpression="(Deleted = 0)" SelectMethod="GetNotesNew" TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_edit" DeleteMethod="DummyNotesNew" InsertMethod="DummyNotesNew" UpdateMethod="DummyNotesNew">
                    </asp:ObjectDataSource>      
                    
                    <asp:ObjectDataSource ID="odsUnitsOfMeasurementUnits" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemByModule" TypeName="LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement.UnitsOfMeasurementAssociationsToolAssociatedUnitsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="FM / Units" Name="module" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>              
                </td>
            </tr>
        </table>
                
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfActiveTab" runat="server" />
                    <asp:HiddenField ID="hdfUnitId" runat="server" />
                    <asp:HiddenField ID="hdfUnitType" runat="server" />
                    <asp:HiddenField ID="hdfUnitState" runat="server" />
                    <asp:HiddenField ID="hdfLoginId" runat="server" />
                    <asp:HiddenField ID="hdfLicenseStateId" runat="server" />
                </td>
            </tr>
        </table>        
    </div>
</asp:Content>