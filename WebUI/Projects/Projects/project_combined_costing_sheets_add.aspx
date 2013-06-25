<%@ Page Title="LFS Live" Language="C#" MasterPageFile="~/mWizard2.Master" AutoEventWireup="true" CodeBehind="project_combined_costing_sheets_add.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.Projects.Projects.project_combined_costing_sheets_add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 740px;">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="upnlProject" runat="server">
                        <ContentTemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:Wizard ID="wzProjectCostinsSheetsAdd" runat="server" Width="910px" Height="450px"
                                                ActiveStepIndex="2" DisplayCancelButton="True" DisplaySideBar="False" SkinID="Wizard"
                                                OnActiveStepChanged="Wizard_ActiveStepChanged" OnNextButtonClick="Wizard_NextButtonClick"
                                                OnFinishButtonClick="Wizard_FinishButtonClick" OnCancelButtonClick="Wizard_CancelButtonClick"
                                                OnPreviousButtonClick="Wizard_PreviousButtonClick">
                                                <WizardSteps>
                                                
                                                    <asp:WizardStep ID="StepBegin" runat="server" Title="Begin" StepType="Start">
                                                    <!-- Page element: 1 column -->
                                                    <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                        <tr>
                                                            <td>
                                                                <asp:RadioButton ID="rbtnBeginNew" runat="server" Checked="True" GroupName="Begin" SkinID="RadioButton" Text="Start with a clean costing sheet" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RadioButton ID="rbtnBeginTemplate" runat="server" GroupName="Begin" SkinID="RadioButton" Text="Use a template from a library" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:WizardStep>
                                                
                                                
                                                
                                                    <asp:WizardStep ID="StepTemplate" runat="server" Title="Template" >
                                                        <!-- Page element: 2 column -->
                                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:Label ID="lblMessage" runat="server" EnableViewState="False" SkinID="LabelError" Text="A costing sheet template must be selected."></asp:Label>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Panel ID="pnlTemplate" runat="server" Height="330px" Width="905px" ScrollBars="Auto">
                                                                        <asp:UpdatePanel id="upnlTemplate" runat="server">
                                                                            <contenttemplate>
                                                                                <asp:GridView ID="grdTemplate" runat="server" SkinID="GridView" Width="100%" AutoGenerateColumns="False" PageSize="12" OnDataBound="grdTemplate_DataBound" DataSourceID="odsCostingSheetTemplate" DataKeyNames="CostingSheetTemplateID" OnRowDeleting="grdTemplate_RowDeleting">
                                                                                    <Columns>                                                               
                                                                                       
                                                                                        <asp:TemplateField ShowHeader="False" Visible="False">
                                                                                            <ItemStyle horizontalalign="Center"></ItemStyle>
                                                                                            <ItemTemplate>
                                                                                                  <asp:Label ID="lblCostingSheetTemplateID" runat="server" SkinID="Label" Text='<%# Bind("CostingSheetTemplateID") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        
                                                                                                                               
                                                                                        <asp:TemplateField ShowHeader="False">
                                                                                            <ItemStyle horizontalalign="Center"></ItemStyle>
                                                                                            <HeaderStyle width="30px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <asp:CheckBox ID="cbxSelected" runat="server" onclick="return cbxSelectedClick(this);" Checked='<%# Eval("Selected") %>' />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        
                                                                                        
                                                                                        <asp:TemplateField HeaderText="Template" SortExpression="Name">
                                                                                            <ItemStyle horizontalalign="Left"></ItemStyle>
                                                                                            <HeaderStyle Width="220px" ></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblName" runat="server" SkinID="Label" Text='<%# Bind("Name") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        
                                                                                        
                                                                                        <asp:TemplateField HeaderText="Type of Work">
                                                                                            <ItemStyle horizontalalign="Left"></ItemStyle>
                                                                                            <HeaderStyle width="220px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblTypeOfWork" runat="server" SkinID="Label" Text='<%# Bind("TypeOfWork") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        
                                                                                        
                                                                                        <asp:TemplateField HeaderText="Costing Area" SortExpression="CostingArea">
                                                                                            <ItemStyle horizontalalign="Center"></ItemStyle>
                                                                                            <HeaderStyle width="100px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblCostingArea" runat="server" SkinID="Label" Text='<%# Bind("CostingArea") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        
                                                                                        
                                                                                        <asp:TemplateField HeaderText="Revenue Included" SortExpression="RevenueIncluded">
                                                                                            <ItemStyle horizontalalign="Center"></ItemStyle>
                                                                                            <HeaderStyle width="30px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <asp:CheckBox ID="cbxRevenueInclude" runat="server" Checked='<%# Eval("RevenueIncluded") %>' />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                            
                                                                                        
                                                                                        
                                                                                        <asp:TemplateField>
                                                                                            <HeaderStyle Width="50px"></HeaderStyle>                                                     
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                                                                    <tr>                                                                                
                                                                                                        <td>
                                                                                                            <asp:ImageButton ID="ibtnDelete" runat="server" CommandName="Delete" SkinID="GridView_Delete" 
                                                                                                                OnClientClick='return confirm("Are you sure you want to delete this template?");' />
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>  
                                                                                </asp:GridView> 
                                                                            </contenttemplate>
                                                                        </asp:UpdatePanel>
                                                                    </asp:Panel>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        
                                                        <!-- Page element: Data objects -->
                                                        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:ObjectDataSource ID="odsCostingSheetTemplate" runat="server" FilterExpression="(Deleted = 0)"
                                                                        SelectMethod="GetCostingSheetTemplate" DeleteMethod="DummyCostingSheetTemplateNew"
                                                                        TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_combined_costing_sheets_add"
                                                                        OldValuesParameterFormatString="original_{0}">
                                                                        <DeleteParameters>
                                                                            <asp:Parameter Name="CostingSheetTemplateID" Type="Int32" />
                                                                        </DeleteParameters>
                                                                    </asp:ObjectDataSource>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:WizardStep>
                                                
                                                
                                                
                                                    <asp:WizardStep ID="StepGeneralInformation" runat="server" Title="GeneralInformation">
                                                        <table cellpadding="0" cellspacing="0" width="0" style="width: 925px">
                                                            <tr>
                                                                <td style="width: 185px">
                                                                </td>
                                                                <td style="width: 185px">
                                                                </td>
                                                                <td style="width: 185px">
                                                                </td>
                                                                <td style="width: 185px">
                                                                </td>
                                                                <td style="width: 185px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:Label ID="lblName" runat="server" SkinID="Label" Text="Name">
                                                                    </asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblFrom" runat="server" SkinID="Label" Text="From">
                                                                    </asp:Label>
                                                                </td>
                                                                <td>
                                                                    <asp:Label ID="lblTo" runat="server" SkinID="Label" Text="To">
                                                                    </asp:Label>
                                                                </td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:TextBox ID="tbxName" runat="server" SkinID="TextBox" Width="360px">
                                                                    </asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpFrom" runat="server" Width="175px" SkinID="RadDatePicker"
                                                                        Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" DayNameFormat="Short"
                                                                            ShowRowHeaders="False" ViewSelectorText="x">
                                                                        </Calendar>
                                                                        <DateInput Width="" LabelCssClass="">
                                                                        </DateInput>
                                                                        <DatePopupButton CssClass="" ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                                <td>
                                                                    <telerik:RadDatePicker ID="tkrdpTo" runat="server" Width="175px" SkinID="RadDatePicker"
                                                                        Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" DayNameFormat="Short"
                                                                            ShowRowHeaders="False" ViewSelectorText="x">
                                                                        </Calendar>
                                                                        <DateInput Width="" LabelCssClass="">
                                                                        </DateInput>
                                                                        <DatePopupButton CssClass="" ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                                                    </telerik:RadDatePicker>
                                                                </td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="tbxName"
                                                                        Display="Dynamic" ErrorMessage="Please provide a name." SkinID="Validator" ValidationGroup="StepGeneralInformation">
                                                                    </asp:RequiredFieldValidator>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="rfvFrom" runat="server" ControlToValidate="tkrdpFrom"
                                                                        Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator" ValidationGroup="StepGeneralInformation">
                                                                    </asp:RequiredFieldValidator>
                                                                    <asp:CustomValidator ID="cvStartDateEndDate" runat="server" Display="Dynamic" ErrorMessage="You cannot add costing sheet in that interval."
                                                                        OnServerValidate="cvStartDateEndDate_ServerValidate" SkinID="Validator" ValidationGroup="StepGeneralInformation">
                                                                    </asp:CustomValidator>
                                                                </td>
                                                                <td>
                                                                    <asp:RequiredFieldValidator ID="rfvTo" runat="server" ControlToValidate="tkrdpTo"
                                                                        Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator" ValidationGroup="StepGeneralInformation">
                                                                    </asp:RequiredFieldValidator>
                                                                </td>
                                                                <td></td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 7px;" colspan="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5">
                                                                    <asp:Label ID="lblTypeOfWork" runat="server" SkinID="Label" Text="Please select the type of work you would like to add">
                                                                    </asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="cbxRehabAssessmentData" runat="server" SkinID="CheckBox" Text="Rehab Assessment Data" Checked="true">
                                                                    </asp:CheckBox>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="cbxFullLengthLiningData" runat="server" SkinID="CheckBox" Text="Full Length Lining Data" Checked="true">
                                                                    </asp:CheckBox>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="cbxPointRepairData" runat="server" SkinID="CheckBox" Text="Point Repair Data" Checked="true">
                                                                    </asp:CheckBox>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="cbxJunctionLiningData" runat="server" SkinID="CheckBox" Text="Junction Lining Data" Checked="true">
                                                                    </asp:CheckBox>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="cbxManholeRehabData" runat="server" SkinID="CheckBox" Text="Manhole Rehab Data" Checked="true">
                                                                    </asp:CheckBox>
                                                                </td>                                                                
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 7px;" colspan="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="cbxMobilizationData" runat="server" SkinID="CheckBox" Text="Mobilization Data" Checked="true">
                                                                    </asp:CheckBox>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="cbxOtherData" runat="server" SkinID="CheckBox" Text="Other Data" Checked="true">
                                                                    </asp:CheckBox>
                                                                </td>
                                                                <td colspan="3">
                                                                </td>
                                                            <tr>
                                                                <td colspan="5">
                                                                    <asp:CustomValidator ID="cvWorks" Display="Dynamic" runat="server" ErrorMessage="You must select at least one work."
                                                                        OnServerValidate="cvWorks_ServerValidate" SkinID="Validator" ValidationGroup="StepGeneralInformation"></asp:CustomValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 7px;" colspan="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5">
                                                                    <asp:Label ID="lblCostingArea" runat="server" SkinID="Label" Text="Please select the costing area you would like to visualize">
                                                                    </asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="cbxLabourHour" runat="server" SkinID="CheckBox" Text="Labour Hour" Checked="true">
                                                                    </asp:CheckBox>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="cbxTrucksEquipment" runat="server" SkinID="CheckBox" Text="Trucks / Equipment" Checked="true">
                                                                    </asp:CheckBox>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="cbxMaterial" runat="server" SkinID="CheckBox" Text="Material" Checked="true">
                                                                    </asp:CheckBox>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="cbxOtherCost" runat="server" SkinID="CheckBox" Text="Misc Costs">
                                                                    </asp:CheckBox>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="cbxSubcontractor" runat="server" SkinID="CheckBox" Text="Subcontractor" Checked="true">
                                                                    </asp:CheckBox>
                                                                </td>                                                                
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 7px;" colspan="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:CheckBox ID="CheckBox1" runat="server" SkinID="CheckBox" Text="Hotels" Checked="true">
                                                                    </asp:CheckBox>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="CheckBox2" runat="server" SkinID="CheckBox" Text="Bonding" Checked="true">
                                                                    </asp:CheckBox>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="CheckBox3" runat="server" SkinID="CheckBox" Text="Insurance" Checked="true">
                                                                    </asp:CheckBox>
                                                                </td>
                                                                <td>
                                                                    <asp:CheckBox ID="CheckBox4" runat="server" SkinID="CheckBox" Text="Other Costs" Checked="true">
                                                                    </asp:CheckBox>
                                                                </td>
                                                                <td>
                                                                    
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5">
                                                                    <asp:CustomValidator ID="cvCostingArea" Display="Dynamic" runat="server" ErrorMessage="You must select at least one costing area."
                                                                        OnServerValidate="cvCostingArea_ServerValidate" SkinID="Validator" ValidationGroup="StepGeneralInformation"></asp:CustomValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 7px;" colspan="5">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5">
                                                                    <asp:Label ID="lblRevenueInformation" runat="server" SkinID="Label" Text="Please select if you want to include revenue information to the costing sheet">
                                                                    </asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5">
                                                                    <asp:CheckBox ID="cbxRevenueInformation" runat="server" SkinID="CheckBox" Text="Include Revenue Information " Checked="true">
                                                                    </asp:CheckBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5" style="height: 10px">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        
                                                        <table cellpadding="0" cellspacing="0" width="0" style="width: 925px">
                                                            <tr>
                                                                <td style="width: 185px">
                                                                </td>
                                                                <td style="width: 185px">
                                                                </td>
                                                                <td style="width: 185px">
                                                                </td>
                                                                <td style="width: 185px">
                                                                </td>
                                                                <td style="width: 185px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5">
                                                                    <asp:Label ID="lblCombinedProjects" runat="server" SkinID="Label" Text="Please select the projects you want to combine in this costing sheet">
                                                                    </asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:Panel ID="pnlProjects" Width="360px" Height="200px" runat="server" SkinID="Panel">
                                                                        <asp:TreeView ID="tvProjectsRoot" runat="server" SkinID="SimpleTreeView" onclick="return OnTreeClick(event);">                                                    
                                                                        </asp:TreeView>
                                                                    </asp:Panel>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:CustomValidator ID="cvProjects" runat="server" SkinID="Validator" Display="Dynamic" ErrorMessage="You must select at least one project."
                                                                        OnServerValidate="cvProjects_ServerValidate" ValidationGroup="StepGeneralInformation">
                                                                    </asp:CustomValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="5" style="height: 10px">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        
                                                        <!-- Page element: 1 column global validator-->
                                                        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                            <td colspan="5">
                                                                    <asp:Label ID="lblWhatDoYouWantToDo" runat="server" SkinID="LabelTitle2" Text="What do you want to do?">
                                                                    </asp:Label>
                                                                </td>
                                                            <tr>
                                                                <td style="width: 150px">
                                                                    <asp:CustomValidator ID="cvEnd" runat="server" Display="Dynamic" ErrorMessage="Please select one or more options."
                                                                        OnServerValidate="cvEnd_ServerValidate" SkinID="Validator" EnableViewState="False"></asp:CustomValidator>
                                                                </td>
                                                            </tr>                                
                                                            <tr>
                                                                <td>
                                                                    <asp:RadioButton ID="cbxEndConfirm" runat="server" GroupName="Option" SkinID="RadioButton" Text="Generate costing sheet" Checked="true" />
                                                                </td>
                                                            </tr>                               
                                                            <tr>
                                                                <td style="height: 7px">
                                                                </td>
                                                            </tr>                                
                                                            <tr>
                                                                <td>
                                                                    <asp:RadioButton ID="cbxEndSave" runat="server" GroupName="Option" SkinID="RadioButton" Text="Save this costing sheet as a template" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        
                                                        <!-- Page element: 3 columns inside options-->
                                                        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                            <tr>
                                                                <td style="height: 2px; width: 15px">
                                                                </td>
                                                                <td style="height: 2px; width: 150px">
                                                                </td>
                                                                <td style="height: 2px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:RadioButton ID="rbtnEndSaveNew" runat="server" GroupName="End"
                                                                        SkinID="RadioButton" Text="New template name :" />
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="tbxEndSaveNew" runat="server" EnableViewState="False" SkinID="TextBox"
                                                                        Style="width: 200px"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:CustomValidator ID="cvEndSaveNew" runat="server" ControlToValidate="tbxEndSaveNew"
                                                                        Display="Dynamic" ErrorMessage="Please provide a template name." OnServerValidate="cvEndSaveNew_ServerValidate"
                                                                        SkinID="Validator" ValidateEmptyText="True" EnableViewState="False"></asp:CustomValidator>
                                                                    <asp:CustomValidator ID="cvEndSaveNewExist" runat="server" ControlToValidate="tbxEndSaveNew"
                                                                        Display="Dynamic" ErrorMessage="That template already exists." OnServerValidate="cvEndSaveNewExist_ServerValidate"
                                                                        SkinID="Validator" EnableViewState="False"></asp:CustomValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 2px;">
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
                                                                    <asp:RadioButton ID="rbtnEndSaveReplace" runat="server" Checked="true" GroupName="End" SkinID="RadioButton"
                                                                        Text="Replace template :" />
                                                                </td>
                                                                <td>
                                                                   <asp:DropDownList ID="luEndSaveTemplate" runat="server" SkinID="DropDownList"
                                                                     EnableViewState="false" Width="150px" DataSourceID="odsTemplate" DataTextField="Name" 
                                                                     DataValueField="CostingSheetTemplateID">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:CustomValidator ID="cvEndSaveTemplate" runat="server" ControlToValidate="luEndSaveTemplate"
                                                                        Display="Dynamic" ErrorMessage="Please select a template." OnServerValidate="cvEndSaveTemplate_ServerValidate"
                                                                        SkinID="Validator" EnableViewState="False"></asp:CustomValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 2px;">
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td>
                                                                    <asp:ObjectDataSource ID="odsTemplate" runat="server" SelectMethod="LoadAndAddItem"
                                                                        TypeName="LiquiForce.LFSLive.BL.Projects.Projects.ProjectCostingSheetTemplateList"
                                                                        OldValuesParameterFormatString="original_{0}">
                                                                        <SelectParameters>
                                                                            <asp:Parameter DefaultValue="0" Name="costingTemplateSheetId" Type="Int32" />
                                                                            <asp:Parameter DefaultValue="(Select)" Name="name" Type="String" />
                                                                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                                                                        </SelectParameters>
                                                                    </asp:ObjectDataSource>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:WizardStep>
                                                    
                                                    
                                                    
                                                    <asp:WizardStep ID="StepLabourHourInformation" runat="server" Title="LabourHourInformation">
                                                        <div runat="server" id="dvLabourHourInformation" style="overflow-x: auto; overflow-y: hidden; width: 930px">
                                                            <table cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblTeamMembers" runat="server" SkinID="Label" Text="Labour Hours"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 7px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:UpdatePanel ID="upnlTeamMembers" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:GridView ID="grdTeamMembers" runat="server" SkinID="GridView" Width="930px" AllowPaging="True"
                                                                                    ShowFooter="true" AutoGenerateColumns="False" DataKeyNames="CostingSheetID,Work_,EmployeeID,RefID"
                                                                                    DataSourceID="odsTeamMembers" OnDataBound="grdTeamMembers_DataBound" OnPageIndexChanging="grdTeamMembers_PageIndexChanging"
                                                                                    PageSize="9" OnRowUpdating="grdTeamMembers_RowUpdating" OnRowDeleting="grdTeamMembers_RowDeleting"
                                                                                    OnRowCommand="grdTeamMembers_RowCommand" OnRowDataBound="grdTeamMembers_RowDataBound" OnRowEditing="grdTeamMembers_RowEditing">
                                                                                    <Columns>
                                                                                        <%--0--%>
                                                                                        <asp:TemplateField HeaderText="CostingSheetID" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblCostingSheetID" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblCostingSheetIDEdit" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                                                                                <telerik:RadDatePicker ID="hdfFrom" runat="server" Visible="false"></telerik:RadDatePicker>
                                                                                                <telerik:RadDatePicker ID="hdfTo" runat="server" Visible="false"></telerik:RadDatePicker>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <telerik:RadDatePicker ID="hdfFrom" runat="server" Visible="false"></telerik:RadDatePicker>
                                                                                                <telerik:RadDatePicker ID="hdfTo" runat="server" Visible="false"></telerik:RadDatePicker>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--1--%>
                                                                                        <asp:TemplateField HeaderText="EmployeeID" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblEmployeeID" runat="server" SkinID="Label" Text='<%# Eval("EmployeeID") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblEmployeeIDEdit" runat="server" SkinID="Label" Text='<%# Eval("EmployeeID") %>'></asp:Label>
                                                                                            </EditItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--2--%>
                                                                                        <asp:TemplateField HeaderText="RefID" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblRefID" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblRefIDEdit" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                                            </EditItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--3--%>
                                                                                        <asp:TemplateField HeaderText="Work_" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblWork_" runat="server" SkinID="Label" Text='<%# Eval("Work_") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblWork_Edit" runat="server" SkinID="Label" Text='<%# Eval("Work_") %>'></asp:Label>
                                                                                            </EditItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--4--%>
                                                                                        <asp:TemplateField HeaderText="Project">
                                                                                            <HeaderStyle Width="85px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblProject" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("Project") %>'> </asp:Label>                                                                                                                                                                                             
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <asp:TextBox ID="tbxProjectEdit" Width="85px" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Text='<%# Eval("Project") %>'></asp:TextBox>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <asp:DropDownList Width="85px" ID="ddlProject_New" runat="server" SkinID="DropDownList">
                                                                                                </asp:DropDownList>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--5--%>
                                                                                        <asp:TemplateField HeaderText="Type of Work . Function">
                                                                                            <HeaderStyle Width="85px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblTypeOfWork" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("WorkFunction") %>'> </asp:Label>                                                                                                                                                                                             
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <asp:TextBox ID="tbxTypeOfWorkEdit" Width="85px" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Text='<%# Eval("WorkFunction") %>'></asp:TextBox>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <asp:DropDownList Width="85px" ID="ddlTypeOfWork_New" runat="server" SkinID="DropDownList" 
                                                                                                    DataSourceID="odsWorkFunctionConcat" DataTextField="WorkFunctionConcat" DataValueField="WorkFunctionConcat">
                                                                                                </asp:DropDownList>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--6--%>
                                                                                        <asp:TemplateField HeaderText="Team Member">
                                                                                            <HeaderStyle Width="95px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblTeamMember" Width="95px" runat="server" SkinID="Label" Text='<%# Eval("Name") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:TextBox ID="tbxTeamMemberEdit" Width="95px" runat="server" SkinID="TextBoxReadOnly"
                                                                                                                    Text='<%# Eval("Name") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:DropDownList Width="95px" ID="ddlTeamMemberNew" runat="server" SkinID="DropDownList"
                                                                                                                    DataTextField="FullName" DataMember="DefaultView" DataValueField="EmployeeID"
                                                                                                                    DataSourceID="odsEmployee">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--7--%>
                                                                                        <asp:TemplateField HeaderText="From">
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                            <HeaderStyle Width="100px" />
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblStartDate" runat="server" SkinID="Label" Text='<%# Bind("StartDate", "{0:d}") %>'
                                                                                                                    Style="width: 100px"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>                                                                                                        
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpStartDateEdit" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "StartDate") %>' Calendar-ShowRowHeaders="false"
                                                                                                                    Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvStartDateEdit" runat="server" ControlToValidate="tkrdpStartDateEdit" ValidationGroup="labourHoursEdit"
                                                                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                                                                <asp:CompareValidator ID="cvStartDateEdit" runat="server" Type="Date" ControlToValidate="tkrdpStartDateEdit" ValidationGroup="labourHoursEdit" SkinID="Validator"
                                                                                                                    Display="Dynamic" ControlToCompare="hdfFrom" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval.">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpStartDateNew" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "StartDate") %>' Calendar-ShowRowHeaders="false"
                                                                                                                    Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvStartDateNew" runat="server" ControlToValidate="tkrdpStartDateNew" ValidationGroup="labourHoursNew"
                                                                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator" >
                                                                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                                                                <asp:CompareValidator ID="cvStartDateNew" runat="server" Type="Date" ControlToValidate="tkrdpStartDateNew" ValidationGroup="labourHoursNew" SkinID="Validator"
                                                                                                                    Display="Dynamic" ControlToCompare="hdfFrom" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval.">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--8--%>
                                                                                        <asp:TemplateField HeaderText="To">
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                            <HeaderStyle Width="100px" />
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblEndDate" runat="server" SkinID="Label" Text='<%# Bind("EndDate", "{0:d}") %>'
                                                                                                                    Style="width: 100px"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpEndDateEdit" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "EndDate") %>' Calendar-ShowRowHeaders="false"
                                                                                                                    Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvEndDateEdit" runat="server" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="labourHoursEdit"
                                                                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                                                                <asp:CompareValidator ID="cvEndDateEdit" runat="server" Type="Date" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="labourHoursEdit" 
                                                                                                                    Display="Dynamic" ControlToCompare="hdfTo" Operator="LessThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                                                                </asp:CompareValidator>
                                                                                                                <asp:CompareValidator ID="cvEndDate2Edit" runat="server" Type="Date" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="labourHoursEdit" 
                                                                                                                    Display="Dynamic" ControlToCompare="tkrdpStartDateEdit" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpEndDateNew" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "EndDate") %>' Calendar-ShowRowHeaders="false"
                                                                                                                    Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvEndDateNew" runat="server" ControlToValidate="tkrdpEndDateNew" ValidationGroup="labourHoursNew"
                                                                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                                                                <asp:CompareValidator ID="cvEndDateNew" runat="server" Type="Date" ControlToValidate="tkrdpEndDateNew" ValidationGroup="labourHoursNew" 
                                                                                                                    Display="Dynamic" ControlToCompare="hdfTo" Operator="LessThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                                                                </asp:CompareValidator>
                                                                                                                <asp:CompareValidator ID="cvEndDate2New" runat="server" Type="Date" ControlToValidate="tkrdpEndDateNew" ValidationGroup="labourHoursNew" 
                                                                                                                    Display="Dynamic" ControlToCompare="tkrdpStartDateNew" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--9--%>
                                                                                        <asp:TemplateField HeaderText="Unit of Measurement/LH">
                                                                                            <HeaderStyle Width="105px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblUnitOfMeasurementLH" Width="105px" runat="server" SkinID="Label"
                                                                                                                    Text='<%# Eval("LHUnitOfMeasurement") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:DropDownList Width="105px" ID="ddlUnitOfMeasurementLHEdit" runat="server" SkinID="DropDownList"
                                                                                                                    DataTextField="Description" DataMember="DefaultView" DataValueField="Description"
                                                                                                                    DataSourceID="odsUnitsOfMeasurementLH">
                                                                                                                </asp:DropDownList>
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
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:DropDownList Width="105px" ID="ddlUnitOfMeasurementLHNew" runat="server" SkinID="DropDownList"
                                                                                                                    DataTextField="Description" DataMember="DefaultView" DataValueField="Description"
                                                                                                                    DataSourceID="odsUnitsOfMeasurementLH">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--10--%>
                                                                                        <asp:TemplateField HeaderText="LH Qty">
                                                                                            <HeaderStyle Width="58px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                                    <tr>
                                                                                                        <td align="center">
                                                                                                            <asp:Label ID="lblLHQty" Width="58px" runat="server" Text='<%# Eval("LHQuantity", "{0:n2}") %>'
                                                                                                                SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                                    <tr>
                                                                                                        <td align="center">
                                                                                                            <asp:TextBox ID="tbxLHQtyEdit" Width="58px" runat="server" Text='<%# Eval("LHQuantity", "{0:n2}") %>'
                                                                                                                SkinID="TextBox"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="rfvLHQtyEdit" runat="server" ControlToValidate="tbxLHQtyEdit"
                                                                                                                ErrorMessage="Please enter a quantity." ValidationGroup="labourHoursEdit" SkinID="Validator"
                                                                                                                Display="Dynamic" InitialValue="">
                                                                                                            </asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                                    <tr>
                                                                                                        <td align="center">
                                                                                                            <asp:TextBox ID="tbxLHQtyNew" Width="58px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="rfvLHQtyNew" runat="server" ControlToValidate="tbxLHQtyNew"
                                                                                                                ErrorMessage="Please enter a quantity." ValidationGroup="labourHoursNew" SkinID="Validator"
                                                                                                                Display="Dynamic" InitialValue="">
                                                                                                            </asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--11--%>
                                                                                        <asp:TemplateField HeaderText="Unit of Measurement/Meals" Visible="false">
                                                                                            <HeaderStyle Width="120px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblUnitOfMeasurementMeals" Width="120px" runat="server" SkinID="Label"
                                                                                                                    Text='<%# Eval("MealsUnitOfMeasurement") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:DropDownList Width="120px" ID="ddlUnitsOfMeasurementLHMealsEdit" runat="server"
                                                                                                                    SkinID="DropDownList" DataTextField="Description" DataMember="DefaultView" DataValueField="Description"
                                                                                                                    DataSourceID="odsUnitsOfMeasurementLHMeals">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:DropDownList Width="120px" ID="ddlUnitsOfMeasurementLHMealsNew" runat="server"
                                                                                                                    SkinID="DropDownList" DataTextField="Description" DataMember="DefaultView" DataValueField="Description"
                                                                                                                    DataSourceID="odsUnitsOfMeasurementLHMeals">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--12--%>
                                                                                        <asp:TemplateField HeaderText="Meals Qty" Visible="false">
                                                                                            <HeaderStyle Width="65px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                                    <tr>
                                                                                                        <td align="center">
                                                                                                            <asp:Label ID="lblMealsQty" Width="65px" runat="server" Text='<%# Eval("MealsQuantity") %>'
                                                                                                                SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                                    <tr>
                                                                                                        <td align="center">
                                                                                                            <asp:TextBox ID="tbxMealsQtyEdit" Width="65px" runat="server" Text='<%# Eval("MealsQuantity") %>'
                                                                                                                SkinID="TextBox"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                                    <tr>
                                                                                                        <td align="center">
                                                                                                            <asp:TextBox ID="tbxMealsQtyNew" Width="65px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--13--%>
                                                                                        <asp:TemplateField HeaderText="Unit of Measurement/Motel" Visible="false">
                                                                                            <HeaderStyle Width="120px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblUnitOfMeasurementMotel" Width="120px" runat="server" SkinID="Label"
                                                                                                                    Text='<%# Eval("MotelUnitOfMeasurement") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:DropDownList Width="120px" ID="ddlUnitsOfMeasurementLHMotelEdit" runat="server"
                                                                                                                    SkinID="DropDownList" DataTextField="Description" DataMember="DefaultView" DataValueField="Description"
                                                                                                                    DataSourceID="odsUnitsOfMeasurementLHMotel">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:DropDownList Width="120px" ID="ddlUnitsOfMeasurementLHMotelNew" runat="server"
                                                                                                                    SkinID="DropDownList" DataTextField="Description" DataMember="DefaultView" DataValueField="Description"
                                                                                                                    DataSourceID="odsUnitsOfMeasurementLHMotel">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--14--%>
                                                                                        <asp:TemplateField HeaderText="Motel Qty" Visible="false">
                                                                                            <HeaderStyle Width="60px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                                    <tr>
                                                                                                        <td align="center">
                                                                                                            <asp:Label ID="lblMotelQty" Width="60px" runat="server" Text='<%# Eval("MotelQuantity") %>'
                                                                                                                SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                                    <tr>
                                                                                                        <td align="center">
                                                                                                            <asp:TextBox ID="tbxMotelQtyEdit" Width="60px" runat="server" Text='<%# Eval("MotelQuantity") %>'
                                                                                                                SkinID="TextBox"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                                    <tr>
                                                                                                        <td align="center">
                                                                                                            <asp:TextBox ID="tbxMotelQtyNew" Width="60px" runat="server" SkinID="Textbox"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--15--%>
                                                                                        <asp:TemplateField HeaderText="LH Cost (CAD)">
                                                                                            <HeaderStyle Width="90px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:Label ID="lblLHCostCAD" Width="90px" runat="server" SkinID="Label" Text='<%# Eval("LHCostCad", "{0:n2}") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxLHCostCADEdit" Width="90px" runat="server" SkinID="TextBox" Text='<%# Eval("LHCostCad", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvLHCostCADEdit" runat="server" ControlToValidate="tbxLHCostCADEdit"
                                                                                                                    ErrorMessage="Please enter a cost." ValidationGroup="labourHoursCadEdit" SkinID="Validator"
                                                                                                                    Display="Dynamic" InitialValue="">
                                                                                                                </asp:RequiredFieldValidator>
                                                                                                                <asp:CompareValidator ID="cvLHCostCADEdit" runat="server" ControlToValidate="tbxLHCostCADEdit"
                                                                                                                    Display="Dynamic" ValidationGroup="labourHoursCadEdit" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxLHCostCADNew" Width="90px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvLHCostCADNew" runat="server" ControlToValidate="tbxLHCostCADNew"
                                                                                                                    ErrorMessage="Please enter a cost." ValidationGroup="labourHoursCadNew" SkinID="Validator"
                                                                                                                    Display="Dynamic" InitialValue="">
                                                                                                                </asp:RequiredFieldValidator>
                                                                                                                <asp:CompareValidator ID="cvLHCostCADNew" runat="server" ControlToValidate="tbxLHCostCADNew"
                                                                                                                    Display="Dynamic" ValidationGroup="labourHoursCadNew" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--16--%>
                                                                                        <asp:TemplateField HeaderText="Meals Cost (CAD)" Visible="false">
                                                                                            <HeaderStyle Width="105px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:Label ID="lblMealsCostCAD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("MealsCostCad", "{0:n2}") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxMealsCostCADEdit" Width="105px" runat="server" SkinID="TextBox"
                                                                                                                    Text='<%# Eval("MealsCostCad", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:CompareValidator ID="cvMealsCostCADEdit" runat="server" ControlToValidate="tbxMealsCostCADEdit"
                                                                                                                    Display="Dynamic" ValidationGroup="labourHoursCadEdit" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxMealsCostCADNew" Width="105px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:CompareValidator ID="cvMealsCostCADNew" runat="server" ControlToValidate="tbxMealsCostCADNew"
                                                                                                                    Display="Dynamic" ValidationGroup="labourHoursCadNew" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--17--%>
                                                                                        <asp:TemplateField HeaderText="Motel Cost (CAD)" Visible="false">
                                                                                            <HeaderStyle Width="105px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:Label ID="lblMotelCostCAD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("MotelCostCad", "{0:n2}") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxMotelCostCADEdit" Width="105px" runat="server" SkinID="TextBox"
                                                                                                                    Text='<%# Eval("MotelCostCad", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:CompareValidator ID="cvMotelCostCADEdit" runat="server" ControlToValidate="tbxMotelCostCADEdit"
                                                                                                                    Display="Dynamic" ValidationGroup="labourHoursCadEdit" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxMotelCostCADNew" Width="105px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:CompareValidator ID="cvMotelCostCADNew" runat="server" ControlToValidate="tbxMotelCostCADNew"
                                                                                                                    Display="Dynamic" ValidationGroup="labourHoursCadNew" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--18--%>
                                                                                        <asp:TemplateField HeaderText="Total Cost (CAD)">
                                                                                            <HeaderStyle Width="105px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:Label ID="lblTotalCostCAD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("TotalCostCad", "{0:n2}") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxTotalCostCADEdit" Width="105px" runat="server" ReadOnly="true"
                                                                                                                    SkinID="TextBoxReadOnly" Text='<%# Eval("TotalCostCad", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxTotalCostCADNew" Width="105px" runat="server" ReadOnly="true"
                                                                                                                    SkinID="TextBoxReadOnly"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--19--%>
                                                                                        <asp:TemplateField HeaderText="LH Cost (USD)">
                                                                                            <HeaderStyle Width="90px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:Label ID="lblLHCostUSD" Width="90px" runat="server" SkinID="Label" Text='<%# Eval("LHCostUsd", "{0:n2}") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxLHCostUSDEdit" Width="90px" runat="server" SkinID="TextBox" Text='<%# Eval("LHCostUsd", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvLHCostUSDEdit" runat="server" ControlToValidate="tbxLHCostUSDEdit"
                                                                                                                    ErrorMessage="Please enter a cost." ValidationGroup="labourHoursUsdEdit" SkinID="Validator"
                                                                                                                    Display="Dynamic" InitialValue="">
                                                                                                                </asp:RequiredFieldValidator>
                                                                                                                <asp:CompareValidator ID="cvLHCostUSDEdit" runat="server" ControlToValidate="tbxLHCostUSDEdit"
                                                                                                                    Display="Dynamic" ValidationGroup="labourHoursUsdEdit" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxLHCostUSDNew" Width="90px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvLHCostUSDNew" runat="server" ControlToValidate="tbxLHCostUSDNew"
                                                                                                                    ErrorMessage="Please enter a cost." ValidationGroup="labourHoursUsdNew" SkinID="Validator"
                                                                                                                    Display="Dynamic" InitialValue="">
                                                                                                                </asp:RequiredFieldValidator>
                                                                                                                <asp:CompareValidator ID="cvLHCostUSDNew" runat="server" ControlToValidate="tbxLHCostUSDNew"
                                                                                                                    Display="Dynamic" ValidationGroup="labourHoursUsdNew" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--20--%>
                                                                                        <asp:TemplateField HeaderText="Meals Cost (USD)" Visible="false">
                                                                                            <HeaderStyle Width="105px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:Label ID="lblMealsCostUSD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("MealsCostUsd", "{0:n2}") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxMealsCostUSDEdit" Width="105px" runat="server" SkinID="TextBox"
                                                                                                                    Text='<%# Eval("MealsCostUsd", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:CompareValidator ID="cvMealsCostUSDEdit" runat="server" ControlToValidate="tbxMealsCostUSDEdit"
                                                                                                                    Display="Dynamic" ValidationGroup="labourHoursUsdEdit" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxMealsCostUSDNew" Width="105px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:CompareValidator ID="cvMealsCostUSDNew" runat="server" ControlToValidate="tbxMealsCostUSDNew"
                                                                                                                    Display="Dynamic" ValidationGroup="labourHoursUsdNew" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--21--%>
                                                                                        <asp:TemplateField HeaderText="Motel Cost (USD)" Visible="false">
                                                                                            <HeaderStyle Width="105px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:Label ID="lblMotelCostUSD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("MotelCostUsd", "{0:n2}") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxMotelCostUSDEdit" Width="105px" runat="server" SkinID="TextBox"
                                                                                                                    Text='<%# Eval("MotelCostUsd", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:CompareValidator ID="cvMotelCostUSDEdit" runat="server" ControlToValidate="tbxMotelCostUSDEdit"
                                                                                                                    Display="Dynamic" ValidationGroup="labourHoursUsdEdit" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxMotelCostUSDNew" Width="105px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:CompareValidator ID="cvMotelCostUSDNew" runat="server" ControlToValidate="tbxMotelCostUSDNew"
                                                                                                                    Display="Dynamic" ValidationGroup="labourHoursUsdNew" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--22--%>
                                                                                        <asp:TemplateField HeaderText="Total Cost (USD)">
                                                                                            <HeaderStyle Width="105px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:Label ID="lblTotalCostUSD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("TotalCostUsd", "{0:n2}") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxTotalCostUSDEdit" Width="105px" runat="server" ReadOnly="true"
                                                                                                                    SkinID="TextBoxReadOnly" Text='<%# Eval("TotalCostUsd", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxTotalCostUSDNew" Width="105px" runat="server" ReadOnly="true"
                                                                                                                    SkinID="TextBoxReadOnly"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--Buttons--%>
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
                                                                                                                <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" CommandName="Add"
                                                                                                                    ToolTip="Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png"></asp:ImageButton>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <HeaderStyle Width="60px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td style="width: 50%">
                                                                                                                <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" CommandName="Edit"
                                                                                                                    ToolTip="Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png"></asp:ImageButton>
                                                                                                            </td>
                                                                                                            <td style="width: 50%">
                                                                                                                <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" CommandName="Delete"
                                                                                                                    OnClientClick='return confirm("Are you sure you want to delete this cost?");'
                                                                                                                    ToolTip="Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png">
                                                                                                                </asp:ImageButton>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                                &nbsp;
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table cellpadding="0" cellspacing="0" border="0">
                                                                            <tr>
                                                                                <td style="width: 565px;">
                                                                                </td>
                                                                                <td style="width: 170px; text-align: right;">
                                                                                    <asp:Label ID="lblTeamMembersTotalCost" Width="170px" runat="server" SkinID="Label"
                                                                                        Text="(USD) : "></asp:Label>
                                                                                </td>
                                                                                <td style="width: 120px; text-align: right;">
                                                                                    <asp:UpdatePanel ID="upnlTeamMembersTotalCostCAD" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:TextBox ID="tbxTeamMembersTotalCostCAD" runat="server" SkinID="TextBoxRightReadOnly"
                                                                                                Width="120px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                    <asp:UpdatePanel ID="upnlTeamMembersTotalCostUSD" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:TextBox ID="tbxTeamMembersTotalCostUSD" runat="server" SkinID="TextBoxRightReadOnly"
                                                                                                Width="120px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </asp:WizardStep>
                                                    
                                                    
                                                    
                                                    <asp:WizardStep ID="StepTrucksEquipmentInformation" runat="server" Title="TrucksEquipmentInformation">
                                                        <div runat="server" id="dvTrucksEquipment" style="overflow-x: auto; overflow-y: hidden; width: 930px">
                                                            <table cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblUnits" runat="server" SkinID="Label" Text="Trucks / Equipment Costs"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 7px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:UpdatePanel ID="upnlUnits" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:GridView ID="grdUnits" runat="server" SkinID="GridView" Width="930px" AllowPaging="True"
                                                                                    ShowFooter="true" AutoGenerateColumns="False" DataKeyNames="CostingSheetID,Work_,UnitID,RefID"
                                                                                    DataSourceID="odsUnits" OnDataBound="grdUnits_DataBound" OnPageIndexChanging="grdUnits_PageIndexChanging"
                                                                                    PageSize="9" OnRowUpdating="grdUnits_RowUpdating" OnRowDeleting="grdUnits_RowDeleting" OnRowEditing="grdUnits_RowEditing"
                                                                                    OnRowCommand="grdUnits_RowCommand" OnRowDataBound="grdUnits_RowDataBound">
                                                                                    <Columns>
                                                                                    
                                                                                        <%--0--%>
                                                                                        <asp:TemplateField HeaderText="CostingSheetID" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblCostingSheetID" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>                                                                                                
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblCostingSheetIDEdit" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                                                                                <telerik:RadDatePicker ID="hdfFrom" runat="server" Visible="false"></telerik:RadDatePicker>
                                                                                                <telerik:RadDatePicker ID="hdfTo" runat="server" Visible="false"></telerik:RadDatePicker>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <telerik:RadDatePicker ID="hdfFrom" runat="server" Visible="false"></telerik:RadDatePicker>
                                                                                                <telerik:RadDatePicker ID="hdfTo" runat="server" Visible="false"></telerik:RadDatePicker>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--1--%>
                                                                                        <asp:TemplateField HeaderText="UnitID" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblUnitID" runat="server" SkinID="Label" Text='<%# Eval("UnitID") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblUnitIDEdit" runat="server" SkinID="Label" Text='<%# Eval("UnitID") %>'></asp:Label>
                                                                                            </EditItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--2--%>
                                                                                        <asp:TemplateField HeaderText="RefID" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblRefID" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblRefIDEdit" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                                            </EditItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--3--%>
                                                                                        <asp:TemplateField HeaderText="Work_" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblWork_" runat="server" SkinID="Label" Text='<%# Eval("Work_") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblWork_Edit" runat="server" SkinID="Label" Text='<%# Eval("Work_") %>'></asp:Label>
                                                                                            </EditItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--4--%>
                                                                                        <asp:TemplateField HeaderText="Project">
                                                                                            <HeaderStyle Width="85px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblProject" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("Project") %>'> </asp:Label>                                                                                                                                                                                             
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <asp:TextBox ID="tbxProjectEdit" Width="85px" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Text='<%# Eval("Project") %>'></asp:TextBox>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <asp:DropDownList Width="85px" ID="ddlProject_New" runat="server" SkinID="DropDownList">
                                                                                                </asp:DropDownList>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--5--%>
                                                                                        <asp:TemplateField HeaderText="Type of Work . Function">
                                                                                            <HeaderStyle Width="155px" Wrap="false"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblTypeOfWork" Width="155px" runat="server" SkinID="Label" Text='<%# Eval("WorkFunction") %>'></asp:Label>
                                                                                            </ItemTemplate>                                                                                            
                                                                                            <EditItemTemplate>
                                                                                                <asp:TextBox ID="tbxTypeOfWorkEdit" Width="155px" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Text='<%# Eval("WorkFunction") %>'></asp:TextBox>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <asp:DropDownList Width="155px" ID="ddlTypeOfWork_New" runat="server" SkinID="DropDownList"
                                                                                                    DataSourceID="odsWorkFunctionConcat" DataTextField="WorkFunctionConcat" DataValueField="WorkFunctionConcat">
                                                                                                </asp:DropDownList>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--6--%>
                                                                                        <asp:TemplateField HeaderText="Unit Code">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblUnitCode" Width="60px" runat="server" SkinID="Label" Text='<%# Eval("UnitCode") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="60px" Wrap="false"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:TextBox ID="tbxUnitCodeEdit" Width="60px" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly"
                                                                                                                    Text='<%# Eval("UnitCode") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:DropDownList Width="60px" ID="ddlUnitCodeNew" runat="server" SkinID="DropDownListLookup"
                                                                                                                    EnableViewState="True" DataTextField="UnitCode" DataValueField="UnitID" DataSourceID="odsUnitCode">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--7--%>
                                                                                        <asp:TemplateField HeaderText="Unit Description">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblUnitDescription" Width="120px" runat="server" SkinID="Label" Text='<%# Eval("UnitDescription") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="120px" Wrap="false"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:TextBox ID="tbxUnitDescriptionEdit" Width="120px" runat="server" ReadOnly="true"
                                                                                                                    SkinID="TextBoxReadOnly" Text='<%# Eval("UnitDescription") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:TextBox ID="tbxUnitDescriptionNew" Width="120px" runat="server" ReadOnly="true"
                                                                                                                    SkinID="TextBoxReadOnly"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--8--%>
                                                                                        <asp:TemplateField HeaderText="From">
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                            <HeaderStyle Width="100px" />
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblStartDate" runat="server" SkinID="Label" Text='<%# Bind("StartDate", "{0:d}") %>'
                                                                                                                    Style="width: 100px"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpStartDateEdit" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "StartDate") %>' Calendar-ShowRowHeaders="false"
                                                                                                                    Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvStartDateEdit" runat="server" ControlToValidate="tkrdpStartDateEdit" ValidationGroup="unitsEdit"
                                                                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                                                                <asp:CompareValidator ID="cvStartDateEdit" runat="server" Type="Date" ControlToValidate="tkrdpStartDateEdit" ValidationGroup="unitsEdit" SkinID="Validator"
                                                                                                                    Display="Dynamic" ControlToCompare="hdfFrom" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval.">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpStartDateNew" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "StartDate") %>' Calendar-ShowRowHeaders="false"
                                                                                                                    Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvStartDateNew" runat="server" ControlToValidate="tkrdpStartDateNew" ValidationGroup="unitsNew"
                                                                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator" >
                                                                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                                                                <asp:CompareValidator ID="cvStartDateNew" runat="server" Type="Date" ControlToValidate="tkrdpStartDateNew" ValidationGroup="unitsNew" SkinID="Validator"
                                                                                                                    Display="Dynamic" ControlToCompare="hdfFrom" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval.">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--9--%>
                                                                                        <asp:TemplateField HeaderText="To">
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                            <HeaderStyle Width="100px" />
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblEndDate" runat="server" SkinID="Label" Text='<%# Bind("EndDate", "{0:d}") %>'
                                                                                                                    Style="width: 100px"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpEndDateEdit" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "EndDate") %>' Calendar-ShowRowHeaders="false"
                                                                                                                    Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvEndDateEdit" runat="server" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="unitsEdit"
                                                                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                                                                <asp:CompareValidator ID="cvEndDateEdit" runat="server" Type="Date" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="unitsEdit" 
                                                                                                                    Display="Dynamic" ControlToCompare="hdfTo" Operator="LessThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                                                                </asp:CompareValidator>
                                                                                                                <asp:CompareValidator ID="cvEndDate2Edit" runat="server" Type="Date" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="unitsEdit" 
                                                                                                                    Display="Dynamic" ControlToCompare="tkrdpStartDateEdit" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpEndDateNew" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "EndDate") %>' Calendar-ShowRowHeaders="false"
                                                                                                                    Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvEndDateNew" runat="server" ControlToValidate="tkrdpEndDateNew" ValidationGroup="unitsNew"
                                                                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                                                                <asp:CompareValidator ID="cvEndDateNew" runat="server" Type="Date" ControlToValidate="tkrdpEndDateNew" ValidationGroup="unitsNew" 
                                                                                                                    Display="Dynamic" ControlToCompare="hdfTo" Operator="LessThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                                                                </asp:CompareValidator>
                                                                                                                <asp:CompareValidator ID="cvEndDate2New" runat="server" Type="Date" ControlToValidate="tkrdpEndDateNew" ValidationGroup="unitsNew" 
                                                                                                                    Display="Dynamic" ControlToCompare="tkrdpStartDateNew" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--10--%>
                                                                                        <asp:TemplateField HeaderText="Unit of Measurement">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblUnitOfMeasurement" Width="90px" runat="server" SkinID="Label" Text='<%# Eval("UnitOfMeasurement") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="90px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:DropDownList ID="ddlUnitOfMeasurementUnitsEdit" runat="server" DataSourceID="odsUnitsOfMeasurementUnits"
                                                                                                                    DataTextField="Description" DataValueField="Description" EnableViewState="True"
                                                                                                                    SkinID="DropDownListLookup" Width="90px">
                                                                                                                </asp:DropDownList>
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
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:DropDownList ID="ddlUnitOfMeasurementUnitsNew" runat="server" DataSourceID="odsUnitsOfMeasurementUnits"
                                                                                                                    DataTextField="Description" DataValueField="Description" EnableViewState="True"
                                                                                                                    SkinID="DropDownListLookup" Width="90px">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--11--%>
                                                                                        <asp:TemplateField HeaderText="Quantity">
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                                    <tr>
                                                                                                        <td align="center">
                                                                                                            <asp:Label ID="lblQuantity" runat="server" Width="60px" Text='<%# Eval("Quantity", "{0:n2}") %>'
                                                                                                                SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="60px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                                    <tr>
                                                                                                        <td align="center">
                                                                                                            <asp:TextBox ID="tbxQuantityEdit" runat="server" Width="60px" Text='<%# Eval("Quantity", "{0:n2}") %>'
                                                                                                                SkinID="TextBox"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="rfvQuantityEdit" runat="server" ControlToValidate="tbxQuantityEdit"
                                                                                                                ErrorMessage="Please enter a quantity." ValidationGroup="unitsEdit" SkinID="Validator"
                                                                                                                Display="Dynamic" InitialValue="">
                                                                                                            </asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                                    <tr>
                                                                                                        <td align="center">
                                                                                                            <asp:TextBox ID="tbxQuantityNew" Width="60px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="rfvQuantityNew" runat="server" ControlToValidate="tbxQuantityNew"
                                                                                                                ErrorMessage="Please enter a quantity." ValidationGroup="unitsNew" SkinID="Validator"
                                                                                                                Display="Dynamic" InitialValue="">
                                                                                                            </asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--12--%>
                                                                                        <asp:TemplateField HeaderText="Cost (CAD)">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:Label ID="lblCostCAD" Width="70px" runat="server" SkinID="Label" Text='<%# Eval("CostCad", "{0:n2}") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="70px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxCostCADEdit" Width="70px" runat="server" SkinID="TextBox" Text='<%# Eval("CostCad", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvCostCADEdit" runat="server" ControlToValidate="tbxCostCADEdit"
                                                                                                                    ErrorMessage="Please enter a cost." ValidationGroup="unitsCadEdit" SkinID="Validator"
                                                                                                                    Display="Dynamic" InitialValue="">
                                                                                                                </asp:RequiredFieldValidator>
                                                                                                                <asp:CompareValidator ID="cvCostCADEdit" runat="server" ControlToValidate="tbxCostCADEdit"
                                                                                                                    Display="Dynamic" ValidationGroup="unitsCadEdit" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxCostCADNew" Width="70px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvCostCADNew" runat="server" ControlToValidate="tbxCostCADNew"
                                                                                                                    ErrorMessage="Please enter a cost." ValidationGroup="unitsCadNew" SkinID="Validator"
                                                                                                                    Display="Dynamic" InitialValue="">
                                                                                                                </asp:RequiredFieldValidator>
                                                                                                                <asp:CompareValidator ID="cvCostCADNew" runat="server" ControlToValidate="tbxCostCADNew"
                                                                                                                    Display="Dynamic" ValidationGroup="unitsCadNew" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--13--%>
                                                                                        <asp:TemplateField HeaderText="Total Cost (CAD)">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:Label ID="lblTotalCostCAD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("TotalCostCad", "{0:n2}") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="105px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxTotalCostCADEdit" Width="105px" runat="server" SkinID="TextBoxReadOnly"
                                                                                                                    ReadOnly="true" Text='<%# Eval("TotalCostCad", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxTotalCostCADNew" Width="105px" runat="server" SkinID="TextBoxReadOnly"
                                                                                                                    ReadOnly="true"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--14--%>
                                                                                        <asp:TemplateField HeaderText="Cost (USD)">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:Label ID="lblCostUSD" runat="server" Width="70px" SkinID="Label" Text='<%# Eval("CostUsd", "{0:n2}") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="70px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxCostUSDEdit" runat="server" Width="70px" SkinID="TextBox" Text='<%# Eval("CostUsd", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvCostUSDEdit" runat="server" ControlToValidate="tbxCostUSDEdit"
                                                                                                                    ErrorMessage="Please enter a cost." ValidationGroup="unitsUsdEdit" SkinID="Validator"
                                                                                                                    Display="Dynamic" InitialValue="">
                                                                                                                </asp:RequiredFieldValidator>
                                                                                                                <asp:CompareValidator ID="cvCostUSDEdit" runat="server" ControlToValidate="tbxCostUSDEdit"
                                                                                                                    Display="Dynamic" ValidationGroup="unitsUsdEdit" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxCostUSDNew" Width="70px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvCostUSDNew" runat="server" ControlToValidate="tbxCostUSDNew"
                                                                                                                    ErrorMessage="Please enter a cost." ValidationGroup="unitsUsdNew" SkinID="Validator"
                                                                                                                    Display="Dynamic" InitialValue="">
                                                                                                                </asp:RequiredFieldValidator>
                                                                                                                <asp:CompareValidator ID="cvCostUSDNew" runat="server" ControlToValidate="tbxCostUSDNew"
                                                                                                                    Display="Dynamic" ValidationGroup="unitsUsdNew" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--15--%>
                                                                                        <asp:TemplateField HeaderText="Total Cost (USD)">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:Label ID="lblTotalCostUSD" runat="server" Width="105px" SkinID="Label" Text='<%# Eval("TotalCostUsd", "{0:n2}") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="105px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxTotalCostUSDEdit" runat="server" Width="105px" ReadOnly="true"
                                                                                                                    SkinID="TextBoxReadOnly" Text='<%# Eval("TotalCostUsd", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxTotalCostUSDNew" Width="105px" runat="server" ReadOnly="true"
                                                                                                                    SkinID="TextBoxReadOnly"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--Buttons--%>
                                                                                        <asp:TemplateField>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
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
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td style="height: 12px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" __designer:wfdid="w80"
                                                                                                                    CommandName="Add" ToolTip="Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png">
                                                                                                                </asp:ImageButton>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <HeaderStyle Width="60px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td style="width: 50%">
                                                                                                                <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" __designer:wfdid="w76"
                                                                                                                    CommandName="Edit" ToolTip="Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png">
                                                                                                                </asp:ImageButton>
                                                                                                            </td>
                                                                                                            <td style="width: 50%">
                                                                                                                <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" __designer:wfdid="w77"
                                                                                                                    CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this cost?");'
                                                                                                                    ToolTip="Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png">
                                                                                                                </asp:ImageButton>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                                &nbsp;
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table cellpadding="0" cellspacing="0" border="0">
                                                                            <tr>
                                                                                <td style="width: 970px; text-align: right;">
                                                                                </td>
                                                                                <td style="width: 140px; text-align: right;">
                                                                                    <asp:Label ID="lblUnitsTotalCosts" runat="server" SkinID="Label" Text="(USD) : "
                                                                                        Width="140px"></asp:Label>
                                                                                </td>
                                                                                <td style="width: 110px; text-align: right;">
                                                                                    <asp:UpdatePanel ID="upnlUnitsTotalCostsCAD" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:TextBox ID="tbxUnitsTotalCostsCAD" runat="server" SkinID="TextBoxRightReadOnly"
                                                                                                Width="110px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                    <asp:UpdatePanel ID="upnlUnitsTotalCostsUSD" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:TextBox ID="tbxUnitsTotalCostsUSD" runat="server" SkinID="TextBoxRightReadOnly"
                                                                                                Width="110px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </td>
                                                                                <td style="width: 60px;">
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </asp:WizardStep>
                                                    
                                                    
                                                    
                                                    <asp:WizardStep ID="StepMaterialInformation" runat="server" Title="MaterialInformation">
                                                        <div runat="server" id="dvMaterial" style="overflow-x: auto; overflow-y: hidden; width: 930px">
                                                            <table cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblMaterials" runat="server" SkinID="Label" Text="Material Costs"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 7px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:UpdatePanel ID="upnlMaterials" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:GridView ID="grdMaterials" runat="server" SkinID="GridView" Width="930px" AllowPaging="True"
                                                                                    ShowFooter="true" AutoGenerateColumns="False" DataKeyNames="CostingSheetID,MaterialID,RefID"
                                                                                    DataSourceID="odsMaterials" OnDataBound="grdMaterials_DataBound" OnPageIndexChanging="grdMaterials_PageIndexChanging"
                                                                                    PageSize="9" OnRowUpdating="grdMaterials_RowUpdating" OnRowDeleting="grdMaterials_RowDeleting" OnRowEditing="grdMaterials_RowEditing"
                                                                                    OnRowCommand="grdMaterials_RowCommand" OnRowDataBound="grdMaterials_RowDataBound">
                                                                                    <Columns>
                                                                                    
                                                                                        <%--0--%>
                                                                                        <asp:TemplateField HeaderText="CostingSheetID" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblCostingSheetID" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>                                                                                                
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblCostingSheetIDEdit" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                                                                                <telerik:RadDatePicker ID="hdfFrom" runat="server" Visible="false"></telerik:RadDatePicker>
                                                                                                <telerik:RadDatePicker ID="hdfTo" runat="server" Visible="false"></telerik:RadDatePicker>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <telerik:RadDatePicker ID="hdfFrom" runat="server" Visible="false"></telerik:RadDatePicker>
                                                                                                <telerik:RadDatePicker ID="hdfTo" runat="server" Visible="false"></telerik:RadDatePicker>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--1--%>
                                                                                        <asp:TemplateField HeaderText="MaterialID" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblMaterialID" runat="server" SkinID="Label" Text='<%# Eval("MaterialID") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblMaterialIDEdit" runat="server" SkinID="Label" Text='<%# Eval("MaterialID") %>'></asp:Label>
                                                                                            </EditItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--2--%>
                                                                                        <asp:TemplateField HeaderText="RefID" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblRefID" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblRefIDEdit" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                                            </EditItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--3--%>
                                                                                        <asp:TemplateField HeaderText="Project">
                                                                                            <HeaderStyle Width="85px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblProject" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("Project") %>'> </asp:Label>                                                                                                                                                                                             
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <asp:TextBox ID="tbxProjectEdit" Width="85px" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Text='<%# Eval("Project") %>'></asp:TextBox>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <asp:DropDownList Width="85px" ID="ddlProject_New" runat="server" SkinID="DropDownList">
                                                                                                </asp:DropDownList>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--4--%>
                                                                                        <asp:TemplateField HeaderText="Type of Work . Function">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblProcess" Width="55px" runat="server" SkinID="Label" Text='<%# Eval("WorkFunction") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="55px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:TextBox ID="tbxProcessEdit" Width="55px" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly"
                                                                                                                    Text='<%# Eval("WorkFunction") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:TextBox ID="tbxProcessNew" Width="55px" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--5--%>
                                                                                        <asp:TemplateField HeaderText="Description">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblDescription" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("Description") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="85px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:TextBox ID="tbxDescriptionEdit" Width="85px" runat="server" SkinID="TextBoxReadOnly"
                                                                                                                    ReadOnly="true" Text='<%# Eval("Description") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:DropDownList Width="85px" ID="ddlDescriptionNew" runat="server" SkinID="DropDownListLookup"
                                                                                                                    EnableViewState="True" DataTextField="Description" DataValueField="MaterialID"
                                                                                                                    DataSourceID="odsMaterialsList">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--6--%>
                                                                                        <asp:TemplateField HeaderText="From">
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                            <HeaderStyle Width="100px" />
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblStartDate" runat="server" SkinID="Label" Text='<%# Bind("StartDate", "{0:d}") %>'
                                                                                                                    Style="width: 100px"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpStartDateEdit" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "StartDate") %>' Calendar-ShowRowHeaders="false"
                                                                                                                    Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvStartDateEdit" runat="server" ControlToValidate="tkrdpStartDateEdit" ValidationGroup="materialsEdit"
                                                                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                                                                <asp:CompareValidator ID="cvStartDateEdit" runat="server" Type="Date" ControlToValidate="tkrdpStartDateEdit" ValidationGroup="materialsEdit" SkinID="Validator"
                                                                                                                    Display="Dynamic" ControlToCompare="hdfFrom" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval.">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                     </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpStartDateNew" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "StartDate") %>' Calendar-ShowRowHeaders="false"
                                                                                                                    Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvStartDateNew" runat="server" ControlToValidate="tkrdpStartDateNew" ValidationGroup="materialsNew"
                                                                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator" >
                                                                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                                                                <asp:CompareValidator ID="cvStartDateNew" runat="server" Type="Date" ControlToValidate="tkrdpStartDateNew" ValidationGroup="materialsNew" SkinID="Validator"
                                                                                                                    Display="Dynamic" ControlToCompare="hdfFrom" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval.">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--7--%>
                                                                                        <asp:TemplateField HeaderText="To">
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                            <HeaderStyle Width="100px" />
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblEndDate" runat="server" SkinID="Label" Text='<%# Bind("EndDate", "{0:d}") %>'
                                                                                                                    Style="width: 100px"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpEndDateEdit" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "EndDate") %>' Calendar-ShowRowHeaders="false"
                                                                                                                    Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvEndDateEdit" runat="server" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="materialsEdit"
                                                                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                                                                <asp:CompareValidator ID="cvEndDateEdit" runat="server" Type="Date" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="materialsEdit" 
                                                                                                                    Display="Dynamic" ControlToCompare="hdfTo" Operator="LessThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                                                                </asp:CompareValidator>
                                                                                                                <asp:CompareValidator ID="cvEndDate2Edit" runat="server" Type="Date" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="materialsEdit" 
                                                                                                                    Display="Dynamic" ControlToCompare="tkrdpStartDateEdit" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpEndDateNew" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "EndDate") %>' Calendar-ShowRowHeaders="false"
                                                                                                                    Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvEndDateNew" runat="server" ControlToValidate="tkrdpEndDateNew" ValidationGroup="materialsNew"
                                                                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                                                                <asp:CompareValidator ID="cvEndDateNew" runat="server" Type="Date" ControlToValidate="tkrdpEndDateNew" ValidationGroup="materialsNew" 
                                                                                                                    Display="Dynamic" ControlToCompare="hdfTo" Operator="LessThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                                                                </asp:CompareValidator>
                                                                                                                <asp:CompareValidator ID="cvEndDate2New" runat="server" Type="Date" ControlToValidate="tkrdpEndDateNew" ValidationGroup="materialsNew" 
                                                                                                                    Display="Dynamic" ControlToCompare="tkrdpStartDateNew" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--8--%>
                                                                                        <asp:TemplateField HeaderText="Unit of Measurement">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblUnitOfMeasurement" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("UnitOfMeasurement") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="85px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:DropDownList ID="ddlUnitOfMeasurementMaterialsEdit" runat="server" DataSourceID="odsUnitsOfMeasurementMaterials"
                                                                                                                    DataTextField="Description" DataValueField="Description" EnableViewState="True"
                                                                                                                    SkinID="DropDownListLookup" Width="85px">
                                                                                                                </asp:DropDownList>
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
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:DropDownList ID="ddlUnitOfMeasurementMaterialsNew" runat="server" DataSourceID="odsUnitsOfMeasurementMaterials"
                                                                                                                    DataTextField="Description" DataValueField="Description" EnableViewState="True"
                                                                                                                    SkinID="DropDownListLookup" Width="85px">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--9--%>
                                                                                        <asp:TemplateField HeaderText="Quantity">
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                                    <tr>
                                                                                                        <td align="center">
                                                                                                            <asp:Label ID="lblQuantity" Width="60px" runat="server" Text='<%# Eval("Quantity", "{0:n2}") %>'
                                                                                                                SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="60px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                                    <tr>
                                                                                                        <td align="center">
                                                                                                            <asp:TextBox ID="tbxQuantityEdit" Width="60px" runat="server" Text='<%# Eval("Quantity", "{0:n2}") %>'
                                                                                                                SkinID="TextBox"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="rfvQuantityEdit" runat="server" ControlToValidate="tbxQuantityEdit"
                                                                                                                ErrorMessage="Please enter a quantity." ValidationGroup="materialsEdit" SkinID="Validator"
                                                                                                                Display="Dynamic" InitialValue="">
                                                                                                            </asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                                    <tr>
                                                                                                        <td align="center">
                                                                                                            <asp:TextBox ID="tbxQuantityNew" Width="60px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="rfvQuantityNew" runat="server" ControlToValidate="tbxQuantityNew"
                                                                                                                ErrorMessage="Please enter a quantity." ValidationGroup="materialsNew" SkinID="Validator"
                                                                                                                Display="Dynamic" InitialValue="">
                                                                                                            </asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--10--%>
                                                                                        <asp:TemplateField HeaderText="Cost (CAD)">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:Label ID="lblCostCAD" Width="75px" runat="server" SkinID="Label" Text='<%# Eval("CostCad", "{0:n2}") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="75px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxCostCADEdit" Width="75px" runat="server" SkinID="TextBox" Text='<%# Eval("CostCad", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvCostCADEdit" runat="server" ControlToValidate="tbxCostCADEdit"
                                                                                                                    ErrorMessage="Please enter a cost." ValidationGroup="materialsCadEdit" SkinID="Validator"
                                                                                                                    Display="Dynamic" InitialValue="">
                                                                                                                </asp:RequiredFieldValidator>
                                                                                                                <asp:CompareValidator ID="cvCostCADEdit" runat="server" ControlToValidate="tbxCostCADEdit"
                                                                                                                    Display="Dynamic" ValidationGroup="materialsCadEdit" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxCostCADNew" Width="75px" runat="server" SkinID="TextBox" Text='<%# Eval("CostCad", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvCostCADNew" runat="server" ControlToValidate="tbxCostCADNew"
                                                                                                                    ErrorMessage="Please enter a cost." ValidationGroup="materialsCadNew" SkinID="Validator"
                                                                                                                    Display="Dynamic" InitialValue="">
                                                                                                                </asp:RequiredFieldValidator>
                                                                                                                <asp:CompareValidator ID="cvCostCostCADNew" runat="server" ControlToValidate="tbxCostCADNew"
                                                                                                                    Display="Dynamic" ValidationGroup="materialsCadNew" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--11--%>
                                                                                        <asp:TemplateField HeaderText="Total Cost (CAD)">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:Label ID="lblTotalCostCAD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("TotalCostCad", "{0:n2}") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="105px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxTotalCostCADEdit" Width="105px" runat="server" ReadOnly="true"
                                                                                                                    SkinID="TextBoxReadOnly" Text='<%# Eval("TotalCostCad", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxTotalCostCADNew" Width="105px" runat="server" ReadOnly="true"
                                                                                                                    SkinID="TextBoxReadOnly"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--12--%>
                                                                                        <asp:TemplateField HeaderText="Cost (USD)">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:Label ID="lblCostUSD" Width="75px" runat="server" SkinID="Label" Text='<%# Eval("CostUsd", "{0:n2}") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="75px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxCostUSDEdit" Width="75px" runat="server" SkinID="TextBox" Text='<%# Eval("CostUsd", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvCostUSDEdit" runat="server" ControlToValidate="tbxCostUSDEdit"
                                                                                                                    ErrorMessage="Please enter a cost." ValidationGroup="materialsUsdEdit" SkinID="Validator"
                                                                                                                    Display="Dynamic" InitialValue="">
                                                                                                                </asp:RequiredFieldValidator>
                                                                                                                <asp:CompareValidator ID="cvCostUSDEdit" runat="server" ControlToValidate="tbxCostUSDEdit"
                                                                                                                    Display="Dynamic" ValidationGroup="materialsUsdEdit" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxCostUSDNew" Width="75px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvCostUSDNew" runat="server" ControlToValidate="tbxCostUSDNew"
                                                                                                                    ErrorMessage="Please enter a cost." ValidationGroup="materialsUsdNew" SkinID="Validator"
                                                                                                                    Display="Dynamic" InitialValue="">
                                                                                                                </asp:RequiredFieldValidator>
                                                                                                                <asp:CompareValidator ID="cvCostUSDNew" runat="server" ControlToValidate="tbxCostUSDNew"
                                                                                                                    Display="Dynamic" ValidationGroup="materialsUsdNew" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--13--%>
                                                                                        <asp:TemplateField HeaderText="Total Cost (USD)">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:Label ID="lblTotalCostUSD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("TotalCostUsd", "{0:n2}") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="105px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxTotalCostUSDEdit" Width="105px" runat="server" ReadOnly="true"
                                                                                                                    SkinID="TextBoxReadOnly" Text='<%# Eval("TotalCostUsd", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxTotalCostUSDNew" Width="105px" runat="server" ReadOnly="true"
                                                                                                                    SkinID="TextBoxReadOnly"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--Buttons--%>
                                                                                        <asp:TemplateField>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
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
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td style="height: 12px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" __designer:wfdid="w80"
                                                                                                                    CommandName="Add" ToolTip="Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png">
                                                                                                                </asp:ImageButton>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <HeaderStyle Width="40px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td style="width: 50%">
                                                                                                                <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" __designer:wfdid="w76"
                                                                                                                    CommandName="Edit" ToolTip="Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png">
                                                                                                                </asp:ImageButton>
                                                                                                            </td>
                                                                                                            <td style="width: 50%">
                                                                                                                <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" __designer:wfdid="w77"
                                                                                                                    CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this cost?");'
                                                                                                                    ToolTip="Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png">
                                                                                                                </asp:ImageButton>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                                &nbsp;
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table cellpadding="0" cellspacing="0" border="0">
                                                                            <tr>
                                                                                <td style="width: 435px;">
                                                                                </td>
                                                                                <td style="width: 145px; text-align: right;">
                                                                                    <asp:Label ID="lblMaterialsTotalCosts" Width="145px" runat="server" SkinID="Label"
                                                                                        Text="(USD) : "></asp:Label>
                                                                                </td>
                                                                                <td style="width: 110px; text-align: right;">
                                                                                    <asp:UpdatePanel ID="upnlMaterialsTotalCostsCAD" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:TextBox ID="tbxMaterialsTotalCostsCAD" runat="server" SkinID="TextBoxRightReadOnly"
                                                                                                Width="110px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                    <asp:UpdatePanel ID="upnlMaterialsTotalCostsUSD" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:TextBox ID="tbxMaterialsTotalCostsUSD" runat="server" SkinID="TextBoxRightReadOnly"
                                                                                                Width="110px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </asp:WizardStep>
                                                    
                                                    
                                                    
                                                    <asp:WizardStep ID="StepSubcontractorInformation" runat="server" Title="SubcontractorInformation">
                                                        <div runat="server" id="dvSubcontractor" style="overflow-x: auto; overflow-y: hidden; width: 930px">
                                                            <table cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblSubcontractors" runat="server" SkinID="Label" Text="Subcontractor Costs"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 7px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:UpdatePanel ID="upnlSubcontractors" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:GridView ID="grdSubcontractors" runat="server" SkinID="GridView" Width="930px" AllowPaging="True"
                                                                                    ShowFooter="true" AutoGenerateColumns="False" DataKeyNames="CostingSheetID,SubcontractorID,RefID"
                                                                                    DataSourceID="odsSubcontractors" OnDataBound="grdSubcontractors_DataBound" OnPageIndexChanging="grdSubcontractors_PageIndexChanging" OnRowDataBound="grdSubcontractors_RowDataBound"
                                                                                    PageSize="9" OnRowUpdating="grdSubcontractors_RowUpdating" OnRowDeleting="grdSubcontractors_RowDeleting" OnRowEditing="grdSubcontractors_RowEditing"
                                                                                    OnRowCommand="grdSubcontractors_RowCommand">
                                                                                    <Columns>
                                                                                    
                                                                                        <%--0--%>
                                                                                        <asp:TemplateField HeaderText="CostingSheetID" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblCostingSheetID" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>                                                                                                
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblCostingSheetIDEdit" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                                                                                <telerik:RadDatePicker ID="hdfFrom" runat="server" Visible="false"></telerik:RadDatePicker>
                                                                                                <telerik:RadDatePicker ID="hdfTo" runat="server" Visible="false"></telerik:RadDatePicker>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <telerik:RadDatePicker ID="hdfFrom" runat="server" Visible="false"></telerik:RadDatePicker>
                                                                                                <telerik:RadDatePicker ID="hdfTo" runat="server" Visible="false"></telerik:RadDatePicker>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--1--%>
                                                                                        <asp:TemplateField HeaderText="SubcontractorID" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblSubcontractorID" runat="server" SkinID="Label" Text='<%# Eval("SubcontractorID") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblSubcontractorIDEdit" runat="server" SkinID="Label" Text='<%# Eval("SubcontractorID") %>'></asp:Label>
                                                                                            </EditItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--2--%>
                                                                                        <asp:TemplateField HeaderText="RefID" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblRefID" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblRefIDEdit" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                                            </EditItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--3--%>
                                                                                        <asp:TemplateField HeaderText="Project">
                                                                                            <HeaderStyle Width="85px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblProject" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("Project") %>'> </asp:Label>                                                                                                                                                                                             
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <asp:TextBox ID="tbxProjectEdit" Width="85px" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Text='<%# Eval("Project") %>'></asp:TextBox>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <asp:DropDownList Width="85px" ID="ddlProject_New" runat="server" SkinID="DropDownList">
                                                                                                </asp:DropDownList>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--4--%>
                                                                                        <asp:TemplateField HeaderText="Date">
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                            <HeaderStyle Width="100px" />
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblStartDate" runat="server" SkinID="Label" Text='<%# Bind("StartDate", "{0:d}") %>'
                                                                                                                    Style="width: 100px"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpStartDateEdit" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "StartDate") %>' Calendar-ShowRowHeaders="false"
                                                                                                                    Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvStartDateEdit" runat="server" ControlToValidate="tkrdpStartDateEdit" ValidationGroup="subcontractorEdit"
                                                                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                                                                <asp:CompareValidator ID="cvStartDateEdit" runat="server" Type="Date" ControlToValidate="tkrdpStartDateEdit" ValidationGroup="subcontractorEdit" SkinID="Validator"
                                                                                                                    Display="Dynamic" ControlToCompare="hdfFrom" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval.">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                     </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpStartDateNew" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "StartDate") %>' Calendar-ShowRowHeaders="false"
                                                                                                                    Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvStartDateNew" runat="server" ControlToValidate="tkrdpStartDateNew" ValidationGroup="subcontractorNew"
                                                                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator" >
                                                                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                                                                <asp:CompareValidator ID="cvStartDateNew" runat="server" Type="Date" ControlToValidate="tkrdpStartDateNew" ValidationGroup="subcontractorNew" SkinID="Validator"
                                                                                                                    Display="Dynamic" ControlToCompare="hdfFrom" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval.">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--5--%>
                                                                                        <asp:TemplateField HeaderText="To" Visible="false">
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                            <HeaderStyle Width="100px" />
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblEndDate" runat="server" SkinID="Label" Text='<%# Bind("EndDate", "{0:d}") %>'
                                                                                                                    Style="width: 100px"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpEndDateEdit" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "EndDate") %>' Calendar-ShowRowHeaders="false"
                                                                                                                    Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvEndDateEdit" runat="server" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="subcontractorEdit"
                                                                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                                                                <asp:CompareValidator ID="cvEndDateEdit" runat="server" Type="Date" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="subcontractorEdit" 
                                                                                                                    Display="Dynamic" ControlToCompare="hdfTo" Operator="LessThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                                                                </asp:CompareValidator>
                                                                                                                <asp:CompareValidator ID="cvEndDate2Edit" runat="server" Type="Date" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="subcontractorEdit" 
                                                                                                                    Display="Dynamic" ControlToCompare="tkrdpStartDateEdit" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpEndDateNew" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "EndDate") %>' Calendar-ShowRowHeaders="false"
                                                                                                                    Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvEndDateNew" runat="server" ControlToValidate="tkrdpEndDateNew" ValidationGroup="subcontractorNew"
                                                                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                                                                <asp:CompareValidator ID="cvEndDateNew" runat="server" Type="Date" ControlToValidate="tkrdpEndDateNew" ValidationGroup="subcontractorNew" 
                                                                                                                    Display="Dynamic" ControlToCompare="hdfTo" Operator="LessThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                                                                </asp:CompareValidator>
                                                                                                                <asp:CompareValidator ID="cvEndDate2New" runat="server" Type="Date" ControlToValidate="tkrdpEndDateNew" ValidationGroup="subcontractorNew" 
                                                                                                                    Display="Dynamic" ControlToCompare="tkrdpStartDateNew" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--6--%>
                                                                                        <asp:TemplateField HeaderText="Subcontractor">
                                                                                            <HeaderStyle Width="95px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblSubcontractor" Width="95px" runat="server" SkinID="Label" Text='<%# Eval("Subcontractor") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:TextBox ID="tbxSubcontractorEdit" Width="95px" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly"
                                                                                                                    Text='<%# Eval("Subcontractor") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:DropDownList Width="95px" ID="ddlSubcontractorNew" runat="server" SkinID="DropDownList" DataTextField="Name" DataMember="DefaultView" DataValueField="SubcontractorID"
                                                                                                                    DataSourceID="odsSubcontractorsList"  >
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--7--%>
                                                                                        <asp:TemplateField HeaderText="Unit of Measurement">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblUnitOfMeasurement" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("UnitOfMeasurement") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="85px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:DropDownList ID="ddlUnitOfMeasurementSubcontractorsEdit" runat="server" DataSourceID="odsUnitsOfMeasurementSubcontractor"
                                                                                                                    DataTextField="Description" DataValueField="Description" EnableViewState="True"
                                                                                                                    SkinID="DropDownListLookup" Width="85px">
                                                                                                                </asp:DropDownList>
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
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:DropDownList ID="ddlUnitOfMeasurementSubcontractorsNew" runat="server" DataSourceID="odsUnitsOfMeasurementSubcontractor"
                                                                                                                    DataTextField="Description" DataValueField="Description" EnableViewState="True"
                                                                                                                    SkinID="DropDownListLookup" Width="85px">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--8--%>
                                                                                        <asp:TemplateField HeaderText="Quantity">
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                                    <tr>
                                                                                                        <td align="center">
                                                                                                            <asp:Label ID="lblQuantity" Width="60px" runat="server" Text='<%# Eval("Quantity", "{0:n2}") %>'
                                                                                                                SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="60px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                                    <tr>
                                                                                                        <td align="center">
                                                                                                            <asp:TextBox ID="tbxQuantityEdit" Width="60px" runat="server" Text='<%# Eval("Quantity", "{0:n2}") %>'
                                                                                                                SkinID="TextBox"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="rfvQuantityEdit" runat="server" ControlToValidate="tbxQuantityEdit"
                                                                                                                ErrorMessage="Please enter a quantity." ValidationGroup="subcontractorsEdit" SkinID="Validator"
                                                                                                                Display="Dynamic" InitialValue="">
                                                                                                            </asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                                    <tr>
                                                                                                        <td align="center">
                                                                                                            <asp:TextBox ID="tbxQuantityNew" Width="60px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="rfvQuantityNew" runat="server" ControlToValidate="tbxQuantityNew"
                                                                                                                ErrorMessage="Please enter a quantity." ValidationGroup="subcontractorsNew" SkinID="Validator"
                                                                                                                Display="Dynamic" InitialValue="">
                                                                                                            </asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--9--%>
                                                                                        <asp:TemplateField HeaderText="Cost (CAD)">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:Label ID="lblCostCAD" Width="75px" runat="server" SkinID="Label" Text='<%# Eval("CostCad", "{0:n2}") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="75px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxCostCADEdit" Width="75px" runat="server" SkinID="TextBox" Text='<%# Eval("CostCad", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvCostCADEdit" runat="server" ControlToValidate="tbxCostCADEdit"
                                                                                                                    ErrorMessage="Please enter a cost." ValidationGroup="subcontractorsCadEdit" SkinID="Validator"
                                                                                                                    Display="Dynamic" InitialValue="">
                                                                                                                </asp:RequiredFieldValidator>
                                                                                                                <asp:CompareValidator ID="cvCostCADEdit" runat="server" ControlToValidate="tbxCostCADEdit"
                                                                                                                    Display="Dynamic" ValidationGroup="subcontractorsCadEdit" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxCostCADNew" Width="75px" runat="server" SkinID="TextBox" Text='<%# Eval("CostCad", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvCostCADNew" runat="server" ControlToValidate="tbxCostCADNew"
                                                                                                                    ErrorMessage="Please enter a cost." ValidationGroup="subcontractorsCadNew" SkinID="Validator"
                                                                                                                    Display="Dynamic" InitialValue="">
                                                                                                                </asp:RequiredFieldValidator>
                                                                                                                <asp:CompareValidator ID="cvCostCostCADNew" runat="server" ControlToValidate="tbxCostCADNew"
                                                                                                                    Display="Dynamic" ValidationGroup="subcontractorsCadNew" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--10--%>
                                                                                        <asp:TemplateField HeaderText="Total Cost (CAD)">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:Label ID="lblTotalCostCAD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("TotalCostCad", "{0:n2}") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="105px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxTotalCostCADEdit" Width="105px" runat="server" ReadOnly="true"
                                                                                                                    SkinID="TextBoxReadOnly" Text='<%# Eval("TotalCostCad", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxTotalCostCADNew" Width="105px" runat="server" ReadOnly="true"
                                                                                                                    SkinID="TextBoxReadOnly"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--11--%>
                                                                                        <asp:TemplateField HeaderText="Cost (USD)">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:Label ID="lblCostUSD" Width="75px" runat="server" SkinID="Label" Text='<%# Eval("CostUsd", "{0:n2}") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="75px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxCostUSDEdit" Width="75px" runat="server" SkinID="TextBox" Text='<%# Eval("CostUsd", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvCostUSDEdit" runat="server" ControlToValidate="tbxCostUSDEdit"
                                                                                                                    ErrorMessage="Please enter a cost." ValidationGroup="subcontractorsUsdEdit" SkinID="Validator"
                                                                                                                    Display="Dynamic" InitialValue="">
                                                                                                                </asp:RequiredFieldValidator>
                                                                                                                <asp:CompareValidator ID="cvCostUSDEdit" runat="server" ControlToValidate="tbxCostUSDEdit"
                                                                                                                    Display="Dynamic" ValidationGroup="subcontractorsUsdEdit" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxCostUSDNew" Width="75px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvCostUSDNew" runat="server" ControlToValidate="tbxCostUSDNew"
                                                                                                                    ErrorMessage="Please enter a cost." ValidationGroup="subcontractorsUsdNew" SkinID="Validator"
                                                                                                                    Display="Dynamic" InitialValue="">
                                                                                                                </asp:RequiredFieldValidator>
                                                                                                                <asp:CompareValidator ID="cvCostUSDNew" runat="server" ControlToValidate="tbxCostUSDNew"
                                                                                                                    Display="Dynamic" ValidationGroup="subcontractorsUsdNew" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--12--%>
                                                                                        <asp:TemplateField HeaderText="Total Cost (USD)">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:Label ID="lblTotalCostUSD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("TotalCostUsd", "{0:n2}") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="105px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxTotalCostUSDEdit" Width="105px" runat="server" ReadOnly="true"
                                                                                                                    SkinID="TextBoxReadOnly" Text='<%# Eval("TotalCostUsd", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxTotalCostUSDNew" Width="105px" runat="server" ReadOnly="true"
                                                                                                                    SkinID="TextBoxReadOnly"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--13--%>
                                                                                        <asp:TemplateField HeaderText="Comment">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblComment" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("Comment") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="85px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:TextBox ID="tbxCommentEdit" Width="85px" runat="server" SkinID="TextBox"
                                                                                                                    Text='<%# Eval("Comment") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:TextBox ID="tbxCommentNew" Width="85px" runat="server" SkinID="TextBox"
                                                                                                                    Text='<%# Eval("Comment") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--Buttons--%>
                                                                                        <asp:TemplateField>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
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
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td style="height: 12px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" __designer:wfdid="w80"
                                                                                                                    CommandName="Add" ToolTip="Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png">
                                                                                                                </asp:ImageButton>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <HeaderStyle Width="40px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td style="width: 50%">
                                                                                                                <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" __designer:wfdid="w76"
                                                                                                                    CommandName="Edit" ToolTip="Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png">
                                                                                                                </asp:ImageButton>
                                                                                                            </td>
                                                                                                            <td style="width: 50%">
                                                                                                                <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" __designer:wfdid="w77"
                                                                                                                    CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this cost?");'
                                                                                                                    ToolTip="Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png">
                                                                                                                </asp:ImageButton>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                                &nbsp;
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table cellpadding="0" cellspacing="0" border="0">
                                                                            <tr>
                                                                                <td style="width: 400px;">
                                                                                </td>
                                                                                <td style="width: 110px; text-align: right;">
                                                                                    <asp:Label ID="lblSubcontractorsTotalCosts" Width="110px" runat="server" SkinID="Label"
                                                                                        Text="(USD) : "></asp:Label>
                                                                                </td>
                                                                                <td style="width: 125px; text-align: right;">
                                                                                    <asp:UpdatePanel ID="upnlSubcontractorsTotalCostsCAD" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:TextBox ID="tbxSubcontractorsTotalCostsCAD" runat="server" SkinID="TextBoxRightReadOnly"
                                                                                                Width="125px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                    <asp:UpdatePanel ID="upnlSubcontractorsTotalCostsUSD" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:TextBox ID="tbxSubcontractorsTotalCostsUSD" runat="server" SkinID="TextBoxRightReadOnly"
                                                                                                Width="125px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </asp:WizardStep>
                                                    
                                                    
                                                    
                                                    <asp:WizardStep ID="StepOtherCostInformation" runat="server" Title="OtherCostInformation">
                                                        <div runat="server" id="dvOtherCost" style="overflow-x: auto; overflow-y: hidden; width: 930px">
                                                            <table cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblOtherCosts" runat="server" SkinID="Label" Text="Misc Costs"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 7px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:UpdatePanel ID="upnlOtherCosts" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:GridView ID="grdOtherCosts" runat="server" SkinID="GridView" Width="930px" AllowPaging="True"
                                                                                    AutoGenerateColumns="False" DataKeyNames="CostingSheetID,RefID" DataSourceID="odsOtherCosts" OnRowEditing="grdOtherCosts_RowEditing"
                                                                                    ShowFooter="true" OnDataBound="grdOtherCosts_DataBound" OnRowDataBound="grdOtherCosts_RowDataBound"
                                                                                    PageSize="9" OnRowUpdating="grdOtherCosts_RowUpdating" OnRowDeleting="grdOtherCosts_RowDeleting"
                                                                                    OnRowCommand="grdOtherCosts_RowCommand">
                                                                                    <Columns>
                                                                                    
                                                                                        <%--0--%>
                                                                                        <asp:TemplateField HeaderText="CostingSheetID" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblCostingSheetID" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblCostingSheetIDEdit" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                                                                                <telerik:RadDatePicker ID="hdfFrom" runat="server" Visible="false"></telerik:RadDatePicker>
                                                                                                <telerik:RadDatePicker ID="hdfTo" runat="server" Visible="false"></telerik:RadDatePicker>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <telerik:RadDatePicker ID="hdfFrom" runat="server" Visible="false"></telerik:RadDatePicker>
                                                                                                <telerik:RadDatePicker ID="hdfTo" runat="server" Visible="false"></telerik:RadDatePicker>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--1--%>
                                                                                        <asp:TemplateField HeaderText="RefID" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblRefID" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblRefIDEdit" runat="server" SkinID="Label" Text='<%# Eval("RefID") %>'></asp:Label>
                                                                                            </EditItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--2--%>
                                                                                        <asp:TemplateField HeaderText="Project">
                                                                                            <HeaderStyle Width="85px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblProject" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("Project") %>'> </asp:Label>                                                                                                                                                                                             
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <asp:TextBox ID="tbxProjectEdit" Width="85px" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Text='<%# Eval("Project") %>'></asp:TextBox>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <asp:DropDownList Width="85px" ID="ddlProject_New" runat="server" SkinID="DropDownList">
                                                                                                </asp:DropDownList>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--3--%>
                                                                                        <asp:TemplateField HeaderText="Type of Work . Function">
                                                                                            <HeaderStyle Width="150px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblWorkFunction" Width="150px" runat="server" SkinID="Label" Text='<%# Eval("WorkFunction") %>'></asp:Label>
                                                                                            </ItemTemplate>                                                                                            
                                                                                            <EditItemTemplate>
                                                                                                <asp:DropDownList Width="150px" ID="ddlWorkFunctionEdit" runat="server" SkinID="DropDownList"
                                                                                                    DataSourceID="odsWorkFunctionConcat" DataTextField="WorkFunctionConcat" DataValueField="WorkFunctionConcat">
                                                                                                </asp:DropDownList>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                               <asp:DropDownList Width="150px" ID="ddlWorkFunctionNew" runat="server" SkinID="DropDownList"
                                                                                                    DataSourceID="odsWorkFunctionConcat" DataTextField="WorkFunctionConcat" DataValueField="WorkFunctionConcat">
                                                                                                </asp:DropDownList>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--4--%>
                                                                                        <asp:TemplateField HeaderText="Description">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblDescription" Width="100px" runat="server" SkinID="Label" Text='<%# Eval("Description") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="100px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:TextBox ID="tbxDescriptionEdit" Width="100px" runat="server" SkinID="TextBox"
                                                                                                                    Text='<%# Eval("Description") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvDescriptionEdit" runat="server" ControlToValidate="tbxDescriptionEdit"
                                                                                                                    ErrorMessage="Please enter a description." ValidationGroup="otherCostsEdit" SkinID="Validator"
                                                                                                                    Display="Dynamic" InitialValue="">
                                                                                                                </asp:RequiredFieldValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:TextBox ID="tbxDescriptionNew" Width="100px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvDescriptionNew" runat="server" ControlToValidate="tbxDescriptionNew"
                                                                                                                    ErrorMessage="Please enter a description." ValidationGroup="otherCostsNew" SkinID="Validator"
                                                                                                                    Display="Dynamic" InitialValue="">
                                                                                                                </asp:RequiredFieldValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--5--%>
                                                                                        <asp:TemplateField HeaderText="From">
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                            <HeaderStyle Width="100px" />
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblStartDate" runat="server" SkinID="Label" Text='<%# Bind("StartDate", "{0:d}") %>'
                                                                                                                    Style="width: 100px"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpStartDateEdit" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "StartDate") %>' Calendar-ShowRowHeaders="false"
                                                                                                                    Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvStartDateEdit" runat="server" ControlToValidate="tkrdpStartDateEdit" ValidationGroup="otherCostsEdit"
                                                                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                                                                <asp:CompareValidator ID="cvStartDateEdit" runat="server" Type="Date" ControlToValidate="tkrdpStartDateEdit" ValidationGroup="otherCostsEdit" SkinID="Validator"
                                                                                                                    Display="Dynamic" ControlToCompare="hdfFrom" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval.">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpStartDateNew" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "StartDate") %>' Calendar-ShowRowHeaders="false"
                                                                                                                    Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvStartDateNew" runat="server" ControlToValidate="tkrdpStartDateNew" ValidationGroup="otherCostsNew"
                                                                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator" >
                                                                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                                                                <asp:CompareValidator ID="cvStartDateNew" runat="server" Type="Date" ControlToValidate="tkrdpStartDateNew" ValidationGroup="otherCostsNew" SkinID="Validator"
                                                                                                                    Display="Dynamic" ControlToCompare="hdfFrom" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval.">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--6--%>
                                                                                        <asp:TemplateField HeaderText="To">
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                            <HeaderStyle Width="100px" />
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblEndDate" runat="server" SkinID="Label" Text='<%# Bind("EndDate", "{0:d}") %>'
                                                                                                                    Style="width: 100px"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpEndDateEdit" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "EndDate") %>' Calendar-ShowRowHeaders="false"
                                                                                                                    Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvEndDateEdit" runat="server" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="otherCostsEdit"
                                                                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                                                                <asp:CompareValidator ID="cvEndDateEdit" runat="server" Type="Date" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="otherCostsEdit" 
                                                                                                                    Display="Dynamic" ControlToCompare="hdfTo" Operator="LessThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                                                                </asp:CompareValidator>
                                                                                                                <asp:CompareValidator ID="cvEndDate2Edit" runat="server" Type="Date" ControlToValidate="tkrdpEndDateEdit" ValidationGroup="otherCostsEdit" 
                                                                                                                    Display="Dynamic" ControlToCompare="tkrdpStartDateEdit" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpEndDateNew" runat="server" Width="100px" SkinID="RadDatePicker"
                                                                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "EndDate") %>' Calendar-ShowRowHeaders="false"
                                                                                                                    Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvEndDateNew" runat="server" ControlToValidate="tkrdpEndDateNew" ValidationGroup="otherCostsNew"
                                                                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                                                                </asp:RequiredFieldValidator>                                                                                                                
                                                                                                                <asp:CompareValidator ID="cvEndDateNew" runat="server" Type="Date" ControlToValidate="tkrdpEndDateNew" ValidationGroup="otherCostsNew" 
                                                                                                                    Display="Dynamic" ControlToCompare="hdfTo" Operator="LessThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                                                                </asp:CompareValidator>
                                                                                                                <asp:CompareValidator ID="cvEndDate2New" runat="server" Type="Date" ControlToValidate="tkrdpEndDateNew" ValidationGroup="otherCostsNew" 
                                                                                                                    Display="Dynamic" ControlToCompare="tkrdpStartDateNew" Operator="GreaterThanEqual" ErrorMessage="You cannot add costing sheet in that interval." SkinID="Validator">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--7--%>
                                                                                        <asp:TemplateField HeaderText="Unit of Measurement">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblUnitOfMeasurement" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("UnitOfMeasurement") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="85px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:DropDownList ID="ddlUnitOfMeasurementOthersEdit" runat="server" SkinID="DropDownList"
                                                                                                                    DataTextField="Description" DataMember="DefaultView" DataValueField="Description"
                                                                                                                    DataSourceID="odsUnitsOfMeasurementOthers" Width="85px">
                                                                                                                </asp:DropDownList>
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
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:DropDownList Width="85px" ID="ddlUnitOfMeasurementOthersNew" runat="server"
                                                                                                                    SkinID="DropDownList" DataTextField="Description" DataMember="DefaultView" DataValueField="Description"
                                                                                                                    DataSourceID="odsUnitsOfMeasurementOthers">
                                                                                                                </asp:DropDownList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--8--%>
                                                                                        <asp:TemplateField HeaderText="Quantity">
                                                                                            <ItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                                    <tr>
                                                                                                        <td align="center">
                                                                                                            <asp:Label ID="lblQuantity" Width="60px" runat="server" Text='<%# Eval("Quantity", "{0:n2}") %>'
                                                                                                                SkinID="Label"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="60px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                                    <tr>
                                                                                                        <td align="center">
                                                                                                            <asp:TextBox ID="tbxQuantityEdit" Width="60px" runat="server" Text='<%# Eval("Quantity", "{0:n2}") %>'
                                                                                                                SkinID="TextBox"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="rfvQuantityEdit" runat="server" ControlToValidate="tbxQuantityEdit"
                                                                                                                ErrorMessage="Please enter a quantity." ValidationGroup="otherCostsEdit" SkinID="Validator"
                                                                                                                Display="Dynamic" InitialValue="">
                                                                                                            </asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellpadding="0" cellspacing="0" border="0">
                                                                                                    <tr>
                                                                                                        <td align="center">
                                                                                                            <asp:TextBox ID="tbxQuantityNew" Width="60px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="rfvQuantityNew" runat="server" ControlToValidate="tbxQuantityNew"
                                                                                                                ErrorMessage="Please enter a quantity." ValidationGroup="otherCostsNew" SkinID="Validator"
                                                                                                                Display="Dynamic" InitialValue="">
                                                                                                            </asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--9--%>
                                                                                        <asp:TemplateField HeaderText="Cost (CAD)">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:Label ID="lblCostCAD" Width="75px" runat="server" SkinID="Label" Text='<%# Eval("CostCad", "{0:n2}") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="75px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxCostCADEdit" Width="75px" runat="server" SkinID="TextBox" Text='<%# Eval("CostCad", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvCostCADEdit" runat="server" ControlToValidate="tbxCostCADEdit"
                                                                                                                    ErrorMessage="Please enter a cost." ValidationGroup="otherCostsCadEdit" SkinID="Validator"
                                                                                                                    Display="Dynamic" InitialValue="">
                                                                                                                </asp:RequiredFieldValidator>
                                                                                                                <asp:CompareValidator ID="cvCostCADEdit" runat="server" ControlToValidate="tbxCostCADEdit"
                                                                                                                    Display="Dynamic" ValidationGroup="otherCostsCadEdit" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxCostCADNew" Width="75px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvCostCADNew" runat="server" ControlToValidate="tbxCostCADNew"
                                                                                                                    ErrorMessage="Please enter a cost." ValidationGroup="otherCostsCadNew" SkinID="Validator"
                                                                                                                    Display="Dynamic" InitialValue="">
                                                                                                                </asp:RequiredFieldValidator>
                                                                                                                <asp:CompareValidator ID="cvCostCADNew" runat="server" ControlToValidate="tbxCostCADNew"
                                                                                                                    Display="Dynamic" ValidationGroup="otherCostsCadNew" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--10--%>
                                                                                        <asp:TemplateField HeaderText="Total Cost (CAD)">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:Label ID="lblTotalCostCAD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("TotalCostCad", "{0:n2}") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="105px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxTotalCostCADEdit" Width="105px" runat="server" ReadOnly="true"
                                                                                                                    SkinID="TextBoxReadOnly" Text='<%# Eval("TotalCostCad", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxTotalCostCADNew" Width="105px" runat="server" ReadOnly="true"
                                                                                                                    SkinID="TextBoxReadOnly"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--11--%>
                                                                                        <asp:TemplateField HeaderText="Cost (USD)">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:Label ID="lblCostUSD" Width="75px" runat="server" SkinID="Label" Text='<%# Eval("CostUsd", "{0:n2}") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="75px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxCostUSDEdit" Width="75px" runat="server" SkinID="TextBox" Text='<%# Eval("CostUsd", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvCostUSDEdit" runat="server" ControlToValidate="tbxCostUSDEdit"
                                                                                                                    ErrorMessage="Please enter a cost." ValidationGroup="otherCostsUsdEdit" SkinID="Validator"
                                                                                                                    Display="Dynamic" InitialValue="">
                                                                                                                </asp:RequiredFieldValidator>
                                                                                                                <asp:CompareValidator ID="cvCostUSDEdit" runat="server" ControlToValidate="tbxCostUSDEdit"
                                                                                                                    Display="Dynamic" ValidationGroup="otherCostsUsdEdit" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxCostUSDNew" Width="75px" runat="server" SkinID="TextBox"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvCostUSDNew" runat="server" ControlToValidate="tbxCostUSDNew"
                                                                                                                    ErrorMessage="Please enter a cost." ValidationGroup="otherCostsUsdNew" SkinID="Validator"
                                                                                                                    Display="Dynamic" InitialValue="">
                                                                                                                </asp:RequiredFieldValidator>
                                                                                                                <asp:CompareValidator ID="cvCostUSDNew" runat="server" ControlToValidate="tbxCostUSDNew"
                                                                                                                    Display="Dynamic" ValidationGroup="otherCostsUsdNew" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--12--%>
                                                                                        <asp:TemplateField HeaderText="Total Cost (USD)">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:Label ID="lblTotalCostUSD" Width="105px" runat="server" SkinID="Label" Text='<%# Eval("TotalCostUsd", "{0:n2}") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="105px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxTotalCostUSDEdit" Width="105px" runat="server" ReadOnly="true"
                                                                                                                    SkinID="TextBoxReadOnly" Text='<%# Eval("TotalCostUsd", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxTotalCostUSDNew" Width="105px" runat="server" ReadOnly="true"
                                                                                                                    SkinID="TextBoxReadOnly"></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--Buttons--%>
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
                                                                                                                <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" __designer:wfdid="w80"
                                                                                                                    CommandName="Add" ToolTip="Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png">
                                                                                                                </asp:ImageButton>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <HeaderStyle Width="40px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td style="width: 50%">
                                                                                                                <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" __designer:wfdid="w76"
                                                                                                                    CommandName="Edit" ToolTip="Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png">
                                                                                                                </asp:ImageButton>
                                                                                                            </td>
                                                                                                            <td style="width: 50%">
                                                                                                                <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" __designer:wfdid="w77"
                                                                                                                    CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this cost?");'
                                                                                                                    ToolTip="Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png">
                                                                                                                </asp:ImageButton>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                                &nbsp;
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table cellpadding="0" cellspacing="0" border="0">
                                                                            <tr>
                                                                                <td style="width: 545px;">
                                                                                </td>
                                                                                <td style="width: 145px; text-align: right;">
                                                                                    <asp:Label ID="lblOtherCostsTotalCosts" Width="145px" runat="server" SkinID="Label"
                                                                                        Text="(USD) : "></asp:Label>
                                                                                </td>
                                                                                <td style="width: 110px; text-align: right;">
                                                                                    <asp:UpdatePanel ID="upnlOtherCostsTotalCostsCAD" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:TextBox ID="tbxOtherCostsTotalCostsCAD" runat="server" SkinID="TextBoxRightReadOnly"
                                                                                                Width="110px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                    <asp:UpdatePanel ID="unplOtherCostsTotalCostsUSD" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:TextBox ID="tbxOtherCostsTotalCostsUSD" runat="server" SkinID="TextBoxRightReadOnly"
                                                                                                Width="110px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </div>
                                                    </asp:WizardStep>
                                                    
                                                    
                                                    
                                                    <asp:WizardStep ID="stepRevenueInformation" runat="server" Title="RevenueInformation">
                                                        <div runat="server" id="dvRevenue" style="overflow-x: auto; overflow-y: hidden; width: 930px">
                                                            <table cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblTitleRevenue" runat="server" SkinID="Label" Text="Revenue Information"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 7px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:UpdatePanel ID="upnlRevenue" runat="server">
                                                                            <ContentTemplate>
                                                                                <asp:GridView ID="grdRevenue" runat="server" SkinID="GridView" Width="930px" AllowPaging="True"
                                                                                    ShowFooter="true" AutoGenerateColumns="False" DataKeyNames="CostingSheetID,RefIDRevenue" OnRowDataBound="grdRevenue_RowDataBound"
                                                                                    DataSourceID="odsRevenue" OnDataBound="grdRevenue_DataBound" OnPageIndexChanging="grdRevenue_PageIndexChanging"
                                                                                    PageSize="9" OnRowUpdating="grdRevenue_RowUpdating" OnRowDeleting="grdRevenue_RowDeleting" OnRowEditing="grdRevenue_RowEditing"
                                                                                    OnRowCommand="grdRevenue_RowCommand">
                                                                                    <Columns>
                                                                                    
                                                                                        <%--0--%>
                                                                                        <asp:TemplateField HeaderText="CostingSheetID" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblCostingSheetID" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>                                                                                                
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblCostingSheetIDEdit" runat="server" SkinID="Label" Text='<%# Eval("CostingSheetID") %>'></asp:Label>
                                                                                                <telerik:RadDatePicker ID="hdfFrom" runat="server" Visible="false"></telerik:RadDatePicker>
                                                                                                <telerik:RadDatePicker ID="hdfTo" runat="server" Visible="false"></telerik:RadDatePicker>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <telerik:RadDatePicker ID="hdfFrom" runat="server" Visible="false"></telerik:RadDatePicker>
                                                                                                <telerik:RadDatePicker ID="hdfTo" runat="server" Visible="false"></telerik:RadDatePicker>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--1--%>
                                                                                        <asp:TemplateField HeaderText="RefIDRevenue" Visible="False">
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblRefIDRevenue" runat="server" SkinID="Label" Text='<%# Eval("RefIDRevenue") %>'></asp:Label>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <asp:Label ID="lblRefIDRevenueEdit" runat="server" SkinID="Label" Text='<%# Eval("RefIDRevenue") %>'></asp:Label>
                                                                                            </EditItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--4--%>
                                                                                        <asp:TemplateField HeaderText="Project">
                                                                                            <HeaderStyle Width="85px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <asp:Label ID="lblProject" Width="85px" runat="server" SkinID="Label" Text='<%# Eval("Project") %>'> </asp:Label>                                                                                                                                                                                             
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <asp:TextBox ID="tbxProjectEdit" Width="85px" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Text='<%# Eval("Project") %>'></asp:TextBox>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <asp:DropDownList Width="85px" ID="ddlProject_New" runat="server" SkinID="DropDownList">
                                                                                                </asp:DropDownList>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--2--%>
                                                                                        <asp:TemplateField HeaderText="Date">
                                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                                            <HeaderStyle Width="150px" />
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblStartDate" runat="server" SkinID="Label" Text='<%# Bind("StartDate", "{0:d}") %>'
                                                                                                                    Style="width: 150px"></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpStartDateEdit" runat="server" Width="150px" SkinID="RadDatePicker"
                                                                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "StartDate") %>' Calendar-ShowRowHeaders="false"
                                                                                                                    Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvStartDateEdit" runat="server" ControlToValidate="tkrdpStartDateEdit" ValidationGroup="revenueEdit"
                                                                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator">
                                                                                                                </asp:RequiredFieldValidator>  
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                     </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <telerik:RadDatePicker ID="tkrdpStartDateNew" runat="server" Width="150px" SkinID="RadDatePicker"
                                                                                                                    DbSelectedDate='<%# DataBinder.Eval(Container.DataItem, "StartDate") %>' Calendar-ShowRowHeaders="false"
                                                                                                                    Calendar-DayNameFormat="Short">
                                                                                                                </telerik:RadDatePicker>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvStartDateNew" runat="server" ControlToValidate="tkrdpStartDateNew" ValidationGroup="revenueNew"
                                                                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator" >
                                                                                                                </asp:RequiredFieldValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>                                                                                        
                                                                                                                                                                              
                                                                                        <%--3--%>
                                                                                        <asp:TemplateField HeaderText="Revenue">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:Label ID="lblRevenue" Width="100px" runat="server" SkinID="Label" Text='<%# Eval("Revenue", "{0:n2}") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="100px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxRevenueEdit" Width="100px" runat="server" SkinID="TextBox" Text='<%# Eval("Revenue", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvRevenueEdit" runat="server" ControlToValidate="tbxRevenueEdit"
                                                                                                                    ErrorMessage="Please enter a revenue." ValidationGroup="RevenueEdit" SkinID="Validator"
                                                                                                                    Display="Dynamic" InitialValue="">
                                                                                                                </asp:RequiredFieldValidator>
                                                                                                                <asp:CompareValidator ID="cvRevenueEdit" runat="server" ControlToValidate="tbxRevenueEdit"
                                                                                                                    Display="Dynamic" ValidationGroup="RevenueEdit" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="right">
                                                                                                                <asp:TextBox ID="tbxRevenueNew" Width="100px" runat="server" SkinID="TextBox" Text='<%# Eval("Revenue", "{0:n2}") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:RequiredFieldValidator ID="rfvRevenueNew" runat="server" ControlToValidate="tbxRevenueNew"
                                                                                                                    ErrorMessage="Please enter a revenue." ValidationGroup="RevenueNew" SkinID="Validator"
                                                                                                                    Display="Dynamic" InitialValue="">
                                                                                                                </asp:RequiredFieldValidator>
                                                                                                                <asp:CompareValidator ID="cvRevenueNew" runat="server" ControlToValidate="tbxRevenueNew"
                                                                                                                    Display="Dynamic" ValidationGroup="revenueNew" ErrorMessage="Invalid format. (use XXXX.XX)"
                                                                                                                    Operator="DataTypeCheck" SkinID="Validator" Type="Currency">
                                                                                                                </asp:CompareValidator>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--4--%>
                                                                                        <asp:TemplateField HeaderText="Comment">
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:Label ID="lblComment" Width="400px" runat="server" SkinID="Label" Text='<%# Eval("Comment") %>'></asp:Label>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                            <HeaderStyle Width="400px"></HeaderStyle>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:TextBox ID="tbxCommentEdit" Width="400px" runat="server" SkinID="TextBox"
                                                                                                                    Text='<%# Eval("Comment") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </EditItemTemplate>
                                                                                            <FooterTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:TextBox ID="tbxCommentNew" Width="400px" runat="server" SkinID="TextBox"
                                                                                                                    Text='<%# Eval("Comment") %>'></asp:TextBox>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                        </asp:TemplateField>
                                                                                        
                                                                                        <%--Buttons--%>
                                                                                        <asp:TemplateField>
                                                                                            <EditItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
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
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td style="height: 12px">
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" __designer:wfdid="w80"
                                                                                                                    CommandName="Add" ToolTip="Add" ImageUrl="./../../App_Themes/LFS2/images/gridview/add.png">
                                                                                                                </asp:ImageButton>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </FooterTemplate>
                                                                                            <HeaderStyle Width="40px"></HeaderStyle>
                                                                                            <ItemTemplate>
                                                                                                <table cellspacing="0" cellpadding="0" border="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td style="width: 50%">
                                                                                                                <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" __designer:wfdid="w76"
                                                                                                                    CommandName="Edit" ToolTip="Edit" ImageUrl="./../../App_Themes/LFS2/images/gridview/edit.png">
                                                                                                                </asp:ImageButton>
                                                                                                            </td>
                                                                                                            <td style="width: 50%">
                                                                                                                <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" __designer:wfdid="w77"
                                                                                                                    CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this cost?");'
                                                                                                                    ToolTip="Delete" ImageUrl="./../../App_Themes/LFS2/images/gridview/delete.png">
                                                                                                                </asp:ImageButton>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                    </Columns>
                                                                                </asp:GridView>
                                                                                &nbsp;
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <table cellpadding="0" cellspacing="0" border="0">
                                                                            <tr>
                                                                                <td style="width: 155px; text-align: right;">
                                                                                    <asp:Label ID="lblRevenueTotal" Width="155px" runat="server" SkinID="Label"
                                                                                        Text="Total Revenue : "></asp:Label>
                                                                                </td>
                                                                                <td style="width: 110px; text-align: right;">
                                                                                    <asp:UpdatePanel ID="upTotalRevenue" runat="server">
                                                                                        <ContentTemplate>
                                                                                            <asp:TextBox ID="tbxRevenueTotal" runat="server" SkinID="TextBoxRightReadOnly"
                                                                                                Width="110px" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
                                                                                        </ContentTemplate>
                                                                                    </asp:UpdatePanel>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height:7px">
                                                                    </td>
                                                                </tr>                                                                
                                                            </table>
                                                            
                                                            <table cellpadding="0" cellspacing="0" width="0" style="width: 480px">
                                                                <tr>
                                                                    <td style="width: 120px">
                                                                    </td>
                                                                    <td style="width: 120px">
                                                                    </td>
                                                                    <td style="width: 120px">
                                                                    </td>
                                                                    <td style="width: 120px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="4">
                                                                        <asp:Label ID="lblRevenueSummary" runat="server" SkinID="Label" Text="Revenue Summary"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td style="height: 7px">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:Label ID="lblGrandTotal" runat="server" Text="Grand Total" SkinID="Label"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblGrandRevenue" runat="server" Text="Revenue" SkinID="Label"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblGrandProfit" runat="server" Text="Profit" SkinID="Label"></asp:Label>
                                                                    </td>
                                                                    <td>
                                                                        <asp:Label ID="lblGrandGrossMargin" runat="server" Text="Gross Margin" SkinID="Label"></asp:Label>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxGrandTotal" runat="server" SkinID="TextBoxRightReadOnly" ReadOnly="true" Width="110px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxGradRevenue" runat="server" SkinID="TextBoxRightReadOnly" ReadOnly="true" Width="110px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxGrandProfit" runat="server" SkinID="TextBoxRightReadOnly" ReadOnly="true" Width="110px"></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox ID="tbxGrandGrossMargin" runat="server" SkinID="TextBoxRightReadOnly" ReadOnly="true" Width="110px"></asp:TextBox>
                                                                    </td>                                                                
                                                                </tr>                                                                
                                                            </table>
                                                        </div>
                                                    </asp:WizardStep>
                                                    
                                                    
                                                    
                                                    <asp:WizardStep ID="StepSummary" runat="server" StepType="Finish" Title="Summary">
                                                        <!-- Page element: Summary -->
                                                        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                            <tr>
                                                                <td style="width: 100%">
                                                                    <asp:TextBox ID="tbxSummary" runat="server" Height="200px" Width="930px" ReadOnly="True"
                                                                        SkinID="TextBoxReadOnly" TextMode="MultiLine"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 7px;">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </asp:WizardStep>
                                                    
                                                    
                                                    
                                                    <asp:WizardStep ID="StepFinalStep" runat="server" Title="FinalStep" StepType="Complete">
                                                        <!-- Page element: Final Steps -->
                                                        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                            <tr>
                                                                <td>
                                                                    <asp:LinkButton ID="lkbtnOpenCostingSheet" runat="server" SkinID="LinkButton" EnableViewState="False">Open the costing sheet you just created</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td style="height: 7px">
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <asp:LinkButton ID="lkbtnEditCostingSheet" runat="server" SkinID="LinkButton">Edit the costing sheet you just created</asp:LinkButton>
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
                                        <td style="vertical-align: bottom; width: 30px">
                                            <asp:UpdateProgress ID="upProject" runat="server" AssociatedUpdatePanelID="upnlProject">
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
                            <asp:AsyncPostBackTrigger ControlID="wzProjectCostinsSheetsAdd" EventName="ActiveStepChanged">
                            </asp:AsyncPostBackTrigger>
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfProjectId" runat="server" />
                    <asp:HiddenField ID="hdfCostingSheetId" runat="server" />
                    <asp:HiddenField ID="hdfGrantTotalCostCad" runat="server" />
                    <asp:HiddenField ID="hdfGrantTotalCostUsd" runat="server" />
                    <asp:HiddenField ID="hdfSelectedIdTemplate" runat="server" />
                    <asp:HiddenField ID="hdfNewOrTemplate" runat="server" />
                    <asp:HiddenField ID="hdfClientId" runat="server" />
                    
                    <asp:ObjectDataSource ID="odsTeamMembers" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetLabourHoursInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_combined_costing_sheets_add"
                        DeleteMethod="DummyTeamMembersNew" InsertMethod="DummyTeamMembersNew" UpdateMethod="DummyTeamMembersNew">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsUnits" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetUnitsInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_combined_costing_sheets_add"
                        DeleteMethod="DummyUnitsNew" InsertMethod="DummyUnitsNew" UpdateMethod="DummyUnitsNew">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsMaterials" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetMaterialsInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_combined_costing_sheets_add"
                        DeleteMethod="DummyMaterialsNew" InsertMethod="DummyMaterialsNew" UpdateMethod="DummyMaterialsNew">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsSubcontractors" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetSubcontractorsInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_combined_costing_sheets_add"
                        DeleteMethod="DummySubcontractorsNew" InsertMethod="DummySubcontractorsNew" UpdateMethod="DummySubcontractorsNew">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsOtherCosts" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetOtherCostsInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_combined_costing_sheets_add"
                        DeleteMethod="DummyOtherCostsNew" InsertMethod="DummyOtherCostsNew" UpdateMethod="DummyOtherCostsNew">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsRevenue" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetRevenueInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.Projects.Projects.project_combined_costing_sheets_add"
                        DeleteMethod="DummyRevenueNew" InsertMethod="DummyRevenueNew" UpdateMethod="DummyRevenueNew">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsEmployee" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemNoSubcontractor"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Employees.EmployeeList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="employeeId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select a team member)" Name="fullName" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsWork_" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTimeWorkList"
                        OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select)" Name="work" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsWorkFunctionConcat" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.LabourHours.TeamProjectTime.TeamProjectTimeWorkFunctionConcatList" CacheDuration="60" EnableCaching="True">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select)" Name="workFunctionConcat" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsUnitCode" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.FleetManagement.Units.UnitsList" CacheDuration="60"
                        EnableCaching="True">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="unitId" Type="String" />
                            <asp:Parameter DefaultValue="" Name="unitCode" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="true" Name="isWithUnitCode" Type="Boolean" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsMaterialsList" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.Materials.MaterialsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select a material)" Name="description" Type="String" />
                            <asp:Parameter DefaultValue="-1" Name="materialId" Type="Int32" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsSubcontractorsList" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.Subcontractors.SubcontractorsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="subcontractorId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select a subcontractor)" Name="name" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <%-- For Units of Measurement--%>
                    <asp:ObjectDataSource ID="odsUnitsOfMeasurementLH" runat="server"  EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemByModule" TypeName="LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement.UnitsOfMeasurementAssociationsToolAssociatedUnitsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="R / Team Members" Name="module" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>          
                    
                    <asp:ObjectDataSource ID="odsUnitsOfMeasurementSubcontractor" runat="server"  EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemByModule" TypeName="LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement.UnitsOfMeasurementAssociationsToolAssociatedUnitsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="R / Team Members" Name="module" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsUnitsOfMeasurementLHMotel" runat="server"  EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemByModule" TypeName="LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement.UnitsOfMeasurementAssociationsToolAssociatedUnitsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="R / Team Members - Motel" Name="module" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsUnitsOfMeasurementLHMeals" runat="server"  EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemByModule" TypeName="LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement.UnitsOfMeasurementAssociationsToolAssociatedUnitsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="R / Team Members - Meals" Name="module" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsUnitsOfMeasurementUnits" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemByModule" TypeName="LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement.UnitsOfMeasurementAssociationsToolAssociatedUnitsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="FM / Units" Name="module" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsUnitsOfMeasurementMaterials" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItemByModule" TypeName="LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement.UnitsOfMeasurementAssociationsToolAssociatedUnitsList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="R / Materials" Name="module" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsUnitsOfMeasurementOthers" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.Resources.UnitsOfMeasurement.UnitsOfMeasurementAssociationsToolAssociatedUnitsList">
                        <SelectParameters>
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                </td>
            </tr>
        </table>
    </div>
</asp:Content>