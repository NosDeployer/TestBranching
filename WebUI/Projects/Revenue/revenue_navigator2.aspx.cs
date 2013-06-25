using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.Projects.Revenue;
using LiquiForce.LFSLive.DA.Projects.Revenue;

namespace LiquiForce.LFSLive.WebUI.Projects.Revenue
{
    /// <summary>
    /// revenue_navigator2
    /// </summary>
    public partial class revenue_navigator2 : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected RevenueNavigatorTDS revenueNavigatorTDS;
        protected RevenueNavigatorTDS.RevenueNavigatorDataTable revenueNavigator;






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
                if (!(Convert.ToBoolean(Session["sgLFS_PROJECTS_REVENUE_VIEW"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in revenue_navigator2.aspx");
                }
                
                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                Session.Remove("revenueNavigatorNewDummy");                
                
                // If coming from 
                // ... revenue_navigator.aspx or revenue_navigator2.aspx
                if ((Request.QueryString["source_page"] == "revenue_navigator.aspx") || (Request.QueryString["source_page"] == "revenue_navigator2.aspx"))
                {
                    RestoreNavigatorState();
                    revenueNavigatorTDS = (RevenueNavigatorTDS)Session["revenueNavigatorTDS"];
                }

                // ... revenue_edit.aspx, revenue_summary.aspx or revenue_delete.aspx
                if ((Request.QueryString["source_page"] == "revenue_edit.aspx") || (Request.QueryString["source_page"] == "revenue_summary.aspx") || (Request.QueryString["source_page"] == "revenue_delete.aspx"))
                {
                    RestoreNavigatorState();

                    if (Request.QueryString["update"] == "no")
                    {
                        revenueNavigatorTDS = (RevenueNavigatorTDS)Session["revenueNavigatorTDS"];
                    }
                    else
                    {
                        // ... Delete store data
                        Session.Contents.Remove("revenueNavigatorTDS");

                        // ... Search data with updates                        
                        revenueNavigatorTDS = SubmitSearch();                        

                        // ... store datasets
                        Session["revenueNavigatorTDS"] = revenueNavigatorTDS;
                    }
                }

                // ... revenue_delete.aspx, revenue_summary.aspx or revenue_edit.aspx
                if ((Request.QueryString["source_page"] == "revenue_delete.aspx") || (Request.QueryString["source_page"] == "revenue_summary.aspx") || (Request.QueryString["source_page"] == "revenue_edit.aspx"))
                {
                    if (revenueNavigatorTDS.RevenueNavigator.Rows.Count == 0)
                    {
                        string url = "./revenue_navigator.aspx?source_page=revenue_navigator2.aspx" + GetNavigatorState() + "&no_results=yes";

                        Response.Redirect(url);
                    }
                }

                Session["revenueNavigatorTDS"] = revenueNavigatorTDS;
                Session["revenueNavigator"] = revenueNavigatorTDS.RevenueNavigator;

                // ... for the total rows
                if (revenueNavigatorTDS.RevenueNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + revenueNavigatorTDS.RevenueNavigator.Rows.Count;
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
                revenueNavigatorTDS = (RevenueNavigatorTDS)Session["revenueNavigatorTDS"];
                revenueNavigator = revenueNavigatorTDS.RevenueNavigator;

                // ... for the total rows
                if (revenueNavigatorTDS.RevenueNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + revenueNavigatorTDS.RevenueNavigator.Rows.Count;
                    lblTotalRows.Visible = true;
                }
                else
                {
                    lblTotalRows.Visible = false;
                }                     
            }
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // Tag Page
                string url = "";

                // Delete store data
                Session.Contents.Remove("revenueNavigatorTDS");

                // Get data from DA gateway
                revenueNavigatorTDS = SubmitSearch();

                // Show results
                if (revenueNavigatorTDS.RevenueNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["revenueNavigatorTDS"] = revenueNavigatorTDS;

                    // ... Go to the results page
                    url = "./revenue_navigator2.aspx?source_page=revenue_navigator2.aspx"+ GetNavigatorState();
                }
                else
                {
                    // ... Go to the search page
                    url = "./revenue_navigator.aspx?source_page=revenue_navigator2.aspx" + GetNavigatorState() + "&no_results=yes";
                }

                Response.Redirect(url);
            }
        }                  



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm7 master = (mForm7)this.Master;
            master.ActiveToolbar = "Projects";                                  
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //       



        protected void grdNavigator_DataBound(object sender, EventArgs e)
        {
            AddNewEmptyFix(grdNavigator);
        }



        protected void grdNavigator_Sorting(object sender, GridViewSortEventArgs e)
        {
            string oldSort = revenueNavigatorTDS.RevenueNavigator.DefaultView.Sort;

            if (!oldSort.Contains(e.SortExpression.ToString()))
            {
                revenueNavigatorTDS.RevenueNavigator.DefaultView.Sort = e.SortExpression + " ASC";
            }
            else
            {
                if (oldSort.Contains("ASC"))
                {
                    revenueNavigatorTDS.RevenueNavigator.DefaultView.Sort = e.SortExpression + " DESC";
                }
                else
                {
                    revenueNavigatorTDS.RevenueNavigator.DefaultView.Sort = e.SortExpression + " ASC";
                }
            }

            // Store data
            Session["revenueNavigatorTDS"] = revenueNavigatorTDS;
            Session["revenueNavigator"] = revenueNavigatorTDS.RevenueNavigator;
        }



        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            odsProject.SelectParameters.RemoveAt(2);
            odsProject.SelectParameters.Add("clientId", ddlClient.SelectedValue);
            odsProject.Select();
            ddlProject.DataBind();
            ddlProject.SelectedIndex = 0;
            upnlProject.Update();
        }









        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnOpen_Click(object sender, EventArgs e)
        {
            PostPageChanges();

            foreach (RevenueNavigatorTDS.RevenueNavigatorRow revenueNavigatorRow in revenueNavigatorTDS.RevenueNavigator)
            {
                if (revenueNavigatorRow.Selected)
                {
                    // Redirect
                    string url = "./revenue_summary.aspx?source_page=revenue_navigator2.aspx&project_id=" + revenueNavigatorRow.ProjectID.ToString() + "&ref_id=" + revenueNavigatorRow.RefID.ToString() + GetNavigatorState();
                    Response.Redirect(url);
                }
                else
                {
                    RestoreNavigatorState();
                    cvSelection.IsValid = false;
                }
            }                        
        }



        protected void btnEdit_Click(object sender, EventArgs e)
        {
            PostPageChanges();

            foreach (RevenueNavigatorTDS.RevenueNavigatorRow revenueNavigatorRow in revenueNavigatorTDS.RevenueNavigator)
            {
                if (revenueNavigatorRow.Selected)
                {
                    // Redirect
                    string url = "./revenue_edit.aspx?source_page=revenue_navigator2.aspx&project_id=" + revenueNavigatorRow.ProjectID.ToString() + "&ref_id=" + revenueNavigatorRow.RefID.ToString() + GetNavigatorState();
                    Response.Redirect(url);
                }
                else
                {
                    RestoreNavigatorState();
                    cvSelection.IsValid = false;
                }
            }            
        }



        protected void btnPreviewList_Click(object sender, EventArgs e)
        {
            string url = "";

            string headerValues = "";
            int totalColumnsExport = 5;
            int totalColumnsPreview = 4;
            string title = "Revenue Results";

            // ... For comments option
            string comments = "None";

            // Establishing header values                        
            if (grdNavigator.Columns[3].Visible) headerValues += "Date";
            if (grdNavigator.Columns[4].Visible) headerValues += " * Client";
            if (grdNavigator.Columns[5].Visible) headerValues += " * Project";
            if (grdNavigator.Columns[6].Visible) headerValues += " * Revenue";

            // Establishing columns to display
            string[] columns = headerValues.Split('*');
            string columnsForReport = "";
            int j;

            // ... for visible columns
            for (int i = 0; i < columns.Length; i++)
            {
                j = i + 1;
                columnsForReport += "&header" + j + "=" + columns[i].Trim();
            }

            // ... For not visible columns
            for (int i = columns.Length; i < totalColumnsPreview; i++)
            {
                j = i + 1;
                columnsForReport += "&header" + j + "=None";
            }

            if (grdNavigator.Columns[7].Visible) comments = "Comment";

            // Report call
            Page.Validate();
            if (Page.IsValid)
            {
                PostPageChanges();
                title = title.Replace("'", "%27");
                Response.Write("<script language='javascript'> {window.open('./revenue_print_search_results_report.aspx?" + columnsForReport + "&comments=" + comments + "&totalColumnsPreview=" + totalColumnsPreview + "&totalColumnsExport=" + totalColumnsExport + "&totalSelectedColumns=" + columns.Length + "&title=" + title + "&format=pdf', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
            }              

            if (url != "") Response.Redirect(url);
        }
       


        protected void btnExportList_Click(object sender, EventArgs e)
        {
            string url = "";
            string headerValues = "";
            int totalColumnsExport = 5;
            int totalColumnsPreview = 4;
            string title = "Revenue Results";
            string columnsForReport = "";
            int j;

            // ... For comments option
            string comments = "None";

            headerValues = "";
            columnsForReport = "";

            //// Establishing header values                        
            if (grdNavigator.Columns[3].Visible) headerValues += "Date";
            if (grdNavigator.Columns[4].Visible) headerValues += " * Client";
            if (grdNavigator.Columns[5].Visible) headerValues += " * Project";
            if (grdNavigator.Columns[6].Visible) headerValues += " * Revenue";
            if (grdNavigator.Columns[7].Visible) headerValues += " * Comment";

            // Establishing columns to display
            string[] columnsExcel = headerValues.Split('*');

            // ... for visible columns
            for (int i = 0; i < columnsExcel.Length; i++)
            {
                j = i + 1;
                columnsForReport += "&header" + j + "=" + columnsExcel[i].Trim();
            }

            // ... For not visible columns
            for (int i = columnsExcel.Length; i < totalColumnsExport; i++)
            {
                j = i + 1;
                columnsForReport += "&header" + j + "=None";
            }            

            // Report call
            Page.Validate();
            if (Page.IsValid)
            {
                PostPageChanges();
                title = title.Replace("'", "%27");
                Response.Write("<script language='javascript'> {window.open('./revenue_print_search_results_report.aspx?" + columnsForReport + "&comments=" + comments + "&totalColumnsPreview=" + totalColumnsPreview + "&totalColumnsExport=" + totalColumnsExport + "&totalSelectedColumns=" + columnsExcel.Length + "&title=" + title + "&format=excel', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
            }

            if (url != "") Response.Redirect(url);
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            PostPageChanges();

            foreach (RevenueNavigatorTDS.RevenueNavigatorRow revenueNavigatorRow in revenueNavigatorTDS.RevenueNavigator)
            {
                if (revenueNavigatorRow.Selected)
                {               
                    // Redirect
                    string url = "./revenue_delete.aspx?source_page=revenue_navigator2.aspx&project_id=" + revenueNavigatorRow.ProjectID.ToString() + "&ref_id=" + revenueNavigatorRow.RefID.ToString() + GetNavigatorState();
                    Response.Redirect(url);
                }
                else
                {
                    RestoreNavigatorState();
                    cvSelection.IsValid = false;                
                }
            }
        }



        protected void btnClearSearch_Click(object sender, EventArgs e)
        {
            string url = "./revenue_navigator.aspx?source_page=lm";

            if (url != "") Response.Redirect(url);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        public RevenueNavigatorTDS.RevenueNavigatorDataTable GetNavigator()
        {
            revenueNavigator = (RevenueNavigatorTDS.RevenueNavigatorDataTable)Session["revenueNavigatorNewDummy"];
            if (revenueNavigator == null)
            {
                revenueNavigator = ((RevenueNavigatorTDS.RevenueNavigatorDataTable)Session["revenueNavigator"]);
            }

            return revenueNavigator;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./revenue_navigator2.js");
        }



        private void RestoreNavigatorState()
        {            
            // Search conditions
            // ... For Client 
            odsClient.DataBind();
            ddlClient.DataSourceID = "odsClient";
            ddlClient.DataValueField = "COMPANIES_ID";
            ddlClient.DataTextField = "Name";
            ddlClient.DataBind();
            ddlClient.SelectedValue = Request.QueryString["search_client"];
            
            //... For Project
            odsProject.SelectParameters.RemoveAt(2);
            odsProject.SelectParameters.Add("clientId", ddlClient.SelectedValue);
            odsProject.Select();
            ddlProject.DataBind();
            upnlProject.Update();
            ddlProject.SelectedValue = Request.QueryString["search_project"];

            //... For Country
            odsCountry.DataBind();
            ddlCountry.DataSourceID = "odsCountry";
            ddlCountry.DataValueField = "countryId";
            ddlCountry.DataTextField = "Name";
            ddlCountry.DataBind();
            ddlCountry.SelectedValue = Request.QueryString["search_country_id"];
            
            //... For sort by            
            ddlSortBy.SelectedValue = Request.QueryString["search_sort_by"];

            // ... For startDate
            tkrdpStartDate.SelectedDate = null;
            string startDate = Request.QueryString["search_start_date"].ToString();
            if (startDate != "null")
            {
                tkrdpStartDate.SelectedDate = DateTime.Parse(Request.QueryString["search_start_date"]);
            }

            // ... For endDate
            tkrdpEndDate.SelectedDate = null;
            string endDate = Request.QueryString["search_end_date"].ToString();
            if (endDate != "null")
            {
                tkrdpEndDate.SelectedDate = DateTime.Parse(Request.QueryString["search_end_date"]);
            }           
        }



        private string GetNavigatorState()
        {            
            // SearchOptions for conditions
            string searchOptions = "";
            searchOptions = searchOptions + "&search_client=" + ddlClient.SelectedValue;
            searchOptions = searchOptions + "&search_project=" + ddlProject.Text.Trim();
            searchOptions = searchOptions + "&search_sort_by=" + ddlSortBy.Text.Trim();
            searchOptions = searchOptions + "&search_country_id=" + ddlCountry.Text.Trim();

            if (tkrdpStartDate.SelectedDate.HasValue)
            {
                searchOptions = searchOptions + "&search_start_date=" + tkrdpStartDate.SelectedDate;
            }
            else
            {
                searchOptions = searchOptions + "&search_start_date=null";
            }

            if (tkrdpEndDate.SelectedDate.HasValue)
            {
                searchOptions = searchOptions + "&search_end_date=" + tkrdpEndDate.SelectedDate;
            }
            else
            {
                searchOptions = searchOptions + "&search_end_date=null";
            }

            // Return
            return  searchOptions;
        }



        private RevenueNavigatorTDS SubmitSearch()
        {
            // Retrieve clauses
            string whereClause = GetWhereClause();
            string orderByClause = GetOrderByClause();

            RevenueNavigatorTDS dataSet = new RevenueNavigatorTDS();
            RevenueNavigatorGateway revenueNavigatorGateway = new RevenueNavigatorGateway(dataSet);

            //... Load data
            RevenueNavigator revenueNavigator = new RevenueNavigator(dataSet);
            revenueNavigator.Load(whereClause, orderByClause);

            return dataSet;
        }



        private string GetWhereClause()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            // General conditions            
            string whereClause = "";
            int clientId = Int32.Parse(ddlClient.SelectedValue);
            int projectId = Int32.Parse(ddlProject.SelectedValue);
            int countryId = Int32.Parse(ddlCountry.SelectedValue);

            DateTime? startTime = null;
            if (tkrdpStartDate.SelectedDate.HasValue)
            {
                startTime = (DateTime)tkrdpStartDate.SelectedDate;
            }

            DateTime? endTime = null;
            if (tkrdpEndDate.SelectedDate.HasValue)
            {
                endTime = (DateTime)tkrdpEndDate.SelectedDate;
            }

            // Search condition
            if (clientId == -1)
            {
                if (countryId == -1)
                {
                    whereClause = "(LPR.Deleted = 0) AND (LPR.COMPANY_ID = " + companyId + ") ";
                }
                else
                {
                    whereClause = "(LP.CountryID = " + countryId + ") AND (LPR.Deleted = 0) AND (LPR.COMPANY_ID = " + companyId + ") ";
                }
            }
            else
            {
                if (projectId == -1)
                {
                    if (countryId == -1)
                    {
                        whereClause = "(LPR.Deleted = 0) AND (LP.ClientID = " + clientId + " ) AND (LPR.COMPANY_ID = " + companyId + ") ";
                    }
                    else
                    {
                        whereClause = "(LP.CountryID = " + countryId + ") AND (LPR.Deleted = 0) AND (LP.ClientID = " + clientId + " ) AND (LPR.COMPANY_ID = " + companyId + ") ";
                    }
                }
                else
                {
                    if (countryId == -1)
                    {
                        whereClause = "(LPR.Deleted = 0) AND (LPR.ProjectID = " + projectId + " ) AND (LPR.COMPANY_ID = " + companyId + ") ";
                    }
                    else
                    {
                        whereClause = "(LP.CountryID = " + countryId + ") AND (LPR.Deleted = 0) AND (LPR.ProjectID = " + projectId + " ) AND (LPR.COMPANY_ID = " + companyId + ") ";
                    }
                }
            }

            // Include dates
            if ((startTime.HasValue) && (!endTime.HasValue))
            {
                whereClause = whereClause + " AND LPR.Date = '" + tkrdpStartDate.SelectedDate.Value.ToShortDateString() + "'";
            }
            else
            {
                if ((!startTime.HasValue) && (endTime.HasValue))
                {
                    whereClause = whereClause + " AND LPR.Date = '" + tkrdpEndDate.SelectedDate.Value.ToShortDateString() + "'";
                }
                else
                {
                    if ((startTime.HasValue) && (endTime.HasValue))
                    {
                        whereClause = whereClause + " AND LPR.Date >= '" + tkrdpStartDate.SelectedDate.Value.ToShortDateString() + "' AND LPR.Date <= '" + tkrdpEndDate.SelectedDate.Value.ToShortDateString() + "'";
                    }
                }
            }

            return whereClause;
        }



        private string GetOrderByClause()
        {
            // Get tableName
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string sortBy = ddlSortBy.SelectedValue;
            string orderBy = "";

            if (sortBy == "Date")
            {
                orderBy = "LPR.Date  DESC";
            }

            if (sortBy == "ClientId")
            {
                orderBy = "LC.Name";
            }

            if (sortBy == "ProjectId")
            {
                orderBy = "LP.Name";
            }

            return orderBy;
        }




        private void PostPageChanges()
        {
            RevenueNavigator revenueNavigator = new RevenueNavigator(revenueNavigatorTDS);

            // Update 
            foreach (GridViewRow row in grdNavigator.Rows)
            {
                int projectId = Int32.Parse(((Label)row.FindControl("lblProjectId")).Text.Trim());
                int refId = Int32.Parse(((Label)row.FindControl("lblRefId")).Text.Trim());
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                revenueNavigator.Update(projectId, refId, selected);
                hdfCurrentProjectId.Value = projectId.ToString();
                hdfCurrentRefId.Value = refId.ToString();
            }

            revenueNavigator.Data.AcceptChanges();

            // Store datasets
            Session["revenueNavigatorTDS"] = revenueNavigatorTDS;
        }
                   


        protected void AddNewEmptyFix(GridView grdNavigator)
        {
            if (grdNavigator.Rows.Count == 0)
            {
                RevenueNavigatorTDS.RevenueNavigatorDataTable dt = new RevenueNavigatorTDS.RevenueNavigatorDataTable();
                //dt.AddRevenueNavigatorRow(-1, -1, "", "", "", "", "", "", false, false, false, false, "", false, false, 0, 0, 0, 0, 0, 0, false, 0, 0, "", "", "", false, false, -1, -1, -1, -1, 0, "");
                Session["revenueNavigatorNewDummy"] = dt;

                grdNavigator.DataBind();
            }

            // normally executes at all postbacks
            if (grdNavigator.Rows.Count == 1)
            {
                RevenueNavigatorTDS.RevenueNavigatorDataTable dt = (RevenueNavigatorTDS.RevenueNavigatorDataTable)Session["revenueNavigatorNewDummy"];
                if (dt != null)
                {
                    grdNavigator.Rows[0].Visible = false;
                    grdNavigator.Rows[0].Controls.Clear();
                }
            }
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



    }
}