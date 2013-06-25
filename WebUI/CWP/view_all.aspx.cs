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
using LiquiForce.LFSLive.CWP.BL;
using LiquiForce.LFSLive.Server;
using System.Data.SqlClient;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP
{
    /// <summary>
    /// view_all
    /// </summary>
	public partial class view_all : System.Web.UI.Page
	{
		///////////////////////////////////////////////////////////////////////////
		/// PROPERTIES AND FIELDS
		///

		protected TDSLFSRecord tdsLfsRecord;
        protected AddRecordTDS addRecordTDS;
        protected AddRecordTDS.PointRepairsDataTable pointRepairs;






		/// ////////////////////////////////////////////////////////////////////////
		/// EVENTS
		///

		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				// Security check
				if (!Convert.ToBoolean(Session["sgLFS_APP_VIEW"]))
				{
                    Response.Redirect("./../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
				}

				// Validate query string
				if (((string)Request.QueryString["source_page"] == null) && ((string)Request.QueryString["record_deleted"] == null))
				{
                    Response.Redirect("./../error_page.aspx?error=" + "Invalid query string in view_fulllength.aspx");
				}

                //... Prepare initial 
                Session.Remove("pointRepairDummy");
                addRecordTDS = new AddRecordTDS();

				// If coming from navigator2.aspx or view_all.aspx
				if (((string)Request.QueryString["source_page"] == "navigator2.aspx") || ((string)Request.QueryString["source_page"] == "view_all.aspx"))
				{
                    int companyId = Convert.ToInt32(Session["companyID"]);
                    Guid id = (Guid)Session["lfsMasterAreaId"];

					//... Get lfs master area record
					LFSRecordGateway lfsRecordGateway = new LFSRecordGateway();
                    tdsLfsRecord = lfsRecordGateway.GetRecordByIdCompanyId(id, companyId);
                    
                    AddRecordPointRepairsGateway addRecordPointRepairsGateway = new AddRecordPointRepairsGateway(addRecordTDS);
                    addRecordPointRepairsGateway.LoadById(id, companyId);

					//... Store datasets
					Session["tdsLfsRecord"] = tdsLfsRecord;
                    Session["addRecordTDS"] = addRecordTDS;
                    pointRepairs = addRecordTDS.PointRepairs;
                    Session["pointRepairs"] = pointRepairs;
				}
				
				// If coming from delete_record.aspx
				if ((string)Request.QueryString["record_deleted"] == "false")
				{
					//... Restore dataset lfs record
					tdsLfsRecord = (TDSLFSRecord)Session["tdsLfsRecord"];
                    addRecordTDS = (AddRecordTDS)Session["addRecordTDS"];
				}

				// Prepare initial data for client
				CompaniesGateway companiesGateway = new CompaniesGateway();
				tbxCOMPANIES_ID.Text = companiesGateway.GetName((int)tdsLfsRecord.LFS_MASTER_AREA.Rows[0]["COMPANIES_ID"], Convert.ToInt32(Session["companyID"]));

				// Databind
				Page.DataBind();
			}
			else
			{
				// Restore dataset lfs record
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
			Response.Redirect("navigator2.aspx?record_modified=false");
		}



		protected void btnDelete_Click(object sender, System.EventArgs e)
		{
			this.PostPageChanges();

			//--- Store currend lfs record
			Session["lfsMasterAreaId"] = new Guid(tbxID.Text);

			//--- Go to delete record page
			Response.Redirect("delete_record.aspx?source_page=view_all.aspx");
		}

		

		protected void Page_PreRender(object sender, EventArgs e)
		{
			// Security check
			// ... edit
			if (Convert.ToBoolean(Session["sgLFS_APP_EDIT"]))
			{
				//--- Master area
				tbxClientID.ReadOnly = false;
				tbxSubArea.ReadOnly = false;
                tbxCity.ReadOnly = false;
                tbxProvState.ReadOnly = false;
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
				cbxPointLining.Enabled = true;
				cbxGrouting.Enabled = true;
				cbxLateralLining.Enabled = true;
				cbxJLiner.Enabled = true;
				cbxRehabAssessment.Enabled = true;
				tbxEstimatedJoints.ReadOnly = false;
				tbxPreFlushDate.ReadOnly = false;
				tbxPreVideoDate.ReadOnly = false;
				cbxFullLengthPointLiner.Enabled = true;
			
				//--- Buttons
				btnOK.Enabled = true;
				btnOK1.Enabled = true;
				btnCancel.Enabled = true;
				btnCancel1.Enabled = true;
			}
			else
			{
				//--- Master area
				tbxClientID.ReadOnly = true;
				tbxSubArea.ReadOnly = true;
				tbxStreet.ReadOnly = true;
                tbxCity.ReadOnly = true;
                tbxProvState.ReadOnly = true;
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
				cbxPointLining.Enabled = false;
				cbxGrouting.Enabled = false;
				cbxLateralLining.Enabled = false;
				cbxJLiner.Enabled = false;
				cbxRehabAssessment.Enabled = false;
				tbxEstimatedJoints.ReadOnly = true;
				tbxPreFlushDate.ReadOnly = true;
				tbxPreVideoDate.ReadOnly = true;
				cbxFullLengthPointLiner.Enabled = false;
			
				//--- Buttons
				btnOK.Enabled = false;
				btnOK1.Enabled = false;
				btnCancel.Enabled = true;
				btnCancel1.Enabled = true;
			}

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

			// ... Admin
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
                // Initialize values
                Guid id = new Guid(((Label)e.Row.FindControl("lblId")).Text);
                int refId = Int32.Parse(((Label)e.Row.FindControl("lblRefId")).Text);
                int companyId = Int32.Parse(((Label)e.Row.FindControl("lblCOMPANY_ID")).Text);

                AddRecordPointRepairsGateway addRecordPointRepairsGateway = new AddRecordPointRepairsGateway(addRecordTDS);

                if (addRecordPointRepairsGateway.Table.Rows.Count > 0)
                {
                    if (addRecordPointRepairsGateway.GetInstallDate(id, refId, companyId).HasValue)
                    {
                        ((RadDatePicker)e.Row.FindControl("tkrdpInstallDateEdit")).SelectedDate = (DateTime)addRecordPointRepairsGateway.GetInstallDate(id, refId, companyId);
                    }
                }                
            }
            
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                if (Convert.ToBoolean(Session["sgLFS_APP_EDIT"]))
                {
                    // Button Validation
                    e.Row.FindControl("ibtnEdit").Visible = true;
                    e.Row.FindControl("ibtnDelete").Visible = true;
                }
                else
                { 
                    // Button validation
                    e.Row.FindControl("ibtnEdit").Visible = false;
                    e.Row.FindControl("ibtnDelete").Visible = false;
                }
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                if (Convert.ToBoolean(Session["sgLFS_APP_EDIT"]))
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
                else
                {
                    ((RadDatePicker)e.Row.FindControl("tkrdpInstallDateFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxRepairSizeFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxDistanceFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxCostFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxReinstatesFooter")).Visible = false;
                    e.Row.FindControl("ibtnAdd").Visible = false;
                    lblMaxNumber.Visible = false;
                }
            }
        }



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
				Response.Redirect("view_all.aspx?source_page=view_all.aspx");
			}
		}



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
				Session["lfsMasterAreaId"] = LiquiForce.LFSLive.CWP.Tools.Navigator.GetNextId((TDSLFSRecordForNavigator)Session["tdsLfsRecordForNavigator"], new Guid(tbxID.Text));

				//--- Display new record
				Response.Redirect("view_all.aspx?source_page=view_all.aspx");
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

                //--- Go to navigator2.aspx
                Response.Redirect("navigator2.aspx?record_modified=true");
            }
        }



        private void GrdPointRepairsAdd()
        {
            if (ValidateFooter())
            {
                Page.Validate("repairsFooter");
                if (Page.IsValid)
                {
                    Guid id = (Guid)Session["lfsMasterAreaId"];
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
                dt.AddPointRepairsRow(Guid.NewGuid(), -1, -1, "", "", new DateTime(), "", -1, -1, "", "", "", "", "", "", false, false, false, false, false, false, false);
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
			// [COMMENTED ROWS BELOW INTENDED FOR MAINTANANCE - DO NOT DELETE]

			// Post lfs master area changes 
			TDSLFSRecord.LFS_MASTER_AREARow lfsMasterAreaRow = tdsLfsRecord.LFS_MASTER_AREA.FindByIDCOMPANY_ID(new Guid(tbxID.Text), Convert.ToInt32(Session["companyID"]));
			
			if (tbxClientID.Text.Trim() != "") lfsMasterAreaRow.ClientID = tbxClientID.Text.Trim(); else lfsMasterAreaRow.SetClientIDNull();
			if (tbxSubArea.Text.Trim() != "") lfsMasterAreaRow.SubArea = tbxSubArea.Text.Trim(); else lfsMasterAreaRow.SetSubAreaNull();
			if (tbxStreet.Text.Trim() != "") lfsMasterAreaRow.Street = tbxStreet.Text.Trim(); else lfsMasterAreaRow.SetStreetNull();
			if (tbxUSMH.Text.Trim() != "") lfsMasterAreaRow.USMH = tbxUSMH.Text.Trim(); else lfsMasterAreaRow.SetUSMHNull();
			if (tbxDSMH.Text.Trim() != "") lfsMasterAreaRow.DSMH = tbxDSMH.Text.Trim(); else lfsMasterAreaRow.SetDSMHNull();
			if (tbxSize_.Text.Trim() != "") lfsMasterAreaRow.Size_ = tbxSize_.Text.Trim(); else lfsMasterAreaRow.SetSize_Null();
			if (tbxScaledLength.Text.Trim() != "") lfsMasterAreaRow.ScaledLength = tbxScaledLength.Text.Trim(); else lfsMasterAreaRow.SetScaledLengthNull();
			if (tbxP1Date.Text.Trim() != "") lfsMasterAreaRow.P1Date = DateTime.Parse(tbxP1Date.Text.Trim()); else lfsMasterAreaRow.SetP1DateNull();

            // update DistanceFromDSMH
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
			lfsMasterAreaRow.PointLining = cbxPointLining.Checked;
			lfsMasterAreaRow.Grouting = cbxGrouting.Checked;
			lfsMasterAreaRow.LateralLining = cbxLateralLining.Checked;
			//if (tbxVacExDate.Text.Trim() != "") lfsMasterAreaRow.VacExDate = DateTime.Parse(tbxVacExDate.Text.Trim());  else lfsMasterAreaRow.SetVacExDateNull();
			//if (tbxPusherDate.Text.Trim() != "") lfsMasterAreaRow.PusherDate = DateTime.Parse(tbxPusherDate.Text.Trim());   else lfsMasterAreaRow.SetPusherDateNull();
			//if (tbxLinerOrdered.Text.Trim() != "") lfsMasterAreaRow.LinerOrdered = DateTime.Parse(tbxLinerOrdered.Text.Trim());   else lfsMasterAreaRow.SetLinerOrderedNull();
			//if (tbxRestoration.Text.Trim() != "") lfsMasterAreaRow.Restoration = DateTime.Parse(tbxRestoration.Text.Trim());   else lfsMasterAreaRow.SetRestorationNull();
			//if (tbxGroutDate.Text.Trim() != "") lfsMasterAreaRow.GroutDate = DateTime.Parse(tbxGroutDate.Text.Trim());   else lfsMasterAreaRow.SetGroutDateNull();
			lfsMasterAreaRow.JLiner = cbxJLiner.Checked;
			lfsMasterAreaRow.RehabAssessment = cbxRehabAssessment.Checked;
			if (tbxEstimatedJoints.Text.Trim() != "") lfsMasterAreaRow.EstimatedJoints = Int32.Parse(tbxEstimatedJoints.Text.Trim()); else lfsMasterAreaRow.SetEstimatedJointsNull();
			//if (tbxJointsTestSealed.Text.Trim() != "") lfsMasterAreaRow.JointsTestSealed = Int32.Parse(tbxJointsTestSealed.Text.Trim()); else lfsMasterAreaRow.SetJointsTestSealedNull();
			if (tbxPreFlushDate.Text.Trim() != "") lfsMasterAreaRow.PreFlushDate = DateTime.Parse(tbxPreFlushDate.Text.Trim()); else lfsMasterAreaRow.SetPreFlushDateNull();
			if (tbxPreVideoDate.Text.Trim() != "") lfsMasterAreaRow.PreVideoDate = DateTime.Parse(tbxPreVideoDate.Text.Trim()); else lfsMasterAreaRow.SetPreVideoDateNull();
			//if (tbxUSMHMN.Text.Trim() != "") lfsMasterAreaRow.USMHMN = tbxUSMHMN.Text.Trim(); else lfsMasterAreaRow.SetUSMHMNNull();
			//if (tbxDSMHMN.Text.Trim() != "") lfsMasterAreaRow.DSMHMN = tbxDSMHMN.Text.Trim(); else lfsMasterAreaRow.SetDSMHMNNull();
			//if (tbxUSMHDepth.Text.Trim() != "") lfsMasterAreaRow.USMHDepth = tbxUSMHDepth.Text.Trim(); else lfsMasterAreaRow.SetUSMHDepthNull();
			//if (tbxDSMHDepth.Text.Trim() != "") lfsMasterAreaRow.DSMHDepth = tbxDSMHDepth.Text.Trim(); else lfsMasterAreaRow.SetDSMHDepthNull();
			//if (tbxMeasurementsTakenBy.Text.Trim() != "") lfsMasterAreaRow.MeasurementsTakenBy = tbxMeasurementsTakenBy.Text.Trim(); else lfsMasterAreaRow.SetMeasurementsTakenByNull();
			if (tbxActualLength.Text.Trim() != "") lfsMasterAreaRow.SteelTapeThruPipe = tbxActualLength.Text.Trim(); else lfsMasterAreaRow.SetSteelTapeThruPipeNull(); // SYNCHRONIZED
			//if (tbxUSMHAtMouth1200.Text.Trim() != "") lfsMasterAreaRow.USMHAtMouth1200 = Double.Parse(tbxUSMHAtMouth1200.Text.Trim()); else lfsMasterAreaRow.SetUSMHAtMouth1200Null();
			//if (tbxUSMHAtMouth100.Text.Trim() != "") lfsMasterAreaRow.USMHAtMouth100 = Double.Parse(tbxUSMHAtMouth100.Text.Trim()); else lfsMasterAreaRow.SetUSMHAtMouth100Null();
			//if (tbxUSMHAtMouth200.Text.Trim() != "") lfsMasterAreaRow.USMHAtMouth200 = Double.Parse(tbxUSMHAtMouth200.Text.Trim()); else lfsMasterAreaRow.SetUSMHAtMouth200Null();
			//if (tbxUSMHAtMouth300.Text.Trim() != "") lfsMasterAreaRow.USMHAtMouth300 = Double.Parse(tbxUSMHAtMouth300.Text.Trim()); else lfsMasterAreaRow.SetUSMHAtMouth300Null();
			//if (tbxUSMHAtMouth400.Text.Trim() != "") lfsMasterAreaRow.USMHAtMouth400 = Double.Parse(tbxUSMHAtMouth400.Text.Trim()); else lfsMasterAreaRow.SetUSMHAtMouth400Null();
			//if (tbxUSMHAtMouth500.Text.Trim() != "") lfsMasterAreaRow.USMHAtMouth500 = Double.Parse(tbxUSMHAtMouth500.Text.Trim()); else lfsMasterAreaRow.SetUSMHAtMouth500Null();
			//if (tbxDSMHAtMouth1200.Text.Trim() != "") lfsMasterAreaRow.DSMHAtMouth1200 = Double.Parse(tbxDSMHAtMouth1200.Text.Trim()); else lfsMasterAreaRow.SetDSMHAtMouth1200Null();
			//if (tbxDSMHAtMouth100.Text.Trim() != "") lfsMasterAreaRow.DSMHAtMouth100 = Double.Parse(tbxDSMHAtMouth100.Text.Trim()); else lfsMasterAreaRow.SetDSMHAtMouth100Null();
			//if (tbxDSMHAtMouth200.Text.Trim() != "") lfsMasterAreaRow.DSMHAtMouth200 = Double.Parse(tbxDSMHAtMouth200.Text.Trim()); else lfsMasterAreaRow.SetDSMHAtMouth200Null();
			//if (tbxDSMHAtMouth300.Text.Trim() != "") lfsMasterAreaRow.DSMHAtMouth300 = Double.Parse(tbxDSMHAtMouth300.Text.Trim()); else lfsMasterAreaRow.SetDSMHAtMouth300Null();
			//if (tbxDSMHAtMouth400.Text.Trim() != "") lfsMasterAreaRow.DSMHAtMouth400 = Double.Parse(tbxDSMHAtMouth400.Text.Trim()); else lfsMasterAreaRow.SetDSMHAtMouth400Null();
			//if (tbxDSMHAtMouth500.Text.Trim() != "") lfsMasterAreaRow.DSMHAtMouth500 = Double.Parse(tbxDSMHAtMouth500.Text.Trim()); else lfsMasterAreaRow.SetDSMHAtMouth500Null();
			//if (tbxHydrantAddress.Text.Trim() != "") lfsMasterAreaRow.HydrantAddress = tbxHydrantAddress.Text.Trim(); else lfsMasterAreaRow.SetHydrantAddressNull();
			//if (tbxDistanceToInversionMH.Text.Trim() != "") lfsMasterAreaRow.DistanceToInversionMH = tbxDistanceToInversionMH.Text.Trim(); else lfsMasterAreaRow.SetDistanceToInversionMHNull();
			//lfsMasterAreaRow.RampsRequired = cbxRampsRequired.Checked;
			//if (ddlDegreeOfTrafficControl.SelectedValue != "") lfsMasterAreaRow.DegreeOfTrafficControl = ddlDegreeOfTrafficControl.SelectedValue; else lfsMasterAreaRow.SetDegreeOfTrafficControlNull(); // LOOKUP
			//lfsMasterAreaRow.StandarBypass = cbxStandarBypass.Checked;
			//if (tbxHydroWireDetails.Text.Trim() != "") lfsMasterAreaRow.HydroWireDetails = tbxHydroWireDetails.Text.Trim(); else lfsMasterAreaRow.SetHydroWireDetailsNull();
			//if (tbxPipeMaterialType.Text.Trim() != "") lfsMasterAreaRow.PipeMaterialType = tbxPipeMaterialType.Text.Trim(); else lfsMasterAreaRow.SetPipeMaterialTypeNull();
			//if (tbxCappedLaterals.Text.Trim() != "") lfsMasterAreaRow.CappedLaterals = Int32.Parse(tbxCappedLaterals.Text.Trim());  else lfsMasterAreaRow.SetCappedLateralsNull();
			//lfsMasterAreaRow.RoboticPrepRequired = cbxRoboticPrepRequired.Checked;
			//lfsMasterAreaRow.PipeSizeChange = cbxPipeSizeChange.Checked;
			//if (tbxM1Comments.Text.Trim() != "") lfsMasterAreaRow.M1Comments = tbxM1Comments.Text.Trim(); else lfsMasterAreaRow.SetM1CommentsNull();
			//if (tbxVideoDoneFrom.Text.Trim() != "") lfsMasterAreaRow.VideoDoneFrom = tbxVideoDoneFrom.Text.Trim(); else lfsMasterAreaRow.SetVideoDoneFromNull();
			//if (tbxToManhole.Text.Trim() != "") lfsMasterAreaRow.ToManhole = tbxToManhole.Text.Trim(); else lfsMasterAreaRow.SetToManholeNull();
			//if (tbxCutterDescriptionDuringMeasuring.Text.Trim() != "") lfsMasterAreaRow.CutterDescriptionDuringMeasuring = tbxCutterDescriptionDuringMeasuring.Text.Trim(); else lfsMasterAreaRow.SetCutterDescriptionDuringMeasuringNull();
			lfsMasterAreaRow.FullLengthPointLiner = cbxFullLengthPointLiner.Checked;
			//lfsMasterAreaRow.BypassRequired = cbxBypassRequired.Checked;
			//if (tbxRoboticDistances.Text.Trim() != "") lfsMasterAreaRow.RoboticDistances = tbxRoboticDistances.Text.Trim(); else lfsMasterAreaRow.SetRoboticDistancesNull();
			//if (tbxTrafficControlDetails.Text.Trim() != "") lfsMasterAreaRow.TrafficControlDetails = tbxTrafficControlDetails.Text.Trim(); else lfsMasterAreaRow.SetTrafficControlDetailsNull();
			//if (tbxLineWithID.Text.Trim() != "") lfsMasterAreaRow.LineWithID = tbxLineWithID.Text.Trim(); else lfsMasterAreaRow.SetLineWithIDNull();
			//lfsMasterAreaRow.SchoolZone = cbxSchoolZone.Checked;
			//lfsMasterAreaRow.RestaurantArea = cbxRestaurantArea.Checked;
			//lfsMasterAreaRow.CarwashLaundromat = cbxCarwashLaundromat.Checked;
			//lfsMasterAreaRow.HydroPulley = cbxHydroPulley.Checked;
			//lfsMasterAreaRow.FridgeCart = cbxFridgeCart.Checked;
			//lfsMasterAreaRow.TwoInchPump = cbxTwoInchPump.Checked;
			//lfsMasterAreaRow.SixInchBypass = cbxSixInchBypass.Checked;
			//lfsMasterAreaRow.Scaffolding = cbxScaffolding.Checked;
			//lfsMasterAreaRow.WinchExtension = cbxWinchExtension.Checked;
			//lfsMasterAreaRow.ExtraGenerator = cbxExtraGenerator.Checked;
			//lfsMasterAreaRow.GreyCableExtension = cbxGreyCableExtension.Checked;
			//lfsMasterAreaRow.EasementMats = cbxEasementMats.Checked;
			//if (ddlMeasurementType.SelectedValue != "") lfsMasterAreaRow.MeasurementType = ddlMeasurementType.SelectedValue; else lfsMasterAreaRow.SetMeasurementTypeNull(); // LOOKUP
			//lfsMasterAreaRow.DropPipe = cbxDropPipe.Checked;
			//if (tbxDropPipeInvertDepth.Text.Trim() != "") lfsMasterAreaRow.DropPipeInvertDepth = tbxDropPipeInvertDepth.Trim(); else lfsMasterAreaRow.SetDropPipeInvertDepthNull();
			//lfsMasterAreaRow.Deleted;
			//if (tbxMeasuredFromManhole.Text.Trim() != "") lfsMasterAreaRow.MeasuredFromManhole = tbxMeasuredFromManhole.Text.Trim(); else lfsMasterAreaRow.SetMeasuredFromManholeNull();
			//if (ddlMainLined.SelectedValue != "") lfsMasterAreaRow.MainLined = ddlMainLined.SelectedValue; else lfsMasterAreaRow.SetMainLinedNull();
			//if (ddlBenchingIssue.SelectedValue != "") lfsMasterAreaRow.BenchingIssue = ddlBenchingIssue.SelectedValue; else lfsMasterAreaRow.SetBenchingIssueNull();
            if (tbxHistory.Text.Trim() != "") lfsMasterAreaRow.History = tbxHistory.Text.Trim();
            if (tbxCity.Text.Trim() != "") lfsMasterAreaRow.City = tbxCity.Text.Trim();
            if (tbxProvState.Text.Trim() != "") lfsMasterAreaRow.ProvState = tbxProvState.Text.Trim();

			// update ScaledLength1
			Distance doubleDistance = new Distance(tbxScaledLength.Text.Trim());
			if (tbxScaledLength.Text.Trim() != "") lfsMasterAreaRow.ScaledLength1 = doubleDistance.ToFeetDouble(); else lfsMasterAreaRow.SetScaledLength1Null();

			// Update m2 tables' reverse setup
			foreach (TDSLFSRecord.LFS_M2_TABLESRow lfsM2TablesRow in tdsLfsRecord.LFS_M2_TABLES)
			{
				if (!lfsM2TablesRow.IsDistanceToCentreOfLateralNull()) 
				{
					lfsM2TablesRow.ReverseSetup = Distance.Subtract(lfsMasterAreaRow.IsActualLengthNull() ? "" : lfsMasterAreaRow.ActualLength, lfsM2TablesRow.DistanceToCentreOfLateral);
				}
			}

            // Store dataset lfs record
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

            // Store datasets
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

			// Wire events
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
