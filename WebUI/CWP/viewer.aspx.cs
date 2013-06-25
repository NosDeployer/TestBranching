using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.CWP.Reports;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace LiquiForce.LFSLive.WebUI.CWP
{
	public partial class viewer : System.Web.UI.Page
	{
        /// ////////////////////////////////////////////////////////////////////////
        /// PROPERTIES AND FIELDS
        ///

        protected CrystalDecisions.CrystalReports.Engine.ReportDocument report;

		/// ////////////////////////////////////////////////////////////////////////
		/// EVENTS
		///

		
		protected void Page_Load(object sender, System.EventArgs e)
		{
			//--- Security check
			if (!Convert.ToBoolean(Session["sgLFS_APP_VIEW"]))
			{
				Response.Redirect("./../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
			}

			//--- Validate query string
			if ((Request.QueryString["target_report"] == null) || (Request.QueryString["format"] == null))
			{
				Response.Redirect("./../error_page.aspx?error=" + "Invalid query string in viewer.aspx");
			}

			//--- Initialize
			bool empty = false;
			LFSRecordForReportsGateway lfsRecordForReportsGateway = new LFSRecordForReportsGateway();

			//--- Get report data
			#region Get report data
			switch (Request.QueryString["target_report"])
			{
				//--- CXIRemovedReport
				case "CXIRemovedReport":
					TDSCXIRemovedReport dataSet = lfsRecordForReportsGateway.GetCXIRemovedReportByCompanyId(Convert.ToInt32(Session["companyID"]));
					if (dataSet.CXIRemovedReport.Rows.Count > 0)
					{
						report = new rCXIRemovedReport();						
						report.SetDataSource(dataSet);

						if (Request.QueryString["format"] == "pdf")
						{ 
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = false;
						}
						else
						{
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = true;
						}

						report.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
						report.PrintOptions.PaperSize = PaperSize.PaperLetter;
					}
					else
					{
						empty = true;
					}
					break;

				//--- ReadyForLining
				case "ReadyForLining":
					TDSReadyForLining tdsReadyForLining = lfsRecordForReportsGateway.GetReadyForLiningByCompanyId(Convert.ToInt32(Session["companyID"]), Convert.ToBoolean(Request.QueryString["all_clients"]), Convert.ToInt32(Request.QueryString["companies_id"]));
					if (tdsReadyForLining.ReadyForLining.Rows.Count > 0)
					{
						report = new rReadyForLining();
						report.SetDataSource(tdsReadyForLining);

						
						if (Request.QueryString["format"] == "pdf")
						{ 
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = false;
						}
						else
						{
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = true;
						}				

						report.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
						report.PrintOptions.PaperSize = PaperSize.PaperLegal;
					}
					else
					{
						empty = true;
					}
					break;

				//--- ToBePrepped
				case "ToBePrepped":
					TDSToBePrepped tdsToBePrepped = lfsRecordForReportsGateway.GetToBePreppedByCompanyId(Convert.ToInt32(Session["companyID"]), Convert.ToBoolean(Request.QueryString["all_clients"]), Convert.ToInt32(Request.QueryString["companies_id"]));
					if (tdsToBePrepped.ToBePrepped.Rows.Count > 0)
					{
						report = new rToBePrepped();
						report.SetDataSource(tdsToBePrepped);
						
						if (Request.QueryString["format"] == "pdf")
						{ 
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = false;
						}
						else
						{
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = true;
						}

						report.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
						report.PrintOptions.PaperSize = PaperSize.PaperLegal;
					}
					else
					{
						empty = true;
					}
					break;

				//--- ToBeMeasured
				case "ToBeMeasured":
					TDSToBeMeasured tdsToBeMeasured = lfsRecordForReportsGateway.GetToBeMeasuredByCompanyId(Convert.ToInt32(Session["companyID"]), Convert.ToBoolean(Request.QueryString["all_clients"]), Convert.ToInt32(Request.QueryString["companies_id"]));
					if (tdsToBeMeasured.ToBeMeasured.Rows.Count > 0)
					{
						report = new rToBeMeasured();
						report.SetDataSource(tdsToBeMeasured);
						
						if (Request.QueryString["format"] == "pdf")
						{ 
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = false;
						}
						else
						{
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = true;
						}

						report.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
						report.PrintOptions.PaperSize = PaperSize.PaperLegal;
					}
					else
					{
						empty = true;
					}
					break;

				//--- LiningCompleted
				case "LiningCompleted": 
					TDSLiningCompleted tdsLiningCompleted = lfsRecordForReportsGateway.GetLiningCompletedByCompanyId(Convert.ToInt32(Session["companyID"]), Convert.ToBoolean(Request.QueryString["all_clients"]), Convert.ToInt32(Request.QueryString["companies_id"]), Convert.ToDateTime(Request.QueryString["start_date"]), Convert.ToDateTime(Request.QueryString["end_date"]));
					if (tdsLiningCompleted.LiningCompleted.Rows.Count > 0)
					{
						report = new rLiningCompleted();
						report.SetDataSource(tdsLiningCompleted);
						
						if (Request.QueryString["format"] == "pdf")
						{ 
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = false;
						}
						else
						{
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = true;
						}

						report.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
						report.PrintOptions.PaperSize = PaperSize.PaperLetter;
					}
					else
					{
						empty = true;
					}
					break;

				//--- OverviewReport
				case "OverviewReport":
					TDSOverviewReport tdsOverviewReport = lfsRecordForReportsGateway.GetOverviewReportByCompanyId(Convert.ToInt32(Session["companyID"]), Convert.ToBoolean(Request.QueryString["all_clients"]), Convert.ToInt32(Request.QueryString["companies_id"]));
					if (tdsOverviewReport.OverviewReport.Rows.Count > 0)
					{
						report = new rOverviewReport();
						report.SetDataSource(tdsOverviewReport);
						
						if (Request.QueryString["format"] == "pdf")
						{ 
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = false;
						}
						else
						{
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = true;
						}

						report.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
						report.PrintOptions.PaperSize = PaperSize.PaperLegal;
					}
					else
					{
						empty = true;
					}
					break;

				//--- RehabAssessmentAreas
				case "RehabAssessmentAreas":
					TDSRehabAssessmentAreas tdsRehabAssessmentAreas = lfsRecordForReportsGateway.GetRehabAssessmentAreasByCompanyId(Convert.ToInt32(Session["companyID"]), Convert.ToBoolean(Request.QueryString["all_clients"]), Convert.ToInt32(Request.QueryString["companies_id"]));
					if (tdsRehabAssessmentAreas.RehabAssessmentAreas.Rows.Count > 0)
					{
						report = new rRehabAssessmentAreas();
						report.SetDataSource(tdsRehabAssessmentAreas);
						
						if (Request.QueryString["format"] == "pdf")
						{ 
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = false;
						}
						else
						{
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = true;
						}

						report.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
						report.PrintOptions.PaperSize = PaperSize.PaperLegal;
					}
					else
					{
						empty = true;
					}
					break;

				//--- AllOutstandingIssues 
				case "AllOutstandingIssues":
					TDSAllOutstandingIssues tdsAllOutstandingIssues = lfsRecordForReportsGateway.GetAllOutstandingIssuesByCompanyId(Convert.ToInt32(Session["companyID"]), Convert.ToBoolean(Request.QueryString["all_clients"]), Convert.ToInt32(Request.QueryString["companies_id"]));
					if (tdsAllOutstandingIssues.AllOutstandingIssues.Rows.Count > 0)
					{
						report = new rAllOutstandingIssues();
						report.SetDataSource(tdsAllOutstandingIssues);
						
						if (Request.QueryString["format"] == "pdf")
						{ 
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = false;
						}
						else
						{
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = true;
						}
						report.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
						report.PrintOptions.PaperSize = PaperSize.PaperLetter;
					}
					else
					{
						empty = true;
					}
					break;

				//--- OutstandingClientIssues
				case "OutstandingClientIssues":
					TDSOutstandingClientIssues tdsOutstandingClientIssues = lfsRecordForReportsGateway.GetOutstandingClientIssuesByCompanyId(Convert.ToInt32(Session["companyID"]), Convert.ToBoolean(Request.QueryString["all_clients"]), Convert.ToInt32(Request.QueryString["companies_id"]));
					if (tdsOutstandingClientIssues.OutstandingClientIssues.Rows.Count > 0)
					{
						report = new rOutstandingClientIssues();
						report.SetDataSource(tdsOutstandingClientIssues);
						
						if (Request.QueryString["format"] == "pdf")
						{ 
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = false;
						}
						else
						{
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = true;
						}

						report.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
						report.PrintOptions.PaperSize = PaperSize.PaperLetter;
					}
					else
					{
						empty = true;
					}
					break;

				//--- OutstandingLFSIssues
				case "OutstandingLFSIssues":
					TDSOutstandingLFSIssues tdsOutstandingLFSIssues = lfsRecordForReportsGateway.GetOutstandingLFSIssuesByCompanyId(Convert.ToInt32(Session["companyID"]), Convert.ToBoolean(Request.QueryString["all_clients"]), Convert.ToInt32(Request.QueryString["companies_id"]));
					if (tdsOutstandingLFSIssues.OutstandingLFSIssues.Rows.Count > 0)
					{
						report = new rOutstandingLFSIssues();
						report.SetDataSource(tdsOutstandingLFSIssues);
						
						if (Request.QueryString["format"] == "pdf")
						{ 
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = false;
						}
						else
						{
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = true;
						}

						report.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
						report.PrintOptions.PaperSize = PaperSize.PaperLetter;
					}
					else
					{
						empty = true;
					}
					break;

				//--- OutstandingInvestigationIssues
				case "OutstandingInvestigationIssues":
					TDSOutstandingInvestigationIssues tdsOutstandingInvestigationIssues = lfsRecordForReportsGateway.GetOutstandingInvestigacionIssuesByCompanyId(Convert.ToInt32(Session["companyID"]), Convert.ToBoolean(Request.QueryString["all_clients"]), Convert.ToInt32(Request.QueryString["companies_id"]));
					if (tdsOutstandingInvestigationIssues.OutstandingInvestigationUssue.Rows.Count > 0)
					{
						report = new  rOutstandingInvestigationIssues();
						report.SetDataSource(tdsOutstandingInvestigationIssues);
						if (Request.QueryString["format"] == "pdf")
						{ 
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = false;
						}
						else
						{
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = true;
						}

						report.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
						report.PrintOptions.PaperSize = PaperSize.PaperLetter;
					}
					else
					{
						empty = true;
					}
					break;

				//--- OutstandingSalesIssues
				case "OutstandingSalesIssues":
					TDSOutstandingSalesIssues tdsOutstandingSalesIssues = lfsRecordForReportsGateway.GetOutstandingSalesIssuesByCompanyId(Convert.ToInt32(Session["companyID"]), Convert.ToBoolean(Request.QueryString["all_clients"]), Convert.ToInt32(Request.QueryString["companies_id"]));
					if (tdsOutstandingSalesIssues.OutstandingSalesIssues.Rows.Count > 0)
					{
						report = new rOutstandingSalesIssues();
						report.SetDataSource(tdsOutstandingSalesIssues);
						if (Request.QueryString["format"] == "pdf")
						{ 
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = false;
						}
						else
						{
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = true;
						}

						report.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
						report.PrintOptions.PaperSize = PaperSize.PaperLetter;
					}
					else
					{
						empty = true;
					}
					break;

				//--- ClientInvestigationIssuesCityCopy
				case "ClientInvestigationIssuesCityCopy":
					TDSClientInvestigationIssuesCityCopy tdsClientInvestigationIssuesCityCopy = lfsRecordForReportsGateway.GetClientInvestigationIssuesCityCopyByCompanyId(Convert.ToInt32(Session["companyID"]), Convert.ToBoolean(Request.QueryString["all_clients"]), Convert.ToInt32(Request.QueryString["companies_id"]));
					if (tdsClientInvestigationIssuesCityCopy.ClientInvestigationIssuesCityCopy.Rows.Count > 0)
					{
						report = new  rClientInvestigationIssuesCityCopy();
						report.SetDataSource(tdsClientInvestigationIssuesCityCopy);
						if (Request.QueryString["format"] == "pdf")
						{ 
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = false;
						}
						else
						{
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = true;
						}
						report.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
						report.PrintOptions.PaperSize = PaperSize.PaperLetter;
					}
					else
					{
						empty = true;
					}
					break;

				//--- PointLinerReport
				case "PointLinerReport":
					TDSPointLinerReport tdsPointLinerReport = lfsRecordForReportsGateway.GetPointLinerReportByCompanyId(Convert.ToInt32(Session["companyID"]), Convert.ToBoolean(Request.QueryString["all_clients"]), Convert.ToInt32(Request.QueryString["companies_id"]));
					if (tdsPointLinerReport.PointLinerReport.Rows.Count > 0)
					{
						report = new rPointLinerReport();
						report.SetDataSource(tdsPointLinerReport);
						
						if (Request.QueryString["format"] == "pdf")
						{ 
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = false;
						}
						else
						{
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = true;
						}
						report.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
						report.PrintOptions.PaperSize = PaperSize.PaperLegal;
					}
					else
					{
						empty = true;
					}
					break;

				//--- PointLinerScopeSheet
				case "PointLinerScopeSheet":
					TDSPointLinerScopeSheet tdsPointLinerScopeSheet = lfsRecordForReportsGateway.GetPointLinerScopeSheetByCompanyId(Convert.ToInt32(Session["companyID"]), Convert.ToBoolean(Request.QueryString["all_clients"]), Convert.ToInt32(Request.QueryString["companies_id"]));
					if (tdsPointLinerScopeSheet.PointLinerScopeSheet.Rows.Count > 0)
					{
						report = new rPointLinerScopeSheet();
						report.SetDataSource(tdsPointLinerScopeSheet);

						report.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
						report.PrintOptions.PaperSize = PaperSize.PaperLegal;
					}
					else
					{
						empty = true;
					}
					break;

				//--- OutstandingPointRepairs
				case "OutstandingPointRepairsReport":
					TDSOutstandingPointRepairs tdsOutstandingPointRepairs = lfsRecordForReportsGateway.GetOutstandingPointRepairsCompanyIdCompaniesId(Convert.ToInt32(Session["companyID"]), Convert.ToBoolean(Request.QueryString["all_clients"]), Convert.ToInt32(Request.QueryString["companies_id"]));
					if (tdsOutstandingPointRepairs.OutstandingPointRepairs.Rows.Count > 0)
					{
						//--- Report creation and data binding
						report = new rOutstandingPointRepairs();						
						report.SetDataSource(tdsOutstandingPointRepairs);
						//--- Format control
						if (Request.QueryString["format"] == "pdf")
						{ 
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = false;
						}
						else
						{
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = true;
						}
						//--- Report format
						report.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
						report.PrintOptions.PaperSize = PaperSize.PaperLegal;
					}
					else
					{
						empty = true;
					}
					break;

				//--- M1ReportByClient
				case "M1ReportByClient":
					TDSM1ReportByClient tdsM1ReportByClient;
					if ((Request.QueryString["id"] != "0") && (Request.QueryString["companies"] == "0") && (Request.QueryString["date"] == "0"))
					{
						tdsM1ReportByClient = lfsRecordForReportsGateway.GetM1ReportByClientByCompanyIdByID(Convert.ToInt32(Session["companyID"]), Request.QueryString["id"]);
					}
					else if ((Request.QueryString["id"] == "0") && (Convert.ToInt32(Request.QueryString["companies"]) != 0) && (Request.QueryString["date"] == "0"))
					{
						tdsM1ReportByClient = lfsRecordForReportsGateway.GetM1ReportByClientByCompanyIdByCompanies(Convert.ToInt32(Session["companyID"]), Convert.ToInt32(Request.QueryString["companies"]));
					}
					else
					{
						tdsM1ReportByClient = lfsRecordForReportsGateway.GetM1ReportByClientByCompanyIdByDate(Convert.ToInt32(Session["companyID"]), Request.QueryString["date"]);
					}
												
					if (tdsM1ReportByClient.M1ReportByClient.Rows.Count > 0)
					{
						report = new rM1ReportByClient();
						report.SetDataSource(tdsM1ReportByClient);

						if (Request.QueryString["format"] == "pdf")
						{ 
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = false;
						}
						else						
						{							
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = true;
						}

						report.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
						report.PrintOptions.PaperSize = PaperSize.PaperLetter;
					}
					else
					{
						empty = true;
					}
					break;

				//--- M2ReportByID
				case "M2ReportByID":
					TDSM2ReportByID tdsM2ReportByID;
					if ((Request.QueryString["id"] != "0") && (Request.QueryString["companies"] == "0") && (Request.QueryString["date"] == "0"))
					{
						tdsM2ReportByID = lfsRecordForReportsGateway.GetM2ReportByIDByCompanyIdById(Convert.ToInt32(Session["companyID"]), Request.QueryString["id"]);
					}
					else if ((Request.QueryString["id"] == "0") && (Convert.ToInt32(Request.QueryString["companies"]) != 0) && (Request.QueryString["date"] == "0"))
					{
						tdsM2ReportByID = lfsRecordForReportsGateway.GetM2ReportByIDByCompanyIdByCompanies(Convert.ToInt32(Session["companyID"]), Convert.ToInt32(Request.QueryString["companies"]));
					}
					else
					{
						tdsM2ReportByID = lfsRecordForReportsGateway.GetM2ReportByIDByCompanyIdByDate(Convert.ToInt32(Session["companyID"]), Request.QueryString["date"]);
					}
								
					if (tdsM2ReportByID.LFS_MASTER_AREA.Rows.Count > 0)
					{						
						report = new rM2ReportByID();
						report.SetDataSource(tdsM2ReportByID);

						if (Request.QueryString["format"] == "pdf")
						{ 
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = false;
						}
						else						
						{							
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = true;
						}

						report.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
						report.PrintOptions.PaperSize = PaperSize.PaperLetter;						
					}
					else
					{
						empty = true;
					}
					break;

				//--- WorkAhead
				case "WorkAhead":
					TDSWorkAhead tdsWorkAhead = lfsRecordForReportsGateway.GetWorkAheadByCompanyId(Convert.ToInt32(Session["companyID"]));
					if (tdsWorkAhead.WorkAhead1.Rows.Count > 0)
					{
						report = new rWorkAhead();
						report.SetDataSource(tdsWorkAhead);
						if (Request.QueryString["format"] == "pdf")
						{ 
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = false;
						}
						else
						{
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = true;
						}

						report.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
						report.PrintOptions.PaperSize = PaperSize.PaperLetter;
					}
					else
					{
						empty = true;
					}
					break;

				//--- JLinerOverviewReport
				case "JLinerOverviewReport":
					TDSJLinerOverviewReport tdsJLinerOverviewReport = lfsRecordForReportsGateway.GetJLinerOverviewReportByCompanyIDCompaniesID(Convert.ToInt32(Session["companyID"]), Convert.ToBoolean(Request.QueryString["all_clients"]), Convert.ToInt32(Request.QueryString["companies_id"]));
					if (tdsJLinerOverviewReport.JLinerOverviewReport.Rows.Count > 0)
					{
						//---Report creation and data binding
						if (Convert.ToBoolean(Session["sgLFS_APP_ADMIN"]))
						{
							report = new rJLinerOverviewReport();						
						}
						else
						{
							report = new rJLinerOverviewReportSimple();						
						}
						report.SetDataSource(tdsJLinerOverviewReport);
						//---Format control
						if (Request.QueryString["format"] == "pdf")
						{ 
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = false;
						}
						else
						{
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = true;
						}
						//---Report format
						report.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
						report.PrintOptions.PaperSize = PaperSize.PaperLegal;
					}
					else
					{
						empty = true;
					}								
					break;

				//--- JLinersReadyToLine
				case "JLinersReadyToLine":
					TDSJLinersReadyToLine tdsJLinersReadyToLine = lfsRecordForReportsGateway.GetJLinersReadyToLineByCompanyIDCompaniesID(Convert.ToInt32(Session["companyID"]), Convert.ToBoolean(Request.QueryString["all_clients"]), Convert.ToInt32(Request.QueryString["companies_id"]));
					if (tdsJLinersReadyToLine.JLinersReadyToLine.Rows.Count > 0)
					{
						//---Report creation and data binding
						report = new rJLinersReadyToLine();						
						report.SetDataSource(tdsJLinersReadyToLine);
						//---Format control
						if (Request.QueryString["format"] == "pdf")
						{ 
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = false;
						}
						else
						{
							((Section)report.ReportDefinition.Sections["sReportHeader"]).SectionFormat.EnableSuppress = false;
							((Section)report.ReportDefinition.Sections["sPageHeader"]).SectionFormat.EnableSuppress = true;
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = true;
						}						
						//---Report format
						report.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
						report.PrintOptions.PaperSize = PaperSize.PaperLegal;
					}
					else
					{
						empty = true;
					}		
					break;

				//--- JLinersToBuild
				case "JLinersToBuild":
					TDSJLinersToBuild tdsJLinersToBuild = lfsRecordForReportsGateway.GetJLinersToBuildByCompanyId(Convert.ToInt32(Session["companyID"]));
					if (tdsJLinersToBuild.JLinersToBuild.Rows.Count > 0)
					{
						report = new rJLinersToBuild();						
						report.SetDataSource(tdsJLinersToBuild);

						if (Request.QueryString["format"] == "pdf")
						{ 
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = false;
						}
						else
						{
							((Section)report.ReportDefinition.Sections["sPageFooter"]).SectionFormat.EnableSuppress = true;
						}

						report.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
						report.PrintOptions.PaperSize = PaperSize.PaperLetter;
					}
					else
					{
						empty = true;
					}
					break;
			}
			#endregion

			if (!empty)
			{
				//--- Configure report

				//--- ... Disk options
				string physicalApplicationPath = Request.PhysicalApplicationPath;
				if (Request.PhysicalApplicationPath.Substring(Request.PhysicalApplicationPath.Length-1, 1) != "\\")
				{
					physicalApplicationPath += "\\";
				}
				
				string fName = "";
				switch (Request.QueryString["format"])
				{
					case "pdf":
						fName = physicalApplicationPath + "export\\" + Guid.NewGuid().ToString() + ".pdf";
						Session["fName"] = fName;
						break;

					case "excel":
						fName = physicalApplicationPath + "export\\" + Guid.NewGuid().ToString() + ".xls";
						Session["fName"] = fName;
						break;

					case "word":
						break;
				}
			
				DiskFileDestinationOptions diskOptions = new DiskFileDestinationOptions();
				diskOptions.DiskFileName = fName;
		
				//--- ... Export options
				report.ExportOptions.DestinationOptions = diskOptions;
				report.ExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
			
				switch (Request.QueryString["format"])
				{
					case "pdf":
						report.ExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
						break;

					case "excel":
						ExcelFormatOptions excelOptions = new ExcelFormatOptions();
						excelOptions.ExcelUseConstantColumnWidth = false;
						excelOptions.ExcelTabHasColumnHeadings = false;

						report.ExportOptions.ExportFormatType = ExportFormatType.Excel;
						report.ExportOptions.FormatOptions = excelOptions;
						break;

					case "word":
						break;
				}

				//--- Export report
				try
				{
					report.Export();
				}
				catch(Exception ex)
				{
					Response.Redirect("./../error_page.aspx?error=" + ex.Message);
				}

				//--- Preview report
				Response.Redirect("viewer2.aspx?target_report=" + Request.QueryString["target_report"] + "&format=" + Request.QueryString["format"], true);
			}
			else
			{
				Response.Write("<br>         No records found for your report.");
			}	
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.report = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			// 
			// report
			// 
			this.report.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait;
			this.report.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter;
			this.report.PrintOptions.PaperSource = CrystalDecisions.Shared.PaperSource.Upper;
			this.report.PrintOptions.PrinterDuplex = CrystalDecisions.Shared.PrinterDuplex.Default;

		}
		#endregion

	}
}