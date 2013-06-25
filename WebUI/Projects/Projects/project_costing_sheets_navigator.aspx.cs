using System;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.BL.Projects.Projects;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// project_costing_sheets_navigator
    /// </summary>
    public partial class project_costing_sheets_navigator : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ProjectCostingSheetsNavigatorTDS projectCostingSheetsNavigatorTDS;
        protected ProjectTDS projectTDS;






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
                if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_COSTINGSHEETS_ADMIN"]))
                {
                    if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_COSTINGSHEETS_VIEW"]))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }

                // Validate query string
                if (Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in project_costing_sheets_navigator.aspx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfProjectId.Value = Request.QueryString["project_id"];
                hdfDataChanged.Value = Request.QueryString["data_changed"];
                hdfDataChangedMessage.Value = "Changes made to this project will not be saved.";

                ViewState["state"] = Request.QueryString["state"];
                ViewState["active_tab"] = Request.QueryString["active_tab"];
                ViewState["origin"] = Request.QueryString["origin"];
                ViewState["update"] = Request.QueryString["update"];

                projectTDS = (ProjectTDS)Session["lfsProjectTDS"];
                
                // Prepare initial data
                //lblResults.Visible = false;

                // ... for project
                int currentProjectId = Int32.Parse(hdfProjectId.Value.ToString());
                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(currentProjectId);
                string name = projectGateway.GetName(currentProjectId);
                if (name.Length > 23) name = name.Substring(0, 20) + "...";
                lblTitleProjectName.Text = name + " (" + projectGateway.GetProjectNumber(currentProjectId) + ")";

                // ... for client
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int currentCompanyId = projectGateway.GetClientID(Int32.Parse(hdfProjectId.Value.ToString()));
                CompaniesGateway companiesGateway = new CompaniesGateway();
                companiesGateway.LoadAllByCompaniesId(currentCompanyId, companyId);
                lblTitleClientName.Text = "Client: " + companiesGateway.GetName(currentCompanyId);

                hdfClientId.Value = projectGateway.GetClientID(int.Parse(hdfProjectId.Value)).ToString();

                // Store navigator state at projects navigator
                StoreNavigatorState();

                // If coming from
                // ... project_summary.aspx, project_edit.aspx, project_sections_navigator.aspx or project_sections_navigator2.aspx
                if ((Request.QueryString["source_page"] == "project_summary.aspx") || (Request.QueryString["source_page"] == "project_edit.aspx") || (Request.QueryString["source_page"] == "project_sections_navigator.aspx") || (Request.QueryString["source_page"] == "project_sections_navigator2.aspx"))
                {
                    projectCostingSheetsNavigatorTDS = new ProjectCostingSheetsNavigatorTDS();

                    // ... Search data with updates
                    projectCostingSheetsNavigatorTDS = SubmitSearch();

                    // ... Store datasets
                    Session["projectCostingSheetsNavigatorTDS"] = projectCostingSheetsNavigatorTDS;
                }

                // ... project_costing_sheets_edit.aspx, project_costing_sheets_summary.aspx or project_costing_sheets_delete.aspx
                if ((Request.QueryString["source_page"] == "project_costing_sheets_edit.aspx") || (Request.QueryString["source_page"] == "project_costing_sheets_summary.aspx") || (Request.QueryString["source_page"] == "project_costing_sheets_delete.aspx") || (Request.QueryString["source_page"] == "project_combined_costing_sheets_edit.aspx") || (Request.QueryString["source_page"] == "project_combined_costing_sheets_summary.aspx") || (Request.QueryString["source_page"] == "project_combined_costing_sheets_delete.aspx"))
                {
                    if (Request.QueryString["update"] == "no")
                    {
                        projectCostingSheetsNavigatorTDS = (ProjectCostingSheetsNavigatorTDS)Session["projectCostingSheetsNavigatorTDS"];
                    }
                    else
                    {
                        // ... Delete store data
                        Session.Contents.Remove("projectCostingSheetsNavigatorTDS");

                        projectCostingSheetsNavigatorTDS = SubmitSearch();                        

                        // ... store datasets
                        Session["projectCostingSheetsNavigatorTDS"] = projectCostingSheetsNavigatorTDS;
                    }
                }

                // For the grid
                grdCostingSheetsNavigator.DataSource = projectCostingSheetsNavigatorTDS.ProjectCostingSheetsNavigator;
                grdCostingSheetsNavigator.DataBind();

                grdCombinedCostingSheetsNavigator.DataSource = projectCostingSheetsNavigatorTDS.ProjectCombinedCostingSheetsNavigator;
                grdCombinedCostingSheetsNavigator.DataBind();

                //lblResults.Visible = false;

                // ... For the total rows
                if (projectCostingSheetsNavigatorTDS.ProjectCostingSheetsNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + projectCostingSheetsNavigatorTDS.ProjectCostingSheetsNavigator.Rows.Count;
                    lblTotalRows.Visible = true;
                    //lblResults.Visible = true;
                    btnOpen.Visible = true;
                    btnEdit.Visible = true;
                    btnDelete.Visible = true;
                    ddlAction.Visible = true;
                    pnlHorizontalRule.Visible = true;
                    lblCostingSheetsTitle.Visible = true;
                }
                else
                {
                    lblTotalRows.Visible = false;
                    btnOpen.Visible = false;
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                    ddlAction.Visible = false;
                    pnlHorizontalRule.Visible = false;
                    lblCostingSheetsTitle.Visible = false;
                }

                // ... For the total rows
                if (projectCostingSheetsNavigatorTDS.ProjectCombinedCostingSheetsNavigator.Rows.Count > 0)
                {
                    //lblResults.Visible = true;
                    lblCombinedCostingSheetsTotalRows.Text = "Total Rows: " + projectCostingSheetsNavigatorTDS.ProjectCombinedCostingSheetsNavigator.Rows.Count;
                    lblCombinedCostingSheetsTotalRows.Visible = true;
                    lblCombinedCostingSheetsTitle.Visible = true;
                    lblCombinedCostingSheetsTotalRows.Visible = true;
                    btnOpenCombinedCostingSheet.Visible = true;
                    btnEditCombinedCostingSheet.Visible = true;
                    btnDeleteCombinedCostingSheet.Visible = true;
                    pnlHorizontalRuleCombinedCostingSheet.Visible = true;
                    ddlActionCombinedCostingSheet.Visible = true;
                }
                else
                {
                    lblCombinedCostingSheetsTotalRows.Visible = false;
                    lblCombinedCostingSheetsTitle.Visible = false;
                    lblCombinedCostingSheetsTotalRows.Visible = false;
                    btnOpenCombinedCostingSheet.Visible = false;
                    btnEditCombinedCostingSheet.Visible = false;
                    btnDeleteCombinedCostingSheet.Visible = false;
                    pnlHorizontalRuleCombinedCostingSheet.Visible = false;
                    ddlActionCombinedCostingSheet.Visible = false;
                }
            }
            else
            {
                // Restore TDS
                projectTDS = (ProjectTDS)Session["lfsProjectTDS"];
                projectCostingSheetsNavigatorTDS = (ProjectCostingSheetsNavigatorTDS)Session["projectCostingSheetsNavigatorTDS"];

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

                // ... For the total rows
                if (projectCostingSheetsNavigatorTDS.ProjectCostingSheetsNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + projectCostingSheetsNavigatorTDS.ProjectCostingSheetsNavigator.Rows.Count;
                    lblTotalRows.Visible = true;
                    //lblResults.Visible = true;
                    btnOpen.Visible = true;
                    btnEdit.Visible = true;
                    btnDelete.Visible = true;
                    ddlAction.Visible = true;
                    pnlHorizontalRule.Visible = true;
                    lblCostingSheetsTitle.Visible = true;
                }
                else
                {
                    lblTotalRows.Visible = false;
                    btnOpen.Visible = false;
                    btnEdit.Visible = false;
                    btnDelete.Visible = false;
                    ddlAction.Visible = false;
                    pnlHorizontalRule.Visible = false;
                    lblCostingSheetsTitle.Visible = false;
                }

                // ... For the total rows
                if (projectCostingSheetsNavigatorTDS.ProjectCombinedCostingSheetsNavigator.Rows.Count > 0)
                {
                    //lblResults.Visible = true;
                    lblCombinedCostingSheetsTotalRows.Text = "Total Rows: " + projectCostingSheetsNavigatorTDS.ProjectCombinedCostingSheetsNavigator.Rows.Count;
                    lblCombinedCostingSheetsTotalRows.Visible = true;
                    lblCombinedCostingSheetsTitle.Visible = true;
                    lblCombinedCostingSheetsTotalRows.Visible = true;
                    btnOpenCombinedCostingSheet.Visible = true;
                    btnEditCombinedCostingSheet.Visible = true;
                    btnDeleteCombinedCostingSheet.Visible = true;
                    pnlHorizontalRuleCombinedCostingSheet.Visible = true;
                    ddlActionCombinedCostingSheet.Visible = true;
                }
                else
                {
                    lblCombinedCostingSheetsTotalRows.Visible = false;
                    lblCombinedCostingSheetsTitle.Visible = false;
                    lblCombinedCostingSheetsTotalRows.Visible = false;
                    btnOpenCombinedCostingSheet.Visible = false;
                    btnEditCombinedCostingSheet.Visible = false;
                    btnDeleteCombinedCostingSheet.Visible = false;
                    pnlHorizontalRuleCombinedCostingSheet.Visible = false;
                    ddlActionCombinedCostingSheet.Visible = false;
                }
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "Projects";

            // Security check
            if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_ADMIN"]))
            {
                tkrpbLeftMenuReports.Visible = false;
            }

            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

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

        protected void btnOpen_Click(object sender, EventArgs e)
        {
            PostPageChanges();

            int costingSheetId = GetCostingSheetId();

            if (costingSheetId > 0)
            {
                // Redirect
                string url = "./project_costing_sheets_summary.aspx?source_page=project_costing_sheets_navigator.aspx&costing_sheet_id=" + costingSheetId + "&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                Response.Redirect(url);
            }
            else
            {
                cvSelection.IsValid = false;
            }
        }



        protected void btnEdit_Click(object sender, EventArgs e)
        {
            PostPageChanges();

            int costingSheetId = GetCostingSheetId();

            if (costingSheetId > 0)
            {
                // Redirect
                string url = "./project_costing_sheets_edit.aspx?source_page=project_costing_sheets_navigator.aspx&costing_sheet_id=" + costingSheetId + "&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                Response.Redirect(url);
            }
            else
            {
                cvSelection.IsValid = false;
            }
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            PostPageChanges();

            int costingSheetId = GetCostingSheetId();
            if (costingSheetId > 0)
            {
                // Redirect
                string url = "./project_costing_sheets_delete.aspx?source_page=project_costing_sheets_navigator.aspx&costing_sheet_id=" + costingSheetId + "&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                Response.Redirect(url);
            }
            else
            {
                cvSelection.IsValid = false;
            }
        }



        protected void ddlAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            PostPageChanges();
            int costingSheetId = GetCostingSheetId();
            int projectId = Int32.Parse(hdfProjectId.Value);
            string operation = ddlAction.SelectedItem.Value.ToString();

            if (costingSheetId > 0)
            {
                ddlAction.SelectedIndex = 0;
                switch (operation)
                {
                    case "PreviewDetailed":
                        Response.Write("<script language='javascript'> {window.open('./project_costing_sheets_preview.aspx?costing_sheet_id= " + costingSheetId + "&project_id=" + projectId + "&type=detailed', '_blank', 'toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
                        break;

                    case "PreviewResume":
                        Response.Write("<script language='javascript'> {window.open('./project_costing_sheets_preview.aspx?costing_sheet_id= " + costingSheetId + "&project_id=" + projectId + "&type=resume', '_blank', 'toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
                        break;
                }
            }
            else
            {
                cvSelection.IsValid = false;
            }
        }



        protected void grdCostingSheetsNavigator_Sorting(object sender, GridViewSortEventArgs e)
        {
            string oldSort = projectCostingSheetsNavigatorTDS.ProjectCostingSheetsNavigator.DefaultView.Sort;

            if (!oldSort.Contains(e.SortExpression.ToString()))
            {
                projectCostingSheetsNavigatorTDS.ProjectCostingSheetsNavigator.DefaultView.Sort = e.SortExpression + " ASC";
                grdCostingSheetsNavigator.DataSource = projectCostingSheetsNavigatorTDS.ProjectCostingSheetsNavigator.DefaultView;
                grdCostingSheetsNavigator.DataBind();
            }
            else
            {
                if (oldSort.Contains("ASC"))
                {
                    projectCostingSheetsNavigatorTDS.ProjectCostingSheetsNavigator.DefaultView.Sort = e.SortExpression + " DESC";
                    grdCostingSheetsNavigator.DataSource = projectCostingSheetsNavigatorTDS.ProjectCostingSheetsNavigator.DefaultView;
                    grdCostingSheetsNavigator.DataBind();
                }
                else
                {
                    projectCostingSheetsNavigatorTDS.ProjectCostingSheetsNavigator.DefaultView.Sort = e.SortExpression + " ASC";
                    grdCostingSheetsNavigator.DataSource = projectCostingSheetsNavigatorTDS.ProjectCostingSheetsNavigator.DefaultView;
                    grdCostingSheetsNavigator.DataBind();
                }
            }
        }



        protected void btnOpenCombinedCostingSheet_Click(object sender, EventArgs e)
        {
            PostPageChangesCombinedCostingSheets();

            int costingSheetId = GetCombinedCostingSheetId();

            if (costingSheetId > 0)
            {
                // Redirect
                string url = "./project_combined_costing_sheets_summary.aspx?source_page=project_costing_sheets_navigator.aspx&costing_sheet_id=" + costingSheetId + "&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                Response.Redirect(url);
            }
            else
            {
                cvSelection.IsValid = false;
            }
        }



        protected void btnEditCombinedCostingSheet_Click(object sender, EventArgs e)
        {
            PostPageChangesCombinedCostingSheets();

            int costingSheetId = GetCombinedCostingSheetId();

            if (costingSheetId > 0)
            {
                // Redirect
                string url = "./project_combined_costing_sheets_edit.aspx?source_page=project_costing_sheets_navigator.aspx&costing_sheet_id=" + costingSheetId + "&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                Response.Redirect(url);
            }
            else
            {
                cvSelection.IsValid = false;
            }
        }



        protected void btnDeleteCombinedCostingSheet_Click(object sender, EventArgs e)
        {
            PostPageChangesCombinedCostingSheets();

            int costingSheetId = GetCombinedCostingSheetId();

            if (costingSheetId > 0)
            {
                // Redirect
                string url = "./project_combined_costing_sheets_delete.aspx?source_page=project_costing_sheets_navigator.aspx&costing_sheet_id=" + costingSheetId + "&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                Response.Redirect(url);
            }
            else
            {
                cvSelection.IsValid = false;
            }
        }



        protected void ddlActionCombinedCostingSheets_SelectedIndexChanged(object sender, EventArgs e)
        {
            PostPageChangesCombinedCostingSheets();

            int costingSheetId = GetCombinedCostingSheetId();
            int projectId = Int32.Parse(hdfProjectId.Value);
            string operation = ddlActionCombinedCostingSheet.SelectedItem.Value.ToString();

            if (costingSheetId > 0)
            {
                ddlActionCombinedCostingSheet.SelectedIndex = 0;
                switch (operation)
                {
                    case "PreviewDetailed":
                        Response.Write("<script language='javascript'> {window.open('./project_combined_costing_sheets_preview.aspx?costing_sheet_id= " + costingSheetId + "&project_id=" + projectId + "&type=detailed', '_blank', 'toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
                        break;

                    case "PreviewResume":
                        Response.Write("<script language='javascript'> {window.open('./project_combined_costing_sheets_preview.aspx?costing_sheet_id= " + costingSheetId + "&project_id=" + projectId + "&type=resume', '_blank', 'toolbar=yes, location=yes, directories=no, status=yes, menubar=yes, scrollbars=yes, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
                        break;
                }
            }
            else
            {
                cvSelection.IsValid = false;
            }
        }



        protected void grdCombinedCostingSheetsNavigator_Sorting(object sender, GridViewSortEventArgs e)
        {
            string oldSort = projectCostingSheetsNavigatorTDS.ProjectCombinedCostingSheetsNavigator.DefaultView.Sort;

            if (!oldSort.Contains(e.SortExpression.ToString()))
            {
                projectCostingSheetsNavigatorTDS.ProjectCombinedCostingSheetsNavigator.DefaultView.Sort = e.SortExpression + " ASC";
                grdCombinedCostingSheetsNavigator.DataSource = projectCostingSheetsNavigatorTDS.ProjectCombinedCostingSheetsNavigator.DefaultView;
                grdCombinedCostingSheetsNavigator.DataBind();
            }
            else
            {
                if (oldSort.Contains("ASC"))
                {
                    projectCostingSheetsNavigatorTDS.ProjectCombinedCostingSheetsNavigator.DefaultView.Sort = e.SortExpression + " DESC";
                    grdCombinedCostingSheetsNavigator.DataSource = projectCostingSheetsNavigatorTDS.ProjectCombinedCostingSheetsNavigator.DefaultView;
                    grdCostingSheetsNavigator.DataBind();
                }
                else
                {
                    projectCostingSheetsNavigatorTDS.ProjectCombinedCostingSheetsNavigator.DefaultView.Sort = e.SortExpression + " ASC";
                    grdCombinedCostingSheetsNavigator.DataSource = projectCostingSheetsNavigatorTDS.ProjectCombinedCostingSheetsNavigator.DefaultView;
                    grdCombinedCostingSheetsNavigator.DataBind();
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mLastSearch":
                    if (Session["lfsProjectNavigatorTDS"] == null)
                    {
                        url = "./projects.aspx?source_page=projects2.aspx&" + GetNavigatorState() + "&no_results=no";
                    }
                    else
                    {
                        url = "./projects2.aspx?source_page=project_costing_sheets_navigator.aspx&project_id=" + hdfProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }
                    break;
            }

            if (url != "") Response.Redirect(url);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mSections":
                    url = "./project_sections_navigator.aspx?source_page=lm&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                    break;

                case "mProject":
                    if (ViewState["state"].ToString() == "summary")
                    {
                        url = "./project_summary.aspx?source_page=lm&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&update=" + (string)ViewState["update"] + "&state=" + (string)ViewState["state"];
                    }

                    if (ViewState["state"].ToString() == "edit")
                    {
                        url = "./project_edit.aspx?source_page=lm&project_id=" + hdfProjectId.Value + "&active_tab=" + (string)ViewState["active_tab"] + GetNavigatorState() + "&origin=" + (string)ViewState["origin"] + "&update=" + (string)ViewState["update"] + "&data_changed=" + hdfDataChanged.Value + "&state=" + (string)ViewState["state"];
                    }
                    break;

                case "mSearch":
                    url = "./projects.aspx?source_page=lm";
                    break;
            }

            if (url != "") Response.Redirect(url);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode1", "./project_costing_sheets_navigator.js");
        }



        private ProjectCostingSheetsNavigatorTDS SubmitSearch()
        {
            ProjectCostingSheetsNavigatorTDS projectCostingSheetsNavigatorTDS = new ProjectCostingSheetsNavigatorTDS();
            // ... Load data
            ProjectCostingSheetsNavigator projectCostingSheetsNavigator = new ProjectCostingSheetsNavigator(projectCostingSheetsNavigatorTDS);
            projectCostingSheetsNavigator.LoadByProjectId(Int32.Parse(hdfProjectId.Value.ToString()), Int32.Parse(hdfCompanyId.Value.ToString()));

            ProjectCombinedCostingSheetsNavigator projectCombinedCostingSheetsNavigator = new ProjectCombinedCostingSheetsNavigator(projectCostingSheetsNavigatorTDS);
            projectCombinedCostingSheetsNavigator.LoadByClientId(Int32.Parse(hdfClientId.Value.ToString()), Int32.Parse(hdfCompanyId.Value.ToString()));

            return (ProjectCostingSheetsNavigatorTDS)projectCostingSheetsNavigatorTDS;
        }



        private void PostPageChanges()
        {
            ProjectCostingSheetsNavigator projectCostingSheetsNavigator = new ProjectCostingSheetsNavigator(projectCostingSheetsNavigatorTDS);

            // Update grid rows
            foreach (GridViewRow row in grdCostingSheetsNavigator.Rows)
            {
                int costingSheetId = int.Parse(((Label)row.FindControl("lblCostingSheetID")).Text);
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                projectCostingSheetsNavigator.Update(costingSheetId, selected);
            }

            projectCostingSheetsNavigator.Data.AcceptChanges();

            // Store datasets
            Session["projectCostingSheetsNavigatorTDS"] = projectCostingSheetsNavigatorTDS;
        }



        private void PostPageChangesCombinedCostingSheets()
        {
            ProjectCombinedCostingSheetsNavigator projectCombinedCostingSheetsNavigator = new ProjectCombinedCostingSheetsNavigator(projectCostingSheetsNavigatorTDS);

            // Update grid rows
            foreach (GridViewRow row in grdCombinedCostingSheetsNavigator.Rows)
            {
                int costingSheetId = int.Parse(((Label)row.FindControl("lblCostingSheetID")).Text);
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                projectCombinedCostingSheetsNavigator.Update(costingSheetId, selected);
            }

            projectCombinedCostingSheetsNavigator.Data.AcceptChanges();

            // Store datasets
            Session["projectCostingSheetsNavigatorTDS"] = projectCostingSheetsNavigatorTDS;
        }



        private int GetCostingSheetId()
        {
            int costingSheetId = 0;

            foreach (ProjectCostingSheetsNavigatorTDS.ProjectCostingSheetsNavigatorRow projectCostingSheetsNavigatorRow in projectCostingSheetsNavigatorTDS.ProjectCostingSheetsNavigator)
            {
                if (projectCostingSheetsNavigatorRow.Selected)
                {
                    costingSheetId = projectCostingSheetsNavigatorRow.CostingSheetID;
                }
            }

            return costingSheetId;
        }



        private int GetCombinedCostingSheetId()
        {
            int costingSheetId = 0;

            foreach (ProjectCostingSheetsNavigatorTDS.ProjectCombinedCostingSheetsNavigatorRow projectCombinedCostingSheetsNavigatorRow in projectCostingSheetsNavigatorTDS.ProjectCombinedCostingSheetsNavigator)
            {
                if (projectCombinedCostingSheetsNavigatorRow.Selected)
                {
                    costingSheetId = projectCombinedCostingSheetsNavigatorRow.CostingSheetID;
                }
            }

            return costingSheetId;
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&search_projectnumber=" + Request.QueryString["search_projectnumber"] + "&search_projectname=" + Request.QueryString["search_projectname"] + "&search_client=" + Request.QueryString["search_client"] + "&search_type=" + Request.QueryString["search_type"] + "&search_state=" + Request.QueryString["search_state"];
        }



        private string GetNavigatorState()
        {
            // Return
            return (string)ViewState["navigatorState"];
        }



    }
}