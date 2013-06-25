using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.CWP.ManholeRehabilitation;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.ManholeRehabilitation;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.WebUI.CWP.ManholeRehabilitation
{
    /// <summary>
    /// mr_comments
    /// </summary>
    public partial class mr_comments : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ManholeRehabilitationTDS manholeRehabilitationTDS;
        protected ManholeRehabilitationTDS.CommentDetailsDataTable manholeRehabilitationCommentDetails;
        





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
                if (!(Convert.ToBoolean(Session["sgLFS_CWP_MANHOLEREHABILITATION_VIEW"]) && Convert.ToBoolean(Session["sgLFS_CWP_MANHOLEREHABILITATION_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["work_id"] == null) || ((string)Request.QueryString["asset_id"] == null) || ((string)Request.QueryString["in_project"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in mr_comments.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();
                hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();
                hdfInProject.Value = Request.QueryString["in_project"].ToString();
                hdfLoginId.Value = Convert.ToInt32(Session["loginID"]).ToString();
                hdfAdminPermission.Value = Convert.ToBoolean(Session["sgLFS_CWP_MANHOLEREHABILITATION_ADMIN"]).ToString();
                hdfWorkType.Value = "Manhole Rehabilitation";
                hdfWorkId.Value = Request.QueryString["work_id"].ToString();
                hdfAssetId.Value = Request.QueryString["asset_id"].ToString();
                hdfUpdate.Value = "yes";

                // ... Names for UserList
                string workType = hdfWorkType.Value.Trim();
                int companyId = Int32.Parse(hdfCompanyId.Value);
                LoginGateway loginGateway = new LoginGateway();
                loginGateway.LoadByLoginId(Convert.ToInt32(hdfLoginId.Value), companyId);
                hdfCreatedBy.Value = loginGateway.GetLastName(Convert.ToInt32(hdfLoginId.Value), companyId) + " " + loginGateway.GetFirstName(Convert.ToInt32(hdfLoginId.Value), companyId);

                // Prepare initial data
                Session.Remove("manholeRehabilitationCommentDetailsDummy");

                // If coming from 
                // ... mr_summary.aspx and mr_edit.aspx
                if (Request.QueryString["source_page"] == "mr_summary.aspx" || Request.QueryString["source_page"] == "mr_edit.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    manholeRehabilitationTDS = (ManholeRehabilitationTDS)Session["manholeRehabilitationTDS"];

                    int assetId = Int32.Parse(hdfAssetId.Value.Trim());
                    int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
                    int workId = Int32.Parse(hdfWorkId.Value.Trim());
                    
                    // ... If the project has works
                    if (workId != 0)
                    {                        
                        ManholeRehabilitationCommentDetailsGateway manholeRehabilitationCommentDetailsGateway = new ManholeRehabilitationCommentDetailsGateway(manholeRehabilitationTDS);
                        manholeRehabilitationCommentDetailsGateway.LoadAllByWorkIdWorkType(workId,companyId, "Manhole Rehabilitation");

                        ManholeRehabilitationCommentDetails manholeRehabilitationCommentDetailsForLoad = new ManholeRehabilitationCommentDetails(manholeRehabilitationCommentDetailsGateway.Data);
                        manholeRehabilitationCommentDetailsForLoad.UpdateForProcess();
                    }

                    // ... Store datasets
                    Session["manholeRehabilitationTDS"] = manholeRehabilitationTDS;
                    Session["manholeRehabilitationCommentDetails"] = manholeRehabilitationTDS.CommentDetails;
                }
            }
            else
            {
                // Restore datasets
                manholeRehabilitationTDS = (ManholeRehabilitationTDS)Session["manholeRehabilitationTDS"];
                manholeRehabilitationCommentDetails = manholeRehabilitationTDS.CommentDetails;

                // Store
                Session["manholeRehabilitationCommentDetails"] = manholeRehabilitationTDS.CommentDetails;
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
            bool adminPermission = Convert.ToBoolean(Session["sgLFS_CWP_MANHOLEREHABILITATION_ADMIN"]);

            // Delete comment
            ManholeRehabilitationCommentDetails model = new ManholeRehabilitationCommentDetails(manholeRehabilitationTDS);
            model.Delete(workId, refId, companyId, loginId, adminPermission);

            // Store dataset
            Session["manholeRehabilitationTDS"] = manholeRehabilitationTDS;
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
                bool adminPermission = Convert.ToBoolean(Session["sgLFS_CWP_MANHOLEREHABILITATION_ADMIN"]);
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
                ManholeRehabilitationCommentDetails model = new ManholeRehabilitationCommentDetails(manholeRehabilitationTDS);
                model.Update(workId, refId, newType, newSubject, companyId, newComment, loginId, adminPermission, toHistory);

                // Store dataset
                Session["manholeRehabilitationTDS"] = manholeRehabilitationTDS;
                Session["manholeRehabilitationCommentDetails"] = manholeRehabilitationTDS.CommentDetails;
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
            dialog2.DialogTitle = "Comments For Manhole Rehabilitation";
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

            // Control values for edit 
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int workId = Int32.Parse(((Label)e.Row.FindControl("lblWorkID")).Text.Trim());
                int refId = Int32.Parse(((Label)e.Row.FindControl("lblRefID")).Text.Trim());

                ManholeRehabilitationCommentDetailsGateway manholeRehabilitationCommentDetailsGateway = new ManholeRehabilitationCommentDetailsGateway(manholeRehabilitationTDS);
                string type = manholeRehabilitationCommentDetailsGateway.GetType(workId, refId);

                if (type != "Manhole Rehabilitation")
                {
                    ((TextBox)e.Row.FindControl("tbxTypeEdit")).Visible = false;
                    ((DropDownList)e.Row.FindControl("ddlTypeEdit")).SelectedValue = type;
                    ((DropDownList)e.Row.FindControl("ddlTypeEdit")).Visible = true;                   
                }
                else
                {
                    ((TextBox)e.Row.FindControl("tbxTypeEdit")).Text = type;
                    ((TextBox)e.Row.FindControl("tbxTypeEdit")).Visible = true;
                    ((DropDownList)e.Row.FindControl("ddlTypeEdit")).Visible = false;
                    ((DropDownList)e.Row.FindControl("ddlTypeEdit")).SelectedValue = "Manhole Rehabilitation";
                }
            }

            // Control value for footer comments
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                // For Material
                ((DropDownList)e.Row.FindControl("ddlTypeNew")).SelectedValue = "Manhole Rehabilitation";
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

        public ManholeRehabilitationTDS.CommentDetailsDataTable GetCommentsNew()
        {
            manholeRehabilitationCommentDetails = (ManholeRehabilitationTDS.CommentDetailsDataTable)Session["manholeRehabilitationCommentDetailsDummy"];
            if (manholeRehabilitationCommentDetails == null)
            {
                manholeRehabilitationCommentDetails = ((ManholeRehabilitationTDS.CommentDetailsDataTable)Session["manholeRehabilitationCommentDetails"]);
            }

            return manholeRehabilitationCommentDetails;
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./mr_comments.js");
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
                // ... mr_summary.aspx or mr_edit.aspx
                if (Request.QueryString["source_page"] == "mr_summary.aspx" || Request.QueryString["source_page"] == "mr_edit.aspx")
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
                int companyId = Int32.Parse(hdfCompanyId.Value);

                // Update comments
                ManholeRehabilitationCommentDetails manholeRehabilitationCommentDetails = new ManholeRehabilitationCommentDetails(manholeRehabilitationTDS);
                manholeRehabilitationCommentDetails.Save(companyId);

                // Update works
                workUpdate();

                // Update section
                int workId = Int32.Parse(hdfWorkId.Value.Trim());
                ManholeRehabilitationWorkDetails fullLengthLiningWorkDetails = new ManholeRehabilitationWorkDetails(manholeRehabilitationTDS);
                fullLengthLiningWorkDetails.UpdateCommentsForSummaryEdit(workId, companyId);

                // Store datasets
                Session["manholeRehabilitationTDS"] = manholeRehabilitationTDS;

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

            // Get original variables
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByWorkId(workId, companyId);

            string originalWorkType = workGateway.GetWorkTypeOriginal(workId);
            int? originalLibraryCategoriesId = workGateway.GetLibraryCategoriesIdOriginal(workId);
            string originalComment = workGateway.GetCommentsOriginal(workId);
            string originalHistory = workGateway.GetHistoryOriginal(workId);

            //Get new comment
            WorkCommentsGateway workCommentsGateway = new WorkCommentsGateway();
            workCommentsGateway.LoadByAssetIdWorkTypeProjectId(assetId, companyId, workType, projectId);
            WorkComments workComments = new WorkComments(workCommentsGateway.Data);
            string newComment = workComments.GetCommentsSummary(companyId, workCommentsGateway.Table.Rows.Count, "\n");

            Work work = new Work(null);
            work.UpdateDirect(workId, projectId, assetId, originalWorkType, originalLibraryCategoriesId, false, companyId, originalComment, originalHistory, workId, projectId, assetId, originalWorkType, originalLibraryCategoriesId, false, companyId, newComment, originalHistory);
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
                ManholeRehabilitationTDS.CommentDetailsDataTable dt = new ManholeRehabilitationTDS.CommentDetailsDataTable();
                dt.AddCommentDetailsRow(-1, -1, "", "", -1, DateTime.Now, "", -1, false, companyId, false, "", false, "");
                Session["manholeRehabilitationCommentDetailsDummy"] = dt;

                grdComments.DataBind();
            }

            // Normally executes at all postbacks
            if (grdComments.Rows.Count == 1)
            {
                ManholeRehabilitationTDS.CommentDetailsDataTable dt = (ManholeRehabilitationTDS.CommentDetailsDataTable)Session["manholeRehabilitationCommentDetailsDummy"];
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

                    ManholeRehabilitationCommentDetails model = new ManholeRehabilitationCommentDetails(manholeRehabilitationTDS);
                    model.Insert(workId, newType, newSubject, loginId, dateTime_, newComment, libraryFilesId, deleted, companyId, inDatabase, userFullName, toHistory, workType);

                    Session.Remove("manholeRehabilitationCommentDetailsDummy");
                    Session["manholeRehabilitationTDS"] = manholeRehabilitationTDS;
                    Session["manholeRehabilitationCommentDetails"] = manholeRehabilitationTDS.CommentDetails;

                    grdComments.DataBind();
                    grdComments.PageIndex = grdComments.PageCount - 1;
                }
            }
        }



    }
}