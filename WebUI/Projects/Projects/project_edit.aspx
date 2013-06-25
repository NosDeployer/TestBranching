<%@ Page Language="C#" MasterPageFile="../../mForm6.master" AutoEventWireup="true" CodeBehind="project_edit.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Projects.Projects.project_edit" Title="LFS Live" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td style="width: 740px">
                    <asp:Label ID="lblHeaderTitle" runat="server" Text="Project" SkinID="LabelPageTitle1" EnableViewState="False"></asp:Label>
                </td>
                <td style="width: 10px"> 
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
                <td>
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
                                    <telerik:RadPanelItem runat="server" Value="mProject" Text="e"></telerik:RadPanelItem>
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
    <!-- CONTENT -->
    <div style="width: 750px;">
        <!-- Table element: 4 columns - Project/Proposal -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 150px">
                    <asp:Label ID="lblProjectNumber" runat="server" EnableViewState="False" Text="Project Number" SkinID="Label"></asp:Label>
                </td>
                <td style="width: 150px">
                    <asp:Label ID="lblName" runat="server" EnableViewState="False" Text="Name" SkinID="Label"></asp:Label>
                </td>
                <td style="width: 150px">
                </td>
                <td style="width: 150px">
                    <asp:Label ID="lblProposalDate" runat="server" EnableViewState="False" Text="Proposal Date" SkinID="Label"></asp:Label>
                </td>
                <td style="width: 150px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxProjectNumber" runat="server" SkinID="TextBoxReadOnly" Width="140px" ReadOnly="True" Text='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT].DefaultView.[0].ProjectNumber") %>' EnableViewState="True"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="tbxName" runat="server" SkinID="TextBox" Width="290px" Text='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT].DefaultView.[0].Name") %>' EnableViewState="True"></asp:TextBox>
                </td>
                <td>
                    <telerik:RadDatePicker ID="tkrdpProposalDate" runat="server" Width="140px" SkinID="RadDatePicker" DbSelectedDate='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT].DefaultView.[0].ProposalDate") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                    </telerik:RadDatePicker>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td colspan="2">
                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="tbxName"
                        Display="Dynamic" EnableViewState="True" ErrorMessage="Please provide a project name"
                        SkinID="Validator" ValidationGroup="projectInformation"></asp:RequiredFieldValidator>
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
                <td>
                </td>
            </tr>        
            <tr>
                <td>
                    <asp:Label ID="lblDescription" runat="server" EnableViewState="False" Text="Description" SkinID="Label"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                    <asp:Label ID="lblStartDate" runat="server" EnableViewState="False" Text="Potential Start Date" SkinID="Label"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="3" rowspan="4">
                    <asp:TextBox ID="tbxDescription" runat="server" Height="61px" SkinID="TextBox" 
                    TextMode="MultiLine" Width="440px" Text='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT].DefaultView.[0].Description") %>' EnableViewState="True"></asp:TextBox>
                </td>
                <td>
                    <telerik:RadDatePicker ID="tkrdpStartDate" runat="server" Width="140px" SkinID="RadDatePicker" DbSelectedDate='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT].DefaultView.[0].StartDate") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                    </telerik:RadDatePicker>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEndDate" runat="server" EnableViewState="False" Text="Potential End Date" SkinID="Label"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadDatePicker ID="tkrdpEndDate" runat="server" Width="140px" SkinID="RadDatePicker" DbSelectedDate='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT].DefaultView.[0].EndDate") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                    </telerik:RadDatePicker>
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
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblCountry" runat="server" EnableViewState="False" 
                        Text="Country" SkinID="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblProvinceState" runat="server" EnableViewState="False" 
                        Text="Province/State" SkinID="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCounty" runat="server" EnableViewState="False" Text="County" 
                        SkinID="Label"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblCity" runat="server" EnableViewState="False" Text="City" 
                        SkinID="Label"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxCountry" runat="server" SkinID="TextBoxReadOnly" 
                        Width="140px" ReadOnly="True"  EnableViewState="True"></asp:TextBox>
                    <asp:HiddenField ID="hdfCountryId" runat="server" Value='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT].DefaultView.[0].CountryID") %>'/>
                </td>
                <td>
                    <asp:TextBox ID="tbxProvinceState" runat="server" SkinID="TextBoxReadOnly" 
                        Width="140px" ReadOnly="True"  EnableViewState="True"></asp:TextBox>
                    <asp:HiddenField ID="hdfProvinceStateId" runat="server" Value='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT].DefaultView.[0].ProvinceID") %>'/>
                </td>
                <td>
                    <asp:TextBox ID="tbxCounty" runat="server" SkinID="TextBoxReadOnly" 
                        Width="140px" ReadOnly="True"  EnableViewState="True"></asp:TextBox>
                    <asp:HiddenField ID="hdfCountyId" runat="server" Value='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT].DefaultView.[0].CountyID") %>'/>
                </td>
                <td>
                    <asp:TextBox ID="tbxCity" runat="server" SkinID="TextBoxReadOnly" Width="140px" 
                        ReadOnly="True"  EnableViewState="True"></asp:TextBox>
                    <asp:HiddenField ID="hdfCityId" runat="server" Value='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT].DefaultView.[0].CityID") %>'/>
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
        
        <!-- Page element: Section title - Client -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblClient" runat="server" SkinID="LabelTitle1" Text="Client" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 4 columns - Client -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 150px">
                    <asp:Label ID="lblClientName" runat="server" EnableViewState="False" Text="Name" SkinID="Label"></asp:Label>
                </td>
                <td style="width: 150px">
                </td>
                <td style="width: 150px">
                    <asp:Label ID="lblClientProjectNumber" runat="server" EnableViewState="False" Text="Client Project Number" SkinID="Label"></asp:Label>
                </td>
                <td style="width: 150px">
                </td>
                <td style="width: 150px">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="tbxClientName" runat="server" SkinID="TextBoxReadOnly" Width="290px" ReadOnly="True"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxClientProjectNumber" runat="server" SkinID="TextBox" Width="140px" Text='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT].DefaultView.[0].ClientProjectNumber") %>' EnableViewState="True"></asp:TextBox>
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
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblClientPrimaryContactId" runat="server" EnableViewState="False" Text="Primary Contact" SkinID="Label"></asp:Label>
                </td>
                <td>                    
                </td>
                <td>
                    <asp:Label ID="lblClientSecondaryContactId" runat="server" EnableViewState="False" Text="Secondary Contact" SkinID="Label"></asp:Label>
                </td>
                <td>                    
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                        <tr>
                            <td style="width: 260px">
                                <asp:DropDownList ID="ddlClientPrimaryContactId" runat="server" SkinID="DropDownList" Width="250px">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 30px">
                                <asp:Button ID="btnClientPrimaryContact" runat="server" Text="..." SkinID="Button" Width="30px" OnClientClick="return btnClientPrimaryContactClick();" EnableViewState="False" />
                            </td>
                            <td style="width: 10px">
                            </td>
                        </tr>
                    </table>
                </td>
                <td colspan="2">
                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                        <tr>
                            <td style="width: 260px">
                                <asp:DropDownList ID="ddlClientSecondaryContactId" runat="server" SkinID="DropDownList" Width="250px">
                                </asp:DropDownList>
                            </td>
                            <td style="width: 30px">
                                <asp:Button ID="btnClientSecondaryContact" runat="server" Text="..." SkinID="Button" Width="30px" OnClientClick="return btnClientSecondaryContactClick();" EnableViewState="False" />
                            </td>
                            <td style="width: 10px">
                            </td>
                        </tr>
                    </table>
                </td>
                <td colspan="1">
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
        
        <!-- Page element: Section title - Resources -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblResources" runat="server" SkinID="LabelTitle1" Text="Resources" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 4 columns - Resources -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 150px">
                    <asp:Label ID="lblProjectLeadId" runat="server" EnableViewState="False" Text="Project Lead" SkinID="Label"></asp:Label>
                </td>
                <td style="width: 150px">
                </td>
                <td style="width: 150px">
                    <asp:Label ID="lblSalesmanId" runat="server" EnableViewState="False" Text="Salesman" SkinID="Label"></asp:Label>
                </td>
                <td style="width: 150px">
                </td>
                <td style="width: 150px">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:DropDownList ID="ddlProjectLeadId" runat="server" SkinID="DropDownList" Width="290px">
                    </asp:DropDownList>
                </td>
                <td colspan="2">
                    <asp:DropDownList ID="ddlSalesmanId" runat="server" SkinID="DropDownList" Width="290px"> 
                    </asp:DropDownList>
                </td>
                <td colspan="1">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
                <td colspan="2">
                    <asp:RequiredFieldValidator ID="rfvSalesman" runat="server" ControlToValidate="ddlSalesmanId"
                        Display="Dynamic" EnableViewState="True" ErrorMessage="Please select a salesman."
                        InitialValue="-1" SkinID="Validator" ValidationGroup="projectInformation"></asp:RequiredFieldValidator>
                </td>
                <td colspan="1">
                </td>
            </tr>
        </table>
        
        <asp:Panel ID="pnlPricing" runat="server" Width="100%">
            <!-- Page element : Horizontal Rule -->
            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                <tr>
                    <td style="height: 30px">
                    </td>
                </tr>
                <tr>
                    <td id="tdPricing" runat="server" style="height: 2px" class="Background_Separator">
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                </tr>
            </table>
            
            <!-- Page element: Section title - Pricing -->
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td>
                        <asp:Label ID="lblPricing" runat="server" SkinID="LabelTitle1" Text="Pricing" EnableViewState="False"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="height: 10px">
                    </td>
                </tr>
            </table>
            
             <!-- Table element: 4 columns - Pricing -->
            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                <tr>
                    <td style="width: 150px">
                        <asp:Label ID="lblBillPrice" runat="server" EnableViewState="False" Text="Total Price Of Project" SkinID="Label"></asp:Label>      
                    </td>
                    <td style="width: 150px">
                    </td>
                    <td style="width: 150px">
                    </td>
                    <td style="width: 150px">
                    </td>
                    <td style="width: 150px">
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="tbxBillPrice" runat="server" style="text-align:right" SkinID="TextBoxRight" Width="140px" EnableViewState="True" Text='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_SALE_BILLING_PRICING].DefaultView.[0].BillPrice", "{0:n2}") %>' ></asp:TextBox>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBillMoney" runat="server" SkinID="DropDownList" Width="60px" SelectedValue='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_SALE_BILLING_PRICING].DefaultView.[0].BillMoney") %>'>
                            <asp:ListItem Selected="True">CAD</asp:ListItem>
                            <asp:ListItem>USD</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td style="width: 150px">
                        <asp:CompareValidator ID="cvBillPrice" runat="server" ControlToValidate="tbxBillPrice"
                            ErrorMessage="Invalid data. (use #.## format)" Operator="DataTypeCheck" SkinID="Validator"
                            Type="Currency" Display="Dynamic" EnableViewState="True" ValidationGroup="projectInformation"></asp:CompareValidator>
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
        
        <!-- Table element: 6 columns - Detailed information title -->
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
                    <cc1:TabContainer ID="tcDetailedInformation" Width="730px" runat="server" CssClass="ajax_tabcontainer">
        
                        <cc1:TabPanel ID="tpJobInfo" runat="server" HeaderText="Job Info" OnClientClick="tpJobInfoClientClick">
                            <ContentTemplate>                            
                                <div style="width: 710px; height: 1300px; overflow-y: auto;">
                                    <!-- Table element: 4 columns - Type of work -->
                                    <asp:UpdatePanel id="upnlTypeOfWork" runat="server">
                                        <contenttemplate>
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width:177px"></td>
                                            <td style="width:177px"></td>
                                            <td style="width:177px"></td>
                                            <td style="width:177px"></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblTypeOfWorkTitle" runat="server" EnableViewState="False"
                                                    SkinID="LabelTitle2" Text="Type Of Work"></asp:Label>
                                            </td>
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
                                                <asp:CheckBox ID="ckbxMhRehab" runat="server" SkinID="CheckBox" Text="MH Rehab"/>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxJunctionLining" runat="server" SkinID="CheckBox" Text="Juntion Lining"/>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxProjectManagement" runat="server" SkinID="CheckBox" Text="Project Management"/>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxFullLengthLining" runat="server" SkinID="CheckBox" Text="Full Length Lining"/>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="ckbxPointRepairs" runat="server" SkinID="CheckBox" Text="Point Repairs"/>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxRehabAssessment" runat="server" SkinID="CheckBox" Text="Rehab Assessment"/>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxGrout" runat="server" SkinID="CheckBox" Text="Grout"/>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxOther" runat="server" SkinID="CheckBox" Text="Other" />
                                            </td>
                                        </tr>
                                    </table>
                                        </contenttemplate>
                                    </asp:UpdatePanel>
                                    
                                    <!-- Page element : Horizontal Rule -->
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 710px">
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
                                    
                                    <asp:UpdatePanel id="upnlSaleBillingPricingValues" runat="server">
                                        <contenttemplate>
                                            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblBillPriceSaleBillingPricing" runat="server" EnableViewState="False" Text="Total Price Of Project" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td >                                                
                                                    </td>                                            
                                                    <td >                                                
                                                    </td> 
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="tbxBillPriceSaleBillingPricing" runat="server" SkinID="TextBox" Width="167px" Text='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_SALE_BILLING_PRICING].DefaultView.[0].BillPrice", "{0:n2}") %>'></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlBillMoneySaleBillingPricing" runat="server" SkinID="DropDownList" Width="60px" SelectedValue='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_SALE_BILLING_PRICING].DefaultView.[0].BillMoney") %>'>
                                                            <asp:ListItem Selected="True">CAD</asp:ListItem>
                                                            <asp:ListItem>USD</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>                                                
                                                    </td>
                                                    <td>
                                                    </td>                                            
                                                </tr>     
                                                <tr>
                                                    <td>
                                                        <asp:CompareValidator ID="cvBillPriceSaleBillingPricing" runat="server" ControlToValidate="tbxBillPriceSaleBillingPricing"
                                                            ErrorMessage="Invalid data. (use #.## format)" Operator="DataTypeCheck" SkinID="Validator"
                                                            Type="Currency" Display="Dynamic" ValidationGroup="salesBilingPricingData"></asp:CompareValidator>
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
                                            </table>
                                        </contenttemplate>
                                    </asp:UpdatePanel>
                                    
                                    <asp:UpdatePanel id="pnlCostsExceptions" runat="server">
                                        <contenttemplate>                                            
                                             <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblFairWageApplies" runat="server" EnableViewState="False" Text="Fair Wage Applies?" SkinID="Label"></asp:Label>
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
                                                        <asp:UpdatePanel id="uplFairWageApplies" runat="server">
                                                             <contenttemplate>
                                                                <asp:CheckBox ID="cbxFairWageApplies" runat="server" 
                                                                 Checked='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT].DefaultView.[0].FairWageApplies") %>' 
                                                                 SkinID="CheckBox" Text="Yes" AutoPostBack="True" 
                                                                 oncheckedchanged="cbxFairWageApplies_CheckedChanged" />
                                                            </contenttemplate>
                                                         </asp:UpdatePanel>
                                                    </td>
                                                    <td>
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
                                            </table>
                                            <!-- Page element: Section title - Job Class Classification -->
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 710px">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblJobClassTypeRate" runat="server" EnableViewState="False" 
                                                            SkinID="Label" Text="Job Class Classification"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 10px">
                                                    </td>
                                                </tr>
                                            </table>
                
                                            <!-- Page element: 1 column - grid -->
                                            <table cellpadding="0" cellspacing="0" width="0" style="width: 710px">
                                                <tr>
                                                    <td>
                                                        <asp:Panel ID="pnlJobClassClassification" runat="server" Height="271px" Width="390px" ScrollBars="Auto"  SkinID="Panel">
                                                            <asp:UpdatePanel id="upJobClassClassification" runat="server">
                                                                <contenttemplate>
                                                                    <asp:GridView ID="grdJobClassClassification" runat="server" SkinID="GridViewInTabs" Width="330px" ShowFooter="True"
                                                                        AutoGenerateColumns="False" DataKeyNames="ProjectID,JobClassType,RefID" DataSourceID="odsJobClassClassificationGrid" DataMember="DefaultView"
                                                                        OnDataBound="grdJobClassClassification_DataBound" OnRowCommand="grdJobClassClassification_RowCommand" OnRowEditing="grdJobClassClassification_RowEditing"
                                                                        OnRowUpdating="grdJobClassClassification_RowUpdating" OnRowDeleting="grdJobClassClassification_RowDeleting">
                                                                        <Columns>                                                        
                                                                            <asp:TemplateField HeaderText="ProjectID" Visible ="False">                                                                                                            
                                                                                <ItemTemplate>                
                                                                                    <asp:Label ID="lblProjectID" runat="server" SkinID="Label" Text='<%# Eval("ProjectID") %>'></asp:Label>                                                                               
                                                                                </ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                    <asp:Label ID="lblProjectIDEdit" runat="server" SkinID="Label" Text='<%# Eval("ProjectID") %>'></asp:Label>
                                                                                </EditItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:Label ID="lblProjectIDNew" runat="server" SkinID="Label" Text='<%# Eval("ProjectID") %>'></asp:Label>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                            
                                                                            <asp:TemplateField HeaderText="JobClassType" Visible ="False">                                                                    
                                                                                <ItemTemplate>                                                                     
                                                                                     <asp:Label ID="lblJobClassType" runat="server" SkinID="Label" Text='<%# Eval("JobClassType") %>'></asp:Label>                                                                                
                                                                                </ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                    <asp:Label ID="lblJobClassTypeEdit" runat="server" SkinID="Label" Text='<%# Eval("JobClassType") %>'></asp:Label>
                                                                                </EditItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:Label ID="lblJobClassTypeNew" runat="server" SkinID="Label" Text='<%# Eval("JobClassType") %>'></asp:Label>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                            
                                                                            <asp:TemplateField HeaderText="RefID" Visible ="False">                                                                    
                                                                                <ItemTemplate>                                                                     
                                                                                     <asp:Label ID="lblRefID" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>                                                                                
                                                                                </ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                    <asp:Label ID="lblRefIDEdit" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                                </EditItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:Label ID="lblRefIDNew" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>                                                                                                                                                                                                    
                                                                                
                                                                            <asp:TemplateField  HeaderText="Job Class">                                                                    
                                                                                <ItemTemplate>
                                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Label ID="lblJobClass" runat="server" SkinID="Label" Text='<%# Eval("JobClassType") %>'></asp:Label>        
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle Width="155px"></HeaderStyle>
                                                                                <EditItemTemplate>
                                                                                    <asp:Label ID="lblJobClassEdit" runat="server" SkinID="Label" Text='<%# Eval("JobClassType") %>'></asp:Label>
                                                                                </EditItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:DropDownList Style="width: 155px" ID="ddlJobClassNew" runat="server" SkinID="DropDownListLookup"
                                                                                        EnableViewState="True" DataTextField="JobClassType" DataValueField="JobClassType" DataSourceID="odsJobClassType">
                                                                                    </asp:DropDownList>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                                                                                        
                                                                            <asp:TemplateField HeaderText="Rate (CAD)">                                                                   
                                                                                <ItemTemplate>
                                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td align="right">
                                                                                                    <asp:Label ID="lblRate" runat="server" SkinID="Label" Text='<%# Eval("Rate", "{0:n2}") %>'></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle Width="83px"></HeaderStyle>
                                                                                <EditItemTemplate>
                                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td align="right">
                                                                                                    <asp:TextBox ID="tbxRateEdit" runat="server" SkinID="TextBox" Text='<%# Eval("Rate", "{0:n2}") %>'
                                                                                                        Width="83px" ></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="right">
                                                                                                    <asp:CompareValidator ID="cvRateEdit" runat="server" ControlToValidate="tbxRateEdit"
                                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Currency" ValidationGroup="jobClassClassificationDataEdit">
                                                                                                    </asp:CompareValidator>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </EditItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td align="right">
                                                                                                    <asp:TextBox ID="tbxRateNew" runat="server" SkinID="TextBox" Width="83px" ></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="right">
                                                                                                    <asp:CompareValidator ID="cvRateNew" runat="server" ControlToValidate="tbxRateNew"
                                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Currency" ValidationGroup="jobClassClassificationDataAdd">
                                                                                                    </asp:CompareValidator>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                            
                                                                            <asp:TemplateField HeaderText="Fringe Rate (CAD)">                                                                   
                                                                                <ItemTemplate>
                                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td align="right">
                                                                                                    <asp:Label ID="lblFringeRate" runat="server" SkinID="Label" Text='<%# Eval("FringeRate", "{0:n2}") %>'></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle Width="83px"></HeaderStyle>
                                                                                <EditItemTemplate>
                                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td align="right">
                                                                                                    <asp:TextBox ID="tbxFringeRateEdit" runat="server" SkinID="TextBox" Text='<%# Eval("FringeRate", "{0:n2}") %>'
                                                                                                        Width="83px" ></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="right">
                                                                                                    <asp:CompareValidator ID="cvFringeRateEdit" runat="server" ControlToValidate="tbxFringeRateEdit"
                                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Currency" ValidationGroup="jobClassClassificationDataEdit">
                                                                                                    </asp:CompareValidator>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </EditItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td align="right">
                                                                                                    <asp:TextBox ID="tbxFringeRateNew" runat="server" SkinID="TextBox" Width="83px" ></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="right">
                                                                                                    <asp:CompareValidator ID="cvFringeRateNew" runat="server" ControlToValidate="tbxFringeRateNew"
                                                                                                        Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Currency" ValidationGroup="jobClassClassificationDataAdd">
                                                                                                    </asp:CompareValidator>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </FooterTemplate>
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
                                                                </contenttemplate>
                                                            </asp:UpdatePanel>                                                                                                         
                                                        </asp:Panel>                                                  
                                                    </td>
                                                </tr>
                                            </table>
                                            
                                            <!-- Page element: Section title - Type Of Work &amp; Function Classification -->
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 710px">
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblTypeOfWorkFunctionClassificationTitle" runat="server" 
                                                            SkinID="Label" Text="Type Of Work . Function Classification" 
                                                            EnableViewState="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 10px">
                                                    </td>
                                                </tr>
                                            </table>
                
                                            <!-- Page element: 1 column - grid -->
                                            <table cellpadding="0" cellspacing="0" width="0" style="width: 710px">
                                                <tr>
                                                    <td>        
                                                        <asp:Panel ID="pnlTypeOfWorkFunctionClassification" runat="server" Height="271px" Width="345px" ScrollBars="Auto" SkinID="Panel">                                        
                                                            <asp:UpdatePanel id="upTypeOfWorkFunctionClassification" runat="server">
                                                                <contenttemplate>
                                                                    <asp:GridView ID="grdTypeOfWorkFunctionClassification" runat="server" 
                                                                        SkinID="GridViewInTabs" Width="330px" ShowFooter="true"
                                                                        AutoGenerateColumns="False" DataKeyNames="ProjectID,Work_,Function_,RefID" DataSourceID="odsTypeOfWorkFunctionClassificationGrid"
                                                                        OnRowCommand="grdTypeOfWorkFunctionClassification_RowCommand" 
                                                                        OnRowEditing="grdTypeOfWorkFunctionClassification_RowEditing"
                                                                        OnRowUpdating="grdTypeOfWorkFunctionClassification_RowUpdating" OnRowDeleting="grdTypeOfWorkFunctionClassification_RowDeleting"
                                                                        OnDataBound="grdTypeOfWorkFunctionClassification_DataBound" 
                                                                        onrowdatabound="grdTypeOfWorkFunctionClassification_RowDataBound" >
                                                                        <Columns>                                                        
                                                                            <asp:TemplateField HeaderText="ProjectID" Visible ="False">                                                                                                            
                                                                                <ItemTemplate>                
                                                                                    <asp:Label ID="lblProjectID" runat="server" SkinID="Label" Text='<%# Eval("ProjectID") %>'></asp:Label>                                                                               
                                                                                </ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                    <asp:Label ID="lblProjectIDEdit" runat="server" SkinID="Label" Text='<%# Eval("ProjectID") %>'></asp:Label>
                                                                                </EditItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:Label ID="lblProjectIDNew" runat="server" SkinID="Label" Text='<%# Eval("ProjectID") %>'></asp:Label>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                            
                                                                            <asp:TemplateField HeaderText="Work_" Visible ="False">                                                                    
                                                                                <ItemTemplate>                                                                     
                                                                                     <asp:Label ID="lblWork_" runat="server" SkinID="Label" Text='<%# Eval("Work_") %>'></asp:Label>                                                                                
                                                                                </ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                    <asp:Label ID="lblWork_Edit" runat="server" SkinID="Label" Text='<%# Eval("Work_") %>'></asp:Label>
                                                                                </EditItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:Label ID="lblWork_New" runat="server" SkinID="Label" Text='<%# Eval("Work_") %>'></asp:Label>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                            
                                                                            <asp:TemplateField HeaderText="Function_" Visible ="False">                                                                    
                                                                                <ItemTemplate>                                                                     
                                                                                     <asp:Label ID="lblFunction_" runat="server" SkinID="Label" Text='<%# Eval("Function_") %>'></asp:Label>                                                                                
                                                                                </ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                    <asp:Label ID="lblFunction_Edit" runat="server" SkinID="Label" Text='<%# Eval("Function_") %>'></asp:Label>
                                                                                </EditItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:Label ID="lblFunction_New" runat="server" SkinID="Label" Text='<%# Eval("Function_") %>'></asp:Label>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>
                                                                            
                                                                            <asp:TemplateField HeaderText="RefID" Visible ="False">                                                                    
                                                                                <ItemTemplate>                                                                     
                                                                                     <asp:Label ID="lblRefID" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>                                                                                
                                                                                </ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                    <asp:Label ID="lblRefIDEdit" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                                </EditItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:Label ID="lblRefIDNew" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                                </FooterTemplate>
                                                                            </asp:TemplateField>                                                                                                                                                                                                    
                                                                                
                                                                            <asp:TemplateField  HeaderText="Type Of Work . Function">                                                                    
                                                                                <ItemTemplate>
                                                                                    <asp:Label ID="lblWorkFunction" runat="server" SkinID="Label" Style="width: 155px"
                                                                                        Text='<%# Bind("WorkFunction") %>' Width="155px"></asp:Label>
                                                                                </ItemTemplate>
                                                                                <EditItemTemplate>
                                                                                    <asp:Label ID="lblWorkFunctionEdit" runat="server" SkinID="Label" Style="width: 155px"
                                                                                        Text='<%# Bind("WorkFunction") %>' Width="155px"></asp:Label>
                                                                                </EditItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:DropDownList Style="width: 155px" ID="ddlWorkFunctionNew" runat="server"
                                                                                        SkinID="DropDownList" DataSourceID="odsWorkFunctionConcat" DataTextField="WorkFunctionConcat"
                                                                                        DataValueField="WorkFunctionConcat">
                                                                                    </asp:DropDownList>
                                                                                </FooterTemplate>
                                                                                <ItemStyle HorizontalAlign="Left" />
                                                                                <HeaderStyle Width="155px" />
                                                                            </asp:TemplateField>
                                                                                                                                        
                                                                            <asp:TemplateField HeaderText="Is Fair Wage?">
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                <FooterStyle HorizontalAlign="Center" />
                                                                                
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="cbxIsFairWage" runat="server" Checked='<%# Bind("IsFairWage") %>' onclick="return cbxClick();"/>
                                                                                </ItemTemplate>
                                                                                 <EditItemTemplate>
                                                                                    <asp:CheckBox ID="cbxIsFairWageEdit" runat="server" Checked='<%# Bind("IsFairWage") %>'/>
                                                                                </EditItemTemplate>
                                                                                <FooterTemplate>
                                                                                    <asp:CheckBox ID="cbxIsFairWageNew" runat="server"/>
                                                                                </FooterTemplate>
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
                                                                </contenttemplate>
                                                            </asp:UpdatePanel>                                                                                                         
                                                        </asp:Panel>
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
                                            </table>
                                        </contenttemplate>
                                    </asp:UpdatePanel>
                                                                               
                                    <asp:UpdatePanel id="upnlEngineerSubcontractors" runat="server">
                                        <contenttemplate>                                               
                                             <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblAreWeTheGeneralContractor" runat="server" EnableViewState="False" Text="Are we the General Contractor?" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="cbxGeneralContractor" runat="server" SkinID="CheckBox" Text="Yes" Checked='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_ENGINEER_SUBCONTRACTORS].DefaultView.[0].GeneralContractor") %>'/>
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
                                                </tr>                                        
                                            </table> 
                                        </contenttemplate>       
                                    </asp:UpdatePanel>             
                                    
                                    <asp:UpdatePanel id="upnlTechnical" runat="server">
                                        <contenttemplate>   
                                            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                </tr> 
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblAreDrawingsAvailable" runat="server" EnableViewState="False" Text="Are drawings available?" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="cbxAvailableDrawings" runat="server" SkinID="CheckBox" Text="Yes." />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAvailableVideo" runat="server" EnableViewState="False" SkinID="Label" Text="Is there a video available?"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="cbxAvailableVideo" runat="server" SkinID="CheckBox" Text="Yes." />
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
                                            </table>
                                        </contenttemplate>       
                                    </asp:UpdatePanel>   
                                    
                                    <asp:UpdatePanel id="upnlEngineerSubcontractors1" runat="server">
                                        <contenttemplate>                                               
                                             <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                </tr>        
                                                <tr>
                                                    <td>                                                
                                                        <asp:Label ID="lblGeneralWSIB" runat="server" EnableViewState="False" Text="WSIB given to client?" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="cbxGeneralWSIB" runat="server" SkinID="CheckBox" Text="Yes" Checked='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_ENGINEER_SUBCONTRACTORS].DefaultView.[0].GeneralWSIB") %>'/>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblGeneralInsuranceCertificate" runat="server" EnableViewState="False" Text="Insurance Certificate given to client?" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="cbxGeneralInsuranceCertificate" runat="server" SkinID="CheckBox" Text="Yes" Checked='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_ENGINEER_SUBCONTRACTORS].DefaultView.[0].GeneralInsuranceCertificate") %>'/>
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
                                            </table>    
                                        </contenttemplate>       
                                    </asp:UpdatePanel>   
                                        
                                    <asp:UpdatePanel id="upnlTermsPO" runat="server">
                                        <contenttemplate>                                             
                                             <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                </tr>
                                                
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblWhatIsVehicleAccessLike" runat="server" EnableViewState="True" SkinID="Label" Text="What is vehicle access like?"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <%--<asp:DropDownList ID="ddlVehicleAccess" runat="server" SkinID="DropDownList" Width="290px">
                                                        </asp:DropDownList>--%>
                                                        <asp:CheckBox ID="ckbxVehicleAccessRoad" runat="server" SkinID="CheckBox" Text="Road" />
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>                                                
                                                        <asp:CheckBox ID="ckbxVehicleAccessEasement" runat="server" SkinID="CheckBox" Text="Easement" />
                                                    </td>
                                                    <td> </td>
                                                    <td> </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>                                                
                                                        <asp:CheckBox ID="ckbxVehicleAccessOther" runat="server" SkinID="CheckBox" Text="Other" />
                                                    </td>
                                                    <td> </td>
                                                    <td> </td>
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
                                            </table>    
                                        </contenttemplate>       
                                    </asp:UpdatePanel>   
                                                                                                                       
                                     <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width:177px"></td>
                                            <td style="width:177px"></td>
                                            <td style="width:177px"></td>
                                            <td style="width:177px"></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel id="upnlEngineerSubcontractors3" runat="server">
                                                    <contenttemplate> 
                                                        <asp:Label ID="lblGeneralBondingSupplied" runat="server" EnableViewState="False" Text="Bonding supplied?" SkinID="Label"></asp:Label>
                                                    </contenttemplate> 
                                                </asp:UpdatePanel>    
                                            </td>
                                            <td>
                                                <asp:UpdatePanel id="upnlEngineerSubcontractors5" runat="server">
                                                    <contenttemplate>
                                                        <asp:Label ID="lblBondNumber" runat="server" EnableViewState="False" Text="Bond number" SkinID="Label"></asp:Label>    
                                                    </contenttemplate>      
                                                </asp:UpdatePanel> 
                                            </td>
                                            <td>
                                                <asp:UpdatePanel id="upnlTermsPO2" runat="server">
                                                    <contenttemplate> 
                                                        <asp:Label ID="lblPurchaseOrderNumber" runat="server" EnableViewState="False" Text="Purchase Order Number" SkinID="Label"></asp:Label>
                                                    </contenttemplate>      
                                                </asp:UpdatePanel>     
                                            </td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel id="upnlEngineerSubcontractors2" runat="server">
                                                    <contenttemplate>                                                                                            
                                                        <asp:DropDownList ID="ddlGeneralBondingSupplied" runat="server" SkinID="DropDownList" Width="167px" SelectedValue='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_ENGINEER_SUBCONTRACTORS].DefaultView.[0].GeneralBondingSupplied") %>'>
                                                                <asp:ListItem Selected="True">NA</asp:ListItem>
                                                                <asp:ListItem>Yes</asp:ListItem>
                                                            </asp:DropDownList>
                                                    </contenttemplate> 
                                                </asp:UpdatePanel>
                                            </td>
                                            <td>
                                                <asp:UpdatePanel id="upnlEngineerSubcontractors4" runat="server">
                                                    <contenttemplate> 
                                                        <asp:TextBox ID="tbxBondNumber" runat="server" SkinID="TextBox" Width="167px" Text='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_ENGINEER_SUBCONTRACTORS].DefaultView.[0].BondNumber") %>'></asp:TextBox>
                                                    </contenttemplate> 
                                                </asp:UpdatePanel>    
                                            </td>
                                            <td>
                                                <asp:UpdatePanel id="upnlTermsPO3" runat="server">
                                                    <contenttemplate> 
                                                        <asp:TextBox ID="tbxPurchaseOrderNumber" runat="server" SkinID="TextBox" Width="167px"></asp:TextBox>
                                                    </contenttemplate>      
                                                </asp:UpdatePanel>        
                                            </td>
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
                                    </table>
                                    
                                    <asp:UpdatePanel id="upnlEngineerSubcontractors6" runat="server">
                                        <contenttemplate>                                             
                                             <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblSubcontractorUsed" runat="server" EnableViewState="False" Text="Are Sub-Contractor being used?" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="cbxSubcontractorUsed" runat="server" SkinID="CheckBox" Text="Yes" Checked='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_ENGINEER_SUBCONTRACTORS].DefaultView.[0].SubcontractorUsed") %>'/>
                                                    </td>
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
                                                        <asp:Label ID="lblSubContractorAgreementIssuedToSubs" runat="server" EnableViewState="False" Text="Sub-contractor Agreement issued to subs?" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="cbxSubcontractorAgreement" runat="server" SkinID="CheckBox" Text="Yes"  EnableViewState="True"/>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSubcontractorWrittenQuote" runat="server" EnableViewState="False" Text="Subcontractor provided written quote?" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="cbxSubcontractorWrittenQuote" runat="server" SkinID="CheckBox" Text="Yes"  EnableViewState="True"/>
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
                                            </table> 
                                        </contenttemplate>
                                    </asp:UpdatePanel>
                                    
                                    
                                    
                                    <asp:UpdatePanel id="upnlSaleBillingPricingValues1" runat="server">
                                        <contenttemplate>   
                                            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                </tr>                                         
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblSubcontractorAmount" runat="server" EnableViewState="False" Text="Subcontractor amount" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="tbxBillSubcontractorAmount" runat="server" SkinID="TextBoxRight" Width="167px" Text='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_SALE_BILLING_PRICING].DefaultView.[0].BillSubcontractorAmount", "{0:n2}") %>'></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblBillSubcontractorAmount2" runat="server" Text="$" SkinID="Label" EnableViewState="False"></asp:Label>
                                                    </td>                                                                                                             
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
                                           </table> 
                                        </contenttemplate>
                                    </asp:UpdatePanel>       
                                    
                                    <asp:UpdatePanel id="upnlEngineerSubcontractors7" runat="server">
                                        <contenttemplate>                                             
                                             <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                </tr>    
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:Label ID="lblSubcontractorRole" runat="server" EnableViewState="False" Text="Sub – contractor role" SkinID="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">                                                        
                                                        <asp:TextBox ID="tbxSubcontractorRole" runat="server" Height="54px" SkinID="TextBox" TextMode="MultiLine" Width="680px"  EnableViewState="True"></asp:TextBox>
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
                                                        <asp:Label ID="lblDesiredOutcome" runat="server" EnableViewState="False" Text="What is the desired outcome (objective) of this project (Client perspective)?" SkinID="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">                                                        
                                                        <asp:TextBox ID="tbxDesireOutcomeOfProject" runat="server" Height="54px"  SkinID="TextBox" TextMode="MultiLine" Width="680px"></asp:TextBox>
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
                                            </table>       
                                        </contenttemplate>
                                    </asp:UpdatePanel>
                                                
                                    <asp:UpdatePanel id="upnlTermsPO1" runat="server">
                                        <contenttemplate>   
                                            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:Label ID="Label20" runat="server" EnableViewState="False" Text="Specific Reporting Needs?" SkinID="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">                                                        
                                                        <asp:TextBox ID="tbxSpecificReportingNeeds" runat="server" Height="54px"  SkinID="TextBox" TextMode="MultiLine" Width="680px"></asp:TextBox>
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
                                            </table>       
                                        </contenttemplate>
                                    </asp:UpdatePanel>
                                                
                                    <asp:UpdatePanel id="upnlNotes" runat="server">
                                        <contenttemplate>   
                                            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width:177px"></td>
                                                    <td style="width:177px"></td>
                                                    <td style="width:264px"></td>
                                                    <td style="width:90px"></td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblNotes" runat="server" EnableViewState="False" Text="Notes" SkinID="Label"></asp:Label>
                                                    </td>                                                
                                                    <td  colspan="2"> </td>
                                                    <td>
                                                        <asp:UpdatePanel id="upnlComments" runat="server">
                                                            <contenttemplate>
                                                                <asp:Button id="btnComments" onclick="btnNotesOnClick" runat="server" SkinID="Button" Text="Update" EnableViewState="False" Width="80px" ></asp:Button> 
                                                            </contenttemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:TextBox ID="tbxNotes" runat="server" Height="100px" SkinID="TextBoxReadOnly" TextMode="MultiLine" ReadOnly="true" Width="680px" EnableViewState="True"></asp:TextBox>
                                                    </td>
                                                </tr>                                                                                      
                                            </table>       
                                        </contenttemplate>
                                    </asp:UpdatePanel>
                                                                   
                                    <!-- Table element: 3 columns - Bottom space -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 30px">
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
                        
                        
                        <cc1:TabPanel ID="tpBudget" runat="server" HeaderText="Budget" OnClientClick="tpBudgetClientClick">
                            <ContentTemplate>
                                <div style="width: 710px; height: 1200px; overflow-y: auto;">
                                    <!-- Table element: 1 columns - budget grid -->
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblBudgetTitle" runat="server" EnableViewState="False"
                                                    SkinID="LabelTitle1" Text="Budgets"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                        </tr>  
                                    </table>
                                    
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">                                                                        
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblProjectBudgetCommand" runat="server" EnableViewState="False"
                                                    SkinID="LabelTitle2" Text="For Labour Hours"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="pnlBudget" runat="server" Height="271px" Width="484px" ScrollBars="Auto" SkinID="Panel"> 
                                                    <asp:UpdatePanel id="upnlBudget" runat="server">
                                                        <contenttemplate>
                                                            <asp:GridView ID="grdBudget" runat="server" SkinID="GridViewInTabs" Width="405px" ShowFooter="true"
                                                                AutoGenerateColumns="False" DataKeyNames="ProjectID,Work_,Function_,RefID" DataSourceID="odsBudget"
                                                                OnRowCommand="grdBudget_RowCommand" OnRowEditing="grdBudget_RowEditing"
                                                                OnRowUpdating="grdBudget_RowUpdating" OnRowDeleting="grdBudget_RowDeleting"
                                                                OnDataBound="grdBudget_DataBound"  >
                                                                <Columns>                                                        
                                                                    <asp:TemplateField HeaderText="ProjectID" Visible ="False">                                                                                                            
                                                                        <ItemTemplate>                
                                                                            <asp:Label ID="lblProjectID" runat="server" SkinID="Label" Text='<%# Eval("ProjectID") %>'></asp:Label>                                                                               
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:Label ID="lblProjectIDEdit" runat="server" SkinID="Label" Text='<%# Eval("ProjectID") %>'></asp:Label>
                                                                        </EditItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblProjectIDNew" runat="server" SkinID="Label" Text='<%# Eval("ProjectID") %>'></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    
                                                                    <asp:TemplateField HeaderText="Work_" Visible ="False">                                                                    
                                                                        <ItemTemplate>                                                                     
                                                                             <asp:Label ID="lblWork_" runat="server" SkinID="Label" Text='<%# Eval("Work_") %>'></asp:Label>                                                                                
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:Label ID="lblWork_Edit" runat="server" SkinID="Label" Text='<%# Eval("Work_") %>'></asp:Label>
                                                                        </EditItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblWork_New" runat="server" SkinID="Label" Text='<%# Eval("Work_") %>'></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    
                                                                    <asp:TemplateField HeaderText="Function_" Visible ="False">                                                                    
                                                                        <ItemTemplate>                                                                     
                                                                             <asp:Label ID="lblFunction_" runat="server" SkinID="Label" Text='<%# Eval("Function_") %>'></asp:Label>                                                                                
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:Label ID="lblFunction_Edit" runat="server" SkinID="Label" Text='<%# Eval("Function_") %>'></asp:Label>
                                                                        </EditItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblFunction_New" runat="server" SkinID="Label" Text='<%# Eval("Function_") %>'></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                    
                                                                    <asp:TemplateField HeaderText="RefID" Visible ="False">                                                                    
                                                                        <ItemTemplate>                                                                     
                                                                             <asp:Label ID="lblRefID" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>                                                                                
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:Label ID="lblRefIDEdit" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                        </EditItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblRefIDNew" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>                                                                                                                                                                                                    
                                                                        
                                                                    <asp:TemplateField  HeaderText="Type Of Work . Function">                                                                    
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblWorkFunction" runat="server" SkinID="Label" 
                                                                                Text='<%# Bind("WorkFunction") %>' Width="255px"></asp:Label>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:Label ID="lblWorkFunctionEdit" runat="server" SkinID="Label"
                                                                                Text='<%# Bind("WorkFunction") %>' Width="255px"></asp:Label>
                                                                        </EditItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:DropDownList Style="width: 255px" ID="ddlWorkFunctionNew" runat="server"
                                                                                SkinID="DropDownList" DataSourceID="odsWorkFunctionConcat" DataTextField="WorkFunctionConcat"
                                                                                DataValueField="WorkFunctionConcat">
                                                                            </asp:DropDownList>
                                                                        </FooterTemplate>
                                                                        <ItemStyle HorizontalAlign="Left" />
                                                                        <HeaderStyle Width="255px" />
                                                                    </asp:TemplateField>
                                                                    
                                                                    <asp:TemplateField HeaderText="Budget">                                                                    
                                                                        <HeaderStyle Width="90px" />   
                                                                        <ItemStyle HorizontalAlign="Right" />  
                                                                        <FooterStyle HorizontalAlign="Right" />                                      
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="tbxBudget_" style="text-align:right" runat="server" Width="80px" ReadOnly="true" SkinID="TextBoxReadOnly"  Text='<%# GetRound(Eval("Budget_"),2) %>'/>
                                                                        </ItemTemplate>
                                                                         <EditItemTemplate>
                                                                            <asp:TextBox ID="tbxBudget_Edit" style="text-align:right" runat="server" Width="80px" SkinID="TextBox" Text='<%# GetRound(Eval("Budget_"),2) %>'/>
                                                                        </EditItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:TextBox ID="tbxBudget_New" style="text-align:right" runat="server" Width="80px" SkinID="TextBox" />
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>
                                                                                                                                
                                                                    <asp:TemplateField HeaderText="KPI Target">                                                                    
                                                                        <HeaderStyle Width="90px" />   
                                                                        <ItemStyle HorizontalAlign="Right" />  
                                                                        <FooterStyle HorizontalAlign="Right" />                                      
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="tbxBudget" style="text-align:right" runat="server" Width="80px" ReadOnly="true" SkinID="TextBoxReadOnly" Text='<%# GetRound(Eval("Budget"),2) %>'/>
                                                                        </ItemTemplate>
                                                                         <EditItemTemplate>
                                                                            <asp:TextBox ID="tbxBudgetEdit" style="text-align:right" runat="server" Width="80px" SkinID="TextBox" Text='<%# GetRound(Eval("Budget"),2) %>'/>
                                                                        </EditItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:TextBox ID="tbxBudgetNew" style="text-align:right" runat="server" Width="80px" SkinID="TextBox" />
                                                                        </FooterTemplate>
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
                                                                                            <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" 
                                                                                                CommandName="Edit" ToolTip="Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png">
                                                                                            </asp:ImageButton>
                                                                                        </td>
                                                                                        <td style="width: 50%">
                                                                                            <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete"
                                                                                                CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this budget?");'
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
                                                        </contenttemplate>
                                                    </asp:UpdatePanel>
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
                                    
                                    <!-- For Vehicles -->
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">                                                                        
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblForVehicles" runat="server" EnableViewState="False"
                                                    SkinID="LabelTitle2" Text="For Vehicles"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblBudget" runat="server" EnableViewState="False"
                                                    SkinID="Label" Text="Budget"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 <asp:TextBox ID="tbxUnitsBudget" style="text-align:right" runat="server" SkinID="TextBox"></asp:TextBox>
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
                                    
                                    <!-- For Materials -->
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">                                                                        
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblTitleForMaterialsBudget" runat="server" EnableViewState="False"
                                                    SkinID="LabelTitle2" Text="For Materials"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblTitle2ForMaterialsBudget" runat="server" EnableViewState="False"
                                                    SkinID="Label" Text="Budget"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 <asp:TextBox ID="tbxMaterialsBudget" style="text-align:right" runat="server" SkinID="TextBox" ></asp:TextBox>
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
                                    
                                    <!-- For Other/Category -->
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">                                                                        
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblTitleForOtherCategory" runat="server" EnableViewState="False"
                                                    SkinID="LabelTitle2" Text="For Other/Category"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px">
                                            </td>
                                        </tr>
                                    </Table>
                                    
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">                                                                        
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblTitleForSubcontractors" runat="server" EnableViewState="False"
                                                    SkinID="LabelTitle2" Text="Subcontractors"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblSubcontractorsBudget" runat="server" EnableViewState="False"
                                                    SkinID="Label" Text="Budget"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 <asp:TextBox ID="tbxSubcontractorsBudget" style="text-align:right" runat="server" SkinID="TextBox"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                                                        
                                    <!-- Page element : Horizontal Rule -->
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    
                                    
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">                                                                        
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblTitleForHotels" runat="server" EnableViewState="False"
                                                    SkinID="LabelTitle2" Text="Hotels"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblHotelsBudget" runat="server" EnableViewState="False"
                                                    SkinID="Label" Text="Budget"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 <asp:TextBox ID="tbxHotelsBudget" style="text-align:right" runat="server" SkinID="TextBox"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <!-- Page element : Horizontal Rule -->
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    
                                    
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">                                                                        
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblTitleForBondings" runat="server" EnableViewState="False"
                                                    SkinID="LabelTitle2" Text="Bondings"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblBondingsBudget" runat="server" EnableViewState="False"
                                                    SkinID="Label" Text="Budget"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 <asp:TextBox ID="tbxBondingsBudget" style="text-align:right" runat="server" SkinID="TextBox"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <!-- Page element : Horizontal Rule -->
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    
                                    
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">                                                                        
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblTitleForInsurances" runat="server" EnableViewState="False"
                                                    SkinID="LabelTitle2" Text="Insurances"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblInsurancesBudget" runat="server" EnableViewState="False"
                                                    SkinID="Label" Text="Budget"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 <asp:TextBox ID="tbxInsurancesBudget" style="text-align:right" runat="server" SkinID="TextBox"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <!-- Page element : Horizontal Rule -->
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 30px">
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblTitleOthersBudget" runat="server" EnableViewState="False"
                                                    SkinID="LabelTitle2" Text="Other Categories"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Panel ID="pnlOtherCostsBudget" runat="server" Height="271px" Width="397px" ScrollBars="Auto"  SkinID="Panel"> 
                                                    <asp:UpdatePanel id="upnlOtherCostsBudget" runat="server">
                                                        <contenttemplate>
                                                             <asp:GridView ID="grdOtherCostsBudget" runat="server" SkinID="GridView" Width="380px" AutoGenerateColumns="False" DataKeyNames="ProjectID,Category,RefID" 
                                                                DataSourceID="odsOtherCostsBudget"  ShowFooter="true"
                                                                OnRowCommand="grdOtherCostsBudget_RowCommand" OnRowEditing="grdOtherCostsBudget_RowEditing"
                                                                OnRowUpdating="grdOtherCostsBudget_RowUpdating" OnRowDeleting="grdOtherCostsBudget_RowDeleting" OnDataBound="grdOtherCostsBudget_DataBound">
                                                                <Columns>                                                        
                                                                    <asp:TemplateField HeaderText="ProjectID" Visible ="False">                                                                                                            
                                                                        <ItemTemplate>                
                                                                            <asp:Label ID="lblProjectID" runat="server" SkinID="Label" Text='<%# Eval("ProjectID") %>'></asp:Label>                                                                               
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:Label ID="lblProjectIDEdit" runat="server" SkinID="Label" Text='<%# Eval("ProjectID") %>'></asp:Label>
                                                                        </EditItemTemplate>
                                                                        <FooterTemplate>
                                                                            <asp:Label ID="lblProjectIDNew" runat="server" SkinID="Label" Text='<%# Eval("ProjectID") %>'></asp:Label>
                                                                        </FooterTemplate>
                                                                    </asp:TemplateField>                                                                                                                                                                                                  
                                                                        
                                                                    <asp:TemplateField  HeaderText="Category">                                                                    
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblCategory" runat="server" Width="255px" SkinID="Label" Text='<%# Eval("Category") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlCategoryEdit" runat="server"
                                                                                            SkinID="DropDownList" Width="255px" EnableViewState="true">
                                                                                            <asp:ListItem Value="-1" Text="(Select a category)"></asp:ListItem>                                                                                                                    
                                                                                            <asp:ListItem Value="Rentals" Text="Rentals"></asp:ListItem>                                                                                                                                                                                                                                        
                                                                                            <asp:ListItem Value="Fuel" Text="Fuel"></asp:ListItem>
                                                                                            <asp:ListItem Value="Traffic Control" Text="Traffic Control"></asp:ListItem>
                                                                                            <asp:ListItem Value="Testing" Text="Testing"></asp:ListItem>
                                                                                            <asp:ListItem Value="Permits" Text="Permits"></asp:ListItem>                                                                                                                    
                                                                                            <asp:ListItem Value="Meals" Text="Meals"></asp:ListItem>
                                                                                            <asp:ListItem Value="Other" Text="Other"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvCategoryEdit" runat="server" ControlToValidate="ddlCategoryEdit"
                                                                                            Display="Dynamic" ErrorMessage="Please select a Category." InitialValue="-1" ValidationGroup="OtherCostsBudgetEdit"
                                                                                            SkinID="Validator" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </EditItemTemplate>
                                                                        <FooterTemplate>
                                                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                <tr>
                                                                                    <td style="height: 12px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlCategoryNew" runat="server"
                                                                                            SkinID="DropDownList" Width="255px" EnableViewState="true">
                                                                                            <asp:ListItem Value="-1" Text="(Select a category)"></asp:ListItem>                                                                                                                    
                                                                                            <asp:ListItem Value="Rentals" Text="Rentals"></asp:ListItem>                                                                                                                                                                                                                                        
                                                                                            <asp:ListItem Value="Fuel" Text="Fuel"></asp:ListItem>
                                                                                            <asp:ListItem Value="Traffic Control" Text="Traffic Control"></asp:ListItem>
                                                                                            <asp:ListItem Value="Testing" Text="Testing"></asp:ListItem>
                                                                                            <asp:ListItem Value="Permits" Text="Permits"></asp:ListItem>                                                                                                                    
                                                                                            <asp:ListItem Value="Meals" Text="Meals"></asp:ListItem>
                                                                                            <asp:ListItem Value="Other" Text="Other"></asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvCategoryNew" runat="server" ControlToValidate="ddlCategoryNew"
                                                                                            Display="Dynamic" ErrorMessage="Please select a Category." InitialValue="-1" ValidationGroup="OtherCostsBudgetAdd"
                                                                                            SkinID="Validator" EnableViewState="False"></asp:RequiredFieldValidator>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </FooterTemplate>
                                                                        <HeaderStyle Width="255px"></HeaderStyle>
                                                                    </asp:TemplateField>
                                                                                                                                
                                                                    <asp:TemplateField HeaderText="Budget">                                                                    
                                                                        <HeaderStyle Width="90px" />   
                                                                        <ItemStyle HorizontalAlign="Right" />  
                                                                        <FooterStyle HorizontalAlign="Right" />                                      
                                                                        <ItemTemplate>
                                                                            <asp:TextBox ID="tbxBudget" style="text-align:right" runat="server" Width="80px" ReadOnly="true" SkinID="TextBoxReadOnly" Text='<%# GetRound(Eval("Budget"),2) %>'/>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxBudgetEdit" style="text-align:right" runat="server" Width="80px" SkinID="TextBox" Text='<%# GetRound(Eval("Budget"),2) %>'/>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:CompareValidator ID="cvBudgetEdit" runat="server" Operator="DataTypeCheck"
                                                                                            Type="Currency" ControlToValidate="tbxBudgetEdit" ValidationGroup="OtherCostsBudgetEdit"
                                                                                            SkinID="Validator" Display="Dynamic" ErrorMessage="Invalid data. (use #.## format)">
                                                                                        </asp:CompareValidator>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </EditItemTemplate>
                                                                        <FooterTemplate>
                                                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                <tr>
                                                                                    <td style="height: 12px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxBudgetNew" style="text-align:right" runat="server" Width="80px" SkinID="TextBox" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:CompareValidator ID="cvBudgetNew" runat="server" Operator="DataTypeCheck"
                                                                                            Type="Currency" ControlToValidate="tbxBudgetNew" ValidationGroup="OtherCostsBudgetAdd"
                                                                                            SkinID="Validator" Display="Dynamic" ErrorMessage="Invalid data. (use #.## format)">
                                                                                        </asp:CompareValidator>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px">
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </FooterTemplate>
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
                                                                                            <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" 
                                                                                                CommandName="Edit" ToolTip="Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png">
                                                                                            </asp:ImageButton>
                                                                                        </td>
                                                                                        <td style="width: 50%">
                                                                                            <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete"
                                                                                                CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this budget?");'
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
                                                        </contenttemplate>
                                                    </asp:UpdatePanel>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <!-- Page element : Horizontal Rule -->
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 520px">
                                        <tr>
                                            <td style="width: 130px">
                                                <asp:Label ID="lblTotalBudgetForProject" runat="server" EnableViewState="False" Text="Total Budget for Project" SkinID="Label"></asp:Label>
                                            </td>
                                            <td style="width: 130px">
                                                <asp:Label ID="lblTotalProjectedRevenue" runat="server" EnableViewState="False" Text="Total Projected Revenue" SkinID="Label"></asp:Label>
                                            </td>
                                            <td style="width: 130px">
                                                <asp:Label ID="lblTotalProjectedProfit" runat="server" EnableViewState="False" Text="Total Projected Profit" SkinID="Label"></asp:Label>
                                            </td>
                                            <td style="width: 130px">
                                                <asp:Label ID="lblProjectedGrossMargin" runat="server" EnableViewState="False" Text="Projected Gross Margin" SkinID="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style="width:110px">
                                                            <asp:TextBox ID="tbxTotalBudgetForProject" style="text-align:right" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Width="100px"></asp:TextBox>
                                                        </td>
                                                        <td style="width:20px">
                                                            <asp:Label ID="lblTotalBudgetForProjectMoney" runat="server" Text="$" SkinID="Label" EnableViewState="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style="width:110px">
                                                            <asp:UpdatePanel id="UpdatePanel1" runat="server">
                                                                <contenttemplate>
                                                                    <asp:TextBox ID="tbxTotalProjectedRevenue" style="text-align:right" runat="server" SkinID="TextBox" Width="100px"></asp:TextBox>
                                                                </contenttemplate>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td style="width:20px">
                                                            <asp:Label ID="lblTotalProjectedRevenueMoney" runat="server" Text="$" SkinID="Label" EnableViewState="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style="width:110px">
                                                            <asp:TextBox ID="tbxTotalProjectedProfit" style="text-align:right" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Width="100px"></asp:TextBox>
                                                        </td>
                                                        <td style="width:20px">
                                                            <asp:Label ID="lblTotalProjectedProfitMoney" runat="server" Text="$" SkinID="Label" EnableViewState="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style="width:110px">
                                                            <asp:TextBox ID="tbxProjectedGrossMargin" style="text-align:right" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Width="100px"></asp:TextBox>
                                                        </td>
                                                        <td style="width:20px">
                                                            <asp:Label ID="lblProjectedGrossMarginMoney" runat="server" Text="%" SkinID="Label" EnableViewState="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>                                                
                                            </td>
                                            <td>
                                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="tbxTotalProjectedRevenue"
                                                    Display="Dynamic" ErrorMessage="Invalid data (use #.## format)" Operator="DataTypeCheck"
                                                    SkinID="Validator" Type="Currency" Width="120px" ValidationGroup="costingUpdatesData">
                                                </asp:CompareValidator>
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
                                                <asp:Label ID="lblInvoicedToDate" runat="server" EnableViewState="False" Text="Invoiced To Date" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblCostsIncurredToDate" runat="server" EnableViewState="False" Text="Costs Incurred To Date" SkinID="Label"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="lblActualGrossMarginToDate" runat="server" EnableViewState="False" Text="Actual Gross Margin To Date" SkinID="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style="width:110px">
                                                            <asp:TextBox ID="tbxInvoicedToDate" style="text-align:right" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Width="100px"></asp:TextBox>
                                                        </td>
                                                        <td style="width:20px">
                                                            <asp:Label ID="lblInvoicedToDateMoney" runat="server" Text="$" SkinID="Label" EnableViewState="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style="width:110px">
                                                            <asp:TextBox ID="tbxCostsIncurredToDate" style="text-align:right" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Width="100px"></asp:TextBox>
                                                        </td>
                                                        <td style="width:20px">
                                                            <asp:Label ID="lblCostsIncurredToDateMoney" runat="server" Text="$" SkinID="Label" EnableViewState="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style="width:110px">
                                                            <asp:TextBox ID="tbxActualGrossMarginToDate" style="text-align:right" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Width="100px"></asp:TextBox>
                                                        </td>
                                                        <td style="width:20px">
                                                            <asp:Label ID="lblActualGrossMarginToDateMoney" runat="server" Text="%" SkinID="Label" EnableViewState="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <!-- Table element: 1 column - Bottom space -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 30px">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
        
        
        
                        <%--<cc1:TabPanel ID="tpSaleBillingPricing" runat="server" HeaderText="Sale/Billing/Pricing" OnClientClick="tpSaleBillingPricingClientClick" >
                            <ContentTemplate>
                                <div style="width: 710px; height: 850px; overflow-y: auto;">
                                    <!-- Table element: 5 columns - Sale -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 710px">
                                        <tr>
                                            <td style="width: 142px">
                                                <asp:Label ID="lblSaleBibProject" runat="server" EnableViewState="False" Text="Bid Project" SkinID="Label"></asp:Label>
                                            </td>
                                            <td style="width: 142px">
                                                <asp:Label ID="lblSaleRFP" runat="server" EnableViewState="False" Text="RFP" SkinID="Label"></asp:Label>
                                            </td>
                                            <td style="width: 142px">
                                                <asp:Label ID="lblSaleSoleSource" runat="server" EnableViewState="False" Text="Sole Source" SkinID="Label"></asp:Label>
                                            </td>
                                            <td style="width: 142px">
                                                <asp:Label ID="lblSaleTermContract" runat="server" EnableViewState="False" Text="Term Contract" SkinID="Label"></asp:Label>
                                            </td>
                                            <td style="width: 142px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="cbxSaleBidProject" runat="server" SkinID="CheckBox" Checked='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_SALE_BILLING_PRICING].DefaultView.[0].SaleBidProject") %>' />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxSaleRFP" runat="server" SkinID="CheckBox" Checked='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_SALE_BILLING_PRICING].DefaultView.[0].SaleRFP") %>'/>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxSaleSoleSource" runat="server" SkinID="CheckBox" Checked='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_SALE_BILLING_PRICING].DefaultView.[0].SaleSoleSource") %>'/>
                                            </td>
                                            <td colspan="2">
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style ="width:30px">
                                                            <asp:CheckBox ID="cbxSaleTermContract" runat="server" SkinID="CheckBox" Checked='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_SALE_BILLING_PRICING].DefaultView.[0].SaleTermContract") %>'/>
                                                        </td>
                                                        <td style ="width:254px">
                                                            <asp:TextBox ID="tbxSaleTermContractDetail" runat="server" SkinID="TextBox" Width="244px" Text='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_SALE_BILLING_PRICING].DefaultView.[0].SaleTermContractDetail") %>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
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
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblSaleOther" runat="server" EnableViewState="False" Text="Other" SkinID="Label"></asp:Label>
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
                                            <td colspan="5">
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style ="width:30px">
                                                            <asp:CheckBox ID="cbxSaleOther" runat="server" SkinID="CheckBox" Checked='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_SALE_BILLING_PRICING].DefaultView.[0].SaleOther") %>'/>
                                                        </td>
                                                        <td style ="width:680px">
                                                            <asp:TextBox ID="tbxSaleOtherDetail" runat="server" SkinID="TextBox" Width="670px" Text='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_SALE_BILLING_PRICING].DefaultView.[0].SaleOtherDetail") %>'></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                </table>
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
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblSaleGettingJob" runat="server" EnableViewState="False" Text="% Chance Of Getting Job" SkinID="Label"></asp:Label>
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
                                                <asp:TextBox ID="tbxSaleGettingJob" runat="server" SkinID="TextBox" Width="132px" Text='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_SALE_BILLING_PRICING].DefaultView.[0].SaleGettingJob") %>'></asp:TextBox>
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
                                            <td>
                                                <asp:CompareValidator ID="cvSaleGettingJob" runat="server" ControlToValidate="tbxSaleGettingJob"
                                                    Display="Dynamic" ErrorMessage="Invalid data. (use # format)" Operator="DataTypeCheck"
                                                    SkinID="Validator" Type="Integer" ValidationGroup="salesBilingPricingData"></asp:CompareValidator>
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
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 710px">
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
                                    
                                    <!-- Table element: 5 columns - Billing -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 710px">
                                        <tr>
                                            <td style="width: 142px">
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
                                            <td>
                                                <asp:Label ID="" runat="server" EnableViewState="False" Text="Total Price Of Project" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="lblBillSubcontractorAmount" runat="server" EnableViewState="False" Text="Sub-Contractor Amount" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                
                                            </td>
                                            <td>
                                                
                                            </td>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style="width:122px">
                                                            <asp:TextBox ID="tbxBillSubcontractorAmount" runat="server" SkinID="TextBox" Width="112px" Text='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_SALE_BILLING_PRICING].DefaultView.[0].BillSubcontractorAmount", "{0:n2}") %>'></asp:TextBox>
                                                        </td>
                                                        <td style="width:20px">
                                                            <asp:Label ID="lblBillSubcontractorAmount2" runat="server" Text="$" SkinID="Label" EnableViewState="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CompareValidator ID="cvBillPriceSaleBillingPricing1" runat="server" ControlToValidate="tbxBillPriceSaleBillingPricing1"
                                                    ErrorMessage="Invalid data. (use #.## format)" Operator="DataTypeCheck" SkinID="Validator"
                                                    Type="Currency" Display="Dynamic" ValidationGroup="salesBilingPricingData"></asp:CompareValidator>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:CompareValidator ID="cvBillSubcontractorAmount" runat="server" ControlToValidate="tbxBillSubcontractorAmount"
                                                    ErrorMessage="Invalid data. (use #.## format)" Operator="DataTypeCheck" SkinID="Validator"
                                                    Type="Currency" Display="Dynamic" ValidationGroup="salesBilingPricingData"></asp:CompareValidator>
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
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblBillBidHardDollar" runat="server" EnableViewState="False" Text="Bid Hard Dollar" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBillPerUnit" runat="server" EnableViewState="False" Text="Per Unit" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblBillHourly" runat="server" EnableViewState="False" Text="Hourly" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:TextBox ID="tbxBillBidHardDollar" runat="server" SkinID="TextBox" Width="274px" Text='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_SALE_BILLING_PRICING].DefaultView.[0].BillBidHardDollar") %>'></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxBillPerUnit" runat="server" SkinID="CheckBox" Checked='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_SALE_BILLING_PRICING].DefaultView.[0].BillPerUnit") %>'/>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxBillHourly" runat="server" SkinID="CheckBox" Checked='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_SALE_BILLING_PRICING].DefaultView.[0].BillHourly") %>'/>
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
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblBillExpectExtras" runat="server" EnableViewState="False" SkinID="Label" Text="Do We Expect Extras?"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="5">
                                                <asp:TextBox ID="tbxBillExpectExtras" runat="server" SkinID="TextBox" Width="700px" Text='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_SALE_BILLING_PRICING].DefaultView.[0].BillExpectExtras") %>'></asp:TextBox>
                                            </td>                    
                                        </tr>
                                    </table>
                                    
                                    <!-- Page element : Horizontal Rule -->
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 710px">
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
                                    
                                    <!-- Page element: Section title - Charges -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 710px">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblCharges" runat="server" SkinID="LabelTitle1" Text="Charges" EnableViewState="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                        </tr>
                                    </table>		
                                    
                                    <!-- Table element: 5 columns - Charges -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 710px">
                                        <tr>
                                            <td style="width: 142px">
                                                <asp:Label ID="lblChargesWater" runat="server" EnableViewState="False" Text="Water Charges?" SkinID="Label" ></asp:Label>
                                            </td>
                                            <td style="width: 142px">
                                            </td>
                                            <td style="width: 142px">
                                                <asp:Label ID="lblChargesDisposal" runat="server" EnableViewState="False" Text="Disposal Charges?" SkinID="Label"></asp:Label>
                                            </td>
                                            <td style="width: 142px">
                                            </td>
                                            <td style="width: 142px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="cbxChargesWater" runat="server" SkinID="CheckBox" Text="&nbsp;Yes. How much" Checked='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_SALE_BILLING_PRICING].DefaultView.[0].ChargesWater") %>'/>
                                            </td>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style="width:122px">
                                                            <asp:TextBox ID="tbxChargesWaterAmount" runat="server" SkinID="TextBox" Width="112px" Text='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_SALE_BILLING_PRICING].DefaultView.[0].ChargesWaterAmount", "{0:n2}") %>'></asp:TextBox>
                                                        </td>
                                                        <td style="width:20px">
                                                            <asp:Label ID="lblChargesWaterAmoun2" runat="server" Text="$" SkinID="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                               </table>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxChargesDisposal" runat="server" SkinID="CheckBox" Text="&nbsp;Yes. How much" Checked='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_SALE_BILLING_PRICING].DefaultView.[0].ChargesDisposal") %>'/>
                                            </td>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style="width:122px">
                                                            <asp:TextBox ID="tbxChargesDisposalAmount" runat="server" SkinID="TextBox" Width="112px" Text='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_SALE_BILLING_PRICING].DefaultView.[0].ChargesDisposalAmount", "{0:n2}") %>'></asp:TextBox>
                                                        </td>
                                                        <td style="width:20px">
                                                            <asp:Label ID="lblChargesDisposalAmount2" runat="server" Text="$" SkinID="Label"></asp:Label>
                                                        </td>
                                                   </tr>
                                               </table>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:CompareValidator ID="cvChargesWaterAmount" runat="server" ControlToValidate="tbxChargesWaterAmount"
                                                    ErrorMessage="Invalid data. (use #.## format)" Operator="DataTypeCheck" SkinID="Validator"
                                                    Type="Currency" Display="Dynamic" ValidationGroup="salesBilingPricingData"></asp:CompareValidator>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:CompareValidator ID="cvChargesDisposalAmount" runat="server" ControlToValidate="tbxChargesDisposalAmount"
                                                    ErrorMessage="Invalid data. (use #.## format)" Operator="DataTypeCheck" SkinID="Validator"
                                                    Type="Currency" Display="Dynamic" ValidationGroup="salesBilingPricingData"></asp:CompareValidator>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <!-- Page element : Horizontal Rule -->
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 710px">
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
                                    
                                    <!-- Page element: Section title - Services -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 710px">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblServices" runat="server" SkinID="LabelTitle1" Text="Services" EnableViewState="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <!-- Page element: 1 column - grid -->
                                    <table cellpadding="0" cellspacing="0" width="0" style="width: 710px">                                        
                                        <tr>
                                            <td>                                                
                                                <asp:UpdatePanel id="upnlgrdServices" runat="server">
                                                    <contenttemplate>
                                                        <asp:GridView ID="grdServices" runat="server" SkinID="GridView" Width="650px"
                                                        AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ProjectID,RefID" DataSourceID="odsServiceGrid"
                                                        OnDataBound="grdServices_DataBound" OnRowDataBound="grdServices_RowDataBound" 
                                                        OnRowUpdating="grdServices_RowUpdating" OnRowCommand="grdServices_RowCommand" OnRowEditing="grdServices_RowEditing"
                                                        PageSize="5" ShowFooter="True" OnRowDeleting="grdServices_RowDeleting">
                                                            <Columns>                                                        
                                                                <asp:TemplateField HeaderText="ProjectID" Visible ="False">
                                                                    <EditItemTemplate>                                                                        
                                                                        <asp:Label ID="lblProjectID" runat="server" SkinID="Label" Text='<%# Eval("ProjectID") %>'></asp:Label>                                                                                
                                                                    </EditItemTemplate>  
                                                                                                                              
                                                                    <ItemTemplate>                
                                                                        <asp:Label ID="lblProjectID" runat="server" SkinID="Label" Text='<%# Eval("ProjectID") %>'></asp:Label>                                                                               
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="RefID" Visible ="False">
                                                                    <EditItemTemplate>                                           
                                                                        <asp:Label ID="lblRefId" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>                                                                                
                                                                    </EditItemTemplate>                                                
                                                                                
                                                                    <ItemTemplate>                                                                     
                                                                         <asp:Label ID="lblRefId" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>                                                                                
                                                                    </ItemTemplate>                                                                    
                                                                </asp:TemplateField>                                                      
                                                                                                                                                                                                    
                                                                    
                                                                <asp:TemplateField  HeaderText="Service">
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td>                                                                                
                                                                                        <asp:DropDownList ID="ddlServiceEdit" runat="server" DataSourceID="odsService"
                                                                                            DataTextField="Name" DataValueField="ServiceID"
                                                                                            SkinID="DropDownListLookup" Style="width: 155px">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                            <tr>
                                                                                <td style="height: 12px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>                                                                             
                                                                                    <asp:DropDownList ID="ddlServiceFooter" runat="server" DataSourceID="odsService"
                                                                                            DataTextField="Name" DataValueField="ServiceID"
                                                                                            SkinID="DropDownListLookup" Style="width: 155px">
                                                                                        </asp:DropDownList>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblService" runat="server" SkinID="Label" ></asp:Label>        
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="155px"></HeaderStyle>
                                                                </asp:TemplateField>
                                                                                                                            
                                                                <asp:TemplateField HeaderText="Description">
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxDescriptionEdit" runat="server" Text='<%# Eval("Description") %>' Width="154px"
                                                                                        SkinID="TextBox"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:CustomValidator ID="cvDescriptionEdit" runat="server" ControlToValidate="tbxDescriptionEdit"
                                                                                            Display="Dynamic" ErrorMessage="Please provide a Description for '(Other)' Service"
                                                                                            OnServerValidate="cvDescriptionEdit_ServerValidate" SkinID="Validator" ValidateEmptyText="True"
                                                                                            ValidationGroup="serviceDataEdit"></asp:CustomValidator></td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                            <tr>
                                                                                <td style="height: 12px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxDescriptionFooter" runat="server"  Width="154px"
                                                                                        SkinID="TextBox"></asp:TextBox>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CustomValidator ID="cvDescriptionFooter" runat="server" ControlToValidate="tbxDescriptionFooter"
                                                                                        Display="Dynamic" ErrorMessage="Please provide a Description for '(Other)' Service"
                                                                                        OnServerValidate="cvDescriptionFooter_ServerValidate" SkinID="Validator" ValidateEmptyText="True"
                                                                                        ValidationGroup="serviceDataAdd"></asp:CustomValidator></td>
                                                                            </tr>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblDescriptionService" runat="server" SkinID="Label" Text='<%# Eval("Description") %>'></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="154px"></HeaderStyle>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Quantity">
                                                                    <EditItemTemplate>
                                                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxQuantityEdit" runat="server" Text='<%# Eval("Quantity") %>' Width="58px"
                                                                                        SkinID="TextBox"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CompareValidator ID="cvQuantityEdit" runat="server" ControlToValidate="tbxQuantityEdit"
                                                                                        Display="Dynamic" ErrorMessage="Invalid data (use # format)" Operator="DataTypeCheck"
                                                                                        SkinID="Validator" Type="Integer" ValidationGroup="serviceDataEdit">
                                                                                   </asp:CompareValidator>
                                                                                   <asp:CustomValidator
                                                                                            ID="cvQuantityEmptyEdit" runat="server" ControlToValidate="tbxQuantityEdit" Display="Dynamic"
                                                                                            ErrorMessage="Please provide a Quantity greater than 0" SkinID="Validator" ValidateEmptyText="True"
                                                                                            ValidationGroup="serviceDataEdit" OnServerValidate="cvQuantityEmptyEdit_ServerValidate"></asp:CustomValidator></td>
                                                                            </tr>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    <FooterTemplate>
                                                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                            <tr>
                                                                                <td style="height: 12px">
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxQuantityFooter" runat="server"  Width="58px"
                                                                                        SkinID="TextBox"></asp:TextBox></td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:CompareValidator ID="cvQuantityFooter" runat="server" ControlToValidate="tbxQuantityFooter"
                                                                                        Display="Dynamic" ErrorMessage="Invalid data (use # format)" Operator="DataTypeCheck"
                                                                                        SkinID="Validator" Type="Integer" ValidationGroup="serviceDataAdd">
                                                                                    </asp:CompareValidator>
                                                                                    <asp:CustomValidator ID="cvQuantityEmptyFooter" runat="server" ControlToValidate="tbxQuantityFooter"
                                                                                        Display="Dynamic" ErrorMessage="Please provide a Quantity greater than 0" SkinID="Validator"
                                                                                        ValidateEmptyText="True" ValidationGroup="serviceDataAdd" OnServerValidate="cvQuantityEmptyFooter_ServerValidate"></asp:CustomValidator></td>
                                                                            </tr>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    <ItemTemplate>
                                                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblQuantity" runat="server" Text='<%# Eval("Quantity") %>' SkinID="Label"></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="58px"></HeaderStyle>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Average Size">
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxAverageSizeEdit" runat="server" SkinID="TextBox" Text='<%# Eval("AverageSize", "{0:n2}") %>'
                                                                                            Width="83px"></asp:TextBox>                                                                                                                                                                </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:CustomValidator ID="cvAverageSizeEdit" runat="server" ControlToValidate="tbxAverageSizeEdit"
                                                                                            Display="Dynamic" ErrorMessage="Please provide a valid Average Size" OnServerValidate="cvAverageSizeEdit_ServerValidate"
                                                                                            SkinID="Validator" ValidationGroup="serviceDataEdit"></asp:CustomValidator></td>
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
                                                                                        <asp:TextBox ID="tbxAverageSizeFooter" runat="server" SkinID="TextBox" Width="83px"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:CustomValidator ID="cvAverageSizeFooter" runat="server" ControlToValidate="tbxAverageSizeFooter"
                                                                                            Display="Dynamic" ErrorMessage="Please provide a valid Average Size" OnServerValidate="cvAverageSizeFooter_ServerValidate"
                                                                                            SkinID="Validator" ValidationGroup="serviceDataAdd"></asp:CustomValidator></td>
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
                                                                                    <td>
                                                                                        <asp:Label ID="lblAverageSize" runat="server" SkinID="Label" Text='<%# Eval("AverageSize", "{0:n2}") %>'></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="83px"></HeaderStyle>
                                                                </asp:TemplateField>                                                                                               
                                                                
                                                                <asp:TemplateField HeaderText="Average Price">
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td align="right">
                                                                                        <asp:TextBox ID="tbxAveragePriceEdit" runat="server" SkinID="TextBox" Text='<%# Eval("AveragePrice", "{0:n2}") %>'
                                                                                            Width="88px" ></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right">
                                                                                        <asp:CompareValidator ID="cvAveragePriceEdit" runat="server" ControlToValidate="tbxAveragePriceEdit"
                                                                                            Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                            Operator="DataTypeCheck" SkinID="Validator" Type="Currency" ValidationGroup="serviceDataEdit"></asp:CompareValidator>
                                                                                        <asp:CustomValidator ID="cvAveragePriceValidationEdit" runat="server" ControlToValidate="tbxAveragePriceEdit"
                                                                                            Display="Dynamic" ErrorMessage="Please provide a Average Price equal or greater than 0"
                                                                                            OnServerValidate="cvAveragePriceValidationEdit_ServerValidate" SkinID="Validator"
                                                                                            ValidationGroup="serviceDataEdit"></asp:CustomValidator></td>
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
                                                                                    <td align="right">
                                                                                        <asp:TextBox ID="tbxAveragePriceFooter" runat="server" SkinID="TextBox" Width="82px" ></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right">
                                                                                        <asp:CompareValidator ID="cvAveragePriceFooter" runat="server" ControlToValidate="tbxAveragePriceFooter"
                                                                                            Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                            Operator="DataTypeCheck" SkinID="Validator" Type="Currency" ValidationGroup="serviceDataAdd"></asp:CompareValidator>
                                                                                        <asp:CustomValidator ID="cvAveragePriceValidationFooter" runat="server" ControlToValidate="tbxAveragePriceFooter"
                                                                                            Display="Dynamic" ErrorMessage="Please provide a Average Price equal or greater than 0"
                                                                                            OnServerValidate="cvAveragePriceValidationFooter_ServerValidate" SkinID="Validator"
                                                                                            ValidationGroup="serviceDataAdd"></asp:CustomValidator></td>
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
                                                                                    <td align="right">
                                                                                        <asp:Label ID="lblAveragePrice" runat="server" SkinID="Label" Text='<%# Eval("AveragePrice", "{0:n2}") %>'></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="82px"></HeaderStyle>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Total">
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td align="right">
                                                                                        <asp:Label ID="lblTotalEdit" runat="server" SkinID="Label" Text='<%# Eval("Total", "{0:n2}") %>'></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
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
                                                                                    <td align="right">
                                                                                        <asp:Label ID="lblTotalFooter" runat="server" SkinID="Label"></asp:Label>
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
                                                                                    <td align="right">
                                                                                        <asp:Label ID="lblTotal" runat="server" SkinID="Label" Text='<%# Eval("Total", "{0:n2}") %>'></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="83px"></HeaderStyle>
                                                                </asp:TemplateField>
                                                                                                                      
                                                                <asp:TemplateField>
                                                                    <EditItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" CommandName="Update"
                                                                                            ImageUrl="./../../App_Themes/LFS2/images/gridview/update.png"></asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" CommandName="Cancel"
                                                                                            ImageUrl="./../../App_Themes/LFS2/images/gridview/cancel.png"></asp:ImageButton>
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
                                                                                        <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" CommandName="Add"
                                                                                            ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png"></asp:ImageButton>
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
                                                                                        <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" CommandName="Edit"
                                                                                            ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png"></asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" CommandName="Delete"
                                                                                            ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png" OnClientClick='return confirm("Are you sure you want to delete this service?");'>
                                                                                        </asp:ImageButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="50px"></HeaderStyle>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>                                                                                             
                                                    </contenttemplate>
                                                </asp:UpdatePanel>
                                                                                                         
                                            </td>
                                        </tr>
                                        <tr>
                                            <td >                    
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 710px" >
                                                    <tr>                                               
                                                        <td style="width: 477px;">
                                                        </td>                                                        
                                                        <td style="width: 70px; text-align: right;">
                                                            <asp:Label ID="lblTotal" runat="server" SkinID="Label" Text="Total:"></asp:Label></td>
                                                        <td style="width: 73px; text-align: right;">
                                                            <asp:UpdatePanel id="upnlTotalCost" runat="server">
                                                                <contenttemplate>
<asp:TextBox id="tbxTotalCost" tabIndex=-1 runat="server" SkinID="TextBoxRightReadOnly" Width="63px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox> 
</contenttemplate>
                                                            </asp:UpdatePanel>        
                                                        </td>
                                                        <td style="width: 100px;">
                                                        </td>  
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px">
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <!-- Table element: 5 columns - Bottom space -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 710px">
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
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>--%>
                        
                        
                        
                        <%--<cc1:TabPanel ID="tpCostingUpdates" runat="server" HeaderText="Costing Updates" OnClientClick="tpCostingUpdatesClientClick">
                            <ContentTemplate>
                                <div style="width: 710px; height: 850px; overflow-y: auto;">
                                    <!-- Table element: 5 columns - Costing -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 700px">
                                        <tr>
                                            <td style="width: 130px">
                                                <asp:Label ID="lblExtrasToDate" runat="server" EnableViewState="False" Text="Extras To Date" SkinID="Label"></asp:Label>
                                            </td>
                                            <td style="width: 130px">
                                                <asp:Label ID="lblInvoicedToDate" runat="server" EnableViewState="False" Text="Invoiced To Date" SkinID="Label"></asp:Label>
                                            </td>
                                            <td style="width: 130px">
                                                <asp:Label ID="lblCostsIncurred" runat="server" EnableViewState="False" Text="Costs Incurred" SkinID="Label"></asp:Label>
                                            </td>
                                            <td style="width: 130px">
                                                <asp:Label ID="lblCostToComplete" runat="server" EnableViewState="False" Text="Cost To Complete" SkinID="Label"></asp:Label>
                                            </td>
                                            <td style="width: 180px">
                                                <asp:Label ID="lblOriginalProfitEstimated" runat="server" EnableViewState="False" Text="Original Profit Estimated" SkinID="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style="width:110px">
                                                            <asp:TextBox ID="tbxExtrasToDate" runat="server" SkinID="TextBox" Width="100px"></asp:TextBox>
                                                        </td>
                                                        <td style="width:20px">
                                                            <asp:Label ID="lblExtrasToDate2" runat="server" Text="$" SkinID="Label" EnableViewState="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style="width:110px">
                                                            <asp:TextBox ID="tbxInvoicedToDate" runat="server" SkinID="TextBox" Width="100px"></asp:TextBox>
                                                        </td>
                                                        <td style="width:20px">
                                                            <asp:Label ID="lblInvoicedToDate2" runat="server" Text="$" SkinID="Label" EnableViewState="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style="width:110px">
                                                            <asp:TextBox ID="tbxCostsIncurred" runat="server" SkinID="TextBox" Width="100px"></asp:TextBox>
                                                        </td>
                                                        <td style="width:20px">
                                                            <asp:Label ID="lblCostsIncurred2" runat="server" Text="$" SkinID="Label" EnableViewState="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style="width:110px">
                                                            <asp:TextBox ID="tbxCostToComplete" runat="server" SkinID="TextBox" Width="100px"></asp:TextBox>
                                                        </td>
                                                        <td style="width:20px">
                                                            <asp:Label ID="lblCostToComplete2" runat="server" Text="$" SkinID="Label" EnableViewState="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style="width:110px">
                                                            <asp:TextBox ID="tbxOriginalProfitEstimated" runat="server" SkinID="TextBox" Width="100px"></asp:TextBox>
                                                        </td>
                                                        <td style="width:20px">
                                                            <asp:Label ID="lblOriginalProfitEstimated2" runat="server" Text="$" SkinID="Label" EnableViewState="False"></asp:Label>
                                                        </td>
                                                        <td style="width:50px">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CompareValidator ID="cvExtrasToDate" runat="server" ControlToValidate="tbxExtrasToDate"
                                                    Display="Dynamic" ErrorMessage="Invalid data (use #.## format)" Operator="DataTypeCheck"
                                                    SkinID="Validator" Type="Currency" Width="120px" ValidationGroup="costingUpdatesData"></asp:CompareValidator>
                                            </td>
                                            <td>
                                                <asp:CompareValidator ID="cvInvoicedToDate" runat="server" ControlToValidate="tbxInvoicedToDate"
                                                    Display="Dynamic" ErrorMessage="Invalid data (use #.## format)" Operator="DataTypeCheck"
                                                    SkinID="Validator" Type="Currency" Width="120px" ValidationGroup="costingUpdatesData"></asp:CompareValidator>
                                            </td>
                                            <td>
                                                <asp:CompareValidator ID="cvCostsIncurred" runat="server" ControlToValidate="tbxCostsIncurred"
                                                    Display="Dynamic" ErrorMessage="Invalid data (use #.## format)" Operator="DataTypeCheck"
                                                    SkinID="Validator" Type="Currency" Width="120px" ValidationGroup="costingUpdatesData"></asp:CompareValidator>
                                            </td>
                                            <td>
                                                <asp:CompareValidator ID="cvCostToComplete" runat="server" ControlToValidate="tbxCostToComplete"
                                                    Display="Dynamic" ErrorMessage="Invalid data (use #.## format)" Operator="DataTypeCheck"
                                                    SkinID="Validator" Type="Currency" Width="120px" ValidationGroup="costingUpdatesData"></asp:CompareValidator>
                                            </td>
                                            <td>
                                                <asp:CompareValidator ID="cvOriginalProfitEstimated" runat="server" ControlToValidate="tbxOriginalProfitEstimated"
                                                    Display="Dynamic" ErrorMessage="Invalid data (use #.## format)" Operator="DataTypeCheck"
                                                    SkinID="Validator" Type="Currency" Width="120px" ValidationGroup="costingUpdatesData"></asp:CompareValidator>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <!-- Table element: 5 columns - Bottom space -->
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
                                        </tr>
                                    </table>
                                    
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>--%>
                        
                        
                        
                        <%--<cc1:TabPanel ID="tpTermsPo" runat="server" HeaderText="Terms/P.O." OnClientClick="tpTermsPoClientClick">
                            <ContentTemplate>
                                <div style="width: 710px; height: 850px; overflow-y: auto;">
                                    <!-- Page element: 1 column - Title -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">     
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblLiquidatedDamage_" runat="server" EnableViewState="False" SkinID="LabelTitle1" Text="Liquidated Damage"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <!-- Table element: 4 columns - Liquidated Damages -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 600px">
                                        <tr>
                                            <td style="width: 25%;">
                                            </td>
                                            <td style="width: 25%;">
                                            </td>
                                            <td style="width: 25%;">
                                            </td>
                                            <td style="width: 25%;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblLiquidatedDamages" runat="server" EnableViewState="False" Text="Liquidated Damages?" SkinID="Label"></asp:Label>
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
                                                <asp:CheckBox ID="cbxLiquidatedDamages" runat="server" SkinID="CheckBox" Text="Yes. If yes how much&nbsp;"/>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxLiquidatedDamagesRate" runat="server" SkinID="TextBox" Width="100px"></asp:TextBox>
                                                <asp:Label ID="lblPer" runat="server" EnableViewState="False" SkinID="Label" Text="$&nbsp;&nbsp; per"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="tbxLiquidatedDamagesUnit" runat="server" SkinID="TextBox" Width="100px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>                                                
                                                <asp:CompareValidator ID="cvLiquidateRate" runat="server" ControlToValidate="tbxLiquidatedDamagesRate"
                                                    Display="Dynamic" ErrorMessage="Invalid data. (use #.## format)" Operator="DataTypeCheck"
                                                    SkinID="Validator" Type="Currency" Width="140px" ValidationGroup="termsPOData">
                                                </asp:CompareValidator>
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
                                    
                                    <!-- Page element: 1 column - Title -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblClientLFSRelationship" runat="server" EnableViewState="False" SkinID="LabelTitle1" Text="Client / LFS Relationship"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                        </tr>
                                    </table>
        
                                    <!-- Table element: 4 columns - Client / LFS Relationship -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 600px">            
                                        <tr>
                                            <td style="width: 25%;">
                                            </td>
                                            <td style="width: 25%">
                                            </td>
                                            <td style="width: 25%">
                                            </td>
                                            <td style="width: 25%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblHaveWeWorkedTogetherBefore" runat="server" EnableViewState="False" SkinID="Label" Text="Have we worked together before?"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="cbxWorkedBefore" runat="server" SkinID="CheckBox" Text="Yes." />
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px">
                                            </td>
                                            <td >
                                            </td>
                                            <td>
                                            </td>
                                            <td >
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Label ID="lblQuirks" runat="server" EnableViewState="False" SkinID="Label" Text="Quirks (example: Big on Tri-Pod usage, home-owner involvement)"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:TextBox ID="tbxClientQuirks" runat="server" Height="35px" SkinID="TextBox" TextMode="MultiLine" Width="590px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="height: 7px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Label ID="lblPromiseToFulfill" runat="server" EnableViewState="False" SkinID="Label" Text="Have we made any promises that operations needs to fulfill?"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <asp:CheckBox ID="cbxClientPromises" runat="server" SkinID="CheckBox" Text="Yes. If yes explain:" />&nbsp;
                                            </td>
                                            <td colspan="3">
                                                <asp:TextBox ID="tbxClientPromises" runat="server" Height="35px" SkinID="TextBox" TextMode="MultiLine" Width="440px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="height: 7px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblWhereDoWeObtainWater" runat="server" EnableViewState="False" SkinID="Label" Text="Where do we obtain water?"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="lblWhereDoWeDisposeMaterials" runat="server" EnableViewState="False" SkinID="Label" Text="Where do we dispose materials?"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:TextBox ID="tbxWaterObtain" runat="server" SkinID="TextBox" Width="290px"></asp:TextBox>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="tbxMaterialDispose" runat="server"  SkinID="TextBox" Width="290px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px;">
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
                                                <asp:Label ID="lblDoWeRequireRPZForHydrant" runat="server" EnableViewState="False" SkinID="Label" Text="Do we require an RPZ for the hydrant?"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="cbxRequireRPZ" runat="server" SkinID="CheckBox" Text="Yes."/>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td >
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
                                                <asp:Label ID="lblWhatIsTheStandardHydrantFitting" runat="server" EnableViewState="False" SkinID="Label" Text="What is the standard hydrant fitting?"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:TextBox ID="tbxStandardHydrantFitting" runat="server"  SkinID="TextBox" Width="590px"></asp:TextBox>
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
                                                <asp:Label ID="lblIsAPreConstructionMeetingNeeded" runat="server" EnableViewState="False" SkinID="Label" Text="Is a Pre-Construction Meeting Needed?"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="cbxPreConstructionMeetingNeed" runat="server" SkinID="CheckBox" Text="Yes." />
                                            </td>
                                            <td>
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
                                                <asp:Label ID="lblSpecificMeetingLoation" runat="server" EnableViewState="False" SkinID="Label" Text="Specific Meeting Location?"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <asp:CheckBox ID="cbxSpecificMeetingLocation" runat="server" SkinID="CheckBox" Text="Yes. If yes explain:" />&nbsp;
                                            </td>
                                            <td colspan="3">
                                                <asp:TextBox ID="tbxSpecificMeetingLocation" runat="server" Height="35px" SkinID="TextBox" TextMode="MultiLine" Width="440px"></asp:TextBox>
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
                                                <asp:Label ID="lblWhatIsVehicleAccessLike1" runat="server" EnableViewState="False" SkinID="Label" Text="What is vehicle access like?"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                
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
                                            <td colspan="4">
                                                <asp:TextBox ID="tbxVehicleAccess" runat="server" Height="35px"  SkinID="TextBox" TextMode="MultiLine" Width="590px"></asp:TextBox>
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
                                                <asp:Label ID="lblDesiredOutcomeOfProject" runat="server" EnableViewState="False" SkinID="Label" Text="What is the desired outcome (objective) of this project (client perspective)?"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                
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
                                                <asp:Label ID="lblSpecificReportingNeeds" runat="server" EnableViewState="False" SkinID="Label" Text="Specific Reporting Needs?"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                
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

                                    <!-- Page element: Section title - Purchase Order -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblPurchaceOrder" runat="server" SkinID="LabelTitle1" Text="Purchase Order" EnableViewState="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                        </tr>
                                    </table>	
                                    	
                                    <!-- Table element: 4 columns - Purchase -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 600px">
                                        <tr>
                                            <td style="width: 25%" colspan="2">
                                                <asp:Label ID="lblPurchaseOrderNumber1" runat="server" EnableViewState="False" Text="Purchase Order Number" SkinID="Label"></asp:Label>
                                            </td>
                                            <td style="width: 25%" colspan="2">
                                                <asp:Label ID="lblPurchaseOrderAttached" runat="server" EnableViewState="False" Text="Purchase Order Attached?" SkinID="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxPurchaseOrderAttach" runat="server" SkinID="CheckBox" Text="Yes." />
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
                                                <asp:Label ID="lblPurchaseOrderWillNotProvidedPleaseExplain" runat="server" EnableViewState="False" SkinID="Label" Text="If a purchase order will not provided please explain (Written Notice To Proceed? Etc)"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:TextBox ID="tbxPurchaseOrderWillNotProvided" runat="server" Height="35px" SkinID="TextBox" TextMode="MultiLine" Width="590px"></asp:TextBox>
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
                        </cc1:TabPanel>--%>
                        
                        
                        
                        <%--<cc1:TabPanel ID="tpTechnical" runat="server" HeaderText="Technical" OnClientClick="tpTechnicalClientClick">
                            <ContentTemplate>
                                <div style="width: 710px; height: 850px; overflow-y: auto;">
                                    <!-- Table element: 4 columns - Technical -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 600px">
                                        <tr>
                                            <td style="width: 25%">
                                            </td>
                                            <td style="width: 25%">
                                            </td>
                                            <td style="width: 25%">
                                            </td>
                                            <td style="width: 25%">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblAvailableDrawings" runat="server" EnableViewState="False" SkinID="Label" Text="Are drawings available?"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="lblAvailableVideo1" runat="server" EnableViewState="False" SkinID="Label" Text="Is there a video available?"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
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
                                                <asp:Label ID="lblGroundconditions" runat="server" EnableViewState="False" SkinID="Label" Text="What are ground conditions like (are bore holes available fort the Vac-Ex Crew)?"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <asp:CheckBox ID="cbxGroundConditions" runat="server" SkinID="CheckBox" Text="Yes. If yes explain:" />&nbsp;
                                            </td>
                                            <td colspan="3">
                                                <asp:TextBox ID="tbxGroundCondition" runat="server" Height="35px" SkinID="TextBox" TextMode="MultiLine" Width="440px"></asp:TextBox>
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
                                            <td colspan="3">
                                                <asp:Label ID="lblReviewVideoInspections" runat="server" EnableViewState="False" SkinID="Label" Text="Have we reviewed the video inspections on the lines?"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="cbxReviewVideoInspections" runat="server" SkinID="CheckBox" Text="Yes." />
                                            </td>
                                            <td>
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
                                            <td colspan="4">
                                                <asp:Label ID="lbLStrangeConfigurations" runat="server" EnableViewState="False" SkinID="Label" Text="Are there any strange configurations that may cause a problem during installation?"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <asp:CheckBox ID="cbxStrangeConfigurations" runat="server" SkinID="CheckBox" Text="Yes. If yes explain:" />&nbsp;
                                            </td>
                                            <td colspan="3">
                                                <asp:TextBox ID="tbxStrangeConfigurations" runat="server" Height="35px"  SkinID="TextBox" TextMode="MultiLine" Width="440px"></asp:TextBox>
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
                                                <asp:Label ID="lblFurtherObservations" runat="server" EnableViewState="False" SkinID="Label" Text="Further observations?"></asp:Label>
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
                                                <asp:TextBox ID="tbxFurtherObservations" runat="server" Height="35px" SkinID="TextBox" TextMode="MultiLine" Width="590px"></asp:TextBox>
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
                                                <asp:Label ID="lblRestrictiveFactors" runat="server" EnableViewState="False" SkinID="Label" Text="Restrictive Factors?"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:TextBox ID="tbxRestrictiveFactors" runat="server" Height="35px" SkinID="TextBox" TextMode="MultiLine" Width="590px"></asp:TextBox>
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
                        </cc1:TabPanel>--%>
                        
                        
                        
                        <%--<cc1:TabPanel ID="tpEngineerSubcontractors" runat="server" HeaderText="Eng./Subcontractors" OnClientClick="tpEngineerSubcontractorsClientClick">
                            <ContentTemplate>
                                <div style="width: 710px;">
                                    <!-- Table element: 3 columns - Engineer/Subcontractors -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                         <tr>
                                            <td style="width: 237px">
                                            </td>
                                            <td style="width: 237px">
                                            </td>
                                            <td style="width: 236px">
                                            </td>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblGeneralContractor" runat="server" EnableViewState="False" Text="Are we the general contractor?" SkinID="Label"></asp:Label>
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
                                                <asp:Label ID="lblGeneralWSIB1" runat="server" EnableViewState="False" Text="WSIB given to client?" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGeneralInsuranceCertificate1" runat="server" EnableViewState="False" Text="Insurance Certificate given to client?" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style="width: 115px">
                                                            <asp:Label ID="lblGeneralBondingSupplied1" runat="server" EnableViewState="False" Text="Bonding supplied?" SkinID="Label"></asp:Label>
                                                        </td>
                                                        <td style="width: 115px">
                                                            <asp:Label ID="lblBondNumber1" runat="server" EnableViewState="False" Text="Bond number" SkinID="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                                 </table>
                                            </td>
                                       </tr>
                                        <tr>
                                            <td>
                                                
                                            </td>
                                            <td>
                                                
                                            </td>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style="width: 115px">
                                                            
                                                        </td>
                                                        <td style="width: 115px">
                                                            
                                                        </td>
                                                    </tr>
                                                </table>
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
                                                <asp:Label ID="lblGeneralMOLForm" runat="server" EnableViewState="False" Text="MOL Form completed and sent in?" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGeneralNoticeProject" runat="server" EnableViewState="False" Text="Notice of Project if we are the General" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGeneralForm1000" runat="server" EnableViewState="False" Text="Form 1000 if we are a Sub-Contractor" SkinID="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralMOLForm" runat="server" SkinID="TextBoxReadOnly" Width="110px" ReadOnly="True" Text='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_ENGINEER_SUBCONTRACTORS].DefaultView.[0].GeneralMOLForm") %>'></asp:TextBox>&nbsp;
                                                <asp:DropDownList ID="ddlGeneralMOLForm" runat="server" SkinID="DropDownList" Width="110px" SelectedValue='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_ENGINEER_SUBCONTRACTORS].DefaultView.[0].GeneralMOLForm") %>'>
                                                    <asp:ListItem Selected="True">NA</asp:ListItem>
                                                    <asp:ListItem>Yes</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rbtnGeneralNoticeProject" runat="server" GroupName="MOLForm" Checked='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_ENGINEER_SUBCONTRACTORS].DefaultView.[0].GeneralNoticeProject") %>'/>
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rbtnGeneralForm1000" runat="server" GroupName="MOLForm" Checked='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_ENGINEER_SUBCONTRACTORS].DefaultView.[0].GeneralForm1000") %>'/>
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
                                    
                                    <!-- Page element: Section title - Engineering Firm -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblEngineeringFirm" runat="server" SkinID="LabelTitle1" Text="Engineering Firm" EnableViewState="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                        </tr>
                                    </table>	
                                    
                                    <!-- Table element: 3 columns - Engineer/Subcontractors -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                         <tr>
                                            <td style="width: 237px">
                                            </td>
                                            <td style="width: 237px">
                                            </td>
                                            <td style="width: 236px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblEngineeringFirmId" runat="server" EnableViewState="False" Text="What Engineering Firm is involved?" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblEngineerId" runat="server" EnableViewState="False" Text="Engineer Name" SkinID="Label"></asp:Label>&nbsp;
                                            </td>
                                            <td>
                                                <asp:Label ID="lblEngineerNumber" runat="server" EnableViewState="False" Text="Engineer Number" SkinID="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlEngineeringFirmId" runat="server" SkinID="DropDownList" Width="227px" SelectedValue='<%# GetEngineeringFirmId(DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_ENGINEER_SUBCONTRACTORS].DefaultView.[0].EngineeringFirmID")) %>'>
                                                </asp:DropDownList>
                                            </td>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style="width: 197px">
                                                            <asp:DropDownList ID="ddlEngineerId" runat="server" SkinID="DropDownList" Width="187px" SelectedValue='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_ENGINEER_SUBCONTRACTORS].DefaultView.[0].EngineerID") %>'>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="width: 40px">
                                                            <asp:Button ID="btnEngineerId" runat="server" Text="..." SkinID="Button" Width="30px" OnClientClick="return btnEngineerIdClick();" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxEngineerNumber" runat="server" SkinID="TextBox" Width="226px" Text='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_ENGINEER_SUBCONTRACTORS].DefaultView.[0].EngineerNumber") %>'></asp:TextBox>
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
                                    
                                    <!-- Page element: Section title - Subcontractors -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblSubcontractors" runat="server" SkinID="LabelTitle1" Text="Sub-Contractors" EnableViewState="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                        </tr>
                                    </table>	
                                    
                                    <!-- Table element: 3 columns - Subcontractors -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 230px">
                                            </td>
                                            <td style="width: 230px">
                                            </td>
                                            <td style="width: 230px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblSubcontractorUsed1" runat="server" EnableViewState="False" Text="Are Sub-Contractor being used?" SkinID="Label"></asp:Label>
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
                                    </table>    
                                    
                                    <!-- Page element : No Results -->
                                    <table id="tNoResults" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%" class="Background_NavigatorsNoResults">
                                        <tr runat="server">
                                            <td id="tdNoResults" runat="server">
                                                <asp:Label ID="lblNoResults" runat="server" Text="Sub-Contrators are not defined for this project" ></asp:Label>
                                            </td>
                                        </tr>
                                    </table>  
                                    
		                            <!-- Page element: 1 column - Grid Subcontractors -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="grdvSubcontractors" runat="server" AutoGenerateColumns="False" GridLines="None" PageSize="1" 
                                                 Width="100%" DataKeyNames="RefID" ShowHeader="False" OnPreRender="grdvSubcontractors_PreRender" 
                                                 OnRowCommand="grdvSubcontractors_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <!-- Table element : 3 columns - Subcontractor row -->
                                                                <table border="0" cellpadding="0" cellspacing="0" style="width: 700px;" class="Background_ViewGrid_Table">
                                                                    <tr>
                                                                        <td colspan="3" style="text-align: center;" class="Background_ViewGrid_Header">
                                                                            <asp:Label ID="lblTitle" runat="server" EnableViewState="False" SkinID="ViewGridHeader" Text="Sub-Contractor"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="width: 20px" class="Background2_ViewGrid_Td">
                                                                        </td>
                                                                        <td style="width: 680px">
                                                                        
                                                                            <!-- Table element : 3 columns - Subcontractor data -->
                                                                            <table border="0" cellspacing="0" cellpadding="0" style="width: 680px;" 
                                                                                  class="Background2_ViewGrid_Td">
                                                                                <tr>
                                                                                   <td style="width: 227px; height: 20px">
                                                                                        <asp:HiddenField ID="hdfRefId" runat="server" Value='<%# Eval("RefID") %>'/>
                                                                                    </td>
                                                                                    <td style="width: 227px">
                                                                                    </td>
                                                                                    <td style="width: 226px;">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblSubcontractorId" runat="server" EnableViewState="False" Text="Client" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblRoyalties" runat="server" EnableViewState="False" Text="Royalties (%)" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:DropDownList ID="ddlSubcontractorId" runat="server" SkinID="DropDownList" Width="217px" DataSourceID="odsCompanies" DataTextField="NAME" DataValueField="COMPANIES_ID" SelectedValue='<%# GetSubContratorID(Eval("SubcontractorID")) %>'>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxRoyalties" runat="server" SkinID="TextBox" Width="217px" Text='<%# Eval("Royalties") %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvSubcontractorId" runat="server" ControlToValidate="ddlSubcontractorId"
                                                                                            Display="Dynamic" ErrorMessage="Please select a Sub-Contractor" InitialValue="-1"
                                                                                            SkinID="Validator" EnableViewState="True" ValidationGroup="subContractorData"></asp:RequiredFieldValidator>
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
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblSubcontractorWrittenQuote" runat="server" EnableViewState="False" Text="Has he provided a written quote?" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblSubcontractorSurveyedSite" runat="server" EnableViewState="False" Text="Has he surveyed the site?" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblSubcontractorWorkedBefore" runat="server" EnableViewState="False" Text="Have we worked before?" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="cbxSubcontractorSurveyedSite" runat="server" SkinID="CheckBox" Text="Yes" Checked='<%# Eval("SurveyedSite") %>' EnableViewState="True"/>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="cbxSubcontractorWorkedBefore" runat="server" SkinID="CheckBox" Text="Yes" Checked='<%# Eval("WorkedBefore") %>' EnableViewState="True"/>
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
                                                                                    <td colspan="3">
                                                                                        <asp:Label ID="lblSubcontractorRole" runat="server" EnableViewState="False" Text="Explain the role of the sub-contractor" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="3">
                                                                                        
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
                                                                                    <td colspan="3">
                                                                                        <asp:Label ID="lblSubcontractorAgreement" runat="server" EnableViewState="False" Text="Has a Sub-Contractor agreement been issued to Sub´s?" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        
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
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="3">
                                                                                        <asp:Label ID="lblSubcontractorIssues" runat="server" EnableViewState="False" Text="Issues with Sub?" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="3">
                                                                                        <asp:TextBox ID="tbxSubcontractorIssues" runat="server" Height="44px" SkinID="TextBox" TextMode="MultiLine" Width="670px" Text='<%# Eval("Issues") %>' EnableViewState="True"></asp:TextBox>
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
                                                                                        <asp:Label ID="lblSubcontractorPurchaseOrder" runat="server" EnableViewState="False" Text="Is Purchase Order included?" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblSubcontractorInsuranceCertificate" runat="server" EnableViewState="False" Text="Is Sub Insurance Certificate included?" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblSubcontractorWSIB" runat="server" EnableViewState="False" Text="Is Sub WSIB included?" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="cbxSubcontractorPurchaseOrder" runat="server" SkinID="CheckBox" Text="Yes" Checked='<%# Eval("PurchaseOrder") %>' EnableViewState="True"/>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="cbxSubcontractorInsuranceCertificate" runat="server" SkinID="CheckBox" Text="Yes" Checked='<%# Eval("InsuranceCertificate") %>' EnableViewState="True"/>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="cbxSubcontractorWSIB" runat="server" SkinID="CheckBox" Text="Yes" Checked='<%# Eval("WSIB") %>' EnableViewState="True"/>
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
                                                                                        <asp:Label ID="lblSubcontractorMOLForm1000" runat="server" EnableViewState="False" Text="Is MOL Form 1000 from Sub included?" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxSubcontractorMOLForm1000" runat="server" SkinID="TextBoxReadOnly" Width="110px" ReadOnly="True" Text='<%# Eval("MOLForm1000") %>' EnableViewState="True"></asp:TextBox>
                                                                                        <asp:DropDownList ID="ddlSubcontractorMOLForm1000" runat="server" SkinID="DropDownList" Width="107px" SelectedValue='<%# Eval("MOLForm1000") %>'>
                                                                                            <asp:ListItem>NA</asp:ListItem>
                                                                                            <asp:ListItem>Yes</asp:ListItem>
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td style="text-align: right">
                                                                                        <asp:Button ID="btnDeleteSubcontractor" runat="server" SkinID="Button" Text="Delete" Width="80px" CommandName="deleteSubcontractor" CommandArgument='<%# Eval("RefID") %>' OnClientClick="return btnDeleteSubcontractorClick();" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 20px">
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td style="width: 10px" class="Background2_ViewGrid_Td">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                                
                                                                <!-- Table element : Space inter rows -->
                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                                    <tr>
                                                                        <td style="height: 35px">
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>

                                    <!-- Table element: 3 columns - Bottom space -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 30px">
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>--%>
                        
                        
                        
                        <%--<cc1:TabPanel ID="tpCostExceptions" runat="server" HeaderText="Cost Excep." OnClientClick="tpCostExceptionsClientClick">
                            <ContentTemplate>
                                <div style="width: 710px; height: 850px; overflow-y: auto;">
                                
                                    <!-- Table element: 3 columns - Engineer/Subcontractors -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                         <tr>
                                            <td style="width: 237px">
                                            </td>
                                            <td style="width: 237px">
                                            </td>
                                            <td style="width: 236px">
                                            </td>
                                             <tr>
                                                 <td>
                                                     <asp:Label ID="lblFairWageApplies1" runat="server" EnableViewState="False" 
                                                         SkinID="Label" Text="Fair Wage Applies?"></asp:Label>
                                                 </td>
                                                 <td>
                                                 </td>
                                                 <td>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td>
                                                     <asp:UpdatePanel id="uplFairWageApplies1" runat="server">
                                                         <contenttemplate>
                                                            <asp:CheckBox ID="cbxFairWageApplies1" runat="server" 
                                                             Checked='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT].DefaultView.[0].FairWageApplies") %>' 
                                                             SkinID="CheckBox" Text="Yes" AutoPostBack="True" 
                                                             oncheckedchanged="cbxFairWageApplies_CheckedChanged" />
                                                        </contenttemplate>
                                                     </asp:UpdatePanel>
                                                 </td>
                                                 <td>
                                                 </td>
                                                 <td>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td colspan="3">
                                                     <asp:CustomValidator ID="cvFairWageApplies" runat="server" Display="Dynamic" 
                                                         ErrorMessage="Old projects could not be Fair Wage." 
                                                         OnServerValidate="cvFairWageApplies_ServerValidate" SkinID="Validator" 
                                                         ValidationGroup="costExceptionsData"></asp:CustomValidator>
                                                 </td>
                                             </tr>
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
                                    
                                    <!-- Page element: Section title - Fair Wage Rates -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblFairWageRates" runat="server" SkinID="LabelTitle1" Text="Fair Wage Rates" EnableViewState="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                        </tr>
                                    </table>                                    
                                                                   
                                    <!-- Page element: Section title - Job Class Classification -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 710px">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblJobClassTypeRate1" runat="server" SkinID="Label" 
                                                    Text="Job Class Classification" EnableViewState="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px">
                                            </td>
                                        </tr>
                                    </table>
        
                                    
                                                                   
                                    <!-- Table element: 3 columns - Bottom space -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 30px">
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>     --%>
                        
                        
                        
                        <%--<cc1:TabPanel ID="tpNotes" runat="server" HeaderText="Notes" OnClientClick="tpNotesClientClick">
                            <ContentTemplate>
                                <div style="width: 710px;">
                                
                                    <table>                                        
                                        <tr>
                                            <td>
                                                <asp:UpdatePanel id="upnlNotes1" runat="server">
                                                    <contenttemplate>
                                                         <asp:GridView ID="grdNotes" runat="server" SkinID="GridViewInTabs" Width="700px"
                                                            ShowFooter="True" AutoGenerateColumns="False" 
                                                            DataKeyNames="ProjectID,RefID" OnDataBound="grdNotes_DataBound" OnRowCommand="grdNotes_RowCommand"
                                                            OnRowDeleting="grdNotes_RowDeleting" OnRowUpdating="grdNotes_RowUpdating" OnRowEditing="grdNotes_RowEditing" 
                                                            OnRowDataBound="grdNotes_RowDataBound" DataSourceID="odsNotes">
                                                            <Columns>
                                                                <asp:TemplateField SortExpression="ProjectID" Visible="False" HeaderText="ProjectID">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblProjectIDEdit" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblProjectID" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label>
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
                                                                
                                                                
                                                                
                                                                <asp:TemplateField  Visible="False" HeaderText="FileName" >                                                            
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblFileNameEdit" runat="server" Text='<%# Eval("FILENAME") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblFileName" runat="server" Text='<%# Eval("FILENAME") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>  
                                                                
                                                                
                                                                
                                                                <asp:TemplateField  Visible="False" HeaderText="LIBRARY_FILES_ID" >                                                            
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
                                                                        <table style="width: 100%; vertical-align: top;" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 155px;">
                                                                                    </td>
                                                                                    <td style="width: 155px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteSubjectEdit" runat="server" SkinID="Label" Text="Subject" EnableViewState="False"></asp:Label></td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteSubjectEdit" runat="server" SkinID="TextBox"
                                                                                            Text='<%# Eval("Subject") %>'></asp:TextBox></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvNoteSubjectEdit" runat="server" SkinID="Validator"
                                                                                            EnableViewState="False" ValidationGroup="notesDataEdit" ErrorMessage="Please provide a subject."
                                                                                            Display="Dynamic" ControlToValidate="tbxNoteSubjectEdit"></asp:RequiredFieldValidator></td>
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
                                                                                        <asp:Label ID="lblNoteDateEdit" runat="server" SkinID="Label" Text="Date & Time" EnableViewState="False"></asp:Label></td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteCreatedByEdit" runat="server" SkinID="Label" Text="Created By"
                                                                                            EnableViewState="False"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        </td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="width: 145px" ID="tbxNoteDateEdit" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# Eval("DateTime") %>' ReadOnly="True"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="width: 145px" ID="tbxNoteCreatedByEdit" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# GetNoteCreatedBy(Eval("LoginID")) %>' ReadOnly="True"></asp:TextBox></td>
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
                                                                        <!-- Page element : 2 columns - Notes Information -->
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 160px;">
                                                                                    </td>
                                                                                    <td style="width: 160px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteSubjectNew" runat="server" SkinID="Label" Text="Subject" EnableViewState="False"></asp:Label></td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="1">
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteSubjectNew" runat="server" SkinID="TextBox"
                                                                                            Text='<%# Eval("Subject") %>' ></asp:TextBox></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvNoteSubjectNew" runat="server" SkinID="Validator"
                                                                                            EnableViewState="False" ValidationGroup="notesDataAdd" ErrorMessage="Please provide a subject."
                                                                                            Display="Dynamic" ControlToValidate="tbxNoteSubjectNew"></asp:RequiredFieldValidator></td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 12px">
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
                                                                        <!-- Page element : 2 columns - Notes Information -->
                                                                        <table style="width: 100%; vertical-align: top;" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 10px; height: 10px">
                                                                                    </td>
                                                                                    <td style="width: 160px;">
                                                                                    </td>
                                                                                    <td style="width: 160px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteSubject" runat="server" SkinID="Label" Text="Subject" EnableViewState="False"></asp:Label></td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td colspan="1">
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteSubject" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# Eval("Subject") %>' ReadOnly="True"></asp:TextBox></td>
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
                                                                                        <asp:Label ID="lblNoteDate" runat="server" SkinID="Label" Text="Date & Time" EnableViewState="False"></asp:Label></td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteCreatedBy" runat="server" SkinID="Label" Text="Created By" EnableViewState="False"></asp:Label></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="width: 145px" ID="tbxNoteDate" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# Eval("DateTime") %>' ReadOnly="True"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <asp:TextBox Style="width: 145px" ID="tbxNoteCreatedBy" runat="server" SkinID="TextBoxReadOnly"
                                                                                            ReadOnly="True" Text='<%# GetNoteCreatedBy(Eval("LoginID")) %>'></asp:TextBox></td>
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
                                                                        <!-- Page element : 2 columns - Notes and attachment information -->
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
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteNoteEdit" runat="server" SkinID="Label" Text="Note" EnableViewState="False"></asp:Label></td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteNoteEdit" runat="server" SkinID="TextBox"
                                                                                            Text='<%# Eval("Note") %>' TextMode="MultiLine" Rows="4"></asp:TextBox></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvNoteNoteEdit" runat="server" SkinID="Validator"
                                                                                            EnableViewState="False" ValidationGroup="notesDataEdit" ErrorMessage="Please provide a note."
                                                                                            Display="Dynamic" ControlToValidate="tbxNoteNoteEdit"></asp:RequiredFieldValidator></td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 7px">
                                                                                    </td>
                                                                                    <td></td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteAttachmentEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                                            Text="Attachment"></asp:Label></td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td style="vertical-align: top;">
                                                                                        <asp:TextBox ID="tbxNoteAttachmentEdit" runat="server" Rows="1" SkinID="TextBoxReadOnly" Style="width: 210px"
                                                                                            Text='<%# Eval("ORIGINAL_FILENAME") %>' Width="220px" ReadOnly="True"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <asp:Button ID="btnNoteDeleteEdit" CommandName="DeleteAttachmentEdit" CommandArgument='<%# Eval("RefID") %>' Width="80px" runat="server" SkinID="Button" Text="Delete" TabIndex="6" />
                                                                                        <asp:Button ID="btnNoteAddEdit" CommandName="AddAttachmentEdit" CommandArgument='<%# Eval("RefID") %>' Width="80px" runat="server" SkinID="Button" Text="Add" TabIndex="4" /></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px">
                                                                                    </td>
                                                                                    <td></td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </EditItemTemplate>
                                                                    
                                                                    <FooterTemplate>
                                                                        <!-- Page element : 2 columns - Notes and attachment information -->
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
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteNoteNew" runat="server" SkinID="Label" Text="Note" EnableViewState="False"></asp:Label></td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteNoteNew" runat="server" SkinID="TextBox"
                                                                                            Text='<%# Eval("Note") %>' Rows="1"></asp:TextBox></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvNoteNoteNew" runat="server" SkinID="Validator"
                                                                                            EnableViewState="False" ValidationGroup="notesDataAdd" ErrorMessage="Please provide a note"
                                                                                            Display="Dynamic" ControlToValidate="tbxNoteNoteNew"></asp:RequiredFieldValidator></td>
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
                                                                                            Text="Attachment"></asp:Label></td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxNoteAttachmentNew" runat="server" Rows="1" SkinID="TextBoxReadOnly" Style="width: 210px" Text='<%# Eval("ORIGINAL_FILENAME") %>' ReadOnly="True"></asp:TextBox>
                                                                                        <asp:Label ID="lblFileNameNoteAttachmentNew" runat="server" SkinID="Label" Text='<%# Eval("FILENAME") %>' Visible ="False"/>    
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Button ID="btnAddFooter" Width="80px" runat="server" SkinID="Button" Text="Add" TabIndex="4" CommandName="AddAttachmentAdd" CommandArgument='<%# Eval("RefID") %>' /></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 12px">
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
                                                                        <!-- Page element : 2 columns - Notes and attachment information -->
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
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteNote" runat="server" SkinID="Label" Text="Note" EnableViewState="False"></asp:Label></td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteNote" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# Eval("Note") %>' ReadOnly="True" TextMode="MultiLine" Rows="4"></asp:TextBox></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td colspan="2" style="height: 7px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteAttachment" runat="server" EnableViewState="False" SkinID="Label"
                                                                                            Text="Attachment"></asp:Label></td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxNoteAttachment" runat="server" Rows="1" SkinID="TextBoxReadOnly" Style="width: 200px"
                                                                                            Text='<%# Eval("ORIGINAL_FILENAME") %>' Width="220px" ReadOnly="True"></asp:TextBox></td>
                                                                                    <td style="vertical-align: top">
                                                                                        <asp:Button ID="btnNoteDownload" CommandName="DownloadAttachment" CommandArgument='<%# Eval("RefID") %>' Width="80px" runat="server" SkinID="Button" Text="Download"/></td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td style="height: 10px" colspan="3">
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
                                                                                        <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" CommandName="Update"
                                                                                            ToolTip="Update" ImageUrl="./../../App_Themes/LFS2/images/gridview/update.png"></asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" CommandName="Cancel"
                                                                                            ToolTip="Cancel" ImageUrl="./../../App_Themes/LFS2/images/gridview/cancel.png"></asp:ImageButton>
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
                                                                                        <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" CommandName="Add"
                                                                                            ToolTip="Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png"></asp:ImageButton>
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
                                                                                        <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" CommandName="Edit"
                                                                                            ToolTip="Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png"></asp:ImageButton>
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" CommandName="Delete"
                                                                                            OnClientClick='return confirm("Are you sure you want to delete this note?");'
                                                                                            ToolTip="Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png"></asp:ImageButton>
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
                                                <asp:TextBox ID="tbxCategoryAssocited" Width="610px" ReadOnly="True" runat="server" SkinID="TextBoxReadOnly" TabIndex="7"></asp:TextBox>
                                            </td>
                                            <td style=" width: 88px">
                                                <asp:Button ID="btnAssociate" runat="server" SkinID="Button" Text="Associate" Width="80px" OnClientClick="return btnAssociateClick();" TabIndex="8" />
                                                <asp:Button ID="btnUnassociate" runat="server" SkinID="Button" Text="Unassociate" OnClick="btnUnassociate_Click" OnClientClick="return btnUnassociateClick();" Width="80px" TabIndex="9" />
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
                                            </td>
                                        </tr>
                                    </table>                                    
                                
                                    <!-- Table element: 2 columns - Bottom space -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 30px">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                           

                        </cc1:TabPanel>--%>
                        
                        
                        
                  </cc1:TabContainer>
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
        
        
        
        <!-- Page element : Data objects -->
		<table  border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsCompanies" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.RAF.CompaniesList" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="companiesId" Type="Int32" />
                            <asp:Parameter DefaultValue="" Name="name" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsService" runat="server" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Services.Services.ServiceList" CacheDuration="1800" EnableCaching="True">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="serviceId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Other)" Name="name" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>                    
                    <asp:ObjectDataSource ID="odsNotes" runat="server"
                        FilterExpression="(Deleted = 0)" SelectMethod="GetNotesNew" TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_edit" DeleteMethod="DummyNotesNew" InsertMethod="DummyNotesNew" UpdateMethod="DummyNotesNew">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsServiceGrid" runat="server"
                        FilterExpression="(Deleted = 0)" SelectMethod="GetServiceNew" TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_edit" DeleteMethod="DummyServiceNew" InsertMethod="DummyServiceNew" UpdateMethod="DummyServiceNew">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsTypeOfWorkFunctionClassificationGrid" runat="server"
                        FilterExpression="(Deleted = 0)" SelectMethod="GetTypeOfWorkFunctionClassificationNew" TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_edit" 
                        DeleteMethod="DummyTypeOfWorkFunctionClassificationNew" InsertMethod="DummyTypeOfWorkFunctionClassificationNew" UpdateMethod="DummyTypeOfWorkFunctionClassificationNew">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsBudget" runat="server"
                        FilterExpression="(Deleted = 0)" SelectMethod="GetTypeOfWorkFunctionBudgetNew" TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_edit" 
                        DeleteMethod="DummyTypeOfWorkFunctionBudgetNew" InsertMethod="DummyTypeOfWorkFunctionBudgetNew" UpdateMethod="DummyTypeOfWorkFunctionBudgetNew">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsSubcontractorsBudget" runat="server"
                        FilterExpression="(Deleted = 0)" SelectMethod="GetSubcontractorsBudgetNew" TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_edit" 
                        DeleteMethod="DummySubcontractorsBudgetNew" InsertMethod="DummySubcontractorsBudgetNew" UpdateMethod="DummySubcontractorsBudgetNew">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsHotelsBudget" runat="server"
                        FilterExpression="(Deleted = 0)" SelectMethod="GetHotelsBudgetNew" TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_edit" 
                        DeleteMethod="DummyHotelsBudgetNew" InsertMethod="DummyHotelsBudgetNew" UpdateMethod="DummyHotelsBudgetNew">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsBondingsBudget" runat="server"
                        FilterExpression="(Deleted = 0)" SelectMethod="GetBondingsBudgetNew" TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_edit" 
                        DeleteMethod="DummyBondingsBudgetNew" InsertMethod="DummyBondingsBudgetNew" UpdateMethod="DummyBondingsBudgetNew">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsInsurancesBudget" runat="server"
                        FilterExpression="(Deleted = 0)" SelectMethod="GetInsurancesBudgetNew" TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_edit" 
                        DeleteMethod="DummyInsurancesBudgetNew" InsertMethod="DummyInsurancesBudgetNew" UpdateMethod="DummyInsurancesBudgetNew">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsOtherCostsBudget" runat="server"
                        FilterExpression="(Deleted = 0)" SelectMethod="GetOtherCostsBudgetNew" TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_edit" 
                        DeleteMethod="DummyOtherCostsBudgetNew" InsertMethod="DummyOtherCostsBudgetNew" UpdateMethod="DummyOtherCostsBudgetNew">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsJobClassClassificationGrid" runat="server"
                        FilterExpression="(Deleted = 0)" SelectMethod="GetJobClassClassificationNew" TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_edit" 
                        DeleteMethod="DummyJobClassClassificationNew" InsertMethod="DummyJobClassClassificationNew" UpdateMethod="DummyJobClassClassificationNew">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsWorkFunctionConcat" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.LabourHours.TeamProjectTime.TeamProjectTimeWorkFunctionConcatList"
                        OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select)" Name="workFunctionConcat" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsJobClassType" runat="server" SelectMethod="LoadAndAddItem" 
                        TypeName="LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTimeJobClassTypeList" CacheDuration="60" EnableCaching="True">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name="countryId" Type="Int32" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue=" " Name="jobClassType" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                     <asp:ObjectDataSource ID="odsSubcontractorsList" runat="server" CacheDuration="60" EnableCaching="True" 
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.Subcontractors.SubcontractorsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="subcontractorId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select a subcontractor)" Name="name" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsHotelsList" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.Hotels.HotelsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="hotelId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select a hotel)" Name="name" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsBondingsList" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.BondingCompanies.BondingCompaniesList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="bondingCompanyId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select a Bonding Company)" Name="name" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsInsurancesList" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.InsuranceCompanies.InsuranceCompaniesList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="insuranceCompanyId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select a Insurance Company)" Name="name" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                </td>
            </tr>
		</table>
		
		
            
		<!-- Page element : Tag page -->
		<table  border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfProjectId" runat="server" />
                    <asp:HiddenField ID="hdfClientId" runat="server" />
                    <asp:HiddenField ID="hdfBeforeUnloadOrigen" runat="server" />
                    <asp:HiddenField ID="hdfDataChanged" runat="server" />
                    <asp:HiddenField ID="hdfDataChangedMessage" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfActiveTab" runat="server" />
                    <asp:HiddenField ID="hdfLoginId" runat="server" />
                    <asp:HiddenField ID="hdfCreatedBy" runat="server" />
                    <asp:HiddenField ID="hdfCreationDateTime" runat="server" Value="no" />                    
                </td>
            </tr>
		</table>
		
		 
    </div>
</asp:Content>
