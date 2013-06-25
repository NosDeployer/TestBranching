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
using System.Collections.Specialized;
using System.Web.Security;
using LiquiForce.LFSLive.CWP.DatabaseGateway;
using LiquiForce.LFSLive.CWP.Tools;

namespace LiquiForce.LFSLive.WebUI.CWP
{
	public partial class navigator : System.Web.UI.Page
	{
		///////////////////////////////////////////////////////////////////////////
		///  FIELDS
		///
		protected TDSLFSRecordForNavigator tdsLfsRecordForNavigator;






		/// ////////////////////////////////////////////////////////////////////////
		/// EVENTS
		///

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
				if ((Request.QueryString["target_page"] == null) && (Request.QueryString["search_results"] == null))
				{
                    Response.Redirect("./../error_page.aspx?error=" + "Invalid query string in navigator.aspx");
				}

				//--- If coming from default.aspx
				if (Request.QueryString["target_page"] != null)
				{
					//--- Store target page
					Session["targetPage"] = Request.QueryString["target_page"];

					//--- Set navigator state
					pNoResults.Visible = false;
					lblResults.Visible = false;
				}

				//--- If coming from navigator2.aspx
				if (Request.QueryString["search_results"] != null)
				{
					//--- Restore navigator state
					ddlSearch.SelectedIndex = (int)Session["ddlSearchSelectedIndex"];
					tbxSearch.Text = (string)Session["tbxSearchText"];
					lblHint.Visible = (bool)Session["lblHintVisible"];
					lblHint.Text = (string)Session["lblHintText"];	
				
					if (Request.QueryString["search_results"] == "true") // No results found
					{
						pNoResults.Visible = true;
						lblResults.Visible = true;
					}
					else
					{
						pNoResults.Visible = false;
						lblResults.Visible = false;
					}
				}
			}
		}



		protected void ddlSearch_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//--- Set navigator state
			tbxSearch.Text = "";
			
			switch (ddlSearch.SelectedItem.Value)
			{
				case ("ID#"):
					lblHint.Visible = true;
					lblHint.Text = "Type '%' to get all records";
					break;

				case ("Client"):
					lblHint.Visible = true;
					lblHint.Text = "Type '%' to get all records";
					break;

				case ("USMH"):
					lblHint.Visible = true;
					lblHint.Text = "Type '%' to get all records";
					break;

				case ("DSMH"):
					lblHint.Visible = true;
					lblHint.Text = "Type '%' to get all records";
					break;

				case ("P1 Date"):
					lblHint.Visible = false;
					lblHint.Text = "";
					break;

				case ("M1 Date"):
					lblHint.Visible = false;
					lblHint.Text = "";
					break;

				case ("M2 Date"):
					lblHint.Visible = false;
					lblHint.Text = "";
					break;

				case ("Install Date"):
					lblHint.Visible = false;
					lblHint.Text = "";
					break;

				case ("Street"):
					lblHint.Visible = true;
					lblHint.Text = "Type '%' to get all records";
					break;
			}

			pNoResults.Visible = false;
			lblResults.Visible = false;
		}



		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			if (Page.IsValid && (tbxSearch.Text.Trim() != ""))
			{
				//--- Get data from database gateway
				tdsLfsRecordForNavigator = this.SubmitSearch();
				Session["tdsLfsRecordForNavigator"] = tdsLfsRecordForNavigator;

				//--- Show results
				if (tdsLfsRecordForNavigator.NAVIGATOR.DefaultView.Count > 0)
				{
					//--- ... Yes results
					//--- ... Store navigator state
					Session["ddlSearchSelectedIndex"] = ddlSearch.SelectedIndex;
					Session["tbxSearchText"] = tbxSearch.Text;
					Session["lblHintVisible"] = lblHint.Visible;
					Session["lblHintText"] = lblHint.Text;

					//--- ... Go to results page
					Response.Redirect("navigator2.aspx?search_results=true");
				}
				else
				{
					//--- ... No results
					pNoResults.Visible = true;
					lblResults.Visible = true;
				}
			}
		}

		

		protected void Page_PreRender(object sender, EventArgs e)
		{
			//--- Set page title
			switch ((string)Session["targetPage"])
			{
				case "view_all.aspx":
					lblTitle.Text = "All Records In All Projects";
					break;

				case "view_fulllength.aspx":
					lblTitle.Text = "Full Length Sections Only";
					break;

				case "view_pointliner.aspx":
					lblTitle.Text = "Point Liner / Other Sections Only";
					break;

				case "view_scopesheet.aspx":
					lblTitle.Text = "Point Liner Scope Sheet";
					break;

				case "view_subcontractor.aspx":
					lblTitle.Text = "Subcontractor Sections Only";
					break;

				case "view_jlinersheet.aspx":
					lblTitle.Text = "Junction Liner Sheet";
					break;
			}
		}
		





		/// ////////////////////////////////////////////////////////////////////////
		/// AUXILIAR EVENTS
		///

		protected void lkbtnSignOut_Click(object sender, System.EventArgs e)
		{
			Response.Redirect((string)Session["loginPage"]);
		}



		private void cvSearchCriteria_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
			//--- Validate search string
			switch (ddlSearch.SelectedItem.Value)
			{
				case ("ID#"):
					args.IsValid = true;
					break;

				case ("Client"):
					args.IsValid = true;
					break;

				case ("USMH"):
					args.IsValid = true;
					break;

				case ("DSMH"):
					args.IsValid = true;
					break;

				case ("P1 Date"):
					args.IsValid = Validator.IsValidDate(tbxSearch.Text.Trim());
					cvSearch.ErrorMessage = "Invalid date";
					break;

				case ("M1 Date"):
					args.IsValid = Validator.IsValidDate(tbxSearch.Text.Trim());
					cvSearch.ErrorMessage = "Invalid date";
					break;

				case ("M2 Date"):
					args.IsValid = Validator.IsValidDate(tbxSearch.Text.Trim());
					cvSearch.ErrorMessage = "Invalid date";
					break;

				case ("Street"):
					args.IsValid = true;
					break;
			}
		}






		/// ////////////////////////////////////////////////////////////////////////
		/// METHODS
		///

        
		private TDSLFSRecordForNavigator SubmitSearch()
		{
			//--- Create database gateway
			LFSRecordForNavigatorGateway lfsRecordForNavigatorGateway = new LFSRecordForNavigatorGateway();
			TDSLFSRecordForNavigator dataSet;

			//--- Get data from database gateway
			switch (ddlSearch.SelectedItem.Value)
			{
				case ("ID#"):
					dataSet = lfsRecordForNavigatorGateway.GetRecordsByCompanyIdRecordIdTargetPage(Convert.ToInt32(Session["companyID"]), tbxSearch.Text.Trim(), (string)Session["targetPage"]);
					break;

				case ("Client"):
					dataSet = lfsRecordForNavigatorGateway.GetRecordsByCompanyIdClientTargetPage(Convert.ToInt32(Session["companyID"]), tbxSearch.Text.Trim(), (string)Session["targetPage"]);
					break;

				case ("USMH"):
					dataSet = lfsRecordForNavigatorGateway.GetRecordsByCompanyIdUsmhTargetPage(Convert.ToInt32(Session["companyID"]), tbxSearch.Text.Trim(), (string)Session["targetPage"]);
					break;

				case ("DSMH"):
					dataSet = lfsRecordForNavigatorGateway.GetRecordsByCompanyIdDsmhTargetPage(Convert.ToInt32(Session["companyID"]), tbxSearch.Text.Trim(), (string)Session["targetPage"]);
					break;

				case ("P1 Date"):
					dataSet = lfsRecordForNavigatorGateway.GetRecordsByCompanyIdP1DateTargetPage(Convert.ToInt32(Session["companyID"]), DateTime.Parse(tbxSearch.Text.Trim()), (string)Session["targetPage"]);
					break;

				case ("M1 Date"):
					dataSet = lfsRecordForNavigatorGateway.GetRecordsByCompanyIdM1DateTargetPage(Convert.ToInt32(Session["companyID"]), DateTime.Parse(tbxSearch.Text.Trim()), (string)Session["targetPage"]);
					break;

				case ("M2 Date"):
					dataSet = lfsRecordForNavigatorGateway.GetRecordsByCompanyIdM2DateTargetPage(Convert.ToInt32(Session["companyID"]), DateTime.Parse(tbxSearch.Text.Trim()), (string)Session["targetPage"]);
					break;

				case ("Install Date"):
					dataSet = lfsRecordForNavigatorGateway.GetRecordsByCompanyIdInstallDateTargetPage(Convert.ToInt32(Session["companyID"]), DateTime.Parse(tbxSearch.Text.Trim()), (string)Session["targetPage"]);
					break;

				case ("Street"):
					dataSet = lfsRecordForNavigatorGateway.GetRecordsByCompanyIdStreetTargetPage(Convert.ToInt32(Session["companyID"]), tbxSearch.Text.Trim(), (string)Session["targetPage"]);
					break;

				default:
					dataSet = null;
					break;
			}

			//--- Apply filter
			dataSet.NAVIGATOR.DefaultView.RowFilter = "(Deleted = 0) AND (Archived = 0)";

			return dataSet;
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
			this.tdsLfsRecordForNavigator = new TDSLFSRecordForNavigator();
			((System.ComponentModel.ISupportInitialize)(this.tdsLfsRecordForNavigator)).BeginInit();
			this.cvSearch.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.cvSearchCriteria_ServerValidate);
			// 
			// tdsLfsRecordForNavigator
			// 
			this.tdsLfsRecordForNavigator.DataSetName = "TDSLFSRecordForNavigator";
			this.tdsLfsRecordForNavigator.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.tdsLfsRecordForNavigator)).EndInit();

		}
		#endregion

		
	}
}
