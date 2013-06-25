using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.CWP.RehabAssessment;
using LiquiForce.LFSLive.BL.CWP.RehabAssessment;
using LiquiForce.LFSLive.DA.CWP.Common;
using LiquiForce.LFSLive.BL.CWP.Common;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.Tools;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.RehabAssessment
{
    /// <summary>
    /// ra_navigator
    /// </summary>
    public partial class ra_navigator : System.Web.UI.Page
    {
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
                if (!(Convert.ToBoolean(Session["sgLFS_CWP_REHABASSESSMENT_VIEW"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["work_type"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in ra_navigator.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();
                hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();
                hdfWorkType.Value = Request.QueryString["work_type"].ToString();

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
                string workType = hdfWorkType.Value;
                int loginId = Convert.ToInt32(Session["loginID"]);
                string viewTypeGlobal = "";
                string viewTypePersonal = "Personal";

                // Global Views check
                if (Convert.ToBoolean(Session["sgLFS_GLOBALVIEWS_VIEW"]))
                {
                    viewTypeGlobal = "Global";
                }

                WorkViewList workViewList = new WorkViewList();
                workViewList.LoadAndAddItem(workType, viewTypeGlobal, viewTypePersonal, loginId, companyId);
                ddlView.DataSource = workViewList.Table;
                ddlView.DataValueField = "ViewID";
                ddlView.DataTextField = "Name";
                ddlView.DataBind();
                ddlView.SelectedIndex = 1;

                // ... for client
                int currentClientId = Int32.Parse(hdfCurrentClientId.Value.ToString());
                
                CompaniesGateway companiesGateway = new CompaniesGateway();
                companiesGateway.LoadByCompaniesId(currentClientId, companyId);
                lblTitleClientName.Text = "Client: " + companiesGateway.GetName(currentClientId);

                // ... for project
                int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());
                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(currentProjectId);
                string name = projectGateway.GetName(currentProjectId);
                if (name.Length > 23) name = name.Substring(0, 20) + "...";
                lblTitleProjectName.Text = " > Project: " + name + " (" + projectGateway.GetProjectNumber(currentProjectId) + ")";
                
                // If coming from 
                // ... Left Menu or jliner_main
                if ((Request.QueryString["source_page"] == "lm") || (Request.QueryString["source_page"] == "select_project.aspx"))
                {
                    tdNoResults.Visible = false;
                }

                // ... ra_navigator2.aspx
                if (Request.QueryString["source_page"] == "ra_navigator2.aspx")
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
                RaNavigatorTDS raNavigatorTDS = SubmitSearch();

                // Show results
                if (raNavigatorTDS.RaNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["raNavigatorTDS"] = raNavigatorTDS;

                    // ... Go to the results page
                    Response.Redirect("./ra_navigator2.aspx?source_page=ra_navigator.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState());
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
                RaNavigatorTDS raNavigatorTDS = SubmitSearchForViews();

                // Show results
                if (raNavigatorTDS.RaNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["raNavigatorTDS"] = raNavigatorTDS;

                    // ... Go to the results page
                    Response.Redirect("./ra_navigator2.aspx?source_page=ra_navigator.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState());
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
            master.ActiveToolbar = "eSewers";

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

        protected void cvForDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Date fields validate
            if ((ddlCondition1.SelectedItem.Text == "Pre-Flush Date") || (ddlCondition1.SelectedItem.Text == "Pre-Video Date") || (ddlCondition1.SelectedItem.Text == "Robotic Prep Date") || (ddlCondition1.SelectedItem.Text == "P1 Date") || (ddlCondition1.SelectedItem.Text == "M1 Date"))
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
            // Date fields validate
            if ((ddlCondition1.SelectedItem.Text == "Pre-Flush Date") || (ddlCondition1.SelectedItem.Text == "Pre-Video Date") || (ddlCondition1.SelectedItem.Text == "Robotic Prep Date") || (ddlCondition1.SelectedItem.Text == "P1 Date") || (ddlCondition1.SelectedItem.Text == "M1 Date"))
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



        protected void cvForBoolean_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Booleans fields validate
            if ((ddlCondition1.SelectedItem.Text == "Pipe Size Change?") || (ddlCondition1.SelectedItem.Text == "Standard Bypass?"))
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



        protected void cvForNumberCondition_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Integer number fields validate
            if ((ddlCondition1.SelectedItem.Text == "CXI's Removed") || (ddlCondition1.SelectedItem.Text == "Laterals") || (ddlCondition1.SelectedItem.Text == "Live Laterals"))
            {
                if ((tbxCondition1.Text != "") && (tbxCondition1.Text != "%"))
                {
                    if (Validator.IsValidInt32(args.Value.Trim()))
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



        protected void btnViewDelete_Click(object sender, EventArgs e)
        {
            int viewId = Int32.Parse(ddlView.SelectedValue.Trim());
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            if (!Convert.ToBoolean(Session["sgLFS_GLOBALVIEWS_DELETE"]))
            {
                WorkViewGateway workViewGateway = new WorkViewGateway();
                workViewGateway.LoadByViewId(viewId, companyId);
                string viewType = workViewGateway.GetType(viewId);

                if (viewType == "Global")
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }
            }

            UpdateDatabase();

            // ... For view ddl
            string workType = hdfWorkType.Value;
            int loginId = Convert.ToInt32(Session["loginID"]);
            string viewTypeGlobal = "";
            string viewTypePersonal = "Personal";

            // Global Views check
            if (Convert.ToBoolean(Session["sgLFS_GLOBALVIEWS_VIEW"]))
            {
                viewTypeGlobal = "Global";
            }

            WorkViewList workViewList = new WorkViewList();
            workViewList.LoadAndAddItem(workType, viewTypeGlobal, viewTypePersonal, loginId, companyId);
            ddlView.DataSource = workViewList.Table;
            ddlView.DataValueField = "ViewID";
            ddlView.DataTextField = "Name";
            ddlView.DataBind();
            ddlView.SelectedIndex = 1;
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("./../Common/select_project.aspx?source_page=ra_navigator.aspx&work_type=" + hdfWorkType.Value.Trim());
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mRehabAssessmentPlan":
                    url = "./ra_lining_plan.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value;
                    break;
            }

            if (url != "") Response.Redirect(url);
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfCurrentProjectIdId = '" + hdfCurrentProjectId.ClientID + "';";
            contentVariables += "var hdfCurrentClientIdId = '" + hdfCurrentClientId.ClientID + "';";
            contentVariables += "var hdfWorkTypeId = '" + hdfWorkType.ClientID + "';";
            contentVariables += "var ddlViewId = '" + ddlView.ClientID + "';";
            
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./ra_navigator.js");
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
            string workType = hdfWorkType.Value;
            int loginId = Convert.ToInt32(Session["loginID"]);
            string viewTypeGlobal = "";
            string viewTypePersonal = "Personal";

            // Global Views check
            if (Convert.ToBoolean(Session["sgLFS_GLOBALVIEWS_VIEW"]))
            {
                viewTypeGlobal = "Global";
            }

            WorkViewList workViewList = new WorkViewList();
            workViewList.LoadAndAddItem(workType, viewTypeGlobal, viewTypePersonal, loginId, companyId);
            ddlView.DataSource = workViewList.Table;
            ddlView.DataValueField = "ViewID";
            ddlView.DataTextField = "Name";
            ddlView.DataBind();
            ddlView.SelectedValue = Request.QueryString["search_ddlView"];

            //Other values
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
            searchOptions = searchOptions + "&search_sort_by=" + ddlSortBy.SelectedValue;
            searchOptions = searchOptions + "&btn_origin=" + hdfBtnOrigin.Value;

            // Return
            return columnsToDisplay + searchOptions;
        }



        private RaNavigatorTDS SubmitSearch()
        {           
            // Retrieve clauses
            string whereClause = GetWhereClause();
            string orderByClause = GetOrderByClause();
            string conditionValue = "";
            
            RaNavigator raNavigator = new RaNavigator();
            string workType = hdfWorkType.Value.Trim();
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());

            // ... Load data
            WorkTypeViewConditionGateway workTypeViewConditionGateway = new WorkTypeViewConditionGateway();
            workTypeViewConditionGateway.LoadByWorkTypeConditionId(workType, int.Parse(ddlCondition1.SelectedValue), companyId);

            conditionValue = workTypeViewConditionGateway.GetColumn_(workType, companyId, int.Parse(ddlCondition1.SelectedValue));

            raNavigator.Load(whereClause, orderByClause, conditionValue, tbxCondition1.Text.Trim(), companyId, currentProjectId, workType);

            return (RaNavigatorTDS)raNavigator.Data;
        }



        private RaNavigatorTDS SubmitSearchForViews()
        {            
            string sqlCommand = "";
            int viewId = Int32.Parse(ddlView.SelectedValue.Trim()); 

            RaNavigator raNavigator = new RaNavigator();
            string workType = hdfWorkType.Value.Trim();
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
            
            // ... Load SqlCommand
            WorkViewGateway workViewGateway = new WorkViewGateway();
            workViewGateway.LoadByViewId(viewId, companyId);

            sqlCommand = workViewGateway.GetSqlCommand(viewId);

            // ... Load data
            raNavigator.LoadForViewsProjectIdCompanyIdWorkType(sqlCommand, currentProjectId, companyId, workType);

            return (RaNavigatorTDS)raNavigator.Data;
        }



        private string GetWhereClause()
        {
            // General conditions
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            string whereClause = "(LW.Deleted = 0) AND (LW.COMPANY_ID = " + companyId + ") AND (LWR.Deleted = 0) AND (LWR.COMPANY_ID = " + companyId + ") AND (AA.Deleted = 0) AND (AA.COMPANY_ID = " + companyId + ") AND (AAS.Deleted = 0) AND (AAS.COMPANY_ID = " + companyId + ") AND (AASS.Deleted = 0) AND (AASS.COMPANY_ID = " + companyId + ")";
            whereClause = whereClause + "AND (LW.ProjectID = " + hdfCurrentProjectId.Value + ") AND (LW.WorkType='" + hdfWorkType.Value + "') ";
           
            // Field condition
            // ... Condition 1
            whereClause = modifyWhereClauseForCondition(whereClause, int.Parse(ddlCondition1.SelectedValue), tbxCondition1.Text.Trim());

            return whereClause;
        }



        private string modifyWhereClauseForCondition(string whereClause, int conditionId, string textForSearch)
        {
            string workType = hdfWorkType.Value.Trim();
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            WorkTypeViewConditionGateway workTypeViewConditionGateway = new WorkTypeViewConditionGateway();
            workTypeViewConditionGateway.LoadByWorkTypeConditionId(workType, conditionId, companyId);

            string conditionValue = workTypeViewConditionGateway.GetColumn_(workType, companyId, conditionId);
            string tableName = workTypeViewConditionGateway.GetTable_(workType, companyId, conditionId);
            
            if (tableName == "AM_ASSET_SEWER_SECTION") tableName = "AASS";
            if (tableName == "LFS_WORK_REHABASSESSMENT") tableName = "LWR";
            if (tableName == "LFS_ASSET_SEWER_SECTION") tableName = "LASS";
            if (tableName == "LFS_WORK") tableName = "LW";
            if (tableName == "LFS_MIGRATED_SECTIONS") tableName = "LMS";
            if (tableName == "LFS_WORK_FULLLENGTHLINING") tableName = "LWFLL";
            if (tableName == "LFS_WORK_FULLLENGTHLINING_M1") tableName = "LWFM1";
            if (tableName == "LFS_WORK_FULLLENGTHLINING_M2") tableName = "LWFLLM2";
            if (tableName == "LFS_WORK_FULLLENGTHLINING_P1") tableName = "LWFLP1";
            if (conditionValue == "USMHAddress") { tableName = "AASUSMH"; conditionValue = "Address"; }
            if (conditionValue == "DSMHAddress") { tableName = "AASDSMH"; conditionValue = "Address"; }

            // FOR TEXT FIELDS. (SubArea, Street, Id(Section), OriginalSectionID, Comments)
            if ((conditionValue == "SubArea") || (conditionValue == "Street") || (conditionValue == "FlowOrderID") || (conditionValue == "OriginalSectionID") || (conditionValue == "Comments")
                || (conditionValue == "MapSize") || (conditionValue == "Size_") || (conditionValue == "MapLength") || (conditionValue == "Length") || (conditionValue == "VideoLength") || (conditionValue == "ClientID") || (conditionValue == "MeasurementTakenBy")
                || (conditionValue == "Address") || (conditionValue == "USMHDepth") || (conditionValue == "USMHMouth12") || (conditionValue == "USMHMouth1") || (conditionValue == "USMHMouth2") || (conditionValue == "USMHMouth3") || (conditionValue == "USMHMouth4")
                || (conditionValue == "USMHMouth5") || (conditionValue == "DSMHDepth") || (conditionValue == "DSMHMouth12") || (conditionValue == "DSMHMouth1") || (conditionValue == "DSMHMouth2") || (conditionValue == "DSMHMouth3") || (conditionValue == "DSMHMouth4") || (conditionValue == "DSMHMouth5") || (conditionValue == "TrafficControl")
                || (conditionValue == "SiteDetails") || (conditionValue == "StandardBypassComments") || (conditionValue == "TrafficControlDetails") || (conditionValue == "MeasurementType") || (conditionValue == "MeasurementFromMH") || (conditionValue == "VideoDoneFromMH") || (conditionValue == "VideoDoneToMH") || (conditionValue == "Thickness"))
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

            // FOR DATE FIELDS. (PreFlushDate, PreVideoDate, P1Date, M1Date, RoboticPrepCompletedDate)
            if ((conditionValue == "PreFlushDate") || (conditionValue == "PreVideoDate") || (conditionValue == "P1Date") || (conditionValue == "M1Date") || (conditionValue == "RoboticPrepCompletedDate"))
            {
                // ... Search
                if (textForSearch == "")
                {
                    whereClause = whereClause + "  AND (  CAST(CONVERT(varchar," + tableName + "." + conditionValue + ", 101) AS smalldatetime) IS NULL)";
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

            // FOR INTEGER AND DOUBLE FIELDS. (Laterals, LiveLaterals, CXIsRemoved)
            if ((conditionValue == "Laterals") || (conditionValue == "LiveLaterals") || (conditionValue == "CXIsRemoved"))
            {
                string operatorValue = "=";

                // ... For operator =
                if (textForSearch == "")
                {
                    whereClause = whereClause + " AND (" + tableName + "." + conditionValue + " IS NULL )";
                }
                else
                {
                    if (textForSearch == "%")
                    {
                        whereClause = whereClause + " AND ((" + tableName + "." + conditionValue + " LIKE '%')";
                        whereClause = whereClause + " OR (" + tableName + "." + conditionValue + " IS NULL))";
                    }
                    else
                    {
                        whereClause = whereClause + " AND (" + tableName + "." + conditionValue + operatorValue + textForSearch + ")";
                    }
                }
            }

            // FOR BOOLEAN FIELDS
            if ((conditionValue == "PipeSizeChange") || (conditionValue == "StandardBypass") || (conditionValue == "RoboticPrepCompleted"))
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
            string workType = hdfWorkType.Value.Trim();
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            
            WorkTypeViewSortGateway workTypeViewSortGateway = new WorkTypeViewSortGateway();
            workTypeViewSortGateway.LoadByWorkTypeSortId(workType, companyId, int.Parse(ddlSortBy.SelectedValue));

            string tableName = workTypeViewSortGateway.GetTable_(workType, companyId, int.Parse(ddlSortBy.SelectedValue));
            string columnName = workTypeViewSortGateway.GetColumn_(workType, companyId, int.Parse(ddlSortBy.SelectedValue));
            
            if (tableName == "AM_ASSET_SEWER_SECTION") tableName = "AASS";
            if (tableName == "LFS_WORK_REHABASSESSMENT") tableName = "LWR";
            if (tableName == "LFS_ASSET_SEWER_SECTION") tableName = "LASS";
            if (tableName == "LFS_WORK") tableName = "LW";

            // Get order by clause
            string orderBy = "";

            orderBy = tableName + "."+columnName;

            return orderBy;
        }



        private void UpdateDatabase()
        {
            int viewId = Int32.Parse(ddlView.SelectedValue.Trim());
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            DB.Open();
            DB.BeginTransaction();
            try
            {
                WorkView workView = new WorkView(null);
                workView.DeleteDirect(viewId, companyId);                

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
            string workType = hdfWorkType.Value.Trim();
            string columnsToDisplay = "&columns_to_display=";

            if (hdfBtnOrigin.Value == "Search")
            {
                WorkTypeViewDisplay workTypeViewDisplay = new WorkTypeViewDisplay();
                columnsToDisplay = columnsToDisplay + workTypeViewDisplay.GetColumnsByDefault(workType, companyId, true);
            }
            else
            {
                if (hdfBtnOrigin.Value == "Go")
                {
                    int viewId = Int32.Parse(ddlView.SelectedValue.Trim());
                    WorkViewDisplay workViewDisplay = new WorkViewDisplay();
                    columnsToDisplay = columnsToDisplay + workViewDisplay.GetColumnsToDisplayForViews(viewId, workType, companyId);
                }
            }
            return columnsToDisplay;
        }



    }
}