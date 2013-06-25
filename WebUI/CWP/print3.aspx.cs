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
using LiquiForce.LFSLive.CWP.Tools;

namespace LiquiForce.LFSLive.WebUI.CWP
{
	public partial class print3 : System.Web.UI.Page
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
					Response.Redirect("./../error_page.aspx?error=" + "Invalid query string in print3.aspx");
				}

				//--- Get clients
				CompaniesGateway companiesGateway = new CompaniesGateway();
				DataSet dataSet = companiesGateway.GetCompaniesForDropDownList(Convert.ToInt32(Session["companyID"]));

				ddlSelectAClient.DataSource = dataSet;
				ddlSelectAClient.DataValueField = "COMPANIES_ID";
				ddlSelectAClient.DataTextField = "NAME";

				//--- Databind
				ddlSelectAClient.DataBind();
			}

			lblRecordID.Visible = false;
		}

		//
		// btnPreview_Click
		//
		protected void btnPreview_Click(object sender, System.EventArgs e)
		{
			//--- Validate

			//--- ... recordId
			if (rbtnRecordID.Checked && (tbxRecordID.Text.Trim() == "") )
			{
				lblRecordID.Visible = true;
				return;
			}

			//--- ... page
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
			//--- Validate

			//--- ... recordId
			if (rbtnRecordID.Checked && (tbxRecordID.Text.Trim() == "") )
			{
				lblRecordID.Visible = true;
				return;
			}

			//--- ... page
			Page.Validate();
			
			if (Page.IsValid)
			{
				//--- Get target url
				string url = this.GetTargetUrl() + "&format=excel";

				//--- Redirect to url
				Response.Redirect(url);
			}
		}

		//
		// Page_PreRender
		//
		protected void Page_PreRender(object sender, EventArgs e)
		{
			//--- Set dialog title
			switch (Request.QueryString["target_report"])
			{
				case "M1ReportByClient":
					lblTitle.Text = "M1 Report By Client";
					rbtnDate.Text = "M1 Date";
					break;

				case "M2ReportByID":
					lblTitle.Text = "M2 Report By ID";
					rbtnDate.Text = "M2 Date";
					break;

				default:
					lblTitle.Text = "SET TITLE IN PRE-RENDER";
					break;
			}

			//--- Form control
			if (rbtnRecordID.Checked)
			{
				tbxRecordID.Enabled = true;
				ddlSelectAClient.Enabled = false;
				tbxDate.Enabled = false;
			}
			else if (rbtnClient.Checked)
			{
				tbxRecordID.Enabled = false;
				ddlSelectAClient.Enabled = true;
				tbxDate.Enabled = false;
			}
			else
			{
				tbxRecordID.Enabled = false;
				ddlSelectAClient.Enabled = false;
				tbxDate.Enabled = true;
			}
		}

		

		/// ////////////////////////////////////////////////////////////////////////
		/// AUXILIAR EVENTS
		///

		//
		// cvRecordID_ServerValidate
		//
		private void cvRecordID_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
			//--- Check whether the RecordID is in use
			LFSMasterAreaGateway lfsMasterAreaGateway = new LFSMasterAreaGateway();
			args.IsValid = lfsMasterAreaGateway.IsRecordIdInUse(tbxRecordID.Text, Convert.ToInt32(Session["companyID"]));
		}

		//
		// Date_ServerValidate
		//
		private void Date_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
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
			//--- Build destination url
			string url = "";

			//--- ... Set target page
			url = Request.QueryString["target_page"];

			//--- ... Append query strings 
			if (rbtnRecordID.Checked)
			{
				url += "?one_id=true&id=" + tbxRecordID.Text + "&companies=0&date=0&target_report=" + Request.QueryString["target_report"];
			}
			else if (rbtnClient.Checked)
			{
				url += "?one_id=false&id=0&companies=" + ddlSelectAClient.SelectedValue + "&date=0&target_report=" + Request.QueryString["target_report"];
			}
			else
			{
				url += "?one_id=false&id=0&companies=0&date=" + tbxDate.Text.Trim() + "&target_report=" + Request.QueryString["target_report"];
			}

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
			this.cvRecordID.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.cvRecordID_ServerValidate);
			this.cvDate.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.Date_ServerValidate);

		}
		#endregion

		
		
	}
}
