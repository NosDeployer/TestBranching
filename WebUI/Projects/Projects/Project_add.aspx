<%@ Page Language="C#" MasterPageFile="../../mWizard2.Master" AutoEventWireup="true" Codebehind="Project_add.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Projects.Projects.Project_add" Title="LFS Live"%>
   
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 470px;">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td style="width: 450px">
                    <asp:Wizard ID="Wizard" runat="server" ActiveStepIndex="1" DisplayCancelButton="True"
                        DisplaySideBar="False" Height="220px" Width="100%" SkinID="Wizard" OnActiveStepChanged="Wizard_ActiveStepChanged"
                        OnNextButtonClick="Wizard_NextButtonClick" OnFinishButtonClick="Wizard_FinishButtonClick"
                        OnCancelButtonClick="Wizard_CancelButtonClick" 
                        OnPreviousButtonClick="Wizard_PreviousButtonClick">
                        <WizardSteps>
                            <asp:WizardStep ID="TypeOfProject" runat="server" Title="Type Of Project">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td style="width: 520px">
                                            <asp:RadioButton ID="rbtnBallpark" SkinID="RadioButton" GroupName="rbtnProjects" Text="Ballpark" Checked="True" runat="server" TabIndex="1" />  
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="rbtnProposal" SkinID="RadioButton" GroupName="rbtnProjects" Text="Proposal" runat="server" TabIndex="2" />  
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RadioButton ID="rbtnInternalProject" SkinID="RadioButton" GroupName="rbtnProjects" Text="Internal Project" runat="server" TabIndex="3" /> 
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="Location" runat="server" Title="Location">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 450px">
                                    <tr>
                                        <td style="width: 225px">
                                            <asp:Label ID="lblCountry" runat="server" SkinID="Label" Text="Country" EnableViewState="False"></asp:Label>
                                        </td>
                                        <td style="width: 225px">
                                            <asp:Label ID="lblProvince" runat="server" SkinID="Label" Text="Province/State" EnableViewState="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="upnlCountry" runat="server">
                                                <contenttemplate>
                                                    <asp:DropDownList id="ddlCountry" tabIndex="1" runat="server" SkinID="DropDownList" Width="215px" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" EnableTheming="True" AutoPostBack="True">
                                                    </asp:DropDownList> 
                                                </contenttemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td >
                                            <asp:UpdatePanel ID="upnlProvince" runat="server">
                                                <contenttemplate>
                                                    <TABLE cellspacing="0" cellpadding="0" width="100%" border="0">
                                                        <TBODY>
                                                            <TR>
                                                                <TD style="WIDTH: 215px">
                                                                    <asp:DropDownList id="ddlProvince" tabIndex="2" runat="server" SkinID="DropDownList" Width="215px" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged" AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                </TD>
                                                                <TD style="VERTICAL-ALIGN: middle">
                                                                    <asp:UpdateProgress id="upProvince" runat="server" AssociatedUpdatePanelID="upnlCountry">
                                                                        <ProgressTemplate>
                                                                            <asp:Image id="imAjaxProvince" runat="server" skinId="Ajax_White"></asp:Image> 
                                                                        </ProgressTemplate>
                                                                    </asp:UpdateProgress>
                                                                </TD>
                                                           </TR>
                                                        </TBODY>
                                                     </TABLE>
                                                </contenttemplate>
                                                <triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlCountry" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                </triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvCountry" runat="server" ControlToValidate="ddlCountry"
                                                Display="Dynamic" ErrorMessage="Please select a country." InitialValue="-1" SkinID="Validator"
                                                ValidationGroup="Location" EnableViewState="False"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvProvince" runat="server" ControlToValidate="ddlProvince"
                                            Display="Dynamic" ErrorMessage="Please select a province." InitialValue="-1" SkinID="Validator"
                                            ValidationGroup="Location" EnableViewState="False"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCounty" runat="server" SkinID="Label" Text="County" EnableViewState="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblCity" runat="server" SkinID="Label" Text="City" EnableViewState="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                       <td>
                                            <asp:UpdatePanel ID="upnlCounty" runat="server">
                                                <contenttemplate>
<TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="WIDTH: 215px"><asp:DropDownList id="ddlCounty" tabIndex="2" runat="server" SkinID="DropDownList" Width="215px" OnSelectedIndexChanged="ddlCounty_SelectedIndexChanged" AutoPostBack="True">
                                                                    </asp:DropDownList> </TD><TD style="VERTICAL-ALIGN: middle"><asp:UpdateProgress id="upCounty" runat="server" AssociatedUpdatePanelID="upnlProvince"><ProgressTemplate>
<asp:Image id="imAjaxCounty" runat="server" skinId="Ajax_White"></asp:Image> 
</ProgressTemplate>
</asp:UpdateProgress> </TD></TR></TBODY></TABLE>
</contenttemplate>
                                                <triggers>
<asp:AsyncPostBackTrigger ControlID="ddlProvince" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
</triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td>
                                            <asp:UpdatePanel ID="upnlCity" runat="server">
                                                <contenttemplate>
<TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="WIDTH: 215px"><asp:DropDownList id="ddlCity" tabIndex="2" runat="server" SkinID="DropDownList" Width="215px">
                                                                    </asp:DropDownList> </TD><TD style="VERTICAL-ALIGN: middle"><asp:UpdateProgress id="upCity" runat="server" AssociatedUpdatePanelID="upnlCounty"><ProgressTemplate>
<asp:Image id="imAjaxCity" runat="server" skinId="Ajax_White"></asp:Image> 
</ProgressTemplate>
</asp:UpdateProgress> </TD></TR></TBODY></TABLE>
</contenttemplate>
                                                <triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlCounty" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                </triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvCounty" runat="server" ControlToValidate="ddlCounty"
                                            Display="Dynamic" ErrorMessage="Please select a county." InitialValue="-1" SkinID="Validator"
                                            ValidationGroup="Location" EnableViewState="False"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="RrfvCity" runat="server" ControlToValidate="ddlCity"
                                            Display="Dynamic" ErrorMessage="Please select a city." InitialValue="-1" SkinID="Validator"
                                            ValidationGroup="Location" EnableViewState="False"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px" colspan="2">
                                        </td>
                                    </tr>                                
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblOffice" runat="server" SkinID="Label" Text="Office" EnableViewState="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:UpdatePanel ID="upnlOffice" runat="server">
                                                <contenttemplate>
                                                    <TABLE cellspacing="0" cellpadding="0" width="100%" border="0">
                                                        <TBODY>
                                                            <TR>
                                                                <TD style="WIDTH: 275px">
                                                                    <asp:DropDownList id="ddlOffice" tabIndex=2 runat="server" 
                                                                        SkinID="DropDownList" Width="440px">
                                                                    </asp:DropDownList> 
                                                                </TD>
                                                                <TD style="VERTICAL-ALIGN: middle">
                                                                    <asp:UpdateProgress id="upOffice" runat="server" AssociatedUpdatePanelID="upnlCountry">
                                                                        <ProgressTemplate>
                                                                            <asp:Image id="imAjaxOffice" runat="server" skinId="Ajax_White"></asp:Image> 
                                                                        </ProgressTemplate>
                                                                    </asp:UpdateProgress> 
                                                                </TD>
                                                            </TR>
                                                        </TBODY>
                                                    </TABLE>
                                                </contenttemplate>
                                                <triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlCountry" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                </triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvOffice" runat="server" ControlToValidate="ddlOffice"
                                            Display="Dynamic" ErrorMessage="Please select an office." InitialValue="-1" SkinID="Validator"
                                            ValidationGroup="Location" EnableViewState="False"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="BallparkProjectSummary" runat="server" Title="Ballpark Project Summary">
                                <table border="0" cellpadding="0" cellspacing="0" id="TABLE1" width="100%">
                                    <tr>
                                        <td style="width: 225px">
                                            <asp:Label ID="lblBallparkProjectClient" runat="server" SkinID="Label" Text="Client" EnableViewState="False"></asp:Label>
                                        </td>
                                        <td style="width: 125px">
                                        </td>
                                        <td style="width: 100px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:UpdatePanel ID="uplBallparkProjectClient" runat="server">
                                                <contenttemplate>
                                                    <asp:DropDownList ID="ddlBallparkProjectClient" runat="server" Width="340px" 
                                                        SkinID="DropDownList" TabIndex="1">
                                                    </asp:DropDownList>
                                                </contenttemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnAddCompanyBallpark" runat="server" EnableViewState="False" 
                                                OnClick="btnAddCompany_Click" SkinID="Button" Text="Add Company" 
                                                Width="90px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:RequiredFieldValidator ID="rfvBallparkProjectClient" runat="server" ControlToValidate="ddlBallparkProjectClient"
                                                Display="Dynamic" ErrorMessage="Please select a client." InitialValue="-1" SkinID="Validator"
                                                ValidationGroup="BallparkProjectSummary" EnableViewState="False"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px;" colspan="3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblBallparkProjectName" runat="server" SkinID="Label" Text="Ballpark Name"
                                            EnableViewState="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBallparkProjectDate" runat="server" SkinID="Label" Text="Ballpark Date"
                                           EnableViewState="False"></asp:Label>
                                        </td>
                                        <td>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="tbxBallparkProjectName" runat="server" Width="215px"
                                            SkinID="TextBox" TabIndex="2"></asp:TextBox>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="tkrdpBallparkProjectDate" runat="server" 
                                                Width="115px" TabIndex="3" SkinID="RadDatePicker" 
                                                Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" DayNameFormat="Short" ShowRowHeaders="False" ViewSelectorText="x"></Calendar>

<DateInput TabIndex="3" Width="" LabelCssClass=""></DateInput>

<DatePopupButton CssClass="" ImageUrl="" HoverImageUrl="" TabIndex="3"></DatePopupButton>
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvBallparkProjectName" runat="server" ControlToValidate="tbxBallparkProjectName"
                                                Display="Dynamic" ErrorMessage="Please provide a ballpark name." SkinID="Validator"
                                                ValidationGroup="BallparkProjectSummary" EnableViewState="False">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px;" colspan="3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblBallparkProjectDescription" runat="server" SkinID="Label" Text="Description"
                                                EnableViewState="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblBallparkProjectPotentialStartDate" runat="server" SkinID="Label" Text="Potential Start Date"
                                                EnableViewState="False"></asp:Label>
                                        </td>
                                        <td>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td rowspan="4" valign="top">
                                            <asp:TextBox ID="tbxBallparkProjectDescription" runat="server" Height="69px" Width="215px" SkinID="TextBox" TextMode="MultiLine" TabIndex="4"></asp:TextBox>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="tkrdpBallparkProjectPotentialStartDate" 
                                                runat="server" Width="115px" TabIndex="5" SkinID="RadDatePicker" 
                                                Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" DayNameFormat="Short" ShowRowHeaders="False" ViewSelectorText="x"></Calendar>

<DateInput TabIndex="5" Width="" LabelCssClass=""></DateInput>

<DatePopupButton CssClass="" ImageUrl="" HoverImageUrl="" TabIndex="5"></DatePopupButton>
                                            </telerik:RadDatePicker>
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
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblBallparkProjectPotentialEndDate" runat="server" SkinID="Label" Text="Potential End Date"
                                                EnableViewState="False"></asp:Label>
                                        </td>
                                        <td>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <telerik:RadDatePicker ID="tkrdpBallparkProjectPotentialEndDate" runat="server" 
                                                Width="115px" TabIndex="6" SkinID="RadDatePicker" 
                                                Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" DayNameFormat="Short" ShowRowHeaders="False" ViewSelectorText="x"></Calendar>

<DateInput TabIndex="6" Width="" LabelCssClass=""></DateInput>

<DatePopupButton CssClass="" ImageUrl="" HoverImageUrl="" TabIndex="6"></DatePopupButton>
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="ProposalSummary" runat="server" Title="Proposal Summary">
                                <table border="0" cellpadding="0" cellspacing="0" id="TABLE2" width="100%">
                                    <tr>
                                        <td style="width: 225px;">
                                            <asp:Label ID="lblProposalClient" runat="server" SkinID="Label" Text="Client" EnableViewState="False"></asp:Label>
                                        </td>
                                        <td style="width: 125px;">
                                            <asp:Label ID="lblProposalClientProjectNumber" runat="server" 
                                                SkinID="LabelSmall" Text="Client Project Number"
                                                EnableViewState="False"></asp:Label>
                                        </td>
                                        <td style="width: 100px;">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="uplProposalClient" runat="server">
                                                <contenttemplate>
                                                    <asp:DropDownList ID="ddlProposalClient" runat="server" Width="215px" SkinID="DropDownList" TabIndex="1">
                                                    </asp:DropDownList>
                                                </contenttemplate>
                                            </asp:UpdatePanel>    
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxClientProposalNumber" runat="server" Width="115px" 
                                                SkinID="TextBox" TabIndex="2"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnAddCompanyProposal" runat="server" EnableViewState="False" 
                                                OnClick="btnAddCompany_Click" SkinID="Button" Text="Add Company" 
                                                Width="90px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvProposalClient" runat="server" ControlToValidate="ddlProposalClient"
                                                Display="Dynamic" ErrorMessage="Please select a client." InitialValue="-1" SkinID="Validator"
                                                ValidationGroup="ProposalSummary" EnableViewState="False"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px;" colspan="3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblProposalName" runat="server" SkinID="Label" Text="Proposal Name"
                                                EnableViewState="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblProposalDate" runat="server" SkinID="Label" Text="Proposal Date"
                                                EnableViewState="False"></asp:Label>
                                        </td>
                                        <td>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="tbxProposalName" runat="server" Width="215px"
                                                SkinID="TextBox" TabIndex="3"></asp:TextBox>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="tkrdpProposalDate" runat="server" Width="115px" 
                                                TabIndex="4" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" 
                                                Calendar-DayNameFormat="Short">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" DayNameFormat="Short" ShowRowHeaders="False" ViewSelectorText="x"></Calendar>

<DateInput TabIndex="4" Width="" LabelCssClass=""></DateInput>

<DatePopupButton CssClass="" ImageUrl="" HoverImageUrl="" TabIndex="4"></DatePopupButton>
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvProposalName" runat="server" ControlToValidate="tbxProposalName"
                                                Display="Dynamic" ErrorMessage="Please provide a proposal name." SkinID="Validator"
                                                ValidationGroup="ProposalSummary" EnableViewState="False"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" style="height: 7px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblProposalDescription" runat="server" SkinID="Label" Text="Description"
                                                EnableViewState="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblProposalPotencialStartDate" runat="server" 
                                                SkinID="LabelSmall" Text="Potential Start Date"
                                                EnableViewState="False"></asp:Label>
                                        </td>
                                        <td>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td rowspan="4" valign="top">
                                            <asp:TextBox ID="tbxProposalDescription" runat="server" Height="69px"
                                                Width="215px" SkinID="TextBox" TextMode="MultiLine" TabIndex="5"></asp:TextBox>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="tkrdpProposalPotencialStartDate" runat="server" 
                                                Width="115px" TabIndex="6" SkinID="RadDatePicker" 
                                                Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" DayNameFormat="Short" ShowRowHeaders="False" ViewSelectorText="x"></Calendar>

<DateInput TabIndex="6" Width="" LabelCssClass=""></DateInput>

<DatePopupButton CssClass="" ImageUrl="" HoverImageUrl="" TabIndex="6"></DatePopupButton>
                                            </telerik:RadDatePicker>
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
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblProposalPotencialEndDate" runat="server" SkinID="LabelSmall" Text="Potential End Date"
                                                EnableViewState="False"></asp:Label>
                                        </td>
                                        <td>
                                            </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <telerik:RadDatePicker ID="tkrdpProposalPotencialEndDate" runat="server" 
                                                Width="115px" TabIndex="7" SkinID="RadDatePicker" 
                                                Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
<Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" DayNameFormat="Short" ShowRowHeaders="False" ViewSelectorText="x"></Calendar>

<DateInput TabIndex="7" Width="" LabelCssClass=""></DateInput>

<DatePopupButton CssClass="" ImageUrl="" HoverImageUrl="" TabIndex="7"></DatePopupButton>
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="InternalProjectSummary" runat="server" Title="Internal Project Summary">
                                <table border="0" cellpadding="0" cellspacing="0" id="TABLE3" width="100%">
                                    <tr>
                                        <td style="width: 225px">
                                            <asp:Label ID="lblInternalProjectClient" runat="server" SkinID="Label" Text="Client" EnableViewState="False"></asp:Label>
                                        </td>
                                        <td style="width: 125px">
                                            </td>
                                        <td style="width: 100px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <contenttemplate>
                                                    <asp:DropDownList ID="ddlInternalProjectClient" runat="server" Width="340px" 
                                                        SkinID="DropDownList" TabIndex="1">
                                            </asp:DropDownList>
                                                </contenttemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td>
                                            <asp:Button ID="btnAddCompanyInternalProject" runat="server" EnableViewState="False" 
                                                OnClick="btnAddCompany_Click" SkinID="Button" Text="Add Company" 
                                                Width="90px" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvInternalProjectClient" runat="server" ControlToValidate="ddlInternalProjectClient"
                                                Display="Dynamic" ErrorMessage="Please select a client." InitialValue="-1" SkinID="Validator"
                                                ValidationGroup="InternalProjectSummary" EnableViewState="False"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            </td>
                                        <td >
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px;" colspan="3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblInternaProjectName" runat="server" EnableViewState="False" 
                                                SkinID="Label" Text="Internal Project Name"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblInternalProjectDate" runat="server" EnableViewState="False" 
                                                SkinID="Label" Text="Internal Project Date"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="tbxInternalProjectName" runat="server" SkinID="TextBox" 
                                                TabIndex="2" Width="215px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <telerik:RadDatePicker ID="tkrdpInternalProjectDate" runat="server" 
                                                SkinID="RadDatePicker" TabIndex="3" 
                                                Width="102px">
                                                <calendar daynameformat="Short" showrowheaders="False" 
                                                    usecolumnheadersasselectors="False" userowheadersasselectors="False" 
                                                    viewselectortext="x">
                                                </calendar>
                                                <dateinput labelcssclass="" tabindex="3" width="">
                                                </dateinput>
                                                <datepopupbutton cssclass="" hoverimageurl="" imageurl="" tabindex="3" />
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvnternalProjectName" runat="server" ControlToValidate="tbxInternalProjectName"
                                                Display="Dynamic" ErrorMessage="Please provide an internal project name." SkinID="Validator"
                                                ValidationGroup="InternalProjectSummary" EnableViewState="False"></asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            </td>
                                        <td >
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px" colspan="3">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblInternalProjectDescription" runat="server" SkinID="Label" Text="Description" EnableViewState="False"></asp:Label>
                                        </td>
                                        <td>
                                            </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="tbxInternalProjectDescription" runat="server" Height="69px"
                                                Width="340px" SkinID="TextBox" TextMode="MultiLine" TabIndex="4"></asp:TextBox>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px;" colspan="3">
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="Resources" runat="server" Title="Resources" StepType="Finish">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%" id="TABLE10">
                                    <tr>
                                        <td style="width: 330px">
                                            <asp:Label ID="lblProjectLead" runat="server" SkinID="Label" Text="Project Lead"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlProjectLead" runat="server" Width="220px" SkinID="DropDownList" TabIndex="1">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblSalesman" runat="server" SkinID="Label" Text="Salesman"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlSalesman" runat="server" Width="220px" SkinID="DropDownList" TabIndex="2">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvSalesman" runat="server" ControlToValidate="ddlSalesman"
                                            Display="Dynamic" ErrorMessage="Please select a salesman." InitialValue="-1" SkinID="Validator"
                                            ValidationGroup="Resources" EnableViewState="False"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px;">
                                        </td>
                                    </tr>
                                </table>                               
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="FinishOptions" runat="server" Title="Finish Options" StepType="Complete">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lkbtnOpenProject" runat="server" SkinID="LinkButton" EnableViewState="False">Open the project you just created</asp:LinkButton>                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lkbtnEditProject" runat="server" SkinID="LinkButton">Edit the project you just created</asp:LinkButton>                                            
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
                    </asp:Wizard>
                </td>
            </tr>
        </table>
    </div>
    
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td>
                <asp:HiddenField ID="hdfCompanyId" runat="server" />
            </td>
        </tr>
    </table>
</asp:Content>