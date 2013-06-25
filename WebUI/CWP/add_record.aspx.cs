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
using LiquiForce.LFSLive.CWP.BL;
using LiquiForce.LFSLive.CWP.Tools;
using LiquiForce.LFSLive.Server;
using System.Data.SqlClient;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP
{
    /// <summary>
    /// add_record
    /// </summary>
	public partial class add_record : System.Web.UI.Page
	{
		///////////////////////////////////////////////////////////////////////////
		/// PROPERTIES AND FIELDS
		///
        protected AddRecordTDS addRecordTDS;
        protected AddRecordTDS.PointRepairsDataTable pointRepairs;
        protected TDSLFSRecord tdsLfsRecord;	
		private Guid newId = new Guid("CA761232-ED42-11CE-BACD-00AA0057B223");

		




		/// ////////////////////////////////////////////////////////////////////////
		/// EVENTS
		///

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				//--- Security check
				if (!(Convert.ToBoolean(Session["sgLFS_APP_VIEW"]) && Convert.ToBoolean(Session["sgLFS_APP_ADD"])))
				{
					Response.Redirect("./../error_page.aspx?error=" + "You are not authorized to add new records. Contact your system administrator.");
				}

				//... Add lfs master area record
                TDSLFSRecord.LFS_MASTER_AREARow lfsMasterAreaRow = tdsLfsRecord.LFS_MASTER_AREA.NewLFS_MASTER_AREARow();
				lfsMasterAreaRow.ID = newId;
				lfsMasterAreaRow.COMPANY_ID = Convert.ToInt32(Session["companyID"]);
				lfsMasterAreaRow.RecordID = "";
				tdsLfsRecord.LFS_MASTER_AREA.AddLFS_MASTER_AREARow(lfsMasterAreaRow);

                //... Prepare initial 
                Session.Remove("pointRepairDummy");
                addRecordTDS = new AddRecordTDS();
                lblMaxNumber.Visible = false;
				
                //... Store datasets
				Session["tdsLfsRecord"] = tdsLfsRecord;
                Session["addRecordTDS"] = addRecordTDS;
                pointRepairs = addRecordTDS.PointRepairs;
                Session["pointRepairs"] = pointRepairs;

                // ... For clients
                CompaniesGateway companiesGateway = new CompaniesGateway();
				DataSet dsCompanies = companiesGateway.GetCompaniesForDropDownList("-1", "", Convert.ToInt32(Session["companyID"]));

				ddlCOMPANIES_ID.DataSource = dsCompanies;
				ddlCOMPANIES_ID.DataValueField = "COMPANIES_ID";
				ddlCOMPANIES_ID.DataTextField = "NAME";
				ddlCOMPANIES_ID.SelectedValue = "-1";
				
				//... Databind
				ddlCOMPANIES_ID.DataBind();                
			}
			else
			{
				//... Restore dataset lfs record
				tdsLfsRecord = (TDSLFSRecord)Session["tdsLfsRecord"];
                addRecordTDS = (AddRecordTDS)Session["addRecordTDS"];
			}
		}		



        protected void grdPointRepairs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Guid id = new Guid(((Label)grdPointRepairs.Rows[e.RowIndex].Cells[0].FindControl("lblId")).Text);
            int refId = Int32.Parse(((Label)grdPointRepairs.Rows[e.RowIndex].Cells[1].FindControl("lblRefId")).Text);
            int companyId = Int32.Parse(((Label)grdPointRepairs.Rows[e.RowIndex].Cells[3].FindControl("lblCOMPANY_ID")).Text);  

            AddRecordPointRepairs model = new AddRecordPointRepairs(addRecordTDS);
            model.Delete(id, refId, companyId);

            Session["addRecordTDS"] = addRecordTDS;
        }



        protected void grdPointRepairs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    GrdPointRepairsAdd();
                    break;
            }
        }



        protected void grdPointRepairs_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {            
             Page.Validate("repairsEdit");
             if (Page.IsValid)
             {
                 Guid id = new Guid(((Label)grdPointRepairs.Rows[e.RowIndex].Cells[0].FindControl("lblId")).Text);
                 int refId = Int32.Parse(((Label)grdPointRepairs.Rows[e.RowIndex].Cells[1].FindControl("lblRefId")).Text);
                 int companyId = Int32.Parse(((Label)grdPointRepairs.Rows[e.RowIndex].Cells[3].FindControl("lblCOMPANY_ID")).Text);

                 string repairSize = ((TextBox)grdPointRepairs.Rows[e.RowIndex].Cells[6].FindControl("tbxRepairSizeEdit")).Text;
                 DateTime? installDate = null; if (((RadDatePicker)grdPointRepairs.Rows[e.RowIndex].Cells[8].FindControl("tkrdpInstallDateEdit")).SelectedDate.HasValue) installDate = ((RadDatePicker)grdPointRepairs.Rows[e.RowIndex].Cells[8].FindControl("tkrdpInstallDateEdit")).SelectedDate.Value;
                 string distance = ((TextBox)grdPointRepairs.Rows[e.RowIndex].Cells[5].FindControl("tbxDistanceEdit")).Text;
                 decimal? cost = null; if (((TextBox)grdPointRepairs.Rows[e.RowIndex].Cells[9].FindControl("tbxCostEdit")).Text != "") cost = Decimal.Parse(((TextBox)grdPointRepairs.Rows[e.RowIndex].Cells[9].FindControl("tbxCostEdit")).Text);
                 int? reinstates = null; if (((TextBox)grdPointRepairs.Rows[e.RowIndex].Cells[7].FindControl("tbxReinstatesEdit")).Text != "") reinstates = Int32.Parse(((TextBox)grdPointRepairs.Rows[e.RowIndex].Cells[7].FindControl("tbxReinstatesEdit")).Text);

                 AddRecordPointRepairs model = new AddRecordPointRepairs(addRecordTDS);
                 model.Update(id, refId, companyId, repairSize, installDate, distance, cost, reinstates);

                 Session["addRecordTDS"] = addRecordTDS;
             }
             else
             {
                 e.Cancel = true;
             }
        }
        
		

		protected void btnOK_Click(object sender, System.EventArgs e)
		{
            Save();            
		}

		

		protected void btnCancel_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("./../default.aspx");
		}

		

		protected void Page_PreRender(object sender, EventArgs e)
		{
			// ... Security check
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

        protected void grdPointRepairs_DataBound(object sender, EventArgs e)
        {
            AddPointRepairsNewEmptyFix(grdPointRepairs);
        }



        protected void grdPointRepairs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {               
                Guid id = new Guid(((Label)e.Row.FindControl("lblId")).Text);
                int refId = Int32.Parse(((Label)e.Row.FindControl("lblRefId")).Text);
                int companyId = Int32.Parse(((Label)e.Row.FindControl("lblCOMPANY_ID")).Text);

                AddRecordPointRepairsGateway addRecordPointRepairsGateway = new AddRecordPointRepairsGateway(addRecordTDS);
                
                if (addRecordPointRepairsGateway.Table.Rows.Count > 0)
                {
                    if (addRecordPointRepairsGateway.GetInstallDate(id, refId, companyId).HasValue)
                    {
                        ((RadDatePicker)e.Row.FindControl("tkrdpInstallDateEdit")).SelectedDate = addRecordPointRepairsGateway.GetInstallDate(id, refId, companyId);
                    }
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                // If the limit is reached
                AddRecordPointRepairs addRecordPointRepairs = new AddRecordPointRepairs(addRecordTDS);
                string newDetailId = addRecordPointRepairs.GetNewPointRepairsDetailId(addRecordTDS);

                if (newDetailId == "-1")
                {
                    ((RadDatePicker)e.Row.FindControl("tkrdpInstallDateFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxRepairSizeFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxDistanceFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxCostFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxReinstatesFooter")).Visible = false;
                    e.Row.FindControl("ibtnAdd").Visible = false;
                    lblMaxNumber.Visible = true;
                }
                else
                {
                    ((RadDatePicker)e.Row.FindControl("tkrdpInstallDateFooter")).Visible = true;                    
                    ((TextBox)e.Row.FindControl("tbxRepairSizeFooter")).Visible = true;
                    ((TextBox)e.Row.FindControl("tbxDistanceFooter")).Visible = true;
                    ((TextBox)e.Row.FindControl("tbxCostFooter")).Visible = true;
                    ((TextBox)e.Row.FindControl("tbxReinstatesFooter")).Visible = true;
                    e.Row.FindControl("ibtnAdd").Visible = true;
                    lblMaxNumber.Visible = false;
                }
            }
        }
        	


		protected void lkbtnSignOut_Click(object sender, System.EventArgs e)
		{
			Response.Redirect((string)Session["loginPage"]);
		}

		

		protected void lkbtnMenu_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("./../default.aspx");
		}

		

		private void cvRecordID1_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
			// Check whether the RecordID is already in use
			LFSMasterAreaGateway lfsMasterAreaGateway = new LFSMasterAreaGateway();
			args.IsValid = !lfsMasterAreaGateway.IsRecordIdInUse(tbxRecordID.Text.Trim(), Convert.ToInt32(Session["companyID"]));
		}

		

		private void cvRecordID2_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
			// Check whether the RecordID is archived
			LFSMasterAreaGateway lfsMasterAreaGateway = new LFSMasterAreaGateway();
			args.IsValid = !lfsMasterAreaGateway.IsRecordIdArchived(tbxRecordID.Text.Trim(), Convert.ToInt32(Session["companyID"]));
		}

		

		private void cvCOMPANIES_ID_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
			// Check whether the user selected a client
			args.IsValid = (ddlCOMPANIES_ID.SelectedValue == "-1") ? false : true;
		}

		

		private void Date_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
			args.IsValid = Validator.IsValidDate(args.Value.Trim());
		}

		

		private void cvScaledLength_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
			args.IsValid = Distance.IsValidDistance(args.Value.Trim());
		}
		
		

		private void cvActualLength_ServerValidate(object source, System.Web.UI.WebControls.ServerValidateEventArgs args)
		{
			args.IsValid = Distance.IsValidDistance(args.Value.Trim());
		}





        
        /// ////////////////////////////////////////////////////////////////////////
        /// PUBLIC METHODS
        ///

        public AddRecordTDS.PointRepairsDataTable GetPointRepairsNew()
        {
            pointRepairs = (AddRecordTDS.PointRepairsDataTable)Session["pointRepairDummy"];
            if (pointRepairs == null)
            {
                pointRepairs = (AddRecordTDS.PointRepairsDataTable)Session["pointRepairs"];
            }

            return pointRepairs;
        }



        public void DummyPointRepairsNew(Guid ID, int RefID, int COMPANY_ID)
        {
        }






		/// ////////////////////////////////////////////////////////////////////////
		/// PRIVATE METHODS
		///

        private void Save()
        {
            Page.Validate("addRecord");

            if (Page.IsValid)
            {
                // Point Repairs Gridview
                // ... If the gridview is edition mode
                if (grdPointRepairs.EditIndex >= 0)
                {
                    grdPointRepairs.UpdateRow(grdPointRepairs.EditIndex, true);
                }

                // ... Save point repairs data at footer
                GrdPointRepairsAdd();

                // Save the rest of data
                this.PostPageChanges();
                this.UpdateDatabase();

                // Go to default.aspx
                Response.Redirect("./../default.aspx");
            }
        }



        private void GrdPointRepairsAdd()
        {
            if (ValidateFooter())
            {
                Page.Validate("repairsFooter");
                if (Page.IsValid)
                {
                    Guid id = newId;
                    int companyId = Convert.ToInt32(Session["companyID"]);
                    string repairSize = ""; if (((TextBox)grdPointRepairs.FooterRow.FindControl("tbxRepairSizeFooter")).Text != "") repairSize = ((TextBox)grdPointRepairs.FooterRow.FindControl("tbxRepairSizeFooter")).Text;
                    DateTime? installDate = null; if (((RadDatePicker)grdPointRepairs.FooterRow.FindControl("tkrdpInstallDateFooter")).SelectedDate.HasValue) installDate = ((RadDatePicker)grdPointRepairs.FooterRow.FindControl("tkrdpInstallDateFooter")).SelectedDate.Value;
                    string distance = ""; if (((TextBox)grdPointRepairs.FooterRow.FindControl("tbxDistanceFooter")).Text != "") distance = ((TextBox)grdPointRepairs.FooterRow.FindControl("tbxDistanceFooter")).Text;
                    decimal? cost = null; if (((TextBox)grdPointRepairs.FooterRow.FindControl("tbxCostFooter")).Text != "") cost = Decimal.Parse(((TextBox)grdPointRepairs.FooterRow.FindControl("tbxCostFooter")).Text);
                    int? reinstates = null; if (((TextBox)grdPointRepairs.FooterRow.FindControl("tbxReinstatesFooter")).Text != "") reinstates = Int32.Parse(((TextBox)grdPointRepairs.FooterRow.FindControl("tbxReinstatesFooter")).Text);
                    string ltAtMh = "";
                    string vtAtMh = "";
                    string linerDistance = "";
                    string direction = "";
                    string mhShot = "";
                    string comments = "";
                    bool deleted = false;
                    bool extraRepair = false;
                    bool cancelled = false;
                    bool approved = false;
                    bool notApproved = false;
                    bool archived = false;
                    bool inDatabase = false;

                    AddRecordPointRepairs model = new AddRecordPointRepairs(addRecordTDS);
                    model.Insert(id, repairSize, installDate, distance, cost, reinstates, ltAtMh, vtAtMh, linerDistance, direction, mhShot, comments, deleted, extraRepair, cancelled, approved, notApproved, archived, companyId, addRecordTDS, inDatabase);

                    Session.Remove("pointRepairDummy");
                    Session["addRecordTDS"] = addRecordTDS;

                    grdPointRepairs.DataBind();
                    grdPointRepairs.PageIndex = grdPointRepairs.PageCount - 1;
                }
            }
        }



        private bool ValidateFooter()
        {
            string repairSize = ((TextBox)grdPointRepairs.FooterRow.FindControl("tbxRepairSizeFooter")).Text;
            DateTime? installDate = null; if (((RadDatePicker)grdPointRepairs.FooterRow.FindControl("tkrdpInstallDateFooter")).SelectedDate.HasValue) installDate = ((RadDatePicker)grdPointRepairs.FooterRow.FindControl("tkrdpInstallDateFooter")).SelectedDate.Value;
            string distance = ((TextBox)grdPointRepairs.FooterRow.FindControl("tbxDistanceFooter")).Text;
            decimal? cost = null; if (((TextBox)grdPointRepairs.FooterRow.FindControl("tbxCostFooter")).Text != "") cost = Decimal.Parse(((TextBox)grdPointRepairs.FooterRow.FindControl("tbxCostFooter")).Text);
            int? reinstates = null; if (((TextBox)grdPointRepairs.FooterRow.FindControl("tbxReinstatesFooter")).Text != "") reinstates = Int32.Parse(((TextBox)grdPointRepairs.FooterRow.FindControl("tbxReinstatesFooter")).Text);

            if ((repairSize != "") || (installDate.HasValue) || (distance != "") || (cost.HasValue) || (reinstates.HasValue))
            {
                return true;
            }

            return false;
        }


        
        protected void AddPointRepairsNewEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                AddRecordTDS.PointRepairsDataTable dt = new AddRecordTDS.PointRepairsDataTable();
                dt.AddPointRepairsRow(Guid.NewGuid(), -1, -1, "", "", new DateTime(),"", -1, -1, "", "", "", "", "", "",  false, false, false, false, false, false, false);
                Session["pointRepairDummy"] = dt;

                grdView.DataBind();
            }

            // normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                AddRecordTDS.PointRepairsDataTable dt = (AddRecordTDS.PointRepairsDataTable)Session["pointRepairDummy"];
                if (dt != null)
                {
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }


		
		private void PostPageChanges()
		{
			//--- [COMMENTED ROWS BELOW INTENDED FOR MAINTANANCE - DO NOT DELETE]		

			//--- Post lfs master area changes 
            int companyId = Convert.ToInt32(Session["companyID"]);
			TDSLFSRecord.LFS_MASTER_AREARow lfsMasterAreaRow = tdsLfsRecord.LFS_MASTER_AREA.FindByIDCOMPANY_ID(newId, companyId);

			LFSMasterAreaGateway lfsMasterAreaGateway = new LFSMasterAreaGateway();
			lfsMasterAreaRow.ID = lfsMasterAreaGateway.GetNewId();
			lfsMasterAreaRow.COMPANY_ID = companyId;
			lfsMasterAreaRow.RecordID = tbxRecordID.Text.Trim();
			if (tbxClientID.Text.Trim() != "") lfsMasterAreaRow.ClientID = tbxClientID.Text.Trim();
			lfsMasterAreaRow.COMPANIES_ID = Int32.Parse(ddlCOMPANIES_ID.SelectedItem.Value);
			if (tbxSubArea.Text.Trim() != "") lfsMasterAreaRow.SubArea = tbxSubArea.Text.Trim();
			if (tbxStreet.Text.Trim() != "") lfsMasterAreaRow.Street = tbxStreet.Text.Trim();
			if (tbxUSMH.Text.Trim() != "") lfsMasterAreaRow.USMH = tbxUSMH.Text.Trim();
			if (tbxDSMH.Text.Trim() != "") lfsMasterAreaRow.DSMH = tbxDSMH.Text.Trim();
			if (tbxSize_.Text.Trim() != "") lfsMasterAreaRow.Size_ = tbxSize_.Text.Trim();
			if (tbxScaledLength.Text.Trim() != "") lfsMasterAreaRow.ScaledLength = tbxScaledLength.Text.Trim();
			if (tbxP1Date.Text.Trim() != "") lfsMasterAreaRow.P1Date = DateTime.Parse(tbxP1Date.Text.Trim());
			if (tbxActualLength.Text.Trim() != "") lfsMasterAreaRow.ActualLength = tbxActualLength.Text.Trim();
			if (tbxLiveLats.Text.Trim() != "") lfsMasterAreaRow.LiveLats = Double.Parse(tbxLiveLats.Text.Trim());
			if (tbxCXIsRemoved.Text.Trim() != "") lfsMasterAreaRow.CXIsRemoved = tbxCXIsRemoved.Text.Trim();
			if (tbxM1Date.Text.Trim() != "") lfsMasterAreaRow.M1Date = DateTime.Parse(tbxM1Date.Text.Trim());
			if (tbxM2Date.Text.Trim() != "") lfsMasterAreaRow.M2Date = DateTime.Parse(tbxM2Date.Text.Trim());
			if (tbxInstallDate.Text.Trim() != "") lfsMasterAreaRow.InstallDate = DateTime.Parse(tbxInstallDate.Text.Trim());
			if (tbxFinalVideo.Text.Trim() != "") lfsMasterAreaRow.FinalVideo = DateTime.Parse(tbxFinalVideo.Text.Trim());
			if (tbxComments.Text.Trim() != "") lfsMasterAreaRow.Comments = tbxComments.Text.Trim();
			lfsMasterAreaRow.IssueIdentified = cbxIssueIdentified.Checked;
			lfsMasterAreaRow.IssueResolved = cbxIssueResolved.Checked;
			lfsMasterAreaRow.FullLengthLining = cbxFullLengthLining.Checked;
			lfsMasterAreaRow.SubcontractorLining = cbxSubcontractorLining.Checked;
			lfsMasterAreaRow.OutOfScopeInArea = cbxOutOfScopeInArea.Checked;
			lfsMasterAreaRow.IssueGivenToBayCity = cbxIssueGivenToBayCity.Checked;
			if (tbxConfirmedSize.Text.Trim() != "") lfsMasterAreaRow.ConfirmedSize = Int32.Parse(tbxConfirmedSize.Text.Trim());
			if (tbxInstallRate.Text.Trim() != "") lfsMasterAreaRow.InstallRate = Decimal.Parse(tbxInstallRate.Text.Trim());
			if (tbxDeadlineDate.Text.Trim() != "") lfsMasterAreaRow.DeadlineDate = DateTime.Parse(tbxDeadlineDate.Text.Trim());
			if (tbxProposedLiningDate.Text.Trim() != "") lfsMasterAreaRow.ProposedLiningDate = DateTime.Parse(tbxProposedLiningDate.Text.Trim());
			lfsMasterAreaRow.SalesIssue = cbxSalesIssue.Checked;
			lfsMasterAreaRow.LFSIssue = cbxLFSIssue.Checked;
			lfsMasterAreaRow.ClientIssue = cbxClientIssue.Checked;
			lfsMasterAreaRow.InvestigationIssue = cbxInvestigationIssue.Checked;
			lfsMasterAreaRow.PointLining = cbxPointLining.Checked;
			lfsMasterAreaRow.Grouting = cbxGrouting.Checked;
			lfsMasterAreaRow.LateralLining = cbxLateralLining.Checked;
			//if (tbxVacExDate.Text.Trim() != "") lfsMasterAreaRow.VacExDate = DateTime.Parse(tbxVacExDate.Text.Trim()); 
			//if (tbxPusherDate.Text.Trim() != "") lfsMasterAreaRow.PusherDate = DateTime.Parse(tbxPusherDate.Text.Trim()); 
			//if (tbxLinerOrdered.Text.Trim() != "") lfsMasterAreaRow.LinerOrdered = DateTime.Parse(tbxLinerOrdered.Text.Trim()); 
			//if (tbxRestoration.Text.Trim() != "") lfsMasterAreaRow.Restoration = DateTime.Parse(tbxRestoration.Text.Trim()); 
			//if (tbxGroutDate.Text.Trim() != "") lfsMasterAreaRow.GroutDate = DateTime.Parse(tbxGroutDate.Text.Trim()); 
			lfsMasterAreaRow.JLiner = cbxJLiner.Checked;
			lfsMasterAreaRow.RehabAssessment = cbxRehabAssessment.Checked;
			if (tbxEstimatedJoints.Text.Trim() != "") lfsMasterAreaRow.EstimatedJoints = Int32.Parse(tbxEstimatedJoints.Text.Trim());
			//if (tbxJointsTestSealed.Text.Trim() != "") lfsMasterAreaRow.JointsTestSealed = Int32.Parse(tbxJointsTestSealed.Text.Trim()); 
			if (tbxPreFlushDate.Text.Trim() != "") lfsMasterAreaRow.PreFlushDate = DateTime.Parse(tbxPreFlushDate.Text.Trim());
			if (tbxPreVideoDate.Text.Trim() != "") lfsMasterAreaRow.PreVideoDate = DateTime.Parse(tbxPreVideoDate.Text.Trim());
			//if (tbxUSMHMN.Text.Trim() != "") lfsMasterAreaRow.USMHMN = tbxUSMHMN.Text.Trim();
			//if (tbxDSMHMN.Text.Trim() != "") lfsMasterAreaRow.DSMHMN = tbxDSMHMN.Text.Trim();
			//if (tbxUSMHDepth.Text.Trim() != "") lfsMasterAreaRow.USMHDepth = tbxUSMHDepth.Text.Trim();
			//if (tbxDSMHDepth.Text.Trim() != "") lfsMasterAreaRow.DSMHDepth = tbxDSMHDepth.Text.Trim();
			//if (tbxMeasurementsTakenBy.Text.Trim() != "") lfsMasterAreaRow.MeasurementsTakenBy = tbxMeasurementsTakenBy.Text.Trim();
			if (tbxActualLength.Text.Trim() != "") lfsMasterAreaRow.SteelTapeThruPipe = tbxActualLength.Text.Trim(); // SYNCHRONIZED
			//if (tbxUSMHAtMouth1200.Text.Trim() != "") lfsMasterAreaRow.USMHAtMouth1200 = Double.Parse(tbxUSMHAtMouth1200.Text.Trim()); 
			//if (tbxUSMHAtMouth100.Text.Trim() != "") lfsMasterAreaRow.USMHAtMouth100 = Double.Parse(tbxUSMHAtMouth100.Text.Trim()); 
			//if (tbxUSMHAtMouth200.Text.Trim() != "") lfsMasterAreaRow.USMHAtMouth200 = Double.Parse(tbxUSMHAtMouth200.Text.Trim()); 
			//if (tbxUSMHAtMouth300.Text.Trim() != "") lfsMasterAreaRow.USMHAtMouth300 = Double.Parse(tbxUSMHAtMouth300.Text.Trim()); 
			//if (tbxUSMHAtMouth400.Text.Trim() != "") lfsMasterAreaRow.USMHAtMouth400 = Double.Parse(tbxUSMHAtMouth400.Text.Trim()); 
			//if (tbxUSMHAtMouth500.Text.Trim() != "") lfsMasterAreaRow.USMHAtMouth500 = Double.Parse(tbxUSMHAtMouth500.Text.Trim()); 
			//if (tbxDSMHAtMouth1200.Text.Trim() != "") lfsMasterAreaRow.DSMHAtMouth1200 = Double.Parse(tbxDSMHAtMouth1200.Text.Trim()); 
			//if (tbxDSMHAtMouth100.Text.Trim() != "") lfsMasterAreaRow.DSMHAtMouth100 = Double.Parse(tbxDSMHAtMouth100.Text.Trim()); 
			//if (tbxDSMHAtMouth200.Text.Trim() != "") lfsMasterAreaRow.DSMHAtMouth200 = Double.Parse(tbxDSMHAtMouth200.Text.Trim()); 
			//if (tbxDSMHAtMouth300.Text.Trim() != "") lfsMasterAreaRow.DSMHAtMouth300 = Double.Parse(tbxDSMHAtMouth300.Text.Trim()); 
			//if (tbxDSMHAtMouth400.Text.Trim() != "") lfsMasterAreaRow.DSMHAtMouth400 = Double.Parse(tbxDSMHAtMouth400.Text.Trim()); 
			//if (tbxDSMHAtMouth500.Text.Trim() != "") lfsMasterAreaRow.DSMHAtMouth500 = Double.Parse(tbxDSMHAtMouth500.Text.Trim()); 
			//if (tbxHydrantAddress.Text.Trim() != "") lfsMasterAreaRow.HydrantAddress = tbxHydrantAddress.Text.Trim();
			//if (tbxDistanceToInversionMH.Text.Trim() != "") lfsMasterAreaRow.DistanceToInversionMH = tbxDistanceToInversionMH.Text.Trim();
			lfsMasterAreaRow.RampsRequired = false;
			//lfsMasterAreaRow.DegreeOfTrafficControl // LOOKUP
			lfsMasterAreaRow.StandarBypass = false;
			//if (tbxHydroWireDetails.Text.Trim() != "") lfsMasterAreaRow.HydroWireDetails = tbxHydroWireDetails.Text.Trim();
			//if (tbxPipeMaterialType.Text.Trim() != "") lfsMasterAreaRow.PipeMaterialType = tbxPipeMaterialType.Text.Trim();
			//if (tbxCappedLaterals.Text.Trim() != "") lfsMasterAreaRow.CappedLaterals = Int32.Parse(tbxCappedLaterals.Text.Trim()); 
			lfsMasterAreaRow.RoboticPrepRequired = false;
			lfsMasterAreaRow.PipeSizeChange = false;
			//if (tbxM1Comments.Text.Trim() != "") lfsMasterAreaRow.M1Comments = tbxM1Comments.Text.Trim();
			//if (tbxVideoDoneFrom.Text.Trim() != "") lfsMasterAreaRow.VideoDoneFrom = tbxVideoDoneFrom.Text.Trim();
			//if (tbxToManhole.Text.Trim() != "") lfsMasterAreaRow.ToManhole = tbxToManhole.Text.Trim();
			//if (tbxCutterDescriptionDuringMeasuring.Text.Trim() != "") lfsMasterAreaRow.CutterDescriptionDuringMeasuring = tbxCutterDescriptionDuringMeasuring.Text.Trim();
			lfsMasterAreaRow.FullLengthPointLiner = cbxFullLengthPointLiner.Checked;
			lfsMasterAreaRow.BypassRequired = false;
			//if (tbxRoboticDistances.Text.Trim() != "") lfsMasterAreaRow.RoboticDistances = tbxRoboticDistances.Text.Trim();
			//if (tbxTrafficControlDetails.Text.Trim() != "") lfsMasterAreaRow.TrafficControlDetails = tbxTrafficControlDetails.Text.Trim(); else lfsMasterAreaRow.SetTrafficControlDetailsNull();
			//if (tbxLineWithID.Text.Trim() != "") lfsMasterAreaRow.LineWithID = tbxLineWithID.Text.Trim(); else lfsMasterAreaRow.SetLineWithIDNull();
			lfsMasterAreaRow.SchoolZone = false;
			lfsMasterAreaRow.RestaurantArea = false;
			lfsMasterAreaRow.CarwashLaundromat = false;
			lfsMasterAreaRow.HydroPulley = false;
			lfsMasterAreaRow.FridgeCart = false;
			lfsMasterAreaRow.TwoInchPump = false;
			lfsMasterAreaRow.SixInchBypass = false;
			lfsMasterAreaRow.Scaffolding = false;
			lfsMasterAreaRow.WinchExtension = false;
			lfsMasterAreaRow.ExtraGenerator = false;
			lfsMasterAreaRow.GreyCableExtension = false;
			lfsMasterAreaRow.EasementMats = false;
			//lfsMasterAreaRow.MeasurementType // LOOKUP
			lfsMasterAreaRow.DropPipe = false;
			//if (tbxDropPipeInvertDepth.Text.Trim() != "") lfsMasterAreaRow.DropPipeInvertDepth = tbxDropPipeInvertDepth.Trim(); else lfsMasterAreaRow.SetDropPipeInvertDepthNull();
			lfsMasterAreaRow.Deleted = false;
			//if (tbxMeasuredFromManhole.Text.Trim() != "") lfsMasterAreaRow.MeasuredFromManhole = tbxMeasuredFromManhole.Text.Trim(); else lfsMasterAreaRow.SetMeasuredFromManholeNull();
			//if (ddlMainLined.SelectedValue != "") lfsMasterAreaRow.MainLined = ddlMainLined.SelectedValue; else lfsMasterAreaRow.SetMainLinedNull();
			//if (ddlBenchingIssue.SelectedValue != "") lfsMasterAreaRow.BenchingIssue = ddlBenchingIssue.SelectedValue; else lfsMasterAreaRow.SetBenchingIssueNull();
			lfsMasterAreaRow.Archived = false;
            if (tbxHistory.Text.Trim() != "") lfsMasterAreaRow.History = tbxHistory.Text.Trim();
            lfsMasterAreaRow.NumLats = 0;
            lfsMasterAreaRow.NotLinedYet = 0;
            lfsMasterAreaRow.AllMeasured = false;
            if (tbxCity.Text.Trim() != "") lfsMasterAreaRow.City = tbxCity.Text.Trim();
            if (tbxProvState.Text.Trim() != "") lfsMasterAreaRow.ProvState = tbxProvState.Text.Trim();

			//--- update ScaledLength1
			Distance doubleDistance = new Distance(tbxScaledLength.Text.Trim());
			if (tbxScaledLength.Text.Trim() != "") lfsMasterAreaRow.ScaledLength1 = doubleDistance.ToFeetDouble(); else lfsMasterAreaRow.SetScaledLength1Null();

			//--- Store dataset lfs record
            Session["tdsLfsRecord"] = tdsLfsRecord;
		}

		

		private void UpdateDatabase()
		{
            // Initialize extra data
            ViewFullLengthLiningTDS viewFullLengthLiningTDS = new ViewFullLengthLiningTDS();
            ViewJLinersheetTDS viewJLinersheetTDS = new ViewJLinersheetTDS();

            string tdsToWork = "addRecord";

            // Save data
            int companyId = Convert.ToInt32(Session["companyID"]);
            LFSRecordGateway lfsRecordGateway = new LFSRecordGateway();
            lfsRecordGateway.UpdateRecord2(tdsLfsRecord, companyId, addRecordTDS, viewFullLengthLiningTDS, viewJLinersheetTDS, tdsToWork);

            //--- Store dataset lfs record
            Session["tdsLfsRecord"] = tdsLfsRecord;
            Session["addRecordTDS"] = addRecordTDS;
            Session["viewJLinersheetTDS"] = viewJLinersheetTDS;
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
			this.cvRecordID1.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.cvRecordID1_ServerValidate);
			this.cvRecordID2.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.cvRecordID2_ServerValidate);
			this.cvCOMPANIES_ID.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.cvCOMPANIES_ID_ServerValidate);
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


