<%@ Page Title="LFS Live" Language="C#" MasterPageFile="../../mForm6.master" AutoEventWireup="true" CodeBehind="timesheet_approve.aspx.cs" Inherits="LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.timesheet_approve" %>
    
<asp:Content ID="Content3" ContentPlaceHolderID="TitlePlaceHolder" runat="server">
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 100%;">
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblTitle" runat="server" SkinID="LabelPageTitle1" Text="Project Times for Approval"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 2px">
                </td>
            </tr>
        </table>
    </div>
</asp:Content>



<asp:Content ID="Content4" ContentPlaceHolderID="ToolbarPlaceHolder" runat="server">
    <!-- TOOLBAR -->
    <div style="width: 750px">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
            <tr>
                <td>
                    <telerik:RadMenu ID="tkrmTop" SkinID="RadMenu" runat="server" OnItemClick="tkrmTop_ItemClick">                        
                        <Items>
                            <telerik:RadMenuItem Value="mApprove" Text="APPROVE" />
                            
                            <telerik:RadMenuItem Value="mCancel" Text="CANCEL" />
                        </Items>
                    </telerik:RadMenu>
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
                                    <telerik:RadPanelItem runat="server" Value="nbTimesheetsToolsApproveProjectTimes" Text="Approve Project Times" Selected="true" PostBack="false" ></telerik:RadPanelItem>
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



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <!-- CONTENT -->
    <div style="width: 750px">
        <table cellpadding="0" cellspacing="0" border="0" style="width: 750px;">
            <tr>
                <%--<td style="width: 110px;">
                </td>--%>
                <td style="width: 170px;">                    
                </td>
                <td style="width: 170px;">
                </td>
                <td style="width: 410px;">                    
                </td>
            </tr>
             <tr>
                <%--<td>
                    <asp:Label ID="lblWorkingLocation" runat="server" SkinID="Label" Text="Working Location" EnableViewState="False"></asp:Label>
                </td>--%> 
                <td>
                    <asp:Label ID="lblClient" runat="server" SkinID="Label" Text="Client" EnableViewState="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblProject" runat="server" SkinID="Label" Text="Project" EnableViewState="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblTeamMember" runat="server" SkinID="Label" Text="Team Member" EnableViewState="False"></asp:Label>
                </td> 
            </tr>
            <tr>
                <%--<td>
                    <asp:UpdatePanel ID="upnlCountry" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" DataMember="DefaultView"
                                DataSourceID="odsCountry" DataTextField="Name" DataValueField="CountryID" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged"
                                SkinID="DropDownList" Width="100px">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>--%>
                <td>
                    <asp:UpdatePanel ID="upnlClient" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="width: 160px">
                                            <asp:DropDownList ID="ddlClient" runat="server" AutoPostBack="True" DataMember="DefaultView"
                                                DataSourceID="odsClient" DataTextField="NAME" DataValueField="COMPANIES_ID" OnSelectedIndexChanged="ddlClient_SelectedIndexChanged"
                                                SkinID="DropDownListLookup" Width="160px">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                        <%--<Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlCountry" EventName="SelectedIndexChanged">
                            </asp:AsyncPostBackTrigger>
                        </Triggers>--%>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="upnlProject" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tbody>
                                    <tr>
                                        <td style="width: 160px">
                                            <asp:DropDownList ID="ddlProject" runat="server" AutoPostBack="True" DataMember="DefaultView"  
                                                DataSourceID="odsProject" DataTextField="NAME" DataValueField="ProjectID" OnSelectedIndexChanged="ddlProject_SelectedIndexChanged"
                                                SkinID="DropDownListLookup" Width="140px" >
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
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlClient" EventName="SelectedIndexChanged">
                            </asp:AsyncPostBackTrigger>
                        </Triggers>
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="upnlTeamMember" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:DropDownList ID="ddlTeamMember" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTeamMember_SelectedIndexChanged"
                                SkinID="DropDownList" Width="400px">
                            </asp:DropDownList>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>     
             <tr>                
                <td>
                    <asp:Label ID="lblStartDate" runat="server" SkinID="Label" Text="Start Date" EnableViewState="False"></asp:Label>
                </td>
                <td>
                    <asp:Label ID="lblEndDate" runat="server" SkinID="Label" Text="End Date" EnableViewState="False"></asp:Label>
                </td>
            </tr>
            <tr>                
                <td>
                    <asp:UpdatePanel ID="upnlStartDate" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <telerik:RadDatePicker ID="tkrdpStartDate" runat="server" AutoPostBack="true"
                                Width="160px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" 
                                Calendar-DayNameFormat="Short" onselecteddatechanged="tkrdpStartDate_SelectedDateChanged">
                            </telerik:RadDatePicker>
                       </ContentTemplate>                        
                    </asp:UpdatePanel>
                </td>
                <td>
                    <asp:UpdatePanel ID="upnlEndDate" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <telerik:RadDatePicker ID="tkrdpEndDate" runat="server" AutoPostBack="true"
                                Width="140px" SkinID="RadDatePicker" Calendar-ShowRowHeaders="false" 
                                Calendar-DayNameFormat="Short" onselecteddatechanged="tkrdpEndDate_SelectedDateChanged">
                            </telerik:RadDatePicker>
                       </ContentTemplate>                        
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td colspan="3" style="height: 10px;">
                </td>
            </tr>
        </table>
        
        <!-- Page element: grid -->
        <table border="0" cellpadding="0" cellspacing="0" style="width: 745px;">            
            <tr>
                <td style="height: 10px;"></td>                                        
            </tr>
            <tr style="text-align: left">                  
                <td>
                    <table border="0" cellpadding="0" cellspacing="0">                        
                        <tr>
                            <td>
                                <asp:Button ID="btnOpen" runat="server" SkinID="Button" Text="Open" Width="100px"
                                    EnableViewState="False" OnClick="btnOpen_Click" />
                            </td>
                            <td style="width:25px">
                            </td>
                            <td>
                                <asp:Button ID="btnEdit" runat="server" SkinID="Button" Text="Edit" Width="100px"
                                    EnableViewState="False" OnClick="btnEdit_Click" />
                            </td>
                            <td style="width:25px">
                            </td>
                            <td>
                                <asp:Button ID="btnDelete" runat="server" SkinID="ButtonRedText" Text="Delete" Width="100px"
                                    EnableViewState="False" OnClick="btnDelete_Click" />
                            </td>
                        </tr>                        
                    </table>
                </td>                
                             
            </tr>
            <tr>
                <td style="height: 10px;"></td>                                      
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblError" runat="server" EnableViewState="False" SkinID="LabelError"
                        Text="At least one project time must be selected.">
                    </asp:Label>
                    <asp:UpdatePanel id="upnlProgress" runat="server">
                        <contenttemplate>                            
                            <asp:UpdateProgress ID="upProjectTimeApprove" runat="server" AssociatedUpdatePanelID="upnlProjectTimeApprove">
                                <ProgressTemplate>
                                    <img src="./../../common/images/ajax1.gif" width="16" height="16" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </contenttemplate>                    
                    </asp:UpdatePanel>
                </td>
            </tr>
            <tr>
                <td>
                    <!--<asp:Panel ID="pnlProjectTimeApprove" runat="server" Height="600px" Width="100%" ScrollBars="Auto">  onscroll="$get('hdnScrollTop').value = this.scrollTop;"  -->
                        <asp:UpdatePanel id="upnlProjectTimeApprove" runat="server">
                            <contenttemplate>
                                <asp:HiddenField ID="hdfScrollTop" runat="server" Value="0" />
                                <div id="divScroll" runat="server" style="width:99%;height:600px; overflow-x:scroll; overflow-y:scroll;" onscroll="return divScrollClick(this);" >
                                <asp:GridView id="grdProjectTimeApprove" runat="server" SkinID="GridView" Width="98%" 
                                    DataKeyNames="ProjectTimeID" DataSourceID="odsProjectTimeApprove" OnRowDataBound="grdProjectTimeApprove_RowDataBound" 
                                    OnDataBound="grdProjectTimeApprove_DataBound" AutoGenerateColumns="False">
                                    <Columns>
                                    
                                        <asp:TemplateField ShowHeader="False" Visible="False">
                                            <ItemStyle horizontalalign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                  <asp:Label ID="lblProjectTimeID" runat="server" SkinID="Label" Text='<%# Bind("ProjectTimeID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField ShowHeader="False" Visible="False">
                                            <ItemStyle horizontalalign="Center"></ItemStyle>
                                            <ItemTemplate>
                                                  <asp:Label ID="lblEmployeeID" runat="server" SkinID="Label" Text='<%# Bind("EmployeeID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField ShowHeader="False">
                                            <ItemStyle horizontalalign="Center"></ItemStyle>                                            
                                            <ItemTemplate>
                                                <asp:CheckBox ID="cbxSelected" runat="server" onclick="return cbxSelectedClick(this);" Checked='<%# Eval("Selected") %>' />
                                            </ItemTemplate>
                                            <HeaderStyle width="30px"></HeaderStyle>
                                            <HeaderTemplate>
                                                <input id="cbxCheckAll" onclick="return cbxCheckAllClick(this);" runat="server" type="checkbox" />
                                            </HeaderTemplate>
                                        </asp:TemplateField>
                                    
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemStyle horizontalalign="Center"></ItemStyle>
                                            <HeaderStyle width="120px"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblDate" runat="server" SkinID="Label" Text='<%# Bind("Date","{0:d}") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                        
                                        
                                        <asp:TemplateField HeaderText="Team Member">
                                            <ItemStyle horizontalalign="Left"></ItemStyle>
                                            <HeaderStyle Width="350px" ></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblTeamMember" runat="server" SkinID="Label" Text='<%# Bind("TeamMember") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Job Class">
                                            <ItemStyle horizontalalign="Left"></ItemStyle>
                                            <HeaderStyle Width="350px" ></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblJobClass" runat="server" SkinID="Label" Text='<%# Bind("JobClass") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Client">
                                            <ItemStyle horizontalalign="Left"></ItemStyle>
                                            <HeaderStyle Width="350px" ></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblClient" runat="server" SkinID="Label" Text='<%# Bind("Client") %>'></asp:Label>
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
                                        
                                        <asp:TemplateField HeaderText="Type Of Work">
                                            <HeaderStyle width="100px"></HeaderStyle>
                                            <ItemStyle horizontalalign="Left"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblTypeOfWork" runat="server" SkinID="Label" Text='<%# Bind("TypeOfWork") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Function">
                                            <HeaderStyle width="90px"></HeaderStyle>
                                            <ItemStyle horizontalalign="Left"></ItemStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblFunction" runat="server" SkinID="Label" Text='<%# Bind("Function_") %>'></asp:Label>
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
                                        
                                        <asp:TemplateField HeaderText="State">
                                            <HeaderStyle width="70px"></HeaderStyle>
                                            <ItemTemplate>
                                                <asp:Label ID="lblState" runat="server" SkinID="Label" Text='<%# Bind("State") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                </asp:GridView>
                                </div>
                            </contenttemplate>
                        </asp:UpdatePanel>
                    <!--</asp:Panel>-->
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
                    <asp:ObjectDataSource ID="odsProjectTimeApprove" runat="server" SelectMethod="GetProjectTimeApprove"
                        TypeName="LiquiForce.LFSLive.WebUI.LabourHours.ProjectTime.timesheet_approve">
                    </asp:ObjectDataSource>                       
                    <asp:ObjectDataSource ID="odsCountry" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Company.Organization.CountryList" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="countryId" Type="Int32" />
                            <asp:Parameter DefaultValue="(All)" Name="name" Type="String" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsClient" runat="server" SelectMethod="LoadAndAddItemByCountryId"
                        TypeName="LiquiForce.LFSLive.BL.Resources.Companies.CompaniesList" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="companiesId" Type="Int32" />
                            <asp:Parameter DefaultValue="(All)" Name="name" Type="String" />
                            <asp:Parameter DefaultValue="-1" Name="countryId" Type="Int32" />
                            <asp:SessionParameter Name="companyId" SessionField="companyID" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsProject" runat="server" SelectMethod="LoadAndAddItem"
                        TypeName="LiquiForce.LFSLive.BL.Projects.Projects.ProjectList" OldValuesParameterFormatString="original_{0}">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="-1" Name="projectId" Type="Int32" />
                            <asp:Parameter DefaultValue="(All)" Name="name" Type="String" />
                            <asp:Parameter DefaultValue="-1" Name="clientId" Type="Int32" />
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
                    <asp:HiddenField ID="hdfCurrentEmployeeId" runat="server" />
                    <asp:HiddenField ID="hdfSelectedEmployeeId" runat="server" />
                    <asp:HiddenField ID="hdfSelectedProjectTimeId" runat="server" />
                    <asp:HiddenField ID="hdfSelectedPeriodId" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    
    
  
</asp:Content>