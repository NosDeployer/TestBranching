<%@ Page Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" CodeBehind="project_sections_navigator2.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Projects.Projects.project_sections_navigator2" Title="LFS Live" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblHeaderTitle" runat="server" Text="Project Sections" SkinID="LabelPageTitle1" EnableViewState="False"></asp:Label>
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
                                    <telerik:RadPanelItem runat="server" Value="mProjectCostingSheets" Text="Project Costing Sheets" ></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mSections" Text="Sections" Selected="true" PostBack="false"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="Tools" Text="Tools" PostBack="false">
                                        <ItemTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 160px;padding-left: 10px;">
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlTools" runat="server" SkinID="ASPxNavBar1_DropDownList" Width="160px" AutoPostBack="true">
                                                            <asp:ListItem Selected="True" Text="(Tools)" Value="Tools"></asp:ListItem>
                                                            <asp:ListItem Text="Add Sections" Value="AddSections"></asp:ListItem>
                                                            <asp:ListItem Text="Bulk Upload" Value="BulkUpload"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr style="height: 10px;">
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadPanelItem>
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
                    <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick">                        
                        <Items>
                            <telerik:RadMenuItem Value="mLastSearch" Text="LAST SEARCH"/>
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
        <asp:Panel ID="pnlDefaultSearch" runat="server" Width="100%" DefaultButton="btnSearch">

            <!-- Page element: Search 5 columns-->
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td style="width: 125px">
                        <asp:Label ID="lblID" runat="server" SkinID="Label" Text="ID (Section)" EnableViewState="False"></asp:Label>
                    </td>
                    <td style="width: 250px">
                        <asp:Label ID="lblStreet" runat="server" SkinID="Label" Text="Street" EnableViewState="False"></asp:Label>
                    </td>
                    <td style="width: 125px">
                        <asp:Label ID="lblUSMH" runat="server" EnableViewState="False" SkinID="Label" Text="USMH"></asp:Label>
                    </td>
                    <td style="width: 125px">
                        <asp:Label ID="lblDSMH" runat="server" EnableViewState="False" SkinID="Label" Text="DSMH"></asp:Label>
                    </td>
                    <td style="width: 125px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="tbxID" runat="server" EnableViewState="false" Width="115px" SkinID="TextBox"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxStreet" runat="server" Style="width: 240px" SkinID="TextBox" EnableViewState="False"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxUSMH" runat="server" EnableViewState="false" Width="115px" SkinID="TextBox"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxDSMH" runat="server" EnableViewState="false" Width="115px" SkinID="TextBox"></asp:TextBox>
                    </td>
                    <td style="text-align: center">
                        <asp:Button ID="btnSearch" runat="server" EnableViewState="false" OnClick="btnSearch_Click" Text="Search" Width="80px" SkinID="Button" /> 
                    </td>
                </tr>
            </table>
        </asp:Panel>
        
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
        
        <!-- Page element: Section title - Results -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblResults" runat="server" SkinID="LabelTitle1" Text="Results" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Page element: Results -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 650px">
                    <asp:Label ID="lblTotalRows" runat="server" EnableViewState="true" SkinID="Label"
                        Text="Total Rows"></asp:Label></td>
                <td style="width: 125px; vertical-align: top;">
                    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="pnlProjectSectionsNavigator" runat="server" Height="330px" Width="609px" ScrollBars="Auto">                                     
                
                       <asp:UpdatePanel id="upnlProjectSectionsNavigator" runat="server">
                            <contenttemplate>
                                <asp:GridView id="grdSectionsNavigator" runat="server" SkinID="GridView" Width="100%" OnSorting="grdSectionsNavigator_Sorting"
                                DataKeyNames="AssetID" DataSourceID="odsNavigator" AllowSorting="True"
                                OnDataBound="grdSectionsNavigator_DataBound" PageSize="12" AutoGenerateColumns="False">
                                    <Columns>
                                       
                                       
                                        <asp:TemplateField ShowHeader="False" Visible="False">
                                            <ItemStyle horizontalalign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                  <asp:Label ID="lblAssetID" runat="server" SkinID="Label" Text='<%# Bind("AssetID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        
                                        
                                        <asp:TemplateField ShowHeader="False" Visible="False">
                                            <ItemStyle horizontalalign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                  <asp:Label ID="lblSectionUSMH" runat="server" SkinID="Label" Text='<%# Bind("USMH") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        
                                        
                                        <asp:TemplateField ShowHeader="False" Visible="False">
                                            <ItemStyle horizontalalign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                  <asp:Label ID="lblSectionDSMH" runat="server" SkinID="Label" Text='<%# Bind("DSMH") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        
                                        
                                        <asp:TemplateField HeaderText="ID (Section)" visible="False">
                                            <ItemStyle horizontalalign="Center"></ItemStyle>
                                            <HeaderStyle Width="113px" ></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblSectionId" runat="server" SkinID="Label" Text='<%# Bind("SectionID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        
                                        
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemStyle horizontalalign="Center"></ItemStyle>
                                            <HeaderStyle width="30px"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbxSelected" runat="server" onclick="return cbxSelectedClick(this);" Checked='<%# Eval("Selected") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        
                                        
                                        <asp:TemplateField HeaderText="ID (Section)" SortExpression="FlowOrderID">
                                            <ItemStyle horizontalalign="Center" wrap="false"></ItemStyle>
                                            <HeaderStyle width="113px" wrap="false"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblFlowOrderId" runat="server" SkinID="Label" Text='<%# Bind("FlowOrderID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        
                                        
                                        <asp:TemplateField HeaderText="Street" SortExpression="Street">
                                            <HeaderStyle width="140px"></HeaderStyle>
                                            <ItemStyle wrap="false" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblSectionStreet" runat="server" SkinID="Label" Text='<%# Bind("Street") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        
                                        
                                        <asp:TemplateField HeaderText="USMH" SortExpression="USMHDescription">
                                            <HeaderStyle width="75px"></HeaderStyle>
                                            <ItemStyle wrap="false" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblSectionUSMHDescription" runat="server" SkinID="Label" Text='<%# Bind("USMHDescription") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        
                                        
                                        <asp:TemplateField HeaderText="DSMH" SortExpression="DSMHDescription">
                                            <HeaderStyle width="75px"></HeaderStyle>
                                            <ItemStyle wrap="false" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblSectionDSMHDescription" runat="server" SkinID="Label" Text='<%# Bind("DSMHDescription") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        
                                        
                                        <asp:TemplateField HeaderText="Laterals" SortExpression="LateralsDescription">
                                            <HeaderStyle width="150px"></HeaderStyle>
                                            <ItemStyle wrap="false" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblLateralsDescription" runat="server" SkinID="Label" Text='<%# Bind("LateralsDescription") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        
                                        
                                        <asp:TemplateField HeaderText="Works" SortExpression="WorksDescription">
                                            <HeaderStyle width="310px"></HeaderStyle>
                                            <ItemStyle wrap="false" />
                                            <ItemTemplate>
                                                <asp:Label ID="lblWorkDescription" runat="server" SkinID="Label" Text='<%# Bind("WorksDescription") %>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </contenttemplate>   
                        </asp:UpdatePanel>
                    </asp:Panel> 
              
                </td>
                <td style="width: 125px; vertical-align: top;">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 125px; text-align: center">
                        <tr>
                            <td>
                                <asp:Button ID="btnOpen" runat="server" SkinID="Button" Text="Open" Width="80px" EnableViewState="False" OnClick="btnOpen_Click"/>
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnDelete" runat="server" SkinID="ButtonRedText" Text="Delete" Width="80px" EnableViewState="False" OnClick="btnDelete_Click" OnClientClick="return btnDeleteClick()" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnClearSearch" runat="server" EnableViewState="False" SkinID="Button"
                                    Text="Clear Search" Style="width: 80px" OnClick="btnClearSearch_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:DropDownList ID="ddlViewWorks" runat="server"  AutoPostBack="true" Height="16px" SkinID="DropDownList"
                                 EnableViewState="false" Width="80px" OnSelectedIndexChanged="ddlViewWorks_SelectedIndexChanged">
                                 <asp:ListItem Text="(Works)" Value="Works" Selected="True"></asp:ListItem>                                 
                                 <asp:ListItem Text="Rehab Assessment" Value="RehabAssessment"></asp:ListItem>
                                 <asp:ListItem Text="Full Length Lining" Value="FullLengthLining"></asp:ListItem>
                                 <asp:ListItem Text="Junction Lining" Value="JunctionLining"></asp:ListItem>
                                </asp:DropDownList>                                                                                                  
                            </td>
                        </tr>                       
                    </table>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblError" runat="server" EnableViewState="False" SkinID="LabelError"
                        Text="At least one proposal must be selected"></asp:Label>
                </td>
                <td></td>
            </tr>
            <tr>
                <td colspan="1">
                    <!-- Page element: Data objects -->
                    <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                        <tr>
                            <td>
                                <asp:ObjectDataSource ID="odsNavigator" runat="server" SelectMethod="GetSections"
                                    TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_sections_navigator2"></asp:ObjectDataSource>
                            </td>
                        </tr>
                    </table>    
                </td>
                <td></td>
             </tr>
        </table>
        
        
        
        <!-- Page element : Footer separation -->
        <table id="Table1" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%" >
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
                    <asp:HiddenField ID="hdfProjectId" runat="server" />
                    <asp:HiddenField ID="hdfClientId" runat="server" />
                    <asp:HiddenField ID="hdfBeforeUnloadOrigen" runat="server" />
                    <asp:HiddenField ID="hdfDataChanged" runat="server" />
                    <asp:HiddenField ID="hdfDataChangedMessage" runat="server" />
                    <asp:HiddenField ID="hdfSelectedAssetId" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>