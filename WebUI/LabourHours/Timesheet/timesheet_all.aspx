<%@ Page Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" Codebehind="timesheet_all.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.Timesheet.timesheet_all" Title="LFS Live" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" SkinID="LabelPageTitle1" Text="All Timesheets For"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 2px">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ToolbarPlaceHolder" runat="server">
    <!-- TOOLBAR -->
    <div style="width: 750px">
    </div>
</asp:Content>


        
<asp:Content ID="Content3" ContentPlaceHolderID="LeftMenuPlaceHolder" runat="server">
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
                            <telerik:RadPanelItem Expanded="True" Value="OthersTimesheets" Text="Others Timesheets" PostBack="false">
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



<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
        <div style="width: 750px">
        <!-- Page element: grid -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblError" runat="server" EnableViewState="False" SkinID="LabelError"
                        Text="At least one timesheet must be selected"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="pnlTimesheetAll" runat="server" Height="350px" Width="609px"
                        ScrollBars="Auto" BorderWidth="1px">
                        <asp:UpdatePanel id="upnlTimesheetAll" runat="server">
                            <contenttemplate>
                                <asp:GridView id="grdTimesheetAll" runat="server" SkinID="GridView" Width="100%" 
                                DataKeyNames="PayPeriodID" DataSourceID="odsTimesheets" 
                                OnDataBound="grdTimesheet_DataBound" PageSize="12" AutoGenerateColumns="False">
                                    <Columns>
                                       
                                       
                                        <asp:TemplateField ShowHeader="False" Visible="False">
                                            <ItemStyle horizontalalign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                  <asp:Label ID="lblPayPeriodID" runat="server" SkinID="Label" Text='<%# Bind("PayPeriodID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       
                                        
                                                                               
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemStyle horizontalalign="Center"></ItemStyle>
                                            <HeaderStyle width="30px"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbxSelected" runat="server" onclick="return cbxSelectedClick(this);" Checked='<%# Eval("Selected") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        
                                        
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemStyle horizontalalign="Left"></ItemStyle>
                                            <HeaderStyle Width="350px" ></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" SkinID="Label" Text='<%# Bind("Name") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        
                                        
                                        <asp:TemplateField HeaderText="Start">
                                            <ItemStyle horizontalalign="Center"></ItemStyle>
                                            <HeaderStyle width="120px"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblStartDate" runat="server" SkinID="Label" Text='<%# Bind("StartDate","{0:d}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        
                                        
                                        <asp:TemplateField HeaderText="End">
                                            <ItemStyle horizontalalign="Center"></ItemStyle>
                                            <HeaderStyle width="120px"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblEndDate" runat="server" SkinID="Label" Text='<%# Bind("EndDate","{0:d}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        
                                        
                                        <asp:TemplateField HeaderText="Time">
                                            <ItemStyle horizontalalign="Right"></ItemStyle>
                                            <HeaderStyle width="60px"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblProjectTime" runat="server" SkinID="Label" Text='<%# Bind("ProjectTime", "{0:n2}") %>' ></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </contenttemplate>
                        </asp:UpdatePanel>
                    </asp:Panel>
                </td>
                <td style="width: 125px; vertical-align: top;">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 125px; text-align: center">                        
                        <tr>
                            <td>
                                <asp:Button ID="btnOpen" runat="server" SkinID="Button" Text="Open" Width="100px"
                                    EnableViewState="False" OnClick="btnOpen_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>           
        </table>
        
        <!-- Page element : Footer separation -->
        <table id="Table1" runat="server" cellpadding="0" cellspacing="0" border="0" style="width: 100%">
            <tr>
                <td style="height: 60px">
                </td>
            </tr>
        </table>
        
        <!-- Page element: Data objects -->
        <table cellpadding="0" cellspacing="0" width="0" style="width: 100%">
            <tr>
                <td>
                    <asp:ObjectDataSource ID="odsTimesheets" runat="server" SelectMethod="GetTimesheets"
                        TypeName="LiquiForce.LFSLive.WebUI.LabourHours.Timesheet.timesheet_all"></asp:ObjectDataSource>                       
                </td>
            </tr>
        </table>
        
        
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfSelectedId" runat="server" />
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
