<%@ Page Language="C#" MasterPageFile="./../../mWizard2.Master" AutoEventWireup="true" CodeBehind="units_add.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_add" Title="LFS Live" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 740px;">
    
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard ID="wzUnitAdd" runat="server" Width="740px" Height="400px" ActiveStepIndex="0" DisplayCancelButton="True" DisplaySideBar="False" SkinID="Wizard" 
                        OnActiveStepChanged="Wizard_ActiveStepChanged" OnNextButtonClick="Wizard_NextButtonClick" OnFinishButtonClick="Wizard_FinishButtonClick" OnCancelButtonClick="Wizard_CancelButtonClick" OnPreviousButtonClick="Wizard_PreviousButtonClick">
                        
                        <WizardSteps>
                        
                            <asp:WizardStep ID="StepTypeInformation" runat="server" Title="Type">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td style="width: 100%">
                                            <asp:RadioButton ID="rbtnVehicle" runat="server" Text="Vehicle" Checked="True" GroupName="UnitType" SkinID="RadioButton" />
                                        </td>
                                    </tr>                                    
                                    <tr>
                                        <td style="width: 100%">
                                            <asp:RadioButton ID="rbtnEquipment" runat="server" Text="Equipment" GroupName="UnitType" SkinID="RadioButton" />
                                        </td>
                                    </tr>                                                                   
                                </table>
                            </asp:WizardStep>
    
    
                            
                            <asp:WizardStep ID="StepGeneralInformation" runat="server" Title="General Information">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td style=" width:185px">
                                            <asp:Label runat="server" ID="lblCode" SkinID="Label" Text="Code"></asp:Label>
                                        </td>
                                        <td style=" width:185px">
                                            <asp:Label runat="server" ID="lblDescription" SkinID="Label" Text="Description"></asp:Label>
                                        </td>
                                        <td style=" width:185px">                                            
                                        </td>
                                        <td style=" width:185px">
                                            <asp:Label runat="server" ID="lblVinSerialNumber" SkinID="Label" Text="VIN"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox runat="server" ID="tbxCode" SkinID="Textbox" Style="width: 175px"></asp:TextBox>
                                        </td>
                                        <td colspan="2">
                                            <asp:TextBox runat="server" ID="tbxDescription" SkinID="TextBox" Style="width: 360px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox runat="server" ID="tbxVinSerialNumber" SkinID="TextBox" Style="width: 175px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="tbxCode"
                                                Display="Dynamic" ErrorMessage="Please provide a code." SkinID="Validator"
                                                ValidationGroup="StepGeneralInformation" EnableViewState="False">
                                            </asp:RequiredFieldValidator>
                                            <asp:CustomValidator ID="cvCode" runat="server" ControlToValidate="tbxCode" Display="Dynamic"
                                                EnableViewState="False" ErrorMessage="Code for the unit is already in use. Please provide other code." 
                                                OnServerValidate="cvCode_ServerValidate" SkinID="Validator" ValidationGroup="StepGeneralInformation">
                                            </asp:CustomValidator>
                                        </td>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvDescription" runat="server" ControlToValidate="tbxDescription"
                                                Display="Dynamic" ErrorMessage="Please provide a description." SkinID="Validator"
                                                ValidationGroup="StepGeneralInformation" EnableViewState="False">
                                            </asp:RequiredFieldValidator>
                                        </td>                                       
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px;">
                                        </td>
                                    </tr>
                                    <tr>
                                         <td>
                                            <asp:Label runat="server" ID="lblManufacturer" SkinID="Label" Text="Manufacturer"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="lblModel" SkinID="Label" Text="Model"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="lblYear" SkinID="Label" Text="Year"></asp:Label>                                            
                                        </td>
                                        <td>
                                            <asp:Label runat="server" ID="lblIsTowable" SkinID="Label" Text="Is Towable?"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="tbxManufacturer" runat="server" SkinID="TextBox" Style="width: 175px" Autocomplete="Off"></asp:TextBox>
                                            <cc1:AutoCompleteExtender ID="aceManufacturer" runat="server" SkinID="AutoCompleteExtender" TargetControlID="tbxManufacturer" ServicePath="./wsUnits.asmx" ServiceMethod="GetManufacturerList" MinimumPrefixLength="2" CompletionSetCount="12" UseContextKey="True" DelimiterCharacters="" Enabled="True">
                                            </cc1:AutoCompleteExtender>
                                        </td> 
                                        <td>
                                            <asp:TextBox ID="tbxModel" runat="server" Style="width: 175px" SkinID="Textbox"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="tbxYear" runat="server" Style="width: 175px" SkinID="TextBox"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="cbxIsTowable" runat="server" SkinID="CheckBox" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td></td>
                                        <td>
                                            <asp:CustomValidator ID="cvForDateRange" runat="server" ControlToValidate="tbxYear" Display="Dynamic"
                                                EnableViewState="False" ErrorMessage="Invalid date. (use a date over 1900)" OnServerValidate="cvForDateRange_ServerValidate"
                                                SkinID="Validator" ValidateEmptyText="True"></asp:CustomValidator>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 30px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 2px" class="Background_Separator" colspan="4">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 10px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Label ID="lblCategory" runat="server" Text="Category" SkinID="Label"></asp:Label>
                                        </td>
                                        <td colspan="2">
                                            <asp:Label ID="lblCompanyLevel" runat="server" Text="Working Location" SkinID="Label"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:Panel ID="pnlCategories" Width="360px" Height="200px" runat="server" SkinID="Panel">
                                                <asp:TreeView ID="tvCategoriesRoot" runat="server" SkinID="SimpleTreeView">
                                                </asp:TreeView>
                                            </asp:Panel>
                                        </td>
                                        <td colspan="2">
                                            <asp:Panel ID="pnlCompanyLevels" Width="360px" Height="200px" runat="server" SkinID="Panel">
                                                <asp:TreeView ID="tvCompanyLevelsRoot" runat="server" SkinID="SimpleTreeView">                                                    
                                                </asp:TreeView>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">
                                            <asp:CustomValidator ID="cvCategories" runat="server" SkinID="Validator" Display="Dynamic" ErrorMessage="You must select at least one category."
                                            OnServerValidate="cvCategories_ServerValidate" ValidationGroup="StepGeneralInformation" ></asp:CustomValidator>
                                        </td>
                                        <td colspan="2">
                                            <asp:CustomValidator ID="cvCompanyLevels" runat="server" SkinID="Validator" Display="Dynamic" ErrorMessage="You can select only one company level leave."
                                            OnServerValidate="cvCompanyLevels_ServerValidate" ValidationGroup="StepGeneralInformation" ></asp:CustomValidator>
                                        </td>
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepVehicleInformation" runat="server" Title="Vehicle Information">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td style=" width:185px">
                                            <asp:Label ID="lblLicenseCountry" runat="server" SkinID="Label" Text="License Country"></asp:Label>
                                        </td>
                                        <td style=" width:185px">
                                            <asp:Label ID="lblLicenseState" runat="server" SkinID="Label" Text="License State"></asp:Label>
                                        </td>
                                        <td style=" width:185px">
                                        </td>
                                        <td style=" width:185px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="upnlCountry" runat="server">
                                                <contenttemplate>
                                                    <asp:DropDownList id="ddlLicenseCountry" runat="server" SkinID="DropDownList" Width="175px" OnSelectedIndexChanged="ddlLicenseCountry_SelectedIndexChanged" AutoPostBack="True">
                                                    </asp:DropDownList>
                                                </contenttemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td>
                                            <asp:UpdatePanel ID="upnlProvince" runat="server">
                                                <ContentTemplate>
                                                    <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                        <tbody>
                                                            <tr>
                                                                <td style="width: 175px">
                                                                    <asp:DropDownList ID="ddlLicenseState" runat="server" SkinID="DropDownList" Width="175px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td style="vertical-align: middle">
                                                                    <asp:UpdateProgress ID="upProvince" runat="server" AssociatedUpdatePanelID="upnlCountry">
                                                                        <ProgressTemplate>
                                                                            <asp:Image ID="imAjaxProvince" runat="server" SkinID="Ajax_White"></asp:Image>
                                                                        </ProgressTemplate>
                                                                    </asp:UpdateProgress>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="ddlLicenseCountry" EventName="SelectedIndexChanged">
                                                    </asp:AsyncPostBackTrigger>
                                                </Triggers>
                                            </asp:UpdatePanel>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblLicensePlateNumber" runat="server" SkinID="Label" Text="License Plate Number"></asp:Label>
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
                                            <asp:TextBox ID="tbxLicensePlateNumber" runat="server" SkinID="TextBox" Style="width: 360px"></asp:TextBox>
                                        </td>
                                        <td colspan="2">
                                        </td>                                        
                                    </tr>
                                    <tr>
                                        <td style="height: 7px;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblApportionedTagNumber" runat="server" SkinID="Label" Text="Apportioned Tag Number"></asp:Label>
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
                                            <asp:TextBox ID="tbxApportionedTagNumber" runat="server" SkinID="TextBox" Style="width: 360px"></asp:TextBox>
                                        </td>
                                        <td colspan="2">
                                        </td>                                        
                                    </tr>
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepChecklistRulesInformation" runat="server" Title="Checklist Rules Information">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td style=" width:185px"></td>
                                        <td style=" width:185px"></td>
                                        <td style=" width:185px"></td>
                                        <td style=" width:185px"></td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:GridView ID="grdChecklistRulesInformation" runat="server" AutoGenerateColumns="False" AllowPaging="True" PageSize="10" SkinID="GridView" Width="730px" OnDataBound="grdChecklistRulesInformation_DataBound" DataSourceID="odsChecklistRulesInformation" DataKeyNames="RuleID,Count" OnPageIndexChanging="grdChecklistRulesInformation_PageIndexChanging" DataMember="DefaultView" OnRowDataBound="grdChecklistRulesInformation_RowDataBound" >
                                                <Columns>
                                                    <asp:BoundField ReadOnly="True" DataField="RuleID" Visible="False" SortExpression="RuleID" HeaderText="RuleID"></asp:BoundField>
                                                    <asp:BoundField ReadOnly="True" DataField="Count" Visible="False" SortExpression="Count" HeaderText="Count"></asp:BoundField>
                                                    
                                                    <asp:TemplateField ShowHeader="False">
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <HeaderStyle Width="30px"></HeaderStyle>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="cbxSelected" runat="server" Checked='<%# Eval("Selected") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="Name">
                                                        <HeaderStyle Width="230px"></HeaderStyle>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblColumn" runat="server" Width="230px" Style="width: 230px" SkinID="Label" Text='<%# Bind("Name") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="Frequency">
                                                        <HeaderStyle Width="170px"></HeaderStyle>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFrequency" runat="server" Width="170px" Style="width: 170px" SkinID="Label" Text='<%# Bind("Frequency") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="Last Service">
                                                        <HeaderStyle Width="135px"></HeaderStyle>
                                                        <ItemTemplate>
                                                            <telerik:RadDatePicker ID="tkrdpLastService" runat="server" Width="135px" SkinID="RadDatePicker" DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "LastService") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                            </telerik:RadDatePicker>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="Next Due">
                                                        <HeaderStyle Width="135px"></HeaderStyle>
                                                        <ItemTemplate>
                                                            <telerik:RadDatePicker ID="tkrdpNextDue" runat="server" Width="135px" SkinID="RadDatePicker" DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "NextDue") %>' Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                            </telerik:RadDatePicker>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField HeaderText="Done">
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <HeaderStyle Width="30px"></HeaderStyle>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="cbxDone" runat="server" Checked='<%# Eval("Done") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                                                                  
                                                </Columns>
                                            </asp:GridView>                                            
                                        </td>                                        
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <asp:CustomValidator ID="cvGrdChecklistRulesInformation" runat="server" Display="Dynamic" 
                                            ErrorMessage="" OnServerValidate="cvGrdChecklistRulesInformation_ServerValidate" ValidationGroup="StepChecklistRulesInformation" SkinID="Validator">
                                            </asp:CustomValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4">
                                            <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:ObjectDataSource ID="odsChecklistRulesInformation" runat="server" SelectMethod="GetChecklistRulesInformation"
                                                            TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Units.units_add"></asp:ObjectDataSource>
                                                    </td>
                                                </tr>
                                            </table>    
                                        </td>
                                    </tr>                                
                                </table>
                            </asp:WizardStep>                         
                                                     
                                                     
                                                        
                            <asp:WizardStep ID="StepSummary" runat="server" StepType="Finish" Title="Summary">                            
                                
                                <!-- Page element: Summary -->
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td style="width: 100%">
                                            <asp:TextBox ID="tbxSummary" runat="server" Height="200px" Width="730px" ReadOnly="True" SkinID="TextBoxReadOnly" TextMode="MultiLine"></asp:TextBox>
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
                                            <asp:LinkButton ID="lkbtnOpenUnit" runat="server" SkinID="LinkButton" EnableViewState="False">Open the unit you just created</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:LinkButton ID="lkbtnEditUnit" runat="server" SkinID="LinkButton">Edit the unit you just created</asp:LinkButton>                                            
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