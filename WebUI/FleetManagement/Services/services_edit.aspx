<%@ Page Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" CodeBehind="services_edit.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.Services.services_edit" Title="LFS Live" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
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
                            <telerik:RadMenuItem Value="mSave" Text="SAVE" ToolTip="save and close" />
                            
                            <telerik:RadMenuItem Value="mApply" Text="APPLY" ToolTip="save and continue" />
                            
                            <telerik:RadMenuItem Value="mCancel" Text="CANCEL" ToolTip="close without saving" />
                        </Items>
                    </telerik:RadMenu>
                    <asp:Label ID="lblMissingData" runat="server" SkinID="LabelError" Text=""></asp:Label>
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
                    <asp:Label ID="lblBasicInformation" runat="server" SkinID="LabelTitle1" Text="Basic Information" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
            </tr>
        </table>
        
        <!-- Table element: 5 columns - Section Details -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 150px">
                    <asp:Label ID="lblServiceNumber" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Service Number"></asp:Label>
                </td>
                <td style="width: 150px">
                    <asp:Label ID="lblDateTime" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Date & Time"></asp:Label>
                </td>
                <td style="width: 150px">
                    <asp:Label ID="lblChecklistNextDueDate" runat="server" EnableViewState="False" SkinID="Label" Text="Checklist Next Due Date"></asp:Label>
                </td>
                <td style="width: 150px">
                    <asp:Label ID="LabelMtoDto" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Fixed Date"></asp:Label>
                </td>
                
                <td style="width: 150px">
                    <asp:Label ID="lblServiceState" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Service State"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxServiceNumber" runat="server" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 140px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxDateTime" runat="server" ReadOnly="True"
                        SkinID="TextBoxSmallReadOnly" Style="width: 140px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxChecklistNextDueDate" runat="server" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Style="width: 140px"></asp:TextBox>
                </td>
                <td>
                    <asp:CheckBox ID="ckbxMtoDto" runat="server" SkinID="CheckBox" />
                </td>
                <td>
                    <asp:TextBox ID="tbxServiceState" runat="server" ReadOnly="True" SkinID="TextBoxSpecialWhite"
                        Style="width: 140px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="height: 7px" colspan="5">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblDescription" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Description"></asp:Label>
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
                    <asp:TextBox ID="tbxServiceDescription" runat="server" SkinID="TextBox"
                        Style="width: 740px" Rows="4" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="5">
                    <asp:RequiredFieldValidator ID="rfvServiceDescription" runat="server" ControlToValidate="tbxServiceDescription"
                        Display="Dynamic" EnableViewState="False" ErrorMessage="Please provide a description."
                        SkinID="Validator" ValidationGroup="serviceData"></asp:RequiredFieldValidator>
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
        
        <!-- Table element: 5 columns - Section Details 2 -->
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="width: 150px">
                    <asp:Label ID="lblUnitCode" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Unit Code"></asp:Label>
                </td>
                <td style="width: 150px">
                    <asp:Label ID="lblUnitDescription" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Unit Description"></asp:Label>
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
                    <asp:TextBox ID="tbxUnitCode" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly"
                        Style="width: 140px"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="tbxUnitDescription" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly"
                        Style="width: 290px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxVinSn" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly"
                        Style="width: 140px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxUnitState" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly"
                        Style="width: 140px"></asp:TextBox>
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
                    <asp:Label ID="lblAssociatedChecklistRule" runat="server" EnableViewState="False" SkinID="Label" Text="Associated Checklist Rule"></asp:Label>
                </td>
                <td style="width: 150px">
                    <asp:Label ID="lblChecklistState" runat="server" SkinID="LabelSmall" Text="Associated Checklist State"></asp:Label>
                </td>
                <td style="width: 150px">
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:TextBox ID="tbxAssociatedChecklistRule" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 440px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxChecklistState" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 140px" EnableTheming="True"></asp:TextBox>
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
                    <asp:Label ID="lblDetailedInformation" runat="server" SkinID="LabelTitle1" Text="Detailed Information" EnableViewState="False"></asp:Label>
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
                    <cc1:TabContainer ID="tcDetailedInformation" Width="730px" runat="server" ActiveTabIndex="2"
                        CssClass="ajax_tabcontainer" Height="640px">
                        <cc1:TabPanel ID="tpGeneralData" runat="server" HeaderText="General" OnClientClick="tpGeneralDataClientClick">
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
                                                <asp:TextBox ID="tbxGeneralCreatedBy" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly"
                                                    Style="width: 274px"></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="tbxGeneralMileage" runat="server" SkinID="TextBox" Style="width: 100px"></asp:TextBox>                                                
                                            </td>
                                            <td>
                                                <asp:Label ID="lblGeneralMileageUnitOfMeasurement" runat="server" SkinID="Label"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvGeneralDataMileage" runat="server" ControlToValidate="tbxGeneralMileage"
                                                    Display="Dynamic" ErrorMessage="Please provide a mileage." SkinID="Validator"
                                                    ValidationGroup="serviceData" ValidateEmptyText="True" OnServerValidate="cvGeneralDataMileage_ServerValidate"></asp:CustomValidator>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="tpAssignmentData" runat="server" HeaderText="Assignment" OnClientClick="tpAssignmentDataClientClick">
                            <ContentTemplate>
                                <asp:Panel ID="pnlAssignmentData" runat="server" Style="width: 710px">
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
                                                    <asp:Label ID="lblAssignmentDataAssignmentDateTime" runat="server" EnableViewState="False"
                                                        SkinID="LabelSmall" Text="Assignment Date & Time" Visible="false"></asp:Label>
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
                                                    <telerik:RadDatePicker ID="tkrdpAssignmentDataAssignedDeadlineDate" runat="server"
                                                        Width="132px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                    </telerik:RadDatePicker>
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
                                        <!-- Page element : Assignment Data -->
                                        <asp:Panel ID="pnlAssignedTo" runat="server" Width="100%">
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td colspan="2" style="width: 274px">
                                                        <asp:RadioButton ID="rbtnAssignmentDataToTeamMember" runat="server" GroupName="Begin"
                                                            SkinID="RadioButton" Text="To Team Member" />
                                                    </td>
                                                    <td colspan="2" style="width: 274px">
                                                        <asp:RadioButton ID="rbtnAssignmentDataToThirdPartyVendor" runat="server" GroupName="Begin"
                                                            SkinID="RadioButton" Text="To Third Party Vendor" />
                                                    </td>
                                                    <td style="width: 142px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:DropDownList ID="ddlAssignmentDataAssignToTeamMember" runat="server" DataMember="DefaultView"
                                                            DataSourceID="odsEmployee" DataTextField="FullName" DataValueField="EmployeeID"
                                                            SkinID="DropDownList" Style="width: 274px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="tbxAssignmentDataAssignToThirdPartyVendor" runat="server" SkinID="TextBox"
                                                            Style="width: 274px"></asp:TextBox>
                                                        <cc1:AutoCompleteExtender ID="aceThirdPartyVendor" runat="server" CompletionSetCount="12"
                                                            MinimumPrefixLength="2" ServiceMethod="GetThirdPartyVendorList" ServicePath="servicesThirdPartyVendor.asmx"
                                                            SkinID="AutoCompleteExtender" TargetControlID="tbxAssignmentDataAssignToThirdPartyVendor"
                                                            UseContextKey="True" DelimiterCharacters="" Enabled="True">
                                                        </cc1:AutoCompleteExtender>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:CustomValidator ID="cvTeamMember" runat="server" ControlToValidate="ddlAssignmentDataAssignToTeamMember"
                                                            Display="Dynamic" ErrorMessage="Please select a team member." OnServerValidate="cvTeamMember_ServerValidate"
                                                            SkinID="Validator" ValidationGroup="assignmentInformation"></asp:CustomValidator>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:CustomValidator ID="cvThirdPartyVendor" runat="server" ControlToValidate="tbxAssignmentDataAssignToThirdPartyVendor"
                                                            Display="Dynamic" ErrorMessage="Please provide a third party vendor." OnServerValidate="cvThridPartyVendor_ServerValidate"
                                                            SkinID="Validator" ValidationGroup="assignmentInformation"></asp:CustomValidator>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <!-- Page element : Assignment data (read only) -->
                                        <asp:Panel ID="pnlAssignedToReadOnly" runat="server" Width="100%">
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td colspan="2" style="height: 20px">
                                                        <asp:RadioButton ID="rbtnAssignmentDataToTeamMemberReadOnly" runat="server" GroupName="Begin"
                                                            SkinID="RadioButton" Text="To Team Member" onclick="return rbtnClick();" Enabled="False" />
                                                    </td>
                                                    <td colspan="2" style="height: 20px">
                                                        <asp:RadioButton ID="rbtnAssignmentDataToThirdPartyVendorReadOnly" runat="server"
                                                            GroupName="Begin" SkinID="RadioButton" Text="To Third Party Vendor" onclick="return rbtnClick();"
                                                            Enabled="False" />
                                                    </td>
                                                    <td style="width: 142px; height: 20px;">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="tbxAssignmentDataAssignToTeamMemberReadOnly" runat="server" SkinID="TextBoxReadOnly"
                                                            Style="width: 274px" ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                    <td colspan="2">
                                                        <asp:TextBox ID="tbxAssignmentDataAssignToThirdPartyVendorReadOnly" runat="server"
                                                            SkinID="TextBoxReadOnly" Style="width: 274px" ReadOnly="True"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        <!-- Page element : Assignment Accept -->
                                        <asp:Panel ID="pnlAssignmentAccept" runat="server" Width="100%">
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
                                                        <asp:Label ID="lblAssignmentDataAcceptedDateTime" runat="server" EnableViewState="False"
                                                            SkinID="LabelSmall" Text="Accepted Date & Time"></asp:Label>
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
                                                            SkinID="TextBoxReadOnly" Style="width: 132px"></asp:TextBox>
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
                                        <!-- Page element : Assignment Reject -->
                                        <asp:Panel ID="pnlAssignmentReject" runat="server" Width="100%">
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
                                                        <asp:Label ID="lblAssignmentDataRejectedDateTime" runat="server" EnableViewState="False"
                                                            SkinID="LabelSmall" Text="Rejected Date & Time"></asp:Label>
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
                                                            SkinID="TextBoxReadOnly" Style="width: 132px"></asp:TextBox>
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
                                                    <td style="height: 7px;">
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
                                                        <asp:TextBox ID="tbxAssignmentDataRejectedReason" runat="server" Rows="4" SkinID="TextBox"
                                                            Style="width: 700px" TextMode="MultiLine"></asp:TextBox>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
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
                                </asp:Panel>
                                <asp:Panel ID="pnlAssignmentDataReadOnly" runat="server" Style="width: 710px">
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
                                                    <asp:Label ID="lblAssignmentDataAssignedDeadlineDateReadOnly" runat="server" EnableViewState="False"
                                                        SkinID="LabelSmall" Text="Assigned Deadline Date"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblAssignmentDataAssignmentDateTimeReadOnly" runat="server" EnableViewState="False"
                                                        SkinID="LabelSmall" Text="Assignment Date & Time" Visible="false"></asp:Label>
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
                                                    <asp:TextBox ID="tbxAssignmentDataAssignedDeadlineDateReadOnly" runat="server" ReadOnly="True"
                                                        SkinID="TextBoxReadOnly" Style="width: 132px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxAssignmentDataAssignmentDateTimeReadOnly" runat="server" ReadOnly="True"
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
                                                    <asp:RadioButton ID="rbtnAssignmentDataReadOnlyToTeamMemberReadOnly" runat="server"
                                                        GroupName="Begin" SkinID="RadioButton" Text="To Team Member" onclick="return rbtnClick();"
                                                        Enabled="False" />
                                                </td>
                                                <td colspan="2">
                                                    <asp:RadioButton ID="rbtnAssignmentDataReadOnlyToThirdPartyVendorReadOnly" runat="server"
                                                        GroupName="Begin" SkinID="RadioButton" Text="To Third Party Vendor" onclick="return rbtnClick();"
                                                        Enabled="False" />
                                                </td>
                                                <td style="width: 142px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <asp:TextBox ID="tbxAssignmentDataReadOnlyAssignToTeamMemberReadOnly" runat="server"
                                                        ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 274px"></asp:TextBox>
                                                </td>
                                                <td colspan="2">
                                                    <asp:TextBox ID="tbxAssignmentDataReadOnlyAssignToThirdPartyVendorReadOnly" runat="server"
                                                        SkinID="TextBoxReadOnly" ReadOnly="True" Style="width: 274px"></asp:TextBox>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                        <asp:Panel ID="pnlAssignmentAcceptReadOnly" runat="server" Width="100%">
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
                                                        <asp:Label ID="lblAssignmentDataAcceptedDateTimeReadOnly" runat="server" EnableViewState="False"
                                                            SkinID="LabelSmall" Text="Accepted Date & Time"></asp:Label>
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
                                                        <asp:TextBox ID="tbxAssignmentDataAcceptedDateTimeReadOnly" runat="server" ReadOnly="True"
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
                                        <asp:Panel ID="pnlAssignmentRejectReadOnly" runat="server" Width="100%">
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
                                                        <asp:Label ID="lblAssignmentDataRejectedDateTimeReadOnly" runat="server" EnableViewState="False"
                                                            SkinID="LabelSmall" Text="Rejected Date & Time"></asp:Label>
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
                                                        <asp:TextBox ID="tbxAssignmentDataRejectedDateTimeReadOnly" runat="server" ReadOnly="True"
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
                                                    <td style="height: 7px;">
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
                                                        <asp:Label ID="lblAssignmentDataRejectedReasonReadOnly" runat="server" EnableViewState="False"
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
                                                        <asp:TextBox ID="tbxAssignmentDataRejectedReasonReadOnly" runat="server" Rows="4"
                                                            SkinID="TextBoxReadOnly" Style="width: 700px" TextMode="MultiLine" ReadOnly="True"></asp:TextBox>
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
                                </asp:Panel>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="tpStartWorkData" runat="server" HeaderText="Start Work" OnClientClick="tpStartWorkDataClientClick">
                            <ContentTemplate>
                                <asp:Panel ID="pnlStartWorkData" runat="server" Style="width: 710px">
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
                                                    <asp:Label ID="lblStartWorkDataStartWorkDateTime" runat="server" EnableViewState="False"
                                                        SkinID="LabelSmall" Text="Start Work Date & Time" visible="false"></asp:Label>
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
                                                    <asp:TextBox ID="tbxStartWorkDataWorkStartDateTime" runat="server" ReadOnly="True"
                                                        SkinID="TextBoxSmallReadOnly" Style="width: 132px" visible="false"></asp:TextBox>
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
                                        
                                        <!-- Table element: 3 columns  -->
                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 284px">
                                            <tr>
                                                <td style="width: 142px; height: 10px">
                                                    <asp:Label ID="lblStartWorkDataUnitOutOfServiceDate" runat="server" EnableViewState="False"
                                                        SkinID="LabelSmall" Text="Unit Out Of Service Date"></asp:Label>
                                                </td>
                                                <td style="width: 110px">
                                                    <asp:Label ID="lblStartWorkDataStartMileage" runat="server" EnableViewState="False"
                                                        SkinID="Label" Text="Mileage"></asp:Label>
                                                </td>
                                                <td style="width: 32px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <telerik:RadDatePicker ID="tkrdpStartWorkDataUnitOutOfServiceDate" runat="server"
                                                        Width="140px" SkinID="RadDatePicker">
                                                        <Calendar DayNameFormat="Short" ShowRowHeaders="False" UseColumnHeadersAsSelectors="False"
                                                            UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput LabelCssClass="" Width="">
                                                        </DateInput>
                                                        <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxStartWorkDataStartMileage" runat="server" SkinID="TextBox" Style="width: 100px"></asp:TextBox>                                                    
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblStartWorkDataMileageUnitOfMeasurement" runat="server" SkinID="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CustomValidator ID="cvOutOfServiceDate" runat="server" ControlToValidate="tbxStartWorkDataStartMileage"
                                                        Display="Dynamic" ErrorMessage="Please select a date." OnServerValidate="cvOutOfServiceDate_ServerValidate"
                                                        SkinID="Validator" ValidateEmptyText="True" ValidationGroup="serviceData"></asp:CustomValidator>
                                                </td>
                                                <td>
                                                    <asp:CustomValidator ID="cvStartWorkDataMileage" runat="server" ControlToValidate="tbxStartWorkDataStartMileage"
                                                        Display="Dynamic" ErrorMessage="Please provide a mileage" OnServerValidate="cvStartWorkDataMileage_ServerValidate"
                                                        SkinID="Validator" ValidateEmptyText="True" ValidationGroup="serviceData"></asp:CustomValidator>
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
                                            </tr>
                                        </table>
                                    </div>
                                </asp:Panel>
                                <asp:Panel ID="pnlStartWorkDataReadOnly" runat="server" Style="width: 710px">
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
                                                    <asp:Label ID="lblStartWorkDataUnitOutOfServiceDateReadOnly" runat="server" EnableViewState="False"
                                                        SkinID="LabelSmall" Text="Start Work Date & Time" visible="false"></asp:Label>
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
                                                    <asp:TextBox ID="tbxStartWorkDataStartWorkDateTimeReadOnly" runat="server" ReadOnly="True"
                                                        SkinID="TextBoxSmallReadOnly" Style="width: 132px" visible="false"></asp:TextBox>
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
                                                    <asp:Label ID="lblStarWorkDataUnitOutOfServiceDateReadOnly" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Unit Out Of Service Date"></asp:Label>
                                                </td>
                                                <td style="width: 110px">
                                                    <asp:Label ID="lblStartWorkDataMileageReadOnly" runat="server" EnableViewState="False" SkinID="Label" Text="Mileage"></asp:Label>
                                                </td>
                                                <td style="width: 32px">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="tbxStartWorkDataUnitOutOfServiceDateReadOnly" runat="server" ReadOnly="True" SkinID="TextBoxSmallReadOnly" Style="width: 132px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxStartWorkDataStartMileageReadOnly" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 100px"></asp:TextBox>                                                    
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblStartWorkDataMileageUnitOfMeasurementReadOnly" runat="server" SkinID="Label"></asp:Label>
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
                                </asp:Panel>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="tpCompleteWorkData" runat="server" HeaderText="Complete Work" OnClientClick="tpCompleteWorkDataClientClick">
                            <ContentTemplate>
                                <asp:Panel ID="pnlCompleteWorkData" runat="server" Style="width: 710px">
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
                                                    <asp:Label ID="lblCompleteWorkDataCompleteWorkDateTime" runat="server" EnableViewState="False"
                                                        SkinID="Label" Text="Complete Work Date & Time" visible="false"></asp:Label>
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
                                                    <asp:TextBox ID="tbxCompleteWorkDataCompleteWorkDateTime" runat="server" ReadOnly="True"
                                                        SkinID="TextBoxSmallReadOnly" Style="width: 132px" visible="false"></asp:TextBox>
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
                                                    <telerik:RadDatePicker ID="tkrdpCompleteWorkDataUnitBackInServiceDate" runat="server"
                                                        Width="132px" SkinID="RadDatePicker">
                                                        <Calendar DayNameFormat="Short" ShowRowHeaders="False" UseColumnHeadersAsSelectors="False"
                                                            UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                        </Calendar>
                                                        <DateInput LabelCssClass="" Width="">
                                                        </DateInput>
                                                        <DatePopupButton CssClass="" HoverImageUrl="" ImageUrl="" />
                                                    </telerik:RadDatePicker>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxCompleteWorkDataCompleteMileage" runat="server" SkinID="TextBox" Style="width: 100px"></asp:TextBox>                                                    
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCompleteWorkDataMileageUnitOfMeasurement" runat="server" SkinID="Label"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:CustomValidator ID="cvBackInServiceDate" runat="server" ControlToValidate="tkrdpCompleteWorkDataUnitBackInServiceDate"
                                                        Display="Dynamic" ErrorMessage="Please select a date." OnServerValidate="cvBackInServiceDate_ServerValidate"
                                                        SkinID="Validator" ValidateEmptyText="True" ValidationGroup="serviceData"></asp:CustomValidator>
                                                </td>
                                                <td>
                                                    <asp:CustomValidator ID="cvCompleteWorkDataMileage" runat="server" ControlToValidate="tbxCompleteWorkDataCompleteMileage"
                                                        Display="Dynamic" ErrorMessage="Please provide a mileage." OnServerValidate="cvCompleteWorkDataMileage_ServerValidate"
                                                        SkinID="Validator" ValidateEmptyText="True" ValidationGroup="serviceData"></asp:CustomValidator>
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
                                        <!-- Page element : Service data from Team member assigned -->
                                        <asp:Panel ID="pnlTeamMemberAssigned" runat="server" Width="100%">
                                            <!-- Page element : 1 column - secction title -->
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblCompleteWorkDataWorkDetailsTitle" runat="server" EnableViewState="False"
                                                            SkinID="LabelTitle2" Text="Work Details"></asp:Label>
                                                    </td>
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
                                                        <asp:Label ID="lblCompleteWorkDataDescription" runat="server" EnableViewState="False"
                                                            SkinID="Label" Text="Description"></asp:Label>
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
                                                        <asp:TextBox ID="tbxCompleteWorkDataDescription" runat="server" Rows="4" SkinID="TextBox"
                                                            Style="width: 700px" TextMode="MultiLine"></asp:TextBox>
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
                                                        <asp:Label ID="lblCompleteWorkDataPreventable" runat="server" EnableViewState="False"
                                                            SkinID="Label" Text="Preventable"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblCompleteWorkDataLabourHours" runat="server" EnableViewState="False"
                                                            SkinID="Label" Text="Labour Hours"></asp:Label>
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
                                                        <asp:CheckBox ID="ckbxCompleteWorkDataPreventable" runat="server" SkinID="CheckBox" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="tbxCompleteWorkDataLabourHours" runat="server" SkinID="TextBox"
                                                            Style="width: 132px"></asp:TextBox>
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
                                                        <asp:CompareValidator ID="cvCompleteWorkDataLabourHours" runat="server" ControlToValidate="tbxCompleteWorkDataLabourHours"
                                                            Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                            Operator="DataTypeCheck" SkinID="Validator" Type="Currency" ValidationGroup="serviceData"></asp:CompareValidator>
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
                                            <!-- Page element : 1 column - secction title -->
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblCompleteWorkDataCostTitle" runat="server" EnableViewState="False"
                                                            SkinID="LabelTitle2" Text="Costs"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 10px">
                                                    </td>
                                                </tr>
                                            </table>
                                            <!-- Page element : 1 column - work details -->
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td colspan="5">
                                                        <asp:UpdatePanel ID="upnlCosts" runat="server">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="grdCosts" runat="server" SkinID="GridViewInTabs" Width="700px"
                                                                    DataSourceID="odsCosts" PageSize="8" ShowFooter="True"
                                                                    AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="ServiceID,RefID" OnRowDataBound="grdCosts_RowDataBound"
                                                                    OnDataBound="grdCosts_DataBound" OnRowCommand="grdCosts_RowCommand" OnRowDeleting="grdCosts_RowDeleting"
                                                                    OnRowUpdating="grdCosts_RowUpdating" OnRowEditing="grdCosts_RowEditing">
                                                                    <Columns>
                                                                        <asp:TemplateField SortExpression="ServiceID" Visible="False" HeaderText="ServiceID">
                                                                            <EditItemTemplate>
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tr>
                                                                                        <td style="height: 12px">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblId" runat="server" Text='<%# Eval("ServiceID") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </EditItemTemplate>
                                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblId" runat="server" Text='<%# Eval("ServiceID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        
                                                                        <asp:TemplateField SortExpression="RefID" Visible="False" HeaderText="RefID">
                                                                            <EditItemTemplate>
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tr>
                                                                                        <td style="height: 12px">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblRefId" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </EditItemTemplate>
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
                                                                            <EditItemTemplate>
                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                    <tr>
                                                                                        <td style="height: 12px">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:TextBox ID="tbxPartNumber" runat="server" EnableViewState="False" SkinID="TextBox"
                                                                                                Text='<%# Eval("PartNumber") %>' Style="width: 60px"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tr>
                                                                                        <td style="height: 12px">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:TextBox ID="tbxPartNumberNew" runat="server" EnableViewState="False" SkinID="TextBox"
                                                                                                Style="width: 60px"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="height: 12px">
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </FooterTemplate>
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
                                                                            <EditItemTemplate>
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tr>
                                                                                        <td style="height: 12px">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:TextBox ID="tbxPartName" runat="server" EnableViewState="False" SkinID="TextBox"
                                                                                                Text='<%# Eval("PartName") %>' Style="width: 130px"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="rfvDescriptionNew" runat="server" ControlToValidate="tbxPartName"
                                                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Please provide a part name."
                                                                                                SkinID="Validator" ValidationGroup="costsDataEdit"></asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tr>
                                                                                        <td style="height: 12px">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:TextBox ID="tbxPartNameNew" runat="server" EnableViewState="False" SkinID="TextBox"
                                                                                                Style="width: 130px"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="tbxPartNameNew"
                                                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Please provide a part name."
                                                                                                SkinID="Validator" ValidationGroup="costsDataAdd"></asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="height: 12px">
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </FooterTemplate>
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
                                                                            <EditItemTemplate>
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tr>
                                                                                        <td style="height: 12px">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:TextBox ID="tbxVendor" runat="server" EnableViewState="False" SkinID="TextBox"
                                                                                                Text='<%# Eval("Vendor") %>' Style="width: 100px"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tr>
                                                                                        <td style="height: 12px">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:TextBox ID="tbxVendorNew" runat="server" EnableViewState="False" SkinID="TextBox"
                                                                                                Style="width: 100px"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="height: 12px">
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </FooterTemplate>
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
                                                                            <EditItemTemplate>
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tr>
                                                                                        <td style="height: 12px">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="text-align: right">
                                                                                            <asp:TextBox ID="tbxCost" runat="server" SkinID="TextBoxRight" Text='<%# String.Format("{0:N2}", Eval("Cost")) %>'
                                                                                                Width="70px"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="text-align: right">
                                                                                            <asp:CompareValidator ID="cvCost" runat="server" ControlToValidate="tbxCost" Display="Dynamic"
                                                                                                EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck"
                                                                                                SkinID="Validator" Type="Currency" ValidationGroup="costsDataEdit"></asp:CompareValidator>
                                                                                            <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="tbxCost"
                                                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Please provide a cost."
                                                                                                SkinID="Validator" ValidationGroup="costsDataEdit"></asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tr>
                                                                                        <td style="height: 12px">
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="text-align: right">
                                                                                            <asp:TextBox ID="tbxCostNew" runat="server" SkinID="TextBoxRight" Width="70px"></asp:TextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="text-align: right">
                                                                                            <asp:CompareValidator ID="cvCostNew" runat="server" ControlToValidate="tbxCostNew"
                                                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                Operator="DataTypeCheck" SkinID="Validator" Type="Currency" ValidationGroup="costsDataAdd"></asp:CompareValidator>
                                                                                            <asp:RequiredFieldValidator ID="rfvDescriptionNew" runat="server" ControlToValidate="tbxCostNew"
                                                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Please provide a cost."
                                                                                                SkinID="Validator" ValidationGroup="costsDataAdd"></asp:RequiredFieldValidator>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="height: 12px">
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </FooterTemplate>
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
                                                                            <EditItemTemplate>
                                                                                <!-- Page element : 2 columns - Notes and attachment information -->
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 10px; height: 12px">
                                                                                            </td>
                                                                                            <td style="width: 210px">
                                                                                            </td>
                                                                                            <td style="width: 90px">
                                                                                            </td>
                                                                                        </tr>
                                                                                       <tr>
                                                                                            <td>
                                                                                            </td>
                                                                                            <td style="vertical-align: top;">
                                                                                                <asp:TextBox ID="tbxNoteAttachmentEdit" runat="server" Rows="1" SkinID="TextBoxReadOnly"
                                                                                                   Text='<%# Eval("ORIGINAL_FILENAME") %>' Width="200px" ReadOnly="True"></asp:TextBox>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Button ID="btnNoteDeleteEdit" CommandName="DeleteAttachmentEdit" CommandArgument='<%# Eval("NoteID") %>'
                                                                                                    Width="80px" runat="server" SkinID="Button" Text="Delete" />
                                                                                                <asp:Button ID="btnNoteAddEdit" CommandName="AddAttachmentEdit" CommandArgument='<%# Eval("NoteID") %>'
                                                                                                    Width="80px" runat="server" SkinID="Button" Text="Add" />
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
                                                                            </EditItemTemplate>
                                                                            <FooterTemplate>
                                                                                <!-- Page element : 2 columns - Notes and attachment information -->
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 10px; height: 12px">
                                                                                            </td>
                                                                                            <td style="width: 210px">
                                                                                            </td>
                                                                                            <td style="width: 90px">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxNoteAttachmentNew" runat="server" Rows="1" SkinID="TextBoxReadOnly"
                                                                                                    Text='<%# Eval("ORIGINAL_FILENAME") %>' Width="200px" ReadOnly="True"></asp:TextBox>
                                                                                                <asp:Label ID="lblFileNameNoteAttachmentNew" runat="server" SkinID="Label" Text='<%# Eval("FILENAME") %>'
                                                                                                    Visible="False" />
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:Button ID="btnAddFooter" Width="80px" runat="server" SkinID="Button" Text="Add"
                                                                                                    TabIndex="4" CommandName="AddAttachmentAdd" CommandArgument='<%# Eval("NoteID") %>' />
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
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                            <HeaderStyle Width="310px"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <!-- Page element : 2 columns - Notes and attachment information -->
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 10px; height: 12px">
                                                                                            </td>
                                                                                            <td style="width: 210px">
                                                                                            </td>
                                                                                            <td style="width: 90px">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td>
                                                                                            </td>
                                                                                            <td>
                                                                                                <asp:TextBox ID="tbxNoteAttachment" runat="server" Rows="1" SkinID="TextBoxReadOnly"
                                                                                                    Text='<%# Eval("ORIGINAL_FILENAME") %>' Width="200px" ReadOnly="True"></asp:TextBox>
                                                                                            </td>
                                                                                            <td style="vertical-align: top">
                                                                                                <asp:Button ID="btnNoteDownload" CommandName="DownloadAttachment" CommandArgument='<%# Eval("NoteID") %>'
                                                                                                    Width="80px" runat="server" SkinID="Button" Text="Download" />
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
                                                                            <EditItemTemplate>
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="height: 12px">
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="width: 50%">
                                                                                                <asp:ImageButton ID="ibtnAccept" runat="server" CommandName="Update"
                                                                                                    SkinID="GridView_Update" ToolTip="Update"></asp:ImageButton>
                                                                                            </td>
                                                                                            <td style="width: 50%">
                                                                                                <asp:ImageButton ID="ibtnCancel" runat="server" CommandName="Cancel"
                                                                                                    SkinID="GridView_Cancel" ToolTip="Cancel"></asp:ImageButton>
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
                                                                                            <td>
                                                                                                <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" 
                                                                                                    CommandName="Add" ToolTip="Add"></asp:ImageButton>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td style="height: 12px">
                                                                                            </td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </FooterTemplate>
                                                                            <HeaderStyle Width="50px"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td style="width: 50%">
                                                                                                <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit"
                                                                                                    CommandName="Edit" ToolTip="Edit"></asp:ImageButton>
                                                                                            </td>
                                                                                            <td style="width: 50%">
                                                                                                <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" 
                                                                                                    CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this part?");'
                                                                                                    ToolTip="Delete"></asp:ImageButton>
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
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td style="width: 300px;">
                                                    </td>
                                                    <td style="width: 75px; text-align: right;">
                                                        <asp:UpdatePanel ID="upnlTotalCost" runat="server">
                                                            <ContentTemplate>
                                                                <asp:TextBox ID="tbxTotalCost" TabIndex="-1" runat="server" SkinID="TextBoxRightReadOnly"
                                                                    Width="100%" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter" ></asp:TextBox>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
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
                                        <asp:Panel ID="pnlThirdPartyVendorAssigned" runat="server" Width="100%">
                                            <!-- Page element : 1 column - secction title -->
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblCompleteWorkDataWorkDetailsTitleThirdPartyVendor" runat="server"
                                                            EnableViewState="False" SkinID="LabelTitle2" Text="Work Details"></asp:Label>
                                                    </td>
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
                                                        <asp:Label ID="lblCompleteWorkDataDescriptionThirdPartyVendor" runat="server" EnableViewState="False"
                                                            SkinID="Label" Text="Description"></asp:Label>
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
                                                        <asp:TextBox ID="tbxCompleteWorkDataDescriptionThirdPartyVendor" runat="server" EnableViewState="False"
                                                            Rows="4" SkinID="TextBox" Style="width: 700px" TextMode="MultiLine"></asp:TextBox>
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
                                                        <asp:Label ID="lblCompleteWorkDataPreventableThirdPartyVendor" runat="server" EnableViewState="False"
                                                            SkinID="Label" Text="Preventable"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblCompleteWorkDataInvoiceNumberThirdPartyVendor" runat="server" EnableViewState="False"
                                                            SkinID="Label" Text="Invoice Number"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblCompleteWorkDataInvoiceAmountThirdPartyVendor" runat="server" EnableViewState="False"
                                                            SkinID="Label" Text="Invoice Amount"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="ckbxCompleteWorkDataPreventableThirdPartyVendor" runat="server"
                                                            SkinID="CheckBox" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="tbxCompleteWorkDataInvoiceNumberThirdPartyVendor" runat="server"
                                                            SkinID="TextBox" Style="width: 132px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="tbxCompleteWorkDataInvoiceAmountThirdPartyVendor" runat="server"
                                                            SkinID="TextBox" Style="width: 132px"></asp:TextBox>
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
                                                        <asp:CompareValidator ID="cvCompleteWorkDataInvoiceAmount" runat="server" ControlToValidate="tbxCompleteWorkDataLabourHours"
                                                            Display="Dynamic" EnableViewState="False" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                            Operator="DataTypeCheck" SkinID="Validator" Type="Currency" ValidationGroup="serviceData"></asp:CompareValidator>
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
                                                        <asp:Label ID="Label1" runat="server" EnableViewState="False" SkinID="LabelTitle2"
                                                            Text="Note &amp; Attachment"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 10px">
                                                    </td>
                                                </tr>
                                            </table>
                                            
                                            <table style="width: 310px" cellspacing="0" cellpadding="0" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 220px">
                                                        </td>
                                                        <td style="width: 90px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                                                                                        <asp:Label ID="lblNoteNoteNew" runat="server" SkinID="Label" Text="Subject" EnableViewState="False"
                                                                ></asp:Label>

                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:TextBox Style="width: 300px" ID="tbxNoteNoteNew" runat="server" SkinID="TextBox"
                                                                EnableViewState="True" Rows="1" ></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RequiredFieldValidator ID="rfvNoteNoteNew" runat="server" SkinID="Validator"
                                                                EnableViewState="False" ErrorMessage="Please provide a note." ValidationGroup="serviceNoteData"
                                                                Display="Dynamic" ControlToValidate="tbxNoteNoteNew" ></asp:RequiredFieldValidator>
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
                                                            <asp:Label ID="lblNoteAttachmentNew" runat="server" EnableViewState="False" SkinID="Label"
                                                                Text="Attachment"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxNoteAttachmentNew" runat="server" Rows="1" SkinID="TextBoxReadOnly"
                                                                Style="width: 210px" ReadOnly="True"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="btnAddAtachment" Width="80px" runat="server" SkinID="Button" Text="Add" OnClick="btnAddAtachment_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </tbody>
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
                                </asp:Panel>
                                <asp:Panel ID="pnlCompleteWorkDataReadOnly" runat="server" Style="width: 710px">
                                    <div style="width: 710px">
                                        <!-- Table element: 5 columns  -->
                                        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%" Visible="false">
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
                                                    <asp:Label ID="lblCompleteWorkDataCompleteWorkDateTimeReadOnly" runat="server" EnableViewState="False"
                                                        SkinID="LabelSmall" Text="Complete Work Date & Time" Visible="false"></asp:Label>
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
                                                    <asp:TextBox ID="tbxCompleteWorkDataCompleteWorkDateTimeReadOnly" runat="server"
                                                        ReadOnly="True" SkinID="TextBoxSmallReadOnly" Style="width: 132px" Visible="false"></asp:TextBox>
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
                                                    <asp:Label ID="lblCompleteWorkDataUnitBackInServiceDateReadOnly" runat="server" EnableViewState="False" SkinID="LabelSmall" Text="Unit Back In Service Date"></asp:Label>
                                                </td>
                                                <td style="width: 110px;">
                                                    <asp:Label ID="lblCompleteWorkDataCompleteMileageReadOnly" runat="server" EnableViewState="False" SkinID="Label" Text="Mileage"></asp:Label>
                                                </td>
                                                <td style="width: 32px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="tbxCompleteWorkDataUnitBackInServiceDateReadOnly" runat="server" ReadOnly="True" SkinID="TextBoxSmallReadOnly" Style="width: 132px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="tbxCompleteWorkDataCompleteMileageReadOnly" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 100px"></asp:TextBox>                                                    
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblCompleteWorkDataMileageUnitOfMeasurementReadOnly" runat="server" SkinID="Label"></asp:Label>
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
                                        <asp:Panel ID="pnlTeamMemberAssignedReadOnly" runat="server" Width="100%">
                                            <!-- Page element : 1 column - secction title -->
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label6" runat="server" EnableViewState="False" SkinID="LabelTitle2"
                                                            Text="Work Details"></asp:Label>
                                                    </td>
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
                                                        <asp:Label ID="lblCompleteWorkDataDescriptionReadOnly" runat="server" EnableViewState="False"
                                                            SkinID="Label" Text="Description"></asp:Label>
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
                                                        <asp:TextBox ID="tbxCompleteWorkDataDescriptionReadOnly" runat="server" ReadOnly="True"
                                                            Rows="4" SkinID="TextBoxReadOnly" Style="width: 700px" TextMode="MultiLine"></asp:TextBox>
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
                                                        <asp:Label ID="lblCompleteWorkDataPreventableReadOnly" runat="server" EnableViewState="False"
                                                            SkinID="Label" Text="Preventable"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblCompleteWorkDataLabourHoursReadOnly" runat="server" EnableViewState="False"
                                                            SkinID="Label" Text="Labour Hours"></asp:Label>
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
                                                        <asp:CheckBox ID="ckbxCompleteWorkDataPreventableReadOnly" runat="server" onclick="return cbxClick();"
                                                            SkinID="CheckBox" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="tbxCompleteWorkDataLabourHoursReadOnly" runat="server" ReadOnly="True"
                                                            SkinID="TextBoxReadOnly" Style="width: 132px"></asp:TextBox>
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
                                            <!-- Page element : 1 column - secction title -->
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblCompleteWorkDataCostTitleReadOnly" runat="server" EnableViewState="False"
                                                            SkinID="LabelTitle2" Text="Costs"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 10px">
                                                    </td>
                                                </tr>
                                            </table>
                                            <!-- Page element : 1 column - work details -->
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td colspan="5">
                                                        <asp:UpdatePanel ID="upnlCostsReadOnly" runat="server">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="grdCostsReadOnly" runat="server" SkinID="GridView" Width="700px"
                                                                     DataSourceID="odsCosts" PageSize="8" AutoGenerateColumns="False"
                                                                    AllowPaging="True" DataKeyNames="ServiceID,RefID" OnDataBound="grdCostsReadOnly_DataBound">
                                                                    <Columns>
                                                                        <asp:TemplateField SortExpression="ServiceID" Visible="False" HeaderText="ServiceID">
                                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblIdReadOnly" runat="server" Text='<%# Eval("ServiceID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField SortExpression="RefID" Visible="False" HeaderText="RefID">
                                                                            <HeaderStyle Width="0px"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <asp:Label ID="lblRefIdReadOnly" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Part Number">
                                                                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                            <HeaderStyle Width="80px" HorizontalAlign="Center"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblPartNumberReadOnly" runat="server" SkinID="Label" Text='<%# Eval("PartNumber") %>'
                                                                                                Width="70px"></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Part Name">
                                                                            <HeaderStyle Width="225px"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblPartNameReadOnly" runat="server" SkinID="Label" Text='<%# Eval("PartName") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Vendor">
                                                                            <HeaderStyle Width="225px"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tr>
                                                                                        <td>
                                                                                            <asp:Label ID="lblVendorReadOnly" runat="server" SkinID="Label" Text='<%# Eval("Vendor") %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Cost">
                                                                            <HeaderStyle Width="100px"></HeaderStyle>
                                                                            <ItemTemplate>
                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                    <tr>
                                                                                        <td style="text-align: right">
                                                                                            <asp:Label ID="lblCostReadOnly" runat="server" SkinID="Label" Text='<%# String.Format("{0:N2}", Eval("Cost")) %>'></asp:Label>
                                                                                        </td>
                                                                                    </tr>
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
                                                    <td style="width: 80px">
                                                    </td>
                                                    <td style="width: 225px">
                                                    </td>
                                                    <td style="width: 225px">
                                                    </td>
                                                    <td style="width: 100px; text-align: right;">
                                                        <asp:TextBox ID="tbxTotalCostReadOnly" runat="server" ReadOnly="True" SkinID="TextBoxRightReadOnly"
                                                            Width="100%" TabIndex="-1"></asp:TextBox>
                                                    </td>
                                                    <td style="width: 60px">
                                                    </td>
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
                                        <asp:Panel ID="pnlThirdPartyVendorAssignedReadOnly" runat="server" Width="100%">
                                            <!-- Page element : 1 column - secction title -->
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblCompleteWorkDataWorkDetailsTitleThirdPartyVendorReadOnly" runat="server"
                                                            EnableViewState="False" SkinID="LabelTitle2" Text="Work Details"></asp:Label>
                                                    </td>
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
                                                        <asp:Label ID="Label12" runat="server" EnableViewState="False" SkinID="Label" Text="Description"></asp:Label>
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
                                                        <asp:TextBox ID="tbxCompleteWorkDataDescriptionThirdPartyVendorReadOnly" runat="server"
                                                            ReadOnly="True" Rows="4" SkinID="TextBoxReadOnly" Style="width: 700px" TextMode="MultiLine"></asp:TextBox>
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
                                                        <asp:Label ID="lblCompleteWorkDataPreventableThirdPartyVendorReadOnly" runat="server"
                                                            EnableViewState="False" SkinID="Label" Text="Preventable"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblCompleteWorkDataInvoiceNumberThirdPartyVendorReadOnly" runat="server"
                                                            EnableViewState="False" SkinID="Label" Text="Invoice Number"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblCompleteWorkDataInvoiceAmountThirdPartyVendorReadOnly" runat="server"
                                                            EnableViewState="False" SkinID="Label" Text="Invoice Amount"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="ckbxCompleteWorkDataPreventableThirdPartyVendorReadOnly" runat="server"
                                                            onclick="return cbxClick();" SkinID="CheckBox" />
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="tbxCompleteWorkDataInvoiceNumberThirdPartyVendorReadOnly" runat="server"
                                                            ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 132px"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="tbxCompleteWorkDataInvoiceAmountThirdPartyVendorReadOnly" runat="server"
                                                            ReadOnly="True" SkinID="TextBoxReadOnly" Style="width: 132px"></asp:TextBox>
                                                    </td>
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
                                </asp:Panel>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel ID="tpNotesData" runat="server" HeaderText="Notes &amp; Attachments"
                            OnClientClick="tpNotesDataClientClick">
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
                                            <td colspan="5" rowspan="5">
                                                <asp:UpdatePanel ID="upnlNotes" runat="server">
                                                    <contenttemplate>
                                                        <asp:GridView ID="grdNotes" runat="server" SkinID="GridViewInTabs" Width="700px"
                                                            DataSourceID="odsNotes" OnRowDataBound="grdNotes_RowDataBound" OnRowUpdating="grdNotes_RowUpdating"
                                                            OnRowDeleting="grdNotes_RowDeleting" OnRowCommand="grdNotes_RowCommand" OnDataBound="grdNotes_DataBound"
                                                            DataKeyNames="ServiceID, RefID" AllowPaging="True" AutoGenerateColumns="False" OnRowEditing="grdNotes_RowEditing"
                                                            ShowFooter="True" PageSize="5" __designer:wfdid="w36">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="ServiceID" SortExpression="ServiceID" 
                                                                    Visible="False">
                                                                    <EditItemTemplate>
                                                                        <asp:Label ID="lblServiceID" runat="server" Text='<%# Eval("ServiceID") %>'></asp:Label>
                                                                    </EditItemTemplate>
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblServiceID" runat="server" Text='<%# Eval("ServiceID") %>'></asp:Label>
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
                                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
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
                                                                                            __designer:wfdid="w76"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteSubjectEdit" runat="server" SkinID="TextBox"
                                                                                            Text='<%# Eval("Subject") %>' EnableViewState="True" __designer:wfdid="w77"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvNoteSubjectEdit" runat="server" SkinID="Validator"
                                                                                            EnableViewState="False" ValidationGroup="notesDataEdit" ErrorMessage="Please provide a subject."
                                                                                            Display="Dynamic" ControlToValidate="tbxNoteSubjectEdit" __designer:wfdid="w78"></asp:RequiredFieldValidator>
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
                                                                                        <asp:Label ID="lblNoteDateEdit" runat="server" EnableViewState="False" 
                                                                                            SkinID="Label" Text="Date"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteCreatedByEdit" runat="server" EnableViewState="False" 
                                                                                            SkinID="Label" Text="Created By"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxNoteDateEdit" runat="server" ReadOnly="True" 
                                                                                            SkinID="TextBoxReadOnly" Style="width: 145px" Text='<%# Eval("DateTime_") %>'></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxNoteCreatedByEdit" runat="server" ReadOnly="True" 
                                                                                            SkinID="TextBoxReadOnly" Style="width: 145px" 
                                                                                            Text='<%# GetNoteCreatedBy(Eval("UserID")) %>'></asp:TextBox>
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
                                                                        <!-- Page element : 2 columns - Notes Information -->
                                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
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
                                                                                            __designer:wfdid="w83"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteSubjectNew" runat="server" SkinID="TextBox"
                                                                                            Text='<%# Eval("Subject") %>' EnableViewState="True" __designer:wfdid="w84"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvNoteSubjectNew" runat="server" SkinID="Validator"
                                                                                            EnableViewState="False" ValidationGroup="notesDataAdd" ErrorMessage="Please provide a subject."
                                                                                            Display="Dynamic" ControlToValidate="tbxNoteSubjectNew" __designer:wfdid="w85"></asp:RequiredFieldValidator>
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
                                                                    <HeaderStyle Width="320px" />
                                                                    <ItemTemplate>
                                                                        <!-- Page element : 2 columns - Notes Information -->
                                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
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
                                                                                            __designer:wfdid="w70"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteSubject" runat="server" SkinID="TextBoxReadOnly"
                                                                                            Text='<%# Eval("Subject") %>' EnableViewState="True" ReadOnly="True" __designer:wfdid="w71"></asp:TextBox>
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
                                                                                        <asp:Label ID="lblNoteDate" runat="server"
                                                                                            EnableViewState="False" SkinID="Label" Text="Date"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteCreatedBy" runat="server" EnableViewState="False" 
                                                                                            SkinID="Label" Text="Created By"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxNoteDate" runat="server" ReadOnly="True" 
                                                                                            SkinID="TextBoxReadOnly" Style="width: 145px" Text='<%# Eval("DateTime_") %>'></asp:TextBox>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxNoteCreatedBy" runat="server" ReadOnly="True" 
                                                                                            SkinID="TextBoxReadOnly" Style="width: 145px" 
                                                                                            Text='<%# GetNoteCreatedBy(Eval("UserID")) %>'></asp:TextBox>
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
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteNoteEdit" runat="server" EnableViewState="False" 
                                                                                            SkinID="Label" Text="Note"></asp:Label>
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
                                                                                            __designer:wfdid="w65"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvNoteNoteEdit" runat="server" SkinID="Validator"
                                                                                            EnableViewState="False" ValidationGroup="notesDataEdit" ErrorMessage="Please provide a note."
                                                                                            Display="Dynamic" ControlToValidate="tbxNoteNoteEdit" __designer:wfdid="w66"></asp:RequiredFieldValidator>
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
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteAttachmentEdit" runat="server" EnableViewState="False" SkinID="Label"
                                                                                            Text="Attachment"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td></td>
                                                                                    <td style="vertical-align: top;">
                                                                                        <asp:TextBox ID="tbxNoteAttachmentEdit" runat="server" Rows="1" SkinID="TextBoxReadOnly" Style="width: 210px"
                                                                                            Text='<%# Eval("ORIGINAL_FILENAME") %>' Width="220px" ReadOnly="True"></asp:TextBox></td>
                                                                                    <td>
                                                                                        <asp:Button ID="btnNoteDeleteEdit" CommandName="DeleteAttachmentEdit" CommandArgument='<%# Eval("RefID") %>' Width="80px" runat="server" SkinID="Button" Text="Delete"/>
                                                                                        <asp:Button ID="btnNoteAddEdit" CommandName="AddAttachmentEdit" CommandArgument='<%# Eval("RefID") %>' Width="80px" runat="server" SkinID="Button" Text="Add"/></td>
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
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteNoteNew" runat="server" SkinID="Label" Text="Note" EnableViewState="False"
                                                                                            __designer:wfdid="w67"></asp:Label>
                                                                                    </td>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td colspan="2">
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteNoteNew" runat="server" SkinID="TextBox"
                                                                                            Text='<%# Eval("Note") %>' EnableViewState="True" Rows="1" __designer:wfdid="w68"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:RequiredFieldValidator ID="rfvNoteNoteNew" runat="server" SkinID="Validator"
                                                                                            EnableViewState="False" ValidationGroup="notesDataAdd" ErrorMessage="Please provide a note."
                                                                                            Display="Dynamic" ControlToValidate="tbxNoteNoteNew" __designer:wfdid="w69"></asp:RequiredFieldValidator>
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
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:TextBox ID="tbxNoteAttachmentNew" runat="server" Rows="1" SkinID="TextBoxReadOnly" Style="width: 210px" Text='<%# Eval("ORIGINAL_FILENAME") %>' ReadOnly="True"></asp:TextBox>
                                                                                        <asp:Label ID="lblFileNameNoteAttachmentNew" runat="server" SkinID="Label" Text='<%# Eval("FILENAME") %>' Visible ="False"/>    
                                                                                    </td>
                                                                                    <td>
                                                                                        <asp:Button ID="btnAddFooter" Width="80px" runat="server" SkinID="Button" Text="Add" TabIndex="4" CommandName="AddAttachmentAdd" CommandArgument='<%# Eval("RefID") %>' /></td>
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
                                                                                        <asp:TextBox Style="width: 300px" ID="tbxNoteNote" runat="server" SkinID="TextBoxReadOnly"
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
                                                                                    <td></td>
                                                                                    <td>
                                                                                        <asp:Label ID="lblNoteAttachment" runat="server" EnableViewState="False" SkinID="Label"
                                                                                            Text="Attachment"></asp:Label>
                                                                                    </td>
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
                                                                                        <asp:ImageButton ID="ibtnAdd" runat="server" CommandName="Add" 
                                                                                            ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png" 
                                                                                            SkinID="GridView_Add" ToolTip="Add" />
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </FooterTemplate>
                                                                    <HeaderStyle Width="60px" />
                                                                    <ItemTemplate>
                                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnEdit" runat="server" CommandName="Edit" 
                                                                                            ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png" 
                                                                                            SkinID="GridView_Edit" ToolTip="Edit" />
                                                                                    </td>
                                                                                    <td style="width: 50%">
                                                                                        <asp:ImageButton ID="ibtnDelete" runat="server" CommandName="Delete" 
                                                                                            ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png" 
                                                                                            OnClientClick="return confirm(&quot;Are you sure you want to delete this note?&quot;);" 
                                                                                            SkinID="GridView_Delete" ToolTip="Delete" />
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
                                        <tr>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                    
                                    <!-- Table element: 6 columns - Bottom space -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
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
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadByAssignableSrsAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Employees.EmployeeList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name="assignableSrs" Type="Int32" />
                            <asp:Parameter DefaultValue="-1" Name="employeeId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select a team member)" Name="fullName" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsCosts" runat="server" FilterExpression="(Deleted = 0)"
                        SelectMethod="GetCostsNew" TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Services.services_edit"
                        DeleteMethod="DummyCostsNew" InsertMethod="DummyCostsNew" UpdateMethod="DummyCostsNew">
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsNotes" runat="server" FilterExpression="(Deleted = 0)"
                        SelectMethod="GetNotesNew" TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Services.services_edit"
                        DeleteMethod="DummyNotesNew" InsertMethod="DummyNotesNew" UpdateMethod="DummyNotesNew">
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
                    <asp:HiddenField ID="hdfErrorFieldList" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
