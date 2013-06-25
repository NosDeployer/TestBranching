<%@ Page Language="C#" MasterPageFile="../../mForm6.master" EnableEventValidation="false" AutoEventWireup="true" Codebehind="timesheet_edit.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.timesheet_edit" Title="LFS Live"  %>

<asp:Content ID="Content4" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" SkinID="LabelPageTitle1" Text="Edit Project Time" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 2px">
                </td>
            </tr>            
        </table>
    </div>
</asp:Content>
    
    
    
<asp:Content ID="Content1" ContentPlaceHolderID="LeftMenuPlaceHolder" runat="server">
    <!-- LEFT MENU -->
    <div style="width: 190px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadPanelBar ID="tkrpbLeftMenuMyTimesheets" runat="server" SkinID="RadPanelBar" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="My Timesheets" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="nbMyTimesheetsViewCurrent" Text="View Current"></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="nbMyTimesheetsViewAll" Text="View All" ></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>            
            <tr>
                <td>
                    <telerik:RadPanelBar id="tkrpbLeftMenuOthersTimesheets" runat="server" SkinID="RadPanelBar" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Others Timesheets" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="nbOthersTimesheetsDDL" Text="" PostBack="false">
                                        <ItemTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblOthersFor" runat="server" EnableViewState="True" Text="Timesheet For" SkinID="Label"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="height: 2px">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:DropDownList ID="ddlOthersFor" runat="server" SkinID="DropDownList" Style="width: 100%" >
                                                        </asp:DropDownList>                                                     
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="nbOthersTimesheetsViewCurrent" Text="View Current" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="nbOthersTimesheetsViewAll" Text="View All" ></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>
            <tr>
                <td style="height: 15px">
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadPanelBar id="tkrpbLeftMenuTools" runat="server" SkinID="RadPanelBar2" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="True" Text="Tools" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="nbTimesheetsToolsAddTeamProjectTime" Text="Add Team Project Time" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="nbTimesheetsToolsApproveProjectTimes" Text="Approve Project Times" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="nbTimesheetsToolsMissingProjectTime" Text="Missing Project Times" ></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>
            <tr>
                <td style="height: 15px">
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadPanelBar id="tkrpbLeftMenuReports" runat="server" SkinID="RadPanelBar2" Width="180px" OnClientItemClicking="tkrpbLeftMenuItemClick">
                        <Items>
                            <telerik:RadPanelItem Expanded="False" Text="Reports" PostBack="false">
                                <Items>
                                    <telerik:RadPanelItem runat="server" Value="nbReportsPrintHoursForPayrollPeriodOld" Text="Print Hours For Payroll Period (Old Version)" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="nbReportsPrintHoursForPayrollPeriod" Text="Print Hours For Payroll Period (New Version)" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="nbReportsPrintHoursForPayrollPeriodWithApproval" Text="Print Hours For Payroll Period (New Version With Approval)" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="nbReportsPrintUnapprovedProjectTimes" Text="Print Unapproved Project Times" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="nbReportsPrintTeamMemberLocation" Text="Print Team Member Location" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="nbReportsPrintVehicleLocation" Text="Print Vehicle Location" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="nbReportsPrintVehicleUsageInUSA" Text="Print Vehicle Usage In USA" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="nbReportsPrint3ChartReport" Text="Print 3 Chart Report" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="nbReportsPrintTeamMemberHoursForRestartWeek" Text="Print Team Member Hours For Restart Week" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="nbReportsPrintLogsOver15Hours" Text="Print Logs Over 14/15 Hours" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="nbReportsPrintMeals" Text="Print Meals" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="nbReportsPrintHoursForProject" Text="Print Hours For Project" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="nbReportsPrintProjectCosting" Text="Print Project Costing" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="nbReportsPrintManhoursPerPhase" Text="Print KPI Report" ></telerik:RadPanelItem>
                                    <telerik:RadPanelItem runat="server" Value="nbReportsPrintSummaryCostingSheetByMonth" Text="Print Summary Costing Sheet by Month" ></telerik:RadPanelItem>
                                </Items>
                            </telerik:RadPanelItem>                      
                        </Items>
                    </telerik:RadPanelBar>
                </td>
            </tr>
        </table>
    </div>      
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ToolbarPlaceHolder" runat="server">
    <!-- TOOLBAR -->
    <div style="width: 750px">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick">                        
                        <Items>
                            <telerik:RadMenuItem Value="mSave" Text="SAVE" ToolTip="save and close" />
                            
                            <telerik:RadMenuItem Value="mCancel" Text="CANCEL" ToolTip="close without saving" />
                            
                            <telerik:RadMenuItem Value="mSummary" Text="SUMMARY" ToolTip="view summary" />
                            
                            <telerik:RadMenuItem Value="mApproveProjectTimes" Text="APPROVE PROJECT TIMES" ToolTip="view approve project times tool" />
                        </Items>
                    </telerik:RadMenu>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
   <div style="width: 750px">
        <!-- Page element: 4 columns -->
        <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td style="width: 187px;">
                    <asp:Label ID="lblEmployeeTitle" runat="server" SkinID="Label" Text="Team Member" EnableViewState="False"></asp:Label>
                </td>
                <td style="width: 187px;">
                </td>
                <td style="width: 187px;">
                    <asp:Label ID="lblState" runat="server" SkinID="Label" Text="State" EnableViewState="false"></asp:Label>
                </td>
                <td style="width: 187px;">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="tbxEmployee" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Width="365px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxState" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Width="175px" Text='<%# DataBinder.Eval(projectTimeTDS, "Tables[LFS_PROJECT_TIME].DefaultView.[0].ProjectTimeState") %>'></asp:TextBox>
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
                    <asp:Label ID="lblClient" runat="server" SkinID="Label" Text="Client" EnableViewState="False"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                    <asp:Label ID="lblProject" runat="server" SkinID="Label" Text="Project" EnableViewState="False"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <!-- Page element: UpdatePanel -->
                    <asp:UpdatePanel ID="upnlClient" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
                            <asp:DropDownList ID="ddlClient" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged" Width="365px" SkinID="DropDownListLookup">
                            </asp:DropDownList>                        
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
                                        <td>
                                            <asp:DropDownList id="ddlProject" runat="server" SkinID="DropDownListLookup" Width="365px" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged" AutoPostBack="True"> </asp:DropDownList> 
                                        </td>
                                        <td style="vertical-align: middle">
                                            <asp:UpdateProgress id="upProject" runat="server" AssociatedUpdatePanelID="upnlClient">
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
                </td>
                <td>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvProject" runat="server" ControlToValidate="ddlProject"
                        Display="Dynamic" ErrorMessage="Please select a project." InitialValue="-1" SkinID="Validator"
                        EnableViewState="False" ValidationGroup="generalData"></asp:RequiredFieldValidator>
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
                    <asp:Label ID="lblDate" runat="server" SkinID="Label" Text="Date" EnableViewState="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblWorkingDetails" runat="server" SkinID="Label" Text="Working / Details" EnableViewState="False"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadDatePicker ID="tkrdpDate_" runat="server" Width="177px" SkinID="RadDatePicker"
                        DbSelectedDate='<%# DataBinder.Eval(projectTimeTDS, "Tables[LFS_PROJECT_TIME].DefaultView.[0].Date_") %>'
                        Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                        <Calendar UseRowHeadersAsSelectors="False" UseColumnHeadersAsSelectors="False" DayNameFormat="Short"
                            ShowRowHeaders="False" ViewSelectorText="x">
                        </Calendar>
                        <DatePopupButton ImageUrl="" HoverImageUrl=""></DatePopupButton>
                    </telerik:RadDatePicker>                        
                </td>
                <td>
                    <!-- Page element: UpdatePanel -->
                    <asp:UpdatePanel ID="upnlWorkingDetails" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:DropDownList id="ddlWorkingDetails" runat="server" SkinID="DropDownList" Width="177px"></asp:DropDownList>
                                        </td>
                                        <td style="vertical-align: middle">
                                            <asp:UpdateProgress id="upWorkingDetails" runat="server" AssociatedUpdatePanelID="upnlProject">
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
                            <asp:AsyncPostBackTrigger ControlID="ddlProject" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                        </triggers>
                    </asp:UpdatePanel>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CustomValidator ID="cvDatePayPeriod" runat="server" ControlToValidate="tkrdpDate_"
                        Display="Dynamic" ErrorMessage="There isn't a Pay Period for the date entered."
                        SkinID="Validator" EnableViewState="False" ValidationGroup="generalData">
                    </asp:CustomValidator>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvWorkingDetails" runat="server" ControlToValidate="ddlWorkingDetails"
                        Display="Dynamic" ErrorMessage="Please select a working / detail." InitialValue="(Select)"
                        SkinID="Validator" EnableViewState="False" ValidationGroup="generalData">
                    </asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CustomValidator ID="cvDateLimitedPayPeriod" runat="server" ControlToValidate="tkrdpDate_"
                        Display="Dynamic" ErrorMessage="You cannot add time in that date."
                        SkinID="Validator" ValidationGroup="generalData"></asp:CustomValidator>
                    <asp:CustomValidator ID="cvDateLimitedWednesdayPayPeriod" runat="server" ControlToValidate="tkrdpDate_"
                        Display="Dynamic" ErrorMessage="You cannot add time in that date."
                        SkinID="Validator" ValidationGroup="generalData"></asp:CustomValidator>
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
                    <asp:Label ID="lblStartTime" runat="server" SkinID="Label" Text="Start Time" EnableViewState="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblEndTime" runat="server" SkinID="Label" Text="End Time" EnableViewState="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblLunch" runat="server" SkinID="Label" Text="Lunch" EnableViewState="False"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel id="upStartTime" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
                            <asp:DropDownList ID="ddlStartTimeHour" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStartTimeHour_SelectedIndexChanged" SkinID="DropDownList" Style="width: 40px">
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
                            <asp:Label ID="lblStartTimeDots" runat="server" EnableViewState="False" SkinID="Label" Text="   : " Width="6px"></asp:Label>
                            <asp:DropDownList ID="ddlStartTimeMinute" runat="server" SkinID="DropDownList" Style="width: 40px" AutoPostBack="true" OnSelectedIndexChanged="ddlStartTimeHour_SelectedIndexChanged">
                                <asp:ListItem Value=" "></asp:ListItem>
                                <asp:ListItem Value="00">00</asp:ListItem>
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
                            <asp:DropDownList ID="ddlEndTimeHour" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEndTimeHour_SelectedIndexChanged" SkinID="DropDownList" Style="width: 40px">
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
                            <asp:Label ID="lblEndTimeDots" runat="server" EnableViewState="False" SkinID="Label" Text="   : " Width="6px" ></asp:Label>
                            <asp:DropDownList ID="ddlEndTimeMinute" runat="server" SkinID="DropDownList" Style="width: 40px">
                                <asp:ListItem Value=" "></asp:ListItem>
                                <asp:ListItem Value="00">00</asp:ListItem>
                                <asp:ListItem Value="15">15</asp:ListItem>
                                <asp:ListItem Value="30">30</asp:ListItem>
                                <asp:ListItem Value="45">45</asp:ListItem>                                                                
                            </asp:DropDownList>                                                               
                        </contenttemplate>           
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:DropDownList ID="ddlLunch" runat="server" SkinID="DropDownList" Style="width: 177px" SelectedValue='<%# GetLunch(DataBinder.Eval(projectTimeTDS, "Tables[LFS_PROJECT_TIME].DefaultView.[0].Offset", "{0:N}")) %>'>
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
                        Display="Dynamic" ErrorMessage="Please delete the start time." SkinID="Validator"
                        ValidateEmptyText="True" EnableViewState="False" 
                        ValidationGroup="generalData"></asp:CustomValidator>
                    <asp:CustomValidator ID="cvValidStartTime" runat="server" ControlToValidate="ddlStartTimeHour"
                        Display="Dynamic" 
                        ErrorMessage="Please provide a valid Time. (provide Hours : Minutes)" SkinID="Validator"
                        ValidateEmptyText="True" EnableViewState="False" 
                        ValidationGroup="generalValidData" 
                        onservervalidate="cvValidStartTime_ServerValidate"></asp:CustomValidator>
                </td>
                <td>
                    <asp:CustomValidator ID="cvEndTimeDelete" runat="server" ControlToValidate="ddlEndTimeHour"
                        Display="Dynamic" ErrorMessage="Please delete the end time." SkinID="Validator"
                        ValidateEmptyText="True" EnableViewState="False" 
                        ValidationGroup="generalData"></asp:CustomValidator>
                    <asp:CustomValidator ID="cvValidEndTime" runat="server" ControlToValidate="ddlEndTimeHour"
                        Display="Dynamic" 
                        ErrorMessage="Please provide a valid Time. (provide Hours : Minutes)" SkinID="Validator"
                        ValidateEmptyText="True" EnableViewState="False" 
                        ValidationGroup="generalValidData" 
                        onservervalidate="cvValidEndTime_ServerValidate"></asp:CustomValidator>
                </td>
                <td>
                    <asp:CustomValidator ID="cvLunchDelete" runat="server" ControlToValidate="ddlLunch"
                        Display="Dynamic" ErrorMessage="Please delete the lunch time." SkinID="Validator"
                        ValidateEmptyText="True" EnableViewState="False" ValidationGroup="generalData"></asp:CustomValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CustomValidator ID="cvStartTimeProvide" runat="server" ControlToValidate="ddlStartTimeHour"
                        Display="Dynamic" ErrorMessage="Please provide a start time." SkinID="Validator" ValidateEmptyText="True" EnableViewState="False" 
                        ValidationGroup="generalData"></asp:CustomValidator>
                    <asp:CustomValidator ID="cvProjectTime" runat="server" Display="Dynamic" ErrorMessage="Project Time must be greater than zero."
                        SkinID="Validator" EnableViewState="False" ValidationGroup="generalData"></asp:CustomValidator>
                    <asp:CustomValidator ID="cvValidTimes" runat="server" Display="Dynamic" ErrorMessage="This start time or end time is overlapping an existent project time, please review you data."
                        OnServerValidate="cvValidTimes_ServerValidate" SkinID="Validator" ValidationGroup="generalData"></asp:CustomValidator>
                </td>
                <td>
                    <asp:CustomValidator ID="cvEndTimeProvide" runat="server" ControlToValidate="ddlEndTimeHour"
                        Display="Dynamic" ErrorMessage="Please provide an end time." SkinID="Validator"
                        ValidateEmptyText="True" EnableViewState="False" 
                        ValidationGroup="generalData"></asp:CustomValidator>
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
                    <asp:Label ID="lblTypeOfWork" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Type Of Work"></asp:Label></td>
                <td>
                    <asp:Label ID="lblFunction" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Function"></asp:Label></td>
                <td>
                    <!-- Page element: UpdatePanel -->
                    <asp:UpdatePanel ID="upnlJobClassTypeLabel" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblJobClassType" runat="server" EnableViewState="False" SkinID="Label" Text="Job Class" Visible="false"></asp:Label>
                                        </td>
                                        <td style="vertical-align: middle">
                                            <asp:UpdateProgress id="upJobClassTypeLabel" runat="server" AssociatedUpdatePanelID="upnlProject">
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
                            <asp:AsyncPostBackTrigger ControlID="ddlProject" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                        </triggers>
                    </asp:UpdatePanel>                    
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel id="upnlTypeOfWork" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
                            <asp:DropDownList id="ddlTypeOfWork" runat="server" SkinID="DropDownList" Width="177px" OnSelectedIndexChanged="ddlTypeOfWork_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>   
                        </contenttemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="upnlFunction" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:DropDownList id="ddlFunction" runat="server" SkinID="DropDownList" Width="177px"></asp:DropDownList>
                                        </td>
                                        <td style="vertical-align: middle">
                                            <asp:UpdateProgress id="upFunction" runat="server" AssociatedUpdatePanelID="upnlTypeOfWork">
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
                            <asp:AsyncPostBackTrigger ControlID="ddlTypeOfWork" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                        </triggers>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <!-- Page element: UpdatePanel -->
                    <asp:UpdatePanel ID="upnlJobClassType" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:DropDownList id="ddlJobClassType" runat="server" SkinID="DropDownList" Width="177px" Visible="false">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="vertical-align: middle">
                                            <asp:UpdateProgress id="upJobClassType" runat="server" AssociatedUpdatePanelID="upnlProject">
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
                            <asp:AsyncPostBackTrigger ControlID="ddlProject" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                        </triggers>
                    </asp:UpdatePanel>                    
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RequiredFieldValidator ID="rfvTypeOfWork" runat="server" ControlToValidate="ddlTypeOfWork"
                        Display="Dynamic" EnableViewState="False" ErrorMessage="Please select a type of work."
                        InitialValue="(Select a Type)" SkinID="Validator" ValidationGroup="specialData"></asp:RequiredFieldValidator></td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvFunction" runat="server" ControlToValidate="ddlFunction"
                        Display="Dynamic" EnableViewState="False" ErrorMessage="Please select a function."
                        InitialValue="(Select a Function)" SkinID="Validator" ValidationGroup="specialData"></asp:RequiredFieldValidator></td>
                <td>
                    <asp:CustomValidator ID="cvJobClassType" runat="server" ControlToValidate="ddlJobClassType"
                        Display="Dynamic" EnableViewState="False" ErrorMessage="Please select a job class."
                        OnServerValidate="cvJobClassType_ServerValidate" SkinID="Validator" ValidationGroup="generalValidData">
                    </asp:CustomValidator>
                    <asp:CustomValidator ID="cvJobClassEmpty" runat="server" ControlToValidate="ddlJobClassType" Display="Dynamic" 
                        EnableViewState="False" ErrorMessage="Please define a valid job class on Team Members module."                                                                
                        OnServerValidate="cvJobClassEmpty_ServerValidate" SkinID="Validator" ValidationGroup="generalValidData" 
                        ValidateEmptyText="True"></asp:CustomValidator>
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
                        <contenttemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:DropDownList id="ddlMealsCountry" runat="server" SkinID="DropDownList" Width="177px"></asp:DropDownList>
                                        </td>
                                        <td style="vertical-align: middle">
                                            <asp:UpdateProgress id="upMealsCountry" runat="server" AssociatedUpdatePanelID="upnlProject">
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
                            <asp:AsyncPostBackTrigger ControlID="ddlProject" EventName="SelectedIndexChanged"></asp:AsyncPostBackTrigger>
                        </triggers>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <%--<asp:CheckBox ID="cbxMealsAllowance" runat="server" SkinID="CheckBox" EnableViewState="False" />--%>
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
                        SkinID="Validator" EnableViewState="False" ValidationGroup="generalData"></asp:CustomValidator>
                </td>
                <td>
                    <asp:CustomValidator ID="cvMealsAllowance" runat="server" Display="Dynamic" ErrorMessage="You already registered meals allowance on this day."
                        SkinID="Validator" ValidationGroup="generalData"></asp:CustomValidator>
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
            <tr>
                <td>
                    <asp:Label ID="lblUnit" runat="server" SkinID="Label" Text="Unit" EnableViewState="False"></asp:Label></td>
                <td>
                    <asp:Label ID="lblTowed" runat="server" SkinID="Label" Text="Towed" EnableViewState="False"></asp:Label></td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="ddlUnit" runat="server" SkinID="DropDownList" Width="177px">
                    </asp:DropDownList></td>
                <td>
                    <asp:DropDownList ID="ddlTowed" runat="server" SkinID="DropDownList" Width="177px">
                    </asp:DropDownList></td>
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
                    <asp:Label ID="lblComments" runat="server" SkinID="Label" Text="Comments" EnableViewState="False"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:TextBox ID="tbxComments" runat="server" Rows="5" Text='<%# DataBinder.Eval(projectTimeTDS, "Tables[LFS_PROJECT_TIME].DefaultView.[0].Comments") %>'
                        SkinID="TextBox" TextMode="MultiLine" Width="740px" EnableViewState="False"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>            
        </table>
        
        <table>
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                </td>
            </tr>
        </table>
        
        <!-- Page element : Footer separation -->
        <table id="Table1" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%" >
            <tr>
                <td style="height: 60px">
                </td>
            </tr>
        </table>


       
    </div>
</asp:Content>