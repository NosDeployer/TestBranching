using System;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.DA.CWP.Assets;
using LiquiForce.LFSLive.DA.Resources.Companies;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// project_sections_navigator2
    /// </summary>
    public partial class project_sections_navigator2 : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ProjectTDS projectTDS;
        protected ProjectSectionsNavigatorTDS projectSectionsNavigatorTDS;
        protected ProjectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATORDataTable projectSectionsNavigator;
        protected AssetsTDS assetsTDS;
        protected LfsAssetsTDS lfsAssetsTDS;
        protected WorkTDS workTDS;






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
                if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_VIEW"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in project_sections_navigator2.aspx");
                }

                projectTDS = (ProjectTDS)Session["lfsProjectTDS"];
                assetsTDS = new AssetsTDS();
                lfsAssetsTDS = new LfsAssetsTDS();
                workTDS = new WorkTDS();

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfProjectId.Value = Request.QueryString["project_id"];
                hdfDataChanged.Value = Request.QueryString["data_changed"];
                hdfDataChangedMessage.Value = "Changes made to this project will not be saved.";
                ViewState["state"] = Request.QueryString["state"];
                ViewState["active_tab"] = Request.QueryString["active_tab"];
                ViewState["origin"] = Request.QueryString["origin"];
                ViewState["update"] = Request.QueryString["update"];

                Session.Remove("projectSectionsNavigatorNewDummy");
                Session.Remove("projectSectionsNavigator");

                // Prepare initial data
                lblError.Visible = false;

                // ... for project
                int currentProjectId = Int32.Parse(hdfProjectId.Value.ToString());
                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(currentProjectId);
                string name = projectGateway.GetName(currentProjectId);
                if (name.Length > 23) name = name.Substring(0, 20) + "...";
                lblTitleProjectName.Text = name + " (" + projectGateway.GetProjectNumber(currentProjectId) + ")";

                // ... for client
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int currentClientId = projectGateway.GetClientID(Int32.Parse(hdfProjectId.Value.ToString()));
                CompaniesGateway companiesGateway = new CompaniesGateway();
                companiesGateway.LoadAllByCompaniesId(currentClientId, companyId);
                lblTitleClientName.Text = "Client: " + companiesGateway.GetName(currentClientId);

                hdfClientId.Value = projectGateway.GetClientID(int.Parse(hdfProjectId.Value)).ToString();

                // Store navigator state at projects navigator
                StoreNavigatorState();

                // ... project_sections_navigator.aspx or project_sections_navigator2.aspx
                if ((Request.QueryString["source_page"] == "project_sections_navigator.aspx") || (Request.QueryString["source_page"] == "project_sections_navigator2.aspx"))
                {
                    // Restore navigator state
                    RestoreNavigatorState();

                    // Restore data
                    projectSectionsNavigatorTDS = (ProjectSectionsNavigatorTDS)Session["lfsProjectSectionsNavigatorTDS"];
                    projectSectionsNavigator = projectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATOR;

                    // Store data
                    Session["projectSectionsNavigator"] = projectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATOR;
                    
                    if (Request.QueryString["update_section"] == "no")
                    {
                        // Restore data
                        projectSectionsNavigatorTDS = (ProjectSectionsNavigatorTDS)Session["lfsProjectSectionsNavigatorTDS"];
                        projectSectionsNavigator = projectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATOR;

                        // Store data
                        Session["projectSectionsNavigator"] = projectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATOR;
                    }
                    else
                    {
                        // ... Delete store data
                        Session.Contents.Remove("lfsProjectSectionsNavigatorTDS");

                        // ... Search data with updates
                        projectSectionsNavigatorTDS = SubmitSearch();

                        // ... store datasets
                        Session["lfsProjectSectionsNavigatorTDS"] = projectSectionsNavigatorTDS;
                        Session["projectSectionsNavigator"] = projectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATOR;
                    }

                    //... for the total rows
                    if (projectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATOR.Rows.Count > 0)
                    {
                        lblTotalRows.Text = "Total Rows: " + projectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATOR.Rows.Count;
                        lblTotalRows.Visible = true;
                    }
                    else
                    {
                        lblTotalRows.Visible = false;
                    }
                }
            }
            else
            {
                // Restore dataset 
                projectTDS = (ProjectTDS)Session["lfsProjectTDS"];
                projectSectionsNavigatorTDS = (ProjectSectionsNavigatorTDS)Session["lfsProjectSectionsNavigatorTDS"];
                assetsTDS = (AssetsTDS)Session["assetsTDS"];
                lfsAssetsTDS = (LfsAssetsTDS)Session["lfsAssetsTDS"];
                workTDS = (WorkTDS)Session["workTDS"];

                // ... for project
                int currentProjectId = Int32.Parse(hdfProjectId.Value.ToString());
                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(currentProjectId);
                string name = projectGateway.GetName(currentProjectId);
                if (name.Length > 23) name = name.Substring(0, 20) + "...";
                lblTitleProjectName.Text = name + " (" + projectGateway.GetProjectNumber(currentProjectId) + ")";

                // ... for client
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int currentClientId = projectGateway.GetClientID(Int32.Parse(hdfProjectId.Value.ToString()));
                CompaniesGateway companiesGateway = new CompaniesGateway();
                companiesGateway.LoadAllByCompaniesId(currentClientId, companyId);
                lblTitleClientName.Text = "Client: " + companiesGateway.GetName(currentClientId);

                // Restore searched data (if any)
                projectSectionsNavigatorTDS = (ProjectSectionsNavigatorTDS)Session["lfsProjectSectionsNavigatorTDS"];
                projectSectionsNavigator = projectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATOR;

                //... for the total rows
                if (projectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATOR.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + projectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATOR.Rows.Count;
                }
                else
                {
                    lblTotalRows.Visible = false;
                }
            }
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string url = "";

            // Delete store data
            Session.Contents.Remove("lfsProjectSectionsNavigatorTDS");
            Session.Contents.Remove("projectSectionsNavigator");

            // Get data from database gateway
            ProjectSectionsNavigatorTDS projectSectionsNavigatorTDS = SubmitSearch();

            // Show results
            if (projectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATOR.DefaultView.Count > 0)
            {
                // ... Store data
                Session["lfsProjectSectionsNavigatorTDS"] = projectSectionsNavigatorTDS;
                Session["projectSectionsNavigator"] = projectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATOR;

                // ... Go to the results page
                Response.Redirect("./project_sections_navigator2.aspx?source_page=project_sections_navigator2.aspx&project_id=" + hdfProjectId.Value + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"] + "&update_section=no&active_tab=" + (string)ViewState["active_tab"]);
            }
            else
            {
                Response.Redirect("./project_sections_navigator.aspx?source_page=project_sections_navigator2.aspx&project_id=" + hdfProjectId.Value + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"] + "&no_results=yes" + "&update_section=no&active_tab=" + (string)ViewState["active_tab"]);
            }

            Response.Redirect(url);
        }                    



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set ddlTools
            DropDownList ddlTools = (DropDownList)tkrpbLeftMenuCurrentProject.FindItemByValue("Tools").FindControl("ddlTools");
            ddlTools.Attributes.Add("onchange", "return OpenTools(this);");

            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "Projects";

            lblHeaderTitle.Text = "Project Sections";

            // Project type check
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(Int32.Parse(hdfProjectId.Value));
            
            if (projectGateway.GetProjectType(Int32.Parse(hdfProjectId.Value)) == "Proposal")
            {
                tkrpbLeftMenuCurrentProject.Items[0].Text = "Current Proposal";
                tkrpbLeftMenuCurrentProject.Items[0].Items[0].Text = "Proposal";

                lblTitleProject.Text = " > Proposal: ";

                tkrpbLeftMenuCurrentProject.Items[0].Items[3].Visible = false; //mSections
                tkrpbLeftMenuCurrentProject.Items[0].Items[4].Visible = false; //mTools
                tkrpbLeftMenuCurrentProject.Items[0].Items[5].Visible = false; //mSeparator   
            }

            if (projectGateway.GetProjectType(Int32.Parse(hdfProjectId.Value)) == "Project")
            {
                tkrpbLeftMenuCurrentProject.Items[0].Text = "Current Project";
                tkrpbLeftMenuCurrentProject.Items[0].Items[0].Text = "Project";

                lblTitleProject.Text = " > Project: ";
            }

            if (projectGateway.GetProjectType(Int32.Parse(hdfProjectId.Value)) == "Internal")
            {
                tkrpbLeftMenuCurrentProject.Items[0].Text = "Current Internal Project";
                tkrpbLeftMenuCurrentProject.Items[0].Items[0].Text = "Internal Project";

                lblTitleProject.Text = " > Internal Project: ";

                tkrpbLeftMenuCurrentProject.Items[0].Items[3].Visible = false; //mSections
                tkrpbLeftMenuCurrentProject.Items[0].Items[4].Visible = false; //mTools
                tkrpbLeftMenuCurrentProject.Items[0].Items[5].Visible = false; //mSeparator   
            }

            if (projectGateway.GetProjectType(int.Parse(hdfProjectId.Value)) == "Ballpark")
            {
                tkrpbLeftMenuCurrentProject.Items[0].Text = "Current Ballpark";
                tkrpbLeftMenuCurrentProject.Items[0].Items[0].Text = "Ballpark";

                lblTitleProject.Text = " > Ballpark: ";

                tkrpbLeftMenuCurrentProject.Items[0].Items[3].Visible = false; //mSections
                tkrpbLeftMenuCurrentProject.Items[0].Items[4].Visible = false; //mTools
                tkrpbLeftMenuCurrentProject.Items[0].Items[5].Visible = false; //mSeparator   
            }

            // Security check
            if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_ADMIN"]))
            {
                tkrpbLeftMenuReports.Visible = false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void grdSectionsNavigator_DataBound(object sender, EventArgs e)
        {
            AddProjectSectionsNewEmptyFix(grdSectionsNavigator);
        }



         protected void grdSectionsNavigator_Sorting(object sender, GridViewSortEventArgs e)
        {
            string oldSort = projectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATOR.DefaultView.Sort;

            if (!oldSort.Contains(e.SortExpression.ToString()))
            {
                projectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATOR.DefaultView.Sort = e.SortExpression + " ASC";
            }
            else
            {
                if (oldSort.Contains("ASC"))
                {
                    projectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATOR.DefaultView.Sort = e.SortExpression + " DESC";
                }
                else
                {
                    projectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATOR.DefaultView.Sort = e.SortExpression + " ASC";
                }
            }

            // Store data
            Session["projectSectionsNavigatorTDS"] = projectSectionsNavigatorTDS;
            Session["projectSectionsNavigator"] = projectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATOR;
        }





                
        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnOpen_Click(object sender, EventArgs e)
        {
            SaveSelectedAssetId();
            int assetId = Int32.Parse(hdfSelectedAssetId.Value);
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int projectId = Int32.Parse(hdfProjectId.Value);

            if (assetId != 0)
            {
                lblError.Visible = false;
                string script = "<script language='javascript'>";
                string url = "./project_sections_summary.aspx?source_page=project_sections_navigator2.aspx&asset_id=" + assetId + "&project_id=" + hdfProjectId.Value + "&company_id=" + hdfCompanyId.Value;
                script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=800, height=430')", url);
                script = script + "</script>";
                Response.Write(script);
            }
            else
            {
                lblError.Visible = true;
            }
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSection();
        }



        protected void btnClearSearch_Click(object sender, EventArgs e)
        {
            string url = "./project_sections_navigator.aspx?source_page=project_sections_navigator2.aspx&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"] + "&update_section=no&no_results=no";

            if (url != "") Response.Redirect(url);
        }       



        protected void ddlViewWorks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (projectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATOR.DefaultView.Count > 0)
            {
                string url = "";

                switch (ddlViewWorks.SelectedItem.Value.ToString())
                {
                    case "RehabAssessment":
                        url = "./../../CWP/RehabAssessment/ra_navigator.aspx?source_page=select_project.aspx&client_id=" + hdfClientId.Value + "&project_id=" + hdfProjectId.Value + "&work_type=Rehab Assessment";
                        break;

                    case "FullLengthLining":
                        url = "./../../CWP/FullLengthLining/fl_navigator.aspx?source_page=select_project.aspx&client_id=" + hdfClientId.Value + "&project_id=" + hdfProjectId.Value + "&work_type=Full Length Lining";
                        ddlViewWorks.AutoPostBack = false;
                        ddlViewWorks.SelectedIndex = 0;
                        break;

                    case "JunctionLining":
                        url = "./../../CWP/JunctionLining/jl_navigator.aspx?source_page=Projects2.aspx&client_id=" + hdfClientId.Value + "&project_id=" + hdfProjectId.Value + "&work_type=Junction Lining";
                        break;
                }

                if (url != "") Response.Redirect(url);
            }
        }



        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mLastSearch":
                    url = "./projects2.aspx?source_page=project_sections_navigator2.aspx&project_id=" + hdfProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;
            }

            if (url != "") Response.Redirect(url);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mProjectCostingSheets":
                    url = "./project_costing_sheets_navigator.aspx?source_page=project_sections_navigator2.aspx&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                    break;

                case "mProject":
                    if (ViewState["state"].ToString() == "summary")
                    {
                        url = "./project_summary.aspx?source_page=lm&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }

                    if (ViewState["state"].ToString() == "edit")
                    {
                        url = "./project_edit.aspx?source_page=lm&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value;
                    }
                    break;

                case "mSearch":
                    url = "./projects.aspx?source_page=lm";
                    break;
            }

            if (url != "") Response.Redirect(url);
        }






        // ////////////////////////////////////////////////////////////////////////
        //  PUBLIC METHODS
        //

        public ProjectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATORDataTable GetSections()
        {
            projectSectionsNavigator = (ProjectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATORDataTable)Session["projectSectionsNavigatorNewDummy"];
            if (projectSectionsNavigator == null)
            {
                projectSectionsNavigator = ((ProjectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATORDataTable)Session["projectSectionsNavigator"]);
            }

            return projectSectionsNavigator;
        }



        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfProjectIdId = '" + hdfProjectId.ClientID + "';";
            contentVariables += "var hdfClientIdId = '" + hdfClientId.ClientID + "';";
            contentVariables += "var hdfDataChangedId = '" + hdfDataChanged.ClientID + "';";
            contentVariables += "var hdfDataChangedMessageId = '" + hdfDataChangedMessage.ClientID + "';";
            contentVariables += "var hdfBeforeUnloadOrigenId = '" + hdfBeforeUnloadOrigen.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode1", "./project_sections_navigator2.js");
        }



        private void RestoreNavigatorState()
        {
            // Search
            tbxID.Text = Request.QueryString["search_section_id"];
            tbxStreet.Text = Request.QueryString["search_street"];
            tbxUSMH.Text = Request.QueryString["search_usmh"];
            tbxDSMH.Text = Request.QueryString["search_dsmh"];
        }



        private string GetNavigatorState()
        {
            // SearchOptions
            string searchOptions = "";
            searchOptions = searchOptions + "&search_section_id=" + tbxID.Text.Trim();
            searchOptions = searchOptions + "&search_street=" + tbxStreet.Text.Trim();
            searchOptions = searchOptions + "&search_usmh=" + tbxUSMH.Text.Trim();
            searchOptions = searchOptions + "&search_dsmh=" + tbxDSMH.Text.Trim();

            Session["sectionNavigatorState"] = searchOptions;

            // Return
            return searchOptions + (string)ViewState["navigatorState"];
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&search_projectnumber=" + Request.QueryString["search_projectnumber"] + "&search_projectname=" + Request.QueryString["search_projectname"] + "&search_client=" + Request.QueryString["search_client"] + "&search_type=" + Request.QueryString["search_type"] + "&search_state=" + Request.QueryString["search_state"];
        }



        private ProjectSectionsNavigatorTDS SubmitSearch()
        {
            // Retrive parameters
            string sectionID = tbxID.Text.Trim();
            string street = tbxStreet.Text.Trim();
            string usmh = tbxUSMH.Text.Trim();
            string dsmh = tbxDSMH.Text.Trim();

            // Load data
            ProjectSectionsNavigator projectSectionsNavigator = new ProjectSectionsNavigator();
            projectSectionsNavigator.LoadBySectionIDStreetUsmhDsmhCompanyIdProjectId(sectionID, street, usmh, dsmh, int.Parse(hdfCompanyId.Value), int.Parse(hdfProjectId.Value));

            return (ProjectSectionsNavigatorTDS)projectSectionsNavigator.Data;
        }



        protected void DeleteSection()
        {
            SaveSelectedAssetId();
            int assetId = Int32.Parse(hdfSelectedAssetId.Value);
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int projectId = Int32.Parse(hdfProjectId.Value);

            DB.Open();
            DB.BeginTransaction();
            try
            {
                ProjectSectionsNavigator projectSectionsNavigator = new ProjectSectionsNavigator(projectSectionsNavigatorTDS);
                projectSectionsNavigator.Delete(projectId, assetId, companyId);

                DB.CommitTransaction();

                projectSectionsNavigatorTDS.AcceptChanges();
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }

            // Redirect
            Response.Redirect("./project_sections_navigator2.aspx?source_page=project_sections_navigator2.aspx&project_id=" + hdfProjectId.Value + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"] + "&update_section=yes&active_tab=" + (string)ViewState["active_tab"]);

        }



        protected void SaveSelectedAssetId()
        {
            int assetIdForUpdate = 0;
            bool selected = false;
            hdfSelectedAssetId.Value = "0";

            ProjectSectionsNavigator projectSectionsNavigatorForUpdate = new ProjectSectionsNavigator(projectSectionsNavigatorTDS);

            foreach (GridViewRow row in grdSectionsNavigator.Rows)
            {
                // ... Update all rows
                selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                assetIdForUpdate = Int32.Parse(((Label)row.FindControl("lblAssetID")).Text.Trim());
                projectSectionsNavigatorForUpdate.Update(assetIdForUpdate, selected);

                // ... Save selected project
                if (selected)
                {
                    hdfSelectedAssetId.Value = assetIdForUpdate.ToString();
                }
            }
            projectSectionsNavigatorForUpdate.Data.AcceptChanges();

            // ... Store datasets
            Session["projectSectionsNavigator"] = projectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATOR;
        }



        protected void AddProjectSectionsNewEmptyFix(GridView grdNavigator)
        {
            if (grdSectionsNavigator.Rows.Count == 0)
            {
                ProjectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATORDataTable dt = new ProjectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATORDataTable();
                dt.AddLFS_PROJECT_SECTIONS_NAVIGATORRow(-1, "", "", -1, -1, -1, -1, "", "", "", false, false, false, -1, "", false, "");
                Session["projectSectionsNavigatorNewDummy"] = dt;

                grdSectionsNavigator.DataBind();
            }

            // normally executes at all postbacks
            if (grdSectionsNavigator.Rows.Count == 1)
            {
                ProjectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATORDataTable dt = (ProjectSectionsNavigatorTDS.LFS_PROJECT_SECTIONS_NAVIGATORDataTable)Session["projectSectionsNavigatorNewDummy"];
                if (dt != null)
                {
                    grdSectionsNavigator.Rows[0].Visible = false;
                    grdSectionsNavigator.Rows[0].Controls.Clear();
                }
            }
        }



    }
}