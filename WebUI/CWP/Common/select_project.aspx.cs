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
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.BL.CWP.Common;
using LiquiForce.LFSLive.BL.Resources.Companies;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.WebUI.CWP.Common
{
    /// <summary>
    /// select_project
    /// </summary>
    public partial class select_project : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //
        protected SelectProjectTDS selectProjectTDS;
        protected SelectProjectTDS.LastUsedProjectsDataTable lastUsedProjects;






        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["work_type"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in select_project.aspx");
                }

                // Security check
                if ((string)Request.QueryString["work_type"] == "Rehab Assessment")
                {
                    if (!(Convert.ToBoolean(Session["sgLFS_CWP_REHABASSESSMENT_VIEW"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }

                if ((string)Request.QueryString["work_type"] == "Full Length Lining")
                {
                    if (!(Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_VIEW"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }

                if ((string)Request.QueryString["work_type"] == "Junction Lining")
                {
                    if (!(Convert.ToBoolean(Session["sgLFS_CWP_JUNCTIONLINING_VIEW"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }

                if ((string)Request.QueryString["work_type"] == "Point Repairs")
                {
                    if (!(Convert.ToBoolean(Session["sgLFS_CWP_POINTREPAIRS_VIEW"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }

                if ((string)Request.QueryString["work_type"] == "Manhole Rehabilitation")
                {
                    if (!(Convert.ToBoolean(Session["sgLFS_CWP_MANHOLEREHABILITATION_VIEW"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }

                // Prepare initial data
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfLoginId.Value = Convert.ToInt32(Session["loginID"]).ToString();
                hdfWorkType.Value = Request.QueryString["work_type"];
                Session.Remove("lastUsedProjectsDummy");

                if (Request.QueryString["work_type"] == "Manhole Rehabilitation")
                {
                    //lblInProjectManhole.Visible = true;
                    //cbxInProject.Visible = true;
                    //btnSelectNoProject.Visible = false;
                    upnlForManholesInProject.Visible = true;
                }
                else
                {
                    //lblInProjectManhole.Visible = false;
                    //cbxInProject.Visible = false;
                    //btnSelectNoProject.Visible = false;
                    upnlForManholesInProject.Visible = true;
                }

                // ...  for the client
                int companyId = Int32.Parse(hdfCompanyId.Value);
                CompaniesList companiesList = new CompaniesList(new DataSet());
                companiesList.LoadAndAddItem(-1, "(Select a client)", companyId);
                ddlClient.DataSource = companiesList.Table;
                ddlClient.DataValueField = "COMPANIES_ID";
                ddlClient.DataTextField = "Name";
                ddlClient.DataBind();
                ddlClient.SelectedIndex = 0;

                // ... for project
                ProjectList projectList = new ProjectList();
                projectList.LoadProjectsAndAddItem(-1, "(Select a project)", -1);
                ddlProject.DataSource = projectList.Table;
                ddlProject.DataValueField = "ProjectID";
                ddlProject.DataTextField = "Name";
                ddlProject.DataBind();
                ddlProject.SelectedIndex = 0;

                // If comming from 
                // ...out
                // ... load batch verification
                if (hdfWorkType.Value == "Manhole Rehabilitation")
                {
                    if (Convert.ToBoolean(Session["sgLFS_CWP_MANHOLEREHABILITATION_ADMIN"]))
                    {
                        string script = "<script language='javascript'>";
                        script += "window.open('./../ManholeRehabilitation/mr_batch_verification.aspx?source_page=select_project.aspx', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=500, height=540')";
                        script += "</script>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Wizard", script, false);
                    }
                }


                if ((hdfWorkType.Value == "Rehab Assessment") || (hdfWorkType.Value == "Full Length Lining") || (hdfWorkType.Value == "Point Repairs") || (hdfWorkType.Value == "Junction Lining") || (hdfWorkType.Value == "Junction Lining Section") || (hdfWorkType.Value == "Manhole Rehabilitation"))
                {
                    DateTime today = DateTime.Today;

                    if ((Convert.ToBoolean(Session["sgLFS_CWP_GERENCIAL_PRODUCTION_REPORTS"])) && (today.DayOfWeek == DayOfWeek.Monday))
                    {
                        string script = "<script language='javascript'>";
                        script += "window.open('./../Common/gerencial_weekly_production_report.aspx?source_page=select_project.aspx', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680')";
                        script += "</script>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Report", script, false);
                    }

                    // ... ... load Gerencial pop up ofr gerencial reports
                    if (Convert.ToBoolean(Session["sgLFS_CWP_GERENCIAL_PRODUCTION_REPORTS"]))
                    {
                        string script = "<script language='javascript'>";
                        script += "window.open('./../Common/gerencial_daily_production_report.aspx?source_page=select_project.aspx', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680')";
                        script += "</script>";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Report2", script, false);
                    }                    

                    // ... ... load eSewers Data
                    ddlClient.SelectedValue = "-1";
                    selectProjectTDS = new SelectProjectTDS();
                    SelectProjectLastUsedProjectsGateway selectProjectLastUsedProjectsGateway = new SelectProjectLastUsedProjectsGateway(selectProjectTDS);
                    selectProjectLastUsedProjectsGateway.LoadByLoginIdWorkType(Int32.Parse(hdfLoginId.Value), hdfWorkType.Value, Int32.Parse(hdfCompanyId.Value));
                }              

                // ... left menu
                if (Request.QueryString["source_page"] == "lm")
                {
                    ddlClient.SelectedValue = (string)Request.QueryString["client"];
                    selectProjectTDS = new SelectProjectTDS();
                    SelectProjectLastUsedProjectsGateway selectProjectLastUsedProjectsGateway = new SelectProjectLastUsedProjectsGateway(selectProjectTDS);
                    selectProjectLastUsedProjectsGateway.LoadByLoginIdWorkType(Int32.Parse(hdfLoginId.Value), hdfWorkType.Value, Int32.Parse(hdfCompanyId.Value));
                }

                // ... Store datasets                
                Session["selectProjectTDS"] = selectProjectTDS;
                Session["lastUsedProjects"] = selectProjectTDS.LastUsedProjects;
            }
            else
            {
                // Restore datasets
                selectProjectTDS = (SelectProjectTDS)Session["selectProjectTDS"];
            }
        }
               

        
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                Save();

                // Page selection
                if (Request.QueryString["work_type"] == "Rehab Assessment")
                {                    
                    string url = "./../RehabAssessment/ra_navigator.aspx?source_page=select_project.aspx&client_id=" + ddlClient.SelectedValue + "&project_id=" + ddlProject.SelectedValue + "&work_type=Rehab Assessment" ;
                    Response.Redirect(url);
                }
                
                if (Request.QueryString["work_type"] == "Full Length Lining")
                {
                    string url = "./../FullLengthLining/fl_navigator.aspx?source_page=select_project.aspx&client_id=" + ddlClient.SelectedValue + "&project_id=" + ddlProject.SelectedValue + "&work_type=Full Length Lining";
                    Response.Redirect(url);
                }

                if (Request.QueryString["work_type"] == "Point Repairs")
                {
                    string url = "./../PointRepairs/pr_navigator.aspx?source_page=select_project.aspx&client_id=" + ddlClient.SelectedValue + "&project_id=" + ddlProject.SelectedValue + "&work_type=Point Repairs";
                    Response.Redirect(url);
                }

                if (Request.QueryString["work_type"] == "Junction Lining")
                {
                    string url = "./../JunctionLining/jl_navigator.aspx?source_page=select_project.aspx&client_id=" + ddlClient.SelectedValue + "&project_id=" + ddlProject.SelectedValue + "&work_type=Junction Lining";
                    Response.Redirect(url);
                }

                if (Request.QueryString["work_type"] == "Junction Lining Section")
                {
                    string url = "./../JunctionLining/jls_navigator.aspx?source_page=select_project.aspx&client_id=" + ddlClient.SelectedValue + "&project_id=" + ddlProject.SelectedValue + "&work_type=Junction Lining Section";
                    Response.Redirect(url);
                }

                if (Request.QueryString["work_type"] == "Manhole Rehabilitation")
                {
                    //if (cbxInProject.Checked)
                    //{
                        // Manholes in project
                        string url = "./../ManholeRehabilitation/mr_navigator.aspx?source_page=select_project.aspx&client_id=" + ddlClient.SelectedValue + "&project_id=" + ddlProject.SelectedValue + "&work_type=Manhole Rehabilitation &in_project=true";
                        Response.Redirect(url);                        
                    //}
                }
            }
        }



        protected void btnSelectNoProject_Click(object sender, EventArgs e)
        {
            Page.Validate();
            if (Page.IsValid)
            {
                // Page selection               
                if (Request.QueryString["work_type"] == "Manhole Rehabilitation")
                {
                    //if (!cbxInProject.Checked)
                    //{
                    //    // Unrelated Manholes 
                    //    string url = "./../ManholeRehabilitation/mr_navigator.aspx?source_page=select_project.aspx&client_id=0&project_id=0&in_project=" + cbxInProject.Checked.ToString() + "&work_type=Manhole Rehabilitation";
                    //    Response.Redirect(url);
                    //}                    
                }
            }
        }



        protected void grdProjects_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    GrdProjectAdd();
                    break;
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "eSewers";

            // Title selection and configure options
            if ((Request.QueryString["work_type"] == "Rehab Assessment"))
            {
                lblTitle.Text = "Rehab Assessment";
            }

            if (Request.QueryString["work_type"] == "Full Length Lining")
            {
                lblTitle.Text = "Full Length Lining";
            }

            if (Request.QueryString["work_type"] == "Point Repairs")
            {
                lblTitle.Text = "Point Repairs";
            }

            if ((Request.QueryString["work_type"] == "Junction Lining") || (Request.QueryString["work_type"] == "Junction Lining Section"))
            {
                lblTitle.Text = "Junction Lining";
            }

            if (Request.QueryString["work_type"] == "Manhole Rehabilitation")
            {
                lblTitle.Text = "Manhole Rehabilitation";
            }
        }
        





        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void grdProjects_DataBound(object sender, EventArgs e)
        {
            AddProjectsNewEmptyFix(grdProjects);
        }



        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectList projectList = new ProjectList();
            projectList.LoadProjectsAndAddItem(-1, "(Select a project)", int.Parse(ddlClient.SelectedValue));
            ddlProject.DataSource = projectList.Table;
            ddlProject.DataValueField = "ProjectID";
            ddlProject.DataTextField = "Name";
            ddlProject.DataBind();
            ddlProject.SelectedIndex = 0;

            rfvProject.Validate();
        }



        protected void cbxInProject_CheckedChanged(object sender, EventArgs e)
        {
            //if (!cbxInProject.Checked)
            //{
            //    lblSelectAClient.Text = "";
            //    btnSelectNoProject.Visible = true;
            //    upnlForManholesInProject.Visible = false;
            //}
            //else
            //{
            //    lblSelectAClient.Text = "Please select a client and a project";
            //    btnSelectNoProject.Visible = false;
            //    upnlForManholesInProject.Visible = true;
            //}
        }



        protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            int currentProjectId = int.Parse(ddlProject.SelectedValue);

            if ((ddlProject.SelectedValue != null) && (ddlProject.SelectedValue != "-1"))
            {
                ProjectGateway projectGateway = new ProjectGateway(new DataSet());
                projectGateway.LoadByProjectId(currentProjectId);
            }

            rfvProject.Validate();
        }



        public string GetUrl(object str, object str2)
        {
            int projectId = Int32.Parse(str.ToString());
            int clientId = Int32.Parse(str2.ToString());

            string url = "";

            // Page selection
            if (Request.QueryString["work_type"] == "Rehab Assessment")
            {
                url = "./../RehabAssessment/ra_navigator.aspx?source_page=select_project.aspx&client_id=" + clientId + "&project_id=" + projectId + "&work_type=Rehab Assessment";
            }

            if (Request.QueryString["work_type"] == "Full Length Lining")
            {
                url = "./../FullLengthLining/fl_navigator.aspx?source_page=select_project.aspx&client_id=" + clientId + "&project_id=" + projectId + "&work_type=Full Length Lining";
            }

            if (Request.QueryString["work_type"] == "Point Repairs")
            {
                url = "./../PointRepairs/pr_navigator.aspx?source_page=select_project.aspx&client_id=" + clientId + "&project_id=" + projectId + "&work_type=Point Repairs";
            }

            if (Request.QueryString["work_type"] == "Junction Lining")
            {
                url = "./../JunctionLining/jl_navigator.aspx?source_page=select_project.aspx&client_id=" + clientId + "&project_id=" + projectId + "&work_type=Junction Lining";
            }

            if (Request.QueryString["work_type"] == "Junction Lining Section")
            {
                url = "./../JunctionLining/jls_navigator.aspx?source_page=select_project.aspx&client_id=" + clientId + "&project_id=" + projectId + "&work_type=Junction Lining Section";
            }

            if (Request.QueryString["work_type"] == "Manhole Rehabilitation")
            {                
                // In project
                url = "./../ManholeRehabilitation/mr_navigator.aspx?source_page=select_project.aspx&client_id=" + clientId + "&project_id=" + projectId + "&in_project=true" + "&work_type=Manhole Rehabilitation";             
            }

            return url;
        }





        // ////////////////////////////////////////////////////////////////////////
        //  PUBLIC METHODS
        //

        public SelectProjectTDS.LastUsedProjectsDataTable GetProjects()
        {
            lastUsedProjects = (SelectProjectTDS.LastUsedProjectsDataTable)Session["lastUsedProjectsDummy"];
            if (lastUsedProjects == null)
            {
                lastUsedProjects = ((SelectProjectTDS.LastUsedProjectsDataTable)Session["lastUsedProjects"]);
            }

            return lastUsedProjects;
        }



        public void DummyCommentNew(int ProjectID, int ClientID, int UserID, DateTime LastLoggedInDate, int COMPANY_ID, string WorkType)
        {
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void Save()
        {
            bool existsAtGrid = false;

            // Validate page
            if (Page.IsValid)
            {
                SelectProjectLastUsedProjectsGateway selectProjectLastUsedProjectsVerifyGateway = new SelectProjectLastUsedProjectsGateway(selectProjectTDS);               
                if (selectProjectLastUsedProjectsVerifyGateway.Table.Rows.Count > 0)
                {
                    // If exists the project in the grid
                    foreach (GridViewRow row in grdProjects.Rows)
                    {
                        // Grid Data
                        int gridClientId = Int32.Parse(((Label)row.FindControl("lblClientId")).Text.Trim());
                        int gridProjectId = Int32.Parse(((Label)row.FindControl("lblProjectId")).Text.Trim());
                        int gridUserId = Int32.Parse(((Label)row.FindControl("lblUserId")).Text.Trim());
                        int gridCompanyId = Int32.Parse(((Label)row.FindControl("lblCompanyId")).Text.Trim());
                        DateTime gridLastLoggedInDate = DateTime.Parse(((Label)row.FindControl("lblLastLoggedInDate")).Text.Trim());
                        string workType = hdfWorkType.Value;

                        // New Data
                        DateTime newLastLoggedInDate = DateTime.Now;

                        if ((gridClientId.ToString() == ddlClient.SelectedValue) && (gridProjectId.ToString() == ddlProject.SelectedValue) && (gridUserId == Int32.Parse(hdfLoginId.Value)) && (gridCompanyId == Int32.Parse(hdfCompanyId.Value)))
                        {
                            // Update if exists
                            SelectProjectLastUsedProjects model = new SelectProjectLastUsedProjects(selectProjectTDS);
                            model.UpdateLogginDate(gridClientId, gridProjectId, gridUserId, gridLastLoggedInDate, gridCompanyId, false, workType, newLastLoggedInDate);
                            existsAtGrid = true;
                        }

                        Session["selectProjectTDS"] = selectProjectTDS;
                        Session["lastUsedProjects"] = selectProjectTDS.LastUsedProjects;

                        grdProjects.DataBind();
                        grdProjects.PageIndex = grdProjects.PageCount - 1;
                    }
                }

                // If doesn't exists at grid
                if (!existsAtGrid)
                {
                    if (grdProjects.Rows.Count < 5)
                    {
                        // Add data if exist at grid's foot
                        GrdProjectAdd();
                    }
                    else
                    {
                        int index = 1;
                        foreach (GridViewRow row in grdProjects.Rows)
                        {
                            if (index == 5)
                            {
                                // Grid Data
                                int gridClientId = Int32.Parse(((Label)row.FindControl("lblClientId")).Text.Trim());
                                int gridProjectId = Int32.Parse(((Label)row.FindControl("lblProjectId")).Text.Trim());
                                int gridUserId = Int32.Parse(((Label)row.FindControl("lblUserId")).Text.Trim());
                                int gridCompanyId = Int32.Parse(((Label)row.FindControl("lblCompanyId")).Text.Trim());
                                DateTime gridLastLoggedInDate = DateTime.Parse(((Label)row.FindControl("lblLastLoggedInDate")).Text.Trim());
                                string workType = hdfWorkType.Value;                                

                                // New Data                                
                                int newProjectId = Int32.Parse(ddlProject.SelectedValue);
                                int newClientId = Int32.Parse(ddlClient.SelectedValue);
                                int newCompanyId = Int32.Parse(hdfCompanyId.Value);
                                int newUserId = Convert.ToInt32(Session["loginID"]);
                                DateTime newLastLoggedInDate = DateTime.Now;                                
                                string newWorkType = hdfWorkType.Value;

                                ProjectGateway projectGateway = new ProjectGateway();
                                projectGateway.LoadByProjectId(newProjectId);
                                string newProjectName = projectGateway.GetName(newProjectId) + " (" + projectGateway.GetProjectNumber(newProjectId) + ")";

                                int companyId = Int32.Parse(hdfCompanyId.Value);
                                CompaniesGateway companiesGateway = new CompaniesGateway();
                                companiesGateway.LoadByCompaniesId(newClientId, companyId);
                                string newClientName = companiesGateway.GetName(newClientId);

                                // Update if exists
                                SelectProjectLastUsedProjects model = new SelectProjectLastUsedProjects(selectProjectTDS);
                                model.Update(gridClientId, gridProjectId, gridUserId, gridCompanyId, workType, newClientId, newProjectId, newUserId, newLastLoggedInDate, newCompanyId, false, newWorkType, newProjectName, newClientName);                                
                            }

                            index = index + 1;
                        }

                        Session["selectProjectTDS"] = selectProjectTDS;
                        Session["lastUsedProjects"] = selectProjectTDS.LastUsedProjects;

                        grdProjects.DataBind();
                        grdProjects.PageIndex = grdProjects.PageCount - 1;
                    }
                }

                // Update data at bd
                UpdateDatabase();
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
                SelectProjectLastUsedProjects selectProjectLastUsedProjects = new SelectProjectLastUsedProjects(selectProjectTDS);
                selectProjectLastUsedProjects.Save(companyId);

                // Store datasets
                Session["selectProjectTDS"] = selectProjectTDS;
                Session["lastUsedProjects"] = selectProjectTDS.LastUsedProjects;

                DB.CommitTransaction();
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        protected void AddProjectsNewEmptyFix(GridView grdProject)
        {
            if (grdProject.Rows.Count == 0)
            {
                SelectProjectTDS.LastUsedProjectsDataTable dt = new SelectProjectTDS.LastUsedProjectsDataTable();
                dt.AddLastUsedProjectsRow(-1, -1, -1, DateTime.Now, -1, false, "", "", "", false);
                Session["lastUsedProjectsDummy"] = dt;

                grdProject.DataBind();
            }

            // Normally executes at all postbacks
            if (grdProject.Rows.Count == 1)
            {
                SelectProjectTDS.LastUsedProjectsDataTable dt = (SelectProjectTDS.LastUsedProjectsDataTable)Session["lastUsedProjectsDummy"];
                if (dt != null)
                {
                    grdProject.Rows[0].Visible = false;
                    grdProject.Rows[0].Controls.Clear();
                }
            }
        }



        private void GrdProjectAdd()
        {
            if (Page.IsValid)
            {
                int projectId = Int32.Parse(ddlProject.SelectedValue);
                int clientId = Int32.Parse(ddlClient.SelectedValue);
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int loginId = Convert.ToInt32(Session["loginID"]);
                DateTime lastLoggedInDate = DateTime.Now;
                bool deleted = false;
                string workType = hdfWorkType.Value;
                                
                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(projectId);
                string projectName = projectGateway.GetName(projectId) + " (" + projectGateway.GetProjectNumber(projectId) + ")";

                CompaniesGateway companiesGateway = new CompaniesGateway();
                companiesGateway.LoadByCompaniesId(clientId, companyId);
                string clientName = companiesGateway.GetName(clientId);
                
                SelectProjectLastUsedProjects model = new SelectProjectLastUsedProjects(selectProjectTDS);
                model.Insert(clientId, projectId, loginId, lastLoggedInDate, companyId, deleted, workType, projectName, clientName, false);

                Session.Remove("lastUsedProjectsDummy");
                Session["selectProjectTDS"] = selectProjectTDS;
                Session["lastUsedProjects"] = selectProjectTDS.LastUsedProjects;

                grdProjects.DataBind();
                grdProjects.PageIndex = grdProjects.PageCount - 1;
            }            
        }

        
    }
}
