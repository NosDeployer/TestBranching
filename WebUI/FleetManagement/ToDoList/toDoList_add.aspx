<%@ Page Language="C#" Title="LFS Live" MasterPageFile="../../mWizard2.Master" AutoEventWireup="true" Codebehind="toDoList_add.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.ToDoList.toDoList_add" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 350px">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard ID="wzToDoList" runat="server" Width="450px" Height="450px" ActiveStepIndex="0"
                        DisplayCancelButton="True" DisplaySideBar="False" SkinID="Wizard" OnActiveStepChanged="Wizard_ActiveStepChanged"
                        OnNextButtonClick="Wizard_NextButtonClick" OnCancelButtonClick="Wizard_CancelButtonClick"
                        OnFinishButtonClick="Wizard_FinishButtonClick" 
                        OnPreviousButtonClick="Wizard_PreviousButtonClick">
                        <WizardSteps>
                            <asp:WizardStep ID="StepBegin" runat="server" Title="Begin">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblSubject" runat="server" EnableViewState="False" 
                                                SkinID="Label" Text="Subject"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="tbxSubject" runat="server" 
                                                SkinID="TextBox" Style="width: 440px;"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:RequiredFieldValidator ID="rfvSubject" runat="server" ControlToValidate="tbxSubject"
                                                Display="Dynamic" EnableViewState="False" 
                                                ErrorMessage="Please provide a subject." SkinID="Validator" 
                                                ValidationGroup="Begin"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 7px">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblComments" runat="server" EnableViewState="False" 
                                                SkinID="Label" Text="Comments"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="tbxComment" runat="server" Rows="4" SkinID="TextBox" 
                                                Style="width: 440px" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:RequiredFieldValidator ID="rfvProblemDescription" runat="server" 
                                                ControlToValidate="tbxComment" Display="Dynamic" EnableViewState="False" 
                                                ErrorMessage="Please provide a comment" SkinID="Validator" 
                                                ValidationGroup="Begin"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 7px">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td style="width:225px">
                                            <asp:Label ID="lblDueDate" runat="server" EnableViewState="False" 
                                                SkinID="Label" Text="Due Date (Optional)"></asp:Label>
                                        </td>
                                        <td style="width:225px">
                                            <asp:Label ID="lblUnitID" runat="server" EnableViewState="False" SkinID="Label" 
                                                Text="Unit / Equipment (Optional)"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <telerik:RadDatePicker ID="tkrdpDueDate" runat="server" 
                                                Culture="English (United States)" SkinID="RadDatePicker" Width="140px">
                                                <calendar daynameformat="Short" showrowheaders="False" 
                                                    usecolumnheadersasselectors="False" userowheadersasselectors="False" 
                                                    viewselectortext="x">
                                                </calendar>
                                                <dateinput labelcssclass="" width="">
                                                </dateinput>
                                                <datepopupbutton cssclass="" hoverimageurl="" imageurl="" />
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlUnit" runat="server" DataMember="DefaultView" 
                                                DataSourceID="odsUnits" DataTextField="Description" DataValueField="UnitID" 
                                                SkinID="DropDownList" Style="width: 215px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 7px">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblAssignTo" runat="server" EnableViewState="False" 
                                                SkinID="Label" Text="Assign To"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 7px">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:RadioButton ID="rbtnAssignToMyself" runat="server" 
                                                AutoPostBack="True" Checked="True" GroupName="Begin" 
                                                SkinID="RadioButton" Text="Myself" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="height: 7px">
                                            </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:RadioButton ID="rbtnAssignToTeamMember" runat="server" 
                                                AutoPostBack="True" GroupName="Begin" SkinID="RadioButton" 
                                                Text="Team Member" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:DropDownList ID="ddlAssignToTeamMember" runat="server" 
                                                DataMember="DefaultView" DataSourceID="odsEmployee" 
                                                DataTextField="FullName" DataValueField="EmployeeID" SkinID="DropDownList" 
                                                Style="width: 440px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:CustomValidator ID="cvTeamMember" runat="server" 
                                                ControlToValidate="ddlAssignToTeamMember" Display="Dynamic" 
                                                ErrorMessage="Please select a team member." 
                                                OnServerValidate="cvTeamMember_ServerValidate" SkinID="Validator" 
                                                ValidationGroup="Begin"></asp:CustomValidator>
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
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Employees.EmployeeList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="employeeId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select a team member)" Name="fullName" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
        
        <!-- Page element: HiddenFields -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfUnitId" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfUnitCode" runat="server" />
                    <asp:HiddenField ID="hdfSubject" runat="server" />
                    <asp:HiddenField ID="hdfComments" runat="server" />
                    <asp:HiddenField ID="hdfDueDate" runat="server" />
                    <asp:HiddenField ID="hdfAssignToMyself" runat="server" />
                    <asp:HiddenField ID="hdfAssignToTeamMember" runat="server" />
                    <asp:HiddenField ID="hdfTeamMemberId" runat="server" />
                    <asp:HiddenField ID="hdfTeamMemberFullName" runat="server" />
                    <asp:HiddenField ID="hdfDashboard" runat="server" />
                    <asp:HiddenField ID="hdfToDoId" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
