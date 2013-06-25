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

namespace LiquiForce.LFSLive.WebUI.CWP
{
    /// <summary>
    /// view_fulllength_m2
    /// </summary>
	public partial class view_fulllength_m2 : System.Web.UI.Page
	{
		///////////////////////////////////////////////////////////////////////////
		/// PROPERTIES AND FIELDS
		///

		protected TDSLFSRecord tdsLfsRecord;
        protected ViewFullLengthLiningTDS viewFullLengthLiningTDS;
        protected ViewFullLengthLiningTDS.LfsM2TablesDataTable lfsM2Tables;






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

                // Prepare initial 
                Session.Remove("lfsM2TablesDummy");

                //... Restore data set lfs record
                tdsLfsRecord = (TDSLFSRecord)Session["tdsLfsRecord"];

				// ... for client
				CompaniesGateway companiesGateway = new CompaniesGateway();
				tbxCOMPANIES_ID.Text = companiesGateway.GetName((int)tdsLfsRecord.LFS_MASTER_AREA.Rows[0]["COMPANIES_ID"], Convert.ToInt32(Session["companyID"]));

				// ... for measurement type
				LFSMeasurementTypeGateway lfsMeasurementTypeGateway = new LFSMeasurementTypeGateway();
				DataSet dsLfsMeasurementType = lfsMeasurementTypeGateway.GetLFSMeasurementTypeForDropDownList("");
				
				ddlMeasurementType.DataSource = dsLfsMeasurementType;
				ddlMeasurementType.DataTextField = "MeasurementType";

                // Load LfsM2Tables data
                int companyId = Convert.ToInt32(Session["companyID"]);
                Guid id = new Guid(Request.QueryString["id"].ToString());
                hdfId.Value = Request.QueryString["id"].ToString();
                
                viewFullLengthLiningTDS = new ViewFullLengthLiningTDS();
                ViewFullLengthLiningLfsM2TablesGateway viewFullLengthLiningLfsM2TablesGateway = new ViewFullLengthLiningLfsM2TablesGateway(viewFullLengthLiningTDS);
                viewFullLengthLiningLfsM2TablesGateway.LoadById(id, companyId);

                Session["viewFullLengthLiningTDS"] = viewFullLengthLiningTDS;
                lfsM2Tables = viewFullLengthLiningTDS.LfsM2Tables;
                Session["lfsM2Tables"] = lfsM2Tables;
				
				// Databind
				Page.DataBind();

				TDSLFSRecord.LFS_MASTER_AREARow lfsMasterAreaRow = tdsLfsRecord.LFS_MASTER_AREA.FindByIDCOMPANY_ID(new Guid(tbxID.Text), Convert.ToInt32(Session["companyID"]));
				ddlMeasurementType.SelectedValue = (lfsMasterAreaRow.IsMeasurementTypeNull()) ? "" : lfsMasterAreaRow.MeasurementType;
			}
			else
			{
				// Restore data set lfs record
				tdsLfsRecord = (TDSLFSRecord)Session["tdsLfsRecord"];
                viewFullLengthLiningTDS = (ViewFullLengthLiningTDS)Session["viewFullLengthLiningTDS"];
			}
		}



        protected void grdLfsM2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            Guid id = new Guid(((Label)grdLfsM2.Rows[e.RowIndex].Cells[0].FindControl("lblId")).Text);
            int refId = Int32.Parse(((Label)grdLfsM2.Rows[e.RowIndex].Cells[1].FindControl("lblRefId")).Text);
            int companyId = Int32.Parse(((Label)grdLfsM2.Rows[e.RowIndex].Cells[2].FindControl("lblCOMPANY_ID")).Text);

            ViewFullLengthLiningLfsM2Tables model = new ViewFullLengthLiningLfsM2Tables(viewFullLengthLiningTDS);
            model.Delete(id, refId, companyId);

            Session["viewFullLengthLiningTDS"] = viewFullLengthLiningTDS;
        }



        protected void grdLfsM2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    GrdLfsM2TablesAdd();
                    break;
            }
        }



        protected void grdLfsM2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("dataEdit");
            if (Page.IsValid)
            {
                Guid id = new Guid(((Label)grdLfsM2.Rows[e.RowIndex].Cells[0].FindControl("lblId")).Text);
                int refId = Int32.Parse(((Label)grdLfsM2.Rows[e.RowIndex].Cells[1].FindControl("lblRefId")).Text);
                int companyId = Int32.Parse(((Label)grdLfsM2.Rows[e.RowIndex].Cells[2].FindControl("lblCOMPANY_ID")).Text);

                float? videoDistance = null; if (((TextBox)grdLfsM2.Rows[e.RowIndex].Cells[3].FindControl("tbxVideoDistanceEdit")).Text.Trim() != "") videoDistance = float.Parse(((TextBox)grdLfsM2.Rows[e.RowIndex].Cells[3].FindControl("tbxVideoDistanceEdit")).Text.Trim());
                string clockPosition = ""; if (((TextBox)grdLfsM2.Rows[e.RowIndex].Cells[3].FindControl("tbxClockPositionEdit")).Text.Trim() != "") clockPosition = ((TextBox)grdLfsM2.Rows[e.RowIndex].Cells[3].FindControl("tbxClockPositionEdit")).Text.Trim();
                string liveOrAbandoned = ""; if (((TextBox)grdLfsM2.Rows[e.RowIndex].Cells[3].FindControl("tbxLiveOrAbandonedEdit")).Text.Trim() != "") liveOrAbandoned = ((TextBox)grdLfsM2.Rows[e.RowIndex].Cells[3].FindControl("tbxLiveOrAbandonedEdit")).Text.Trim();
                string distanceToCentreOfLateral = ""; if (((TextBox)grdLfsM2.Rows[e.RowIndex].Cells[3].FindControl("tbxDistanceToCentreEdit")).Text.Trim() != "") distanceToCentreOfLateral = ((TextBox)grdLfsM2.Rows[e.RowIndex].Cells[3].FindControl("tbxDistanceToCentreEdit")).Text.Trim();
                string lateralDiameter = ""; if (((TextBox)grdLfsM2.Rows[e.RowIndex].Cells[3].FindControl("tbxLateralDiameterEdit")).Text.Trim() != "") lateralDiameter = ((TextBox)grdLfsM2.Rows[e.RowIndex].Cells[3].FindControl("tbxLateralDiameterEdit")).Text.Trim();
                string lateralType = ""; if (((TextBox)grdLfsM2.Rows[e.RowIndex].Cells[3].FindControl("tbxLateralTypeEdit")).Text.Trim() != "") lateralType = ((TextBox)grdLfsM2.Rows[e.RowIndex].Cells[3].FindControl("tbxLateralTypeEdit")).Text.Trim();
                string dateTimeOpened = ""; if (((TextBox)grdLfsM2.Rows[e.RowIndex].Cells[3].FindControl("tbxTimeOpenedEdit")).Text.Trim() != "") dateTimeOpened = ((TextBox)grdLfsM2.Rows[e.RowIndex].Cells[3].FindControl("tbxTimeOpenedEdit")).Text.Trim();
                string comments = ""; if (((TextBox)grdLfsM2.Rows[e.RowIndex].Cells[3].FindControl("tbxCommentEdit")).Text.Trim() != "") comments = ((TextBox)grdLfsM2.Rows[e.RowIndex].Cells[3].FindControl("tbxCommentEdit")).Text.Trim();
                string reverseSetup = "";
                if (distanceToCentreOfLateral != "")
                {
                    TDSLFSRecord.LFS_MASTER_AREARow lfsMasterAreaRow = tdsLfsRecord.LFS_MASTER_AREA.FindByIDCOMPANY_ID(new Guid(tbxID.Text), Convert.ToInt32(Session["companyID"]));
                    reverseSetup = Distance.Subtract(lfsMasterAreaRow.IsActualLengthNull() ? "" : lfsMasterAreaRow.ActualLength, distanceToCentreOfLateral);
                }

                ViewFullLengthLiningLfsM2Tables model = new ViewFullLengthLiningLfsM2Tables(viewFullLengthLiningTDS);
                model.Update(id, refId, companyId, videoDistance, clockPosition, liveOrAbandoned, distanceToCentreOfLateral, lateralDiameter, lateralType, dateTimeOpened, comments, reverseSetup);

                Session["viewFullLengthLiningTDS"] = viewFullLengthLiningTDS;
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
				tbxLiveLats.ReadOnly = false;
				tbxM2Date.ReadOnly = false;
				tbxConfirmedSize.ReadOnly = false;
				tbxCappedLaterals.ReadOnly = false;
				tbxVideoDoneFrom.ReadOnly = false;
				tbxToManhole.ReadOnly = false;
				tbxCutterDescriptionDuringMeasuring.ReadOnly = false;
				ddlMeasurementType.Enabled = true;
				tbxMeasuredFromManhole.ReadOnly = false;

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
				tbxLiveLats.ReadOnly = true;
				tbxM2Date.ReadOnly = true;
				tbxConfirmedSize.ReadOnly = true;
				tbxCappedLaterals.ReadOnly = true;
				tbxVideoDoneFrom.ReadOnly = true;
				tbxToManhole.ReadOnly = true;
				tbxCutterDescriptionDuringMeasuring.ReadOnly = true;
				ddlMeasurementType.Enabled = false;
				tbxMeasuredFromManhole.ReadOnly = true;

				//--- Buttons
				btnOK.Enabled = false;
				btnOK1.Enabled = false;
				btnCancel.Enabled = true;
				btnCancel1.Enabled = true;
			}
		}






		/// ////////////////////////////////////////////////////////////////////////
		/// AUXILIAR EVENTS
		///

        protected void grdLfsM2_DataBound(object sender, EventArgs e)
        {
            AddLfsM2TablesNewEmptyFix(grdLfsM2);
        }



        protected void grdLfsM2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
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
                    ((Label)e.Row.FindControl("lblVideoDistanceFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblClockPositionFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblLiveOrAbandonedFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblDistanceToCentreFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblLateralDiameterFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblLateralTypeFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblTimeOpenedFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblReverseSetupFooter")).Visible = true;
                    ((Label)e.Row.FindControl("lblCommentsFooter")).Visible = true;

                    ((TextBox)e.Row.FindControl("tbxVideoDistanceFooter")).Visible = true;
                    ((TextBox)e.Row.FindControl("tbxClockPositionFooter")).Visible = true;
                    ((TextBox)e.Row.FindControl("tbxLiveOrAbandonedFooter")).Visible = true;
                    ((TextBox)e.Row.FindControl("tbxDistanceToCentreFooter")).Visible = true;
                    ((TextBox)e.Row.FindControl("tbxLateralDiameterFooter")).Visible = true;
                    ((TextBox)e.Row.FindControl("tbxLateralTypeFooter")).Visible = true;
                    ((TextBox)e.Row.FindControl("tbxTimeOpenedFooter")).Visible = true;
                    ((TextBox)e.Row.FindControl("tbxReverseSetupFooter")).Visible = true;
                    ((TextBox)e.Row.FindControl("tbxCommentFooter")).Visible = true;
                    e.Row.FindControl("ibtnAdd").Visible = true;                                            
                }
                else
                {
                    ((Label)e.Row.FindControl("lblVideoDistanceFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblClockPositionFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblLiveOrAbandonedFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblDistanceToCentreFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblLateralDiameterFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblLateralTypeFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblTimeOpenedFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblReverseSetupFooter")).Visible = false;
                    ((Label)e.Row.FindControl("lblCommentsFooter")).Visible = false;

                    ((TextBox)e.Row.FindControl("tbxVideoDistanceFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxClockPositionFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxLiveOrAbandonedFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxDistanceToCentreFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxLateralDiameterFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxLateralTypeFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxTimeOpenedFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxReverseSetupFooter")).Visible = false;
                    ((TextBox)e.Row.FindControl("tbxCommentFooter")).Visible = false;
                    e.Row.FindControl("ibtnAdd").Visible = false;                    
                }
            }
        }



        protected void cvDistance_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (args.Value.Trim() != "")
            {
                if (!Validator.IsValidDecimalForGrid(args.Value.Trim()))
                {
                    args.IsValid = false;
                }
            }        
        }



        protected void cvDistanceToCentre_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (args.Value.Trim() != "")
            {
                if (!Distance.IsValidDistanceInFormatEng1(args.Value.Trim()))
                {
                    args.IsValid = false;
                }
            }
        }



		protected void lkbtnSectionDetails_Click(object sender, System.EventArgs e)
		{
			//--- Validate page
			Page.Validate();

			if (Page.IsValid)
			{
				//--- Post page changes
				PostPageChanges();

				//--- Go to view_fulllength_m1.aspx
				Response.Redirect("view_fulllength.aspx?source_page=view_fulllength_m2.aspx");
			}	
		}

		

		protected void lkbtnM1_Click(object sender, System.EventArgs e)
		{
			//--- Validate page
			Page.Validate();

			if (Page.IsValid)
			{
				//--- Post page changes
				PostPageChanges();

				//--- Go to view_fulllength_m2.aspx
                Response.Redirect("view_fulllength_m1.aspx?id=" + hdfId.Value);
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





		
        /// ////////////////////////////////////////////////////////////////////////
        /// PUBLIC METHODS
        ///

        public ViewFullLengthLiningTDS.LfsM2TablesDataTable GetLfsM2New()
        {
            lfsM2Tables = (ViewFullLengthLiningTDS.LfsM2TablesDataTable)Session["lfsM2TablesDummy"];
            if (lfsM2Tables == null)
            {
                lfsM2Tables = (ViewFullLengthLiningTDS.LfsM2TablesDataTable)Session["lfsM2Tables"];
            }

            return lfsM2Tables;
        }



        public void DummyLfsM2New(Guid ID, int RefID, int COMPANY_ID)
        {
        }






        /// ////////////////////////////////////////////////////////////////////////
		/// PRIVATE METHODS
		///

        private void Save()
        {
            bool validData = true;

            Page.Validate("addRecord");
            if (!Page.IsValid) validData = false;

            Page.Validate("dataEdit");
            if (!Page.IsValid) validData = false;

            if (validData)
            {
                // LfsM2Tables Gridview, if the gridview is edition mode
                if (grdLfsM2.EditIndex >= 0)
                {
                    grdLfsM2.UpdateRow(grdLfsM2.EditIndex, true);
                }

                // ... Save point repairs data at footer
                GrdLfsM2TablesAdd();

                // Save the rest of data
                this.PostPageChanges();
                this.UpdateDatabase();

                //--- Go to navigator2.aspx
                Response.Redirect("navigator2.aspx?record_modified=true");
            }
        }



        private void GrdLfsM2TablesAdd()
        {
            if (ValidateFooter())
            {
                Page.Validate("dataFooter");
                if (Page.IsValid)
                {
                    Guid id = new Guid(Request.QueryString["id"].ToString());
                    int companyId = Convert.ToInt32(Session["companyID"]);

                    float? videoDistance = null; if(((TextBox)grdLfsM2.FooterRow.FindControl("tbxVideoDistanceFooter")).Text != "") videoDistance = Single.Parse(((TextBox)grdLfsM2.FooterRow.FindControl("tbxVideoDistanceFooter")).Text.Trim());
                    string clockPosition = ""; if (((TextBox)grdLfsM2.FooterRow.FindControl("tbxClockPositionFooter")).Text.Trim() != "") clockPosition = ((TextBox)grdLfsM2.FooterRow.FindControl("tbxClockPositionFooter")).Text.Trim();
                    string liveOrAbandoned = ""; if (((TextBox)grdLfsM2.FooterRow.FindControl("tbxLiveOrAbandonedFooter")).Text.Trim() != "") liveOrAbandoned = ((TextBox)grdLfsM2.FooterRow.FindControl("tbxLiveOrAbandonedFooter")).Text.Trim();
                    string distanceToCentreOfLateral = ""; if (((TextBox)grdLfsM2.FooterRow.FindControl("tbxDistanceToCentreFooter")).Text.Trim() != "") distanceToCentreOfLateral = ((TextBox)grdLfsM2.FooterRow.FindControl("tbxDistanceToCentreFooter")).Text.Trim();
                    string lateralDiameter = ""; if (((TextBox)grdLfsM2.FooterRow.FindControl("tbxLateralDiameterFooter")).Text.Trim() != "") lateralDiameter = ((TextBox)grdLfsM2.FooterRow.FindControl("tbxLateralDiameterFooter")).Text.Trim();
                    string lateralType = ""; if (((TextBox)grdLfsM2.FooterRow.FindControl("tbxLateralTypeFooter")).Text.Trim() != "") lateralType = ((TextBox)grdLfsM2.FooterRow.FindControl("tbxLateralTypeFooter")).Text.Trim();
                    string dateTimeOpened = ""; if (((TextBox)grdLfsM2.FooterRow.FindControl("tbxTimeOpenedFooter")).Text.Trim() != "") dateTimeOpened = ((TextBox)grdLfsM2.FooterRow.FindControl("tbxTimeOpenedFooter")).Text.Trim();
                    string comments = ""; if (((TextBox)grdLfsM2.FooterRow.FindControl("tbxCommentFooter")).Text.Trim() != "") comments = ((TextBox)grdLfsM2.FooterRow.FindControl("tbxCommentFooter")).Text.Trim();
                    string reverseSetup = "";
                    if (distanceToCentreOfLateral != "")
                    {
                        TDSLFSRecord.LFS_MASTER_AREARow lfsMasterAreaRow = tdsLfsRecord.LFS_MASTER_AREA.FindByIDCOMPANY_ID(new Guid(tbxID.Text), Convert.ToInt32(Session["companyID"]));
                        reverseSetup = Distance.Subtract(lfsMasterAreaRow.IsActualLengthNull() ? "" : lfsMasterAreaRow.ActualLength, distanceToCentreOfLateral);
                    }
                    
                    bool archived = false;
                    bool deleted = false;
                    bool inDatabase = false;

                    ViewFullLengthLiningLfsM2Tables model = new ViewFullLengthLiningLfsM2Tables(viewFullLengthLiningTDS);
                    model.Insert(id, companyId, videoDistance, clockPosition, liveOrAbandoned, distanceToCentreOfLateral, lateralDiameter, lateralType, dateTimeOpened, comments, reverseSetup, deleted, archived, inDatabase);

                    Session.Remove("lfsM2TablesDummy");
                    Session["viewFullLengthLiningTDS"] = viewFullLengthLiningTDS;
                    lfsM2Tables = viewFullLengthLiningTDS.LfsM2Tables;
                    Session["lfsM2Tables"] = lfsM2Tables;

                    grdLfsM2.DataBind();
                    grdLfsM2.PageIndex = grdLfsM2.PageCount - 1;
                }
            }
        }



        private bool ValidateFooter()
        {
            float? videoDistance = null; if (((TextBox)grdLfsM2.FooterRow.FindControl("tbxVideoDistanceFooter")).Text != "") videoDistance = Single.Parse(((TextBox)grdLfsM2.FooterRow.FindControl("tbxVideoDistanceFooter")).Text.Trim());
            string clockPosition = ""; if (((TextBox)grdLfsM2.FooterRow.FindControl("tbxClockPositionFooter")).Text.Trim() != "") clockPosition = ((TextBox)grdLfsM2.FooterRow.FindControl("tbxClockPositionFooter")).Text.Trim();
            string liveOrAbandoned = ""; if (((TextBox)grdLfsM2.FooterRow.FindControl("tbxLiveOrAbandonedFooter")).Text.Trim() != "") liveOrAbandoned = ((TextBox)grdLfsM2.FooterRow.FindControl("tbxLiveOrAbandonedFooter")).Text.Trim();
            string distanceToCentreOfLateral = ""; if (((TextBox)grdLfsM2.FooterRow.FindControl("tbxDistanceToCentreFooter")).Text.Trim() != "") distanceToCentreOfLateral = ((TextBox)grdLfsM2.FooterRow.FindControl("tbxDistanceToCentreFooter")).Text.Trim();
            string lateralDiameter = ""; if (((TextBox)grdLfsM2.FooterRow.FindControl("tbxLateralDiameterFooter")).Text.Trim() != "") lateralDiameter = ((TextBox)grdLfsM2.FooterRow.FindControl("tbxLateralDiameterFooter")).Text.Trim();
            string lateralType = ""; if (((TextBox)grdLfsM2.FooterRow.FindControl("tbxLateralTypeFooter")).Text.Trim() != "") lateralType = ((TextBox)grdLfsM2.FooterRow.FindControl("tbxLateralTypeFooter")).Text.Trim();
            string dateTimeOpened = ""; if (((TextBox)grdLfsM2.FooterRow.FindControl("tbxTimeOpenedFooter")).Text.Trim() != "") dateTimeOpened = ((TextBox)grdLfsM2.FooterRow.FindControl("tbxTimeOpenedFooter")).Text.Trim();
            string comments = ""; if (((TextBox)grdLfsM2.FooterRow.FindControl("tbxCommentFooter")).Text.Trim() != "") comments = ((TextBox)grdLfsM2.FooterRow.FindControl("tbxCommentFooter")).Text.Trim();

            if ((videoDistance.HasValue) || (clockPosition != "" ) || (liveOrAbandoned != "") || (distanceToCentreOfLateral != "") || (lateralDiameter != "") || (lateralType != "") || (dateTimeOpened != "") || (comments != ""))
            {
                return true;
            }

            return false;
        }



        protected void AddLfsM2TablesNewEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                ViewFullLengthLiningTDS.LfsM2TablesDataTable dt = new ViewFullLengthLiningTDS.LfsM2TablesDataTable();
                dt.AddLfsM2TablesRow(Guid.NewGuid(), -1, -1, -1, "", "", "", "", "", "", "", "", false, false, false);
                Session["lfsM2TablesDummy"] = dt;

                grdView.DataBind();
            }

            // normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ViewFullLengthLiningTDS.LfsM2TablesDataTable dt = (ViewFullLengthLiningTDS.LfsM2TablesDataTable)Session["lfsM2TablesDummy"];
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
			if (tbxLiveLats.Text.Trim() != "") lfsMasterAreaRow.LiveLats = Double.Parse(tbxLiveLats.Text.Trim()); else lfsMasterAreaRow.SetLiveLatsNull();
			if (tbxM2Date.Text.Trim() != "") lfsMasterAreaRow.M2Date = DateTime.Parse(tbxM2Date.Text.Trim()); else lfsMasterAreaRow.SetM2DateNull();
			if (tbxConfirmedSize.Text.Trim() != "") lfsMasterAreaRow.ConfirmedSize = Int32.Parse(tbxConfirmedSize.Text.Trim()); else lfsMasterAreaRow.SetConfirmedSizeNull();
			if (tbxCappedLaterals.Text.Trim() != "") lfsMasterAreaRow.CappedLaterals = Int32.Parse(tbxCappedLaterals.Text.Trim());  else lfsMasterAreaRow.SetCappedLateralsNull();
			if (tbxVideoDoneFrom.Text.Trim() != "") lfsMasterAreaRow.VideoDoneFrom = tbxVideoDoneFrom.Text.Trim(); else lfsMasterAreaRow.SetVideoDoneFromNull();
			if (tbxToManhole.Text.Trim() != "") lfsMasterAreaRow.ToManhole = tbxToManhole.Text.Trim(); else lfsMasterAreaRow.SetToManholeNull();
			if (tbxCutterDescriptionDuringMeasuring.Text.Trim() != "") lfsMasterAreaRow.CutterDescriptionDuringMeasuring = tbxCutterDescriptionDuringMeasuring.Text.Trim(); else lfsMasterAreaRow.SetCutterDescriptionDuringMeasuringNull();
			if (ddlMeasurementType.SelectedValue != "") lfsMasterAreaRow.MeasurementType = ddlMeasurementType.SelectedValue; else lfsMasterAreaRow.SetMeasurementTypeNull();
			if (tbxMeasuredFromManhole.Text.Trim() != "") lfsMasterAreaRow.MeasuredFromManhole = tbxMeasuredFromManhole.Text.Trim(); else lfsMasterAreaRow.SetMeasuredFromManholeNull();

			//--- Store dataset lfs record
			Session["tdsLfsRecord"] = tdsLfsRecord;
		}

		

		private void UpdateDatabase()
		{
            // Initialize extra data
            AddRecordTDS addRecordTDS = new AddRecordTDS();
            ViewJLinersheetTDS viewJLinersheetTDS = new ViewJLinersheetTDS();
            string tdsToWork = "viewFullLengthLining";

            // Save data
            int companyId = Convert.ToInt32(Session["companyID"]);
            LFSRecordGateway lfsRecordGateway = new LFSRecordGateway();
            lfsRecordGateway.UpdateRecord2(tdsLfsRecord, companyId, addRecordTDS, viewFullLengthLiningTDS, viewJLinersheetTDS, tdsToWork);

            //--- Store dataset lfs record
            Session["tdsLfsRecord"] = tdsLfsRecord;            
            Session["viewFullLengthLiningTDS"] = viewFullLengthLiningTDS;
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
			this.cvM2Date.ServerValidate += new System.Web.UI.WebControls.ServerValidateEventHandler(this.Date_ServerValidate);

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

