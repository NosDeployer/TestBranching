<%@ Page Language="C#" MasterPageFile="../../mForm6.master" AutoEventWireup="true" Codebehind="fl_summary.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.FullLengthLining.fl_summary" Title="LFS Live" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td style="width: 670px">
                    <asp:Label ID="lblTitle" runat="server" Text="Full Length Lining Summary" SkinID="LabelPageTitle1"></asp:Label>
                </td>
                <td style="width: 70px">
                </td>
                <td style="width: 10px">
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 2px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTitleClientName" runat="server" Text="Client:" SkinID="LabelPageTitle2"></asp:Label>
                    <asp:Label ID="lblTitleProjectName" runat="server" Text="> Project: Town Of Markham (01KV456782)" SkinID="LabelPageTitle2"></asp:Label>
                </td>
                <td>
                    <asp:Button ID="btnTitleProjectChange" runat="server" Text="Change" Width="70px" SkinID="ButtonPageTitle" EnableViewState="False" OnClick="btnChange_Click" />
                </td>
                <td>
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
                            <telerik:RadPanelItem Expanded="True" Text="Full Length Lining" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddSection" Text="Add Sections"></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mBulkUpload" Text="Bulk Upload" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mWincapBulkUpload" Text="Wincan (Lateral) Bulk Upload" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mResinsSetup" Text="Resins Setup" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mCatalystSetup" Text="Catalyst Setup" ></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mCXIRemovedReport" Text="CXI Removed Report" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mReadyForLining" Text="Ready For Lining" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mToBePrepped" Text="To Be Prepped" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mToBeLined" Text="To Be Lined" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mLiningCompleted" Text="Lining Completed" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mOverviewReport" Text="Overview Report" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mAllOutstandingIssues" Text="All Outstanding Issues" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mOutstandingClientIssues" Text="Outstanding Client Issues" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mOutstandingLFSIssues" Text="Outstanding LFS Issues" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mOutstandingInvestigationIssues" Text="Outstanding Investigation Issues" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mOutstandingSalesIssues" Text="Outstanding Sales Issues" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mClientInvestigationIssuesCityCopy" Text="Client / Investigation Issues - City Copy" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mM1M2ReportByClient" Text="M1 &amp; M2 Report" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mWorkAhead" Text="Work Ahead %'s And $'s" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mReinstate" Text="Reinstate Report" ></telerik:RadPanelItem>      
                                    <telerik:RadPanelItem runat="server" Value="mWetOut" Text="Wetout Sheet" ></telerik:RadPanelItem>      
                                    <telerik:RadPanelItem runat="server" Value="mInversion" Text="Inversion Sheet" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mOpenedAndBrushed" Text="Opened And Brushed Report" ></telerik:RadPanelItem>
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
                            
                            <telerik:RadMenuItem Value="mDelete" Text="DELETE" />
                            
                            <telerik:RadMenuItem Value="mLateralLocationSheet" Text="PRINT LATERAL LOCATION SHEET" />
                            
                            <telerik:RadMenuItem Value="mViewWorks" Text="WORKS">
                                <items>
                                    <telerik:RadMenuItem Value="mRehabAssessment" Text="REHAB ASSESSMENT" />
                                    <telerik:RadMenuItem Value="mPointRepairs" Text="POINT REPAIRS" />
                                    <telerik:RadMenuItem Value="mJunctionLining" Text="JUNCTION LINING" />  
                                </items>
                            </telerik:RadMenuItem>
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
    <div style="width: 750px">
        
        <!-- Table element: 1 columns - Section Details Title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblSectionDetails" runat="server" SkinID="LabelTitle1" Text="Section Details" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 6 columns - Section Details -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 125px">
                    <asp:Label ID="lblSectionId" runat="server" EnableViewState="False" SkinID="Label" Text="ID (Section)"></asp:Label>
                </td>
                <td style="width: 125px">
                    <asp:Label ID="lblOldCwpId" runat="server" EnableViewState="False" SkinID="Label" Text="Old CWP ID (Section)"></asp:Label>
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
                <td>
                    <asp:TextBox ID="tbxFlowOrderId" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxOldCwpId" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
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
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblStreet" runat="server" EnableViewState="False" SkinID="Label" Text="Street"></asp:Label></td>
                <td>
                    <asp:Label ID="lblUSMH" runat="server" EnableViewState="False" SkinID="Label" Text="USMH"></asp:Label></td>
                <td>
                    <asp:Label ID="lblDSMH" runat="server" EnableViewState="False" SkinID="Label" Text="DSMH"></asp:Label></td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="tbxStreet" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 240px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxUSMH" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxDSMH" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
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
        
        <!-- Table element: 6 columns - Section Details 2 -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 125px">
                    <asp:Label ID="lblMapSize" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Map Size"></asp:Label></td>
                <td style="width: 125px">
                    <asp:Label ID="lblConfirmedSize" runat="server" EnableViewState="False" SkinID="Label" Text="Confirmed Size"></asp:Label></td>
                <td style="width: 125px">
                    <asp:Label ID="lblThickness" runat="server" EnableViewState="False" 
                        SkinID="Label" Text="Thickness"></asp:Label></td>
                <td style="width: 125px">
                    <asp:Label ID="lblMapLength" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Map Length"></asp:Label></td>
                <td style="width: 125px">
                    <asp:Label ID="lblSteelTapeLength" runat="server" EnableViewState="False" SkinID="Label" Text="Steel Tape Length"></asp:Label></td>
                <td style="width: 125px">
                    <asp:Label ID="lblVideoLength" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Video Length"></asp:Label></td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxMapSize" runat="server" EnableViewState="False" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="tbxConfirmedSize" runat="server" EnableViewState="False" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="tbxThickness" runat="server" EnableViewState="False" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="tbxMapLength" runat="server" EnableViewState="False" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="tbxSteelTapeLength" runat="server" EnableViewState="False" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="tbxVideoLength" runat="server" EnableViewState="False" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox></td>
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
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLaterals" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Laterals"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblLiveLaterals" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Live Laterals"></asp:Label>
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
                    <asp:TextBox ID="tbxLaterals" runat="server" EnableViewState="False" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxLiveLaterals" runat="server" EnableViewState="False" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
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
        
        <!-- Table element: 6 columns - Full Length Lining Details title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblFullLengthLiningDetails" runat="server" SkinID="LabelTitle1" Text="Full Length Lining Details"
                        EnableViewState="False"></asp:Label></td>
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
                    <cc1:TabContainer ID="tcFlDetails" Width="730px" runat="server" 
                        ActiveTabIndex="5" CssClass="ajax_tabcontainer">
        
                        <cc1:TabPanel ID="tpGeneralData" runat="server" HeaderText="General Data"  OnClientClick="tpGeneralDataClientClick" >
                            <ContentTemplate>
                                <div style="width: 710px; height: 430px; overflow-y: auto;">
                                
                                    <!-- Table element: 6 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px; height: 10px;">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblGeneralClientId" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="Client ID"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblGeneralSubArea" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="Sub Area"></asp:Label></td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGeneralInstallRate" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="Install Rate" Visible="false"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralClientId" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralSubArea" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralInstallRate" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px" Visible="false"></asp:TextBox></td>
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
        
                                    <!-- Table element: 6 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px;">
                                                <asp:Label ID="lblGeneralPreFlushDate" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="Pre-Flush Date"></asp:Label></td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralPreVideoDate" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="Pre-Video Date"></asp:Label></td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralPreFlushDate" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralPreVideoDate" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
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
        
                                    <!-- Table element: 6 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px;">
                                                <asp:Label ID="lblGeneralProposedLiningDate" runat="server" EnableViewState="False"
                                                    SkinID="LabelSmall" Text="Proposed Lining    Date"></asp:Label></td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralDeadlineLiningDate" runat="server" EnableViewState="False"
                                                    SkinID="LabelSmall" Text="Deadline Lining Date"></asp:Label></td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralProposedLiningDate" runat="server" EnableViewState="False"
                                                    ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralDeadlineLiningDate" runat="server" EnableViewState="False"
                                                    ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
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
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblGeneralP1Date" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="P1 Date"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblGeneralM1Date" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="M1 Date"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblGeneralM2Date" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="M2 Date"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblGeneralInstallDate" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="Install Date"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblGeneralFinalVideo" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="Final Video"></asp:Label></td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralP1Date" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralM1Date" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralM2Date" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralInstallDate" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralFinalVideo" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
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
        
                                    <!-- Table element: 6 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px;">
                                                <asp:Label ID="lblGeneralIssueIdentified" runat="server" EnableViewState="False"
                                                    SkinID="Label" Text="Issue Identified?"></asp:Label></td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralLfsIssue" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="LFS Issue?"></asp:Label></td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralClientIssue" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="Client Issue?"></asp:Label></td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralSalesIssue" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="Sales Issue?"></asp:Label></td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralIssueGivenToClient" runat="server" EnableViewState="False"
                                                    SkinID="LabelSmall" Text="Issue Given To Client?"></asp:Label></td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralIssueInvestigation" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="Issue Investigation?"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="ckbxGeneralIssueIdentified" runat="server" onclick="return cbxClick();"
                                                    SkinID="CheckBox" /></td>
                                            <td>
                                                <asp:CheckBox ID="ckbxGeneralLfsIssue" runat="server" onclick="return cbxClick();"
                                                    SkinID="CheckBox" /></td>
                                            <td>
                                                <asp:CheckBox ID="ckbxGeneralClientIssue" runat="server" onclick="return cbxClick();"
                                                    SkinID="CheckBox" /></td>
                                            <td>
                                                <asp:CheckBox ID="ckbxGeneralSalesIssue" runat="server" onclick="return cbxClick();"
                                                    SkinID="CheckBox" /></td>
                                            <td>
                                                <asp:CheckBox ID="ckbxGeneralIssueGivenToClient" runat="server" onclick="return cbxClick();"
                                                    SkinID="CheckBox" /></td>
                                            <td>
                                                <asp:CheckBox ID="ckbxGeneralIssueInvestigation" runat="server" onclick="return cbxClick();"
                                                    SkinID="CheckBox" /></td>
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
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblGeneralIssueResolved" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="Issue Resolved?"></asp:Label>
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
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="ckbxGeneralIssueResolved" runat="server" onclick="return cbxClick();"
                                                    SkinID="CheckBox" /></td>
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
                        </cc1:TabPanel>
        
        
        
                        <cc1:TabPanel ID="tpPrepData" runat="server" HeaderText="Prep Data" OnClientClick="tpPrepDataClientClick">
                            <ContentTemplate>
                                <div style="width: 710px; height: 430px; overflow-y: auto;">
                                
                                    <!-- Table element: 6 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px; height: 10px;">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblPrepDataP1Completed" runat="server" EnableViewState="false" SkinID="Label" Text="P1 Completed"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPrepDataP1Date" runat="server" EnableViewState="False" SkinID="Label" Text="P1 Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPrepDataRoboticPrepComleted" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Section Robotic Prep"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblPrepDataRoboticPrepComletedDate" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Robotic Prep Completed Date"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="ckbxPrepDataP1Completed" runat="server" onclick="return cbxClick();" SkinID="CheckBox" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxPrepDataP1Date" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxPrepDataRoboticPrepCompleted" runat="server" onclick="return cbxClick();" SkinID="CheckBox"/>
                                            </td>
                                            <td > 
                                                <asp:TextBox ID="tbxPrepDataRoboticPrepCompletedDate" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                                           
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
        
                                    <!-- Table element: 6 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px;">
                                                <asp:Label ID="lblPrepDataCXIsRemoved" runat="server" EnableViewState="False" SkinID="Label" Text="CXI’s Removed"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxPrepDataCXIsRemoved" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
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
                        </cc1:TabPanel>
        
        
        
                        <cc1:TabPanel ID="tpM1Data" runat="server" HeaderText="M1 Data" OnClientClick="tpM1DataClientClick" >
                            <ContentTemplate>
                                <div style="width: 710px">
                                
                                    <!-- Table element: 6 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px; height: 10px;">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblM1DataM1Date" runat="server" EnableViewState="False" SkinID="Label" Text="M1 Date"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="lblM1DataMeasurementsTakenBy" runat="server" EnableViewState="False" SkinID="Label" Text="Measurements Taken By"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataM1Date" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="tbxM1DataMeasurementsTakenBy" runat="server" EnableViewState="False"
                                                    ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 226px"></asp:TextBox>
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
        
                                    <!-- Table element: 6 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px;">
                                                <asp:Label ID="lblM1DataMaterial" runat="server" EnableViewState="False" SkinID="Label" Text="Material"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblM1DataSteelTapeThroughSewer" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Steel Tape Through Sewer"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:TextBox ID="tbxM1DataMaterial" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 226px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataSteelTapeThroughSewer" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
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
        
                                    <!-- Table element: 6 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px;">
                                                <asp:Label ID="lblM1DataUsmhAddress" runat="server" EnableViewState="False" SkinID="Label" Text="USMH Address"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblM1DataUsmhDepth" runat="server" EnableViewState="False" SkinID="Label" Text="USMH Depth"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataUsmhAddress" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataUsmhDepth" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
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
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblM1DataUsmhMouth12" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="USMH Mouth 12:00"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblM1DataUsmhMouth1" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="USMH Mouth 1:00"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblM1DataUsmhMouth2" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="USMH Mouth 2:00"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblM1DataUsmhMouth3" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="USMH Mouth 3:00"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblM1DataUsmhMouth4" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="USMH Mouth 4:00"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblM1DataUsmhMouth5" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="USMH Mouth 5:00"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataUsmhMouth12" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataUsmhMouth1" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataUsmhMouth2" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataUsmhMouth3" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataUsmhMouth4" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataUsmhMouth5" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
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
        
                                    <!-- Table element: 6 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px;">
                                                <asp:Label ID="lblM1DataDsmhAddress" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="DSMH Address"></asp:Label></td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblM1DataDsmhdepth" runat="server" EnableViewState="False"
                                                    SkinID="Label" Text="DSMH Depth"></asp:Label></td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataDsmhAddress" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataDsmhDepth" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
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
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblM1DataDsmhMouth12" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="DSMH Mouth 12:00"></asp:Label></td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblM1DataDsmhMouth1" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="DSMH Mouth 1:00"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblM1DataDsmhMouth2" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="DSMH Mouth 2:00"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblM1DataDsmhMouth3" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="DSMH Mouth 3:00"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblM1DataDsmhMouth4" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="DSMH Mouth 4:00"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblM1DataDsmhMouth5" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="DSMH Mouth 5:00"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataDsmhMouth12" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
                                            <td style="width: 118px">
                                                <asp:TextBox ID="tbxM1DataDsmhMouth1" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataDsmhMouth2" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataDsmhMouth3" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataDsmhMouth4" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataDsmhMouth5" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
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
        
                                    <!-- Table element: 6 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px" >
                                                <asp:Label ID="lblM1DataTrafficControl" runat="server" EnableViewState="False" SkinID="Label" Text="Traffic Control"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblSiteDetails" runat="server" EnableViewState="False" SkinID="Label" Text="Site Details"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblM1DataAccessType" runat="server" SkinID="Label" Text="Access Type"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataTrafficControl" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px;"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataSiteDetails" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px;"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataAccessType" runat="server" EnableViewState="false" ReadOnly="true" SkinID="TextBoxReadOnly" Style="width: 108px;"></asp:TextBox>
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
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblM1DataPipeSizeChange" runat="server" EnableViewState="False" SkinID="Label" Text="Pipe Size Change?"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblM1DataStandardBypass" runat="server" EnableViewState="False" SkinID="Label" Text="Standard Bypass?"></asp:Label>
                                            </td>
                                            <td>                                                
                                            <td colspan="2">
                                            </td>
                                            <td>
                                            </td>                                            
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="ckbxM1DataPipeSizeChange" runat="server" onclick="return cbxClick();" SkinID="CheckBox" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxM1DataStandardBypass" runat="server" onclick="return cbxClick();" SkinID="CheckBox" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataRoboticPrepDate" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="tbxM1DataIssue" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 226px"></asp:TextBox>
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
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:Label ID="lblM1DataStandardBypassComments" runat="server" EnableViewState="False" SkinID="Label" Text="Standard Bypass Comments"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:TextBox ID="tbxM1DataStandardBypassComments" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 698px" Rows="4" TextMode="MultiLine"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6" style="height: 7px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:Label ID="lblM1DataTrafficControlDetails" runat="server" EnableViewState="False" SkinID="Label" Text="Traffic Control Details"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:TextBox ID="tbxM1DataTrafficControlDetails" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 698px" Rows="4" TextMode="MultiLine"></asp:TextBox>
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
                                    
                                    <!-- Table element: 6 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px;">
                                                <asp:Label ID="lblM1DataMeasurementType" runat="server" EnableViewState="False" SkinID="Label" Text="Measurement Type"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblM1DataMeasuredFromMH" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Measured From MH"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataMeasurementType" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataMeasuredFromMH" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
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
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblM1DataVideoDoneFromMH" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Video Done From MH"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblM1DataToMH" runat="server" EnableViewState="False" SkinID="Label" Text="To MH"></asp:Label>
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
                                                <asp:TextBox ID="tbxM1DataVideoDoneFromMH" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataToMH" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
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
                                    
                                    <!-- Table element: 1 columns  - Lateral Measurement Info Title -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblLateralMeasurementInfo" runat="server" EnableViewState="False" SkinID="LabelTitle2" Text="Lateral Measurement Info"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height:10px">
                                            </td>
                                        </tr>
                                    </table>
                                                                    
                                    <!-- Table element: 1 columns  - Lateral Measurement Info Section -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">                                    
                                        <tr>
                                            <td>                                            
                                                <!-- Page element: 1 column - Grid Laterals -->
                                                <asp:GridView id="grdLaterals" runat="server" SkinID="GridView" 
                                                DataSourceID="odsLaterals" OnDataBound="grdLaterals_DataBound"                                                
                                                AutoGenerateColumns="False" DataKeyNames="Lateral" >
                                                <Columns> 
                                                                                                    
                                                    <asp:TemplateField HeaderText="Lateral" SortExpression="Lateral" Visible="False">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLateral" runat="server" Text='<%# Eval("Lateral") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                                                                   
                                                    <asp:TemplateField HeaderText="Laterals" SortExpression="LateralID">
                                                        <HeaderStyle Width="560px" />                                                    
                                                        
                                                        <ItemTemplate>
                                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 560px">
                                                                <tr>
                                                                    <td style="width: 10px; height: 10px"></td>
                                                                    <td style="width: 90px"></td>
                                                                    <td style="width: 90px"></td>
                                                                    <td style="width: 90px"></td>
                                                                    <td style="width: 90px"></td>
                                                                    <td style="width: 90px"></td>
                                                                    <td style="width: 90px"></td>
                                                                    <td style="width: 10px"></td>
                                                                </tr>
                                                                 <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblLateralId" runat="server" SkinID="Label" Text="Lateral ID"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblClientInspectionNo" runat="server" SkinID="LabelSmall" Text="Client Insp.#"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblClientLateralId" runat="server" SkinID="Label" Text="Client Lateral ID"></asp:Label>
                                                                    </td>
                                                                    <td colspan="2">
                                                                        <asp:Label ID="lblMn" runat="server" SkinID="Label" Text="MN#"></asp:Label>
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
                                                                        <asp:TextBox ID="tbxLateralId" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("LateralID") %>' Width="80px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxClientInspectionNo" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("ClientInspectionNo") %>' Width="80px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxClientLateralId" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("ClientLateralID") %>' Width="80px"></asp:TextBox>
                                                                    </td>
                                                                    <td colspan="2">
                                                                        <asp:TextBox ID="tbxMn" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("Mn") %>' Width="170px"></asp:TextBox>
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
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>                                                                    
                                                                    <td>
                                                                        <asp:Label ID="lblClockPosition" runat="server" SkinID="Label" Text="Clock Position"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblSize" runat="server" SkinID="Label" Text="Size"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblMaterial" runat="server" SkinID="Label" Text="Material"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblConnectionType" runat="server" SkinID="LabelSmall" Text="Connection Type"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblJLFlangeType" runat="server" SkinID="Label" Text="JL Flange Type"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblLive" runat="server" SkinID="Label" Text="Live"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>                                                                    
                                                                    <td>
                                                                        <asp:TextBox ID="tbxClockPosition" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("ClockPosition") %>' Width="80px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxSize" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("Size_") %>' Width="80px" ReadOnly="True"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxMaterial" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("MaterialType") %>' Width="80px" ReadOnly="True"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxConnectionType" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("ConnectionType") %>' Width="80px" ReadOnly="True"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxJLFlangeType" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("Flange") %>' Width="80px" ReadOnly="True"></asp:TextBox>                                                                        
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxLive" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("Live") %>' Width="80px" ReadOnly="True"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 7px"></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblVideoDistance" runat="server" SkinID="Label" Text="Video Distance"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblDistanceToCentre" runat="server" SkinID="LabelSmall" Text="Distance To Centre"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblReverseSetup" runat="server" SkinID="Label" Text="Reverse Setup"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblTimeOpened" runat="server" SkinID="Label" Text="Opened"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblReinstate" runat="server" SkinID="Label" Text="Brushed"></asp:Label>
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
                                                                        <asp:TextBox ID="tbxVideoDistance" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# GetDistance(Eval("VideoDistance")) %>' Width="80px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxDistanceToCentre" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# GetDistance(Eval("DistanceToCentre")) %>' Width="80px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:UpdatePanel ID="upnlLateralReverseSetup" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:TextBox ID="tbxReverseSetup" runat="server" ReadOnly="True" 
                                                                                    SkinID="TextBoxReadOnly" Text='<%# GetDistance(Eval("ReverseSetup")) %>' 
                                                                                    Width="80px"></asp:TextBox>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxTimeOpened" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("TimeOpened") %>' Width="80px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxReinstate" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("Reinstate", "{0:d}") %>' Width="80px"></asp:TextBox>
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
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblRequiresRoboticPrep" runat="server" SkinID="LabelSmall" Text="Requires Robotic Prep"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblRequiresRoboticPrepDate" runat="server" SkinID="LabelSmall" Text="Requires Robotic Prep Date"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblHoldClientIssue" runat="server" SkinID="LabelSmall" Text="Hold - Client Issue"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblHoldLFSIssue" runat="server" SkinID="LabelSmall" Text="Hold - LFS Issue"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblDyeTestReq" runat="server" SkinID="LabelSmall" Text="Dye Test Req'd"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblDyeTestComplete" runat="server" SkinID="LabelSmall" Text="Dye Test Complete"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox ID="ckbxRequiresRoboticPrep" runat="server" Checked='<%# Eval("RequiresRoboticPrep") %>' onclick="return cbxClick();" SkinID="CheckBox" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxRequiresRoboticPrepDate" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("RequiresRoboticPrepDate", "{0:d}") %>' Width="80px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox ID="ckbxHoldClientIssue" runat="server" Checked='<%# Eval("HoldClientIssue") %>' onclick="return cbxClick();" SkinID="CheckBox" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox ID="ckbxRequiresRoboticPrep1" runat="server" Checked='<%# Eval("HoldLFSIssue") %>' onclick="return cbxClick();" SkinID="CheckBox" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox ID="ckbxDyeTestReq" runat="server" Checked='<%# Eval("DyeTestReq") %>' onclick="return cbxClick();" SkinID="CheckBox" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxDyeTestComplete" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("DyeTestComplete", "{0:d}") %>' Width="80px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 7px"></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td colspan="6">
                                                                        <asp:Label ID="lblComments" runat="server" SkinID="Label" Text="Comments"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td colspan="6">
                                                                        <asp:TextBox ID="tbxComments" runat="server" EnableViewState="False" 
                                                                            ReadOnly="True" Rows="4" SkinID="TextBoxReadOnly" Style="width: 530px" 
                                                                            Text='<%# Eval("Comments") %>' TextMode="MultiLine"></asp:TextBox>
                                                                    </td>
                                                                    <td></td>
                                                                </tr>
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
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                            </table>                                                        
                                                        </ItemTemplate>                                                        
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="Line lateral?">                                                                
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="cbxJl" runat="server" Checked='<%# Eval("LineLateral") %>' Enabled="false" SkinID="CheckBox" />
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="50px"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                    </asp:TemplateField>
                                                                                                        
                                                    <asp:TemplateField HeaderText="In Project" SortExpression="InProject">
                                                        <HeaderStyle Width="50px" />
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="cbxInProjectI" runat="server" Checked='<%# Eval("InProject") %>' Enabled="false" SkinID="CheckBox" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField Visible="False">
                                                        <HeaderStyle Width="40px"></HeaderStyle>
                                                        <ItemTemplate>
                                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                <tr>
                                                                    <td style="width: 50%">
                                                                        <asp:ImageButton ID="ibtnEdit" runat="server" CommandName="Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png" />
                                                                    </td>
                                                                    <td style="width: 50%">
                                                                        <asp:ImageButton ID="ibtnDelete" runat="server" CommandName="Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png" OnClientClick='return confirm("Are you sure you want to delete this section?");' />
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
                        </cc1:TabPanel>
        
        
        
                        <cc1:TabPanel ID="tpM2Data" runat="server" HeaderText="M2 Data" OnClientClick="tpM2DataClientClick" >                            
                            <ContentTemplate>
                                <div style="width: 710px; height: 430px; overflow-y: auto;">
                                
                                    <!-- Table element: 6 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px; height: 10px;">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblM2DataM2Date" runat="server" EnableViewState="False" SkinID="Label" Text="M2 Date"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="lblM2DataMeasurementsTakenBy" runat="server" EnableViewState="False"
                                                    SkinID="Label" Text="Measurements Taken By"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxM2DataM2Date" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="tbxM2DataMeasurementsTakenBy" runat="server" EnableViewState="False"
                                                    ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 226px"></asp:TextBox>
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
        
                                    <!-- Table element: 6 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px;">
                                                <asp:Label ID="lblM2DataDropPipe" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="Drop Pipe"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblM2DataDropPipeInvertDepth" runat="server" EnableViewState="False"
                                                    SkinID="LabelSmall" Text="Drop Pipe Invert Depth"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblM2DataCappedLaterals" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="Capped Laterals"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="ckbxM2DataDropPipe" runat="server" onclick="return cbxClick();"
                                                    SkinID="CheckBox" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM2DataDropPipeInvertdepth" runat="server" EnableViewState="False"
                                                    ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM2DataCappedLaterals" runat="server" EnableViewState="False"
                                                    ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <!-- Page element : Horizontal Rule -->
                                    <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 31px">
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
        
                                    <!-- Table element: 6 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px;">
                                                <asp:Label ID="lblM2DataLineWidthId" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="Line Width ID#"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:TextBox ID="tbxM2DataLineWidthId" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 226px"></asp:TextBox>
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
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblM2DataHydrantAddress" runat="server" EnableViewState="False" SkinID="Label" Text="Hydrant Address"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblM2DataDistanceToInversionMH" runat="server" EnableViewState="False"
                                                    SkinID="Label" Text="Hydrant Distance to inversion MH"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblM2DataHydroWireWithin10FtOfInversionMH" runat="server" EnableViewState="False"
                                                    SkinID="LabelSmall" Text="Hydro Wire Within 10 Ft Of Inversion MH"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="height: 7px">
                                                <asp:TextBox ID="tbxM2DataHydrantAddress" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 462px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="tbxM2DataDistanceToInversionMH" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="tbxM2DataHydroWireWitin10FtOfInversionMh" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="height: 7px">
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblM2DataSurfaceGrade" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="Surface Grade"></asp:Label>
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
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxM2DataSurfaceGrade" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
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
        
                                    <!-- Table element: 6 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblM2DataExtraEquipmentNeeded" runat="server" EnableViewState="False"
                                                    SkinID="LabelTitle2" Text="Extra Equipment Needed"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
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
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="cbxM2DataHydroPulley" runat="server" EnableViewState="true" SkinID="CheckBox" Text="Hydro Pulley?" onclick="return cbxClick();" />
                                            </td>                                               
                                            <td>
                                                <asp:CheckBox ID="cbxM2DataFridgeCart" runat="server" EnableViewState="true" SkinID="CheckBox" Text="Fridge Cart?" onclick="return cbxClick();" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxM2DataTwoPump" runat="server" EnableViewState="true" SkinID="CheckBox" Text='2" Pump?' onclick="return cbxClick();" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxM2DataSixBypass" runat="server" EnableViewState="true" SkinID="CheckBox" Text='6" Bypass?' onclick="return cbxClick();" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxM2DataScaffolding" runat="server" EnableViewState="true" SkinID="CheckBox" Text="Scaffolding?" onclick="return cbxClick();" />                                                
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxM2DataWinchExtension" runat="server" EnableViewState="true" SkinID="CheckBox" Text="Winch Extension?" onclick="return cbxClick();" />
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
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="cbxM2DataExtraGenerator" runat="server" EnableViewState="true" SkinID="CheckBox" Text="Extra Generator?" onclick="return cbxClick();" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxM2DataGreyCableExtension" runat="server" EnableViewState="true" SkinID="CheckBox" Text="Grey Cable Extension?" onclick="return cbxClick();" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxM2DataEasementMats" runat="server" EnableViewState="true" SkinID="CheckBox" Text="Easement Mats?" onclick="return cbxClick();" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxM2DataRampsRequired" runat="server" EnableViewState="true" SkinID="CheckBox" Text="Ramps Required?" onclick="return cbxClick();" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="cbxM2DataCameraSkid" runat="server" EnableViewState="true" SkinID="CheckBox" Text="Camera Skid?" onclick="return cbxClick();" />
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>                                    
                                    
                                    
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>        
                        
                        
                                                
                        <cc1:TabPanel ID="tpWetOut" runat="server" HeaderText="Wet Out" OnClientClick="tpWetOutClientClick">
                           <ContentTemplate>
                                <div style="width: 710px">
                                    <!-- Table element: 6 columns Setup information -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px; height: 10px;">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:Label ID="lblWetOutDataIncludeWetOutInformation" runat="server" SkinID="Label" Text="Include Wet Out - Inversion Information"></asp:Label>
                                            </td>                                                    
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:CheckBox ID="ckbxWetOutDataIncludeWetOutInformation" Enabled="false" runat="server" SkinID="CheckBox"/>
                                            </td>                                                    
                                        </tr>
                                        <tr>
                                            <td style="height: 7px" colspan="6">
                                            </td>
                                        </tr>
                                    </table>
                                
                                    <asp:Panel ID="upnlVisibleInformation" runat="server">
                                        <!-- Table element: 6 columns Setup information -->
                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                            <tr>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataSetup" runat="server" SkinID="LabelTitle2" Text="Setup"></asp:Label>
                                                </td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                           <tr>
                                                <td style="height: 10px" colspan="6">
                                                </td>
                                            </tr>
                                        </table>
                                        
                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                            <tr>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataLinerTube" runat="server" SkinID="Label" Text="Liner Tube"></asp:Label>
                                                </td>
                                                <td colspan="3">
                                                    <asp:Label ID="lblWetOutDataResin" runat="server" SkinID="Label" Text="Resin"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataExcessResin" runat="server" SkinID="Label" Text="Excess Resin (%)"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataPoundsDrums" runat="server" SkinID="Label" Text="Pounds & Drums "></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="tbxWetOutDataLinerTube" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                                
                                                </td>
                                                <td colspan="3">
                                                    <asp:TextBox ID="tbxWetOutDataResins" runat="server" SkinID="TextBoxReadOnly" Style="width: 344px"></asp:TextBox>                                
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxWetOutDataExcessResin" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td>                                                
                                                    <asp:TextBox ID="tbxWetOutDataPoundsDrums" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                            </tr>
                                           <tr>
                                                <td style="height: 7px" colspan="6">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataDrumDiameter" runat="server" SkinID="Label" Text="Drum Diameter"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataHoistMaximumHeight" runat="server" SkinID="Label" Text="Hoist Maximum Height (ft)"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataHoistMinimumHeight" runat="server" SkinID="Label" Text="Hoist Minimum Height (ft)"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataDownDropTubeLength" runat="server" SkinID="Label" Text="Down (Drop) Tube Length (ft)"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataPumpHeightAboveGround" runat="server" SkinID="Label" Text="Pump Height Above Ground (ft)"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataTubeResinToFeltFactor" runat="server" SkinID="Label" Text="Tube Resin to Felt Factor (%)"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="tbxWetOutDataDrumDiameter" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxWetOutDataHoistMaximumHeight" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                                                                        </td>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxWetOutDataHoistMinimumHeight" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxWetOutDataDownDropTubeLength" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxWetOutDataPumpHeightAboveGround" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxWetOutDataTubeResinToFeltFactor" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
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
                                        
                                        <!-- Table element: 6 columns Wet Out Sheet information -->
                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                            <tr>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataWetOutSheet" runat="server" SkinID="LabelTitle2" Text="Wet Out Sheet"></asp:Label>
                                                </td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                           <tr>
                                                <td style="height: 10px" colspan="6">
                                                </td>
                                            </tr>
                                        </table>
                                        
                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                            <tr>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataDateOfSheet" runat="server" SkinID="Label" Text="Date Of Sheet"></asp:Label>
                                                </td>
                                                <td colspan="2">
                                                    <asp:Label ID="lblWetOutDataMadeBy" runat="server" SkinID="Label" Text="Made By"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataRunDetails" runat="server" SkinID="Label" Text="Run Details"></asp:Label>
                                                </td>
                                                <td>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr  style="vertical-align:top; height:50px">
                                                <td>
                                                     <asp:TextBox ID="tbxWetOutDataDateOfSheet" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            

                                                </td>
                                                <td colspan="2">                                              
                                                    <asp:TextBox ID="tbxWetOutDataMadeBy" runat="server" SkinID="TextBoxReadOnly" Style="width: 226px"></asp:TextBox>                            
                                                </td>
                                                <td> 
                                                    <asp:Panel ID="pnlWetOutDataSectionId" Width="108px" Height="50px" runat="server" SkinID="PanelReadOnly">
                                                        <asp:CheckBoxList ID="cbxlWetOutDataSectionId" runat="server" SkinID="CheckBoxListWithoutBorderReadOnly" 
                                                           onclick="return cbxSelectedClick(event);" Enabled="false">
                                                       </asp:CheckBoxList>
                                                   </asp:Panel>
                                                </td>
                                                <td colspan="2">                                                
                                                    <asp:TextBox ID="tbxWetOutDataRunDetails2" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                            </tr>
                                           <tr>
                                                <td style="height: 7px" colspan="6">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataWetOutDate" runat="server" SkinID="Label" Text="Wet Out Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataInstallDate" runat="server" SkinID="Label" Text="Install Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataTubeThickness" runat="server" SkinID="Label" Text="Tube Thickness"></asp:Label>
                                                </td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="tbxWetOutDataWetOutDate" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                </td>
                                                <td>                                                 
                                                    <asp:TextBox ID="tbxWetOutDataInstallDate" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                                </td>
                                                <td>                                                 
                                                    <asp:TextBox ID="tbxWetOutDataTubeThickness" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                                           
                                                </td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                           <tr>
                                                <td style="height: 7px" colspan="6">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataLengthToLine" runat="server" SkinID="Label" Text="Length To Line (ft)"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataPlusExtra" runat="server" SkinID="Label" Text="Plus Extra (ft)"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataForTurnOffset" runat="server" SkinID="LabelSmall" Text="For Turn/Offset (ft)"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataLengthtToWetOut" runat="server" SkinID="LabelSmall" Text="Lengtht to Wet Out (ft)"></asp:Label>
                                                </td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="tbxWetOutDataLengthToLine" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxWetOutDataPlusExtra" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxWetOutDataForTurnOffset" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxWetOutDataLengthtToWetOut" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                           <tr>
                                                <td style="height: 7px" colspan="6">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:Label ID="lblWetOutDataResinGray" runat="server" SkinID="Label" Text="RESIN:"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 7px" colspan="6">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:Label ID="lblWetOutDataDrumContainsGray" runat="server" SkinID="Label" Text="Drum contains:"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 7px" colspan="6">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:Label ID="lblWetOutDataLinerTubeGray" runat="server" SkinID="Label" Text="Liner Tube:"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 7px" colspan="6">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataTubeMaxColdHead" runat="server" SkinID="LabelSmall" Text="Tube Max Cold Head (ft)"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataTubeMaxColdHeadPsi" runat="server" SkinID="LabelSmall" Text="Tube Max Cold Head (psi)"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataTubeMaxHotHead" runat="server" SkinID="LabelSmall" Text="Tube Max Hot Head (ft)"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataTubeMaxHotHeadPsi" runat="server" SkinID="LabelSmall" Text="Tube Max Hot Head (psi)"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataTubeIdealHead" runat="server" SkinID="LabelSmall" Text="Tube Ideal Head (ft)"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataTubeIdealHeadPsi" runat="server" SkinID="LabelSmall" Text="Tube Ideal Head (psi)"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="tbxWetOutDataTubeMaxColdHead" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxWetOutDataTubeMaxColdHeadPSI" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxWetOutDataTubeMaxHotHead" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxWetOutDataTubeMaxHotHeadPSI" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxWetOutDataTubeIdealHead" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                                                                       
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxWetOutDataTubeIdealHeadPSI" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                            </tr>
                                             <tr>
                                                <td style="height: 7px" colspan="6">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:Label ID="lblWetOutDataLbDrumsGrey" runat="server" SkinID="Label" Text="Lb Drums:"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 7px" colspan="6">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataNetResinForTube" runat="server" SkinID="Label" Text="Net Resin For Tube (lbs)"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataNetResinForTubeUsgals" runat="server" SkinID="Label" Text="Net Resin For Tube (usgals)"></asp:Label>
                                                </td>
                                                <td></td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataNetResinForTubLbsFt" runat="server" SkinID="Label" Text="Net Resin For Tube (lbs/ft)"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataNetResinForTubUsgFt" runat="server" SkinID="Label" Text="Net Resin For Tube (usg/ft)"></asp:Label>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="tbxWetOutDataNetResinForTube" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxWetOutDataNetResinForTubeUsgals" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxWetOutDataNetResinForTubeDrumsIns" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxWetOutDataNetResinForTubeLbsFt" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxWetOutDataNetResinForTubeUsgFt" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                                                                       
                                                </td>
                                                <td></td>
                                            </tr>
                                            
                                            
                                           <tr>
                                                <td style="height: 7px" colspan="6">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:Label ID="lblWetOutDataNetResinGrey" runat="server" SkinID="Label" Text="Net Resin"></asp:Label>
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
                                        
                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                            <tr>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataExtraResinForMix" runat="server" SkinID="LabelSmall" Text="Extra Resin For Mix (%)"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataExtraLbsForMix" runat="server" SkinID="Label" Text="Extra Lbs For Mix (lbs)"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataTotalMixQuantity" runat="server" SkinID="Label" Text="Total Mix Quantity (lbs)"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataTotalMixQuantityUsgals" runat="server" SkinID="Label" Text="Total Mix Quantity (usgals)"></asp:Label>
                                                </td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                     <asp:TextBox ID="tbxWetOutDataExtraResinForMix" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td>
                                                     <asp:TextBox ID="tbxWetOutDataExtraLbsForMix" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td> 
                                                     <asp:TextBox ID="tbxWetOutDataTotalMixQuantity" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td>
                                                     <asp:TextBox ID="tbxWetOutDataTotalMixQuantityUsgals" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td>
                                                     <asp:TextBox ID="tbxWetOutDataTotalMixQuantityDrumsIns" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td></td>
                                            </tr>
                                           <tr>
                                                <td style="height: 7px" colspan="6">
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
                                        
                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                            <tr>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:Label ID="lblCatalysts" runat="server" SkinID="LabelBold" Text="Catalysts"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 10px" colspan="6">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:Panel ID="pnlCatalysts" runat="server" Height="180px" Width="100%" ScrollBars="Auto">
                                                        <asp:UpdatePanel id="upnlCatalysts" runat="server">
                                                            <contenttemplate>
                                                                <!-- Page element: 1 column - Grid Catalyst -->
                                                                <asp:GridView ID="grdCatalysts" runat="server" SkinID="GridView" Width="630px" AutoGenerateColumns="False"
                                                                    AllowPaging="True" PageSize="5" ShowFooter="False" OnDataBound="grdCatalysts_DataBound"
                                                                    DataKeyNames="WorkID, RefID" DataSourceID="odsCatalysts">
                                                                    <Columns>
                                                                                                                                        
                                                                        <asp:TemplateField Visible="False" HeaderText="No">                                                                        
                                                                            <ItemStyle HorizontalAlign="Center" />                                                                        
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCWorkId" runat="server"  SkinID="Label" Text='<%# Eval("WorkID") %>' Width="30px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField Visible="False" HeaderText="No">                                                                        
                                                                            <ItemStyle HorizontalAlign="Center" />                                                                        
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblCRefId" runat="server"  SkinID="Label" Text='<%# Eval("RefID") %>' Width="30px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField  Visible="True" HeaderText="Catalyst">
                                                                            <HeaderStyle Width="200px"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblName" runat="server" SkinID="Label" Text='<%# Eval("Name") %>' Width="190px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                                                                                                                                                     
                                                                        <asp:TemplateField  Visible="True" HeaderText="% by Weight ">
                                                                            <HeaderStyle Width="70px"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                            <ItemTemplate>                                                                        
                                                                                <asp:Label ID="lblPercentageByWeight" runat="server" SkinID="Label" Text='<%# GetRound(Eval("PercentageByWeight"),2) %>' Width="60px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField> 
                                                                                                                                                   
                                                                        
                                                                         <asp:TemplateField  Visible="True" HeaderText="Lbs For Mix Quantity">
                                                                            <HeaderStyle Width="70px"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Right" />
                                                                           <ItemTemplate>                                                                        
                                                                                <asp:Label ID="lblLbsForMixQuantity" runat="server" SkinID="Label" Text='<%# GetRound(Eval("LbsForMixQuantity"),2) %>' Width="60px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>    
                                                                        
                                                                        <asp:TemplateField  Visible="True" HeaderText="Lbs For Drum">
                                                                            <HeaderStyle Width="250px"></HeaderStyle>
                                                                            <ItemStyle HorizontalAlign="Right" /> 
                                                                            <ItemTemplate>                                                                        
                                                                                <asp:Label ID="lblLbsForDrum" runat="server" SkinID="Label" Text='<%# Eval("LbsForDrum") %>' Width="240px"></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>                                                                                                                                                                                                                                                                                                                                                      
                                                                                                                                      
                                                                        <asp:TemplateField>
                                                                            <EditItemTemplate>
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
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </FooterTemplate>
                                                                            <HeaderStyle Width="40px"></HeaderStyle>
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
                                                            </contenttemplate>
                                                        </asp:UpdatePanel>                                                        
                                                    </asp:Panel>
                                                </td>                                        
                                                <td>
                                                    <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                        <tr>
                                                            <td>
                                                                <asp:ObjectDataSource ID="odsCatalysts" runat="server" FilterExpression="(Deleted = 0)"
                                                                    SelectMethod="GetCatalystsNew" 
                                                                    TypeName="LiquiForce.LFSLive.WebUI.CWP.FullLengthLining.fl_edit">
                                                                </asp:ObjectDataSource>
                                                                
                                                                <asp:ObjectDataSource ID="odsCatalystsName" runat="server" CacheDuration="120" EnableCaching="True"
                                                                    OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" 
                                                                    TypeName="LiquiForce.LFSLive.BL.CWP.Works.WorkFullLengthLiningCatalystsList">
                                                                    <SelectParameters>
                                                                        <asp:SessionParameter DefaultValue="-1" Name="catalystId" Type="Int32" />
                                                                        <asp:Parameter DefaultValue="(Select)" Name="name" Type="String" />
                                                                        <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                                                                    </SelectParameters>
                                                                </asp:ObjectDataSource>
                                                            </td>
                                                        </tr>
                                                    </table>    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 7px" colspan="6">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                     <asp:UpdatePanel ID="upnlWetOutDataCatalystGrey" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Label ID="lblWetOutDataCatalystGrey" runat="server" SkinID="Label" Text=""></asp:Label>
                                                        </ContentTemplate>
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
                                        
                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                            <tr>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:Label ID="lblWetOutDataTotalTubeLengthDetermination" runat="server" SkinID="LabelBold" Text="Total Tube Length Determination"></asp:Label>
                                                </td>                                            
                                            </tr>                                        
                                            <tr>
                                                <td style="height: 7px" colspan="6">
                                                </td>
                                            </tr>                                        
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataInversionType" runat="server" SkinID="Label" Text="Inversion Type"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataDepthOfInversionMH" runat="server" SkinID="LabelSmall" Text="Depth Of Inversion MH (ft)"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataTubeForColumn" runat="server" SkinID="LabelSmall" Text="Tube For Column (ft)"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataTubeForStartDry" runat="server" SkinID="LabelSmall" Text="Tube For Start Dry (ft)"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataTotalTube" runat="server" SkinID="Label" Text="Total Tube (ft)"></asp:Label>
                                                </td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="tbxWetOutDataInversionType" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td>
                                                     <asp:TextBox ID="tbxWetOutDataDepthOfInversionMH" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td> 
                                                     <asp:TextBox ID="tbxWetOutDataTubeForColumn" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td>
                                                     <asp:TextBox ID="tbxWetOutDataTubeForStartDry" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td>
                                                     <asp:TextBox ID="tbxWetOutDataTotalTube" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td></td>
                                            </tr>
                                           <tr>
                                                <td style="height: 7px" colspan="6">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataDropTubeConnects" runat="server" SkinID="Label" Text="DropTube Connects"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataAllowsHeadTo" runat="server" SkinID="Label" Text="Allows Head To (ft)"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataRollerGap" runat="server" SkinID="Label" Text="Roller Gap (mm)"></asp:Label>
                                                </td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                     <asp:TextBox ID="tbxWetOutDataDropTubeConnects" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td>
                                                     <asp:TextBox ID="tbxWetOutDataAllowsHeadTo" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td> 
                                                     <asp:TextBox ID="tbxWetOutDataRollerGap" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 10px" colspan="6">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:UpdatePanel ID="upnlWetOutGraphic" runat="server">
                                                        <ContentTemplate>                                           
                                                            <asp:Panel ID="upnlGraphic" runat="server"  SkinID="FLWetOutPanel" ScrollBars="None" Width="460px" Height="93px" >
                                                                <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                                    <tr>
                                                                        <td style="width: 70px"></td>                                                            
                                                                        <td style="width: 290px"></td>
                                                                        <td style="width: 100px"></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td></td>                                                            
                                                                        <td style="text-align:center">
                                                                            <asp:Label ID="lblWetOutDataDimensionLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                        </td>
                                                                        <td></td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td></td>                                                            
                                                                        <td style="text-align:center">
                                                                            <asp:Label ID="lblWetOutDataTotalTubeLengthlabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>                                                                    
                                                                        </td>
                                                                        <td style="text-align:left">
                                                                            <asp:Label ID="lblWetOutDataForColumnLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 20px" colspan="3">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="text-align:right">
                                                                            <asp:Label ID="lblWetOutDataDryFtLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                        </td>                                                            
                                                                        <td style="text-align:center">
                                                                            <asp:Label ID="lblWetOutDataWetOutLengthlabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                        </td>
                                                                        <td style="text-align:left">
                                                                            <asp:Label ID="lblWetOutDataDryFtEndLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 20px" colspan="3">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td  style="text-align:right">
                                                                            <asp:Label ID="lblWetOutDataTailEndlabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                        </td>                                                            
                                                                        <td  style="text-align:center">
                                                                            <asp:Label ID="lblWetOutDataRollerGapLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                        </td>
                                                                        <td style="text-align:left">
                                                                            <asp:Label ID="lblWetOutDataColumnEndlabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                </table>                                             
                                                            </asp:Panel>        
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>   
                                                </td>                                            
                                            </tr>
                                            <tr>
                                                <td style="height: 10px" colspan="6">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:Label ID="lblWetOutDataHoistHeightCheck" runat="server" SkinID="LabelBold" Text="Hoist Height Check"></asp:Label>
                                                </td>                                            
                                            </tr>                                        
                                            <tr>
                                                <td style="height: 7px" colspan="6">
                                                </td>
                                            </tr>  
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataHeightNeeded" runat="server" SkinID="Label" Text="Height Needed (ft)"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataAvailable" runat="server" SkinID="Label" Text="Available"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataHoistHeight" runat="server" SkinID="Label" Text="Hoist Height?"></asp:Label>
                                                </td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                     <asp:TextBox ID="tbxWetOutDataHeightNeeded" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td>
                                                     <asp:TextBox ID="tbxWetOutDataAvailable" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td> 
                                                     <asp:TextBox ID="tbxWetOutDataHoistHeight" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>                            
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblWetOutDataWarning" runat="server" SkinID="LabelError" Text="WARNING!"></asp:Label>
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
                                        
                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                            <tr>
                                                <td style="width: 118px; height: 10px;">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 118px">
                                                </td>
                                                <td style="width: 148px">
                                                </td>
                                                <td style="width: 90px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="lblWetOutDataNotes" runat="server" EnableViewState="True" SkinID="Label"
                                                        Text="Notes"></asp:Label>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>                                             
                                                    <asp:Button ID="btnWetOutDataNotes" OnClick="btnWetOutDataNotesOnClick" runat="server" SkinID="Button"
                                                        Text="Update" EnableViewState="True" Width="80px"></asp:Button>                                                            
                                                </td>                                           
                                            </tr>
                                            <tr>
                                                <td colspan="6">
                                                    <asp:TextBox ID="tbxWetOutDataNotes" runat="server" ReadOnly="True" Rows="20"
                                                        SkinID="TextBoxReadOnly" Style="width: 700px" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                            </tr>                                                
                                            <tr>
                                                <td style="height: 30px" colspan="6">
                                                </td>
                                            </tr>                                                                              
                                        </table>
                                    </asp:Panel>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpInversionCure" runat="server" HeaderText="Inversion & Cure" OnClientClick="tpInversionCureClientClick">
                            <ContentTemplate>
                                <!-- Table element: 6 columns  -->
                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                    <tr>
                                        <td style="width: 118px; height: 10px;">
                                        </td>
                                        <td style="width: 118px">
                                        </td>
                                        <td style="width: 118px">
                                        </td>
                                        <td style="width: 118px">
                                        </td>
                                        <td style="width: 118px">
                                        </td>
                                        <td style="width: 118px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="6">
                                            <asp:Label ID="lblInversionDataIncludeInversionInformation" runat="server" SkinID="Label" Text="Include Wet Out - Inversion Information"></asp:Label>
                                        </td>                                                    
                                    </tr>
                                    <tr>
                                        <td  colspan="6"> 
                                            <asp:CheckBox ID="ckbxInversionDataIncludeInversionInformation" Enabled="false" runat="server" SkinID="CheckBox" />
                                        </td>                                                    
                                    </tr>
                                    <tr>
                                        <td style="height: 7px" colspan="6">
                                        </td>
                                    </tr> 
                                </table>
                                
                                <asp:Panel ID="upnlInversionVisibleInformation" runat="server">
                                    <!-- Table element: 6 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px; height: 10px;">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:Label ID="lblInversionTitle" runat="server" SkinID="LabelTitle2" Text="Inversion And Cure Sheet"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px" colspan="6">
                                            </td>
                                        </tr>
                                    </table>                                                                                                   
                           
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:Label ID="lblInversionDataSubtitle" runat="server" SkinID="LabelTitle2" Text="For:"></asp:Label>
                                            </td>                                                    
                                        </tr>
                                        <tr>
                                            <td style="height: 7px" colspan="6">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:Label ID="lblInversionDataComment" runat="server" SkinID="Label" Text="SHEET IS THEORETICAL GUIDE. WHERE REQUIRED, FIELD ADJUST PARAMETERS TO SUIT ACTUAL CONDITIONS"></asp:Label>
                                            </td>                                                    
                                        </tr>
                                        <tr>
                                            <td style="height: 7px" colspan="6">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblInversionDataDateOfSheet" runat="server" SkinID="Label" Text="Date Of Sheet"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="lblInversionDataMadeBy" runat="server" SkinID="Label" Text="Made By"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInversionDataInstalledOn" runat="server" SkinID="Label" Text="Installed On"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInversionDataRunDetails" runat="server" SkinID="Label" Text="Run Details"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr  style="vertical-align:top; height:50px">
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataDateOfSheet" runat="server" SkinID="TextBoxReadOnly"
                                                    Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="tbxInversionDataMadeBy" runat="server" SkinID="TextBoxReadOnly"
                                                    Style="width: 226px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataInstalledOn" runat="server" SkinID="TextBoxReadOnly"
                                                    Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Panel ID="pnlInversionDataSectionId" Width="108px" Height="50px" runat="server" SkinID="PanelReadOnly">
                                                   <asp:CheckBoxList ID="cbxlInversionDataSectionId" runat="server" SkinID="CheckBoxListWithoutBorderReadOnly"  
                                                       onclick="return cbxSelectedClick(event);" Enabled="False">
                                                   </asp:CheckBoxList>                                                                                  
                                               </asp:Panel>                          
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataRunDetails2" runat="server" SkinID="TextBoxReadOnly"
                                                    Style="width: 108px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px" colspan="6">
                                            </td>
                                        </tr>                                     
                                        <tr>
                                            <td colspan="6">
                                                <asp:Label ID="lblInversionDataCommentsNotes" runat="server" SkinID="Label" Text="Comment / Note"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:TextBox Style="width: 700px" ID="tbxInversionDataCommentsEdit" runat="server"
                                                    SkinID="TextBoxReadOnly" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                            </td>
                                        </tr>                                                
                                        <tr>
                                            <td style="height: 7px" colspan="6">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblInversionDataLinerSize" runat="server" SkinID="Label" Text="Liner Size"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInversionDataRunLength" runat="server" SkinID="Label" Text="Wet Out Length"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInversionDataWetOutLenght" runat="server" SkinID="Label" Text="For Turn/Offset"></asp:Label>
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
                                                <asp:TextBox ID="tbxInversionDataLinerSize" runat="server" SkinID="TextBoxReadOnly"
                                                    Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataRunLength" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataWetOutLenght" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
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
                                                <asp:Label ID="lblInversionDataLinerInfoGrey" runat="server" SkinID="Label" Text="Liner Products:"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px" colspan="6">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:Label ID="lblInversionDataHeadsGrey" runat="server" SkinID="Label" Text="Heads:"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px" colspan="6">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblInversionDataPipeType" runat="server" SkinID="Label" Text="Pipe Type"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInversionDataPipeCondition" runat="server" SkinID="Label" Text="Pipe Condition"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInversionDataGroundMoisture" runat="server" SkinID="Label" Text="Ground Moisture"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInversionDataBoilerSize" runat="server" SkinID="Label" Text="Boiler Size, Btu/hr"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInversionDataPumpsTotalCapacity" runat="server" SkinID="Label"
                                                    Text="Pump(s) Total Capacity (usgpm)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInversionDataLayflatSize" runat="server" SkinID="Label" Text="Layflat Size"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataPipeType" runat="server" SkinID="TextBoxReadOnly"
                                                    Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataPipeCondition" runat="server" SkinID="TextBoxReadOnly"
                                                    Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataGroundMoisture" runat="server" SkinID="TextBoxReadOnly"
                                                    Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataBoilerSize" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataPumpsTotalCapacity" runat="server" SkinID="TextBoxReadOnly"
                                                    Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataLayflatSize" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px" colspan="6">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblInversionDataLayflatQuantityTotal" runat="server" SkinID="Label"
                                                    Text="Layflat Quantity - Total"></asp:Label>
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
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataLayflatQuantityTotal" runat="server" SkinID="TextBoxReadOnly"
                                                    Style="width: 108px"></asp:TextBox>
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
                                    
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblInversionDataWaterStartTempTs" runat="server" SkinID="Label" Text="Water Start Temp Ts (°F)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInversionDataTempT1" runat="server" SkinID="Label" Text="Temp T1 (°F)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInversionDataHoldAtT1For" runat="server" SkinID="Label" Text="Hold At T1 For (hr)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInversionDataTempT2" runat="server" SkinID="Label" Text="Temp T2 (°F)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInversionDataCookAtT2For" runat="server" SkinID="LabelSmall" Text="Cook At T2 For (hr)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInversionDataCoolDownFor" runat="server" SkinID="Label" Text="Cool Down for (hr)"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataWaterStartTempTs" runat="server" SkinID="TextBoxReadOnly"
                                                    Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataTempT1" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataHoldAtT1For" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataTempT2" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataCookAtT2For" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataCoolDownFor" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px" colspan="6">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblInversionDataCoolToTemp" runat="server" SkinID="LabelSmall" Text="Cool To Temp, Tc (°F)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInversionDataDropInPipeRun" runat="server" SkinID="LabelSmall" Text="Drop In Pipe Run (ft)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInversionDataPipeSlopeOf" runat="server" SkinID="LabelSmall" Text="= Pipe Slope Of (%)"></asp:Label>
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
                                                <asp:TextBox ID="tbxInversionDataCoolToTemp" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataDropInPipeRun" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataPipeSlopeOf" runat="server" SkinID="TextBoxReadOnly"
                                                    Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px" colspan="6">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:Label ID="lblInversionDataSubtitle2" runat="server" SkinID="LabelBold" Text="Aprox Time"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px" colspan="6">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblInversionData45F120F" runat="server" SkinID="Label" Text="45°F-120°F (hr)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInversionDataHold" runat="server" SkinID="Label" Text="Hold (hr)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInversionData120F185F" runat="server" SkinID="Label" Text="120°F-185°F (hr)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInversionDataCookTime" runat="server" SkinID="Label" Text="Cook Time (hr)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInversionDataCoolTime" runat="server" SkinID="Label" Text="Cool Time (hr)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInversionDataAproxTotal" runat="server" SkinID="Label" Text="Aprox Total (hr)"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxInversionData45F120F" runat="server" SkinID="TextBoxReadOnly"
                                                    Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataHold" runat="server" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInversionData120F185F" runat="server" SkinID="TextBoxReadOnly"
                                                    Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataCookTime" runat="server" SkinID="TextBoxReadOnly"
                                                    Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataCoolTime" runat="server" SkinID="TextBoxReadOnly"
                                                    Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataAproxTotal" runat="server" SkinID="TextBoxReadOnly"
                                                    Style="width: 108px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px" colspan="6">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:UpdatePanel ID="upnlInversionGraphic" runat="server">
                                                    <ContentTemplate>                                           
                                                        <asp:Panel ID="upnlInversionGraphic1" runat="server"  SkinID="FLInversionPanel" ScrollBars="None" Width="428px" Height="173px" >
                                                            <table cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                                                <tr>
                                                                    <td style="width: 70px; height:7px"></td>                                                            
                                                                    <td style="width: 50px"></td>
                                                                    <td style="width: 156px"></td>
                                                                    <td style="width: 50px"></td>
                                                                    <td style="width: 52px"></td>
                                                                    <td style="width: 50px"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>                                                            
                                                                    <td style="text-align:left" colspan="2">
                                                                        <asp:Label ID="lblInversionDataColumnHeadLabel" runat="server" SkinID="LabelSmall" Text="If Column Head at"></asp:Label>
                                                                    </td>                                                                    
                                                                    <td  style="text-align:right" colspan="3">
                                                                        <asp:Label ID="lblInversionDataCorrespongingHeadAtEndLabel" runat="server" SkinID="LabelSmall" Text="Corresponding Head at End"></asp:Label>
                                                                    </td>                                                                                                                                     
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 10px" colspan="6">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>    
                                                                    <td></td>                                                        
                                                                    <td colspan="2">
                                                                        <asp:Label ID="lblInversionDataMaxColdForTubeLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                    </td>                                                                    
                                                                    
                                                                    <td style="text-align:right">
                                                                        <asp:Label ID="lblInversionDataMaxColdForTubeEndLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>                                                                        
                                                                    </td>
                                                                    <td></td>
                                                                </tr>     
                                                                <tr>
                                                                    <td style="height: 5px" colspan="6">
                                                                    </td>
                                                                </tr>                                                           
                                                                <tr>
                                                                    <td></td>                                                            
                                                                    <td></td>
                                                                    <td  colspan="2">
                                                                        <asp:Label ID="lblInversionDataMaxHotForTubeLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                    </td>                                                                                                                                        
                                                                    <td style="text-align:right">
                                                                        <asp:Label ID="lblInversionDataMaxHotForTubeEndLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>                                                                        
                                                                    </td>
                                                                    <td></td>
                                                                </tr> 
                                                                <tr>
                                                                    <td style="height: 5px" colspan="6">
                                                                    </td>
                                                                </tr>                                                                   
                                                                <tr>
                                                                    <td></td>                                                            
                                                                    <td></td>
                                                                    <td  colspan="2">
                                                                        <asp:Label ID="lblInversionDataIdelForTubeLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                    </td>                                                                                                                                       
                                                                    <td style="text-align:right">
                                                                        <asp:Label ID="lblInversionDataIdelForTubeEndLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>                                                                        
                                                                    </td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 20px" colspan="6">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="text-align:left">
                                                                        <asp:Label ID="lblInversionDataPumpHeightLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>
                                                                    </td>                                                                                                                                
                                                                    <td style="text-align:center" colspan="3">
                                                                        <asp:Label ID="lblInversionDataLinerSizeLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>                                                                        
                                                                    </td>                                                                    
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>                                                                                                                                
                                                                    <td style="text-align:center" colspan="3">
                                                                        <asp:Label ID="lblInversionDataRunLengthLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>                                                                        
                                                                    </td>                                                                    
                                                                    <td  style="text-align:right">
                                                                        <asp:Label ID="lblInversionDataEndLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>                                                                        
                                                                    </td>
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td  style="text-align:left">
                                                                        <asp:Label ID="lblInversionDataDepthOfInversionMHLabel" runat="server" SkinID="LabelSmall" Text=" "></asp:Label>                                                                        
                                                                    </td>                                                            
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                    <td></td>
                                                                </tr>
                                                            </table>                                             
                                                        </asp:Panel>        
                                                    </ContentTemplate>
                                                </asp:UpdatePanel> 
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px" colspan="6">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:Label ID="lblInversionDataPumpingCirculationSubtitle" runat="server" SkinID="LabelBold"
                                                    Text="Pumping & Circulation "></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px" colspan="6">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblInversionDataWaterChangesPerHour" runat="server" SkinID="Label"
                                                    Text="Water Changes Per Hour"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInversionDataReturnWaterVelocity" runat="server" SkinID="Label"
                                                    Text="Return Water Velocity (ft/sec)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInversionDataLayflatBackPressure" runat="server" SkinID="Label"
                                                    Text="Layflat Back Pressure (psi)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInversionDataPumpLiftAtIdealHead" runat="server" SkinID="Label"
                                                    Text="Pump Lift At Ideal Head (ft)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInversionDataWaterToFillLinerColumn" runat="server" SkinID="Label"
                                                    Text="Water To Fill Liner & Column (usg)"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInversionDataWaterPerFit" runat="server" SkinID="Label"
                                                 Text="Water Per Fit (usg/ft)" ></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataWaterChangesPerHour" runat="server" SkinID="TextBoxReadOnly"
                                                    Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataReturnWaterVelocity" runat="server" SkinID="TextBoxReadOnly"
                                                    Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataLayflatBackPressure" runat="server" SkinID="TextBoxReadOnly"
                                                    Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataPumpLiftAtIdealHead" runat="server" SkinID="TextBoxReadOnly"
                                                    Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataWaterToFillLinerColumn" runat="server" SkinID="TextBoxReadOnly"
                                                    Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInversionDataWaterPerFit" runat="server" SkinID="TextBoxReadOnly"
                                                    Style="width: 108px"></asp:TextBox>
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
                                    
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:Label ID="lblInversionDataFieldCureRecord" runat="server" SkinID="LabelTitle2" Text="Field Cure Record"></asp:Label>
                                            </td>
                                        </tr>                                                
                                        <tr>
                                            <td style="height: 10px" colspan="6">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6"> 
                                               <asp:TextBox ID="lblInversionDataFieldCureRecordSummary" runat="server" 
                                                    ReadOnly="True" Rows="30"
                                                    SkinID="TextBoxReadOnly" Style="width: 700px" TextMode="MultiLine"></asp:TextBox>
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
                                    
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:Label ID="lblInversionDataNotesAndInstallationResults" runat="server" SkinID="Label" Text="Notes And Installation Results"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:TextBox Style="width: 700px" 
                                                    ID="tbxInversionDataNotesAndInstallationResults" runat="server"
                                                    SkinID="TextBoxReadOnly" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                            </td>
                                        </tr>                                                
                                        <tr>
                                            <td style="height: 30px" colspan="6">
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>         
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpInstallData" runat="server" HeaderText="Install Data" OnClientClick="tpInstallDataClientClick">
                            <ContentTemplate>
                                <div style="width: 710px; height: 430px; overflow-y: auto;">
                                    <!-- Table element: 6 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px; height: 10px;">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblInstallDataInstallDate" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="Install Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblInstallDataFinalVideoDate" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="Final Video Date"></asp:Label>
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
                                                <asp:TextBox ID="tbxInstallDataInstallDate" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxInstallDataFinalVideoDate" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
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
                        </cc1:TabPanel>
        
                        
        
                        <cc1:TabPanel ID="tpComments" runat="server" HeaderText="Comments" OnClientClick="tpCommentDataClientClick">
                            <ContentTemplate>
                                <div style="width: 710px; height: 430px; overflow-y: auto;">
                                    <!-- Table element: 6 columns  -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td style="width: 118px; height: 10px;">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 118px">
                                            </td>
                                            <td style="width: 148px">
                                            </td>                                            
                                            <td style="width: 90px">
                                            </td>                                            
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblCommentsDataComments" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="Comments Summary"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:UpdatePanel id="upnlComments" runat="server">
                                                    <contenttemplate>
                                                        <asp:Button id="btnComments" onclick="btnCommentsOnClick" runat="server" SkinID="Button" Text="Update" EnableViewState="False" Width="80px" ></asp:Button> 
                                                    </contenttemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:TextBox ID="tbxCommentsDataComments" runat="server" EnableViewState="False"
                                                    ReadOnly="True" Rows="20" SkinID="TextBoxReadOnly" Style="width: 700px" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 30px" colspan="6">
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
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
                    <asp:ObjectDataSource ID="odsLaterals" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetLateralDetails"
                        TypeName="LiquiForce.LFSLive.WebUI.CWP.FullLengthLining.fl_summary"></asp:ObjectDataSource>
                </td>
            </tr>
        </table>
                
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCurrentClientId" runat="server" />
                    <asp:HiddenField ID="hdfCurrentProjectId" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfWorkType" runat="server" />
                    <asp:HiddenField ID="hdfAssetId" runat="server" />
                    <asp:HiddenField ID="hdfCountryId" runat="server" />
                    <asp:HiddenField ID="hdfProvinceId" runat="server" />
                    <asp:HiddenField ID="hdfCountyId" runat="server" />
                    <asp:HiddenField ID="hdfCityId" runat="server" />
                    <asp:HiddenField ID="hdfWorkId" runat="server" />
                    <asp:HiddenField ID="hdfActiveTab" runat="server" />
                    <asp:HiddenField ID="hdfSectionId" runat="server" />
                    <asp:HiddenField ID="hdfFlowOrderId" runat="server" />
                    <asp:HiddenField ID="hdfMeasuredFrom" runat="server" />
                    <asp:HiddenField ID="hdfRunDetails" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
