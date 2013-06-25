using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.BL.CWP.Section;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.BL.CWP.Jliner;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.WebUI.CWP.Jliner
{
    /// <summary>
    /// jliner_comments
    /// </summar
    public partial class jliner_comments : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected SectionTDS sectionTDS;
        protected FlatSectionJlinerTDS flatSectionJlinerTDS;
        protected FlatSectionJlinerTDS.JuntionLiner2CommentDataTable comments;






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
                if (!(Convert.ToBoolean(Session["sgLFS_APP_VIEW"]) && Convert.ToBoolean(Session["sgLFS_APP_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in flat_section_jliner_edit.aspx");
                }

                // Tag page
                hdfCurrentClient.Value = (string)Request.QueryString["client"];
                hdfLoginId.Value = Convert.ToInt32(Session["loginID"]).ToString();
                hdfId.Value = Convert.ToString(Request.QueryString["rowId"]);
                hdfRefId.Value = Convert.ToString(Request.QueryString["rowRefId"]);
                hdfCompanyId.Value = Convert.ToString(Request.QueryString["rowCompanyId"]);
                hdfAdminPermission.Value = Convert.ToBoolean(Session["sgLFS_APP_ADMIN"]).ToString();
                hdfUpdate.Value = "yes";

                // Prepare initial data
                Session.Remove("commentsDummy");

                // ... Names for UserList
                int companyId = Int32.Parse(hdfCompanyId.Value);

                LoginGateway loginGateway = new LoginGateway();
                loginGateway.LoadByLoginId(Convert.ToInt32(hdfLoginId.Value), companyId);
                hdfCreatedBy.Value = loginGateway.GetLastName(Convert.ToInt32(hdfLoginId.Value), companyId) + " " + loginGateway.GetFirstName(Convert.ToInt32(hdfLoginId.Value), companyId);
                hdfCreationDateTime.Value = DateTime.Now.ToString();

                // If comming from 
                // ... flat_section_jliner_summary.aspx
                if (Request.QueryString["source_page"] == "flat_section_jliner_summary.aspx" || Request.QueryString["source_page"] == "flat_section_jliner_edit.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];
                    Session["rowFocus"] = Convert.ToInt32(Request.QueryString["rowFocus"].ToString());

                    // ... Load comments to edit
                    sectionTDS = new SectionTDS();
                    flatSectionJlinerTDS = (FlatSectionJlinerTDS)Session["flatSectionJlinerTDS"];

                    SectionGateway sectionGateway = new SectionGateway(sectionTDS);
                    sectionGateway.LoadById(new Guid(hdfId.Value), Convert.ToInt32(hdfCompanyId.Value));

                    JlinerGateway jlinerGateway = new JlinerGateway(sectionTDS);
                    jlinerGateway.LoadByIdCompanyIdRefId(new Guid(hdfId.Value), Convert.ToInt32(hdfCompanyId.Value), Convert.ToInt32(hdfRefId.Value));

                    FlatSectionJlinerJuntionLiner2CommentGateway flatSectionJlinerJuntionLiner2CommentGateway = new FlatSectionJlinerJuntionLiner2CommentGateway(flatSectionJlinerTDS);
                    flatSectionJlinerJuntionLiner2CommentGateway.LoadAllByIdRefId(new Guid(hdfId.Value), Convert.ToInt32(hdfRefId.Value), Convert.ToInt32(hdfCompanyId.Value));

                    FlatSectionJlinerJuntionLiner2Comment flatSectionJlinerJuntionLiner2Comment = new FlatSectionJlinerJuntionLiner2Comment(flatSectionJlinerJuntionLiner2CommentGateway.Data);
                    flatSectionJlinerJuntionLiner2Comment.UpdateForProcess();

                    // ... Load history for transfers
                    FlatSectionJlinerJuntionLiner2HistoryGateway flatSectionJlinerJuntionLiner2HistoryGateway = new FlatSectionJlinerJuntionLiner2HistoryGateway(flatSectionJlinerTDS);
                    flatSectionJlinerJuntionLiner2HistoryGateway.LoadAllByIdRefId(new Guid(hdfId.Value), Convert.ToInt32(hdfRefId.Value), Convert.ToInt32(hdfCompanyId.Value));
                                      
                    // ... Store datasets
                    Session["sectionTDS"] = sectionTDS;                                       
                    Session["flatSectionJlinerTDS"] = flatSectionJlinerTDS;
                    comments = flatSectionJlinerTDS.JuntionLiner2Comment;
                    Session["comments"] = comments;
                }
            }
            else
            {
                // Restore datasets
                sectionTDS = (SectionTDS)Session["sectionTDS"];
                flatSectionJlinerTDS = (FlatSectionJlinerTDS)Session["flatSectionJlinerTDS"];
                Session["flatSectionJlinerTDS"] = flatSectionJlinerTDS;
                comments = flatSectionJlinerTDS.JuntionLiner2Comment;
                Session["comments"] = comments;
            }
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
            Guid id = new Guid(((Label)grdComments.Rows[e.RowIndex].Cells[0].FindControl("lblId")).Text);
            int refId = Int32.Parse(((Label)grdComments.Rows[e.RowIndex].Cells[1].FindControl("lblRefID")).Text);
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int commentId = Int32.Parse(((Label)grdComments.Rows[e.RowIndex].Cells[2].FindControl("lblCommentID")).Text);
            int loginId = Convert.ToInt32(hdfLoginId.Value);
            bool adminPermission = Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_ADMIN"]);

            // Delete comment
            FlatSectionJlinerJuntionLiner2Comment model = new FlatSectionJlinerJuntionLiner2Comment(flatSectionJlinerTDS);
            model.Delete(id, refId, companyId, commentId, loginId, adminPermission);

            // Store dataset
            Session["flatSectionJlinerTDS"] = flatSectionJlinerTDS;
        }



        protected void grdComments_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("commentsDataEdit");
            if (Page.IsValid)
            {
                Guid id = new Guid(((Label)grdComments.Rows[e.RowIndex].Cells[0].FindControl("lblId")).Text);
                int refId = Int32.Parse(((Label)grdComments.Rows[e.RowIndex].Cells[1].FindControl("lblRefID")).Text);
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int commentId = Int32.Parse(((Label)grdComments.Rows[e.RowIndex].Cells[2].FindControl("lblCommentID")).Text);

                int loginId = Convert.ToInt32(Session["loginID"]);
                bool adminPermission = Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_ADMIN"]);
                string newComment = ((TextBox)grdComments.Rows[e.RowIndex].Cells[5].FindControl("tbxCommentsEdit")).Text.Trim();
                bool toHistory = ((CheckBox)grdComments.Rows[e.RowIndex].Cells[4].FindControl("ckbxToHistoryEdit")).Checked;

                // Update data
                FlatSectionJlinerJuntionLiner2Comment model = new FlatSectionJlinerJuntionLiner2Comment(flatSectionJlinerTDS);
                model.Update(id, refId, companyId, commentId, loginId, newComment, false, adminPermission, toHistory);

                // Store dataset
                Session["flatSectionJlinerTDS"] = flatSectionJlinerTDS;
                Session["comments"] = flatSectionJlinerTDS.JuntionLiner2Comment;                
            }
            else
            {
                e.Cancel = true;
            }
        }


        
  
        protected void btnSave_Click(object sender, System.EventArgs e)
        {
            Save();
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Dialog title
            mDialog2 dialog = (mDialog2)this.Master;
            dialog.DialogTitle = "Comments";
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
                if (((Label)e.Row.FindControl("lblLoginId")).Text != "")
                {
                    int loginId = Int32.Parse(hdfLoginId.Value);
                    bool adminPermission = bool.Parse(hdfAdminPermission.Value);
                    int rowUserId = Int32.Parse(((Label)e.Row.FindControl("lblLoginId")).Text);

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

        public FlatSectionJlinerTDS.JuntionLiner2CommentDataTable GetCommentsNew()
        {
            comments = (FlatSectionJlinerTDS.JuntionLiner2CommentDataTable)Session["commentsDummy"];
            if (comments == null)
            {
                comments = ((FlatSectionJlinerTDS.JuntionLiner2CommentDataTable)Session["comments"]);
            }

            return comments;
        }



        public void DummyCommentNew(Guid ID, int RefID, int COMPANY_ID, int CommentID)
        {
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // METHODS
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./jliner_comments.js");
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
                // ... flat_section_jliner_summary.aspx
                if (Request.QueryString["source_page"] == "flat_section_jliner_summary.aspx" || Request.QueryString["source_page"] == "flat_section_jliner_edit.aspx")
                {
                    ViewState["update"] = "yes";
                    Response.Write("<script language='javascript'> {window.close();}</script>");
                }
            }
        }



        private void TransferToHistory()
        {
            int loginId = Convert.ToInt32(hdfLoginId.Value);
            bool adminPermission = Convert.ToBoolean(Session["sgLFS_APP_ADMIN"]);

            FlatSectionJlinerJuntionLiner2Comment flatSectionJlinerJuntionLiner2Comment = new FlatSectionJlinerJuntionLiner2Comment(flatSectionJlinerTDS);
            FlatSectionJlinerJuntionLiner2History flatSectionJlinerJuntionLiner2History = new FlatSectionJlinerJuntionLiner2History(flatSectionJlinerTDS);

            flatSectionJlinerJuntionLiner2Comment.transferToHistory(loginId, adminPermission, flatSectionJlinerJuntionLiner2History);
            Session["flatSectionJlinerTDS"] = flatSectionJlinerTDS;
        }



        private void UpdateDatabase()
        {
            DB.Open();
            DB.BeginTransaction();
            try
            {
                Guid id = new Guid(hdfId.Value);
                int refId = Int32.Parse(hdfRefId.Value);
                int companyId = Int32.Parse(hdfCompanyId.Value);

                // Save Comments
                FlatSectionJlinerJuntionLiner2Comment flatSectionJlinerJuntionLiner2Comment = new FlatSectionJlinerJuntionLiner2Comment(flatSectionJlinerTDS);
                flatSectionJlinerJuntionLiner2Comment.Save(id, companyId);

                // Save History
                FlatSectionJlinerJuntionLiner2History flatSectionJlinerJuntionLiner2History = new FlatSectionJlinerJuntionLiner2History(flatSectionJlinerTDS);
                flatSectionJlinerJuntionLiner2History.Save(id, companyId);

                // Save jliner
                FlatSectionJliner flatSectionJlinerUpdateCommentsHistory = new FlatSectionJliner();
                flatSectionJlinerUpdateCommentsHistory.LoadByIdRefId(id, refId, companyId);
                flatSectionJlinerUpdateCommentsHistory.UpdateComments(id.ToString());
                flatSectionJlinerUpdateCommentsHistory.UpdateHistory(id.ToString());
                
                Session["flatSectionJlinerTDS"] = flatSectionJlinerTDS;
                flatSectionJlinerUpdateCommentsHistory.Save(companyId);

                // Update FlatSectionJliner for new Comments
                FlatSectionJliner flatSectionJlinerForCommentsHistory = new FlatSectionJliner(flatSectionJlinerTDS);
                flatSectionJlinerForCommentsHistory.UpdateCommentsHistoryForSummaryEdit();

                Session["flatSectionJlinerTDS"] = flatSectionJlinerTDS;

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
            string comment = ((TextBox)grdComments.FooterRow.FindControl("tbxCommentsNew")).Text.Trim();

            if (comment != "")
            {
                return true;
            }

            return false;
        }



        protected void AddCommentsNewEmptyFix(GridView grdComments)
        {
            if (grdComments.Rows.Count == 0)
            {
                FlatSectionJlinerTDS.JuntionLiner2CommentDataTable dt = new FlatSectionJlinerTDS.JuntionLiner2CommentDataTable();
                dt.AddJuntionLiner2CommentRow(Guid.NewGuid(), -1, -1, -1, DateTime.Now, -1, "", false, false, false, "" );
                Session["commentsDummy"] = dt;

                grdComments.DataBind();
            }

            // Normally executes at all postbacks
            if (grdComments.Rows.Count == 1)
            {
                FlatSectionJlinerTDS.JuntionLiner2CommentDataTable dt = (FlatSectionJlinerTDS.JuntionLiner2CommentDataTable)Session["commentsDummy"];
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
                    Guid id = new Guid(hdfId.Value);
                    int refId = Convert.ToInt32(hdfRefId.Value);

                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    DateTime dateTime_ = DateTime.Now;
                    bool inDatabase = false;
                    bool deleted = false;

                    string newComment = ((TextBox)grdComments.FooterRow.FindControl("tbxCommentsNew")).Text.Trim();
                    bool toHistory = ((CheckBox)grdComments.FooterRow.FindControl("ckbxToHistoryNew")).Checked;
                                        
                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string userFullName = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);

                    FlatSectionJlinerJuntionLiner2Comment model = new FlatSectionJlinerJuntionLiner2Comment(flatSectionJlinerTDS);
                    model.Insert(id, refId, companyId, dateTime_, loginId, newComment, deleted, toHistory, inDatabase);

                    Session.Remove("commentsDummy");
                    Session["flatSectionJlinerTDS"] = flatSectionJlinerTDS;
                    Session["comments"] = flatSectionJlinerTDS.JuntionLiner2Comment;

                    grdComments.DataBind();
                    grdComments.PageIndex = grdComments.PageCount - 1;
                }
            }
        }




    }
}
