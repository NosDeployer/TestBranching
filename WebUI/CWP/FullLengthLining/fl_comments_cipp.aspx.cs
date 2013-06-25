using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.BL.CWP.FullLengthLining;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.BL.CWP.Works;

namespace LiquiForce.LFSLive.WebUI.CWP.FullLengthLining
{
    /// <summary>
    /// fl_comments_cipp
    /// </summary>
    public partial class fl_comments_cipp : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected FullLengthLiningTDS fullLengthLiningTDS;
        protected FullLengthLiningTDS.WetOutCommentsDetailsDataTable fullLengthLiningWetOutCommentDetails;






        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            // Register client scripts
            this.RegisterClientScripts();

            if (!IsPostBack)
            {
                // Security check
                if (!(Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_VIEW"]) && Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_EDIT"]) && Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_ADD"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["work_id"] == null) || ((string)Request.QueryString["asset_id"] == null) && ((string)Request.QueryString["run_details"] == null) && ((string)Request.QueryString["project_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in fl_comments_cipp.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfLoginId.Value = Convert.ToInt32(Session["loginID"]).ToString();
                hdfAdminPermission.Value = Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_ADMIN"]).ToString();
                hdfWorkType.Value = "Full Length Lining Wet Out";
                hdfWorkId.Value = Request.QueryString["work_id"].ToString();
                hdfAssetId.Value = Request.QueryString["asset_id"].ToString();
                hdfRunDetail.Value = Request.QueryString["run_details"].ToString();
                hdfProjectId.Value = Request.QueryString["project_id"].ToString();
                hdfUpdate.Value = "yes";

                // ... Names for UserList
                string workType = hdfWorkType.Value.Trim();
                int companyId = Int32.Parse(hdfCompanyId.Value);

                LoginGateway loginGateway = new LoginGateway();
                loginGateway.LoadByLoginId(Convert.ToInt32(hdfLoginId.Value), companyId);
                hdfCreatedBy.Value = loginGateway.GetLastName(Convert.ToInt32(hdfLoginId.Value), companyId) + " " + loginGateway.GetFirstName(Convert.ToInt32(hdfLoginId.Value), companyId);

                // Prepare initial data
                Session.Remove("fullLengthLiningWetOutCommentDetailsDummy");
                Session.Remove("fullLengthLiningWetOutCommentDetails");

                // If coming from 
                // ... fl_summary.aspx and fl_edit.aspx but not notesCipp
                if (Request.QueryString["source_page"] == "fl_summary.aspx" || Request.QueryString["source_page"] == "fl_edit.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    fullLengthLiningTDS = (FullLengthLiningTDS)Session["fullLengthLiningTDS"];
                    int flWorkId = Int32.Parse(hdfWorkId.Value.Trim());
                    
                    // ... If the project has fl works
                    if (flWorkId != 0)
                    {                           
                        // ... update fl cip comments
                        FullLengthLiningWetOutCommentsDetailsGateway fullLengthLiningWetOutCommentsDetailsGateway = new FullLengthLiningWetOutCommentsDetailsGateway(fullLengthLiningTDS);
                        fullLengthLiningWetOutCommentsDetailsGateway.LoadAllByWorkIdWorkType(flWorkId, companyId, "Full Length Lining Wet Out");

                        FullLengthLiningWetOutCommentsDetails fullLengthLiningWetOutCommentsDetails = new FullLengthLiningWetOutCommentsDetails(fullLengthLiningWetOutCommentsDetailsGateway.Data);
                        fullLengthLiningWetOutCommentsDetails.UpdateForProcess();                                                
                    }                    

                    // ... Store datasets
                    Session["fullLengthLiningTDS"] = fullLengthLiningTDS;
                    Session["fullLengthLiningWetOutCommentDetails"] = fullLengthLiningTDS.WetOutCommentsDetails;
                }
            }
            else
            {
                // Restore datasets
                fullLengthLiningTDS = (FullLengthLiningTDS)Session["fullLengthLiningTDS"];
                fullLengthLiningWetOutCommentDetails = fullLengthLiningTDS.WetOutCommentsDetails;

                // Store
                Session["fullLengthLiningWetOutCommentDetails"] = fullLengthLiningTDS.WetOutCommentsDetails;
            }
        }



        protected void btnSave_Click(object sender, System.EventArgs e)
        {
            Save();
        }



        protected void grdComments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Comments Gridview, if the gridview is edition mode
                    if (grdComments.EditIndex >= 0)
                    {
                        grdComments.UpdateRow(grdComments.EditIndex, true);
                    }

                    // Add New Comment
                    GrdCommentsAdd();
                    break;
            }
        }



        protected void grdComments_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Comments Gridview, if the gridview is edition mode
            if (grdComments.EditIndex >= 0)
            {
                grdComments.UpdateRow(grdComments.EditIndex, true);
            }

            // Delete comments
            int workId = (int)e.Keys["WorkID"];
            int refId = (int)e.Keys["RefID"];
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int loginId = Convert.ToInt32(hdfLoginId.Value);
            bool adminPermission = Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_ADMIN"]);

            // Delete comment
            FullLengthLiningWetOutCommentsDetails model = new FullLengthLiningWetOutCommentsDetails(fullLengthLiningTDS);
            model.Delete(workId, refId, companyId, loginId, adminPermission);

            // Store dataset
            Session["fullLengthLiningTDS"] = fullLengthLiningTDS;
        }



        protected void grdComments_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("commentsDataEdit");
            if (Page.IsValid)
            {
                int workId = (int)e.Keys["WorkID"];
                int refId = (int)e.Keys["RefID"];
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int loginId = Convert.ToInt32(Session["loginID"]);
                bool adminPermission = Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_ADMIN"]);
                bool toHistory = false;

                string newSubject = ((TextBox)grdComments.Rows[e.RowIndex].Cells[3].FindControl("tbxSubjectEdit")).Text.Trim();
                string newComment = ((TextBox)grdComments.Rows[e.RowIndex].Cells[4].FindControl("tbxCommentsEdit")).Text.Trim();
                string newType = "";
                if (((DropDownList)grdComments.Rows[e.RowIndex].Cells[3].FindControl("ddlTypeEdit")).Visible)
                {
                    newType = ((DropDownList)grdComments.Rows[e.RowIndex].Cells[3].FindControl("ddlTypeEdit")).SelectedValue.ToString().Trim();
                }
                else
                {
                    newType = ((TextBox)grdComments.Rows[e.RowIndex].Cells[3].FindControl("tbxTypeEdit")).Text;
                }

                // Update data
                FullLengthLiningWetOutCommentsDetails model = new FullLengthLiningWetOutCommentsDetails(fullLengthLiningTDS);
                model.Update(workId, refId, newType, newSubject, companyId, newComment, loginId, adminPermission, toHistory);

                // Store dataset
                Session["fullLengthLiningTDS"] = fullLengthLiningTDS;
                Session["fullLengthLiningWetOutCommentDetails"] = fullLengthLiningTDS.WetOutCommentsDetails;
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Dialog title
            mDialog2 dialog2 = (mDialog2)this.Master;
            dialog2.DialogTitle = "Comments For Full Length Lining";
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void grdComments_DataBound(object sender, EventArgs e)
        {
            AddCommentsNewEmptyFix(grdComments);
        }



        protected void grdComments_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || ((e.Row.RowState == DataControlRowState.Alternate))))
            {
                if (((Label)e.Row.FindControl("lblUserId")).Text != "")
                {
                    int loginId = Int32.Parse(hdfLoginId.Value);
                    bool adminPermission = bool.Parse(hdfAdminPermission.Value);
                    int rowUserId = Int32.Parse(((Label)e.Row.FindControl("lblUserId")).Text);

                    if ((loginId == rowUserId) || (adminPermission))
                    {
                        e.Row.FindControl("ibtnDelete").Visible = true;
                        e.Row.FindControl("ibtnEdit").Visible = true;
                    }
                    else
                    {
                        e.Row.FindControl("ibtnDelete").Visible = false;
                        e.Row.FindControl("ibtnEdit").Visible = false;
                    }
                }
            }

            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int workId = Int32.Parse(((Label)e.Row.FindControl("lblWorkID")).Text.Trim());
                int refId = Int32.Parse(((Label)e.Row.FindControl("lblRefID")).Text.Trim());

                FullLengthLiningWetOutCommentsDetailsGateway fullLengthLiningWetOutCommentDetailsGateway = new FullLengthLiningWetOutCommentsDetailsGateway(fullLengthLiningTDS);
                string type = fullLengthLiningWetOutCommentDetailsGateway.GetType(workId, refId);
                                
                ((TextBox)e.Row.FindControl("tbxTypeEdit")).Text = type;
                ((TextBox)e.Row.FindControl("tbxTypeEdit")).Visible = true;
                ((DropDownList)e.Row.FindControl("ddlTypeEdit")).Visible = false;
                ((DropDownList)e.Row.FindControl("ddlTypeEdit")).SelectedValue = "Wet Out";                    
            }

            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ((DropDownList)e.Row.FindControl("ddlTypeNew")).SelectedValue = "Wet Out";                                   
            }
        }



        protected void grdComments_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Comments Gridview, if the gridview is edition mode
            if (grdComments.EditIndex >= 0)
            {
                grdComments.UpdateRow(grdComments.EditIndex, true);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        //  METHODS
        //

        public FullLengthLiningTDS.WetOutCommentsDetailsDataTable GetCommentsNew()
        {
            fullLengthLiningWetOutCommentDetails = (FullLengthLiningTDS.WetOutCommentsDetailsDataTable)Session["fullLengthLiningWetOutCommentDetailsDummy"];
            if (fullLengthLiningWetOutCommentDetails == null)
            {
                fullLengthLiningWetOutCommentDetails = ((FullLengthLiningTDS.WetOutCommentsDetailsDataTable)Session["fullLengthLiningWetOutCommentDetails"]);
            }

            return fullLengthLiningWetOutCommentDetails;
        }



        public void DummyCommentNew(int WorkID, int RefID)
        {
        }



        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register client-side events
            HtmlGenericControl body = (HtmlGenericControl)Page.Master.FindControl("myBody");
            body.Attributes.Add("onunload", "OnUnload();");

            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfUpdateId = '" + hdfUpdate.ClientID + "';";
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./fl_comments_cipp.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&search_projectnumber=" + Request.QueryString["search_projectnumber"] + "&search_projectname=" + Request.QueryString["search_projectname"] + "&search_client=" + Request.QueryString["search_client"] + "&search_type=" + Request.QueryString["search_type"] + "&search_state=" + Request.QueryString["search_state"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private void Save()
        {
            // Validate page
            Page.Validate("commentsDataEdit");
            if (Page.IsValid)
            {
                // Comments Gridview
                // ... If the gridview is edition mode
                if (grdComments.EditIndex >= 0)
                {
                    grdComments.UpdateRow(grdComments.EditIndex, true);
                }

                // Add data if exist at grid's foot
                GrdCommentsAdd();

                // Update data
                UpdateDatabase();

                // If coming from 
                // ... fl_summary.aspx or fl_edit.aspx
                if (Request.QueryString["source_page"] == "fl_summary.aspx" || Request.QueryString["source_page"] == "fl_edit.aspx")
                {
                    ViewState["update"] = "yes";
                    Response.Write("<script language='javascript'> {window.close();}</script>");
                }
            }
        }



        private void UpdateDatabase()
        {
            DB.Open();
            DB.BeginTransaction();
            try
            {               
                // Update comments
                string runDetails = hdfRunDetail.Value;                
                int projectId = Int32.Parse(hdfProjectId.Value);
                int companyId = Int32.Parse(hdfCompanyId.Value);

                FullLengthLiningWetOutCommentsDetails fullLengthLiningWetOutCommentsDetails = new FullLengthLiningWetOutCommentsDetails(fullLengthLiningTDS);
                fullLengthLiningWetOutCommentsDetails.Save(companyId, runDetails, projectId);

                // Update works
                workUpdate();

                // Update section
                int workId = Int32.Parse(hdfWorkId.Value.Trim());
                FullLengthLiningWorkDetails fullLengthLiningWorkDetails = new FullLengthLiningWorkDetails(fullLengthLiningTDS);
                fullLengthLiningWorkDetails.UpdateCommentsWetOutForSummaryEdit(workId, companyId);

                // Store datasets
                Session["fullLengthLiningTDS"] = fullLengthLiningTDS;

                DB.CommitTransaction();
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private void workUpdate()
        {
            // Get general variables
            int workId = Int32.Parse(hdfWorkId.Value.Trim());
            int assetId = Int32.Parse(hdfAssetId.Value.Trim());
            int originalCompanyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string workType = hdfWorkType.Value.Trim();
            bool originalDeleted = false;

            // Get original variables                         
            FullLengthLiningWorkDetailsGateway fullLengthLiningWorkDetailsGateway = new FullLengthLiningWorkDetailsGateway();
            fullLengthLiningWorkDetailsGateway.LoadByWorkIdAssetId(workId, assetId, originalCompanyId);                              

            // ... Verify if work has cipp information
            if (fullLengthLiningWorkDetailsGateway.Table.Rows.Count > 0)
            {
                // Wet Out data original values
                string originalLinerTube = fullLengthLiningWorkDetailsGateway.GetLinerTubeOriginal(workId);
                int originalResinId = fullLengthLiningWorkDetailsGateway.GetResinIdOriginal(workId);
                decimal originalExcessResin = fullLengthLiningWorkDetailsGateway.GetExcessResinOriginal(workId);
                string originalPoundsDrums = fullLengthLiningWorkDetailsGateway.GetPoundsDrumsOriginal(workId);
                decimal originalDrumDiameter = fullLengthLiningWorkDetailsGateway.GetDrumDiameterOriginal(workId);
                decimal originalHoistMaximumHeight = fullLengthLiningWorkDetailsGateway.GetHoistMaximumHeightOriginal(workId);
                decimal originalHoistMinimumHeight = fullLengthLiningWorkDetailsGateway.GetHoistMinimumHeightOriginal(workId);
                decimal originalDownDropTubeLenght = fullLengthLiningWorkDetailsGateway.GetDownDropTubeLenghtOriginal(workId);
                decimal originalPumpHeightAboveGround = fullLengthLiningWorkDetailsGateway.GetPumpHeightAboveGroundOriginal(workId);
                int originalTubeResinToFeltFactor = fullLengthLiningWorkDetailsGateway.GetTubeResinToFeltFactorOriginal(workId);
                DateTime originalDateOfSheet = fullLengthLiningWorkDetailsGateway.GetDateOfSheetOriginal(workId);
                int originalEmployeeId = fullLengthLiningWorkDetailsGateway.GetEmployeeIdOriginal(workId);
                string originalRunDetails = fullLengthLiningWorkDetailsGateway.GetRunDetailsOriginal(workId);
                string originalRunDetails2 = fullLengthLiningWorkDetailsGateway.GetRunDetails2Original(workId);
                DateTime originalWetOutDate = fullLengthLiningWorkDetailsGateway.GetWetOutDateOriginal(workId);
                DateTime? originalWetOutInstallDate = fullLengthLiningWorkDetailsGateway.GetWetOutInstallDateOriginal(workId);
                string originalThickness = fullLengthLiningWorkDetailsGateway.GetInversionThicknessOriginal(workId);
                decimal originalLengthToLine = fullLengthLiningWorkDetailsGateway.GetLengthToLineOriginal(workId);
                decimal originalPlusExtra = fullLengthLiningWorkDetailsGateway.GetPlusExtraOriginal(workId);
                decimal originalForTurnOffset = fullLengthLiningWorkDetailsGateway.GetForTurnOffsetOriginal(workId);
                decimal originalLengthToWetOut = fullLengthLiningWorkDetailsGateway.GetLengthToWetOutOriginal(workId);
                decimal originalTubeMaxColdHead = fullLengthLiningWorkDetailsGateway.GetTubeMaxColdHeadOriginal(workId);
                decimal originalTubeMaxColdHeadPsi = fullLengthLiningWorkDetailsGateway.GetTubeMaxColdHeadPsiOriginal(workId);
                decimal originalTubeMaxHotHead = fullLengthLiningWorkDetailsGateway.GetTubeMaxHotHeadOriginal(workId);
                decimal originalTubeMaxHotHeadPsi = fullLengthLiningWorkDetailsGateway.GetTubeMaxHotHeadPsiOriginal(workId);
                decimal originalTubeIdealHead = fullLengthLiningWorkDetailsGateway.GetTubeIdealHeadOriginal(workId);
                decimal originalTubeIdealHeadPsi = fullLengthLiningWorkDetailsGateway.GetTubeIdealHeadPsiOriginal(workId);
                decimal originalNetResinForTube = fullLengthLiningWorkDetailsGateway.GetNetResinForTubeOriginal(workId);
                decimal originalNetResinForTubeUsgals = fullLengthLiningWorkDetailsGateway.GetNetResinForTubeUsgalsOriginal(workId);
                string originalNetResinForTubeDrumsIns = fullLengthLiningWorkDetailsGateway.GetNetResinForTubeDrumsInsOriginal(workId);
                decimal originalNetResinForTubeLbsFt = fullLengthLiningWorkDetailsGateway.GetNetResinForTubeLbsFtOriginal(workId);
                decimal originalNetResinForTubeUsgFt = fullLengthLiningWorkDetailsGateway.GetNetResinForTubeUsgFtOriginal(workId);
                int originalExtraResinForMix = fullLengthLiningWorkDetailsGateway.GetExtraResinForMixOriginal(workId);
                decimal originalExtraLbsForMix = fullLengthLiningWorkDetailsGateway.GetExtraLbsForMixOriginal(workId);
                decimal originalTotalMixQuantity = fullLengthLiningWorkDetailsGateway.GetTotalMixQuantityOriginal(workId);
                decimal originalTotalMixQuantityUsgals = fullLengthLiningWorkDetailsGateway.GetTotalMixQuantityUsgalsOriginal(workId);
                string originalTotalMixQuantityDrumsIns = fullLengthLiningWorkDetailsGateway.GetTotalMixQuantityDrumsInsOriginal(workId);
                string originalInversionType = fullLengthLiningWorkDetailsGateway.GetInversionTypeOriginal(workId);
                decimal originalDepthOfInversionMH = fullLengthLiningWorkDetailsGateway.GetDepthOfInversionMHOriginal(workId);
                decimal originalTubeForColumn = fullLengthLiningWorkDetailsGateway.GetTubeForColumnOriginal(workId);
                decimal originalTubeForStartDry = fullLengthLiningWorkDetailsGateway.GetTubeForStartDryOriginal(workId);
                decimal originalTotalTube = fullLengthLiningWorkDetailsGateway.GetTotalTubeOriginal(workId);
                string originalDropTubeConnects = fullLengthLiningWorkDetailsGateway.GetDropTubeConnectsOriginal(workId);
                decimal originalAllowsHeadTo = fullLengthLiningWorkDetailsGateway.GetAllowsHeadToOriginal(workId);
                decimal originalRollerGap = fullLengthLiningWorkDetailsGateway.GetRollerGapOriginal(workId);
                decimal originalHeightNeeded = fullLengthLiningWorkDetailsGateway.GetHeightNeededOriginal(workId);
                string originalAvailable = fullLengthLiningWorkDetailsGateway.GetAvailableOriginal(workId);
                string originalHoistHeight = fullLengthLiningWorkDetailsGateway.GetHoistHeightOriginal(workId);
                string originalCommentsCipp = fullLengthLiningWorkDetailsGateway.GetCommentsCippOriginal(workId);
                string originalResinsLabel = fullLengthLiningWorkDetailsGateway.GetResinsLabelOriginal(workId);
                string originalDrumContainsLabel = fullLengthLiningWorkDetailsGateway.GetDrumContainsLabelOriginal(workId);
                string originalLinerTubeLabel = fullLengthLiningWorkDetailsGateway.GetLinerTubeLabelOriginal(workId);
                string originalForLbDrumsLabel = fullLengthLiningWorkDetailsGateway.GetForLbDrumsLabelOriginal(workId);
                string originalNetResinLabel = fullLengthLiningWorkDetailsGateway.GetNetResinLabelOriginal(workId);
                string originalCatalystLabel = fullLengthLiningWorkDetailsGateway.GetCatalystLabelOriginal(workId);
                               
                // Wet Out new data 
                // ... Get new comment
                WorkFullLengthLiningWetOutCommentsGateway workFullLengthLiningWetOutCommentsGateway = new WorkFullLengthLiningWetOutCommentsGateway();
                workFullLengthLiningWetOutCommentsGateway.LoadAllByWorkIdWorkType(workId, originalCompanyId, workType);
                
                WorkFullLengthLiningWetOutComments workFullLengthLiningWetOutComments = new WorkFullLengthLiningWetOutComments(workFullLengthLiningWetOutCommentsGateway.Data);
                string newComments = workFullLengthLiningWetOutComments.GetCommentsSummary(originalCompanyId, workFullLengthLiningWetOutCommentsGateway.Table.Rows.Count, "\n");
                                          
                // Update work with cipp information
                WorkFullLengthLiningWetOut workFullLengthLiningWetOut = new WorkFullLengthLiningWetOut(null);
                workFullLengthLiningWetOut.UpdateDirect(workId, originalLinerTube, originalResinId, originalExcessResin, originalPoundsDrums, originalDrumDiameter, originalHoistMaximumHeight, originalHoistMinimumHeight, originalDownDropTubeLenght, originalPumpHeightAboveGround, originalTubeResinToFeltFactor, originalDateOfSheet, originalEmployeeId, originalRunDetails, originalRunDetails2, originalWetOutDate, originalWetOutInstallDate, originalThickness, originalLengthToLine, originalPlusExtra, originalForTurnOffset, originalLengthToWetOut, originalTubeMaxColdHead, originalTubeMaxColdHeadPsi, originalTubeMaxHotHead, originalTubeMaxHotHeadPsi, originalTubeIdealHead, originalTubeIdealHeadPsi, originalNetResinForTube, originalNetResinForTubeUsgals, originalNetResinForTubeDrumsIns, originalNetResinForTubeLbsFt, originalNetResinForTubeUsgFt, originalExtraResinForMix, originalExtraLbsForMix, originalTotalMixQuantity, originalTotalMixQuantityUsgals, originalTotalMixQuantityDrumsIns, originalInversionType, originalDepthOfInversionMH, originalTubeForColumn, originalTubeForStartDry, originalTotalTube, originalDropTubeConnects, originalAllowsHeadTo, originalRollerGap, originalHeightNeeded, originalAvailable, originalHoistHeight, originalCommentsCipp, originalResinsLabel, originalDrumContainsLabel, originalLinerTubeLabel, originalForLbDrumsLabel, originalNetResinLabel, originalCatalystLabel, originalDeleted, originalCompanyId, workId, originalLinerTube, originalResinId, originalExcessResin, originalPoundsDrums, originalDrumDiameter, originalHoistMaximumHeight, originalHoistMinimumHeight, originalDownDropTubeLenght, originalPumpHeightAboveGround, originalTubeResinToFeltFactor, originalDateOfSheet, originalEmployeeId, originalRunDetails, originalRunDetails2, originalWetOutDate, originalWetOutInstallDate, originalThickness, originalLengthToLine, originalPlusExtra, originalForTurnOffset, originalLengthToWetOut, originalTubeMaxColdHead, originalTubeMaxColdHeadPsi, originalTubeMaxHotHead, originalTubeMaxHotHeadPsi, originalTubeIdealHead, originalTubeIdealHeadPsi, originalNetResinForTube, originalNetResinForTubeUsgals, originalNetResinForTubeDrumsIns, originalNetResinForTubeLbsFt, originalNetResinForTubeUsgFt, originalExtraResinForMix, originalExtraLbsForMix, originalTotalMixQuantity, originalTotalMixQuantityUsgals, originalTotalMixQuantityDrumsIns, originalInversionType, originalDepthOfInversionMH, originalTubeForColumn, originalTubeForStartDry, originalTotalTube, originalDropTubeConnects, originalAllowsHeadTo, originalRollerGap, originalHeightNeeded, originalAvailable, originalHoistHeight, newComments, originalResinsLabel, originalDrumContainsLabel, originalLinerTubeLabel, originalForLbDrumsLabel, originalNetResinLabel, originalCatalystLabel, originalDeleted, originalCompanyId);
            }
        }



        protected string GetCommentCreatedBy(object userId)
        {
            if (userId != DBNull.Value)
            {
                if (Convert.ToInt32(userId) != -1)
                {
                    try
                    {
                        // Created By
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        LoginGateway loginGateway = new LoginGateway();
                        loginGateway.LoadByLoginId(Convert.ToInt32(userId), companyId);
                        string userName = loginGateway.GetLastName(Convert.ToInt32(userId), companyId) + " " + loginGateway.GetFirstName(Convert.ToInt32(userId), companyId);

                        return userName.ToString();
                    }
                    catch
                    {
                        return "";
                    }
                }
                else
                {
                    return "";
                }
            }
            else
            {
                return "";
            }
        }



        private bool ValidateCommentsFooter()
        {
            string subject = ((TextBox)grdComments.FooterRow.FindControl("tbxSubjectNew")).Text.Trim();
            string comment = ((TextBox)grdComments.FooterRow.FindControl("tbxCommentsNew")).Text.Trim();

            if ((subject != "") || (comment != ""))
            {
                return true;
            }

            return false;
        }



        protected void AddCommentsNewEmptyFix(GridView grdComments)
        {
            if (grdComments.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                FullLengthLiningTDS.WetOutCommentsDetailsDataTable dt = new FullLengthLiningTDS.WetOutCommentsDetailsDataTable();
                dt.AddWetOutCommentsDetailsRow(-1, -1, "", "", -1, DateTime.Now, "", -1, false, companyId, false, "", "");
                Session["fullLengthLiningWetOutCommentDetailsDummy"] = dt;

                grdComments.DataBind();
            }

            // Normally executes at all postbacks
            if (grdComments.Rows.Count == 1)
            {
                FullLengthLiningTDS.WetOutCommentsDetailsDataTable dt = (FullLengthLiningTDS.WetOutCommentsDetailsDataTable)Session["fullLengthLiningWetOutCommentDetailsDummy"];
                if (dt != null)
                {
                    grdComments.Rows[0].Visible = false;
                    grdComments.Rows[0].Controls.Clear();
                }
            }
        }



        private void GrdCommentsAdd()
        {
            if (ValidateCommentsFooter())
            {
                Page.Validate("commentsDataAdd");
                if (Page.IsValid)
                {
                    int workId = Int32.Parse(hdfWorkId.Value);
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    DateTime dateTime_ = DateTime.Now;
                    bool inDatabase = false;
                    bool deleted = false;
                    string workType = hdfWorkType.Value;

                    string newSubject = ((TextBox)grdComments.FooterRow.FindControl("tbxSubjectNew")).Text.Trim();
                    string newType = ((DropDownList)grdComments.FooterRow.FindControl("ddlTypeNew")).SelectedValue.ToString().Trim();                   
                    string newComment = ((TextBox)grdComments.FooterRow.FindControl("tbxCommentsNew")).Text.Trim();
                    int? libraryFilesId = null; if (((Label)grdComments.FooterRow.FindControl("lblLIBRARY_FILES_IDNew")).Text != "") libraryFilesId = Int32.Parse(((Label)grdComments.FooterRow.FindControl("lblLIBRARY_FILES_IDNew")).Text.Trim());

                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string userFullName = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);

                    FullLengthLiningWetOutCommentsDetails model = new FullLengthLiningWetOutCommentsDetails(fullLengthLiningTDS);
                    model.Insert(workId, newType, newSubject, loginId, dateTime_, newComment, libraryFilesId, deleted, companyId, inDatabase, userFullName, workType);

                    Session.Remove("fullLengthLiningWetOutCommentDetailsDummy");
                    Session["fullLengthLiningTDS"] = fullLengthLiningTDS;
                    Session["fullLengthLiningWetOutCommentDetails"] = fullLengthLiningTDS.WetOutCommentsDetails;

                    grdComments.DataBind();
                    grdComments.PageIndex = grdComments.PageCount - 1;
                }
            }
        }


    }
}
