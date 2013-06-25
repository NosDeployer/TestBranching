<%@ Page Language="C#" MasterPageFile="../../mForm6.master" AutoEventWireup="true" Codebehind="timesheet_summary.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.timesheet_summary" Title="LFS Live" %>
    
<asp:Content ID="Content4" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" SkinID="LabelPageTitle1" Text="Project Time Summary" EnableViewState="False"></asp:Label>
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
                    <telerik:RadPanelBar ID="tkrpbLeftMenuOthersTimesheets" runat="server" SkinID="RadPanelBar" Width="180px" OnItemClick="tkrpbLeftMenu_ItemClick">
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
                            <telerik:RadMenuItem Value="mAdd" Text="ADD" />
                            
                            <telerik:RadMenuItem Value="mEdit" Text="EDIT" />
                            
                            <telerik:RadMenuItem Value="mDelete" Text="DELETE" />
                            
                            <telerik:RadMenuItem Value="mTimesheet" Text="TIMESHEET" />
                            
                            <telerik:RadMenuItem Value="mApproveProjectTimes" Text="APPROVE PROJECT TIME" />
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
                    <asp:Label ID="lblTeamMember" runat="server" SkinID="Label" Text="Team Member" EnableViewState="False"></asp:Label>
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
                    <asp:TextBox ID="tbxEmployee" runat="server" ReadOnly="True" SkinID="TextBoxReadOnly" Width="365px" EnableViewState="False"></asp:TextBox>
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
                <td colspan="2">
                    <asp:Label ID="lblClient" runat="server" SkinID="Label" Text="Client" EnableViewState="False"></asp:Label>
                </td>
                <td colspan="2">
                    <asp:Label ID="lblProject" runat="server" SkinID="Label" Text="Project" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:TextBox ID="tbxClient" runat="server" SkinID="TextBoxReadOnly" Text='' Width="365px"
                        ReadOnly="True" EnableViewState="False"></asp:TextBox>
                </td>
                <td colspan="2">
                    <asp:TextBox ID="tbxProject" runat="server" SkinID="TextBoxReadOnly" Text='' Width="365px"
                        ReadOnly="True" EnableViewState="False"></asp:TextBox>
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
                    <asp:Label ID="lblDate" runat="server" EnableViewState="False" SkinID="Label" Text="Date"></asp:Label></td>
                <td>
                    <asp:Label ID="lblWorkingDetails" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Working / Details"></asp:Label></td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxDate" runat="server" SkinID="TextBoxReadOnly" Text='<%# DataBinder.Eval(projectTimeTDS, "Tables[LFS_PROJECT_TIME].DefaultView.[0].Date_", "{0:d}") %>'
                        Width="177px" ReadOnly="True" EnableViewState="False"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="tbxWorkingDetails" runat="server" SkinID="TextBoxReadOnly" Text='<%# DataBinder.Eval(projectTimeTDS, "Tables[LFS_PROJECT_TIME].DefaultView.[0].WorkingDetails") %>'
                        Width="177px" ReadOnly="True" EnableViewState="False"></asp:TextBox></td>
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
                    <asp:Label ID="lblStartTime" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Start Time"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblEndTime" runat="server" EnableViewState="False" SkinID="Label"
                        Text="End Time"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblLunch" runat="server" EnableViewState="False" SkinID="Label" Text="Lunch"></asp:Label>
                </td>
                <td>                    
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxStartTime" runat="server" SkinID="TextBoxReadOnly" Text='<%# DataBinder.Eval(projectTimeTDS, "Tables[LFS_PROJECT_TIME].DefaultView.[0].StartTime", "{0:H:mm}") %>'
                        Width="177px" ReadOnly="True" EnableViewState="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxEndTime" runat="server" SkinID="TextBoxReadOnly" Text='<%# DataBinder.Eval(projectTimeTDS, "Tables[LFS_PROJECT_TIME].DefaultView.[0].EndTime", "{0:H:mm}") %>'
                        Width="177px" ReadOnly="True" EnableViewState="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxLunch" runat="server" SkinID="TextBoxReadOnly" Text='<%# DataBinder.Eval(projectTimeTDS, "Tables[LFS_PROJECT_TIME].DefaultView.[0].Offset", "{0:N}") %>'
                        Width="177px" ReadOnly="True" EnableViewState="False"></asp:TextBox>
                </td>
                <td>
                    <%--<asp:CheckBox ID="cbxFairWage" runat="server" Width="177px" onclick="return cbxClick();" SkinID="CheckBox" EnableViewState="False" Checked='<%# DataBinder.Eval(projectTimeTDS, "Tables[LFS_PROJECT_TIME].DefaultView.[0].FairWage") %>' />--%>
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
                        Text="Type of Work"></asp:Label></td>
                <td>
                    <asp:Label ID="lblFunction" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Function"></asp:Label></td>
                <td>
                    <asp:Label ID="lblJobClassType" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Job Class"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxTypeOfWork" runat="server" EnableViewState="False" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Text='<%# DataBinder.Eval(projectTimeTDS, "Tables[LFS_PROJECT_TIME].DefaultView.[0].StartTime", "{0:t}") %>'
                        Width="177px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="tbxFunction" runat="server" EnableViewState="False" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Text='<%# DataBinder.Eval(projectTimeTDS, "Tables[LFS_PROJECT_TIME].DefaultView.[0].StartTime", "{0:t}") %>'
                        Width="177px"></asp:TextBox></td>
                <td>
                    <asp:TextBox ID="tbxJobClassType" runat="server" EnableViewState="False" ReadOnly="True"
                        SkinID="TextBoxReadOnly" Text='<%# DataBinder.Eval(projectTimeTDS, "Tables[LFS_PROJECT_TIME].DefaultView.[0].JobClassType") %>'
                        Width="177px"></asp:TextBox>
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
                    <asp:Label ID="lblMealsCountry" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Meals country"></asp:Label>
                </td>
                <td>
                    <%--<asp:Label ID="lblMealsAllowance" runat="server" EnableViewState="False" SkinID="Label"
                        Text="Meals allowance"></asp:Label>--%>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxMealsCountry" runat="server" SkinID="TextBoxReadOnly" Text=''
                        Width="177px" ReadOnly="True" EnableViewState="False"></asp:TextBox>
                </td>
                <td>
                    <%--<asp:CheckBox ID="cbxMealsAllowance" runat="server" SkinID="CheckBox" onclick="return cbxClick();"
                        EnableViewState="False" />--%>
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
                    <asp:Label ID="lblUnit" runat="server" EnableViewState="False" SkinID="Label" Text="Unit"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTowed" runat="server" EnableViewState="False" SkinID="Label" Text="Towed"></asp:Label>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox ID="tbxUnit" runat="server" SkinID="TextBoxReadOnly" Text='' Width="177px"
                        ReadOnly="True" EnableViewState="False"></asp:TextBox>
                </td>
                <td>
                    <asp:TextBox ID="tbxTowed" runat="server" SkinID="TextBoxReadOnly" Text='' Width="177px"
                        ReadOnly="True" EnableTheming="True" EnableViewState="False"></asp:TextBox>
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
                <td colspan="4">
                    <asp:Label ID="lblComments" runat="server" SkinID="Label" Text="Comments" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:TextBox ID="tbxComments" runat="server" Height="65px" Text='<%# DataBinder.Eval(projectTimeTDS, "Tables[LFS_PROJECT_TIME].DefaultView.[0].Comments") %>'
                        SkinID="TextBoxReadOnly" TextMode="MultiLine" Width="740px" ReadOnly="True" EnableViewState="False"></asp:TextBox>
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