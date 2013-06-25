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
	public partial class print_for_lining_completed : System.Web.UI.Page
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
				if (!Convert.ToBoolean(Session["sgLFS_APP_ADMIN"]))
				{
					Response.Redirect("./../error_page.aspx?error=" + "You are not authorized to print this report. Contact your system administrator.");
				}

				//--- Validate query string
				if ((Request.QueryString["target_page"] == null) || (Request.QueryString["target_report"] == null))
				{
					Response.Redirect("./../error_page.aspx?error=" + "Invalid query string in print_for_lining_completed.aspx");
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
			Page.Validate();
			
			if (Page.IsValid)
			{
				//--- Get target url
				string url = this.GetTargetUrl() + "&format=pdf";

				//--- Redirect to url
				Response.Redirect(url);
			}
		}

		//
		// btnExport_Click
		//
		protected void btnExport_Click(object sender, System.EventArgs e)
		{
			Page.Validate();
			
			if (Page.IsValid)
			{
				//--- Get target url
				string url = this.GetTargetUrl() + "&format=excel";

				//--- Redirect to url
				Response.Redirect(url);
			}
		}



		/// ////////////////////////////////////////////////////////////////////////
		/// AUXILIAR EVENTS
		///

		//
		// Date_ServerValidate
		//
		private void cvDate_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
			args.IsValid = Validator.IsValidDate(args.Value.Trim());	
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
		
			url += "&start_date=" + tbxStartDate.Text.Trim() +"&end_date=" + tbxEndDate.Text.Trim() + "&target_report=" + Request.QueryString["target_report"];

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
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.cvStartDate.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.cvDate_ServerValidate);
			this.cvEndDate.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.cvDate_ServerValidate);

		}
		#endregion


	}
}
