using System;
using System.Web.UI;
using LiquiForce.LFSLive.BL.Projects.Revenue;
using LiquiForce.LFSLive.DA.Projects.Revenue;

namespace LiquiForce.LFSLive.WebUI.Projects.Revenue
{
    /// <summary>
    /// revenue_navigator
    /// </summary>
    public partial class revenue_navigator : System.Web.UI.Page
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
                // Security check
                if (!(Convert.ToBoolean(Session["sgLFS_PROJECTS_REVENUE_VIEW"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in revenue_navigator.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();

                // Prepare initial data                                  
                // If coming from 

                // ... Left Menu or out
                if ((Request.QueryString["source_page"] == "lm") || (Request.QueryString["source_page"] == "out"))
                {
                    tdNoResults.Visible = false;
                }

                // ... revenue_navigator2.aspx
                if (Request.QueryString["source_page"] == "revenue_navigator2.aspx")
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
        


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Page.Validate();
            
            if (Page.IsValid)
            {
                RevenueNavigatorTDS revenueNavigatorTDS = SubmitSearch();

                //Show results
                if (revenueNavigatorTDS.RevenueNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["revenueNavigatorTDS"] = revenueNavigatorTDS;

                    // ... Go to the results page
                    Response.Redirect("./revenue_navigator2.aspx?source_page=revenue_navigator.aspx&" + GetNavigatorState());
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
            master.ActiveToolbar = "Projects";           
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

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
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./revenue_navigator.js");
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
            return searchOptions;
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
                orderBy = "LPR.Date DESC";
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


    }
}