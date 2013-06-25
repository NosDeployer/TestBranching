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
using LiquiForce.LFSLive.CWP.DatabaseGateway;

namespace LiquiForce.LFSLive.WebUI.CWP
{
	public partial class print2 : System.Web.UI.Page
	{
		/// ////////////////////////////////////////////////////////////////////////
		/// EVENTS
		///

		//
		// Page_Load
		//
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				//--- Security check
				if (!Convert.ToBoolean(Session["sgLFS_APP_VIEW"]))
				{
					Response.Redirect("./../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
				}

				//--- Validate query string
				if ((Request.QueryString["target_page"] == null) || (Request.QueryString["target_report"] == null))
				{
					Response.Redirect("./../error_page.aspx?error=" + "Invalid query string in print2.aspx");
				}

				//--- Get clients
				CompaniesGateway companiesGateway = new CompaniesGateway();
				DataSet dataSet = companiesGateway.GetCompaniesForDropDownList("-1", "-- ALL CLIENTS --", Convert.ToInt32(Session["companyID"]));

				ddlSelectAClient.DataSource = dataSet;
				ddlSelectAClient.DataValueField = "COMPANIES_ID";
				ddlSelectAClient.DataTextField = "NAME";
				ddlSelectAClient.SelectedValue = "-1";

				//--- Databind
				ddlSelectAClient.DataBind();
			}
		}

		//
		// btnPreview_Click
		//
		protected void btnPreview_Click(object sender, System.EventArgs e)
		{
			//--- Get target url
			string url = this.GetTargetUrl() + "&format=pdf";

			//--- Redirect to url
			Response.Redirect(url);
		}

		//
		// btnExport_Click
		//
		protected void btnExport_Click(object sender, System.EventArgs e)
		{
			//--- Get target url
			string url = this.GetTargetUrl() + "&format=excel";

			//--- Redirect to url
			Response.Redirect(url);
		}

		//
		// Page_PreRender
		//
		protected void Page_PreRender(object sender, EventArgs e)
		{
			//--- Set dialog title
			switch (Request.QueryString["target_report"])
			{
				case "ReadyForLining":
					lblTitle.Text = "Ready For Lining";
					break;

				case "ToBePrepped":
					lblTitle.Text = "To Be Prepped";
					break;

				case "ToBeMeasured":
					lblTitle.Text = "To Be Measured";
					break;

				case "OverviewReport":
					lblTitle.Text = "Overview Report";
					break;

				case "RehabAssessmentAreas":
					lblTitle.Text = "Rehab Assessment Areas";
					break;

				case "AllOutstandingIssues":
					lblTitle.Text = "All Outstanding Issues";
					break;

				case "OutstandingClientIssues":
					lblTitle.Text = "Outstanding Client Issues";
					break;

				case "OutstandingLFSIssues":
					lblTitle.Text = "Outstanding LFS Issues";
					break;

				case "OutstandingInvestigationIssues":
					lblTitle.Text = "Outstanding Investigation Issues";
					break;

				case "OutstandingSalesIssues":
					lblTitle.Text = "Outstanding Sales Issues";
					break;

				case "ClientInvestigationIssuesCityCopy":
					lblTitle.Text = "Client/Investigation Issues - City Copy";
					break;

				case "PointLinerReport":
					lblTitle.Text = "Point Liner Overview Report";
					break;

				case "PointLinerScopeSheet":
					lblTitle.Text = "Point Liner Scope Sheet";
					break;

				case "OutstandingPointRepairsReport":
					lblTitle.Text = "Outstanding Point Repairs Report";
					break;

				case "JLinerOverviewReport":
					lblTitle.Text = "Junction Liner Overview Report";
					break;

				case "JLinersReadyToLine":
					lblTitle.Text = "Junction Liner Ready To Line";
					break;

				default:
					lblTitle.Text = "SET TITLE IN PRE-RENDER";
					break;
			}
		}



		/// ////////////////////////////////////////////////////////////////////////
		/// METHODS
		///

		//
		// GetTargetUrl
		//
		private string GetTargetUrl()
		{
			//--- Build target url
			string url = "";

			//--- ... Set target page
			url = Request.QueryString["target_page"];

			//--- ... Append query strings 
			if (ddlSelectAClient.SelectedValue == "-1")
			{
				url += "?all_clients=true&companies_id=0";
			}
			else
			{
				url += "?all_clients=false&companies_id=" + ddlSelectAClient.SelectedValue;
			}
			
			url += "&target_report=" + Request.QueryString["target_report"];

			return url;
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);

			//--- Wire events
			this.PreRender += new EventHandler(Page_PreRender);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion
		

	}
}
