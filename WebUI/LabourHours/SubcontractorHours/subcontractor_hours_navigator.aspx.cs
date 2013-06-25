using System;
using System.Data;
using System.Web.UI;
using LiquiForce.LFSLive.BL.LabourHours.SubcontractorHours;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.BL.RAF;
using LiquiForce.LFSLive.DA.LabourHours.SubcontractorHours;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.LabourHours.SubcontractorHours
{
    /// <summary>
    /// subcontractor_hours_navigator
    /// </summary>
    public partial class subcontractor_hours_navigator : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // INITIAL EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            // Register client scripts
            this.RegisterClientScripts();
            
            if (!IsPostBack)
            {
                if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_SUBCONTRACTOR_HOURS_ADMIN"])))
                {
                    // Security check
                    if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_SUBCONTRACTOR_HOURS_VIEW"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }

                    // Validate query string
                    if ((string)Request.QueryString["source_page"] == null)
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in subcontractor_hours_navigator.aspx");
                    }
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                tkrdpStartDate.SelectedDate = DateTime.Now;
                tkrdpEndDate.SelectedDate = DateTime.Now;

                // ...  for the client
                int companyId = Int32.Parse(hdfCompanyId.Value);
                CompaniesList companiesList = new CompaniesList(new DataSet());
                companiesList.LoadAndAddItem(-1, "(All)", companyId);
                ddlClient.DataSource = companiesList.Table;
                ddlClient.DataValueField = "COMPANIES_ID";
                ddlClient.DataTextField = "NAME";
                ddlClient.DataBind();
                ddlClient.SelectedIndex = 0;

                // ... for project
                ProjectList projectList = new ProjectList();
                projectList.LoadProjectsAndAddItem(-1, "(All)", -1);
                ddlProject.DataSource = projectList.Table;
                ddlProject.DataValueField = "ProjectID";
                ddlProject.DataTextField = "Name";
                ddlProject.DataBind();
                ddlProject.SelectedIndex = 0;

                // If coming from 
                // ... Left Menu or out
                if ((Request.QueryString["source_page"] == "lm") || (Request.QueryString["source_page"] == "out"))
                {
                    tdNoResults.Visible = false;
                }

                // ... subcontractor_hours_navigator2.aspx
                if (Request.QueryString["source_page"] == "subcontractor_hours_navigator2.aspx")
                {
                    RestoreNavigatorState();
                    if ((string)Request.QueryString["no_results"] == "yes")
                    {
                        tdNoResults.Visible = true;
                    }
                    else
                    {
                        tdNoResults.Visible = false;
                    }
                }
            }
        }



        protected void btnSearchBySubcontractor_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                SubcontractorHoursNavigatorTDS subcontractorHoursNavigatorTDS = SubmitSearchBySubcontractor();

                // Show results
                if (subcontractorHoursNavigatorTDS.SubcontractorHoursNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["subcontractorHoursNavigatorTDS"] = subcontractorHoursNavigatorTDS;

                    // ... Go to the results page
                    Response.Redirect("./subcontractor_hours_navigator2.aspx?source_page=subcontractor_hours_navigator.aspx" + GetNavigatorState());
                }
                else
                {
                    tdNoResults.Visible = true;
                }
            }
        }



        protected void btnSearchByProject_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                SubcontractorHoursNavigatorTDS subcontractorHoursNavigatorTDS = SubmitSearchByProject();

                // Show results
                if (subcontractorHoursNavigatorTDS.SubcontractorHoursNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["subcontractorHoursNavigatorTDS"] = subcontractorHoursNavigatorTDS;

                    // ... Go to the results page
                    Response.Redirect("./subcontractor_hours_navigator2.aspx?source_page=subcontractor_hours_navigator.aspx" + GetNavigatorState());
                }
                else
                {
                    tdNoResults.Visible = true;
                }
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm7 master = (mForm7)this.Master;
            master.ActiveToolbar = "LabourHours";
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectList projectList = new ProjectList();
            projectList.LoadProjectsAndAddItem(-1, "(All)", int.Parse(ddlClient.SelectedValue));
            ddlProject.DataSource = projectList.Table;
            ddlProject.DataValueField = "ProjectID";
            ddlProject.DataTextField = "Name";
            ddlProject.DataBind();
            ddlProject.SelectedIndex = 0;
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mAddHoursBySubcontractor":
                    url = "./../../LabourHours/SubcontractorHours/subcontractor_hours_add_by_subcontractor.aspx?source_page=lm" + GetNavigatorState();
                    Response.Redirect(url);
                    break;

                case "mAddHoursByClientProject":
                    url = "./../../LabourHours/SubcontractorHours/subcontractor_hours_add_by_client_project.aspx?source_page=lm" + GetNavigatorState();
                    Response.Redirect(url);
                    break;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./subcontractor_hours_navigator.js");
        }



        private void RestoreNavigatorState()
        {
            // Search condition 1
            // ... For Condition 
            // ...  for the client
            int companyId = Int32.Parse(hdfCompanyId.Value);
            CompaniesList companiesList = new CompaniesList(new DataSet());
            companiesList.LoadAndAddItem(-1, "(All)", companyId);
            ddlClient.DataSource = companiesList.Table;
            ddlClient.DataValueField = "COMPANIES_ID";
            ddlClient.DataTextField = "NAME";
            ddlClient.DataBind();
            //ddlClient.SelectedIndex = 0;
            ddlClient.SelectedValue = Request.QueryString["search_ddlClient"];

            int clientId = -1;
            if (Request.QueryString["search_ddlClient"] != "" && Request.QueryString["search_ddlClient"] != null)
            {
                clientId = Int32.Parse(Request.QueryString["search_ddlClient"].ToString());
            }

            // ... for project
            ProjectList projectList = new ProjectList();
            projectList.LoadProjectsAndAddItem(-1, "(All)", clientId);
            ddlProject.DataSource = projectList.Table;
            ddlProject.DataValueField = "ProjectID";
            ddlProject.DataTextField = "Name";
            ddlProject.DataBind();
            //ddlProject.SelectedIndex = 0;
            ddlProject.SelectedValue = Request.QueryString["search_ddlProject"];

            // Search condition 1
            // ... For Condition 
            odsSubcontractorsList.DataBind();
            ddlSubcontractor.DataSourceID = "odsSubcontractorsList";
            ddlSubcontractor.DataValueField = "SubcontractorID";
            ddlSubcontractor.DataTextField = "Name";
            ddlSubcontractor.DataBind();
            ddlSubcontractor.SelectedValue = Request.QueryString["search_ddlSubcontractor"];

            //Other values
            //... For SortBy
            ddlSortBy.SelectedValue = Request.QueryString["search_sort_by"];

            if (!String.IsNullOrEmpty(Request.QueryString["search_tkrdpStartDate"].ToString()))
            {
                tkrdpStartDate.SelectedDate = DateTime.Parse(Request.QueryString["search_tkrdpStartDate"]);
            }

            if (!String.IsNullOrEmpty(Request.QueryString["search_tkrdpEndDate"].ToString()))
            {
                tkrdpEndDate.SelectedDate = DateTime.Parse(Request.QueryString["search_tkrdpEndDate"]);
            }

            if (!String.IsNullOrEmpty(Request.QueryString["search_cbxFilterByDateSelected"].ToString()))
            {
                cbxFilterByRangeOfDates.Checked = Convert.ToBoolean(Request.QueryString["search_cbxFilterByDateSelected"]);
            }
        }



        private string GetNavigatorState()
        {
            // SearchOptions for condition 1
            string searchOptions = "";
            searchOptions = searchOptions + "&search_ddlClient=" + ddlClient.SelectedValue;
            searchOptions = searchOptions + "&search_ddlProject=" + ddlProject.SelectedValue;
            searchOptions = searchOptions + "&search_ddlSubcontractor=" + ddlSubcontractor.SelectedValue;
            searchOptions = searchOptions + "&search_sort_by=" + ddlSortBy.SelectedValue;
            searchOptions = searchOptions + "&search_tkrdpStartDate=" + tkrdpStartDate.SelectedDate;
            searchOptions = searchOptions + "&search_tkrdpEndDate=" + tkrdpEndDate.SelectedDate;
            searchOptions = searchOptions + "&search_cbxFilterByDateSelected=" + cbxFilterByRangeOfDates.Checked.ToString();

            // Return
            return searchOptions;
        }



        private SubcontractorHoursNavigatorTDS SubmitSearchBySubcontractor()
        {
            // Retrieve clauses
            int subcontractorId = Convert.ToInt32(ddlSubcontractor.SelectedValue);

            string whereClause = GetWhereClauseBySubcontractor(subcontractorId);
            string orderByClause = GetOrderByClause();
            
            SubcontractorHoursNavigator subcontractorHoursNavigator = new SubcontractorHoursNavigator();

            subcontractorHoursNavigator.Load(whereClause, orderByClause);

            return (SubcontractorHoursNavigatorTDS)subcontractorHoursNavigator.Data;
        }



        private SubcontractorHoursNavigatorTDS SubmitSearchByProject()
        {
            // Retrieve clauses
            int projectId = Convert.ToInt32(ddlProject.SelectedValue);

            string whereClause = GetWhereClauseByProject(projectId);
            string orderByClause = GetOrderByClause();
            
            SubcontractorHoursNavigator subcontractorHoursNavigator = new SubcontractorHoursNavigator();

            subcontractorHoursNavigator.Load(whereClause, orderByClause);

            return (SubcontractorHoursNavigatorTDS)subcontractorHoursNavigator.Data;
        }



        private string GetWhereClauseBySubcontractor(int subcontractorId)
        {
            // General conditions
            string whereClause = "(SC.Deleted = 0) AND (S.Deleted = 0) ";

            // Subcontractor selected
            if (subcontractorId != -1)
            {
                whereClause = whereClause + "AND (SC.SubcontractorID = " + subcontractorId + ")";
            }

            if (cbxFilterByRangeOfDates.Checked)
            {
                whereClause = whereClause + string.Format(" AND SC.Date >= '{0}' AND SC.Date <= '{1}'", tkrdpStartDate.SelectedDate.Value.ToShortDateString(), tkrdpEndDate.SelectedDate.Value.ToShortDateString());
            }

            return whereClause;
        }



        private string GetWhereClauseByProject(int projectId)
        {
            // General conditions
            string whereClause = "(SC.Deleted = 0) AND (S.Deleted = 0) ";

            // Client selected
            if (Int32.Parse(ddlClient.SelectedValue) != -1)
            {
                whereClause = whereClause + " AND (P.ClientID = " + ddlClient.SelectedValue + ") ";
            }

            // Project selected
            if (projectId != -1)
            {
                whereClause = whereClause + " AND (SC.ProjectID = " + projectId + ") ";
            }

            if (cbxFilterByRangeOfDates.Checked)
            {
                whereClause = whereClause + string.Format(" AND SC.Date >= '{0}' AND SC.Date <= '{1}'", tkrdpStartDate.SelectedDate.Value.ToShortDateString(), tkrdpEndDate.SelectedDate.Value.ToShortDateString());
            }

            return whereClause;
        }



        private string GetOrderByClause()
        {
            // Get order by clause
            string orderBy = "";

            switch (ddlSortBy.SelectedItem.Text)
            {
                case "Date":
                    orderBy = " SC.Date ASC";
                    break;

                case "Subcontractor":
                    orderBy = " S.Name ASC";
                    break;

                case "Client":
                    orderBy = " C.Name ASC";
                    break;

                case "Project":
                    orderBy = " P.Name ASC";
                    break;
            }

            return orderBy;
        }




    }
}