using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.CWP.FullLengthLining;
using LiquiForce.LFSLive.BL.CWP.RehabAssessment;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.DA.CWP.RehabAssessment;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.WebUI.CWP.RehabAssessment
{
    /// <summary>
    /// ra_comments
    /// </summar
    public partial class ra_comments : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected RehabAssessmentTDS rehabAssessmentTDS;
        protected RehabAssessmentTDS.CommentDetailsDataTable rehabAssessmentCommentDetails;






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
                if (!(Convert.ToBoolean(Session["sgLFS_CWP_REHABASSESSMENT_VIEW"]) && Convert.ToBoolean(Session["sgLFS_CWP_REHABASSESSMENT_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["work_id"] == null) || ((string)Request.QueryString["asset_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in ra_comments.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();
                hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();
                hdfLoginId.Value = Convert.ToInt32(Session["loginID"]).ToString();
                hdfAdminPermission.Value = Convert.ToBoolean(Session["sgLFS_CWP_REHABASSESSMENT_ADMIN"]).ToString();
                hdfWorkType.Value = "Rehab Assessment";
                hdfWorkId.Value = Request.QueryString["work_id"].ToString();
                hdfAssetId.Value = Request.QueryString["asset_id"].ToString();
                hdfUpdate.Value = "yes";

                // Prepare initial data
                Session.Remove("rehabAssessmentCommentDetailsDummy");

                // ... Names for UserList
                string workType = hdfWorkType.Value.Trim();
                int companyId = Int32.Parse(hdfCompanyId.Value);

                LoginGateway loginGateway = new LoginGateway();
                loginGateway.LoadByLoginId(Convert.ToInt32(hdfLoginId.Value),companyId);
                hdfCreatedBy.Value = loginGateway.GetLastName(Convert.ToInt32(hdfLoginId.Value), companyId) + " " + loginGateway.GetFirstName(Convert.ToInt32(hdfLoginId.Value), companyId);
                hdfCreationDateTime.Value = DateTime.Now.ToString();

                // If coming from 
                // ... ra_summary.aspx or ra_edit.aspx
                if (Request.QueryString["source_page"] == "ra_summary.aspx" || Request.QueryString["source_page"] == "ra_edit.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // For RA
                    rehabAssessmentTDS = (RehabAssessmentTDS)Session["rehabAssessmentTDS"];

                    int assetId = Int32.Parse(hdfAssetId.Value.Trim());                    
                    int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
                    int workId = Int32.Parse(hdfWorkId.Value.Trim());

                    if (workId != 0)
                    {
                        // ... update comments
                        RehabAssessmentCommentDetailsGateway rehabAssessmentCommentDetailsGateway = new RehabAssessmentCommentDetailsGateway(rehabAssessmentTDS);
                        rehabAssessmentCommentDetailsGateway.LoadAllByWorkIdWorkType(workId, companyId, workType);

                        RehabAssessmentCommentDetails rehabAssessmentCommentDetails = new RehabAssessmentCommentDetails(rehabAssessmentCommentDetailsGateway.Data);
                        rehabAssessmentCommentDetails.UpdateForProcess();
                    }

                    // For FLL
                    int workIdFll = GetWorkId(currentProjectId, assetId, "Full Length Lining", companyId);
                    hdfWorkIdFll.Value = workIdFll.ToString();

                    if (workIdFll != 0)
                    {                        
                        // ... update comments
                        FullLengthLiningCommentDetailsGateway fullLengthLiningCommentDetailsGateway = new FullLengthLiningCommentDetailsGateway();
                        fullLengthLiningCommentDetailsGateway.LoadAllByWorkIdWorkType(workIdFll, companyId, "Full Length Lining");

                        FullLengthLiningCommentDetails fullLengthLiningCommentDetails = new FullLengthLiningCommentDetails(fullLengthLiningCommentDetailsGateway.Data);
                        fullLengthLiningCommentDetails.UpdateForProcess();
                    }

                    // ... Store datasets
                    Session["rehabAssessmentTDS"] = rehabAssessmentTDS;
                    Session["rehabAssessmentCommentDetails"] = rehabAssessmentTDS.CommentDetails;
                }
            }
            else
            {
                // Restore datasets
                rehabAssessmentTDS = (RehabAssessmentTDS)Session["rehabAssessmentTDS"];
                rehabAssessmentCommentDetails = rehabAssessmentTDS.CommentDetails;
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
            int workIdFll = Int32.Parse(hdfWorkIdFll.Value);

            int workId = (int)e.Keys["WorkID"];
            int refId = (int)e.Keys["RefID"];
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int loginId = Convert.ToInt32(hdfLoginId.Value);
            bool adminPermission = Convert.ToBoolean(Session["sgLFS_CWP_REHABASSESSMENT_ADMIN"]);

            // Delete comment
            RehabAssessmentCommentDetails model = new RehabAssessmentCommentDetails(rehabAssessmentTDS);
            model.Delete(workId, refId, companyId, loginId, adminPermission);

            // Store dataset
            Session["rehabAssessmentTDS"] = rehabAssessmentTDS;
        }




        protected void grdComments_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("commentsDataEdit");
            if (Page.IsValid)
            {
                int workIdFll = Int32.Parse(hdfWorkIdFll.Value);
                int workIdRa = Int32.Parse(hdfWorkId.Value);

                int workId = (int)e.Keys["WorkID"];
                int refId = (int)e.Keys["RefID"];
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int loginId = Convert.ToInt32(Session["loginID"]);
                bool adminPermission = Convert.ToBoolean(Session["sgLFS_CWP_REHABASSESSMENT_ADMIN"]);
                bool toHistory = false;

                string newSubject = ((TextBox)grdComments.Rows[e.RowIndex].Cells[5].FindControl("tbxSubjectEdit")).Text.Trim();
                string newComment = ((TextBox)grdComments.Rows[e.RowIndex].Cells[6].FindControl("tbxCommentsEdit")).Text.Trim();
                string newType = ((DropDownList)grdComments.Rows[e.RowIndex].Cells[5].FindControl("ddlTypeEdit")).SelectedValue.ToString().Trim();
                string workType = ((Label)grdComments.Rows[e.RowIndex].Cells[6].FindControl("lblWorkType")).Text.Trim();
                
                RehabAssessmentCommentDetails model = new RehabAssessmentCommentDetails(rehabAssessmentTDS);

                // Update data                    
                model.Update(workId, refId, newType, newSubject, companyId, newComment, loginId, adminPermission, toHistory, workIdFll, workIdRa, workType);

                // Store dataset
                Session["rehabAssessmentTDS"] = rehabAssessmentTDS;
                Session["rehabAssessmentCommentDetails"] = rehabAssessmentTDS.CommentDetails;
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
            dialog2.DialogTitle = "Comments For Rehab Assessment";
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

                RehabAssessmentCommentDetailsGateway rehabAssessmentCommentDetailsGateway = new RehabAssessmentCommentDetailsGateway(rehabAssessmentTDS);
                string type = rehabAssessmentCommentDetailsGateway.GetType(workId, refId);

                ((DropDownList)e.Row.FindControl("ddlTypeEdit")).SelectedValue = type;
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
        //  PUBLIC METHODS
        //

        public RehabAssessmentTDS.CommentDetailsDataTable GetCommentsNew()
        {
            rehabAssessmentCommentDetails = (RehabAssessmentTDS.CommentDetailsDataTable)Session["rehabAssessmentCommentDetailsDummy"];
            if (rehabAssessmentCommentDetails == null)
            {
                rehabAssessmentCommentDetails = ((RehabAssessmentTDS.CommentDetailsDataTable)Session["rehabAssessmentCommentDetails"]);
            }

            return rehabAssessmentCommentDetails;
        }



        public void DummyCommentNew(int WorkID, int RefID)
        {
        }






        // ////////////////////////////////////////////////////////////////////////
        //  PRIVATE METHODS
        //

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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./ra_comments.js");
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
                // ... ra_summary.aspx or ra_edit.aspx
                if (Request.QueryString["source_page"] == "ra_summary.aspx" || Request.QueryString["source_page"] == "ra_edit.aspx")
                {
                    ViewState["update"] = "yes";
                    Response.Write("<script language='javascript'> {window.close();}</script>");
                }
            }
        }



        private void UpdateDatabase()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int originalWorkId = Int32.Parse(hdfWorkId.Value);

            DB.Open();
            DB.BeginTransaction();
            try
            {
                int workIdFll = Int32.Parse(hdfWorkIdFll.Value);
                int workIdRa = Int32.Parse(hdfWorkId.Value);                
                
                RehabAssessmentCommentDetails raCommentDetails = new RehabAssessmentCommentDetails(rehabAssessmentTDS);
                
                // Save Comments for RA and Fll
                raCommentDetails.Save(originalWorkId, companyId);

                // Update works
                workUpdate();

                // Update comments
                int workId = Int32.Parse(hdfWorkId.Value.Trim());
                RehabAssessmentWorkDetails rehabAssessmentWorkDetails = new RehabAssessmentWorkDetails(rehabAssessmentTDS);
                rehabAssessmentWorkDetails.UpdateCommentsForSummaryEdit(workId, companyId);

                // Store datasets
                Session["rehabAssessmentTDS"] = rehabAssessmentTDS;

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
            int projectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
            int assetId = Int32.Parse(hdfAssetId.Value.Trim());
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string workType = hdfWorkType.Value.Trim();

            // Update comments for rehab assessment
            // Get original variables 
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByWorkId(workId, companyId);

            string originalWorkType = workGateway.GetWorkTypeOriginal(workId);
            int? originalLibraryCategoriesId = workGateway.GetLibraryCategoriesIdOriginal(workId);
            string originalComment = workGateway.GetCommentsOriginal(workId);
            string originalHistory = workGateway.GetHistoryOriginal(workId);

            //Get all new rehab assessment comments
            RehabAssessmentCommentDetailsGateway rehabAssessmentCommentDetailsGateway = new RehabAssessmentCommentDetailsGateway(rehabAssessmentTDS);
            rehabAssessmentCommentDetailsGateway.LoadAllByWorkIdWorkType(workId, companyId, workType);
            RehabAssessmentCommentDetails rehabAssessmentCommentDetails = new RehabAssessmentCommentDetails(rehabAssessmentCommentDetailsGateway.Data);
            string newComment = rehabAssessmentCommentDetails.GetAllRehabAssessmentComments(workId, companyId, rehabAssessmentCommentDetailsGateway.Table.Rows.Count, "\n");

            Work work = new Work(null);
            work.UpdateDirect(workId, projectId, assetId, originalWorkType, originalLibraryCategoriesId, false, companyId, originalComment, originalHistory, workId, projectId, assetId, originalWorkType, originalLibraryCategoriesId, false, companyId, newComment, originalHistory);

            // Update comments for full length lining
            int workIdFll = Int32.Parse(hdfWorkIdFll.Value.Trim());

            if (workIdFll != 0)
            {
                WorkGateway workGatewayForFll = new WorkGateway();
                workGatewayForFll.LoadByWorkId(workIdFll, companyId);

                string originalWorkTypeForFll = workGatewayForFll.GetWorkTypeOriginal(workIdFll);
                int? originalLibraryCategoriesIdForFll = workGatewayForFll.GetLibraryCategoriesIdOriginal(workIdFll);
                string originalCommentForFll = workGatewayForFll.GetCommentsOriginal(workIdFll);
                string originalHistoryForFll = workGatewayForFll.GetHistoryOriginal(workIdFll);

                //Get all new fulllengthlining comments
                FullLengthLiningCommentDetailsGateway fullLengthLiningCommentDetailsGateway = new FullLengthLiningCommentDetailsGateway();
                fullLengthLiningCommentDetailsGateway.LoadAllByWorkIdWorkType(workIdFll, companyId, "Full Length Lining");
                FullLengthLiningCommentDetails fullLengthLiningCommentDetails = new FullLengthLiningCommentDetails(fullLengthLiningCommentDetailsGateway.Data);
                string newCommentForFll = fullLengthLiningCommentDetails.GetAllFullLengthLiningComments(workIdFll, companyId, fullLengthLiningCommentDetailsGateway.Table.Rows.Count, "\n");

                // Save comments
                Work workForFll = new Work(null);
                workForFll.UpdateDirect(workIdFll, projectId, assetId, originalWorkTypeForFll, originalLibraryCategoriesIdForFll, false, companyId, originalCommentForFll, originalHistoryForFll, workIdFll, projectId, assetId, originalWorkTypeForFll, originalLibraryCategoriesIdForFll, false, companyId, newCommentForFll, originalHistoryForFll);
            }
        }



        private int GetWorkId(int projectId, int assetId, string workType, int companyId)
        {
            int workId = 0;
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, workType, companyId);
            if (workGateway.Table.Rows.Count > 0)
            {
                // Get WorkId
                workId = workGateway.GetWorkId(assetId, workType, projectId);
            }

            return workId;
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
                        loginGateway.LoadByLoginId(Convert.ToInt32(userId),companyId);
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
                RehabAssessmentTDS.CommentDetailsDataTable dt = new RehabAssessmentTDS.CommentDetailsDataTable();
                dt.AddCommentDetailsRow(-1, -1, "", "", -1, DateTime.Now, "", -1, false, companyId, false, "", false, "");
                Session["rehabAssessmentCommentDetailsDummy"] = dt;

                grdComments.DataBind();
            }

            // Normally executes at all postbacks
            if (grdComments.Rows.Count == 1)
            {
                RehabAssessmentTDS.CommentDetailsDataTable dt = (RehabAssessmentTDS.CommentDetailsDataTable)Session["rehabAssessmentCommentDetailsDummy"];
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
                    int workIdFll = Int32.Parse(hdfWorkIdFll.Value.Trim());
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    DateTime dateTime_ = DateTime.Now;
                    bool inDatabase = false;
                    bool toHistory = false;
                    bool deleted = false;
                    string workType = hdfWorkType.Value;

                    string newSubject = ((TextBox)grdComments.FooterRow.FindControl("tbxSubjectNew")).Text.Trim();
                    string newType = ((DropDownList)grdComments.FooterRow.FindControl("ddlTypeNew")).SelectedValue.ToString().Trim();
                    string newComment = ((TextBox)grdComments.FooterRow.FindControl("tbxCommentsNew")).Text.Trim();
                    int? libraryFilesId = null; if (((Label)grdComments.FooterRow.FindControl("lblLIBRARY_FILES_IDNew")).Text != "") libraryFilesId = Int32.Parse(((Label)grdComments.FooterRow.FindControl("lblLIBRARY_FILES_IDNew")).Text.Trim());

                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string userFullName = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);

                    if (newType == "Rehab Assessment")
                    {
                        RehabAssessmentCommentDetails model = new RehabAssessmentCommentDetails(rehabAssessmentTDS);
                        model.Insert(workId, newType, newSubject, loginId, dateTime_, newComment, libraryFilesId, deleted, companyId, inDatabase, userFullName, toHistory, workType);
                    }
                    else
                    {
                        if (workIdFll != 0)
                        {
                            RehabAssessmentCommentDetails model = new RehabAssessmentCommentDetails(rehabAssessmentTDS);
                            model.Insert(workIdFll, newType, newSubject, loginId, dateTime_, newComment, libraryFilesId, deleted, companyId, inDatabase, userFullName, toHistory, workType);
                        }
                    }

                    Session.Remove("rehabAssessmentCommentDetailsDummy");
                    Session["rehabAssessmentTDS"] = rehabAssessmentTDS;
                    Session["rehabAssessmentCommentDetails"] = rehabAssessmentTDS.CommentDetails;

                    grdComments.DataBind();
                    grdComments.PageIndex = grdComments.PageCount - 1;
                }
            }
        }



    }
}
