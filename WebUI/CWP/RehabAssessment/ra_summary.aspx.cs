using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.CWP.RehabAssessment;
using LiquiForce.LFSLive.BL.CWP.RehabAssessment;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.Tools;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.RehabAssessment
{
    /// <summary>
    /// ra_summary
    /// </summary>
    public partial class ra_summary : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected RehabAssessmentTDS.LateralDetailsDataTable raAddLateralsNewDetails;
        protected RehabAssessmentTDS rehabAssessmentTDS;






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
                if (!(Convert.ToBoolean(Session["sgLFS_CWP_REHABASSESSMENT_VIEW"]) && Convert.ToBoolean(Session["sgLFS_CWP_REHABASSESSMENT_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in ra_summary.aspx");
                }

                // Tag Page
                TagPage();

                Session.Remove("raAddLateralsNewDummy");

                // If coming from 
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());
                int assetId = Int32.Parse(hdfAssetId.Value.Trim());
                string workType = hdfWorkType.Value;
                int workId = Int32.Parse(hdfWorkId.Value);                

                // ... ra_navigator2.aspx
                if (Request.QueryString["source_page"] == "ra_navigator2.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";

                    // Set initial tab
                    if ((string)Session["dialogOpenedRa"] != "1")
                    {
                        rehabAssessmentTDS = new RehabAssessmentTDS();

                        RehabAssessmentSectionDetails rehabAssessmentSectionDetails = new RehabAssessmentSectionDetails(rehabAssessmentTDS);
                        rehabAssessmentSectionDetails.LoadByWorkId(workId, companyId);

                        RehabAssessmentWorkDetails rehabAssessmentWorkDetails = new RehabAssessmentWorkDetails(rehabAssessmentTDS);
                        rehabAssessmentWorkDetails.LoadByWorkId(workId, companyId);

                        int workIdFll = GetWorkId(currentProjectId, assetId, "Full Length Lining", companyId);
                        RehabAssessmentLateralDetails rehabAssessmentLateralDetails = new RehabAssessmentLateralDetails(rehabAssessmentTDS);
                        rehabAssessmentLateralDetails.LoadForEdit(workIdFll, assetId, companyId, currentProjectId);

                        hdfActiveTab.Value = Request.QueryString["active_tab"];
                    }
                    else
                    {
                        hdfActiveTab.Value = (string)Session["activeTabRa"];

                        // Restore dataset
                        rehabAssessmentTDS = (RehabAssessmentTDS)Session["rehabAssessmentTDS"];
                    }

                    tcRaDetails.ActiveTabIndex = Int32.Parse(hdfActiveTab.Value);

                    // Store dataset
                    Session["rehabAssessmentTDS"] = rehabAssessmentTDS;
                }

                // ... ra_delete.aspx or ra_edit.aspx 
                if ((Request.QueryString["source_page"] == "ra_delete.aspx") || (Request.QueryString["source_page"] == "ra_edit.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
                    rehabAssessmentTDS = (RehabAssessmentTDS)Session["rehabAssessmentTDS"];

                    // ... Set initial tab
                    if ((string)Session["dialogOpenedRa"] != "1")
                    {
                        hdfActiveTab.Value = Request.QueryString["active_tab"];
                    }
                    else
                    {
                        hdfActiveTab.Value = (string)Session["activeTabRa"];
                    }

                    tcRaDetails.ActiveTabIndex = Int32.Parse(hdfActiveTab.Value);
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

                // ... Data for current work                
                LoadRehabAssessmentData(currentProjectId, assetId, companyId);

                // Databind
                Page.DataBind();
            }
            else
            {
                // Restore datasets
                rehabAssessmentTDS = (RehabAssessmentTDS)Session["rehabAssessmentTDS"];

                // Set initial tab
                int activeTab = Int32.Parse(hdfActiveTab.Value);
                tcRaDetails.ActiveTabIndex = activeTab;
            }
        }        



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "eSewers";

            // For materials
            // ... Load material for m1

            int companyId = Int32.Parse(hdfCompanyId.Value);
            int assetId = Int32.Parse(hdfAssetId.Value);
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());

            MaterialInformationGateway materialInformationGateway = new MaterialInformationGateway();
            materialInformationGateway.LoadLastMaterialByAssetId(assetId, companyId);

            if (materialInformationGateway.Table.Rows.Count > 0)
            {
                tbxM1DataMaterial.Text = materialInformationGateway.GetLastMaterialType(assetId);
            }

            // Hide or show the Old CWP ID field
            if (tbxOldCwpId.Text == "")
            {
                lblOldCwpId.Visible = false;
                tbxOldCwpId.Visible = false;
            }

            if (tbxFlowOrderId.Text == "")
            {
                LoadRehabAssessmentData(currentProjectId, assetId, companyId);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void grdLaterals_DataBound(object sender, EventArgs e)
        {
            RaAddLateralsNewEmptyFix(grdLaterals);
        }



        protected void btnCommentsOnClick(object sender, EventArgs e)
        {
            // Store active tab for postback
            Session["activeTabRa"] = "3";
            Session["dialogOpenedRa"] = "1";

            // Open Dialog
            int assetId = Int32.Parse(hdfAssetId.Value);
            int workId = Int32.Parse(hdfWorkId.Value);
            int currentClientId = Int32.Parse(hdfCurrentClientId.Value);
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value);

            string script = "<script language='javascript'>";
            string url = "./ra_comments.aspx?source_page=ra_summary.aspx&asset_id=" + hdfAssetId.Value + "&client_id=" + hdfCurrentClientId.Value + "&work_id=" + hdfWorkId.Value + "&project_id=" + hdfCurrentProjectId.Value;
            script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=795, height=640')", url);
            script = script + "</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Comments", script, false);
        }
        





        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("./../Common/select_project.aspx?source_page=ra_summary.aspx&work_type=" + hdfWorkType.Value.Trim());
        }



        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            // Store active tab for postback
            Session["activeTabRa"] = "0";
            Session["dialogOpenedRa"] = "0";

            string activeTab = hdfActiveTab.Value;
            string url = "";

            switch (e.Item.Value)
            {
                case "mEdit":                    
                    url = "./ra_edit.aspx?source_page=ra_summary.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&asset_id=" + hdfAssetId.Value + "&update=" + (string)ViewState["update"] + "&active_tab=" + activeTab;
                    break;

                case "mDelete":
                    url = "./ra_delete.aspx?source_page=ra_summary.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&asset_id=" + hdfAssetId.Value + "&update=" + (string)ViewState["update"];
                    break;

                case "mLastSearch":
                    url = "./ra_navigator2.aspx?source_page=ra_summary.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                // Works
                case "mFullLenghtLining":
                    url = "./../FullLengthLining/fl_navigator.aspx?source_page=select_project.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=Full Length Lining";
                    break;

                case "mPointRepairs":
                    url = "./../PointRepairs/pr_navigator.aspx?source_page=select_project.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=Point Repairs";
                    break;

                case "mJunctionLining":
                    url = "./../JunctionLining/jl_navigator.aspx?source_page=select_project.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=Junction Lining";
                    break;

                case "mPrevious":
                    // Get previous record
                    int previousId = RaNavigator.GetPreviousId((RaNavigatorTDS)Session["raNavigatorTDS"], Int32.Parse(hdfAssetId.Value));
                    if (previousId != Int32.Parse(hdfAssetId.Value))
                    {
                        // Redirect
                        url = "./ra_summary.aspx?source_page=ra_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + previousId.ToString() + "&active_tab=" + activeTab + GetNavigatorState();
                    }
                    break;

                case "mNext":
                    // Get next record
                    int nextId = RaNavigator.GetNextId((RaNavigatorTDS)Session["raNavigatorTDS"], Int32.Parse(hdfAssetId.Value));
                    if (nextId != Int32.Parse(hdfAssetId.Value))
                    {
                        // Redirect
                        url = "./ra_summary.aspx?source_page=ra_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + nextId.ToString() + "&active_tab=" + activeTab + GetNavigatorState();
                    }
                    break;
            }

            if (url != "") Response.Redirect(url);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            // Store active tab for postback
            Session["activeTabRa"] = "0";
            Session["dialogOpenedRa"] = "0";

            string url = "";

            switch (e.Item.Value)
            {
                case "mRehabAssessmentPlan":
                    url = "./ra_lining_plan.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value;
                    break;

                case "mSearch":
                    url = "./ra_navigator.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value;
                    break;
            }

            if (url != "") Response.Redirect(url);
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        public RehabAssessmentTDS.LateralDetailsDataTable GetLateralDetails()
        {
            raAddLateralsNewDetails = (RehabAssessmentTDS.LateralDetailsDataTable)Session["raAddLateralsNewDummy"];
            if (raAddLateralsNewDetails == null)
            {
                raAddLateralsNewDetails = ((RehabAssessmentTDS)Session["rehabAssessmentTDS"]).LateralDetails;
            }

            return raAddLateralsNewDetails;
        }



        private void RegisterClientScripts()
        {
            // Publishing body's OnKeyDown event 
            HtmlGenericControl bodyUnload = (HtmlGenericControl)Page.Master.FindControl("myBody");
            bodyUnload.Attributes.Add("OnKeyDown", "OnKeyDown(event);");

            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfWorkTypeId = '" + hdfWorkType.ClientID + "';";
            contentVariables += "var hdfCurrentClientIdId = '" + hdfCurrentClientId.ClientID + "';";
            contentVariables += "var hdfCurrentProjectIdId = '" + hdfCurrentProjectId.ClientID + "';";
            contentVariables += "var hdfAssetIdId = '" + hdfAssetId.ClientID + "';";
            contentVariables += "var hdfWorkIdId = '" + hdfWorkId.ClientID + "';";
            contentVariables += "var hdfWorkIdFllId = '" + hdfWorkIdFll.ClientID + "';";
            contentVariables += "var hdfActiveTabId = '" + hdfActiveTab.ClientID + "';";
            contentVariables += "var hdfMeasuredFromId = '" + hdfMeasuredFrom.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./ra_summary.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&btn_origin=" + Request.QueryString["btn_origin"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        protected void RaAddLateralsNewEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                RehabAssessmentTDS.LateralDetailsDataTable dt = new RehabAssessmentTDS.LateralDetailsDataTable();
                int companyId = Int32.Parse(hdfCompanyId.Value);
                dt.AddLateralDetailsRow(-1, "", "", "", "", "", DateTime.Now, "", "", "", "", "", "", false, companyId, false, false, false, "", false, "", true, false, true, false, "", "", "", DateTime.Now, false, DateTime.Now, false, false, false, "", false, DateTime.Now, "");
                Session["raAddLateralsNewDummy"] = dt;

                grdView.DataBind();
            }

            // normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                RehabAssessmentTDS.LateralDetailsDataTable dt = (RehabAssessmentTDS.LateralDetailsDataTable)Session["raAddLateralsNewDummy"];
                if (dt != null)
                {
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        protected string GetDistance(object distance)
        {
            if (distance != DBNull.Value)
            {
                if (Validator.IsValidDouble(distance.ToString()))
                {
                    if (distance.ToString().Contains("-"))
                    {
                        string positiveValue = distance.ToString().Replace('-', ' ').Trim();
                        return "-" + string.Format("{0:0.0}", Convert.ToDouble(positiveValue));
                    }
                    else
                    {
                        return string.Format("{0:0.0}", Convert.ToDouble(distance));
                    }
                }
                else
                {
                    return distance.ToString();
                }
            }
            else
            {
                return "";
            }
        }



        protected string GetIssueSelected(string issue)
        {
            if (issue != "")
            {
                if (issue.ToString() == "Dig Required Prior To Lining")
                {
                    return "Dig Req'd Prior To Lining";
                }

                if (issue.ToString() == "Dig Required After Lining")
                {
                    return "Dig Req'd After Lining";
                }

                if (issue.ToString() == "Robotic Prep Required")
                {
                    return "Robotic Prep Req'd";
                }

                return issue.ToString();
            }
            else
            {
                return "";
            }
        }


        
        #region TagPage and Load Functions

        private void TagPage()
        {
            hdfCompanyId.Value = Session["companyID"].ToString();
            hdfCurrentProjectId.Value = Request.QueryString["project_id"].ToString();
            hdfCurrentClientId.Value = Request.QueryString["client_id"].ToString();
            hdfWorkType.Value = "Rehab Assessment";
            hdfAssetId.Value = Request.QueryString["asset_id"].ToString();
            hdfActiveTab.Value = Request.QueryString["active_tab"].ToString();

            // Get ids & location
            int projectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
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
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int assetId = Int32.Parse(hdfAssetId.Value);
            string workType = hdfWorkType.Value;

            WorkGateway workGateway = new WorkGateway();
            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, workType, companyId);
            hdfWorkId.Value = workGateway.GetWorkId(assetId, workType, projectId).ToString();

            hdfWorkIdFll.Value = GetWorkId(projectId, assetId, "Full Length Lining", companyId).ToString();
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



        private void LoadRehabAssessmentData(int projectId, int assetId, int companyId)
        {
            // Get WorkId
            string workType = hdfWorkType.Value.Trim();
            int workId = Int32.Parse(hdfWorkId.Value);

            // Load Data
            LoadSectionData(workId);
            LoadWorkData(workId, assetId);
        }



        private void LoadSectionData(int workId)
        {
            RehabAssessmentSectionDetailsGateway rehabAssessmentSectionDetailsGateway = new RehabAssessmentSectionDetailsGateway(rehabAssessmentTDS);
            if (rehabAssessmentSectionDetailsGateway.Table.Rows.Count > 0)
            {
                // Load Section Details
                tbxFlowOrderId.Text = rehabAssessmentSectionDetailsGateway.GetFlowOrderId(workId);
                hdfFlowOrderId.Value = rehabAssessmentSectionDetailsGateway.GetFlowOrderId(workId);
                hdfSectionId.Value = rehabAssessmentSectionDetailsGateway.GetSectionId(workId);
                tbxOldCwpId.Text = rehabAssessmentSectionDetailsGateway.GetOriginalSectionId(workId);                
                tbxStreet.Text = rehabAssessmentSectionDetailsGateway.GetStreet(workId);
                tbxUSMH.Text = rehabAssessmentSectionDetailsGateway.GetUsmhDescription(workId);
                tbxDSMH.Text = rehabAssessmentSectionDetailsGateway.GetDsmhDescription(workId);
                tbxMapSize.Text = rehabAssessmentSectionDetailsGateway.GetMapSize(workId);
                tbxConfirmedSize.Text = rehabAssessmentSectionDetailsGateway.GetSize_(workId);
                tbxThickness.Text = rehabAssessmentSectionDetailsGateway.GetThickness(workId);
                tbxMapLength.Text = rehabAssessmentSectionDetailsGateway.GetMapLength(workId);
                tbxLength.Text = rehabAssessmentSectionDetailsGateway.GetLength(workId);
                tbxLaterals.Text = "0"; if (rehabAssessmentSectionDetailsGateway.GetLaterals(workId).HasValue) tbxLaterals.Text = rehabAssessmentSectionDetailsGateway.GetLaterals(workId).ToString().Trim();
                tbxLiveLaterals.Text = "0"; if (rehabAssessmentSectionDetailsGateway.GetLiveLaterals(workId).HasValue) tbxLiveLaterals.Text = rehabAssessmentSectionDetailsGateway.GetLiveLaterals(workId).ToString().Trim();

                // For m1 data
                // ... for depths
                tbxM1DataUsmhDepth.Text = rehabAssessmentSectionDetailsGateway.GetUsmhDepth(workId);
                tbxM1DataDsmhDepth.Text = rehabAssessmentSectionDetailsGateway.GetDsmhDepth(workId);

                // ... for address
                tbxM1DataUsmhAddress.Text = rehabAssessmentSectionDetailsGateway.GetUsmhAddress(workId);
                tbxM1DataDsmhAddress.Text = rehabAssessmentSectionDetailsGateway.GetDsmhAddress(workId);

                // ... Get lfs asset sewer data
                tbxM1DataSteelTapeThroughSewer.Text = rehabAssessmentSectionDetailsGateway.GetSteelTapeThroughSewer(workId);
                tbxM1DataUsmhMouth12.Text = rehabAssessmentSectionDetailsGateway.GetUsmhMouth12(workId);
                tbxM1DataUsmhMouth1.Text = rehabAssessmentSectionDetailsGateway.GetUsmhMouth1(workId);
                tbxM1DataUsmhMouth2.Text = rehabAssessmentSectionDetailsGateway.GetUsmhMouth2(workId);
                tbxM1DataUsmhMouth3.Text = rehabAssessmentSectionDetailsGateway.GetUsmhMouth3(workId);
                tbxM1DataUsmhMouth4.Text = rehabAssessmentSectionDetailsGateway.GetUsmhMouth4(workId);
                tbxM1DataUsmhMouth5.Text = rehabAssessmentSectionDetailsGateway.GetUsmhMouth5(workId);
                tbxM1DataDsmhMouth12.Text = rehabAssessmentSectionDetailsGateway.GetDsmhMouth12(workId);
                tbxM1DataDsmhMouth1.Text = rehabAssessmentSectionDetailsGateway.GetDsmhMouth1(workId);
                tbxM1DataDsmhMouth2.Text = rehabAssessmentSectionDetailsGateway.GetDsmhMouth2(workId);
                tbxM1DataDsmhMouth3.Text = rehabAssessmentSectionDetailsGateway.GetDsmhMouth3(workId);
                tbxM1DataDsmhMouth4.Text = rehabAssessmentSectionDetailsGateway.GetDsmhMouth4(workId);
                tbxM1DataDsmhMouth5.Text = rehabAssessmentSectionDetailsGateway.GetDsmhMouth5(workId);
                tbxGeneralSubArea.Text = rehabAssessmentSectionDetailsGateway.GetSubArea(workId);
            }
        }



        private void LoadWorkData(int workId, int assetId)
        {
            RehabAssessmentWorkDetailsGateway rehabAssessmentWorkDetailsGateway = new RehabAssessmentWorkDetailsGateway(rehabAssessmentTDS);
            
            if (rehabAssessmentWorkDetailsGateway.Table.Rows.Count > 0)
            {
                // For Header
                tbxVideoLength.Text = rehabAssessmentWorkDetailsGateway.GetVideoDistance(workId);

                // Load general data
                tbxGeneralClientId.Text = rehabAssessmentWorkDetailsGateway.GetClientId(workId);
                
                tbxPrepDataP1Date.Text = "";
                if (rehabAssessmentWorkDetailsGateway.GetP1Date(workId).HasValue)
                {
                    DateTime p1Date = (DateTime)rehabAssessmentWorkDetailsGateway.GetP1Date(workId);
                    tbxPrepDataP1Date.Text = p1Date.Month.ToString() + "/" + p1Date.Day.ToString() + "/" + p1Date.Year.ToString();
                }

                tbxM1DataM1Date.Text = "";
                if (rehabAssessmentWorkDetailsGateway.GetM1Date(workId).HasValue)
                {
                    DateTime m1Date = (DateTime)rehabAssessmentWorkDetailsGateway.GetM1Date(workId);
                    tbxM1DataM1Date.Text = m1Date.Month.ToString() + "/" + m1Date.Day.ToString() + "/" + m1Date.Year.ToString();
                }

                // ... for RA data
                tbxGeneralPreFlushDate.Text = "";
                if (rehabAssessmentWorkDetailsGateway.GetPreFlushDate(workId).HasValue)
                {
                    DateTime preFlushDate = (DateTime)rehabAssessmentWorkDetailsGateway.GetPreFlushDate(workId);
                    tbxGeneralPreFlushDate.Text = preFlushDate.Month.ToString() + "/" + preFlushDate.Day.ToString() + "/" + preFlushDate.Year.ToString();
                }

                tbxGeneralPreVideoDate.Text = "";
                if (rehabAssessmentWorkDetailsGateway.GetPreVideoDate(workId).HasValue)
                {
                    DateTime preVideoDate = (DateTime)rehabAssessmentWorkDetailsGateway.GetPreVideoDate(workId);
                    tbxGeneralPreVideoDate.Text = preVideoDate.Month.ToString() + "/" + preVideoDate.Day.ToString() + "/" + preVideoDate.Year.ToString();
                }

                // For FullLengthLiningP1 data
                tbxPrepDataCXIsRemoved.Text = ""; if (rehabAssessmentWorkDetailsGateway.GetCxisRemoved(workId).HasValue) tbxPrepDataCXIsRemoved.Text = rehabAssessmentWorkDetailsGateway.GetCxisRemoved(workId).ToString();
                ckbxPrepDataRoboticPrepCompleted.Checked = rehabAssessmentWorkDetailsGateway.GetRoboticPrepCompleted(workId);
                tbxPrepDataRoboticPrepCompletedDate.Text = "";
                if (rehabAssessmentWorkDetailsGateway.GetRoboticPrepCompletedDate(workId).HasValue)
                {
                    DateTime prePrepDataRoboticPrepCompletedDate = (DateTime)rehabAssessmentWorkDetailsGateway.GetRoboticPrepCompletedDate(workId);
                    tbxPrepDataRoboticPrepCompletedDate.Text = prePrepDataRoboticPrepCompletedDate.Month.ToString() + "/" + prePrepDataRoboticPrepCompletedDate.Day.ToString() + "/" + prePrepDataRoboticPrepCompletedDate.Year.ToString();
                }
                ckbxPrepDataP1Completed.Checked = rehabAssessmentWorkDetailsGateway.GetP1Completed(workId);

                // For FullLengthLiningM1 data
                // ... for material
                tbxM1DataMaterial.Text = rehabAssessmentWorkDetailsGateway.GetMaterial(workId);

                // ... For m1 data
                tbxM1DataMeasurementsTakenBy.Text = rehabAssessmentWorkDetailsGateway.GetMeasurementTakenBy(workId);
                tbxM1DataTrafficControl.Text = rehabAssessmentWorkDetailsGateway.GetTrafficControl(workId);
                tbxM1DataSiteDetails.Text = rehabAssessmentWorkDetailsGateway.GetSiteDetails(workId);
                tbxM1DataAccessType.Text = rehabAssessmentWorkDetailsGateway.GetAccessType(workId);
                ckbxM1DataPipeSizeChange.Checked = rehabAssessmentWorkDetailsGateway.GetPipeSizeChange(workId);
                ckbxM1DataStandardBypass.Checked = rehabAssessmentWorkDetailsGateway.GetStandardBypass(workId);
                //tbxM1DataIssue.Text = GetIssueSelected (rehabAssessmentWorkDetailsGateway.GetIssue(workId));
                tbxM1DataStandardBypassComments.Text = rehabAssessmentWorkDetailsGateway.GetStandardBypassComments(workId);
                tbxM1DataTrafficControlDetails.Text = rehabAssessmentWorkDetailsGateway.GetTrafficControlDetails(workId);
                tbxM1DataMeasurementType.Text = rehabAssessmentWorkDetailsGateway.GetMeasurementType(workId);
                tbxM1DataMeasuredFromMH.Text = rehabAssessmentWorkDetailsGateway.GetMeasurementFromMh(workId);
                hdfMeasuredFrom.Value = rehabAssessmentWorkDetailsGateway.GetMeasurementFromMh(workId);
                tbxM1DataVideoDoneFromMH.Text = rehabAssessmentWorkDetailsGateway.GetVideoDoneFromMh(workId);
                tbxM1DataToMH.Text = rehabAssessmentWorkDetailsGateway.GetVideoDoneToMh(workId);

                //tbxM1DataRoboticPrepDate.Text = "";
                //if (rehabAssessmentWorkDetailsGateway.GetRoboticPrepDate(workId).HasValue)
                //{
                //    DateTime roboticPrepDate = (DateTime)rehabAssessmentWorkDetailsGateway.GetRoboticPrepDate(workId);
                //    tbxM1DataRoboticPrepDate.Text = roboticPrepDate.Month.ToString() + "/" + roboticPrepDate.Day.ToString() + "/" + roboticPrepDate.Year.ToString();
                //}

                // For comments
                tbxCommentsDataComments.Text = rehabAssessmentWorkDetailsGateway.GetComments(workId);
            }
        }

        #endregion


        
    }
}