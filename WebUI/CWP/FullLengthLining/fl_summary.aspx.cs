using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.BL.CWP.FullLengthLining;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.Tools;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.FullLengthLining
{
    /// <summary>
    /// fl_summary
    /// </summar
    public partial class fl_summary : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected FullLengthLiningTDS.LateralDetailsDataTable flAddLateralsNewDetails;
        protected FullLengthLiningTDS.WetOutCatalystsDetailsDataTable wetOutCatalystsDetails;
        protected FullLengthLiningTDS fullLengthLiningTDS;






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
                if (!(Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_VIEW"]) && Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["asset_id"] == null) || ((string)Request.QueryString["active_tab"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in fl_summary.aspx");
                }

                // Tag Page
                TagPage();

                Session.Remove("flAddLateralsNewDummy");
                Session.Remove("wetOutCatalystsDetailsDummy");

                // If comming from 
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());
                int assetId = Int32.Parse(hdfAssetId.Value.Trim());
                string workType = hdfWorkType.Value;
                int workId = Int32.Parse(hdfWorkId.Value);

                // ... fl_navigator2.aspx
                if (Request.QueryString["source_page"] == "fl_navigator2.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";

                    // Set initial tab
                    if ((string)Session["dialogOpenedFll"] != "1")
                    {
                        hdfActiveTab.Value = Request.QueryString["active_tab"];

                        fullLengthLiningTDS = new FullLengthLiningTDS();
                        
                        FullLengthLiningSectionDetails fullLengthLiningSectionDetails = new FullLengthLiningSectionDetails(fullLengthLiningTDS);
                        fullLengthLiningSectionDetails.LoadByWorkId(workId, companyId);

                        FullLengthLiningWorkDetails fullLengthLiningWorkDetails = new FullLengthLiningWorkDetails(fullLengthLiningTDS);
                        fullLengthLiningWorkDetails.LoadByWorkIdAssetId(workId, assetId, companyId);

                        FullLengthLiningLateralDetails fullLengthLiningLateralDetails = new FullLengthLiningLateralDetails(fullLengthLiningTDS);
                        fullLengthLiningLateralDetails.LoadForEdit(workId, assetId, companyId, currentProjectId);

                        FullLengthLiningWetOutCatalystsDetails fullLengthLiningWetOutCatalystsDetails = new FullLengthLiningWetOutCatalystsDetails(fullLengthLiningTDS);
                        fullLengthLiningWetOutCatalystsDetails.LoadAll(workId, companyId);
                    }
                    else
                    {
                        hdfActiveTab.Value = (string)Session["activeTabFll"];

                        // Restore datasets
                        fullLengthLiningTDS = (FullLengthLiningTDS)Session["fullLengthLiningTDS"];
                    }

                    tcFlDetails.ActiveTabIndex = Int32.Parse(hdfActiveTab.Value);

                    // Store dataset
                    Session["fullLengthLiningTDS"] = fullLengthLiningTDS;
                }

                // ... fl_delete.aspx or fl_edit.aspx 
                if ((Request.QueryString["source_page"] == "fl_delete.aspx") || (Request.QueryString["source_page"] == "fl_edit.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
                    fullLengthLiningTDS = (FullLengthLiningTDS)Session["fullLengthLiningTDS"];

                    // ... Set initial tab
                    if ((string)Session["dialogOpenedFll"] != "1")
                    {
                        hdfActiveTab.Value = Request.QueryString["active_tab"];
                    }
                    else
                    {
                        hdfActiveTab.Value = (string)Session["activeTabFll"];
                    }

                    tcFlDetails.ActiveTabIndex = Int32.Parse(hdfActiveTab.Value);
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

                // ... for wet out section list
                AssetSewerSectionList assetSewerSectionList = new AssetSewerSectionList();
                assetSewerSectionList.LoadAndAddItem(Int32.Parse(hdfCurrentProjectId.Value), hdfWorkType.Value, "-1", "(All)", Int32.Parse(hdfCompanyId.Value));
                cbxlWetOutDataSectionId.DataSource = assetSewerSectionList.Table;
                cbxlWetOutDataSectionId.DataValueField = "SectionID";
                cbxlWetOutDataSectionId.DataTextField = "FlowOrderID";
                cbxlWetOutDataSectionId.DataBind();

                cbxlInversionDataSectionId.DataSource = assetSewerSectionList.Table;
                cbxlInversionDataSectionId.DataValueField = "SectionID";
                cbxlInversionDataSectionId.DataTextField = "FlowOrderID";
                cbxlInversionDataSectionId.DataBind();  

                // ... Data for current full length lining work                
                LoadFullLengthLiningData(currentProjectId, assetId, companyId);
                                
                // Databind
                Page.DataBind();

                // Especial load for Run details
                string runDetails = hdfRunDetails.Value;
                WorkFullLengthLiningWetOutGateway workFullLengthLiningWetOutGateway = new WorkFullLengthLiningWetOutGateway();
                workFullLengthLiningWetOutGateway.LoadByWorkId(workId, companyId);

                // ... Verify if work has cipp information to load run details
                if (workFullLengthLiningWetOutGateway.Table.Rows.Count > 0)
                {
                    string[] runDetailsList = runDetails.Split('>');
                    for (int i = 0; i < runDetailsList.Length; i++)
                    {
                        cbxlWetOutDataSectionId.Items.FindByValue(runDetailsList[i]).Selected = true;
                        cbxlInversionDataSectionId.Items.FindByValue(runDetailsList[i]).Selected = true;
                    }
                }
                else
                {
                    if (cbxlWetOutDataSectionId.Items.Count > 1)
                    {                        
                        cbxlWetOutDataSectionId.Items.FindByValue(hdfSectionId.Value).Selected = true;
                    }
                }
            }
            else
            {
                // Restore datasets
                fullLengthLiningTDS = (FullLengthLiningTDS)Session["fullLengthLiningTDS"];
                
                // Set initial tab
                int activeTab = Int32.Parse(hdfActiveTab.Value);
                tcFlDetails.ActiveTabIndex = activeTab;

                // Load summary for inversionfield cure record
                int companyId =Int32.Parse(hdfCompanyId.Value);
                int workId = Int32.Parse(hdfWorkId.Value);

                FlInversionFieldCureRecord FlInversionFieldCureRecordForSummary = new FlInversionFieldCureRecord();
                FlInversionFieldCureRecordForSummary.Load(workId, companyId);
                if (FlInversionFieldCureRecordForSummary.Table.Rows.Count > 0)
                {
                    lblInversionDataFieldCureRecordSummary.Text = FlInversionFieldCureRecordForSummary.GetSummary();
                }

            }
        }

        

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "eSewers";

            // For error message
            lblWetOutDataWarning.Visible = false;
            if (tbxWetOutDataHoistHeight.Text == "OK")
            {
                lblWetOutDataWarning.Visible = false;
            }
            else
            {
                lblWetOutDataWarning.Visible = true;
            }
            
            // For Material
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int assetId = Int32.Parse(hdfAssetId.Value);
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());

            MaterialInformationGateway materialInformationGateway = new MaterialInformationGateway();
            materialInformationGateway.LoadLastMaterialByAssetId(assetId, companyId);

            if (materialInformationGateway.Table.Rows.Count > 0)
            {
                tbxM1DataMaterial.Text = materialInformationGateway.GetLastMaterialType(assetId);
            }

            // Hide or Show the Old CWP ID field
            if (tbxOldCwpId.Text == "")
            {
                lblOldCwpId.Visible = false;
                tbxOldCwpId.Visible = false;
            }

            if (tbxFlowOrderId.Text == "")
            {
                LoadFullLengthLiningData(currentProjectId, assetId, companyId);
            }

            // Validate tools
            if (Convert.ToBoolean(Session["sgLFS_CWP_FULLLENGTHLINING_ADMIN"]))
            {
                tkrpbLeftMenuTools.Items[0].Items[1].Visible = true; // Resins option
                tkrpbLeftMenuTools.Items[0].Items[2].Visible = true; // Catalyst option
            }
            else
            {
                tkrpbLeftMenuTools.Items[0].Items[1].Visible = false; // Resins option
                tkrpbLeftMenuTools.Items[0].Items[2].Visible = false; // Catalyst option
            }

            // Make Wetout tab visible
            if (ckbxWetOutDataIncludeWetOutInformation.Checked)
            {
                upnlVisibleInformation.Visible = true;
            }
            else
            {
                upnlVisibleInformation.Visible = false;
            }

            // Make inversion tab visible
            if (ckbxInversionDataIncludeInversionInformation.Checked)
            {
                upnlInversionVisibleInformation.Visible = true;
            }
            else
            {
                upnlInversionVisibleInformation.Visible = false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void grdLaterals_DataBound(object sender, EventArgs e)
        {
            FlAddLateralsNewEmptyFix(grdLaterals);
        }



        protected void grdCatalysts_DataBound(object sender, EventArgs e)
        {
            AddCatalystsNewEmptyFix(grdCatalysts);
        }



        protected void btnCommentsOnClick(object sender, EventArgs e)
        {
            // Store active tab for postback
            Session["activeTabFll"] = "7";
            Session["dialogOpenedFll"] = "1";

            // Open Dialog
            int assetId = Int32.Parse(hdfAssetId.Value);
            int workId = Int32.Parse(hdfWorkId.Value);
            int currentClientId = Int32.Parse(hdfCurrentClientId.Value);
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value);

            string script = "<script language='javascript'>";
            string url = "./fl_comments.aspx?source_page=fl_edit.aspx&asset_id=" + hdfAssetId.Value + "&client_id=" + hdfCurrentClientId.Value + "&work_id=" + hdfWorkId.Value + "&project_id=" + hdfCurrentProjectId.Value;
            script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=795, height=640')", url);
            script = script + "</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Comments", script, false);
        }



        protected void btnWetOutDataNotesOnClick(object sender, EventArgs e)
        {
            // Store active tab for postback
            Session["activeTabFll"] = "4";
            Session["dialogOpenedFll"] = "1";

            // Open Dialog
            int assetId = Int32.Parse(hdfAssetId.Value);
            int workId = Int32.Parse(hdfWorkId.Value);

            string script = "<script language='javascript'>";
            string url = "./fl_comments_cipp.aspx?source_page=fl_edit.aspx&asset_id=" + hdfAssetId.Value + "&work_id=" + hdfWorkId.Value;
            script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=795, height=640')", url);
            script = script + "</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Comments", script, false);
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("./../Common/select_project.aspx?source_page=fl_summary.aspx&work_type=" + hdfWorkType.Value.Trim());
        }



        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            // Store active tab for postback
            Session["activeTabFll"] = "0";
            Session["dialogOpenedFll"] = "0";

            string activeTab = hdfActiveTab.Value;
            string url = "";

            switch (e.Item.Value)
            {
                case "mEdit":
                    url = "./fl_edit.aspx?source_page=fl_summary.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&asset_id=" + hdfAssetId.Value + "&update=" + (string)ViewState["update"] + "&active_tab=" + activeTab;
                    break;

                case "mDelete":
                    url = "./fl_delete.aspx?source_page=fl_summary.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&asset_id=" + hdfAssetId.Value + "&update=" + (string)ViewState["update"];
                    break;

                case "mLastSearch":
                    url = "./fl_navigator2.aspx?source_page=fl_summary.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    break;

                case "mPrevious":
                    // Get previous record
                    int previousId = FlNavigator.GetPreviousId((FlNavigatorTDS)Session["flNavigatorTDS"], Int32.Parse(hdfAssetId.Value));
                    if (previousId != Int32.Parse(hdfAssetId.Value))
                    {
                        url = "./fl_summary.aspx?source_page=fl_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + previousId.ToString() + "&active_tab=" + activeTab + GetNavigatorState();
                    }
                    break;

                case "mNext":
                    // Get next record
                    int nextId = FlNavigator.GetNextId((FlNavigatorTDS)Session["flNavigatorTDS"], Int32.Parse(hdfAssetId.Value));
                    if (nextId != Int32.Parse(hdfAssetId.Value))
                    {
                        url = "./fl_summary.aspx?source_page=fl_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + nextId.ToString() + "&active_tab=" + activeTab + GetNavigatorState();
                    }
                    break;

                // Works
                case "mRehabAssessment":
                    url = "./../../CWP/RehabAssessment/ra_navigator.aspx?source_page=select_project.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=Rehab Assessment";
                    break;

                case "mPointRepairs":
                    url = "./../PointRepairs/pr_navigator.aspx?source_page=select_project.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=Point Repairs";
                    break;

                case "mJunctionLining":
                    url = "./../JunctionLining/jl_navigator.aspx?source_page=select_project.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=Junction Lining";
                    break;
            }

            if (url != "") Response.Redirect(url);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
           // Store active tab for postback
            Session["activeTabFll"] = "0";
            Session["dialogOpenedFll"] = "0";

            switch (e.Item.Value)
            {
                case "mSearch":
                    string url = "./fl_navigator.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value;
                    Response.Redirect(url);
                    break;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        public FullLengthLiningTDS.LateralDetailsDataTable GetLateralDetails()
        {
            flAddLateralsNewDetails = (FullLengthLiningTDS.LateralDetailsDataTable)Session["flAddLateralsNewDummy"];
            if (flAddLateralsNewDetails == null)
            {
                flAddLateralsNewDetails = ((FullLengthLiningTDS)Session["fullLengthLiningTDS"]).LateralDetails;
            }

            return flAddLateralsNewDetails;
        }



        public FullLengthLiningTDS.WetOutCatalystsDetailsDataTable GetCatalystsNew()
        {
            wetOutCatalystsDetails = (FullLengthLiningTDS.WetOutCatalystsDetailsDataTable)Session["wetOutCatalystsDetailsDummy"];
            if (wetOutCatalystsDetails == null)
            {
                wetOutCatalystsDetails = ((FullLengthLiningTDS)Session["fullLengthLiningTDS"]).WetOutCatalystsDetails;
            }

            return wetOutCatalystsDetails;
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
            contentVariables += "var hdfActiveTabId = '" + hdfActiveTab.ClientID + "';";
            contentVariables += "var hdfMeasuredFromId = '" + hdfMeasuredFrom.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./fl_summary.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&columns_to_display2=" + Request.QueryString["columns_to_display2"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_ddlCondition2=" + Request.QueryString["search_ddlCondition2"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_tbxCondition2=" + Request.QueryString["search_tbxCondition2"] + "&search_ddlOperator1=" + Request.QueryString["search_ddlOperator1"] + "&search_ddlOperator2=" + Request.QueryString["search_ddlOperator2"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_sub_area=" + Request.QueryString["search_sub_area"] + "&btn_origin=" + Request.QueryString["btn_origin"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        protected void FlAddLateralsNewEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                FullLengthLiningTDS.LateralDetailsDataTable dt = new FullLengthLiningTDS.LateralDetailsDataTable();
                int companyId = Int32.Parse(hdfCompanyId.Value);
                dt.AddLateralDetailsRow(-1, "", "", "", "", "", DateTime.Now, "", "", "", "", "", "", false, companyId, false, false, false, false, false, "", false, "", "", "", "", DateTime.Now, false, DateTime.Now, false, false, false, "", false, DateTime.Now, "");
                Session["flAddLateralsNewDummy"] = dt;

                grdView.DataBind();
            }

            // normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                FullLengthLiningTDS.LateralDetailsDataTable dt = (FullLengthLiningTDS.LateralDetailsDataTable)Session["flAddLateralsNewDummy"];
                if (dt != null)
                {
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        protected void AddCatalystsNewEmptyFix(GridView grdCatalysts)
        {
            if (grdCatalysts.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                FullLengthLiningTDS.WetOutCatalystsDetailsDataTable dt = new FullLengthLiningTDS.WetOutCatalystsDetailsDataTable();
                dt.AddWetOutCatalystsDetailsRow(-1, -1, -1, "", -1, -1, "", false, companyId, false);
                Session["wetOutCatalystsDetailsDummy"] = dt;

                grdCatalysts.DataBind();
            }

            // Normally executes at all postbacks
            if (grdCatalysts.Rows.Count == 1)
            {
                FullLengthLiningTDS.WetOutCatalystsDetailsDataTable dt = (FullLengthLiningTDS.WetOutCatalystsDetailsDataTable)Session["wetOutCatalystsDetailsDummy"];
                if (dt != null)
                {
                    grdCatalysts.Rows[0].Visible = false;
                    grdCatalysts.Rows[0].Controls.Clear();
                }
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
            hdfWorkType.Value = "Full Length Lining";
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
        }



        private void LoadFullLengthLiningData(int projectId, int assetId, int companyId)
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
            FullLengthLiningSectionDetailsGateway fullLengthLiningSectionDetailsGateway = new FullLengthLiningSectionDetailsGateway(fullLengthLiningTDS);
            if (fullLengthLiningSectionDetailsGateway.Table.Rows.Count > 0)
            {
                // Load Section Details
                tbxFlowOrderId.Text = fullLengthLiningSectionDetailsGateway.GetFlowOrderId(workId);
                hdfSectionId.Value = fullLengthLiningSectionDetailsGateway.GetSectionId(workId);
                hdfFlowOrderId.Value = fullLengthLiningSectionDetailsGateway.GetFlowOrderId(workId);
                hdfSectionId.Value = fullLengthLiningSectionDetailsGateway.GetSectionId(workId);
                tbxOldCwpId.Text = fullLengthLiningSectionDetailsGateway.GetOriginalSectionId(workId);
                tbxStreet.Text = fullLengthLiningSectionDetailsGateway.GetStreet(workId);
                tbxUSMH.Text = fullLengthLiningSectionDetailsGateway.GetUsmhDescription(workId);
                tbxDSMH.Text = fullLengthLiningSectionDetailsGateway.GetDsmhDescription(workId);
                tbxMapSize.Text = fullLengthLiningSectionDetailsGateway.GetMapSize(workId);
                tbxConfirmedSize.Text = fullLengthLiningSectionDetailsGateway.GetSize_(workId);
                tbxThickness.Text = fullLengthLiningSectionDetailsGateway.GetThickness(workId);
                tbxMapLength.Text = fullLengthLiningSectionDetailsGateway.GetMapLength(workId);
                tbxSteelTapeLength.Text = fullLengthLiningSectionDetailsGateway.GetLength(workId);
                tbxLaterals.Text = "0"; if (fullLengthLiningSectionDetailsGateway.GetLaterals(workId).HasValue) tbxLaterals.Text = fullLengthLiningSectionDetailsGateway.GetLaterals(workId).ToString().Trim();
                tbxLiveLaterals.Text = "0"; if (fullLengthLiningSectionDetailsGateway.GetLiveLaterals(workId).HasValue) tbxLiveLaterals.Text = fullLengthLiningSectionDetailsGateway.GetLiveLaterals(workId).ToString().Trim();

                // For m1 data
                // ... Get Depths
                tbxM1DataUsmhDepth.Text = fullLengthLiningSectionDetailsGateway.GetUsmhDepth(workId);
                tbxM1DataDsmhDepth.Text = fullLengthLiningSectionDetailsGateway.GetDsmhDepth(workId);

                // ... Get Address
                tbxM1DataUsmhAddress.Text = fullLengthLiningSectionDetailsGateway.GetUsmhAddress(workId);
                tbxM1DataDsmhAddress.Text = fullLengthLiningSectionDetailsGateway.GetDsmhAddress(workId);

                // ... Get lfs asset sewer data
                tbxM1DataSteelTapeThroughSewer.Text = fullLengthLiningSectionDetailsGateway.GetSteelTapeThroughSewer(workId);
                tbxM1DataUsmhMouth12.Text = fullLengthLiningSectionDetailsGateway.GetUsmhMouth12(workId);
                tbxM1DataUsmhMouth1.Text = fullLengthLiningSectionDetailsGateway.GetUsmhMouth1(workId);
                tbxM1DataUsmhMouth2.Text = fullLengthLiningSectionDetailsGateway.GetUsmhMouth2(workId);
                tbxM1DataUsmhMouth3.Text = fullLengthLiningSectionDetailsGateway.GetUsmhMouth3(workId);
                tbxM1DataUsmhMouth4.Text = fullLengthLiningSectionDetailsGateway.GetUsmhMouth4(workId);
                tbxM1DataUsmhMouth5.Text = fullLengthLiningSectionDetailsGateway.GetUsmhMouth5(workId);
                tbxM1DataDsmhMouth12.Text = fullLengthLiningSectionDetailsGateway.GetDsmhMouth12(workId);
                tbxM1DataDsmhMouth1.Text = fullLengthLiningSectionDetailsGateway.GetDsmhMouth1(workId);
                tbxM1DataDsmhMouth2.Text = fullLengthLiningSectionDetailsGateway.GetDsmhMouth2(workId);
                tbxM1DataDsmhMouth3.Text = fullLengthLiningSectionDetailsGateway.GetDsmhMouth3(workId);
                tbxM1DataDsmhMouth4.Text = fullLengthLiningSectionDetailsGateway.GetDsmhMouth4(workId);
                tbxM1DataDsmhMouth5.Text = fullLengthLiningSectionDetailsGateway.GetDsmhMouth5(workId);
                tbxGeneralSubArea.Text = fullLengthLiningSectionDetailsGateway.GetSubArea(workId);
            }
        }



        private void LoadWorkData(int workId, int assetId)
        {
            FullLengthLiningWorkDetailsGateway fullLengthLiningWorkDetailsGateway = new FullLengthLiningWorkDetailsGateway(fullLengthLiningTDS);
            if (fullLengthLiningWorkDetailsGateway.Table.Rows.Count > 0)
            {
                // For Header
                tbxVideoLength.Text = fullLengthLiningWorkDetailsGateway.GetVideoLength(workId);

                // Load full length lining general data
                tbxGeneralClientId.Text = fullLengthLiningWorkDetailsGateway.GetClientId(workId);
                ckbxGeneralIssueIdentified.Checked = fullLengthLiningWorkDetailsGateway.GetIssueIdentified(workId);
                ckbxGeneralLfsIssue.Checked = fullLengthLiningWorkDetailsGateway.GetIssueLFS(workId);
                ckbxGeneralClientIssue.Checked = fullLengthLiningWorkDetailsGateway.GetIssueClient(workId);
                ckbxGeneralSalesIssue.Checked = fullLengthLiningWorkDetailsGateway.GetIssueSales(workId);
                ckbxGeneralIssueGivenToClient.Checked = fullLengthLiningWorkDetailsGateway.GetIssueGivenToClient(workId);
                ckbxGeneralIssueResolved.Checked = fullLengthLiningWorkDetailsGateway.GetIssueResolved(workId);
                ckbxGeneralIssueInvestigation.Checked = fullLengthLiningWorkDetailsGateway.GetIssueInvestigation(workId);

                // ... Load Dates
                tbxGeneralProposedLiningDate.Text = "";
                if (fullLengthLiningWorkDetailsGateway.GetProposedLiningDate(workId).HasValue)
                {
                    DateTime proposedLiningDate = (DateTime)fullLengthLiningWorkDetailsGateway.GetProposedLiningDate(workId);
                    tbxGeneralProposedLiningDate.Text = proposedLiningDate.Month.ToString() + "/" + proposedLiningDate.Day.ToString() + "/" + proposedLiningDate.Year.ToString();
                }

                tbxGeneralDeadlineLiningDate.Text = "";
                if (fullLengthLiningWorkDetailsGateway.GetDeadlineLiningDate(workId).HasValue)
                {
                    DateTime deadlineLiningDate = (DateTime)fullLengthLiningWorkDetailsGateway.GetDeadlineLiningDate(workId);
                    tbxGeneralDeadlineLiningDate.Text = deadlineLiningDate.Month.ToString() + "/" + deadlineLiningDate.Day.ToString() + "/" + deadlineLiningDate.Year.ToString();
                }

                tbxGeneralP1Date.Text = "";
                tbxPrepDataP1Date.Text = "";
                if (fullLengthLiningWorkDetailsGateway.GetP1Date(workId).HasValue)
                {
                    DateTime p1Date = (DateTime)fullLengthLiningWorkDetailsGateway.GetP1Date(workId);
                    tbxGeneralP1Date.Text = p1Date.Month.ToString() + "/" + p1Date.Day.ToString() + "/" + p1Date.Year.ToString();
                    tbxPrepDataP1Date.Text = p1Date.Month.ToString() + "/" + p1Date.Day.ToString() + "/" + p1Date.Year.ToString();
                }

                tbxGeneralM1Date.Text = "";
                tbxM1DataM1Date.Text = "";
                if (fullLengthLiningWorkDetailsGateway.GetM1Date(workId).HasValue)
                {
                    DateTime m1Date = (DateTime)fullLengthLiningWorkDetailsGateway.GetM1Date(workId);
                    tbxGeneralM1Date.Text = m1Date.Month.ToString() + "/" + m1Date.Day.ToString() + "/" + m1Date.Year.ToString();
                    tbxM1DataM1Date.Text = m1Date.Month.ToString() + "/" + m1Date.Day.ToString() + "/" + m1Date.Year.ToString();
                }

                tbxGeneralM2Date.Text = "";
                tbxM2DataM2Date.Text = "";
                if (fullLengthLiningWorkDetailsGateway.GetM2Date(workId).HasValue)
                {
                    DateTime m2Date = (DateTime)fullLengthLiningWorkDetailsGateway.GetM2Date(workId);
                    tbxGeneralM2Date.Text = m2Date.Month.ToString() + "/" + m2Date.Day.ToString() + "/" + m2Date.Year.ToString();
                    tbxM2DataM2Date.Text = m2Date.Month.ToString() + "/" + m2Date.Day.ToString() + "/" + m2Date.Year.ToString();
                }

                tbxGeneralInstallDate.Text = "";
                tbxInstallDataInstallDate.Text = "";
                if (fullLengthLiningWorkDetailsGateway.GetInstallDate(workId).HasValue)
                {
                    DateTime installDate = (DateTime)fullLengthLiningWorkDetailsGateway.GetInstallDate(workId);
                    tbxGeneralInstallDate.Text = installDate.Month.ToString() + "/" + installDate.Day.ToString() + "/" + installDate.Year.ToString();
                    tbxInstallDataInstallDate.Text = installDate.Month.ToString() + "/" + installDate.Day.ToString() + "/" + installDate.Year.ToString();
                }

                tbxGeneralFinalVideo.Text = "";
                tbxInstallDataFinalVideoDate.Text = "";
                if (fullLengthLiningWorkDetailsGateway.GetFinalVideoDate(workId).HasValue)
                {
                    DateTime finalVideo = (DateTime)fullLengthLiningWorkDetailsGateway.GetFinalVideoDate(workId);
                    tbxGeneralFinalVideo.Text = finalVideo.Month.ToString() + "/" + finalVideo.Day.ToString() + "/" + finalVideo.Year.ToString();
                    tbxInstallDataFinalVideoDate.Text = finalVideo.Month.ToString() + "/" + finalVideo.Day.ToString() + "/" + finalVideo.Year.ToString();
                }

                // ... for RA data
                tbxGeneralPreFlushDate.Text = "";
                if (fullLengthLiningWorkDetailsGateway.GetPreFlushDate(workId).HasValue)
                {
                    DateTime preFlushDate = (DateTime)fullLengthLiningWorkDetailsGateway.GetPreFlushDate(workId);
                    tbxGeneralPreFlushDate.Text = preFlushDate.Month.ToString() + "/" + preFlushDate.Day.ToString() + "/" + preFlushDate.Year.ToString();
                }

                tbxGeneralPreVideoDate.Text = "";
                if (fullLengthLiningWorkDetailsGateway.GetPreVideoDate(workId).HasValue)
                {
                    DateTime preVideoDate = (DateTime)fullLengthLiningWorkDetailsGateway.GetPreVideoDate(workId);
                    tbxGeneralPreVideoDate.Text = preVideoDate.Month.ToString() + "/" + preVideoDate.Day.ToString() + "/" + preVideoDate.Year.ToString();
                }

                // For FullLengthLiningP1 data
                tbxPrepDataCXIsRemoved.Text = ""; if (fullLengthLiningWorkDetailsGateway.GetCxisRemoved(workId).HasValue) tbxPrepDataCXIsRemoved.Text = fullLengthLiningWorkDetailsGateway.GetCxisRemoved(workId).ToString();
                ckbxPrepDataRoboticPrepCompleted.Checked = fullLengthLiningWorkDetailsGateway.GetRoboticPrepCompleted(workId);
                if (fullLengthLiningWorkDetailsGateway.GetRoboticPrepCompletedDate(workId).HasValue)
                {
                    DateTime prePrepDataRoboticPrepCompletedDate = (DateTime)fullLengthLiningWorkDetailsGateway.GetRoboticPrepCompletedDate(workId);
                    tbxPrepDataRoboticPrepCompletedDate.Text = prePrepDataRoboticPrepCompletedDate.Month.ToString() + "/" + prePrepDataRoboticPrepCompletedDate.Day.ToString() + "/" + prePrepDataRoboticPrepCompletedDate.Year.ToString();
                }
                ckbxPrepDataP1Completed.Checked = fullLengthLiningWorkDetailsGateway.GetP1Completed(workId);

                // For FullLengthLiningM1 data
                // ... for material
                tbxM1DataMaterial.Text = fullLengthLiningWorkDetailsGateway.GetMaterial(workId);

                // ... form m1 data                
                tbxM1DataMeasurementsTakenBy.Text = fullLengthLiningWorkDetailsGateway.GetMeasurementTakenBy(workId);
                tbxM1DataTrafficControl.Text = fullLengthLiningWorkDetailsGateway.GetTrafficControl(workId);
                tbxM1DataSiteDetails.Text = fullLengthLiningWorkDetailsGateway.GetSiteDetails(workId);
                tbxM1DataAccessType.Text = fullLengthLiningWorkDetailsGateway.GetAccessType(workId);
                ckbxM1DataPipeSizeChange.Checked = fullLengthLiningWorkDetailsGateway.GetPipeSizeChange(workId);
                ckbxM1DataStandardBypass.Checked = fullLengthLiningWorkDetailsGateway.GetStandardBypass(workId);
                tbxM1DataStandardBypassComments.Text = fullLengthLiningWorkDetailsGateway.GetStandardBypassComments(workId);
                tbxM1DataTrafficControlDetails.Text = fullLengthLiningWorkDetailsGateway.GetTrafficControlDetails(workId);
                tbxM1DataMeasurementType.Text = fullLengthLiningWorkDetailsGateway.GetMeasurementType(workId);
                tbxM1DataMeasuredFromMH.Text = fullLengthLiningWorkDetailsGateway.GetMeasurementFromMh(workId);
                hdfMeasuredFrom.Value = fullLengthLiningWorkDetailsGateway.GetMeasurementFromMh(workId);
                tbxM1DataVideoDoneFromMH.Text = fullLengthLiningWorkDetailsGateway.GetVideoDoneFromMh(workId);
                tbxM1DataToMH.Text = fullLengthLiningWorkDetailsGateway.GetVideoDoneToMh(workId);

                // For FullLengthLiningM2 data
                tbxM2DataMeasurementsTakenBy.Text = fullLengthLiningWorkDetailsGateway.GetMeasurementTakenByM2(workId);
                ckbxM2DataDropPipe.Checked = fullLengthLiningWorkDetailsGateway.GetDropPipe(workId);
                tbxM2DataDropPipeInvertdepth.Text = fullLengthLiningWorkDetailsGateway.GetDropPipeInvertDepth(workId);
                tbxM2DataCappedLaterals.Text = ""; if (fullLengthLiningWorkDetailsGateway.GetCappedLaterals(workId).HasValue) tbxM2DataCappedLaterals.Text = fullLengthLiningWorkDetailsGateway.GetCappedLaterals(workId).ToString();
                tbxM2DataLineWidthId.Text = fullLengthLiningWorkDetailsGateway.GetLineWithId(workId);
                tbxM2DataHydrantAddress.Text = fullLengthLiningWorkDetailsGateway.GetHydrantAddress(workId);
                tbxM2DataHydroWireWitin10FtOfInversionMh.Text = fullLengthLiningWorkDetailsGateway.GetHydroWiredWithin10FtOfInversionMH(workId);
                tbxM2DataDistanceToInversionMH.Text = fullLengthLiningWorkDetailsGateway.GetDistanceToInversionMh(workId);
                tbxM2DataSurfaceGrade.Text = fullLengthLiningWorkDetailsGateway.GetSurfaceGrade(workId);
                cbxM2DataHydroPulley.Checked = fullLengthLiningWorkDetailsGateway.GetHydroPulley(workId);
                cbxM2DataFridgeCart.Checked = fullLengthLiningWorkDetailsGateway.GetFridgeCart(workId);
                cbxM2DataTwoPump.Checked = fullLengthLiningWorkDetailsGateway.GetTwoPump(workId);
                cbxM2DataSixBypass.Checked = fullLengthLiningWorkDetailsGateway.GetSixBypass(workId);
                cbxM2DataScaffolding.Checked = fullLengthLiningWorkDetailsGateway.GetScaffolding(workId);
                cbxM2DataWinchExtension.Checked = fullLengthLiningWorkDetailsGateway.GetWinchExtension(workId);
                cbxM2DataExtraGenerator.Checked = fullLengthLiningWorkDetailsGateway.GetExtraGenerator(workId);
                cbxM2DataGreyCableExtension.Checked = fullLengthLiningWorkDetailsGateway.GetGreyCableExtension(workId);
                cbxM2DataEasementMats.Checked = fullLengthLiningWorkDetailsGateway.GetEasementMats(workId);
                cbxM2DataRampsRequired.Checked = fullLengthLiningWorkDetailsGateway.GetRampRequired(workId);
                cbxM2DataCameraSkid.Checked = fullLengthLiningWorkDetailsGateway.GetCameraSkid(workId);

                // For FullLengthLiningWetOut data
                int companyId = Int32.Parse(hdfCompanyId.Value);

                // ... ... tube size = confirmed Size
                Distance confirmedSizeDistance = new Distance(tbxConfirmedSize.Text);
                double confirmedSize = 0;
                string[] confirmedSizeString = confirmedSizeDistance.ToStringInEng1().Split('\"');
                
                if (Validator.IsValidDouble(tbxConfirmedSize.Text))
                {
                    confirmedSize = double.Parse(tbxConfirmedSize.Text);
                }
                else
                {
                    if (!confirmedSizeDistance.ToStringInEng1().Contains("'"))
                    {
                        confirmedSize = double.Parse(confirmedSizeString[0]);
                    }
                    else
                    {
                        confirmedSize = Math.Ceiling(confirmedSizeDistance.ToDoubleInEng3() * 12);
                        tbxConfirmedSize.Text = confirmedSize.ToString();
                    }
                }
               

                // ... Verify if work has wet out information
                WorkFullLengthLiningWetOutGateway workFullLengthLiningWetOutGateway = new WorkFullLengthLiningWetOutGateway();
                workFullLengthLiningWetOutGateway.LoadByWorkId(workId, companyId);

                if (workFullLengthLiningWetOutGateway.Table.Rows.Count > 0)
                {
                    // ... setup data
                    tbxWetOutDataLinerTube.Text = fullLengthLiningWorkDetailsGateway.GetLinerTube(workId);
                    if (tbxWetOutDataLinerTube.Text != "")
                    {
                        ckbxWetOutDataIncludeWetOutInformation.Checked = true;
                    }
                    else 
                    {
                        ckbxWetOutDataIncludeWetOutInformation.Checked = false;
                    }

                    int resinId = fullLengthLiningWorkDetailsGateway.GetResinId(workId);
                    WorkFullLengthLiningResinsGateway workFullLengthLiningResinsGateway = new WorkFullLengthLiningResinsGateway();
                    workFullLengthLiningResinsGateway.LoadByResinId(resinId, companyId);
                    string resin = workFullLengthLiningResinsGateway.GetResinMake(resinId) + " " + workFullLengthLiningResinsGateway.GetResinType(resinId) + " " + workFullLengthLiningResinsGateway.GetResinNumber(resinId);
                    tbxWetOutDataResins.Text = resin;

                    tbxWetOutDataExcessResin.Text = fullLengthLiningWorkDetailsGateway.GetExcessResin(workId).ToString();
                    tbxWetOutDataPoundsDrums.Text = fullLengthLiningWorkDetailsGateway.GetPoundsDrums(workId);
                    tbxWetOutDataDrumDiameter.Text = fullLengthLiningWorkDetailsGateway.GetDrumDiameter(workId).ToString();
                    tbxWetOutDataHoistMaximumHeight.Text = fullLengthLiningWorkDetailsGateway.GetHoistMaximumHeight(workId).ToString();
                    tbxWetOutDataHoistMinimumHeight.Text = fullLengthLiningWorkDetailsGateway.GetHoistMinimumHeight(workId).ToString();
                    tbxWetOutDataDownDropTubeLength.Text = fullLengthLiningWorkDetailsGateway.GetDownDropTubeLenght(workId).ToString();
                    tbxWetOutDataPumpHeightAboveGround.Text = fullLengthLiningWorkDetailsGateway.GetPumpHeightAboveGround(workId).ToString();
                    tbxWetOutDataTubeResinToFeltFactor.Text = fullLengthLiningWorkDetailsGateway.GetTubeResinToFeltFactor(workId).ToString();

                    // ... wet out sheet
                    DateTime wetOutDataDateOfSheet = fullLengthLiningWorkDetailsGateway.GetDateOfSheet(workId);
                    tbxWetOutDataDateOfSheet.Text = wetOutDataDateOfSheet.Month.ToString() + "/" + wetOutDataDateOfSheet.Day.ToString() + "/" + wetOutDataDateOfSheet.Year.ToString();
                                     
                    int employeeId = fullLengthLiningWorkDetailsGateway.GetEmployeeId(workId);
                    EmployeeGateway employeeGateway = new EmployeeGateway();
                    employeeGateway.LoadByEmployeeId(employeeId);
                    tbxWetOutDataMadeBy.Text = employeeGateway.GetLastName(employeeId) + " " + employeeGateway.GetFirstName(employeeId);
                    hdfRunDetails.Value = fullLengthLiningWorkDetailsGateway.GetRunDetails(workId);                    
                    tbxWetOutDataRunDetails2.Text = fullLengthLiningWorkDetailsGateway.GetRunDetails2(workId);
                    DateTime wetOutDataWetOutDate = fullLengthLiningWorkDetailsGateway.GetWetOutDate(workId);
                    tbxWetOutDataWetOutDate.Text = wetOutDataWetOutDate.Month.ToString() + "/" + wetOutDataWetOutDate.Day.ToString() + "/" + wetOutDataWetOutDate.Year.ToString();
                                       
                    DateTime? wetOutDataInstallDate = fullLengthLiningWorkDetailsGateway.GetWetOutInstallDate(workId);
                    if (fullLengthLiningWorkDetailsGateway.GetWetOutInstallDate(workId).HasValue)
                    {
                        DateTime wetOutDataInstallDateDateTime = (DateTime)wetOutDataInstallDate;
                        tbxWetOutDataInstallDate.Text = wetOutDataInstallDateDateTime.Month.ToString() + "/" + wetOutDataInstallDateDateTime.Day.ToString() + "/" + wetOutDataInstallDateDateTime.Year.ToString();
                    }                       

                    tbxWetOutDataTubeThickness.Text = fullLengthLiningWorkDetailsGateway.GetInversionThickness(workId);
                    tbxWetOutDataLengthToLine.Text = decimal.Round(decimal.Parse(fullLengthLiningWorkDetailsGateway.GetLengthToLine(workId).ToString()), 1).ToString();
                    tbxWetOutDataPlusExtra.Text = fullLengthLiningWorkDetailsGateway.GetPlusExtra(workId).ToString();
                    tbxWetOutDataForTurnOffset.Text = fullLengthLiningWorkDetailsGateway.GetForTurnOffset(workId).ToString();
                    tbxWetOutDataLengthtToWetOut.Text = fullLengthLiningWorkDetailsGateway.GetLengthToWetOut(workId).ToString();

                    tbxWetOutDataTubeMaxColdHead.Text = fullLengthLiningWorkDetailsGateway.GetTubeMaxColdHead(workId).ToString();
                    tbxWetOutDataTubeMaxColdHeadPSI.Text = fullLengthLiningWorkDetailsGateway.GetTubeMaxColdHeadPsi(workId).ToString();
                    tbxWetOutDataTubeMaxHotHead.Text = fullLengthLiningWorkDetailsGateway.GetTubeMaxHotHead(workId).ToString();
                    tbxWetOutDataTubeMaxHotHeadPSI.Text = fullLengthLiningWorkDetailsGateway.GetTubeMaxHotHeadPsi(workId).ToString();
                    tbxWetOutDataTubeIdealHead.Text = fullLengthLiningWorkDetailsGateway.GetTubeIdealHead(workId).ToString();
                    tbxWetOutDataTubeIdealHeadPSI.Text = fullLengthLiningWorkDetailsGateway.GetTubeIdealHeadPsi(workId).ToString();

                    tbxWetOutDataNetResinForTube.Text = fullLengthLiningWorkDetailsGateway.GetNetResinForTube(workId).ToString();
                    tbxWetOutDataNetResinForTubeUsgals.Text = fullLengthLiningWorkDetailsGateway.GetNetResinForTubeUsgals(workId).ToString();
                    tbxWetOutDataNetResinForTubeDrumsIns.Text = fullLengthLiningWorkDetailsGateway.GetNetResinForTubeDrumsIns(workId);
                    tbxWetOutDataNetResinForTubeLbsFt.Text = fullLengthLiningWorkDetailsGateway.GetNetResinForTubeLbsFt(workId).ToString();
                    tbxWetOutDataNetResinForTubeUsgFt.Text = fullLengthLiningWorkDetailsGateway.GetNetResinForTubeUsgFt(workId).ToString();

                    tbxWetOutDataExtraResinForMix.Text = fullLengthLiningWorkDetailsGateway.GetExtraResinForMix(workId).ToString();
                    tbxWetOutDataExtraLbsForMix.Text = fullLengthLiningWorkDetailsGateway.GetExtraLbsForMix(workId).ToString();
                    tbxWetOutDataTotalMixQuantity.Text = fullLengthLiningWorkDetailsGateway.GetTotalMixQuantity(workId).ToString();
                    tbxWetOutDataTotalMixQuantityUsgals.Text = fullLengthLiningWorkDetailsGateway.GetTotalMixQuantityUsgals(workId).ToString();
                    tbxWetOutDataTotalMixQuantityDrumsIns.Text = fullLengthLiningWorkDetailsGateway.GetTotalMixQuantityDrumsIns(workId);

                    tbxWetOutDataInversionType.Text = fullLengthLiningWorkDetailsGateway.GetInversionType(workId);
                    tbxWetOutDataDepthOfInversionMH.Text = fullLengthLiningWorkDetailsGateway.GetDepthOfInversionMH(workId).ToString();
                    tbxWetOutDataTubeForColumn.Text = fullLengthLiningWorkDetailsGateway.GetTubeForColumn(workId).ToString();
                    tbxWetOutDataTubeForStartDry.Text = fullLengthLiningWorkDetailsGateway.GetTubeForStartDry(workId).ToString();
                    tbxWetOutDataTotalTube.Text = fullLengthLiningWorkDetailsGateway.GetTotalTube(workId).ToString();
                    tbxWetOutDataDropTubeConnects.Text = fullLengthLiningWorkDetailsGateway.GetDropTubeConnects(workId);
                    tbxWetOutDataAllowsHeadTo.Text = fullLengthLiningWorkDetailsGateway.GetAllowsHeadTo(workId).ToString();
                    tbxWetOutDataRollerGap.Text = fullLengthLiningWorkDetailsGateway.GetRollerGap(workId).ToString();

                    tbxWetOutDataHeightNeeded.Text = fullLengthLiningWorkDetailsGateway.GetHeightNeeded(workId).ToString();
                    tbxWetOutDataAvailable.Text = fullLengthLiningWorkDetailsGateway.GetAvailable(workId);
                    tbxWetOutDataHoistHeight.Text = fullLengthLiningWorkDetailsGateway.GetHoistHeight(workId);
                    tbxWetOutDataNotes.Text = fullLengthLiningWorkDetailsGateway.GetCommentsCipp(workId);

                    lblWetOutDataResinGray.Text = fullLengthLiningWorkDetailsGateway.GetResinsLabel(workId);
                    lblWetOutDataDrumContainsGray.Text = fullLengthLiningWorkDetailsGateway.GetDrumContainsLabel(workId);
                    lblWetOutDataLinerTubeGray.Text = fullLengthLiningWorkDetailsGateway.GetLinerTubeLabel(workId);
                    lblWetOutDataLbDrumsGrey.Text = fullLengthLiningWorkDetailsGateway.GetForLbDrumsLabel(workId);
                    lblWetOutDataNetResinGrey.Text = fullLengthLiningWorkDetailsGateway.GetNetResinLabel(workId);
                    lblWetOutDataCatalystGrey.Text = fullLengthLiningWorkDetailsGateway.GetCatalystLabel(workId);

                    // ... ... graphic labels
                    lblWetOutDataDimensionLabel.Text = confirmedSize + " ins x " + tbxWetOutDataTubeThickness.Text + " mm Tube";
                    lblWetOutDataTotalTubeLengthlabel.Text = "Total Tube Length " + tbxWetOutDataTotalTube.Text + " ft";
                    lblWetOutDataForColumnLabel.Text = tbxWetOutDataTubeForColumn.Text + " ft  for Column";
                    lblWetOutDataDryFtLabel.Text = "Dry " + tbxWetOutDataTubeForStartDry.Text + " ft";
                    lblWetOutDataWetOutLengthlabel.Text = "Wet-Out Length " + tbxWetOutDataLengthtToWetOut.Text + " ft";
                    lblWetOutDataDryFtEndLabel.Text = "Dry " + tbxWetOutDataTubeForColumn.Text + " ft";
                    lblWetOutDataTailEndlabel.Text = "Tail End";
                    lblWetOutDataColumnEndlabel.Text = "Column End";
                    lblWetOutDataRollerGapLabel.Text = "Roller Gap " + tbxWetOutDataRollerGap.Text + " mm";
                }                

                // ... Verify if work has inversion information
                WorkFullLengthLiningInversionGateway workFullLengthLiningInversionGateway = new WorkFullLengthLiningInversionGateway();
                workFullLengthLiningInversionGateway.LoadByWorkId(workId, companyId);

                // ... Verify if work has inversion information
                if (workFullLengthLiningInversionGateway.Table.Rows.Count > 0)
                { 
                    // ... inversion data
                    lblInversionDataSubtitle.Text = "For:" + fullLengthLiningWorkDetailsGateway.GetLinerTube(workId);

                    DateTime inversionDataDateOfSheet = fullLengthLiningWorkDetailsGateway.GetDateOfSheet(workId);
                    tbxInversionDataDateOfSheet.Text = inversionDataDateOfSheet.Month.ToString() + "/" + inversionDataDateOfSheet.Day.ToString() + "/" + inversionDataDateOfSheet.Year.ToString();
                    
                    tbxInversionDataMadeBy.Text = tbxWetOutDataMadeBy.Text;

                    DateTime? inversionDataInstalledOn = fullLengthLiningWorkDetailsGateway.GetWetOutInstallDate(workId);
                    if (fullLengthLiningWorkDetailsGateway.GetWetOutInstallDate(workId).HasValue)
                    {
                        DateTime inversionDataInstalledOnDateTime = (DateTime)inversionDataInstalledOn;
                        tbxWetOutDataInstallDate.Text = inversionDataInstalledOnDateTime.Month.ToString() + "/" + inversionDataInstalledOnDateTime.Day.ToString() + "/" + inversionDataInstalledOnDateTime.Year.ToString();
                    }
   
                    tbxInversionDataRunDetails2.Text = fullLengthLiningWorkDetailsGateway.GetRunDetails2(workId);
                    tbxInversionDataCommentsEdit.Text = fullLengthLiningWorkDetailsGateway.GetInversionComment(workId);
                    tbxInversionDataLinerSize.Text = confirmedSize.ToString() + " ins x" + fullLengthLiningWorkDetailsGateway.GetInversionThickness(workId);
                    tbxInversionDataRunLength.Text = decimal.Round(decimal.Parse(fullLengthLiningWorkDetailsGateway.GetLengthToLine(workId).ToString()), 1).ToString() ;
                    tbxInversionDataWetOutLenght.Text = fullLengthLiningWorkDetailsGateway.GetLengthToWetOut(workId).ToString();

                    tbxInversionDataPipeType.Text = fullLengthLiningWorkDetailsGateway.GetPipeType(workId);
                    if (tbxInversionDataPipeType.Text != "")
                    {
                        ckbxInversionDataIncludeInversionInformation.Checked = true;
                    }
                    else
                    {
                        ckbxInversionDataIncludeInversionInformation.Checked = false;
                    }

                    tbxInversionDataPipeCondition.Text = fullLengthLiningWorkDetailsGateway.GetPipeCondition(workId);
                    tbxInversionDataGroundMoisture.Text = fullLengthLiningWorkDetailsGateway.GetGroundMoisture(workId);
                    tbxInversionDataBoilerSize.Text = fullLengthLiningWorkDetailsGateway.GetBoilerSize(workId).ToString();
                    tbxInversionDataPumpsTotalCapacity.Text = fullLengthLiningWorkDetailsGateway.GetPumpTotalCapacity(workId).ToString();
                    tbxInversionDataLayflatSize.Text = fullLengthLiningWorkDetailsGateway.GetLayFlatSize(workId).ToString();
                    tbxInversionDataLayflatQuantityTotal.Text = fullLengthLiningWorkDetailsGateway.GetLayFlatQuantityTotal(workId).ToString();

                    tbxInversionDataWaterStartTempTs.Text = fullLengthLiningWorkDetailsGateway.GetWaterStartTemp(workId).ToString();
                    tbxInversionDataTempT1.Text = fullLengthLiningWorkDetailsGateway.GetTemp1(workId).ToString();
                    tbxInversionDataHoldAtT1For.Text = fullLengthLiningWorkDetailsGateway.GetHoldAtT1(workId).ToString();
                    tbxInversionDataTempT2.Text = fullLengthLiningWorkDetailsGateway.GetTempT2(workId).ToString();
                    tbxInversionDataCookAtT2For.Text = fullLengthLiningWorkDetailsGateway.GetCookAtT2(workId).ToString();
                    tbxInversionDataCoolDownFor.Text = fullLengthLiningWorkDetailsGateway.GetCoolDownFor(workId).ToString();

                    tbxInversionDataCoolToTemp.Text = fullLengthLiningWorkDetailsGateway.GetCoolToTemp(workId).ToString();
                    tbxInversionDataDropInPipeRun.Text = fullLengthLiningWorkDetailsGateway.GetDropInPipeRun(workId).ToString();
                    tbxInversionDataPipeSlopeOf.Text = fullLengthLiningWorkDetailsGateway.GetPipeSlopOf(workId).ToString();

                    lblInversionData45F120F.Text = tbxInversionDataWaterStartTempTs.Text + "°F-" + tbxInversionDataTempT1.Text + "°F (hr)";
                    tbxInversionData45F120F.Text = fullLengthLiningWorkDetailsGateway.GetF45F120(workId).ToString();
                    tbxInversionDataHold.Text = fullLengthLiningWorkDetailsGateway.GetHold(workId).ToString();
                    lblInversionData120F185F.Text = tbxInversionDataTempT1.Text + "°F-" + tbxInversionDataTempT2.Text + "°F (hr)"; 
                    tbxInversionData120F185F.Text = fullLengthLiningWorkDetailsGateway.GetF120F185(workId).ToString();
                    tbxInversionDataCookTime.Text = fullLengthLiningWorkDetailsGateway.GetCookTime(workId).ToString();
                    tbxInversionDataCoolTime.Text = fullLengthLiningWorkDetailsGateway.GetCoolTime(workId).ToString();
                    tbxInversionDataAproxTotal.Text = fullLengthLiningWorkDetailsGateway.GetAproxTotal(workId).ToString();

                    tbxInversionDataWaterChangesPerHour.Text = fullLengthLiningWorkDetailsGateway.GetWaterChangesPerHour(workId).ToString();
                    tbxInversionDataReturnWaterVelocity.Text = fullLengthLiningWorkDetailsGateway.GetReturnWaterVelocity(workId).ToString();
                    tbxInversionDataLayflatBackPressure.Text = fullLengthLiningWorkDetailsGateway.GetLayflatBackPressure(workId).ToString();
                    tbxInversionDataPumpLiftAtIdealHead.Text = fullLengthLiningWorkDetailsGateway.GetPumpLiftAtIdealHead(workId).ToString();
                    tbxInversionDataWaterToFillLinerColumn.Text = fullLengthLiningWorkDetailsGateway.GetWaterToFillLinerColumn(workId).ToString();
                    tbxInversionDataWaterPerFit.Text = fullLengthLiningWorkDetailsGateway.GetWaterPerFit(workId).ToString();

                    tbxInversionDataNotesAndInstallationResults.Text = fullLengthLiningWorkDetailsGateway.GetInstallationResults(workId);

                    FlInversionFieldCureRecord FlInversionFieldCureRecordForSummary = new FlInversionFieldCureRecord();
                    FlInversionFieldCureRecordForSummary.Load(workId, companyId);
                    if (FlInversionFieldCureRecordForSummary.Table.Rows.Count > 0)
                    {
                        lblInversionDataFieldCureRecordSummary.Text = FlInversionFieldCureRecordForSummary.GetSummary();
                    }

                    // ... ... graphic labels
                    lblInversionDataMaxColdForTubeLabel.Text = tbxWetOutDataTubeMaxColdHead.Text + " ft = Max Cold for tube";
                    lblInversionDataMaxHotForTubeLabel.Text = tbxWetOutDataTubeMaxHotHead.Text + " ft = Max Hot for tube";
                    lblInversionDataIdelForTubeLabel.Text = tbxWetOutDataTubeIdealHead.Text + " ft = Ideal for tube";

                    double maxColdForTubeEnd = double.Parse(tbxWetOutDataTubeMaxColdHead.Text) + double.Parse(tbxInversionDataDropInPipeRun.Text);
                    lblInversionDataMaxColdForTubeEndLabel.Text = decimal.Round(decimal.Parse(maxColdForTubeEnd.ToString()), 1).ToString() + " ft";

                    double maxHotForTubeEnd = double.Parse(tbxWetOutDataTubeMaxHotHead.Text) + double.Parse(tbxInversionDataDropInPipeRun.Text);
                    lblInversionDataMaxHotForTubeEndLabel.Text = decimal.Round(decimal.Parse(maxHotForTubeEnd.ToString()), 1).ToString() + " ft";

                    double idealForTubeEnd = double.Parse(tbxWetOutDataTubeIdealHead.Text) + double.Parse(tbxInversionDataDropInPipeRun.Text);
                    lblInversionDataIdelForTubeEndLabel.Text = decimal.Round(decimal.Parse(idealForTubeEnd.ToString()), 1).ToString() + " ft";

                    lblInversionDataPumpHeightLabel.Text = "   " + tbxWetOutDataPumpHeightAboveGround.Text + " ft";
                    lblInversionDataLinerSizeLabel.Text = confirmedSize.ToString() + " ins x" + fullLengthLiningWorkDetailsGateway.GetInversionThickness(workId) + " Liner";

                    lblInversionDataRunLengthLabel.Text = "Run Length: " + tbxInversionDataRunLength.Text + " ft; Fall: " + tbxInversionDataDropInPipeRun.Text + " ft";
                    lblInversionDataDepthOfInversionMHLabel.Text = "   " + tbxWetOutDataDepthOfInversionMH.Text + " ft";
                    lblInversionDataEndLabel.Text = "End";
                }

                // Show FLL Comments + RA Comments                          
                int flWorkId = workId;

                // ... ... Get raWorkId
                int raWorkId = 0;
                int projectId = Int32.Parse(hdfCurrentProjectId.Value);
                WorkGateway workGateway = new WorkGateway();
                workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, "Rehab Assessment", companyId);
                if (workGateway.Table.Rows.Count > 0)
                {
                    raWorkId = workGateway.GetWorkId(assetId, "Rehab Assessment", projectId);
                }

                // ... ... Get comments
                FullLengthLiningAllComments fullLengthLiningAllComments = new FullLengthLiningAllComments(fullLengthLiningTDS);
                fullLengthLiningAllComments.LoadAllByFlWorkIdRaWorkId(flWorkId, raWorkId, companyId);
                
                // ... ... Store datasets
                Session["fullLengthLiningTDS"] = fullLengthLiningTDS;

                // ... ... Show comments
                tbxCommentsDataComments.Text = fullLengthLiningAllComments.GetFLOrRAComments(companyId, fullLengthLiningAllComments.Table.Rows.Count, "\n");
            }
        }

        #endregion



        protected string GetDistance(object distance)
        {
            if (distance != DBNull.Value)
            {
                Distance distanceInch = new Distance(distance.ToString());
                return distanceInch.ToStringInEng1(); 
            }
            else
            {
                return "";
            }
        }



        protected string GetRound(object value, int decimals)
        {
            if (value != DBNull.Value)
            {
                if (decimals == 3)
                {
                    return string.Format("{0:0.000}", Convert.ToDecimal(value));
                }
                else
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
            }
            else
            {
                return "";
            }
        }


    }
}
