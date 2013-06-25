<%@ Page Language="C#" MasterPageFile="../../mForm6.master" AutoEventWireup="true" CodeBehind="project_summary.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Projects.Projects.project_summary" Title="LFS Live" %>

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
                    <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick" OnClientItemClicking="tkrmTopItemClicking">                        
                        <Items>
                            <telerik:RadMenuItem Value="mEdit" Text="EDIT" />
                            
                            <telerik:RadMenuItem Value="mProposal" Text="CHANGE STATE">
                                <items>
                                    <telerik:RadMenuItem Value="mProposalAward" Text="AWARD" />
                                    <telerik:RadMenuItem Value="mProposalLostBid" Text="LOST BID" />
                                    <telerik:RadMenuItem Value="mProposalCancel" Text="CANCEL" />
                                    <telerik:RadMenuItem Value="mProposalBidding" Text="BIDDING" />
                                    <telerik:RadMenuItem Text="" PostBack="false" style="margin: 1px 0 1px 0!important;padding: 0 0 0 0!important;">
                                        <ItemTemplate>
                                            <table style="width: 100%" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                     <td style="height: 5px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="height: 1px; width: 300px; background-color: #7F9DB9;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                     <td style="height: 5px">
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem  Value="mProposalUnpromoteToBallpark" Text="UNPROMOTE TO BALLPARK" />
                                    <telerik:RadMenuItem  Value="mProposalPromoteToProject" Text="PROMOTE TO PROJECT" />
                                </items>
                            </telerik:RadMenuItem>
                            
                            <telerik:RadMenuItem Value="mProject" Text="CHANGE STATE">
                                <items>
                                    <telerik:RadMenuItem Value="mProjectSetWaiting" Text="SET WAITING" />
                                    <telerik:RadMenuItem Value="mProjectActivate" Text="ACTIVATE" />
                                    <telerik:RadMenuItem Value="mProjectInactivate" Text="INACTIVATE" />
                                    <telerik:RadMenuItem Value="mProjectComplete" Text="COMPLETE" />
                                    <telerik:RadMenuItem Value="mProjectCancel" Text="CANCEL" />
                                    <telerik:RadMenuItem Text="" PostBack="false" style="margin: 1px 0 1px 0!important;padding: 0 0 0 0!important;">
                                        <ItemTemplate>
                                            <table style="width: 100%" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                     <td style="height: 5px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="height: 1px; width: 300px; background-color: #7F9DB9;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                     <td style="height: 5px">
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem  Value="mProjectUnpromoteToBallpark" Text="UNPROMOTE TO BALLPARK" />
                                    <telerik:RadMenuItem  Value="mProjectUnpromoteToProposal" Text="UNPROMOTE TO PROPOSAL" />
                                    <telerik:RadMenuItem Text="" PostBack="false" style="margin: 1px 0 1px 0!important;padding: 0 0 0 0!important;">
                                        <ItemTemplate>
                                            <table style="width: 100%" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                     <td style="height: 5px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="height: 1px; width: 300px; background-color: #7F9DB9;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                     <td style="height: 5px">
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem  Value="mProjectTagAsInternal" Text="TAG AS INTERNAL" />
                                </items>
                            </telerik:RadMenuItem>
                            
                            <telerik:RadMenuItem Value="mInternalProject" Text="CHANGE STATE">
                                <items>
                                    <telerik:RadMenuItem Value="mInternalProjectActivate" Text="ACTIVATE" />
                                    <telerik:RadMenuItem Value="mInternalProjectCancel" Text="CANCEL" />
                                    <telerik:RadMenuItem Value="mInternalProjectComplete" Text="COMPLETE" />
                                    <telerik:RadMenuItem Text="" PostBack="false" style="margin: 1px 0 1px 0!important;padding: 0 0 0 0!important;">
                                        <ItemTemplate>
                                            <table style="width: 100%" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                     <td style="height: 5px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="height: 1px; width: 300px; background-color: #7F9DB9;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                     <td style="height: 5px">
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem  Value="mInternalProjectPromoteToProposal" Text="PROMOTE TO PROPOSAL" />
                                    <telerik:RadMenuItem  Value="mInternalProjectPromoteToProject" Text="PROMOTE TO PROJECT" />
                                </items>
                            </telerik:RadMenuItem>
                            
                            <telerik:RadMenuItem Value="mBallparkProject" Text="CHANGE STATE">
                                <items>
                                    <telerik:RadMenuItem Value="mBallparkProjectActivate" Text="ACTIVATE" />
                                    <telerik:RadMenuItem Value="mBallparkProjectCancel" Text="CANCEL" />
                                    <telerik:RadMenuItem Text="" PostBack="false" style="margin: 1px 0 1px 0!important;padding: 0 0 0 0!important;">
                                        <ItemTemplate>
                                            <table style="width: 100%" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                     <td style="height: 5px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="height: 1px; width: 300px; background-color: #7F9DB9;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                     <td style="height: 5px">
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadMenuItem>
                                    <telerik:RadMenuItem  Value="mBallparkProjectPromoteToProposal" Text="PROMOTE TO PROPOSAL" />
                                    <telerik:RadMenuItem  Value="mBallparkProjectPromoteToProject" Text="PROMOTE TO PROJECT" />
                                </items>
                            </telerik:RadMenuItem>                           
                            
                            <telerik:RadMenuItem Value="mViewWorks" Text="WORKS">
                                <items>
                                    <telerik:RadMenuItem Value="mRehabAssessment" Text="REHAB ASSESSMENT" />
                                    <telerik:RadMenuItem Value="mFullLenghtLining" Text="FULL LENGTH LINING" />
                                    <telerik:RadMenuItem Value="mPointRepairs" Text="POINT REPAIRS" />
                                    <telerik:RadMenuItem  Value="mJunctionLining" Text="JUNCTION LINING" />
                                </items>
                            </telerik:RadMenuItem>
                            
                            <telerik:RadMenuItem Value="mAddSubcontractor" Text="ADD SUBCONTRACTOR" />
                            
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



<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 750px;">
        <!-- Table element: 5 columns - Project/Proposal -->
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
                    <asp:TextBox ID="tbxName" runat="server" SkinID="TextBoxReadOnly" Width="290px" ReadOnly="True" Text='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT].DefaultView.[0].Name") %>' EnableViewState="True"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxProposalDate" runat="server" SkinID="TextBoxReadOnly" Width="140px" ReadOnly="True" Text='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT].DefaultView.[0].ProposalDate", "{0:d}") %>' EnableViewState="True"></asp:TextBox>
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
                <td >
                </td>
                <td >
                </td>
                <td >
                    <asp:Label ID="lblStartDate" runat="server" EnableViewState="False" Text="Potential Start Date" SkinID="Label"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="3" rowspan="4">
                    <asp:TextBox ID="tbxDescription" runat="server" Height="61px" ReadOnly="True" SkinID="TextBoxReadOnly" TextMode="MultiLine" 
                    Width="440px" Text='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT].DefaultView.[0].Description") %>' EnableViewState="True"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxStartDate" runat="server" SkinID="TextBoxReadOnly" Width="140px" ReadOnly="True" Text='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT].DefaultView.[0].StartDate", "{0:d}") %>' EnableViewState="True"></asp:TextBox>
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
                    <asp:Label ID="lblEndDate" runat="server" EnableViewState="False" Text="Potential End Date" SkinID="Label"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxEndDate" runat="server" SkinID="TextBoxReadOnly" Width="140px" ReadOnly="True" Text='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT].DefaultView.[0].EndDate", "{0:d}") %>' EnableViewState="True"></asp:TextBox>
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
                    <asp:TextBox ID="tbxClientName" runat="server" SkinID="TextBoxReadOnly" Width="290px" ReadOnly="True" EnableViewState="True"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxClientProjectNumber" runat="server" SkinID="TextBoxReadOnly" Width="140px" ReadOnly="True" Text='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT].DefaultView.[0].ClientProjectNumber") %>' EnableViewState="True"></asp:TextBox>
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
                    <asp:HiddenField ID="hdfClientPrimaryContactID" runat="server" Value='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT].DefaultView.[0].ClientPrimaryContactID") %>'/>
                </td>
                <td>
                    <asp:Label ID="lblClientSecondaryContactId" runat="server" EnableViewState="False" Text="Secondary Contact" SkinID="Label"></asp:Label>
                </td>
                <td>
                    <asp:HiddenField ID="hdfClientSecondaryContactID" runat="server" Value='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT].DefaultView.[0].ClientSecondaryContactID") %>' />
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                        <tr>
                            <td style="width: 260px">
                                <asp:TextBox ID="tbxClientPrimaryContact" runat="server" SkinID="TextBoxReadOnly" Width="250px" ReadOnly="True" EnableViewState="True"></asp:TextBox>
                            </td>
                            <td style="width: 30px">
                                <asp:Button ID="btnClientPrimaryContact" runat="server" Text="..." SkinID="Button" Width="30px" OnClientClick="return btnClientPrimaryContactClick();" EnableViewState="True" />
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
                                <asp:TextBox ID="tbxClientSecondaryContact" runat="server" SkinID="TextBoxReadOnly" Width="250px" ReadOnly="True" EnableViewState="True"></asp:TextBox>
                            </td>
                            <td style="width: 30px">
                                <asp:Button ID="btnClientSecondaryContact" runat="server" Text="..." SkinID="Button" Width="30px" OnClientClick="return btnClientSecondaryContactClick();" EnableViewState="True" />
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
                    <asp:TextBox ID="tbxProjectLead" runat="server" SkinID="TextBoxReadOnly" Width="290px" ReadOnly="True" EnableViewState="True"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="tbxSalesman" runat="server" SkinID="TextBoxReadOnly" Width="290px" ReadOnly="True" EnableViewState="True"></asp:TextBox>
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
                        <asp:TextBox ID="tbxBillPrice" style="text-align:right" runat="server" SkinID="TextBoxRightReadOnly" Width="140px" ReadOnly="True" EnableViewState="True"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="tbxBillMoney" runat="server" SkinID="TextBoxReadOnly" Width="60px" ReadOnly="True" EnableViewState="True"></asp:TextBox>
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
                    <cc1:TabContainer ID="tcDetailedInformation" Width="730px" runat="server" 
                        CssClass="ajax_tabcontainer" >
        
        
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
                                                <asp:CheckBox ID="ckbxMhRehab" runat="server" SkinID="CheckBox" Text="MH Rehab" onclick="return cbxClick();"/>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxJunctionLining" runat="server" SkinID="CheckBox" Text="Juntion Lining" onclick="return cbxClick();"/>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxProjectManagement" runat="server" SkinID="CheckBox" Text="Project Management" onclick="return cbxClick();"/>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxFullLengthLining" runat="server" SkinID="CheckBox" Text="Full Length Lining" onclick="return cbxClick();"/>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="ckbxPointRepairs" runat="server" SkinID="CheckBox" Text="Point Repairs" onclick="return cbxClick();"/>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxRehabAssessment" runat="server" SkinID="CheckBox" Text="Rehab Assessment" onclick="return cbxClick();"/>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxGrout" runat="server" SkinID="CheckBox" Text="Grout" onclick="return cbxClick();"/>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxOther" runat="server" SkinID="CheckBox" Text="Other" onclick="return cbxClick();"/>
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
                                                        <asp:TextBox ID="tbxBillPriceSaleBillingPricing" runat="server" SkinID="TextBoxReadOnly" Width="167px" ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="tbxBillMoneySaleBillingPricing" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Width="60px"></asp:TextBox>
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
                                                        <asp:CheckBox ID="cbxFairWageApplies" runat="server" SkinID="CheckBox" Text="Yes" Checked='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT].DefaultView.[0].FairWageApplies") %>' onclick="return cbxClick();"/>
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
                                                        <asp:Panel ID="pnlJobClassClassification" runat="server" Height="200px" Width="345px" ScrollBars="Auto" SkinID="PanelReadOnly">                                                
                                                            <asp:UpdatePanel id="upJobClassClassification" runat="server">
                                                                <contenttemplate>
                                                                    <asp:GridView ID="grdJobClassClassification" runat="server" SkinID="GridView" Width="330px"
                                                                    AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="ProjectID,JobClassType,RefID" DataSourceID="odsJobClassClassificationGrid"
                                                                    OnDataBound="grdJobClassClassification_DataBound" >
                                                                        <Columns>                                                        
                                                                            <asp:TemplateField HeaderText="ProjectID" Visible ="False">                                                                                                            
                                                                                <ItemTemplate>                
                                                                                    <asp:Label ID="lblProjectID" runat="server" SkinID="Label" Text='<%# Eval("ProjectID") %>'></asp:Label>                                                                               
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            
                                                                            <asp:TemplateField HeaderText="JobClassType" Visible ="False">                                                                    
                                                                                <ItemTemplate>                                                                     
                                                                                     <asp:Label ID="lblJobClassType" runat="server" SkinID="Label" Text='<%# Eval("JobClassType") %>'></asp:Label>                                                                                
                                                                                </ItemTemplate>                                                                    
                                                                            </asp:TemplateField>
                                                                            
                                                                            <asp:TemplateField HeaderText="RefID" Visible ="False">                                                                    
                                                                                <ItemTemplate>                                                                     
                                                                                     <asp:Label ID="lblRefId" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>                                                                                
                                                                                </ItemTemplate>                                                                    
                                                                            </asp:TemplateField>                                                                                                                                                                                                    
                                                                                
                                                                            <asp:TemplateField  HeaderText="Job Class">                                                                    
                                                                                <ItemTemplate>
                                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Label ID="lblJobClassType" runat="server" SkinID="Label" Text='<%# Eval("JobClassType") %>'></asp:Label>        
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle Width="155px"></HeaderStyle>
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
                                                                                        </tbody>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle Width="83px"></HeaderStyle>
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
                                                                                        </tbody>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle Width="83px"></HeaderStyle>
                                                                            </asp:TemplateField>
                                                                                                                                  
                                                                            <asp:TemplateField>                                                                    
                                                                                <ItemTemplate>
                                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td style="width: 50%">                                                                                        
                                                                                                </td>
                                                                                                <td style="width: 50%">                                                                                        
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
                                                            SkinID="Label" Text="Type Of Work &amp; Function Classification" 
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
                                                        <asp:Panel ID="pnlTypeOfWorkFunctionClassification" runat="server" Height="200px" Width="345px" ScrollBars="Auto" SkinID="PanelReadOnly">                                                                                       
                                                            <asp:UpdatePanel id="upTypeOfWorkFunctionClassification" runat="server">
                                                                <contenttemplate>
                                                                    <asp:GridView ID="grdTypeOfWorkFunctionClassification" runat="server" SkinID="GridView" Width="330px"
                                                                     AutoGenerateColumns="False" DataKeyNames="ProjectID,Work_,Function_,RefID" DataSourceID="odsTypeOfWorkFunctionClassificationGrid"
                                                                    OnDataBound="grdTypeOfWorkFunctionClassification_DataBound"  >
                                                                        <Columns>                                                        
                                                                            <asp:TemplateField HeaderText="ProjectID" Visible ="False">                                                                                                            
                                                                                <ItemTemplate>                
                                                                                    <asp:Label ID="lblProjectID" runat="server" SkinID="Label" Text='<%# Eval("ProjectID") %>'></asp:Label>                                                                               
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            
                                                                            <asp:TemplateField HeaderText="Work_" Visible ="False">                                                                    
                                                                                <ItemTemplate>                                                                     
                                                                                     <asp:Label ID="lblWork_" runat="server" SkinID="Label" Text='<%# Eval("Work_") %>'></asp:Label>                                                                                
                                                                                </ItemTemplate>                                                                    
                                                                            </asp:TemplateField>
                                                                            
                                                                            <asp:TemplateField HeaderText="Function_" Visible ="False">                                                                    
                                                                                <ItemTemplate>                                                                     
                                                                                     <asp:Label ID="lblFunction_" runat="server" SkinID="Label" Text='<%# Eval("Function_") %>'></asp:Label>                                                                                
                                                                                </ItemTemplate>                                                                    
                                                                            </asp:TemplateField>
                                                                            
                                                                            <asp:TemplateField HeaderText="RefID" Visible ="False">                                                                    
                                                                                <ItemTemplate>                                                                     
                                                                                     <asp:Label ID="lblRefId" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>                                                                                
                                                                                </ItemTemplate>                                                                    
                                                                            </asp:TemplateField>                                                                                                                                                                                                    
                                                                                
                                                                            <asp:TemplateField  HeaderText="Type Of Work &amp; Function">                                                                    
                                                                                <ItemTemplate>
                                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Label ID="lblTypeOfWorkFunction" runat="server" SkinID="Label" Text='<%# Eval("WorkFunction") %>'></asp:Label>        
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                                <HeaderStyle Width="155px"></HeaderStyle>
                                                                            </asp:TemplateField>
                                                                                                                                        
                                                                            <asp:TemplateField HeaderText="Is Fair Wage?">
                                                                                <ItemStyle HorizontalAlign="Center" />
                                                                                <ItemTemplate>
                                                                                    <asp:CheckBox ID="cbxIsFairWage" runat="server" Checked='<%# Bind("IsFairWage") %>' onclick="return cbxClick();" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>                                                          
                                                                                                                                  
                                                                            <asp:TemplateField>                                                                    
                                                                                <ItemTemplate>
                                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td style="width: 50%">                                                                                        
                                                                                                </td>
                                                                                                <td style="width: 50%">                                                                                        
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
                                                        <asp:CheckBox ID="cbxGeneralContractor" runat="server" SkinID="CheckBox" Text="Yes" onclick="return cbxClick();"/>
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
                                                        <asp:CheckBox ID="cbxAvailableDrawings" runat="server" SkinID="CheckBox" onclick="return cbxClick();" Text="Yes." EnableViewState="True" />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblAvailableVideo" runat="server" EnableViewState="False" SkinID="Label" Text="Is there a video available?"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="cbxAvailableVideo" runat="server" SkinID="CheckBox" onclick="return cbxClick();" Text="Yes." EnableViewState="True" />
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
                                                        <asp:CheckBox ID="cbxGeneralWSIB" runat="server" SkinID="CheckBox" Text="Yes" onclick="return cbxClick();"/>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblGeneralInsuranceCertificate" runat="server" EnableViewState="False" Text="Insurance Certificate given to client?" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="cbxGeneralInsuranceCertificate" runat="server" SkinID="CheckBox" Text="Yes" onclick="return cbxClick();"/>
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
                                                        <%--<asp:TextBox ID="tbxVehicleAccess" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Width="167px" EnableViewState="True"></asp:TextBox>--%>
                                                        <asp:CheckBox ID="ckbxVehicleAccessRoad" runat="server" SkinID="CheckBox" Text="Road" onclick="return cbxClick();"/>
                                                    </td>
                                                    <td></td>
                                                    <td></td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>                                                
                                                        <asp:CheckBox ID="ckbxVehicleAccessEasement" runat="server" SkinID="CheckBox" Text="Easement" onclick="return cbxClick();"/>
                                                    </td>
                                                    <td> </td>
                                                    <td> </td>
                                                </tr>
                                                <tr>
                                                    <td></td>
                                                    <td>                                                
                                                        <asp:CheckBox ID="ckbxVehicleAccessOther" runat="server" SkinID="CheckBox" Text="Other" onclick="return cbxClick();"/>
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
                                                        <asp:TextBox ID="tbxGeneralBondingSupplied" runat="server" SkinID="TextBoxReadOnly" Width="167px" ReadOnly="True"></asp:TextBox>
                                                    </contenttemplate> 
                                                </asp:UpdatePanel>
                                            </td>
                                            <td>
                                                <asp:UpdatePanel id="upnlEngineerSubcontractors4" runat="server">
                                                    <contenttemplate> 
                                                        <asp:TextBox ID="tbxBondNumber" runat="server" SkinID="TextBoxReadOnly" Width="167px" ReadOnly="True"></asp:TextBox>
                                                    </contenttemplate> 
                                                </asp:UpdatePanel>    
                                            </td>
                                            <td>
                                                <asp:UpdatePanel id="upnlTermsPO3" runat="server">
                                                    <contenttemplate> 
                                                        <asp:TextBox ID="tbxPurchaseOrderNumber" runat="server" SkinID="TextBoxReadOnly" Width="167px" ReadOnly="True" EnableViewState="True"></asp:TextBox>
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
                                                        <asp:CheckBox ID="cbxSubcontractorUsed" runat="server" SkinID="CheckBox" Text="Yes" onclick="return cbxClick();"/>
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
                                                        <asp:CheckBox ID="cbxSubcontractorAgreement" runat="server" SkinID="CheckBox" Text="Yes" onclick="return cbxClick();"  EnableViewState="False"/>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblSubcontractorWrittenQuote" runat="server" EnableViewState="False" Text="Subcontractor provided written quote?" SkinID="Label"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="cbxSubcontractorWrittenQuote" runat="server" SkinID="CheckBox" Text="Yes" onclick="return cbxClick();"  EnableViewState="False"/>
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
                                                    <td >
                                                        <asp:TextBox ID="tbxBillSubcontractorAmount" runat="server" SkinID="TextBoxRightReadOnly" ReadOnly = "true" Width="167px" Text='<%# DataBinder.Eval(projectTDS, "Tables[LFS_PROJECT_SALE_BILLING_PRICING].DefaultView.[0].BillSubcontractorAmount", "{0:n2}") %>'></asp:TextBox>
                                                    </td>
                                                    <td>                                                        
                                                        <asp:Label ID="lblBillSubcontractorAmount2" runat="server" Text="$" SkinID="Label"></asp:Label>                                                               
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
                                                        <asp:TextBox ID="tbxSubcontractorRole" runat="server" Height="54px" SkinID="TextBoxReadOnly" TextMode="MultiLine" Width="680px" ReadOnly="True" EnableViewState="False"></asp:TextBox>
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
                                                        <asp:TextBox ID="tbxDesireOutcomeOfProject" runat="server" Height="54px" SkinID="TextBoxReadOnly" TextMode="MultiLine" Width="680px" ReadOnly="True" Text='<%# Eval("Role") %>' EnableViewState="False"></asp:TextBox>
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
                                                        <asp:Label ID="lblSpecificReportingNeeds" runat="server" EnableViewState="False" Text="Specific Reporting Needs?" SkinID="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:TextBox ID="tbxSpecificReportingNeeds" runat="server" Height="54px" SkinID="TextBoxReadOnly" TextMode="MultiLine" Width="680px" ReadOnly="True" Text='<%# Eval("Role") %>' EnableViewState="False"></asp:TextBox>
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
                                                                <asp:Button id="btnComments" onclick="btnNotesOnClick" runat="server" SkinID="Button" Text="Update" EnableViewState="True" Width="80px" ></asp:Button> 
                                                            </contenttemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="4">
                                                        <asp:TextBox ID="tbxNotes" runat="server" Height="100px" SkinID="TextBoxReadOnly" TextMode="MultiLine" Width="680px" ReadOnly="True" Text='<%# Eval("Role") %>' EnableViewState="False"></asp:TextBox>
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
                                                <asp:Panel ID="pnlBudget" runat="server" Height="200px" Width="440px" ScrollBars="Auto" SkinID="PanelReadOnly"> 
                                                    <asp:GridView ID="grdBudget" runat="server" SkinID="GridView" Width="405px"  AutoGenerateColumns="False" DataKeyNames="ProjectID,Work_,Function_,RefID" DataSourceID="odsBudget"
                                                        OnDataBound="grdBudget_DataBound"  >
                                                        <Columns>                                                        
                                                            <asp:TemplateField HeaderText="ProjectID" Visible ="False">                                                                                                            
                                                                <ItemTemplate>                
                                                                    <asp:Label ID="lblProjectID" runat="server" SkinID="Label" Text='<%# Eval("ProjectID") %>'></asp:Label>                                                                               
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                            <asp:TemplateField HeaderText="Work_" Visible ="False">                                                                    
                                                                <ItemTemplate>                                                                     
                                                                     <asp:Label ID="lblWork_" runat="server" SkinID="Label" Text='<%# Eval("Work_") %>'></asp:Label>                                                                                
                                                                </ItemTemplate>                                                                    
                                                            </asp:TemplateField>
                                                            
                                                            <asp:TemplateField HeaderText="Function_" Visible ="False">                                                                    
                                                                <ItemTemplate>                                                                     
                                                                     <asp:Label ID="lblFunction_" runat="server" SkinID="Label" Text='<%# Eval("Function_") %>'></asp:Label>                                                                                
                                                                </ItemTemplate>                                                                    
                                                            </asp:TemplateField>
                                                            
                                                            <asp:TemplateField HeaderText="RefID" Visible ="False">                                                                    
                                                                <ItemTemplate>                                                                     
                                                                     <asp:Label ID="lblRefId" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>                                                                                
                                                                </ItemTemplate>                                                                    
                                                            </asp:TemplateField>                                                                                                                                                                                                    
                                                                
                                                            <asp:TemplateField  HeaderText="Type Of Work &amp; Function">                                                                    
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblTypeOfWorkFunction" runat="server" Width="255px" SkinID="Label" Text='<%# Eval("WorkFunction") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="255px"></HeaderStyle>
                                                            </asp:TemplateField>
                                                            
                                                            <asp:TemplateField HeaderText="Budget">
                                                                <HeaderStyle Width="90px" />   
                                                                <ItemStyle HorizontalAlign="Right" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblBudget_" runat="server" SkinID="Label" Width="80px" Text='<%# GetRound(Eval("Budget_"),2) %>'  />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                                                                                        
                                                            <asp:TemplateField HeaderText="KPI Target">
                                                                <HeaderStyle Width="90px" />   
                                                                <ItemStyle HorizontalAlign="Right" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblBudget" runat="server" SkinID="Label" Width="80px" Text='<%# GetRound(Eval("Budget"),2) %>'  />
                                                                </ItemTemplate>
                                                            </asp:TemplateField> 
                                                        </Columns>
                                                    </asp:GridView>  
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
                                                <asp:Label ID="Label1" runat="server" EnableViewState="False"
                                                    SkinID="LabelTitle2" Text="For Vehicles"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Label2" runat="server" EnableViewState="False"
                                                    SkinID="Label" Text="Budget"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                 <asp:TextBox ID="tbxUnitsBudget" style="text-align:right" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"></asp:TextBox>
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
                                                 <asp:TextBox ID="tbxMaterialsBudget" style="text-align:right" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"></asp:TextBox>
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
                                                 <asp:TextBox ID="tbxSubcontractorsBudget" style="text-align:right" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"></asp:TextBox>
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
                                                 <asp:TextBox ID="tbxHotelsBudget" style="text-align:right" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"></asp:TextBox>
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
                                                 <asp:TextBox ID="tbxBondingsBudget" style="text-align:right" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"></asp:TextBox>
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
                                                 <asp:TextBox ID="tbxInsurancesBudget" style="text-align:right" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"></asp:TextBox>
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
                                                <asp:Panel ID="pnlOtherCostsBudget" runat="server" Height="200px" Width="395px" ScrollBars="Auto"  SkinID="PanelReadOnly"> 
                                                     <asp:GridView ID="grdOthersBudget" runat="server" SkinID="GridView" Width="380px"  AutoGenerateColumns="False" DataKeyNames="ProjectID,Category,RefID" 
                                                        DataSourceID="odsOthersBudget" OnDataBound="grdOthersBudget_DataBound" >
                                                        <Columns>                                                        
                                                            <asp:TemplateField HeaderText="ProjectID" Visible ="False">                                                                                                            
                                                                <ItemTemplate>                
                                                                    <asp:Label ID="lblProjectID" runat="server" SkinID="Label" Text='<%# Eval("ProjectID") %>'></asp:Label>                                                                               
                                                                </ItemTemplate>
                                                            </asp:TemplateField>                                                                                                                                                                                                   
                                                                
                                                            <asp:TemplateField HeaderText="Category">                                                                    
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCategory" runat="server" Width="255px" SkinID="Label" Text='<%# Eval("Category") %>'></asp:Label>
                                                                </ItemTemplate>
                                                                <HeaderStyle Width="255px"></HeaderStyle>
                                                            </asp:TemplateField>
                                                                                                                        
                                                            <asp:TemplateField HeaderText="Budget">
                                                                <HeaderStyle Width="90px" />   
                                                                <ItemStyle HorizontalAlign="Right" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblBudget" runat="server" SkinID="Label" Width="80px" Text='<%# GetRound(Eval("Budget"),2) %>'  />
                                                                </ItemTemplate>
                                                            </asp:TemplateField> 
                                                        </Columns>
                                                    </asp:GridView>  
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
                                                            <asp:TextBox ID="tbxTotalProjectedRevenue" style="text-align:right" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Width="100px"></asp:TextBox>
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
                                                <asp:Label ID="lblSaleBibProject" runat="server" EnableViewState="False" Text="Bid Project" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSaleRFP" runat="server" EnableViewState="False" Text="RFP" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSaleSoleSource" runat="server" Text="Sole Source" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblSaleTermContract" runat="server" EnableViewState="False" Text="Term Contract" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="cbxSaleBidProject" runat="server" SkinID="CheckBox" onclick="return cbxClick();"/>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxSaleRFP" runat="server" SkinID="CheckBox" onclick="return cbxClick();"/>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxSaleSoleSource" runat="server" SkinID="CheckBox" onclick="return cbxClick();"/>
                                            </td>
                                            <td colspan="2">
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style ="width:30px">
                                                            <asp:CheckBox ID="cbxSaleTermContract" runat="server" SkinID="CheckBox" onclick="return cbxClick();"/>
                                                        </td>
                                                        <td style ="width:254px">
                                                            <asp:TextBox ID="tbxSaleTermContractDetail" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Width="244px"></asp:TextBox>
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
                                                            <asp:CheckBox ID="cbxSaleOther" runat="server" SkinID="CheckBox" onclick="return cbxClick();"/>
                                                        </td>
                                                        <td style ="width:680px">
                                                            <asp:TextBox ID="tbxSaleOtherDetail" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Width="670px"></asp:TextBox>
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
                                                <asp:TextBox ID="tbxSaleGettingJob" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Width="132px"></asp:TextBox>
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
                                                <asp:TextBox ID="tbxBillBidHardDollar" runat="server" SkinID="TextBoxReadOnly" Width="274px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxBillPerUnit" runat="server" SkinID="CheckBox" onclick="return cbxClick();"/>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxBillHourly" runat="server" SkinID="CheckBox" onclick="return cbxClick();"/>
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
                                                <asp:TextBox ID="tbxBillExpectExtras" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Width="700px"></asp:TextBox>
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
                                                <asp:Label ID="lblChargesWater" runat="server" EnableViewState="False" Text="Water Charges?" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblChargesDisposal" runat="server" EnableViewState="False" Text="Disposal Charges?" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="cbxChargesWater" runat="server" SkinID="CheckBox" Text="&nbsp;Yes. How much" onclick="return cbxClick();"/>
                                            </td>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style="width:122px">
                                                            <asp:TextBox ID="tbxChargesWaterAmount" runat="server" SkinID="TextBoxReadOnly" Width="112px" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width:20px">
                                                            <asp:Label ID="lblChargesWaterAmount2" runat="server" Text="$" SkinID="Label"></asp:Label>
                                                        </td>
                                                    </tr>
                                               </table>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxChargesDisposal" runat="server" SkinID="CheckBox" Text="&nbsp;Yes. How much" onclick="return cbxClick();"/>
                                            </td>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style="width:122px">
                                                            <asp:TextBox ID="tbxChargesDisposalAmount" runat="server" SkinID="TextBoxReadOnly" Width="112px" ReadOnly="True"></asp:TextBox>
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
                                                        OnDataBound="grdServices_DataBound" OnRowDataBound="grdServices_RowDataBound" PageSize="5"  >
                                                            <Columns>                                                        
                                                                <asp:TemplateField HeaderText="ProjectID" Visible ="False">                                                                                                            
                                                                    <ItemTemplate>                
                                                                        <asp:Label ID="lblProjectID" runat="server" SkinID="Label" Text='<%# Eval("ProjectID") %>'></asp:Label>                                                                               
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="RefID" Visible ="False">                                                                    
                                                                    <ItemTemplate>                                                                     
                                                                         <asp:Label ID="lblRefId" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>                                                                                
                                                                    </ItemTemplate>                                                                    
                                                                </asp:TemplateField>                                                      
                                                                                                                                                                                                    
                                                                    
                                                                <asp:TemplateField  HeaderText="Service">                                                                    
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
                                                                    <ItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblDescription" runat="server" SkinID="Label" Text='<%# Eval("Description") %>'></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                    <HeaderStyle Width="154px"></HeaderStyle>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Quantity">                                                                    
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
                                                                    <ItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                        
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        
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
                                    <!-- Table element: 5 columns Costing -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 700px">
                                        <tr>
                                            <td style="width: 130px">
                                            </td>
                                            <td style="width: 130px">
                                            </td>
                                            <td style="width: 130px">
                                            </td>
                                            <td style="width: 130px">
                                            </td>
                                            <td style="width: 180px">
                                            </td>
                                        </tr>
                                        <tr>
                                           <td>
                                                <asp:Label ID="lblExtrasToDate" runat="server" EnableViewState="False" Text="Extras To Date" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInvoicedToDate" runat="server" EnableViewState="false" Text="Invoiced To Date" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblCostsIncurred" runat="server" EnableViewState="false" Text="Costs Incurred" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblCostToComplete" runat="server" EnableViewState="False" Text="Cost To Complete" SkinID="Label"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblOriginalProfitEstimated" runat="server" EnableViewState="false" Text="Original Profit Estimated" SkinID="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style="width:110px">
                                                            <asp:TextBox ID="tbxExtrasToDate" runat="server" SkinID="TextBoxReadOnly" Width="100px" ReadOnly="True" EnableViewState="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width:20px">
                                                            <asp:Label ID="lblExtrasToDate2" runat="server" Text="$" SkinID="Label" EnableViewState="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style="width:110px">
                                                            <asp:TextBox ID="tbxInvoicedToDate" runat="server" SkinID="TextBoxReadOnly" Width="100px" ReadOnly="True" EnableViewState="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width:20px">
                                                            <asp:Label ID="lblInvoicedToDate2" runat="server" Text="$" SkinID="Label" EnableViewState="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style="width:110px">
                                                            <asp:TextBox ID="tbxCostsIncurred" runat="server" SkinID="TextBoxReadOnly" Width="100px" ReadOnly="True" EnableViewState="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width:20px">
                                                            <asp:Label ID="lblCostsIncurred2" runat="server" Text="$" SkinID="Label" EnableViewState="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style="width:110px">
                                                            <asp:TextBox ID="tbxCostToComplete" runat="server" SkinID="TextBoxReadOnly" Width="100px" ReadOnly="True" EnableViewState="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width:20px">
                                                            <asp:Label ID="lblCostToComplete2" runat="server" Text="$" SkinID="Label" EnableViewState="false"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style="width:110px">
                                                            <asp:TextBox ID="tbxOriginalProfitEstimated" runat="server" SkinID="TextBoxReadOnly" Width="100px" ReadOnly="True" EnableViewState="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width:20px">
                                                            <asp:Label ID="lblOriginalProfitEstimated2" runat="server" Text="$" SkinID="Label" EnableViewState="false"></asp:Label>
                                                        </td>
                                                        <td style="width:50px">
                                                        </td>
                                                    </tr>
                                                </table>
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
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 600px">
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
                                                <asp:CheckBox ID="cbxLiquidatedDamages" runat="server" SkinID="CheckBox" Text="Yes. If yes how much" onclick="return cbxClick();" EnableViewState="True" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxLiquidatedDamagesRate" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Width="100px" EnableViewState="True"></asp:TextBox>
                                                <asp:Label ID="lblPer" runat="server" EnableViewState="False" SkinID="Label" Text="$&nbsp;&nbsp; per"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="tbxLiquidatedDamagesUnit" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Width="100px" EnableViewState="True"></asp:TextBox>
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
                                                <asp:CheckBox ID="cbxWorkedBefore" runat="server" SkinID="CheckBox" onclick="return cbxClick();" Text="Yes." EnableViewState="True" />
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
                                                <asp:Label ID="lblQuirks" runat="server" EnableViewState="False" SkinID="Label" Text="Quirks (example: Big on Tri-Pod usage, home-owner involvement)"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:TextBox ID="tbxClientQuirks" runat="server" Height="35px" ReadOnly="true" SkinID="TextBoxReadOnly" TextMode="MultiLine" Width="590px" EnableViewState="True"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="height: 7px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:Label ID="lblPromiseToFulfill" runat="server" EnableViewState="False" SkinID="Label" Text="Have we made any promises that operations needs to fulfill?"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <asp:CheckBox ID="cbxClientPromises" runat="server" SkinID="CheckBox" onclick="return cbxClick();" Text="Yes. If yes explain:" EnableViewState="True" />
                                            </td>
                                            <td colspan="3">
                                                <asp:TextBox ID="tbxClientPromises" runat="server" Height="35px" ReadOnly="true" SkinID="TextBoxReadOnly" TextMode="MultiLine" Width="440px" EnableViewState="True"></asp:TextBox>
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
                                                <asp:TextBox ID="tbxWaterObtain" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Width="290px" EnableViewState="True"></asp:TextBox>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="tbxMaterialDispose" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Width="290px" EnableViewState="True"></asp:TextBox>
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
                                                <asp:Label ID="lblDoWeRequireRPZForHydrant" runat="server" EnableViewState="False" SkinID="Label" Text="Do we require a RPZ for the hydrant?"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="cbxRequireRPZ" runat="server" SkinID="CheckBox" onclick="return cbxClick();" Text="Yes." EnableViewState="True"/>
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
                                                <asp:Label ID="lblWhatIsTheStandardHydrantFitting" runat="server" EnableViewState="False" SkinID="Label" Text="What is the standard hydrant fitting?"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <asp:TextBox ID="tbxStandardHydrantFitting" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Width="590px" EnableViewState="True"></asp:TextBox>
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
                                                <asp:CheckBox ID="cbxPreConstructionMeetingNeed" runat="server" onclick="return cbxClick();" SkinID="CheckBox" Text="Yes." EnableViewState="True" />
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
                                                <asp:CheckBox ID="cbxSpecificMeetingLocation" runat="server" SkinID="CheckBox" onclick="return cbxClick();" Text="Yes. If yes explain:" EnableViewState="True" />&nbsp;
                                            </td>
                                            <td colspan="3">
                                                <asp:TextBox ID="tbxSpecificMeetingLocation" runat="server" Height="35px" ReadOnly="true" SkinID="TextBoxReadOnly" TextMode="MultiLine" Width="440px" EnableViewState="True"></asp:TextBox>
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
                                                <asp:TextBox ID="tbxVehicleAccessNotes" runat="server" Height="35px" ReadOnly="true" SkinID="TextBoxReadOnly" TextMode="MultiLine" Width="590px" EnableViewState="True"></asp:TextBox>
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
                                                <asp:TextBox ID="tbxDesireOutcomeOfProject" runat="server" Height="35px" ReadOnly="true" SkinID="TextBoxReadOnly" TextMode="MultiLine" Width="590px" EnableViewState="True"></asp:TextBox>
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

                                    <!-- Page element: Section title - Purchace Order -->
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
                                            <td colspan="2">
                                                
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="lblPurchaseOrderAttached" runat="server" EnableViewState="False" Text="Purchase Order Attached?" SkinID="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                
                                            </td>
                                            <td >
                                                <asp:CheckBox ID="cbxPurchaseOrderAttach" runat="server" onclick="return cbxClick();"  SkinID="CheckBox" Text="Yes." EnableViewState="True" />
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
                                                <asp:TextBox ID="tbxPurchaseOrderWillNotProvided" runat="server" Height="35px" ReadOnly="true" SkinID="TextBoxReadOnly"
                                                    TextMode="MultiLine" Width="590px" EnableViewState="True">
                                                </asp:TextBox>
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
                                            <td colspan="4">
                                                <asp:Label ID="lblGroundconditions" runat="server" EnableViewState="False" SkinID="Label" Text="What are ground conditions like (are bore holes available fort the Vac-Ex Crew)?"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <asp:CheckBox ID="cbxGroundConditions" runat="server" SkinID="CheckBox" onclick="return cbxClick();" Text="Yes. If yes explain:" EnableViewState="True" />&nbsp;
                                            </td>
                                            <td colspan="3">
                                                <asp:TextBox ID="tbxGroundCondition" runat="server" Height="35px" ReadOnly="true" SkinID="TextBoxReadOnly" TextMode="MultiLine" Width="440px" EnableViewState="True"></asp:TextBox>
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
                                                <asp:CheckBox ID="cbxReviewVideoInspections" runat="server" SkinID="CheckBox" onclick="return cbxClick();" Text="Yes." EnableViewState="True"/>
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
                                                <asp:Label ID="lblStrangeConfigurations" runat="server" EnableViewState="False" SkinID="Label" Text="Are there any strange configurations that may cause a problem during installation?"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top">
                                                <asp:CheckBox ID="cbxStrangeConfigurations" runat="server" SkinID="CheckBox" onclick="return cbxClick();" Text="Yes. If yes explain:" EnableViewState="True" />&nbsp;
                                            </td>
                                            <td colspan="3">
                                                <asp:TextBox ID="tbxStrangeConfigurations" runat="server" Height="35px" ReadOnly="true" SkinID="TextBoxReadOnly" TextMode="MultiLine" Width="440px" EnableViewState="True"></asp:TextBox>
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
                                                <asp:TextBox ID="tbxFurtherObservations" runat="server" Height="35px" ReadOnly="true" SkinID="TextBoxReadOnly" TextMode="MultiLine" Width="590px" EnableViewState="True"></asp:TextBox>
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
                                                <asp:TextBox ID="tbxRestrictiveFactors" runat="server" Height="35px" ReadOnly="true" SkinID="TextBoxReadOnly" TextMode="MultiLine" Width="590px" EnableViewState="True"></asp:TextBox>
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
                                <div style="width: 710px">
                                
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
                                                <asp:TextBox ID="tbxGeneralMOLForm" runat="server" SkinID="TextBoxReadOnly" Width="110px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rbtnGeneralNoticeProject" runat="server" GroupName="MOLForm" onclick="return rbtnClick();" />
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="rbtnGeneralForm1000" runat="server" GroupName="MOLForm" onclick="return rbtnClick();" />
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
                                                <asp:Label ID="lblEngineerId" runat="server" EnableViewState="False" Text="Engineer Name" SkinID="Label"></asp:Label>
                                                <asp:HiddenField ID="hdfEngineerId" runat="server" />
                                            </td>
                                            <td>
                                                <asp:Label ID="lblEngineerNumber" runat="server" EnableViewState="False" Text="Engineer Number" SkinID="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxEngineeringFirmId" runat="server" SkinID="TextBoxReadOnly" Width="227px" ReadOnly="True"></asp:TextBox>
                                            </td>
                                            <td>
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
                                                    <tr>
                                                        <td style="width: 197px">
                                                            <asp:TextBox ID="tbxEngineerId" runat="server" SkinID="TextBoxReadOnly" Width="187px" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td style="width: 40px">
                                                            <asp:Button ID="btnEngineerId" runat="server" Text="..." SkinID="Button" Width="30px" OnClientClick="return btnEngineerIdClick();" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxEngineerNumber" runat="server" SkinID="TextBoxReadOnly" Width="226px" ReadOnly="True"></asp:TextBox>
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
                                    
		                            <!-- Page element : No Results -->
                                    <table id="tNoResults" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%" class="Background_NavigatorsNoResults">
                                        <tr runat="server">
                                            <td id="tdNoResults" runat="server">
                                                <asp:Label ID="lblNoResults" runat="server" Text="Sub-Contrators are not defined for this project"></asp:Label>
                                            </td>
                                        </tr>
                                    </table> 
		
                                    <!-- Page element: 1 column - Grid Subcontractors -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:GridView ID="grdvSubcontractors" runat="server" AutoGenerateColumns="False" GridLines="None" PageSize="1" Width="100%" DataKeyNames="RefID" ShowHeader="False" OnPreRender="grdvSubcontractors_PreRender" EnableViewState="False">
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
                                                                            <table border="0" cellspacing="0" cellpadding="0" style="width: 680px;" class="Background2_ViewGrid_Td">
                                                                                <tr>
                                                                                    <td style="width: 227px; height: 20px">
                                                                                    </td>
                                                                                    <td style="width: 227px">
                                                                                    </td>
                                                                                    <td style="width: 226px">
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblSubcontractorId" runat="server" EnableViewState="False" Text="Name" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                         <asp:Label ID="lblRoyalties" runat="server" EnableViewState="False" Text="Royalties (%)" SkinID="Label"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxSubcontractorId" runat="server" SkinID="TextBoxReadOnly" Width="217px" ReadOnly="True" Text='<%# GetSubcontractorId(Eval("SubcontractorID")) %>' EnableViewState="True"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxRoyalties" runat="server" SkinID="TextBoxReadOnly" Width="217px" Text='<%# Eval("Royalties") %>' EnableViewState="True"></asp:TextBox>
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
                                                                                        <asp:CheckBox ID="cbxSubcontractorSurveyedSite" runat="server" SkinID="CheckBox" Text="Yes" onclick="return cbxClick();" Checked='<%# Eval("SurveyedSite") %>' EnableViewState="False"/>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="cbxSubcontractorWorkedBefore" runat="server" SkinID="CheckBox" Text="Yes" onclick="return cbxClick();" Checked='<%# Eval("WorkedBefore") %>' EnableViewState="False"/>
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
                                                                                        <asp:TextBox ID="tbxSubcontractorIssues" runat="server" Height="44px" SkinID="TextBoxReadOnly" TextMode="MultiLine" Width="670px" ReadOnly="True" Text='<%# Eval("Issues") %>' EnableViewState="False"></asp:TextBox>
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
                                                                                        <asp:CheckBox ID="cbxSubcontractorPurchaseOrder" runat="server" SkinID="CheckBox" Text="Yes" onclick="return cbxClick();" Checked='<%# Eval("PurchaseOrder") %>' EnableViewState="False"/>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="cbxSubcontractorInsuranceCertificate" runat="server" SkinID="CheckBox" Text="Yes" onclick="return cbxClick();" Checked='<%# Eval("InsuranceCertificate") %>' EnableViewState="False"/>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:CheckBox ID="cbxSubcontractorWSIB" runat="server" SkinID="CheckBox" Text="Yes" onclick="return cbxClick();" Checked='<%# Eval("WSIB") %>' EnableViewState="False"/>
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
                                                                                        <asp:TextBox ID="tbxSubcontractorMOLForm1000" runat="server" SkinID="TextBoxReadOnly" Width="110px" ReadOnly="True" Text='<%# Eval("MOLForm1000") %>' EnableViewState="False"></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
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
                        
                        
                        
                        <%--<cc1:TabPanel ID="tpNotes" runat="server" HeaderText="Notes" OnClientClick="tpNotesClientClick">
                            <ContentTemplate>
                                <div style="width: 710px; height: 850px; overflow-y: auto;">
                                    <table>                                                                           
                                        <tr>
                                            <td>
                                                 <asp:GridView ID="grdNotes" runat="server" SkinID="GridViewInTabs" Width="700px"
                                                    PageSize="5" AutoGenerateColumns="False" AllowPaging="True" OnRowCommand="grdNotes_RowCommand"
                                                    DataKeyNames="ProjectID,RefID" OnDataBound="grdNotes_DataBound" OnRowDataBound="grdNotes_RowDataBound"
                                                    DataSourceID="odsNotes">
                                                    <Columns>
                                                        <asp:TemplateField SortExpression="ProjectID" Visible="False" HeaderText="ProjectID">                                                            
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblProjectID" runat="server" Text='<%# Eval("ProjectID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField SortExpression="RefID" Visible="False" HeaderText="RefID">                                                            
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRefID" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        
                                                        <asp:TemplateField  Visible="False" >                                                            
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblFileName" runat="server" Text='<%# Eval("FILENAME") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>                                                                                                              
                                                        
                                                        <asp:TemplateField SortExpression="Subject" HeaderText="Information">                                                            
                                                            <HeaderStyle Width="320px"></HeaderStyle>
                                                            <ItemTemplate>
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
                                                                            <td style="height: 7px">
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
                                                                                <asp:Label ID="lblNoteCreatedBy" runat="server" SkinID="Label" Text="Created By"
                                                                                    EnableViewState="False"></asp:Label></td>
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
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <HeaderStyle Width="320px"></HeaderStyle>
                                                            <ItemTemplate>
                                                                <!-- Page element : 2 columns - Notes and attachment information -->
                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="width: 10px; height: 10px">
                                                                            </td>
                                                                            <td style="width: 220px;">
                                                                            </td>
                                                                            <td style="width: 90px">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblNoteNote" runat="server" SkinID="Label" Text="Note" EnableViewState="False"></asp:Label></td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="1">
                                                                            </td>
                                                                            <td colspan="2">
                                                                                <asp:TextBox Style="width: 300px" ID="tbxNoteNote" runat="server" SkinID="TextBoxReadOnly"
                                                                                    Text='<%# Eval("Note") %>' ReadOnly="True" TextMode="MultiLine"
                                                                                    Rows="4"></asp:TextBox></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td colspan="3" style="height: 7px">
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblNoteAttachment" runat="server" EnableViewState="False" SkinID="Label"
                                                                                    Text="Attachment"></asp:Label></td>
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxNoteAttachment" runat="server" Rows="1" SkinID="TextBoxReadOnly" 
                                                                                    ReadOnly="true" Style="width: 210px" Text='<%# Eval("ORIGINAL_FILENAME") %>' Width="220px"></asp:TextBox></td>
                                                                            <td>
                                                                                <asp:Button ID="btnNoteDownload" CommandName="DownloadAttachment" CommandArgument='<%# Eval("RefID") %>' runat="server" SkinID="Button" Text="Download" Width="80px"/></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 10px">
                                                                            </td>
                                                                            <td colspan="1">
                                                                            </td>
                                                                            <td colspan="1">
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>                                                            
                                                            <HeaderStyle Width="60px"></HeaderStyle>
                                                            <ItemTemplate>
                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td style="width: 50%">                                                                                
                                                                            </td>
                                                                            <td style="width: 50%">                                                                                
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
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
                                    
                                    <!-- Table element: 1 column - Resource Centre -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 600px">
                                        <tr>
                                            <td style="width: 600px">
                                                <asp:Label ID="lblCategoryAssociated" runat="server" Text="Associated Category" SkinID="Label" EnableViewState="False"></asp:Label>
                                            </td>
                                            <td style="width: 150px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxCategoryAssocited" Width="590px" ReadOnly="True" runat="server" SkinID="TextBoxReadOnly" ></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px">
                                            </td>
                                            <td style="height: 7px">
                                            </td>
                                        </tr>
                                    </table>                                                                                                                                                    
                                                                                                                                                    
                                    <!-- Table element: 2 columns - Bottom space -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 30px">
                                            </td>
                                            <td>
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
        <table id="Table1" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%" >
            <tr>
                <td style="height: 60px">
                </td>
            </tr>
        </table>
        
        <!-- Page element : Data Objects -->
		<table  border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsServiceGrid" runat="server"
                        FilterExpression="(Deleted = 0)" SelectMethod="GetServiceNew" TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_summary" >
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsTypeOfWorkFunctionClassificationGrid" runat="server"
                        FilterExpression="(Deleted = 0)" SelectMethod="GetTypeOfWorkFunctionClassificationNew" TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_summary" >
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsBudget" runat="server"
                        FilterExpression="(Deleted = 0)" SelectMethod="GetTypeOfWorkFunctionBudgetNew" TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_summary" >
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsSubcontractorsBudget" runat="server"
                        FilterExpression="(Deleted = 0)" SelectMethod="GetSubcontractorsBudgetNew" TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_summary" >
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsHotelsBudget" runat="server"
                        FilterExpression="(Deleted = 0)" SelectMethod="GetHotelsBudgetNew" TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_summary" >
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsBondingsBudget" runat="server"
                        FilterExpression="(Deleted = 0)" SelectMethod="GetBondingsBudgetNew" TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_summary" >
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsInsurancesBudget" runat="server"
                        FilterExpression="(Deleted = 0)" SelectMethod="GetInsurancesBudgetNew" TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_summary" >
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsOthersBudget" runat="server"
                        FilterExpression="(Deleted = 0)" SelectMethod="GetOthersBudgetNew" TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_summary" >
                    </asp:ObjectDataSource>
                                        
                    <asp:ObjectDataSource ID="odsJobClassClassificationGrid" runat="server"
                        FilterExpression="(Deleted = 0)" SelectMethod="GetJobClassClassificationNew" TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_summary" >
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsNotes" runat="server"
                        FilterExpression="(Deleted = 0)" SelectMethod="GetNotesNew" TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_summary" >
                    </asp:ObjectDataSource>
                    
                </td>
            </tr>
		</table>
        
		<!-- Page element : Tag page -->
		<table  border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfProjectId" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfClientId" runat="server" />
                    <asp:HiddenField ID="hdfActiveTab" runat="server" />
                    <asp:HiddenField ID="hdfLoginId" runat="server" />
                    <asp:HiddenField ID="hdfCreatedBy" runat="server" />
                    <asp:HiddenField ID="hdfCreationDateTime" runat="server" Value="no" />
                    <asp:HiddenField ID="hdfBeforeUnloadOrigen" runat="server" />
                    <asp:HiddenField ID="hdfDataChanged" runat="server" />
                    <asp:HiddenField ID="hdfDataChangedMessage" runat="server" />
                </td>
            </tr>
		</table>
		
	
    </div>
</asp:Content>
