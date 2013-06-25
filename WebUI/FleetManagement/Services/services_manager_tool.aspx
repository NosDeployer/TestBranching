<%@ Page Language="C#" Title="LFS Live" AutoEventWireup="true" MasterPageFile="../../mWizard2.Master"
CodeBehind="services_manager_tool.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.FleetManagement.Services.services_manager_tool" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 350px">
        <!-- Page element: Wizard -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Wizard ID="wzServices" runat="server" Width="450px" Height="450px" ActiveStepIndex="1" 
                        DisplayCancelButton="True" DisplaySideBar="False" SkinID="Wizard" 
                        OnActiveStepChanged="Wizard_ActiveStepChanged" OnNextButtonClick="Wizard_NextButtonClick" 
                        OnCancelButtonClick="Wizard_CancelButtonClick" OnFinishButtonClick="Wizard_FinishButtonClick"
                        OnPreviousButtonClick="Wizard_PreviousButtonClick">
                        <WizardSteps>



                            <asp:WizardStep ID="StepBegin" runat="server" Title="Begin">
                                <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblServiceRequests" runat="server" EnableViewState="False" SkinID="Label" Text="Service Requests"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 7px">                                        
                                        </td>
                                    </tr>                                    
                                    <tr>
                                        <td colspan="5">
                                            <asp:Panel ID="pnlgrdServiceRequests" runat="server" Height="350px" Width="450px" ScrollBars="Auto">
                                                <asp:UpdatePanel id="upnlServiceRequests" runat="server">
                                                    <contenttemplate>
                                                        <asp:GridView id="grdServiceRequests" runat="server" SkinID="GridViewInTabs" Width="433px" DataSourceID="odsServiceRequests" AutoGenerateColumns="False" DataKeyNames="ServiceID" OnDataBound="grdServiceRequests_DataBound" OnRowDataBound="grdServiceRequests_RowDataBound" OnSorting="grdServiceRequests_Sorting" AllowSorting="True">
                                                            <Columns>
                                                                
                                                                <asp:TemplateField  Visible="False">
                                                                    <HeaderStyle Width="0px"></HeaderStyle>                                                                                                                                                                                               
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblServiceId" runat="server" Text='<%# Eval("ServiceID") %>'></asp:Label>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>                                                                                                        
                                                                
                                                                <asp:TemplateField ShowHeader="False">
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    <HeaderStyle Width="30px"></HeaderStyle>
                                                                    <ItemTemplate>
                                                                        <asp:CheckBox ID="cbxSelected" runat="server" onclick="return cbxSelectedClick(this);" Checked='<%# Eval("Selected") %>' />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Service Number" SortExpression="Number">
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                    <HeaderStyle Width="45px" HorizontalAlign="Center"></HeaderStyle>                                                                                                                               
                                                                    <ItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblNumber" runat="server" SkinID="Label" Text='<%# Eval("Number") %>' ></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                
                                                                <asp:TemplateField HeaderText="Problem Description">
                                                                    <HeaderStyle Width="288px"></HeaderStyle>                                                                                                                          
                                                                    <ItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblDescription" runat="server" SkinID="Label" Text='<%# Eval("Description") %>' ></asp:Label>
                                                                                </td>
                                                                            </tr>
                                                                        </table>                                                                
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>

                                                                <asp:TemplateField HeaderText="State" SortExpression="State">
                                                                    <HeaderStyle Width="70px"></HeaderStyle>                                                                
                                                                    <ItemTemplate>
                                                                        <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:Label ID="lblState" runat="server" SkinID="Label" Text='<%# Eval("State") %>'></asp:Label>
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
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblError" runat="server" EnableViewState="False" SkinID="LabelError" Text="At least one service request must be selected"></asp:Label>
                                        </td>                                       
                                    </tr>                                          
                                </table>
                            </asp:WizardStep>
                            
                            
                            
                            <asp:WizardStep ID="StepStepsInformation" runat="server" Title="Steps Information">                           
                               
                               
                                <asp:UpdatePanel ID="upPnlAssignation" runat="server">
                                    <ContentTemplate>
                                        <!-- Page element : 1 panel - assignment information -->
                                        <asp:Panel ID="pnlAssignmentInformation" runat="server" Width="100%">
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
                                                                EnableViewState="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="rbtnAssignToMyself" runat="server" SkinID="RadioButton" Text="Myself"
                                                                OnCheckedChanged="rbtnAssignToMyself_CheckedChanged" GroupName="Begin" AutoPostBack="True">
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
                                                                Text="Team Member" OnCheckedChanged="rbtnAssignToMyself_CheckedChanged" GroupName="Begin"
                                                                Checked="True" AutoPostBack="True"></asp:RadioButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList Style="width: 440px" ID="ddlAssignToTeamMember" runat="server"
                                                                SkinID="DropDownList" DataTextField="FullName" DataMember="DefaultView" DataValueField="EmployeeID"
                                                                DataSourceID="odsEmployee">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CustomValidator ID="cvTeamMember" runat="server" SkinID="Validator" OnServerValidate="cvTeamMember_ServerValidate"
                                                                Display="Dynamic" ValidationGroup="assignmentInformation" ControlToValidate="ddlAssignToTeamMember"
                                                                ErrorMessage="Please select a team member."></asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:RadioButton ID="rbtnAssignToThirdPartyVendor" runat="server" SkinID="RadioButton"
                                                                Text="Third Party Vendor" OnCheckedChanged="rbtnAssignToMyself_CheckedChanged"
                                                                GroupName="Begin" AutoPostBack="True"></asp:RadioButton>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox Style="width: 440px" ID="tbxAssignToThirdPartyVendor" runat="server"
                                                                SkinID="TextBox"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CustomValidator ID="cvThirdPartyVendor" runat="server" SkinID="Validator" OnServerValidate="cvThridPartyVendor_ServerValidate"
                                                                Display="Dynamic" ValidationGroup="assignmentInformation" ControlToValidate="tbxAssignToThirdPartyVendor"
                                                                ErrorMessage="Please provide a third party vendor." ValidateEmptyText="True"></asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:Label ID="lblDeadLine" runat="server" SkinID="Label" Text="Deadline Date" EnableViewState="False"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <telerik:RadDatePicker ID="tkrdpDeadlineDate" runat="server" Width="140px" SkinID="RadDatePicker"
                                                                Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
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
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                    
                            
                                                        
                                <!-- Page element : Horizontal Rule -->
                                <table id="acceptInformationSeparator" runat="server" cellspacing="0" cellpadding="0" border="0" style="width: 100%">
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
                                            <td><asp:CheckBox ID="ckbxAcceptSR" runat="server" SkinID="CheckBox" Text="I want to accept this SR" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 7px">
                                            </td>
                                        </tr>                                                                        
                                    </table>
                                </asp:Panel>
                                
                                
                                
                                <!-- Page element : Horizontal Rule -->
                                <table id="startWorkSeparator" runat="server" cellspacing="0" cellpadding="0" border="0" style="width: 100%">
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
                                                <telerik:RadDatePicker ID="tkrdpStartWorkUnitOutOfServiceDate" runat="server" Width="140px"
                                                    SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" DayNameFormat="Short"
                                                        ShowRowHeaders="False" ViewSelectorText="x">
                                                    </Calendar>
                                                    <DateInput Width="" LabelCssClass="">
                                                    </DateInput>
                                                    <DatePopupButton CssClass="" ImageUrl="" HoverImageUrl=""></DatePopupButton>
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
                                                <asp:CustomValidator ID="cvStartMileage" runat="server" 
                                                    ControlToValidate="tbxStartWorkStartMileage" Display="Dynamic" 
                                                    ErrorMessage="Please provide a mileage." 
                                                    OnServerValidate="cvStartMileage_ServerValidate" SkinID="Validator" 
                                                    ValidateEmptyText="True" ValidationGroup="startWorkInformation"></asp:CustomValidator>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                                
                                
                                
                                <!-- Page element : Horizontal Rule -->
                                <table id="completeWorkSeparator" runat="server" cellspacing="0" cellpadding="0" border="0" style="width: 100%">
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
                                
                                
                                
                                <!-- Page element : 1 panel - complete work information -->
                                <asp:Panel ID="pnlCompleteWorkInformation" runat="server" Width="100%">
                                    <!-- Table element: 3 columns  -->
                                    <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                        <tr>
                                            <td colspan="3">
                                                <asp:Label ID="lblCompleteTitle" runat="server" EnableViewState="False" SkinID="LabelTitle2" Text="Please provide complete work information"></asp:Label>
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
                                                <telerik:RadDatePicker ID="tkrdpCompleteWorkUnitBackInServiceDate" runat="server"
                                                    Width="140px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">               
                                                </telerik:RadDatePicker>
                                            </td>
                                            <td>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:TextBox ID="tbxCompleteWorkCompleteMileage" runat="server" SkinID="TextBox" Style="width: 120px; "></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblCompleteWorkCompleteMileageUnitOfMeasurement" runat="server" SkinID="Label" ></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:CustomValidator ID="cvUnitBackInServiceDate" runat="server" ControlToValidate="tkrdpCompleteWorkUnitBackInServiceDate"
                                                    Display="Dynamic" ErrorMessage="Please select a date." OnServerValidate="cvUnitBackInServiceDate_ServerValidate"
                                                    SkinID="Validator" ValidateEmptyText="True" ValidationGroup="completeInformation"></asp:CustomValidator>
                                            </td>
                                            <td>
                                                <asp:CustomValidator ID="cvCompleteMileage" runat="server" ControlToValidate="tbxCompleteWorkCompleteMileage"
                                                    Display="Dynamic" ErrorMessage="Please provide a mileage." OnServerValidate="cvCompleteMileage_ServerValidate"
                                                    SkinID="Validator" ValidateEmptyText="True" ValidationGroup="completeInformation"></asp:CustomValidator>
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
                    
                                    
                                    <asp:UpdatePanel ID="upPnlAssignationData" runat="server">
                                        <ContentTemplate>
                                            <!-- Page element : 1 panel - complete work for team members -->
                                            <asp:Panel ID="pnlAssignTeamMember" runat="server" Width="100%">
                                                <!-- Page element : 1 column - work details -->
                                                <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                    <tbody>
                                                        <tr>
                                                            <td style="width: 150px">
                                                                <asp:Label ID="lblCompleteWorkDataDescription" runat="server" SkinID="Label" Text="Description"></asp:Label>
                                                            </td>
                                                            <td style="width: 150px">
                                                            </td>
                                                            <td style="width: 150px">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <asp:TextBox Style="width: 440px" ID="tbxCompleteWorkDataDescription" runat="server"
                                                                    SkinID="TextBox" Rows="4" TextMode="MultiLine"></asp:TextBox>
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
                                                                <asp:Label ID="lblCompleteWorkDataPreventable" runat="server" SkinID="Label" Text="Preventable"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblCompleteWorkDataLabourHours" runat="server" SkinID="Label" Text="Labour Hours"></asp:Label>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="ckbxCompleteWorkDataPreventable" runat="server" SkinID="CheckBox">
                                                                </asp:CheckBox>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox Style="width: 140px" ID="tbxCompleteWorkDataLabourHours" runat="server" SkinID="TextBox"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                            </td>
                                                            <td>
                                                                <asp:CompareValidator ID="cvCompleteWorkDataLabourHours" runat="server" SkinID="Validator"
                                                                    ErrorMessage="Invalid format. (use XXXX.XX)" ControlToValidate="tbxCompleteWorkDataLabourHours"
                                                                    ValidationGroup="completeInformation" Display="Dynamic" Operator="DataTypeCheck"
                                                                    Type="Currency"></asp:CompareValidator>
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
                                                                <asp:Label ID="lblCompleteWorkDataCostTitle" runat="server" SkinID="Label" Text="Costs"></asp:Label>
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
                                                            <td>
                                                                <asp:UpdatePanel ID="upnlCosts" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:GridView ID="grdCosts" runat="server" SkinID="GridViewInTabs" Width="450px"
                                                                            OnDataBound="grdCosts_DataBound" DataKeyNames="ServiceID,RefID" AutoGenerateColumns="False"
                                                                            __designer:wfdid="w124" DataSourceID="odsCosts" PageSize="4" ShowFooter="True"
                                                                            AllowPaging="True" OnRowCommand="grdCosts_RowCommand" OnRowDeleting="grdCosts_RowDeleting"
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
                                                                                                            Text='<%# Eval("PartName") %>' EnableViewState="True" __designer:wfdid="w138"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:RequiredFieldValidator ID="rfvDescriptionNew" runat="server" SkinID="Validator"
                                                                                                            EnableViewState="True" __designer:wfdid="w139" Display="Dynamic" ValidationGroup="costsDataEdit"
                                                                                                            ControlToValidate="tbxPartName" ErrorMessage="Please provide a part name.">
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
                                                                                                            EnableViewState="True" __designer:wfdid="w140"></asp:TextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <asp:RequiredFieldValidator ID="rfvDescription" runat="server" SkinID="Validator"
                                                                                                            EnableViewState="True" __designer:wfdid="w141" Display="Dynamic" ValidationGroup="costsDataAdd"
                                                                                                            ControlToValidate="tbxPartNameNew" ErrorMessage="Please provide a part name.">
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
                                                                                                            Width="110px" __designer:wfdid="w137"></asp:Label>
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
                                                                <asp:UpdatePanel ID="upnlTotalCost" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:TextBox ID="tbxTotalCost" runat="server" SkinID="TextBoxRightReadOnly" Width="100%"
                                                                            ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox>
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
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </asp:Panel>
                                            
                                            <!-- Page element : 1 panel - Assign to third party vendor -->
                                            <asp:Panel ID="pnlAssignThirdPartyVendor" runat="server" Width="100%">
                                                <!-- Page element : 1 column - work details -->
                                                <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
                                                    <tr>
                                                        <td style="width: 150px;">
                                                            <asp:Label ID="lblDescriptionTPV" runat="server" SkinID="Label" Text="Description"></asp:Label>
                                                        </td>
                                                        <td style="width: 150px">
                                                        </td>
                                                        <td style="width: 150px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:TextBox ID="tbxDescriptionTPV" runat="server" Rows="4" SkinID="TextBox" Style="width: 440px"
                                                                TextMode="MultiLine"></asp:TextBox>
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
                                                            <asp:Label ID="lblPreventableTPV" runat="server" SkinID="Label" Text="Preventable"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInvoiceNumberTPV" runat="server" SkinID="Label" Text="Invoice Number"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblInvoiceAmountTPV" runat="server" SkinID="Label" Text="Invoice Amount"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <asp:CheckBox ID="ckbxPreventableTPV" runat="server" SkinID="CheckBox" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxInvoiceNumberTPV" runat="server" SkinID="TextBox" Style="width: 140px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxInvoiceAmountTPV" runat="server" SkinID="TextBox" Style="width: 140px"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:CompareValidator ID="cvInvoiceAmount" runat="server" ControlToValidate="tbxInvoiceAmountTPV"
                                                                Display="Dynamic" ErrorMessage="Invalid format. (use XXXX.XX)" Operator="DataTypeCheck"
                                                                SkinID="Validator" Type="Currency" ValidationGroup="completeInformation"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                            
                                            
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </asp:Panel>                                                                                               
                                
                                <!-- Page element : Horizontal Rule -->
                                <table id="notesSeparator" runat="server" cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                    <tr runat="server">
                                        <td style="height: 30px" runat="server">
                                        </td>
                                    </tr>
                                    <tr runat="server">
                                        <td style="height: 2px" class="Background_Separator" runat="server">
                                        </td>
                                    </tr>
                                    <tr runat="server">
                                        <td  style="height: 10px" runat="server">
                                        </td>
                                    </tr>
                                </table>
                                
                                <!-- Page element : 1 panel - notes information -->
                                <asp:Panel ID="pnlNotesInformation" runat="server" Width="100%">
                                    <!-- Page element: Section title - Notes Centre -->
                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblNotesTitle" runat="server" SkinID="LabelTitle2" Text="Notes" EnableViewState="False"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px">
                                            </td>
                                        </tr>
                                    </table>
                                            
                                    <asp:UpdatePanel ID="upnlNotesInformation" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="grdNotes" runat="server" SkinID="GridViewInTabs" Width="450px"
                                                DataSourceID="odsNotes" OnRowDataBound="grdNotes_RowDataBound" OnRowUpdating="grdNotes_RowUpdating"
                                                OnRowDeleting="grdNotes_RowDeleting" OnRowCommand="grdNotes_RowCommand" OnDataBound="grdNotes_DataBound"
                                                DataKeyNames="ServiceID, RefID" AllowPaging="True" AutoGenerateColumns="False" OnRowEditing="grdNotes_RowEditing"
                                                ShowFooter="True" PageSize="5" __designer:wfdid="w36">
                                                <Columns>
                                                
                                                    <asp:TemplateField HeaderText="ServiceID" SortExpression="ServiceID" Visible="False">
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
                                                    
                                                    <asp:TemplateField Visible="False" HeaderText="FileName" >                                                            
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblFileNameEdit" runat="server" Text='<%# Eval("FILENAME") %>'></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblFileName" runat="server" Text='<%# Eval("FILENAME") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>                                                                
                                                    
                                                    <asp:TemplateField Visible="False" HeaderText="LIBRARY_FILES_ID" >                                                            
                                                        <EditItemTemplate>
                                                            <asp:Label ID="lblLibraryFileIdEdit" runat="server" Text='<%# Eval("LIBRARY_FILES_ID") %>'></asp:Label>
                                                        </EditItemTemplate>
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblLibraryFileId" runat="server" Text='<%# Eval("LIBRARY_FILES_ID") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    
                                                    <asp:TemplateField SortExpression="Subject" HeaderText="Information">
                                                        <EditItemTemplate>
                                                            <!-- Page element : 1 column - Notes Information -->
                                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 160px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblNoteSubjectEdit" runat="server" SkinID="Label" Text="Subject" EnableViewState="False" ></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox Style="width: 150px" ID="tbxNoteSubjectEdit" runat="server" SkinID="TextBox"
                                                                                Text='<%# Eval("Subject") %>' EnableViewState="True" ></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:RequiredFieldValidator ID="rfvNoteSubjectEdit" runat="server" SkinID="Validator"
                                                                                EnableViewState="False" ValidationGroup="notesDataEdit" ErrorMessage="Please provide a subject."
                                                                                Display="Dynamic" ControlToValidate="tbxNoteSubjectEdit" ></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 7px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblNoteDateEdit" runat="server" EnableViewState="False" SkinID="Label" Text="Date"></asp:Label>
                                                                        </td>
                                                                        
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxNoteDateEdit" runat="server" ReadOnly="True" 
                                                                                SkinID="TextBoxReadOnly" Style="width: 150px" Text='<%# Eval("DateTime_") %>'></asp:TextBox>
                                                                        </td>                                                                        
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 7px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblNoteCreatedByEdit" runat="server" EnableViewState="False" SkinID="Label" Text="Created By"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxNoteCreatedByEdit" runat="server" ReadOnly="True" 
                                                                                SkinID="TextBoxReadOnly" Style="width: 150px" 
                                                                                Text='<%# GetNoteCreatedBy(Eval("UserID")) %>'></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 10px">
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </EditItemTemplate>
                                                        <FooterTemplate>
                                                            <!-- Page element : 1 column - Notes Information -->
                                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 160px; height: 10px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblNoteSubjectNew" runat="server" SkinID="Label" Text="Subject" EnableViewState="False" ></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox Style="width: 150px" ID="tbxNoteSubjectNew" runat="server" SkinID="TextBox"
                                                                                Text='<%# Eval("Subject") %>' EnableViewState="True" ></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:RequiredFieldValidator ID="rfvNoteSubjectNew" runat="server" SkinID="Validator"
                                                                                EnableViewState="False" ValidationGroup="notesDataAdd" ErrorMessage="Please provide a subject."
                                                                                Display="Dynamic" ControlToValidate="tbxNoteSubjectNew" ></asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 10px">
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </FooterTemplate>
                                                        <HeaderStyle Width="160px" />
                                                        <ItemTemplate>
                                                            <!-- Page element : 2 columns - Notes Information -->
                                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 160px; height: 10px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblNoteSubject" runat="server" SkinID="Label" Text="Subject" EnableViewState="False" ></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox Style="width: 150px" ID="tbxNoteSubject" runat="server" SkinID="TextBoxReadOnly"
                                                                                Text='<%# Eval("Subject") %>' EnableViewState="True" ReadOnly="True" ></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 7px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblNoteDate" runat="server" EnableViewState="False" SkinID="Label" Text="Date"></asp:Label>
                                                                        </td>                                                                        
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxNoteDate" runat="server" ReadOnly="True" 
                                                                                SkinID="TextBoxReadOnly" Style="width: 150px" Text='<%# Eval("DateTime_") %>'></asp:TextBox>
                                                                        </td>                                                                        
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 7px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblNoteCreatedBy" runat="server" EnableViewState="False" SkinID="Label" Text="Created By"></asp:Label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxNoteCreatedBy" runat="server" ReadOnly="True" 
                                                                                SkinID="TextBoxReadOnly" Style="width: 150px" 
                                                                                Text='<%# GetNoteCreatedBy(Eval("UserID")) %>'></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td style="height: 10px">
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
                                                                        <td style="width: 150px">
                                                                        </td>
                                                                        <td style="width: 80px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblNoteNoteEdit" runat="server" EnableViewState="False" SkinID="Label" Text="Note"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:TextBox Style="width: 220px" ID="tbxNoteNoteEdit" runat="server" SkinID="TextBox"
                                                                                Text='<%# Eval("Note") %>' EnableViewState="True" TextMode="MultiLine" Rows="4" ></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <asp:RequiredFieldValidator ID="rfvNoteNoteEdit" runat="server" SkinID="Validator"
                                                                                EnableViewState="False" ValidationGroup="notesDataEdit" ErrorMessage="Please provide a note."
                                                                                Display="Dynamic" ControlToValidate="tbxNoteNoteEdit" ></asp:RequiredFieldValidator>
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
                                                                            <asp:Label ID="lblNoteAttachmentEdit" runat="server" EnableViewState="False" SkinID="Label" Text="Attachment"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td style="vertical-align: top;">
                                                                            <asp:TextBox ID="tbxNoteAttachmentEdit" runat="server" Rows="1" SkinID="TextBoxReadOnly" Style="width: 140px" Text='<%# Eval("ORIGINAL_FILENAME") %>' Width="220px" ReadOnly="True"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnNoteDeleteEdit" CommandName="DeleteAttachmentEdit" CommandArgument='<%# Eval("RefID") %>' Width="70px" runat="server" SkinID="Button" Text="Delete"/>
                                                                            <asp:Button ID="btnNoteAddEdit" CommandName="AddAttachmentEdit" CommandArgument='<%# Eval("RefID") %>' Width="70px" runat="server" SkinID="Button" Text="Add"/>
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
                                                            <!-- Page element : 2 columns - Notes and attachment information -->
                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 10px; height: 10px">
                                                                        </td>
                                                                        <td style="width: 150px">
                                                                        </td>
                                                                        <td style="width: 80px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblNoteNoteNew" runat="server" SkinID="Label" Text="Note" EnableViewState="False" ></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:TextBox Style="width: 220px" ID="tbxNoteNoteNew" runat="server" SkinID="TextBox" Text='<%# Eval("Note") %>' EnableViewState="True" Rows="1" ></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <asp:RequiredFieldValidator ID="rfvNoteNoteNew" runat="server" SkinID="Validator"
                                                                                EnableViewState="False" ValidationGroup="notesDataAdd" ErrorMessage="Please provide a note."
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
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblNoteAttachmentNew" runat="server" EnableViewState="False" SkinID="Label" Text="Attachment"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxNoteAttachmentNew" runat="server" Rows="1" SkinID="TextBoxReadOnly" Style="width: 140px" Text='<%# Eval("ORIGINAL_FILENAME") %>' ReadOnly="True"></asp:TextBox>
                                                                            <asp:Label ID="lblFileNameNoteAttachmentNew" runat="server" SkinID="Label" Text='<%# Eval("FILENAME") %>' Visible="False"/>    
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnAddFooter" Width="70px" runat="server" SkinID="Button" Text="Add" TabIndex="4" CommandName="AddAttachmentAdd" CommandArgument='<%# Eval("RefID") %>' />
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
                                                        <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                        <HeaderStyle Width="230px"></HeaderStyle>
                                                        <ItemTemplate>
                                                            <!-- Page element : 2 columns - Notes and attachment information -->
                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                <tbody>
                                                                    <tr>
                                                                        <td style="width: 10px; height: 10px">
                                                                        </td>
                                                                        <td style="width: 150px">
                                                                        </td>
                                                                        <td style="width: 80px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblNoteNote" runat="server" SkinID="Label" Text="Note" EnableViewState="False" ></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td colspan="2">
                                                                            <asp:TextBox Style="width: 220px" ID="tbxNoteNote" runat="server" SkinID="TextBoxReadOnly"
                                                                                Text='<%# Eval("Note") %>' EnableViewState="True" ReadOnly="True" TextMode="MultiLine"
                                                                                Rows="4"></asp:TextBox>
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
                                                                            <asp:Label ID="lblNoteAttachment" runat="server" EnableViewState="False" SkinID="Label" Text="Attachment"></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxNoteAttachment" runat="server" Rows="1" SkinID="TextBoxReadOnly" Style="width: 140px" Text='<%# Eval("ORIGINAL_FILENAME") %>' Width="140px" ReadOnly="True"></asp:TextBox>
                                                                        </td>
                                                                        <td style="vertical-align: top">
                                                                            <asp:Button ID="btnNoteDownload" CommandName="DownloadAttachment" CommandArgument='<%# Eval("RefID") %>' Width="70px" runat="server" SkinID="Button" Text="Download"/>
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
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                               </asp:Panel>
                               
                               <!-- Page element : Horizontal Rule -->
                                <table id="resourceCentreSeparator" runat="server" cellspacing="0" cellpadding="0" border="0" style="width: 100%">
                                    <tr id="Tr1" runat="server">
                                        <td id="Td1" style="height: 30px" runat="server">
                                        </td>
                                    </tr>
                                    <tr id="Tr2" runat="server">
                                        <td id="Td2" style="height: 2px" class="Background_Separator" runat="server">
                                        </td>
                                    </tr>
                                    <tr id="Tr3" runat="server">
                                        <td id="Td3"  style="height: 10px" runat="server">
                                        </td>
                                    </tr>
                                </table>
                                    
                                    
                                <asp:Panel ID="pnlResourceCentre" runat="server" Width="100%">
                                    <asp:UpdatePanel ID="upnlResourceCentre" runat="server">
                                        <ContentTemplate>
                                            <!-- Page element: Section title - Resource Centre -->
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 425px;">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblResourceCentre" runat="server" SkinID="LabelTitle2" Text="Resource Centre" EnableViewState="False"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 10px">
                                                    </td>
                                                </tr>
                                            </table>
                
                                            <!-- Table element: 2 columns - Resource Centre -->
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 425px;">
                                                <tr>
                                                    <td style="width: 335px">
                                                        <asp:Label ID="lblCategoryAssociated" runat="server" Text="Associated Category" SkinID="Label" EnableViewState="False"></asp:Label>
                                                    </td>
                                                    <td style="width: 90px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="tbxCategoryAssocited" Width="325px" ReadOnly="True" runat="server" SkinID="TextBoxReadOnly"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:Button ID="btnAssociate" runat="server" SkinID="Button" Text="Associate" OnClick="btnAssociate_Click" OnClientClick="return btnAssociateClick();" Width="80px" />
                                                        <asp:Button ID="btnUnassociate" runat="server" SkinID="Button" Text="Unassociate" OnClick="btnUnassociate_Click" OnClientClick="return btnUnassociateClick();" Width="80px" />
                                                    </td>
                                                </tr>
                                            </table>
                                            
                                             <table cellpadding="0" cellspacing="0" width="0" style="width: 425px;">
                                                <tr>
                                                    <td style="height: 60px">
                                                    </td>
                                                </tr>
                                            </table> 
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </asp:Panel>                                
                                                       
                                                     
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
                                        <asp:Button ID="btnPrevious" style="width:80px" runat="server" CausesValidation="False" CommandName="MovePrevious"
                                            Text="Previous" SkinID="Button" EnableViewState="False" /></td>
                                    <td style="width: 90px; text-align: right">
                                        <asp:Button ID="NextButton" style="width:80px" runat="server" CausesValidation="False" CommandName="MoveNext"
                                            Text="Next" SkinID="Button" EnableViewState="False" />
                                    </td>
                                    <td style="width: 90px; text-align: right">
                                        <asp:Button ID="CancelButton" style="width:80px" runat="server" CausesValidation="False" CommandName="Cancel"
                                            Text="Cancel" SkinID="Button" EnableViewState="False" />
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
                                    <td style="width: 90px; text-align: right; ">
                                        <asp:Button ID="btnPrevious" style="width:80px" runat="server" CausesValidation="False" CommandName="MovePrevious"
                                            Text="Previous" SkinID="Button" EnableViewState="False" /></td>
                                    <td style="width: 90px; text-align: right">
                                        <asp:Button ID="FinishButton" style="width:80px" runat="server" CommandName="MoveComplete" Text="Finish"
                                            SkinID="Button" EnableViewState="False" />
                                    </td>
                                    <td style="width: 90px; text-align: right">
                                        <asp:Button ID="CancelButton" style="width:80px" runat="server" CausesValidation="False" CommandName="Cancel"
                                            Text="Cancel" SkinID="Button" EnableViewState="False" />
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
                    <asp:ObjectDataSource ID="odsEmployee" runat="server" CacheDuration="60" EnableCaching="True"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="LoadByAssignableSrsAndAddItem" 
                        TypeName="LiquiForce.LFSLive.BL.Resources.Employees.EmployeeList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name="assignableSrs" Type="Int32" />
                            <asp:Parameter DefaultValue="-1" Name="employeeId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select a team member)" Name="fullName" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsServiceRequests" runat="server" FilterExpression="(Deleted = 0)"
                        OldValuesParameterFormatString="original_{0}" SelectMethod="GetServiceRequests" 
                        TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Services.services_manager_tool">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsCosts" runat="server" TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Services.services_manager_tool" FilterExpression="(Deleted = 0)"
                        InsertMethod="DummyCostsNew" UpdateMethod="DummyCostsNew" DeleteMethod="DummyCostsNew" SelectMethod="GetCostsNew" >
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsNotes" runat="server" FilterExpression="(Deleted = 0)"
                        SelectMethod="GetNotesNew" TypeName="LiquiForce.LFSLive.WebUI.FleetManagement.Services.services_manager_tool"
                        DeleteMethod="DummyNotesNew" InsertMethod="DummyNotesNew" UpdateMethod="DummyNotesNew">
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>

        <!-- Page element: HiddenFields -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfPnlAssignmentInformation" runat="server" />
                    <asp:HiddenField ID="hdfAssignToMyself" runat="server" />
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
                    <asp:HiddenField ID="hdfSelectedSRId" runat="server" />
                    <asp:HiddenField ID="hdfUnitId" runat="server" />     
                    <asp:HiddenField ID="hdfCompanyLevel" runat="server" />                      
                    <asp:HiddenField ID="hdfUnitType" runat="server" />                            
                    <asp:HiddenField ID="hdfState" runat="server" />   
                    <asp:HiddenField ID="hdfServiceNumber" runat="server" />
                    <asp:HiddenField ID="hdfServiceDescription" runat="server" />
                    <asp:HiddenField ID="hdfDashboard" runat="server" />
                    <asp:HiddenField ID="hdfMileageUnitOfMeasurement" runat="server" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>