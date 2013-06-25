<%@ Page Language="C#" MasterPageFile="./../../mWizard2.Master" AutoEventWireup="true" CodeBehind="checklist_rules_add.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.ChecklistRules.checklist_rules_add" Title="LFS Live" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 550px;">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard ID="wzChecklistRulesAdd" runat="server" Width="550px" Height="360px" ActiveStepIndex="0" DisplayCancelButton="True" DisplaySideBar="False" SkinID="Wizard" 
                        OnActiveStepChanged="Wizard_ActiveStepChanged" OnNextButtonClick="Wizard_NextButtonClick" OnFinishButtonClick="Wizard_FinishButtonClick" OnCancelButtonClick="Wizard_CancelButtonClick" OnPreviousButtonClick="Wizard_PreviousButtonClick">
                        
                        <WizardSteps>
                        
                            <asp:WizardStep ID="StepGeneralInformation" runat="server" Title="General Information">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td style=" width:300px">
                                            <asp:Label runat="server" ID="lblName" SkinID="Label" Text="Name"></asp:Label>
                                        </td>
                                        <td style=" width:250px">
                                            <asp:Label runat="server" ID="lblMtoDot" SkinID="Label" Text="Fixed Date"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="tbxName" Width="290px" runat="server" SkinID="TextBox"></asp:TextBox>                                            
                                        </td>
                                        <td>
                                            <asp:CheckBox id="cbxMtoDot" runat="server" SkinID="CheckBox" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="tbxName"
                                                Display="Dynamic" ErrorMessage="Please provide a checklist rule name." SkinID="Validator"
                                                ValidationGroup="StepGeneralInformation" EnableViewState="False">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px;" colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblDescription" Text="Description" runat="server" SkinID="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:TextBox ID="tbxDescription" runat="server" Height="80px" Width="400px" SkinID="TextBox" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepSchedulingOptions" runat="server" Title="Scheduling Options">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td style=" width:300px">
                                            <asp:Label runat="server" ID="lblFrequency" SkinID="Label" Text="Frequency"></asp:Label>
                                        </td>                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlFrequency" runat="server" Width="290px" SkinID="DropDownList">
                                            </asp:DropDownList>
                                        </td>                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvFrequency" runat="server" ControlToValidate="ddlFrequency"
                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Please select a frequency."
                                                InitialValue="(Select a frequency)" SkinID="Validator" ValidationGroup="StepSchedulingOptions" Width="290px">
                                            </asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px;">
                                        </td>
                                    </tr>                                    
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblGenerateServiceRequest" Text="Generate Service Request?" runat="server" SkinID="Label"></asp:Label>
                                        </td>                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            <table cellpadding="0" cellspacing="0" width="0" style="width: 120px">
                                                <tr>
                                                    <td style=" width: 50px;">
                                                        <asp:TextBox runat="server" ID="tbxServicesRequestDaysBefore" SkinID="textbox" Width="40px"></asp:TextBox>
                                                    </td>
                                                    <td style=" width: 70px;">
                                                        <asp:Label runat="server" ID="lblServicesRequestDaysBefore" SkinID="Label" Text="days before"></asp:Label>
                                                    </td>                                                    
                                                </tr>
                                            </table>                                            
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table cellpadding="0" cellspacing="0" width="0" style="width: 120px">
                                                <tr>
                                                    <td style=" width: 120px;">
                                                        <asp:CustomValidator ID="cvServicesRequestDaysBefore" runat="server" ControlToValidate="tbxServicesRequestDaysBefore" Display="Dynamic" OnServerValidate="cvServicesRequestDaysBefore_ServerValidate" 
                                                            SkinID="Validator" ValidationGroup="StepSchedulingOptions" ValidateEmptyText="true">
                                                        </asp:CustomValidator>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                                                        
                                                        
                            <asp:WizardStep ID="StepCompanyLevels" runat="server" Title="Company Levels">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lblCompanyLevel" SkinID="Label" Text="Working Location"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlCompanyLevels" Width="500px" Height="300px" runat="server" SkinID="Panel">
                                                <asp:TreeView ID="tvCompanyLevelsRoot" runat="server" SkinID="SimpleTreeView" onclick="return OnTreeClick(event);">                                                    
                                                </asp:TreeView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CustomValidator ID="cvCompanyLevels" runat="server" SkinID="Validator" Display="Dynamic" ErrorMessage="You must select at least one company level."
                                                OnServerValidate="cvCompanyLevels_ServerValidate" ValidationGroup="StepCompanyLevels">
                                            </asp:CustomValidator>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepCategories" runat="server" Title="Categories">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lblCategory" SkinID="Label" Text="Category"></asp:Label>
                                        </td>                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlCategories" Width="500px" Height="300px" runat="server" SkinID="Panel">
                                                <asp:TreeView ID="tvCategoriesRoot" runat="server" SkinID="SimpleTreeView" onclick="return OnTreeClick(event);">
                                                </asp:TreeView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CustomValidator ID="cvCategories" runat="server" SkinID="Validator" Display="Dynamic" ErrorMessage="You must select at least one category."
                                                OnServerValidate="cvCategories_ServerValidate" ValidationGroup="StepCategories">
                                            </asp:CustomValidator>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepUnits" runat="server" Title="Units">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lblUnits" SkinID="Label" Text="Units"></asp:Label>
                                        </td>                                        
                                    </tr>                                    
                                    <tr>
                                        <td>
                                            <table border="0" cellpadding="0" cellspacing="0" width="365px">
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <asp:Panel ID="pnlUnits" runat="server"  SkinID="Panel" Width="500px" Height="300px">
                                                                <asp:CheckBoxList ID="cbxlUnitsSelected" runat="server"   SkinID="CheckBoxListWithoutBorder" >
                                                                </asp:CheckBoxList>
                                                            </asp:Panel>
                                                        </td>                                                        
                                                </tbody>
                                            </table>                                                
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:CustomValidator ID="cvUnits" runat="server" SkinID="Validator" Display="Dynamic" ErrorMessage="You must select at least one unit."
                                                OnServerValidate="cvUnits_ServerValidate" ValidationGroup="StepUnits">
                                            </asp:CustomValidator>
                                        </td>
                                    </tr>                                  
                                    <tr>
                                        <td>
                                            <asp:Label runat="server" ID="lblTotalUnits" SkinID="Label" Text="Units"></asp:Label>
                                        </td>                                        
                                    </tr>
                                </table>
                            </asp:WizardStep>
                         
                                                        
                                                        
                                                        
                            <asp:WizardStep ID="StepSummary" runat="server" StepType="Finish" Title="Summary">                            
                                <!-- Page element: Summary -->
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td style="width: 100%">
                                            <asp:TextBox ID="tbxSummary" runat="server" Height="200px" Width="500px" ReadOnly="True" SkinID="TextBoxReadOnly" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px;">
                                        </td>
                                    </tr>
                                </table>                                                          
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepFinalStep" runat="server" Title="Final Step" StepType="Complete">
                                <!-- Page element: Final Steps -->
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lkbtnOpenUnit" runat="server" SkinID="LinkButton" EnableViewState="False">Open the checklist rule you just created</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lkbtnEditUnit" runat="server" SkinID="LinkButton">Edit the checklist rule you just created</asp:LinkButton>                                            
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
        
        <!-- Page element: Data objects -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>                                    
                    <asp:ObjectDataSource ID="odsUnits" runat="server" SelectMethod="LoadAndAddItemByCategory"
                        TypeName="LiquiForce.LFSLive.BL.FleetManagement.Units.Unitslist" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="Flusher Truck" Name="category" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />                            
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>    
        
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfUpdate" runat="server" />                    
                </td>
            </tr>
        </table>
    </div>
</asp:Content>