using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.CWP.JunctionLining;
using LiquiForce.LFSLive.DA.CWP.JunctionLining;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.WebUI.CWP.JunctionLining
{
    /// <summary>
    /// jl_comments
    /// </summary>
    public partial class jl_comments : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected FlatSectionJlTDS flatSectionJlTDS;
        protected JlNavigatorTDS jlNavigatorTDS;
        protected FlatSectionJlTDS.FlatSectionJlCommentDetailsDataTable flatSectionJlCommentDetails;






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
                if (!(Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_VIEW"]) && Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["row_asset_id"] == null) || ((string)Request.QueryString["row_focus"] == null) || ((string)Request.QueryString["work_type"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in jl_comments.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();
                hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();
                hdfLoginId.Value = Convert.ToInt32(Session["loginID"]).ToString();
                hdfAssetId.Value = Convert.ToString(Request.QueryString["row_asset_id"]);
                hdfAdminPermission.Value = Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_ADMIN"]).ToString();
                hdfWorkType.Value = Request.QueryString["work_type"].ToString();
                hdfSection_.Value = Request.QueryString["section_"].ToString();
                hdfUpdate.Value = "yes";

                // ... Names for UserList
                string workType = hdfWorkType.Value.Trim();
                int companyId = Int32.Parse(hdfCompanyId.Value);

                LoginGateway loginGateway = new LoginGateway();
                loginGateway.LoadByLoginId(Convert.ToInt32(hdfLoginId.Value), companyId);
                hdfCreatedBy.Value = loginGateway.GetLastName(Convert.ToInt32(hdfLoginId.Value), companyId) + " " + loginGateway.GetFirstName(Convert.ToInt32(hdfLoginId.Value), companyId);
                hdfCreationDateTime.Value = DateTime.Now.ToString();

                // Prepare initial data
                Session.Remove("flatSectionJlCommentDetailsDummy");

                // If coming from 
                // ... flat_section_jl_summary.aspx or flat_section_jl_edit.aspx
                if (Request.QueryString["source_page"] == "flat_section_jl_summary.aspx" || Request.QueryString["source_page"] == "flat_section_jl_edit.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];
                    Session["rowFocus"] = Convert.ToInt32(Request.QueryString["row_focus"].ToString());

                    // ... Load comments to edit
                    flatSectionJlTDS = (FlatSectionJlTDS)Session["flatSectionJlTDS"];
                    jlNavigatorTDS = (JlNavigatorTDS)Session["jlNavigatorTDS"];

                    // Get workId
                    int assetId = Int32.Parse(hdfAssetId.Value.Trim());                    
                    int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
                    int jlWorkId = 0;
                    int raWorkId = 0;
                    int flWorkId = 0;

                    WorkGateway searchWorkGateway = new WorkGateway();
                    searchWorkGateway.LoadByProjectIdAssetIdWorkType(currentProjectId, assetId, "Junction Lining Lateral", companyId);

                    // ... If the project has jl works
                    if (searchWorkGateway.Table.Rows.Count > 0)
                    {
                        jlWorkId = searchWorkGateway.GetWorkId(assetId, "Junction Lining Lateral", currentProjectId);

                        // ... ...Tag Page
                        hdfWorkId.Value = jlWorkId.ToString().Trim();

                        // ... ...Get ra work id for comments
                        int section_ = Int32.Parse(hdfSection_.Value) ;
                        WorkGateway workGatewayRAFL = new WorkGateway();

                        // ... ...Get fl work id for comments
                        workGatewayRAFL.LoadByProjectIdAssetIdWorkType(currentProjectId, section_, "Full Length Lining", companyId);
                        if (workGatewayRAFL.Table.Rows.Count > 0)
                        {
                            flWorkId = workGatewayRAFL.GetWorkId(section_, "Full Length Lining", currentProjectId);
                        }
                                                
                        workGatewayRAFL.LoadByProjectIdAssetIdWorkType(currentProjectId, section_, "Rehab Assessment", companyId);
                        if (workGatewayRAFL.Table.Rows.Count > 0)
                        {
                            raWorkId = workGatewayRAFL.GetWorkId(section_, "Rehab Assessment", currentProjectId);
                        }                        

                        // ... ...Get comments
                        FlatSectionJlCommentDetailsGateway flatSectionJlCommentDetailsGateway = new FlatSectionJlCommentDetailsGateway(flatSectionJlTDS);
                        flatSectionJlCommentDetailsGateway.LoadAllByJlWorkIdRaWorkIdFlWorkId(jlWorkId, raWorkId, flWorkId, companyId);

                        FlatSectionJlCommentDetails flatSectionJlCommentDetails = new FlatSectionJlCommentDetails(flatSectionJlCommentDetailsGateway.Data);
                        flatSectionJlCommentDetails.UpdateForProcess();

                        // ... ...Get history
                        FlatSectionJlHistoryDetailsGateway flatSectionJlHistoryDetailsGateway = new FlatSectionJlHistoryDetailsGateway(flatSectionJlTDS);
                        flatSectionJlHistoryDetailsGateway.LoadAllByJlWorkIdRaWorkIdFlWorkId(jlWorkId, raWorkId, flWorkId, companyId);
                    }

                    // ... Store datasets
                    Session["flatSectionJlTDS"] = flatSectionJlTDS;
                    Session["jlNavigatorTDS"] = jlNavigatorTDS;
                    Session["flatSectionJlCommentDetails"] = flatSectionJlTDS.FlatSectionJlCommentDetails;
                }
            }
            else
            {
                // Restore datasets
                flatSectionJlTDS = (FlatSectionJlTDS)Session["flatSectionJlTDS"];
                jlNavigatorTDS = (JlNavigatorTDS)Session["jlNavigatorTDS"];
                flatSectionJlCommentDetails = flatSectionJlTDS.FlatSectionJlCommentDetails;

                // Store
                Session["flatSectionJlCommentDetails"] = flatSectionJlTDS.FlatSectionJlCommentDetails;
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
            bool adminPermission = Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_ADMIN"]);

            // Delete comment
            FlatSectionJlCommentDetails model = new FlatSectionJlCommentDetails(flatSectionJlTDS);
            model.Delete(workId, refId, companyId, loginId, adminPermission);

            // Store dataset
            Session["flatSectionJlTDS"] = flatSectionJlTDS;
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
                bool adminPermission = Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_ADMIN"]);
                string type = ((Label)grdComments.Rows[e.RowIndex].Cells[4].FindControl("lblType")).Text.Trim();
                string newSubject = ((TextBox)grdComments.Rows[e.RowIndex].Cells[5].FindControl("tbxSubjectEdit")).Text.Trim();
                string newComment = ((TextBox)grdComments.Rows[e.RowIndex].Cells[5].FindControl("tbxCommentsEdit")).Text.Trim();
                bool toHistory = ((CheckBox)grdComments.Rows[e.RowIndex].Cells[5].FindControl("ckbxToHistoryEdit")).Checked;

                // Update data
                FlatSectionJlCommentDetails model = new FlatSectionJlCommentDetails(flatSectionJlTDS);
                model.Update(workId, refId, type, newSubject, companyId, newComment, loginId, adminPermission, toHistory);

                // Store dataset
                Session["flatSectionJlTDS"] = flatSectionJlTDS;
                Session["flatSectionJlCommentDetails"] = flatSectionJlTDS.FlatSectionJlCommentDetails;
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
            dialog2.DialogTitle = "Comments For Junction Lining";
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

        public FlatSectionJlTDS.FlatSectionJlCommentDetailsDataTable GetCommentsNew()
        {
            flatSectionJlCommentDetails = (FlatSectionJlTDS.FlatSectionJlCommentDetailsDataTable)Session["flatSectionJlCommentDetailsDummy"];
            if (flatSectionJlCommentDetails == null)
            {
                flatSectionJlCommentDetails = ((FlatSectionJlTDS.FlatSectionJlCommentDetailsDataTable)Session["flatSectionJlCommentDetails"]);
            }

            return flatSectionJlCommentDetails;
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

            contentVariables += "var hdfWorkIdId = '" + hdfWorkId.ClientID + "';";
            contentVariables += "var hdfLoginIdId = '" + hdfLoginId.ClientID + "';";
            contentVariables += "var hdfCreatedById = '" + hdfCreatedBy.ClientID + "';";
            contentVariables += "var hdfAssetIdId = '" + hdfAssetId.ClientID + "';";
            contentVariables += "var hdfCompanyIdId = '" + hdfCompanyId.ClientID + "';";
            contentVariables += "var hdfUpdateId = '" + hdfUpdate.ClientID + "';";
            contentVariables += "var hdfCreationDateTimeId = '" + hdfCreationDateTime.ClientID + "';";
            contentVariables += "var hdfAdminPermissionId = '" + hdfAdminPermission.ClientID + "';";
            contentVariables += "var hdfCurrentClientIdId = '" + hdfCurrentClientId.ClientID + "';";
            contentVariables += "var hdfCurrentProjectIdId = '" + hdfCurrentProjectId.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./jl_comments.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&columns_to_display2=" + Request.QueryString["columns_to_display2"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_ddlCondition2=" + Request.QueryString["search_ddlCondition2"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_tbxCondition2=" + Request.QueryString["search_tbxCondition2"] + "&search_ddlOperator1=" + Request.QueryString["search_ddlOperator1"] + "&search_ddlOperator2=" + Request.QueryString["search_ddlOperator2"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_issues=" + Request.QueryString["search_issues"] + "&search_sub_area=" + Request.QueryString["search_sub_area"] + "&btn_origin=" + Request.QueryString["btn_origin"];
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
                // Comments Gridview, if the gridview is edition mode
                if (grdComments.EditIndex >= 0)
                {
                    grdComments.UpdateRow(grdComments.EditIndex, true);
                }

                // Add data if exist at grid's foot
                GrdCommentsAdd();

                TransferToHistory();
                UpdateDatabase();

                // If coming from 
                // ... flat_section_jl_summary.aspx or flat_section_jl_edit.aspx
                if (Request.QueryString["source_page"] == "flat_section_jl_summary.aspx" || Request.QueryString["source_page"] == "flat_section_jl_edit.aspx")
                {
                    ViewState["update"] = "yes";
                    Response.Write("<script language='javascript'> {window.close();}</script>");
                }
            }
        }



        private void TransferToHistory()
        {
            int loginId = Convert.ToInt32(hdfLoginId.Value);
            bool adminPermission = Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_ADMIN"]);

            FlatSectionJlCommentDetails flatSectionJlCommentDetails = new FlatSectionJlCommentDetails(flatSectionJlTDS);
            FlatSectionJlHistoryDetails flatSectionJlHistoryDetails = new FlatSectionJlHistoryDetails(flatSectionJlTDS);

            flatSectionJlCommentDetails.TransferToHistory(loginId, adminPermission, flatSectionJlHistoryDetails);
        }



        private void UpdateDatabase()
        {
            DB.Open();
            DB.BeginTransaction();
            try
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);

                // Update Comments and History
                FlatSectionJlCommentDetails flatSectionJlCommentDetails = new FlatSectionJlCommentDetails(flatSectionJlTDS);
                flatSectionJlCommentDetails.Save(companyId);

                FlatSectionJlHistoryDetails flatSectionJlHistoryDetails = new FlatSectionJlHistoryDetails(flatSectionJlTDS);
                flatSectionJlHistoryDetails.Save(companyId);                

                // Update FlatSectionJl for new Comments
                int workId = Int32.Parse(hdfWorkId.Value.Trim());
                string workType = "Junction Lining Lateral";

                FlatSectionJl flatSectionJl = new FlatSectionJl(flatSectionJlTDS);
                flatSectionJl.UpdateCommentsHistoryForSummaryEdit(workId, workType, companyId);

                JlNavigator jlNavigator = new JlNavigator(jlNavigatorTDS);
                jlNavigator.UpdateComments(workId, workType, companyId);                               

                Session["flatSectionJlTDS"] = flatSectionJlTDS;
                Session["jlNavigatorTDS"] = jlNavigatorTDS;

                DB.CommitTransaction();
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
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
                FlatSectionJlTDS.FlatSectionJlCommentDetailsDataTable dt = new FlatSectionJlTDS.FlatSectionJlCommentDetailsDataTable();
                dt.AddFlatSectionJlCommentDetailsRow(-1, -1, "", "", -1, DateTime.Now, "", -1, false, companyId, false, "", false, "");
                Session["flatSectionJlCommentDetailsDummy"] = dt;

                grdComments.DataBind();
            }

            // Normally executes at all postbacks
            if (grdComments.Rows.Count == 1)
            {
                FlatSectionJlTDS.FlatSectionJlCommentDetailsDataTable dt = (FlatSectionJlTDS.FlatSectionJlCommentDetailsDataTable)Session["flatSectionJlCommentDetailsDummy"];
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
                    string newType = "Junction Lining Lateral";
                    string newComment = ((TextBox)grdComments.FooterRow.FindControl("tbxCommentsNew")).Text.Trim();
                    int? libraryFilesId = null; if (((Label)grdComments.FooterRow.FindControl("lblLIBRARY_FILES_IDNew")).Text != "") libraryFilesId = Int32.Parse(((Label)grdComments.FooterRow.FindControl("lblLIBRARY_FILES_IDNew")).Text.Trim());
                    bool toHistory = ((CheckBox)grdComments.FooterRow.FindControl("ckbxToHistoryNew")).Checked;
                                        
                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string userFullName = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);

                    FlatSectionJlCommentDetails model = new FlatSectionJlCommentDetails(flatSectionJlTDS);
                    model.Insert(workId, newType, newSubject, loginId, dateTime_, newComment, libraryFilesId, deleted, companyId, inDatabase, userFullName, toHistory, workType);

                    Session.Remove("flatSectionJlCommentDetailsDummy");
                    Session["flatSectionJlTDS"] = flatSectionJlTDS;
                    Session["flatSectionJlCommentDetails"] = flatSectionJlTDS.FlatSectionJlCommentDetails;

                    grdComments.DataBind();
                    grdComments.PageIndex = grdComments.PageCount - 1;
                }
            }
        }

        

    }
}