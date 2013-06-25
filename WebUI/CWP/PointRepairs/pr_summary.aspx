<%@ Page Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" CodeBehind="pr_summary.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.PointRepairs.pr_summary" Title="LFS Live" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td style="width: 670px">
                    <asp:Label ID="lblTitle" runat="server" Text="Point Repairs Summary" SkinID="LabelPageTitle1"></asp:Label>
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
                            <telerik:RadPanelItem Expanded="True" Text="Point Repairs" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddSection" Text="Add Sections"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSearch" Text="Search" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSeparator" PostBack="false">
                                        <ItemTemplate>
                                            <table style="width: 100%" cellpadding="0" cellspacing="0" border="0">
                                                <tr>
                                                    <table style="width: 170px;padding-left: 10px;" cellpadding="0" cellspacing="0" border="0">
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mPointRepairsPlan" Text="Lining Plan"></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mOverviewReport" Text="Overview Report" ></telerik:RadPanelItem>
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
                            <telerik:RadMenuItem Value="mViewWorks" Text="WORKS">
                                <items>
                                    <telerik:RadMenuItem Value="mRehabAssessment" Text="REHAB ASSESSMENT" />
                                    <telerik:RadMenuItem Value="mFullLenghtLining" Text="FULL LENGTH LINING" />                                    
                                    <telerik:RadMenuItem  Value="mJunctionLining" Text="JUNCTION LINING" /> 
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
                    <asp:Label ID="lblStreet" runat="server" EnableViewState="False" SkinID="Label" Text="Street"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblUSMH" runat="server" EnableViewState="False" SkinID="Label" Text="USMH"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblUSMHMN" runat="server" EnableViewState="False" SkinID="Label" Text="USMH Address"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDSMH" runat="server" EnableViewState="False" SkinID="Label" Text="DSMH"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDSMHMN" runat="server" EnableViewState="False" SkinID="Label" Text="DSMH Address"></asp:Label>
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
                    <asp:TextBox ID="tbxUSMHMN" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxDSMH" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxDSMHMN" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
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
                    <asp:Label ID="lblMapSize" runat="server" EnableViewState="False" SkinID="Label" Text="Map Size"></asp:Label>
                </td>
                <td style="width: 125px">
                    <asp:Label ID="lblConfirmedSize" runat="server" EnableViewState="False" SkinID="Label" Text="Confirmed Size"></asp:Label>
                </td>
                <td style="width: 125px">
                    <asp:Label ID="lblMapLength" runat="server" EnableViewState="False" SkinID="Label" Text="Map Length"></asp:Label>
                </td>
                <td style="width: 125px">
                    <asp:Label ID="lblSteelTapeLength" runat="server" EnableViewState="False" SkinID="Label" Text="Steel Tape Length"></asp:Label>
                </td>
                <td style="width: 125px">
                    <asp:Label ID="lblVideoLength" runat="server" EnableViewState="False" SkinID="Label" Text="Video Length"></asp:Label>
                </td>
                <td style="width: 125px">
                    <asp:Label ID="lblLaterals" runat="server" EnableViewState="False" SkinID="Label" Text="Laterals"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxMapSize" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxConfirmedSize" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxMapLength" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxSteelTapeLength" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxVideoLength" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxLaterals" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
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
                    <asp:Label ID="lblLiveLaterals" runat="server" EnableViewState="False" SkinID="Label" Text="Live Laterals"></asp:Label>
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
                    <asp:TextBox ID="tbxLiveLaterals" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
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
        
        <!-- Table element: 6 columns - Point Repairs Details title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblPointRepairsDetails" runat="server" SkinID="LabelTitle1" Text="Point Repairs Details" EnableViewState="False"></asp:Label>
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
                    <cc1:TabContainer ID="tcPrDetails" Width="730px" runat="server" ActiveTabIndex="0" CssClass="ajax_tabcontainer">
        
                        <cc1:TabPanel ID="tpGeneralData" runat="server" HeaderText="General Data" OnClientClick="tpGeneralDataClientClick" >
                            <ContentTemplate>
                                <div style="width: 710px; height: 490px; overflow-y: auto;">
                                
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
                                                <asp:Label ID="lblGeneralDataClientId" runat="server" EnableViewState="False" SkinID="Label" Text="Client ID"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGeneralDataSubArea" runat="server" EnableViewState="False" SkinID="Label" Text="Sub Area"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="lblGeneralDataMeasurementsTakenBy" runat="server" EnableViewState="False" SkinID="Label" Text="Measurements Taken By"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralDataClientId" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralDataSubArea" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="tbxGeneralDataMeasurementsTakenBy" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 226px"></asp:TextBox>
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
                                                <asp:Label ID="lblGeneralDataPreFlushDate" runat="server" EnableViewState="False" SkinID="Label" Text="Pre-Flush Date"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralDataPreVideoDate" runat="server" EnableViewState="False" SkinID="Label" Text="Pre-Video Date"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralDataP1Date" runat="server" EnableViewState="False" SkinID="Label" Text="P1 Date"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralDataRepairConfirmationDate" runat="server" EnableViewState="False" SkinID="Label" Text="Repair Confirmation Date"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralDataTrafficControl" runat="server" EnableViewState="False" SkinID="Label" Text="Traffic Control"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralDataMaterial" runat="server" EnableViewState="False" SkinID="Label" Text="Material"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralDataPreFlushDate" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralDataPreVideoDate" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralDataP1Date" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralDataRepairConfirmationDate" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralDataTrafficControl" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralDataMaterial" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
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
                                                <asp:Label ID="lblGeneralDataBypassRequired" runat="server" EnableViewState="False" SkinID="Label" Text="Bypass Required?"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGeneralDataCXIsRemoved" runat="server" EnableViewState="False" SkinID="Label" Text="CXI's Removed"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGeneralDataRoboticDistances" runat="server" EnableViewState="False" SkinID="Label" Text="Robotic Distances"></asp:Label>
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
                                                <asp:CheckBox ID="ckbxGeneralDataBypassRequired" runat="server" onclick="return cbxClick();" SkinID="CheckBox" />
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralDataCXIsRemoved" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralDataRoboticDistances" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
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
                                                <asp:Label ID="lblGeneralDataProposedLiningDate" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Proposed Lining Date"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralDataDeadlineLiningDate" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Deadline Lining Date"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralDataFinalVideo" runat="server" EnableViewState="False" SkinID="Label" Text="Final Video"></asp:Label>
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
                                                <asp:TextBox ID="tbxGeneralDataProposedLiningDate" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralDataDeadlineLiningDate" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralDataFinalVideo" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
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
                                                <asp:Label ID="lblGeneralDataEstimatedJoints" runat="server" EnableViewState="False" SkinID="Label" Text="Estimated # Joints"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralDataJointsTestSealed" runat="server" EnableViewState="False" SkinID="Label" Text="# Joints Test/Sealed"></asp:Label>
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
                                                <asp:TextBox ID="tbxGeneralDataEstimatedJoints" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralDataJointsTestSealed" runat="server" EnableViewState="False" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
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
                                            <td style="width: 118px;">
                                                <asp:Label ID="lblGeneralDataIssueIdentified" runat="server" EnableViewState="False" SkinID="Label" Text="Issue Identified?"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralDataLfsIssue" runat="server" EnableViewState="False" SkinID="Label" Text="LFS Issue?"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralDataClientIssue" runat="server" EnableViewState="False" SkinID="Label" Text="Client Issue?"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralDataSalesIssue" runat="server" EnableViewState="False" SkinID="Label" Text="Sales Issue?"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralDataIssueGivenToClient" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Issue Given To Client?"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralDataIssueInvestigation" runat="server" EnableViewState="False" SkinID="Label" Text="Issue Investigation?"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CheckBox ID="ckbxGeneralDataIssueIdentified" runat="server" onclick="return cbxClick();" SkinID="CheckBox" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxGeneralDataLfsIssue" runat="server" onclick="return cbxClick();" SkinID="CheckBox" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxGeneralDataClientIssue" runat="server" onclick="return cbxClick();" SkinID="CheckBox" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxGeneralDataSalesIssue" runat="server" onclick="return cbxClick();" SkinID="CheckBox" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxGeneralDataIssueGivenToClient" runat="server" onclick="return cbxClick();" SkinID="CheckBox" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxGeneralDataIssueInvestigation" runat="server" onclick="return cbxClick();" SkinID="CheckBox" />
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
                                                <asp:Label ID="lblGeneralDataIssueResolved" runat="server" EnableViewState="False" SkinID="Label" Text="Issue Resolved?"></asp:Label>
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
                                                <asp:CheckBox ID="ckbxGeneralDataIssueResolved" runat="server" onclick="return cbxClick();" SkinID="CheckBox" />
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
        
        
        
                        <cc1:TabPanel ID="tpRepairsData" runat="server" HeaderText="Repairs" OnClientClick="tpRepairsDataClientClick" >
                            <ContentTemplate>
                                <div style="width: 710px;">
                                    
                                    <!-- Page element: Filter by -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">            
                                        <tr>
                                            <td style="width: 130px">
                                                <asp:Label ID="lblOrder" runat="server" SkinID="Label" Text="Filter Repairs By" EnableViewState="False"></asp:Label>
                                            </td>
                                            <td style="width: 90px">
                                            </td>
                                            <td style="width: 510px">
                                            </td>
                                            <td style="width: 10px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                            <td style="height: 7px">
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlFilter" runat="server" SkinID="DropDownListLookup" AutoPostBack="True" OnSelectedIndexChanged="ddlFilter_SelectedIndexChanged" Width="220px">
                                                    <asp:ListItem Value="(All)" Text="(All)" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Value="Robotic Reaming" Text="Robotic Reaming"></asp:ListItem>
                                                    <asp:ListItem Value="Point Lining" Text="Point Lining"></asp:ListItem>
                                                    <asp:ListItem Value="Grouting" Text="Grouting"></asp:ListItem>
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
                                    <!-- Table element: 1 column  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:GridView id="grdRepairs" runat="server" SkinID="GridViewInTabs" Width="700px" AutoGenerateColumns="False" DataSourceID="odsRepairs" DataKeyNames="WorkID,RepairPointID" OnDataBound="grdRepairs_DataBound">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Repair">
                                                            <HeaderStyle Width="645px"></HeaderStyle>                                                            
                                                            <ItemTemplate>
                                                            
                                                                <asp:PlaceHolder ID="phRoboticReaming" runat="server" Visible='<%# Convert.ToBoolean(Eval("Type").ToString() == "Robotic Reaming") %>'>                                                                
                                                                    <!-- Page element : 6 columns - Repair Information -->
                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">                                                                    
                                                                        <tr>
                                                                            <td style="width: 10px; height: 10px">
                                                                            </td>
                                                                            <td style="width: 129px;">
                                                                                <asp:Label ID="lblRmRepairPointId" runat="server" Text="Repair ID" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                            </td>
                                                                            <td style="width: 129px">
                                                                                <asp:Label ID="lblRmRepairType" runat="server" Text="Repair Type" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                            </td>
                                                                           <td style="width: 129px">
                                                                                <asp:Label ID="lblRmReamDistance" runat="server" Text="Ream Distance" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                            </td>
                                                                            <td style="width: 129px">
                                                                                <asp:Label ID="lblRmDefectQualifier" runat="server" SkinID="Label" Text="Defect Qualifier" EnableViewState="True"></asp:Label>
                                                                            </td>
                                                                            <td style="width: 129px">
                                                                                <asp:Label ID="lblRmDefectDetails" runat="server" SkinID="Label" Text="Defect Details" EnableViewState="True"></asp:Label>
                                                                            </td>                                                                                    
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxRmRepairPointId" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("RepairPointID") %>' EnableViewState="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxRmRepairType" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("Type") %>' EnableViewState="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxRmReamDistance" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("ReamDistance") %>' EnableViewState="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxRmDefectQualifier" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("DefectQualifier") %>' EnableViewState="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxRmDefectDetails" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("DefectDetails") %>' EnableViewState="True"></asp:TextBox>
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
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblRmReamDate" runat="server" Text="Ream Date" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblRmApproval" runat="server" SkinID="Label" Text="Approval" EnableViewState="True"></asp:Label>
                                                                            </td>                                                                                   
                                                                            <td>
                                                                                <asp:Label ID="lblRmReinstateDate" runat="server" Text="Reinstate Date" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxRmReamDate" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("ReamDate", "{0:d}") %>' EnableViewState="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox ID="cbxRmExtraRepair" runat="server" SkinID="CheckBox" Enabled="false" Checked='<%# Eval("ExtraRepair") %>' Text="Extra Repair" EnableViewState="True" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox ID="cbxRmCancelled" runat="server" SkinID="CheckBox" Enabled="false" Checked='<%# Eval("Cancelled") %>' Text="Cancelled" EnableViewState="True" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxRmApproval" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("Approval") %>' EnableViewState="True"></asp:TextBox>
                                                                            </td>                                                                                    
                                                                            <td>
                                                                                <asp:TextBox ID="tbxRmReinstateDate" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("ReinstateDate", "{0:d}") %>' EnableViewState="True"></asp:TextBox>                                                                                
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
                                                                            </td>
                                                                            <td colspan="5">
                                                                                <asp:Label ID="lblRmComments" runat="server" Text="Comments" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td colspan="5">
                                                                                <asp:TextBox ID="tbxRmComments" runat="server" TextMode="MultiLine" Rows="2" SkinID="TextBoxReadOnly" ReadOnly="true" Width="635px" Text='<%# Eval("Comments") %>' EnableViewState="True"></asp:TextBox>
                                                                            <td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 10px">
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
                                                                </asp:PlaceHolder>
                                                                
                                                                <asp:PlaceHolder ID="phPointLining" runat="server" Visible='<%# Convert.ToBoolean(Eval("Type").ToString() == "Point Lining") %>'>                                                               
                                                                    <!-- Page element : 6 columns - Repair Information -->
                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                        <tr>
                                                                            <td style="width: 10px; height: 10px">
                                                                            </td>
                                                                            <td style="width: 129px;">
                                                                                <asp:Label ID="lblPlRepairPointID" runat="server" Text="Repair ID" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                            </td>
                                                                            <td style="width: 129px">
                                                                                <asp:Label ID="lblPlRepairType" runat="server" Text="Repair Type" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                            </td>
                                                                           <td style="width: 129px">
                                                                                <asp:Label ID="lblPlLinerDistance" runat="server" Text="Liner Distance" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                            </td>
                                                                            <td style="width: 129px">
                                                                                <asp:Label ID="lblPlDefectQualifier" runat="server" SkinID="Label" Text="Defect Qualifier" EnableViewState="True"></asp:Label>
                                                                            </td>
                                                                            <td style="width: 129px">
                                                                                <asp:Label ID="lblPlDefectDetails" runat="server" SkinID="Label" Text="Defect Details" EnableViewState="True"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxPlRepairPointId" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("RepairPointID") %>' EnableViewState="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxPlRepairType" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("Type") %>' EnableViewState="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxPlLinerDistance" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("LinerDistance") %>' EnableViewState="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxPlDefectQualifier" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("DefectQualifier") %>' EnableViewState="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxPlDefectDetails" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("DefectDetails") %>' EnableViewState="True"></asp:TextBox>
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
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblPlDirection" runat="server" Text="Direction" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblPlReinstates" runat="server" Text="Reinstates" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblPlLtmh" runat="server" SkinID="Label" Text="LT @ MH" EnableViewState="True"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblPlVtmh" runat="server" SkinID="Label" Text="VT @ MH" EnableViewState="True"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblPlDistance" runat="server" SkinID="Label" Text="Distance" EnableViewState="True"></asp:Label>
                                                                            </td>                                                                                    
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxPlDirection" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("Direction") %>' EnableViewState="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxPlReinstates" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("Reinstates") %>' EnableViewState="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxPlLtmh" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("LTMH") %>' EnableViewState="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxPlVtmh" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("VTMH") %>' EnableViewState="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxPlDistance" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("Distance") %>' EnableViewState="True"></asp:TextBox>
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
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblPlSize" runat="server" SkinID="Label" Text="Size" EnableViewState="True"></asp:Label>                                                                              
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblPlLength" runat="server" SkinID="Label" Text="Length" EnableViewState="True"></asp:Label>                                                                              
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblPlInstallDate" runat="server" SkinID="Label" Text="Install Date" EnableViewState="True"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblPlMhShot" runat="server" SkinID="Label" Text="MH Shot?" EnableViewState="True"></asp:Label>
                                                                            </td>                                                                            
                                                                            <td>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxPlSize" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("Size_") %>' EnableViewState="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxPlLength" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("Length") %>' EnableViewState="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxPlInstallDate" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("InstallDate", "{0:d}") %>' EnableViewState="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxPlMhShot" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("MHShot") %>' EnableViewState="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox ID="cbxPlExtraRepair" runat="server" SkinID="CheckBox" Enabled="false" Checked='<%# Eval("ExtraRepair") %>' Text="Extra Repair" EnableViewState="True"/>
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
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblPlApproval" runat="server" SkinID="Label" Text="Approval" EnableViewState="True"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblPlReinstateDate" runat="server" Text="Reinstate Date" SkinID="Label" EnableViewState="True"></asp:Label>
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
                                                                                <asp:CheckBox ID="cbxPlCancelled" runat="server" SkinID="CheckBox" Enabled="false" Checked='<%# Eval("Cancelled") %>' Text="Cancelled" EnableViewState="True" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxPlApproval" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("Approval") %>' EnableViewState="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxPlReinstateDate" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("ReinstateDate", "{0:d}") %>' EnableViewState="True"></asp:TextBox>                                                                                
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
                                                                            </td>
                                                                            <td colspan="5">
                                                                                <asp:Label ID="lblPlComments" runat="server" Text="Comments" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td colspan="5">
                                                                                <asp:TextBox ID="tbxPlComments" runat="server" TextMode="MultiLine" Rows="2" SkinID="TextBoxReadOnly" ReadOnly="true" Width="635px" Text='<%# Eval("Comments") %>' EnableViewState="True"></asp:TextBox>
                                                                            <td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 10px">
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
                                                                </asp:PlaceHolder>
                                                                
                                                                <asp:PlaceHolder ID="phGrouting" runat="server" Visible='<%# Convert.ToBoolean(Eval("Type").ToString() == "Grouting") %>'> 
                                                                    <!-- Page element : 6 columns - Repair Information -->
                                                                    <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                        <tr>
                                                                            <td style="width: 10px; height: 10px">
                                                                            </td>
                                                                            <td style="width: 129px;">
                                                                                <asp:Label ID="lblGtRepairPointId" runat="server" Text="Repair ID" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                            </td>
                                                                            <td style="width: 129px">
                                                                                <asp:Label ID="lblGtRepairType" runat="server" Text="Repair Type" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                            </td>
                                                                           <td style="width: 129px">
                                                                                <asp:Label ID="lblGtGroutDistance" runat="server" Text="Grout Distance" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                            </td>
                                                                            <td style="width: 129px"> 
                                                                                <asp:Label ID="lblGtDefectQualifier" runat="server" SkinID="Label" Text="Defect Qualifier" EnableViewState="True"></asp:Label>
                                                                            </td>
                                                                            <td style="width: 129px"> 
                                                                                <asp:Label ID="lblGtDefectDetails" runat="server" SkinID="Label" Text="Defect Details" EnableViewState="True"></asp:Label>
                                                                            </td>                                                                            
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxGtRepairPointId" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("RepairPointID") %>' EnableViewState="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxGtRepairType" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("Type") %>' EnableViewState="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxGtGroutDistance" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("GroutDistance") %>' EnableViewState="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxGtDefectQualifier" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("DefectQualifier") %>' EnableViewState="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxGtDefectDetails" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("DefectDetails") %>' EnableViewState="True"></asp:TextBox>
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
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblGtGroutDate" runat="server" Text="Grout Date" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:Label ID="lblGtApproval" runat="server" SkinID="Label" Text="Approval" EnableViewState="True"></asp:Label>
                                                                            </td>                                                                        
                                                                            <td>
                                                                                <asp:Label ID="lblGtReinstateDate" runat="server" Text="Reinstate Date" SkinID="Label" EnableViewState="True"></asp:Label>                                                                                
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxGtGroutDate" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("GroutDate", "{0:d}") %>' EnableViewState="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox ID="cbxGtExtraRepair" runat="server" SkinID="CheckBox" Enabled="false" Checked='<%# Eval("ExtraRepair") %>' Text="Extra Repair" EnableViewState="True" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:CheckBox ID="cbxGtCancelled" runat="server" SkinID="CheckBox" Enabled="false" Checked='<%# Eval("Cancelled") %>' Text="Cancelled" EnableViewState="True" />
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxGtApproval" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("Approval") %>' EnableViewState="True"></asp:TextBox>
                                                                            </td>
                                                                            <td>
                                                                                <asp:TextBox ID="tbxGtReinstateDate" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Width="119px" Text='<%# Eval("ReinstateDate", "{0:d}") %>' EnableViewState="True"></asp:TextBox>                                                                                
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
                                                                            </td>
                                                                            <td colspan="5">
                                                                                <asp:Label ID="lblGtComments" runat="server" Text="Comments" SkinID="Label" EnableViewState="True"></asp:Label>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                            </td>
                                                                            <td colspan="5">
                                                                                <asp:TextBox ID="tbxGtComments" runat="server" TextMode="MultiLine" Rows="2" SkinID="TextBoxReadOnly" ReadOnly="true" Width="635px" Text='<%# Eval("Comments") %>' EnableViewState="True"></asp:TextBox>
                                                                            <td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td style="height: 10px">
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
                                                                </asp:PlaceHolder>
                                                                
                                                            </ItemTemplate>                                                        
                                                        </asp:TemplateField>

                                                        <asp:TemplateField>  
                                                            <HeaderStyle Width="55px"></HeaderStyle>                                                     
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
        
        
        
                        <cc1:TabPanel ID="tpComments" runat="server" HeaderText="Comments" OnClientClick="tpCommentsDataClientClick">
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
                                                <asp:GridView id="grdComments" runat="server" SkinID="GridViewInTabs" Width="700px" AutoGenerateColumns="False" 
                                                    DataSourceID="odsComments" DataKeyNames="WorkID,RefID" OnDataBound="grdComments_DataBound">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="WorkID" SortExpression="WorkID" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblWorkID" runat="server" Text='<%# Eval("WorkID") %>'></asp:Label>                 
                                                            </ItemTemplate>
                                                        </asp:TemplateField>                                                   
                                                                                                            
                                                        <asp:TemplateField HeaderText="RefID" SortExpression="RefID" Visible="False">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblRefID" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>                 
                                                            </ItemTemplate>
                                                        </asp:TemplateField>                                                 
                                                        
                                                        <asp:TemplateField HeaderText="Information" SortExpression="Subject">
                                                            <HeaderStyle Width="320px"></HeaderStyle>
                                                            <ItemTemplate>                                                        
                                                                <!-- Page element : 2 columns - Comments Information -->
                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                    <tr>
                                                                        <td style="width: 160px; height: 10px">
                                                                        </td>
                                                                        <td style="width: 160px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblCommentSubject" runat="server" EnableViewState="True" SkinID="Label" Text="Subject"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="tbxCommentSubject" runat="server" EnableViewState="True" ReadOnly="True" Text='<%# Eval("Subject") %>' SkinID="TextBoxReadOnly" Style="width: 310px"></asp:TextBox>
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
                                                                            <asp:Label ID="lblCommentDate" runat="server" EnableViewState="True" SkinID="Label" Text="Date"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblCommentCreatedBy" runat="server" EnableViewState="True" SkinID="Label" Text="Created By"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxCommentDate" runat="server" EnableViewState="True" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 150px" Text='<%# Eval("DateTime_") %>'></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxCommentCreatedBy" runat="server" EnableViewState="True" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 150px" Text='<%# GetCommentCreatedBy(Eval("UserID")) %>'></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 10px">
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </ItemTemplate>                                                        
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Comment" SortExpression="Comment">
                                                            <HeaderStyle Width="320px"></HeaderStyle>
                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            <ItemTemplate>
                                                                <!-- Page element : 2 columns - Comment information -->
                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                    <tr>
                                                                        <td style="width: 160px; height: 10px">
                                                                        </td>
                                                                        <td style="width: 160px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblCommentComment" runat="server" EnableViewState="True" SkinID="Label" Text="Comment"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2">
                                                                            <asp:TextBox ID="tbxCommentComment" runat="server" EnableViewState="True" ReadOnly="True" Text='<%# Eval("Comment") %>' Rows="4" SkinID="TextBoxReadOnly" Style="width: 310px" TextMode="MultiLine"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="2" style="height: 10px">
                                                                        </td>
                                                                    </tr>
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
                    <asp:ObjectDataSource ID="odsComments" runat="server" FilterExpression="(Deleted = 0)"
                        SelectMethod="GetCommentsNew" TypeName="LiquiForce.LFSLive.WebUI.CWP.PointRepairs.pr_summary">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsRepairs" runat="server" FilterExpression="(Deleted = 0)"
                        SelectMethod="GetRepairsNew" TypeName="LiquiForce.LFSLive.WebUI.CWP.PointRepairs.pr_summary">
                        
                    </asp:ObjectDataSource>
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
                    <asp:HiddenField ID="hdfAssetId" runat="server" />
                    <asp:HiddenField ID="hdfCountryId" runat="server" />
                    <asp:HiddenField ID="hdfProvinceId" runat="server" />
                    <asp:HiddenField ID="hdfCountyId" runat="server" />
                    <asp:HiddenField ID="hdfCityId" runat="server" />
                    <asp:HiddenField ID="hdfWorkId" runat="server" />
                    <asp:HiddenField ID="hdfActiveTab" runat="server" />
                    <asp:HiddenField ID="hdfSectionId" runat="server" />
                    <asp:HiddenField ID="hdfFlowOrderId" runat="server" />
                </td>
            </tr>
        </table>
        
    </div>
</asp:Content>