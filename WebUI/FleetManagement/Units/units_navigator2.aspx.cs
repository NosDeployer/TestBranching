using System;
using System.Data;
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
    /// units_navigator2
    /// </summary>
    public partial class units_navigator2 : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected UnitsNavigatorTDS unitsNavigatorTDS;






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
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in units_navigator2.aspx");
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

                FmViewList fmViewList = new FmViewList(new DataSet());
                fmViewList.LoadAndAddItem(fmType, viewTypeGlobal, viewTypePersonal, loginId, companyId);
                ddlView.DataSource = fmViewList.Table;
                ddlView.DataValueField = "ViewID";
                ddlView.DataTextField = "Name";
                ddlView.DataBind();
                ddlView.SelectedIndex = 1;

                // If coming from
                // ... units_navigator.aspx or units_navigator2.aspx
                if ((Request.QueryString["source_page"] == "units_navigator.aspx") || (Request.QueryString["source_page"] == "units_navigator2.aspx"))
                {
                    RestoreNavigatorState();

                    unitsNavigatorTDS = (UnitsNavigatorTDS)Session["unitsNavigatorTDS"];
                }

                // ... units_edit.aspx, units_summary.aspx or units_delete.aspx
                if ((Request.QueryString["source_page"] == "units_edit.aspx") || (Request.QueryString["source_page"] == "units_summary.aspx") || (Request.QueryString["source_page"] == "units_delete.aspx"))
                {
                    RestoreNavigatorState();

                    if (Request.QueryString["update"] == "no")
                    {
                        unitsNavigatorTDS = (UnitsNavigatorTDS)Session["unitsNavigatorTDS"];
                    }
                    else
                    {
                        // ... Delete store data
                        Session.Contents.Remove("unitsNavigatorTDS");

                        // ... Search data with updates
                        if (hdfBtnOrigin.Value == "Search")
                        {
                            unitsNavigatorTDS = SubmitSearch();
                        }
                        else
                        {
                            if (hdfBtnOrigin.Value == "Go")
                            {
                                unitsNavigatorTDS = SubmitSearchForViews();
                            }
                        }

                        // ... store datasets
                        Session["unitsNavigatorTDS"] = unitsNavigatorTDS;
                    }
                }

                // ... units_delete.aspx, units_summary.aspx or units_edit.aspx
                if ((Request.QueryString["source_page"] == "units_delete.aspx") || (Request.QueryString["source_page"] == "units_summary.aspx") || (Request.QueryString["source_page"] == "units_edit.aspx"))
                {
                    try
                    {
                        if (unitsNavigatorTDS.UnitsNavigator.Rows.Count == 0)
                        {
                            string url = "./units_navigator.aspx?source_page=units_navigator2.aspx&fm_type=" + hdfFmType.Value + GetNavigatorState() + "&no_results=yes";
                            Response.Redirect(url);
                        }
                    }
                    catch
                    {
                        string url = "./units_navigator.aspx?source_page=out";
                        Response.Redirect(url);
                    }
                }

                // For the grid
                grdUnitsNavigator.DataSource = unitsNavigatorTDS.UnitsNavigator;
                grdUnitsNavigator.DataBind();;

                //... for the total rows
                if (unitsNavigatorTDS.UnitsNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + unitsNavigatorTDS.UnitsNavigator.Rows.Count;
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
                unitsNavigatorTDS = (UnitsNavigatorTDS)Session["unitsNavigatorTDS"];

                // ... for the total rows
                if (unitsNavigatorTDS.UnitsNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + unitsNavigatorTDS.UnitsNavigator.Rows.Count;
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
                Session.Contents.Remove("unitsNavigatorTDS");

                // Get data from DA gateway
                unitsNavigatorTDS = SubmitSearch();

                // Show results
                if (unitsNavigatorTDS.UnitsNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["unitsNavigatorTDS"] = unitsNavigatorTDS;

                    // ... Go to the results page
                    url = "./units_navigator2.aspx?source_page=units_navigator2.aspx" + GetNavigatorState();
                }
                else
                {
                    // ... Go to the search page
                    url = "./units_navigator.aspx?source_page=units_navigator2.aspx" + GetNavigatorState() + "&no_results=yes";
                }

                Response.Redirect(url);
            }
        }



        protected void btnGo_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // Tag Page
                hdfBtnOrigin.Value = "Go";

                string url = "";

                // Delete store data
                Session.Contents.Remove("unitsNavigatorTDS");

                // Get data from DA gateway
                unitsNavigatorTDS = SubmitSearchForViews();

                // Show results
                if (unitsNavigatorTDS.UnitsNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["unitsNavigatorTDS"] = unitsNavigatorTDS;

                    // ... Go to the results page
                    url = "./units_navigator2.aspx?source_page=units_navigator2.aspx" + GetNavigatorState();
                }
                else
                {
                    // ... Go to the search page
                    url = "./units_navigator.aspx?source_page=units_navigator2.aspx&fm_type=" + hdfFmType.Value + GetNavigatorState() + "&no_results=yes";
                }

                Response.Redirect(url);
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
            // double number fields validate
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
        // NAVIGATION EVENTS
        //

        protected void btnOpen_Click(object sender, EventArgs e)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            PostPageChanges();

            int unitId = GetUnitId();
            if (unitId > 0)
            {
                UnitsGateway unitsGateway = new UnitsGateway();
                unitsGateway.LoadByUnitId(unitId, companyId);
                string unitType = unitsGateway.GetType(unitId);
                string unitState = unitsGateway.GetState(unitId);

                // Store active tab for postback
                Session["activeTabUnits"] = "0";
                Session["dialogOpenedUnits"] = "0";

                // Redirect
                string url = "./units_summary.aspx?source_page=units_navigator2.aspx&unit_id=" + unitId + "&unit_type=" + unitType + "&unit_state=" + unitState + "&active_tab=0" + GetNavigatorState();
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

            int unitId = GetUnitId();
            if (unitId > 0)
            {
                UnitsGateway unitsGateway = new UnitsGateway();
                unitsGateway.LoadByUnitId(unitId, companyId);
                string unitType = unitsGateway.GetType(unitId);
                string unitState = unitsGateway.GetState(unitId);

                // Store active tab for postback
                Session["activeTabUnits"] = "0";
                Session["dialogOpenedUnits"] = "0";

                // Redirect
                string url = "./units_edit.aspx?source_page=units_navigator2.aspx&unit_id=" + unitId + "&unit_type=" + unitType + "&unit_state=" + unitState + "&active_tab=0" + GetNavigatorState();
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
            int totalColumnsExport = 37;
            int totalColumnsPreview = 36;
            string title = "Units Search Results";

            // ... for title view
            if (hdfBtnOrigin.Value == "Go")
            {
                int viewId = Int32.Parse(ddlView.SelectedValue.Trim());
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

                // ... Load name view
                FmViewGateway fmViewGateway = new FmViewGateway();
                fmViewGateway.LoadByViewId(viewId, companyId);

                title = fmViewGateway.GetName(viewId);
            }

            // ... For notes option
            string notes = "None";

            // Establishing header values                        
            if (grdUnitsNavigator.Columns[2].Visible) headerValues += "Code";
            if (grdUnitsNavigator.Columns[3].Visible) headerValues += " * Description";
            if (grdUnitsNavigator.Columns[4].Visible) headerValues += " * VIN/SN";
            if (grdUnitsNavigator.Columns[5].Visible) headerValues += " * State";
            if (grdUnitsNavigator.Columns[6].Visible) headerValues += " * Manufacturer";
            if (grdUnitsNavigator.Columns[7].Visible) headerValues += " * Model";
            if (grdUnitsNavigator.Columns[8].Visible) headerValues += " * Is Towable?";
            if (grdUnitsNavigator.Columns[9].Visible) headerValues += " * Insurance Class";
            if (grdUnitsNavigator.Columns[10].Visible) headerValues += " * Ryder Specified";

            // before columns 9 after columns 11
            if (grdUnitsNavigator.Columns[11].Visible) headerValues += " * Model Year";
            if (grdUnitsNavigator.Columns[12].Visible) headerValues += " * Category";
            if (grdUnitsNavigator.Columns[13].Visible) headerValues += " * Company Level";
            if (grdUnitsNavigator.Columns[14].Visible) headerValues += " * Acquisition Date";
            if (grdUnitsNavigator.Columns[15].Visible) headerValues += " * Cost (CAD)";
            if (grdUnitsNavigator.Columns[16].Visible) headerValues += " * Cost (USD)";
            if (grdUnitsNavigator.Columns[17].Visible) headerValues += " * License Country";
            if (grdUnitsNavigator.Columns[18].Visible) headerValues += " * License State";
            if (grdUnitsNavigator.Columns[19].Visible) headerValues += " * License Plate Number";
            if (grdUnitsNavigator.Columns[20].Visible) headerValues += " * Apportioned Tag Number";
            if (grdUnitsNavigator.Columns[21].Visible) headerValues += " * Actual Weight";
            if (grdUnitsNavigator.Columns[22].Visible) headerValues += " * Registered Weight";
            if (grdUnitsNavigator.Columns[23].Visible) headerValues += " * Tire Size Front";
            if (grdUnitsNavigator.Columns[24].Visible) headerValues += " * Tire Size Back";
            if (grdUnitsNavigator.Columns[25].Visible) headerValues += " * Number Of Axes";
            if (grdUnitsNavigator.Columns[26].Visible) headerValues += " * Fuel Type";
            if (grdUnitsNavigator.Columns[27].Visible) headerValues += " * Beginning Odometer";
            if (grdUnitsNavigator.Columns[28].Visible) headerValues += " * Is Reefer Equipped?";
            if (grdUnitsNavigator.Columns[29].Visible) headerValues += " * Is PTO Equipped?";
            if (grdUnitsNavigator.Columns[30].Visible) headerValues += " * Owner Type";
            if (grdUnitsNavigator.Columns[31].Visible) headerValues += " * Owner Country";
            if (grdUnitsNavigator.Columns[32].Visible) headerValues += " * Owner State";
            if (grdUnitsNavigator.Columns[33].Visible) headerValues += " * Owner Name";
            if (grdUnitsNavigator.Columns[34].Visible) headerValues += " * Contact Info";
            if (grdUnitsNavigator.Columns[35].Visible) headerValues += " * Qualified Date";
            if (grdUnitsNavigator.Columns[36].Visible) headerValues += " * Not Qualified Date";
            if (grdUnitsNavigator.Columns[37].Visible) headerValues += " * Not Qualified Explain";

            // Establishing columns to display
            string[] columns = headerValues.Split('*');
            string columnsForReport = "";
            int j;

            // ... For visible columns
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

            if (grdUnitsNavigator.Columns[38].Visible) { notes = "Notes"; }

            // Report call
            Page.Validate();
            if (Page.IsValid)
            {
                PostPageChanges();
                title = title.Replace("'", "%27");
                Response.Write("<script language='javascript'> {window.open('./units_print_search_results_report.aspx?" + columnsForReport + "&notes=" + notes + "&totalColumnsPreview=" + totalColumnsPreview + "&totalColumnsExport=" + totalColumnsExport + "&totalSelectedColumns=" + columns.Length + "&title=" + title + "&format=pdf', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
            }
                   
            if (url != "") Response.Redirect(url);
        }



        protected void btnExportList_Click(object sender, EventArgs e)
        {
            string url = "";
            string headerValues = "";
            int totalColumnsExport = 37;
            int totalColumnsPreview = 36;
            string title = "Units Search Results";
            string columnsForReport = "";
            int j;

            // ... for title view
            if (hdfBtnOrigin.Value == "Go")
            {
                int viewId = Int32.Parse(ddlView.SelectedValue.Trim());
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

                // ... Load name view
                FmViewGateway fmViewGateway = new FmViewGateway();
                fmViewGateway.LoadByViewId(viewId, companyId);

                title = fmViewGateway.GetName(viewId);
            }

            // ... For notes option
            string notes = "None";

            headerValues = "";
            columnsForReport = "";

            // Establishing header values                        
            if (grdUnitsNavigator.Columns[2].Visible) headerValues += "Code";
            if (grdUnitsNavigator.Columns[3].Visible) headerValues += " * Description";
            if (grdUnitsNavigator.Columns[4].Visible) headerValues += " * VIN/SN";
            if (grdUnitsNavigator.Columns[5].Visible) headerValues += " * State";
            if (grdUnitsNavigator.Columns[6].Visible) headerValues += " * Manufacturer";
            if (grdUnitsNavigator.Columns[7].Visible) headerValues += " * Model";
            if (grdUnitsNavigator.Columns[8].Visible) headerValues += " * Is Towable?";
            if (grdUnitsNavigator.Columns[9].Visible) headerValues += " * Insurance Class";
            if (grdUnitsNavigator.Columns[10].Visible) headerValues += " * Ryder Specified";

            // before column 9 after column 11
            if (grdUnitsNavigator.Columns[11].Visible) headerValues += " * Model Year";
            if (grdUnitsNavigator.Columns[12].Visible) headerValues += " * Category";
            if (grdUnitsNavigator.Columns[13].Visible) headerValues += " * Company Level";
            if (grdUnitsNavigator.Columns[14].Visible) headerValues += " * Acquisition Date";
            if (grdUnitsNavigator.Columns[15].Visible) headerValues += " * Cost (CAD)";
            if (grdUnitsNavigator.Columns[16].Visible) headerValues += " * Cost (USD)";
            if (grdUnitsNavigator.Columns[17].Visible) headerValues += " * License Country";
            if (grdUnitsNavigator.Columns[18].Visible) headerValues += " * License State";
            if (grdUnitsNavigator.Columns[19].Visible) headerValues += " * License Plate Number";
            if (grdUnitsNavigator.Columns[20].Visible) headerValues += " * Apportioned Tag Number";
            if (grdUnitsNavigator.Columns[21].Visible) headerValues += " * Actual Weight";
            if (grdUnitsNavigator.Columns[22].Visible) headerValues += " * Registered Weight";
            if (grdUnitsNavigator.Columns[23].Visible) headerValues += " * Tire Size Front";
            if (grdUnitsNavigator.Columns[24].Visible) headerValues += " * Tire Size Back";
            if (grdUnitsNavigator.Columns[25].Visible) headerValues += " * Number Of Axes";
            if (grdUnitsNavigator.Columns[26].Visible) headerValues += " * Fuel Type";
            if (grdUnitsNavigator.Columns[27].Visible) headerValues += " * Beginning Odometer";
            if (grdUnitsNavigator.Columns[28].Visible) headerValues += " * Is Reefer Equipped?";
            if (grdUnitsNavigator.Columns[29].Visible) headerValues += " * Is PTO Equipped?";
            if (grdUnitsNavigator.Columns[30].Visible) headerValues += " * Owner Type";
            if (grdUnitsNavigator.Columns[31].Visible) headerValues += " * Owner Country";
            if (grdUnitsNavigator.Columns[32].Visible) headerValues += " * Owner State";
            if (grdUnitsNavigator.Columns[33].Visible) headerValues += " * Owner Name";
            if (grdUnitsNavigator.Columns[34].Visible) headerValues += " * Contact Info";
            if (grdUnitsNavigator.Columns[35].Visible) headerValues += " * Qualified Date";
            if (grdUnitsNavigator.Columns[36].Visible) headerValues += " * Not Qualified Date";
            if (grdUnitsNavigator.Columns[37].Visible) headerValues += " * Not Qualified Explain";
            if (grdUnitsNavigator.Columns[38].Visible) headerValues += " * Notes";

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
                Response.Write("<script language='javascript'> {window.open('./units_print_search_results_report.aspx?" + columnsForReport + "&notes=" + notes + "&totalColumnsPreview=" + totalColumnsPreview + "&totalColumnsExport=" + totalColumnsExport + "&totalSelectedColumns=" + columnsExcel.Length + "&title=" + title + "&format=excel', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
            }

            if (url != "") Response.Redirect(url);
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            PostPageChanges();

            int unitId = GetUnitId();
            UnitsGateway unitsGateway = new UnitsGateway();
            unitsGateway.LoadByUnitId(unitId, companyId);
            string unitType = unitsGateway.GetType(unitId);
            string unitState = unitsGateway.GetState(unitId);

            if (unitId > 0)
            {
                switch (Delete(unitId, companyId))
                {
                    case 0:
                        // Store active tab for postback
                        Session["activeTabUnits"] = "0";
                        Session["dialogOpenedUnits"] = "0";

                        // Redirect
                        string url = "./units_delete.aspx?source_page=units_navigator2.aspx&unit_id=" + unitId + "&unit_type=" + unitType + "&unit_state=" + unitState + GetNavigatorState() + "&update=yes&active_tab=0";
                        Response.Redirect(url);
                        break;

                    case 1:
                        cvSelection.ErrorMessage = "The unit has been registered in a Timesheet, you cannot delete it.";
                        cvSelection.IsValid = false;
                        break;

                    case 2:
                        cvSelection.ErrorMessage = "The unit has been registered in the Add Team Project Time wizard, you cannot delete him.";
                        cvSelection.IsValid = false;
                        break;

                    case 3:
                        cvSelection.ErrorMessage = "The unit has been registered in the Add Team Project Time wizard, you cannot delete him.";
                        cvSelection.IsValid = false;
                        break;

                    case 4:
                        cvSelection.ErrorMessage = "The unit has services active, you cannot delete him.";
                        cvSelection.IsValid = false;
                        break;
                }
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
            }
        }



        protected void btnClearSearch_Click(object sender, EventArgs e)
        {
            string url = "./units_navigator.aspx?source_page=lm";

            if (url != "") Response.Redirect(url);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfFmTypeId = '" + hdfFmType.ClientID + "';";
            contentVariables += "var ddlViewId = '" + ddlView.ClientID + "';";
            
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./units_navigator2.js");
        }



        private void RestoreNavigatorState()
        {
            try
            {
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

                // Grid's columns
                grdUnitsNavigator.Columns[2].Visible = (columnsToDisplay.IndexOf("Code") >= 0 ? true : false);
                grdUnitsNavigator.Columns[3].Visible = (columnsToDisplay.IndexOf("Description") >= 0 ? true : false);
                grdUnitsNavigator.Columns[4].Visible = (columnsToDisplay.IndexOf("VIN/SN") >= 0 ? true : false);
                grdUnitsNavigator.Columns[5].Visible = (columnsToDisplay.IndexOf(", State") >= 0 ? true : false);
                grdUnitsNavigator.Columns[6].Visible = (columnsToDisplay.IndexOf("Manufacturer") >= 0 ? true : false);
                grdUnitsNavigator.Columns[7].Visible = (columnsToDisplay.IndexOf("Model") >= 0 ? true : false);
                grdUnitsNavigator.Columns[8].Visible = (columnsToDisplay.IndexOf("Is Towable?") >= 0 ? true : false);
                grdUnitsNavigator.Columns[9].Visible = (columnsToDisplay.IndexOf("Insurance Class") >= 0 ? true : false);
                grdUnitsNavigator.Columns[10].Visible = (columnsToDisplay.IndexOf("Ryder Specified") >= 0 ? true : false);

                // before 9 after 11
                grdUnitsNavigator.Columns[11].Visible = (columnsToDisplay.IndexOf("Model Year") >= 0 ? true : false);
                grdUnitsNavigator.Columns[12].Visible = (columnsToDisplay.IndexOf("Category") >= 0 ? true : false);
                grdUnitsNavigator.Columns[13].Visible = (columnsToDisplay.IndexOf("Company Level") >= 0 ? true : false);
                grdUnitsNavigator.Columns[14].Visible = (columnsToDisplay.IndexOf("Acquisition Date") >= 0 ? true : false);
                grdUnitsNavigator.Columns[15].Visible = (columnsToDisplay.IndexOf("Cost (CAD)") >= 0 ? true : false);
                grdUnitsNavigator.Columns[16].Visible = (columnsToDisplay.IndexOf("Cost (USD)") >= 0 ? true : false);
                grdUnitsNavigator.Columns[17].Visible = (columnsToDisplay.IndexOf("License Country") >= 0 ? true : false);
                grdUnitsNavigator.Columns[18].Visible = (columnsToDisplay.IndexOf("License State") >= 0 ? true : false);
                grdUnitsNavigator.Columns[19].Visible = (columnsToDisplay.IndexOf("License Plate Number") >= 0 ? true : false);
                grdUnitsNavigator.Columns[20].Visible = (columnsToDisplay.IndexOf("Apportioned Tag Number") >= 0 ? true : false);
                grdUnitsNavigator.Columns[21].Visible = (columnsToDisplay.IndexOf("Actual Weight") >= 0 ? true : false);
                grdUnitsNavigator.Columns[22].Visible = (columnsToDisplay.IndexOf("Registered Weight") >= 0 ? true : false);
                grdUnitsNavigator.Columns[23].Visible = (columnsToDisplay.IndexOf("Tire Size Front") >= 0 ? true : false);
                grdUnitsNavigator.Columns[24].Visible = (columnsToDisplay.IndexOf("Tire Size Back") >= 0 ? true : false);
                grdUnitsNavigator.Columns[25].Visible = (columnsToDisplay.IndexOf("Number Of Axes") >= 0 ? true : false);
                grdUnitsNavigator.Columns[26].Visible = (columnsToDisplay.IndexOf("Fuel Type") >= 0 ? true : false);
                grdUnitsNavigator.Columns[27].Visible = (columnsToDisplay.IndexOf("Beginning Odometer") >= 0 ? true : false);
                grdUnitsNavigator.Columns[28].Visible = (columnsToDisplay.IndexOf("Is Reefer Equipped?") >= 0 ? true : false);
                grdUnitsNavigator.Columns[29].Visible = (columnsToDisplay.IndexOf("Is PTO Equipped?") >= 0 ? true : false);
                grdUnitsNavigator.Columns[30].Visible = (columnsToDisplay.IndexOf("Owner Type") >= 0 ? true : false);
                grdUnitsNavigator.Columns[31].Visible = (columnsToDisplay.IndexOf("Owner Country") >= 0 ? true : false);
                grdUnitsNavigator.Columns[32].Visible = (columnsToDisplay.IndexOf("Owner State") >= 0 ? true : false);
                grdUnitsNavigator.Columns[33].Visible = (columnsToDisplay.IndexOf("Owner Name") >= 0 ? true : false);
                grdUnitsNavigator.Columns[34].Visible = (columnsToDisplay.IndexOf("Contact Info") >= 0 ? true : false);
                grdUnitsNavigator.Columns[35].Visible = (columnsToDisplay.IndexOf("Qualified Date") >= 0 ? true : false);
                grdUnitsNavigator.Columns[36].Visible = (columnsToDisplay.IndexOf("Not Qualified Date") >= 0 ? true : false);
                grdUnitsNavigator.Columns[37].Visible = (columnsToDisplay.IndexOf("Not Qualified Explain") >= 0 ? true : false);
                grdUnitsNavigator.Columns[38].Visible = (columnsToDisplay.IndexOf("Notes") >= 0 ? true : false);
            }
            catch
            {
                string url = "./units_navigator.aspx?source_page=out";
                Response.Redirect(url);
            }
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
            string fmType = hdfFmType.Value.Trim();
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            // ... Load data
            FmTypeViewConditionGateway fmTypeViewConditionGateway = new FmTypeViewConditionGateway();
            fmTypeViewConditionGateway.LoadByFmTypeConditionId(fmType, companyId, int.Parse(ddlCondition1.SelectedValue));

            conditionValue = fmTypeViewConditionGateway.GetColumn_(fmType, companyId, int.Parse(ddlCondition1.SelectedValue));

            // ... Load data
            unitsNavigator.Load(whereClause, orderByClause, conditionValue, tbxCondition1.Text.Trim(), companyId);

            return (UnitsNavigatorTDS)unitsNavigator.Data;
        }



        private UnitsNavigatorTDS SubmitSearchForViews()
        {
            string sqlCommand = "";
            int viewId = Int32.Parse(ddlView.SelectedValue.Trim());

            UnitsNavigator unitsNavigator = new UnitsNavigator();
            string fmType = hdfFmType.Value.Trim();
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            // ... Load SqlCommand
            FmViewGateway fmViewGateway = new FmViewGateway();
            fmViewGateway.LoadByViewId(viewId, companyId);

            sqlCommand = fmViewGateway.GetSqlCommand(viewId);

            // ... Load data
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



        private void PostPageChanges()
        {
            UnitsNavigator unitsNavigator = new UnitsNavigator(unitsNavigatorTDS);

            // Update UnitsNavigator rows
            foreach (GridViewRow row in grdUnitsNavigator.Rows)
            {
                string unitIdLabel = ((Label)row.FindControl("lblUnitId")).Text.Trim();
                int unitId = Int32.Parse(unitIdLabel.ToString().Trim());
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                unitsNavigator.Update(unitId, selected);
            }

            unitsNavigator.Data.AcceptChanges();

            // Store datasets
            Session["unitsNavigatorTDS"] = unitsNavigatorTDS;
        }



        private int GetUnitId()
        {
            int unitId = 0;

            foreach (UnitsNavigatorTDS.UnitsNavigatorRow unitsNavigatorRow in unitsNavigatorTDS.UnitsNavigator)
            {
                if (unitsNavigatorRow.Selected)
                {
                    unitId = unitsNavigatorRow.UnitID;
                }
            }

            return unitId;
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



        private int Delete(int unitId, int companyId)
        {
            LiquiForce.LFSLive.BL.FleetManagement.Units.Units units = new LiquiForce.LFSLive.BL.FleetManagement.Units.Units(null);
            
            int result = units.IsInUse(unitId, companyId);                    

            return result;
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