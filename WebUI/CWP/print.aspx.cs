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
	public partial class print : System.Web.UI.Page
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
					case "CXIRemovedReport":
						if (!Convert.ToBoolean(Session["sgLFS_APP_ADMIN"]))
						{
							Response.Redirect("./../error_page.aspx?error=" + "You are not authorized to print this report. Contact your system administrator.");
						}
						break;

					case "WorkAhead":
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
				case "CXIRemovedReport":
					lblTitle.Text = "CXI's Removed Report";
					break;

				case "WorkAhead":
					lblTitle.Text = "Work Ahead";
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
