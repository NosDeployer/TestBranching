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
using System.Web.Security;
using LiquiForce.LFSLive.CWP.DatabaseGateway;
using LiquiForce.LFSLive.CWP.Tools;

namespace LiquiForce.LFSLive.WebUI.CWP
{
	public partial class view_subcontractor : System.Web.UI.Page
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
				if (!Convert.ToBoolean(Session["sgLFS_APP_VIEW"]))
				{
					Response.Redirect("./../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
				}

				//--- Validate query string
				if (((string)Request.QueryString["source_page"] == null) && ((string)Request.QueryString["record_deleted"] == null))
				{
					Response.Redirect("./../error_page.aspx?error=" + "Invalid query string in view_fulllength.aspx");
				}

				//--- If coming from navigator2.aspx or view_subcontractor.aspx
				if (((string)Request.QueryString["source_page"] == "navigator2.aspx") || ((string)Request.QueryString["source_page"] == "view_subcontractor.aspx"))
				{
					//--- Get lfs master area record
					LFSRecordGateway lfsRecordGateway = new LFSRecordGateway();
					tdsLfsRecord = lfsRecordGateway.GetRecordByIdCompanyId((Guid)Session["lfsMasterAreaId"], Convert.ToInt32(Session["companyID"]));

					//--- Store dataset lfs record
					Session["tdsLfsRecord"] = tdsLfsRecord;
				}

				//--- If coming from delete_record.aspx
				if ((string)Request.QueryString["record_deleted"] == "false")
				{
					//--- Restore dataset lfs record
					tdsLfsRecord = (TDSLFSRecord)Session["tdsLfsRecord"];
				}

				//--- Prepare initial data for client
				CompaniesGateway companiesGateway = new CompaniesGateway();
				tbxCOMPANIES_ID.Text = companiesGateway.GetName((int)tdsLfsRecord.LFS_MASTER_AREA.Rows[0]["COMPANIES_ID"], Convert.ToInt32(Session["companyID"]));

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
			//--- Validate page
			Page.Validate();

			if (Page.IsValid)
			{
				//--- Post page changes
				this.PostPageChanges();

				//--- Update database
				this.UpdateDatabase();

				//--- Go to navigator2.aspx
				Response.Redirect("navigator2.aspx?record_modified=true");
			}
		}

		//
		// btnCancel_Click
		//
		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			//--- Go to navigator2.aspx
			Response.Redirect("navigator2.aspx?record_modified=false");
		}

		//
		// btnDelete_Click
		//
		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			//--- Post page changes
			this.PostPageChanges();

			//--- Store currend lfs record
			Session["lfsMasterAreaId"] = new Guid(tbxID.Text);

			//--- Go to delete record page
			Response.Redirect("delete_record.aspx?source_page=view_subcontractor.aspx");
		}

		//
		// Page_PreRender
		//
		protected void Page_PreRender(object sender, EventArgs e)
		{
			//--- Security check

			//--- ... edit
			if (Convert.ToBoolean(Session["sgLFS_APP_EDIT"]))
			{
				//--- Master area
				tbxStreet.ReadOnly = false;
				tbxUSMH.ReadOnly = false;
				tbxDSMH.ReadOnly = false;
				tbxSize_.ReadOnly = false;
				tbxScaledLength.ReadOnly = false;
				tbxP1Date.ReadOnly = false;
				tbxActualLength.ReadOnly = false;
				tbxLiveLats.ReadOnly = false;
				tbxCXIsRemoved.ReadOnly = false;
				tbxM1Date.ReadOnly = false;
				tbxM2Date.ReadOnly = false;
				tbxInstallDate.ReadOnly = false;
				tbxFinalVideo.ReadOnly = false;
				tbxComments.ReadOnly = false;
				cbxIssueIdentified.Enabled = true;
				cbxIssueResolved.Enabled = true;
				cbxFullLengthLining.Enabled = true;
				cbxSubcontractorLining.Enabled = true;
				cbxOutOfScopeInArea.Enabled = true;
				cbxIssueGivenToBayCity.Enabled = true;
				tbxConfirmedSize.ReadOnly = false;
				tbxInstallRate.ReadOnly = false;
				tbxDeadlineDate.ReadOnly = false;
				tbxProposedLiningDate.ReadOnly = false;
				cbxSalesIssue.Enabled = true;
				cbxLFSIssue.Enabled = true;
				cbxClientIssue.Enabled = true;
				cbxInvestigationIssue.Enabled = true;
				tbxPreFlushDate.ReadOnly = false;
				tbxPreVideoDate.ReadOnly = false;

				//--- Buttons
				btnOK.Enabled = true;
				btnOK1.Enabled = true;
				btnCancel.Enabled = true;
				btnCancel1.Enabled = true;
			}
			else
			{
				//--- Master area
				tbxStreet.ReadOnly = true;
				tbxUSMH.ReadOnly = true;
				tbxDSMH.ReadOnly = true;
				tbxSize_.ReadOnly = true;
				tbxScaledLength.ReadOnly = true;
				tbxP1Date.ReadOnly = true;
				tbxActualLength.ReadOnly = true;
				tbxLiveLats.ReadOnly = true;
				tbxCXIsRemoved.ReadOnly = true;
				tbxM1Date.ReadOnly = true;
				tbxM2Date.ReadOnly = true;
				tbxInstallDate.ReadOnly = true;
				tbxFinalVideo.ReadOnly = true;
				tbxComments.ReadOnly = true;
				cbxIssueIdentified.Enabled = false;
				cbxIssueResolved.Enabled = false;
				cbxFullLengthLining.Enabled = false;
				cbxSubcontractorLining.Enabled = false;
				cbxOutOfScopeInArea.Enabled = false;
				cbxIssueGivenToBayCity.Enabled = false;
				tbxConfirmedSize.ReadOnly = true;
				tbxInstallRate.ReadOnly = true;
				tbxDeadlineDate.ReadOnly = true;
				tbxProposedLiningDate.ReadOnly = true;
				cbxSalesIssue.Enabled = false;
				cbxLFSIssue.Enabled = false;
				cbxClientIssue.Enabled = false;
				cbxInvestigationIssue.Enabled = false;
				tbxPreFlushDate.ReadOnly = true;
				tbxPreVideoDate.ReadOnly = true;
				
				//--- Buttons
				btnOK.Enabled = false;
				btnOK1.Enabled = false;
				btnCancel.Enabled = true;
				btnCancel1.Enabled = true;
			}

			//--- ... Delete
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

			//--- ... Admin
			if (Convert.ToBoolean(Session["sgLFS_APP_ADMIN"]))
			{
				tbxInstallRate.Visible = true;
				lblInstallRate.Visible = true;
			}
			else
			{
				tbxInstallRate.Visible = false;
				lblInstallRate.Visible = false;
			}
		}
		


		/// ////////////////////////////////////////////////////////////////////////
		/// AUXILIAR EVENTS
		///

		//
		// btnPrevious_Click
		//
		protected void btnPrevious_Click(object sender, System.EventArgs e)
		{
			//--- Validate page
			Page.Validate();

			if (Page.IsValid)
			{	
				//--- Post page changes
				PostPageChanges();

				//--- Update database
				UpdateDatabase();

				//--- Get previous record
				Session["lfsMasterAreaId"] = Navigator.GetPreviousId((TDSLFSRecordForNavigator)Session["tdsLfsRecordForNavigator"], new Guid(tbxID.Text));

				//--- Display new record
				Response.Redirect("view_subcontractor.aspx?source_page=view_subcontractor.aspx");
			}
		}

		//
		// btnNext_Click
		//
		protected void btnNext_Click(object sender, System.EventArgs e)
		{
			//--- Validate page
			Page.Validate();

			if (Page.IsValid)
			{	
				//--- Post page changes
				PostPageChanges();

				//--- Update database
				UpdateDatabase();

				//--- Get next record
				Session["lfsMasterAreaId"] = Navigator.GetNextId((TDSLFSRecordForNavigator)Session["tdsLfsRecordForNavigator"], new Guid(tbxID.Text));

				//--- Display new record
				Response.Redirect("view_subcontractor.aspx?source_page=view_subcontractor.aspx");
			}
		}

		//
		// lkbtnSignOut_Click
		//
		protected void lkbtnSignOut_Click(object sender, System.EventArgs e)
		{
			//--- Sing out
			Response.Redirect((string)Session["loginPage"]);
		}

		//
		// lkbtnMenu_Click
		//
		protected void lkbtnMenu_Click(object sender, System.EventArgs e)
		{
			//--- Go to default.aspx
			Response.Redirect("./../default.aspx");
		}

		//
		// Date_ServerValidate
		//
		private void Date_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
			args.IsValid = Validator.IsValidDate(args.Value.Trim());
		}

		//
		// cvScaledLength_ServerValidate
		//
		private void cvScaledLength_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
			args.IsValid = Distance.IsValidDistance(args.Value.Trim());
		}

		//
		// cvActualLength_ServerValidate
		//
		private void cvActualLength_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
            cvActualLength.ErrorMessage = "";
            bool isValid = true;

            if (Distance.IsValidDistance(args.Value.Trim()) || tbxActualLength.Text.Trim() == "")
            {
                foreach (TDSLFSRecord.LFS_JUNCTION_LINER2Row lfsJunctionLiner2Row in tdsLfsRecord.LFS_JUNCTION_LINER2)
                {
                    if (!lfsJunctionLiner2Row.IsDistanceFromUSMHNull() && lfsJunctionLiner2Row.DistanceFromUSMH >= 0)
                    {
                        Distance length = new Distance(tbxActualLength.Text.ToString()) - new Distance(lfsJunctionLiner2Row.DistanceFromUSMH.ToString());
                        if (length.ToDoubleInEng3() < 0)
                        {
                            isValid = false;
                            cvActualLength.ErrorMessage = "Actual Length must be greater than the Distance From USMH of its laterals";
                        }
                    }
                }
                args.IsValid = isValid;
            }
            else
            {
                cvActualLength.ErrorMessage = "Invalid data";
                args.IsValid = false;
            }
		}



        /// ////////////////////////////////////////////////////////////////////////
		/// METHODS
		///

		//
		// PostPageChanges
		//
		private void PostPageChanges()
		{
			//--- Post lfs master area changes
			TDSLFSRecord.LFS_MASTER_AREARow lfsMasterAreaRow = tdsLfsRecord.LFS_MASTER_AREA.FindByIDCOMPANY_ID(new Guid(tbxID.Text), Convert.ToInt32(Session["companyID"]));
			
			if (tbxStreet.Text.Trim() != "") lfsMasterAreaRow.Street = tbxStreet.Text.Trim(); else lfsMasterAreaRow.SetStreetNull();
			if (tbxUSMH.Text.Trim() != "") lfsMasterAreaRow.USMH = tbxUSMH.Text.Trim(); else lfsMasterAreaRow.SetUSMHNull();
			if (tbxDSMH.Text.Trim() != "") lfsMasterAreaRow.DSMH = tbxDSMH.Text.Trim(); else lfsMasterAreaRow.SetDSMHNull();
			if (tbxSize_.Text.Trim() != "") lfsMasterAreaRow.Size_ = tbxSize_.Text.Trim(); else lfsMasterAreaRow.SetSize_Null();
			if (tbxScaledLength.Text.Trim() != "") lfsMasterAreaRow.ScaledLength = tbxScaledLength.Text.Trim(); else lfsMasterAreaRow.SetScaledLengthNull();
			if (tbxP1Date.Text.Trim() != "") lfsMasterAreaRow.P1Date = DateTime.Parse(tbxP1Date.Text.Trim()); else lfsMasterAreaRow.SetP1DateNull();

            //--- update DistanceFromDSMH
            foreach (TDSLFSRecord.LFS_JUNCTION_LINER2Row lfsJunctionLiner2Row in tdsLfsRecord.LFS_JUNCTION_LINER2)
            {
                if (!lfsJunctionLiner2Row.IsDistanceFromUSMHNull() && lfsJunctionLiner2Row.DistanceFromUSMH >= 0)
                {
                    Distance length = new Distance(tbxActualLength.Text.Trim()) - new Distance(lfsJunctionLiner2Row.DistanceFromUSMH.ToString());
                    lfsJunctionLiner2Row.DistanceFromDSMH = length.ToDoubleInEng3();
                }
            }

            if (tbxActualLength.Text.Trim() != "") lfsMasterAreaRow.ActualLength = tbxActualLength.Text.Trim(); else lfsMasterAreaRow.SetActualLengthNull();
			if (tbxLiveLats.Text.Trim() != "") lfsMasterAreaRow.LiveLats = Double.Parse(tbxLiveLats.Text.Trim()); else lfsMasterAreaRow.SetLiveLatsNull();
			if (tbxCXIsRemoved.Text.Trim() != "") lfsMasterAreaRow.CXIsRemoved = tbxCXIsRemoved.Text.Trim(); else lfsMasterAreaRow.SetCXIsRemovedNull();
			if (tbxM1Date.Text.Trim() != "") lfsMasterAreaRow.M1Date = DateTime.Parse(tbxM1Date.Text.Trim()); else lfsMasterAreaRow.SetM1DateNull();
			if (tbxM2Date.Text.Trim() != "") lfsMasterAreaRow.M2Date = DateTime.Parse(tbxM2Date.Text.Trim()); else lfsMasterAreaRow.SetM2DateNull();
			if (tbxInstallDate.Text.Trim() != "") lfsMasterAreaRow.InstallDate = DateTime.Parse(tbxInstallDate.Text.Trim()); else lfsMasterAreaRow.SetInstallDateNull();
			if (tbxFinalVideo.Text.Trim() != "") lfsMasterAreaRow.FinalVideo = DateTime.Parse(tbxFinalVideo.Text.Trim()); else lfsMasterAreaRow.SetFinalVideoNull();
			if (tbxComments.Text.Trim() != "") lfsMasterAreaRow.Comments = tbxComments.Text.Trim(); else lfsMasterAreaRow.SetCommentsNull();
			lfsMasterAreaRow.IssueIdentified = cbxIssueIdentified.Checked;
			lfsMasterAreaRow.IssueResolved = cbxIssueResolved.Checked;
			lfsMasterAreaRow.FullLengthLining = cbxFullLengthLining.Checked;
			lfsMasterAreaRow.SubcontractorLining = cbxSubcontractorLining.Checked;
			lfsMasterAreaRow.OutOfScopeInArea = cbxOutOfScopeInArea.Checked;
			lfsMasterAreaRow.IssueGivenToBayCity = cbxIssueGivenToBayCity.Checked;
			if (tbxConfirmedSize.Text.Trim() != "") lfsMasterAreaRow.ConfirmedSize = Int32.Parse(tbxConfirmedSize.Text.Trim()); else lfsMasterAreaRow.SetConfirmedSizeNull();
			if (tbxInstallRate.Text.Trim() != "") lfsMasterAreaRow.InstallRate = Decimal.Parse(tbxInstallRate.Text.Trim()); else lfsMasterAreaRow.SetInstallRateNull();
			if (tbxDeadlineDate.Text.Trim() != "") lfsMasterAreaRow.DeadlineDate = DateTime.Parse(tbxDeadlineDate.Text.Trim()); else lfsMasterAreaRow.SetDeadlineDateNull();
			if (tbxProposedLiningDate.Text.Trim() != "") lfsMasterAreaRow.ProposedLiningDate = DateTime.Parse(tbxProposedLiningDate.Text.Trim()); else lfsMasterAreaRow.SetProposedLiningDateNull();
			lfsMasterAreaRow.SalesIssue = cbxSalesIssue.Checked;
			lfsMasterAreaRow.LFSIssue = cbxLFSIssue.Checked;
			lfsMasterAreaRow.ClientIssue = cbxClientIssue.Checked;
			lfsMasterAreaRow.InvestigationIssue = cbxInvestigationIssue.Checked;
			if (tbxPreFlushDate.Text.Trim() != "") lfsMasterAreaRow.PreFlushDate = DateTime.Parse(tbxPreFlushDate.Text.Trim()); else lfsMasterAreaRow.SetPreFlushDateNull();
			if (tbxPreVideoDate.Text.Trim() != "") lfsMasterAreaRow.PreVideoDate = DateTime.Parse(tbxPreVideoDate.Text.Trim()); else lfsMasterAreaRow.SetPreVideoDateNull();
			if (tbxActualLength.Text.Trim() != "") lfsMasterAreaRow.SteelTapeThruPipe = tbxActualLength.Text.Trim(); else lfsMasterAreaRow.SetSteelTapeThruPipeNull(); // SYNCHRONIZED

			//--- update ScaledLength1
			Distance doubleDistance = new Distance(tbxScaledLength.Text.Trim());
			if (tbxScaledLength.Text.Trim() != "") lfsMasterAreaRow.ScaledLength1 = doubleDistance.ToFeetDouble(); else lfsMasterAreaRow.SetScaledLength1Null();

			//--- Update m2 tables' reverse setup
			foreach (TDSLFSRecord.LFS_M2_TABLESRow lfsM2TablesRow in tdsLfsRecord.LFS_M2_TABLES)
			{
				if (!lfsM2TablesRow.IsDistanceToCentreOfLateralNull()) 
				{
					lfsM2TablesRow.ReverseSetup = Distance.Subtract(lfsMasterAreaRow.IsActualLengthNull() ? "" : lfsMasterAreaRow.ActualLength, lfsM2TablesRow.DistanceToCentreOfLateral);
				}
			}

			//--- Store dataset lfs record
			Session["tdsLfsRecord"] = tdsLfsRecord;
		}

		//
		// UpdateDatabase
		//
		private void UpdateDatabase()
		{
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

			//--- Store datasets
			Session["tdsLfsRecord"] = tdsLfsRecord;
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
			this.tdsLfsRecord = new TDSLFSRecord();
			((System.ComponentModel.ISupportInitialize)(this.tdsLfsRecord)).BeginInit();
			this.cvActualLength.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.cvActualLength_ServerValidate);
			this.cvPreFlushDate.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.Date_ServerValidate);
			this.cvPreVideoDate.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.Date_ServerValidate);
			this.cvProposedLiningDate.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.Date_ServerValidate);
			this.cvDeadlineDate.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.Date_ServerValidate);
			this.cvP1Date.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.Date_ServerValidate);
			this.cvM1Date.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.Date_ServerValidate);
			this.cvM2Date.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.Date_ServerValidate);
			this.cvInstallDate.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.Date_ServerValidate);
			this.cvFinalVideo.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.Date_ServerValidate);
			// 
			// tdsLfsRecord
			// 
			this.tdsLfsRecord.DataSetName = "TDSLFSRecord";
			this.tdsLfsRecord.Locale = new System.Globalization.CultureInfo("en-US");
			this.cvScaledLength.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.cvScaledLength_ServerValidate);
			((System.ComponentModel.ISupportInitialize)(this.tdsLfsRecord)).EndInit();

		}
		#endregion


		
	}
}
