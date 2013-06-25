<%@ Page language="c#" Codebehind="default.aspx.cs" AutoEventWireup="True" Inherits="LiquiForce.LFSLive.WebUI._default" SmartNavigation="true" %>
    
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >

<html>
	<head runat="server">
		<title>LFS Combined Work Program</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR" />
		<meta content="C#" name="CODE_LANGUAGE" />
		<meta content="JavaScript" name="vs_defaultClientScript" />
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema" />
		<link href="./common/images/lfcss.css" type="text/css" rel="stylesheet" />
		<!-- -------------------- Scripts -------------------- -->
		<script>
			//--- IdLookup
			function IdLookup()
			{
				window.open("./cwp/id_lookup.aspx","_blank","toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width:=550, height:=380");
			}
			
			//--- Reports
			function CXIRemovedReport()
			{
				window.open("./cwp/print.aspx?target_page=viewer.aspx&target_report=CXIRemovedReport","_blank","toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width:=600, height:=300");
			}
			
			function ReadyForLining()
			{
				window.open("./cwp/print2.aspx?target_page=viewer.aspx&target_report=ReadyForLining","_blank","toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width:=600, height:=300");
			}
			
			function ToBePrepped()
			{
				window.open("./cwp/print2.aspx?target_page=viewer.aspx&target_report=ToBePrepped","_blank","toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width:=600, height:=300");
			}
			
			function ToBeMeasured()
			{
				window.open("./cwp/print2.aspx?target_page=viewer.aspx&target_report=ToBeMeasured","_blank","toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width:=600, height:=300");
			}
			
			function LiningCompleted()
			{
				window.open("./cwp/print_for_lining_completed.aspx?target_page=viewer.aspx&target_report=LiningCompleted","_blank","toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width:=630, height:=380");
			}
			
			function OverviewReport()
			{
				window.open("./cwp/print2.aspx?target_page=viewer.aspx&target_report=OverviewReport","_blank","toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width:=600, height:=300");
			}
			
			function RehabAssessmentAreas()
			{
				window.open("./cwp/print2.aspx?target_page=viewer.aspx&target_report=RehabAssessmentAreas","_blank","toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width:=600, height:=300");
			}
			
			function AllOutstandingIssues()
			{
				window.open("./cwp/print2.aspx?target_page=viewer.aspx&target_report=AllOutstandingIssues","_blank","toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width:=600, height:=300");
			}
			
			function OutstandingClientIssues()
			{
				window.open("./cwp/print2.aspx?target_page=viewer.aspx&target_report=OutstandingClientIssues","_blank","toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width:=600, height:=300");
			}
			
			function OutstandingLFSIssues()
			{
				window.open("./cwp/print2.aspx?target_page=viewer.aspx&target_report=OutstandingLFSIssues","_blank","toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width:=600, height:=300");
			}
			
			function OutstandingInvestigationIssues()
			{
				window.open("./cwp/print2.aspx?target_page=viewer.aspx&target_report=OutstandingInvestigationIssues","_blank","toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width:=600, height:=300");
			}
			
			function OutstandingSalesIssues()
			{
				window.open("./cwp/print2.aspx?target_page=viewer.aspx&target_report=OutstandingSalesIssues","_blank","toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width:=600, height:=300");
			}
			
			function ClientInvestigationIssuesCityCopy()
			{
				window.open("./cwp/print2.aspx?target_page=viewer.aspx&target_report=ClientInvestigationIssuesCityCopy","_blank","toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width:=600, height:=300");
			}
			
			function PointLinerReport()
			{
				window.open("./cwp/print2.aspx?target_page=viewer.aspx&target_report=PointLinerReport","_blank","toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width:=600, height:=300");
			}
			
			function PointLinerScopeSheet()
			{
				window.open("./cwp/print2.aspx?target_page=viewer.aspx&target_report=PointLinerScopeSheet","_blank","toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width:=600, height:=300");
			}
			
			function OutstandingPointRepairsReport()
			{
				window.open("./cwp/print2.aspx?target_page=viewer.aspx&target_report=OutstandingPointRepairsReport","_blank","toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width:=600, height:=300");
			}
			
			function M1ReportByClient()
			{
				window.open("./cwp/print3.aspx?target_page=viewer.aspx&target_report=M1ReportByClient","_blank","toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width:=630, height:=380");
			}
			
			function M2ReportByID()
			{
				window.open("./cwp/print3.aspx?target_page=viewer.aspx&target_report=M2ReportByID","_blank","toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width:=630, height:=380");
			}
			
			function WorkAhead()
			{
				window.open("./cwp/print.aspx?target_page=viewer.aspx&target_report=WorkAhead","_blank","toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width:=600, height:=300");
			}
			
			function JLinerOverviewReport()
			{
				window.open("./cwp/print2.aspx?target_page=viewer.aspx&target_report=JLinerOverviewReport","_blank","toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width:=600, height:=300");
			}

			function JLinersReadyToLine()
			{
				window.open("./cwp/print2.aspx?target_page=viewer.aspx&target_report=JLinersReadyToLine","_blank","toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width:=600, height:=300");
			}

			function JLinersToBuild()
			{
				window.open("./cwp/print_for_jltobuild.aspx?target_page=viewer.aspx&target_report=JLinersToBuild","_blank","toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width:=600, height:=300");
			}
			
			//--- Tools
			function DataDump()
			{
				window.open("./cwp/data_dump.aspx","_blank","toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width:=600, height:=300");
			}
			
			function BulkUpload()
			{
				window.open("./cwp/bulk_upload.aspx","_blank","toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width:=600, height:=350");
			}
			
			function ArchiveTool()
			{
				window.open("./cwp/archive.aspx?source_page=default.aspx","_blank","toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width:=980, height:=550");
			}
	
		</script>
	</head>
	<body>
		<form method="post" runat="server">
		    <asp:ScriptManager ID="ScriptManagerMaster4" runat="server">
            </asp:ScriptManager>
			<table cellspacing="0" cellpadding="0" style="width:900px" align="center" border="0">
				<tr style="height:40px">
					<td style="width:25px">&nbsp;</td>
					<td style="width:850px">&nbsp;</td>
					<td style="width:25px">&nbsp;</td>
				</tr>
				<tr style="height:530px">
					<td style="width:25px">
					</td>
					<td valign="top" style="width:850px">
						<table style="height:530px ; width:850px" cellspacing="0" cellpadding="0" bgcolor="#c8dbed" border="0">
							<tr>
								<td valign="top" style="width:235px" bgcolor="#2f82c7">&nbsp;
                                    <table cellspacing="0" cellpadding="0" style="width: 240px; padding-left: 11px; padding-bottom: 11px; padding-right: 11px; padding-bottom: 10px;" border="0">
                                        <tr>
                                            <td>
                                                <telerik:RadPanelBar ID="tkrpbLeftMenuAddRecords" BackColor="#2F82C7" Style="width: 240px"
                                                    runat="server" SkinID="RadPanelBar3" Width="180px">
                                                    <Items>
                                                        <telerik:RadPanelItem Expanded="True" Text="Add Records" PostBack="false">
                                                            <Items>
                                                                <telerik:RadPanelItem runat="server" NavigateUrl="./cwp/add_record.aspx" Text="Add New Record">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem runat="server" NavigateUrl="javascript:IdLookup();" Text="ID Lookup">
                                                                </telerik:RadPanelItem>
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
                                                <telerik:RadPanelBar ID="tkrpbLeftMenuDataEntry" BackColor="#2F82C7" Style="width: 240px" runat="server"
                                                    SkinID="RadPanelBar3" Width="180px">
                                                    <Items>
                                                        <telerik:RadPanelItem Expanded="True" Text="Data Entry / Viewing Pages" PostBack="false">
                                                            <Items>
                                                                <telerik:RadPanelItem NavigateUrl="./cwp/navigator.aspx?target_page=view_all.aspx"
                                                                    Text="All Records In All Projects">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="./cwp/navigator.aspx?target_page=view_fulllength.aspx"
                                                                    Text="Full Length Sections Only">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="./cwp/navigator.aspx?target_page=view_pointliner.aspx"
                                                                    Text="Point Liner / Other Sections Only">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="./cwp/navigator.aspx?target_page=view_subcontractor.aspx"
                                                                    Text="Subcontractor Sections Only">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="./cwp/navigator.aspx?target_page=view_scopesheet.aspx"
                                                                    Text="Point Liner Scope Sheet">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="./cwp/navigator.aspx?target_page=view_jlinersheet.aspx"
                                                                    Text="Junction Liner Sheet">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="./CWP/Common/select_project.aspx?source_page=default.aspx&work_type=Rehab Assessment"
                                                                    Text="Rehab Assessment">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="./CWP/Common/select_project.aspx?source_page=default.aspx&work_type=Full Length Lining"
                                                                    Text="Full Length Lining">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="./CWP/Common/select_project.aspx?source_page=default.aspx&work_type=Point Repairs"
                                                                    Text="Point Repairs">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="./CWP/Common/select_project.aspx?source_page=default.aspx&work_type=Junction Lining"
                                                                    Text="Junction Lining">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="./CWP/Common/select_project.aspx?source_page=default.aspx&work_type=Manhole Rehabilitation"
                                                                    Text="Manhole Rehabilitation">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="./CWP/Jliner/jliner_main.aspx?source_page=out"
                                                                    Text="Claude's Lateral Database">
                                                                </telerik:RadPanelItem>
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
                                                <telerik:RadPanelBar ID="tkrpbLeftMenuReports" BackColor="#2F82C7" Style="width: 240px" runat="server"
                                                    SkinID="RadPanelBar3" Width="180px">
                                                    <Items>
                                                        <telerik:RadPanelItem Expanded="False" Text="Reports" PostBack="false">
                                                            <Items>
                                                                <telerik:RadPanelItem NavigateUrl="javascript:CXIRemovedReport();" Text="CXI Removed Report">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="javascript:ReadyForLining();" Text="Ready For Lining">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="javascript:ToBePrepped();" Text="To Be Prepped">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="javascript:ToBeMeasured();" Text="To Be Measured">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="javascript:LiningCompleted();" Text="Lining Completed">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="javascript:OverviewReport();" Text="Overview Report">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="javascript:RehabAssessmentAreas();" Text="Rehab Assessment Areas">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="javascript:AllOutstandingIssues();" Text="All Outstanding Issues">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="javascript:OutstandingClientIssues();" Text="Outstanding Client Issues">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="javascript:OutstandingLFSIssues();" Text="Outstanding LFS Issues">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="javascript:OutstandingInvestigationIssues();"
                                                                    Text="Outstanding Investigation Issues">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="javascript:OutstandingSalesIssues();" Text="Outstanding Sales Issues">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="javascript:ClientInvestigationIssuesCityCopy();"
                                                                    Text="Client / Investigation Issues - City Copy">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="javascript:PointLinerReport();" Text="Point Liner Overview Report">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="javascript:PointLinerScopeSheet();" Text="Point Liner Scope Sheet">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="javascript:OutstandingPointRepairsReport();" Text="Outstanding Point Repairs Report">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="javascript:M1ReportByClient();" Text="M1 Report By Client">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="javascript:M2ReportByID();" Text="M2 Report By ID#">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="javascript:WorkAhead();" Text="Work Ahead %'s And $'s">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="javascript:JLinerOverviewReport();" Text="Junction Liner Overview Report">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="javascript:JLinersReadyToLine();" Text="Junction Liners Ready To Line">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="javascript:JLinersToBuild();" Text="Junction Liners To Build">
                                                                </telerik:RadPanelItem>
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
                                                <telerik:RadPanelBar ID="tkrpbLeftMenuTools" BackColor="#2F82C7" Style="width: 240px" runat="server"
                                                    SkinID="RadPanelBar3" Width="180px">
                                                    <Items>
                                                        <telerik:RadPanelItem Expanded="False" Text="Tools" PostBack="false">
                                                            <Items>
                                                                <telerik:RadPanelItem NavigateUrl="javascript:DataDump();" Text="Data Dump">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="javascript:BulkUpload();" Text="Bulk Upload">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="javascript:ArchiveTool();" Text="Archive Tool">
                                                                </telerik:RadPanelItem>
                                                            </Items>
                                                        </telerik:RadPanelItem>
                                                    </Items>
                                                </telerik:RadPanelBar>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 15px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <telerik:RadPanelBar ID="tkrpbLeftMenuLFSLive" BackColor="#2F82C7" Style="width: 240px" runat="server"
                                                    SkinID="RadPanelBar3" Width="180px">
                                                    <Items>
                                                        <telerik:RadPanelItem Expanded="False" Text="LFS Live" PostBack="false">
                                                            <Items>
                                                                <telerik:RadPanelItem NavigateUrl="./projects/projects/projects.aspx?source_page=out"
                                                                    Text="Projects">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="./projects/Revenue/revenue_navigator.aspx?source_page=out"
                                                                    Text="Revenue">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="./labourhours/timesheet/timesheet.aspx?source_page=out"
                                                                    Text="Labour Hours">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="./labourhours/vacations/vacations_all.aspx?source_page=out"
                                                                    Text="Vacations">
                                                                </telerik:RadPanelItem>
                                                                 <telerik:RadPanelItem NavigateUrl="./labourhours/ActualCosts/actual_costs_navigator.aspx?source_page=out"
                                                                    Text="Actual Costs">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="./FleetManagement/Dashboard/dashboard_login.aspx?source_page=out"
                                                                    Text="Fleet Management">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="./FleetManagement/Units/units_navigator.aspx?source_page=out"
                                                                    Text="Units">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="./FleetManagement/Services/services_navigator.aspx?source_page=out"
                                                                    Text="Services">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="./FleetManagement/ToDoList/toDoList_navigator.aspx?source_page=out"
                                                                    Text="To Do List">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="./FleetManagement/ChecklistRules/checklist_rules_navigator.aspx?source_page=out"
                                                                    Text="Checklist Rules">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="./Resources/Employees/employees_navigator.aspx?source_page=out"
                                                                    Text="Team Members">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="./Resources/Materials/materials_navigator.aspx?source_page=out"
                                                                    Text="Materials">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="./Resources/Subcontractors/subcontractors_navigator.aspx?source_page=out"
                                                                    Text="Subcontractors">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="./Resources/Hotels/hotels_navigator.aspx?source_page=out"
                                                                    Text="Hotels">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="./Resources/BondingCompanies/bondingCompanies_navigator.aspx?source_page=out"
                                                                    Text="Bondng Companies">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="./Resources/InsuranceCompanies/insuranceCompanies_navigator.aspx?source_page=out"
                                                                    Text="Insurance">
                                                                </telerik:RadPanelItem>                                                                
                                                                <telerik:RadPanelItem NavigateUrl="./Resources/UnitsOfMeasurement/unitsOfMeasurement_navigator.aspx?source_page=out"
                                                                    Text="Units Of Measurement">
                                                                </telerik:RadPanelItem>
                                                                <telerik:RadPanelItem NavigateUrl="./ITTechSupportTicket/SupportTicket/supportTicket_navigator.aspx?source_page=out"
                                                                    Text="IT Tech Support Tickets">
                                                                </telerik:RadPanelItem>
                                                            </Items>
                                                        </telerik:RadPanelItem>
                                                    </Items>
                                                </telerik:RadPanelBar>                                                
                                            </td>
                                        </tr>
                                    </table>
								</td>
								<td valign="top">
									<table style="height:500px; width:615px" cellspacing="0" cellpadding="0" border="0">
										<tr style="height:30px">
											<td align="right" bgcolor="#f7941c"><asp:linkbutton id="lkbtnSignOut" runat="server" style="width:67px" CssClass="tSignOutLinkDefault" onclick="lkbtnSignOut_Click">Sign out</asp:linkbutton>&nbsp;&nbsp;</td>
										</tr>
										<tr valign="middle" align="center" style="height:470px">
											<td bgcolor="#93b7dd"><img style="height:300px; width:450px" alt="" src="./common/images/logo.gif" /></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
					<td style="width:25px">&nbsp;</td>
				</tr>
				<tr style="height:40px">
					<td>&nbsp;</td>
					<td>&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</html>
