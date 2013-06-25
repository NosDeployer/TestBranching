using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.DA.FleetManagement.Services;
using LiquiForce.LFSLive.BL.FleetManagement.Services;
using LiquiForce.LFSLive.DA.FleetManagement.Common;
using LiquiForce.LFSLive.BL.FleetManagement.Common;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Services
{
    /// <summary>
    /// services_navigator
    /// </summary>
    public partial class services_navigator : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ServicesNavigatorTDS servicesNavigatorTDS;
        





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
                if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_VIEW"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null) 
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in services_navigator.aspx");
                }                

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfFmType.Value = "Services";

                // Prepare initial data
                // ... For sortByList
                odsSortByList.DataBind();
                ddlSortBy.DataSourceID = "odsSortByList";
                ddlSortBy.DataValueField = "SortID";
                ddlSortBy.DataTextField = "Name";
                ddlSortBy.DataBind();

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
                string viewTypeGlobal = "";
                string viewTypePersonal = "Personal";

                // Global Views check
                if (Convert.ToBoolean(Session["sgLFS_GLOBALVIEWS_VIEW"]))
                {
                    viewTypeGlobal = "Global";
                }                

                FmViewList fmViewList = new FmViewList();
                fmViewList.LoadAndAddItem(fmType, viewTypeGlobal, viewTypePersonal, loginId, companyId);
                ddlView.DataSource = fmViewList.Table;
                ddlView.DataValueField = "ViewID";
                ddlView.DataTextField = "Name";
                ddlView.DataBind();
                ddlView.SelectedIndex = 1;

                // If coming from 
                // ... Left Menu or out
                if ((Request.QueryString["source_page"] == "lm") || (Request.QueryString["source_page"] == "out"))
                {
                    tdNoResults.Visible = false;
                }

                // ... services_navigator2.aspx
                if (Request.QueryString["source_page"] == "services_navigator2.aspx")
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
            else
            {
                
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
                ServicesNavigatorTDS servicesNavigatorTDS = SubmitSearch();

                 //Show results
                if (servicesNavigatorTDS.ServicesNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["servicesNavigatorTDS"] = servicesNavigatorTDS;

                    // ... Go to the results page
                    Response.Redirect("./services_navigator2.aspx?source_page=services_navigator.aspx" + GetNavigatorState());
                }
                else
                {
                    tdNoResults.Visible = true;
                }
            }
        }



        protected void btnGo_Click(object sender, EventArgs e)
        {
            // Tag Page
            hdfBtnOrigin.Value = "Go";

            // Get data from DA gateway
            if (Page.IsValid)
            {
                ServicesNavigatorTDS servicesNavigatorTDS = SubmitSearchForViews();

                // Show results
                if (servicesNavigatorTDS.ServicesNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["servicesNavigatorTDS"] = servicesNavigatorTDS;

                    // ... Go to the results page
                    Response.Redirect("./services_navigator2.aspx?source_page=services_navigator.aspx" + GetNavigatorState());
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

            // Validate left menu if the user has admin permission
            if (Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_ADMIN"]))
            {
                tkrpbLeftMenuAllServiceRequests.Visible = true;
                tkrpbLeftMenuMyServiceRequests.Visible = false;
                tkrpbLeftMenuTools.Visible = true;
            }
            else
            {
                tkrpbLeftMenuAllServiceRequests.Visible = false;
                tkrpbLeftMenuMyServiceRequests.Visible = true;
                tkrpbLeftMenuTools.Visible = false;
            }

            // View buttons
            if (Convert.ToBoolean(Session["sgLFS_VIEWS_DELETE"]))
            {
                btnViewDelete.Visible = true;
            }
            else
            {
                btnViewDelete.Visible = false;
            }

            if (Convert.ToBoolean(Session["sgLFS_VIEWS_EDIT"]))
            {
                btnViewEdit.Visible = true;
            }
            else
            {
                btnViewEdit.Visible = false;
            }

            if (Convert.ToBoolean(Session["sgLFS_VIEWS_ADD"]))
            {
                btnViewAdd.Visible = true;
            }
            else
            {
                btnViewAdd.Visible = false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void btnViewDelete_Click(object sender, EventArgs e)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            int viewId = Int32.Parse(ddlView.SelectedValue.Trim());

            if (!(Convert.ToBoolean(Session["sgLFS_GLOBALVIEWS_DELETE"])))
            {
                FmViewGateway fmViewGateway = new FmViewGateway();
                fmViewGateway.LoadByViewId(viewId, companyId);
                string viewType = fmViewGateway.GetType(viewId);

                if (viewType == "Global")
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }
            }

            UpdateDatabaseForViews();

            // ... For view ddl
            string fmType = hdfFmType.Value;
            int loginId = Convert.ToInt32(Session["loginID"]);
            string viewTypeGlobal = "";
            string viewTypePersonal = "Personal";

            // Global Views check
            if (Convert.ToBoolean(Session["sgLFS_GLOBALVIEWS_VIEW"]))
            {
                viewTypeGlobal = "Global";
            }

            FmViewList fmViewList = new FmViewList();
            fmViewList.LoadAndAddItem(fmType, viewTypeGlobal, viewTypePersonal, loginId, companyId);
            ddlView.DataSource = fmViewList.Table;
            ddlView.DataValueField = "ViewID";
            ddlView.DataTextField = "Name";
            ddlView.DataBind();
            ddlView.SelectedIndex = 1;
        }



        protected void cvForDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //  Date fields validate
            if ((ddlCondition1.SelectedItem.Text == "Start Date") || (ddlCondition1.SelectedItem.Text == "Complete Date") || (ddlCondition1.SelectedItem.Text == "Deadline Date") || (ddlCondition1.SelectedItem.Text == "Date & Time") || (ddlCondition1.SelectedItem.Text == "Assignment Date") || (ddlCondition1.SelectedItem.Text == "Accepted Date") || (ddlCondition1.SelectedItem.Text == "Unit Out Of Service Date") || (ddlCondition1.SelectedItem.Text == "Unit Back In Service Date"))
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
            if ((ddlCondition1.SelectedItem.Text == "Start Date") || (ddlCondition1.SelectedItem.Text == "Complete Date") || (ddlCondition1.SelectedItem.Text == "Deadline Date") || (ddlCondition1.SelectedItem.Text == "Date & Time") || (ddlCondition1.SelectedItem.Text == "Assignment Date") || (ddlCondition1.SelectedItem.Text == "Accepted Date") || (ddlCondition1.SelectedItem.Text == "Unit Out Of Service Date") || (ddlCondition1.SelectedItem.Text == "Unit Back In Service Date"))
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



        protected void cvForMoneyCondition_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // double number fields validate
            if (ddlCondition1.SelectedItem.Text != "")
            {
                if (ddlCondition1.SelectedItem.Text == "Labour Hours")
                {
                    if ((tbxCondition1.Text != "") && (tbxCondition1.Text != "%"))
                    {
                        if (Validator.IsValidDouble(args.Value.Trim()))
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
        }



        protected void cvForBoolean_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Booleans fields validate
            if ((ddlCondition1.SelectedItem.Text == "Fixed Date") || (ddlCondition1.SelectedItem.Text == "Preventable"))
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






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";
            contentVariables += "var ddlViewId = '" + ddlView.ClientID + "';";
            contentVariables += "var hdfFmTypeId = '" + hdfFmType.ClientID + "';";
            
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./services_navigator.js");
        }



        private void RestoreNavigatorState()
        {
            // Search condition 1
            // Columns To Display
            string columnsToDisplay = Request.QueryString["columns_to_display"];

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

            // ... ForView 
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string fmType = hdfFmType.Value;
            int loginId = Convert.ToInt32(Session["loginID"]);
            string viewTypeGlobal = "";
            string viewTypePersonal = "Personal";

            // Global Views check
            if (Convert.ToBoolean(Session["sgLFS_GLOBALVIEWS_VIEW"]))
            {
                viewTypeGlobal = "Global";
            }

            FmViewList fmViewList = new FmViewList();
            fmViewList.LoadAndAddItem(fmType, viewTypeGlobal, viewTypePersonal, loginId, companyId);
            ddlView.DataSource = fmViewList.Table;
            ddlView.DataValueField = "ViewID";
            ddlView.DataTextField = "Name";
            ddlView.DataBind();
            ddlView.SelectedValue = Request.QueryString["search_ddlView"];

            //Other values
            //... For State
            odsState.DataBind();
            ddlState.DataSourceID = "odsState";
            ddlState.DataValueField = "State";
            ddlState.DataTextField = "State";
            ddlState.DataBind();
            ddlState.SelectedValue = Request.QueryString["search_state"];

            //... For SortBy
            odsSortByList.DataBind();
            ddlSortBy.DataSourceID = "odsSortByList";
            ddlSortBy.DataValueField = "SortID";
            ddlSortBy.DataTextField = "Name";
            ddlSortBy.DataBind();
            ddlSortBy.SelectedValue = Request.QueryString["search_sort_by"];

            // ... For BtnOrigin
            hdfBtnOrigin.Value = Request.QueryString["btn_origin"];
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
            
            // For Views
            searchOptions = searchOptions + "&search_ddlView=" + ddlView.SelectedValue;

            // Other values
            searchOptions = searchOptions + "&search_state=" + ddlState.SelectedValue;
            searchOptions = searchOptions + "&search_sort_by=" + ddlSortBy.SelectedValue;
            searchOptions = searchOptions + "&btn_origin=" + hdfBtnOrigin.Value;

            // Return
            return columnsToDisplay + searchOptions;
        }



        private ServicesNavigatorTDS SubmitSearch()
        {
            // Retrieve clauses
            string whereClause = GetWhereClause();
            string orderByClause = GetOrderByClause();
            string conditionValue = "";

            ServicesNavigator servicesNavigator = new ServicesNavigator();
            string fmType = hdfFmType.Value.Trim();
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            // ... Load data            
            FmTypeViewConditionGateway fmTypeViewConditionGateway = new FmTypeViewConditionGateway();
            fmTypeViewConditionGateway.LoadByFmTypeConditionId(fmType, companyId, int.Parse(ddlCondition1.SelectedValue));

            conditionValue = fmTypeViewConditionGateway.GetColumn_(fmType, companyId, int.Parse(ddlCondition1.SelectedValue));

            servicesNavigator.Load(whereClause, orderByClause, conditionValue, tbxCondition1.Text.Trim(), companyId, fmType);

            return (ServicesNavigatorTDS)servicesNavigator.Data;
        }



        private ServicesNavigatorTDS SubmitSearchForViews()
        {
            int viewId = Int32.Parse(ddlView.SelectedValue.Trim());
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            // ... Load SqlCommand
            FmViewGateway fmViewGateway = new FmViewGateway();
            fmViewGateway.LoadByViewId(viewId, companyId);

            string sqlCommand = "";
            sqlCommand = fmViewGateway.GetSqlCommand(viewId);

            // ... Load data
            string fmType = hdfFmType.Value.Trim();

            ServicesNavigator servicesNavigator = new ServicesNavigator();
            servicesNavigator.LoadForViewsFmTypeCompanyId(sqlCommand, fmType, companyId);

            return (ServicesNavigatorTDS)servicesNavigator.Data;
        }



        private string GetWhereClause()
        {
            // General conditions
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            string whereClause = "(LFS.Deleted = 0) AND (LFU.Deleted = 0) AND (LFS.COMPANY_ID = " + companyId + ") AND (LFU.COMPANY_ID = " + companyId + ") ";
           
            // For state
            if( ddlState.SelectedValue == "(All)")
            {
                whereClause = whereClause +  " AND (LFS.State IS NOT NULL) ";
            }
            else
            {
                whereClause = whereClause + " AND (LFS.State = '" + ddlState.SelectedValue + "' ) ";
            }
            
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

            if (tableName == "LFS_FM_SERVICE") tableName = "LFS";
            if (tableName == "LFS_FM_SERVICE_VEHICLE") tableName = "LFSV";
            if (tableName == "LFS_FM_UNIT") tableName = "LFU";
            if (tableName == "LFS_FM_RULE") tableName = "LFR";
            if (tableName == "LFS_FM_CHECKLIST") tableName = "LFC";
            if (tableName == "LFS_FM_COMPANYLEVEL") tableName = "LFCL";

            if (conditionName == "Created By") tableName = "LEOwner";
            if (conditionName == "Assigned To") tableName = "LEAssignedTo";

            // FOR TEXT FIELDS. (Service Number, Unit Code, Unit Description, Notes, Created by, Assigned to, Checklist Rules)
            if ((conditionValue == "Number") || (conditionValue == "UnitCode") || (conditionValue == "Description") || (conditionValue == "VIN") || (conditionValue == "Notes") || (conditionValue == "FullName") || (conditionValue == "Name") || (conditionValue == "VIN") || (conditionValue == "State") || (conditionValue == "Mileage") || (conditionValue == "StartWorkOutOfServiceTime") || (conditionValue == "StartWorkMileage") || (conditionValue == "CompleteWorkBackToServiceTime") || (conditionValue == "CompleteWorkMileage") || (conditionValue == "CompleteWorkDetailDescription"))
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
                            if (conditionValue == "Notes")
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

            // FOR DATE FIELDS. (StartWorkDateTime, CompleteWorkDateTime, AssignDeadlineDate)
            if ((conditionValue == "StartWorkDateTime") || (conditionValue == "CompleteWorkDateTime") || (conditionValue == "AssignDeadlineDate") || (conditionValue == "DateTime_") || (conditionValue == "AssignDateTime") || (conditionValue == "AcceptDateTime") || (conditionValue == "StartWorkOutOfServiceDate") || (conditionValue == "CompleteWorkBackToServiceDate"))
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
                            //whereClause = whereClause + " AND ( CAST(CONVERT(varchar," + tableName + "." + conditionValue + ", 101) AS smalldatetime) = '" + textForSearch + "')";
                            whereClause = whereClause + " AND ( CAST(CONVERT(varchar," + tableName + "." + conditionValue + ", 101) AS smalldatetime) LIKE '%" + textForSearch + "%')";
                        }
                        else
                        {
                            whereClause = whereClause + " AND ( CAST(CONVERT(varchar," + tableName + "." + conditionValue + ", 101) AS smalldatetime) LIKE '%" + textForSearch + "%')";
                        }
                    }
                }
            }

            // FOR BOOLEAN FIELDS
            if ((conditionValue == "MTO") || (conditionValue == "CompleteWorkDetailPreventable"))
            {
                if (textForSearch != "")
                {
                    if ((textForSearch.ToUpper() == "Y") || (textForSearch.ToUpper() == "YES"))
                    {
                        whereClause = whereClause + " AND (" + tableName + "." + conditionValue + " = 1)";
                    }
                    else
                    {
                        if ((textForSearch.ToUpper() == "N") || (textForSearch.ToUpper() == "NO"))
                        {
                            whereClause = whereClause + " AND (" + tableName + "." + conditionValue + " = 0)";
                        }
                        else
                        {
                            if (textForSearch == "%")
                            {
                                whereClause = whereClause + " AND ((" + tableName + "." + conditionValue + " = 1) OR (" + tableName + "." + conditionValue + " = 0))";
                            }
                        }
                    }
                }
            }

            // FOR DECIMAL FIELDS
            if (conditionValue == "CompleteWorkDetailTMLabourHours")
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
                        whereClause = whereClause + " AND (" + tableName + "." + conditionValue + "=" + textForSearch + ")";
                    }
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

            if (tableName == "LFS_FM_SERVICE") tableName = "LFS";
            if (tableName == "LFS_FM_UNIT") tableName = "LFU";
            if (tableName == "LFS_FM_RULE") tableName = "LFR";
            if (conditionName == "Created By") tableName = "LEOwner";
            if (conditionName == "Assigned To") tableName = "LEAssignedTo";

            FmTypeViewConditionGateway fmTypeViewConditionGateway = new FmTypeViewConditionGateway();
            fmTypeViewConditionGateway.LoadByFmTypeConditionId(fmType, companyId, int.Parse(ddlCondition1.SelectedValue));

            string conditionValue = fmTypeViewConditionGateway.GetColumn_(fmType, companyId, int.Parse(ddlCondition1.SelectedValue));

            // Get order by clause
            string orderBy = "";

            if (columnName == "Date")
            {
                switch (conditionValue)
                {
                    case "StartWorkDateTime":
                        orderBy = " ORDER BY LFS.StartWorkDateTime DESC";
                        break;

                    case "CompleteWorkDateTime":
                        orderBy = " ORDER BY LFS.CompleteWorkDateTime DESC";
                        break;

                    case "AssignDeadlineDate":
                        orderBy = " ORDER BY LFS.AssignDeadlineDate DESC";
                        break;

                    case "DateTime_":
                        orderBy = " ORDER BY LFS.DateTime_ DESC";
                        break;

                    case "AssignDateTime":
                        orderBy = " ORDER BY LFS.AssignDateTime DESC";
                        break;

                    case "AcceptDateTime":
                        orderBy = " ORDER BY LFS.AcceptDateTime DESC";
                        break;

                    case "StartWorkOutOfServiceDate":
                        orderBy = " ORDER BY LFS.StartWorkOutOfServiceDate DESC";
                        break;

                    case "CompleteWorkBackToServiceDate":
                        orderBy = " ORDER BY LFS.CompleteWorkBackToServiceDate DESC";
                        break;

                    default:
                        orderBy = " ORDER BY LFS.ServiceID ASC";
                        break;
                }
            }
            else
            {
                if (columnName == "Number")
                {
                    orderBy = String.Format(" ORDER BY CASE WHEN 1 = IsNumeric({0}.{1}) THEN Cast({0}.{1} AS INT) END ", tableName, columnName);
                }
                else
                {
                    if (conditionName == "Problem Description")
                    {
                        orderBy = String.Format(" ORDER BY CAST({0}.{1} AS nvarchar) ", tableName, columnName);
                    }
                    else
                    {
                        orderBy = " ORDER BY " + tableName + "." + columnName;
                    }
                }
            }

            return orderBy;
        }



        private void UpdateDatabaseForViews()
        {
            int viewId = Int32.Parse(ddlView.SelectedValue.Trim());
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            DB.Open();
            DB.BeginTransaction();
            try
            {
                FmView fmView = new FmView(null);
                fmView.DeleteDirect(viewId, companyId);                

                DB.CommitTransaction();
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }            
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
            else
            {
                if (hdfBtnOrigin.Value == "Go")
                {
                    int viewId = Int32.Parse(ddlView.SelectedValue.Trim());
                    FmViewDisplay fmViewDisplay = new FmViewDisplay();
                    columnsToDisplay = columnsToDisplay + fmViewDisplay.GetColumnsToDisplayForViews(viewId, fmType, companyId);
                }
            }

            return columnsToDisplay;
        }
        
        

    }
}