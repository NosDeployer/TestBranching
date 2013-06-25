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
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP
{
    /// <summary>
    /// view_scopesheet
    /// </summary>
	public partial class view_scopesheet : System.Web.UI.Page
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
				if (((string)Request.QueryString["source_page"] == null) && ((string)Request.QueryString["record_deleted"] == null))
				{
					Response.Redirect("./../error_page.aspx?error=" + "Invalid query string in view_fulllength.aspx");
				}

                // Prepare initial values
                Session.Remove("pointRepairDummy");
                addRecordTDS = new AddRecordTDS();

				// If coming from navigator2.aspx or view_scopesheet.aspx
				if (((string)Request.QueryString["source_page"] == "navigator2.aspx") || ((string)Request.QueryString["source_page"] == "view_scopesheet.aspx"))
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

                // Prepare initial data 
                // ... for client
				CompaniesGateway companiesGateway = new CompaniesGateway();
				tbxCOMPANIES_ID.Text = companiesGateway.GetName((int)tdsLfsRecord.LFS_MASTER_AREA.Rows[0]["COMPANIES_ID"], Convert.ToInt32(Session["companyID"]));

				// ... for traffic control
				LFSTrafficControlGateway lfsTrafficControlGateway = new LFSTrafficControlGateway();
				DataSet dsLfsTrafficControl = lfsTrafficControlGateway.GetLFSTrafficControlForDropDownList("");

				ddlDegreeOfTrafficControl.DataSource = dsLfsTrafficControl;
				ddlDegreeOfTrafficControl.DataTextField = "TrafficControl";

    			// Databind
				Page.DataBind();

				TDSLFSRecord.LFS_MASTER_AREARow lfsMasterAreaRow = tdsLfsRecord.LFS_MASTER_AREA.FindByIDCOMPANY_ID(new Guid(tbxID.Text), Convert.ToInt32(Session["companyID"]));
				ddlDegreeOfTrafficControl.SelectedValue = (lfsMasterAreaRow.IsDegreeOfTrafficControlNull()) ? "" : lfsMasterAreaRow.DegreeOfTrafficControl;
			}
			else
			{
				// Restore datasets
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
                int companyId = Int32.Parse(((Label)grdPointRepairs.Rows[e.RowIndex].Cells[2].FindControl("lblCOMPANY_ID")).Text);

                string linerDistance = ((TextBox)grdPointRepairs.Rows[e.RowIndex].Cells[3].FindControl("tbxLinerDistanceEdit")).Text.Trim();
                string direction = ((DropDownList)grdPointRepairs.Rows[e.RowIndex].Cells[3].FindControl("ddlDirectionEdit")).SelectedValue;
                int? reinstates = null; if (((TextBox)grdPointRepairs.Rows[e.RowIndex].Cells[3].FindControl("tbxReinstatesEdit")).Text != "") reinstates = Int32.Parse(((TextBox)grdPointRepairs.Rows[e.RowIndex].Cells[3].FindControl("tbxReinstatesEdit")).Text);
                string ltMh = ((TextBox)grdPointRepairs.Rows[e.RowIndex].Cells[3].FindControl("tbxLtMhEdit")).Text.Trim();
                string vtMh = ((TextBox)grdPointRepairs.Rows[e.RowIndex].Cells[3].FindControl("tbxVtMhEdit")).Text.Trim();
                DateTime? installDate = null; if (((RadDatePicker)grdPointRepairs.Rows[e.RowIndex].Cells[3].FindControl("tkrdpInstallDateEdit")).SelectedDate.HasValue) installDate = ((RadDatePicker)grdPointRepairs.Rows[e.RowIndex].Cells[3].FindControl("tkrdpInstallDateEdit")).SelectedDate.Value;
                string distance = ((TextBox)grdPointRepairs.Rows[e.RowIndex].Cells[3].FindControl("tbxDistanceEdit")).Text.Trim();
                string size = ((TextBox)grdPointRepairs.Rows[e.RowIndex].Cells[3].FindControl("tbxSizeEdit")).Text.Trim();
                string mhShot = ((DropDownList)grdPointRepairs.Rows[e.RowIndex].Cells[3].FindControl("ddlMhShotEdit")).SelectedValue;
                bool extraRepair = ((CheckBox)grdPointRepairs.Rows[e.RowIndex].Cells[3].FindControl("ckbxExptraRepairEdit")).Checked;
                bool cancelled = ((CheckBox)grdPointRepairs.Rows[e.RowIndex].Cells[3].FindControl("ckbxCancelledEdit")).Checked;
                bool approved = ((CheckBox)grdPointRepairs.Rows[e.RowIndex].Cells[3].FindControl("ckbxApprovedEdit")).Checked;
                bool notApproved = ((CheckBox)grdPointRepairs.Rows[e.RowIndex].Cells[3].FindControl("ckbxNotApprovedEdit")).Checked;

                AddRecordPointRepairs model = new AddRecordPointRepairs(addRecordTDS);
                model.Update(id, refId, companyId, linerDistance, direction, reinstates, ltMh, vtMh, installDate, distance, size, mhShot, extraRepair, cancelled, approved, notApproved);

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
			//--- Post page changes
			this.PostPageChanges();

			//--- Store currend lfs record
			Session["lfsMasterAreaId"] = new Guid(tbxID.Text);

			//--- Go to delete record page
			Response.Redirect("delete_record.aspx?source_page=view_scopesheet.aspx");
		}

		

		protected void Page_PreRender(object sender, EventArgs e)
		{
			// Security check

			// ... edit
			if (Convert.ToBoolean(Session["sgLFS_APP_EDIT"]))
			{
				//... Master area
				tbxStreet.ReadOnly = false;
				tbxUSMH.ReadOnly = false;
				tbxDSMH.ReadOnly = false;
				tbxSize_.ReadOnly = false;
				tbxScaledLength.ReadOnly = false;
				tbxP1Date.ReadOnly = false;
				tbxActualLength.ReadOnly = false;
				tbxM1Date.ReadOnly = false;
				tbxFinalVideo.ReadOnly = false;
				tbxComments.ReadOnly = false;
				tbxConfirmedSize.ReadOnly = false;
				tbxUSMHMN.ReadOnly = false;
				tbxDSMHMN.ReadOnly = false;
				tbxMeasurementsTakenBy.ReadOnly = false;
				ddlDegreeOfTrafficControl.Enabled = true;
				tbxPipeMaterialType.ReadOnly = false;
				cbxRoboticPrepRequired.Enabled = true;
				cbxBypassRequired.Enabled = true;
				tbxRoboticDistances.ReadOnly = false;
				cbxIssueIdentified.Enabled = true;
				cbxLFSIssue.Enabled = true;
				cbxSalesIssue.Enabled = true;
				cbxInvestigationIssue.Enabled = true;
				cbxIssueResolved.Enabled = true;
				cbxIssueGivenToBayCity.Enabled = true;
				cbxClientIssue.Enabled = true;
				
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
				tbxM1Date.ReadOnly = true;
				tbxFinalVideo.ReadOnly = true;
				tbxComments.ReadOnly = true;
				tbxConfirmedSize.ReadOnly = true;
				tbxUSMHMN.ReadOnly = true;
				tbxDSMHMN.ReadOnly = true;
				tbxMeasurementsTakenBy.ReadOnly = true;
				ddlDegreeOfTrafficControl.Enabled = false;
				tbxPipeMaterialType.ReadOnly = true;
				cbxRoboticPrepRequired.Enabled = false;
				cbxBypassRequired.Enabled = false;
				tbxRoboticDistances.ReadOnly = true;
				cbxIssueIdentified.Enabled = false;
				cbxLFSIssue.Enabled = false;
				cbxSalesIssue.Enabled = false;
				cbxInvestigationIssue.Enabled = false;
				cbxIssueResolved.Enabled = false;
				cbxIssueGivenToBayCity.Enabled = false;
				cbxClientIssue.Enabled = false;
				
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
                
                // ... for direction
                if (addRecordPointRepairsGateway.GetDirection(id, refId, companyId) != "")
                {
                    ((DropDownList)e.Row.FindControl("ddlDirectionEdit")).SelectedValue = addRecordPointRepairsGateway.GetDirection(id, refId, companyId);
                }
                else
                {
                    ((DropDownList)e.Row.FindControl("ddlDirectionEdit")).SelectedIndex = 4;
                }

                // ... for MhShoot
                if (addRecordPointRepairsGateway.GetMHShot(id, refId, companyId) != "")
                {
                    ((DropDownList)e.Row.FindControl("ddlMhShotEdit")).SelectedValue = addRecordPointRepairsGateway.GetMHShot(id, refId, companyId);
                }
                else
                {
                    ((DropDownList)e.Row.FindControl("ddlMhShotEdit")).SelectedIndex = 2;
                }

                // ... For Install Date
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
                // Validation of permissions
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
                    // Initialize variables
                    ((DropDownList)e.Row.FindControl("ddlMhShotFooter")).SelectedIndex = 2;
                    ((DropDownList)e.Row.FindControl("ddlDirectionFooter")).SelectedIndex = 4;

                    // If the limit is reached
                    AddRecordPointRepairs addRecordPointRepairs = new AddRecordPointRepairs(addRecordTDS);
                    string newDetailId = addRecordPointRepairs.GetNewPointRepairsDetailId(addRecordTDS);

                    if (newDetailId == "-1")
                    {
                        ((RadDatePicker)e.Row.FindControl("tkrdpInstallDateFooter")).Visible = false;
                        ((TextBox)e.Row.FindControl("tbxLinerDistanceFooter")).Visible = false;
                        ((CheckBox)e.Row.FindControl("ddlDirectionFooter")).Visible = false;
                        ((TextBox)e.Row.FindControl("tbxLtMhFooter")).Visible = false;
                        ((TextBox)e.Row.FindControl("tbxVtMhFooter")).Visible = false;
                        ((TextBox)e.Row.FindControl("tbxDistanceFooter")).Visible = false;
                        ((TextBox)e.Row.FindControl("tbxSizeFooter")).Visible = false;
                        ((DropDownList)e.Row.FindControl("ddlMhShotFooter")).Visible = false;
                        ((CheckBox)e.Row.FindControl("ckbxExptraRepairFooter")).Visible = false;
                        ((CheckBox)e.Row.FindControl("ckbxCancelledFooter")).Visible = false;
                        ((CheckBox)e.Row.FindControl("ckbxApprovedFooter")).Visible = false;
                        ((CheckBox)e.Row.FindControl("ckbxNotApprovedFooter")).Visible = false;
                        ((TextBox)e.Row.FindControl("tbxCommentFooter")).Visible = false;
                        e.Row.FindControl("ibtnAdd").Visible = false;
                        lblMaxNumber.Visible = true;
                    }
                    else
                    {
                        ((RadDatePicker)e.Row.FindControl("tkrdpInstallDateFooter")).Visible = true;
                        ((TextBox)e.Row.FindControl("tbxLinerDistanceFooter")).Visible = true;
                        ((DropDownList)e.Row.FindControl("ddlDirectionFooter")).Visible = true;
                        ((TextBox)e.Row.FindControl("tbxLtMhFooter")).Visible = true;
                        ((TextBox)e.Row.FindControl("tbxVtMhFooter")).Visible = true;
                        ((TextBox)e.Row.FindControl("tbxDistanceFooter")).Visible = true;
                        ((TextBox)e.Row.FindControl("tbxSizeFooter")).Visible = true;
                        ((DropDownList)e.Row.FindControl("ddlMhShotFooter")).Visible = true;
                        ((CheckBox)e.Row.FindControl("ckbxExptraRepairFooter")).Visible = true;
                        ((CheckBox)e.Row.FindControl("ckbxCancelledFooter")).Visible = true;
                        ((CheckBox)e.Row.FindControl("ckbxApprovedFooter")).Visible = true;
                        ((CheckBox)e.Row.FindControl("ckbxNotApprovedFooter")).Visible = true;
                        ((TextBox)e.Row.FindControl("tbxCommentFooter")).Visible = true;
                        e.Row.FindControl("ibtnAdd").Visible = true;
                        lblMaxNumber.Visible = false;
                    }
                }
                else
                {
                    ((RadDatePicker)e.Row.FindControl("tkrdpInstallDateFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxLinerDistanceFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxDirectionFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxLtMhFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxVtMhFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxDistanceFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxSizeFooter")).Visible = false;
                    ((DropDownList)e.Row.FindControl("ddlMhShotFooter")).Visible = false;
                    ((CheckBox)e.Row.FindControl("ckbxExptraRepairFooter")).Visible = false;
                    ((CheckBox)e.Row.FindControl("ckbxCancelledFooter")).Visible = false;
                    ((CheckBox)e.Row.FindControl("ckbxApprovedFooter")).Visible = false;
                    ((CheckBox)e.Row.FindControl("ckbxNotApprovedFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxCommentFooter")).Visible = false;
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
				PostPageChanges();
				UpdateDatabase();

				//--- Get previous record
				Session["lfsMasterAreaId"] = Navigator.GetPreviousId((TDSLFSRecordForNavigator)Session["tdsLfsRecordForNavigator"], new Guid(tbxID.Text));

				//--- Display new record
				Response.Redirect("view_scopesheet.aspx?source_page=view_scopesheet.aspx");
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
				Session["lfsMasterAreaId"] = Navigator.GetNextId((TDSLFSRecordForNavigator)Session["tdsLfsRecordForNavigator"], new Guid(tbxID.Text));

				//--- Display new record
				Response.Redirect("view_scopesheet.aspx?source_page=view_scopesheet.aspx");
			}
		}

		

		protected void lkbtnSignOut_Click(object sender, System.EventArgs e)
		{
			//--- Sing out
			Response.Redirect((string)Session["loginPage"]);
		}

		

		protected void lkbtnMenu_Click(object sender, System.EventArgs e)
		{
			//--- Go to default.aspx
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

        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";                        

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./view_scopesheet.js");
        }
    


        private void Save()
        {
            bool validData = true;

            Page.Validate("addRecord");
            if (!Page.IsValid) validData = false;

            Page.Validate("editData");
            if (!Page.IsValid) validData = false;

            if (validData)
            {
                // Point Repairs Gridview, if the gridview is edition mode
                if (grdPointRepairs.EditIndex >= 0)
                {
                    grdPointRepairs.UpdateRow(grdPointRepairs.EditIndex, true);
                }

                // ... Save point repairs data at footer
                GrdPointRepairsAdd();

                // Save the rest of data
                this.PostPageChanges();
                this.UpdateDatabase();

                // Go to navigator2.aspx
                Response.Redirect("navigator2.aspx?record_modified=true");
            }
        }



        private void GrdPointRepairsAdd()
        {            
            Page.Validate("repairsFooter");
            if (Page.IsValid)
            {
                if (ValidateFooter())
                {
                    Guid id = (Guid)Session["lfsMasterAreaId"];
                    int companyId = Convert.ToInt32(Session["companyID"]);
                    string repairSize = ""; if (((TextBox)grdPointRepairs.FooterRow.FindControl("tbxSizeFooter")).Text != "") repairSize = ((TextBox)grdPointRepairs.FooterRow.FindControl("tbxSizeFooter")).Text.Trim();
                    DateTime? installDate = null; if (((RadDatePicker)grdPointRepairs.FooterRow.FindControl("tkrdpInstallDateFooter")).SelectedDate.HasValue) installDate = ((RadDatePicker)grdPointRepairs.FooterRow.FindControl("tkrdpInstallDateFooter")).SelectedDate.Value;
                    string distance = ""; if (((TextBox)grdPointRepairs.FooterRow.FindControl("tbxDistanceFooter")).Text != "") distance = ((TextBox)grdPointRepairs.FooterRow.FindControl("tbxDistanceFooter")).Text.Trim();                    
                    int? reinstates = null; if (((TextBox)grdPointRepairs.FooterRow.FindControl("tbxReinstatesFooter")).Text != "") reinstates = Int32.Parse(((TextBox)grdPointRepairs.FooterRow.FindControl("tbxReinstatesFooter")).Text.Trim());
                    string ltAtMh = ""; if (((TextBox)grdPointRepairs.FooterRow.FindControl("tbxLtMhFooter")).Text != "") ltAtMh = ((TextBox)grdPointRepairs.FooterRow.FindControl("tbxLtMhFooter")).Text.Trim();
                    string vtAtMh = ""; if (((TextBox)grdPointRepairs.FooterRow.FindControl("tbxVtMhFooter")).Text != "") vtAtMh = ((TextBox)grdPointRepairs.FooterRow.FindControl("tbxVtMhFooter")).Text.Trim();
                    string linerDistance = ""; if (((TextBox)grdPointRepairs.FooterRow.FindControl("tbxLinerDistanceFooter")).Text != "") linerDistance = ((TextBox)grdPointRepairs.FooterRow.FindControl("tbxLinerDistanceFooter")).Text.Trim();
                    string direction = ""; if (((DropDownList)grdPointRepairs.FooterRow.FindControl("ddlDirectionFooter")).SelectedValue != "") direction = ((DropDownList)grdPointRepairs.FooterRow.FindControl("ddlDirectionFooter")).SelectedValue;
                    string mhShot = ""; if (((DropDownList)grdPointRepairs.FooterRow.FindControl("ddlMhShotFooter")).SelectedValue != "") mhShot = ((DropDownList)grdPointRepairs.FooterRow.FindControl("ddlMhShotFooter")).SelectedValue;
                    string comments = ""; if (((TextBox)grdPointRepairs.FooterRow.FindControl("tbxCommentFooter")).Text != "") comments = ((TextBox)grdPointRepairs.FooterRow.FindControl("tbxCommentFooter")).Text.Trim();
                    bool deleted = false;
                    bool extraRepair = ((CheckBox)grdPointRepairs.FooterRow.FindControl("ckbxExptraRepairFooter")).Checked;
                    bool cancelled = ((CheckBox)grdPointRepairs.FooterRow.FindControl("ckbxCancelledFooter")).Checked;
                    bool approved = ((CheckBox)grdPointRepairs.FooterRow.FindControl("ckbxApprovedFooter")).Checked;
                    bool notApproved = ((CheckBox)grdPointRepairs.FooterRow.FindControl("ckbxNotApprovedFooter")).Checked;
                    bool archived = false;
                    bool inDatabase = false;
                    decimal? cost = null;

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
            string repairSize = ""; if (((TextBox)grdPointRepairs.FooterRow.FindControl("tbxSizeFooter")).Text != "") repairSize = ((TextBox)grdPointRepairs.FooterRow.FindControl("tbxSizeFooter")).Text.Trim();
            DateTime? installDate = null; if (((RadDatePicker)grdPointRepairs.FooterRow.FindControl("tkrdpInstallDateFooter")).SelectedDate.HasValue) installDate = ((RadDatePicker)grdPointRepairs.FooterRow.FindControl("tkrdpInstallDateFooter")).SelectedDate.Value;
            string distance = ""; if (((TextBox)grdPointRepairs.FooterRow.FindControl("tbxDistanceFooter")).Text != "") distance = ((TextBox)grdPointRepairs.FooterRow.FindControl("tbxDistanceFooter")).Text.Trim();
            int? reinstates = null; if (((TextBox)grdPointRepairs.FooterRow.FindControl("tbxReinstatesFooter")).Text != "") reinstates = Int32.Parse(((TextBox)grdPointRepairs.FooterRow.FindControl("tbxReinstatesFooter")).Text.Trim());
            string ltAtMh = ""; if (((TextBox)grdPointRepairs.FooterRow.FindControl("tbxLtMhFooter")).Text != "") ltAtMh = ((TextBox)grdPointRepairs.FooterRow.FindControl("tbxLtMhFooter")).Text.Trim();
            string vtAtMh = ""; if (((TextBox)grdPointRepairs.FooterRow.FindControl("tbxVtMhFooter")).Text != "") vtAtMh = ((TextBox)grdPointRepairs.FooterRow.FindControl("tbxVtMhFooter")).Text.Trim();
            string linerDistance = ""; if (((TextBox)grdPointRepairs.FooterRow.FindControl("tbxLinerDistanceFooter")).Text != "") linerDistance = ((TextBox)grdPointRepairs.FooterRow.FindControl("tbxLinerDistanceFooter")).Text.Trim();
            string direction = ""; if (((DropDownList)grdPointRepairs.FooterRow.FindControl("ddlDirectionFooter")).SelectedValue != "") direction = ((DropDownList)grdPointRepairs.FooterRow.FindControl("ddlDirectionFooter")).SelectedValue;
            string mhShot = ""; if (((DropDownList)grdPointRepairs.FooterRow.FindControl("ddlMhShotFooter")).SelectedValue != "") mhShot = ((DropDownList)grdPointRepairs.FooterRow.FindControl("ddlMhShotFooter")).SelectedValue;
            string comments = ""; if (((TextBox)grdPointRepairs.FooterRow.FindControl("tbxCommentFooter")).Text != "") comments =((TextBox)grdPointRepairs.FooterRow.FindControl("tbxCommentFooter")).Text.Trim();
            bool extraRepair = ((CheckBox)grdPointRepairs.FooterRow.FindControl("ckbxExptraRepairFooter")).Checked;
            bool cancelled = ((CheckBox)grdPointRepairs.FooterRow.FindControl("ckbxCancelledFooter")).Checked;
            bool approved = ((CheckBox)grdPointRepairs.FooterRow.FindControl("ckbxApprovedFooter")).Checked;
            bool notApproved = ((CheckBox)grdPointRepairs.FooterRow.FindControl("ckbxNotApprovedFooter")).Checked;

            if ((repairSize != "") || (installDate.HasValue) || (distance != "") || (reinstates.HasValue) || (ltAtMh != "") || (vtAtMh != "") || (linerDistance != "") || (direction !="") || (mhShot != "" ) || (comments != "") || (extraRepair) || (cancelled) || (approved) || (notApproved))
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
			if (tbxM1Date.Text.Trim() != "") lfsMasterAreaRow.M1Date = DateTime.Parse(tbxM1Date.Text.Trim()); else lfsMasterAreaRow.SetM1DateNull();
			if (tbxFinalVideo.Text.Trim() != "") lfsMasterAreaRow.FinalVideo = DateTime.Parse(tbxFinalVideo.Text.Trim()); else lfsMasterAreaRow.SetFinalVideoNull();
			if (tbxComments.Text.Trim() != "") lfsMasterAreaRow.Comments = tbxComments.Text.Trim(); else lfsMasterAreaRow.SetCommentsNull();
			if (tbxConfirmedSize.Text.Trim() != "") lfsMasterAreaRow.ConfirmedSize = Int32.Parse(tbxConfirmedSize.Text.Trim()); else lfsMasterAreaRow.SetConfirmedSizeNull();
			if (tbxUSMHMN.Text.Trim() != "") lfsMasterAreaRow.USMHMN = tbxUSMHMN.Text.Trim(); else lfsMasterAreaRow.SetUSMHMNNull();
			if (tbxDSMHMN.Text.Trim() != "") lfsMasterAreaRow.DSMHMN = tbxDSMHMN.Text.Trim(); else lfsMasterAreaRow.SetDSMHMNNull();
			if (tbxMeasurementsTakenBy.Text.Trim() != "") lfsMasterAreaRow.MeasurementsTakenBy = tbxMeasurementsTakenBy.Text.Trim(); else lfsMasterAreaRow.SetMeasurementsTakenByNull();
			if (tbxActualLength.Text.Trim() != "") lfsMasterAreaRow.SteelTapeThruPipe = tbxActualLength.Text.Trim(); else lfsMasterAreaRow.SetSteelTapeThruPipeNull(); // SYNCHRONIZED
			if (ddlDegreeOfTrafficControl.SelectedValue != "") lfsMasterAreaRow.DegreeOfTrafficControl = ddlDegreeOfTrafficControl.SelectedValue; else lfsMasterAreaRow.SetDegreeOfTrafficControlNull();
			if (tbxPipeMaterialType.Text.Trim() != "") lfsMasterAreaRow.PipeMaterialType = tbxPipeMaterialType.Text.Trim(); else lfsMasterAreaRow.SetPipeMaterialTypeNull();
			lfsMasterAreaRow.RoboticPrepRequired = cbxRoboticPrepRequired.Checked;
			lfsMasterAreaRow.BypassRequired = cbxBypassRequired.Checked;
			if (tbxRoboticDistances.Text.Trim() != "") lfsMasterAreaRow.RoboticDistances = tbxRoboticDistances.Text.Trim(); else lfsMasterAreaRow.SetRoboticDistancesNull();
			lfsMasterAreaRow.IssueIdentified = cbxIssueIdentified.Checked;
			lfsMasterAreaRow.LFSIssue = cbxLFSIssue.Checked;
			lfsMasterAreaRow.SalesIssue = cbxSalesIssue.Checked;
			lfsMasterAreaRow.InvestigationIssue = cbxInvestigationIssue.Checked;
			lfsMasterAreaRow.IssueResolved = cbxIssueResolved.Checked;
			lfsMasterAreaRow.IssueGivenToBayCity = cbxIssueGivenToBayCity.Checked;
			lfsMasterAreaRow.ClientIssue = cbxClientIssue.Checked;

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
			this.cvP1Date.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.Date_ServerValidate);
			this.cvM1Date.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.Date_ServerValidate);
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
