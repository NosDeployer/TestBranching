using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.FleetManagement.Common;
using LiquiForce.LFSLive.BL.ITTechSupportTicket.SupportTicket;
using LiquiForce.LFSLive.DA.FleetManagement.Common;
using LiquiForce.LFSLive.DA.ITTechSupportTicket.SupportTicket;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.WebUI.ITTechSupportTicket.SupportTicket
{
    /// <summary>
    /// supportTicket_navigator2
    /// </summary>
    public partial class supportTicket_navigator2 : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected SupportTicketNavigatorTDS supportTicketNavigatorTDS;






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
                if (!(Convert.ToBoolean(Session["sgLFS_ITTST_SUPPORTTICKET_ADMIN"])))
                {
                    if (!(Convert.ToBoolean(Session["sgLFS_ITTST_SUPPORTTICKET_VIEW"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in supportTicket_navigator2.aspx");
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
                // ... supportTicket_navigator.aspx or supportTicket_navigator2.aspx
                if ((Request.QueryString["source_page"] == "supportTicket_navigator.aspx") || (Request.QueryString["source_page"] == "supportTicket_navigator2.aspx"))
                {
                    RestoreNavigatorState();
                    supportTicketNavigatorTDS = (SupportTicketNavigatorTDS)Session["supportTicketNavigatorTDS"];
                }

                // ... supportTicket_edit.aspx, supportTicket_summary.aspx or supportTicket_delete.aspx
                if ((Request.QueryString["source_page"] == "supportTicket_edit.aspx") || (Request.QueryString["source_page"] == "supportTicket_summary.aspx") || (Request.QueryString["source_page"] == "supportTicket_delete.aspx"))
                {
                    RestoreNavigatorState();

                    if (Request.QueryString["update"] == "no")
                    {
                        supportTicketNavigatorTDS = (SupportTicketNavigatorTDS)Session["supportTicketNavigatorTDS"];
                    }
                    else
                    {
                        // ... Delete store data
                        Session.Contents.Remove("supportTicketNavigatorTDS");
                        supportTicketNavigatorTDS = SubmitSearch();
                        
                        // ... store datasets
                        Session["supportTicketNavigatorTDS"] = supportTicketNavigatorTDS;
                    }
                }

                // ... supportTicket_delete.aspx, supportTicket_summary.aspx or supportTicket_edit.aspx
                if ((Request.QueryString["source_page"] == "supportTicket_delete.aspx") || (Request.QueryString["source_page"] == "supportTicket_summary.aspx") || (Request.QueryString["source_page"] == "supportTicket_edit.aspx"))
                {
                    if (supportTicketNavigatorTDS.SupportTicketNavigator.Rows.Count == 0)
                    {
                        string url = "./supportTicket_navigator.aspx?source_page=supportTicket_navigator2.aspx&fm_type=" + hdfFmType.Value + GetNavigatorState() + "&no_results=yes";
                        Response.Redirect(url);
                    }
                }

                // For the grid
                grdSupportTicketNavigator.DataSource = supportTicketNavigatorTDS.SupportTicketNavigator;
                grdSupportTicketNavigator.DataBind();

                //... for the total rows
                if (supportTicketNavigatorTDS.SupportTicketNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + supportTicketNavigatorTDS.SupportTicketNavigator.Rows.Count;
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
                supportTicketNavigatorTDS = (SupportTicketNavigatorTDS)Session["supportTicketNavigatorTDS"];

                // ... for the total rows
                if (supportTicketNavigatorTDS.SupportTicketNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + supportTicketNavigatorTDS.SupportTicketNavigator.Rows.Count;
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
                Session.Contents.Remove("supportTicketNavigatorTDS");

                // Get data from DA gateway
                supportTicketNavigatorTDS = SubmitSearch();

                // Show results
                if (supportTicketNavigatorTDS.SupportTicketNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["supportTicketNavigatorTDS"] = supportTicketNavigatorTDS;

                    // ... Go to the results page
                    url = "./supportTicket_navigator2.aspx?source_page=supportTicket_navigator2.aspx" + GetNavigatorState();
                }
                else
                {
                    // ... Go to the search page
                    url = "./supportTicket_navigator.aspx?source_page=supportTicket_navigator2.aspx" + GetNavigatorState() + "&no_results=yes";
                }

                Response.Redirect(url);
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm7 master = (mForm7)this.Master;
            master.ActiveToolbar = "ITTechSupportTicket";
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
            
            PostPageChanges();

            int supportTicketId = GetSupportTicketId();
            if (supportTicketId > 0)
            {
                // Redirect
                string url = "./supportTicket_summary.aspx?source_page=supportTicket_navigator2.aspx&dashboard=False&supportTicket_id=" + supportTicketId + GetNavigatorState();
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
            
            PostPageChanges();

            int supportTicketId = GetSupportTicketId();
            if (supportTicketId > 0)
            {
                // Redirect
                //string url = "./supportTicket_edit.aspx?source_page=supportTicket_navigator2.aspx&dashboard=False&supportTicket_id=" + supportTicketId + GetNavigatorState();
                string url = "./supportTicket_summary.aspx?source_page=supportTicket_navigator2.aspx&dashboard=False&supportTicket_id=" + supportTicketId + GetNavigatorState();
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
            string title = "IT Tech Support Ticket Search Results";

            // ... For comments option
            string comments = "None";

            // Establishing header values                        
            if (grdSupportTicketNavigator.Columns[2].Visible) headerValues += "Date";
            if (grdSupportTicketNavigator.Columns[3].Visible) headerValues += " * Category";
            if (grdSupportTicketNavigator.Columns[4].Visible) headerValues += " * Created By";
            if (grdSupportTicketNavigator.Columns[5].Visible) headerValues += " * Assigned To";
            if (grdSupportTicketNavigator.Columns[6].Visible) headerValues += " * Subject";
            if (grdSupportTicketNavigator.Columns[8].Visible) headerValues += " * Due Date";
            if (grdSupportTicketNavigator.Columns[9].Visible) headerValues += " * State";

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

            if (grdSupportTicketNavigator.Columns[7].Visible) comments = "Last Action Comment";

            // Report call
            Page.Validate();
            if (Page.IsValid)
            {
                PostPageChanges();
                title = title.Replace("'", "%27");
                Response.Write("<script language='javascript'> {window.open('./supportTicket_print_search_results_report.aspx?" + columnsForReport + "&comments=" + comments + "&totalColumnsPreview=" + totalColumnsPreview + "&totalColumnsExport=" + totalColumnsExport + "&totalSelectedColumns=" + columns.Length + "&title=" + title + "&format=pdf', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
            }

            if (url != "") Response.Redirect(url);
        }



        protected void btnExportList_Click(object sender, EventArgs e)
        {
            string url = "";
            string headerValues = "";
            int totalColumnsExport = 8;
            int totalColumnsPreview = 7;
            string title = "IT Tech Support Ticket Search Results";
            string columnsForReport = "";
            int j;

            // ... For comments option
            string comments = "None";

            headerValues = "";
            columnsForReport = "";

            // Establishing header values                        
            if (grdSupportTicketNavigator.Columns[2].Visible) headerValues += "Date";
            if (grdSupportTicketNavigator.Columns[3].Visible) headerValues += " * Category";
            if (grdSupportTicketNavigator.Columns[4].Visible) headerValues += " * Created By";
            if (grdSupportTicketNavigator.Columns[5].Visible) headerValues += " * Assigned To";
            if (grdSupportTicketNavigator.Columns[6].Visible) headerValues += " * Subject";
            if (grdSupportTicketNavigator.Columns[7].Visible) headerValues += " * Last Action Comment";
            if (grdSupportTicketNavigator.Columns[8].Visible) headerValues += " * Due Date";
            if (grdSupportTicketNavigator.Columns[9].Visible) headerValues += " * State";
            
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

            if (grdSupportTicketNavigator.Columns[6].Visible) comments = "Last Action Comment";

            // Report call
            Page.Validate();
            if (Page.IsValid)
            {
                PostPageChanges();
                title = title.Replace("'", "%27");
                Response.Write("<script language='javascript'> {window.open('./supportTicket_print_search_results_report.aspx?" + columnsForReport + "&comments=" + comments + "&totalColumnsPreview=" + totalColumnsPreview + "&totalColumnsExport=" + totalColumnsExport + "&totalSelectedColumns=" + columnsExcel.Length + "&title=" + title + "&format=excel', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
            }

            if (url != "") Response.Redirect(url);
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            
            PostPageChanges();

            int supportTicketId = GetSupportTicketId();

            if (supportTicketId > 0)
            {
                // Redirect
                string url = "./supportTicket_delete.aspx?source_page=supportTicket_navigator2.aspx&dashboard=False&supportTicket_id=" + supportTicketId + GetNavigatorState();
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
            string url = "./supportTicket_navigator.aspx?source_page=lm";

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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./supportTicket_navigator2.js");
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



        private SupportTicketNavigatorTDS SubmitSearch()
        {
            // Retrieve clauses
            string whereClause = GetWhereClause();
            string orderByClause = GetOrderByClause();
            string conditionValue = "";
            string conditionName = "";

            SupportTicketNavigator supportTicketNavigator = new SupportTicketNavigator();
            string fmType = hdfFmType.Value.Trim();
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            // ... Load data            
            FmTypeViewConditionGateway fmTypeViewConditionGateway = new FmTypeViewConditionGateway();
            fmTypeViewConditionGateway.LoadByFmTypeConditionId(fmType, companyId, int.Parse(ddlCondition1.SelectedValue));

            conditionValue = fmTypeViewConditionGateway.GetColumn_(fmType, companyId, int.Parse(ddlCondition1.SelectedValue));
            conditionName = fmTypeViewConditionGateway.GetName(fmType, companyId, int.Parse(ddlCondition1.SelectedValue));

            supportTicketNavigator.Load(whereClause, orderByClause, conditionValue, conditionName, tbxCondition1.Text.Trim(), companyId);

            return (SupportTicketNavigatorTDS)supportTicketNavigator.Data;
        }



        private string GetWhereClause()
        {
            // General conditions
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            string whereClause = "(LITST.Deleted = 0) AND (LITST.COMPANY_ID = " + companyId + ") ";

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

            if (tableName == "LFS_ITTST_SUPPORTICKET") tableName = "LITST";
            if (tableName == "LFS_FM_TODOLIST") tableName = "LITST";
            if (tableName == "LFS_EMPLOYEE") tableName = "LRE";
            if (tableName == "LFS_ITTST_SUPPORTICKET_ACTIVITY") tableName = "LITSTA";
            if (tableName == "LFS_FM_TODOLIST_ACTIVITY") tableName = "LITSTA";

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
                    whereClause = whereClause + "AND (LITST.State = '" + state + "')";
                }
                else
                {
                    whereClause = whereClause + "AND (LITST.State = 'New' OR LITST.State = 'In Progress')";
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

            if (tableName == "LFS_ITTST_SUPPORTICKET") tableName = "LITST";
            if (tableName == "LFS_FM_TODOLIST") tableName = "LITST";
            if (tableName == "LFS_EMPLOYEE") tableName = "LRE";
            if (tableName == "LFS_ITTST_SUPPORTICKET_ACTIVITY") tableName = "LITSTA";
            if (tableName == "LFS_FM_TODOLIST_ACTIVITY") tableName = "LITSTA";

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
                        orderBy = " ORDER BY LITST.CreationDate DESC";
                    }
                    else
                    {
                        if (columnName == "DueDate")
                        {
                            orderBy = " ORDER BY LITST.DueDate DESC";
                        }
                        else
                        {
                            if (conditionName == "State")
                            {
                                orderBy = " ORDER BY LITST.State ASC";
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
            SupportTicketNavigator supportTicketNavigator = new SupportTicketNavigator(supportTicketNavigatorTDS);

            // Update supportTicketNavigator rows
            foreach (GridViewRow row in grdSupportTicketNavigator.Rows)
            {
                string supportTicketIdLabel = ((Label)row.FindControl("lblSupportTicketId")).Text.Trim();
                int supportTicketId = Int32.Parse(supportTicketIdLabel.ToString().Trim());
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                supportTicketNavigator.Update(supportTicketId, selected);
            }

            supportTicketNavigator.Data.AcceptChanges();

            // Store datasets
            Session["supportTicketNavigatorTDS"] = supportTicketNavigatorTDS;
        }



        private int GetSupportTicketId()
        {
            int supportTicketId = 0;

            foreach (SupportTicketNavigatorTDS.SupportTicketNavigatorRow supportTicketNavigatorRow in supportTicketNavigatorTDS.SupportTicketNavigator)
            {
                if (supportTicketNavigatorRow.Selected)
                {
                    supportTicketId = supportTicketNavigatorRow.SupportTicketID;
                }
            }

            return supportTicketId;
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