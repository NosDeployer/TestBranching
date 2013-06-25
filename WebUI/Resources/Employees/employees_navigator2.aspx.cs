using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.BL.Resources.Employees;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.DA.Resources.Common;
using LiquiForce.LFSLive.BL.Resources.Common;

namespace LiquiForce.LFSLive.WebUI.Resources.Employees
{
    /// <summary>
    /// employees_navigator2
    /// </summary>
    public partial class employees_navigator2 : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected EmployeeNavigatorTDS employeeNavigatorTDS;
        protected EmployeeNavigatorTDS.EmployeeNavigatorDataTable employeeNavigator;






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
                if (!(Convert.ToBoolean(Session["sgLFS_RESOURCES_EMPLOYEES_VIEW"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in employees_navigator2.aspx");
                }
                
                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfResourceType.Value = "Employee";
                Session.Remove("employeeNavigatorNewDummy");

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
                // ... employees_navigator.aspx or employees_navigator2.aspx
                if ((Request.QueryString["source_page"] == "employees_navigator.aspx") || (Request.QueryString["source_page"] == "employees_navigator2.aspx"))
                {
                    RestoreNavigatorState();
                    employeeNavigatorTDS = (EmployeeNavigatorTDS)Session["employeeNavigatorTDS"];
                }

                // ... employees_edit.aspx, employees_summary.aspx or employees_delete.aspx
                if ((Request.QueryString["source_page"] == "employees_edit.aspx") || (Request.QueryString["source_page"] == "employees_summary.aspx") || (Request.QueryString["source_page"] == "employees_delete.aspx"))
                {
                    RestoreNavigatorState();

                    if (Request.QueryString["update"] == "no")
                    {
                        employeeNavigatorTDS = (EmployeeNavigatorTDS)Session["employeeNavigatorTDS"];
                    }
                    else
                    {
                        // ... Delete store data
                        Session.Contents.Remove("employeeNavigatorTDS");

                        // ... Search data with updates                        
                        employeeNavigatorTDS = SubmitSearch();                        

                        // ... store datasets
                        Session["employeeNavigatorTDS"] = employeeNavigatorTDS;
                    }
                }

                // ... employees_delete.aspx, employee_summary.aspx or employee_edit.aspx
                if ((Request.QueryString["source_page"] == "employee_delete.aspx") || (Request.QueryString["source_page"] == "employee_summary.aspx") || (Request.QueryString["source_page"] == "employee_edit.aspx"))
                {
                    if (employeeNavigatorTDS.EmployeeNavigator.Rows.Count == 0)
                    {
                        string url = "./employees_navigator.aspx?source_page=employees_navigator2.aspx&re_type=" + hdfResourceType.Value + GetNavigatorState() + "&no_results=yes";
                        Response.Redirect(url);
                    }
                }

                Session["employeeNavigatorTDS"] = employeeNavigatorTDS;
                Session["employeeNavigator"] = employeeNavigatorTDS.EmployeeNavigator;

                // ... for the total rows
                if (employeeNavigatorTDS.EmployeeNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + employeeNavigatorTDS.EmployeeNavigator.Rows.Count;
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
                employeeNavigatorTDS = (EmployeeNavigatorTDS)Session["employeeNavigatorTDS"];
                employeeNavigator = employeeNavigatorTDS.EmployeeNavigator;

                // ... for the total rows
                if (employeeNavigatorTDS.EmployeeNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + employeeNavigatorTDS.EmployeeNavigator.Rows.Count;
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
                Session.Contents.Remove("employeeNavigatorTDS");

                // Get data from DA gateway
                employeeNavigatorTDS = SubmitSearch();

                // Show results
                if (employeeNavigatorTDS.EmployeeNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["employeeNavigatorTDS"] = employeeNavigatorTDS;

                    // ... Go to the results page
                    url = "./employees_navigator2.aspx?source_page=employees_navigator2.aspx"+ GetNavigatorState();
                }
                else
                {
                    // ... Go to the search page
                    url = "./employees_navigator.aspx?source_page=employees_navigator2.aspx&resource_type=" + hdfResourceType.Value + GetNavigatorState() + "&no_results=yes";
                }

                Response.Redirect(url);
            }
        }                  



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm7 master = (mForm7)this.Master;
            master.ActiveToolbar = "Resources";            
            
            // ... Grid information 
            if (!Convert.ToBoolean(Session["sgLFS_RESOURCES_EMPLOYEES_ADMIN"]))
            {
                // Validate Cost information, only visible for admin                    
                grdNavigator.Columns[17].Visible = false;
                grdNavigator.Columns[18].Visible = false;
                grdNavigator.Columns[19].Visible = false;
                grdNavigator.Columns[20].Visible = false;
                grdNavigator.Columns[21].Visible = false;
                grdNavigator.Columns[22].Visible = false;
                grdNavigator.Columns[23].Visible = false;
                grdNavigator.Columns[24].Visible = false;
                grdNavigator.Columns[25].Visible = false;
            }
            else
            {
                grdNavigator.Columns[17].Visible = true;
                grdNavigator.Columns[18].Visible = true;
                grdNavigator.Columns[19].Visible = true;
                grdNavigator.Columns[20].Visible = true;
                grdNavigator.Columns[21].Visible = true;
                grdNavigator.Columns[22].Visible = true;
                grdNavigator.Columns[23].Visible = true;
                grdNavigator.Columns[24].Visible = true;
                grdNavigator.Columns[25].Visible = true;
            }

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



        protected void grdNavigator_DataBound(object sender, EventArgs e)
        {
            AddNewEmptyFix(grdNavigator);
        }



        protected void grdNavigator_Sorting(object sender, GridViewSortEventArgs e)
        {
            string oldSort = employeeNavigatorTDS.EmployeeNavigator.DefaultView.Sort;

            if (!oldSort.Contains(e.SortExpression.ToString()))
            {
                employeeNavigatorTDS.EmployeeNavigator.DefaultView.Sort = e.SortExpression + " ASC";
            }
            else
            {
                if (oldSort.Contains("ASC"))
                {
                    employeeNavigatorTDS.EmployeeNavigator.DefaultView.Sort = e.SortExpression + " DESC";
                }
                else
                {
                    employeeNavigatorTDS.EmployeeNavigator.DefaultView.Sort = e.SortExpression + " ASC";
                }
            }

            // Store data
            Session["employeeNavigatorTDS"] = employeeNavigatorTDS;
            Session["employeeNavigator"] = employeeNavigatorTDS.EmployeeNavigator;
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnOpen_Click(object sender, EventArgs e)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string resourceType = hdfResourceType.Value.Trim();

            PostPageChanges();

            int employeeId = GetEmployeeId();
            hdfCurrentEmployeeId.Value = employeeId.ToString();

            if (employeeId > 0)
            {
                // Store active tab for postback
                Session["activeTabEmployees"] = "0";
                Session["dialogOpenedEmployees"] = "0";

                // Redirect
                string url = "./employees_summary.aspx?source_page=employees_navigator2.aspx&employee_id=" + hdfCurrentEmployeeId.Value + "&active_tab=0" + GetNavigatorState();
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
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string resourceType = hdfResourceType.Value.Trim();

            PostPageChanges();

            int employeeId = GetEmployeeId();
            hdfCurrentEmployeeId.Value = employeeId.ToString();

            if (employeeId > 0)
            {
                // Store active tab for postback
                Session["activeTabEmployees"] = "0";
                Session["dialogOpenedEmployees"] = "0";

                // Redirect
                string url = "./employees_edit.aspx?source_page=employees_navigator2.aspx&employee_id=" + employeeId + "&active_tab=0" + GetNavigatorState();
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
            string url = "";

            string headerValues = "";
            int totalColumnsExport = 23;
            int totalColumnsPreview = 23;
            string name = "";
            string title = "Team Search Results";

            // ... For comments option
            string comments = "None";

            // Establishing header values                        
            if (grdNavigator.Columns[3].Visible) headerValues += "First Name";
            if (grdNavigator.Columns[4].Visible) headerValues += " * Last Name";
            if (grdNavigator.Columns[5].Visible) headerValues += " * Email";
            if (grdNavigator.Columns[6].Visible) headerValues += " * Type";
            if (grdNavigator.Columns[7].Visible) headerValues += " * State";
            if (grdNavigator.Columns[8].Visible) headerValues += " * Category";
            if (grdNavigator.Columns[9].Visible) headerValues += " * Job Class";
            if (grdNavigator.Columns[10].Visible) headerValues += " * Is Salesman?";
            if (grdNavigator.Columns[11].Visible) headerValues += " * Approve Timesheets?";
            if (grdNavigator.Columns[12].Visible) headerValues += " * Request Timesheet?";
            if (grdNavigator.Columns[13].Visible) headerValues += " * Salaried";
            if (grdNavigator.Columns[14].Visible) headerValues += " * Assignable SR";
            if (grdNavigator.Columns[15].Visible) headerValues += " * Vacations Manager?";
            if (grdNavigator.Columns[16].Visible) headerValues += " * Personnel Agency";
            if (grdNavigator.Columns[17].Visible) headerValues += " * Pay Rate (CAD)";
            if (grdNavigator.Columns[18].Visible) headerValues += " * Burden Rate (CAD)";
            if (grdNavigator.Columns[19].Visible) headerValues += " * Total Cost (CAD)";
            if (grdNavigator.Columns[20].Visible) headerValues += " * Benefit Factor (CAD)";
            if (grdNavigator.Columns[21].Visible) headerValues += " * Pay Rate (USD)";
            if (grdNavigator.Columns[22].Visible) headerValues += " * Burden Rate (USD)";
            if (grdNavigator.Columns[23].Visible) headerValues += " * Total Cost (USD)";
            if (grdNavigator.Columns[24].Visible) headerValues += " * Benefit Factor (USD)";
            if (grdNavigator.Columns[25].Visible) headerValues += " * Health Benefit (USD)";            

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

            // Report call
            Page.Validate();
            if (Page.IsValid)
            {
                PostPageChanges();
                title = title.Replace("'", "%27");
                Response.Write("<script language='javascript'> {window.open('./employees_print_search_results_report.aspx?" + columnsForReport + "&comments=" + comments + "&totalColumnsPreview=" + totalColumnsPreview + "&totalColumnsExport=" + totalColumnsExport + "&totalSelectedColumns=" + columns.Length + "&name=" + name + "&title=" + title + "&format=pdf', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
            }                    

            if (url != "") Response.Redirect(url);
        }



        protected void btnExportList_Click(object sender, EventArgs e)
        {
            string url = "";
            string headerValues = "";
            int totalColumnsExport = 23;
            int totalColumnsPreview = 23;
            string name = "";
            string title = "Team Search Results";
            string columnsForReport = "";
            int j;

            // ... For comments option
            string comments = "None";

            headerValues = "";
            columnsForReport = "";

            // Establishing header values                        
            if (grdNavigator.Columns[3].Visible) headerValues += "First Name";
            if (grdNavigator.Columns[4].Visible) headerValues += " * Last Name";
            if (grdNavigator.Columns[5].Visible) headerValues += " * Email";
            if (grdNavigator.Columns[6].Visible) headerValues += " * Type";
            if (grdNavigator.Columns[7].Visible) headerValues += " * State";
            if (grdNavigator.Columns[8].Visible) headerValues += " * Category";
            if (grdNavigator.Columns[9].Visible) headerValues += " * Job Class";
            if (grdNavigator.Columns[10].Visible) headerValues += " * Is Salesman?";
            if (grdNavigator.Columns[11].Visible) headerValues += " * Approve Timesheets?";
            if (grdNavigator.Columns[12].Visible) headerValues += " * Request Timesheet?";
            if (grdNavigator.Columns[13].Visible) headerValues += " * Salaried";
            if (grdNavigator.Columns[14].Visible) headerValues += " * Assignable SR";
            if (grdNavigator.Columns[15].Visible) headerValues += " * Vacations Manager?";
            if (grdNavigator.Columns[16].Visible) headerValues += " * Personnel Agency";
            if (grdNavigator.Columns[17].Visible) headerValues += " * Pay Rate (CAD)";
            if (grdNavigator.Columns[18].Visible) headerValues += " * Burden Rate (CAD)";
            if (grdNavigator.Columns[19].Visible) headerValues += " * Total Cost (CAD)";
            if (grdNavigator.Columns[20].Visible) headerValues += " * Benefit Factor (CAD)";
            if (grdNavigator.Columns[21].Visible) headerValues += " * Pay Rate (USD)";
            if (grdNavigator.Columns[22].Visible) headerValues += " * Burden Rate (USD)";
            if (grdNavigator.Columns[23].Visible) headerValues += " * Total Cost (USD)";
            if (grdNavigator.Columns[24].Visible) headerValues += " * Benefit Factor (USD)";
            if (grdNavigator.Columns[25].Visible) headerValues += " * Health Benefit (USD)"; 

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
                Response.Write("<script language='javascript'> {window.open('./employees_print_search_results_report.aspx?" + columnsForReport + "&comments=" + comments + "&totalColumnsPreview=" + totalColumnsPreview + "&totalColumnsExport=" + totalColumnsExport + "&totalSelectedColumns=" + columnsExcel.Length + "&name=" + name + "&title=" + title + "&format=excel', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
            }
                    
            if (url != "") Response.Redirect(url);
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string resourceType = hdfResourceType.Value.Trim();

            PostPageChanges();

            int employeeId = GetEmployeeId();
            if (employeeId > 0)
            {
                hdfCurrentEmployeeId.Value = employeeId.ToString();

                // Store active tab for postback
                Session["activeTabEmployees"] = "0";
                Session["dialogOpenedEmployees"] = "0";

                // Redirect
                string url = "./employees_delete.aspx?source_page=employees_navigator2.aspx&employee_id=" + employeeId + GetNavigatorState();
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
            string url = "./employees_navigator.aspx?source_page=lm&resource_type=" + hdfResourceType.Value;

            if (url != "") Response.Redirect(url);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        public EmployeeNavigatorTDS.EmployeeNavigatorDataTable GetNavigator()
        {
            employeeNavigator = (EmployeeNavigatorTDS.EmployeeNavigatorDataTable)Session["employeeNavigatorNewDummy"];
            if (employeeNavigator == null)
            {
                employeeNavigator = ((EmployeeNavigatorTDS.EmployeeNavigatorDataTable)Session["employeeNavigator"]);
            }

            return employeeNavigator;
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfResourceTypeId = '" + hdfResourceType.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./employees_navigator2.js");
        }



        private void RestoreNavigatorState()
        {
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

            // ... For View 
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string resourceType = hdfResourceType.Value;
            int loginId = Convert.ToInt32(Session["loginID"]); 
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
            string resourceType = hdfResourceType.Value.Trim();
            string conditionValue = "";
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            EmployeeNavigator employeeNavigator = new EmployeeNavigator();

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



        private void PostPageChanges()
        {
            EmployeeNavigator employeeNavigator = new EmployeeNavigator(employeeNavigatorTDS);

            // Update 
            foreach (GridViewRow row in grdNavigator.Rows)
            {
                int employeeId = Int32.Parse(((Label)row.FindControl("lblEmployeeId")).Text.Trim());
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                employeeNavigator.Update(employeeId, selected);
            }

            employeeNavigator.Data.AcceptChanges();

            // Store datasets
            Session["employeeNavigatorTDS"] = employeeNavigatorTDS;
        }



        private int GetEmployeeId()
        {
            int employeeId = 0;

            foreach (EmployeeNavigatorTDS.EmployeeNavigatorRow employeeNavigatorRow in employeeNavigatorTDS.EmployeeNavigator)
            {
                if (employeeNavigatorRow.Selected)
                {
                    employeeId = employeeNavigatorRow.EmployeeID;
                }
            }

            return employeeId;
        }       



        private string GetColumnsToDisplay()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string resourceType = hdfResourceType.Value.Trim();
            string columnsToDisplay = "&columns_to_display=";

            ResourceTypeViewDisplay resourceTypeViewDisplay = new ResourceTypeViewDisplay();
            columnsToDisplay = columnsToDisplay + resourceTypeViewDisplay.GetColumnsByDefault(resourceType, companyId, true);
            
            return columnsToDisplay;
        }



        protected string GetType(object type)
        {
            if (type != DBNull.Value)
            {
                EmployeeTypeGateway employeeTypeGateway = new EmployeeTypeGateway();
                employeeTypeGateway.LoadByType((string)type);

                if (employeeTypeGateway.Table.Rows.Count > 0)
                {
                    return employeeTypeGateway.GetDescription((string)type);
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



        protected string GetState(object state)
        {
            if (state != DBNull.Value)
            {
                EmployeeStateGateway employeeStateGateway = new EmployeeStateGateway();
                employeeStateGateway.LoadByState((string)state);

                if (employeeStateGateway.Table.Rows.Count > 0)
                {
                    return employeeStateGateway.GetDescription((string)state);
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



        protected void AddNewEmptyFix(GridView grdNavigator)
        {
            if (grdNavigator.Rows.Count == 0)
            {
                EmployeeNavigatorTDS.EmployeeNavigatorDataTable dt = new EmployeeNavigatorTDS.EmployeeNavigatorDataTable();
                dt.AddEmployeeNavigatorRow(-1, -1, "", "", "", "", "", "", false, false, false, false, "", false, false, 0, 0, 0, 0, 0, 0, false, 0, 0, "", "", "", false, false, -1, -1, -1, -1, 0, "");
                Session["employeeNavigatorNewDummy"] = dt;

                grdNavigator.DataBind();
            }

            // normally executes at all postbacks
            if (grdNavigator.Rows.Count == 1)
            {
                EmployeeNavigatorTDS.EmployeeNavigatorDataTable dt = (EmployeeNavigatorTDS.EmployeeNavigatorDataTable)Session["employeeNavigatorNewDummy"];
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
