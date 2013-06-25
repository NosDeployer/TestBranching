<%@ Page Title="LFS Live" Language="C#" MasterPageFile="~/mWizard2.Master" AutoEventWireup="true" CodeBehind="comments_migration.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.comments_migration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 350px">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard ID="wzCommentsMigration" runat="server" Width="450px" Height="450px" ActiveStepIndex="0"
                        DisplayCancelButton="True" DisplaySideBar="False" SkinID="Wizard" OnActiveStepChanged="Wizard_ActiveStepChanged"
                        OnNextButtonClick="Wizard_NextButtonClick" OnCancelButtonClick="Wizard_CancelButtonClick"
                        OnFinishButtonClick="Wizard_FinishButtonClick" 
                        OnPreviousButtonClick="Wizard_PreviousButtonClick">
                        <WizardSteps>
                            <asp:WizardStep ID="StepBegin" runat="server" Title="Begin">
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblSelectAParentProject" runat="server" SkinID="LabelTitle2" Text="Please select the parent project"
                                                EnableViewState="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 10px">
                                        </td>
                                    </tr>
                                </table>
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td style="width: 200px">
                                            <asp:Label ID="lblParentClient" runat="server" EnableViewState="False" SkinID="Label"
                                                Text="Client"></asp:Label>
                                        </td>
                                        <td style="width: 200px">
                                            <asp:Label ID="lblParentProject" runat="server" EnableViewState="False" SkinID="Label"
                                                Text="Project"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="upnlParentClient" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlParentClient" runat="server" SkinID="DropDownListLookup"
                                                        Width="190px" OnSelectedIndexChanged="ddlParentClient_SelectedIndexChanged" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td>
                                            <asp:UpdatePanel ID="upnlParentProject" runat="server">
                                                <ContentTemplate>
                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 190px">
                                                                    <asp:DropDownList ID="ddlParentProject" runat="server" SkinID="DropDownListLookup"
                                                                        Width="220px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="vertical-align: middle">
                                                                    <asp:UpdateProgress ID="upParentProject" runat="server" AssociatedUpdatePanelID="upnlParentClient">
                                                                        <ProgressTemplate>
                                                                            <asp:Image ID="imParentAjax" runat="server" SkinID="Ajax_Grey"></asp:Image>
                                                                        </ProgressTemplate>
                                                                    </asp:UpdateProgress>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlParentClient" EventName="SelectedIndexChanged">
                                                    </asp:AsyncPostBackTrigger>
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvParentClient" runat="server" ControlToValidate="ddlParentClient"
                                                EnableViewState="False" ErrorMessage="Please select a client." InitialValue="-1" ValidationGroup="Begin"
                                                SkinID="Validator">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvParentProject" runat="server" ControlToValidate="ddlParentProject"
                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Please select a project." ValidationGroup="Begin"
                                                InitialValue="-1" SkinID="Validator">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 7px">
                                        </td>
                                    </tr>
                                </table>
                                
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblSelectAChildProject" runat="server" SkinID="LabelTitle2" Text="Please select the child project"
                                                EnableViewState="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 10px">
                                        </td>
                                    </tr>
                                </table>
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                    <tr>
                                        <td style="width: 200px">
                                            <asp:Label ID="lblChildClient" runat="server" EnableViewState="False" SkinID="Label"
                                                Text="Client"></asp:Label>
                                        </td>
                                        <td style="width: 200px">
                                            <asp:Label ID="lblChildProject" runat="server" EnableViewState="False" SkinID="Label"
                                                Text="Project"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="upnlChildClient" runat="server">
                                                <ContentTemplate>
                                                    <asp:DropDownList ID="ddlChildClient" runat="server" SkinID="DropDownListLookup"
                                                        Width="190px" OnSelectedIndexChanged="ddlChildClient_SelectedIndexChanged" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td>
                                            <asp:UpdatePanel ID="upnlChildProject" runat="server">
                                                <ContentTemplate>
                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 190px">
                                                                    <asp:DropDownList ID="ddlChildProject" runat="server" SkinID="DropDownListLookup"
                                                                        Width="220px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="vertical-align: middle">
                                                                    <asp:UpdateProgress ID="upChildProject" runat="server" AssociatedUpdatePanelID="upnlChildClient">
                                                                        <ProgressTemplate>
                                                                            <asp:Image ID="imChildAjax" runat="server" SkinID="Ajax_Grey"></asp:Image>
                                                                        </ProgressTemplate>
                                                                    </asp:UpdateProgress>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlChildClient" EventName="SelectedIndexChanged">
                                                    </asp:AsyncPostBackTrigger>
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvChildClient" runat="server" ControlToValidate="ddlChildClient"
                                                EnableViewState="False" ErrorMessage="Please select a client." InitialValue="-1" ValidationGroup="Begin"
                                                SkinID="Validator">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvChildProject" runat="server" ControlToValidate="ddlChildProject"
                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Please select a project." ValidationGroup="Begin"
                                                InitialValue="-1" SkinID="Validator">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 7px">
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>                                                                                                         
                            
                            
                            
                            <asp:WizardStep ID="StepSummary" runat="server" StepType="Finish" Title="Summary">
                                <!-- Page element: Summary -->
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td style="width: 100%">
                                            <asp:TextBox ID="tbxSummary" runat="server" Height="380px" Width="440px" ReadOnly="True"
                                                SkinID="TextBoxReadOnly" TextMode="MultiLine"></asp:TextBox>
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
                    
                </td>
            </tr>
        </table>
        
        <!-- Page element: HiddenFields -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfTag" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>