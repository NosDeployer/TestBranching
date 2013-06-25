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
using LiquiForce.LFSLive.DA.CWP.Works;
using System.Collections;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.RehabAssessment
{
    /// <summary>
    /// ra_navigator2
    /// </summary>
    public partial class ra_navigator2 : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected RaNavigatorTDS raNavigatorTDS;






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
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in ra_navigator2.aspx");
                }
                                
                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();
                hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();
                hdfWorkType.Value = "Rehab Assessment";

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
                // ... ra_navigator.aspx or ra_navigator2.aspx
                if ((Request.QueryString["source_page"] == "ra_navigator.aspx") || (Request.QueryString["source_page"] == "ra_navigator2.aspx"))
                {
                    RestoreNavigatorState();
                    raNavigatorTDS = (RaNavigatorTDS)Session["raNavigatorTDS"];
                }

                // ... ra_edit.aspx, ra_summary.aspx or ra_delete.aspx
                if ((Request.QueryString["source_page"] == "ra_edit.aspx") || (Request.QueryString["source_page"] == "ra_summary.aspx") || (Request.QueryString["source_page"] == "ra_delete.aspx"))
                {
                    RestoreNavigatorState();

                    if (Request.QueryString["update"] == "no")
                    {
                        raNavigatorTDS = (RaNavigatorTDS)Session["raNavigatorTDS"];
                    }
                    else
                    {
                        // ... Delete store data
                        Session.Contents.Remove("raNavigatorTDS");

                        // ... Search data with updates
                        if (hdfBtnOrigin.Value == "Search")
                        {
                            raNavigatorTDS = SubmitSearch();
                        }
                        else
                        {
                            if (hdfBtnOrigin.Value == "Go")
                            {
                                raNavigatorTDS = SubmitSearchForViews();
                            }
                        }

                        // ... store datasets
                        Session["raNavigatorTDS"] = raNavigatorTDS;
                    }
                }

                // ... ra_delete.aspx, ra_summary.aspx or ra_edit.aspx
                if ((Request.QueryString["source_page"] == "ra_delete.aspx") || (Request.QueryString["source_page"] == "ra_summary.aspx") || (Request.QueryString["source_page"] == "ra_edit.aspx"))
                {
                    if (raNavigatorTDS.RaNavigator.Rows.Count == 0)
                    {
                        string url = "./ra_navigator.aspx?source_page=ra_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + GetNavigatorState() + "&no_results=yes";
                        Response.Redirect(url);
                    }
                }
                               
                // For the grid
                grdRANavigator.DataSource = raNavigatorTDS.RaNavigator;
                grdRANavigator.DataBind();

                // ... for the total rows
                if (raNavigatorTDS.RaNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + raNavigatorTDS.RaNavigator.Rows.Count;
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
                raNavigatorTDS = (RaNavigatorTDS)Session["raNavigatorTDS"];
                
                // ... for the total rows
                if (raNavigatorTDS.RaNavigator.Rows.Count > 0)
                {
                    lblTotalRows.Text = "Total Rows: " + raNavigatorTDS.RaNavigator.Rows.Count;
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
                hdfBtnOrigin.Value = "Search";

                string url = "";

                // Delete store data
                Session.Contents.Remove("raNavigatorTDS");

                // Get data from DA gateway
                raNavigatorTDS = SubmitSearch();

                // Show results
                if (raNavigatorTDS.RaNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["raNavigatorTDS"] = raNavigatorTDS;

                    // ... Go to the results page
                    url = "./ra_navigator2.aspx?source_page=ra_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState();
                }
                else
                {
                    // ... Go to the search page
                    url = "./ra_navigator.aspx?source_page=ra_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + GetNavigatorState() + "&no_results=yes";
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
                Session.Contents.Remove("raNavigatorTDS");

                // Get data from DA gateway
                raNavigatorTDS = SubmitSearchForViews();

                // Show results
                if (raNavigatorTDS.RaNavigator.Rows.Count > 0)
                {
                    // ... Store data
                    Session["raNavigatorTDS"] = raNavigatorTDS;

                    // ... Go to the results page
                    url = "./ra_navigator2.aspx?source_page=ra_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState();
                }
                else
                {
                    // ... Go to the search page
                    url = "./ra_navigator.aspx?source_page=ra_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value + GetNavigatorState() + "&no_results=yes";
                }

                Response.Redirect(url);
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

            UpdateDatabaseForViews();

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
            Response.Redirect("./../Common/select_project.aspx?source_page=ra_navigator2.aspx&work_type=" + hdfWorkType.Value.Trim());
        }



        protected void btnOpen_Click(object sender, EventArgs e)
        {
            PostPageChanges();

            int assetId = GetAssetId();
            if (assetId > 0)
            {
                // Store active tab for postback
                Session["activeTabRa"] = "0";
                Session["dialogOpenedRa"] = "0";

                // Redirect
                string url = "./ra_summary.aspx?source_page=ra_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + assetId + "&active_tab=0" + GetNavigatorState();
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

            int assetId = GetAssetId();
            if (assetId > 0)
            {
                // Store active tab for postback
                Session["activeTabRa"] = "0";
                Session["dialogOpenedRa"] = "0";

                // Redirect
                string url = "./ra_edit.aspx?source_page=ra_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + assetId + "&active_tab=0" + GetNavigatorState();
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
            int totalColumnsExport = 53;
            int totalColumnsPreview = 52;
            string client = "";
            string name = "";
            string project = "";
            string title = "Rehab Assessment Search Results";

            // ... for client            
            int currentClientId = Int32.Parse(hdfCurrentClientId.Value.ToString());
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            CompaniesGateway companiesGateway = new CompaniesGateway();
            companiesGateway.LoadByCompaniesId(currentClientId, companyId);
            client += "Client: " + companiesGateway.GetName(currentClientId);

            // ... for project            
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(currentProjectId);
            project = projectGateway.GetName(currentProjectId);
            name = client + " > Project: " + project + " (" + projectGateway.GetProjectNumber(currentProjectId) + ")";

            // ... for title view
            if (hdfBtnOrigin.Value == "Go")
            {
                int viewId = Int32.Parse(ddlView.SelectedValue.Trim());                

                // ... Load name view
                WorkViewGateway workViewGateway = new WorkViewGateway();
                workViewGateway.LoadByViewId(viewId, companyId);

                title = workViewGateway.GetName(viewId);
            }

            // ... For comments option
            string comments = "None";
            
            // Establishing header values                        
            if (grdRANavigator.Columns[2].Visible) headerValues += "ID (Section)";
            if (grdRANavigator.Columns[3].Visible) headerValues += " * Old CWP ID";
            if (grdRANavigator.Columns[4].Visible) headerValues += " * Sub Area";
            if (grdRANavigator.Columns[5].Visible) headerValues += " * Street";
            if (grdRANavigator.Columns[6].Visible) headerValues += " * USMH";
            if (grdRANavigator.Columns[7].Visible) headerValues += " * DSMH";
            if (grdRANavigator.Columns[8].Visible) headerValues += " * Pre-Flush Date";
            if (grdRANavigator.Columns[9].Visible) headerValues += " * Pre-Video Date";
            if (grdRANavigator.Columns[10].Visible) headerValues += " * Map Size";
            if (grdRANavigator.Columns[11].Visible) headerValues += " * Map Length";
            if (grdRANavigator.Columns[12].Visible) headerValues += " * Thickness";
            if (grdRANavigator.Columns[13].Visible) headerValues += " * Size_";
            if (grdRANavigator.Columns[14].Visible) headerValues += " * Length";
            if (grdRANavigator.Columns[16].Visible) headerValues += " * VideoLength";
            if (grdRANavigator.Columns[17].Visible) headerValues += " * Laterals";
            if (grdRANavigator.Columns[18].Visible) headerValues += " * LiveLaterals";
            if (grdRANavigator.Columns[19].Visible) headerValues += " * ClientID";
            if (grdRANavigator.Columns[20].Visible) headerValues += " * P1Date";
            if (grdRANavigator.Columns[21].Visible) headerValues += " * CXIsRemoved";
            if (grdRANavigator.Columns[22].Visible) headerValues += " * M1Date";
            if (grdRANavigator.Columns[23].Visible) headerValues += " * MeasurementTakenBy";
            if (grdRANavigator.Columns[24].Visible) headerValues += " * MaterialType";
            if (grdRANavigator.Columns[25].Visible) headerValues += " * USMHAddress";
            if (grdRANavigator.Columns[26].Visible) headerValues += " * USMHDepth";
            if (grdRANavigator.Columns[27].Visible) headerValues += " * USMHMouth12";
            if (grdRANavigator.Columns[28].Visible) headerValues += " * USMHMouth1";
            if (grdRANavigator.Columns[29].Visible) headerValues += " * USMHMouth2";
            if (grdRANavigator.Columns[30].Visible) headerValues += " * USMHMouth3";
            if (grdRANavigator.Columns[31].Visible) headerValues += " * USMHMouth4";
            if (grdRANavigator.Columns[32].Visible) headerValues += " * USMHMouth5";
            if (grdRANavigator.Columns[33].Visible) headerValues += " * DSMHAddress";
            if (grdRANavigator.Columns[34].Visible) headerValues += " * DSMHDepth";
            if (grdRANavigator.Columns[35].Visible) headerValues += " * DSMHMouth12";
            if (grdRANavigator.Columns[36].Visible) headerValues += " * DSMHMouth1";
            if (grdRANavigator.Columns[37].Visible) headerValues += " * DSMHMouth2";
            if (grdRANavigator.Columns[38].Visible) headerValues += " * DSMHMouth3";
            if (grdRANavigator.Columns[39].Visible) headerValues += " * DSMHMouth4";
            if (grdRANavigator.Columns[40].Visible) headerValues += " * DSMHMouth5";
            if (grdRANavigator.Columns[41].Visible) headerValues += " * TrafficControl";
            if (grdRANavigator.Columns[42].Visible) headerValues += " * SiteDetails";
            if (grdRANavigator.Columns[43].Visible) headerValues += " * PipeSizeChange";
            if (grdRANavigator.Columns[44].Visible) headerValues += " * StandardBypass";
            if (grdRANavigator.Columns[45].Visible) headerValues += " * StandardBypassComments";
            if (grdRANavigator.Columns[46].Visible) headerValues += " * TrafficControlDetails";
            if (grdRANavigator.Columns[47].Visible) headerValues += " * MeasurementType";
            if (grdRANavigator.Columns[48].Visible) headerValues += " * MeasurementFromMH";
            if (grdRANavigator.Columns[49].Visible) headerValues += " * VideoDoneFromMH";
            if (grdRANavigator.Columns[50].Visible) headerValues += " * VideoDoneToMH";
            if (grdRANavigator.Columns[51].Visible) headerValues += " * RoboticPrepCompleted";
            if (grdRANavigator.Columns[52].Visible) headerValues += " * RoboticPrepCompleted Date";

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

            if (grdRANavigator.Columns[15].Visible) comments = "Comments";

            // Report call
            Page.Validate();
            if (Page.IsValid)
            {
                PostPageChanges();
                title = title.Replace("'", "%27");
                Response.Write("<script language='javascript'> {window.open('./ra_print_search_results_report.aspx?" + columnsForReport + "&comments=" + comments + "&totalColumnsPreview=" + totalColumnsPreview + "&totalColumnsExport=" + totalColumnsExport + "&totalSelectedColumns=" + columns.Length + "&name=" + Server.UrlEncode(name) + "&title=" + Server.UrlEncode(title) + "&format=pdf', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
            }                

            if (url != "") Response.Redirect(url);
        }



        protected void btnExportList_Click(object sender, EventArgs e)
        {
            string url = "";

            string headerValues = "";
            int totalColumnsExport = 53;
            int totalColumnsPreview = 52;
            string client = "";
            string name = "";
            string project = "";
            string title = "Rehab Assessment Search Results";
            string columnsForReport = "";
            int j;

            // ... for client            
            int currentClientId = Int32.Parse(hdfCurrentClientId.Value.ToString());
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());

            CompaniesGateway companiesGateway = new CompaniesGateway();
            companiesGateway.LoadByCompaniesId(currentClientId, companyId);
            client += "Client: " + companiesGateway.GetName(currentClientId);

            // ... for project            
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(currentProjectId);
            project = projectGateway.GetName(currentProjectId);
            name = client + " > Project: " + project + " (" + projectGateway.GetProjectNumber(currentProjectId) + ")";

            // ... for title view
            if (hdfBtnOrigin.Value == "Go")
            {
                int viewId = Int32.Parse(ddlView.SelectedValue.Trim());                

                // ... Load name view
                WorkViewGateway workViewGateway = new WorkViewGateway();
                workViewGateway.LoadByViewId(viewId, companyId);

                title = workViewGateway.GetName(viewId);
            }

            // ... For comments option
            string comments = "None";

            headerValues = "";
            columnsForReport = "";

            // Establishing header values                        
            if (grdRANavigator.Columns[2].Visible) headerValues += "ID (Section)";
            if (grdRANavigator.Columns[3].Visible) headerValues += " * Old CWP ID";
            if (grdRANavigator.Columns[4].Visible) headerValues += " * Sub Area";
            if (grdRANavigator.Columns[5].Visible) headerValues += " * Street";
            if (grdRANavigator.Columns[6].Visible) headerValues += " * USMH";
            if (grdRANavigator.Columns[7].Visible) headerValues += " * DSMH";
            if (grdRANavigator.Columns[8].Visible) headerValues += " * Pre-Flush Date";
            if (grdRANavigator.Columns[9].Visible) headerValues += " * Pre-Video Date";
            if (grdRANavigator.Columns[10].Visible) headerValues += " * Map Size";
            if (grdRANavigator.Columns[11].Visible) headerValues += " * Map Length";
            if (grdRANavigator.Columns[12].Visible) headerValues += " * Thickness";
            if (grdRANavigator.Columns[13].Visible) headerValues += " * Size_";
            if (grdRANavigator.Columns[14].Visible) headerValues += " * Length";
            if (grdRANavigator.Columns[15].Visible) headerValues += " * Comments";
            if (grdRANavigator.Columns[16].Visible) headerValues += " * VideoLength";
            if (grdRANavigator.Columns[17].Visible) headerValues += " * Laterals";
            if (grdRANavigator.Columns[18].Visible) headerValues += " * LiveLaterals";
            if (grdRANavigator.Columns[19].Visible) headerValues += " * ClientID";
            if (grdRANavigator.Columns[20].Visible) headerValues += " * P1Date";
            if (grdRANavigator.Columns[21].Visible) headerValues += " * CXIsRemoved";
            if (grdRANavigator.Columns[22].Visible) headerValues += " * M1Date";
            if (grdRANavigator.Columns[23].Visible) headerValues += " * MeasurementTakenBy";
            if (grdRANavigator.Columns[24].Visible) headerValues += " * MaterialType";
            if (grdRANavigator.Columns[25].Visible) headerValues += " * USMHAddress";
            if (grdRANavigator.Columns[26].Visible) headerValues += " * USMHDepth";
            if (grdRANavigator.Columns[27].Visible) headerValues += " * USMHMouth12";
            if (grdRANavigator.Columns[28].Visible) headerValues += " * USMHMouth1";
            if (grdRANavigator.Columns[29].Visible) headerValues += " * USMHMouth2";
            if (grdRANavigator.Columns[30].Visible) headerValues += " * USMHMouth3";
            if (grdRANavigator.Columns[31].Visible) headerValues += " * USMHMouth4";
            if (grdRANavigator.Columns[32].Visible) headerValues += " * USMHMouth5";
            if (grdRANavigator.Columns[33].Visible) headerValues += " * DSMHAddress";
            if (grdRANavigator.Columns[34].Visible) headerValues += " * DSMHDepth";
            if (grdRANavigator.Columns[35].Visible) headerValues += " * DSMHMouth12";
            if (grdRANavigator.Columns[36].Visible) headerValues += " * DSMHMouth1";
            if (grdRANavigator.Columns[37].Visible) headerValues += " * DSMHMouth2";
            if (grdRANavigator.Columns[38].Visible) headerValues += " * DSMHMouth3";
            if (grdRANavigator.Columns[39].Visible) headerValues += " * DSMHMouth4";
            if (grdRANavigator.Columns[40].Visible) headerValues += " * DSMHMouth5";
            if (grdRANavigator.Columns[41].Visible) headerValues += " * TrafficControl";
            if (grdRANavigator.Columns[42].Visible) headerValues += " * SiteDetails";
            if (grdRANavigator.Columns[43].Visible) headerValues += " * PipeSizeChange";
            if (grdRANavigator.Columns[44].Visible) headerValues += " * StandardBypass";
            if (grdRANavigator.Columns[45].Visible) headerValues += " * StandardBypassComments";
            if (grdRANavigator.Columns[46].Visible) headerValues += " * TrafficControlDetails";
            if (grdRANavigator.Columns[47].Visible) headerValues += " * MeasurementType";
            if (grdRANavigator.Columns[48].Visible) headerValues += " * MeasurementFromMH";
            if (grdRANavigator.Columns[49].Visible) headerValues += " * VideoDoneFromMH";
            if (grdRANavigator.Columns[50].Visible) headerValues += " * VideoDoneToMH";
            if (grdRANavigator.Columns[51].Visible) headerValues += " * RoboticPrepCompleted";
            if (grdRANavigator.Columns[52].Visible) headerValues += " * RoboticPrepCompleted Date";

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
                Response.Write("<script language='javascript'> {window.open('./ra_print_search_results_report.aspx?" + columnsForReport + "&comments=" + comments + "&totalColumnsPreview=" + totalColumnsPreview + "&totalColumnsExport=" + totalColumnsExport + "&totalSelectedColumns=" + columnsExcel.Length + "&name=" + Server.UrlEncode(name) + "&title=" + Server.UrlEncode(title) + "&format=excel', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
            }
                    
            if (url != "") Response.Redirect(url);
        }



        protected void btnPrintLateralLocationSheet_Click(object sender, EventArgs e)
        {
            // Report call
            Page.Validate();
            if (Page.IsValid)
            {
                PostPageChanges();

                int assetId = GetAssetId();
                if (assetId > 0)
                {
                    int workIdRa = GetWorkId(Int32.Parse(hdfCurrentProjectId.Value), assetId, "Rehab Assessment", Int32.Parse(hdfCompanyId.Value));
                    int workIdFll = GetWorkId(Int32.Parse(hdfCurrentProjectId.Value), assetId, "Full Length Lining", Int32.Parse(hdfCompanyId.Value));

                    RehabAssessmentWorkDetailsGateway rehabAssessmentWorkDetailsGateway = new RehabAssessmentWorkDetailsGateway();
                    rehabAssessmentWorkDetailsGateway.LoadByWorkId(workIdRa, Int32.Parse(hdfCompanyId.Value));
                    string measuredFrom = rehabAssessmentWorkDetailsGateway.GetMeasurementFromMh(workIdRa);

                    Response.Write("<script language='javascript'> {window.open('./../../CWP/Common/lateral_location_sheet_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.Value + "&client_id=" + hdfCurrentClientId.Value + "&work_id=" + workIdFll.ToString() + "&measured_from=" + measuredFrom + "&asset_id=" + assetId.ToString() + "', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680');}</script>");
                }
                else
                {
                    cvSelection.IsValid = false;
                }
            }
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string workType = hdfWorkType.Value.Trim();

            PostPageChanges();

            int assetId = GetAssetId();
            if (assetId > 0)
            {
                // Store active tab for postback
                Session["activeTabRa"] = "0";
                Session["dialogOpenedRa"] = "0";

                // Redirect
                string url = "./ra_delete.aspx?source_page=ra_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + assetId + GetNavigatorState();
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
            string url = "./ra_navigator.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value;

            if (url != "") Response.Redirect(url);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            string url = "";

            switch (e.Item.Value)
            {
                case "mRehabAssessmentPlan":
                    url = "./ra_lining_plan.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value; 
                    break;

                case "mM1M2ReportByClient":
                    PostPageChanges();
                    ArrayList sectionIdArrayList2 = GetSectionIdArrayList();
                    if (sectionIdArrayList2.Count > 0)
                    {
                        Session["sectionsSelected"] = sectionIdArrayList2;
                    }

                    string script2 = "<script language='javascript'>";
                    url = "./../FullLengthLining/fl_m12_report.aspx?source_page=lm&project_id=" + hdfCurrentProjectId.Value + "&client_id=" + hdfCurrentClientId.Value + "&work_type=Junction Lining Section";
                    script2 = script2 + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=yes, menubar=no, scrollbars=no, resizable=yes, copyhistory=no, width=800, height=680')", url);
                    script2 = script2 + "</script>";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "M1Report", script2, false);
                    url = "";
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./ra_navigator2.js");
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
            
            // ... For View 
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

            // Grid's columns
            grdRANavigator.Columns[2].Visible = (columnsToDisplay.IndexOf("SectionID") >= 0 ? true : false);
            grdRANavigator.Columns[3].Visible = (columnsToDisplay.IndexOf("OriginalSectionID") >= 0 ? true : false);
            grdRANavigator.Columns[4].Visible = (columnsToDisplay.IndexOf("SubArea") >= 0 ? true : false);
            grdRANavigator.Columns[5].Visible = (columnsToDisplay.IndexOf("Street") >= 0 ? true : false);
            grdRANavigator.Columns[6].Visible = (columnsToDisplay.Contains("USMH,") ? true : false);
            grdRANavigator.Columns[7].Visible = (columnsToDisplay.Contains("DSMH") ? true : false);
            grdRANavigator.Columns[8].Visible = (columnsToDisplay.IndexOf("PreFlushDate") >= 0 ? true : false);
            grdRANavigator.Columns[9].Visible = (columnsToDisplay.IndexOf("PreVideoDate") >= 0 ? true : false);
            grdRANavigator.Columns[10].Visible = (columnsToDisplay.IndexOf("MapSize") >= 0 ? true : false);
            grdRANavigator.Columns[11].Visible = (columnsToDisplay.Contains("MapLength") ? true : false);
            grdRANavigator.Columns[12].Visible = (columnsToDisplay.Contains("Thickness") ? true : false);
            grdRANavigator.Columns[13].Visible = (columnsToDisplay.IndexOf("Size_") >= 0 ? true : false);
            grdRANavigator.Columns[14].Visible = (columnsToDisplay.Contains("Length") ? true : false);
            grdRANavigator.Columns[15].Visible = (columnsToDisplay.IndexOf("Comment") >= 0 ? true : false);
            grdRANavigator.Columns[16].Visible = (columnsToDisplay.Contains("VideoLength") ? true : false);
            grdRANavigator.Columns[17].Visible = (columnsToDisplay.Contains("Laterals") ? true : false);
            grdRANavigator.Columns[18].Visible = (columnsToDisplay.Contains("LiveLaterals") ? true : false);
            grdRANavigator.Columns[19].Visible = (columnsToDisplay.IndexOf("ClientID") >= 0 ? true : false);
            grdRANavigator.Columns[20].Visible = (columnsToDisplay.IndexOf("P1Date") >= 0 ? true : false);
            grdRANavigator.Columns[21].Visible = (columnsToDisplay.IndexOf("CXIsRemoved") >= 0 ? true : false);
            grdRANavigator.Columns[22].Visible = (columnsToDisplay.IndexOf("M1Date") >= 0 ? true : false);
            grdRANavigator.Columns[23].Visible = (columnsToDisplay.IndexOf("MeasurementTakenBy") >= 0 ? true : false);
            grdRANavigator.Columns[24].Visible = (columnsToDisplay.IndexOf("MaterialType") >= 0 ? true : false);
            grdRANavigator.Columns[25].Visible = (columnsToDisplay.IndexOf("USMHAddress") >= 0 ? true : false);
            grdRANavigator.Columns[26].Visible = (columnsToDisplay.IndexOf("USMHDepth") >= 0 ? true : false);
            grdRANavigator.Columns[27].Visible = (columnsToDisplay.IndexOf("USMHMouth12") >= 0 ? true : false);
            grdRANavigator.Columns[28].Visible = (columnsToDisplay.IndexOf("USMHMouth1,") >= 0 ? true : false);
            grdRANavigator.Columns[29].Visible = (columnsToDisplay.IndexOf("USMHMouth2") >= 0 ? true : false);
            grdRANavigator.Columns[30].Visible = (columnsToDisplay.IndexOf("USMHMouth3") >= 0 ? true : false);
            grdRANavigator.Columns[31].Visible = (columnsToDisplay.IndexOf("USMHMouth4") >= 0 ? true : false);
            grdRANavigator.Columns[32].Visible = (columnsToDisplay.IndexOf("USMHMouth5") >= 0 ? true : false);
            grdRANavigator.Columns[33].Visible = (columnsToDisplay.IndexOf("DSMHAddress") >= 0 ? true : false);
            grdRANavigator.Columns[34].Visible = (columnsToDisplay.IndexOf("DSMHDepth") >= 0 ? true : false);
            grdRANavigator.Columns[35].Visible = (columnsToDisplay.IndexOf("DSMHMouth12") >= 0 ? true : false);
            grdRANavigator.Columns[36].Visible = (columnsToDisplay.IndexOf("DSMHMouth1,") >= 0 ? true : false);
            grdRANavigator.Columns[37].Visible = (columnsToDisplay.IndexOf("DSMHMouth2") >= 0 ? true : false);
            grdRANavigator.Columns[38].Visible = (columnsToDisplay.IndexOf("DSMHMouth3") >= 0 ? true : false);
            grdRANavigator.Columns[39].Visible = (columnsToDisplay.IndexOf("DSMHMouth4") >= 0 ? true : false);
            grdRANavigator.Columns[40].Visible = (columnsToDisplay.IndexOf("DSMHMouth5") >= 0 ? true : false);
            grdRANavigator.Columns[41].Visible = (columnsToDisplay.IndexOf("TrafficControl") >= 0 ? true : false);
            grdRANavigator.Columns[42].Visible = (columnsToDisplay.IndexOf("SiteDetails") >= 0 ? true : false);
            grdRANavigator.Columns[43].Visible = (columnsToDisplay.IndexOf("PipeSizeChange") >= 0 ? true : false);
            grdRANavigator.Columns[44].Visible = (columnsToDisplay.IndexOf("StandardBypass") >= 0 ? true : false);
            grdRANavigator.Columns[45].Visible = (columnsToDisplay.IndexOf("StandardBypassComments") >= 0 ? true : false);
            grdRANavigator.Columns[46].Visible = (columnsToDisplay.IndexOf("TrafficControlDetails") >= 0 ? true : false);
            grdRANavigator.Columns[47].Visible = (columnsToDisplay.IndexOf("MeasurementType") >= 0 ? true : false);
            grdRANavigator.Columns[48].Visible = (columnsToDisplay.IndexOf("MeasurementFromMH") >= 0 ? true : false);
            grdRANavigator.Columns[49].Visible = (columnsToDisplay.IndexOf("VideoDoneFromMH") >= 0 ? true : false);
            grdRANavigator.Columns[50].Visible = (columnsToDisplay.IndexOf("VideoDoneToMH") >= 0 ? true : false);
            grdRANavigator.Columns[51].Visible = (columnsToDisplay.IndexOf("RoboticPrepCompleted") >= 0 ? true : false);
            grdRANavigator.Columns[52].Visible = (columnsToDisplay.IndexOf("RoboticPrepCompletedDate") >= 0 ? true : false);
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
            string workType = hdfWorkType.Value.Trim();
            string conditionValue = "";
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
            RaNavigator raNavigator = new RaNavigator();

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
            whereClause = whereClause + "AND (LW.ProjectID = " + hdfCurrentProjectId.Value + ")AND (LW.WorkType='" + hdfWorkType.Value + "') ";
            
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
                || (conditionValue == "SiteDetails") ||  (conditionValue == "StandardBypassComments") || (conditionValue == "TrafficControlDetails") || (conditionValue == "MeasurementType") || (conditionValue == "MeasurementFromMH") || (conditionValue == "VideoDoneFromMH") || (conditionValue == "VideoDoneToMH") || (conditionValue == "Thickness"))
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
            if ((conditionValue == "PreFlushDate") || (conditionValue == "PreVideoDate") || (conditionValue == "P1Date") || (conditionValue == "M1Date") ||  (conditionValue == "RoboticPrepCompletedDate"))
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
            orderBy = tableName + "." + columnName;
            return orderBy;
        }



        private void PostPageChanges()
        {
            RaNavigator raNavigator = new RaNavigator(raNavigatorTDS);

            // Update grid rows
            foreach (GridViewRow row in grdRANavigator.Rows)
            {
                string assetIdLabel = ((Label)row.FindControl("lblAssetId")).Text.Trim();
                int assetId = Int32.Parse(assetIdLabel.ToString().Trim());
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                raNavigator.Update(assetId, selected);
            }

            raNavigator.Data.AcceptChanges();

            // Store datasets
            Session["raNavigatorTDS"] = raNavigatorTDS;
        }



        private int GetAssetId()
        {
            int assetId = 0;

            foreach (RaNavigatorTDS.RaNavigatorRow raNavigatorRow in raNavigatorTDS.RaNavigator)
            {
                if (raNavigatorRow.Selected)
                {
                    assetId = raNavigatorRow.AssetID;
                }
            }

            return assetId;
        }



        private ArrayList GetSectionIdArrayList()
        {
            ArrayList raIdArrayList = new ArrayList();

            foreach (RaNavigatorTDS.RaNavigatorRow raNavigatorRow in raNavigatorTDS.RaNavigator)
            {
                if (raNavigatorRow.Selected)
                {
                    if (!raIdArrayList.Contains(raNavigatorRow.SectionID))
                    {
                        raIdArrayList.Add(raNavigatorRow.SectionID);
                    }
                }
            }

            return raIdArrayList;
        }



        private int GetWorkId(int projectId, int assetId, string workType, int companyId)
        {
            int workId = 0;
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, workType, companyId);
            if (workGateway.Table.Rows.Count > 0)
            {
                // Get WorkId
                workId = workGateway.GetWorkId(assetId, workType, projectId);
            }

            return workId;
        }



        private void UpdateDatabaseForViews()
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