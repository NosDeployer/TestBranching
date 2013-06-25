<%@ Page Language="C#" MasterPageFile="../../mForm6.master" AutoEventWireup="true" Codebehind="timesheet_add.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.timesheet_add" Title="LFS Live"%>
    
<asp:Content ID="Content4" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="LabelTitle" runat="server" SkinID="LabelPageTitle1" Text="Add Project Time" EnableViewState="False"></asp:Label>
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

    <script language="javascript" type="text/javascript">
        function confirmAdd() {
            if (document.getElementById('ctl00_ContentPlaceHolder_hdfIsMoreThan15').value == "true") {
                return confirm("You entered more than 15 hours, are you sure? Do you want to continue?");
            }
            else {
                return true;
            }
        }

        function confirmEdit() {
            if (document.getElementById('ctl00_ContentPlaceHolder_hdfIsMoreThan15Edit').value == "true") {
                return confirm("You entered more than 15 hours, are you sure? Do you want to continue?");
            }
            else {
                return true;
            }
        }
    </script>
    
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
                <td style="width: 25%;">
                    <asp:Label ID="lblEmployeeTitle" runat="server" SkinID="Label" Text="Team Member" EnableViewState="False"></asp:Label>
                </td>
                <td style="width: 25%;">
                </td>
                <td style="width: 25%;">
                    <asp:Label ID="lblState" runat="server" SkinID="Label" Text="State" EnableViewState="false"></asp:Label>
                </td>
                <td style="width: 25%;">
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="tbxEmployee" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Width="360px"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxState" runat="server" ReadOnly="true" SkinID="TextBoxReadOnly" Width="175px"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="height: 7px;">
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
                            <asp:DropDownList ID="ddlClient" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged" Width="360px" SkinID="DropDownListLookup">
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
                                        <td style="width:360px">
                                            <asp:DropDownList id="ddlProject" runat="server" SkinID="DropDownListLookup" Width="360px" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged" AutoPostBack="True"> </asp:DropDownList> 
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
                    <asp:RequiredFieldValidator ID="rfvClient" runat="server" ControlToValidate="ddlClient"
                        Display="Dynamic" ErrorMessage="Please select a client." InitialValue="-1" SkinID="Validator"
                        EnableViewState="False" ValidationGroup="generalData">
                    </asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvProject" runat="server" ControlToValidate="ddlProject"
                        Display="Dynamic" ErrorMessage="Please select a project." InitialValue="-1" SkinID="Validator"
                        EnableViewState="False" ValidationGroup="generalData">
                    </asp:RequiredFieldValidator>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="height: 7px;">
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
                     <!-- Page element: UpdatePanel -->
                    <asp:UpdatePanel ID="upnlLblStartDate" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="width: 175px">
                                            <asp:Label ID="lblStartDate" runat="server" SkinID="Label" Text="Date" EnableViewState="False"></asp:Label>
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
                    <!-- Page element: UpdatePanel -->
                    <asp:UpdatePanel ID="upnlLblLastDate" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="width: 175px">
                                            <asp:Label ID="lblLastDate" runat="server" SkinID="Label" Text="End Date" EnableViewState="False" Visible="false"></asp:Label>
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
                    <!-- Page element: UpdatePanel -->
                    <asp:UpdatePanel ID="upnlLblWorkingDetails" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="width: 175px">
                                            <asp:Label ID="lblWorkingDetails" runat="server" SkinID="Label" Text="Working / Details" Visible="false"></asp:Label>
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
                    <telerik:RadDatePicker ID="tkrdpStartDate" runat="server" Width="175px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                    </telerik:RadDatePicker>
                </td>
                <td>
                    <!-- Page element: UpdatePanel -->
                    <asp:UpdatePanel ID="upnlDeLastDate" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="width: 175px">
                                            <telerik:RadDatePicker ID="tkrdpEndDate" runat="server" Width="175px" SkinID="RadDatePicker" Visible="false" Calendar-ShowRowHeaders="false" Calendar-DayNameFormat="Short">
                                            </telerik:RadDatePicker>
                                        </td>
                                        <td style="vertical-align: middle">
                                            <asp:UpdateProgress id="upDeLastDate" runat="server" AssociatedUpdatePanelID="upnlProject">
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
                     <!-- Page element: UpdatePanel -->
                    <asp:UpdatePanel ID="upnlDdlWorkingDetails" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="width: 175px">
                                            <asp:HiddenField ID="hdfWorkingDetails" runat="server" />
                                            <asp:DropDownList Style="width: 175px" ID="ddlWorkingDetails" runat="server" SkinID="DropDownListLookup" Visible="false"
                                                EnableViewState="True" DataTextField="WorkingDetails" DataValueField="WorkingDetails" DataSourceID="odsWorkingDetails">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="vertical-align: middle">
                                            <asp:UpdateProgress id="upDdlWorkingDetails" runat="server" AssociatedUpdatePanelID="upnlProject">
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
                    <asp:RequiredFieldValidator ID="rfvStartDate" runat="server" ControlToValidate="tkrdpStartDate" ValidationGroup="generalData"
                        Display="Dynamic" ErrorMessage="Please provide a start date." SkinID="Validator" EnableViewState="False">
                    </asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvDatePayPeriodStartDate" runat="server" ControlToValidate="tkrdpStartDate" ValidationGroup="generalData"
                        Display="Dynamic" ErrorMessage="There isn't a Pay Period for the date entered." SkinID="Validator">
                    </asp:CustomValidator>
                    <asp:CustomValidator ID="cvDateLimitedPayPeriodStartDate" runat="server" ControlToValidate="tkrdpStartDate" ValidationGroup="generalData"
                        Display="Dynamic" ErrorMessage="You cannot add time in that date." SkinID="Validator" >
                    </asp:CustomValidator>
                    <asp:CustomValidator ID="cvDateLimitedWednesdayPayPeriodStartDate" runat="server" ControlToValidate="tkrdpStartDate" ValidationGroup="generalData"
                        Display="Dynamic" ErrorMessage="You cannot add time in that date." SkinID="Validator" >
                    </asp:CustomValidator>
                </td>
                <td>          
                    <asp:RequiredFieldValidator ID="rfvLastDate" runat="server" ControlToValidate="tkrdpEndDate" ValidationGroup="specialData"
                        Display="Dynamic" ErrorMessage="Please provide an end date." SkinID="Validator">
                    </asp:RequiredFieldValidator>
                    <asp:CustomValidator ID="cvDayPayPeriodLastDate" runat="server" ControlToValidate="tkrdpEndDate" ValidationGroup="specialData"
                        Display="Dynamic" ErrorMessage="There isn't a Pay Period for the date entered." SkinID="Validator">
                    </asp:CustomValidator>
                    <asp:CustomValidator ID="cvDateLimitedPayPeriodLastDate" runat="server" ControlToValidate="tkrdpEndDate" ValidationGroup="specialData"
                        Display="Dynamic" ErrorMessage="You cannot add time in that date." SkinID="Validator">
                    </asp:CustomValidator>
                    <asp:CustomValidator ID="cvMinDateLastDate" runat="server" ControlToValidate="tkrdpEndDate" ValidationGroup="specialData"
                        Display="Dynamic" ErrorMessage="Please provide an end date greater than & equals to start date." SkinID="Validator">
                    </asp:CustomValidator>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvWorkingDetailst" runat="server" ControlToValidate="ddlWorkingDetails"
                        Display="Dynamic" EnableViewState="False" ErrorMessage="Please select a working / details."
                        InitialValue="(Select)" SkinID="Validator" ValidationGroup="specialData">
                    </asp:RequiredFieldValidator>
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
                    <!-- Page element: UpdatePanel -->
                    <asp:UpdatePanel ID="upnlLblMealsCountry" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="width: 175px">
                                            <asp:Label ID="lblMealsCountry" runat="server" SkinID="Label" Text="Meals Country" EnableViewState="False"></asp:Label>
                                        </td>
                                        <td style="vertical-align: middle">
                                            <asp:UpdateProgress id="upLblMealsCountry" runat="server" AssociatedUpdatePanelID="upnlProject">
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
                                        <td style="width: 175px">
                                            <asp:DropDownList id="ddlMealsCountry" runat="server" SkinID="DropDownList" Width="175px"></asp:DropDownList>
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
                        SkinID="Validator" EnableViewState="False" OnServerValidate="cvMealsCountry_ServerValidate" ValidationGroup="footerData">
                    </asp:CustomValidator>
                    <asp:CustomValidator ID="cvMealsCountryEdit" runat="server" ControlToValidate="ddlMealsCountry"
                        Display="Dynamic" ErrorMessage="You checked a meals allowance but not selected a meals country; please select a meals country."
                        SkinID="Validator" EnableViewState="False" OnServerValidate="cvMealsCountryEdit_ServerValidate" ValidationGroup="editData">
                    </asp:CustomValidator>
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>  --%>
            <tr>
                <td colspan="4">
                    <!-- Page element: UpdatePanel -->
                    <asp:UpdatePanel ID="upnlLblCommentsVacation" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblCommentsVacation" runat="server" SkinID="Label" Text="Comments" Visible="false"></asp:Label>
                                        </td>
                                        <td style="vertical-align: middle">
                                            <asp:UpdateProgress id="upLblCommentsVacation" runat="server" AssociatedUpdatePanelID="upnlProject">
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
            </tr>
            <tr>
                <td colspan="4">
                    <!-- Page element: UpdatePanel -->
                    <asp:UpdatePanel ID="upnlTbxCommentsVacation" runat="server" UpdateMode="Conditional">
                        <contenttemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:TextBox ID="tbxCommentsVacation" runat="server" SkinID="TextBoxMemo" Width="726px" Rows="1" Visible="false"></asp:TextBox>
                                         </td>
                                        <td style="vertical-align: middle">
                                            <asp:UpdateProgress id="upTbxCommentsVacation" runat="server" AssociatedUpdatePanelID="upnlProject">
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
            </tr>
            <tr>
                <td style="height: 10px">
                </td>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
        </table>
        
        <%--Grid--%>
        <!-- Table element: 1 columns  - Timesheets Info Section -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:UpdatePanel id="upnlTimesheets" runat="server">
                        <contenttemplate>
                            <!-- Page element: 1 column - Grid Timesheets -->
                            <asp:GridView ID="grdProjectTime" runat="server" SkinID="GridView" Width="740px" 
                                DataKeyNames="ProjectTimeID" AutoGenerateColumns="False" OnRowDataBound="grdProjectTime_RowDataBound"
                                OnRowDeleting="grdProjectTime_RowDeleting" OnRowUpdating="grdProjectTime_RowUpdating"
                                OnRowCommand="grdProjectTime_RowCommand" OnDataBound="grdProjectTime_DataBound" OnRowEditing="grdProjectTime_RowEditing"
                                ShowFooter="True" DataSourceID="odsProjectTime" PageSize="5" AllowPaging="true" >
                                <Columns>
                                    <asp:TemplateField SortExpression="ProjectTimeID" Visible="False" HeaderText="ProjectTimeID">
                                        <EditItemTemplate>
                                            <asp:Label ID="lblProjectTimeIdEdit" runat="server" Text='<%# Eval("ProjectTimeID") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:Label ID="lblProjectTimeId" runat="server" Text='<%# Eval("ProjectTimeID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    
                                    
                                    <asp:TemplateField SortExpression="ProjectTime" HeaderText="Project Time">
                                        <EditItemTemplate>
                                            <!-- Page element : 8 columns - Data -->
                                            <table style="width: 700px" cellspacing="0" cellpadding="0" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10px; height: 12px">
                                                        </td>
                                                        <td style="width: 120px;">
                                                        </td>
                                                        <td style="width: 120px">
                                                        </td>
                                                        <td style="width: 125px">
                                                        </td>
                                                        <td style="width: 110px">
                                                        </td>
                                                        <td style="width: 110px">
                                                        </td>
                                                        <td style="width: 95px">
                                                        </td>
                                                        <td style="width: 10px">
                                                        </td>                                                        
                                                    </tr>                                                
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblStartTimeEdit" runat="server" SkinID="Label" Text="Start Time"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEndTimeEdit" runat="server" SkinID="Label" Text="End Time"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblLunchEdit" runat="server" SkinID="Label" Text="Lunch"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:HiddenField ID="hdfDateEdit" runat="server" Value='<%# Eval("Date_") %>' />                                                            
                                                            <asp:UpdatePanel id="upStartTimeEdit" runat="server" UpdateMode="Conditional">
                                                                <contenttemplate>
                                                                    <asp:DropDownList ID="ddlStartTimeHourEdit" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStartTimeHourEdit_SelectedIndexChanged" SkinID="DropDownList" Style="width: 40px" >
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
                                                                        SkinID="Label" Text="   : " Width="6px"></asp:Label>
                                                                    <asp:DropDownList ID="ddlStartTimeMinuteEdit" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStartTimeHourEdit_SelectedIndexChanged" SkinID="DropDownList" Style="width: 40px">
                                                                        <asp:ListItem Value=" "></asp:ListItem>
                                                                        <asp:ListItem Value="00">00</asp:ListItem>
                                                                        <asp:ListItem Value="15">15</asp:ListItem>
                                                                        <asp:ListItem Value="30">30</asp:ListItem>
                                                                        <asp:ListItem Value="45">45</asp:ListItem>                                                                
                                                                    </asp:DropDownList>               
                                                                </contenttemplate>           
                                                            </asp:UpdatePanel> 
                                                        </td>
                                                        <td colspan="2">                                                            
                                                            <asp:UpdatePanel id="upEndTimeEdit" runat="server" UpdateMode="Conditional">
                                                                <contenttemplate>
                                                                    <asp:DropDownList ID="ddlEndTimeHourEdit" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEndTimeHourEdit_SelectedIndexChanged" SkinID="DropDownList" Style="width: 40px">
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
                                                                        SkinID="Label" Text="   : " Width="6px"></asp:Label>
                                                                    <asp:DropDownList ID="ddlEndTimeMinuteEdit" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEndTimeMinuteEdit_SelectedIndexChanged" SkinID="DropDownList" Style="width: 40px">
                                                                        <asp:ListItem Value=" "></asp:ListItem>
                                                                        <asp:ListItem Value="00" >00</asp:ListItem>
                                                                        <asp:ListItem Value="15">15</asp:ListItem>
                                                                        <asp:ListItem Value="30">30</asp:ListItem>
                                                                        <asp:ListItem Value="45">45</asp:ListItem>                                                                
                                                                    </asp:DropDownList>                                                                   
                                                                </contenttemplate>           
                                                            </asp:UpdatePanel> 
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlLunchEdit" runat="server" SkinID="DropDownList" Style="width: 100px" SelectedValue='<%# GetLunch(Eval("Offset", "{0:n2}")) %>'>
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
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:CustomValidator ID="cvStarTimeProvideEdit" runat="server" 
                                                                ControlToValidate="ddlStartTimeHourEdit" Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Please provide start time." 
                                                                OnServerValidate="cvStartTimeProvideEdit_ServerValidate" SkinID="Validator" 
                                                                ValidateEmptyText="True" ValidationGroup="editData"></asp:CustomValidator>
                                                            <asp:CustomValidator ID="cvStartTimeDeleteEdit" runat="server" 
                                                                ControlToValidate="ddlStartTimeHourEdit" Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Please delete start time." 
                                                                OnServerValidate="cvStartTimeDeleteEdit_ServerValidate" SkinID="Validator" 
                                                                ValidationGroup="editData"></asp:CustomValidator>
                                                            <asp:CustomValidator ID="cvValidProjectTimeEdit2" runat="server" 
                                                                ControlToValidate="ddlStartTimeHourEdit" Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Project Time must be greater than zero." 
                                                                OnServerValidate="cvValidProjectTimeEdit_ServerValidate" SkinID="Validator" 
                                                                ValidationGroup="editData"></asp:CustomValidator>
                                                            <asp:CustomValidator ID="cvValidStartTimeEdit" runat="server" 
                                                                ControlToValidate="ddlStartTimeHourEdit" Display="Dynamic" 
                                                                EnableViewState="False" 
                                                                ErrorMessage="Please provide a valid Time. (provide Hours : Minutes)" 
                                                                onservervalidate="cvValidStartTimeEdit_ServerValidate" SkinID="Validator" 
                                                                ValidateEmptyText="True" ValidationGroup="editValidData"></asp:CustomValidator>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:CustomValidator ID="cvEndTimeDeleteEdit" runat="server" 
                                                                ControlToValidate="ddlEndTimeHourEdit" Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Please delete end time." 
                                                                OnServerValidate="cvEndTimeDeleteEdit_ServerValidate" SkinID="Validator" 
                                                                ValidationGroup="editData"></asp:CustomValidator>
                                                            <asp:CustomValidator ID="cvValidProjectTimeEdit" runat="server" 
                                                                ControlToValidate="ddlEndTimeHourEdit" Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Project Time must be greater than zero." 
                                                                OnServerValidate="cvValidProjectTimeEdit_ServerValidate" SkinID="Validator" 
                                                                ValidationGroup="editData"></asp:CustomValidator>
                                                            <asp:CustomValidator ID="cvProvideEndTimeEdit" runat="server" 
                                                                ControlToValidate="ddlEndTimeHourEdit" Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Please provide end time." 
                                                                OnServerValidate="cvProvideEndTimeEdit_ServerValidate" SkinID="Validator" 
                                                                ValidateEmptyText="True" ValidationGroup="editData"></asp:CustomValidator>
                                                            <asp:CustomValidator ID="cvValidEndTimeEdit" runat="server" 
                                                                ControlToValidate="ddlEndTimeHourEdit" Display="Dynamic" 
                                                                EnableViewState="False" 
                                                                ErrorMessage="Please provide a valid Time. (provide Hours : Minutes)" 
                                                                onservervalidate="cvValidEndTimeEdit_ServerValidate" SkinID="Validator" 
                                                                ValidateEmptyText="True" ValidationGroup="editValidData"></asp:CustomValidator>
                                                        </td>
                                                        <td>
                                                            <asp:CustomValidator ID="cvValidProjectTimeLunchEdit" runat="server" 
                                                                ControlToValidate="ddlLunchEdit" Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Project Time must be greater than zero." 
                                                                OnServerValidate="cvValidProjectTimeEdit_ServerValidate" SkinID="Validator" 
                                                                ValidationGroup="editData"></asp:CustomValidator>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td colspan="6">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblTypeOfWorkFunctionEdit" runat="server" SkinID="Label" Text="Type of Work - Function"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblJobClassTypeEdit" runat="server" SkinID="Label" Text="Job Class"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblUnitEdit" runat="server" SkinID="Label" Text="Unit"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblTowedEdit" runat="server" SkinID="Label" Text="Towed"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <%--<asp:Label ID="lblMealsAllowanceEdit" runat="server" SkinID="Label" Text="Meals Allowance"></asp:Label>--%>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:DropDownList ID="ddlTypeOfWorkFunctionEdit" runat="server" 
                                                                DataSourceID="odsWorkFunctionConcat" DataTextField="WorkFunctionConcat" 
                                                                DataValueField="WorkFunctionConcat" SkinID="DropDownList" Style="width: 230px">
                                                            </asp:DropDownList>
                                                        </td>                                                       
                                                        <td>
                                                            <asp:DropDownList ID="ddlJobClassTypeEdit" runat="server" 
                                                                DataSourceID="odsJobClassType" DataTextField="JobClassType" 
                                                                DataValueField="JobClassType" EnableViewState="True" 
                                                                SkinID="DropDownListLookup" Style="width: 115px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlUnitEdit" runat="server" DataSourceID="odsUnit" 
                                                                DataTextField="UnitCode" DataValueField="UnitID" EnableViewState="True" 
                                                                SkinID="DropDownListLookup" Style="width: 100px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlTowedEdit" runat="server" DataSourceID="odsTowed" 
                                                                DataTextField="UnitCode" DataValueField="UnitID" EnableViewState="True" 
                                                                SkinID="DropDownListLookup" Style="width: 100px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <%--<asp:CheckBox ID="ckbxMealsAllowanceEdit" runat="server" 
                                                                Checked='<%# Eval("IsMealsAllowance") %>' SkinID="CheckBox" />--%>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:CustomValidator ID="cvTypeOfWorkFunctionDeleteEdit" runat="server" 
                                                                ControlToValidate="ddlTypeOfWorkFunctionEdit" Display="Dynamic" 
                                                                EnableViewState="False" ErrorMessage="Please delete type of work - function." 
                                                                OnServerValidate="cvTypeOfWorkFunctionDeleteEdit_ServerValidate" 
                                                                SkinID="Validator" ValidationGroup="editData"></asp:CustomValidator>
                                                            <asp:CustomValidator ID="cvProvideTypeOfWorkFunctionEdit" runat="server" 
                                                                ControlToValidate="ddlTypeOfWorkFunctionEdit" Display="Dynamic" 
                                                                EnableViewState="False" ErrorMessage="Please select a type of work - function." 
                                                                OnServerValidate="cvProvideTypeOfWorkFunctionEdit_ServerValidate" 
                                                                SkinID="Validator" ValidationGroup="editData"></asp:CustomValidator>
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
                                                        <td>
                                                            <asp:CustomValidator ID="cvUnitDeleteEdit" runat="server" 
                                                                ControlToValidate="ddlUnitEdit" Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Please delete unit." 
                                                                OnServerValidate="cvUnitDeleteEdit_ServerValidate" SkinID="Validator" 
                                                                ValidationGroup="editData"></asp:CustomValidator>
                                                        </td>
                                                        <td>
                                                            <asp:CustomValidator ID="cvTowedDeleteEdit" runat="server" 
                                                                ControlToValidate="ddlTowedEdit" Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Please delete towed." 
                                                                OnServerValidate="cvTowedDeleteEdit_ServerValidate" SkinID="Validator" 
                                                                ValidationGroup="editData"></asp:CustomValidator>
                                                        </td>
                                                        <td>
                                                            <%--<asp:CustomValidator ID="cvValidMealsCountryEdit" runat="server" 
                                                                Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="You checked a meals allowance but not selected a meals country; please select a meals country." 
                                                                OnServerValidate="cvValidMealsCountryEdit_ServerValidate" SkinID="Validator" 
                                                                ValidationGroup="editData"></asp:CustomValidator>--%>
                                                            <%--<asp:CustomValidator ID="cvDuplicateMealsAllowanceEdit" runat="server" 
                                                                Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Duplicated meals allowance." 
                                                                OnServerValidate="cvDuplicateMealsAllowanceEdit_ServerValidate" 
                                                                SkinID="Validator" ValidationGroup="editData"></asp:CustomValidator>--%>
                                                            <%--<asp:CustomValidator ID="cvAlreadyRegisteredMealsAllowanceEdit" runat="server" 
                                                                Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="You already registered meals allowance on this day." 
                                                                OnServerValidate="cvAlreadyRegisteredMealsAllowanceEdit_ServerValidate" 
                                                                SkinID="Validator" ValidationGroup="editData"></asp:CustomValidator>--%>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td colspan="6">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="6">
                                                            <asp:Label ID="lblCommentsEdit" runat="server" SkinID="Label" Text="Comments"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="6">
                                                            <asp:TextBox ID="tbxCommentsEdit" runat="server" Rows="4" SkinID="TextBoxMemo" 
                                                                Text='<%# Eval("Comments") %>' TextMode="MultiLine" Width="680px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                        <td colspan="6">
                                                            <asp:CustomValidator ID="cvValidTimesEdit" runat="server" Display="Dynamic" 
                                                                EnableViewState="False" 
                                                                ErrorMessage="This start time or end time is overlapping an existent project time, please review you data" 
                                                                OnServerValidate="cvValidTimesEdit_ServerValidate" SkinID="Validator" 
                                                                ValidationGroup="editData"></asp:CustomValidator>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 12px">
                                                        </td>
                                                        <td colspan="6">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </EditItemTemplate>
                                        <FooterTemplate>
                                            <!-- Page element : 8 columns - New data -->
                                            <table style="width: 700px" cellspacing="0" cellpadding="0" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10px; height: 12px">
                                                        </td>
                                                        <td style="width: 120px;">
                                                        </td>
                                                        <td style="width: 120px">
                                                        </td>
                                                        <td style="width: 125px">
                                                        </td>
                                                        <td style="width: 110px">
                                                        </td>
                                                        <td style="width: 110px">
                                                        </td>
                                                        <td style="width: 95px">
                                                        </td>
                                                        <td style="width: 10px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblStartTimeFooter" runat="server" SkinID="Label" Text="Start Time"></asp:Label></td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEndTimeFooter" runat="server" SkinID="Label" Text="End Time"></asp:Label></td>
                                                        <td>
                                                            </td>
                                                        <td>
                                                            <asp:Label ID="lblLunchFooter" runat="server" SkinID="Label" Text="Lunch"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:UpdatePanel id="upStartTimeFooter" runat="server" UpdateMode="Conditional">
                                                                <contenttemplate>
                                                                    <asp:DropDownList ID="ddlStartTimeHourFooter" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStartTimeHourFooter_SelectedIndexChanged" SkinID="DropDownList" Style="width: 40px">
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
                                                                        SkinID="Label" Text="   : " Width="6px"></asp:Label>
                                                                    <asp:DropDownList ID="ddlStartTimeMinuteFooter" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlStartTimeHourFooter_SelectedIndexChanged" SkinID="DropDownList" Style="width: 40px">
                                                                        <asp:ListItem Value=" "></asp:ListItem>
                                                                        <asp:ListItem Value="00" Selected="True">00</asp:ListItem>
                                                                        <asp:ListItem Value="15">15</asp:ListItem>
                                                                        <asp:ListItem Value="30">30</asp:ListItem>
                                                                        <asp:ListItem Value="45">45</asp:ListItem>                                                                
                                                                    </asp:DropDownList>                
                                                                </contenttemplate>           
                                                            </asp:UpdatePanel> 
                                                        
                                                        </td>
                                                        <td colspan="2">                                                        
                                                            <asp:UpdatePanel id="upEndTimeFooter" runat="server" UpdateMode="Conditional">
                                                                <contenttemplate>
                                                                    <asp:DropDownList ID="ddlEndTimeHourFooter" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEndTimeHourFooter_SelectedIndexChanged" SkinID="DropDownList" Style="width: 40px" >
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
                                                                        SkinID="Label" Text="   : " Width="6px"></asp:Label>
                                                                    <asp:DropDownList ID="ddlEndTimeMinuteFooter" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlEndTimeMinuteFooter_SelectedIndexChanged" SkinID="DropDownList" Style="width: 40px">
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
                                                            <asp:DropDownList ID="ddlLunchFooter" runat="server" SkinID="DropDownList" Style="width: 100px">
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
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:CustomValidator ID="cvStarTimeProvideFooter" runat="server" ControlToValidate="ddlEndTimeHourFooter"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Please provide start time."
                                                                OnServerValidate="cvStartTimeProvideFooter_ServerValidate" SkinID="Validator"
                                                                ValidateEmptyText="True" ValidationGroup="footerData"></asp:CustomValidator>
                                                            <asp:CustomValidator ID="cvStartTimeDeleteFooter" runat="server" ControlToValidate="ddlStartTimeHourFooter"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Please delete start time."
                                                                OnServerValidate="cvStartTimeDeleteFooter_ServerValidate" SkinID="Validator"
                                                                ValidationGroup="footerData"></asp:CustomValidator>
                                                            <asp:CustomValidator ID="cvValidProjectTimeFooter2" runat="server" ControlToValidate="ddlStartTimeHourFooter"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Project Time must be greater than zero."
                                                                OnServerValidate="cvValidProjectTimeFooter_ServerValidate" SkinID="Validator"
                                                                ValidationGroup="footerData"></asp:CustomValidator>
                                                            <asp:CustomValidator ID="cvValidStartTimeFooter" runat="server" 
                                                                ControlToValidate="ddlStartTimeHourFooter" Display="Dynamic" 
                                                                EnableViewState="False" 
                                                                ErrorMessage="Please provide a valid Time. (provide Hours : Minutes)" 
                                                                onservervalidate="cvValidStartTimeFooter_ServerValidate" SkinID="Validator" 
                                                                ValidateEmptyText="True" ValidationGroup="footerValidData"></asp:CustomValidator>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:CustomValidator ID="cvEndTimeDeleteFooter" runat="server" ControlToValidate="ddlEndTimeHourFooter"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Please delete end time."
                                                                OnServerValidate="cvEndTimeDeleteFooter_ServerValidate" SkinID="Validator" 
                                                                ValidationGroup="footerData"></asp:CustomValidator>
                                                            <asp:CustomValidator ID="cvProvideEndTime" runat="server" ControlToValidate="ddlEndTimeHourFooter"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Please provide end time."
                                                                OnServerValidate="cvProvideEndTimeFooter_ServerValidate" 
                                                                SkinID="Validator" ValidateEmptyText="True"
                                                                ValidationGroup="footerData"></asp:CustomValidator>
                                                            <asp:CustomValidator ID="cvValidProjectTimeFooter1" runat="server" ControlToValidate="ddlEndTimeHourFooter"
                                                                Display="Dynamic" EnableViewState="False" ErrorMessage="Project Time must be greater than zero."
                                                                OnServerValidate="cvValidProjectTimeFooter_ServerValidate" SkinID="Validator"
                                                                ValidationGroup="footerData"></asp:CustomValidator>
                                                            <asp:CustomValidator ID="cvValidEndTimeFooter" runat="server" 
                                                                ControlToValidate="ddlEndTimeHourFooter" Display="Dynamic" 
                                                                EnableViewState="False" 
                                                                ErrorMessage="Please provide a valid Time. (provide Hours : Minutes)" 
                                                                onservervalidate="cvValidEndTimeFooter_ServerValidate" SkinID="Validator" 
                                                                ValidateEmptyText="True" ValidationGroup="footerValidData"></asp:CustomValidator>
                                                        </td>
                                                        <td>
                                                            <asp:CustomValidator ID="cvValidProjectTimeFooter" runat="server" 
                                                                ControlToValidate="ddlLunchFooter" Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Project Time must be greater than zero." 
                                                                OnServerValidate="cvValidProjectTimeFooter_ServerValidate" SkinID="Validator" 
                                                                ValidationGroup="footerData"></asp:CustomValidator>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td colspan="6">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblTypeOfWorkFunctionFooter" runat="server" SkinID="Label" Text="Type of Work - Function"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblJobClassTypeFooter" runat="server" SkinID="Label" Text="Job Class"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblUnitFooter" runat="server" SkinID="Label" Text="Unit"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblTowedFooter" runat="server" SkinID="Label" Text="Towed"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <%--<asp:Label ID="lblMealsAllowanceFooter" runat="server" SkinID="Label" Text="Meals Allowance"></asp:Label>--%>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:DropDownList ID="ddlTypeOfWorkFooter" runat="server" 
                                                                DataSourceID="odsWorkFunctionConcat" DataTextField="WorkFunctionConcat" 
                                                                DataValueField="WorkFunctionConcat" SkinID="DropDownList" Style="width: 230px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlJobClassTypeFooter" runat="server" 
                                                                DataSourceID="odsJobClassType" DataTextField="JobClassType" 
                                                                DataValueField="JobClassType" EnableViewState="True" 
                                                                SkinID="DropDownListLookup" Style="width: 115px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlUnitFooter" runat="server" DataSourceID="odsUnit" 
                                                                DataTextField="UnitCode" DataValueField="UnitID" SkinID="DropDownList" 
                                                                Style="width: 100px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:DropDownList ID="ddlTowedFooter" runat="server" DataSourceID="odsTowed" 
                                                                DataTextField="UnitCode" DataValueField="UnitID" SkinID="DropDownList" 
                                                                Style="width: 100px">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <%--<asp:CheckBox ID="ckbxMealsAllowanceFooter" runat="server" SkinID="CheckBox" 
                                                                Style="width: 85px" />--%>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td colspan="2">
                                                            <asp:CustomValidator ID="cvTypeOfWorkFunctionDeleteFooter" runat="server" 
                                                                ControlToValidate="ddlTypeOfWorkFooter" Display="Dynamic" 
                                                                EnableViewState="False" ErrorMessage="Please delete type of work - function." 
                                                                OnServerValidate="cvTypeOfWorkFunctionDeleteFooter_ServerValidate" 
                                                                SkinID="Validator" ValidationGroup="footerData"></asp:CustomValidator>
                                                            <asp:CustomValidator ID="cvProvideTypeOfWorkFunctionFooter" runat="server" 
                                                                ControlToValidate="ddlTypeOfWorkFooter" Display="Dynamic" 
                                                                EnableViewState="False" ErrorMessage="Please select a type of work - function." 
                                                                OnServerValidate="cvProvideTypeOfWorkFunctionFooter_ServerValidate" 
                                                                SkinID="Validator" ValidationGroup="footerData"></asp:CustomValidator>
                                                        </td>
                                                        <td>
                                                            <asp:CustomValidator ID="cvJobClassTypeFooter" runat="server" 
                                                                ControlToValidate="ddlJobClassTypeFooter" Display="Dynamic" 
                                                                EnableViewState="False" ErrorMessage="Please select a job class." 
                                                                OnServerValidate="cvJobClassTypeFooter_ServerValidate" 
                                                                SkinID="Validator" ValidationGroup="footerData"></asp:CustomValidator>
                                                            <asp:CustomValidator ID="cvJobClassEmptyFooter" runat="server" 
                                                                ControlToValidate="ddlJobClassTypeFooter" Display="Dynamic" 
                                                                EnableViewState="False" 
                                                                ErrorMessage="Please define a valid job class on Team Members module." 
                                                                OnServerValidate="cvJobClassEmptyFooter_ServerValidate" SkinID="Validator" 
                                                                ValidateEmptyText="True" ValidationGroup="footerData"></asp:CustomValidator>
                                                        </td>
                                                        <td>
                                                            <asp:CustomValidator ID="cvUnitDeleteFooter" runat="server" 
                                                                ControlToValidate="ddlUnitFooter" Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Please delete unit." 
                                                                OnServerValidate="cvUnitDeleteFooter_ServerValidate" SkinID="Validator" 
                                                                ValidationGroup="footerData"></asp:CustomValidator>
                                                        </td>
                                                        <td>
                                                            <asp:CustomValidator ID="cvTowedDeleteFooter" runat="server" 
                                                                ControlToValidate="ddlTowedFooter" Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Please delete towed." 
                                                                OnServerValidate="cvTowedDeleteFooter_ServerValidate" SkinID="Validator" 
                                                                ValidationGroup="footerData"></asp:CustomValidator>
                                                        </td>
                                                        <td>
                                                            <%--<asp:CustomValidator ID="cvValidMealsCountryFooter" runat="server" 
                                                                Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="You checked a meals allowance but not selected a meals country; please select a meals country." 
                                                                OnServerValidate="cvValidMealsCountryFooter_ServerValidate" SkinID="Validator" 
                                                                ValidationGroup="footerData">
                                                            </asp:CustomValidator>
                                                            <asp:CustomValidator ID="cvAlreadyRegisteredMealsAllowanceFooter" 
                                                                runat="server" Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="You already registered meals allowance on this day." 
                                                                OnServerValidate="cvAlreadyRegisteredMealsAllowanceFooter_ServerValidate" 
                                                                SkinID="Validator" ValidationGroup="footerData">
                                                            </asp:CustomValidator>
                                                            <asp:CustomValidator ID="cvDuplicateMealsAllowanceFooter" runat="server" 
                                                                Display="Dynamic" EnableViewState="False" 
                                                                ErrorMessage="Duplicated meals allowance." 
                                                                OnServerValidate="cvDuplicateMealsAllowanceFooter_ServerValidate" 
                                                                SkinID="Validator" ValidationGroup="footerData">
                                                            </asp:CustomValidator>--%>
                                                        </td>
                                                        <td></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td colspan="6">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="6">
                                                            <asp:Label ID="lblNewComments" runat="server" SkinID="Label" Text="Comments"></asp:Label></td>
                                                        <td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="6">
                                                            <asp:TextBox ID="tbxCommentsFooter" runat="server" SkinID="TextBoxMemo" Text='<%# Eval("Comments") %>'
                                                                Width="680px" Rows="1"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td></td>
                                                        <td colspan="6">
                                                            <asp:CustomValidator ID="cvValidDateFooter" runat="server" Display="Dynamic"
                                                               EnableViewState="False" ErrorMessage="You cannot add time in that date." OnServerValidate="cvValidDateFooter_ServerValidate"
                                                               SkinID="Validator" ValidationGroup="footerData"></asp:CustomValidator>
                                                            <asp:CustomValidator ID="cvValidTimesFooter" runat="server" Display="Dynamic"
                                                               EnableViewState="False" ErrorMessage="This start time or end time is overlapping an existent project time, please review you data." OnServerValidate="cvValidTimesFooter_ServerValidate"
                                                               SkinID="Validator" ValidationGroup="footerData"></asp:CustomValidator>   
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 12px">
                                                        </td>
                                                        <td colspan="6">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </FooterTemplate>
                                        <HeaderStyle Width="700px"></HeaderStyle>
                                        <ItemTemplate>
                                            <!-- Page element : 8 columns - Data -->
                                            <table style="width: 700px" cellspacing="0" cellpadding="0" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 10px; height: 12px">
                                                        </td>
                                                        <td style="width: 120px;">
                                                        </td>
                                                        <td style="width: 120px">
                                                        </td>
                                                        <td style="width: 125px">
                                                        </td>
                                                        <td style="width: 110px">
                                                        </td>
                                                        <td style="width: 110px">
                                                        </td>
                                                        <td style="width: 95px">
                                                        </td>
                                                        <td style="width: 10px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblStartTime" runat="server" SkinID="Label" Text="Start Time"></asp:Label></td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblEndTime" runat="server" SkinID="Label" Text="End Time"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td >
                                                            <asp:Label ID="lblLuch" runat="server" SkinID="Label" Text="Lunch"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="tbxStartTime" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("StartTime") %>'
                                                                Width="230px" ReadOnly="True"></asp:TextBox></td>
                                                        <td colspan="2">
                                                            <asp:TextBox ID="tbxEndTime" runat="server" ReadOnly="True" 
                                                                SkinID="TextBoxReadOnly" Text='<%# Eval("EndTime") %>' Width="225px"></asp:TextBox>
                                                        </td>
                                                        <td colspan="1">
                                                            <asp:TextBox ID="tbxLunch" runat="server" ReadOnly="True" 
                                                                SkinID="TextBoxReadOnly" Text='<%# Eval("Offset", "{0:n2}") %>' Width="100px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td colspan="6">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="2">
                                                            <asp:Label ID="lblTypeOfWorkFunction" runat="server" SkinID="Label" Text="Type of Work - Function"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblJobClassType" runat="server" SkinID="Label" Text="Job Class"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblUnit" runat="server" SkinID="Label" Text="Unit"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="lblTowed" runat="server" SkinID="Label" Text="Towed"></asp:Label>
                                                        </td>
                                                        <td>
                                                            <%--<asp:Label ID="lblMealsAllowance" runat="server" SkinID="Label" Text="Meals Allowance"></asp:Label>--%>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="2">
                                                            <!-- Page element: UpdatePanel -->
                                                            <asp:TextBox ID="tbxTypeOfWorkFunction" runat="server" ReadOnly="True" 
                                                                SkinID="TextBoxSmallReadOnly" Text='<%# Eval("WorkFunctionConcat") %>' 
                                                                Width="230px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:UpdatePanel ID="upnlJobClassType" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>
                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                    <asp:TextBox ID="tbxJobClassType" runat="server" ReadOnly="True" 
                                                                                        SkinID="TextBoxReadOnly" Text='<%# Eval("JobClassType") %>' Width="100px"></asp:TextBox>
                                                                                </td>
                                                                                <td style="vertical-align: middle">
                                                                                    <asp:UpdateProgress ID="upJobClassType" runat="server" 
                                                                                        AssociatedUpdatePanelID="upnlProject">
                                                                                        <ProgressTemplate>
                                                                                            <img height="16" src="../../common/images/ajax1.gif" width="16" />
                                                                                        </ProgressTemplate>
                                                                                    </asp:UpdateProgress>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:AsyncPostBackTrigger ControlID="ddlProject" EventName="SelectedIndexChanged" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxUnit" runat="server" ReadOnly="True" 
                                                                SkinID="TextBoxReadOnly" Text='<%# GetUnitCode(Eval("UnitID")) %>' 
                                                                Width="100px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="tbxTowed" runat="server" ReadOnly="True" 
                                                                SkinID="TextBoxReadOnly" Text='<%# GetUnitCode(Eval("TowedUnitID")) %>' 
                                                                Width="100px"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <%--<asp:CheckBox ID="ckbxMealsAllowance" runat="server" 
                                                                Checked='<%# Eval("IsMealsAllowance") %>' Enabled="false" 
                                                                onclick="return cbxClick();" SkinID="CheckBox" Width="85px" />--%>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 7px">
                                                        </td>
                                                        <td colspan="6">
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="6">
                                                            <asp:Label ID="lblComments" runat="server" SkinID="Label" Text="Comments"></asp:Label>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td colspan="6">
                                                            <asp:TextBox ID="tbxComments" runat="server" SkinID="TextBoxReadOnly" Text='<%# Eval("Comments") %>'
                                                                Width="680px" ReadOnly="True" TextMode="MultiLine" Rows="4"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 12px">
                                                        </td>
                                                        <td colspan="6">
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
                                                            <asp:ImageButton ID="ibtnAccept" runat="server" SkinID="GridView_Update" CommandName="Update" OnClientClick='return confirmEdit();'></asp:ImageButton>
                                                        </td>
                                                        <td style="width: 50%">
                                                            <asp:ImageButton ID="ibtnCancel" runat="server" SkinID="GridView_Cancel" CommandName="Cancel"></asp:ImageButton>
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
                                                            <asp:ImageButton ID="ibtnAdd" runat="server" SkinID="GridView_Add" CommandName="Add Range" OnClientClick='return confirmAdd();'></asp:ImageButton>
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
                                                            <asp:ImageButton ID="ibtnEdit" runat="server" SkinID="GridView_Edit" CommandName="Edit"></asp:ImageButton>
                                                        </td>
                                                        <td style="width: 50%">
                                                            <asp:ImageButton ID="ibtnDelete" runat="server" SkinID="GridView_Delete" 
                                                                CommandName="Delete" OnClientClick='return confirm("Are you sure you want to delete this project time?");'>
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
                </td>
            </tr>            
            <tr>
                <td style="height:60px">
                </td>
            </tr> 
        </table>
        
                
        <table>
            <tr>
                <td>
                    <asp:HiddenField ID="hdfEmployeeID" runat="server" />
                    <asp:HiddenField ID="hdfProjectTimeID" runat="server" />
                    <asp:HiddenField ID="hdfCompaniesID" runat="server" EnableViewState="true" />
                    <asp:HiddenField ID="hdfProjectID" runat="server" />
                    <asp:HiddenField ID="hdfStartTime" runat="server" />
                    <asp:HiddenField ID="hdfEndTime" runat="server" />
                    <asp:HiddenField ID="hdfOffset" runat="server" />
                    <asp:HiddenField ID="hdfLocation" runat="server" />
                    <asp:HiddenField ID="hdfMealsCountry" runat="server" />
                    <asp:HiddenField ID="hdfMealsAllowance" runat="server" />
                    <asp:HiddenField ID="hdfProjectTimeState" runat="server" />
                    <asp:HiddenField ID="hdfClearUnitAssigment" runat="server" />
                    <asp:HiddenField ID="hdfDate" runat="server" />
                    <asp:HiddenField ID="hdfWork_" runat="server" />
                    <asp:HiddenField ID="hdfFunction_" runat="server" />
                    <asp:HiddenField ID="hdfWorkFunctionConcat" runat="server" />
                    <asp:HiddenField ID="hdfSaveClick" runat="server" />
                    <asp:HiddenField ID="hdfPeriodId" runat="server" />
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />                    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:UpdatePanel ID="upIsMoreThan15" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:HiddenField ID="hdfIsMoreThan15" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="upIsMoreThan15Edit" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:HiddenField ID="hdfIsMoreThan15Edit" runat="server" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        
        
        <!-- Page element: DataObjects -->
        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%;">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsProjectTime" runat="server" SelectMethod="GetProjectTime"
                        TypeName="LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.timesheet_add" DeleteMethod="DummyProjectTimeNew"
                        FilterExpression="(Deleted = 0)" UpdateMethod="DummyProjectTimeNew" InsertMethod="DummyProjectTimeNew"
                        OldValuesParameterFormatString="original_{0}">
                        <DeleteParameters>
                            <asp:Parameter Name="ProjectTimeID" Type="Int32" />
                        </DeleteParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="ProjectTimeID" Type="Int32" />
                        </UpdateParameters>
                        <InsertParameters>
                            <asp:Parameter Name="ProjectTimeID" Type="Int32" />
                        </InsertParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsTimeInterval" runat="server" SelectMethod="GetTimeInterval"
                        TypeName="LiquiForce.LFSLive.Tools.Time" EnableCaching="True">
                    </asp:ObjectDataSource>

                    <asp:ObjectDataSource ID="odsWorkFunctionConcat" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.LabourHours.TeamProjectTime.TeamProjectTimeWorkFunctionConcatList" CacheDuration="60" EnableCaching="True">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select)" Name="workFunctionConcat" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>

                    <asp:ObjectDataSource ID="odsTowed" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.FleetManagement.Units.UnitsList" CacheDuration="60" EnableCaching="True">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="unitId" Type="String" />
                            <asp:Parameter DefaultValue="" Name="unitCode" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="true" Name="isWithUnitCode" Type="Boolean" />
                            <asp:Parameter DefaultValue="1" Name="isTowable" Type="Int32" />
                            <asp:Parameter DefaultValue="Vehicle" Name="type" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    
                    <asp:ObjectDataSource ID="odsUnit" runat="server" SelectMethod="LoadAndAddItem" 
                        TypeName="LiquiForce.LFSLive.BL.FleetManagement.Units.UnitsList" CacheDuration="60" EnableCaching="True">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="unitId" Type="String" />
                            <asp:Parameter DefaultValue="" Name="unitCode" Type="String" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                            <asp:Parameter DefaultValue="true" Name="isWithUnitCode" Type="Boolean" />
                            <asp:Parameter DefaultValue="0" Name="isTowable" Type="Int32" />
                            <asp:Parameter DefaultValue="Vehicle" Name="type" Type="String" />
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

                    <asp:ObjectDataSource ID="odsWorkingDetails" runat="server" SelectMethod="LoadActiveAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.LabourHours.ProjectTime.WorkingDetails" OldValuesParameterFormatString="original_{0}"
                        EnableCaching="True">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="(Select)" Name="workingDetails" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>