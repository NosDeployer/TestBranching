<%@ Page Language="C#" MasterPageFile="../../mWizard2.Master" AutoEventWireup="true"
    Codebehind="timesheet_team.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.TeamProjectTime.timesheet_team"
    Title="LFS Live" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 650px; height: 630px;">
        <!-- Page element: Wizard -->
        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
            <tr>
                <td>
                    <asp:UpdatePanel ID="upnlTeam" runat="server">
                        <ContentTemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">                                
                                <tr>
                                    <td>
                                        <asp:Wizard ID="wzTeam" runat="server" Width="910px" Height="450px" ActiveStepIndex="2"
                                            DisplayCancelButton="True" DisplaySideBar="False" OnActiveStepChanged="wzTeam_ActiveStepChanged"
                                            OnCancelButtonClick="wzTeam_CancelButtonClick" OnFinishButtonClick="wzTeam_FinishButtonClick"
                                            OnNextButtonClick="wzTeam_NextButtonClick" OnPreviousButtonClick="wzTeam_PreviousButtonClick"
                                            SkinID="Wizard">
                                            <WizardSteps>
                                            
                                                <asp:WizardStep ID="StepBegin" runat="server" Title="Begin" StepType="Start">
                                                    <!-- Page element: 1 column -->
                                                    <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                        <tr>
                                                            <td>
                                                                <asp:RadioButton ID="rbtnBeginNew" runat="server" Checked="True" GroupName="Begin" SkinID="RadioButton" Text="Start with a clean wizard" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RadioButton ID="rbtnBeginTemplate" runat="server" GroupName="Begin" SkinID="RadioButton" Text="Use a template from a library" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:WizardStep>
                                                
                                                
                                                
                                                <asp:WizardStep runat="server" Title="Template" ID="StepTemplate">
                                                    <!-- Page element: 2 column -->
                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblMessage" runat="server" EnableViewState="False" SkinID="LabelError" Text="At least one timesheet must be selected."></asp:Label>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Panel ID="pnlTemplate" runat="server" Height="330px" Width="905px" ScrollBars="Auto">
                                                                    <asp:UpdatePanel id="upnlTemplate" runat="server">
                                                                        <contenttemplate>
                                                                            <asp:GridView id="grdTemplate" runat="server" SkinID="GridView" Width="100%" AutoGenerateColumns="False" PageSize="12" OnDataBound="grdTemplate_DataBound" DataSourceID="odsTimesheetsTemplate" DataKeyNames="TeamProjectTimeID" OnRowDeleting="grdTemplate_RowDeleting">
                                                                                <Columns>                                                               
                                                                                   
                                                                                    <asp:TemplateField ShowHeader="False" Visible="False">
                                                                                        <ItemStyle horizontalalign="Center"></ItemStyle>
                                                                                        <ItemTemplate>
                                                                                              <asp:Label ID="lblTeamProjectTimeID" runat="server" SkinID="Label" Text='<%# Bind("TeamProjectTimeID") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    
                                                                                    
                                                                                                                           
                                                                                    <asp:TemplateField ShowHeader="False">
                                                                                        <ItemStyle horizontalalign="Center"></ItemStyle>
                                                                                        <HeaderStyle width="30px"></HeaderStyle>
                                                                                        <ItemTemplate>
                                                                                            <asp:CheckBox ID="cbxSelected" runat="server" onclick="return cbxSelectedClick(this);" Checked='<%# Eval("Selected") %>' />
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    
                                                                                    
                                                                                    
                                                                                    <asp:TemplateField HeaderText="Template" SortExpression="TemplateName">
                                                                                        <ItemStyle horizontalalign="Left"></ItemStyle>
                                                                                        <HeaderStyle Width="220px" ></HeaderStyle>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblTemplateName" runat="server" SkinID="Label" Text='<%# Bind("TemplateName") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    
                                                                                    
                                                                                    
                                                                                    <asp:TemplateField HeaderText="Client">
                                                                                        <ItemStyle horizontalalign="Left"></ItemStyle>
                                                                                        <HeaderStyle width="220px"></HeaderStyle>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblClientName" runat="server" SkinID="Label" Text='<%# Bind("ClientName") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    
                                                                                    
                                                                                    
                                                                                    <asp:TemplateField HeaderText="Project Number" SortExpression="ProjectNumber">
                                                                                        <ItemStyle horizontalalign="Center"></ItemStyle>
                                                                                        <HeaderStyle width="100px"></HeaderStyle>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblProjectNumber" runat="server" SkinID="Label" Text='<%# Bind("ProjectNumber") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    
                                                                                    
                                                                                    
                                                                                    <asp:TemplateField HeaderText="Project Name" SortExpression="ProjectName">
                                                                                        <ItemStyle horizontalalign="Left"></ItemStyle>
                                                                                        <HeaderStyle width="290px"></HeaderStyle>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblProjectName" runat="server" SkinID="Label" Text='<%# Bind("ProjectName") %>' ></asp:Label>
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
                                                                <asp:ObjectDataSource ID="odsTimesheetsTemplate" runat="server" FilterExpression="(Deleted = 0)"
                                                                    SelectMethod="GetTimesheetsTemplate" DeleteMethod="DummyTimesheetsTemplateNew"
                                                                    TypeName="LiquiForce.LFSLive.WebUI.LabourHours.TeamProjectTime.timesheet_team"
                                                                    OldValuesParameterFormatString="original_{0}">
                                                                    <DeleteParameters>
                                                                        <asp:Parameter Name="TeamProjectTimeID" Type="Int32" />
                                                                    </DeleteParameters>
                                                                </asp:ObjectDataSource>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:WizardStep>
                                                
                                                
                                                
                                                <asp:WizardStep ID="StepData" runat="server" Title="Data" StepType="Start">
                                                    <!-- Page element: 4 columns -->
                                                    <table border="0" cellpadding="0" cellspacing="0" width="720">
                                                        <tr>
                                                            <td style="width: 25%">
                                                                <asp:Label ID="lblClient" runat="server" SkinID="Label" Text="Client" EnableViewState="False"></asp:Label>
                                                            </td>
                                                            <td style="width: 25%">
                                                            </td>
                                                            <td style="width: 25%">
                                                                <asp:Label ID="lblProject" runat="server" SkinID="Label" Text="Project" EnableViewState="False"></asp:Label>
                                                            </td>
                                                            <td style="width: 25%">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="2">
                                                                <asp:UpdatePanel ID="upnlClient" runat="server" UpdateMode="Conditional">
                                                                    <contenttemplate>
                                                                        <asp:DropDownList id="ddlClient" runat="server" SkinID="DropDownListLookup" Width="330px" DataMember="DefaultView" DataSourceID="odsClient" AutoPostBack="True" DataValueField="COMPANIES_ID" DataTextField="NAME" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged"></asp:DropDownList> 
                                                                    </contenttemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                            <td colspan="2">
                                                                <!-- Page element: UpdatePanel -->
                                                                <asp:UpdatePanel ID="upnlProject" runat="server">
                                                                    <contenttemplate>
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 330px">
                                                                                        <asp:DropDownList ID="ddlProject" runat="server" SkinID="DropDownListLookup" Width="330px"
                                                                                            DataMember="DefaultView" DataSourceID="odsActiveProjectsActiveInternalProjectsActiveBallparkProjects"
                                                                                            AutoPostBack="True" DataValueField="ProjectID" DataTextField="NAME" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td style="vertical-align: middle">
                                                                                        <asp:UpdateProgress ID="upProject" runat="server" AssociatedUpdatePanelID="upnlClient">
                                                                                            <ProgressTemplate>
                                                                                                <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                                                            </ProgressTemplate>
                                                                                        </asp:UpdateProgress>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </contenttemplate>
                                                                    <triggers>
                                                                        <asp:AsyncPostBackTrigger ControlID="ddlClient" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                                                                    </triggers>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvClient" runat="server" ControlToValidate="ddlClient"
                                                                    Display="Dynamic" ErrorMessage="Please select a client." InitialValue="-1" SkinID="Validator"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td colspan="2">
                                                                <asp:RequiredFieldValidator ID="rfvProject" runat="server" ControlToValidate="ddlProject"
                                                                    Display="Dynamic" ErrorMessage="Please select a project." InitialValue="-1" SkinID="Validator"></asp:RequiredFieldValidator>
                                                                <asp:CustomValidator ID="cvProject" runat="server" ControlToValidate="ddlProject"
                                                                    Display="Dynamic" ErrorMessage="Please select an active project or an active internal project."
                                                                    SkinID="Validator" OnServerValidate="cvProject_ServerValidate" Width="330px"></asp:CustomValidator>
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
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblDate" runat="server" SkinID="Label" Text="Date" EnableViewState="False"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblWorkingDetailsGeneral" runat="server" SkinID="Label" Text="Working / Details" EnableViewState="False"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblState" runat="server" SkinID="Label" Text="State" EnableViewState="False"></asp:Label>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <telerik:RadDatePicker ID="tkrdpDate_" runat="server" Width="150px" SkinID="RadDatePicker" 
                                                                    Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                                                    <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" DayNameFormat="Short"
                                                                        ShowRowHeaders="False" ViewSelectorText="x">
                                                                    </Calendar>
                                                                    <DateInput Width="" DisplayDateFormat="M/d/yyyy" DateFormat="M/d/yyyy">
                                                                    </DateInput>
                                                                    <DatePopupButton CssClass="" ImageUrl="" HoverImageUrl=""></DatePopupButton>
                                                                </telerik:RadDatePicker>
                                                            </td>
                                                            <td>
                                                                <!-- Page element: UpdatePanel -->
                                                                <asp:UpdatePanel ID="upnlWorkingDetails" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 150px">
                                                                                        <asp:TextBox ID="tbxWorkingDetails" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true"
                                                                                            Width="150px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="vertical-align: middle">
                                                                                        <asp:UpdateProgress ID="upWorkingDetails" runat="server" AssociatedUpdatePanelID="upnlProject">
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
                                                                        <asp:AsyncPostBackTrigger ControlID="ddlProject" EventName="SelectedIndexChanged">
                                                                        </asp:AsyncPostBackTrigger>
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                            <td>
                                                                <asp:TextBox ID="tbxState" runat="server" SkinID="TextBoxReadOnly" ReadOnly="true" Text="For Approval" Width="165px"></asp:TextBox>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvDate" runat="server" ControlToValidate="tkrdpDate_"
                                                                    Display="Dynamic" ErrorMessage="Please provide a date." SkinID="Validator"></asp:RequiredFieldValidator>
                                                                <asp:CustomValidator ID="cvDatePayPeriod" runat="server" ControlToValidate="tkrdpDate_"
                                                                    Display="Dynamic" ErrorMessage="There isn't a Pay Period for the date entered."
                                                                    SkinID="Validator" Width="150px" EnableViewState="False"></asp:CustomValidator>
                                                                <asp:CustomValidator ID="cvDateLimitedPayPeriod" runat="server" ControlToValidate="tkrdpDate_"
                                                                    Display="Dynamic" ErrorMessage="You cannot add time in that date." SkinID="Validator"
                                                                    Width="150px" EnableViewState="False"></asp:CustomValidator>
                                                                <asp:CustomValidator ID="cvDateLimitedPayPeriodForWed" runat="server" ControlToValidate="tkrdpDate_"
                                                                    Display="Dynamic" ErrorMessage="You cannot add time in that date." SkinID="Validator"
                                                                    Width="150px" EnableViewState="False"></asp:CustomValidator>
                                                            </td>
                                                            <td>                                            
                                                            </td>
                                                            <td>
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
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblStartTimeGeneral" runat="server" SkinID="Label" Text="Start Time" EnableViewState="False"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblEndTimeGeneral" runat="server" SkinID="Label" Text="End Time" EnableViewState="False"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblLunchGeneral" runat="server" SkinID="Label" Text="Lunch" EnableViewState="False"></asp:Label>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>                                               
                                                                <asp:UpdatePanel id="upStartTime" runat="server" UpdateMode="Conditional">
                                                                    <contenttemplate>
                                                                        <asp:DropDownList ID="ddlStartTimeHour" runat="server" AutoPostBack="true" SkinID="DropDownList" 
                                                                        Style="width: 50px">
                                                                            <asp:ListItem Value=" " Selected="True" ></asp:ListItem>
                                                                            <asp:ListItem Value="0">0</asp:ListItem>
                                                                            <asp:ListItem Value="1">1</asp:ListItem>
                                                                            <asp:ListItem Value="2">2</asp:ListItem>
                                                                            <asp:ListItem Value="3">3</asp:ListItem>
                                                                            <asp:ListItem Value="4">4</asp:ListItem>
                                                                            <asp:ListItem Value="5">5</asp:ListItem>
                                                                            <asp:ListItem Value="6">6</asp:ListItem>
                                                                            <asp:ListItem Value="7">7</asp:ListItem>
                                                                            <asp:ListItem Value="8">8</asp:ListItem>
                                                                            <asp:ListItem Value="9">9</asp:ListItem>
                                                                            <asp:ListItem Value="10">10</asp:ListItem>
                                                                            <asp:ListItem Value="11">11</asp:ListItem>
                                                                            <asp:ListItem Value="12">12</asp:ListItem>
                                                                            <asp:ListItem Value="13">13</asp:ListItem>
                                                                            <asp:ListItem Value="14">14</asp:ListItem>
                                                                            <asp:ListItem Value="15">15</asp:ListItem>
                                                                            <asp:ListItem Value="16">16</asp:ListItem>
                                                                            <asp:ListItem Value="17">17</asp:ListItem>
                                                                            <asp:ListItem Value="18">18</asp:ListItem>
                                                                            <asp:ListItem Value="19">19</asp:ListItem>
                                                                            <asp:ListItem Value="20">20</asp:ListItem>
                                                                            <asp:ListItem Value="21">21</asp:ListItem>
                                                                            <asp:ListItem Value="22">22</asp:ListItem>
                                                                            <asp:ListItem Value="23">23</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:Label ID="lblStartTimeDots" runat="server" EnableViewState="False" 
                                                                            SkinID="Label" Text="   : " Width="6px"></asp:Label>
                                                                        <asp:DropDownList ID="ddlStartTimeMinute" runat="server" SkinID="DropDownList" Style="width: 50px">
                                                                            <asp:ListItem Value=" "></asp:ListItem>
                                                                            <asp:ListItem Value="00" Selected="True">00</asp:ListItem>
                                                                            <asp:ListItem Value="15">15</asp:ListItem>
                                                                            <asp:ListItem Value="30">30</asp:ListItem>
                                                                            <asp:ListItem Value="45">45</asp:ListItem>                                                                
                                                                        </asp:DropDownList>               
                                                                    </contenttemplate>           
                                                                </asp:UpdatePanel>                                                                                    
                                                            </td>
                                                            <td>                                              
                                                                <asp:UpdatePanel id="upEndTime" runat="server" UpdateMode="Conditional">
                                                                    <contenttemplate>
                                                                        <asp:DropDownList ID="ddlEndTimeHour" runat="server" AutoPostBack="true"  SkinID="DropDownList" 
                                                                        Style="width: 50px" >
                                                                            <asp:ListItem Value=" " Selected="True" ></asp:ListItem>
                                                                            <asp:ListItem Value="0">0</asp:ListItem>
                                                                            <asp:ListItem Value="1">1</asp:ListItem>
                                                                            <asp:ListItem Value="2">2</asp:ListItem>
                                                                            <asp:ListItem Value="3">3</asp:ListItem>
                                                                            <asp:ListItem Value="4">4</asp:ListItem>
                                                                            <asp:ListItem Value="5">5</asp:ListItem>
                                                                            <asp:ListItem Value="6">6</asp:ListItem>
                                                                            <asp:ListItem Value="7">7</asp:ListItem>
                                                                            <asp:ListItem Value="8">8</asp:ListItem>
                                                                            <asp:ListItem Value="9">9</asp:ListItem>
                                                                            <asp:ListItem Value="10">10</asp:ListItem>
                                                                            <asp:ListItem Value="11">11</asp:ListItem>
                                                                            <asp:ListItem Value="12">12</asp:ListItem>
                                                                            <asp:ListItem Value="13">13</asp:ListItem>
                                                                            <asp:ListItem Value="14">14</asp:ListItem>
                                                                            <asp:ListItem Value="15">15</asp:ListItem>
                                                                            <asp:ListItem Value="16">16</asp:ListItem>
                                                                            <asp:ListItem Value="17">17</asp:ListItem>
                                                                            <asp:ListItem Value="18">18</asp:ListItem>
                                                                            <asp:ListItem Value="19">19</asp:ListItem>
                                                                            <asp:ListItem Value="20">20</asp:ListItem>
                                                                            <asp:ListItem Value="21">21</asp:ListItem>
                                                                            <asp:ListItem Value="22">22</asp:ListItem>
                                                                            <asp:ListItem Value="23">23</asp:ListItem>
                                                                        </asp:DropDownList>
                                                                        <asp:Label ID="lblEndTimeDots" runat="server" EnableViewState="False" 
                                                                            SkinID="Label" Text="   : " Width="6px" ></asp:Label>
                                                                        <asp:DropDownList ID="ddlEndTimeMinute" runat="server" SkinID="DropDownList" Style="width: 50px">
                                                                            <asp:ListItem Value=" "></asp:ListItem>
                                                                            <asp:ListItem Value="00" Selected="True">00</asp:ListItem>
                                                                            <asp:ListItem Value="15">15</asp:ListItem>
                                                                            <asp:ListItem Value="30">30</asp:ListItem>
                                                                            <asp:ListItem Value="45">45</asp:ListItem>                                                                
                                                                        </asp:DropDownList>    
                                                                    </contenttemplate>           
                                                                </asp:UpdatePanel>                                         
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="ddlLunch" runat="server" SkinID="DropDownList" Style="width: 165px">
                                                                    <asp:ListItem Value="0">0.00</asp:ListItem>
                                                                    <asp:ListItem Value="0.25">0.25</asp:ListItem>
                                                                    <asp:ListItem Value="0.50">0.50</asp:ListItem>
                                                                    <asp:ListItem Value="0.75">0.75</asp:ListItem>
                                                                    <asp:ListItem Value="1.00">1.00</asp:ListItem>
                                                                    <asp:ListItem Value="1.25">1.25</asp:ListItem>
                                                                    <asp:ListItem Value="1.50">1.50</asp:ListItem>
                                                                    <asp:ListItem Value="1.75">1.75</asp:ListItem>
                                                                    <asp:ListItem Value="2.00">2.00</asp:ListItem>
                                                                </asp:DropDownList>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:CustomValidator ID="cvStartTimeDelete" runat="server" ControlToValidate="ddlStartTimeHour"
                                                                    Display="Dynamic" ErrorMessage="Please delete a start time." SkinID="Validator"
                                                                    ValidateEmptyText="True" EnableViewState="False"></asp:CustomValidator>
                                                                <asp:CustomValidator ID="cvStartTimeProvide" runat="server" ControlToValidate="ddlStartTimeHour"
                                                                    Display="Dynamic" ErrorMessage="Please provide a start time." SkinID="Validator"
                                                                    ValidateEmptyText="True" EnableViewState="False"></asp:CustomValidator>
                                                                <asp:CustomValidator ID="cvProjectTime" runat="server" Display="Dynamic" ErrorMessage="Project Time must be greater than zero."
                                                                    SkinID="Validator" EnableViewState="False"></asp:CustomValidator>
                                                                <asp:CustomValidator ID="cvValidStartTime" runat="server" ControlToValidate="ddlStartTimeHour"
                                                                    Display="Dynamic" ErrorMessage="Please provide a valid Time. (provide Hours : Minutes)" SkinID="Validator"
                                                                    ValidateEmptyText="True" EnableViewState="False" ValidationGroup="generalValidData" 
                                                                    onservervalidate="cvValidStartTime_ServerValidate"></asp:CustomValidator>
                                                            </td>
                                                            <td>
                                                                <asp:CustomValidator ID="cvEndTimeDelete" runat="server" ControlToValidate="ddlEndTimeHour"
                                                                    Display="Dynamic" ErrorMessage="Please delete a end time." SkinID="Validator"
                                                                    ValidateEmptyText="True" EnableViewState="False"></asp:CustomValidator>
                                                                <asp:CustomValidator ID="cvEndTimeProvide" runat="server" ControlToValidate="ddlEndTimeHour"
                                                                    Display="Dynamic" ErrorMessage="Please provide a end time." SkinID="Validator"
                                                                    ValidateEmptyText="True" EnableViewState="False"></asp:CustomValidator>   
                                                                <asp:CustomValidator ID="cvValidEndTime" runat="server" ControlToValidate="ddlEndTimeHour"
                                                                    Display="Dynamic" ErrorMessage="Please provide a valid Time. (provide Hours : Minutes)" SkinID="Validator"
                                                                    ValidateEmptyText="True" EnableViewState="False" ValidationGroup="generalValidData" 
                                                                    onservervalidate="cvValidEndTime_ServerValidate"></asp:CustomValidator>                                         
                                                            </td>
                                                            <td>
                                                                <asp:CustomValidator ID="cvLunchDelete" runat="server" ControlToValidate="ddlLunch"
                                                                    Display="Dynamic" ErrorMessage="Please delete a lunch time." SkinID="Validator"
                                                                    ValidateEmptyText="True" EnableViewState="False"></asp:CustomValidator>
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
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblTypeOfWork" runat="server" EnableViewState="False" SkinID="Label"
                                                                    Text="Type of Work"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <asp:Label ID="lblFunction" runat="server" EnableViewState="False" SkinID="Label"
                                                                    Text="Function"></asp:Label>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:UpdatePanel ID="upnlTypeOfWork" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <asp:DropDownList ID="ddlTypeOfWork" runat="server" SkinID="DropDownList" Width="150px"
                                                                            AutoPostBack="True" OnSelectedIndexChanged="ddlTypeOfWork_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                            <td>
                                                                <asp:UpdatePanel ID="upnlFunction" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 150px">
                                                                                        <asp:DropDownList ID="ddlFunction" runat="server" SkinID="DropDownList" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="ddlFunction_SelectedIndexChanged">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td style="vertical-align: middle">
                                                                                        <asp:UpdateProgress ID="upFunction" runat="server" AssociatedUpdatePanelID="upnlTypeOfWork">
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
                                                                        <asp:AsyncPostBackTrigger ControlID="ddlTypeOfWork" EventName="SelectedIndexChanged">
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
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvTypeOfWork" runat="server" ControlToValidate="ddlTypeOfWork"
                                                                    Display="Dynamic" EnableViewState="False" ErrorMessage="Please select a type of work."
                                                                    InitialValue="(Select a Type)" SkinID="Validator"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:RequiredFieldValidator ID="rfvFunction" runat="server" ControlToValidate="ddlFunction"
                                                                    Display="Dynamic" EnableViewState="False" ErrorMessage="Please select a function."
                                                                    InitialValue="(Select a Function)" SkinID="Validator"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
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
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblMealsCountry" runat="server" SkinID="Label" Text="Meals Country"
                                                                    EnableViewState="False"></asp:Label>
                                                            </td>
                                                            <td>
                                                                <%--<asp:Label ID="lblMealsAllowance" runat="server" SkinID="Label" Text="Meals Allowance"
                                                                    EnableViewState="False"></asp:Label>--%>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <!-- Page element: UpdatePanel -->
                                                                <asp:UpdatePanel ID="upnlMealsCountry" runat="server" UpdateMode="Conditional">
                                                                    <ContentTemplate>
                                                                        <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td style="width: 150px">
                                                                                        <asp:DropDownList ID="ddlMealsCountry" runat="server" SkinID="DropDownList" Width="150px"
                                                                                            DataMember="DefaultView" DataSourceID="odsMealsCountry" DataValueField="CountryID"
                                                                                            DataTextField="Name">
                                                                                        </asp:DropDownList>
                                                                                    </td>
                                                                                    <td style="vertical-align: middle">
                                                                                        <asp:UpdateProgress ID="upMealsCountry" runat="server" AssociatedUpdatePanelID="upnlProject">
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
                                                                        <asp:AsyncPostBackTrigger ControlID="ddlProject" EventName="SelectedIndexChanged">
                                                                        </asp:AsyncPostBackTrigger>
                                                                    </Triggers>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                            <td>
                                                                <%--<asp:CheckBox ID="cbxMealsAllowance" runat="server" SkinID="CheckBox" />--%>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                        <%--<tr>
                                                            <td>
                                                                <asp:CustomValidator ID="cvMealsCountry" runat="server" ControlToValidate="ddlMealsCountry"
                                                                    Display="Dynamic" ErrorMessage="You checked a meals allowance but not selected a meals country; please select a meals country."
                                                                    SkinID="Validator" Width="137px" EnableViewState="False"></asp:CustomValidator>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>--%>
                                                        <tr>
                                                            <td style="height: 7px">
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    
                                                    <asp:UpdatePanel ID="upnlFullLengthInstall" UpdateMode="Conditional" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Panel ID="pnlFullLengthInstall" runat="server"  Visible="false">
                                                                <!-- Page element: 4 columns -->
                                                                <table border="0" cellpadding="0" cellspacing="0" width="720">
                                                                    <tr>
                                                                        <td style="width: 25%">
                                                                            <asp:Label ID="lblSectionId" runat="server" SkinID="Label" Text="Sections" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 25%">
                                                                            <asp:UpdateProgress ID="upFullLengthInstall" runat="server" AssociatedUpdatePanelID="upnlFunction">
                                                                                <ProgressTemplate>
                                                                                    <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                                                </ProgressTemplate>
                                                                            </asp:UpdateProgress>  
                                                                        </td>
                                                                        <td style="width: 25%">                                                        
                                                                        </td>
                                                                        <td style="width: 25%">
                                                                        </td>
                                                                    </tr>
                                                                    <%--<tr>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlSections" runat="server" SkinID="DropDownListLookup" Width="150px"></asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxInstallDate" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Width="150px"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>--%>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:Panel ID="pnlSectionsInstall" runat="server" Height="200px" Width="330px" ScrollBars="Vertical">	                                                        
	                                                                            <asp:GridView ID="grdSectionsInstall" runat="server" AutoGenerateColumns="False" SkinID="GridView" Width="310px" 
		                                                                            OnDataBound="grdSectionsInstall_DataBound" DataSourceID="odsSectionsInstall" DataKeyNames="SectionID" 
		                                                                            DataMember="DefaultView" >
		                                                                            <Columns>
			                                                                            <asp:BoundField ReadOnly="True" DataField="SectionID" Visible="False" SortExpression="SectionID" HeaderText="SectionID"></asp:BoundField>
                                                                    					
			                                                                            <asp:TemplateField ShowHeader="False">
				                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
				                                                                            <HeaderStyle Width="40px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:CheckBox ID="cbxSelected" runat="server" Checked='<%# Eval("Selected") %>' />
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>
                                                                    					
			                                                                            <asp:TemplateField HeaderText="Section ID">
				                                                                            <HeaderStyle Width="110px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:Label ID="lblFlowOrderID" runat="server" Width="110px" SkinID="Label" Text='<%# Bind("FlowOrderID") %>'></asp:Label>
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>
                                                                    					
			                                                                            <asp:TemplateField HeaderText="Install Date">
				                                                                            <HeaderStyle Width="85px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:Label ID="lblInstallDate" runat="server" Width="85px" SkinID="Label" Text='<%# Bind("_Date", "{0:d}") %>'></asp:Label>
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>						  
		                                                                            </Columns>
	                                                                            </asp:GridView>
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <%--<asp:RequiredFieldValidator ID="rfvInstallSections" runat="server" ControlToValidate="ddlSections" ValidationGroup="generalValidInstall"
                                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Please select a section." InitialValue="-1" SkinID="Validator">
                                                                            </asp:RequiredFieldValidator>--%>
                                                                            <asp:CustomValidator ID="cvInstallSections" runat="server" OnServerValidate="cvInstallSections_ServerValidate"
                                                                                Display="Dynamic" ErrorMessage="Please select at least one section." ValidationGroup="generalValidInstall"
                                                                                SkinID="Validator" EnableViewState="False">
                                                                            </asp:CustomValidator>
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
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlFunction" EventName="SelectedIndexChanged">
                                                            </asp:AsyncPostBackTrigger>
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                    
                                                    <asp:UpdatePanel ID="upnlFullLengthPrepMeasure" UpdateMode="Conditional" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Panel ID="pnlFullLengthPrepMeasure" runat="server" Visible="false">
                                                                <!-- Page element: 4 columns -->
                                                                <table border="0" cellpadding="0" cellspacing="0" width="330px">
                                                                    <tr>
                                                                        <td style="width: 25%">
                                                                            <asp:Label ID="lblSections" runat="server" SkinID="Label" Text="Sections" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 25%">
                                                                             <asp:UpdateProgress ID="upFullLengthPrepMeasure" runat="server" AssociatedUpdatePanelID="upnlFunction">
                                                                                <ProgressTemplate>
                                                                                    <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                                                </ProgressTemplate>
                                                                            </asp:UpdateProgress>                                                       
                                                                        </td>
                                                                        <td style="width: 25%">                                            
                                                                        </td>
                                                                        <td style="width: 25%">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:Panel ID="pnlSections" runat="server" Height="200px" Width="330px" ScrollBars="Vertical">	                                                        
	                                                                            <asp:GridView ID="grdSections" runat="server" AutoGenerateColumns="False" SkinID="GridView" Width="310px" 
		                                                                            OnDataBound="grdSections_DataBound" DataSourceID="odsSections" DataKeyNames="SectionID" 
		                                                                            DataMember="DefaultView" >
		                                                                            <Columns>
			                                                                            <asp:BoundField ReadOnly="True" DataField="SectionID" Visible="False" SortExpression="SectionID" HeaderText="SectionID"></asp:BoundField>
                                                                    					
			                                                                            <asp:TemplateField ShowHeader="False">
				                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
				                                                                            <HeaderStyle Width="40px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:CheckBox ID="cbxSelected" runat="server" Checked='<%# Eval("Selected") %>' />
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>
                                                                    					
			                                                                            <asp:TemplateField HeaderText="Section ID">
				                                                                            <HeaderStyle Width="110px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:Label ID="lblFlowOrderID" runat="server" Width="110px" SkinID="Label" Text='<%# Bind("FlowOrderID") %>'></asp:Label>
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>
                                                                    					
			                                                                            <asp:TemplateField HeaderText="Completed">
				                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
				                                                                            <HeaderStyle Width="75px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:CheckBox ID="cbxCompleted" runat="server" Checked='<%# Eval("Completed") %>' />
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>
                                                                    					
			                                                                            <asp:TemplateField HeaderText="Prep Date">
				                                                                            <HeaderStyle Width="85px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:Label ID="lblPrepDate" runat="server" Width="85px" SkinID="Label" Text='<%# Bind("_Date", "{0:d}") %>'></asp:Label>
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>						  
		                                                                            </Columns>
	                                                                            </asp:GridView>
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:CustomValidator ID="cvPrepMeasureSections" runat="server" OnServerValidate="cvPrepMeasureSections_ServerValidate"
                                                                                Display="Dynamic" ErrorMessage="Please select at least one section." ValidationGroup="generalValidPrepMeasure"
                                                                                SkinID="Validator" EnableViewState="False">
                                                                            </asp:CustomValidator>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlFunction" EventName="SelectedIndexChanged">
                                                            </asp:AsyncPostBackTrigger>
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                    
                                                    <asp:UpdatePanel ID="upnlFullLengthReinstatePostVideo" UpdateMode="Conditional" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Panel ID="pnlFullLengthReinstatePostVideo" runat="server" Visible="false">
                                                                <!-- Page element: 4 columns -->
                                                                <table border="0" cellpadding="0" cellspacing="0" width="720">
                                                                    <tr>
                                                                        <td style="width: 25%">
                                                                            <asp:Label ID="lblSectionsFullLengthReinstatePostVideo" runat="server" SkinID="Label" Text="Sections" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 25%">
                                                                             <asp:UpdateProgress ID="upFullLengthReinstatePostVideo" runat="server" AssociatedUpdatePanelID="upnlFunction">
                                                                                <ProgressTemplate>
                                                                                    <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                                                </ProgressTemplate>
                                                                            </asp:UpdateProgress>
                                                                        </td>
                                                                        <td style="width: 25%">                                            
                                                                        </td>
                                                                        <td style="width: 25%">
                                                                        </td>
                                                                    </tr>
                                                                    <%--<tr>
                                                                        <td style="width: 180px">
                                                                            <asp:Label ID="lblSectionIdReinstatePostVideo" runat="server" SkinID="Label" Text="Section ID" EnableViewState="False"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 180px">
                                                                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                                                <tr>
                                                                                    <td style="width: 50%;">
                                                                                        <asp:Label ID="lblPercentageOpened" runat="server" SkinID="LabelSmall" Text="Percentage Opened"></asp:Label>
                                                                                    </td>
                                                                                    <td style="width: 50%;">
                                                                                        <asp:Label ID="lblPercentageBrushed" runat="server" SkinID="LabelSmall" Text="Percentage Brushed"></asp:Label>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>                                                        
                                                                        </td>
                                                                        <td style="width: 180px">
                                                                            <asp:Label ID="lblCompleted" runat="server" SkinID="Label" Text="Completed"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 180px">
                                                                            <asp:Label ID="lblPostVideo" runat="server" SkinID="Label" Text="Post Video"></asp:Label>
                                                                            
                                                                        </td>
                                                                    </tr>--%>
                                                                    <%--<tr>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlSectionsReinstatePostVideo" runat="server" SkinID="DropDownListLookup" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="ddlSectionsReinstatePostVideo_SelectedIndexChanged" ></asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            <table cellspacing="0" cellpadding="0" width="150px" border="0">
                                                                                <tr>
                                                                                    <td style="width: 70px">
                                                                                        <asp:TextBox ID="tbxPercentageOpened" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Width="70px"></asp:TextBox>
                                                                                    </td>
                                                                                    <td style="width: 10px">
                                                                                        +
                                                                                    </td>
                                                                                    <td style="width: 70px">
                                                                                        <asp:TextBox ID="tbxPercentageBrushed" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Width="70px"></asp:TextBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </td>
                                                                        <td>
                                                                            <asp:CheckBox ID="cbxCompleted" runat="server" SkinID="CheckBox" onclick="return cbxClick();" />                                                        
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="tbxPostVideo" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:RequiredFieldValidator ID="rfvReinstatePostVideoSection" runat="server" ControlToValidate="ddlSectionsReinstatePostVideo" ValidationGroup="generalValidReinstatePostVideo"
                                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Please select a section." InitialValue="-1" SkinID="Validator">
                                                                            </asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>--%>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:Panel ID="pnlSectionsReinstatePostVideo" runat="server" Height="140px" Width="540px" ScrollBars="Vertical">	                                                        
	                                                                            <asp:GridView ID="grdSectionsReinstatePostVideo" runat="server" AutoGenerateColumns="False" SkinID="GridView" Width="520px" 
		                                                                            OnDataBound="grdSectionsReinstatePostVideo_DataBound" DataSourceID="odsSectionsReinstatePostVideo" DataKeyNames="SectionID" 
		                                                                            DataMember="DefaultView"  >
		                                                                            <Columns>
			                                                                            <asp:BoundField ReadOnly="True" DataField="SectionID" Visible="False" SortExpression="SectionID" HeaderText="SectionID"></asp:BoundField>
                                                                    					
			                                                                            <asp:TemplateField ShowHeader="False">
				                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
				                                                                            <HeaderStyle Width="40px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:CheckBox ID="cbxSelected" runat="server" Checked='<%# Eval("Selected") %>' AutoPostBack="True" OnCheckedChanged="cbxSelectedSectionReinstatePostVideo_CheckedChanged" />
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>
                                                                    					
			                                                                            <asp:TemplateField HeaderText="Section ID">
				                                                                            <HeaderStyle Width="110px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:Label ID="lblFlowOrderID" runat="server" Width="110px" SkinID="Label" Text='<%# Bind("FlowOrderID") %>'></asp:Label>
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>
                    			                                                        
			                                                                            <asp:TemplateField HeaderText="Percentage Opened">
			                                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
				                                                                            <HeaderStyle Width="50px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:Label ID="lblPercentageOpened" runat="server" Width="110px" SkinID="Label" Text='<%# Bind("PercentageOpened") %>'></asp:Label>
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>
                    			                                                        
			                                                                            <asp:TemplateField HeaderText="Percentage Brushed">
			                                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
				                                                                            <HeaderStyle Width="50px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:Label ID="lblPercentageBrushed" runat="server" Width="110px" SkinID="Label" Text='<%# Bind("PercentageBrushed") %>'></asp:Label>
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>
                                                                    					
			                                                                            <asp:TemplateField HeaderText="Completed">
				                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
				                                                                            <HeaderStyle Width="75px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:CheckBox ID="cbxCompleted" runat="server" Checked='<%# Eval("Completed") %>' onclick="return cbxClick();" />
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>
                                                                    					
			                                                                            <asp:TemplateField HeaderText="Post Video">
				                                                                            <HeaderStyle Width="85px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:Label ID="lblPostVideo" runat="server" Width="85px" SkinID="Label" Text='<%# Bind("_Date", "{0:d}") %>'></asp:Label>
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>
                    			                                                        
			                                                                            <asp:TemplateField HeaderText="" Visible="false">
				                                                                            <HeaderStyle Width="0px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:Label ID="lblSectionID" runat="server" SkinID="Label" Text='<%# Bind("SectionID") %>'></asp:Label>
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>
		                                                                            </Columns>
	                                                                            </asp:GridView>
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:CustomValidator ID="cvReinstatePostVideoSection" runat="server" OnServerValidate="cvReinstatePostVideoSections_ServerValidate"
                                                                                Display="Dynamic" ErrorMessage="Please select at least one section." ValidationGroup="generalValidReinstatePostVideo"
                                                                                SkinID="Validator" EnableViewState="False">
                                                                            </asp:CustomValidator>
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
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:Label ID="lblTitleLaterals" SkinID="Label" runat="server" Text="Laterals"></asp:Label>                                                        
                                                                        </td>
                                                                        <td>
                                                                            <asp:UpdateProgress ID="upFullLengthReinstatePostVideo2" runat="server" AssociatedUpdatePanelID="upnlFullLengthReinstatePostVideo">
                                                                                <ProgressTemplate>
                                                                                    <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                                                </ProgressTemplate>
                                                                            </asp:UpdateProgress>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                        <td>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:Panel ID="pnlLaterals" runat="server" Height="140px" Width="385px" ScrollBars="Auto">	                                                        
	                                                                            <asp:GridView ID="grdLaterals" runat="server" AutoGenerateColumns="False" SkinID="GridView" Width="365px" 
		                                                                            OnDataBound="grdLaterals_DataBound" DataSourceID="odsLaterals" DataKeyNames="SectionID, LateralID" 
		                                                                            DataMember="DefaultView">
		                                                                            <Columns>
			                                                                            <asp:BoundField ReadOnly="True" DataField="SectionID" Visible="False" SortExpression="SectionID" HeaderText="SectionID"></asp:BoundField>
			                                                                            <asp:BoundField ReadOnly="True" DataField="LateralID" Visible="False" SortExpression="LateralID" HeaderText="LateralID"></asp:BoundField>
                                                                    					
			                                                                            <asp:TemplateField ShowHeader="False">
				                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
				                                                                            <HeaderStyle Width="25px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:CheckBox ID="cbxSelected" runat="server" Checked='<%# Eval("Selected") %>' />
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>
                                                                    					
			                                                                            <asp:TemplateField HeaderText="Lateral ID">
				                                                                            <HeaderStyle Width="110px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:Label ID="lblLateralID" runat="server" Width="110px" SkinID="Label" Text='<%# Bind("LateralID") %>'></asp:Label>
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>
                    			                                                        
			                                                                            <asp:TemplateField HeaderText="Opened">
				                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
				                                                                            <HeaderStyle Width="115px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:CheckBox ID="cbxOpened" runat="server" Checked='<%# Eval("Opened") %>' OnCheckedChanged="cbxOpened_OnCheckedChanged" AutoPostBack="true" />
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>		
                                                                    					
			                                                                            <asp:TemplateField HeaderText="Brushed">
				                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
				                                                                            <HeaderStyle Width="115px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:CheckBox ID="cbxBrushed" runat="server" Checked='<%# Eval("Brushed") %>' OnCheckedChanged="cbxOpened_OnCheckedChanged" AutoPostBack="true" />
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>
                    			                                                        
			                                                                            <asp:TemplateField HeaderText="Section ID" Visible="false">
				                                                                            <HeaderStyle Width="0px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:Label ID="lblSectionID" runat="server" SkinID="Label" Text='<%# Bind("SectionID") %>'></asp:Label>
				                                                                            </ItemTemplate>
				                                                                        </asp:TemplateField>
                    				                                                    
				                                                                        <asp:TemplateField HeaderText="Lateral Asset ID" Visible="false">
				                                                                            <HeaderStyle Width="0px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:Label ID="lblAssetIDLateral" runat="server" SkinID="Label" Text='<%# Bind("AssetIDLateral") %>'></asp:Label>
				                                                                            </ItemTemplate>
				                                                                        </asp:TemplateField>
		                                                                            </Columns>
	                                                                            </asp:GridView>
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:CustomValidator ID="cvReinstatePostVideoLaterals" runat="server" OnServerValidate="cvReinstatePostVideoLaterals_ServerValidate"
                                                                                Display="Dynamic" ErrorMessage="Please select at least one lateral. You must be select brushed or opened" ValidationGroup="generalValidReinstatePostVideo"
                                                                                SkinID="Validator" EnableViewState="False">
                                                                            </asp:CustomValidator>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlFunction" EventName="SelectedIndexChanged">
                                                            </asp:AsyncPostBackTrigger>
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                    
                                                    <%--Start--%>
                                                    
                                                    <asp:UpdatePanel ID="upnlManholesRehabPrep" UpdateMode="Conditional" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Panel ID="pnlSectionsManholesRehabPrep" runat="server" Visible="false">
                                                                <!-- Page element: 4 columns -->
                                                                <table border="0" cellpadding="0" cellspacing="0" width="720">
                                                                    <tr>
                                                                        <td style="width: 180px">
                                                                            <asp:Label ID="lblManholesRehabPrep" runat="server" Text="Manholes" SkinID="Label"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 180px">
                                                                            <asp:UpdateProgress ID="upManholesRehabPrep" runat="server" AssociatedUpdatePanelID="upnlFunction">
                                                                                <ProgressTemplate>
                                                                                    <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                                                </ProgressTemplate>
                                                                            </asp:UpdateProgress>
                                                                        </td>
                                                                        <td style="width: 180px">
                                                                        </td>
                                                                        <td style="width: 180px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:Panel ID="pnlManholesRehabPrep" runat="server" Height="140px" Width="515px" ScrollBars="Auto">	                                                        
	                                                                            <asp:GridView ID="grdManholesRehabPrep" runat="server" AutoGenerateColumns="False" SkinID="GridView" Width="365px" 
		                                                                            OnDataBound="grdManholesRehabPrep_DataBound" DataSourceID="odsManholesRehabPrep" DataKeyNames="AssetID" 
		                                                                            DataMember="DefaultView">
		                                                                            <Columns>
			                                                                            <asp:BoundField ReadOnly="True" DataField="AssetID" Visible="False" SortExpression="AssetID" HeaderText="AssetID"></asp:BoundField>
                                                                    					
			                                                                            <asp:TemplateField ShowHeader="False">
				                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
				                                                                            <HeaderStyle Width="25px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:CheckBox ID="cbxSelected" runat="server" Checked='<%# Eval("Selected") %>' />
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>
                                                                    					
			                                                                            <asp:TemplateField HeaderText="MH #">
				                                                                            <HeaderStyle Width="110px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:Label ID="lblMHID" runat="server" Width="110px" SkinID="Label" Text='<%# Bind("ManholeNumber") %>'></asp:Label>
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>
                    			                                                        
			                                                                            <asp:TemplateField HeaderText="Street">
				                                                                            <HeaderStyle Width="170px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:Label ID="lblAddress" runat="server" Width="170px" SkinID="Label" Text='<%# Bind("Street") %>'></asp:Label>
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>
                    			                                                        
			                                                                            <asp:TemplateField HeaderText="Square Foot">
				                                                                            <HeaderStyle Width="85px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:Label ID="lblLongitude" runat="server" Width="110px" SkinID="Label" Text='<%# Bind("SquareFoot") %>'></asp:Label>
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>
                    			                                                        
			                                                                            <asp:TemplateField HeaderText="Preped Date">
				                                                                            <HeaderStyle Width="85px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:Label ID="lblPrepDate" runat="server" Width="85px" SkinID="Label" Text='<%# Bind("_Date", "{0:d}") %>'></asp:Label>
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>
		                                                                            </Columns>
	                                                                            </asp:GridView>
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:CustomValidator ID="cvManholesRehabPrep" runat="server" OnServerValidate="cvManholesRehabPrep_ServerValidate"
                                                                                Display="Dynamic" ErrorMessage="Please select at least one manhole." ValidationGroup="generalValidManholesRehabPrep"
                                                                                SkinID="Validator" EnableViewState="False">
                                                                            </asp:CustomValidator>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlFunction" EventName="SelectedIndexChanged">
                                                            </asp:AsyncPostBackTrigger>
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                    
                                                    <asp:UpdatePanel ID="upnlManholesRehabSpray" UpdateMode="Conditional" runat="server">
                                                        <ContentTemplate>
                                                            <asp:Panel ID="pnlSectionsManholesRehabSpray" runat="server" Visible="false">
                                                                <!-- Page element: 4 columns -->
                                                                <table border="0" cellpadding="0" cellspacing="0" width="720">
                                                                    <tr>
                                                                        <td style="width: 180px">
                                                                            <asp:Label ID="lblManholesRehabSpray" runat="server" Text="Manholes" SkinID="Label"></asp:Label>
                                                                        </td>
                                                                        <td style="width: 180px">
                                                                            <asp:UpdateProgress ID="upManholesRehabSpray" runat="server" AssociatedUpdatePanelID="upnlFunction">
                                                                                <ProgressTemplate>
                                                                                    <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                                                </ProgressTemplate>
                                                                            </asp:UpdateProgress>
                                                                        </td>
                                                                        <td style="width: 180px">
                                                                        </td>
                                                                        <td style="width: 180px">
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:Panel ID="pnlManholesRehabSpray" runat="server" Height="140px" Width="515px" ScrollBars="Auto">	                                                        
	                                                                            <asp:GridView ID="grdManholesRehabSpray" runat="server" AutoGenerateColumns="False" SkinID="GridView" Width="365px" 
		                                                                            OnDataBound="grdManholesRehabSpray_DataBound" DataSourceID="odsManholesRehabSpray" DataKeyNames="AssetID" 
		                                                                            DataMember="DefaultView">
		                                                                            <Columns>
			                                                                            <asp:BoundField ReadOnly="True" DataField="AssetID" Visible="False" SortExpression="AssetID" HeaderText="AssetID"></asp:BoundField>
                                                                    					
			                                                                            <asp:TemplateField ShowHeader="False">
				                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
				                                                                            <HeaderStyle Width="25px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:CheckBox ID="cbxSelected" runat="server" Checked='<%# Eval("Selected") %>' />
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>
                                                                    					
			                                                                            <asp:TemplateField HeaderText="MH #">
				                                                                            <HeaderStyle Width="110px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:Label ID="lblMHID" runat="server" Width="110px" SkinID="Label" Text='<%# Bind("ManholeNumber") %>'></asp:Label>
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>
                    			                                                        
			                                                                            <asp:TemplateField HeaderText="Street">
				                                                                            <HeaderStyle Width="170px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:Label ID="lblAddress" runat="server" Width="170px" SkinID="Label" Text='<%# Bind("Street") %>'></asp:Label>
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>
                    			                                                        
			                                                                            <asp:TemplateField HeaderText="Square Foot">
				                                                                            <HeaderStyle Width="85px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:Label ID="lblLongitude" runat="server" Width="110px" SkinID="Label" Text='<%# Bind("SquareFoot") %>'></asp:Label>
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>
                    			                                                        
			                                                                            <asp:TemplateField HeaderText="Sprayed Date">
				                                                                            <HeaderStyle Width="85px"></HeaderStyle>
				                                                                            <ItemTemplate>
					                                                                            <asp:Label ID="lblSprayDate" runat="server" Width="85px" SkinID="Label" Text='<%# Bind("_Date", "{0:d}") %>'></asp:Label>
				                                                                            </ItemTemplate>
			                                                                            </asp:TemplateField>
		                                                                            </Columns>
	                                                                            </asp:GridView>
                                                                            </asp:Panel>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td colspan="4">
                                                                            <asp:CustomValidator ID="cvManholesRehabSpray" runat="server" OnServerValidate="cvManholesRehabSpray_ServerValidate"
                                                                                Display="Dynamic" ErrorMessage="Please select at least one manhole." ValidationGroup="generalValidManholesRehabSpray"
                                                                                SkinID="Validator" EnableViewState="False">
                                                                            </asp:CustomValidator>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </asp:Panel>
                                                        </ContentTemplate>
                                                        <Triggers>
                                                            <asp:AsyncPostBackTrigger ControlID="ddlFunction" EventName="SelectedIndexChanged">
                                                            </asp:AsyncPostBackTrigger>
                                                        </Triggers>
                                                    </asp:UpdatePanel>
                                                    
                                                    <%--End--%>
                                                    
                                                    <br />
                                                    <br />
                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tr>
                                                            <td style="width: 25%">
                                                                <%--<asp:Label ID="lblClearUnitsAssigment" runat="server" SkinID="Label" Text="Clear Units assigment"
                                                                    EnableViewState="False"></asp:Label>--%>
                                                            </td>
                                                            <td style="width: 25%">
                                                            </td>
                                                            <td style="width: 25%">
                                                            </td>
                                                            <td style="width: 25%">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                    <%--                                            <asp:CheckBox ID="cbxClearUnitAssigment" runat="server" SkinID="CheckBox" />
                    --%>                                        </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                            <td>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:WizardStep>
                                                
                                                
                                                
                                                <asp:WizardStep ID="StepEmployees" runat="server" Title="Employees">
                                                    <!-- Page element: 1 column title -->
                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                        <tr>
                                                            <td style="width: 35px">
                                                                <asp:Label ID="lblDateEmployees" runat="server" SkinID="Label" Text="Date" EnableViewState="False"></asp:Label>
                                                            </td>
                                                            <td colspan="2" style="width: 850px">                                            
                                                                <asp:TextBox ID="tbxDate" runat="server" SkinID="TextBoxReadOnly" Width="170px" ReadOnly="True"></asp:TextBox>                                                
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td colspan="3">
                                                                <asp:CustomValidator ID="cvValidDatePayPeriod" runat="server" ControlToValidate="tbxDate"
                                                                    Display="Dynamic" EnableViewState="False" ErrorMessage="There isn't a Pay Period for the date entered."
                                                                    OnServerValidate="cvValidDatePayPeriod_ServerValidate" SkinID="Validator" ValidateEmptyText="True"
                                                                    ValidationGroup="teamMember"></asp:CustomValidator>
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
                                                    </table>
                                                    
                                                    <!-- Page element: 1 -->
                                                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">                                    
                                                        <tr>
                                                            <td>
                                                                <asp:Panel ID="pnlProjectTime" runat="server" Height="330px" Width="900px">
                                                                    <asp:UpdatePanel id="upnlProjectTime" runat="server">
                                                                        <contenttemplate>
                                                                            <!-- Page element: 1 column - Grid Project Time -->
                                                                            <asp:GridView ID="grdProjectTime" runat="server" SkinID="GridView" Width="100%" AutoGenerateColumns="False"
                                                                                AllowPaging="True" PageSize="3" ShowFooter="True" OnDataBound="grdProjectTime_DataBound"
                                                                                OnRowCommand="grdProjectTime_RowCommand" OnRowUpdating="grdProjectTime_RowUpdating" OnRowEditing="grdProjectTime_RowEditing"
                                                                                OnRowDeleting="grdProjectTime_RowDeleting" OnRowDataBound="grdProjectTime_RowDataBound"
                                                                                DataKeyNames="TeamProjectTimeID,DetailID" DataSourceID="odsTeamProjectTimeDetail">
                                                                                <Columns>
                                                                                    <asp:TemplateField SortExpression="TeamProjectTimeID" Visible="False" HeaderText="TeamProjectTimeID">
                                                                                        <EditItemTemplate>
                                                                                            <asp:Label ID="lblTeamProjectTimeIdEdit" runat="server" Text='<%# Eval("TeamProjectTimeID") %>'></asp:Label>
                                                                                        </EditItemTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblTeamProjectTimeId" runat="server" Text='<%# Eval("TeamProjectTimeID") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    
                                                                                    <asp:TemplateField SortExpression="DetailID" Visible="False" HeaderText="DetailID">
                                                                                        <EditItemTemplate>
                                                                                            <asp:Label ID="lblDetailIdEdit" runat="server" Text='<%# Eval("DetailID") %>'></asp:Label>
                                                                                        </EditItemTemplate>
                                                                                        <FooterTemplate>
                                                                                            <asp:Label ID="lblDetailIdFooter" runat="server" Text='<%# Eval("DetailID") %>'></asp:Label>
                                                                                        </FooterTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblDetailId" runat="server" Text='<%# Eval("DetailID") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>
                                                                                    
                                                                                    <asp:TemplateField SortExpression="EmployeeID" Visible="False" HeaderText="EmployeeID">
                                                                                        <EditItemTemplate>
                                                                                            <asp:Label ID="lblEmployeeIdEdit" runat="server" Text='<%# Eval("EmployeeID") %>'></asp:Label>
                                                                                        </EditItemTemplate>
                                                                                        <ItemTemplate>
                                                                                            <asp:Label ID="lblEmployeeId" runat="server" Text='<%# Eval("EmployeeID") %>'></asp:Label>
                                                                                        </ItemTemplate>
                                                                                    </asp:TemplateField>                                                                                                            
                                                                                    
                                                                                    <asp:TemplateField SortExpression="ProjectTime" HeaderText="Project Time">
                                                                                        <EditItemTemplate>
                                                                                            <!-- Page element : 9 columns - Data -->
                                                                                            <table style="width: 850px" cellspacing="0" cellpadding="0" border="0">
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td style="width: 10px; height: 7px">
                                                                                                        </td>
                                                                                                        <td style="width: 90px;">
                                                                                                        </td>
                                                                                                        <td style="width: 90px">
                                                                                                        </td>
                                                                                                        <td style="width: 135px">
                                                                                                        </td>
                                                                                                        <td style="width: 135px">
                                                                                                        </td>
                                                                                                        <td style="width: 90px">
                                                                                                        </td>
                                                                                                        <td style="width: 210px">
                                                                                                        </td>
                                                                                                        <td style="width: 90px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                        <td colspan="2">
                                                                                                            <asp:Label ID="lblTeamMemberEdit" runat="server" SkinID="Label" Text="Available Team Member"></asp:Label></td>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblStartTimeEdit" runat="server" SkinID="Label" Text="Start Time"></asp:Label></td>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblEndTimeEdit" runat="server" SkinID="Label" Text="End Time"></asp:Label></td>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblLunchEdit" runat="server" SkinID="Label" Text="Lunch"></asp:Label></td>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblTypeOfWorkFunctionEdit" runat="server" SkinID="Label" Text="Type of Work - Function"></asp:Label></td>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblJobClassTypeEdit" runat="server" SkinID="Label" Text="Job Class"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                        <td colspan="2">
                                                                                                            <asp:UpdatePanel ID="upnlEmployeeEdit" runat="server" UpdateMode="Conditional">
                                                                                                                <contenttemplate>                                                                   
                                                                                                                    <asp:DropDownList Style="width: 170px" ID="ddlEmployeesEdit" runat="server" AutoPostBack="true" SkinID="DropDownList" DataSourceID="odsEmployeeAvailable" 
                                                                                                                        DataTextField="FullName" DataValueField="EmployeeID" OnSelectedIndexChanged="ddlEmployeesEdit_SelectedIndexChanged">
                                                                                                                    </asp:DropDownList>
                                                                                                                </contenttemplate>
                                                                                                            </asp:UpdatePanel>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:UpdatePanel id="upStartTimeEdit" runat="server" UpdateMode="Conditional">
                                                                                                                <contenttemplate>
                                                                                                                    <asp:DropDownList ID="ddlStartTimeHourEdit" runat="server" AutoPostBack="true"  SkinID="DropDownList" 
                                                                                                                    Style="width: 50px" >
                                                                                                                        <asp:ListItem Value=" " Selected="True" ></asp:ListItem>
                                                                                                                        <asp:ListItem Value="0">0</asp:ListItem>
                                                                                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                                                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                                                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                                                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                                                                                        <asp:ListItem Value="5">5</asp:ListItem>
                                                                                                                        <asp:ListItem Value="6">6</asp:ListItem>
                                                                                                                        <asp:ListItem Value="7">7</asp:ListItem>
                                                                                                                        <asp:ListItem Value="8">8</asp:ListItem>
                                                                                                                        <asp:ListItem Value="9">9</asp:ListItem>
                                                                                                                        <asp:ListItem Value="10">10</asp:ListItem>
                                                                                                                        <asp:ListItem Value="11">11</asp:ListItem>
                                                                                                                        <asp:ListItem Value="12">12</asp:ListItem>
                                                                                                                        <asp:ListItem Value="13">13</asp:ListItem>
                                                                                                                        <asp:ListItem Value="14">14</asp:ListItem>
                                                                                                                        <asp:ListItem Value="15">15</asp:ListItem>
                                                                                                                        <asp:ListItem Value="16">16</asp:ListItem>
                                                                                                                        <asp:ListItem Value="17">17</asp:ListItem>
                                                                                                                        <asp:ListItem Value="18">18</asp:ListItem>
                                                                                                                        <asp:ListItem Value="19">19</asp:ListItem>
                                                                                                                        <asp:ListItem Value="20">20</asp:ListItem>
                                                                                                                        <asp:ListItem Value="21">21</asp:ListItem>
                                                                                                                        <asp:ListItem Value="22">22</asp:ListItem>
                                                                                                                        <asp:ListItem Value="23">23</asp:ListItem>
                                                                                                                    </asp:DropDownList>
                                                                                                                    <asp:Label ID="lblStartTimeDotsEdit" runat="server" EnableViewState="False" 
                                                                                                                        SkinID="Label" Text=":"></asp:Label>
                                                                                                                    <asp:DropDownList ID="ddlStartTimeMinuteEdit" runat="server"   SkinID="DropDownList" Style="width:50px">
                                                                                                                        <asp:ListItem Value=" " Selected="True"></asp:ListItem>
                                                                                                                        <asp:ListItem Value="00">00</asp:ListItem>
                                                                                                                        <asp:ListItem Value="15">15</asp:ListItem>
                                                                                                                        <asp:ListItem Value="30">30</asp:ListItem>
                                                                                                                        <asp:ListItem Value="45">45</asp:ListItem>                                                                
                                                                                                                    </asp:DropDownList>               
                                                                                                                </contenttemplate>           
                                                                                                            </asp:UpdatePanel> 
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:UpdatePanel id="upEndTimeEdit" runat="server" UpdateMode="Conditional">
                                                                                                                <contenttemplate>
                                                                                                                    <asp:DropDownList ID="ddlEndTimeHourEdit" runat="server" AutoPostBack="true"  SkinID="DropDownList" 
                                                                                                                    Style="width: 50px">
                                                                                                                        <asp:ListItem Value=" " Selected="True" ></asp:ListItem>
                                                                                                                        <asp:ListItem Value="0">0</asp:ListItem>
                                                                                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                                                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                                                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                                                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                                                                                        <asp:ListItem Value="5">5</asp:ListItem>
                                                                                                                        <asp:ListItem Value="6">6</asp:ListItem>
                                                                                                                        <asp:ListItem Value="7">7</asp:ListItem>
                                                                                                                        <asp:ListItem Value="8">8</asp:ListItem>
                                                                                                                        <asp:ListItem Value="9">9</asp:ListItem>
                                                                                                                        <asp:ListItem Value="10">10</asp:ListItem>
                                                                                                                        <asp:ListItem Value="11">11</asp:ListItem>
                                                                                                                        <asp:ListItem Value="12">12</asp:ListItem>
                                                                                                                        <asp:ListItem Value="13">13</asp:ListItem>
                                                                                                                        <asp:ListItem Value="14">14</asp:ListItem>
                                                                                                                        <asp:ListItem Value="15">15</asp:ListItem>
                                                                                                                        <asp:ListItem Value="16">16</asp:ListItem>
                                                                                                                        <asp:ListItem Value="17">17</asp:ListItem>
                                                                                                                        <asp:ListItem Value="18">18</asp:ListItem>
                                                                                                                        <asp:ListItem Value="19">19</asp:ListItem>
                                                                                                                        <asp:ListItem Value="20">20</asp:ListItem>
                                                                                                                        <asp:ListItem Value="21">21</asp:ListItem>
                                                                                                                        <asp:ListItem Value="22">22</asp:ListItem>
                                                                                                                        <asp:ListItem Value="23">23</asp:ListItem>
                                                                                                                    </asp:DropDownList>
                                                                                                                    <asp:Label ID="lblEndTimeDotsEdit" runat="server" EnableViewState="False" 
                                                                                                                        SkinID="Label" Text=":"></asp:Label>
                                                                                                                    <asp:DropDownList ID="ddlEndTimeMinuteEdit" runat="server"   SkinID="DropDownList" Style="width: 50px">
                                                                                                                        <asp:ListItem Value=" " Selected="True"></asp:ListItem>
                                                                                                                        <asp:ListItem Value="00">00</asp:ListItem>
                                                                                                                        <asp:ListItem Value="15">15</asp:ListItem>
                                                                                                                        <asp:ListItem Value="30">30</asp:ListItem>
                                                                                                                        <asp:ListItem Value="45">45</asp:ListItem>                                                                
                                                                                                                    </asp:DropDownList>                                                                                               
                                                                                                                </contenttemplate>           
                                                                                                            </asp:UpdatePanel> 
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:DropDownList ID="ddlLunchEdit" runat="server" SkinID="DropDownList" Style="width: 80px">
                                                                                                                <asp:ListItem Value="0">0.00</asp:ListItem>
                                                                                                                <asp:ListItem Value="0.25">0.25</asp:ListItem>
                                                                                                                <asp:ListItem Value="0.50">0.50</asp:ListItem>
                                                                                                                <asp:ListItem Value="0.75">0.75</asp:ListItem>
                                                                                                                <asp:ListItem Value="1.00">1.00</asp:ListItem>
                                                                                                                <asp:ListItem Value="1.25">1.25</asp:ListItem>
                                                                                                                <asp:ListItem Value="1.50">1.50</asp:ListItem>
                                                                                                                <asp:ListItem Value="1.75">1.75</asp:ListItem>
                                                                                                                <asp:ListItem Value="2.00">2.00</asp:ListItem>
                                                                                                            </asp:DropDownList>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:DropDownList Style="width: 200px" ID="ddlTypeOfWorkFunctionEdit" runat="server" SkinID="DropDownList" DataSourceID="odsWorkFunctionConcat"
                                                                                                                DataTextField="WorkFunctionConcat" DataValueField="WorkFunctionConcat">
                                                                                                            </asp:DropDownList>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:DropDownList Style="width: 80px" ID="ddlJobClassTypeEdit" runat="server" SkinID="DropDownListLookup"
                                                                                                                EnableViewState="True" DataTextField="JobClassType" DataValueField="JobClassType"
                                                                                                                DataSourceID="odsJobClassType">
                                                                                                            </asp:DropDownList>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                        <td colspan="2">
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:CustomValidator ID="cvStarTimeProvideEdit" runat="server" SkinID="Validator" EnableViewState="False" ControlToValidate="ddlStartTimeHourEdit"
                                                                                                                Display="Dynamic" ErrorMessage="Please provide start time." OnServerValidate="cvStartTimeProvideEdit_ServerValidate"
                                                                                                                ValidateEmptyText="True" ValidationGroup="editData"></asp:CustomValidator>
                                                                                                            <asp:CustomValidator ID="cvStartTimeDeleteEdit" runat="server" SkinID="Validator" EnableViewState="False" ControlToValidate="ddlStartTimeHourEdit" Display="Dynamic"
                                                                                                                ErrorMessage="Please delete start time." OnServerValidate="cvStartTimeDeleteEdit_ServerValidate"
                                                                                                                ValidationGroup="editData"></asp:CustomValidator>
                                                                                                            <asp:CustomValidator ID="cvValidStartTimeEdit" runat="server" 
                                                                                                                ControlToValidate="ddlStartTimeHourEdit" Display="Dynamic" 
                                                                                                                EnableViewState="False" 
                                                                                                                ErrorMessage="Please provide a valid Time. (provide Hours : Minutes)" 
                                                                                                                onservervalidate="cvValidStartTimeEdit_ServerValidate" SkinID="Validator" 
                                                                                                                ValidateEmptyText="True" ValidationGroup="editValidData"></asp:CustomValidator>
                                                                                                            <asp:CustomValidator ID="cvValidProjectTimeEdit2" runat="server" SkinID="Validator" EnableViewState="False"
                                                                                                                ControlToValidate="ddlStartTimeHourEdit" Display="Dynamic" ErrorMessage="Project Time must be greater than zero."
                                                                                                                OnServerValidate="cvValidProjectTimeEdit_ServerValidate" ValidationGroup="editData"></asp:CustomValidator>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:CustomValidator ID="cvEndTimeDeleteEdit" runat="server" SkinID="Validator" EnableViewState="False" ControlToValidate="ddlEndTimeHourEdit" Display="Dynamic"
                                                                                                                ErrorMessage="Please delete end time." OnServerValidate="cvEndTimeDeleteEdit_ServerValidate" ValidationGroup="editData"></asp:CustomValidator>
                                                                                                            <asp:CustomValidator ID="cvProvideEndTimeEdit" runat="server" SkinID="Validator" EnableViewState="False" ControlToValidate="ddlEndTimeHourEdit"
                                                                                                                Display="Dynamic" ErrorMessage="Please provide end time." OnServerValidate="cvProvideEndTimeEdit_ServerValidate"
                                                                                                                ValidateEmptyText="True" ValidationGroup="editData"></asp:CustomValidator>
                                                                                                            <asp:CustomValidator ID="cvValidEndTimeEdit" runat="server" 
                                                                                                                ControlToValidate="ddlEndTimeHourEdit" Display="Dynamic" 
                                                                                                                EnableViewState="False" 
                                                                                                                ErrorMessage="Please provide a valid Time. (provide Hours : Minutes)" 
                                                                                                                onservervalidate="cvValidEndTimeEdit_ServerValidate" SkinID="Validator" 
                                                                                                                ValidateEmptyText="True" ValidationGroup="editValidData"></asp:CustomValidator>
                                                                                                            <asp:CustomValidator ID="cvValidProjectTimeEdit" runat="server" SkinID="Validator" EnableViewState="False" ControlToValidate="ddlLunchEdit"
                                                                                                                Display="Dynamic" ErrorMessage="Project Time must be greater than zero." OnServerValidate="cvValidProjectTimeEdit_ServerValidate"
                                                                                                                ValidationGroup="editData"></asp:CustomValidator>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:CompareValidator ID="cvLunchTypeEdit" runat="server" SkinID="Validator" EnableViewState="True" ControlToValidate="ddlLunchEdit" Display="Dynamic" ErrorMessage="Invalid format. (use X.XX)"
                                                                                                                ValidationGroup="editData" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                                                                                                            <asp:CustomValidator ID="cvLunchDeleteEdit" runat="server" SkinID="Validator" EnableViewState="False" ControlToValidate="ddlLunchEdit" Display="Dynamic" ErrorMessage="Please delete lunch."
                                                                                                                OnServerValidate="cvLunchDeleteEdit_ServerValidate" ValidationGroup="editData"></asp:CustomValidator></td>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="rfvTypeOfWorkFunctionEdit" runat="server" SkinID="Validator" EnableViewState="False" ControlToValidate="ddlTypeOfWorkFunctionEdit"
                                                                                                                Display="Dynamic" ErrorMessage="Please select a type of work - function." ValidationGroup="editData"
                                                                                                                InitialValue="(Select)"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:CustomValidator ID="cvJobClassTypeEdit" runat="server" ControlToValidate="ddlJobClassTypeEdit"
                                                                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Please select a job class."
                                                                                                                OnServerValidate="cvJobClassTypeEdit_ServerValidate" SkinID="Validator" ValidationGroup="editData">
                                                                                                            </asp:CustomValidator>
                                                                                                            <asp:CustomValidator ID="cvJobClassEmptyEdit" runat="server" 
                                                                                                                ControlToValidate="ddlJobClassTypeEdit" Display="Dynamic" 
                                                                                                                EnableViewState="False" 
                                                                                                                ErrorMessage="Please define a valid job class on Team Members module." 
                                                                                                                OnServerValidate="cvJobClassEmptyEdit_ServerValidate" SkinID="Validator" 
                                                                                                                ValidateEmptyText="True" ValidationGroup="editData"></asp:CustomValidator>
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
                                                                                                            <asp:Label ID="lblUnitEdit" runat="server" SkinID="Label" Text="Unit"></asp:Label>
                                                                                                        </td> 
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblTowedEdit" runat="server" SkinID="Label" Text="Towed"></asp:Label>
                                                                                                        </td>
                                                                                                        <%--<td>
                                                                                                            <asp:Label ID="lblMealsAllowanceEdit" runat="server" SkinID="LabelSmall" Text="Meals Allowance"></asp:Label>
                                                                                                        </td>--%>
                                                                                                        <td colspan="5">
                                                                                                            <asp:Label ID="lblCommentsEdit" runat="server" SkinID="Label" Text="Comments"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:DropDownList Style="width: 80px" ID="ddlUnitEdit" runat="server" SkinID="DropDownListLookup"
                                                                                                                EnableViewState="True" DataSourceID="odsUnit" DataTextField="UnitCode" DataValueField="UnitID">
                                                                                                            </asp:DropDownList></td>
                                                                                                        <td>
                                                                                                            <asp:DropDownList Style="width: 80px" ID="ddlTowedEdit" runat="server" SkinID="DropDownListLookup"
                                                                                                                EnableViewState="True" DataSourceID="odsTowed" DataTextField="UnitCode" DataValueField="UnitID">
                                                                                                            </asp:DropDownList></td>
                                                                                                        <%--<td>
                                                                                                            <asp:CheckBox ID="ckbxMealsAllowanceEdit" runat="server" SkinID="CheckBox"
                                                                                                                Checked='<%# Eval("MealsAllowance") %>'></asp:CheckBox>
                                                                                                          </td>--%>
                                                                                                        <td colspan="5">
                                                                                                            <asp:TextBox ID="tbxCommentsEdit" runat="server" SkinID="TextBoxMemo" Text='<%# Eval("Comments") %>'
                                                                                                                Width="515px" ></asp:TextBox></td>
                                                                                                    </tr>
                                                                                                    <%--<tr>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:CustomValidator ID="cvValidMealsCountryEdit" runat="server" SkinID="Validator"
                                                                                                                EnableViewState="False" Display="Dynamic" ErrorMessage="You checked a meals allowance but not selected a meals country; please select a meals country."
                                                                                                                OnServerValidate="cvValidMealsCountryEdit_ServerValidate" ValidationGroup="editData"></asp:CustomValidator>
                                                                                                            <asp:CustomValidator ID="cvAlreadyRegisteredMealsAllowanceEdit" runat="server" SkinID="Validator"
                                                                                                                EnableViewState="False" Display="Dynamic" ErrorMessage="You already registered meals allowance on this day."
                                                                                                                OnServerValidate="cvAlreadyRegisteredMealsAllowanceEdit_ServerValidate" ValidationGroup="editData"></asp:CustomValidator>
                                                                                                            <asp:CustomValidator ID="cvDuplicateMealsAllowanceEdit" runat="server" SkinID="Validator" EnableViewState="False" Display="Dynamic" ErrorMessage="Duplicated meals allowance."
                                                                                                                OnServerValidate="cvDuplicateMealsAllowanceEdit_ServerValidate" ValidationGroup="editData"></asp:CustomValidator></td>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                    </tr>--%>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            &nbsp;</td>
                                                                                                        <td colspan="5">
                                                                                                            <asp:CustomValidator ID="cvValidTimesEdit" runat="server" Display="Dynamic" 
                                                                                                                EnableViewState="False" 
                                                                                                                ErrorMessage="This start time or end time is overlapping an existent project time, please review you data." 
                                                                                                                OnServerValidate="cvValidTimesEdit_ServerValidate" SkinID="Validator" 
                                                                                                                ValidationGroup="editData"></asp:CustomValidator>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            &nbsp;</td>
                                                                                                        <td>
                                                                                                            &nbsp;</td>
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
                                                                                                        <td>
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
                                                                                            <!-- Page element : 9 columns - New Data -->
                                                                                            <table style="width: 850px" cellspacing="0" cellpadding="0" border="0">
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td style="width: 10px; height: 7px">
                                                                                                        </td>
                                                                                                        <td style="width: 90px;">
                                                                                                        </td>
                                                                                                        <td style="width: 90px">
                                                                                                        </td>
                                                                                                        <td style="width: 135px">
                                                                                                        </td>
                                                                                                        <td style="width: 135px">
                                                                                                        </td>
                                                                                                        <td style="width: 90px">
                                                                                                        </td>
                                                                                                        <td style="width: 210px">
                                                                                                        </td>
                                                                                                        <td style="width: 90px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                        <td colspan="2">
                                                                                                            <asp:Label ID="lblAvailableTeamMemberFooter" runat="server" SkinID="Label" Text="Available Team Member"></asp:Label></td>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblStartTimeFooter" runat="server" SkinID="Label" Text="Start Time"></asp:Label></td>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblEndTimeFooter" runat="server" SkinID="Label" Text="End Time"></asp:Label></td>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblLunchFooter" runat="server" SkinID="Label" Text="Lunch"></asp:Label></td>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblTypeOfWorkFunctionFooter" runat="server" SkinID="Label" Text="Type of Work - Function"></asp:Label></td>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblJobClassTypeFooter" runat="server" SkinID="Label" Text="Job Class"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                        <td colspan="2">
                                                                                                            <asp:UpdatePanel ID="upnlEmployeeFooter" runat="server" UpdateMode="Conditional">
                                            <contenttemplate>
                                                                                                            <asp:DropDownList Style="width: 170px" ID="ddlEmployeesFooter" AutoPostBack="true" runat="server" SkinID="DropDownList" DataSourceID="odsEmployeeAvailable" DataTextField="FullName"
                                                                                                                DataValueField="EmployeeID" OnSelectedIndexChanged="ddlEmployeesFooter_SelectedIndexChanged">
                                                                                                            </asp:DropDownList>
                                                                                                            </contenttemplate>
                                        </asp:UpdatePanel>    
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:UpdatePanel id="upStartTimeFooter" runat="server" UpdateMode="Conditional">
                                                                                                                <contenttemplate>
                                                                                                                    <asp:DropDownList ID="ddlStartTimeHourFooter" runat="server" AutoPostBack="true"  SkinID="DropDownList" 
                                                                                                                    Style="width: 50px">
                                                                                                                        <asp:ListItem Value=" " Selected="True" ></asp:ListItem>
                                                                                                                        <asp:ListItem Value="0">0</asp:ListItem>
                                                                                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                                                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                                                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                                                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                                                                                        <asp:ListItem Value="5">5</asp:ListItem>
                                                                                                                        <asp:ListItem Value="6">6</asp:ListItem>
                                                                                                                        <asp:ListItem Value="7">7</asp:ListItem>
                                                                                                                        <asp:ListItem Value="8">8</asp:ListItem>
                                                                                                                        <asp:ListItem Value="9">9</asp:ListItem>
                                                                                                                        <asp:ListItem Value="10">10</asp:ListItem>
                                                                                                                        <asp:ListItem Value="11">11</asp:ListItem>
                                                                                                                        <asp:ListItem Value="12">12</asp:ListItem>
                                                                                                                        <asp:ListItem Value="13">13</asp:ListItem>
                                                                                                                        <asp:ListItem Value="14">14</asp:ListItem>
                                                                                                                        <asp:ListItem Value="15">15</asp:ListItem>
                                                                                                                        <asp:ListItem Value="16">16</asp:ListItem>
                                                                                                                        <asp:ListItem Value="17">17</asp:ListItem>
                                                                                                                        <asp:ListItem Value="18">18</asp:ListItem>
                                                                                                                        <asp:ListItem Value="19">19</asp:ListItem>
                                                                                                                        <asp:ListItem Value="20">20</asp:ListItem>
                                                                                                                        <asp:ListItem Value="21">21</asp:ListItem>
                                                                                                                        <asp:ListItem Value="22">22</asp:ListItem>
                                                                                                                        <asp:ListItem Value="23">23</asp:ListItem>
                                                                                                                    </asp:DropDownList>
                                                                                                                    <asp:Label ID="lblStartTimeDotsFooter" runat="server" EnableViewState="False" 
                                                                                                                        SkinID="Label" Text=":"></asp:Label>
                                                                                                                    <asp:DropDownList ID="ddlStartTimeMinuteFooter" runat="server"   SkinID="DropDownList" Style="width: 50px">
                                                                                                                        <asp:ListItem Value=" "></asp:ListItem>
                                                                                                                        <asp:ListItem Value="00" Selected="True">00</asp:ListItem>
                                                                                                                        <asp:ListItem Value="15">15</asp:ListItem>
                                                                                                                        <asp:ListItem Value="30">30</asp:ListItem>
                                                                                                                        <asp:ListItem Value="45">45</asp:ListItem>                                                                
                                                                                                                    </asp:DropDownList>                
                                                                                                                </contenttemplate>           
                                                                                                            </asp:UpdatePanel> 
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:UpdatePanel id="upEndTimeFooter" runat="server" UpdateMode="Conditional">
                                                                                                                <contenttemplate>
                                                                                                                    <asp:DropDownList ID="ddlEndTimeHourFooter" runat="server" AutoPostBack="true"  SkinID="DropDownList" 
                                                                                                                    Style="width: 50px" >
                                                                                                                        <asp:ListItem Value=" " Selected="True" ></asp:ListItem>
                                                                                                                        <asp:ListItem Value="0">0</asp:ListItem>
                                                                                                                        <asp:ListItem Value="1">1</asp:ListItem>
                                                                                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                                                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                                                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                                                                                        <asp:ListItem Value="5">5</asp:ListItem>
                                                                                                                        <asp:ListItem Value="6">6</asp:ListItem>
                                                                                                                        <asp:ListItem Value="7">7</asp:ListItem>
                                                                                                                        <asp:ListItem Value="8">8</asp:ListItem>
                                                                                                                        <asp:ListItem Value="9">9</asp:ListItem>
                                                                                                                        <asp:ListItem Value="10">10</asp:ListItem>
                                                                                                                        <asp:ListItem Value="11">11</asp:ListItem>
                                                                                                                        <asp:ListItem Value="12">12</asp:ListItem>
                                                                                                                        <asp:ListItem Value="13">13</asp:ListItem>
                                                                                                                        <asp:ListItem Value="14">14</asp:ListItem>
                                                                                                                        <asp:ListItem Value="15">15</asp:ListItem>
                                                                                                                        <asp:ListItem Value="16">16</asp:ListItem>
                                                                                                                        <asp:ListItem Value="17">17</asp:ListItem>
                                                                                                                        <asp:ListItem Value="18">18</asp:ListItem>
                                                                                                                        <asp:ListItem Value="19">19</asp:ListItem>
                                                                                                                        <asp:ListItem Value="20">20</asp:ListItem>
                                                                                                                        <asp:ListItem Value="21">21</asp:ListItem>
                                                                                                                        <asp:ListItem Value="22">22</asp:ListItem>
                                                                                                                        <asp:ListItem Value="23">23</asp:ListItem>
                                                                                                                    </asp:DropDownList>
                                                                                                                    <asp:Label ID="lblEndTimeDotsFooter" runat="server" EnableViewState="False" 
                                                                                                                        SkinID="Label" Text=":"></asp:Label>
                                                                                                                    <asp:DropDownList ID="ddlEndTimeMinuteFooter" runat="server"   SkinID="DropDownList" Style="width: 50px">
                                                                                                                        <asp:ListItem Value=" "></asp:ListItem>
                                                                                                                        <asp:ListItem Value="00" Selected="True">00</asp:ListItem>
                                                                                                                        <asp:ListItem Value="15">15</asp:ListItem>
                                                                                                                        <asp:ListItem Value="30">30</asp:ListItem>
                                                                                                                        <asp:ListItem Value="45">45</asp:ListItem>                                                                
                                                                                                                    </asp:DropDownList>              
                                                                                                                </contenttemplate>           
                                                                                                            </asp:UpdatePanel> 
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:DropDownList ID="ddlLunchFooter" runat="server" SkinID="DropDownList" Style="width: 80px">
                                                                                                                <asp:ListItem Value="0">0.00</asp:ListItem>
                                                                                                                <asp:ListItem Value="0.25">0.25</asp:ListItem>
                                                                                                                <asp:ListItem Value="0.50">0.50</asp:ListItem>
                                                                                                                <asp:ListItem Value="0.75">0.75</asp:ListItem>
                                                                                                                <asp:ListItem Value="1.00">1.00</asp:ListItem>
                                                                                                                <asp:ListItem Value="1.25">1.25</asp:ListItem>
                                                                                                                <asp:ListItem Value="1.50">1.50</asp:ListItem>
                                                                                                                <asp:ListItem Value="1.75">1.75</asp:ListItem>
                                                                                                                <asp:ListItem Value="1.75">1.75</asp:ListItem>
                                                                                                                <asp:ListItem Value="2.00">2.00</asp:ListItem>
                                                                                                            </asp:DropDownList>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:DropDownList Style="width: 200px" ID="ddlTypeOfWorkFooter" runat="server" SkinID="DropDownList" DataSourceID="odsWorkFunctionConcat" DataTextField="WorkFunctionConcat"
                                                                                                                DataValueField="WorkFunctionConcat">
                                                                                                            </asp:DropDownList></td>
                                                                                                        <td>
                                                                                                            <asp:DropDownList Style="width: 80px" ID="ddlJobClassTypeFooter" runat="server"
                                                                                                                SkinID="DropDownListLookup" EnableViewState="True" DataTextField="JobClassType"
                                                                                                                DataValueField="JobClassType" DataSourceID="odsJobClassType">
                                                                                                            </asp:DropDownList>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                        <td colspan="2">
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:CustomValidator ID="cvStarTimeProvideFooter" runat="server" SkinID="Validator"
                                                                                                                EnableViewState="False" ControlToValidate="ddlStartTimeHourFooter"
                                                                                                                Display="Dynamic" ErrorMessage="Please provide start time." OnServerValidate="cvStartTimeProvideFooter_ServerValidate"
                                                                                                                ValidateEmptyText="True" ValidationGroup="footerData"></asp:CustomValidator>
                                                                                                            <asp:CustomValidator ID="cvStartTimeDeleteFooter" runat="server" SkinID="Validator"
                                                                                                                EnableViewState="False" ControlToValidate="ddlStartTimeHourFooter"
                                                                                                                Display="Dynamic" ErrorMessage="Please delete start time." OnServerValidate="cvStartTimeDeleteFooter_ServerValidate"
                                                                                                                ValidationGroup="footerData"></asp:CustomValidator>
                                                                                                            <asp:CustomValidator ID="cvValidStartTimeFooter" runat="server" 
                                                                                                                ControlToValidate="ddlStartTimeHourFooter" Display="Dynamic" 
                                                                                                                EnableViewState="False" 
                                                                                                                ErrorMessage="Please provide a valid Time. (provide Hours : Minutes)" 
                                                                                                                onservervalidate="cvValidStartTimeFooter_ServerValidate" SkinID="Validator" 
                                                                                                                ValidateEmptyText="True" ValidationGroup="footerValidData"></asp:CustomValidator>
                                                                                                            <asp:CustomValidator ID="cvValidProjectTimeFooter2" runat="server" SkinID="Validator"
                                                                                                                EnableViewState="False" ControlToValidate="ddlStartTimeHourFooter"
                                                                                                                Display="Dynamic" ErrorMessage="Project Time must be greater than zero." OnServerValidate="cvValidProjectTimeFooter_ServerValidate"
                                                                                                                ValidationGroup="footerData"></asp:CustomValidator></td>
                                                                                                        <td>
                                                                                                            <asp:CustomValidator ID="cvEndTimeDeleteFooter" runat="server" SkinID="Validator"
                                                                                                                EnableViewState="False" ControlToValidate="ddlEndTimeHourFooter"
                                                                                                                Display="Dynamic" ErrorMessage="Please delete end time." OnServerValidate="cvEndTimeDeleteFooter_ServerValidate"
                                                                                                                ValidationGroup="footerData"></asp:CustomValidator>
                                                                                                            <asp:CustomValidator ID="cvProvideEndTime" runat="server" SkinID="Validator" EnableViewState="False" ControlToValidate="ddlEndTimeHourFooter" Display="Dynamic"
                                                                                                                ErrorMessage="Please provide end time." OnServerValidate="cvProvideEndTimeFooter_ServerValidate"
                                                                                                                ValidateEmptyText="True" ValidationGroup="footerData"></asp:CustomValidator>
                                                                                                            <asp:CustomValidator ID="cvValidEndTimeFooter" runat="server" 
                                                                                                                ControlToValidate="ddlEndTimeHourFooter" Display="Dynamic" 
                                                                                                                EnableViewState="False" 
                                                                                                                ErrorMessage="Please provide a valid Time. (provide Hours : Minutes)" 
                                                                                                                onservervalidate="cvValidEndTimeFooter_ServerValidate" SkinID="Validator" 
                                                                                                                ValidateEmptyText="True" ValidationGroup="footerValidData"></asp:CustomValidator>
                                                                                                            <asp:CustomValidator ID="cvValidProjectTimeFooter1" runat="server" SkinID="Validator" EnableViewState="False" ControlToValidate="ddlEndTimeHourFooter"
                                                                                                                Display="Dynamic" ErrorMessage="Project Time must be greater than zero." OnServerValidate="cvValidProjectTimeFooter_ServerValidate"
                                                                                                                ValidationGroup="footerData"></asp:CustomValidator></td>
                                                                                                        <td>
                                                                                                            <asp:CompareValidator ID="cvLunchTypeFooter" runat="server" SkinID="Validator" EnableViewState="True" ControlToValidate="ddlLunchFooter" Display="Dynamic"
                                                                                                                ErrorMessage="Invalid format. (use X.XX)" ValidationGroup="footerData" Operator="DataTypeCheck"
                                                                                                                Type="Double"></asp:CompareValidator>
                                                                                                            <asp:CustomValidator ID="cvLunchDeleteFooter" runat="server" SkinID="Validator" EnableViewState="False" ControlToValidate="ddlLunchFooter" Display="Dynamic"
                                                                                                                ErrorMessage="Please delete lunch." OnServerValidate="cvLunchDeleteFooter_ServerValidate"
                                                                                                                ValidationGroup="footerData"></asp:CustomValidator>
                                                                                                            <asp:CustomValidator ID="cvValidProjectTimeFooter" runat="server" SkinID="Validator" EnableViewState="False" ControlToValidate="ddlLunchFooter"
                                                                                                                Display="Dynamic" ErrorMessage="Project Time must be greater than zero." OnServerValidate="cvValidProjectTimeFooter_ServerValidate"
                                                                                                                ValidationGroup="footerData"></asp:CustomValidator></td>
                                                                                                        <td>
                                                                                                            <asp:RequiredFieldValidator ID="rfvTypeOfWorkFunctionFooter" runat="server" SkinID="Validator"
                                                                                                                EnableViewState="False" ControlToValidate="ddlTypeOfWorkFooter"
                                                                                                                Display="Dynamic" ErrorMessage="Please select a type of work - function." ValidationGroup="footerData"
                                                                                                                InitialValue="(Select)"></asp:RequiredFieldValidator>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:CustomValidator ID="cvJobClassTypeFooter" runat="server" ControlToValidate="ddlJobClassTypeFooter"
                                                                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Please select a job class."
                                                                                                                OnServerValidate="cvJobClassTypeFooter_ServerValidate" SkinID="Validator" ValidationGroup="footerData">
                                                                                                            </asp:CustomValidator>
                                                                                                            <asp:CustomValidator ID="cvJobClassEmptyFooter" runat="server" 
                                                                                                                ControlToValidate="ddlJobClassTypeFooter" Display="Dynamic" 
                                                                                                                EnableViewState="False" 
                                                                                                                ErrorMessage="Please define a valid job class on Team Members module." 
                                                                                                                OnServerValidate="cvJobClassEmptyFooter_ServerValidate" SkinID="Validator" 
                                                                                                                ValidateEmptyText="True" ValidationGroup="footerData"></asp:CustomValidator>
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
                                                                                                            <asp:Label ID="lblUnitFooter" runat="server" SkinID="Label" Text="Unit"></asp:Label></td>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblTowedFooter" runat="server" SkinID="Label" Text="Towed"></asp:Label></td>
                                                                                                        <td>
                                                                                                            <%--<asp:Label ID="lblMealsAllowanceFooter" runat="server" SkinID="LabelSmall" Text="Meals Allowance"></asp:Label>--%>
                                                                                                        </td>
                                                                                                        <td colspan="5">
                                                                                                            <asp:Label ID="lblNewComments" runat="server" SkinID="Label" Text="Comments"></asp:Label></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:DropDownList Style="width: 80px" ID="ddlUnitFooter" runat="server" SkinID="DropDownList" DataSourceID="odsUnit" DataTextField="UnitCode" DataValueField="UnitID">
                                                                                                            </asp:DropDownList></td>
                                                                                                        <td>
                                                                                                            <asp:DropDownList Style="width: 80px" ID="ddlTowedFooter" runat="server" SkinID="DropDownList" DataSourceID="odsTowed" DataTextField="UnitCode" DataValueField="UnitID">
                                                                                                            </asp:DropDownList></td>
                                                                                                        <td>
                                                                                                            <%--<asp:CheckBox ID="ckbxMealsAllowanceFooter" runat="server" SkinID="CheckBox">
                                                                                                            </asp:CheckBox>--%>
                                                                                                        </td>
                                                                                                        <td colspan="5">
                                                                                                            <asp:TextBox ID="tbxCommentsFooter" runat="server" SkinID="TextBoxMemo" Text='<%# Eval("Comments") %>'
                                                                                                                Width="515px" Rows="1"></asp:TextBox></td>
                                                                                                    </tr>
                                                                                                    <%--<tr>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:CustomValidator ID="cvValidMealsCountryFooter" runat="server" SkinID="Validator"
                                                                                                                EnableViewState="False" Display="Dynamic" ErrorMessage="You checked a meals allowance but not selected a meals country; please select a meals country."
                                                                                                                OnServerValidate="cvValidMealsCountryFooter_ServerValidate" ValidationGroup="footerData"></asp:CustomValidator>
                                                                                                            <asp:CustomValidator ID="cvAlreadyRegisteredMealsAllowanceFooter" runat="server" SkinID="Validator" EnableViewState="False" Display="Dynamic"
                                                                                                                ErrorMessage="You already registered meals allowance on this day." OnServerValidate="cvAlreadyRegisteredMealsAllowanceFooter_ServerValidate"
                                                                                                                ValidationGroup="footerData"></asp:CustomValidator>
                                                                                                            <asp:CustomValidator ID="cvDuplicateMealsAllowanceFooter" runat="server" SkinID="Validator" EnableViewState="False" Display="Dynamic" ErrorMessage="Duplicated meals allowance."
                                                                                                                OnServerValidate="cvDuplicateMealsAllowanceFooter_ServerValidate" ValidationGroup="footerData"></asp:CustomValidator></td>
                                                                                                        <td colspan="4">
                                                                                                        </td>
                                                                                                    </tr>--%>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            &nbsp;</td>
                                                                                                        <td colspan="7">
                                                                                                            <asp:CustomValidator ID="cvValidTimesFooter" runat="server" Display="Dynamic" 
                                                                                                                EnableViewState="False" 
                                                                                                                ErrorMessage="This start time or end time is overlapping an existent project time, please review you data." 
                                                                                                                OnServerValidate="cvValidTimesFooter_ServerValidate" SkinID="Validator" 
                                                                                                                ValidationGroup="footerData"></asp:CustomValidator>
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
                                                                                                        <td>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </tbody>
                                                                                            </table>
                                                                                        </FooterTemplate>
                                                                                        
                                                                                        <HeaderStyle Width="850px"></HeaderStyle>
                                                                                        
                                                                                        <ItemTemplate>
                                                                                            <table style="width: 850px" cellspacing="0" cellpadding="0" border="0">
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td style="width: 10px; height: 7px">
                                                                                                        </td>
                                                                                                        <td style="width: 90px;">
                                                                                                        </td>
                                                                                                        <td style="width: 90px">
                                                                                                        </td>
                                                                                                        <td style="width: 135px">
                                                                                                        </td>
                                                                                                        <td style="width: 135px">
                                                                                                        </td>
                                                                                                        <td style="width: 90px">
                                                                                                        </td>
                                                                                                        <td style="width: 210px">
                                                                                                        </td>
                                                                                                        <td style="width: 90px">
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td >
                                                                                                        </td>
                                                                                                        <td colspan="2">
                                                                                                            <asp:Label ID="lblTeamMember" runat="server" SkinID="Label" Text="Team Member"></asp:Label></td>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblStartTime" runat="server" SkinID="Label" Text="Start Time"></asp:Label></td>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblEndTime" runat="server" SkinID="Label" Text="End Time"></asp:Label></td>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblLunch" runat="server" SkinID="Label" Text="Lunch"></asp:Label></td>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblTypeOfWorkFunction" runat="server" SkinID="Label" Text="Type of Work - Function"></asp:Label></td>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblJobClassType" runat="server" SkinID="Label" Text="Job Class"></asp:Label>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                        <td colspan="2">
                                                                                                            <asp:TextBox ID="tbxTeamMember" runat="server" SkinID="TextBoxReadOnly" Text='<%# GetEmployeeName(Eval("EmployeeID")) %>'
                                                                                                                Width="170px" ReadOnly="True"></asp:TextBox>
                                                                                                            <asp:HiddenField ID="hdfEmployeeId" Value='<%# Eval("EmployeeID") %>' runat="server" />  
                                                                                                                </td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="tbxStartTime" runat="server" SkinID="TextBoxReadOnly" Text='<%# Bind("StartTime", "{0:H:mm}") %>'
                                                                                                                Width="125px" ReadOnly="True"></asp:TextBox></td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="tbxEndTime" runat="server" SkinID="TextBoxReadOnly" Text='<%# Bind("EndTime", "{0:H:mm}") %>'
                                                                                                                Width="125px" ReadOnly="True"></asp:TextBox></td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="tbxLunch" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("Offset", "{0:n2}") %>'
                                                                                                                Width="80px" ReadOnly="True"></asp:TextBox></td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="tbxTypeOfWorkFunction" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("WorkFunctionConcat") %>'
                                                                                                                Width="200px" ReadOnly="True"></asp:TextBox></td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="tbxJobClassType" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly"
                                                                                                                Text='<%# Eval("JobClassType") %>' Width="80px"></asp:TextBox>
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
                                                                                                            <asp:Label ID="lblUnit" runat="server" SkinID="Label" Text="Unit"></asp:Label></td>
                                                                                                        <td>
                                                                                                            <asp:Label ID="lblTowed" runat="server" SkinID="Label" Text="Towed"></asp:Label></td>
                                                                                                        <%--<td>
                                                                                                            <asp:Label ID="lblMealsAllowance" runat="server" SkinID="LabelSmall" Text="Meals Allowance"></asp:Label>
                                                                                                        </td>--%>
                                                                                                        <td colspan="5">
                                                                                                            <asp:Label ID="lblComments" runat="server" SkinID="Label" Text="Comments"></asp:Label></td>
                                                                                                    </tr>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                        </td>
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="tbxUnit" runat="server" SkinID="TextBoxReadOnly" Text='<%# GetUnitCode(Eval("UnitID")) %>'
                                                                                                                Width="80px" ReadOnly="True"></asp:TextBox></td> 
                                                                                                        <td>
                                                                                                            <asp:TextBox ID="tbxTowed" runat="server" SkinID="TextBoxReadOnly" Text='<%# GetUnitCode(Eval("TowedUnitID")) %>'
                                                                                                                Width="80px" ReadOnly="True"></asp:TextBox></td>
                                                                                                        <%--<td>
                                                                                                            <asp:CheckBox ID="ckbxMealsAllowance" onclick="return cbxClick();" runat="server"
                                                                                                                SkinID="CheckBox" Checked='<%# Eval("MealsAllowance") %>'>
                                                                                                            </asp:CheckBox>
                                                                                                        </td>--%>
                                                                                                        <td colspan="5">
                                                                                                            <asp:TextBox ID="tbxComments" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("Comments") %>'
                                                                                                                Width="515px" ReadOnly="True" ></asp:TextBox></td>
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
                                                                                                        <td>
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
                                                                                                            <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" CommandName="Update">
                                                                                                            </asp:ImageButton>
                                                                                                        </td>
                                                                                                        <td style="width: 50%">
                                                                                                            <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" CommandName="Cancel">
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
                                                                                                            <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" CommandName="Add">
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
                                                                                        <HeaderStyle Width="50px"></HeaderStyle>
                                                                                        <ItemTemplate>
                                                                                            <table style="width: 100%" cellspacing="0" cellpadding="0" border="0">
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td style="width: 50%">
                                                                                                            <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" CommandName="Edit">
                                                                                                            </asp:ImageButton>
                                                                                                        </td>
                                                                                                        <td style="width: 50%">
                                                                                                            <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" CommandName="Delete"
                                                                                                                OnClientClick='return confirm("Are you sure you want to delete this project time?");'>
                                                                                                            </asp:ImageButton>
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
                                                                </asp:Panel>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="height: 30px">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:WizardStep>
                                                
                                                
                                                
                                                <asp:WizardStep ID="StepEnd" runat="server" Title="End">
                                                    <!-- Page element: 1 column global validator-->
                                                    <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
                                                        <tr>
                                                            <td style="width: 150px">
                                                                <asp:CustomValidator ID="cvEnd" runat="server" Display="Dynamic" ErrorMessage="Please select one or more options."
                                                                    OnServerValidate="cvEnd_ServerValidate" SkinID="Validator" EnableViewState="False"></asp:CustomValidator>
                                                            </td>
                                                        </tr>                                
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="cbxEndConfirm" runat="server" SkinID="CheckBox" Text="Confirm my work (add timesheet entries to the team members I selected before)" />
                                                            </td>
                                                        </tr>                               
                                                        <tr>
                                                            <td style="height: 7px">
                                                            </td>
                                                        </tr>                                
                                                        <tr>
                                                            <td>
                                                                <asp:CheckBox ID="cbxEndSave" runat="server" SkinID="CheckBox" Text="Save my work as a template" />
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
                                                                <asp:RadioButton ID="rbtnEndSaveNew" runat="server" Checked="True" GroupName="End"
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
                                                                <asp:RadioButton ID="rbtnEndSaveReplace" runat="server" GroupName="End" SkinID="RadioButton"
                                                                    Text="Replace template :" />
                                                            </td>
                                                            <td>
                                                                <asp:DropDownList ID="luEndSaveTemplate" runat="server"  SkinID="DropDownList"
                                                                 EnableViewState="false" Width="150px" DataSourceID="odsTemplate" DataTextField="TemplateName" 
                                                                 DataValueField="TeamProjectTimeID">
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
                                                            </td>
                                                        </tr>
                                                    </table>
                                                    
                                                    <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">                                
                                                        <tr>
                                                            <td style="height: 7px">
                                                            </td>
                                                        </tr> 
                                                        <tr>
                                                            <td colspan="3">
                                                                <asp:Label ID="lblError" runat="server" SkinID="LabelError" Text="This start time or end time is overlapping an existent project time, please review you data for: "></asp:Label> 
                                                                <asp:Label ID="lblError2" runat="server" SkinID="LabelError" Text="Please define a valid job class on Team Members module for: "></asp:Label> 
                                                            </td>   
                                                        </tr>
                                                     </table>                                    
                                             
                                                </asp:WizardStep>
                                            </WizardSteps>
                                        </asp:Wizard>                            
                                    </td>
                                    <td style="vertical-align: bottom; width: 30px">
                                            <asp:UpdateProgress ID="upTeam" runat="server" AssociatedUpdatePanelID="upnlTeam">
                                                <ProgressTemplate>
                                                    <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                                </ProgressTemplate>
                                            </asp:UpdateProgress>
                                        </td>
                                </tr>
                                <tr>
                <td>
                    <asp:HiddenField ID="hdfTeamProjectTimeID" runat="server" />
                    <asp:HiddenField ID="hdfDetailID" runat="server" />
                    <asp:HiddenField ID="hdfCompaniesID" runat="server" />
                    <asp:HiddenField ID="hdfProjectID" runat="server" />
                    <asp:HiddenField ID="hdfStartTime" runat="server" />
                    <asp:HiddenField ID="hdfEndTime" runat="server" />
                    <asp:HiddenField ID="hdfOffset" runat="server" />
                    <asp:HiddenField ID="hdfWorkingDetails" runat="server" />
                    <asp:HiddenField ID="hdfLocation" runat="server" />
                    <asp:HiddenField ID="hdfMealsCountry" runat="server" />
                    <asp:HiddenField ID="hdfMealsAllowance" runat="server" />
                    <asp:HiddenField ID="hdfIsMealsAllowance" runat="server" />                    
                    <asp:HiddenField ID="hdfProjectTimeState" runat="server" />
                    <asp:HiddenField ID="hdfClearUnitAssigment" runat="server" />
                    <asp:HiddenField ID="hdfDate" runat="server" />
                    <asp:HiddenField ID="hdfWork_" runat="server" />
                    <asp:HiddenField ID="hdfFunction_" runat="server" />
                    <asp:HiddenField ID="hdfWorkFunctionConcat" runat="server" />
                    <asp:HiddenField ID="hdfFairWage" runat="server" />
                    <asp:HiddenField ID="hdfSelectedIdTemplate" runat="server" />
                    <asp:HiddenField ID="hdfNewOrTemplate" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfBtnNext" runat="server" />                   
                </td>
            </tr>
                            </table>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="wzTeam" EventName="ActiveStepChanged">
                            </asp:AsyncPostBackTrigger>
                        </Triggers>
                    </asp:UpdatePanel>    
                </td>
            </tr>
            
        </table>
        
        <!-- Page element: DataObjects -->
        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%;">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsTeamProjectTimeDetail" runat="server" SelectMethod="GetTeamProjectTimeDetail"
                        TypeName="LiquiForce.LFSLive.WebUI.LabourHours.TeamProjectTime.timesheet_team"
                        DeleteMethod="DummyTeamProjectTimeDetailNew" FilterExpression="(Deleted = 0)"
                        UpdateMethod="DummyTeamProjectTimeDetailNew" InsertMethod="DummyTeamProjectTimeDetailNew"
                        OldValuesParameterFormatString="original_{0}">
                        <DeleteParameters>
                            <asp:Parameter Name="TeamProjectTimeID" Type="Int32" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="TeamProjectTimeID" Type="Int32" />
                        </UpdateParameters>
                        <InsertParameters>
                            <asp:Parameter Name="TeamProjectTimeID" Type="Int32" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsClient" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Companies.CompaniesList" CacheDuration="120" EnableCaching="True">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="companiesId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select a client)" Name="name" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsProject" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Projects.Projects.ProjectList" EnableCaching="True">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="projectId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select a project)" Name="name" Type="String" />
                            <asp:Parameter DefaultValue="-1" Name="clientId" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsActiveProjectsActiveInternalProjectsActiveBallparkProjects"
                        runat="server" SelectMethod="LoadActiveProjectsActiveInternalProjectsActiveBallparkProjectsAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Projects.Projects.ProjectList" EnableCaching="True">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="projectId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select a project)" Name="name" Type="String" />
                            <asp:Parameter DefaultValue="-1" Name="clientId" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsProjectsInternalProjectsBallparkProjects" runat="server"
                        SelectMethod="LoadProjectsInternalProjectsBallparkProjectsAndAddItem" TypeName="LiquiForce.LFSLive.BL.Projects.Projects.ProjectList">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="projectId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select a project)" Name="name" Type="String" />
                            <asp:Parameter DefaultValue="-1" Name="clientId" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsWorkingDetails" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.LabourHours.ProjectTime.WorkingDetails" OldValuesParameterFormatString="original_{0}"
                        EnableCaching="True">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select)" Name="workingDetails" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsTimeInterval" runat="server" SelectMethod="GetTimeInterval"
                        TypeName="LiquiForce.LFSLive.Tools.Time" EnableCaching="True">
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsMealsCountry" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Company.Organization.CountryList" EnableCaching="True">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="countryId" Type="Int32" />
                            <asp:Parameter DefaultValue=" " Name="name" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsTowed" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.FleetManagement.Units.UnitsList" CacheDuration="60"
                        EnableCaching="True">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="unitId" Type="String" />
                            <asp:Parameter DefaultValue=" " Name="unitCode" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="true" Name="isWithUnitCode" Type="Boolean" />
                            <asp:Parameter DefaultValue="1" Name="isTowable" Type="Int32" />
                        </SelectParameters>
                        
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="LoadAndAddItem" TypeName="LiquiForce.LFSLive.BL.FleetManagement.Units.UnitsList"
                        CacheDuration="60" EnableCaching="True">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="unitId" Type="String" />
                            <asp:Parameter DefaultValue=" " Name="unitCode" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="true" Name="isWithUnitCode" Type="Boolean" />
                            <asp:Parameter DefaultValue="0" Name="isTowable" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsEmployee" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Employees.EmployeeList" OldValuesParameterFormatString="original_{0}"
                        CacheDuration="60" EnableCaching="True">
                        <SelectParameters>
                            <asp:Parameter Name="employeeId" Type="Int32" />
                            <asp:Parameter Name="fullName" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsEmployeeAvailable" runat="server" SelectMethod="LoadByRequestProjectTime"
                        TypeName="LiquiForce.LFSLive.DA.Resources.Employees.EmployeeListGateway" OldValuesParameterFormatString="original_{0}"
                        CacheDuration="60" EnableCaching="True">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name="requestProjectTime" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsTemplate" runat="server" SelectMethod="LoadForDropDownListByLoginIdAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.LabourHours.TeamProjectTime.TeamProjectTime2"
                        OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="loginId" Type="Int32" />
                            <asp:Parameter DefaultValue="0" Name="teamProjectTimeId" Type="Int32" />
                            <asp:Parameter DefaultValue="(Select)" Name="templateName" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsWorkFunctionConcat" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.LabourHours.TeamProjectTime.TeamProjectTimeWorkFunctionConcatList"
                        OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select)" Name="workFunctionConcat" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsJobClassType" runat="server" SelectMethod="LoadAndAddItem" 
                        TypeName="LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTimeJobClassTypeList" CacheDuration="60" EnableCaching="True">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name="countryId" Type="Int32" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue=" " Name="jobClassType" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsSections" runat="server" SelectMethod="GetSectionsInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.LabourHours.TeamProjectTime.timesheet_team"></asp:ObjectDataSource>
                        
                    <asp:ObjectDataSource ID="odsSectionsInstall" runat="server" SelectMethod="GetSectionsInstallInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.LabourHours.TeamProjectTime.timesheet_team"></asp:ObjectDataSource>
                        
                    <asp:ObjectDataSource ID="odsSectionsReinstatePostVideo" runat="server" SelectMethod="GetSectionsReinstatePostVideoInformation"
                        TypeName="LiquiForce.LFSLive.WebUI.LabourHours.TeamProjectTime.timesheet_team"></asp:ObjectDataSource>
                        
                    <asp:ObjectDataSource ID="odsLaterals" runat="server" SelectMethod="GetLateralsInformation" 
                        TypeName="LiquiForce.LFSLive.WebUI.LabourHours.TeamProjectTime.timesheet_team"></asp:ObjectDataSource>
                        
                    <asp:ObjectDataSource ID="odsManholesRehabPrep" runat="server" SelectMethod="GetSectionsManholesRehabPrepInformation" 
                        TypeName="LiquiForce.LFSLive.WebUI.LabourHours.TeamProjectTime.timesheet_team"></asp:ObjectDataSource>
                        
                    <asp:ObjectDataSource ID="odsManholesRehabSpray" runat="server" SelectMethod="GetSectionsManholesRehabSprayInformation" 
                        TypeName="LiquiForce.LFSLive.WebUI.LabourHours.TeamProjectTime.timesheet_team"></asp:ObjectDataSource>
                    
                </td>
            </tr>
        </table>
        
        
       
    </div>
</asp:Content>
