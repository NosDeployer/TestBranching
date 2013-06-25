using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.CWP.PointRepairs;
using LiquiForce.LFSLive.BL.CWP.PointRepairs;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.CWP.Works;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.PointRepairs
{
    /// <summary>
    /// pr_summary
    /// </summary>
    public partial class pr_summary : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected PointRepairsTDS pointRepairsTDS;
        protected PointRepairsTDS.RepairDetailsDataTable pointRepairsRepairsTemp;
        protected PointRepairsTDS.CommentDetailsDataTable pointRepairsCommentsTemp;
        
        

        
        
                      
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
                if (!(Convert.ToBoolean(Session["sgLFS_CWP_POINTREPAIRS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_CWP_POINTREPAIRS_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null) ||  ((string)Request.QueryString["asset_id"] == null) || ((string)Request.QueryString["active_tab"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in pr_summary.aspx");
                }

                // Tag Page
                TagPage();

                // If coming from 
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());
                int assetId = Int32.Parse(hdfAssetId.Value.Trim());
                int workId = Int32.Parse(hdfWorkId.Value);

                Session.Remove("pointRepairsRepairsTempDummy");
                Session.Remove("pointRepairsCommentsTempDummy");

                // ... pr_navigator2.aspx
                if (Request.QueryString["source_page"] == "pr_navigator2.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";

                    // ... Set initial tab
                    if ((string)Session["dialogOpenedPr"] != "1")
                    {
                        hdfActiveTab.Value = Request.QueryString["active_tab"];

                        pointRepairsTDS = new PointRepairsTDS();
                        pointRepairsRepairsTemp = new PointRepairsTDS.RepairDetailsDataTable();
                        pointRepairsCommentsTemp = new PointRepairsTDS.CommentDetailsDataTable();
                        
                        PointRepairsSectionDetails pointRepairsSectionDetails = new PointRepairsSectionDetails(pointRepairsTDS);
                        pointRepairsSectionDetails.LoadByWorkId(workId, companyId);

                        PointRepairsWorkDetails pointRepairsWorkDetails = new PointRepairsWorkDetails(pointRepairsTDS);
                        pointRepairsWorkDetails.LoadByWorkIdAssetId(workId, assetId, companyId);

                        PointRepairsRepairDetails pointRepairsRepairDetails = new PointRepairsRepairDetails(pointRepairsTDS);
                        pointRepairsRepairDetails.LoadAllByWorkId(workId, companyId);

                        PointRepairsCommentDetails pointRepairsCommentDetails = new PointRepairsCommentDetails(pointRepairsTDS);
                        pointRepairsCommentDetails.LoadAllByWorkIdWorkType(workId, companyId, "Point Repairs");
                    }
                    else
                    {
                        hdfActiveTab.Value = (string)Session["activeTabPr"];

                        // Restore datasets
                        pointRepairsTDS = (PointRepairsTDS)Session["pointRepairsTDS"];
                        pointRepairsRepairsTemp = (PointRepairsTDS.RepairDetailsDataTable)Session["pointRepairsRepairsTemp"];
                        pointRepairsCommentsTemp = (PointRepairsTDS.CommentDetailsDataTable)Session["pointRepairsCommentsTemp"];
                    }

                    tcPrDetails.ActiveTabIndex = Int32.Parse(hdfActiveTab.Value);

                    Session["filterExpression"] = "Deleted = 0";

                    // Store dataset
                    Session["pointRepairsTDS"] = pointRepairsTDS;
                    Session["pointRepairsRepairsTemp"] = pointRepairsRepairsTemp;
                    Session["pointRepairsCommentsTemp"] = pointRepairsCommentsTemp;
                }

                // ... pr_delete.aspx or pr_edit.aspx 
                if ((Request.QueryString["source_page"] == "pr_delete.aspx") || (Request.QueryString["source_page"] == "pr_edit.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
                    pointRepairsTDS = (PointRepairsTDS)Session["pointRepairsTDS"];
                    pointRepairsRepairsTemp = (PointRepairsTDS.RepairDetailsDataTable)Session["pointRepairsRepairsTemp"];
                    pointRepairsCommentsTemp = (PointRepairsTDS.CommentDetailsDataTable)Session["pointRepairsCommentsTemp"];

                    // ... Set initial tab
                    if ((string)Session["dialogOpenedPr"] != "1")
                    {
                        hdfActiveTab.Value = Request.QueryString["active_tab"];
                    }
                    else
                    {
                        hdfActiveTab.Value = (string)Session["activeTabPr"];
                    }

                    tcPrDetails.ActiveTabIndex = Int32.Parse(hdfActiveTab.Value);

                    ApplyFilter();

                    switch ((string)Session["filterExpression"])
                    {
                        case "Deleted = 0":
                            ddlFilter.SelectedIndex = 0;
                            break;

                        case "Type='Robotic Reaming' AND Deleted = 0":
                            ddlFilter.SelectedIndex = 1;
                            break;

                        case "Type='Point Lining' AND Deleted = 0":
                            ddlFilter.SelectedIndex = 2;
                            break;

                        case "Type='Grouting' AND Deleted = 0":
                            ddlFilter.SelectedIndex = 3;
                            break;

                        default:
                            ddlFilter.SelectedIndex = 0;
                            break;
                    }
                }

                // Prepare initial data
                // ... for client
                int currentClientId = Int32.Parse(hdfCurrentClientId.Value.ToString());
                
                CompaniesGateway companiesGateway = new CompaniesGateway();
                companiesGateway.LoadByCompaniesId(currentClientId, companyId);
                lblTitleClientName.Text = "Client: " + companiesGateway.GetName(currentClientId);

                // ... for project
                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(currentProjectId);
                string name = projectGateway.GetName(currentProjectId);
                if (name.Length > 23) name = name.Substring(0, 20) + "...";
                lblTitleProjectName.Text = " > Project: " + name + " (" + projectGateway.GetProjectNumber(currentProjectId) + ") > Selected Section";

                // ... Data for current point repairs work                
                LoadPointRepairsData(currentProjectId, assetId, companyId);                
            }
            else
            {
                // Restore datasets
                pointRepairsTDS = (PointRepairsTDS)Session["pointRepairsTDS"];
                pointRepairsRepairsTemp = (PointRepairsTDS.RepairDetailsDataTable)Session["pointRepairsRepairsTemp"];
                pointRepairsCommentsTemp = (PointRepairsTDS.CommentDetailsDataTable)Session["pointRepairsCommentsTemp"];

                // Set initial tab
                int activeTab = Int32.Parse(hdfActiveTab.Value);
                tcPrDetails.ActiveTabIndex = activeTab;

                ApplyFilter();
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "eSewers";

            int companyId = Int32.Parse(hdfCompanyId.Value);
            int assetId = Int32.Parse(hdfAssetId.Value);
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());

            MaterialInformationGateway materialInformationGateway = new MaterialInformationGateway();
            materialInformationGateway.LoadLastMaterialByAssetId(assetId, companyId);

            if (materialInformationGateway.Table.Rows.Count > 0)
            {
                tbxGeneralDataMaterial.Text = materialInformationGateway.GetLastMaterialType(assetId);
            }
           
            if (tbxFlowOrderId.Text == "")
            {
                LoadPointRepairsData(currentProjectId, assetId, companyId);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void ddlFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlFilter.SelectedValue)
            {
                case "(All)":
                    SetFilter("Deleted = 0");
                    break;

                case "Robotic Reaming":
                    SetFilter("Type='Robotic Reaming' AND Deleted = 0");
                    break;

                case "Point Lining":
                    SetFilter("Type='Point Lining' AND Deleted = 0");
                    break;

                case "Grouting":
                    SetFilter("Type='Grouting' AND Deleted = 0");
                    break;
            }
        }



        protected void grdRepairs_DataBound(object sender, EventArgs e)
        {
            AddRepairsNewEmptyFix(grdRepairs);
        }



        protected void grdComments_DataBound(object sender, EventArgs e)
        {
            AddCommentsNewEmptyFix(grdComments);
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("./../Common/select_project.aspx?source_page=pr_summary.aspx&work_type=Point Repairs");
        }



        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            // Store active tab for postback
            Session["activeTabPr"] = "0";
            Session["dialogOpenedPr"] = "0";

            string activeTab = hdfActiveTab.Value;
            string url = "";

            switch (e.Item.Value)
            {
                case "mEdit":
                    switch (ddlFilter.SelectedValue)
                    {
                        case "(All)":
                            SetFilter("Deleted = 0");
                            break;

                        case "Robotic Reaming":
                            SetFilter("Type='Robotic Reaming' AND Deleted = 0");
                            break;

                        case "Point Lining":
                            SetFilter("Type='Point Lining' AND Deleted = 0");
                            break;

                        case "Grouting":
                            SetFilter("Type='Grouting' AND Deleted = 0");
                            break;
                    }
                    url = "./pr_edit.aspx?source_page=pr_summary.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&asset_id=" + hdfAssetId.Value + "&update=" + (string)ViewState["update"] + "&active_tab=" + hdfActiveTab.Value;
                    break;

                case "mDelete":
                    switch (ddlFilter.SelectedValue)
                    {
                        case "(All)":
                            SetFilter("Deleted = 0");
                            break;

                        case "Robotic Reaming":
                            SetFilter("Type='Robotic Reaming' AND Deleted = 0");
                            break;

                        case "Point Lining":
                            SetFilter("Type='Point Lining' AND Deleted = 0");
                            break;

                        case "Grouting":
                            SetFilter("Type='Grouting' AND Deleted = 0");
                            break;
                    }
                    url = "./pr_delete.aspx?source_page=pr_summary.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&asset_id=" + hdfAssetId.Value + "&update=" + (string)ViewState["update"];
                    break;

                // Go to Works
                case "mRehabAssessment":
                    url = "./../../CWP/RehabAssessment/ra_navigator.aspx?source_page=select_project.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=Rehab Assessment";
                    break;

                case "mFullLenghtLining":
                    url = "./../../CWP/FullLengthLining/fl_navigator.aspx?source_page=select_project.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=Full Length Lining";
                    break;

                case "mJunctionLining":
                    url = "./../../CWP/JunctionLining/jl_navigator.aspx?source_page=select_project.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=Junction Lining";
                    break;

                // Navigate
                case "mLastSearch":
                    url = "./pr_navigator2.aspx?source_page=pr_summary.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mPrevious":
                    // Get previous record
                    int previousId = PrNavigator.GetPreviousId((PrNavigatorTDS)Session["prNavigatorTDS"], Int32.Parse(hdfAssetId.Value));
                    if (previousId != Int32.Parse(hdfAssetId.Value))
                    {
                        switch (ddlFilter.SelectedValue)
                        {
                            case "(All)":
                                SetFilter("Deleted = 0");
                                break;

                            case "Robotic Reaming":
                                SetFilter("Type='Robotic Reaming' AND Deleted = 0");
                                break;

                            case "Point Lining":
                                SetFilter("Type='Point Lining' AND Deleted = 0");
                                break;

                            case "Grouting":
                                SetFilter("Type='Grouting' AND Deleted = 0");
                                break;
                        }

                        // Redirect
                        url = "./pr_summary.aspx?source_page=pr_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + previousId.ToString() + "&active_tab=" + activeTab + GetNavigatorState();
                    }
                    break;

                case "mNext":
                    // Get next record
                    int nextId = PrNavigator.GetNextId((PrNavigatorTDS)Session["prNavigatorTDS"], Int32.Parse(hdfAssetId.Value));
                    if (nextId != Int32.Parse(hdfAssetId.Value))
                    {
                        switch (ddlFilter.SelectedValue)
                        {
                            case "(All)":
                                SetFilter("Deleted = 0");
                                break;

                            case "Robotic Reaming":
                                SetFilter("Type='Robotic Reaming' AND Deleted = 0");
                                break;

                            case "Point Lining":
                                SetFilter("Type='Point Lining' AND Deleted = 0");
                                break;

                            case "Grouting":
                                SetFilter("Type='Grouting' AND Deleted = 0");
                                break;
                        }

                        // Redirect
                        url = "./pr_summary.aspx?source_page=pr_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + nextId.ToString() + "&active_tab=" + activeTab + GetNavigatorState();
                    }
                    break;
            }

            if (url != "") Response.Redirect(url);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            string url = "";

            // Store active tab for postback
            Session["activeTabPr"] = "0";
            Session["dialogOpenedPr"] = "0";

            switch (e.Item.Value)
            {
                case "mSearch":
                    url = "./pr_navigator.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=Point Repairs";
                    break;

                case "mPointRepairsPlan":
                    url = "./pr_lining_plan.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value;
                    break;
            }

            if (url != "") Response.Redirect(url);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfCurrentClientIdId = '" + hdfCurrentClientId.ClientID + "';";
            contentVariables += "var hdfCurrentProjectIdId = '" + hdfCurrentProjectId.ClientID + "';";
            contentVariables += "var hdfWorkIdId = '" + hdfWorkId.ClientID + "';";
            contentVariables += "var hdfActiveTabId = '" + hdfActiveTab.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./pr_summary.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&columns_to_display2=" + Request.QueryString["columns_to_display2"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_ddlCondition2=" + Request.QueryString["search_ddlCondition2"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_tbxCondition2=" + Request.QueryString["search_tbxCondition2"] + "&search_ddlOperator1=" + Request.QueryString["search_ddlOperator1"] + "&search_ddlOperator2=" + Request.QueryString["search_ddlOperator2"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_sub_area=" + Request.QueryString["search_sub_area"] + "&btn_origin=" + Request.QueryString["btn_origin"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }

        

        #region TagPage and Load Functions

        private void TagPage()
        {
            hdfCompanyId.Value = Session["companyID"].ToString();
            hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();
            hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();
            hdfAssetId.Value = Request.QueryString["asset_id"].ToString();
            hdfActiveTab.Value = Request.QueryString["active_tab"].ToString();

            // Get ids & location
            int projectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int assetId = Int32.Parse(hdfAssetId.Value);

            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            // ... Get ids
            Int64 currentCountry = projectGateway.GetCountryID(projectId);
            Int64? currentProvince = null; if (projectGateway.GetProvinceID(projectId).HasValue) currentProvince = (Int64)projectGateway.GetProvinceID(projectId);
            Int64? currentCounty = null; if (projectGateway.GetCountyID(projectId).HasValue) currentCounty = (Int64)projectGateway.GetCountyID(projectId);
            Int64? currentCity = null; if (projectGateway.GetCityID(projectId).HasValue) currentCity = (Int64)projectGateway.GetCityID(projectId);

            hdfCountryId.Value = currentCountry.ToString();
            hdfProvinceId.Value = currentProvince.ToString();
            hdfCountyId.Value = currentCounty.ToString();
            hdfCityId.Value = currentCity.ToString();

            // Get workId
            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, "Point Repairs", companyId);
            hdfWorkId.Value = workGateway.GetWorkId(assetId, "Point Repairs", projectId).ToString();
        }



        private void LoadPointRepairsData(int projectId, int assetId, int companyId)
        {
            // Get WorkId
            int workId = Int32.Parse(hdfWorkId.Value);

            // Load Data
            LoadSectionData(workId);
            LoadWorkData(workId, assetId);
        }



        private void LoadSectionData(int workId)
        {
            PointRepairsSectionDetailsGateway pointRepairsSectionDetailsGateway = new PointRepairsSectionDetailsGateway(pointRepairsTDS);
            if (pointRepairsSectionDetailsGateway.Table.Rows.Count > 0)
            {
                // Load Section Details
                tbxFlowOrderId.Text = pointRepairsSectionDetailsGateway.GetFlowOrderId(workId);
                hdfSectionId.Value = pointRepairsSectionDetailsGateway.GetSectionId(workId);
                hdfFlowOrderId.Value = pointRepairsSectionDetailsGateway.GetFlowOrderId(workId);
                hdfSectionId.Value = pointRepairsSectionDetailsGateway.GetSectionId(workId);
                tbxStreet.Text = pointRepairsSectionDetailsGateway.GetStreet(workId);
                tbxUSMH.Text = pointRepairsSectionDetailsGateway.GetUsmhDescription(workId);
                tbxUSMHMN.Text = pointRepairsSectionDetailsGateway.GetUsmhAddress(workId);
                tbxDSMH.Text = pointRepairsSectionDetailsGateway.GetDsmhDescription(workId);
                tbxDSMHMN.Text = pointRepairsSectionDetailsGateway.GetDsmhAddress(workId);
                tbxMapSize.Text = pointRepairsSectionDetailsGateway.GetMapSize(workId);
                tbxConfirmedSize.Text = pointRepairsSectionDetailsGateway.GetSize_(workId);
                tbxMapLength.Text = pointRepairsSectionDetailsGateway.GetMapLength(workId);
                tbxSteelTapeLength.Text = pointRepairsSectionDetailsGateway.GetLength(workId);
                tbxLaterals.Text = "0"; if (pointRepairsSectionDetailsGateway.GetLaterals(workId).HasValue) tbxLaterals.Text = pointRepairsSectionDetailsGateway.GetLaterals(workId).ToString().Trim();
                tbxLiveLaterals.Text = "0"; if (pointRepairsSectionDetailsGateway.GetLiveLaterals(workId).HasValue) tbxLiveLaterals.Text = pointRepairsSectionDetailsGateway.GetLiveLaterals(workId).ToString().Trim();
                tbxGeneralDataSubArea.Text = pointRepairsSectionDetailsGateway.GetSubArea(workId);
            }
        }



        private void LoadWorkData(int workId, int assetId)
        {
            PointRepairsWorkDetailsGateway pointRepairsWorkDetailsGateway = new PointRepairsWorkDetailsGateway(pointRepairsTDS);
            
            if (pointRepairsWorkDetailsGateway.Table.Rows.Count > 0)
            {
                // For Header
                tbxVideoLength.Text = pointRepairsWorkDetailsGateway.GetVideoLength(workId);

                // For PR general data
                tbxGeneralDataClientId.Text = pointRepairsWorkDetailsGateway.GetClientId(workId);
                tbxGeneralDataMeasurementsTakenBy.Text = pointRepairsWorkDetailsGateway.GetMeasurementTakenBy(workId);

                // For RA data
                tbxGeneralDataPreFlushDate.Text = "";
                if (pointRepairsWorkDetailsGateway.GetPreFlushDate(workId).HasValue)
                {
                    DateTime preFlushDate = (DateTime)pointRepairsWorkDetailsGateway.GetPreFlushDate(workId);
                    tbxGeneralDataPreFlushDate.Text = preFlushDate.Month.ToString() + "/" + preFlushDate.Day.ToString() + "/" + preFlushDate.Year.ToString();
                }

                tbxGeneralDataPreVideoDate.Text = "";
                if (pointRepairsWorkDetailsGateway.GetPreVideoDate(workId).HasValue)
                {
                    DateTime preVideoDate = (DateTime)pointRepairsWorkDetailsGateway.GetPreVideoDate(workId);
                    tbxGeneralDataPreVideoDate.Text = preVideoDate.Month.ToString() + "/" + preVideoDate.Day.ToString() + "/" + preVideoDate.Year.ToString();
                }
                // For FLL data
                tbxGeneralDataP1Date.Text = "";
                if (pointRepairsWorkDetailsGateway.GetP1Date(workId).HasValue)
                {
                    DateTime p1Date = (DateTime)pointRepairsWorkDetailsGateway.GetP1Date(workId);
                    tbxGeneralDataP1Date.Text = p1Date.Month.ToString() + "/" + p1Date.Day.ToString() + "/" + p1Date.Year.ToString();
                }

                tbxGeneralDataRepairConfirmationDate.Text = "";
                if (pointRepairsWorkDetailsGateway.GetRepairConfirmationDate(workId).HasValue)
                {
                    DateTime confirmationDate = (DateTime)pointRepairsWorkDetailsGateway.GetRepairConfirmationDate(workId);
                    tbxGeneralDataRepairConfirmationDate.Text = confirmationDate.Month.ToString() + "/" + confirmationDate.Day.ToString() + "/" + confirmationDate.Year.ToString();
                }
                
                // For FLL M1 data
                tbxGeneralDataTrafficControl.Text = pointRepairsWorkDetailsGateway.GetTrafficControl(workId);
                tbxGeneralDataMaterial.Text = pointRepairsWorkDetailsGateway.GetMaterial(workId); 

                // For FLL P1 data
                tbxGeneralDataCXIsRemoved.Text = ""; if (pointRepairsWorkDetailsGateway.GetCxisRemoved(workId).HasValue) tbxGeneralDataCXIsRemoved.Text = pointRepairsWorkDetailsGateway.GetCxisRemoved(workId).ToString();

                ckbxGeneralDataBypassRequired.Checked = pointRepairsWorkDetailsGateway.GetBypassRequired(workId);
                tbxGeneralDataRoboticDistances.Text = pointRepairsWorkDetailsGateway.GetRoboticDistances(workId);
                tbxGeneralDataProposedLiningDate.Text = "";
                if (pointRepairsWorkDetailsGateway.GetProposedLiningDate(workId).HasValue)
                {
                    DateTime proposedLiningDate = (DateTime)pointRepairsWorkDetailsGateway.GetProposedLiningDate(workId);
                    tbxGeneralDataProposedLiningDate.Text = proposedLiningDate.Month.ToString() + "/" + proposedLiningDate.Day.ToString() + "/" + proposedLiningDate.Year.ToString();
                }

                tbxGeneralDataDeadlineLiningDate.Text = "";
                if (pointRepairsWorkDetailsGateway.GetDeadlineLiningDate(workId).HasValue)
                {
                    DateTime deadlineLiningDate = (DateTime)pointRepairsWorkDetailsGateway.GetDeadlineLiningDate(workId);
                    tbxGeneralDataDeadlineLiningDate.Text = deadlineLiningDate.Month.ToString() + "/" + deadlineLiningDate.Day.ToString() + "/" + deadlineLiningDate.Year.ToString();
                }

                tbxGeneralDataFinalVideo.Text = "";
                if (pointRepairsWorkDetailsGateway.GetFinalVideoDate(workId).HasValue)
                {
                    DateTime finalVideo = (DateTime)pointRepairsWorkDetailsGateway.GetFinalVideoDate(workId);
                    tbxGeneralDataFinalVideo.Text = finalVideo.Month.ToString() + "/" + finalVideo.Day.ToString() + "/" + finalVideo.Year.ToString();
                }

                tbxGeneralDataEstimatedJoints.Text = ""; if (pointRepairsWorkDetailsGateway.GetEstimatedJoints(workId).HasValue) tbxGeneralDataEstimatedJoints.Text = pointRepairsWorkDetailsGateway.GetEstimatedJoints(workId).ToString();
                tbxGeneralDataJointsTestSealed.Text = ""; if (pointRepairsWorkDetailsGateway.GetJointsTestSealed(workId).HasValue) tbxGeneralDataJointsTestSealed.Text = pointRepairsWorkDetailsGateway.GetJointsTestSealed(workId).ToString();

                ckbxGeneralDataIssueIdentified.Checked = pointRepairsWorkDetailsGateway.GetIssueIdentified(workId);
                ckbxGeneralDataLfsIssue.Checked = pointRepairsWorkDetailsGateway.GetIssueLFS(workId);
                ckbxGeneralDataClientIssue.Checked = pointRepairsWorkDetailsGateway.GetIssueClient(workId);
                ckbxGeneralDataSalesIssue.Checked = pointRepairsWorkDetailsGateway.GetIssueSales(workId);
                ckbxGeneralDataIssueGivenToClient.Checked = pointRepairsWorkDetailsGateway.GetIssueGivenToClient(workId);
                ckbxGeneralDataIssueInvestigation.Checked = pointRepairsWorkDetailsGateway.GetIssueInvestigation(workId);
                ckbxGeneralDataIssueResolved.Checked = pointRepairsWorkDetailsGateway.GetIssueResolved(workId);
            }
        }



        #endregion
        



        protected void AddRepairsNewEmptyFix(GridView grdView)
        {
            if (grdRepairs.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                PointRepairsTDS.RepairDetailsDataTable dt = new PointRepairsTDS.RepairDetailsDataTable();
                dt.AddRepairDetailsRow(-1, "PL-A", "Temp", "", DateTime.Now, "", "", 0, "", "", "", "", DateTime.Now, "", "", DateTime.Now, "", false, false, "", false, companyId, false, "", "", "", DateTime.Now);
                Session["pointRepairsRepairsTempDummy"] = dt;
                SetFilter("Type='Temp' AND Deleted = 0");
                grdRepairs.DataBind();
            }

            // normally executes at all postbacks
            if (grdRepairs.Rows.Count == 1)
            {
                PointRepairsTDS.RepairDetailsDataTable dt = (PointRepairsTDS.RepairDetailsDataTable)Session["pointRepairsRepairsTempDummy"];
                if (dt != null)
                {
                    grdRepairs.Rows[0].Visible = false;
                    grdRepairs.Rows[0].Controls.Clear();

                    Session.Remove("pointRepairsRepairsTempDummy");
                }
            }
        }



        protected void AddCommentsNewEmptyFix(GridView grdView)
        {
            if (grdComments.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                PointRepairsTDS.CommentDetailsDataTable dt = new PointRepairsTDS.CommentDetailsDataTable();
                dt.AddCommentDetailsRow(-1, -1, "", "", -1, DateTime.Now, "", -1, false, companyId, false, "");
                Session["pointRepairsCommentsTempDummy"] = dt;

                grdComments.DataBind();
            }

            // normally executes at all postbacks
            if (grdComments.Rows.Count == 1)
            {
                PointRepairsTDS.CommentDetailsDataTable dt = (PointRepairsTDS.CommentDetailsDataTable)Session["pointRepairsCommentsTempDummy"];
                if (dt != null)
                {
                    grdComments.Rows[0].Visible = false;
                    grdComments.Rows[0].Controls.Clear();
                }
            }
        }        



        protected string GetCommentCreatedBy(object userId)
        {
            if (userId != DBNull.Value)
            {
                if (Convert.ToInt32(userId) != -1)
                {
                    try
                    {
                        // Created By
                        int companyId = Int32.Parse(hdfCompanyId.Value);

                        LoginGateway loginGateway = new LoginGateway();
                        loginGateway.LoadByLoginId(Convert.ToInt32(userId), companyId);
                        string userName = loginGateway.GetLastName(Convert.ToInt32(userId), companyId) + " " + loginGateway.GetFirstName(Convert.ToInt32(userId), companyId);

                        return userName.ToString();
                    }
                    catch
                    {
                        return "";
                    }
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



        private void ApplyFilter()
        {
            odsRepairs.FilterExpression = Session["filterExpression"].ToString();
        }



        protected void SetFilter(string filter)
        {
            Session["filterExpression"] = filter;
            ApplyFilter();
        }



        public PointRepairsTDS.RepairDetailsDataTable GetRepairsNew()
        {
            pointRepairsRepairsTemp = (PointRepairsTDS.RepairDetailsDataTable)Session["pointRepairsRepairsTempDummy"];

            if (pointRepairsRepairsTemp == null)
            {
                pointRepairsRepairsTemp = ((PointRepairsTDS)Session["pointRepairsTDS"]).RepairDetails;
            }

            return pointRepairsRepairsTemp;
        }



        public PointRepairsTDS.CommentDetailsDataTable GetCommentsNew()
        {
            pointRepairsCommentsTemp = (PointRepairsTDS.CommentDetailsDataTable)Session["pointRepairsCommentsTempDummy"];

            if (pointRepairsCommentsTemp == null)
            {
                pointRepairsCommentsTemp = ((PointRepairsTDS)Session["pointRepairsTDS"]).CommentDetails;
            }

            return pointRepairsCommentsTemp;
        }



    }
}