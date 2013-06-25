using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// project_notes
    /// </summar
    public partial class project_notes : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ProjectNavigatorTDS projectNavigatorTDS;
        protected ProjectNavigatorTDS.ProjectNotesDataTable projectNotes;






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
                if (!(Convert.ToBoolean(Session["sgLFS_PROJECTS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_PROJECTS_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in project_notes.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();
                hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();
                hdfLoginId.Value = Convert.ToInt32(Session["loginID"]).ToString();                
                hdfUpdate.Value = "yes";

                // Prepare initial data
                Session.Remove("projectNotesDummy");

                // ... Names for UserList               
                int companyId = Int32.Parse(hdfCompanyId.Value);

                LoginGateway loginGateway = new LoginGateway();
                loginGateway.LoadByLoginId(Convert.ToInt32(hdfLoginId.Value),companyId);
                hdfCreatedBy.Value = loginGateway.GetLastName(Convert.ToInt32(hdfLoginId.Value), companyId) + " " + loginGateway.GetFirstName(Convert.ToInt32(hdfLoginId.Value), companyId);
                hdfCreationDateTime.Value = DateTime.Now.ToString();

                // If coming from 
                // ... project_summary.aspx or project_edit.aspx
                if (Request.QueryString["source_page"] == "project_summary.aspx" || Request.QueryString["source_page"] == "project_edit.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];
                    projectNavigatorTDS = (ProjectNavigatorTDS)Session["projectNavigatorTDS"];

                    projectNotes = (ProjectNavigatorTDS.ProjectNotesDataTable)Session["projectNotes"];
                    int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
                    
                    // Get Notes
                    ProjectNavigatorProjectNotes projectNavigatorProjectNotes = new ProjectNavigatorProjectNotes(projectNavigatorTDS);
                    projectNavigatorProjectNotes.LoadAllByProjectId(currentProjectId);                                        

                    // ... Store datasets
                    Session["projectNavigatorTDS"] = projectNavigatorTDS;
                    Session["projectNotes"] = projectNavigatorTDS.ProjectNotes;
                }
            }
            else
            {
                // Restore datasets
                projectNavigatorTDS = (ProjectNavigatorTDS)Session["projectNavigatorTDS"];
                projectNotes = (ProjectNavigatorTDS.ProjectNotesDataTable)Session["projectNotes"];                
            }
        }
                

        protected void btnSave_Click(object sender, System.EventArgs e)
        {
            Save();
        }       



        protected void grdNotes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Notes Gridview, if the gridview is edition mode
                    if (grdNotes.EditIndex >= 0)
                    {
                        grdNotes.UpdateRow(grdNotes.EditIndex, true);
                    }

                    // Add New Note
                    GrdNotesAdd();
                    break;
            }
        }



        protected void grdNotes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Notes Gridview, if the gridview is edition mode
            if (grdNotes.EditIndex >= 0)
            {
                grdNotes.UpdateRow(grdNotes.EditIndex, true);
            }

            // Delete notes
            int projectId = (int)e.Keys["ProjectID"];
            int refId = (int)e.Keys["RefID"];

            ProjectNavigatorProjectNotes model = new ProjectNavigatorProjectNotes(projectNavigatorTDS);
            model.Delete(projectId, refId);           

            // Store dataset
            Session["projectNavigatorTDS"] = projectNavigatorTDS;
        }




        protected void grdNotes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("notesDataEdit");
            if (Page.IsValid)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int projectId = Int32.Parse(((Label)grdNotes.Rows[e.RowIndex].Cells[0].FindControl("lblProjectIDEdit")).Text.Trim());
                int refId = Int32.Parse(((Label)grdNotes.Rows[e.RowIndex].Cells[1].FindControl("lblRefIDEdit")).Text.Trim());
                string subject = ((TextBox)grdNotes.Rows[e.RowIndex].Cells[4].FindControl("tbxNoteSubjectEdit")).Text.Trim();
                string note = ((TextBox)grdNotes.Rows[e.RowIndex].Cells[5].FindControl("tbxNoteNoteEdit")).Text.Trim();
                int? libraryFilesId = null;                

                // Update data
                ProjectNavigatorProjectNotes model = new ProjectNavigatorProjectNotes(projectNavigatorTDS);
                model.Update(projectId, refId, subject, note, libraryFilesId);

                // Store dataset
                Session["projectNavigatorTDS"] = projectNavigatorTDS;
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
            dialog2.DialogTitle = "Project ";
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void grdNotes_DataBound(object sender, EventArgs e)
        {
            AddNotesNewEmptyFix(grdNotes);
        }



        protected void grdNotes_RowEditing(object sender, GridViewEditEventArgs e)
        {
             //Notes Gridview, if the gridview is edition mode
            if (grdNotes.EditIndex >= 0)
            {
                grdNotes.UpdateRow(grdNotes.EditIndex, true);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        //  PUBLIC METHODS
        //

        public ProjectNavigatorTDS.ProjectNotesDataTable GetNotesNew()
        {
            projectNotes = (ProjectNavigatorTDS.ProjectNotesDataTable)Session["projectNotesDummy"];
            if (projectNotes == null)
            {
                projectNotes = ((ProjectNavigatorTDS)Session["projectNavigatorTDS"]).ProjectNotes;
            }

            return projectNotes;
        }



        public void DummyNotesNew(int ProjectID, int RefID)
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./project_notes.js");
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
            Page.Validate("notesDataEdit");
            if (Page.IsValid)
            {
                // Notes grid, if the gridview is edition mode
                if (grdNotes.EditIndex >= 0)
                {
                    grdNotes.UpdateRow(grdNotes.EditIndex, true);
                }

                // Add data if exist at grid's foot
                GrdNotesAdd();

                // Update data
                UpdateDatabase();

                // If coming from 
                // ... project_summary.aspx or project_edit.aspx
                if (Request.QueryString["source_page"] == "project_summary.aspx" || Request.QueryString["source_page"] == "project_edit.aspx")
                {
                    ViewState["update"] = "yes";
                    Response.Write("<script language='javascript'> {window.close();}</script>");
                }
            }
        }



        private void UpdateDatabase()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int originalProjectId = Int32.Parse( hdfCurrentProjectId.Value);

            DB.Open();
            DB.BeginTransaction();
            try
            {
                ProjectNavigatorProjectNotes projectNavigatorProjectNotes = new ProjectNavigatorProjectNotes(projectNavigatorTDS);
                projectNavigatorProjectNotes.Save(companyId);
                        
                // Store datasets
                Session["projectNavigatorTDS"] = projectNavigatorTDS;

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



        private bool ValidateNotesFooter()
        {
            string subject = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteSubjectNew")).Text.Trim();
            string note = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteNoteNew")).Text.Trim();            

            if ((subject != "") || (note != ""))
            {
                return true;
            }

            return false;
        }



        protected void AddNotesNewEmptyFix(GridView grdNotes)
        {
            if (grdNotes.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectNavigatorTDS.ProjectNotesDataTable dt = new ProjectNavigatorTDS.ProjectNotesDataTable();
                dt.AddProjectNotesRow(-1, -1, "", DateTime.Now, -1, "", false, -1, companyId, "", "", false);
                Session["projectNotesDummy"] = dt;

                grdNotes.DataBind();
            }

            // Normally executes at all postbacks
            if (grdNotes.Rows.Count == 1)
            {
                ProjectNavigatorTDS.ProjectNotesDataTable dt = (ProjectNavigatorTDS.ProjectNotesDataTable)Session["projectNotesDummy"];
                if (dt != null)
                {
                    grdNotes.Rows[0].Visible = false;
                    grdNotes.Rows[0].Controls.Clear();
                }
            }
        }



        private void GrdNotesAdd()
        {
            if (ValidateNotesFooter())
            {
                Page.Validate("notesDataAdd");
                if (Page.IsValid)
                {
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    int projectId = Int32.Parse(hdfCurrentProjectId.Value);
                    string newSubject = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteSubjectNew")).Text.Trim();
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    DateTime dateTime = DateTime.Now;
                    string newNote = ((TextBox)grdNotes.FooterRow.FindControl("tbxNoteNoteNew")).Text.Trim();
                    bool deleted = false;
                    bool inNoteDatabase = false;

                    int? libraryFilesId = null;                    

                    ProjectNavigatorProjectNotes model = new ProjectNavigatorProjectNotes(projectNavigatorTDS);
                    model.Insert(projectId, newSubject, dateTime, loginId, newNote, deleted, libraryFilesId, companyId, inNoteDatabase);

                    Session.Remove("projectNotesDummy");
                    Session["projectNavigatorTDS"] = projectNavigatorTDS;

                    grdNotes.DataBind();
                    grdNotes.PageIndex = grdNotes.PageCount - 1;
                }
            }
        }



        protected string GetNoteCreatedBy(object userId)
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



    }
}
