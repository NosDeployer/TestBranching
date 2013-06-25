<%@ Page Language="C#" MasterPageFile="./../../mForm6.master" AutoEventWireup="true" Codebehind="timesheet.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.Timesheet.timesheet" Title="LFS Live" %>
     
<asp:Content ID="Content4" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" SkinID="LabelPageTitle1" Text="Current Timesheet For"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:CustomValidator ID="CustomValidator1" runat="server" Display="Dynamic" ErrorMessage="Your user account is not associated with an entry in the eCRM address book, please associate it, or contact the system administrator for further assistance."
                        OnServerValidate="cvTitle_ServerValidate" SkinID="Validator" EnableViewState="False"></asp:CustomValidator>
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
                            <telerik:RadMenuItem Value="mAddProjectTime" Text="ADD PROJECT TIME" />
                            
                            <telerik:RadMenuItem Value="mApproveTimesheet" Text="APPROVE TIMESHEETS" />
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
        <!-- Page element: grid -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:Label ID="lblError" runat="server" EnableViewState="False" SkinID="LabelError" Text="At least one project time must be selected"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="pnlgrdTimesheet" runat="server" Height="330px" Width="609px"
                        ScrollBars="Auto" BorderWidth="1px">
                        <asp:UpdatePanel id="upnlgrdTimesheet" runat="server">
                            <contenttemplate>
                                <asp:GridView id="grdTimesheet" runat="server" SkinID="GridView" Width="100%" 
                                DataKeyNames="ProjectTimeID" DataSourceID="odsTimesheets" 
                                OnDataBound="grdTimesheet_DataBound" PageSize="12" AutoGenerateColumns="False">
                                    <Columns>
                                                                              
                                        <asp:TemplateField ShowHeader="False" Visible="False">
                                            <ItemStyle horizontalalign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                  <asp:Label ID="lblProjectTimeID" runat="server" SkinID="Label" Text='<%# Bind("ProjectTimeID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                      
                                        
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemStyle horizontalalign="Center"></ItemStyle>
                                            <HeaderStyle width="30px"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbxSelected" runat="server" onclick="return cbxSelectedClick(this);" Checked='<%# Eval("Selected") %>' />
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <input id="cbxCheckAll" onclick="return cbxCheckAllClick(this);" runat="server" type="checkbox" />
                                            </HeaderTemplate>
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemStyle horizontalalign="Center"></ItemStyle>
                                            <HeaderStyle Width="60px" ></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDate" runat="server" SkinID="Label" Text='<%# Bind("Date_","{0:d}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                                                                
                                        <asp:TemplateField HeaderText="Name" >
                                            <ItemStyle horizontalalign="Left"></ItemStyle>
                                            <HeaderStyle width="120px"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblClientName" runat="server" SkinID="Label" Text='<%# Bind("ClientName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                                                                
                                        <asp:TemplateField HeaderText="Project Number">
                                            <HeaderStyle width="90px"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblProjectNumber" runat="server" SkinID="Label" Text='<%# Bind("ProjectNumber") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Project Name">
                                            <HeaderStyle width="160px"></HeaderStyle>
                                            <ItemStyle horizontalalign="Left"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblProjectName" runat="server" SkinID="Label" Text='<%# Bind("ProjectName") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="State">
                                            <HeaderStyle width="70px"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblState" runat="server" SkinID="Label" Text='<%# Bind("State") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                                              
                                        <asp:TemplateField HeaderText="Start">
                                            <HeaderStyle width="70px"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblStartTime" runat="server" SkinID="Label" Text='<%# Bind("StartTime", "{0:H:mm}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                                                                
                                        <asp:TemplateField HeaderText="End">
                                            <HeaderStyle width="70px"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblEndTime" runat="server" SkinID="Label" Text='<%# Bind("EndTime", "{0:H:mm}") %>'></asp:Label>
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
                                <asp:Button ID="btnPriorTimesheet" runat="server" SkinID="Button" Text="Prior Timesheet"
                                    Width="100px" EnableViewState="False" OnClick="btnPriorTimesheet_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnNexTimesheet" runat="server" SkinID="Button" Text="Next Timesheet"
                                    Width="100px" EnableViewState="False" OnClick="btnNextTimesheet_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <!-- Page element : Horizontal Rule -->
                        <tr>
                            <td>
                                <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; text-align: center">
                                    <tr>
                                        <td style="width: 22px">
                                        </td>
                                        <td style="height: 10px; width: 80px">
                                        </td>
                                        <td style="width: 23px">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td style="height: 1px" class="Background_Separator">
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                        </td>
                                        <td style="height: 10px">
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
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
                        <tr>
                            <td>
                                <asp:Button ID="btnEdit" runat="server" SkinID="Button" Text="Edit" Width="100px"
                                    EnableViewState="False" OnClick="btnEdit_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="btnDelete" runat="server" SkinID="ButtonRedText" Text="Delete" Width="100px"
                                    EnableViewState="False" OnClick="btnDelete_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 7px">
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td >                    
                    <table cellpadding="0" cellspacing="0" border="0" style="width: 609px" >
                        <tr>                                               
                            <td style="width: 30px;">
                            </td>
                            <td style="width: 60px">
                            </td>
                            <td style="width: 100px">
                            </td>
                            <td style="width: 90px">
                            </td>
                            <td style="width: 149px">
                            </td>
                            <td style="width: 60px">
                            </td>
                            <td style="width: 55px; text-align: right;">
                                <asp:Label ID="Label1" runat="server" SkinID="Label" Text="Total:"></asp:Label></td>
                            <td style="width: 65px; text-align: right;">
                                <asp:UpdatePanel id="upnlTotalCost" runat="server">
                                    <contenttemplate>
                                        <asp:TextBox id="tbxTotalCost" tabIndex=-1 runat="server" SkinID="TextBoxRightReadOnly" Width="100%" ReadOnly="True" CssClass="Background_ViewGrid_TotalFooter"></asp:TextBox> 
                                    </contenttemplate>
                                </asp:UpdatePanel>        
                            </td>
                        </tr>
                    </table>
                </td>
                <td>
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
                        TypeName="LiquiForce.LFSLive.WebUI.LabourHours.Timesheet.timesheet"></asp:ObjectDataSource>                                                               
                </td>
            </tr>
        </table>
        
        
        <!-- Page element : Tag page -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <asp:HiddenField ID="hdfCompanyId" runat="server" />
                    <asp:HiddenField ID="hdfSelectedProjectTimeId" runat="server" />
                    <asp:HiddenField ID="hdfLoginId" runat="server" />
                    &nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>