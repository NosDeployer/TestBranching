<%@ Page Language="C#" MasterPageFile="./../../mForm6.master"  AutoEventWireup="true" CodeBehind="services_summary.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.Services.services_summary" Title="LFS Live" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td>
                    <asp:Label ID="lblTitle" runat="server" Text="Service Information" SkinID="LabelPageTitle1"></asp:Label>
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
                    <telerik:RadPanelBar ID="tkrpbLeftMenuMyServiceRequests" runat="server" SkinID="RadPanelBar" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="My Service Requests" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddServiceRequest" Text="Add Service Request"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSearch" Text="Search" ></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadPanelBar ID="tkrpbLeftMenuAllServiceRequests" runat="server" SkinID="RadPanelBar" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="All Service Requests" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="mAddServiceRequest" Text="Add Service Request"></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mSRManager" Text="Service Requests Manager" ></telerik:RadPanelItem>
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
                                    <telerik:RadPanelItem runat="server" Value="mMyCurrentSR" Text="My Current Service Requests" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSRUnassigned" Text="Unassigned Service Requests" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSRRejected" Text="Rejected Service Requests" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSRAboutToExpire" Text="About To Expire Service Requests" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="mSRExpired" Text="Expired Service Requests" ></telerik:RadPanelItem>
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
                            
                            <telerik:RadMenuItem Value="mAssign" Text="ASSIGN" />
                            
                            <telerik:RadMenuItem Value="mAccept" Text="ACCEPT" />
                            
                            <telerik:RadMenuItem Value="mReject" Text="REJECT" />
                            
                            <telerik:RadMenuItem Value="mStartWork" Text="START WORK" />
                            
                            <telerik:RadMenuItem Value="mCompleteWork" Text="COMPLETE WORK" />
                        </Items>                        
                    </telerik:RadMenu>
                </td>
                <td align="right">
                    <telerik:RadMenu ID="tkrmTopNavigation" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick" style="float:right !important;" >                       
                        <Items>
                            <telerik:RadMenuItem Value="mPrevious" Text="PREVIOUS" ToolTip="Previous record" />
                            
                            <telerik:RadMenuItem Value="mNext" Text="NEXT" ToolTip="Next record" />
                            
                            <telerik:RadMenuItem Value="mLastSearch" Text="LAST SEARCH" />
                            
                            <telerik:RadMenuItem Value="mDashboard" Text="RETURN TO DASHBOARD" />
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
        
        <!-- Table element: 1 columns - Service Details Title -->
       <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblBasicInformation" runat="server" SkinID="LabelTitle1" Text="Basic Information" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 5 columns - Service Details -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 150px">
                    <asp:Label ID="lblServiceNumber" runat="server" EnableViewState="False" SkinID="Label" Text="Service Number"></asp:Label>
                </td>
                <td style="width: 150px">
                    <asp:Label ID="lblDateTime" runat="server" EnableViewState="False" SkinID="Label" Text="Date & Time"></asp:Label>
                </td>
                <td style="width: 150px">
                    <asp:Label ID="lblChecklistNextDueDate" runat="server" EnableViewState="False" SkinID="Label" Text="Checklist Next Due Date"></asp:Label>
                </td>
                <td style="width: 150px">
                    <asp:Label ID="lblMtoDot" runat="server" EnableViewState="False" SkinID="Label" Text="Fixed Date"></asp:Label>
                </td>                
                <td style="width: 150px">
                    <asp:Label ID="lblServiceState" runat="server" EnableViewState="False" SkinID="Label" Text="Service State"></asp:Label>
                 </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxServiceNumber" runat="server" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 140px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxDateTime" runat="server" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 140px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxChecklistNextDueDate" runat="server" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 140px"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="ckbxMtoDto" runat="server" onclick="return cbxClick();" SkinID="CheckBox" />
                </td>                
                <td>
                    <asp:TextBox ID="tbxServiceState" runat="server" ReadOnly="True"
                        SkinID="TextBoxSpecialWhite" Style="width: 140px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 7px" colspan="5">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblDescription" runat="server" EnableViewState="False" SkinID="Label" Text="Description"></asp:Label>
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
                    <asp:TextBox ID="tbxServiceDescription" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 740px" Rows="4" 
                        TextMode="MultiLine"></asp:TextBox>
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
        
        <!-- Table element: 5 columns - Service Details 2 -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 150px">
                    <asp:Label ID="lblUnitCode" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Unit Code"></asp:Label>
                </td>
                <td style="width: 150px">
                    <asp:Label ID="lblUnitDescription" runat="server" EnableViewState="False" SkinID="Label" Text="Unit Description"></asp:Label>
                </td>
                <td style="width: 150px">
                </td>
                <td style="width: 150px">
                    <asp:Label ID="lblVinSn" runat="server" EnableViewState="False" SkinID="Label" Text="VIN/SN"></asp:Label>
                </td>
                <td style="width: 150px">
                    <asp:Label ID="lblUnitState" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Unit State"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxUnitCode" runat="server" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 140px"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="tbxUnitDescription" runat="server" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 290px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxVinSn" runat="server" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 140px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxUnitState" runat="server" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 140px"></asp:TextBox>
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
        
        <!-- Table element: 5 columns - Service Details 2 -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td colspan="3" style="width: 450px">
                    <asp:Label ID="lblAssociatedChecklistRule" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Associated Checklist Rule"></asp:Label>
                </td>
                <td style="width: 150px">
                    <asp:Label ID="lblChecklistState" runat="server" EnableViewState="False" SkinID="LabelSmall"
                        Text="Associated Checklist State"></asp:Label>
                </td>
                <td style="width: 150px">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:TextBox ID="tbxAssociatedChecklistRule" runat="server" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 440px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxChecklistState" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly"
                        Style="width: 140px"></asp:TextBox>
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
        
        <!-- Table element: 5 columns - Detailed information title -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblDetailedInformation" runat="server" SkinID="LabelTitle1" Text="Detailed Information"
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
                    <cc1:TabContainer ID="tcDetailedInformation" Width="730px" runat="server" 
                        ActiveTabIndex="3" CssClass="ajax_tabcontainer" Height="640px">
        
                        <cc1:TabPanel ID="tpGeneralData" runat="server" HeaderText="General" OnClientClick="tpGeneralDataClientClick" >
                            <ContentTemplate>
                                <div style="width: 710px">
                                
                                    <!-- Table element: 4 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 416px">
                                        <tr>
                                            <td style="width: 142px; height: 10px;">
                                            </td>
                                            <td style="width: 142px">
                                            </td>
                                            <td style="width: 110px">
                                            </td>
                                            <td style="width: 32px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblGeneralCreatedBy" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="Created By"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGeneralMileage" runat="server" EnableViewState="False" SkinID="Label"
                                                    Text="Mileage"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:TextBox ID="tbxGeneralCreatedBy" runat="server" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 274px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralMileage" runat="server" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 100px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGeneralMileageUnitOfMeasurement" runat="server" 
                                                    EnableViewState="False" SkinID="Label"></asp:Label>    
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpAssignmentData" runat="server" HeaderText="Assignment" OnClientClick="tpAssignmentDataClientClick">
                            <ContentTemplate>
                                <div style="width: 710px">
                                
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
                                            <td>
                                                <asp:Label ID="lblAssignmentDataAssignedDeadlineDate" runat="server" EnableViewState="False"
                                                    SkinID="LabelSmall" Text="Assigned Deadline Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblAssignmentDataAssignmentDateTime" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                    Text="Assignment Date & Time" Visible="false"></asp:Label>
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
                                                <asp:TextBox ID="tbxAssignmentDataAssignedDeadlineDate" runat="server"
                                                    ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 132px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxAssignmentDataAssignmentDateTime" runat="server" ReadOnly="True"
                                                    SkinID="TextBoxSmallReadOnly" Style="width: 132px" Visible="false"></asp:TextBox>
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
        
                                    <!-- Table element: 5 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td colspan="2">
                                                <asp:RadioButton ID="rbtnAssignmentDataToTeamMember" runat="server" Checked="True"
                                                    GroupName="Begin" SkinID="RadioButton" Text="To Team Member" onclick="return rbtnClick();" />
                                            </td>
                                            <td colspan="2">
                                                <asp:RadioButton ID="rbtnAssignmentDataToThirdPartyVendor" runat="server" Checked="True"
                                                    GroupName="Begin" SkinID="RadioButton" Text="To Third Party Vendor" onclick="return rbtnClick();" />
                                            </td>
                                            <td style="width: 142px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:TextBox ID="tbxAssigmentDataToTeamMemberName" runat="server" ReadOnly="True"
                                                    SkinID="TextBoxReadOnly" Style="width: 274px"></asp:TextBox>
                                            </td>
                                            <td colspan="2">
                                                <asp:TextBox ID="tbxAssignmentDataAssignToThirdPartyVendor" runat="server" SkinID="TextBoxReadOnly" 
                                                ReadOnly="True" Style="width: 274px"></asp:TextBox>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <asp:Panel ID="pnlAssignmentAccept" runat="server"  Width="100%">
                
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
            
                                        <!-- Table element: 5 columns - Accept data  --> 
                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                            <tr>
                                                <td style="width: 142px">
                                                    <asp:Label ID="lblAssignmentDataAcceptedDateTime" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                        Text="Accepted Date & Time"></asp:Label>
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
                                                    <asp:TextBox ID="tbxAssignmentDataAcceptedDateTime" runat="server" ReadOnly="True"
                                                        SkinID="TextBoxSmallReadOnly" Style="width: 132px"></asp:TextBox>
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
                                    
                                    
                                    <asp:Panel ID="pnlAssignmentReject" runat="server"  Width="100%">
                
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
                                        
                                        <!-- Table element: 5 columns - Reject data  -->                                    
                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                            <tr>
                                                <td style="width: 142px">
                                                    <asp:Label ID="lblAssignmentDataRejectedDateTime" runat="server" EnableViewState="False" SkinID="LabelSmall"
                                                        Text="Rejected Date & Time"></asp:Label>
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
                                                    <asp:TextBox ID="tbxAssignmentDataRejectedDateTime" runat="server" ReadOnly="True"
                                                        SkinID="TextBoxSmallReadOnly" Style="width: 132px"></asp:TextBox>
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
                                                <td style="height: 7px;" colspan="5">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblAssignmentDataRejectedReason" runat="server" EnableViewState="False"
                                                        SkinID="Label" Text="Rejected Reason"></asp:Label>
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
                                                    <asp:TextBox ID="tbxAssignmentDataRejectedReason" runat="server" Rows="4" SkinID="TextBoxReadOnly"
                                                        Style="width: 700px" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>              
                                    </asp:Panel>
                                    
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
                        </cc1:TabPanel>                        
                        
                        
                        
                        <cc1:TabPanel ID="tpStartWorkData" runat="server" HeaderText="Start Work" OnClientClick="tpStartWorkDataClientClick" >
                            <ContentTemplate>
                                <div style="width: 710px">
                                
                                    <!-- Table element: 1 column  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 142px" visible="false">
                                       <tr>
                                            <td>
                                                <asp:Label ID="lblStartWorkDataStartWorkDateTime" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Start Work Date & Time" visible="false"></asp:Label>
                                                <asp:TextBox ID="tbxStartWorkDataWorkStartDateTime" runat="server" ReadOnly="True"
                                                    SkinID="TextBoxSmallReadOnly" Style="width: 132px" visible="false">
                                                </asp:TextBox>
                                            </td>                                                
                                        </tr>
                                    </table>
        
                                    <%--<!-- Page element : Horizontal Rule -->
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
                                    </table>--%>
        
                                    <!-- Table element: 3 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 284px">
                                        <tr>
                                            <td style="width: 142px; height: 10px;">
                                            </td>
                                            <td style="width: 110px">
                                            </td>
                                            <td style="width: 32px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblStartWorkDataUnitOutOfServiceDate" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Unit Out Of Service Date"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblStartWorkDataStartMileage" runat="server" EnableViewState="False" SkinID="Label" Text="Mileage"></asp:Label>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxStartWorkDataUnitOutOfServiceDate" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Width="132px" >
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxStartWorkDataStartMileage" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Width="100px">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblStartWorkDataMileageUnitOfMeasurement" runat="server" SkinID="Label" Width="32px">
                                                </asp:Label>
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
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpCompleteWorkData" runat="server" HeaderText="Complete Work" OnClientClick="tpCompleteWorkDataClientClick" >
                            <ContentTemplate>
                                <div style="width: 710px">
                                
                                    <!-- Table element: 5 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%" visible="false">
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
                                            <td>
                                                <asp:Label ID="lblCompleteWorkDataCompleteWorkDateTime" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Complete Work Date & Time" visible="false"></asp:Label>
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
                                                <asp:TextBox ID="tbxCompleteWorkDataCompleteWorkDateTime" runat="server" ReadOnly="True" SkinID="TextBoxSmallReadOnly" Style="width: 132px" visible="false"></asp:TextBox>
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
        
                                    <%--<!-- Page element : Horizontal Rule -->
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
                                    </table>--%>
        
                                    <!-- Table element: 3 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 284px">
                                        <tr>
                                            <td style="width: 142px; height: 10px;">
                                                <asp:Label ID="lblCompleteWorkDataUnitBackInServiceDate" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Unit Back In Service Date"></asp:Label>
                                            </td>
                                            <td style="width: 110px">
                                                <asp:Label ID="lblCompleteWorkDataCompleteMileage" runat="server" EnableViewState="False" SkinID="Label" Text="Mileage"></asp:Label>
                                            </td>
                                            <td style="width: 32px">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="tbxCompleteWorkDataUnitBackInServiceDate" runat="server"
                                                    ReadOnly="True" SkinID="TextBoxSmallReadOnly" Style="width: 132px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxCompleteWorkDataCompleteMileage" runat="server" 
                                                    ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 100px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblCompleteWorkDataMileageUnitOfMeasurement" runat="server" 
                                                    EnableViewState="False" SkinID="Label"></asp:Label>
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
                                    
                                    <!-- Page element : Service data from Team member assigned -->
                                    <asp:Panel ID="pnlTeamMemberAssigned" runat="server"  Width="100%">
                                        
                                        <!-- Page element : 1 column - secction title -->
                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                            <tr>
                                                <td>                                                    
                                                    <asp:Label ID="lblCompleteWorkDataWorkDetailsTitle" runat="server" EnableViewState="False" SkinID="LabelTitle2"
                                                        Text="Work Details"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 10px">
                                                </td>
                                            </tr>
                                        </table>    
                                        
                                        <!-- Page element : 1 column - work details -->
                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                            <tr>
                                                <td style="width: 142px;">                                                    
                                                    <asp:Label ID="lblCompleteWorkDataDescription" runat="server" EnableViewState="False" SkinID="Label"
                                                        Text="Description"></asp:Label></td>
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
                                                    <asp:TextBox ID="tbxCompleteWorkDataDescription" runat="server" ReadOnly="True"
                                                        Rows="4" SkinID="TextBoxReadOnly" Style="width: 700px" TextMode="MultiLine"></asp:TextBox></td>
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
                                                    <asp:Label ID="Label2" runat="server" EnableViewState="False" SkinID="Label" Text="Preventable"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblCompleteWorkDataLabourHours" runat="server" EnableViewState="False"
                                                        SkinID="Label" Text="Labour Hours"></asp:Label></td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><asp:CheckBox ID="ckbxCompleteWorkDataPreventable" runat="server" onclick="return cbxClick();" SkinID="CheckBox" /></td>
                                                <td>
                                                    <asp:TextBox ID="tbxCompleteWorkDataLabourHours" runat="server"
                                                        ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 132px"></asp:TextBox></td>
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
                                        
                                         <!-- Page element : 1 column - secction title -->
                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                            <tr>
                                                <td>                                                    
                                                    <asp:Label ID="lblCompleteWorkDataCostTitle" runat="server" EnableViewState="False" SkinID="LabelTitle2"
                                                        Text="Costs"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 10px">
                                                </td>
                                            </tr>
                                        </table>    
                                        
                                        <!-- Page element : 1 column - work details -->
                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                            <tr>
                                                <td>
                                                    <asp:UpdatePanel id="upnlCosts" runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="grdCosts" runat="server" SkinID="GridViewInTabs" Width="700px" __designer:wfdid="w49" OnRowCommand="grdCosts_RowCommand"
                                                                OnDataBound="grdCosts_DataBound" DataSourceID="odsCosts" PageSize="8" AutoGenerateColumns="False" OnRowDataBound="grdCosts_RowDataBound"
                                                                AllowPaging="True" DataKeyNames="ServiceID,RefID">
                                                                <Columns>
                                                                    <asp:TemplateField SortExpression="ServiceID" Visible="False" HeaderText="ServiceID">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblId" runat="server" Text='<%# Eval("ServiceID") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField SortExpression="RefID" Visible="False" HeaderText="RefID">
                                                                        <HeaderStyle Width="0px"></HeaderStyle>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblRefId" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField SortExpression="NoteID" Visible="False" HeaderText="NoteID">
                                                                        <EditItemTemplate>
                                                                            <asp:Label ID="lblNoteIDEdit" runat="server" Text='<%# Eval("NoteID") %>'></asp:Label>
                                                                        </EditItemTemplate>
                                                                        <ItemTemplate>
                                                                            <asp:Label ID="lblNoteID" runat="server" Text='<%# Eval("NoteID") %>'></asp:Label>
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
                                                                    <asp:TemplateField HeaderText="Part Number">
                                                                        <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                        <HeaderStyle Width="60px" HorizontalAlign="Center"></HeaderStyle>
                                                                        <ItemTemplate>
                                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPartNumber" runat="server" SkinID="Label" Text='<%# Eval("PartNumber") %>'
                                                                                            Width="60px"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Part Name">
                                                                        <HeaderStyle Width="130px"></HeaderStyle>
                                                                        <ItemTemplate>
                                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblPartName" runat="server" SkinID="Label" Text='<%# Eval("PartName") %>'></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Vendor">
                                                                        <HeaderStyle Width="100px"></HeaderStyle>
                                                                        <ItemTemplate>
                                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td>
                                                                                        <asp:Label ID="lblVendor" runat="server" SkinID="Label" Text='<%# Eval("Vendor") %>'></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Cost">
                                                                        <HeaderStyle Width="70px"></HeaderStyle>
                                                                        <ItemTemplate>
                                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                <tr>
                                                                                    <td style="text-align: right">
                                                                                        <asp:Label ID="lblCost" runat="server" SkinID="Label" Text='<%# String.Format("{0:N2}", Eval("Cost")) %>'></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField SortExpression="NoteAttachment" HeaderText="Note &amp; Attachment">
                                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                        <HeaderStyle Width="310px"></HeaderStyle>
                                                                        <ItemTemplate>
                                                                            <!-- Page element : 2 columns - Notes and attachment information -->
                                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td style="width: 10px; height: 10px">
                                                                                        </td>
                                                                                        <td style="width: 210px;">
                                                                                        </td>
                                                                                        <td style="width: 90px">
                                                                                        </td>
                                                                                    </tr>                                                                                    
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:TextBox ID="tbxNoteAttachment" runat="server" Rows="1" SkinID="TextBoxReadOnly"
                                                                                                ReadOnly="true" Text='<%# Eval("ORIGINAL_FILENAME") %>' Width="200px"></asp:TextBox>
                                                                                        </td>
                                                                                        <td>
                                                                                            <asp:Button ID="btnNoteDownload" CommandName="DownloadAttachment" CommandArgument='<%# Eval("NoteID") %>'
                                                                                                runat="server" SkinID="Button" Text="Download" Width="80px" />
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
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <HeaderStyle Width="50px"></HeaderStyle>
                                                                        <ItemTemplate>
                                                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                    </td>
                                                                                </tr>
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
                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                            <tr>                                               
                                                <td style="width: 275px">
                                                </td>
                                                <td style="width: 70px; text-align: right;">
                                                        <asp:TextBox ID="tbxTotalCost" runat="server" ReadOnly="True" SkinID="TextBoxRightReadOnly" 
                                                        Width="100%" TabIndex="-1"></asp:TextBox></td>
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
                                            </tr>
                                        </table>
                                          
                                    </asp:Panel>
                                    
                                    <!-- Page element : Service data from  Third Party Vendor -->
                                    <asp:Panel ID="pnlThirdPartyVendorAssigned" runat="server"  Width="100%">
                
                                        <!-- Page element : 1 column - secction title -->
                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                            <tr>
                                                <td>                                                    
                                                    <asp:Label ID="lblCompleteWorkDataWorkDetailsTitleThirdPartyVendor" runat="server" EnableViewState="False" SkinID="LabelTitle2"
                                                        Text="Work Details"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="height: 10px">
                                                </td>
                                            </tr>
                                        </table>    
                                        
                                        <!-- Page element : 1 column - work details -->
                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                            <tr>
                                                <td style="width: 142px;">                                                    
                                                    <asp:Label ID="lblCompleteWorkDataDescriptionThirdPartyVendor" runat="server" EnableViewState="False" SkinID="Label"
                                                        Text="Description"></asp:Label></td>
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
                                                    <asp:TextBox ID="tbxCompleteWorkDataDescriptionThirdPartyVendor" runat="server"
                                                        ReadOnly="True" Rows="4" SkinID="TextBoxReadOnly" Style="width: 700px" TextMode="MultiLine"></asp:TextBox></td>
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
                                                    <asp:Label ID="lblCompleteWorkDataPreventableThirdPartyVendor" runat="server" EnableViewState="False"
                                                        SkinID="Label" Text="Preventable"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblCompleteWorkDataInvoiceNumberThirdPartyVendor" runat="server" EnableViewState="False"
                                                        SkinID="Label" Text="Invoice Number"></asp:Label></td>
                                                <td>
                                                    <asp:Label ID="lblCompleteWorkDataInvoiceAmountThirdPartyVendor" runat="server" EnableViewState="False"
                                                        SkinID="Label" Text="Invoice Amount"></asp:Label></td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td><asp:CheckBox ID="ckbxCompleteWorkDataPreventableThirdPartyVendor" runat="server" onclick="return cbxClick();" SkinID="CheckBox" /></td>
                                                <td>
                                                    <asp:TextBox ID="tbxCompleteWorkDataInvoiceNumberThirdPartyVendor" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 132px"></asp:TextBox></td>
                                                <td>
                                                    <asp:TextBox ID="tbxCompleteWorkDataInvoiceAmountThirdPartyVendor" runat="server" ReadOnly="True"
                                                        SkinID="TextBoxReadOnly" Style="width: 132px"></asp:TextBox></td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>    
                                    </asp:Panel>    
                                    
                                    <!-- Page element : Footer separator -->                              
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
                        </cc1:TabPanel>
                        
                        
                        
                        <cc1:TabPanel ID="tpNotesData" runat="server" HeaderText="Notes &amp; Attachments" OnClientClick="tpNotesDataClientClick">
                            <ContentTemplate>
                                <div style="width: 710px; height: 730px; overflow-y: auto;">
                                
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
                                                <asp:GridView id="grdNotes" runat="server" SkinID="GridViewInTabs" Width="700px" 
                                                DataSourceID="odsNotes" DataKeyNames="ServiceID,RefID" AllowPaging="True" 
                                                AutoGenerateColumns="False"  OnRowDataBound="grdNotes_RowDataBound" OnRowCommand="grdNotes_RowCommand"
                                                PageSize="6" OnDataBound="grdNotes_DataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="ServiceID" SortExpression="ServiceID" Visible="False">
                                                        <EditItemTemplate>
                                                            <asp:Label id="lblServiceID" runat="server" Text='<%# Eval("ServiceID") %>'></asp:Label> 
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label id="lblServiceID" runat="server" Text='<%# Eval("ServiceID") %>'></asp:Label>                 
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    
                                                    
                                                    <asp:TemplateField HeaderText="RefID" SortExpression="RefID" Visible="False">
                                                        <EditItemTemplate>
                                                            <asp:Label id="lblRefID" runat="server" Text='<%# Eval("RefID") %>'></asp:Label> 
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label id="lblRefID" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>                 
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
                                                    
                                                    
                                                    
                                                    <asp:TemplateField HeaderText="Information" SortExpression="Subject">
                                                    
                                                        <ItemTemplate>
                                
                                                            <!-- Page element : 2 columns - Notes Information -->
                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                <tr>
                                                                    <td style="width: 10px; height: 10px"></td>
                                                                    <td style="width: 155px;">
                                                                    </td>
                                                                    <td style="width: 155px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td>
                                                                        <asp:Label ID="lblNoteSubject" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Subject"></asp:Label></td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td colspan="2">
                                                                        <asp:TextBox ID="tbxNoteSubject" runat="server" EnableViewState="True" ReadOnly="True" Text='<%# Eval("Subject") %>'
                                                                            SkinID="TextBoxReadOnly" Style="width: 300px"></asp:TextBox></td>
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
                                                                        <asp:Label ID="lblNoteDate" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Date"></asp:Label></td>
                                                                    <td>
                                                                        <asp:Label ID="lblNoteCreatedBy" runat="server" EnableViewState="False" SkinID="Label"
                                                                            Text="Created By"></asp:Label></td>
                                                                </tr>
                                                                <tr>
                                                                    <td></td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxNoteDate" runat="server" EnableViewState="True" ReadOnly="True"
                                                                            SkinID="TextBoxReadOnly" Style="width: 145px" Text='<%# Eval("DateTime_") %>'></asp:TextBox></td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxNoteCreatedBy" runat="server" EnableViewState="False" ReadOnly="True"
                                                                            SkinID="TextBoxReadOnly" Style="width: 145px" Text='<%# GetNoteCreatedBy(Eval("UserID")) %>'></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 10px">
                                                                    </td>
                                                                    <td></td>
                                                                    <td>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="320px"></HeaderStyle>
                                                    </asp:TemplateField>



                                                    <asp:TemplateField SortExpression="NoteAttachment" HeaderText="Note &amp; Attachment">
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <HeaderStyle Width="310px"></HeaderStyle>
                                                        <ItemTemplate>
                                                            <!-- Page element : 2 columns - Notes and attachment information -->
                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 10px; height: 10px">
                                                                        </td>
                                                                        <td style="width: 210px;">
                                                                        </td>
                                                                        <td style="width: 90px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblNoteNote" runat="server" SkinID="Label" Text="Note" EnableViewState="False"
                                                                                __designer:wfdid="w62"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:TextBox Style="width: 290px" ID="tbxNoteNote" runat="server" SkinID="TextBoxReadOnly"
                                                                                Text='<%# Eval("Note") %>' EnableViewState="True" ReadOnly="True" TextMode="MultiLine"
                                                                                Rows="4" __designer:wfdid="w63"></asp:TextBox>
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
                                                                            <asp:TextBox ID="tbxNoteAttachment" runat="server" Rows="1" SkinID="TextBoxReadOnly"
                                                                                ReadOnly="true" Text='<%# Eval("ORIGINAL_FILENAME") %>' Width="200px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnNoteDownload" CommandName="DownloadAttachment" CommandArgument='<%# Eval("RefID") %>'
                                                                                runat="server" SkinID="Button" Text="Download" Width="80px" />
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
                                                        <HeaderStyle Width="60px"></HeaderStyle>
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
                                Notes &amp; Attachments
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
                    <asp:ObjectDataSource ID="odsEmployee" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.Employees.EmployeeList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="employeeId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select a team member)" Name="fullName" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsCosts" runat="server" FilterExpression="(Deleted = 0)"
                        SelectMethod="GetCostsNew" TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Services.services_edit">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsNotes" runat="server" FilterExpression="(Deleted = 0)"
                        SelectMethod="GetNotesNew" TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Services.services_edit">
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
                
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfFmType" runat="server" />
                    <asp:HiddenField ID="hdfActiveTab" runat="server" />
                    <asp:HiddenField ID="hdfServiceId" runat="server" />
                    <asp:HiddenField ID="hdfServiceState" runat="server" />
                    <asp:HiddenField ID="hdfLoginId" runat="server" />
                    <asp:HiddenField ID="hdfDashboard" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>