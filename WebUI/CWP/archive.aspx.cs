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
	public partial class Archive : System.Web.UI.Page
	{
		///////////////////////////////////////////////////////////////////////////
		/// PROPERTIES AND FIELDS
		///

		//
		// Data components
		//
		protected TDSLFSRecordForArchiveTool tdsLfsRecordForArchiveTool;
		
		
		
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
				if (!(Convert.ToBoolean(Session["sgLFS_APP_VIEW"]) && Convert.ToBoolean(Session["sgLFS_APP_ADMIN"])))
				{
					Response.Redirect("./../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
				}

				//--- Validate query string
				if (Request.QueryString["source_page"] == null)
				{
					Response.Redirect("./../error_page.aspx?error=" + "Invalid query string in archive.aspx");
				}

				//--- If coming from default.aspx
				if (Request.QueryString["source_page"] == "default.aspx")
				{
					//--- Set archive tool state
					pNoResults.Visible = false;
					lblResults.Visible = false;
				}

				//--- If coming from archive2.aspx
				if (Request.QueryString["source_page"] == "archive2.aspx")
				{
					//--- Restore archive tool state
					ddlSearch.SelectedIndex = (int)Session["ddlSearchSelectedIndexForAT"];
					tbxSearch.Text = (string)Session["tbxSearchTextForAT"];
					lblHint.Visible = (bool)Session["lblHintVisibleForAT"];
					lblHint.Text = (string)Session["lblHintTextForAT"];	
				
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

		//
		// ddlSearch_SelectedIndexChanged
		//
		protected void ddlSearch_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//--- Set archive tool state
			pNoResults.Visible = false;
			lblResults.Visible = false;
		}

		//
		// btnSubmit_Click
		//
		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			if (Page.IsValid && (tbxSearch.Text.Trim() != ""))
			{
				//--- Get data from database gateway
				tdsLfsRecordForArchiveTool = this.SubmitSearch();
				Session["tdsLfsRecordForArchiveTool"] = tdsLfsRecordForArchiveTool;

				//--- Show results
				if (tdsLfsRecordForArchiveTool.ARCHIVE.DefaultView.Count > 0)
				{
					//--- ... Yes results
					//--- ... Store archive tool state
					Session["ddlSearchSelectedIndexForAT"] = ddlSearch.SelectedIndex;
					Session["tbxSearchTextForAT"] = tbxSearch.Text;
					Session["lblHintVisibleForAT"] = lblHint.Visible;
					Session["lblHintTextForAT"] = lblHint.Text;

					//--- ... Go to results page
					Response.Redirect("archive2.aspx?source_page=archive.aspx&search_results=true");
				}
				else
				{
					//--- ... No results
					pNoResults.Visible = true;
					lblResults.Visible = true;
				}
			}
		}



		/// ////////////////////////////////////////////////////////////////////////
		/// METHODS
		///

		//
		// SubmitSearch
		//
		private TDSLFSRecordForArchiveTool SubmitSearch()
		{
			//--- Create database gateway
			LFSRecordForArchiveToolGateway lfsRecordForArchiveToolGateway = new LFSRecordForArchiveToolGateway();
			TDSLFSRecordForArchiveTool dataSet;

			//--- Get data from database gateway
			switch (ddlSearch.SelectedItem.Value)
			{
				case ("ID#"):
					dataSet = lfsRecordForArchiveToolGateway.GetRecordsByCompanyIdRecordId(Convert.ToInt32(Session["companyID"]), tbxSearch.Text.Trim());
					break;
				
				case ("Client"):
					dataSet = lfsRecordForArchiveToolGateway.GetRecordsByCompanyIdClient(Convert.ToInt32(Session["companyID"]), tbxSearch.Text.Trim());
					break;

				case ("USMH"):
					dataSet = lfsRecordForArchiveToolGateway.GetRecordsByCompanyIdUsmh(Convert.ToInt32(Session["companyID"]), tbxSearch.Text.Trim());
					break;

				case ("DSMH"):
					dataSet = lfsRecordForArchiveToolGateway.GetRecordsByCompanyIdDsmh(Convert.ToInt32(Session["companyID"]), tbxSearch.Text.Trim());
					break;

				case ("Street"):
					dataSet = lfsRecordForArchiveToolGateway.GetRecordsByCompanyIdStreet(Convert.ToInt32(Session["companyID"]), tbxSearch.Text.Trim());
					break;

				default:
					dataSet = null;
					break;
			}

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
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
			this.tdsLfsRecordForArchiveTool = new TDSLFSRecordForArchiveTool();
			((System.ComponentModel.ISupportInitialize)(this.tdsLfsRecordForArchiveTool)).BeginInit();
			// 
			// tdsLfsRecordForArchiveTool
			// 
			this.tdsLfsRecordForArchiveTool.DataSetName = "TDSLfsRecordForArchiveTool";
			this.tdsLfsRecordForArchiveTool.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.tdsLfsRecordForArchiveTool)).EndInit();

		}
		#endregion		


	}
}
