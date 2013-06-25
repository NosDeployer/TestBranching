using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.BL.Resources.Employees;
using LiquiForce.LFSLive.DA.Resources.Common;
using LiquiForce.LFSLive.BL.Resources.Common;

namespace LiquiForce.LFSLive.WebUI.Resources.Employees
{
    /// <summary>
    /// employees_navigator
    /// </summary>
    public partial class employees_navigator : System.Web.UI.Page
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
                if (!(Convert.ToBoolean(Session["sgLFS_RESOURCES_EMPLOYEES_VIEW"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in employees_navigator.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfResourceType.Value = "Employee";

                // Prepare initial data
                // ... For 
                odsViewForConditionList.DataBind();
                ddlCondition1.DataSourceID = "odsViewForConditionList";
                ddlCondition1.DataValueField = "ConditionID";
                ddlCondition1.DataTextField = "Name";
                ddlCondition1.DataBind();

                // Prepare initial data
                // ... For sortByList
                odsSortByList.DataBind();
                ddlSortBy.DataSourceID = "odsSortByList";
                ddlSortBy.DataValueField = "SortID";
                ddlSortBy.DataTextField = "Name";
                ddlSortBy.DataBind();

                // If coming from 

                // ... Left Menu or out
                if ((Request.QueryString["source_page"] == "lm") || (Request.QueryString["source_page"] == "out"))
                {
                    tdNoResults.Visible = false;
                }

                // ... employees_navigator2.aspx
                if (Request.QueryString["source_page"] == "employees_navigator2.aspx")
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
                EmployeeNavigatorTDS employeeNavigatorTDS = SubmitSearch();

                // Show results
                if (employeeNavigatorTDS.EmployeeNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["employeeNavigatorTDS"] = employeeNavigatorTDS;

                    // ... Go to the results page
                    Response.Redirect("./employees_navigator2.aspx?source_page=employees_navigator.aspx&" + GetNavigatorState());
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
            master.ActiveToolbar = "Resources";

            if (!Convert.ToBoolean(Session["sgLFS_RESOURCES_EMPLOYEES_ADMIN"]))
            {
                tkrpbLeftMenuTools.Items[0].Items[0].Visible = false; // Personnel Agencies
            }

            if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_VACATIONS_HOLIDAY_FULL_EDITING"])))
            {
                tkrpbLeftMenuTools.Items[0].Items[1].Visible = false; // Vacations Setup
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //
        
        protected void cvForBoolean_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Booleans fields validate
            if ((ddlCondition1.SelectedItem.Text == "Is Salesman?") || (ddlCondition1.SelectedItem.Text == "Approve Timesheets?") || (ddlCondition1.SelectedItem.Text == "Request Timesheet?") || (ddlCondition1.SelectedItem.Text == "Salaried") || (ddlCondition1.SelectedItem.Text == "Assignable SR'S") || (ddlCondition1.SelectedItem.Text == "Vacations Manager?"))
            {
                if ((args.Value.Trim().ToUpper() == "Y") || (args.Value.Trim().ToUpper() == "YES") || (args.Value.Trim().ToUpper() == "N") || (args.Value.Trim().ToUpper() == "NO") || (args.Value.Trim() == "%") || (args.Value.Trim() == ""))
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvForDecimalNumberCondition_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Decimal number fields validate
            if ((ddlCondition1.SelectedItem.Text == "Pay Rate (CAD)") || (ddlCondition1.SelectedItem.Text == "Pay Rate (USD)") || (ddlCondition1.SelectedItem.Text == "Burden Rate (CAD)") || (ddlCondition1.SelectedItem.Text == "Burden Rate (USD)") 
                || (ddlCondition1.SelectedItem.Text == "Total Cost (CAD)") || (ddlCondition1.SelectedItem.Text == "Total Cost (CAD)")
                || (ddlCondition1.SelectedItem.Text == "Benefit Factor (CAD)") || (ddlCondition1.SelectedItem.Text == "Benefit Factor (USD)") || (ddlCondition1.SelectedItem.Text == "Health Benefit (USD)"))
            {
                if ((tbxCondition1.Text != "") && (tbxCondition1.Text != "%"))
                {
                    if (Validator.IsValidDecimal(args.Value.Trim()))
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        args.IsValid = false;
                    }
                }
                else
                {
                    args.IsValid = true;
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./employees_navigator.js");
        }



        private void RestoreNavigatorState()
        {
            // Search condition 1
            // Columns To Display
            string columnsToDisplay = Request.QueryString["columns_to_display"];

            // Search condition 1
            // ... For Condition 
            odsViewForConditionList.DataBind();
            ddlCondition1.DataSourceID = "odsViewForConditionList";
            ddlCondition1.DataValueField = "ConditionID";
            ddlCondition1.DataTextField = "Name";
            ddlCondition1.DataBind();
            ddlCondition1.SelectedValue = Request.QueryString["search_ddlCondition1"];

            //Other values
            //... For SortBy
            odsSortByList.DataBind();
            ddlSortBy.DataSourceID = "odsSortByList";
            ddlSortBy.DataValueField = "SortID";
            ddlSortBy.DataTextField = "Name";
            ddlSortBy.DataBind();
            ddlSortBy.SelectedValue = Request.QueryString["search_sort_by"];

            // ... For text for search
            tbxCondition1.Text = Request.QueryString["search_tbxCondition1"];
        }



        private string GetNavigatorState()
        {
            // Columns to display
            string columnsToDisplay = "";
            columnsToDisplay = columnsToDisplay + GetColumnsToDisplay();

            // SearchOptions for condition 1
            string searchOptions = "";
            searchOptions = searchOptions + "&search_ddlCondition1=" + ddlCondition1.SelectedValue;
            searchOptions = searchOptions + "&search_tbxCondition1=" + tbxCondition1.Text.Trim();
            searchOptions = searchOptions + "&search_sort_by=" + ddlSortBy.SelectedValue;

            // Return
            return columnsToDisplay + searchOptions;
        }



        private EmployeeNavigatorTDS SubmitSearch()
        {
            // Retrieve clauses
            string whereClause = GetWhereClause();
            string orderByClause = GetOrderByClause();
            string conditionValue = "";

            EmployeeNavigator employeeNavigator = new EmployeeNavigator();
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string resourceType = hdfResourceType.Value.Trim();

            // ... Load data
            ResourceTypeViewConditionGateway resourceTypeViewConditionGateway = new ResourceTypeViewConditionGateway();
            resourceTypeViewConditionGateway.LoadByResourceTypeConditionId(resourceType, companyId, int.Parse(ddlCondition1.SelectedValue));

            conditionValue = resourceTypeViewConditionGateway.GetColumn_(resourceType, companyId, int.Parse(ddlCondition1.SelectedValue));

            employeeNavigator.Load(whereClause, orderByClause, conditionValue, tbxCondition1.Text.Trim(), companyId, resourceType);

            return (EmployeeNavigatorTDS)employeeNavigator.Data;
        }



        private string GetWhereClause()
        {
            // General conditions
            string whereClause = "(LRE.Deleted = 0) ";            

            // Field condition
            // ... Condition 1
            whereClause = modifyWhereClauseForCondition(whereClause, int.Parse(ddlCondition1.SelectedValue), tbxCondition1.Text.Trim());

            return whereClause;
        }



        private string modifyWhereClauseForCondition(string whereClause, int conditionId, string textForSearch)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string resourceType = hdfResourceType.Value;

            ResourceTypeViewConditionGateway resourceTypeViewConditionGateway = new ResourceTypeViewConditionGateway();
            resourceTypeViewConditionGateway.LoadByResourceTypeConditionId(resourceType, companyId, conditionId);

            string conditionValue = resourceTypeViewConditionGateway.GetColumn_(resourceType, companyId, conditionId);
            string tableName = resourceTypeViewConditionGateway.GetTable_(resourceType, companyId, conditionId);

            if (tableName == "LFS_RESOURCES_EMPLOYEE") tableName = "LRE";
            if (tableName == "LFS_RESOURCES_EMPLOYEE_TYPE") tableName = "LRET";
            if (tableName == "LFS_RESOURCES_EMPLOYEE_STATE") tableName = "LRES";
            if (tableName == "LFS_RESOURCES_EMPLOYEE_COST_HISTORY") tableName = "LRECH";

            // FOR TEXT FIELDS. (FirstName, LastName, Email, Type, State, JobClassType)
            if ((conditionValue == "FirstName") || (conditionValue == "LastName") || (conditionValue == "eMail") || (conditionValue == "Description") || (conditionValue == "Type") || (conditionValue == "State") || (conditionValue == "Category") || (conditionValue == "JobClassType") || (conditionValue == "PersonalAgencyName"))                
            {
                // ... Search
                if (textForSearch == "%")
                {
                    whereClause = whereClause + " AND ((" + tableName + "." + conditionValue + " LIKE '%')";
                    whereClause = whereClause + " OR (" + tableName + "." + conditionValue + " IS NULL))";
                }
                else
                {
                    if (textForSearch == "")
                    {
                        whereClause = whereClause + " AND (" + tableName + "." + conditionValue + " IS NULL )";
                    }
                    else
                    {
                        if (textForSearch.Contains("\""))
                        {
                            if (conditionValue == "Comments")
                            {
                                textForSearch = textForSearch.Replace("'", "''");
                                whereClause = whereClause + "AND (" + tableName + "." + conditionValue + " LIKE '%" + textForSearch + "%')";
                            }
                            else
                            {
                                textForSearch = textForSearch.Replace("\"", "");
                                whereClause = whereClause + "AND (" + tableName + "." + conditionValue + " = '" + textForSearch + "')";
                            }
                        }
                        else
                        {
                            textForSearch = textForSearch.Replace("'", "''");
                            whereClause = whereClause + "AND (" + tableName + "." + conditionValue + " LIKE '%" + textForSearch + "%')";
                        }
                    }
                }
            }

            // FOR BOOLEAN FIELDS
            if ((conditionValue == "IsSalesman") || (conditionValue == "ApproveTimesheets") || (conditionValue == "RequestProjectTime") || (conditionValue == "Salaried") || (conditionValue == "AssignableSRS") || (conditionValue == "IsVacationsManager"))
            {
                if (textForSearch != "")
                {
                    if ((textForSearch.ToUpper() == "Y") || (textForSearch.ToUpper() == "YES"))
                    {
                        whereClause = whereClause + " AND (" + conditionValue + " = 1)";
                    }
                    else
                    {
                        if ((textForSearch.ToUpper() == "N") || (textForSearch.ToUpper() == "NO"))
                        {
                            whereClause = whereClause + " AND (" + conditionValue + " = 0)";
                        }
                        else
                        {
                            if (textForSearch == "%")
                            {
                                whereClause = whereClause + " AND ((" + conditionValue + " = 1) OR (" + conditionValue + " = 0))";
                            }
                        }
                    }
                }
            }

            return whereClause;
        }



        private string GetOrderByClause()
        {
            // Get tableName
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            ResourceTypeViewSortGateway resourceTypeViewSortGateway = new ResourceTypeViewSortGateway();
            resourceTypeViewSortGateway.LoadByResourceTypeSortId("Employee", companyId, int.Parse(ddlSortBy.SelectedValue));

            string tableName = resourceTypeViewSortGateway.GetTable_("Employee", companyId, int.Parse(ddlSortBy.SelectedValue));
            string columnName = resourceTypeViewSortGateway.GetColumn_("Employee", companyId, int.Parse(ddlSortBy.SelectedValue));

            if (tableName == "LFS_RESOURCES_EMPLOYEE") tableName = "LRE";

            // Get order by clause
            string orderBy = "";

            orderBy = tableName + "." + columnName;

            return orderBy;
        }



        private string GetColumnsToDisplay()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string resourceType = hdfResourceType.Value.Trim();
            string columnsToDisplay = "&columns_to_display=";

            ResourceTypeViewDisplay resourceTypeViewDisplay = new  ResourceTypeViewDisplay();
            columnsToDisplay = columnsToDisplay + resourceTypeViewDisplay.GetColumnsByDefault(resourceType, companyId, true);
            
            return columnsToDisplay;
        }



    }
}