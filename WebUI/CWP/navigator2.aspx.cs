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
    /// <summary>
    /// navigator2
    /// </summary>
	public partial class navigator2 : System.Web.UI.Page
	{
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

		protected TDSLFSRecordForNavigator tdsLfsRecordForNavigator;
        protected TDSLFSRecordForNavigator.NAVIGATORDataTable navigator;






        /// ////////////////////////////////////////////////////////////////////////
		/// EVENTS
		///

		protected void Page_Load(object sender, System.EventArgs e)
		{
            // Register client scripts
            this.RegisterClientScripts();

			if (!IsPostBack)
			{
				// Security check
				if (!Convert.ToBoolean(Session["sgLFS_APP_VIEW"]))
				{
                    Response.Redirect("./../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
				}

				// Validate query string
				if ((Request.QueryString["search_results"] == null) && (Request.QueryString["record_modified"] == null) && (Request.QueryString["record_deleted"] == null))
				{
                    Response.Redirect("./../error_page.aspx?error=" + "Invalid query string in navigator2.aspx");
				}

                // Tag Page
                Session.Remove("navigatorDummy");

				// If coming from navigator.aspx
				if (Request.QueryString["search_results"] != null)
				{
					// ... Restore navigator state
					ddlSearch.SelectedIndex = (int)Session["ddlSearchSelectedIndex"];
					tbxSearch.Text = (string)Session["tbxSearchText"];
					lblHint.Visible = (bool)Session["lblHintVisible"];
					lblHint.Text = (string)Session["lblHintText"];

					// ... Restore searched data
					tdsLfsRecordForNavigator = (TDSLFSRecordForNavigator)Session["tdsLfsRecordForNavigator"];
                    navigator = tdsLfsRecordForNavigator.NAVIGATOR;
                    Session["navigator"] = navigator;
				}
				
				// If coming from target page
				if (Request.QueryString["record_modified"] != null)
				{
					// ...Restore navigator state
					ddlSearch.SelectedIndex = (int)Session["ddlSearchSelectedIndex"];
					tbxSearch.Text = (string)Session["tbxSearchText"];
					lblHint.Visible = (bool)Session["lblHintVisible"];
					lblHint.Text = (string)Session["lblHintText"];

					// ...Reload data
					if (Request.QueryString["record_modified"] == "true")
					{
						tdsLfsRecordForNavigator = this.SubmitSearch();
						Session["tdsLfsRecordForNavigator"] = tdsLfsRecordForNavigator;
                        navigator = tdsLfsRecordForNavigator.NAVIGATOR;
                        Session["navigator"] = navigator;
					}
					else
					{
						tdsLfsRecordForNavigator = (TDSLFSRecordForNavigator)Session["tdsLfsRecordForNavigator"];
                        navigator = tdsLfsRecordForNavigator.NAVIGATOR;
                        Session["navigator"] = navigator;
					}					
				}

				// If coming from delete record
				if (Request.QueryString["record_deleted"] != null)
				{
					// ... Restore navigator state
					ddlSearch.SelectedIndex = (int)Session["ddlSearchSelectedIndex"];
					tbxSearch.Text = (string)Session["tbxSearchText"];
					lblHint.Visible = (bool)Session["lblHintVisible"];
					lblHint.Text = (string)Session["lblHintText"];

					// ... Reload data
					if (Request.QueryString["record_deleted"] == "true")
					{
						tdsLfsRecordForNavigator = this.SubmitSearch();
						Session["tdsLfsRecordForNavigator"] = tdsLfsRecordForNavigator;
                        navigator = tdsLfsRecordForNavigator.NAVIGATOR;
                        Session["navigator"] = navigator;
					}
					else
					{
						tdsLfsRecordForNavigator = (TDSLFSRecordForNavigator)Session["tdsLfsRecordForNavigator"];
                        navigator = tdsLfsRecordForNavigator.NAVIGATOR;
                        Session["navigator"] = navigator;
					}
				}

                // For the total rows
                if (tdsLfsRecordForNavigator.NAVIGATOR.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + tdsLfsRecordForNavigator.NAVIGATOR.Rows.Count;
                    lblTotalRows.Visible = true;
                }
                else
                {
                    lblTotalRows.Visible = false;
                }
			}
			else
			{
				// Restore searched data (if any)
				tdsLfsRecordForNavigator = (TDSLFSRecordForNavigator)Session["tdsLfsRecordForNavigator"];

                // For the total rows
                if (tdsLfsRecordForNavigator.NAVIGATOR.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + tdsLfsRecordForNavigator.NAVIGATOR.Rows.Count;
                    lblTotalRows.Visible = true;
                }
                else
                {
                    lblTotalRows.Visible = false;
                }
			}
		}



		protected void ddlSearch_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			// Set navigator state
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

			Session["ddlSearchSelectedIndex"] = ddlSearch.SelectedIndex;
			Session["tbxSearchText"] = tbxSearch.Text;
			Session["lblHintVisible"] = lblHint.Visible;
			Session["lblHintText"] = lblHint.Text;

			// Go to results page
			Response.Redirect("navigator.aspx?search_results=false");
		}



		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
            Page.Validate("submitText");            
			if (Page.IsValid && (tbxSearch.Text.Trim() != ""))
			{
				// Get data from database gateway
				tdsLfsRecordForNavigator = this.SubmitSearch();
				Session["tdsLfsRecordForNavigator"] = tdsLfsRecordForNavigator;
                navigator = tdsLfsRecordForNavigator.NAVIGATOR;
                Session["navigator"] = navigator;

                grdCWPNavigator.DataBind();

				// Show results
				if (tdsLfsRecordForNavigator.NAVIGATOR.DefaultView.Count <= 0)
                {
					// ... No results
					// ... Store navigator state
					Session["ddlSearchSelectedIndex"] = ddlSearch.SelectedIndex;
					Session["tbxSearchText"] = tbxSearch.Text;
					Session["lblHintVisible"] = lblHint.Visible;
					Session["lblHintText"] = lblHint.Text;

					// ... Go to search page
					Response.Redirect("navigator.aspx?search_results=true");
				}
			}
		}

        

		protected void btnView_Click(object sender, System.EventArgs e)
		{
            Page.Validate("resultsGrid");
            if (Page.IsValid)
            {
                if (this.tdsLfsRecordForNavigator.NAVIGATOR.DefaultView.Count > 0)
                {
                    // Store navigator state
                    Session["ddlSearchSelectedIndex"] = ddlSearch.SelectedIndex;
                    Session["tbxSearchText"] = tbxSearch.Text;
                    Session["lblHintVisible"] = lblHint.Visible;
                    Session["lblHintText"] = lblHint.Text;

                    // Store current lfs master area id
                    Session["lfsMasterAreaId"] = new Guid(hdfSelectedId.Value);

                    // Go to target page
                    Response.Redirect((string)Session["targetPage"] + "?source_page=navigator2.aspx");
                }
            }
		}



		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
            Page.Validate("resultsGrid");
            if (Page.IsValid)
            {
                if (this.tdsLfsRecordForNavigator.NAVIGATOR.DefaultView.Count > 0)
                {
                    // Store navigator state
                    Session["ddlSearchSelectedIndex"] = ddlSearch.SelectedIndex;
                    Session["tbxSearchText"] = tbxSearch.Text;
                    Session["lblHintVisible"] = lblHint.Visible;
                    Session["lblHintText"] = lblHint.Text;

                    // Store currend lfs record                    
                    Session["lfsMasterAreaId"] = new Guid(hdfSelectedId.Value);

                    // Go to delete record page
                    Response.Redirect("delete_record.aspx?source_page=navigator2.aspx");
                }
            }
        }



        protected void grdNavigator_FetchingRows(object sender, EventArgs e)
        {
            tdsLfsRecordForNavigator.NAVIGATOR.DefaultView.RowFilter = "(Deleted = 0) AND (Archived = 0)"; //---> Mario: Este creo que no es necesario por la aplicación del filtro en el método SubmitSearch
        }
        
        

		protected void Page_PreRender(object sender, EventArgs e)
		{
			// Set page title
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

			// Security check
			// ... Delete
			if (Convert.ToBoolean(Session["sgLFS_APP_DELETE"]))
			{
				btnDelete.Visible = true;
				btnDelete.Enabled = true;
			}
			else
			{
				btnDelete.Visible = false;
				btnDelete.Enabled = false;
			}
		}






		/// ////////////////////////////////////////////////////////////////////////
		/// AUXILIAR EVENTS
		///

		protected void lkbtnSignOut_Click(object sender, System.EventArgs e)
		{
			// Sing out
			Response.Redirect((string)Session["loginPage"]);
		}



		private void cvSearchCriteria_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
			// Validate search string
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



        protected void cvSelection_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;

            SaveSelectedId();
            if (hdfSelectedId.Value != "0")
            {
                args.IsValid = true;
            }
        }



        protected void grdCWPNavigator_DataBound(object sender, EventArgs e)
        {
            AddNavigatorNewEmptyFix(grdCWPNavigator);
        }






        /// ////////////////////////////////////////////////////////////////////////
        /// PUBLIC METHODS
        ///
        public TDSLFSRecordForNavigator.NAVIGATORDataTable GetNavigator()
        {
            navigator = (TDSLFSRecordForNavigator.NAVIGATORDataTable)Session["navigatorDummy"];
            if (navigator == null)
            {
                navigator = ((TDSLFSRecordForNavigator.NAVIGATORDataTable)Session["navigator"]);
            }

            return navigator;
        }






		/// ////////////////////////////////////////////////////////////////////////
		/// PRIVATE METHODS
		///

        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./navigator2.js");
        }



		private TDSLFSRecordForNavigator SubmitSearch()
		{
			// Create database gateway
			LFSRecordForNavigatorGateway lfsRecordForNavigatorGateway = new LFSRecordForNavigatorGateway();
			TDSLFSRecordForNavigator dataSet;

			// Get data from database gateway
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

			// Apply filter
			dataSet.NAVIGATOR.DefaultView.RowFilter = "(Deleted = 0) AND (Archived = 0)";

			return dataSet;
		}



        protected void AddNavigatorNewEmptyFix(GridView grdCWPNavigator)
        {
            if (grdCWPNavigator.Rows.Count == 0)
            {
                TDSLFSRecordForNavigator.NAVIGATORDataTable dt = new TDSLFSRecordForNavigator.NAVIGATORDataTable();
                dt.AddNAVIGATORRow(Guid.NewGuid(), -1, "", -1, "", "", "", "", new DateTime(), new DateTime(), new DateTime(), new DateTime(), false, false, false);
                Session["navigatorDummy"] = dt;

                grdCWPNavigator.DataBind();
            }

            // normally executes at all postbacks
            if (grdCWPNavigator.Rows.Count == 1)
            {
                TDSLFSRecordForNavigator.NAVIGATORDataTable dt = (TDSLFSRecordForNavigator.NAVIGATORDataTable)Session["navigatorDummy"];
                if (dt != null)
                {
                    grdCWPNavigator.Rows[0].Visible = false;
                    grdCWPNavigator.Rows[0].Controls.Clear();
                }
            }
        }



        protected void SaveSelectedId()
        {
            bool selected = false;
            hdfSelectedId.Value = "0";
            string stringId = "";

            foreach (GridViewRow row in grdCWPNavigator.Rows)
            {
                // ... Update all rows
                selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                stringId = ((Label)row.FindControl("lblId")).Text.Trim();

                // ... Save selected project
                if (selected)
                {
                    hdfSelectedId.Value = stringId;                    
                }
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
