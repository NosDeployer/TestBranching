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
	public partial class delete_record : System.Web.UI.Page
	{
        ///////////////////////////////////////////////////////////////////////////
        /// PROPERTIES AND FIELDS
        ///

        //
        // Data components
        //
        protected TDSLFSRecord tdsLfsRecord;
        
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
				if (!(Convert.ToBoolean(Session["sgLFS_APP_VIEW"]) && Convert.ToBoolean(Session["sgLFS_APP_DELETE"])))
				{
					Response.Redirect("./../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
				}

				//--- Validate query string
				if ((Request.QueryString["source_page"] == null))
				{
					Response.Redirect("./../error_page.aspx?error=" + "Invalid query string in delete_record.aspx");
				}

				//--- If coming from navigator2.aspx
				if ((string)Request.QueryString["source_page"] == "navigator2.aspx")
				{
					//--- Get lfs master area record
					LFSRecordGateway lfsRecordGateway = new LFSRecordGateway();
					tdsLfsRecord = lfsRecordGateway.GetRecordByIdCompanyId((Guid)Session["lfsMasterAreaId"], Convert.ToInt32(Session["companyID"]));
				}
				else
				{
					//--- Restore dataset lfs record
					tdsLfsRecord = (TDSLFSRecord)Session["tdsLfsRecord"];
				}

				//--- Store datasets
				Session["tdsLfsRecord"] = tdsLfsRecord;

				//--- Databind
				Page.DataBind();
			}
			else
			{
				//--- Restore dataset lfs record
				tdsLfsRecord = (TDSLFSRecord)Session["tdsLfsRecord"];
			}
		}

		//
		// btnOK_Click
		//
		protected void btnOK_Click(object sender, System.EventArgs e)
		{
			//--- Delete record

			//--- ... Master area
			TDSLFSRecord.LFS_MASTER_AREARow lfsMasterAreaRow = tdsLfsRecord.LFS_MASTER_AREA.FindByIDCOMPANY_ID(new Guid(tbxID.Text), Convert.ToInt32(Session["companyID"]));
			lfsMasterAreaRow.Deleted = true;

			//--- ... Point repairs
			foreach (TDSLFSRecord.LFS_POINT_REPAIRSRow lfsPointRepairsRow in tdsLfsRecord.LFS_POINT_REPAIRS)
			{
				lfsPointRepairsRow.Deleted = true;
			}

			//--- ... M2 tables
			foreach (TDSLFSRecord.LFS_M2_TABLESRow lfsM2TablesRow in tdsLfsRecord.LFS_M2_TABLES)
			{
				lfsM2TablesRow.Deleted = true;
			}

			//--- ... Junction Liner
			foreach (TDSLFSRecord.LFS_JUNCTION_LINERRow lfsJunctionLinerRow in tdsLfsRecord.LFS_JUNCTION_LINER)
			{
				lfsJunctionLinerRow.Deleted = true;
			}

            //--- ... Junction Liner2
            foreach (TDSLFSRecord.LFS_JUNCTION_LINER2Row lfsJunctionLiner2Row in tdsLfsRecord.LFS_JUNCTION_LINER2)
            {
                lfsJunctionLiner2Row.Deleted = true;
            }

			//--- Update database
			try
			{
				LFSRecordGateway lfsRecordGateway = new LFSRecordGateway();
				lfsRecordGateway.UpdateRecord(tdsLfsRecord);
			}
			catch(Exception ex)
			{
				Response.Redirect("./../error_page.aspx?error=" + ex.Message);
			}

			//--- Go to source page
			Response.Redirect("navigator2.aspx?record_deleted=true");
		}

		//
		// btnCancel_Click
		//
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			//--- Go to source page
			Response.Redirect(Request.QueryString["source_page"] + "?record_deleted=false");
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
			this.tdsLfsRecord = new TDSLFSRecord();
			((System.ComponentModel.ISupportInitialize)(this.tdsLfsRecord)).BeginInit();
			// 
			// tdsLfsRecord
			// 
			this.tdsLfsRecord.DataSetName = "TDSLFSRecord";
			this.tdsLfsRecord.Locale = new System.Globalization.CultureInfo("en-US");
			((System.ComponentModel.ISupportInitialize)(this.tdsLfsRecord)).EndInit();

		}
		#endregion


	}
}
