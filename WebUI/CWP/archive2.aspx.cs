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
    /// <summary>
    /// archive2
    /// </summary>
	public partial class archive2 : System.Web.UI.Page
	{
		///////////////////////////////////////////////////////////////////////////
		/// PROPERTIES AND FIELDS
		///
		protected TDSLFSRecordForArchiveTool tdsLfsRecordForArchiveTool;
        protected TDSLFSRecordForArchiveTool.ARCHIVEDataTable archiveTool; 
		
		
		



		///////////////////////////////////////////////////////////////////////////
		/// EVENTS
		///
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

				//--- If coming from archive.aspx
				if (Request.QueryString["source_page"] == "archive.aspx")
				{
					//--- Restore archive tool state
					ddlSearch.SelectedIndex = (int)Session["ddlSearchSelectedIndexForAT"];
					tbxSearch.Text = (string)Session["tbxSearchTextForAT"];
					lblHint.Visible = (bool)Session["lblHintVisibleForAT"];
					lblHint.Text = (string)Session["lblHintTextForAT"];

					//--- Restore searched data
					tdsLfsRecordForArchiveTool = (TDSLFSRecordForArchiveTool)Session["tdsLfsRecordForArchiveTool"];
                    archiveTool = tdsLfsRecordForArchiveTool.ARCHIVE;
                    Session["archiveTool"] = archiveTool;
				}
			}
			else
			{
				//--- Restore searched data (if any)
				tdsLfsRecordForArchiveTool = (TDSLFSRecordForArchiveTool)Session["tdsLfsRecordForArchiveTool"];
                archiveTool = tdsLfsRecordForArchiveTool.ARCHIVE;
                Session["archiveTool"] = archiveTool;
			}
		}



		protected void ddlSearch_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//--- Store archive tool state
			Session["ddlSearchSelectedIndexForAT"] = ddlSearch.SelectedIndex;
			Session["tbxSearchTextForAT"] = tbxSearch.Text;
			Session["lblHintVisibleForAT"] = lblHint.Visible;
			Session["lblHintTextForAT"] = lblHint.Text;

			//--- Go to results page
			Response.Redirect("archive.aspx?source_page=archive2.aspx&search_results=false");
		}



		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{
			if (Page.IsValid && (tbxSearch.Text.Trim() != ""))
			{
				//--- Get data from database gateway
				tdsLfsRecordForArchiveTool = this.SubmitSearch();
				Session["tdsLfsRecordForArchiveTool"] = tdsLfsRecordForArchiveTool;
                archiveTool = tdsLfsRecordForArchiveTool.ARCHIVE;
                Session["archiveTool"] = archiveTool;

				//--- Show results
				if (tdsLfsRecordForArchiveTool.ARCHIVE.DefaultView.Count > 0)
				{
					//... Yes results
					grdArchive2.DataBind();
				}
				else
				{
					//.... No results
					//... Store archive tool state
					Session["ddlSearchSelectedIndexForAT"] = ddlSearch.SelectedIndex;
					Session["tbxSearchTextForAT"] = tbxSearch.Text;
					Session["lblHintVisibleForAT"] = lblHint.Visible;
					Session["lblHintTextForAT"] = lblHint.Text;

					//... Go to search page
					Response.Redirect("archive.aspx?source_page=archive2.aspx&search_results=true");
				}
			}
		}
		

		
        protected void btnArchive_Click(object sender, System.EventArgs e)
		{
            int companyId = Int32.Parse(Session["companyID"].ToString());

			// Archive selected records
            foreach (GridViewRow row in grdArchive2.Rows)
            {
                Guid id = new Guid(((Label)row.FindControl("lblId")).Text);
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                if (selected)
                {
                    ArchiveRecord(id, companyId, true);
                }
            }

			// Repeat search to get updated data
			this.btnSubmit_Click(null, null);
		}

		

		protected void btnUnarchive_Click(object sender, System.EventArgs e)
		{
            int companyId = Int32.Parse(Session["companyID"].ToString());

            foreach (GridViewRow row in grdArchive2.Rows)
            {
                Guid id = new Guid(((Label)row.FindControl("lblId")).Text);
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                if (selected)
                {
                    ArchiveRecord(id, companyId, false);
                }
            }

			// Repeat search to get updated data
			this.btnSubmit_Click(null, null);
		}






        /// ////////////////////////////////////////////////////////////////////////
        /// AUXILIAR EVENTS
        ///

        protected void grdArchive2_DataBound(object sender, EventArgs e)
        {
            AddArchiveEmptyFix(grdArchive2);
        }






        /// ////////////////////////////////////////////////////////////////////////
        /// PUBLIC METHODS
        ///

        public TDSLFSRecordForArchiveTool.ARCHIVEDataTable GetArchiveNew()
        {
            archiveTool = (TDSLFSRecordForArchiveTool.ARCHIVEDataTable)Session["archiveToolDummy"];
            if (archiveTool == null)
            {
                archiveTool = (TDSLFSRecordForArchiveTool.ARCHIVEDataTable)Session["archiveTool"];
            }

            return archiveTool;
        }






		/// ////////////////////////////////////////////////////////////////////////
		/// PRIVATE METHODS
		///		

        protected void AddArchiveEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                TDSLFSRecordForArchiveTool.ARCHIVEDataTable dt = new TDSLFSRecordForArchiveTool.ARCHIVEDataTable();
                dt.AddARCHIVERow(Guid.NewGuid(), -1, "", -1, "", "", "", "", false, false);
                Session["archiveToolDummy"] = dt;

                grdView.DataBind();
            }

            // normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                TDSLFSRecordForArchiveTool.ARCHIVEDataTable dt = (TDSLFSRecordForArchiveTool.ARCHIVEDataTable)Session["archiveToolDummy"];
                if (dt != null)
                {
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



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

		

		private void ArchiveRecord(Guid id, int companyId, bool archive)
		{
			LFSRecordGateway lfsRecordGateway = new LFSRecordGateway();
			TDSLFSRecord tdsLfsRecord = lfsRecordGateway.GetRecordByIdCompanyId(id, companyId);
			
			//--- Archive record
			
			//--- ... Master area
			TDSLFSRecord.LFS_MASTER_AREARow lfsMasterAreaRow = tdsLfsRecord.LFS_MASTER_AREA.FindByIDCOMPANY_ID(id, companyId);
			lfsMasterAreaRow.Archived = archive;

			//--- ... Point repairs
			foreach (TDSLFSRecord.LFS_POINT_REPAIRSRow lfsPointRepairsRow in tdsLfsRecord.LFS_POINT_REPAIRS)
			{
				lfsPointRepairsRow.Archived = archive;
			}

			//--- ... M2 tables
			foreach (TDSLFSRecord.LFS_M2_TABLESRow lfsM2TablesRow in tdsLfsRecord.LFS_M2_TABLES)
			{
				lfsM2TablesRow.Archived = archive;
			}

			//--- ... Point repairs
			foreach (TDSLFSRecord.LFS_JUNCTION_LINERRow lfsJunctionLinerRow in tdsLfsRecord.LFS_JUNCTION_LINER)
			{
				lfsJunctionLinerRow.Archived = archive;
			}

			//--- Update database
			try
			{
				lfsRecordGateway.UpdateRecord(tdsLfsRecord);
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
			this.tdsLfsRecordForArchiveTool.DataSetName = "TDSLFSRecordForArchiveTool";
			this.tdsLfsRecordForArchiveTool.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.tdsLfsRecordForArchiveTool)).EndInit();

		}
		#endregion


	}
}
