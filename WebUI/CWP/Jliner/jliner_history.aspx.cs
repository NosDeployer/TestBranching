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
using LiquiForce.LFSLive.DA.CWP.Section;
using LiquiForce.LFSLive.BL.CWP.Section;
using LiquiForce.LFSLive.DA.CWP.Jliner;
using LiquiForce.LFSLive.BL.CWP.Jliner;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.Server;


namespace LiquiForce.LFSLive.WebUI.CWP.Jliner
{
    /// <summary>
    /// jliner_history
    /// </summar
    public partial class jliner_history : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected SectionTDS sectionTDS;
        protected FlatSectionJlinerTDS flatSectionJlinerTDS;
        protected FlatSectionJlinerTDS.JuntionLiner2HistoryDataTable history;






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
                Session.Remove("historyDummy");

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

                    // ... Load history to edit
                    sectionTDS = new SectionTDS();
                    flatSectionJlinerTDS = (FlatSectionJlinerTDS)Session["flatSectionJlinerTDS"];

                    SectionGateway sectionGateway = new SectionGateway(sectionTDS);
                    sectionGateway.LoadById(new Guid(hdfId.Value), Convert.ToInt32(hdfCompanyId.Value));

                    JlinerGateway jlinerGateway = new JlinerGateway(sectionTDS);
                    jlinerGateway.LoadByIdCompanyIdRefId(new Guid(hdfId.Value), Convert.ToInt32(hdfCompanyId.Value), Convert.ToInt32(hdfRefId.Value));

                    FlatSectionJlinerJuntionLiner2HistoryGateway flatSectionJlinerJuntionLiner2HistoryGateway = new FlatSectionJlinerJuntionLiner2HistoryGateway(flatSectionJlinerTDS);
                    flatSectionJlinerJuntionLiner2HistoryGateway.LoadAllByIdRefId(new Guid(hdfId.Value), Convert.ToInt32(hdfRefId.Value), Convert.ToInt32(hdfCompanyId.Value));

                    FlatSectionJlinerJuntionLiner2History flatSectionJlinerJuntionLiner2History = new FlatSectionJlinerJuntionLiner2History(flatSectionJlinerJuntionLiner2HistoryGateway.Data);
                    flatSectionJlinerJuntionLiner2History.UpdateForProcess();

                    // ... Load comments for transfers
                    FlatSectionJlinerJuntionLiner2CommentGateway flatSectionJlinerJuntionLiner2CommentGateway = new FlatSectionJlinerJuntionLiner2CommentGateway(flatSectionJlinerTDS);
                    flatSectionJlinerJuntionLiner2CommentGateway.LoadAllByIdRefId(new Guid(hdfId.Value), Convert.ToInt32(hdfRefId.Value), Convert.ToInt32(hdfCompanyId.Value));
                    
                    // ... Store datasets
                    Session["sectionTDS"] = sectionTDS;
                    Session["flatSectionJlinerTDS"] = flatSectionJlinerTDS;
                    history = flatSectionJlinerTDS.JuntionLiner2History;
                    Session["history"] = history;
                }
            }
            else
            {
                // Restore datasets
                sectionTDS = (SectionTDS)Session["sectionTDS"];
                flatSectionJlinerTDS = (FlatSectionJlinerTDS)Session["flatSectionJlinerTDS"];
                Session["flatSectionJlinerTDS"] = flatSectionJlinerTDS;
                history = flatSectionJlinerTDS.JuntionLiner2History;
                Session["history"] = history;
            }
        }



        protected void grdHistory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // History Gridview, if the gridview is edition mode
                    if (grdHistory.EditIndex >= 0)
                    {
                        grdHistory.UpdateRow(grdHistory.EditIndex, true);
                    }

                    // Add New History
                    GrdHistoryAdd();
                    break;
            }
        }



        protected void grdHistory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Comments Gridview, if the gridview is edition mode
            if (grdHistory.EditIndex >= 0)
            {
                grdHistory.UpdateRow(grdHistory.EditIndex, true);
            }

            // Delete history
            Guid id = new Guid(((Label)grdHistory.Rows[e.RowIndex].Cells[0].FindControl("lblId")).Text);
            int refId = Int32.Parse(((Label)grdHistory.Rows[e.RowIndex].Cells[1].FindControl("lblRefID")).Text);
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int historyId = Int32.Parse(((Label)grdHistory.Rows[e.RowIndex].Cells[2].FindControl("lblHistoryID")).Text);
            int loginId = Convert.ToInt32(hdfLoginId.Value);
            bool adminPermission = Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_ADMIN"]);

            FlatSectionJlinerJuntionLiner2History model = new FlatSectionJlinerJuntionLiner2History(flatSectionJlinerTDS);
            model.Delete(id, refId, companyId, historyId, loginId, adminPermission);

            // Store dataset
            Session["flatSectionJlinerTDS"] = flatSectionJlinerTDS;
        }



        protected void grdHistory_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("commentsDataEdit");
            if (Page.IsValid)
            {
                Guid id = new Guid(((Label)grdHistory.Rows[e.RowIndex].Cells[0].FindControl("lblId")).Text);
                int refId = Int32.Parse(((Label)grdHistory.Rows[e.RowIndex].Cells[1].FindControl("lblRefID")).Text);
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int historyId = Int32.Parse(((Label)grdHistory.Rows[e.RowIndex].Cells[2].FindControl("lblHistoryID")).Text);

                int loginId = Convert.ToInt32(Session["loginID"]);
                bool adminPermission = Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_ADMIN"]);
                string newHistory = ((TextBox)grdHistory.Rows[e.RowIndex].Cells[5].FindControl("tbxHistoryEdit")).Text.Trim();
                bool toComments = ((CheckBox)grdHistory.Rows[e.RowIndex].Cells[4].FindControl("ckbxToCommentsEdit")).Checked;

                // Update data
                FlatSectionJlinerJuntionLiner2History model = new FlatSectionJlinerJuntionLiner2History(flatSectionJlinerTDS);
                model.Update(id, refId, companyId, historyId, loginId, newHistory, false, adminPermission, toComments);

                // Store dataset
                Session["flatSectionJlinerTDS"] = flatSectionJlinerTDS;
                Session["history"] = flatSectionJlinerTDS.JuntionLiner2History;
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
            dialog.DialogTitle = "History";
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void grdHistory_DataBound(object sender, EventArgs e)
        {
            AddHistoryNewEmptyFix(grdHistory);
        }



        protected void grdHistory_RowDataBound(object sender, GridViewRowEventArgs e)
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



        protected void grdHistory_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // History Gridview, if the gridview is edition mode
            if (grdHistory.EditIndex >= 0)
            {
                grdHistory.UpdateRow(grdHistory.EditIndex, true);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        //  PUBLIC METHODS
        //

        public FlatSectionJlinerTDS.JuntionLiner2HistoryDataTable GetCommentsNew()
        {
            history = (FlatSectionJlinerTDS.JuntionLiner2HistoryDataTable)Session["historyDummy"];
            if (history == null)
            {
                history = ((FlatSectionJlinerTDS.JuntionLiner2HistoryDataTable)Session["history"]);
            }

            return history;
        }



        public void DummyCommentNew(Guid ID, int RefID, int COMPANY_ID, int HistoryID)
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./jliner_history.js");
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
                if (grdHistory.EditIndex >= 0)
                {
                    grdHistory.UpdateRow(grdHistory.EditIndex, true);
                }

                // Add data if exist at grid's foot
                GrdHistoryAdd(); 
                
                TransferToComments();
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



        private void TransferToComments()
        {
            int loginId = Convert.ToInt32(hdfLoginId.Value);
            bool adminPermission = Convert.ToBoolean(Session["sgLFS_APP_ADMIN"]);

            FlatSectionJlinerJuntionLiner2Comment flatSectionJlinerJuntionLiner2Comment = new FlatSectionJlinerJuntionLiner2Comment(flatSectionJlinerTDS);
            FlatSectionJlinerJuntionLiner2History flatSectionJlinerJuntionLiner2History = new FlatSectionJlinerJuntionLiner2History(flatSectionJlinerTDS);

            flatSectionJlinerJuntionLiner2History.transferToComments(loginId, adminPermission, flatSectionJlinerJuntionLiner2Comment);
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
                FlatSectionJliner flatSectionJliner = new FlatSectionJliner(flatSectionJlinerTDS);
                flatSectionJliner.UpdateCommentsHistoryForSummaryEdit();

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



        private bool ValidateHistoryFooter()
        {
            string history = ((TextBox)grdHistory.FooterRow.FindControl("tbxHistoryNew")).Text.Trim();

            if (history != "")
            {
                return true;
            }

            return false;
        }



        protected void AddHistoryNewEmptyFix(GridView grdComments)
        {
            if (grdHistory.Rows.Count == 0)
            {
                FlatSectionJlinerTDS.JuntionLiner2HistoryDataTable dt = new FlatSectionJlinerTDS.JuntionLiner2HistoryDataTable();
                dt.AddJuntionLiner2HistoryRow(Guid.NewGuid(), -1, -1, -1, DateTime.Now, -1, "", false, false, false, "");
                Session["historyDummy"] = dt;

                grdHistory.DataBind();
            }

            // Normally executes at all postbacks
            if (grdHistory.Rows.Count == 1)
            {
                FlatSectionJlinerTDS.JuntionLiner2HistoryDataTable dt = (FlatSectionJlinerTDS.JuntionLiner2HistoryDataTable)Session["historyDummy"];
                if (dt != null)
                {
                    grdHistory.Rows[0].Visible = false;
                    grdHistory.Rows[0].Controls.Clear();
                }
            }
        }



        private void GrdHistoryAdd()
        {
            if (ValidateHistoryFooter())
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

                    string newComment = ((TextBox)grdHistory.FooterRow.FindControl("tbxHistoryNew")).Text.Trim();
                    bool toComments = ((CheckBox)grdHistory.FooterRow.FindControl("ckbxToCommentsNew")).Checked;

                    LoginGateway loginGateway = new LoginGateway();
                    loginGateway.LoadByLoginId(loginId, companyId);
                    string userFullName = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);

                    FlatSectionJlinerJuntionLiner2History model = new FlatSectionJlinerJuntionLiner2History(flatSectionJlinerTDS);
                    model.Insert(id, refId, companyId, dateTime_, loginId, newComment, deleted, toComments, inDatabase);

                    Session.Remove("historyDummy");
                    Session["flatSectionJlinerTDS"] = flatSectionJlinerTDS;
                    Session["history"] = flatSectionJlinerTDS.JuntionLiner2History;

                    grdHistory.DataBind();
                    grdHistory.PageIndex = grdHistory.PageCount - 1;
                }
            }
        }


    }
}
