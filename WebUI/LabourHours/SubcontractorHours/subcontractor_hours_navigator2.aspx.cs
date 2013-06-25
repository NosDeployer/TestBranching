using System;
using System.Data;
using System.Web.UI;
using LiquiForce.LFSLive.BL.LabourHours.SubcontractorHours;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.BL.RAF;
using LiquiForce.LFSLive.DA.LabourHours.SubcontractorHours;
using Telerik.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.DA.Projects.Projects;
using System.Text;

namespace LiquiForce.LFSLive.WebUI.LabourHours.SubcontractorHours
{
    /// <summary>
    /// subcontractor_hours_navigator2
    /// </summary>
    public partial class subcontractor_hours_navigator2 : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected SubcontractorHoursNavigatorTDS subcontractorHoursNavigatorTDS;
        protected SubcontractorHoursNavigatorTDS.SubcontractorHoursNavigatorDataTable subcontractorHoursNavigator;






        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
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

                Session.Remove("subcontractorHoursNavigatorNewDummy");

                RestoreNavigatorState();
                
                // If coming from 
                // ... subcontractor_hours_navigator.aspx or subcontractor_hours_navigator2.aspx
                if ((Request.QueryString["source_page"] == "subcontractor_hours_navigator.aspx") || (Request.QueryString["source_page"] == "subcontractor_hours_navigator2.aspx"))
                {                    
                    subcontractorHoursNavigatorTDS = (SubcontractorHoursNavigatorTDS)Session["subcontractorHoursNavigatorTDS"];
                }

                // ... subcontractor_hours_edit.aspx, subcontractor_hours_summary.aspx or subcontractor_hours_delete.aspx
                if ((Request.QueryString["source_page"] == "subcontractor_hours_edit.aspx") || (Request.QueryString["source_page"] == "subcontractor_hours_summary.aspx") || (Request.QueryString["source_page"] == "subcontractor_hours_delete.aspx"))
                {
                    RestoreNavigatorState();

                    if (Request.QueryString["update"] == "no")
                    {
                        subcontractorHoursNavigatorTDS = (SubcontractorHoursNavigatorTDS)Session["subcontractorHoursNavigatorTDS"];
                    }
                    else
                    {
                        // ... Delete store data
                        Session.Contents.Remove("subcontractorHoursNavigatorTDS");

                        // ... Search data with updates                        
                        subcontractorHoursNavigatorTDS = SubmitSearchBySubcontractor();

                        // ... store datasets
                        Session["subcontractorHoursNavigatorTDS"] = subcontractorHoursNavigatorTDS;
                    }
                }

                Session["subcontractorHoursNavigatorTDS"] = subcontractorHoursNavigatorTDS;
                Session["subcontractorHoursNavigator"] = subcontractorHoursNavigatorTDS.SubcontractorHoursNavigator;

                // ... for the total rows
                if (subcontractorHoursNavigatorTDS.SubcontractorHoursNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + subcontractorHoursNavigatorTDS.SubcontractorHoursNavigator.Rows.Count;
                    lblTotalRows.Visible = true;
                }
                else
                {
                    lblTotalRows.Visible = false;
                }
            }
            else
            {
                // Restore searched data (if any)
                subcontractorHoursNavigatorTDS = (SubcontractorHoursNavigatorTDS)Session["subcontractorHoursNavigatorTDS"];
                subcontractorHoursNavigator = subcontractorHoursNavigatorTDS.SubcontractorHoursNavigator;

                // ... for the total rows
                if (subcontractorHoursNavigatorTDS.SubcontractorHoursNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + subcontractorHoursNavigatorTDS.SubcontractorHoursNavigator.Rows.Count;
                    lblTotalRows.Visible = true;
                }
                else
                {
                    lblTotalRows.Visible = false;
                }
            }
        }



        protected void btnSearchBySubcontractor_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                // Tag Page
                string url = "";

                // Delete store data
                Session.Contents.Remove("subcontractorHoursNavigatorTDS");

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
                    // ... Go to the search page
                    url = "./subcontractor_hours_navigator.aspx?source_page=subcontractor_hours_navigator2.aspx" + GetNavigatorState() + "&no_results=yes";
                    Response.Redirect(url);
                }
            }
        }



        protected void btnSearchByProject_Click(object sender, EventArgs e)
        {
            Page.Validate();

            if (Page.IsValid)
            {
                // Tag Page
                string url = "";

                // Delete store data
                Session.Contents.Remove("subcontractorHoursNavigatorTDS");

                SubcontractorHoursNavigatorTDS subcontractorHoursNavigatorTDS = SubmitSearchByProject();

                // Show results
                if (subcontractorHoursNavigatorTDS.SubcontractorHoursNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["subcontractorHoursNavigatorTDS"] = subcontractorHoursNavigatorTDS;

                    // ... Go to the results page
                    Response.Redirect("./subcontractor_hours_navigator2.aspx?source_page=subcontractor_hours_navigator2.aspx" + GetNavigatorState());
                }
                else
                {
                    // ... Go to the search page
                    url = "./subcontractor_hours_navigator.aspx?source_page=subcontractor_hours_navigator2.aspx" + GetNavigatorState() + "&no_results=yes";
                    Response.Redirect(url);
                }
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm7 master = (mForm7)this.Master;
            master.ActiveToolbar = "LabourHours";

            SetFilterByDate();
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



        protected void grdNavigator_DataBound(object sender, EventArgs e)
        {
            AddNewEmptyFix(grdNavigator);
        }



        protected void grdNavigator_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Normal rows
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int projectId = Int32.Parse(((Label)e.Row.FindControl("lblProjectID")).Text);

                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(projectId);

                if (projectGateway.GetCountryID(projectId) == 1) //Canada
                {
                    ((Label)e.Row.FindControl("lblRateUsd")).Text = ((Label)e.Row.FindControl("lblRateCad")).Text;
                    ((Label)e.Row.FindControl("lblTotalUsd")).Text = ((Label)e.Row.FindControl("lblTotalCad")).Text;
                }
                else
                {
                    ((Label)e.Row.FindControl("lblRateCad")).Text = ((Label)e.Row.FindControl("lblRateUsd")).Text;
                    ((Label)e.Row.FindControl("lblTotalCad")).Text = ((Label)e.Row.FindControl("lblTotalUsd")).Text;

                    //((Label)e.Row.FindControl("lblRateCad")).Visible = false;
                    //((Label)e.Row.FindControl("lblTotalCad")).Visible = false;
                    //((Label)e.Row.FindControl("lblRateUsd")).Visible = true;
                    //((Label)e.Row.FindControl("lblTotalUsd")).Visible = true;
                }
            }
        }



        protected void grdNavigator_Sorting(object sender, GridViewSortEventArgs e)
        {
            string oldSort = subcontractorHoursNavigatorTDS.SubcontractorHoursNavigator.DefaultView.Sort;

            if (!oldSort.Contains(e.SortExpression.ToString()))
            {
                subcontractorHoursNavigatorTDS.SubcontractorHoursNavigator.DefaultView.Sort = e.SortExpression + " ASC";
            }
            else
            {
                if (oldSort.Contains("ASC"))
                {
                    subcontractorHoursNavigatorTDS.SubcontractorHoursNavigator.DefaultView.Sort = e.SortExpression + " DESC";
                }
                else
                {
                    subcontractorHoursNavigatorTDS.SubcontractorHoursNavigator.DefaultView.Sort = e.SortExpression + " ASC";
                }
            }

            // Store data
            Session["subcontractorHoursNavigatorTDS"] = subcontractorHoursNavigatorTDS;
            Session["subcontractorHoursNavigator"] = subcontractorHoursNavigatorTDS.SubcontractorHoursNavigator;
        }



        protected void tkrdpStartDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (!tkrdpEndDate.SelectedDate.HasValue)
            {
                tkrdpEndDate.SelectedDate = tkrdpStartDate.SelectedDate;
                upnlEndDate.Update();
            }

            SetFilterByDate();
        }



        protected void tkrdpEndDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (!tkrdpStartDate.SelectedDate.HasValue)
            {
                tkrdpStartDate.SelectedDate = tkrdpEndDate.SelectedDate;
                upnlStartDate.Update();
            }

            SetFilterByDate();
        }



        private void ApplyFilter()
        {
            odsNavigator.FilterExpression = (string)ViewState["filter_expression"];
            grdNavigator.DataBind();
        }



        protected void SetFilterByDate()
        {
            StringBuilder filterExpression = new StringBuilder();

            if (cbxFilterByRangeOfDates.Checked)
            {
                if (tkrdpStartDate.SelectedDate.HasValue)
                {
                    filterExpression.Append(string.Format(" Date >= '{0}' AND Date <= '{1}'", tkrdpStartDate.SelectedDate.Value.ToShortDateString(), tkrdpEndDate.SelectedDate.Value.ToShortDateString()));
                }

                ViewState["filter_expression"] = filterExpression.ToString();

                ApplyFilter();
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnOpen_Click(object sender, EventArgs e)
        {
            PostPageChanges();

            int projectId = 0;
            int refId = 0;

            foreach (SubcontractorHoursNavigatorTDS.SubcontractorHoursNavigatorRow subcontractorHoursNavigatorRow in subcontractorHoursNavigatorTDS.SubcontractorHoursNavigator)
            {
                if (subcontractorHoursNavigatorRow.Selected)
                {
                    projectId = subcontractorHoursNavigatorRow.ProjectID;
                    refId = subcontractorHoursNavigatorRow.RefID;                   
                }
            }

            if ((projectId > 0) && (refId > 0))
            {
                // Redirect
                string url = "./subcontractor_hours_summary.aspx?source_page=subcontractor_hours_navigator2.aspx&project_id=" + projectId + "&ref_id=" + refId + GetNavigatorState();
                Response.Redirect(url);
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
            }
        }



        protected void btnEdit_Click(object sender, EventArgs e)
        {
            PostPageChanges();

            int projectId = 0;
            int refId = 0;

            foreach (SubcontractorHoursNavigatorTDS.SubcontractorHoursNavigatorRow subcontractorHoursNavigatorRow in subcontractorHoursNavigatorTDS.SubcontractorHoursNavigator)
            {
                if (subcontractorHoursNavigatorRow.Selected)
                {
                    projectId = subcontractorHoursNavigatorRow.ProjectID;
                    refId = subcontractorHoursNavigatorRow.RefID;
                }
            }

            if ((projectId > 0) && (refId > 0))
            {
                // Redirect
                string url = "./subcontractor_hours_edit.aspx?source_page=subcontractor_hours_navigator2.aspx&project_id=" + projectId + "&ref_id=" + refId + GetNavigatorState();
                Response.Redirect(url);
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
            }
        }



        protected void btnPreviewList_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'> {window.open('./subcontractor_hours_print_search_results_report.aspx?format=pdf', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
        }



        protected void btnExportList_Click(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'> {window.open('./subcontractor_hours_print_search_results_report.aspx?format=excel', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            PostPageChanges();

            int projectId = 0;
            int refId = 0;

            foreach (SubcontractorHoursNavigatorTDS.SubcontractorHoursNavigatorRow subcontractorHoursNavigatorRow in subcontractorHoursNavigatorTDS.SubcontractorHoursNavigator)
            {
                if (subcontractorHoursNavigatorRow.Selected)
                {
                    projectId = subcontractorHoursNavigatorRow.ProjectID;
                    refId = subcontractorHoursNavigatorRow.RefID;
                }
            }

            if ((projectId > 0) && (refId > 0))
            {
                // Redirect
                string url = "./subcontractor_hours_delete.aspx?source_page=subcontractor_hours_navigator2.aspx&project_id=" + projectId + "&ref_id=" + refId + GetNavigatorState();
                Response.Redirect(url);
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
            }
        }



        protected void btnClearSearch_Click(object sender, EventArgs e)
        {
            string url = "./subcontractor_hours_navigator.aspx?source_page=lm";

            if (url != "") Response.Redirect(url);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        public SubcontractorHoursNavigatorTDS.SubcontractorHoursNavigatorDataTable GetNavigator()
        {
            subcontractorHoursNavigator = (SubcontractorHoursNavigatorTDS.SubcontractorHoursNavigatorDataTable)Session["subcontractorHoursNavigatorNewDummy"];
            if (subcontractorHoursNavigator == null)
            {
                subcontractorHoursNavigator = ((SubcontractorHoursNavigatorTDS.SubcontractorHoursNavigatorDataTable)Session["subcontractorHoursNavigator"]);
            }

            return subcontractorHoursNavigator;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./subcontractor_hours_navigator2.js");
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
                whereClause = whereClause + " AND (SC.ProjectID = " + projectId + ") AND (P.ClientID = " + ddlClient.SelectedValue + ") ";
            }

            if (cbxFilterByRangeOfDates.Checked)
            {
                whereClause = whereClause + string.Format(" AND SC.Date >= '{0}' AND SC.Date <= '{1}'", tkrdpStartDate.SelectedDate.Value.ToShortDateString(), tkrdpEndDate.SelectedDate.Value.ToShortDateString());
            }

            return whereClause;
        }



        protected string GetRound(object value, int decimals)
        {
            if (value != DBNull.Value)
            {
                if (decimals == 2)
                {
                    return string.Format("{0:0.00}", Convert.ToDecimal(value));
                }
                else
                {
                    return string.Format("{0:0.0}", Convert.ToDecimal(value));
                }
            }
            else
            {
                return "";
            }
        }



        protected void AddNewEmptyFix(GridView grdNavigator)
        {
            if (grdNavigator.Rows.Count == 0)
            {
                SubcontractorHoursNavigatorTDS.SubcontractorHoursNavigatorDataTable dt = new SubcontractorHoursNavigatorTDS.SubcontractorHoursNavigatorDataTable();
                dt.AddSubcontractorHoursNavigatorRow(0, 0, 0, DateTime.Now, "", "", "", 0, 0, 0, 0, 0, false, false);
                Session["subcontractorHoursNavigatorNewDummy"] = dt;

                grdNavigator.DataBind();
            }

            // normally executes at all postbacks
            if (grdNavigator.Rows.Count == 1)
            {
                SubcontractorHoursNavigatorTDS.SubcontractorHoursNavigatorDataTable dt = (SubcontractorHoursNavigatorTDS.SubcontractorHoursNavigatorDataTable)Session["subcontractorHoursNavigatorNewDummy"];
                if (dt != null)
                {
                    grdNavigator.Rows[0].Visible = false;
                    grdNavigator.Rows[0].Controls.Clear();
                }
            }
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



        private void PostPageChanges()
        {
            SubcontractorHoursNavigator subcontractorHoursNavigator = new SubcontractorHoursNavigator(subcontractorHoursNavigatorTDS);

            // Update 
            foreach (GridViewRow row in grdNavigator.Rows)
            {
                if (((CheckBox)row.FindControl("cbxSelected")).Checked)
                {
                    int subcontractorId = Int32.Parse(((Label)row.FindControl("lblSubcontractorID")).Text.Trim());
                    int projectId = Int32.Parse(((Label)row.FindControl("lblProjectID")).Text.Trim());
                    int refId = Int32.Parse(((Label)row.FindControl("lblRefIDID")).Text.Trim());
                    bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                    subcontractorHoursNavigator.Update(subcontractorId, projectId, refId, selected);
                }
            }

            subcontractorHoursNavigator.Data.AcceptChanges();

            // Store datasets
            Session["subcontractorHoursNavigatorTDS"] = subcontractorHoursNavigatorTDS;
        }



        protected void cbxFilterByRangeOfDates_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxFilterByRangeOfDates.Checked)
            {
                SetFilterByDate();
            }
        }

        

    }
}