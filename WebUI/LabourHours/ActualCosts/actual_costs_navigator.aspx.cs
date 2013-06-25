using System;
using System.Data;
using System.Web.UI;
using LiquiForce.LFSLive.BL.LabourHours.ActualCosts;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.BL.Resources.Companies;
using LiquiForce.LFSLive.DA.LabourHours.ActualCosts;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts
{
    /// <summary>
    /// actual_costs_navigator
    /// </summary>
    public partial class actual_costs_navigator : System.Web.UI.Page
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
                if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_ACTUAL_COSTS_ADMIN"])))
                {
                    // Security check
                    if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_ACTUAL_COSTS_VIEW"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }

                    // Validate query string
                    if ((string)Request.QueryString["source_page"] == null)
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in actual_costs_navigator.aspx");
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
                ddlClient.DataTextField = "Name";
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

                // ... for conditions                
                ddlCategory.SelectedIndex = 0;
                tbxTextForSearch.Visible = true;
                ddlSubcontractor.Visible = false;
                ddlHotels.Visible = false;
                ddlInsurance.Visible = false;
                ddlBonding.Visible = false; 

                // If coming from 
                // ... Left Menu or out
                if ((Request.QueryString["source_page"] == "lm") || (Request.QueryString["source_page"] == "out"))
                {
                    tdNoResults.Visible = false;
                }

                // ... actual_costs_navigator2.aspx
                if (Request.QueryString["source_page"] == "actual_costs_navigator2.aspx")
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
                ActualCostsNavigatorTDS actualCostsNavigatorTDS = SubmitSearch();

                // Show results
                string category = ddlCategory.SelectedValue;

                if (category == "All")
                {
                    if ((actualCostsNavigatorTDS.SubcontractorCosts.Rows.Count > 0) || (actualCostsNavigatorTDS.HotelCosts.Rows.Count > 0) || (actualCostsNavigatorTDS.InsuranceCompaniesCosts.Rows.Count > 0) || (actualCostsNavigatorTDS.BondingCompaniesCosts.Rows.Count > 0) || (actualCostsNavigatorTDS.OtherCosts.Rows.Count > 0))
                    {
                         // ... Store data
                        Session["actualCostsNavigatorTDS"] = actualCostsNavigatorTDS;

                        // ... Go to the results page
                        Response.Redirect("./actual_costs_navigator2.aspx?source_page=actual_costs_navigator.aspx" + GetNavigatorState());
                    }
                    else
                    {
                        tdNoResults.Visible = true;
                    }                    
                }
                else
                {
                    if (category == "Subcontractors")
                    {
                        if (actualCostsNavigatorTDS.SubcontractorCosts.Rows.Count > 0)
                        {
                            // ... Store data
                            Session["actualCostsNavigatorTDS"] = actualCostsNavigatorTDS;

                            // ... Go to the results page
                            Response.Redirect("./actual_costs_navigator2.aspx?source_page=actual_costs_navigator.aspx" + GetNavigatorState());
                        }
                        else
                        {
                            tdNoResults.Visible = true;
                        }
                    }
                    else
                    {
                        if (category == "Hotel")
                        {
                            if (actualCostsNavigatorTDS.HotelCosts.Rows.Count > 0)
                            {
                                // ... Store data
                                Session["actualCostsNavigatorTDS"] = actualCostsNavigatorTDS;

                                // ... Go to the results page
                                Response.Redirect("./actual_costs_navigator2.aspx?source_page=actual_costs_navigator.aspx" + GetNavigatorState());
                            }
                            else
                            {
                                tdNoResults.Visible = true;
                            }
                        }
                        else
                        {
                            if (category == "Insurance")
                            {
                                if (actualCostsNavigatorTDS.InsuranceCompaniesCosts.Rows.Count > 0)
                                {
                                    // ... Store data
                                    Session["actualCostsNavigatorTDS"] = actualCostsNavigatorTDS;

                                    // ... Go to the results page
                                    Response.Redirect("./actual_costs_navigator2.aspx?source_page=actual_costs_navigator.aspx" + GetNavigatorState());
                                }
                                else
                                {
                                    tdNoResults.Visible = true;
                                }
                            }
                            else
                            {

                                if (category == "Bonding")
                                {
                                    if (actualCostsNavigatorTDS.BondingCompaniesCosts.Rows.Count > 0)
                                    {
                                        // ... Store data
                                        Session["actualCostsNavigatorTDS"] = actualCostsNavigatorTDS;

                                        // ... Go to the results page
                                        Response.Redirect("./actual_costs_navigator2.aspx?source_page=actual_costs_navigator.aspx" + GetNavigatorState());
                                    }
                                    else
                                    {
                                        tdNoResults.Visible = true;
                                    }
                                }
                                else
                                {
                                    if (actualCostsNavigatorTDS.OtherCosts.Rows.Count > 0)
                                    {
                                        // ... Store data
                                        Session["actualCostsNavigatorTDS"] = actualCostsNavigatorTDS;

                                        // ... Go to the results page
                                        Response.Redirect("./actual_costs_navigator2.aspx?source_page=actual_costs_navigator.aspx" + GetNavigatorState());
                                    }
                                    else
                                    {
                                        tdNoResults.Visible = true;
                                    }
                                }                            
                            }
                        }
                    }
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



        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((ddlCategory.SelectedValue == "(All)") || (ddlCategory.SelectedValue == "Rentals") || (ddlCategory.SelectedValue == "Fuel") || (ddlCategory.SelectedValue == "Traffic Control") || (ddlCategory.SelectedValue == "Testing") || (ddlCategory.SelectedValue == "Permits") || (ddlCategory.SelectedValue == "Meals") || (ddlCategory.SelectedValue == "Other"))
            {                
                ddlSubcontractor.Visible = false;
                ddlHotels.Visible = false;
                ddlInsurance.Visible = false;
                ddlBonding.Visible = false;
            }
            else
            {
                if (ddlCategory.SelectedValue == "Subcontractors")
                {                    
                    ddlSubcontractor.Visible = true;
                    ddlHotels.Visible = false;
                    ddlInsurance.Visible = false;
                    ddlBonding.Visible = false;
                }
                else
                {
                    if (ddlCategory.SelectedValue == "Hotels")
                    {                        
                        ddlSubcontractor.Visible = false;
                        ddlHotels.Visible = true;
                        ddlInsurance.Visible = false;
                        ddlBonding.Visible = false;
                    }
                    else
                    {
                        if (ddlCategory.SelectedValue == "Bonding")
                        {                            
                            ddlSubcontractor.Visible = false;
                            ddlHotels.Visible = false;
                            ddlInsurance.Visible = false;
                            ddlBonding.Visible = true;
                        }
                        else
                        {
                            if (ddlCategory.SelectedValue == "Insurance")
                            {                                
                                ddlSubcontractor.Visible = false;
                                ddlHotels.Visible = false;
                                ddlInsurance.Visible = true;
                                ddlBonding.Visible = false;
                            }
                            else
                            {                                
                                ddlSubcontractor.Visible = false;
                                ddlHotels.Visible = false;
                                ddlInsurance.Visible = false;
                                ddlBonding.Visible = false;
                            }
                        }
                    }
                }
            }
        }





        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Resolve timeout problem
            ScriptManager scriptManager = (ScriptManager)this.Page.Master.FindControl("ScriptManagerMaster7");
            if (scriptManager != null)
            {
                scriptManager.AsyncPostBackTimeout = 2400;
            }

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./actual_costs_navigator.js");
        }



        private void RestoreNavigatorState()
        {
            // ...  for the client
            int companyId = Int32.Parse(hdfCompanyId.Value);
            CompaniesList companiesList = new CompaniesList(new DataSet());
            companiesList.LoadAndAddItem(-1, "(All)", companyId);
            ddlClient.DataSource = companiesList.Table;
            ddlClient.DataValueField = "COMPANIES_ID";
            ddlClient.DataTextField = "Name";
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

            // ... for category            
            ddlCategory.SelectedValue = Request.QueryString["search_category"];

            // ... for textForSearch
            tbxTextForSearch.Text = Request.QueryString["search_textForSearch"];

            // ... for subcontrator            
            if (Request.QueryString["search_category"] == "Subcontractors")
            {
                // ... ... Make values visible
                ddlSubcontractor.Visible = true;
                ddlHotels.Visible = false;
                ddlInsurance.Visible = false;
                ddlBonding.Visible = false;

                // ... ... Load values
                odsSubcontractorsList.DataBind();
                ddlSubcontractor.DataSourceID = "odsSubcontractorsList";
                ddlSubcontractor.DataValueField = "SubcontractorID";
                ddlSubcontractor.DataTextField = "Name";
                ddlSubcontractor.DataBind();
                ddlSubcontractor.SelectedValue = Request.QueryString["search_ddlSubcontractor"];
            }

            // ... for hotel            
            if (Request.QueryString["search_category"] == "Hotel")
            {
                // ... ... Make values visible
                ddlSubcontractor.Visible = false;
                ddlHotels.Visible = true;
                ddlInsurance.Visible = false;
                ddlBonding.Visible = false;

                // ... ... Load values                
                odsHotelsList.DataBind();
                ddlHotels.DataSourceID = "odsHotelsList";
                ddlHotels.DataValueField = "COMPANIES_ID";
                ddlHotels.DataTextField = "Name";
                ddlHotels.DataBind();
                ddlHotels.SelectedValue = Request.QueryString["search_ddlHotels"];
            }

            // ... for insurance            
            if (Request.QueryString["search_category"] == "Insurance")
            {
                // ... ... Make values visible
                ddlSubcontractor.Visible = false;
                ddlHotels.Visible = false;
                ddlInsurance.Visible = true;
                ddlBonding.Visible = false;

                // ... ... Load values                
                odsInsuranceList.DataBind();
                ddlInsurance.DataSourceID = "odsInsuranceList";
                ddlInsurance.DataValueField = "COMPANIES_ID";
                ddlInsurance.DataTextField = "Name";
                ddlInsurance.DataBind();
                ddlInsurance.SelectedValue = Request.QueryString["search_ddlInsurance"];
            }

            // ... for bonding         
            if (Request.QueryString["search_category"] == "Bonding")
            {
                // ... ... Make values visible
                ddlSubcontractor.Visible = false;
                ddlHotels.Visible = false;
                ddlInsurance.Visible = false;
                ddlBonding.Visible = true;

                // ... ... Load values                
                odsBondingList.DataBind();
                ddlBonding.DataSourceID = "odsBondingList";
                ddlBonding.DataValueField = "COMPANIES_ID";
                ddlBonding.DataTextField = "Name";
                ddlBonding.DataBind();
                ddlBonding.SelectedValue = Request.QueryString["search_ddlBonding"];
            }

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
            searchOptions = searchOptions + "&search_ddlHotels=" + ddlHotels.SelectedValue;
            searchOptions = searchOptions + "&search_ddlInsurance=" + ddlInsurance.SelectedValue;
            searchOptions = searchOptions + "&search_ddlBonding=" + ddlBonding.SelectedValue;
            searchOptions = searchOptions + "&search_sort_by=" + ddlSortBy.SelectedValue;
            searchOptions = searchOptions + "&search_tkrdpStartDate=" + tkrdpStartDate.SelectedDate;
            searchOptions = searchOptions + "&search_tkrdpEndDate=" + tkrdpEndDate.SelectedDate;
            searchOptions = searchOptions + "&search_cbxFilterByDateSelected=" + cbxFilterByRangeOfDates.Checked.ToString();
            searchOptions = searchOptions + "&search_category=" + ddlCategory.SelectedValue;
            searchOptions = searchOptions + "&search_textForSearch=" + tbxTextForSearch.Text;

            // Return
            return searchOptions;
        }



        private ActualCostsNavigatorTDS SubmitSearch()
        {
            // Values to search            
            int projectId = Convert.ToInt32(ddlProject.SelectedValue);
            int clientId = Convert.ToInt32(ddlClient.SelectedValue);
            string textForSearch = tbxTextForSearch.Text;
            string category = ddlCategory.SelectedValue;
            ActualCostsNavigatorTDS actualCostsNavigatorTDSForSearch = new ActualCostsNavigatorTDS();

            // Retrieve  Where clause     
            if (category == "All")
            {
                // ... subcontractors                
                LoadBySubcontractor(projectId, clientId, textForSearch, actualCostsNavigatorTDSForSearch, -1);

                // ... hotels               
                LoadByHotel(projectId, clientId, textForSearch, actualCostsNavigatorTDSForSearch, -1);

                // ... insurance               
                LoadByInsurance(projectId, clientId, textForSearch, actualCostsNavigatorTDSForSearch, -1);

                // ... bonding                
                LoadByBonding(projectId, clientId, textForSearch, actualCostsNavigatorTDSForSearch, -1);

                // ... others                
                LoadByOther(projectId, clientId, textForSearch, actualCostsNavigatorTDSForSearch, "LoadAll");
            }
            else
            {
                if (category == "Subcontractors")
                {
                    int subcontractorId = Convert.ToInt32(ddlSubcontractor.SelectedValue);
                    LoadBySubcontractor(projectId, clientId, textForSearch, actualCostsNavigatorTDSForSearch, subcontractorId);
                }
                else
                {
                    if (category == "Hotel")
                    {
                        int hotelId = Convert.ToInt32(ddlHotels.SelectedValue);
                        LoadByHotel(projectId, clientId, textForSearch, actualCostsNavigatorTDSForSearch, hotelId);
                    }
                    else
                    {
                        if (category == "Insurance")
                        {
                            int insuranceCompanyId = Convert.ToInt32(ddlInsurance.SelectedValue);
                            LoadByInsurance(projectId, clientId, textForSearch, actualCostsNavigatorTDSForSearch, insuranceCompanyId);
                        }
                        else
                        {
                            if (category == "Bonding")
                            {
                                int bondingCompanyId = Convert.ToInt32(ddlBonding.SelectedValue);
                                LoadByBonding(projectId, clientId, textForSearch, actualCostsNavigatorTDSForSearch, bondingCompanyId);                                
                            }
                            else
                            {
                                LoadByOther(projectId, clientId, textForSearch, actualCostsNavigatorTDSForSearch, category);                                
                            }
                        }
                    }
                }
            }

            return actualCostsNavigatorTDSForSearch;
        }


        private void LoadBySubcontractor(int projectId, int clientId, string textForSearch, ActualCostsNavigatorTDS actualCostsNavigatorTDSForSearch, int subcontractorId)
        {            
            string whereClause = GetWhereClauseForSubcontractor(subcontractorId, projectId, clientId, textForSearch);
            string orderByClause = GetOrderByClause();

            ActualCostsNavigatorSubcontractorCosts actualCostsNavigatorSubcontractorCosts = new ActualCostsNavigatorSubcontractorCosts(actualCostsNavigatorTDSForSearch);
            actualCostsNavigatorSubcontractorCosts.Load(whereClause, orderByClause);
        }



        private void LoadByHotel(int projectId, int clientId, string textForSearch, ActualCostsNavigatorTDS actualCostsNavigatorTDSForSearch, int hotelId)
        {            
            string whereClause = GetWhereClauseForHotel(hotelId, projectId, clientId, textForSearch);
            string orderByClause = GetOrderByClause();

            ActualCostsNavigatorHotelCosts actualCostsNavigatorHotelCosts = new ActualCostsNavigatorHotelCosts(actualCostsNavigatorTDSForSearch);
            actualCostsNavigatorHotelCosts.Load(whereClause, orderByClause);
        }


        private void LoadByInsurance(int projectId, int clientId, string textForSearch, ActualCostsNavigatorTDS actualCostsNavigatorTDSForSearch, int insuranceCompanyId)
        {        
            string whereClause = GetWhereClauseForInsurance(insuranceCompanyId, projectId, clientId, textForSearch);
            string orderByClause = GetOrderByClause();

            ActualCostsNavigatorInsuranceCompaniesCosts actualCostsNavigatorInsuranceCompaniesCosts = new ActualCostsNavigatorInsuranceCompaniesCosts(actualCostsNavigatorTDSForSearch);
            actualCostsNavigatorInsuranceCompaniesCosts.Load(whereClause, orderByClause);
        }



        private void LoadByBonding(int projectId, int clientId, string textForSearch, ActualCostsNavigatorTDS actualCostsNavigatorTDSForSearch, int bondingCompanyId)
        {            
            string whereClause = GetWhereClauseForBonding(bondingCompanyId, projectId, clientId, textForSearch);
            string orderByClause = GetOrderByClause();

            ActualCostsNavigatorBondingCompaniesCosts actualCostsNavigatorBondingCompaniesCosts = new ActualCostsNavigatorBondingCompaniesCosts(actualCostsNavigatorTDSForSearch);
            actualCostsNavigatorBondingCompaniesCosts.Load(whereClause, orderByClause);
        }



        private void LoadByOther(int projectId, int clientId, string textForSearch, ActualCostsNavigatorTDS actualCostsNavigatorTDSForSearch, string category)
        {
            bool loadAll = false;
            if (category == "LoadAll") loadAll = true;
            string whereClause = GetWhereClauseForOther(category, projectId, clientId, textForSearch, loadAll);
            string orderByClause = GetOrderByClause();

            ActualCostsNavigatorOtherCosts actualCostsNavigatorOtherCosts = new ActualCostsNavigatorOtherCosts(actualCostsNavigatorTDSForSearch);
            actualCostsNavigatorOtherCosts.Load(whereClause, orderByClause);
        }



        private string GetWhereClauseForSubcontractor(int subcontractorId, int projectId, int clientId, string textForSearch)
        {
            // General conditions
            string whereClause = "(SC.Deleted = 0) AND (S.Deleted = 0) ";

            // Subcontractor selected
            if (subcontractorId != -1)
            {
                whereClause = whereClause + "AND (SC.SubcontractorID = " + subcontractorId + ")";
            }

            // Client selected
            if (Int32.Parse(ddlClient.SelectedValue) != -1)
            {
                whereClause = whereClause + " AND (P.ClientID = " + clientId + ") ";
            }

            // Project selected
            if (projectId != -1)
            {
                whereClause = whereClause + " AND (SC.ProjectID = " + projectId + ") ";
            }

            // Date range
            if (cbxFilterByRangeOfDates.Checked)
            {
                whereClause = whereClause + string.Format(" AND SC.Date >= '{0}' AND SC.Date <= '{1}'", tkrdpStartDate.SelectedDate.Value.ToShortDateString(), tkrdpEndDate.SelectedDate.Value.ToShortDateString());
            }

            // For rate condition
            string operatorValue = "=";
            
            if (textForSearch == "")
            {
                whereClause = whereClause + " AND ((SC.RateCad IS NULL) OR (SC.RateUsd IS NULL))";
            }
            else
            {
                if (textForSearch == "%")
                {
                    whereClause = whereClause + " AND (((SC.RateCad LIKE '%') OR (SC.RateUsd LIKE '%'))";
                    whereClause = whereClause + " OR (SC.RateCad IS NULL) OR (SC.RateUsd IS NULL))";
                }
                else
                {
                    whereClause = whereClause + " AND ((SC.RateCad " + operatorValue + textForSearch + ") or (SC.RateUSd " + operatorValue + textForSearch + "))";
                }
            }

            return whereClause;
        }



        private string GetWhereClauseForHotel(int hotelId, int projectId, int clientId, string textForSearch)
        {
            // General conditions
            string whereClause = "(HC.Deleted = 0) AND (H.Deleted = 0) ";

            // Hotel selected
            if (hotelId != -1)
            {
                whereClause = whereClause + "AND (HC.HotelID = " + hotelId + ")";
            }

            // Client selected
            if (Int32.Parse(ddlClient.SelectedValue) != -1)
            {
                whereClause = whereClause + " AND (P.ClientID = " + clientId + ") ";
            }

            // Project selected
            if (projectId != -1)
            {
                whereClause = whereClause + " AND (HC.ProjectID = " + projectId + ") ";
            }

            // Date Range
            if (cbxFilterByRangeOfDates.Checked)
            {
                whereClause = whereClause + string.Format(" AND HC.Date >= '{0}' AND HC.Date <= '{1}'", tkrdpStartDate.SelectedDate.Value.ToShortDateString(), tkrdpEndDate.SelectedDate.Value.ToShortDateString());
            }

            // ... For operator Rate
            string operatorValue = "=";

            if (textForSearch == "")
            {
                whereClause = whereClause + " AND ((HC.RateCad IS NULL) OR (HC.RateUsd IS NULL))";
            }
            else
            {
                if (textForSearch == "%")
                {
                    whereClause = whereClause + " AND (((HC.RateCad LIKE '%') OR (HC.RateUsd LIKE '%'))";
                    whereClause = whereClause + " OR (HC.RateCad IS NULL) OR (HC.RateUsd IS NULL))";
                }
                else
                {
                    whereClause = whereClause + " AND ((HC.RateCad " + operatorValue + textForSearch + ") or (HC.RateUSd " + operatorValue + textForSearch + "))";
                }
            }

            return whereClause;
        }



        private string GetWhereClauseForInsurance(int insuranceId, int projectId, int clientId, string textForSearch)
        {
            // General conditions
            string whereClause = "(ICC.Deleted = 0) AND (IC.Deleted = 0) ";

            // Insurance selected
            if (insuranceId != -1)
            {
                whereClause = whereClause + "AND (ICC.InsuranceCompanyID = " + insuranceId + ")";
            }

            // Client selected
            if (Int32.Parse(ddlClient.SelectedValue) != -1)
            {
                whereClause = whereClause + " AND (P.ClientID = " + clientId + ") ";
            }

            // Project selected
            if (projectId != -1)
            {
                whereClause = whereClause + " AND (ICC.ProjectID = " + projectId + ") ";
            }

            // Date range
            if (cbxFilterByRangeOfDates.Checked)
            {
                whereClause = whereClause + string.Format(" AND ICC.Date >= '{0}' AND ICC.Date <= '{1}'", tkrdpStartDate.SelectedDate.Value.ToShortDateString(), tkrdpEndDate.SelectedDate.Value.ToShortDateString());
            }

            // ... For operator Rate
            string operatorValue = "=";

            if (textForSearch == "")
            {
                whereClause = whereClause + " AND ((ICC.RateCad IS NULL) OR (ICC.RateUsd IS NULL))";
            }
            else
            {
                if (textForSearch == "%")
                {
                    whereClause = whereClause + " AND (((ICC.RateCad LIKE '%') OR (ICC.RateUsd LIKE '%'))";
                    whereClause = whereClause + " OR (ICC.RateCad IS NULL) OR (ICC.RateUsd IS NULL))";
                }
                else
                {
                    whereClause = whereClause + " AND ((ICC.RateCad " + operatorValue + textForSearch + ") or (ICC.RateUSd " + operatorValue + textForSearch + "))";
                }
            }

            return whereClause;
        }



        private string GetWhereClauseForBonding(int bondingId, int projectId, int clientId, string textForSearch)
        {
            // General conditions
            string whereClause = "(BCC.Deleted = 0) AND (BC.Deleted = 0) ";

            // Bonding selected
            if (bondingId != -1)
            {
                whereClause = whereClause + "AND (BCC.BondingCompanyID = " + bondingId + ")";
            }

            // Client selected
            if (Int32.Parse(ddlClient.SelectedValue) != -1)
            {
                whereClause = whereClause + " AND (P.ClientID = " + clientId + ") ";
            }

            // Project selected
            if (projectId != -1)
            {
                whereClause = whereClause + " AND (BCC.ProjectID = " + projectId + ") ";
            }

            // Date range
            if (cbxFilterByRangeOfDates.Checked)
            {
                whereClause = whereClause + string.Format(" AND BCC.Date >= '{0}' AND BCC.Date <= '{1}'", tkrdpStartDate.SelectedDate.Value.ToShortDateString(), tkrdpEndDate.SelectedDate.Value.ToShortDateString());
            }

            // ... For operator Rate
            string operatorValue = "=";

            if (textForSearch == "")
            {
                whereClause = whereClause + " AND ((BCC.RateCad IS NULL) OR (BCC.RateUsd IS NULL))";
            }
            else
            {
                if (textForSearch == "%")
                {
                    whereClause = whereClause + " AND (((BCC.RateCad LIKE '%') OR (BCC.RateUsd LIKE '%'))";
                    whereClause = whereClause + " OR (BCC.RateCad IS NULL) OR (BCC.RateUsd IS NULL))";
                }
                else
                {
                    whereClause = whereClause + " AND ((BCC.RateCad " + operatorValue + textForSearch + ") or (BCC.RateUSd " + operatorValue + textForSearch + "))";
                }
            }

            return whereClause;
        }



        private string GetWhereClauseForOther(string category, int projectId, int clientId, string textForSearch, bool loadAll)
        {
            // General conditions
            string whereClause = "(OC.Deleted = 0) ";

            // Category selected            
            if (!loadAll)
            {
                whereClause = whereClause + "AND (OC.Category = '" + category + "')";
            }            

            // Client selected
            if (Int32.Parse(ddlClient.SelectedValue) != -1)
            {
                whereClause = whereClause + " AND (P.ClientID = " + clientId + ") ";
            }

            // Project selected
            if (projectId != -1)
            {
                whereClause = whereClause + " AND (OC.ProjectID = " + projectId + ") ";
            }

            // Date range
            if (cbxFilterByRangeOfDates.Checked)
            {
                whereClause = whereClause + string.Format(" AND OC.Date >= '{0}' AND OC.Date <= '{1}'", tkrdpStartDate.SelectedDate.Value.ToShortDateString(), tkrdpEndDate.SelectedDate.Value.ToShortDateString());
            }

            // ... For operator Rate
            string operatorValue = "=";

            if (textForSearch == "")
            {
                whereClause = whereClause + " AND ((OC.RateCad IS NULL) OR (OC.RateUsd IS NULL))";
            }
            else
            {
                if (textForSearch == "%")
                {
                    whereClause = whereClause + " AND (((OC.RateCad LIKE '%') OR (OC.RateUsd LIKE '%'))";
                    whereClause = whereClause + " OR (OC.RateCad IS NULL) OR (OC.RateUsd IS NULL))";
                }
                else
                {
                    whereClause = whereClause + " AND ((OC.RateCad " + operatorValue + textForSearch + ") or (OC.RateUSd " + operatorValue + textForSearch + "))";
                }
            }

            return whereClause;
        }



        private string GetOrderByClause()
        {
            // Get order by clause
            string orderBy = "";            
            string category = ddlCategory.SelectedValue;

            switch (ddlSortBy.SelectedItem.Text)
            {                
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