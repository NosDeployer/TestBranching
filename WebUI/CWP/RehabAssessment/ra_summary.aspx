<%@ Page Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" CodeBehind="ra_summary.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.CWP.RehabAssessment.ra_summary" Title="LFS Live" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%; ">
            <tr>
                <td style="width: 670px">
                    <asp:Label ID="lblTitle" runat="server" Text="Rehab Assessment Summary" SkinID="LabelPageTitle1"></asp:Label>
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
                    <asp:Button ID="btnTitleProjectChange" runat="server" Text="Change" Width="70px" SkinID="ButtonPageTitle" EnableViewState="False" OnClick="btnChange_Click"/>
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
                            <telerik:RadPanelItem Expanded="True" Text="Rehab Assessment" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddSection" Text="Add Sections"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSearch" Text="Search" ></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mRehabAssessmentPlan" Text="Rehab Assessment Plan"></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mM1M2ReportByClient" Text="M1 &amp; M2 Report" ></telerik:RadPanelItem>
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
                                    <telerik:RadMenuItem Value="mFullLenghtLining" Text="FULL LENGTH LINING" />
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
                    <asp:Label ID="lblStreet" runat="server" EnableViewState="False" SkinID="Label" Text="Street"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblUSMH" runat="server" EnableViewState="False" SkinID="Label" Text="USMH"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblDSMH" runat="server" EnableViewState="False" SkinID="Label" Text="DSMH"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="tbxStreet" runat="server" EnableViewState="False" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 240px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxUSMH" runat="server" EnableViewState="False" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxDSMH" runat="server" EnableViewState="False" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
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
                    <asp:Label ID="lblMapSize" runat="server" EnableViewState="False" SkinID="Label" Text="Map Size"></asp:Label>
                </td>
                <td style="width: 125px">
                    <asp:Label ID="lblConfirmedSize" runat="server" EnableViewState="False" SkinID="Label" Text="Confirmed Size"></asp:Label>
                </td>
                <td style="width: 125px">
                    <asp:Label ID="lblThickness" runat="server" EnableViewState="False" 
                        SkinID="Label" Text="Thickness"></asp:Label>
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
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxMapSize" runat="server" EnableViewState="False" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxConfirmedSize" runat="server" EnableViewState="False" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxThickness" runat="server" EnableViewState="False" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxMapLength" runat="server" EnableViewState="False" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxLength" runat="server" EnableViewState="False" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxVideoLength" runat="server" EnableViewState="False" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 115px"></asp:TextBox>
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
                    <asp:Label ID="lblLaterals" runat="server" EnableViewState="False" SkinID="Label" Text="Laterals"></asp:Label>
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
        
        <!-- Table element: 6 columns - Rehab Assessment Details title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblRehabAssessmentDetails" runat="server" SkinID="LabelTitle1" Text="Rehab Assessment Details"
                        EnableViewState="False"></asp:Label>
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
                    <cc1:TabContainer ID="tcRaDetails" Width="730px" runat="server" 
                        ActiveTabIndex="2" CssClass="ajax_tabcontainer">
        
                        <cc1:TabPanel ID="tpGeneralData" runat="server" HeaderText="General Data"  OnClientClick="tpGeneralDataClientClick" >
                            <ContentTemplate>
                                <div style="width: 710px; height: 220px; overflow-y: auto;">
                                
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
                                                    Text="Client ID"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGeneralSubArea" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="Sub Area"></asp:Label>
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
                                                <asp:TextBox ID="tbxGeneralClientId" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralSubArea" runat="server" EnableViewState="False" ReadOnly="True"
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
                                                    Text="Pre-Flush Date"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblGeneralPreVideoDate" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="Pre-Video Date"></asp:Label>
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
                                                <asp:TextBox ID="tbxGeneralPreFlushDate" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralPreVideoDate" runat="server" EnableViewState="False" ReadOnly="True"
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
        
        
        
                        <cc1:TabPanel ID="tpPrepData" runat="server" HeaderText="Prep Data" OnClientClick="tpPrepDataClientClick">
                            <ContentTemplate>
                                <div style="width: 710px; height: 220px; overflow-y: auto;">
                                
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
                                                <asp:CheckBox ID="ckbxPrepDataRoboticPrepCompleted" runat="server" onclick="return cbxClick();" SkinID="CheckBox" />
                                            </td>
                                            <td>
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
                                                <asp:Label ID="lblPrepDataCXIsRemoved" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="CXI’s Removed"></asp:Label>
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
                                                <asp:TextBox ID="tbxPrepDataCXIsRemoved" runat="server" EnableViewState="False" ReadOnly="True"
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
                                                <asp:Label ID="lblM1DataMeasurementsTakenBy" runat="server" EnableViewState="False"
                                                    SkinID="Label" Text="Measurements Taken By"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataM1Date" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
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
                                                <asp:Label ID="lblM1DataSteelTapeThroughSewer" runat="server" EnableViewState="False"
                                                    SkinID="Label" Text="Steel Tape Through Sewer"></asp:Label>
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
                                                <asp:TextBox ID="tbxM1DataMaterial" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 226px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataSteelTapeThroughSewer" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
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
                                                <asp:Label ID="lblM1DataUsmhDepth" runat="server" EnableViewState="False"
                                                    SkinID="Label" Text="USMH Depth"></asp:Label>
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
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataUsmhDepth" runat="server" EnableViewState="False" ReadOnly="True"
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
                                                    Text="USMH Mouth 12:00"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblM1DataUsmhMouth1" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="USMH Mouth 1:00"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblM1DataUsmhMouth2" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="USMH Mouth 2:00"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblM1DataUsmhMouth3" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="USMH Mouth 3:00"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblM1DataUsmhMouth4" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="USMH Mouth 4:00"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblM1DataUsmhMouth5" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="USMH Mouth 5:00"></asp:Label></td>
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
                                            <td>
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
                                            <td>
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
                                            <td style="width: 118px">
                                                <asp:Label ID="lblM1DataTrafficControl" runat="server" EnableViewState="False" SkinID="Label" Text="Traffic Control"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblM1DataSiteDetails" runat="server" EnableViewState="False" SkinID="Label" Text="Site Details"></asp:Label>
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
                                                <asp:CheckBox ID="ckbxM1DataPipeSizeChange" runat="server" onclick="return cbxClick();" SkinID="CheckBox" />
                                            </td>
                                            <td>
                                                <asp:CheckBox ID="ckbxM1DataStandardBypass" runat="server" onclick="return cbxClick();" SkinID="CheckBox" />
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
                                            <td colspan="6">
                                                <asp:Label ID="lblM1DataStandardBypassComments" runat="server" EnableViewState="False"
                                                    SkinID="Label" Text="Standard Bypass Comments"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:TextBox ID="tbxM1DataStandardBypassComments" runat="server" EnableViewState="False"
                                                    ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 698px" Rows="4" TextMode="MultiLine"></asp:TextBox>
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
                                                <asp:Label ID="lblM1DataMeasurementType" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="Measurement Type"></asp:Label>
                                            </td>
                                            <td style="width: 118px;">
                                                <asp:Label ID="lblM1DataMeasuredFromMH" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                    Text="Measured From MH"></asp:Label>
                                            </td>
                                            <td style="width: 118px;">
                                            </td>
                                            <td style="width: 118px;">
                                            </td>
                                            <td style="width: 118px;">
                                            </td>
                                            <td style="width: 118px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataMeasurementType" runat="server" EnableViewState="False" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataMeasuredFromMH" runat="server" EnableViewState="False"
                                                    ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
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
                                            <td style="width: 118px;">
                                                <asp:Label ID="lblM1DataVideoDoneFromMH" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Video Done From MH"></asp:Label>
                                            </td>
                                            <td style="width: 118px">
                                                <asp:Label ID="lblM1DataToMH" runat="server" EnableViewState="False" SkinID="Label" Text="To MH"></asp:Label>
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
                                                <asp:TextBox ID="tbxM1DataVideoDoneFromMH" runat="server" EnableViewState="False"
                                                    ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 108px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxM1DataToMH" runat="server" EnableViewState="False" ReadOnly="True"
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
                                                <asp:Label ID="lblLateralMeasurementInfo" runat="server" EnableViewState="False" SkinID="LabelTitle2"
                                                    Text="Lateral Measurement Info"></asp:Label>
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
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblLateral" runat="server" Text='<%# Eval("Lateral") %>'></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLateral" runat="server" Text='<%# Eval("Lateral") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                                                                   
                                                    <asp:TemplateField HeaderText="Laterals" SortExpression="LateralID">
                                                        <HeaderStyle Width="570px" />                                                    
                                                        
                                                        <ItemTemplate>
                                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 570px">
                                                                <tr>
                                                                    <td style="width: 10px; height: 12px"></td>
                                                                    <td style="width: 91px"></td>
                                                                    <td style="width: 91px"></td>
                                                                    <td style="width: 92px"></td>
                                                                    <td style="width: 92px"></td>
                                                                    <td style="width: 92px"></td>
                                                                    <td style="width: 92px"></td>
                                                                    <td style="width: 10px"></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblLateralId" runat="server" SkinID="Label" Text="Lateral ID"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblClientInspectionNo" runat="server" SkinID="Label" Text="Client Insp.#"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblClientLateralId" runat="server" SkinID="Label" Text="Client Lateral ID"></asp:Label>
                                                                    </td>
                                                                    <td colspan="2">
                                                                        <asp:Label ID="lblMn" runat="server" SkinID="Label" Text="MN#"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblContractYear" runat="server" SkinID="Label" Text="Contract Year"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxLateralId" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("LateralID") %>' Width="81px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxClientInspectionNo" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("ClientInspectionNo") %>' Width="81px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxClientLateralId" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("ClientLateralID") %>' Width="81px"></asp:TextBox>
                                                                    </td>
                                                                    <td colspan="2">
                                                                        <asp:TextBox ID="tbxMn" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("Mn") %>' Width="174px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxContractYear" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("ContractYear") %>' Width="81px"></asp:TextBox>
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
                                                                        <asp:Label ID="lblConnectionType" runat="server" SkinID="Label" Text="Connection Type"></asp:Label>
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
                                                                        <asp:TextBox ID="tbxClockPosition" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Text='<%# Eval("ClockPosition") %>' Width="81px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxSize" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("Size_") %>' Width="82px" ReadOnly="True"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxMaterial" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("MaterialType") %>' Width="82px" ReadOnly="True"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxConnectionType" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("ConnectionType") %>' Width="82px" ReadOnly="True"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxJLFlangeType" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("Flange") %>' Width="82px" ReadOnly="True"></asp:TextBox>                                                                        
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxLive" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("Live") %>' Width="82px" ReadOnly="True"></asp:TextBox>
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
                                                                        <asp:Label ID="lblV1Inspection" runat="server" SkinID="Label" Text="V1 Inspection"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxVideoDistance" runat="server" ReadOnly="True" 
                                                                            SkinID="TextBoxReadOnly" Text='<%# GetDistance(Eval("VideoDistance")) %>' 
                                                                            Width="81px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxDistanceToCentre" runat="server" ReadOnly="True" 
                                                                            SkinID="TextBoxReadOnly" Text='<%# GetDistance(Eval("DistanceToCentre")) %>' 
                                                                            Width="81px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:UpdatePanel ID="upnlLateralReverseSetup" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:TextBox ID="tbxReverseSetup" runat="server" ReadOnly="True" 
                                                                                    SkinID="TextBoxReadOnly" Text='<%# GetDistance(Eval("ReverseSetup")) %>' 
                                                                                    Width="81px"></asp:TextBox>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxTimeOpened" runat="server" ReadOnly="True" 
                                                                            SkinID="TextBoxReadOnly" Text='<%# Eval("TimeOpened") %>' Width="82px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxReinstate" runat="server" ReadOnly="True" 
                                                                            SkinID="TextBoxReadOnly" Text='<%# Eval("Reinstate", "{0:d}") %>' Width="82px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxV1Inspection" runat="server" ReadOnly="True" 
                                                                            SkinID="TextBoxReadOnly" Text='<%# Eval("V1Inspection", "{0:d}") %>' 
                                                                            Width="82px"></asp:TextBox>
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
                                                                        <asp:CheckBox ID="ckbxRequiresRoboticPrep" runat="server" 
                                                                            Checked='<%# Eval("RequiresRoboticPrep") %>' onclick="return cbxClick();" 
                                                                            SkinID="CheckBox" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxRequiresRoboticPrepDate" runat="server" ReadOnly="True" 
                                                                            SkinID="TextBoxReadOnly" Text='<%# Eval("RequiresRoboticPrepDate", "{0:d}") %>' 
                                                                            Width="81px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox ID="ckbxHoldClientIssue" runat="server" 
                                                                            Checked='<%# Eval("HoldClientIssue") %>' onclick="return cbxClick();" 
                                                                            SkinID="CheckBox" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox ID="ckbxHoldLFSIssue" runat="server" 
                                                                            Checked='<%# Eval("HoldLFSIssue") %>' onclick="return cbxClick();" 
                                                                            SkinID="CheckBox" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:CheckBox ID="ckbxDyeTestReq" runat="server" 
                                                                            Checked='<%# Eval("DyeTestReq") %>' onclick="return cbxClick();" 
                                                                            SkinID="CheckBox" />
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxDyeTestComplete" runat="server" ReadOnly="True" 
                                                                            SkinID="TextBoxReadOnly" Text='<%# Eval("DyeTestComplete", "{0:d}") %>' 
                                                                            Width="81px"></asp:TextBox>
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
                                                                    <td></td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                    </td>
                                                                    <td colspan="6">
                                                                        <asp:TextBox ID="tbxComments" runat="server" EnableViewState="False" 
                                                                            ReadOnly="True" Rows="4" SkinID="TextBoxReadOnly" Style="width: 540px" 
                                                                            Text='<%# Eval("Comments") %>' TextMode="MultiLine"></asp:TextBox>
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
                                                    
                                                    <asp:TemplateField HeaderText="Line Lateral?">
                                                        <HeaderStyle Width="50px" />
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>                                                        
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="cbxJl" runat="server" Checked='<%# Eval("LineLateral") %>' Enabled="false" SkinID="CheckBox" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                                                                        
                                                    <asp:TemplateField SortExpression="InProject">
                                                        <HeaderStyle Width="90px" />
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <EditItemTemplate>
                                                            <%--<asp:CheckBox ID="cbxInProject" runat="server" Checked='<%# Eval("InProject") %>' SkinID="CheckBox" />--%>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <%--<asp:CheckBox ID="cbxInProjectI" runat="server" Checked='<%# Eval("InProject") %>' Enabled="false" SkinID="CheckBox" />--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField Visible="False">
                                                        <HeaderStyle Width="40px"></HeaderStyle>
                                                        <EditItemTemplate>
                                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                <tr>
                                                                    <td style="width: 50%">
                                                                        <asp:ImageButton ID="ibtnAccept" runat="server" CommandName="Update" ImageUrl="./../../App_Themes/LFS2/images/gridview/update.png" />
                                                                    </td>
                                                                    <td style="width: 50%">
                                                                        <asp:ImageButton ID="ibtnCancel" runat="server" CommandName="Cancel" ImageUrl="./../../App_Themes/LFS2/images/gridview/cancel.png" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </EditItemTemplate>
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
        
        
        
                        <cc1:TabPanel ID="tpComments" runat="server" HeaderText="Comments" OnClientClick="tpCommentDataClientClick">
                            <ContentTemplate>
                                <div style="width: 710px; height: 220px; overflow-y: auto;">
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
                                                        <asp:Button id="btnComments" onclick="btnCommentsOnClick" runat="server" SkinID="Button" Text="Update" EnableViewState="False" Width="80px" __designer:wfdid="w215"></asp:Button> 
                                                    </contenttemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="6">
                                                <asp:TextBox ID="tbxCommentsDataComments" runat="server" EnableViewState="False"
                                                    ReadOnly="True" Rows="20" SkinID="TextBoxReadOnly" Style="width: 700px" TextMode="MultiLine"></asp:TextBox></td>
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
                        TypeName="LiquiForce.LFSLive.WebUI.CWP.RehabAssessment.ra_summary">
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
                    <asp:HiddenField ID="hdfWorkType" runat="server" />
                    <asp:HiddenField ID="hdfAssetId" runat="server" />
                    <asp:HiddenField ID="hdfCountryId" runat="server" />
                    <asp:HiddenField ID="hdfProvinceId" runat="server" />
                    <asp:HiddenField ID="hdfCountyId" runat="server" />
                    <asp:HiddenField ID="hdfCityId" runat="server" />
                    <asp:HiddenField ID="hdfWorkId" runat="server" />
                    <asp:HiddenField ID="hdfWorkIdFll" runat="server" />
                    <asp:HiddenField ID="hdfActiveTab" runat="server" />
                    <asp:HiddenField ID="hdfSectionId" runat="server" />
                    <asp:HiddenField ID="hdfFlowOrderId" runat="server" />
                    <asp:HiddenField ID="hdfMeasuredFrom" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>