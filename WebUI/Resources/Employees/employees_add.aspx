<%@ Page Language="C#" Title="LFS Live" MasterPageFile="./../../mWizard2.Master" AutoEventWireup="true" CodeBehind="employees_add.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Resources.Employees.employees_add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 350px">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard ID="wzTeamMember" runat="server" Width="350px" Height="300px" 
                        ActiveStepIndex="1" DisplayCancelButton="True" DisplaySideBar="False" SkinID="Wizard" 
                        OnActiveStepChanged="Wizard_ActiveStepChanged" 
                        OnNextButtonClick="Wizard_NextButtonClick" 
                        OnFinishButtonClick="Wizard_FinishButtonClick" 
                        OnCancelButtonClick="Wizard_CancelButtonClick" 
                        OnPreviousButtonClick="Wizard_PreviousButtonClick">
                        <WizardSteps>



                            <asp:WizardStep ID="StepBegin" runat="server" Title="Begin">
                                <asp:UpdatePanel ID="upnlUserErrorMessage" runat="server">
                                    <ContentTemplate>
                                    <table cellpadding="0" cellspacing="0"  style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblUsers" runat="server" SkinID="Label" Text="Users in iamatrenchlessexpert.com"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:DropDownList ID="ddlUsers" runat="server" SkinID="DropDownListLookup"
                                                    DataSourceID="odsUsers" Width="230px" DataValueField="LOGIN_ID" DataTextField="REAL_NAME"
                                                    OnSelectedIndexChanged="ddlUsersFooter_SelectedIndexChanged" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>                                            
                                                <asp:Label ID="lblUserErrorMessage" runat="server" SkinID="LabelError" Text="The user is already registered in LFS Live."></asp:Label>                                                                                                
                                            </td>
                                        </tr>
                                    </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepGeneralData" runat="server" Title="General Data">
                                <!-- Page element: General Data -->
                                <table cellpadding="0" cellspacing="0" style="width: 350px">
                                    <tr>
                                        <td style="width: 175px">
                                            <asp:Label ID="lblType" runat="server" EnableViewState="False" SkinID="Label" Text="Type"></asp:Label>
                                        </td>
                                        <td style="width: 175px">
                                            <asp:Label ID="lblState" runat="server" EnableViewState="False" SkinID="Label" Text="State"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <!-- Page element: UpdatePanel -->
                                            <asp:UpdatePanel ID="upnlType" runat="server">
                                                <ContentTemplate>
                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlType" runat="server" DataSourceID="odsType" DataTextField="Description"
                                                                        DataValueField="Type" SkinID="DropDownListLookup" Width="165px" OnSelectedIndexChanged="ddlType_SelectedIndexChanged"
                                                                        AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlState" runat="server" DataSourceID="odsState" DataTextField="Description"
                                                DataValueField="State" SkinID="DropDownListLookup" Width="165px">
                                            </asp:DropDownList>
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
                                            <asp:Label ID="lblCategory" runat="server" EnableViewState="False" SkinID="Label" Text="Category"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblJobClassType" runat="server" EnableViewState="False" SkinID="Label"
                                                Text="Job Class"></asp:Label>
                                        </td>                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlCategory" runat="server" DataSourceID="odsCategory" DataTextField="Category"
                                                DataValueField="Category" SkinID="DropDownListLookup" Width="165px">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <!-- Page element: UpdatePanel -->
                                            <asp:UpdatePanel ID="upnlJobClassType" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td>
                                                                    <asp:DropDownList Style="width: 165px" ID="ddlJobClassType" runat="server" SkinID="DropDownListLookup">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="vertical-align: middle">
                                                                    <asp:UpdateProgress ID="upJobClassType" runat="server" AssociatedUpdatePanelID="upnlType">
                                                                        <ProgressTemplate>
                                                                            <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                                        </ProgressTemplate>
                                                                    </asp:UpdateProgress>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlType" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="ddlCategory"
                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Please select a category."
                                                InitialValue="(Select a category)" SkinID="Validator" ValidationGroup="General"></asp:RequiredFieldValidator>
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
                                            <asp:Label ID="lblApproveTimesheets" runat="server" EnableViewState="False" SkinID="Label"
                                                Text="Approve Timesheets?"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblRequestTimesheet" runat="server" EnableViewState="False" SkinID="Label"
                                                Text="Request Timesheet?"></asp:Label>
                                        </td>                                                                                
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="ckbxApproveTimesheets" runat="server" SkinID="CheckBox" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ckbxRequestTimesheet" runat="server" SkinID="CheckBox" />
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
                                            <asp:Label ID="lblSalaried" runat="server" EnableViewState="False" SkinID="Label"
                                                Text="Salaried"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblAssignableSRS" runat="server" EnableViewState="False" SkinID="Label"
                                                Text="Assignable SR's"></asp:Label>
                                        </td>                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox ID="ckbxSalaried" runat="server" SkinID="CheckBox" />
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="ckbxAssignableSrs" runat="server" SkinID="CheckBox" />
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
                                            <asp:Label ID="lblVacationsManager" runat="server" EnableViewState="False" SkinID="Label"
                                                Text="Vacations Manager?"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblPersonalAgency" runat="server" EnableViewState="false" SkinID="Label" Text="Personnel Agency"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CheckBox runat="server" SkinID="CheckBox" ID="ckbxVacationsManager"></asp:CheckBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlPersonalAgency" runat="server" DataSourceID="odsPersonalAgency" DataTextField="PersonalAgencyName"
                                                DataValueField="PersonalAgencyName" SkinID="DropDownListLookup" Width="165px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                                                       
                        
                                                    
                           <asp:WizardStep ID="StepSummary" runat="server" StepType="Finish" Title="Summary">
                                <!-- Page element: Summary -->
                                <table cellpadding="0" cellspacing="0"  style="width: 100%">
                                    <tr>
                                        <td style="width: 100%">
                                            <asp:TextBox ID="tbxSummary" runat="server" Height="200px" Width="250px" ReadOnly="True"
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
                                            <asp:LinkButton ID="lkbtnOpenTeamMember" runat="server" SkinID="LinkButton" EnableViewState="False">Open the team member you just created</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lkbtnEditTeamMember" runat="server" SkinID="LinkButton">Edit the team member you just created</asp:LinkButton>
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
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsUsers" runat="server" SelectMethod="Load" TypeName="LiquiForce.LFSLive.DA.RAF.LoginListGateway"
                        OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>    
                    </asp:ObjectDataSource>
                        
                    <asp:ObjectDataSource ID="odsType" runat="server" SelectMethod="Load" TypeName="LiquiForce.LFSLive.DA.Resources.Employees.EmployeeTypeGateway"
                        OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
                        
                    <asp:ObjectDataSource ID="odsState" runat="server" SelectMethod="Load" TypeName="LiquiForce.LFSLive.DA.Resources.Employees.EmployeeStateGateway"
                        OldValuesParameterFormatString="original_{0}"></asp:ObjectDataSource>
                        
                    <asp:ObjectDataSource ID="odsCategory" runat="server" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.Employees.EmployeeCategoryList"
                        OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select a category)" Name="category" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsPersonalAgency" runat="server" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.Employees.PersonalAgencyList"
                        OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="" Name="personalAgencyName" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
        
        <!-- Page element: HiddenFields -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>                    
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />                    
                    <asp:HiddenField ID="hdfType" runat="server" />                    
                    <asp:HiddenField ID="hdfState" runat="server" />                    
                    <asp:HiddenField ID="hdfRequestTimesheet" runat="server" />                    
                    <asp:HiddenField ID="hdfSalaried" runat="server" />                    
                    <asp:HiddenField ID="hdfFirstName" runat="server" />                    
                    <asp:HiddenField ID="hdfLastName" runat="server" />                    
                    <asp:HiddenField ID="hdfMail" runat="server" />                    
                    <asp:HiddenField ID="hdfEmployeeId" runat="server" />                    
                    <asp:HiddenField ID="hdfAssignableSrs" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
