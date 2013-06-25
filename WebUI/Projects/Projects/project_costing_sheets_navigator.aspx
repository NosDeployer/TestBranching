<%@ Page Title="LFS Live" Language="C#" MasterPageFile="./../../mForm6.Master" AutoEventWireup="true" CodeBehind="project_costing_sheets_navigator.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Projects.Projects.project_costing_sheets_navigator" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblHeaderTitle" runat="server" Text="Project Costing Sheets" SkinID="LabelPageTitle1" EnableViewState="False"></asp:Label>
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
    <!-- LEFT MENU -->
    <div style="width: 190px;">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadPanelBar ID="tkrpbLeftMenuCurrentProject" runat="server" SkinID="RadPanelBar" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Current Project" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mProject" Text="Project"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mProjectCostingSheets" Text="Project Costing Sheets" Selected="true" PostBack="false" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSeparator" PostBack="false">
                                        <ItemTemplate>
                                            <table style="width: 170px;padding-left: 10px;" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td style="height: 1px" class="ASPxNavBar1_Separator">
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSections" Text="Sections"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSeparator" PostBack="false">
                                        <ItemTemplate>
                                            <table style="width: 170px;padding-left: 10px;" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td style="height: 1px" class="ASPxNavBar1_Separator">
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mProjectSynopsis" Text="Project Synopsis"></telerik:RadPanelItem>
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
                    <telerik:RadPanelBar ID="tkrpbLeftMenuProjects" runat="server" SkinID="RadPanelBar2" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Projects" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddProject" Text="Add Project"></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mDuplicateProposal" Text="Duplicate Proposal Tool" ></telerik:RadPanelItem>
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
                    <telerik:RadPanelBar ID="tkrpbLeftMenuReports" runat="server" SkinID="RadPanelBar2" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="False" Text="Reports" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mBallparkSummaryReport" Text="Ballpark Summary"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mTotalValueOfProposalsReport" Text="Total Value Of Proposals" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mCurrentActiveWorkOnHandReport" Text="Current Active Work On Hand" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mProjectsSummaryReport" Text="Projects Summary" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSeparator" PostBack="false">
                                        <ItemTemplate>
                                            <table style="width: 170px;padding-left: 10px;" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <td style="height: 1px" class="ASPxNavBar2_Separator">
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mProductionReport" Text="Production Report"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mVideoCompleteReport" Text="Video Complete Report"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mDetailedCostingSheetReport" Text="Detailed Costing Sheet"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mCombinedDetailedCostingSheetReport" Text="Combined Detailed Costing Sheet"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mConsolidatedCostingSheetReport" Text="Consolidated Costing Sheet"></telerik:RadPanelItem>
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
                    <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick" OnClientItemClicking="tkrmTopItemClicking">                        
                        <Items>
                            <telerik:RadMenuItem Value="mAddCostingSheet" Text="ADD COSTING SHEET" />
                            <telerik:RadMenuItem Value="mAddCombinedCostingSheet" Text="ADD COMBINED COSTING SHEET" />
                            <telerik:RadMenuItem Value="mLastSearch" Text="LAST SEARCH" />
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
        <!-- Page element: Results -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 750px">
            <tr>
                <td style="width: 625px">
                    <asp:CustomValidator ID="cvSelection" runat="server" ErrorMessage="Please select one costing sheet."
                        Display="Dynamic" SkinID="Validator">
                    </asp:CustomValidator>
                </td>
                <td style="width: 125px">
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCostingSheetsTitle" runat="server" EnableViewState="False" SkinID="LabelTitle1" Text="Costing Sheets"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTotalRows" runat="server" EnableViewState="False" SkinID="Label" Text="Total Rows"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top">
                    <asp:UpdatePanel id="upnlCostingSheets" runat="server">
                        <contenttemplate>
                            <asp:GridView ID="grdCostingSheetsNavigator" runat="server" AutoGenerateColumns="False" DataKeyNames="CostingSheetID"
                                SkinID="GridView" AllowSorting="True" OnSorting="grdCostingSheetsNavigator_Sorting" >
                                <Columns>
                                
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="Center" />                            
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbxSelected" onclick="return cbxSelectedClick(this);" runat="server"
                                                Checked='<%# Bind("Selected") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCostingSheetID" runat="server" Text='<%# Bind("CostingSheetID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Costing Sheets" SortExpression="Name">
                                        <HeaderStyle Width="250px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Width="250px" Text='<%# Bind("Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Data Range" SortExpression="StartDate">
                                        <HeaderStyle Width="210px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblDescription" runat="server" Width="210px" Text='<%# Bind("DataRange") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="State" SortExpression="State">
                                        <HeaderStyle Width="120px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblState" runat="server" Width="120px" Text='<%# Bind("State") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                </Columns>
                            </asp:GridView>
                        </contenttemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="vertical-align: top">
        
                    <!-- Table element: 1 column -->
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 125px; text-align: center">
        
                        <!-- Page element : Buttons -->
                        <tr>
                            <td>
                                <asp:Button ID="btnOpen" runat="server" EnableViewState="False" SkinID="Button" Text="Open"
                                Style="width: 80px" OnClick="btnOpen_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEdit" runat="server" EnableViewState="False" SkinID="Button" Text="Edit"
                                    Style="width: 80px" OnClick="btnEdit_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnDelete" runat="server" EnableViewState="False" SkinID="ButtonRedText"
                                    Text="Delete" Style="width: 80px" OnClick="btnDelete_Click" />
                            </td>
                        </tr>
                        <!-- Page element : Horizontal Rule -->
                        <tr>
                            <td>
                                <asp:Panel ID="pnlHorizontalRule" runat="server">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; text-align: center">                        
                                    <tr>
                                        <td style="width: 22px"></td>
                                        <td style="height: 10px;width: 80px"></td>
                                        <td style="width: 23px"></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td style="height: 1px" class="Background_Separator"></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td style="height: 10px"></td>
                                        <td></td>
                                    </tr>
                                </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlAction" runat="server"  AutoPostBack="true" Height="16px" SkinID="DropDownList"
                                 EnableViewState="false" Width="80px" OnSelectedIndexChanged="ddlAction_SelectedIndexChanged">
                                     <asp:ListItem Text="(Actions)" Value="Actions" Selected="True"></asp:ListItem>
                                     <asp:ListItem Text="Preview Detailed" Value="PreviewDetailed"></asp:ListItem>
                                     <asp:ListItem Text="Preview Resume" Value="PreviewResume"></asp:ListItem>
                                </asp:DropDownList>                                                                   
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 30px">
                </td>
                <td>
                </td>
            </tr>
        </table>
        
        <!-- Page element: Results -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 750px">
            <tr>
                <td style="width: 625px">
                    <asp:CustomValidator ID="cvCombinedCostingSheets" runat="server" ErrorMessage="Please select one combined costing sheet."
                        Display="Dynamic" SkinID="Validator">
                    </asp:CustomValidator>
                </td>
                <td style="width: 125px">
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCombinedCostingSheetsTitle" runat="server" EnableViewState="False" SkinID="LabelTitle1" Text="Combined Costing Sheets"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="height: 7px">
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCombinedCostingSheetsTotalRows" runat="server" EnableViewState="False" SkinID="Label" Text="Total Rows"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top">
                    <asp:UpdatePanel id="upnlCombinedCostingSheets" runat="server">
                        <contenttemplate>
                            <asp:GridView ID="grdCombinedCostingSheetsNavigator" runat="server" AutoGenerateColumns="False" DataKeyNames="CostingSheetID" Width="615px"
                                SkinID="GridView" AllowSorting="True" OnSorting="grdCombinedCostingSheetsNavigator_Sorting" >
                                <Columns>
                                
                                    <asp:TemplateField>
                                        <ItemStyle HorizontalAlign="Center" />                            
                                        <ItemTemplate>
                                            <asp:CheckBox ID="cbxSelected" onclick="return cbxSelectedClick(this);" runat="server"
                                                Checked='<%# Bind("Selected") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField Visible="False">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCostingSheetID" runat="server" Text='<%# Bind("CostingSheetID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Costing Sheet" SortExpression="Name">
                                        <HeaderStyle Width="150px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Width="150px" Text='<%# Bind("Name") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Data Range" SortExpression="StartDate">
                                        <HeaderStyle Width="150px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblDescription" runat="server" Width="150px" Text='<%# Bind("DataRange") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="Combined Projects" SortExpression="CombinedProjets">
                                        <HeaderStyle Width="200px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblCombinedProjects" runat="server" Width="200px" Text='<%# Bind("CombinedProjects") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField HeaderText="State" SortExpression="State">
                                        <HeaderStyle Width="100px" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblState" runat="server" Width="100px" Text='<%# Bind("State") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                </Columns>
                            </asp:GridView>
                        </contenttemplate>
                    </asp:UpdatePanel>
                </td>
                <td style="vertical-align: top">
        
                    <!-- Table element: 1 column -->
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 125px; text-align: center">
        
                        <!-- Page element : Buttons -->
                        <tr>
                            <td>
                                <asp:Button ID="btnOpenCombinedCostingSheet" runat="server" EnableViewState="False" SkinID="Button" Text="Open"
                                Style="width: 80px" OnClick="btnOpenCombinedCostingSheet_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnEditCombinedCostingSheet" runat="server" EnableViewState="False" SkinID="Button" Text="Edit"
                                    Style="width: 80px" OnClick="btnEditCombinedCostingSheet_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnDeleteCombinedCostingSheet" runat="server" EnableViewState="False" SkinID="ButtonRedText"
                                    Text="Delete" Style="width: 80px" OnClick="btnDeleteCombinedCostingSheet_Click" />
                            </td>
                        </tr>
                        <!-- Page element : Horizontal Rule -->
                        <tr>
                            <td>
                                <asp:Panel ID="pnlHorizontalRuleCombinedCostingSheet" runat="server">
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; text-align: center">                        
                                        <tr>
                                            <td style="width: 22px"></td>
                                            <td style="height: 10px;width: 80px"></td>
                                            <td style="width: 23px"></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td style="height: 1px" class="Background_Separator"></td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td></td>
                                            <td style="height: 10px"></td>
                                            <td></td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlActionCombinedCostingSheet" runat="server"  AutoPostBack="true" Height="16px" SkinID="DropDownList"
                                    EnableViewState="false" Width="80px" OnSelectedIndexChanged="ddlAction_SelectedIndexChanged">
                                     <asp:ListItem Text="(Actions)" Value="Actions" Selected="True"></asp:ListItem>
                                     <asp:ListItem Text="Preview Detailed" Value="PreviewDetailed"></asp:ListItem>
                                     <asp:ListItem Text="Preview Resume" Value="PreviewResume"></asp:ListItem>
                                </asp:DropDownList>                                                                   
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td style="height: 60px">
                </td>
                <td>
                </td>
            </tr>
        </table>
        
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfProjectId" runat="server" />
                    <asp:HiddenField ID="hdfClientId" runat="server" />
                    <asp:HiddenField ID="hdfBeforeUnloadOrigen" runat="server" />
                    <asp:HiddenField ID="hdfDataChanged" runat="server" />
                    <asp:HiddenField ID="hdfDataChangedMessage" runat="server" />            
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
