using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.FleetManagement.Services;
using LiquiForce.LFSLive.BL.FleetManagement.Services;
using LiquiForce.LFSLive.DA.FleetManagement.Common;
using LiquiForce.LFSLive.BL.FleetManagement.Common;
using LiquiForce.LFSLive.DA.Resources.Employees;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Services
{
    /// <summary>
    /// services_navigator2
    /// </summary>
    public partial class services_navigator2 : System.Web.UI.Page
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
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in services_navigator2.aspx");
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
                // ... services_navigator.aspx or services_navigator2.aspx
                if ((Request.QueryString["source_page"] == "services_navigator.aspx") || (Request.QueryString["source_page"] == "services_navigator2.aspx"))
                {
                    RestoreNavigatorState();

                    servicesNavigatorTDS = (ServicesNavigatorTDS)Session["servicesNavigatorTDS"];
                }

                // ... services_edit.aspx, services_summary.aspx or services_delete.aspx
                if ((Request.QueryString["source_page"] == "services_edit.aspx") || (Request.QueryString["source_page"] == "services_summary.aspx") || (Request.QueryString["source_page"] == "services_delete.aspx"))
                {
                    RestoreNavigatorState();

                    if (Request.QueryString["update"] == "no")
                    {
                        servicesNavigatorTDS = (ServicesNavigatorTDS)Session["servicesNavigatorTDS"];
                    }
                    else
                    {
                        // ... Delete store data
                        Session.Contents.Remove("servicesNavigatorTDS");

                        // ... Search data with updates
                        if (hdfBtnOrigin.Value == "Search")
                        {
                            servicesNavigatorTDS = SubmitSearch();
                        }
                        else
                        {
                            if (hdfBtnOrigin.Value == "Go")
                            {
                                servicesNavigatorTDS = SubmitSearchForViews();
                            }
                        }

                        // ... store datasets
                        Session["servicesNavigatorTDS"] = servicesNavigatorTDS;
                    }
                }

                // ... services_delete.aspx, services_summary.aspx or services_edit.aspx
                if ((Request.QueryString["source_page"] == "services_delete.aspx") || (Request.QueryString["source_page"] == "services_summary.aspx") || (Request.QueryString["source_page"] == "services_edit.aspx"))
                {
                    if (servicesNavigatorTDS.ServicesNavigator.Rows.Count == 0)
                    {
                        string url = "./services_navigator.aspx?source_page=services_navigator2.aspx&fm_type=" + hdfFmType.Value + GetNavigatorState() + "&no_results=yes";
                        Response.Redirect(url);
                    }
                }

                // For the grid
                grdServicesNavigator.DataSource = servicesNavigatorTDS.ServicesNavigator;
                grdServicesNavigator.DataBind();

                //... for the total rows
                if (servicesNavigatorTDS.ServicesNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + servicesNavigatorTDS.ServicesNavigator.Rows.Count;
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
                servicesNavigatorTDS = (ServicesNavigatorTDS)Session["servicesNavigatorTDS"];
                
                // ... for the total rows
                if (servicesNavigatorTDS.ServicesNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + servicesNavigatorTDS.ServicesNavigator.Rows.Count;
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
                Session.Contents.Remove("servicesNavigatorTDS");

                // Get data from DA gateway
                servicesNavigatorTDS = SubmitSearch();

                // Show results
                if (servicesNavigatorTDS.ServicesNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["servicesNavigatorTDS"] = servicesNavigatorTDS;

                    // ... Go to the results page
                    url = "./services_navigator2.aspx?source_page=services_navigator2.aspx" + GetNavigatorState();
                }
                else
                {
                    // ... Go to the search page
                    url = "./services_navigator.aspx?source_page=services_navigator2.aspx" + GetNavigatorState() + "&no_results=yes";
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
                Session.Contents.Remove("servicesNavigatorTDS");

                // Get data from DA gateway
                servicesNavigatorTDS = SubmitSearchForViews();

                // Show results
                if (servicesNavigatorTDS.ServicesNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["servicesNavigatorTDS"] = servicesNavigatorTDS;

                    // ... Go to the results page
                    url = "./services_navigator2.aspx?source_page=services_navigator2.aspx" + GetNavigatorState();
                }
                else
                {
                    // ... Go to the search page
                    url = "./services_navigator.aspx?source_page=services_navigator2.aspx&fm_type=" + hdfFmType.Value + GetNavigatorState() + "&no_results=yes";
                }

                Response.Redirect(url);
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
        // NAVIGATION EVENTS
        //

        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            switch (e.Item.Value)
            {
                case "mSRManager":
                    Session.Remove("dialogOpenedServicesManagerTool");

                    PostPageChanges();

                    // Store active tab for postback
                    Session["activeTabServices"] = "0";
                    Session["dialogOpenedServices"] = "0";
                    Session.Remove("libraryTDSForServices");

                    int serviceId = GetServiceId();
                    if (serviceId > 0)
                    {
                        string script = "<script language='javascript'>";
                        string url = "services_manager_tool.aspx?source_page=services_navigator2.aspx&service_id=" + serviceId + "&dashboard=False&unit_id=none";
                        script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no, width=525, height=650')", url);
                        script = script + "</script>";

                        Response.Write(script);
                    }
                    else
                    {
                        string script = "<script language='javascript'>";
                        string url = "services_manager_tool.aspx?&source_page=lm&dashboard=False";
                        script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no, width=525, height=650')", url);
                        script = script + "</script>";

                        Response.Write(script);
                    }
                    break;
            }
        }



        protected void btnOpen_Click(object sender, EventArgs e)
        {
            PostPageChanges();

            int serviceId = GetServiceId();
            if (serviceId > 0)
            {
                // Store active tab for postback
                Session["activeTabServices"] = "0";
                Session["dialogOpenedServices"] = "0";
                Session.Remove("libraryTDSForServices");

                // Redirect
                string url = "./services_summary.aspx?source_page=services_navigator2.aspx&dashboard=False&service_id=" + serviceId + "&active_tab=0" + GetNavigatorState();
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
            PostPageChanges();

            int serviceId = GetServiceId();
            if (serviceId > 0)
            {
                // Store active tab for postback
                Session["activeTabServices"] = "0";
                Session["dialogOpenedServices"] = "0";
                Session.Remove("libraryTDSForServices");

                // Redirect
                string url = "./services_edit.aspx?source_page=services_navigator2.aspx&dashboard=False&service_id=" + serviceId + "&active_tab=0" + GetNavigatorState();
                Response.Redirect(url);
            }
            else
            {
                RestoreNavigatorState();
                cvSelection.IsValid = false;
            }
        }



        protected void btnGoToSRManager_Click(object sender, EventArgs e)
        {
            Session.Remove("dialogOpenedServicesManagerTool");

            PostPageChanges();

            int serviceId = GetServiceId();
            if (serviceId > 0)
            {
                // Store active tab for postback
                Session["activeTabServices"] = "0";
                Session["dialogOpenedServices"] = "0";
                Session.Remove("libraryTDSForServices");

                string script = "<script language='javascript'>";
                string url = "services_manager_tool.aspx?source_page=services_navigator2.aspx&service_id=" + serviceId + "&dashboard=False&unit_id=none";
                script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=yes, resizable=yes, copyhistory=no, width=525, height=650')", url);
                script = script + "</script>";

                Response.Write(script);
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
            int totalColumnsExport = 29;
            int totalColumnsPreview = 28;
            string title = "Services Search Results";

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

            // ... For comments option
            string comments = "None";

            // Establishing header values                        
            if (grdServicesNavigator.Columns[2].Visible) headerValues += "Service Number";
            if (grdServicesNavigator.Columns[3].Visible) headerValues += " * Date";
            if (grdServicesNavigator.Columns[4].Visible) headerValues += " * Fixed Date";
            if (grdServicesNavigator.Columns[5].Visible) headerValues += " * Service State";
            if (grdServicesNavigator.Columns[6].Visible) headerValues += " * Problem Description";
            if (grdServicesNavigator.Columns[7].Visible) headerValues += " * Unit Code";
            if (grdServicesNavigator.Columns[8].Visible) headerValues += " * Unit Description";
            if (grdServicesNavigator.Columns[9].Visible) headerValues += " * VIN/SN";
            if (grdServicesNavigator.Columns[10].Visible) headerValues += " * Unit State";
            if (grdServicesNavigator.Columns[11].Visible) headerValues += " * Checklist Rule";
            if (grdServicesNavigator.Columns[12].Visible) headerValues += " * Checklist State";
            if (grdServicesNavigator.Columns[13].Visible) headerValues += " * Created by";
            if (grdServicesNavigator.Columns[14].Visible) headerValues += " * Mileage";
            if (grdServicesNavigator.Columns[15].Visible) headerValues += " * Assign Date";
            if (grdServicesNavigator.Columns[16].Visible) headerValues += " * Deadline Date";
            if (grdServicesNavigator.Columns[17].Visible) headerValues += " * Assigned to";
            if (grdServicesNavigator.Columns[18].Visible) headerValues += " * Accepted Date";
            if (grdServicesNavigator.Columns[19].Visible) headerValues += " * Start Date";
            if (grdServicesNavigator.Columns[20].Visible) headerValues += " * Unit Out Of Service Date";
            if (grdServicesNavigator.Columns[21].Visible) headerValues += " * Unit Out Of Service Time";
            if (grdServicesNavigator.Columns[22].Visible) headerValues += " * Start Work Mileage";
            if (grdServicesNavigator.Columns[23].Visible) headerValues += " * Complete Date";
            if (grdServicesNavigator.Columns[24].Visible) headerValues += " * Unit Back In Service Date";
            if (grdServicesNavigator.Columns[25].Visible) headerValues += " * Unit Back In Service Time";
            if (grdServicesNavigator.Columns[26].Visible) headerValues += " * Complete Work Mileage";
            if (grdServicesNavigator.Columns[27].Visible) headerValues += " * Work Details";
            if (grdServicesNavigator.Columns[28].Visible) headerValues += " * Preventable";
            if (grdServicesNavigator.Columns[29].Visible) headerValues += " * Labour Hours";

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

            if (grdServicesNavigator.Columns[30].Visible) comments = "Comments";

            // Report call
            Page.Validate();
            if (Page.IsValid)
            {
                PostPageChanges();
                //title = title.Replace("'", "''");
                title = title.Replace("'", "%27");
                //url = string.Format("<script language='javascript'> {window.open('./services_print_search_results_report.aspx?{0}&comments={1}&totalColumnsPreview={2}&totalColumnsExport={3}&totalSelectedColumns={4}&title={5}&format=pdf', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>", columnsForReport, comments, totalColumnsPreview.ToString(), totalColumnsExport.ToString(), columns.Length.ToString(), title);
                Response.Write("<script language='javascript'> {window.open('./services_print_search_results_report.aspx?" + columnsForReport + "&comments=" + comments + "&totalColumnsPreview=" + totalColumnsPreview + "&totalColumnsExport=" + totalColumnsExport + "&totalSelectedColumns=" + columns.Length + "&title=" + title + "&format=pdf', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
                //url = url.Replace("'", "\'");
                //Response.Write(url);
            } 
        }



        protected void btnExportList_Click(object sender, EventArgs e)
        {
            string url = "";
            string headerValues = "";
            int totalColumnsExport = 29;
            int totalColumnsPreview = 28;
            string title = "Services Search Results";
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

            // ... For comments option
            string comments = "None";

            headerValues = "";
            columnsForReport = "";

            // Establishing header values                        
            if (grdServicesNavigator.Columns[2].Visible) headerValues += "Service Number";
            if (grdServicesNavigator.Columns[3].Visible) headerValues += " * Date";
            if (grdServicesNavigator.Columns[4].Visible) headerValues += " * Fixed Date";
            if (grdServicesNavigator.Columns[5].Visible) headerValues += " * Service State";
            if (grdServicesNavigator.Columns[6].Visible) headerValues += " * Problem Description";
            if (grdServicesNavigator.Columns[7].Visible) headerValues += " * Unit Code";
            if (grdServicesNavigator.Columns[8].Visible) headerValues += " * Unit Description";
            if (grdServicesNavigator.Columns[9].Visible) headerValues += " * VIN/SN";
            if (grdServicesNavigator.Columns[10].Visible) headerValues += " * Unit State";
            if (grdServicesNavigator.Columns[11].Visible) headerValues += " * Checklist Rule";
            if (grdServicesNavigator.Columns[12].Visible) headerValues += " * Checklist State";
            if (grdServicesNavigator.Columns[13].Visible) headerValues += " * Created by";
            if (grdServicesNavigator.Columns[14].Visible) headerValues += " * Mileage";
            if (grdServicesNavigator.Columns[15].Visible) headerValues += " * Assign Date";
            if (grdServicesNavigator.Columns[16].Visible) headerValues += " * Deadline Date";
            if (grdServicesNavigator.Columns[17].Visible) headerValues += " * Assigned to";
            if (grdServicesNavigator.Columns[18].Visible) headerValues += " * Accepted Date";
            if (grdServicesNavigator.Columns[19].Visible) headerValues += " * Start Date";
            if (grdServicesNavigator.Columns[20].Visible) headerValues += " * Unit Out Of Service Date";
            if (grdServicesNavigator.Columns[21].Visible) headerValues += " * Unit Out Of Service Time";
            if (grdServicesNavigator.Columns[22].Visible) headerValues += " * Start Work Mileage";
            if (grdServicesNavigator.Columns[23].Visible) headerValues += " * Complete Date";
            if (grdServicesNavigator.Columns[24].Visible) headerValues += " * Unit Back In Service Date";
            if (grdServicesNavigator.Columns[25].Visible) headerValues += " * Unit Back In Service Time";
            if (grdServicesNavigator.Columns[26].Visible) headerValues += " * Complete Work Mileage";
            if (grdServicesNavigator.Columns[27].Visible) headerValues += " * Work Details";
            if (grdServicesNavigator.Columns[28].Visible) headerValues += " * Preventable";
            if (grdServicesNavigator.Columns[29].Visible) headerValues += " * Labour Hours";
            if (grdServicesNavigator.Columns[30].Visible) headerValues += " * Notes";

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

            if (grdServicesNavigator.Columns[30].Visible) comments = "Comments";

            // Report call
            Page.Validate();
            if (Page.IsValid)
            {
                PostPageChanges();
                title = title.Replace("'", "%27");
                Response.Write("<script language='javascript'> {window.open('./services_print_search_results_report.aspx?" + columnsForReport + "&comments=" + comments + "&totalColumnsPreview=" + totalColumnsPreview + "&totalColumnsExport=" + totalColumnsExport + "&totalSelectedColumns=" + columnsExcel.Length + "&title=" + title + "&format=excel', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
            }                   

            if (url != "") Response.Redirect(url);
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string fmType = hdfFmType.Value.Trim();

            PostPageChanges();

            int serviceId = GetServiceId();

            if (serviceId > 0)
            {
                if (IsDeletedSR(serviceId, companyId))
                {
                    // Redirect
                    string url = "./services_delete.aspx?source_page=services_navigator2.aspx&dashboard=False&service_id=" + serviceId + GetNavigatorState();
                    Response.Redirect(url);
                }
                else
                {
                    cvSelection.ErrorMessage = "You cannot delete the SR because it's associated with a Checklist Rule.";
                    cvSelection.IsValid = false;
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
            string url = "./services_navigator.aspx?source_page=lm";

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
            contentVariables += "var ddlViewId = '" + ddlView.ClientID + "';";
            
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./services_navigator2.js");
        }



        private void RestoreNavigatorState()
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

            // Grid's columns
            grdServicesNavigator.Columns[2].Visible = (columnsToDisplay.IndexOf("Service Number") >= 0 ? true : false);
            grdServicesNavigator.Columns[3].Visible = (columnsToDisplay.IndexOf("Date & Time") >= 0 ? true : false);
            grdServicesNavigator.Columns[4].Visible = (columnsToDisplay.IndexOf("Fixed Date") >= 0 ? true : false);
            grdServicesNavigator.Columns[5].Visible = (columnsToDisplay.Contains("State") ? true : false);
            grdServicesNavigator.Columns[6].Visible = (columnsToDisplay.IndexOf("Problem Description") >= 0 ? true : false);
            grdServicesNavigator.Columns[7].Visible = (columnsToDisplay.IndexOf("Unit Code") >= 0 ? true : false);
            grdServicesNavigator.Columns[8].Visible = (columnsToDisplay.IndexOf("Unit Description") >= 0 ? true : false);
            grdServicesNavigator.Columns[9].Visible = (columnsToDisplay.IndexOf("VIN/SN") >= 0 ? true : false);
            grdServicesNavigator.Columns[10].Visible = (columnsToDisplay.IndexOf("Unit State") >= 0 ? true : false);
            grdServicesNavigator.Columns[11].Visible = (columnsToDisplay.IndexOf("Checklist Rule") >= 0 ? true : false);
            grdServicesNavigator.Columns[12].Visible = (columnsToDisplay.IndexOf("Associated Checklist State") >= 0 ? true : false);
            grdServicesNavigator.Columns[13].Visible = (columnsToDisplay.IndexOf("Created by") >= 0 ? true : false);
            grdServicesNavigator.Columns[14].Visible = (columnsToDisplay.IndexOf("Mileage") >= 0 ? true : false);
            grdServicesNavigator.Columns[15].Visible = (columnsToDisplay.IndexOf("Assignment Date") >= 0 ? true : false);
            grdServicesNavigator.Columns[16].Visible = (columnsToDisplay.IndexOf("Deadline Date") >= 0 ? true : false);
            grdServicesNavigator.Columns[17].Visible = (columnsToDisplay.IndexOf("Assigned to") >= 0 ? true : false);
            grdServicesNavigator.Columns[18].Visible = (columnsToDisplay.IndexOf("Accepted Date") >= 0 ? true : false);
            grdServicesNavigator.Columns[19].Visible = (columnsToDisplay.IndexOf("Start Date") >= 0 ? true : false);
            grdServicesNavigator.Columns[20].Visible = (columnsToDisplay.IndexOf("Unit Out Of Service Date") >= 0 ? true : false);
            grdServicesNavigator.Columns[21].Visible = (columnsToDisplay.IndexOf("Unit Out Of Service Time") >= 0 ? true : false);
            grdServicesNavigator.Columns[22].Visible = (columnsToDisplay.IndexOf("Start Work Mileage") >= 0 ? true : false);
            grdServicesNavigator.Columns[23].Visible = (columnsToDisplay.IndexOf("Complete Date") >= 0 ? true : false);
            grdServicesNavigator.Columns[24].Visible = (columnsToDisplay.IndexOf("Unit Back In Service Date") >= 0 ? true : false);
            grdServicesNavigator.Columns[25].Visible = (columnsToDisplay.IndexOf("Unit Back In Service Time") >= 0 ? true : false);
            grdServicesNavigator.Columns[26].Visible = (columnsToDisplay.IndexOf("Complete Work Mileage") >= 0 ? true : false);
            grdServicesNavigator.Columns[27].Visible = (columnsToDisplay.IndexOf("Work Details") >= 0 ? true : false);
            grdServicesNavigator.Columns[28].Visible = (columnsToDisplay.IndexOf("Preventable") >= 0 ? true : false);
            grdServicesNavigator.Columns[29].Visible = (columnsToDisplay.IndexOf("Labour Hours") >= 0 ? true : false);
            grdServicesNavigator.Columns[30].Visible = (columnsToDisplay.IndexOf("Notes") >= 0 ? true : false);
            grdServicesNavigator.Columns[31].Visible = (columnsToDisplay.IndexOf("Working Location") >= 0 ? true : false); 
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

            // ... Load data
            servicesNavigator.Load(whereClause, orderByClause, conditionValue, tbxCondition1.Text.Trim(), companyId, fmType);

            return (ServicesNavigatorTDS)servicesNavigator.Data;
        }



        private ServicesNavigatorTDS SubmitSearchForViews()
        {
            string sqlCommand = "";
            int viewId = Int32.Parse(ddlView.SelectedValue.Trim());

            ServicesNavigator servicesNavigator = new ServicesNavigator();
            string fmType = hdfFmType.Value.Trim();
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            // ... Load SqlCommand
            FmViewGateway fmViewGateway = new FmViewGateway();
            fmViewGateway.LoadByViewId(viewId, companyId);

            sqlCommand = fmViewGateway.GetSqlCommand(viewId);

            // ... Load data
            servicesNavigator.LoadForViewsFmTypeCompanyId(sqlCommand, fmType, companyId);

            return (ServicesNavigatorTDS)servicesNavigator.Data;
        }



        private string GetWhereClause()
        {
            // General conditions
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            string whereClause = "(LFS.Deleted = 0) AND (LFU.Deleted = 0) AND (LFS.COMPANY_ID = " + companyId + ") AND (LFU.COMPANY_ID = " + companyId + ") ";

            // For state
            if (ddlState.SelectedValue == "(All)")
            {
                whereClause = whereClause + " AND (LFS.State IS NOT NULL) ";
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

            // FOR TEXT FIELDS. (Service Number, Unit Code, Unit Description, Notes, Created by, Assigned to, Checklist Rule)
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



        private void PostPageChanges()
        {
            ServicesNavigator servicesNavigator = new ServicesNavigator(servicesNavigatorTDS);

            // Update serviceNavigator rows
            foreach (GridViewRow row in grdServicesNavigator.Rows)
            {
                string serviceIdLabel = ((Label)row.FindControl("lblServiceId")).Text.Trim();
                int serviceId = Int32.Parse(serviceIdLabel.ToString().Trim());
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                servicesNavigator.Update(serviceId, selected);
            }

            servicesNavigator.Data.AcceptChanges();

            // Store datasets
            Session["servicesNavigatorTDS"] = servicesNavigatorTDS;
        }



        private int GetServiceId()
        {
            int serviceId = 0;

            foreach (ServicesNavigatorTDS.ServicesNavigatorRow servicesNavigatorRow in servicesNavigatorTDS.ServicesNavigator)
            {
                if (servicesNavigatorRow.Selected)
                {
                    serviceId = servicesNavigatorRow.ServiceID;
                }
            }

            return serviceId;
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



        private bool IsDeletedSR(int serviceId, int companyId)
        {
            ServiceInformationBasicInformationGateway serviceInformationBasicInformationGateway = new ServiceInformationBasicInformationGateway();
            serviceInformationBasicInformationGateway.LoadByServiceId(serviceId, companyId);

            if (serviceInformationBasicInformationGateway.Table.Rows.Count > 0)
            {
                int loginId = Convert.ToInt32(Session["loginID"]);
                bool serviceAdmin = Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_SERVICES_ADMIN"]);
                EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
                int employeeId = employeeGateway.GetEmployeIdByLoginId(loginId);
                int ownerId = serviceInformationBasicInformationGateway.GetOwnerID(serviceId);
                
                if (!(serviceInformationBasicInformationGateway.GetRuleId(serviceId).HasValue) && ((employeeId == ownerId) || (serviceAdmin)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }        



    }
}