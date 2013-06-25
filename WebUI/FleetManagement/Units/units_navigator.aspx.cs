using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.FleetManagement.Common;
using LiquiForce.LFSLive.BL.FleetManagement.Units;
using LiquiForce.LFSLive.DA.FleetManagement.Common;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Units
{
    /// <summary>
    /// units_navigator
    /// </summary>
    public partial class units_navigator : System.Web.UI.Page
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
                if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_UNITS_VIEW"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in units_navigator.aspx");
                }                

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfFmType.Value = "Units";

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

                // ... units_navigator2.aspx
                if (Request.QueryString["source_page"] == "units_navigator2.aspx")
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

                Session.Remove("arrayCategoriesSelectedForEdit");
                Session.Remove("arrayCompanyLevelsSelectedForEdit");
                Session.Remove("categoriesTDS");
                Session.Remove("companyLevelsTDS");
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
                UnitsNavigatorTDS unitsNavigatorTDS = SubmitSearch();

                // Show results
                if (unitsNavigatorTDS.UnitsNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["unitsNavigatorTDS"] = unitsNavigatorTDS;

                    // ... Go to the results page
                    Response.Redirect("./units_navigator2.aspx?source_page=units_navigator.aspx" + GetNavigatorState());
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
                UnitsNavigatorTDS unitsNavigatorTDS = SubmitSearchForViews();

                // Show results
                if (unitsNavigatorTDS.UnitsNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["unitsNavigatorTDS"] = unitsNavigatorTDS;

                    // ... Go to the results page
                    Response.Redirect("./units_navigator2.aspx?source_page=units_navigator.aspx" + GetNavigatorState());
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
            //  Date fields validate
            if ((ddlCondition1.SelectedItem.Text == "Model Year") || (ddlCondition1.SelectedItem.Text == "Acquisition Date") || (ddlCondition1.SelectedItem.Text == "Qualified Date") || (ddlCondition1.SelectedItem.Text == "Not Qualified Date"))
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
            if ((ddlCondition1.SelectedItem.Text == "Model Year") || (ddlCondition1.SelectedItem.Text == "Acquisition Date") || (ddlCondition1.SelectedItem.Text == "Qualified Date") || (ddlCondition1.SelectedItem.Text == "Not Qualified Date"))
            {
                // For dates before 1900
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



        protected void cvForBoolean_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Booleans fields validate
            if ((ddlCondition1.SelectedItem.Text == "Is Towable?") || (ddlCondition1.SelectedItem.Text == "With alarms") || (ddlCondition1.SelectedItem.Text == "With services late") || (ddlCondition1.SelectedItem.Text == "With checklist in unknown state") || (ddlCondition1.SelectedItem.Text == "Is Reefer Equipped?") || (ddlCondition1.SelectedItem.Text == "Is PTO Equipped?"))
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



        protected void cvForMoneyCondition_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Double number fields validate
            if (ddlCondition1.SelectedItem.Text != "")
            {
                if (ddlCondition1.SelectedItem.Text == "Cost")
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./units_navigator.js");
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



        private UnitsNavigatorTDS SubmitSearch()
        {
            // Retrieve clauses
            string whereClause = GetWhereClause();
            string orderByClause = GetOrderByClause();
            string conditionValue = "";

            UnitsNavigator unitsNavigator = new UnitsNavigator();
            string fmType = hdfFmType.Value;
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());            

            // ... Load data            
            FmTypeViewConditionGateway fmTypeViewConditionGateway = new FmTypeViewConditionGateway();
            fmTypeViewConditionGateway.LoadByFmTypeConditionId(fmType, companyId, int.Parse(ddlCondition1.SelectedValue));

            conditionValue = fmTypeViewConditionGateway.GetColumn_(fmType, companyId, int.Parse(ddlCondition1.SelectedValue));

            unitsNavigator.Load(whereClause, orderByClause, conditionValue, tbxCondition1.Text.Trim(), companyId);

            return (UnitsNavigatorTDS)unitsNavigator.Data;
        }



        private UnitsNavigatorTDS SubmitSearchForViews()
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

            UnitsNavigator unitsNavigator = new UnitsNavigator();
            unitsNavigator.LoadForViewsFmTypeCompanyId(sqlCommand, fmType, companyId);

            return (UnitsNavigatorTDS)unitsNavigator.Data;
        }



        private string GetWhereClause()
        {
            // General conditions
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            string whereClause = "(FMU.Deleted = 0) AND (FMU.State <> 'Archived') AND (FMC.Deleted = 0) AND (FMU.COMPANY_ID = " + companyId + ") AND (FMC.COMPANY_ID = " + companyId + ") ";

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
            string tableName = fmTypeViewConditionGateway.GetTable_(fmType, companyId, conditionId);

            switch (tableName)
            {
                case "LFS_FM_UNIT":
                    tableName = "FMU";
                    break;

                case "LFS_FM_UNIT_COST_HISTORY":
                    tableName = "FMUCH";
                    break;

                case "LFS_FM_UNIT_VEHICLE":
                    tableName = "FMUV";
                    break;

                case "LFS_FM_COMPANYLEVEL":
                    if (conditionValue == "CompanyLevel")
                    {
                        conditionValue = "Name";
                        tableName = "FMC";
                    }
                    break;

                case "LFS_COUNTRY":
                    if (conditionValue == "LicenseCountry")
                    {
                        tableName = "LCL";
                    }
                    if (conditionValue == "OwnerCountry")
                    {

                        tableName = "LCO";
                    }
                    conditionValue = "Name";
                    break;

                case "LFS_PROVINCE":                    
                    if (conditionValue == "LicenseState")
                    {
                        tableName = "LPL";
                    }
                    if (conditionValue == "OwnerState")
                    {
                        
                        tableName = "LPO";
                    }
                    conditionValue = "Name";
                    break;
            }

            // FOR TEXT FIELDS.
            if ((conditionValue == "UnitCode") || (conditionValue == "VIN") || (conditionValue == "Description") || (conditionValue == "State") || (conditionValue == "Manufacturer") || (conditionValue == "Model") || (conditionValue == "Year_") || (conditionValue == "Categories") || (conditionValue == "Name") || (conditionValue == "OwnerType") || (conditionValue == "Notes") || (conditionValue == "LicenseCountry") || (conditionValue == "LicenseState") || (conditionValue == "LicensePlateNumbver") || (conditionValue == "AportionedTagNumber") || (conditionValue == "ActualWeight") || (conditionValue == "RegisteredWeight") || (conditionValue == "TireSizeFront") || (conditionValue == "TireSizeBack") || (conditionValue == "NumberOfAxes") || (conditionValue == "FuelType") || (conditionValue == "BeginningOdometer") || (conditionValue == "OwnerCountry") || (conditionValue == "OwnerState") || (conditionValue == "OwnerName") || (conditionValue == "OwnerContact") || (conditionValue == "NotQualifiedExplain") || (conditionValue == "InsuranceClass") || (conditionValue == "InsuranceClassRyderSpecified"))
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

            // FOR BOOLEAN FIELDS
            if ((conditionValue == "IsTowable") || (conditionValue == "IsReeferEquipped") || (conditionValue == "IsPTOEquipped"))
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

            // FOR DATE FIELDS. (AcquisitionDate, QualifiedDate, NotQualifiedDate)
            if ((conditionValue == "AcquisitionDate") || (conditionValue == "QualifiedDate") || (conditionValue == "NotQualifiedDate"))
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

            if (tableName == "LFS_FM_UNIT")
            {
                tableName = "FMU";
            }
            else
            {
                if ((tableName == "LFS_FM_COMPANYLEVEL") && (columnName == "CompanyLevel"))
                {
                    columnName = "Name";
                    tableName = "FMC";
                }
            }

            // Get order by clause
            string orderBy = "";

            if (columnName == "Notes" || columnName == "Categories")
            {
                orderBy = String.Format(" CAST({0}.{1} AS nvarchar)", tableName, columnName);
            }
            else
            {
                orderBy = tableName + "." + columnName;
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
            string fmType = hdfFmType.Value.Trim();
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