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
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP
{
	public partial class view_jlinersheet : System.Web.UI.Page
	{
        ///////////////////////////////////////////////////////////////////////////
        /// PROPERTIES AND FIELDS
        ///
       
		protected TDSLFSRecord tdsLfsRecord;
        protected ViewJLinersheetTDS viewJLinersheetTDS;
        protected ViewJLinersheetTDS.JunctionLinerDataTable jliner;






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
					Response.Redirect("./../error_page.aspx?error=" + "Invalid query string in view_jlinersheet.aspx");
				}

                // Prepare initial data
                Session.Remove("jlinerDummy");
                lblMaxNumber.Visible = false;                

				// If coming from navigator2.aspx or view_jlinersheet.aspx
				if (((string)Request.QueryString["source_page"] == "navigator2.aspx") || ((string)Request.QueryString["source_page"] == "view_jlinersheet.aspx"))
				{
					//... Get lfs master area record
					LFSRecordGateway lfsRecordGateway = new LFSRecordGateway();
                    viewJLinersheetTDS = new ViewJLinersheetTDS();

                    ViewJLinersheetJunctionLinerGateway viewJLinersheetJunctionLinerGateway = new ViewJLinersheetJunctionLinerGateway(viewJLinersheetTDS);
                    viewJLinersheetJunctionLinerGateway.LoadById((Guid)Session["lfsMasterAreaId"], Convert.ToInt32(Session["companyID"]));

					tdsLfsRecord = lfsRecordGateway.GetRecordByIdCompanyId((Guid)Session["lfsMasterAreaId"], Convert.ToInt32(Session["companyID"]));

					//... Store datasets
					Session["tdsLfsRecord"] = tdsLfsRecord;
                    Session["viewJLinersheetTDS"] = viewJLinersheetTDS;
                    jliner = viewJLinersheetTDS.JunctionLiner;
                    Session["jliner"] = jliner;
				}

				// If coming from delete_record.aspx
				if ((string)Request.QueryString["record_deleted"] == "false")
				{
					//... Restore dataset lfs record
					tdsLfsRecord = (TDSLFSRecord)Session["tdsLfsRecord"];
                    viewJLinersheetTDS = (ViewJLinersheetTDS)Session["viewJLinersheetTDS"];
				}				

				// ... for client
				CompaniesGateway companiesGateway = new CompaniesGateway();
				tbxCOMPANIES_ID.Text = companiesGateway.GetName((int)tdsLfsRecord.LFS_MASTER_AREA.Rows[0]["COMPANIES_ID"], Convert.ToInt32(Session["companyID"]));

				// Databind
				Page.DataBind();

				ddlMainLined.SelectedIndex = (tdsLfsRecord.LFS_MASTER_AREA[0].IsMainLinedNull()) ? 2 : ((tdsLfsRecord.LFS_MASTER_AREA[0].MainLined == "Yes") ? 0 : 1);
				ddlBenchingIssue.SelectedIndex = (tdsLfsRecord.LFS_MASTER_AREA[0].IsBenchingIssueNull()) ? 2 : ((tdsLfsRecord.LFS_MASTER_AREA[0].BenchingIssue == "Yes") ? 0 : 1);
			}
			else
			{
				//--- Restore dataset lfs record
				tdsLfsRecord = (TDSLFSRecord)Session["tdsLfsRecord"];
                viewJLinersheetTDS = (ViewJLinersheetTDS)Session["viewJLinersheetTDS"];
			}
		}



        protected void grdJlinerSheet_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Guid id = new Guid(((Label)grdJlinerSheet.Rows[e.RowIndex].Cells[0].FindControl("lblId")).Text);
            int refId = Int32.Parse(((Label)grdJlinerSheet.Rows[e.RowIndex].Cells[1].FindControl("lblRefId")).Text);
            int companyId = Int32.Parse(((Label)grdJlinerSheet.Rows[e.RowIndex].Cells[2].FindControl("lblCOMPANY_ID")).Text);

            ViewJLinersheetJunctionLiner model = new ViewJLinersheetJunctionLiner(viewJLinersheetTDS);
            model.Delete(id, refId, companyId);

            Session["viewJLinersheetTDS"] = viewJLinersheetTDS;
        }



        protected void grdJlinerSheet_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    GrdJlinerSheetAdd();
                    break;
            }
        }



        protected void grdJlinerSheet_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("dataEdit");
            if (Page.IsValid)
            {
                Guid id = new Guid(((Label)grdJlinerSheet.Rows[e.RowIndex].Cells[0].FindControl("lblId")).Text);
                int refId = Int32.Parse(((Label)grdJlinerSheet.Rows[e.RowIndex].Cells[1].FindControl("lblRefId")).Text);
                int companyId = Int32.Parse(((Label)grdJlinerSheet.Rows[e.RowIndex].Cells[2].FindControl("lblCOMPANY_ID")).Text);

                string mn = ""; if (((TextBox)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("tbxMnEdit")).Text.Trim() != "") mn = ((TextBox)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("tbxMnEdit")).Text.Trim();
                double? distanceFromUsmh = null; if (((TextBox)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("tbxDistanceFromUsmhEdit")).Text.Trim() != "") distanceFromUsmh = double.Parse(((TextBox)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("tbxDistanceFromUsmhEdit")).Text.Trim());
                string confirmedLatSize = ""; if (((TextBox)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("tbxConfirmedLatSizeEdit")).Text.Trim() != "") confirmedLatSize = ((TextBox)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("tbxConfirmedLatSizeEdit")).Text.Trim();
                string lateralMaterial = ""; if (((TextBox)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("tbxLateralMaterialEdit")).Text.Trim() != "") lateralMaterial = ((TextBox)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("tbxLateralMaterialEdit")).Text.Trim();
                string sharedLateral = ""; if (((DropDownList)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("ddlSharedLateralEdit")).Text.Trim() != "") sharedLateral = ((DropDownList)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("ddlSharedLateralEdit")).SelectedValue;
                bool cleanoutRequired = ((CheckBox)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("ckbxCleanoutRequiredEdit")).Checked;
                bool pitRequired = ((CheckBox)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("ckbxPitRequiredEdit")).Checked;
                bool mHShot = ((CheckBox)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("ckbxMhShotEdit")).Checked;
                string mainConnection = ""; if (((DropDownList)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("ddlMainConnectionEdit")).Text.Trim() != "") mainConnection = ((DropDownList)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("ddlMainConnectionEdit")).SelectedValue;
                string transition = ""; if (((DropDownList)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("ddlTransitionEdit")).Text.Trim() != "") transition = ((DropDownList)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("ddlTransitionEdit")).SelectedValue;
                bool cleanoutInstalled = ((CheckBox)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("ckbxCleanoutInstalledEdit")).Checked;
                bool pitInstalled = ((CheckBox)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("ckbxPitInstalledEdit")).Checked;
                bool cleanoutGrouted = ((CheckBox)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("ckbxCleanoutGroutedEdit")).Checked;
                bool cleanoutCored = ((CheckBox)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("ckbxCleanoutCoredEdit")).Checked;
                DateTime? prepCompleted = null; if (((RadDatePicker)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("tkrdpPrepCompletedEdit")).SelectedDate.HasValue) prepCompleted = ((RadDatePicker)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("tkrdpPrepCompletedEdit")).SelectedDate.Value;
                string measuredLatLength = ""; if (((TextBox)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("tbxMeasuredLatLengthEdit")).Text.Trim() != "") measuredLatLength = ((TextBox)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("tbxMeasuredLatLengthEdit")).Text.Trim();
                string measurementsTakenBy = ""; if (((TextBox)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("tbxMeasurementsTakenByEdit")).Text.Trim() != "") measurementsTakenBy = ((TextBox)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("tbxMeasurementsTakenByEdit")).Text.Trim();
                DateTime? linerInstalled = null; if (((RadDatePicker)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("tkrdpLinerInstalledEdit")).SelectedDate.HasValue) linerInstalled = ((RadDatePicker)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("tkrdpLinerInstalledEdit")).SelectedDate.Value;
                DateTime? finalVideo = null; if (((RadDatePicker)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("tkrdpFinalVideoEdit")).SelectedDate.HasValue) finalVideo = ((RadDatePicker)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("tkrdpFinalVideoEdit")).SelectedDate.Value;
                bool restorationComplete = ((CheckBox)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("ckbxRestorationCompleteEdit")).Checked;
                bool linerOrdered = ((CheckBox)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("ckbxLinerOrderedEdit")).Checked;
                bool linerInStock = ((CheckBox)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("ckbxLinerInStockEdit")).Checked;
                decimal? linerPrice = null; if (((TextBox)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("tbxLinerPriceEdit")).Text.Trim() != "") linerPrice = decimal.Parse(((TextBox)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("tbxLinerPriceEdit")).Text.Trim());
                string comments = ""; if (((TextBox)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("tbxCommentEdit")).Text.Trim() != "") comments = ((TextBox)grdJlinerSheet.Rows[e.RowIndex].Cells[3].FindControl("tbxCommentEdit")).Text.Trim();

                ViewJLinersheetJunctionLiner model = new ViewJLinersheetJunctionLiner(viewJLinersheetTDS);
                model.Update(id, refId, companyId, mn, distanceFromUsmh, confirmedLatSize, lateralMaterial, sharedLateral, cleanoutRequired, pitRequired, mHShot, mainConnection, transition, cleanoutInstalled, pitInstalled, cleanoutGrouted, cleanoutCored, prepCompleted, measuredLatLength, measurementsTakenBy, linerInstalled, finalVideo, restorationComplete, linerOrdered, linerInStock, linerPrice, comments);

                Session["viewJLinersheetTDS"] = viewJLinersheetTDS;
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
			Response.Redirect("delete_record.aspx?source_page=view_jlinersheet.aspx");
		}

		

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
				tbxComments.ReadOnly = false;
				tbxConfirmedSize.ReadOnly = false;
				tbxUSMHMN.ReadOnly = false;
				tbxDSMHMN.ReadOnly = false;
				cbxIssueIdentified.Enabled = true;
				cbxLFSIssue.Enabled = true;
				cbxSalesIssue.Enabled = true;
				cbxInvestigationIssue.Enabled = true;
				cbxIssueResolved.Enabled = true;
				cbxIssueGivenToBayCity.Enabled = true;
				cbxClientIssue.Enabled = true;
				tbxTrafficControlDetails.Enabled = true;
				ddlMainLined.Enabled = true;
				ddlBenchingIssue.Enabled = true;
				
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
				tbxComments.ReadOnly = true;
				tbxConfirmedSize.ReadOnly = true;
				tbxUSMHMN.ReadOnly = true;
				tbxDSMHMN.ReadOnly = true;
				cbxIssueIdentified.Enabled = false;
				cbxLFSIssue.Enabled = false;
				cbxSalesIssue.Enabled = false;
				cbxInvestigationIssue.Enabled = false;
				cbxIssueResolved.Enabled = false;
				cbxIssueGivenToBayCity.Enabled = false;
				cbxClientIssue.Enabled = false;
				tbxTrafficControlDetails.Enabled = false;
				ddlMainLined.Enabled = false;
				ddlBenchingIssue.Enabled = false;
				
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

        protected void grdJlinerSheet_DataBound(object sender, EventArgs e)
        {
            AddJlinersheetNewEmptyFix(grdJlinerSheet);
        }



        protected void grdJlinerSheet_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                Guid id = new Guid(((Label)e.Row.FindControl("lblId")).Text);
                int refId = Int32.Parse(((Label)e.Row.FindControl("lblRefId")).Text);
                int companyId = Int32.Parse(((Label)e.Row.FindControl("lblCOMPANY_ID")).Text);

                ViewJLinersheetJunctionLinerGateway viewJLinersheetJunctionLinerGateway = new ViewJLinersheetJunctionLinerGateway(viewJLinersheetTDS);

                // For Prep Completed
                if (viewJLinersheetJunctionLinerGateway.Table.Rows.Count > 0)
                {
                    if (viewJLinersheetJunctionLinerGateway.GetPrepCompleted(id, refId, companyId).HasValue)
                    {
                        ((RadDatePicker)e.Row.FindControl("tkrdpPrepCompletedEdit")).SelectedDate = viewJLinersheetJunctionLinerGateway.GetPrepCompleted(id, refId, companyId);
                    }
                }

                // For Liner Installed
                if (viewJLinersheetJunctionLinerGateway.Table.Rows.Count > 0)
                {
                    if (viewJLinersheetJunctionLinerGateway.GetLinerInstalled(id, refId, companyId).HasValue)
                    {
                        ((RadDatePicker)e.Row.FindControl("tkrdpLinerInstalledEdit")).SelectedDate = viewJLinersheetJunctionLinerGateway.GetLinerInstalled(id, refId, companyId);
                    }
                }

                // For Final Video
                if (viewJLinersheetJunctionLinerGateway.Table.Rows.Count > 0)
                {
                    if (viewJLinersheetJunctionLinerGateway.GetFinalVideo(id, refId, companyId).HasValue)
                    {
                        ((RadDatePicker)e.Row.FindControl("tkrdpFinalVideoEdit")).SelectedDate = viewJLinersheetJunctionLinerGateway.GetFinalVideo(id, refId, companyId);
                    }
                }

                // For Transition
                if (viewJLinersheetJunctionLinerGateway.Table.Rows.Count > 0)
                {
                    ((DropDownList)e.Row.FindControl("ddlTransitionEdit")).SelectedValue = viewJLinersheetJunctionLinerGateway.GetTransition(id, refId, companyId);                    
                }

                // For Main connection
                if (viewJLinersheetJunctionLinerGateway.Table.Rows.Count > 0)
                {
                    ((DropDownList)e.Row.FindControl("ddlMainConnectionEdit")).SelectedValue = viewJLinersheetJunctionLinerGateway.GetMainConnection(id, refId, companyId);
                }

                // For Shared Lateral
                if (viewJLinersheetJunctionLinerGateway.Table.Rows.Count > 0)
                {
                    ((DropDownList)e.Row.FindControl("ddlSharedLateralEdit")).SelectedValue = viewJLinersheetJunctionLinerGateway.GetSharedLateral(id, refId, companyId);
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
                // If the limit is reached
                ViewJLinersheetJunctionLiner viewJLinersheetJunctionLinerForDetailId = new ViewJLinersheetJunctionLiner(viewJLinersheetTDS);
                string newDetailId = viewJLinersheetJunctionLinerForDetailId.GetNewDetailId(viewJLinersheetTDS);

                if (newDetailId != "-1")
                {
                    ((Label)e.Row.FindControl("lblMnFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblDistanceFromUsmhFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblConfirmedLatSizeFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblLateralMaterialFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblSharedLateralFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblCleanoutRequiredFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblPitRequiredFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblMhShotFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblMainConnectionFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblTransitionFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblCleanoutInstalledFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblCleanoutGroutedFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblClenoutCoredFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblPitInstalledFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblPrepCompletedFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblMeasuredLatLengthFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblMeasurementsTakenByFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblLinerInstalledFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblFinalVideoFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblRestorationCompleteFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblLinerOrdered")).Visible = true;
                    ((Label)e.Row.FindControl("lblLinerInStockFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblLinerPriceFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblCommentsFooter")).Visible = true;

                    ((TextBox)e.Row.FindControl("tbxMnFooter")).Visible = true;
                    ((TextBox)e.Row.FindControl("tbxDistanceFromUsmhFooter")).Visible = true;
                    ((TextBox)e.Row.FindControl("tbxConfirmedLatSizeFooter")).Visible = true;
                    ((TextBox)e.Row.FindControl("tbxLateralMaterialFooter")).Visible = true;
                    ((DropDownList)e.Row.FindControl("ddlSharedLateralFooter")).Visible = true;
                    ((CheckBox)e.Row.FindControl("ckbxCleanoutRequiredFooter")).Visible = true;
                    ((CheckBox)e.Row.FindControl("ckbxPitRequiredFooter")).Visible = true;
                    ((CheckBox)e.Row.FindControl("ckbxMhShotFooter")).Visible = true;
                    ((DropDownList)e.Row.FindControl("ddlMainConnectionFooter")).Visible = true;
                    ((DropDownList)e.Row.FindControl("ddlTransitionFooter")).Visible = true;
                    ((CheckBox)e.Row.FindControl("ckbxCleanoutInstalledFooter")).Visible = true;
                    ((CheckBox)e.Row.FindControl("ckbxPitInstalledFooter")).Visible = true;
                    ((CheckBox)e.Row.FindControl("ckbxCleanoutGroutedFooter")).Visible = true;
                    ((CheckBox)e.Row.FindControl("ckbxCleanoutCoredFooter")).Visible = true;
                    ((RadDatePicker)e.Row.FindControl("tkrdpPrepCompletedFooter")).Visible = true;
                    ((TextBox)e.Row.FindControl("tbxMeasuredLatLengthFooter")).Visible = true;
                    ((TextBox)e.Row.FindControl("tbxMeasurementsTakenByFooter")).Visible = true;
                    ((RadDatePicker)e.Row.FindControl("tkrdpLinerInstalledFooter")).Visible = true;
                    ((RadDatePicker)e.Row.FindControl("tkrdpFinalVideoFooter")).Visible = true;
                    ((CheckBox)e.Row.FindControl("ckbxRestorationCompleteFooter")).Visible = true;
                    ((CheckBox)e.Row.FindControl("ckbxLinerOrderedFooter")).Visible = true;
                    ((CheckBox)e.Row.FindControl("ckbxLinerInStockFooter")).Visible = true;
                    ((TextBox)e.Row.FindControl("tbxLinerPriceFooter")).Visible = true;
                    ((TextBox)e.Row.FindControl("tbxCommentFooter")).Visible = true;
                    e.Row.FindControl("ibtnAdd").Visible = true;
                    lblMaxNumber.Visible = false;

                    if (!Convert.ToBoolean(Session["sgLFS_APP_EDIT"]))
                    {
                        ((Label)e.Row.FindControl("lblMnFooter")).Visible = false;
                        ((Label)e.Row.FindControl("lblDistanceFromUsmhFooter")).Visible = false;
                        ((Label)e.Row.FindControl("lblConfirmedLatSizeFooter")).Visible = false;
                        ((Label)e.Row.FindControl("lblLateralMaterialFooter")).Visible = false;
                        ((Label)e.Row.FindControl("lblSharedLateralFooter")).Visible = false;
                        ((Label)e.Row.FindControl("lblCleanoutRequiredFooter")).Visible = false;
                        ((Label)e.Row.FindControl("lblPitRequiredFooter")).Visible = false;
                        ((Label)e.Row.FindControl("lblMhShotFooter")).Visible = false;
                        ((Label)e.Row.FindControl("lblMainConnectionFooter")).Visible = false;
                        ((Label)e.Row.FindControl("lblTransitionFooter")).Visible = false;
                        ((Label)e.Row.FindControl("lblCleanoutInstalledFooter")).Visible = false;
                        ((Label)e.Row.FindControl("lblCleanoutGroutedFooter")).Visible = false;
                        ((Label)e.Row.FindControl("lblClenoutCoredFooter")).Visible = false;
                        ((Label)e.Row.FindControl("lblPitInstalledFooter")).Visible = false;
                        ((Label)e.Row.FindControl("lblPrepCompletedFooter")).Visible = false;
                        ((Label)e.Row.FindControl("lblMeasuredLatLengthFooter")).Visible = false;
                        ((Label)e.Row.FindControl("lblMeasurementsTakenByFooter")).Visible = false;
                        ((Label)e.Row.FindControl("lblLinerInstalledFooter")).Visible = false;
                        ((Label)e.Row.FindControl("lblFinalVideoFooter")).Visible = false;
                        ((Label)e.Row.FindControl("lblRestorationCompleteFooter")).Visible = false;
                        ((Label)e.Row.FindControl("lblLinerOrdered")).Visible = false;
                        ((Label)e.Row.FindControl("lblLinerInStockFooter")).Visible = false;
                        ((Label)e.Row.FindControl("lblLinerPriceFooter")).Visible = false;
                        ((Label)e.Row.FindControl("lblCommentsFooter")).Visible = false;

                        ((TextBox)e.Row.FindControl("tbxMnFooter")).Visible = false;
                        ((TextBox)e.Row.FindControl("tbxDistanceFromUsmhFooter")).Visible = false;
                        ((TextBox)e.Row.FindControl("tbxConfirmedLatSizeFooter")).Visible = false;
                        ((TextBox)e.Row.FindControl("tbxLateralMaterialFooter")).Visible = false;
                        ((DropDownList)e.Row.FindControl("ddlSharedLateralFooter")).Visible = false;
                        ((CheckBox)e.Row.FindControl("ckbxCleanoutRequiredFooter")).Visible = false;
                        ((CheckBox)e.Row.FindControl("ckbxPitRequiredFooter")).Visible = false;
                        ((CheckBox)e.Row.FindControl("ckbxMhShotFooter")).Visible = false;
                        ((DropDownList)e.Row.FindControl("ddlMainConnectionFooter")).Visible = false;
                        ((DropDownList)e.Row.FindControl("ddlTransitionFooter")).Visible = false;
                        ((CheckBox)e.Row.FindControl("ckbxCleanoutInstalledFooter")).Visible = false;
                        ((CheckBox)e.Row.FindControl("ckbxPitInstalledFooter")).Visible = false;
                        ((CheckBox)e.Row.FindControl("ckbxCleanoutGroutedFooter")).Visible = false;
                        ((CheckBox)e.Row.FindControl("ckbxCleanoutCoredFooter")).Visible = false;
                        ((RadDatePicker)e.Row.FindControl("tkrdpPrepCompletedFooter")).Visible = false;
                        ((TextBox)e.Row.FindControl("tbxMeasuredLatLengthFooter")).Visible = false;
                        ((TextBox)e.Row.FindControl("tbxMeasurementsTakenByFooter")).Visible = false;
                        ((RadDatePicker)e.Row.FindControl("tkrdpLinerInstalledFooter")).Visible = false;
                        ((RadDatePicker)e.Row.FindControl("tkrdpFinalVideoFooter")).Visible = false;
                        ((CheckBox)e.Row.FindControl("ckbxRestorationCompleteFooter")).Visible = false;
                        ((CheckBox)e.Row.FindControl("ckbxLinerOrderedFooter")).Visible = false;
                        ((CheckBox)e.Row.FindControl("ckbxLinerInStockFooter")).Visible = false;
                        ((TextBox)e.Row.FindControl("tbxLinerPriceFooter")).Visible = false;
                        ((TextBox)e.Row.FindControl("tbxCommentFooter")).Visible = false;
                        e.Row.FindControl("ibtnAdd").Visible = false;
                    }
                }
                else
                {
                    ((Label)e.Row.FindControl("lblMnFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblDistanceFromUsmhFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblConfirmedLatSizeFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblLateralMaterialFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblSharedLateralFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblCleanoutRequiredFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblPitRequiredFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblMhShotFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblMainConnectionFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblTransitionFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblCleanoutInstalledFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblCleanoutGroutedFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblClenoutCoredFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblPitInstalledFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblPrepCompletedFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblMeasuredLatLengthFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblMeasurementsTakenByFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblLinerInstalledFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblFinalVideoFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblRestorationCompleteFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblLinerOrdered")).Visible = false;
                    ((Label)e.Row.FindControl("lblLinerInStockFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblLinerPriceFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblCommentsFooter")).Visible = false;

                    ((TextBox)e.Row.FindControl("tbxMnFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxDistanceFromUsmhFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxConfirmedLatSizeFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxLateralMaterialFooter")).Visible = false;
                    ((DropDownList)e.Row.FindControl("ddlSharedLateralFooter")).Visible = false;
                    ((CheckBox)e.Row.FindControl("ckbxCleanoutRequiredFooter")).Visible = false;
                    ((CheckBox)e.Row.FindControl("ckbxPitRequiredFooter")).Visible = false;
                    ((CheckBox)e.Row.FindControl("ckbxMhShotFooter")).Visible = false;
                    ((DropDownList)e.Row.FindControl("ddlMainConnectionFooter")).Visible = false;
                    ((DropDownList)e.Row.FindControl("ddlTransitionFooter")).Visible = false;
                    ((CheckBox)e.Row.FindControl("ckbxCleanoutInstalledFooter")).Visible = false;
                    ((CheckBox)e.Row.FindControl("ckbxPitInstalledFooter")).Visible = false;
                    ((CheckBox)e.Row.FindControl("ckbxCleanoutGroutedFooter")).Visible = false;
                    ((CheckBox)e.Row.FindControl("ckbxCleanoutCoredFooter")).Visible = false;
                    ((RadDatePicker)e.Row.FindControl("tkrdpPrepCompletedFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxMeasuredLatLengthFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxMeasurementsTakenByFooter")).Visible = false;
                    ((RadDatePicker)e.Row.FindControl("tkrdpLinerInstalledFooter")).Visible = false;
                    ((RadDatePicker)e.Row.FindControl("tkrdpFinalVideoFooter")).Visible = false;
                    ((CheckBox)e.Row.FindControl("ckbxRestorationCompleteFooter")).Visible = false;
                    ((CheckBox)e.Row.FindControl("ckbxLinerOrderedFooter")).Visible = false;
                    ((CheckBox)e.Row.FindControl("ckbxLinerInStockFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxLinerPriceFooter")).Visible = false;
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
				//--- Post page changes
				PostPageChanges();

				//--- Update database
				UpdateDatabase();

				//--- Get previous record
				Session["lfsMasterAreaId"] = Navigator.GetPreviousId((TDSLFSRecordForNavigator)Session["tdsLfsRecordForNavigator"], new Guid(tbxID.Text));

				//--- Display new record
				Response.Redirect("view_jlinersheet.aspx?source_page=view_jlinersheet.aspx");
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
				Response.Redirect("view_jlinersheet.aspx?source_page=view_jlinersheet.aspx");
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

        public ViewJLinersheetTDS.JunctionLinerDataTable GetJlinerNew()
        {
            jliner = (ViewJLinersheetTDS.JunctionLinerDataTable)Session["jlinerDummy"];
            if (jliner == null)
            {
                jliner = (ViewJLinersheetTDS.JunctionLinerDataTable)Session["jliner"];
            }

            return jliner;
        }



        public void DummyJlinerNew(Guid ID, int RefID, int COMPANY_ID)
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./view_jlinersheet.js");
        }



        private void Save()
        {            
            bool validData = true;

            Page.Validate("dataFooter");
            if (!Page.IsValid) validData = false;

            Page.Validate("dataEdit");
            if (!Page.IsValid) validData = false;

            if (validData)
            {
                // LfsM2Tables Gridview, if the gridview is edition mode
                if (grdJlinerSheet.EditIndex >= 0)
                {
                    grdJlinerSheet.UpdateRow(grdJlinerSheet.EditIndex, true);
                }

                // ... Save point repairs data at footer
                GrdJlinerSheetAdd();

                // Save the rest of data
                this.PostPageChanges();
                this.UpdateDatabase();

                //--- Go to navigator2.aspx
                Response.Redirect("navigator2.aspx?record_modified=true");
            }
        }



        private void GrdJlinerSheetAdd()
        {
            if (ValidateFooter())
            {
                Page.Validate("dataFooter");
                if (Page.IsValid)
                {
                    Guid id = new Guid(tbxID.Text);
                    int companyId = Convert.ToInt32(Session["companyID"]);
                    ViewJLinersheetJunctionLiner viewJLinersheetJunctionLinerForDetailId = new ViewJLinersheetJunctionLiner(viewJLinersheetTDS);
                    string detailId = viewJLinersheetJunctionLinerForDetailId.GetNewDetailId(viewJLinersheetTDS);
                    string mn = ""; if (((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxMnFooter")).Text.Trim() != "") mn = ((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxMnFooter")).Text.Trim();
                    double? distanceFromUsmh = null; if (((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxDistanceFromUsmhFooter")).Text.Trim() != "") distanceFromUsmh = double.Parse(((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxDistanceFromUsmhFooter")).Text.Trim());
                    string confirmedLatSize = ""; if (((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxConfirmedLatSizeFooter")).Text.Trim() != "") confirmedLatSize = ((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxConfirmedLatSizeFooter")).Text.Trim();
                    string lateralMaterial = ""; if (((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxLateralMaterialFooter")).Text.Trim() != "") lateralMaterial = ((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxLateralMaterialFooter")).Text.Trim();
                    string sharedLateral = ""; if (((DropDownList)grdJlinerSheet.FooterRow.FindControl("ddlSharedLateralFooter")).Text.Trim() != "") sharedLateral = ((DropDownList)grdJlinerSheet.FooterRow.FindControl("ddlSharedLateralFooter")).SelectedValue;
                    bool cleanoutRequired = ((CheckBox)grdJlinerSheet.FooterRow.FindControl("ckbxCleanoutRequiredFooter")).Checked;
                    bool pitRequired = ((CheckBox)grdJlinerSheet.FooterRow.FindControl("ckbxPitRequiredFooter")).Checked;
                    bool mHShot = ((CheckBox)grdJlinerSheet.FooterRow.FindControl("ckbxMhShotFooter")).Checked;
                    string mainConnection = ""; if (((DropDownList)grdJlinerSheet.FooterRow.FindControl("ddlMainConnectionFooter")).Text.Trim() != "") mainConnection = ((DropDownList)grdJlinerSheet.FooterRow.FindControl("ddlMainConnectionFooter")).SelectedValue;
                    string transition = ""; if (((DropDownList)grdJlinerSheet.FooterRow.FindControl("ddlTransitionFooter")).Text.Trim() != "") transition = ((DropDownList)grdJlinerSheet.FooterRow.FindControl("ddlTransitionFooter")).SelectedValue;
                    bool cleanoutInstalled = ((CheckBox)grdJlinerSheet.FooterRow.FindControl("ckbxCleanoutInstalledFooter")).Checked;
                    bool pitInstalled = ((CheckBox)grdJlinerSheet.FooterRow.FindControl("ckbxPitInstalledFooter")).Checked;
                    bool cleanoutGrouted = ((CheckBox)grdJlinerSheet.FooterRow.FindControl("ckbxCleanoutGroutedFooter")).Checked;
                    bool cleanoutCored = ((CheckBox)grdJlinerSheet.FooterRow.FindControl("ckbxCleanoutCoredFooter")).Checked;
                    DateTime? prepCompleted = null; if (((RadDatePicker)grdJlinerSheet.FooterRow.FindControl("tkrdpPrepCompletedFooter")).SelectedDate.HasValue) prepCompleted = ((RadDatePicker)grdJlinerSheet.FooterRow.FindControl("tkrdpPrepCompletedFooter")).SelectedDate.Value;
                    string measuredLatLength = ""; if (((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxMeasuredLatLengthFooter")).Text.Trim() != "") measuredLatLength = ((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxMeasuredLatLengthFooter")).Text.Trim();
                    string measurementsTakenBy = ""; if (((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxMeasurementsTakenByFooter")).Text.Trim() != "") measurementsTakenBy = ((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxMeasurementsTakenByFooter")).Text.Trim();
                    DateTime? linerInstalled = null; if (((RadDatePicker)grdJlinerSheet.FooterRow.FindControl("tkrdpLinerInstalledFooter")).SelectedDate.HasValue) linerInstalled = ((RadDatePicker)grdJlinerSheet.FooterRow.FindControl("tkrdpLinerInstalledFooter")).SelectedDate.Value;
                    DateTime? finalVideo = null; if (((RadDatePicker)grdJlinerSheet.FooterRow.FindControl("tkrdpFinalVideoFooter")).SelectedDate.HasValue) finalVideo = ((RadDatePicker)grdJlinerSheet.FooterRow.FindControl("tkrdpFinalVideoFooter")).SelectedDate.Value;
                    bool restorationComplete = ((CheckBox)grdJlinerSheet.FooterRow.FindControl("ckbxRestorationCompleteFooter")).Checked;
                    bool linerOrdered = ((CheckBox)grdJlinerSheet.FooterRow.FindControl("ckbxLinerOrderedFooter")).Checked;
                    bool linerInStock = ((CheckBox)grdJlinerSheet.FooterRow.FindControl("ckbxLinerInStockFooter")).Checked;
                    decimal? linerPrice = null; if (((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxLinerPriceFooter")).Text.Trim() != "") linerPrice = decimal.Parse(((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxLinerPriceFooter")).Text.Trim());
                    string comments = ""; if (((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxCommentFooter")).Text.Trim() != "") comments = ((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxCommentFooter")).Text.Trim();
                    bool archived = false;
                    bool deleted = false;
                    bool inDatabase = false;

                    ViewJLinersheetJunctionLiner model = new ViewJLinersheetJunctionLiner(viewJLinersheetTDS);
                    model.Insert(id, companyId, detailId, mn, distanceFromUsmh, confirmedLatSize, lateralMaterial, sharedLateral, cleanoutRequired, pitRequired, mHShot, mainConnection, transition, cleanoutInstalled, pitInstalled, cleanoutGrouted, cleanoutCored, prepCompleted, measuredLatLength, measurementsTakenBy, linerInstalled, finalVideo, restorationComplete, linerOrdered, linerInStock, linerPrice, comments, deleted, archived, inDatabase);

                    Session.Remove("jlinerDummy");
                    Session["viewJLinersheetTDS"] = viewJLinersheetTDS;
                    jliner = viewJLinersheetTDS.JunctionLiner;
                    Session["jliner"] = jliner;

                    grdJlinerSheet.DataBind();
                    grdJlinerSheet.PageIndex = grdJlinerSheet.PageCount - 1;
                }
            }
        }



        private bool ValidateFooter()
        {
            string mn = ""; if (((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxMnFooter")).Text.Trim() != "") mn = ((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxMnFooter")).Text.Trim();
            double? distanceFromUsmh = null; if (((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxDistanceFromUsmhFooter")).Text.Trim() != "") distanceFromUsmh = double.Parse(((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxDistanceFromUsmhFooter")).Text.Trim());
            string confirmedLatSize = ""; if (((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxConfirmedLatSizeFooter")).Text.Trim() != "") confirmedLatSize = ((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxConfirmedLatSizeFooter")).Text.Trim();
            string lateralMaterial = ""; if (((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxLateralMaterialFooter")).Text.Trim() != "") lateralMaterial = ((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxLateralMaterialFooter")).Text.Trim();
            string sharedLateral = ""; if (((DropDownList)grdJlinerSheet.FooterRow.FindControl("ddlSharedLateralFooter")).Text.Trim() != "") sharedLateral = ((DropDownList)grdJlinerSheet.FooterRow.FindControl("ddlSharedLateralFooter")).SelectedValue;
            bool cleanoutRequired = ((CheckBox)grdJlinerSheet.FooterRow.FindControl("ckbxCleanoutRequiredFooter")).Checked;
            bool pitRequired = ((CheckBox)grdJlinerSheet.FooterRow.FindControl("ckbxPitRequiredFooter")).Checked;
            bool mHShot = ((CheckBox)grdJlinerSheet.FooterRow.FindControl("ckbxMhShotFooter")).Checked;
            string mainConnection = ""; if (((DropDownList)grdJlinerSheet.FooterRow.FindControl("ddlMainConnectionFooter")).Text.Trim() != "") mainConnection = ((DropDownList)grdJlinerSheet.FooterRow.FindControl("ddlMainConnectionFooter")).SelectedValue;
            string transition = ""; if (((DropDownList)grdJlinerSheet.FooterRow.FindControl("ddlTransitionFooter")).Text.Trim() != "") transition = ((DropDownList)grdJlinerSheet.FooterRow.FindControl("ddlTransitionFooter")).SelectedValue;
            bool cleanoutInstalled = ((CheckBox)grdJlinerSheet.FooterRow.FindControl("ckbxCleanoutInstalledFooter")).Checked;
            bool pitInstalled = ((CheckBox)grdJlinerSheet.FooterRow.FindControl("ckbxPitInstalledFooter")).Checked;
            bool cleanoutGrouted = ((CheckBox)grdJlinerSheet.FooterRow.FindControl("ckbxCleanoutGroutedFooter")).Checked;
            bool cleanoutCored = ((CheckBox)grdJlinerSheet.FooterRow.FindControl("ckbxCleanoutCoredFooter")).Checked;
            DateTime? prepCompleted = null; if (((RadDatePicker)grdJlinerSheet.FooterRow.FindControl("tkrdpPrepCompletedFooter")).SelectedDate.HasValue) prepCompleted = ((RadDatePicker)grdJlinerSheet.FooterRow.FindControl("tkrdpPrepCompletedFooter")).SelectedDate.Value;
            string measuredLatLength = ""; if (((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxMeasuredLatLengthFooter")).Text.Trim() != "") measuredLatLength = ((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxMeasuredLatLengthFooter")).Text.Trim();
            string measurementsTakenBy = ""; if (((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxMeasurementsTakenByFooter")).Text.Trim() != "") measurementsTakenBy = ((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxMeasurementsTakenByFooter")).Text.Trim();
            DateTime? linerInstalled = null; if (((RadDatePicker)grdJlinerSheet.FooterRow.FindControl("tkrdpLinerInstalledFooter")).SelectedDate.HasValue) linerInstalled = ((RadDatePicker)grdJlinerSheet.FooterRow.FindControl("tkrdpLinerInstalledFooter")).SelectedDate.Value;
            DateTime? finalVideo = null; if (((RadDatePicker)grdJlinerSheet.FooterRow.FindControl("tkrdpFinalVideoFooter")).SelectedDate.HasValue) finalVideo = ((RadDatePicker)grdJlinerSheet.FooterRow.FindControl("tkrdpFinalVideoFooter")).SelectedDate.Value;
            bool restorationComplete = ((CheckBox)grdJlinerSheet.FooterRow.FindControl("ckbxRestorationCompleteFooter")).Checked;
            bool linerOrdered = ((CheckBox)grdJlinerSheet.FooterRow.FindControl("ckbxLinerOrderedFooter")).Checked;
            bool linerInStock = ((CheckBox)grdJlinerSheet.FooterRow.FindControl("ckbxLinerInStockFooter")).Checked;
            decimal? linerPrice = null; if (((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxLinerPriceFooter")).Text.Trim() != "") linerPrice = decimal.Parse(((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxLinerPriceFooter")).Text.Trim());
            string comments = ""; if (((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxCommentFooter")).Text.Trim() != "") comments = ((TextBox)grdJlinerSheet.FooterRow.FindControl("tbxCommentFooter")).Text.Trim();

            if ((distanceFromUsmh.HasValue) || (mn != "") || (confirmedLatSize != "") || (lateralMaterial != "") || (sharedLateral != "") || (cleanoutRequired) || (pitRequired) || (mHShot) || (mainConnection != "") || (transition != "") || (cleanoutInstalled) || (pitInstalled) || (cleanoutGrouted) || (cleanoutCored) || (prepCompleted.HasValue) || (measuredLatLength != "") || (measurementsTakenBy != "") || (linerInstalled.HasValue) || (finalVideo.HasValue) || (restorationComplete) || (linerOrdered) || (linerInStock) || (linerPrice.HasValue) || (comments != ""))
            {
                return true;
            }

            return false;
        }



        protected void AddJlinersheetNewEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                ViewJLinersheetTDS.JunctionLinerDataTable dt = new ViewJLinersheetTDS.JunctionLinerDataTable();
                dt.AddJunctionLinerRow(Guid.NewGuid(), -1, -1, "", "", -1, "", "", "", false, false, false, "", "", false, false, false, false, new DateTime(), "", "", new DateTime(), new DateTime(), false, false, false, -1, "", false, false, false);
                Session["jlinerDummy"] = dt;

                grdView.DataBind();
            }

            // normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ViewJLinersheetTDS.JunctionLinerDataTable dt = (ViewJLinersheetTDS.JunctionLinerDataTable)Session["jlinerDummy"];
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
			if (tbxComments.Text.Trim() != "") lfsMasterAreaRow.Comments = tbxComments.Text.Trim(); else lfsMasterAreaRow.SetCommentsNull();
			if (tbxConfirmedSize.Text.Trim() != "") lfsMasterAreaRow.ConfirmedSize = Int32.Parse(tbxConfirmedSize.Text.Trim()); else lfsMasterAreaRow.SetConfirmedSizeNull();
			if (tbxUSMHMN.Text.Trim() != "") lfsMasterAreaRow.USMHMN = tbxUSMHMN.Text.Trim(); else lfsMasterAreaRow.SetUSMHMNNull();
			if (tbxDSMHMN.Text.Trim() != "") lfsMasterAreaRow.DSMHMN = tbxDSMHMN.Text.Trim(); else lfsMasterAreaRow.SetDSMHMNNull();
			if (tbxActualLength.Text.Trim() != "") lfsMasterAreaRow.SteelTapeThruPipe = tbxActualLength.Text.Trim(); else lfsMasterAreaRow.SetSteelTapeThruPipeNull(); // SYNCHRONIZED
			lfsMasterAreaRow.IssueIdentified = cbxIssueIdentified.Checked;
			lfsMasterAreaRow.LFSIssue = cbxLFSIssue.Checked;
			lfsMasterAreaRow.SalesIssue = cbxSalesIssue.Checked;
			lfsMasterAreaRow.InvestigationIssue = cbxInvestigationIssue.Checked;
			lfsMasterAreaRow.IssueResolved = cbxIssueResolved.Checked;
			lfsMasterAreaRow.IssueGivenToBayCity = cbxIssueGivenToBayCity.Checked;
			lfsMasterAreaRow.ClientIssue = cbxClientIssue.Checked;
			if (tbxTrafficControlDetails.Text.Trim() != "") lfsMasterAreaRow.TrafficControlDetails = tbxTrafficControlDetails.Text.Trim(); else lfsMasterAreaRow.SetTrafficControlDetailsNull();
			if (ddlMainLined.SelectedValue != "") lfsMasterAreaRow.MainLined = ddlMainLined.SelectedValue; else lfsMasterAreaRow.SetMainLinedNull();
			if (ddlBenchingIssue.SelectedValue != "") lfsMasterAreaRow.BenchingIssue = ddlBenchingIssue.SelectedValue; else lfsMasterAreaRow.SetBenchingIssueNull();

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
            AddRecordTDS addRecordTDS = new AddRecordTDS();

            string tdsToWork = "viewJLinersheet";

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
			this.cvScaledLength.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.cvScaledLength_ServerValidate);
			this.cvActualLength.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.cvActualLength_ServerValidate);
			this.cvP1Date.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.Date_ServerValidate);

            
            
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
