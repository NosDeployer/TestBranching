using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.FleetManagement.ToDoList;
using LiquiForce.LFSLive.BL.FleetManagement.ToDoList;
using LiquiForce.LFSLive.DA.FleetManagement.Common;
using LiquiForce.LFSLive.BL.FleetManagement.Common;
using LiquiForce.LFSLive.DA.Resources.Employees;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.ToDoList
{
    /// <summary>
    /// toDoList_navigator2
    /// </summary>
    public partial class toDoList_navigator2 : System.Web.UI.Page
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
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in toDoList_navigator2.aspx");
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
                // ... toDoList_navigator.aspx or toDoList_navigator2.aspx
                if ((Request.QueryString["source_page"] == "toDoList_navigator.aspx") || (Request.QueryString["source_page"] == "toDoList_navigator2.aspx"))
                {
                    RestoreNavigatorState();
                    toDoListNavigatorTDS = (ToDoListNavigatorTDS)Session["toDoListNavigatorTDS"];
                }

                // ... toDoList_edit.aspx, toDoList_summary.aspx or toDoList_delete.aspx
                if ((Request.QueryString["source_page"] == "toDoList_edit.aspx") || (Request.QueryString["source_page"] == "toDoList_summary.aspx") || (Request.QueryString["source_page"] == "toDoList_delete.aspx"))
                {
                    RestoreNavigatorState();

                    if (Request.QueryString["update"] == "no")
                    {
                        toDoListNavigatorTDS = (ToDoListNavigatorTDS)Session["toDoListNavigatorTDS"];
                    }
                    else
                    {
                        // ... Delete store data
                        Session.Contents.Remove("toDoListNavigatorTDS");                                               
                        toDoListNavigatorTDS = SubmitSearch();
                        

                        // ... store datasets
                        Session["toDoListNavigatorTDS"] = toDoListNavigatorTDS;
                    }
                }

                // ... toDoList_delete.aspx, toDoList_summary.aspx or toDoList_edit.aspx
                if ((Request.QueryString["source_page"] == "toDoList_delete.aspx") || (Request.QueryString["source_page"] == "toDoList_summary.aspx") || (Request.QueryString["source_page"] == "toDoList_edit.aspx"))
                {
                    if (toDoListNavigatorTDS.ToDoListNavigator.Rows.Count == 0)
                    {
                        string url = "./toDoList_navigator.aspx?source_page=toDoList_navigator2.aspx&fm_type=" + hdfFmType.Value + GetNavigatorState() + "&no_results=yes";
                        Response.Redirect(url);
                    }
                }

                // For the grid
                grdToDoListNavigator.DataSource = toDoListNavigatorTDS.ToDoListNavigator;
                grdToDoListNavigator.DataBind();

                //... for the total rows
                if (toDoListNavigatorTDS.ToDoListNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + toDoListNavigatorTDS.ToDoListNavigator.Rows.Count;
                    lblTotalRows.Visible = true;
                }
                else
                {
                    lblTotalRows.Visible = false;
                }
            }
            else
            {
                // Restore TDS
                toDoListNavigatorTDS = (ToDoListNavigatorTDS)Session["toDoListNavigatorTDS"];
                
                // ... for the total rows
                if (toDoListNavigatorTDS.ToDoListNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + toDoListNavigatorTDS.ToDoListNavigator.Rows.Count;
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
            Page.Validate();

            if (Page.IsValid)
            {
                // Tag Page
                hdfBtnOrigin.Value = "Search";

                string url = "";

                // Delete store data
                Session.Contents.Remove("toDoListNavigatorTDS");

                // Get data from DA gateway
                toDoListNavigatorTDS = SubmitSearch();

                // Show results
                if (toDoListNavigatorTDS.ToDoListNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["toDoListNavigatorTDS"] = toDoListNavigatorTDS;

                    // ... Go to the results page
                    url = "./toDoList_navigator2.aspx?source_page=toDoList_navigator2.aspx" + GetNavigatorState();
                }
                else
                {
                    // ... Go to the search page
                    url = "./toDoList_navigator.aspx?source_page=toDoList_navigator2.aspx" + GetNavigatorState() + "&no_results=yes";
                }

                Response.Redirect(url);
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
        // NAVIGATION EVENTS
        //

        protected void btnOpen_Click(object sender, EventArgs e)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string fmType = hdfFmType.Value.Trim();

            PostPageChanges();

            int toDoId = GetToDoId();
            if (toDoId > 0)
            {
                // Redirect
                string url = "./toDoList_summary.aspx?source_page=toDoList_navigator2.aspx&dashboard=False&toDo_id=" + toDoId + GetNavigatorState();
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
            string fmType = hdfFmType.Value.Trim();

            PostPageChanges();

            int toDoId = GetToDoId();
            if (toDoId > 0)
            {
                // Redirect
                string url = "./toDoList_edit.aspx?source_page=toDoList_navigator2.aspx&dashboard=False&toDo_id=" + toDoId + GetNavigatorState();
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
            int totalColumnsExport = 8;
            int totalColumnsPreview = 7;
            string title = "To Do List Search Results";                     

            // ... For comments option
            string comments = "None";

            // Establishing header values                        
            if (grdToDoListNavigator.Columns[2].Visible) headerValues += "Date";
            if (grdToDoListNavigator.Columns[3].Visible) headerValues += " * Created By";
            if (grdToDoListNavigator.Columns[4].Visible) headerValues += " * Assigned To";
            if (grdToDoListNavigator.Columns[5].Visible) headerValues += " * Subject";
            if (grdToDoListNavigator.Columns[7].Visible) headerValues += " * Unit";
            if (grdToDoListNavigator.Columns[8].Visible) headerValues += " * Due Date";
            if (grdToDoListNavigator.Columns[9].Visible) headerValues += " * State";            

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

            if (grdToDoListNavigator.Columns[6].Visible) comments = "Last Action Comment";

            // Report call
            Page.Validate();
            if (Page.IsValid)
            {
                PostPageChanges();
                title = title.Replace("'", "%27");
                Response.Write("<script language='javascript'> {window.open('./toDoList_print_search_results_report.aspx?" + columnsForReport + "&comments=" + comments + "&totalColumnsPreview=" + totalColumnsPreview + "&totalColumnsExport=" + totalColumnsExport + "&totalSelectedColumns=" + columns.Length + "&title=" + title + "&format=pdf', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
            }              

            if (url != "") Response.Redirect(url);
        }



        protected void btnExportList_Click(object sender, EventArgs e)
        {
            string url = "";
            string headerValues = "";
            int totalColumnsExport = 8;
            int totalColumnsPreview = 7;
            string title = "To Do List Search Results";
            string columnsForReport = "";
            int j;                      

            // ... For comments option
            string comments = "None";

            headerValues = "";
            columnsForReport = "";

            // Establishing header values                        
            if (grdToDoListNavigator.Columns[2].Visible) headerValues += "Date";
            if (grdToDoListNavigator.Columns[3].Visible) headerValues += " * Created By";
            if (grdToDoListNavigator.Columns[4].Visible) headerValues += " * Assigned To";
            if (grdToDoListNavigator.Columns[5].Visible) headerValues += " * Subject";
            if (grdToDoListNavigator.Columns[6].Visible) headerValues += " * Last Action Comment";
            if (grdToDoListNavigator.Columns[7].Visible) headerValues += " * Unit";
            if (grdToDoListNavigator.Columns[8].Visible) headerValues += " * Due Date";
            if (grdToDoListNavigator.Columns[9].Visible) headerValues += " * State";            

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

            if (grdToDoListNavigator.Columns[6].Visible) comments = "Last Action Comment";

            // Report call
            Page.Validate();
            if (Page.IsValid)
            {
                PostPageChanges();
                title = title.Replace("'", "%27");
                Response.Write("<script language='javascript'> {window.open('./toDoList_print_search_results_report.aspx?" + columnsForReport + "&comments=" + comments + "&totalColumnsPreview=" + totalColumnsPreview + "&totalColumnsExport=" + totalColumnsExport + "&totalSelectedColumns=" + columnsExcel.Length + "&title=" + title + "&format=excel', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
            }                   

            if (url != "") Response.Redirect(url);
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string fmType = hdfFmType.Value.Trim();

            PostPageChanges();

            int toDoId = GetToDoId();

            if (toDoId > 0)
            {
                // Redirect
                string url = "./toDoList_delete.aspx?source_page=toDoList_navigator2.aspx&dashboard=False&toDo_id=" + toDoId + GetNavigatorState();
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
            string url = "./toDoList_navigator.aspx?source_page=lm";

            if (url != "") Response.Redirect(url);
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./toDoList_navigator2.js");
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



        private void PostPageChanges()
        {
            ToDoListNavigator toDoListNavigator = new ToDoListNavigator(toDoListNavigatorTDS);

            // Update toDoListNavigator rows
            foreach (GridViewRow row in grdToDoListNavigator.Rows)
            {
                string toDoIdLabel = ((Label)row.FindControl("lblToDoId")).Text.Trim();
                int toDoId = Int32.Parse(toDoIdLabel.ToString().Trim());
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                toDoListNavigator.Update(toDoId, selected);
            }

            toDoListNavigator.Data.AcceptChanges();

            // Store datasets
            Session["toDoListNavigatorTDS"] = toDoListNavigatorTDS;
        }



        private int GetToDoId()
        {
            int toDoId = 0;

            foreach (ToDoListNavigatorTDS.ToDoListNavigatorRow toDoListNavigatorRow in toDoListNavigatorTDS.ToDoListNavigator)
            {
                if (toDoListNavigatorRow.Selected)
                {
                    toDoId = toDoListNavigatorRow.ToDoID;
                }
            }

            return toDoId;
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