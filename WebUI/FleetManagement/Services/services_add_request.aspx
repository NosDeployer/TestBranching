<%@ Page Language="C#" Title="LFS Live" MasterPageFile="../../mWizard2.Master" AutoEventWireup="true" Codebehind="services_add_request.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.Services.services_add_request" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 350px">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard ID="wzServices" runat="server" Width="450px" Height="450px" ActiveStepIndex="1"
                        DisplayCancelButton="True" DisplaySideBar="False" SkinID="Wizard" OnActiveStepChanged="Wizard_ActiveStepChanged"
                        OnNextButtonClick="Wizard_NextButtonClick" OnCancelButtonClick="Wizard_CancelButtonClick"
                        OnFinishButtonClick="Wizard_FinishButtonClick" OnPreviousButtonClick="Wizard_PreviousButtonClick">
                        <WizardSteps>
                            <asp:WizardStep ID="StepBegin" runat="server" Title="Begin">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblUnit" runat="server" EnableViewState="False" SkinID="Label" Text="Unit"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlUnits" runat="server" DataMember="DefaultView" DataSourceID="odsUnits"
                                                DataTextField="Description" DataValueField="UnitID" SkinID="DropDownList" Style="width: 440px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvUnit" runat="server" ControlToValidate="ddlUnits"
                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Please select a unit."
                                                InitialValue="-1" SkinID="Validator" ValidationGroup="Begin"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepGeneralInformation" runat="server" Title="General Information">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td colspan="3">
                                            <asp:Label ID="lblGeneralnformationTitle" runat="server" EnableViewState="False"
                                                SkinID="LabelTitle2" Text="Please provide general information."></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 150px; height: 10px;">
                                        </td>
                                        <td style="width: 150px">
                                        </td>
                                        <td style="width: 150px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblMtoDto" runat="server" EnableViewState="False" SkinID="Label" Text="Fixed Date"></asp:Label>
                                        </td>
                                        <td colspan="2">
                                            <asp:Label ID="lblMileage" runat="server" EnableViewState="False" SkinID="Label" Text="Mileage"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="ckbxMtoDto" runat="server" SkinID="CheckBox" />
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox ID="tbxMileage" runat="server" SkinID="TextBox" Style="width: 140px"></asp:TextBox>
                                            <asp:Label ID="lblMileageUnitOfMeasurement" runat="server" SkinID="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td colspan="2">
                                            <asp:CustomValidator ID="cvMileage" runat="server" ControlToValidate="tbxMileage"
                                                Display="Dynamic" ErrorMessage="Please provide a mileage." OnServerValidate="cvMileage_ServerValidate"
                                                SkinID="Validator" ValidateEmptyText="True" ValidationGroup="GeneralInformation"></asp:CustomValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="height: 7px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Label ID="lblDescription" runat="server" EnableViewState="False" SkinID="Label" Text="Problem Description"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:TextBox ID="tbxDescription" runat="server" Style="width: 440px" SkinID="TextBox" Rows="4" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:RequiredFieldValidator ID="rfvProblemDescription" runat="server" ControlToValidate="tbxDescription"
                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Please provide the problem description."
                                                SkinID="Validator" ValidationGroup="assignmentInformation"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="height: 7px">
                                        </td>
                                    </tr>
                                </table>
                            
                                <!-- Page element : Horizontal Rule -->
                                <table id="Table1" runat="server" cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                    <tr runat="server">
                                        <td style="height: 30px" runat="server">
                                        </td>
                                    </tr>
                                    <tr runat="server">
                                        <td style="height: 2px" class="Background_Separator" runat="server">
                                        </td>
                                    </tr>
                                    <tr runat="server">
                                        <td style="height: 10px" runat="server">
                                        </td>
                                    </tr>
                                </table>
                            
                                <asp:UpdatePanel id="upPnlAssignation" runat="server">
                                    <contenttemplate>
                                        <!-- Page element : 1 panel - assignment information -->
                                        <asp:Panel ID="pnlAssignmentInformation" runat="server" Width="100%" >
                                            <table style="width: 100%" cellspacing="0" cellpadding="0" width="0">
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblAssignmentPanelTitle" runat="server" SkinID="LabelTitle2" Text="Please provide assignment information"
                                                                EnableViewState="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblAssignmentTo" runat="server" SkinID="Label" Text="Assign SR to"
                                                                EnableViewState="False" __designer:wfdid="w107"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="rbtnUnassigned" runat="server" SkinID="RadioButton" Text="Unassigned"
                                                                __designer:wfdid="w1" Checked="True" GroupName="Begin" AutoPostBack="True" OnCheckedChanged="rbtnAssignToMyself_CheckedChanged">
                                                            </asp:RadioButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="rbtnAssignToMyself" runat="server" SkinID="RadioButton" Text="Myself"
                                                                __designer:wfdid="w108" GroupName="Begin" AutoPostBack="True" OnCheckedChanged="rbtnAssignToMyself_CheckedChanged">
                                                            </asp:RadioButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="rbtnAssignToTeamMember" runat="server" SkinID="RadioButton"
                                                                Text="Team Member" __designer:wfdid="w109" GroupName="Begin" AutoPostBack="True"
                                                                OnCheckedChanged="rbtnAssignToMyself_CheckedChanged"></asp:RadioButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList Style="width: 440px" ID="ddlAssignToTeamMember" runat="server"
                                                                SkinID="DropDownList" __designer:wfdid="w110" DataTextField="FullName" DataMember="DefaultView"
                                                                DataValueField="EmployeeID" DataSourceID="odsEmployee">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CustomValidator ID="cvTeamMember" runat="server" SkinID="Validator" OnServerValidate="cvTeamMember_ServerValidate"
                                                                Display="Dynamic" ValidationGroup="assignmentInformation" ControlToValidate="ddlAssignToTeamMember"
                                                                ErrorMessage="Please select a team member." __designer:wfdid="w111"></asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="rbtnAssignToThirdPartyVendor" runat="server" SkinID="RadioButton"
                                                                Text="Third Party Vendor" __designer:wfdid="w112" GroupName="Begin" AutoPostBack="True"
                                                                OnCheckedChanged="rbtnAssignToMyself_CheckedChanged"></asp:RadioButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox Style="width: 440px" ID="tbxAssignToThirdPartyVendor" runat="server"
                                                                SkinID="TextBox" __designer:wfdid="w113"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CustomValidator ID="cvThirdPartyVendor" runat="server" SkinID="Validator" OnServerValidate="cvThridPartyVendor_ServerValidate"
                                                                Display="Dynamic" ValidationGroup="assignmentInformation" ControlToValidate="tbxAssignToThirdPartyVendor"
                                                                ErrorMessage="Please provide a third party vendor." ValidateEmptyText="True" __designer:wfdid="w114"></asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblDeadLine" runat="server" SkinID="Label" Text="Deadline Date" EnableViewState="False"
                                                                __designer:wfdid="w115"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <telerik:RadDatePicker ID="tkrdpDeadlineDate" runat="server" Width="140px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                            </telerik:RadDatePicker>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </asp:Panel>
                                    </contenttemplate>
                                </asp:UpdatePanel>
                                
                                <asp:UpdatePanel id="upPnlAssignationData" runat="server">
                                    <contenttemplate>
                                
                                        <!-- Page element : Horizontal Rule -->                                
                                        <table id="acceptInformationSeparator" runat="server" cellspacing="0" cellpadding="0"
                                            border="0" style="width: 100%">
                                            <tr id="Tr1" runat="server">
                                                <td id="Td1" style="height: 30px" runat="server">
                                                </td>
                                            </tr>
                                            <tr id="Tr2" runat="server">
                                                <td id="Td2" style="height: 2px" class="Background_Separator" runat="server">
                                                </td>
                                            </tr>
                                            <tr id="Tr3" runat="server">
                                                <td id="Td3" style="height: 10px" runat="server">
                                                </td>
                                            </tr>
                                        </table>
                                        
                                        <!-- Page element : 1 panel - accept information -->
                                        <asp:Panel ID="pnlAcceptInformation" runat="server" Width="100%">
                                            <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblAcceptTitle" runat="server" EnableViewState="False" SkinID="LabelTitle2"
                                                            Text="Do you want to accept the Service Request?"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 10px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBox ID="ckbxAcceptSR" runat="server" SkinID="CheckBox" Text="I want to accept this SR" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CustomValidator ID="cvAcceptSR" runat="server" ControlToValidate="tbxDescription"
                                                            Display="Dynamic" ErrorMessage="You should assign the work first." OnServerValidate="cvAcceptSR_ServerValidate"
                                                            SkinID="Validator" ValidateEmptyText="True" ValidationGroup="assignmentInformation"></asp:CustomValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px">
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        
                                        <!-- Page element : Horizontal Rule -->
                                        <table id="startWorkSeparator" runat="server" cellspacing="0" cellpadding="0" border="0"
                                            style="width: 100%">
                                            <tr  runat="server">
                                                <td  style="height: 30px" runat="server">
                                                </td>
                                            </tr>
                                            <tr runat="server">
                                                <td  style="height: 2px" class="Background_Separator" runat="server">
                                                </td>
                                            </tr>
                                            <tr runat="server">
                                                <td  style="height: 10px" runat="server">
                                                </td>
                                            </tr>
                                        </table>
                                        
                                        <!-- Page element : 1 panel - start work information -->
                                        <asp:Panel ID="pnlStartWorkInformation" runat="server" Width="100%">
                                            <!-- Table element: 3 columns  -->
                                            <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Label ID="lblStartWorkTitle" runat="server" EnableViewState="False" SkinID="LabelTitle2"
                                                            Text="Please provide start work information"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 10px" colspan="3">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:CheckBox ID="ckbxStartSR" runat="server" SkinID="CheckBox" Text="I want to start this SR" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:CustomValidator ID="cvStartSR" runat="server" ControlToValidate="tbxCompleteWorkCompleteMileage"
                                                            Display="Dynamic" ErrorMessage="You should accept the work before providing start work information."
                                                            OnServerValidate="cvStartSR_ServerValidate" SkinID="Validator" ValidateEmptyText="True"
                                                            ValidationGroup="startWorkInformation"></asp:CustomValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px; width: 150px;">
                                                    </td>
                                                    <td style="width: 150px">
                                                    </td>
                                                    <td style="width: 150px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblStartWorkUnitOutOfServiceDate" runat="server" SkinID="Label" Text="Unit Out Of Service Date"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblStartWorkStartMileage" runat="server" SkinID="Label" Text="Mileage"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <telerik:RadDatePicker ID="tkrdpStartWorkUnitOutOfServiceDate" runat="server" Width="140px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                        </telerik:RadDatePicker>
                                                    </td>                                                    
                                                    <td>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="tbxStartWorkStartMileage" runat="server" SkinID="TextBox" Style="width: 120px;" onkeyup="MakeCompleteWorkMileageSameStartWorkMileage();"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblStartWorkStartMileageUnitOfMeasurement" runat="server" SkinID="Label"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CustomValidator ID="cvUnitOutOfServiceDate" runat="server" ControlToValidate="tkrdpStartWorkUnitOutOfServiceDate"
                                                            Display="Dynamic" ErrorMessage="Please select a date." OnServerValidate="cvUnitOutOfServiceDate_ServerValidate"
                                                            SkinID="Validator" ValidateEmptyText="True" ValidationGroup="startWorkInformation"></asp:CustomValidator>
                                                    </td>
                                                    <td>
                                                        <asp:CustomValidator ID="cvStartMileage" runat="server" ControlToValidate="tbxStartWorkStartMileage"
                                                            Display="Dynamic" ErrorMessage="Please provide a mileage." OnServerValidate="cvStartMileage_ServerValidate"
                                                            SkinID="Validator" ValidateEmptyText="True" 
                                                            ValidationGroup="startWorkInformation"></asp:CustomValidator>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                        
                                        <!-- Page element : Horizontal Rule -->
                                        <table id="completeWorkSeparator" runat="server" cellspacing="0" cellpadding="0"
                                            border="0" style="width: 100%">
                                            <tr id="Tr7" runat="server">
                                                <td id="Td7" style="height: 30px" runat="server">
                                                </td>
                                            </tr>
                                            <tr id="Tr8" runat="server">
                                                <td id="Td8" style="height: 2px" class="Background_Separator" runat="server">
                                                </td>
                                            </tr>
                                            <tr id="Tr9" runat="server">
                                                <td id="Td9" style="height: 10px" runat="server">
                                                </td>
                                            </tr>
                                        </table>
                                        
                                        <!-- Page element : 1 panel - complete work information -->
                                        <asp:Panel ID="pnlCompleteWorkInformation" runat="server" Width="100%">
                                            
                                            <!-- Table element: 3 columns  -->
                                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:Label ID="lblCompleteTitle" runat="server" EnableViewState="False" SkinID="LabelTitle2" Text="Please provide complete work information"/>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 10px" colspan="3">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:CheckBox ID="ckbxCompleteSR" runat="server" SkinID="CheckBox" Text="I want to complete this SR" />
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="3">
                                                        <asp:CustomValidator ID="cvCompleteSR" runat="server" ControlToValidate="tbxCompleteWorkCompleteMileage"
                                                            Display="Dynamic" ErrorMessage="You should start work before providing complete work information."
                                                            OnServerValidate="cvCompleteSR_ServerValidate" SkinID="Validator" ValidateEmptyText="True"
                                                            ValidationGroup="completeInformation"></asp:CustomValidator>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 7px; width: 150px;">
                                                    </td>
                                                    <td style="width: 150px">
                                                    </td>
                                                    <td style="width: 150px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblCompleteWorkUnitBackInServiceDate" runat="server" SkinID="Label" Text="Unit Back In Service Date"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblCompleteWorkCompleteMileage" runat="server" SkinID="Label" Text="Mileage"></asp:Label>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <telerik:RadDatePicker ID="tkrdpCompleteWorkUnitBackInServiceDate" runat="server" Width="140px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                        </telerik:RadDatePicker>
                                                    </td>                                                    
                                                    <td>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox ID="tbxCompleteWorkCompleteMileage" runat="server" SkinID="TextBox" Style="width: 120px;"></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblCompleteWorkCompleteMileageUnitOfMeasurement" runat="server" SkinID="Label"></asp:Label>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:CustomValidator ID="cvUnitBackInServiceDate" runat="server" 
                                                            ControlToValidate="tkrdpCompleteWorkUnitBackInServiceDate" Display="Dynamic" 
                                                            ErrorMessage="Please select a date." 
                                                            OnServerValidate="cvUnitBackInServiceDate_ServerValidate" SkinID="Validator" 
                                                            ValidateEmptyText="True" ValidationGroup="completeInformation"></asp:CustomValidator>
                                                    </td>
                                                    <td>
                                                        <asp:CustomValidator ID="cvCompleteMileage" runat="server" 
                                                            ControlToValidate="tbxCompleteWorkCompleteMileage" Display="Dynamic" 
                                                            ErrorMessage="Please provide a mileage." 
                                                            OnServerValidate="cvCompleteMileage_ServerValidate" SkinID="Validator" 
                                                            ValidateEmptyText="True" ValidationGroup="completeInformation"></asp:CustomValidator>
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
                                            </table>
                                                                                                                                        
                                            <!-- Page element : 1 panel - complete work for team members -->
                                            <asp:Panel ID="pnlAssignTeamMember" runat="server" Width="100%" >
                                                <!-- Page element : 1 column - work details -->
                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 150px">
                                                                <asp:Label ID="lblCompleteWorkDataDescription" runat="server" SkinID="Label" Text="Description"
                                                                ></asp:Label>
                                                            </td>
                                                            <td style="width: 150px">
                                                            </td>
                                                            <td style="width: 150px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <asp:TextBox Style="width: 440px" ID="tbxCompleteWorkDataDescription" runat="server"
                                                                    SkinID="TextBox" TextMode="MultiLine" Rows="4" __designer:wfdid="w155"></asp:TextBox>
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
                                                                <asp:Label ID="lblCompleteWorkDataPreventable" runat="server" SkinID="Label" Text="Preventable"
                                                                    __designer:wfdid="w156"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblCompleteWorkDataLabourHours" runat="server" SkinID="Label" Text="Labour Hours"
                                                                    __designer:wfdid="w157"></asp:Label>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="ckbxCompleteWorkDataPreventable" runat="server" SkinID="CheckBox"
                                                                    __designer:wfdid="w158"></asp:CheckBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox Style="width: 140px" ID="tbxCompleteWorkDataLabourHours" runat="server"
                                                                    SkinID="TextBox" __designer:wfdid="w159"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                <asp:CompareValidator ID="cvCompleteWorkDataLabourHours" runat="server" SkinID="Validator"
                                                                    Display="Dynamic" ValidationGroup="completeInformation" ControlToValidate="tbxCompleteWorkDataLabourHours"
                                                                    ErrorMessage="Invalid format. (use XXXX.XX)" __designer:wfdid="w160" Type="Currency"
                                                                    Operator="DataTypeCheck"></asp:CompareValidator>
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
                                                    </tbody>
                                                </table>
                                                
                                                <!-- Page element : 1 column - secction title -->
                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblCompleteWorkDataCostTitle" runat="server" SkinID="Label" Text="Costs"
                                                                    __designer:wfdid="w161"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 10px">
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                
                                                <!-- Page element : 1 column - work details -->
                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td colspan="5">
                                                                <asp:UpdatePanel id="upnlCosts" runat="server" __designer:wfdid="w162">
                                                                    <ContentTemplate>
                                                                        <asp:GridView ID="grdCosts" runat="server" SkinID="GridViewInTabs" Width="450px"
                                                                            DataSourceID="odsCosts" __designer:wfdid="w163" OnRowUpdating="grdCosts_RowUpdating"
                                                                            OnRowDeleting="grdCosts_RowDeleting" OnRowCommand="grdCosts_RowCommand" AllowPaging="True"
                                                                            ShowFooter="True" PageSize="4" AutoGenerateColumns="False" DataKeyNames="ServiceID,RefID"
                                                                            OnDataBound="grdCosts_DataBound" OnRowEditing="grdCosts_RowEditing">
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
                                                                                    <HeaderStyle Width="0px"></HeaderStyle>
                                                                                    <ItemTemplate>
                                                                                        <asp:Label ID="lblRefId" runat="server" Text='<%# Eval("RefID") %>'></asp:Label>
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
                                                                                                    <asp:TextBox ID="tbxPartNumber" runat="server" EnableViewState="True" SkinID="TextBox"
                                                                                                        Text='<%# Eval("PartNumber") %>' Style="width: 77px"></asp:TextBox>
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
                                                                                                    <asp:TextBox ID="tbxPartNumberNew" runat="server" EnableViewState="True" SkinID="TextBox"
                                                                                                        Style="width: 77px"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="height: 12px">
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </FooterTemplate>
                                                                                    <ItemStyle HorizontalAlign="Left"></ItemStyle>
                                                                                    <HeaderStyle Width="87px" HorizontalAlign="Center"></HeaderStyle>
                                                                                    <ItemTemplate>
                                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <asp:Label ID="lblPartNumber" runat="server" SkinID="Label" Text='<%# Eval("PartNumber") %>'
                                                                                                        Width="77px"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:TemplateField HeaderText="Part Name">
                                                                                    <EditItemTemplate>
                                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                            <tbody>
                                                                                                <tr>
                                                                                                    <td style="height: 12px">
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:TextBox Style="width: 110px" ID="tbxPartName" runat="server" SkinID="TextBox"
                                                                                                            Text='<%# Eval("PartName") %>' EnableViewState="True"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:RequiredFieldValidator ID="rfvDescriptionNew" runat="server" SkinID="Validator"
                                                                                                            EnableViewState="True" Display="Dynamic" ValidationGroup="costsDataEdit" ControlToValidate="tbxPartName"
                                                                                                            ErrorMessage="Please provide a part name.">
                                                                                                        </asp:RequiredFieldValidator>
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
                                                                                                        <asp:TextBox Style="width: 110px" ID="tbxPartNameNew" runat="server" SkinID="TextBox"
                                                                                                            EnableViewState="True"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" SkinID="Validator"
                                                                                                            EnableViewState="True" Display="Dynamic" ValidationGroup="costsDataAdd" ControlToValidate="tbxPartNameNew"
                                                                                                            ErrorMessage="Please provide a part name.">
                                                                                                        </asp:RequiredFieldValidator>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="height: 12px">
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </tbody>
                                                                                        </table>
                                                                                    </FooterTemplate>
                                                                                    <HeaderStyle Width="120px"></HeaderStyle>
                                                                                    <ItemTemplate>
                                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                            <tbody>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:Label ID="lblPartName" runat="server" SkinID="Label" Text='<%# Eval("PartName") %>'
                                                                                                            Width="110px"></asp:Label>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </tbody>
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
                                                                                                    <asp:TextBox ID="tbxVendor" runat="server" EnableViewState="True" SkinID="TextBox"
                                                                                                        Text='<%# Eval("Vendor") %>' Style="width: 110px"></asp:TextBox>
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
                                                                                                    <asp:TextBox ID="tbxVendorNew" runat="server" EnableViewState="True" SkinID="TextBox"
                                                                                                        Style="width: 110px"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="height: 12px">
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </FooterTemplate>
                                                                                    <HeaderStyle Width="120px"></HeaderStyle>
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
                                                                                                        Width="75px"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="text-align: right">
                                                                                                    <asp:CompareValidator ID="cvCost" runat="server" ControlToValidate="tbxCost" Display="Dynamic"
                                                                                                        EnableViewState="True" ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck"
                                                                                                        SkinID="Validator" Type="Currency" ValidationGroup="costsDataEdit">
                                                                                                    </asp:CompareValidator>
                                                                                                    <asp:RequiredFieldValidator ID="rfvCost" runat="server" ControlToValidate="tbxCost"
                                                                                                        Display="Dynamic" EnableViewState="True" ErrorMessage="Please provide a cost."
                                                                                                        SkinID="Validator" ValidationGroup="costsDataEdit">
                                                                                                    </asp:RequiredFieldValidator>
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
                                                                                                    <asp:TextBox ID="tbxCostNew" runat="server" SkinID="TextBoxRight" Width="75px"></asp:TextBox>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="text-align: right">
                                                                                                    <asp:CompareValidator ID="cvCostNew" runat="server" ControlToValidate="tbxCostNew"
                                                                                                        Display="Dynamic" EnableViewState="True" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                        Operator="DataTypeCheck" SkinID="Validator" Type="Currency" ValidationGroup="costsDataAdd">
                                                                                                    </asp:CompareValidator>
                                                                                                    <asp:RequiredFieldValidator ID="rfvCostNew" runat="server" ControlToValidate="tbxCostNew"
                                                                                                        Display="Dynamic" EnableViewState="True" ErrorMessage="Please provide a cost."
                                                                                                        SkinID="Validator" ValidationGroup="costsDataAdd">
                                                                                                    </asp:RequiredFieldValidator>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td style="height: 12px">
                                                                                                </td>
                                                                                            </tr>
                                                                                        </table>
                                                                                    </FooterTemplate>
                                                                                    <HeaderStyle Width="85px"></HeaderStyle>
                                                                                    <ItemTemplate>
                                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                            <tr>
                                                                                                <td style="text-align: right">
                                                                                                    <asp:Label ID="lblCost" runat="server" SkinID="Label" Text='<%# String.Format("{0:N2}", Eval("Cost")) %>'
                                                                                                        Width="75px"></asp:Label>
                                                                                                </td>
                                                                                            </tr>
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
                                                                                                        <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" CommandName="Update"
                                                                                                            ToolTip="Update"></asp:ImageButton>
                                                                                                    </td>
                                                                                                    <td style="width: 50%">
                                                                                                        <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" CommandName="Cancel"
                                                                                                            ToolTip="Cancel"></asp:ImageButton>
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
                                                                                                        <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" CommandName="Add"
                                                                                                            ToolTip="Add"></asp:ImageButton>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="height: 12px">
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </tbody>
                                                                                        </table>
                                                                                    </FooterTemplate>
                                                                                    <HeaderStyle Width="38px"></HeaderStyle>
                                                                                    <ItemTemplate>
                                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                            <tbody>
                                                                                                <tr>
                                                                                                    <td style="width: 50%">
                                                                                                        <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" CommandName="Edit"
                                                                                                            ToolTip="Edit"></asp:ImageButton>
                                                                                                    </td>
                                                                                                    <td style="width: 50%">
                                                                                                        <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" CommandName="Delete"
                                                                                                            OnClientClick='return confirm("Are you sure you want to delete this part?");'
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
                                                    </tbody>
                                                </table>
                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 330px">
                                                                
                                                            </td>
                                                            <td style="width: 85px; text-align: right">
                                                                <asp:UpdatePanel id="upnlTotalCost" runat="server" __designer:wfdid="w164">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="tbxTotalCost" runat="server" SkinID="TextBoxRightReadOnly" Width="100%"
                                                                        __designer:wfdid="w165" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter">
                                                                        </asp:TextBox>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                            <td style="width: 35px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 10px">
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td colspan="3">
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:Panel>
                                        
                                            <!-- Page element : 1 panel - Assign to third party vendor -->
                                            <asp:Panel ID="pnlAssignThirdPartyVendor" runat="server" Width="100%">
                                                <!-- Page element : 1 column - work details -->
                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 150px">
                                                                <asp:Label ID="lblDescriptionTPV" runat="server" SkinID="Label" Text="Description"
                                                                ></asp:Label>
                                                            </td>
                                                            <td style="width: 150px">
                                                            </td>
                                                            <td style="width: 150px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <asp:TextBox Style="width: 440px" ID="tbxDescriptionTPV" runat="server" SkinID="TextBox"
                                                                    TextMode="MultiLine" Rows="4"></asp:TextBox>
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
                                                                <asp:Label ID="lblPreventableTPV" runat="server" SkinID="Label" Text="Preventable"
                                                                    __designer:wfdid="w169"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblInvoiceNumberTPV" runat="server" SkinID="Label" Text="Invoice Number"
                                                                    __designer:wfdid="w170"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblInvoiceAmountTPV" runat="server" SkinID="Label" Text="Invoice Amount"
                                                                    __designer:wfdid="w171"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="ckbxPreventableTPV" runat="server" SkinID="CheckBox" >
                                                                </asp:CheckBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox Style="width: 140px" ID="tbxInvoiceNumberTPV" runat="server" SkinID="TextBox"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox Style="width: 140px" ID="tbxInvoiceAmountTPV" runat="server" SkinID="TextBox"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                <asp:CompareValidator ID="cvInvoiceAmount" runat="server" SkinID="Validator" Display="Dynamic"
                                                                    ValidationGroup="completeInformation" ControlToValidate="tbxInvoiceAmountTPV"
                                                                    ErrorMessage="Invalid format. (use XXXX.XX)" __designer:wfdid="w175" Type="Currency"
                                                                    Operator="DataTypeCheck"></asp:CompareValidator>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:Panel>
                                        </asp:Panel>
                                    </contenttemplate>
                                </asp:UpdatePanel>
                                    
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td style="height: 60px">
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepSummary" runat="server" StepType="Finish" Title="Summary">
                                <!-- Page element: Summary -->
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td style="width: 100%">
                                            <asp:TextBox ID="tbxSummary" runat="server" Height="380px" Width="440px" ReadOnly="True" SkinID="TextBoxReadOnly" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px">
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepFinalStep" runat="server" Title="Final Step" StepType="Complete">
                                <!-- Page element: Final Steps -->
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lkbtnOpenService" runat="server" SkinID="LinkButton" EnableViewState="False">Open the service you just created</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lkbtnEditService" runat="server" SkinID="LinkButton">Edit the service you just created</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lkbtnClose" runat="server" SkinID="LinkButton">Close this window</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px">
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                        </WizardSteps>
                        
                        <StepNavigationTemplate>
                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                <tr>
                                    <td style="width: 100px">
                                    </td>
                                    <td style="width: 80px; text-align: right">
                                    </td>
                                    <td style="width: 90px; text-align: right">
                                        <asp:Button ID="btnPrevious" Style="width: 80px" runat="server" CausesValidation="False"
                                            CommandName="MovePrevious" Text="Previous" SkinID="Button" EnableViewState="False" /></td>
                                    <td style="width: 90px; text-align: right">
                                        <asp:Button ID="NextButton" Style="width: 80px" runat="server" CausesValidation="False"
                                            CommandName="MoveNext" Text="Next" SkinID="Button" EnableViewState="False" />
                                    </td>
                                    <td style="width: 90px; text-align: right">
                                        <asp:Button ID="CancelButton" Style="width: 80px" runat="server" CausesValidation="False"
                                            CommandName="Cancel" Text="Cancel" SkinID="Button" EnableViewState="False" />
                                    </td>
                                </tr>
                            </table>
                        </StepNavigationTemplate>
                        
                        <FinishNavigationTemplate>
                            <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                <tr>
                                    <td style="width: 100px">
                                    </td>
                                    <td style="width: 80px; text-align: right">
                                    </td>
                                    <td style="width: 90px; text-align: right;">
                                        <asp:Button ID="btnPrevious" Style="width: 80px" runat="server" CausesValidation="False"
                                            CommandName="MovePrevious" Text="Previous" SkinID="Button" EnableViewState="False" /></td>
                                    <td style="width: 90px; text-align: right">
                                        <asp:Button ID="FinishButton" Style="width: 80px" runat="server" CommandName="MoveComplete"
                                            Text="Finish" SkinID="Button" EnableViewState="False" />
                                    </td>
                                    <td style="width: 90px; text-align: right">
                                        <asp:Button ID="CancelButton" Style="width: 80px" runat="server" CausesValidation="False"
                                            CommandName="Cancel" Text="Cancel" SkinID="Button" EnableViewState="False" />
                                    </td>
                                </tr>
                            </table>
                        </FinishNavigationTemplate>
                    </asp:Wizard>
                </td>
            </tr>
        </table>
        
        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsUnits" runat="server" CacheDuration="120" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.FleetManagement.Units.UnitsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="unitId" Type="String" />
                            <asp:Parameter DefaultValue="(Select a unit)" Name="description" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsEmployee" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadByAssignableSrsAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Employees.EmployeeList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name="assignableSrs" Type="Int32" />
                            <asp:Parameter DefaultValue="-1" Name="employeeId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select a team member)" Name="fullName" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsCosts" runat="server" DeleteMethod="DummyCostsNew" FilterExpression="(Deleted = 0)"
                        InsertMethod="DummyCostsNew" SelectMethod="GetCostsNew" TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Services.services_add_request"
                        UpdateMethod="DummyCostsNew"></asp:ObjectDataSource>
                </td>
            </tr>
        </table>
        
        <!-- Page element: HiddenFields -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfUnitId" runat="server" />
                    <asp:HiddenField ID="hdfInitialUnitId" runat="server" />
                    <asp:HiddenField ID="hdfUnitCode" runat="server" />
                    <asp:HiddenField ID="hdfUnitType" runat="server" />
                    <asp:HiddenField ID="hdfDescription" runat="server" />
                    <asp:HiddenField ID="hdfMtoDto" runat="server" />
                    <asp:HiddenField ID="hdfMileage" runat="server" />
                    <asp:HiddenField ID="hdfPnlAssignmentInformation" runat="server" />
                    <asp:HiddenField ID="hdfAssignToMyself" runat="server" />
                    <asp:HiddenField ID="hdfUnassigned" runat="server" />
                    <asp:HiddenField ID="hdfAssignToThirdPartyVendor" runat="server" />
                    <asp:HiddenField ID="hdfAssignToTeamMember" runat="server" />
                    <asp:HiddenField ID="hdfDeadlineDate" runat="server" />
                    <asp:HiddenField ID="hdfTeamMemberId" runat="server" />
                    <asp:HiddenField ID="hdfTeamMemberFullName" runat="server" />
                    <asp:HiddenField ID="hdfThirdPartyVendor" runat="server" />
                    <asp:HiddenField ID="hdfPnlAcceptInformation" runat="server" />
                    <asp:HiddenField ID="hdfAcceptInformation" runat="server" />
                    <asp:HiddenField ID="hdfAcceptSR" runat="server" />
                    <asp:HiddenField ID="hdfPnlStartWorkInformation" runat="server" />
                    <asp:HiddenField ID="hdfStartSR" runat="server" />
                    <asp:HiddenField ID="hdfUnitOutOfServiceDate" runat="server" />
                    <asp:HiddenField ID="hdfUnitOutOfServiceTime" runat="server" />
                    <asp:HiddenField ID="hdfStartMileage" runat="server" />
                    <asp:HiddenField ID="hdfPnlCompleteWorkInformation" runat="server" />
                    <asp:HiddenField ID="hdfCompleteSR" runat="server" />
                    <asp:HiddenField ID="hdfUnitBackInServiceDate" runat="server" />
                    <asp:HiddenField ID="hdfUnitBackInServiceTime" runat="server" />
                    <asp:HiddenField ID="hdfCompleteWorkMileage" runat="server" />
                    <asp:HiddenField ID="hdfCompleteWorkDescription" runat="server" />
                    <asp:HiddenField ID="hdfCompleteWorkPreventable" runat="server" />
                    <asp:HiddenField ID="hdfCompleteWorkLabourHours" runat="server" />
                    <asp:HiddenField ID="hdfCompleteWorkCosts" runat="server" />
                    <asp:HiddenField ID="hdfServiceState" runat="server" />
                    <asp:HiddenField ID="hdfInvoiceAmount" runat="server" />
                    <asp:HiddenField ID="hdfInvoiceNumber" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfCompanyLevel" runat="server" />
                    <asp:HiddenField ID="hdfState" runat="server" />
                    <asp:HiddenField ID="hdfServiceNumber" runat="server" />
                    <asp:HiddenField ID="hdfServiceDescription" runat="server" />
                    <asp:HiddenField ID="hdfNewServiceId" runat="server" />
                    <asp:HiddenField ID="hdfDashboard" runat="server" />
                    <asp:HiddenField ID="hdfRuleId" runat="server" />
                    <asp:HiddenField ID="hdfMileageUnitOfMeasurement" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>