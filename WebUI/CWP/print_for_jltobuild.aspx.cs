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
using LiquiForce.LFSLive.CWP.Reports;
using LiquiForce.LFSLive.CWP.Tools;

namespace LiquiForce.LFSLive.WebUI.CWP
{
	public partial class print_for_jltobuild : System.Web.UI.Page
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

				//--- ... Access to this page
				if (!Convert.ToBoolean(Session["sgLFS_APP_VIEW"]))
				{
					Response.Redirect("./../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
				}

				//--- ... Access to target report
				switch (Request.QueryString["target_report"])
				{
					case "JLinersToBuild":
						if (!Convert.ToBoolean(Session["sgLFS_APP_ADMIN"]))
						{
							Response.Redirect("./../error_page.aspx?error=" + "You are not authorized to print this report. Contact your system administrator.");
						}
						break;
				}

				//--- Validate query string
				if ((Request.QueryString["target_page"] == null) || (Request.QueryString["target_report"] == null))
				{
					Response.Redirect("./../error_page.aspx?error=" + "Invalid query string in print.aspx");
				}
			}
		}

		//
		// btnPreview_Click
		//
		protected void btnPreview_Click(object sender, System.EventArgs e)
		{
			//--- Autofill liner ordered
			if (cbxAutoFillLinerOrdered.Checked)
			{
				this.AutofillLinerOrdered();
			}

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
			//--- Autofill liner ordered
			if (cbxAutoFillLinerOrdered.Checked)
			{
				this.AutofillLinerOrdered();
			}

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
			string a = (string)Request.QueryString["target_report"];
			switch (Request.QueryString["target_report"])
			{
				case "JLinersToBuild":
					lblTitle.Text = "Junction Liners To Build";
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
			url += "?target_report=" + Request.QueryString["target_report"];

			return url;
		}

		//
		// AutofillLinerOrdered
		//
		private void AutofillLinerOrdered()
		{
			//--- Initialize
			TDSLFSRecord currentTdsLfsRecord = new TDSLFSRecord();  // holds the current record being autofilled
			TDSLFSRecord allTdsLfsRecord = new TDSLFSRecord();		// holds all the records autofilled so far

			string currentId;	// holds the current id being autofilled
			string lastId = "";	// holds the last id autofilled so far
			
			LFSRecordForReportsGateway lfsRecordForReportsGateway = new LFSRecordForReportsGateway();
			LFSRecordGateway lfsRecordGateway = new LFSRecordGateway();


			//--- Autofill LinerOrdered

			//--- ... Get the jliners to be autofilled
			TDSJLinersToBuild tdsJLinersToBuild = lfsRecordForReportsGateway.GetJLinersToBuildByCompanyId(Convert.ToInt32(Session["companyID"]));

			foreach (TDSJLinersToBuild.JLinersToBuildRow jLinersToBuildRow in tdsJLinersToBuild.JLinersToBuild)
			{
				currentId = jLinersToBuildRow.ID;

				if (currentId != lastId)
				{	
					//--- ... Get the lfs record corresponding to the jliner to be autofilled
					currentTdsLfsRecord.Clear();
					currentTdsLfsRecord = lfsRecordGateway.GetRecordByIdCompanyId(new Guid(currentId), Convert.ToInt32(Session["companyID"]));

					//--- ... Autofill the jliners
					DataView dataView = new DataView(tdsJLinersToBuild.JLinersToBuild, "ID='" + currentId + "'", "", DataViewRowState.CurrentRows);
					foreach (DataRowView row in dataView)
					{
						TDSLFSRecord.LFS_JUNCTION_LINERRow currentLfsJunctionLinerRow = currentTdsLfsRecord.LFS_JUNCTION_LINER.FindByIDRefIDCOMPANY_ID(new Guid((string)row["ID"]), (int)row["RefID"], (int)row["COMPANY_ID"]);
						currentLfsJunctionLinerRow.LinerOrdered = true;
					}

					allTdsLfsRecord.Merge(currentTdsLfsRecord);

					lastId = currentId;
				}
			}


			//--- Update database
			try
			{
				lfsRecordGateway.UpdateRecord(allTdsLfsRecord);
			}
			catch(Exception ex)
			{
				Response.Redirect("./../error_page.aspx?error=" + ex.Message);
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
