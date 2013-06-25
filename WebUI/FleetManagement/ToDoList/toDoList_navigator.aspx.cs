using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.FleetManagement.ToDoList;
using LiquiForce.LFSLive.BL.FleetManagement.ToDoList;
using LiquiForce.LFSLive.DA.FleetManagement.Common;
using LiquiForce.LFSLive.BL.FleetManagement.Common;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.ToDoList
{
    /// <summary>
    /// toDoList_navigator
    /// </summary>
    public partial class toDoList_navigator : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ToDoListNavigatorTDS toDoListNavigatorTDS;
        





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
                if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_TODOLIST_VIEW"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null) 
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in toDoList_navigator.aspx");
                }                

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfFmType.Value = "ToDoList";

                // Prepare initial data
                // ... For sortByList
                odsSortByList.DataBind();
                ddlSortBy.DataSourceID = "odsSortByList";
                ddlSortBy.DataValueField = "SortID";
                ddlSortBy.DataTextField = "Name";
                ddlSortBy.DataBind();

                // ... For state  
                odsState.DataBind();
                ddlState.DataSourceID = "odsState";
                ddlState.DataValueField = "State";
                ddlState.DataTextField = "State";
                ddlState.DataBind();
                //ddlState.Items.Add("New & In Progress");

                // ... For 
                odsViewForDisplayList.DataBind();
                ddlCondition1.DataSourceID = "odsViewForDisplayList";
                ddlCondition1.DataValueField = "ConditionID";
                ddlCondition1.DataTextField = "Name";
                ddlCondition1.DataBind();

                // ... For view ddl
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                string fmType = hdfFmType.Value;
                int loginId = Convert.ToInt32(Session["loginID"]);
                                             
                // If coming from 
                // ... Left Menu or out
                if ((Request.QueryString["source_page"] == "lm") || (Request.QueryString["source_page"] == "out"))
                {
                    tdNoResults.Visible = false;
                }

                // ... toDoList_navigator2.aspx
                if (Request.QueryString["source_page"] == "toDoList_navigator2.aspx")
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
            // Tag Page
            hdfBtnOrigin.Value = "Search";

            Page.Validate();

            // Get data from DA gateway
            if (Page.IsValid)
            {
                ToDoListNavigatorTDS toDoListNavigatorTDS = SubmitSearch();

                 //Show results
                if (toDoListNavigatorTDS.ToDoListNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["toDoListNavigatorTDS"] = toDoListNavigatorTDS;

                    // ... Go to the results page
                    Response.Redirect("./toDoList_navigator2.aspx?source_page=toDoList_navigator.aspx" + GetNavigatorState());
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
            master.ActiveToolbar = "FleetManagement";
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //
                
        protected void cvForDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //  Date fields validate
            if ((ddlCondition1.SelectedItem.Text == "Date") || (ddlCondition1.SelectedItem.Text == "Due Date"))
            {
                // for complete date and only year
                if (((Validator.IsValidDate(args.Value.Trim()) && (args.Value.Trim().Length > 7))) || ((Validator.IsValidInt32(args.Value.Trim())) && (args.Value.Trim().Length == 4)) || (args.Value.Trim() == "%") || (args.Value.Trim() == ""))
                {
                    args.IsValid = true;
                }
                else
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvForDateRange_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //  Date fields validate
            if ((ddlCondition1.SelectedItem.Text == "Date") || (ddlCondition1.SelectedItem.Text == "Due Date"))
            {
                // For dates before 1900
                if (cvForDate.IsValid)
                {
                    string[] date = (args.Value.Trim()).Split('/');
                    if (((Validator.IsValidDate(args.Value.Trim())) && (Int32.Parse(date[2]) >= 1900)) || ((args.Value.Trim().Length == 4) && (Validator.IsValidInt32(args.Value.Trim())) && (Int32.Parse(args.Value.Trim()) >= 1900)) || (args.Value.Trim() == "%") || (args.Value.Trim() == ""))
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        args.IsValid = false;
                    }
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfFmTypeId = '" + hdfFmType.ClientID + "';";
            
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./toDoList_navigator.js");
        }



        private void RestoreNavigatorState()
        {
            // Search condition 1
            // ... For Condition 
            odsViewForDisplayList.DataBind();
            ddlCondition1.DataSourceID = "odsViewForDisplayList";
            ddlCondition1.DataValueField = "ConditionID";
            ddlCondition1.DataTextField = "Name";
            ddlCondition1.DataBind();
            ddlCondition1.SelectedValue = Request.QueryString["search_ddlCondition1"];

            // ... For text for search
            tbxCondition1.Text = Request.QueryString["search_tbxCondition1"];

            //... For SortBy
            odsSortByList.DataBind();
            ddlSortBy.DataSourceID = "odsSortByList";
            ddlSortBy.DataValueField = "SortID";
            ddlSortBy.DataTextField = "Name";
            ddlSortBy.DataBind();
            ddlSortBy.SelectedValue = Request.QueryString["search_sort_by"];

            //... For State
            odsState.DataBind();
            ddlState.DataSourceID = "odsState";
            ddlState.DataValueField = "State";
            ddlState.DataTextField = "State";
            ddlState.DataBind();

            if (Request.QueryString["search_state"] == "NewAndInProgress")
            {
                ddlState.SelectedIndex = 5;
            }
            else
            {
                ddlState.SelectedValue = Request.QueryString["search_state"];
            }
        }



        private string GetNavigatorState()
        {           
            // Search and sort
            string searchOptions = "";
            searchOptions = searchOptions + "&search_ddlCondition1=" + ddlCondition1.SelectedValue;
            searchOptions = searchOptions + "&search_tbxCondition1=" + tbxCondition1.Text.Trim();
            searchOptions = searchOptions + "&search_sort_by=" + ddlSortBy.SelectedValue;
            if (ddlState.SelectedValue != "New & In Progress")
            {
                searchOptions = searchOptions + "&search_state=" + ddlState.SelectedValue;
            }
            else
            {
                searchOptions = searchOptions + "&search_state=NewAndInProgress";
            }

            // Return
            return searchOptions;
        }



        private ToDoListNavigatorTDS SubmitSearch()
        {
            // Retrieve clauses
            string whereClause = GetWhereClause();
            string orderByClause = GetOrderByClause();
            string conditionValue = "";
            string conditionName = "";

            ToDoListNavigator toDolistNavigator = new ToDoListNavigator();
            string fmType = hdfFmType.Value.Trim();
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            // ... Load data            
            FmTypeViewConditionGateway fmTypeViewConditionGateway = new FmTypeViewConditionGateway();
            fmTypeViewConditionGateway.LoadByFmTypeConditionId(fmType, companyId, int.Parse(ddlCondition1.SelectedValue));

            conditionValue = fmTypeViewConditionGateway.GetColumn_(fmType, companyId, int.Parse(ddlCondition1.SelectedValue));
            conditionName = fmTypeViewConditionGateway.GetName(fmType, companyId, int.Parse(ddlCondition1.SelectedValue));

            toDolistNavigator.Load(whereClause, orderByClause, conditionValue, conditionName, tbxCondition1.Text.Trim(), companyId, fmType);

            return (ToDoListNavigatorTDS)toDolistNavigator.Data;
        }

             
        
        private string GetWhereClause()
        {
            // General conditions
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            string whereClause = "(LFTDL.Deleted = 0) AND (LFTDL.COMPANY_ID = " + companyId + ") ";
                      
            // Field condition
            // ... Condition 1
            whereClause = modifyWhereClauseForCondition(whereClause, int.Parse(ddlCondition1.SelectedValue), tbxCondition1.Text.Trim());

            return whereClause;
        }



        private string modifyWhereClauseForCondition(string whereClause, int conditionId, string textForSearch)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string fmType = hdfFmType.Value;

            FmTypeViewConditionGateway fmTypeViewConditionGateway = new FmTypeViewConditionGateway();
            fmTypeViewConditionGateway.LoadByFmTypeConditionId(fmType, companyId, conditionId);

            string conditionValue = fmTypeViewConditionGateway.GetColumn_(fmType, companyId, conditionId);
            string conditionName = fmTypeViewConditionGateway.GetName(fmType, companyId, conditionId);
            string tableName = fmTypeViewConditionGateway.GetTable_(fmType, companyId, conditionId);

            if (tableName == "LFS_FM_TODOLIST") tableName = "LFTDL";
            if (tableName == "LFS_EMPLOYEE") tableName = "LRE";
            if (tableName == "LFS_FM_UNIT") tableName = "LFU";
            if (tableName == "LFS_FM_TODOLIST_ACTIVITY") tableName = "LFTDLA";

            if (conditionName == "Created By") tableName = "LEOwner";

            // FOR TEXT FIELDS. (Subject, Unit Code)
            if ((conditionValue == "Subject") || (conditionValue == "UnitCode"))
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
                            if (conditionValue == "LastComment")
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

            // FOR DATE FIELDS. (CreationDate, DueDate)
            if ((conditionValue == "CreationDate") || (conditionValue == "DueDate"))
            {
                // ... Search
                if (textForSearch == "")
                {
                    whereClause = whereClause + " AND ( CAST(CONVERT(varchar," + tableName + "." + conditionValue + ", 101) AS smalldatetime) IS NULL)";
                }
                else
                {
                    if (textForSearch == "%")
                    {
                        whereClause = whereClause + " AND (( CAST(CONVERT(varchar," + tableName + "." + conditionValue + ", 101) AS smalldatetime) IS NOT NULL) OR ";
                        whereClause = whereClause + "( CAST(CONVERT(varchar," + tableName + "." + conditionValue + ", 101) AS smalldatetime) IS NULL))";
                    }
                    else
                    {
                        if ((Validator.IsValidDate(textForSearch)) && (textForSearch.Length > 7))
                        {
                            whereClause = whereClause + " AND ( CAST(CONVERT(varchar," + tableName + "." + conditionValue + ", 101) AS smalldatetime) = '" + textForSearch + "')";                            
                        }
                        else
                        {
                            whereClause = whereClause + " AND ( CAST(CONVERT(varchar," + tableName + "." + conditionValue + ", 101) AS smalldatetime) LIKE '%" + textForSearch + "%')";
                        }
                    }
                }
            }

            string state = ddlState.SelectedValue;
            if (state != "(All)")
            {
                if (state != "New & In Progress")
                {
                    whereClause = whereClause + "AND (LFTDL.State = '" + state + "')";
                }
                else
                {
                    whereClause = whereClause + "AND (LFTDL.State = 'New' OR LFTDL.State = 'In Progress')";
                }
            }


            return whereClause;
        }



        private string GetOrderByClause()
        {
            // Get tableName
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string fmType = hdfFmType.Value;

            FmTypeViewSortGateway fmTypeViewSortGateway = new FmTypeViewSortGateway();
            fmTypeViewSortGateway.LoadByFmTypeSortId(fmType, companyId, int.Parse(ddlSortBy.SelectedValue));

            string tableName = fmTypeViewSortGateway.GetTable_(fmType, companyId, int.Parse(ddlSortBy.SelectedValue));
            string columnName = fmTypeViewSortGateway.GetColumn_(fmType, companyId, int.Parse(ddlSortBy.SelectedValue));
            string conditionName = fmTypeViewSortGateway.GetName(fmType, companyId, int.Parse(ddlSortBy.SelectedValue));

            if (tableName == "LFS_FM_TODOLIST") tableName = "LFTDL";
            if (tableName == "LFS_EMPLOYEE") tableName = "LRE";
            if (tableName == "LFS_FM_UNIT") tableName = "LFU";
            if (tableName == "LFS_FM_TODOLIST_ACTIVITY") tableName = "LFTDLA";


            FmTypeViewConditionGateway fmTypeViewConditionGateway = new FmTypeViewConditionGateway();
            fmTypeViewConditionGateway.LoadByFmTypeConditionId(fmType, companyId, int.Parse(ddlCondition1.SelectedValue));

            string conditionValue = fmTypeViewConditionGateway.GetColumn_(fmType, companyId, int.Parse(ddlCondition1.SelectedValue));

            // Get order by clause
            string orderBy = "";

            // ... For Names Assigned To
            if (ddlSortBy.SelectedValue == "3")
            {
                orderBy = " ORDER BY LastAssignedTeamMemberName ASC";
            }
            else
            {
                // .... For CreatedBy
                if (ddlSortBy.SelectedValue == "2")
                {
                    orderBy = " ORDER BY OwnerName ASC";
                }
                else
                {
                    // For Fields
                    if (columnName == "CreationDate")
                    {
                        orderBy = " ORDER BY LFTDL.CreationDate DESC";
                    }
                    else
                    {
                        if (columnName == "DueDate")
                        {
                            orderBy = " ORDER BY LFTDL.DueDate DESC";
                        }
                        else
                        {
                            if (conditionName == "State")
                            {
                                orderBy = " ORDER BY LFTDL.State ASC";
                            }
                            else
                            {
                                orderBy = " ORDER BY " + tableName + "." + columnName;
                            }
                        }
                    }
                }
            }  

            return orderBy;
        }
                      
        

        private string GetColumnsToDisplay()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string fmType = hdfFmType.Value;
            string columnsToDisplay = "&columns_to_display=";

            if (hdfBtnOrigin.Value == "Search")
            {
                FmTypeViewDisplay fmTypeViewDisplay = new FmTypeViewDisplay();
                columnsToDisplay = columnsToDisplay + fmTypeViewDisplay.GetColumnsByDefault(fmType, companyId, true);
            }            

            return columnsToDisplay;
        }

                     

    }
}