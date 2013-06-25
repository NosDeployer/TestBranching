using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.BL.CWP.ManholeRehabilitation;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.DA.CWP.ManholeRehabilitation;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.Tools;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.ManholeRehabilitation
{
    /// <summary>
    /// mr_summary
    /// </summar
    public partial class mr_summary : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ManholeRehabilitationTDS manholeRehabilitationTDS;






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
                if (!(Convert.ToBoolean(Session["sgLFS_CWP_MANHOLEREHABILITATION_VIEW"]) && Convert.ToBoolean(Session["sgLFS_CWP_MANHOLEREHABILITATION_EDIT"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["asset_id"] == null) || ((string)Request.QueryString["active_tab"] == null) || ((string)Request.QueryString["in_project"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in mr_summary.aspx");
                }

                // Tag Page
                TagPage();

                // If comming from 
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());
                int assetId = Int32.Parse(hdfAssetId.Value.Trim());
                string workType = hdfWorkType.Value;
                int workId = Int32.Parse(hdfWorkId.Value);

                // ... mr_navigator2.aspx
                if (Request.QueryString["source_page"] == "mr_navigator2.aspx")
                {
                    StoreNavigatorState();
                    ViewState["update"] = "no";

                    // Set initial tab
                    if ((string)Session["dialogOpenedMr"] != "1")
                    {
                        hdfActiveTab.Value = Request.QueryString["active_tab"];

                        manholeRehabilitationTDS = new ManholeRehabilitationTDS();
                        
                        ManholeRehabilitationManholeDetails manholeRehabilitationManholeDetails = new ManholeRehabilitationManholeDetails(manholeRehabilitationTDS);
                        manholeRehabilitationManholeDetails.LoadByAssetId(assetId, companyId);

                        ManholeRehabilitationWorkDetails fullLengthLiningWorkDetails = new ManholeRehabilitationWorkDetails(manholeRehabilitationTDS);
                        fullLengthLiningWorkDetails.LoadByWorkIdAssetId(workId, assetId, companyId);
                    }
                    else
                    {
                        hdfActiveTab.Value = (string)Session["activeTabMr"];

                        // Restore datasets
                        manholeRehabilitationTDS = (ManholeRehabilitationTDS)Session["manholeRehabilitationTDS"];
                    }

                    tcMrDetails.ActiveTabIndex = Int32.Parse(hdfActiveTab.Value);

                    // Store dataset
                    Session["manholeRehabilitationTDS"] = manholeRehabilitationTDS;
                }

                // ... mr_delete.aspx or mr_edit.aspx 
                if ((Request.QueryString["source_page"] == "mr_delete.aspx") || (Request.QueryString["source_page"] == "mr_edit.aspx"))
                {
                    StoreNavigatorState();
                    ViewState["update"] = Request.QueryString["update"];

                    // Restore dataset
                    manholeRehabilitationTDS = new ManholeRehabilitationTDS();

                    ManholeRehabilitationManholeDetails manholeRehabilitationManholeDetails = new ManholeRehabilitationManholeDetails(manholeRehabilitationTDS);
                    manholeRehabilitationManholeDetails.LoadByAssetId(assetId, companyId);

                    ManholeRehabilitationWorkDetails fullLengthLiningWorkDetails = new ManholeRehabilitationWorkDetails(manholeRehabilitationTDS);
                    fullLengthLiningWorkDetails.LoadByWorkIdAssetId(workId, assetId, companyId);

                    // ... Set initial tab
                    if ((string)Session["dialogOpenedMr"] != "1")
                    {
                        hdfActiveTab.Value = Request.QueryString["active_tab"];
                    }
                    else
                    {
                        hdfActiveTab.Value = (string)Session["activeTabMr"];
                    }

                    tcMrDetails.ActiveTabIndex = Int32.Parse(hdfActiveTab.Value);
                }

                // Prepare initial data
                if ((hdfCurrentClientId.Value != "0") && (hdfCurrentProjectId.Value != "0"))
                {
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
                    lblTitleProjectName.Text = " > Project: " + name + " (" + projectGateway.GetProjectNumber(currentProjectId) + ") ";
                }
                else
                {
                    lblTitleClientName.Text = "";
                    lblTitleProjectName.Text = "";
                }

                // ... Data for current full length lining work                
                LoadManholeRehabilitationData(currentProjectId, assetId, companyId);
                                
                // Databind
                Page.DataBind();
            }
            else
            {
                // Restore datasets
                manholeRehabilitationTDS = (ManholeRehabilitationTDS)Session["manholeRehabilitationTDS"];
                
                // Set initial tab
                int activeTab = Int32.Parse(hdfActiveTab.Value);
                tcMrDetails.ActiveTabIndex = activeTab;

                // Load summary for inversionfield cure record
                int companyId =Int32.Parse(hdfCompanyId.Value);
                int workId = Int32.Parse(hdfWorkId.Value);
            }
        }

        

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm6 master = (mForm6)this.Master;
            master.ActiveToolbar = "eSewers";                                  
           
            // Validate tools
            if (Convert.ToBoolean(Session["sgLFS_CWP_MANHOLEREHABILITATION_ADMIN"]))
            {
                tkrpbLeftMenuTools.Items[0].Visible = true; // Add batch
            }
            else
            {
                tkrpbLeftMenuTools.Items[0].Visible = false; // Add batch
            }

            // Visible panels
            ShapeStructure();

            // View work information
            bool inProject = bool.Parse(hdfInProject.Value);
            if (!inProject)
            {
                pnlWorkData.Visible = false;
            }
            else
            {
                pnlWorkData.Visible = true;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //
      
        protected void btnCommentsOnClick(object sender, EventArgs e)
        {
            // Store active tab for postback
            Session["activeTabMr"] = "0";
            Session["dialogOpenedMr"] = "0";

            // Open Dialog
            int assetId = Int32.Parse(hdfAssetId.Value);
            int workId = Int32.Parse(hdfWorkId.Value);
            int currentClientId = Int32.Parse(hdfCurrentClientId.Value);
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value);

            string script = "<script language='javascript'>";
            string url = "./mr_comments.aspx?source_page=mr_edit.aspx&asset_id=" + hdfAssetId.Value + "&client_id=" + hdfCurrentClientId.Value + "&work_id=" + hdfWorkId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&in_project=" + hdfInProject;
            script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=795, height=640')", url);
            script = script + "</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Comments", script, false);
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("./../Common/select_project.aspx?source_page=mr_summary.aspx&work_type=" + hdfWorkType.Value.Trim());
        }



        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            // Store active tab for postback
            Session["activeTabMr"] = "0";
            Session["dialogOpenedMr"] = "0";

            string activeTab = hdfActiveTab.Value;
            string url = "";

            switch (e.Item.Value)
            {
                case "mEdit":
                    url = "./mr_edit.aspx?source_page=mr_summary.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&asset_id=" + hdfAssetId.Value + "&in_project=" + hdfInProject.Value + "&update=" + (string)ViewState["update"] + "&active_tab=" + activeTab;
                    break;

                case "mDelete":
                    url = "./mr_delete.aspx?source_page=mr_summary.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&asset_id=" + hdfAssetId.Value + "&in_project=" + hdfInProject.Value + "&update=" + (string)ViewState["update"];
                    break;

                case "mLastSearch":
                    url = "./mr_navigator2.aspx?source_page=mr_summary.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&in_project=" + hdfInProject.Value + "&update=" + (string)ViewState["update"];
                    break;

                case "mPrevious":
                    // Get previous record
                    int previousId = MrNavigator.GetPreviousId((MrNavigatorTDS)Session["mrNavigatorTDS"], Int32.Parse(hdfAssetId.Value));
                    if (previousId != Int32.Parse(hdfAssetId.Value))
                    {
                        url = "./mr_summary.aspx?source_page=mr_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + previousId.ToString() + "&in_project=" + hdfInProject.Value + "&active_tab=" + activeTab + GetNavigatorState();
                    }
                    break;

                case "mNext":
                    // Get next record
                    int nextId = MrNavigator.GetNextId((MrNavigatorTDS)Session["mrNavigatorTDS"], Int32.Parse(hdfAssetId.Value));
                    if (nextId != Int32.Parse(hdfAssetId.Value))
                    {
                        url = "./mr_summary.aspx?source_page=mr_navigator2.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + nextId.ToString() + "&in_project=" + hdfInProject.Value + "&active_tab=" + activeTab + GetNavigatorState();
                    }
                    break;              
            }

            if (url != "") Response.Redirect(url);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
           // Store active tab for postback
            Session["activeTabMr"] = "0";
            Session["dialogOpenedMr"] = "0";

            switch (e.Item.Value)
            {
                case "mSearch":
                    string url = "./mr_navigator.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value  + "&in_project=" + hdfInProject.Value ;
                    Response.Redirect(url);
                    break;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //            

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

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./mr_summary.js");
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&columns_to_display2=" + Request.QueryString["columns_to_display2"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_ddlCondition2=" + Request.QueryString["search_ddlCondition2"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_tbxCondition2=" + Request.QueryString["search_tbxCondition2"] + "&search_ddlOperator1=" + Request.QueryString["search_ddlOperator1"] + "&search_ddlOperator2=" + Request.QueryString["search_ddlOperator2"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&btn_origin=" + Request.QueryString["btn_origin"];
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
            hdfWorkType.Value = "Manhole Rehabilitation";
            hdfAssetId.Value = Request.QueryString["asset_id"].ToString();
            hdfActiveTab.Value = Request.QueryString["active_tab"].ToString();
            hdfInProject.Value = Request.QueryString["in_project"].ToString();

            // Get ids & location
            int projectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            if (projectGateway.Table.Rows.Count > 0)
            {
                // ... Get ids
                Int64 currentCountry = projectGateway.GetCountryID(projectId);
                Int64? currentProvince = null; if (projectGateway.GetProvinceID(projectId).HasValue) currentProvince = (Int64)projectGateway.GetProvinceID(projectId);
                Int64? currentCounty = null; if (projectGateway.GetCountyID(projectId).HasValue) currentCounty = (Int64)projectGateway.GetCountyID(projectId);
                Int64? currentCity = null; if (projectGateway.GetCityID(projectId).HasValue) currentCity = (Int64)projectGateway.GetCityID(projectId);

                hdfCountryId.Value = currentCountry.ToString();
                hdfProvinceId.Value = currentProvince.ToString();
                hdfCountyId.Value = currentCounty.ToString();
                hdfCityId.Value = currentCity.ToString();
            }
            else
            {
                hdfCountryId.Value = "0";
                hdfProvinceId.Value = "0";
                hdfCountyId.Value = "0";
                hdfCityId.Value = "0";
            }

            // Get workId
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int assetId = Int32.Parse(hdfAssetId.Value);
            string workType = hdfWorkType.Value;

            WorkGateway workGateway = new WorkGateway();
            hdfWorkId.Value = "0";

            workGateway.LoadByProjectIdAssetIdWorkType(projectId, assetId, workType, companyId);

            if (workGateway.Table.Rows.Count > 0)
            {
                hdfWorkId.Value = workGateway.GetWorkId(assetId, workType, projectId).ToString();
            }
        }



        private void LoadManholeRehabilitationData(int projectId, int assetId, int companyId)
        {
            // Get WorkId
            string workType = hdfWorkType.Value.Trim();
            int workId = Int32.Parse(hdfWorkId.Value);

            // Load Data
            LoadManholeData(assetId);
            LoadWorkData(workId, assetId);
        }



        private void LoadManholeData(int assetId)
        {
            ManholeRehabilitationManholeDetailsGateway manholeRehabilitationManholeDetailsGateway = new ManholeRehabilitationManholeDetailsGateway(manholeRehabilitationTDS);

            if (manholeRehabilitationManholeDetailsGateway.Table.Rows.Count > 0)
            {
                LoadManholeGeneralDetailDate(assetId, manholeRehabilitationManholeDetailsGateway);

                LoadManholeRoundShape(assetId, manholeRehabilitationManholeDetailsGateway);

                LoadManholeRectangularShape(assetId, manholeRehabilitationManholeDetailsGateway);

                LoadManholeMixShape(assetId, manholeRehabilitationManholeDetailsGateway);

                LoadManholeOtherShape(assetId, manholeRehabilitationManholeDetailsGateway);
            }
        }



        private void LoadManholeGeneralDetailDate(int assetId, ManholeRehabilitationManholeDetailsGateway manholeRehabilitationManholeDetailsGateway)
        {
            // Load Manhole Details for header
            tbxManholeNumber.Text = manholeRehabilitationManholeDetailsGateway.GetMHID(assetId);

            tbxStreet.Text = manholeRehabilitationManholeDetailsGateway.GetAddress(assetId);
            tbxLongitude.Text = manholeRehabilitationManholeDetailsGateway.GetLongitude(assetId);
            tbxLatitude.Text = manholeRehabilitationManholeDetailsGateway.GetLatitud(assetId);
            tbxShape.Text = manholeRehabilitationManholeDetailsGateway.GetManholeShape(assetId);
            if (manholeRehabilitationManholeDetailsGateway.GetMaterialID(assetId).HasValue)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int? materialId = manholeRehabilitationManholeDetailsGateway.GetMaterialID(assetId);
                AssetSewerMHMaterialTypeGateway assetSewerMHMaterialTypeGateway = new AssetSewerMHMaterialTypeGateway();
                assetSewerMHMaterialTypeGateway.LoadByMaterialId((int)materialId, companyId);

                tbxMaterial.Text = assetSewerMHMaterialTypeGateway.GetMaterialType((int)materialId);
            }
            else
            {
                tbxMaterial.Text = "";
            }

            tbxLocation.Text = manholeRehabilitationManholeDetailsGateway.GetLocation(assetId);
            tbxConditioningRating.Text = "";
            if (manholeRehabilitationManholeDetailsGateway.GetConditionRating(assetId).HasValue)
            {
                tbxConditioningRating.Text = manholeRehabilitationManholeDetailsGateway.GetConditionRating(assetId).ToString();
            }
        }



        private void LoadManholeOtherShape(int assetId, ManholeRehabilitationManholeDetailsGateway manholeRehabilitationManholeDetailsGateway)
        {
            // ... Other shape
            tbxRehabilitationDataOtherStructure.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetTotalSurfaceArea(assetId));
        }



        private void LoadManholeMixShape(int assetId, ManholeRehabilitationManholeDetailsGateway manholeRehabilitationManholeDetailsGateway)
        {
            // ... Mix Shape
            // ... ... Top
            tbxRehabilitationDataRoundDiameter.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetTopDiameter(assetId));
            lblDataRoundDiameterLabel.Text = tbxRehabilitationDataRoundDiameter.Text;
            tbxRehabilitationDataRoundDepth.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetTopDepth(assetId));
            lblDataRoundDepthLabel.Text = tbxRehabilitationDataRoundDepth.Text;

            ckbxRehabilitationDataRoundFloor.Checked = false;
            tbxRehabilitationDataRoundFloor.Text = "";
            if (manholeRehabilitationManholeDetailsGateway.GetTopFloor(assetId) != "")
            {
                ckbxRehabilitationDataRoundFloor.Checked = true;
                tbxRehabilitationDataRoundFloor.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetTopFloor(assetId));
            }

            ckbxRehabilitationDataRoundCeiling.Checked = false;
            tbxRehabilitationDataRoundCeiling.Text = "";
            if (manholeRehabilitationManholeDetailsGateway.GetTopCeiling(assetId) != "")
            {
                ckbxRehabilitationDataRoundCeiling.Checked = true;
                tbxRehabilitationDataRoundCeiling.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetTopCeiling(assetId));
                lblDataRoundCeilingLabel.Text = tbxRehabilitationDataRoundCeiling.Text;
            }

            ckbxRehabilitationDataRoundBenching.Checked = false;
            tbxRehabilitationDataRoundBenching.Text = "";
            if (manholeRehabilitationManholeDetailsGateway.GetTopBenching(assetId) != "")
            {
                ckbxRehabilitationDataRoundBenching.Checked = true;
                tbxRehabilitationDataRoundBenching.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetTopBenching(assetId));
            }

            tbxRehabilitationDataRoundSurfaceArea.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetTopSurfaceArea(assetId));
            lblDataRoundSurfaceAreaLabel.Text = tbxRehabilitationDataRoundSurfaceArea.Text;

            // Recalculate Top total surface area  
            decimal roundSurfaceArea = GetValueValidForCalculations(tbxRehabilitationDataRoundSurfaceArea.Text);
            decimal roundFloor = GetValueValidForCalculations(tbxRehabilitationDataRoundFloor.Text);
            decimal roundCeiling = GetValueValidForCalculations(tbxRehabilitationDataRoundCeiling.Text);
            decimal roundBenching = GetValueValidForCalculations(tbxRehabilitationDataRoundBenching.Text);

            decimal roundTotalSurfaceArea = decimal.Round(roundSurfaceArea + roundFloor + roundCeiling + roundBenching, 2);
            Distance roundTotalSurfaceAreaDistance = new Distance(roundTotalSurfaceArea.ToString());
            tbxRehabilitationDataMixedRoundTotalSurfaceArea.Text = roundTotalSurfaceAreaDistance.ToStringInEng3();

            // ... ... Down
            tbxRehabilitationDataRectangleLongSide.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetRectangle2LongSide(assetId));
            lblRectangleLongSideLabel.Text = tbxRehabilitationDataRectangleLongSide.Text;
            tbxRehabilitationDataRectangleShortSide.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetRectangle2ShortSide(assetId));
            lblRectangleShortSideLabel.Text = tbxRehabilitationDataRectangleShortSide.Text;
            tbxRehabilitationDataRectangleDepth.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetDownDepth(assetId));
            lblRectangleDepthLabel.Text = tbxRehabilitationDataRectangleDepth.Text;

            ckbxRehabilitationDataRectangleFloor.Checked = false;
            tbxRehabilitationDataRectangleFloor.Text = "";
            if (manholeRehabilitationManholeDetailsGateway.GetDownFloor(assetId) != "")
            {
                ckbxRehabilitationDataRectangleFloor.Checked = true;
                tbxRehabilitationDataRectangleFloor.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetDownFloor(assetId));
            }

            ckbxRehabilitationDataRectangleCeiling.Checked = false;
            tbxRehabilitationDataRectangleCeiling.Text = "";
            if (manholeRehabilitationManholeDetailsGateway.GetDownCeiling(assetId) != "")
            {
                ckbxRehabilitationDataRectangleCeiling.Checked = true;
                tbxRehabilitationDataRectangleCeiling.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetDownCeiling(assetId));
                lblRectangleCeilingLabel.Text = tbxRehabilitationDataRectangleCeiling.Text;
            }

            ckbxRehabilitationDataBenching.Checked = false;
            tbxRehabilitationDataBenching.Text = "";
            if (manholeRehabilitationManholeDetailsGateway.GetDownBenching(assetId) != "")
            {
                ckbxRehabilitationDataBenching.Checked = true;
                tbxRehabilitationDataBenching.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetDownBenching(assetId));
            }

            tbxRehabilitationDataRectangularSufaceArea.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetDownSurfaceArea(assetId));
            lblRectangleSurfaceAreaLabel.Text = tbxRehabilitationDataRectangularSufaceArea.Text;

            // Recalculate Top total surface area  
            decimal mixesRectangleSurfaceArea = GetValueValidForCalculations(tbxRehabilitationDataRectangularSufaceArea.Text);
            decimal mixesRectangleFloor = GetValueValidForCalculations(tbxRehabilitationDataRectangleFloor.Text);
            decimal mixesRectangleCeiling = GetValueValidForCalculations(tbxRehabilitationDataRectangleCeiling.Text);
            decimal mixesRectangleBenching = GetValueValidForCalculations(tbxRehabilitationDataBenching.Text);

            decimal mixesRectangleTotalSurfaceArea = decimal.Round(mixesRectangleSurfaceArea + mixesRectangleFloor + mixesRectangleCeiling + mixesRectangleBenching, 2);
            Distance mixesRectangleTotalSurfaceAreaDistance = new Distance(mixesRectangleTotalSurfaceArea.ToString());
            tbxRehabilitationDataMixedRectangleTotalSurfaceArea.Text = mixesRectangleTotalSurfaceAreaDistance.ToStringInEng3();

            tbxRehabilitationDataManholeRugs.Text = manholeRehabilitationManholeDetailsGateway.GetManholeRugs(assetId).ToString();

            // ... ... Totals
            tbxRehabilitationDataTotalDepth.Text = GetValueValidForCalculationsInStringWithoutDecimals(manholeRehabilitationManholeDetailsGateway.GetTotalDepth(assetId));
            lblMixedTotalDepthLabel.Text = tbxRehabilitationDataTotalDepth.Text;
            tbxRehabilitationDataTotalSurfaceArea.Text = GetValueValidForCalculationsInStringWithoutDecimals(manholeRehabilitationManholeDetailsGateway.GetTotalSurfaceArea(assetId));
            lblTotalMixedSurfaceAreaLabel.Text = tbxRehabilitationDataTotalSurfaceArea.Text;
        }

        

        private void LoadManholeRectangularShape(int assetId, ManholeRehabilitationManholeDetailsGateway manholeRehabilitationManholeDetailsGateway)
        {
            // ... Rectangular Shape
            // ... ... Rectangular 1
            tbxRehabilitationDataRectangle1LongSide.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetRectangle1LongSide(assetId));
            lblRectangular1LongSideLabel.Text = tbxRehabilitationDataRectangle1LongSide.Text;
            tbxRehabilitationDataRectangle1ShortSide.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetRectangle1ShortSide(assetId));
            lblRectangular1ShortSideLabel.Text = tbxRehabilitationDataRectangle1ShortSide.Text;
            tbxRehabilitationDataRectangle1Depth.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetTopDepth(assetId));
            lblRectangular1DephtLabel.Text = tbxRehabilitationDataRectangle1Depth.Text;

            ckbxRehabilitationDataRectangle1Floor.Checked = false;
            tbxRehabilitationDataRectangle1Floor.Text = "";
            if (manholeRehabilitationManholeDetailsGateway.GetTopFloor(assetId) != "")
            {
                ckbxRehabilitationDataRectangle1Floor.Checked = true;
                tbxRehabilitationDataRectangle1Floor.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetTopFloor(assetId));
            }

            ckbxRehabilitationDataRectangle1Ceiling.Checked = false;
            tbxRehabilitationDataRectangle1Ceiling.Text = "";
            if (manholeRehabilitationManholeDetailsGateway.GetTopCeiling(assetId) != "")
            {
                ckbxRehabilitationDataRectangle1Ceiling.Checked = true;
                tbxRehabilitationDataRectangle1Ceiling.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetTopCeiling(assetId));
                lblRectangular1CeilingLabel.Text = tbxRehabilitationDataRectangle1Ceiling.Text;
            }

            ckbxRehabilitationDataRectangle1Benching.Checked = false;
            tbxRehabilitationDataRectangle1Benching.Text = "";
            if (manholeRehabilitationManholeDetailsGateway.GetTopBenching(assetId) != "")
            {
                ckbxRehabilitationDataRectangle1Benching.Checked = true;
                tbxRehabilitationDataRectangle1Benching.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetTopBenching(assetId));
            }

            tbxRehabilitationDataRectangle1SurfaceArea.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetTopSurfaceArea(assetId));
            lblRectangle1SurfaceAreaLabel.Text = tbxRehabilitationDataRectangle1SurfaceArea.Text;

            // Recalculate rectangle 1 total surface area  
            decimal rectangle1SurfaceArea = GetValueValidForCalculations(tbxRehabilitationDataRectangle1SurfaceArea.Text);
            decimal rectangle1Floor = GetValueValidForCalculations(tbxRehabilitationDataRectangle1Floor.Text);
            decimal rectangle1Ceiling = GetValueValidForCalculations(tbxRehabilitationDataRectangle1Ceiling.Text);
            decimal rectangle1Benching = GetValueValidForCalculations(tbxRehabilitationDataRectangle1Benching.Text);

            decimal rectangle1TotalSurfaceArea = decimal.Round(rectangle1SurfaceArea + rectangle1Floor + rectangle1Ceiling + rectangle1Benching, 2);
            Distance rectangle1TotalSurfaceAreaDistance = new Distance(rectangle1TotalSurfaceArea.ToString());
            tbxRehabilitationDataRectangle1TotalSurfaceArea.Text = rectangle1TotalSurfaceAreaDistance.ToStringInEng3();

            // ... ... Rectangular 2
            tbxRehabilitationDataRectangle2LongSide.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetRectangle2LongSide(assetId));
            lblRectangle2LongSideLabel.Text = tbxRehabilitationDataRectangle2LongSide.Text;
            tbxRehabilitationDataRectangle2ShortSide.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetRectangle2ShortSide(assetId));
            lblRectangular2ShortSideLabel.Text = tbxRehabilitationDataRectangle2ShortSide.Text;
            tbxRehabilitationDataRectangle2Depth.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetDownDepth(assetId));
            lblRectangular2Depth.Text = tbxRehabilitationDataRectangle2Depth.Text;

            ckbxRehabilitationDataRectangle2Floor.Checked = false;
            tbxRehabilitationDataRectangle2Floor.Text = "";
            if (manholeRehabilitationManholeDetailsGateway.GetDownFloor(assetId) != "")
            {
                ckbxRehabilitationDataRectangle2Floor.Checked = true;
                tbxRehabilitationDataRectangle2Floor.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetDownFloor(assetId));
            }

            ckbxRehabilitationDataRectangle2Ceiling.Checked = false;
            tbxRehabilitationDataRectangle2Ceiling.Text = "";
            if (manholeRehabilitationManholeDetailsGateway.GetDownCeiling(assetId) != "")
            {
                ckbxRehabilitationDataRectangle2Ceiling.Checked = true;
                tbxRehabilitationDataRectangle2Ceiling.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetDownCeiling(assetId));
                lblRectangular2CeilingLabel.Text = tbxRehabilitationDataRectangle2Ceiling.Text;
            }

            ckbxRehabilitationDataRectangle2Benching.Checked = false;
            tbxRehabilitationDataRectangle2Benching.Text = "";
            if (manholeRehabilitationManholeDetailsGateway.GetDownBenching(assetId) != "")
            {
                ckbxRehabilitationDataRectangle2Benching.Checked = true;
                tbxRehabilitationDataRectangle2Benching.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetDownBenching(assetId));
            }

            tbxRehabilitationDataRectangle2SurfaceArea.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetDownSurfaceArea(assetId));
            lblRectangle2SurfaceAreaLabel.Text = tbxRehabilitationDataRectangle2SurfaceArea.Text;

            // Recalculate rectangle 2 total surface area  
            decimal rectangle2SurfaceArea = GetValueValidForCalculations(tbxRehabilitationDataRectangle2SurfaceArea.Text);
            decimal rectangle2Floor = GetValueValidForCalculations(tbxRehabilitationDataRectangle2Floor.Text);
            decimal rectangle2Ceiling = GetValueValidForCalculations(tbxRehabilitationDataRectangle2Ceiling.Text);
            decimal rectangle2Benching = GetValueValidForCalculations(tbxRehabilitationDataRectangle2Benching.Text);

            decimal rectangle2TotalSurfaceArea = decimal.Round(rectangle2SurfaceArea + rectangle2Floor + rectangle2Ceiling + rectangle2Benching, 2);
            Distance rectangle2TotalSurfaceAreaDistance = new Distance(rectangle2TotalSurfaceArea.ToString());
            tbxRehabilitationDataRectangle2TotalSurfaceArea.Text = rectangle2TotalSurfaceAreaDistance.ToStringInEng3();

            tbxRehabilitationDataRectangularManholeRugs.Text = manholeRehabilitationManholeDetailsGateway.GetManholeRugs(assetId).ToString();

            // ... ... Totals
            tbxRehabilitationDataRectangularTotalDepth.Text = GetValueValidForCalculationsInStringWithoutDecimals(manholeRehabilitationManholeDetailsGateway.GetTotalDepth(assetId));
            lblRectangularTotalDepthLabel.Text = tbxRehabilitationDataRectangularTotalDepth.Text;
            tbxRehabilitationDataRectangularTotalSurfaceArea.Text = GetValueValidForCalculationsInStringWithoutDecimals(manholeRehabilitationManholeDetailsGateway.GetTotalSurfaceArea(assetId));
            lblRectangularTotalSurfaceAreaLabel.Text = tbxRehabilitationDataRectangularTotalSurfaceArea.Text;
        }



        private void LoadManholeRoundShape(int assetId, ManholeRehabilitationManholeDetailsGateway manholeRehabilitationManholeDetailsGateway)
        {
            // Load manhole structure information                
            // ... Round shape
            // ... ... Chimney
            tbxRehabilitationDataChimneyDiameter.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetTopDiameter(assetId));
            lblRoudChimneyDiameterLabel.Text = tbxRehabilitationDataChimneyDiameter.Text;
            tbxRehabilitationDataChimneyDepth.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetTopDepth(assetId));
            lblRoudChimneyDepthLabel.Text = tbxRehabilitationDataChimneyDepth.Text;

            ckbxRehabilitationDataChimneyFloor.Checked = false;
            tbxRehabilitationDataChimneyFloor.Text = "";
            if (manholeRehabilitationManholeDetailsGateway.GetTopFloor(assetId) != "")
            {
                ckbxRehabilitationDataChimneyFloor.Checked = true;
                tbxRehabilitationDataChimneyFloor.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetTopFloor(assetId));
            }

            ckbxRehabilitationDataChimneyCeiling.Checked = false;
            tbxRehabilitationDataChimneyCeiling.Text = "";
            if (manholeRehabilitationManholeDetailsGateway.GetTopCeiling(assetId) != "")
            {
                ckbxRehabilitationDataChimneyCeiling.Checked = true;
                tbxRehabilitationDataChimneyCeiling.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetTopCeiling(assetId));
                lblRoudChimneyCeilingLabel.Text = tbxRehabilitationDataChimneyCeiling.Text;
            }

            ckbxRehabilitationDataChimneyBenching.Checked = false;
            tbxRehabilitationDataChimneyBenching.Text = "";
            if (manholeRehabilitationManholeDetailsGateway.GetTopBenching(assetId) != "")
            {
                ckbxRehabilitationDataChimneyBenching.Checked = true;
                tbxRehabilitationDataChimneyBenching.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetTopBenching(assetId));
            }

            ckbxRehabilitationDataChimneySurfaceArea.Checked = false;
            tbxRehabilitationDataChimneySurfaceArea.Text = "";
            if (manholeRehabilitationManholeDetailsGateway.GetTopSurfaceArea(assetId) != "")
            {
                ckbxRehabilitationDataChimneySurfaceArea.Checked = true;
                tbxRehabilitationDataChimneySurfaceArea.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetTopSurfaceArea(assetId));
                lblRoundChimneySurfaceAreaLabel.Text = tbxRehabilitationDataChimneySurfaceArea.Text;
            }

            // Recalculate Top total surface area  
            decimal chimneySurfaceArea = GetValueValidForCalculations(tbxRehabilitationDataChimneySurfaceArea.Text);
            decimal chimneyFloor = GetValueValidForCalculations(tbxRehabilitationDataChimneyFloor.Text);
            decimal chimneyCeiling = GetValueValidForCalculations(tbxRehabilitationDataChimneyCeiling.Text);
            decimal chimneyBenching = GetValueValidForCalculations(tbxRehabilitationDataChimneyBenching.Text);

            decimal chimneyTotalSurfaceArea = decimal.Round(chimneySurfaceArea + chimneyFloor + chimneyCeiling + chimneyBenching, 2);
            Distance chimneyTotalSurfaceAreaDistance = new Distance(chimneyTotalSurfaceArea.ToString());
            tbxRehabilitationDataChimneyTotalSurfaceArea.Text = chimneyTotalSurfaceAreaDistance.ToStringInEng3();

            // ... ... Barrel
            tbxRehabilitationDataBarrelDiameter.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetDownDiameter(assetId));
            lblRoudBarrelDiameterLabel.Text = tbxRehabilitationDataBarrelDiameter.Text;
            tbxRehabilitationDataBarrelDepth.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetDownDepth(assetId));
            lblRoudBarrelDepthLabel.Text = tbxRehabilitationDataBarrelDepth.Text;

            ckbxRehabilitationDataBarrelFloor.Checked = false;
            tbxRehabilitationDataBarrelFloor.Text = "";
            if (manholeRehabilitationManholeDetailsGateway.GetDownFloor(assetId) != "")
            {
                ckbxRehabilitationDataBarrelFloor.Checked = true;
                tbxRehabilitationDataBarrelFloor.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetDownFloor(assetId));
            }

            ckbxRehabilitationDataBarrelCeiling.Checked = false;
            tbxRehabilitationDataBarrelCeiling.Text = "";
            if (manholeRehabilitationManholeDetailsGateway.GetDownCeiling(assetId) != "")
            {
                ckbxRehabilitationDataBarrelCeiling.Checked = true;
                tbxRehabilitationDataBarrelCeiling.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetDownCeiling(assetId));
                lblRoundBarrelCeilingLabel.Text = tbxRehabilitationDataBarrelCeiling.Text;
            }

            ckbxRehabilitationDataBarrelBenching.Checked = false;
            tbxRehabilitationDataBarrelBenching.Text = "";
            if (manholeRehabilitationManholeDetailsGateway.GetDownBenching(assetId) != "")
            {
                ckbxRehabilitationDataBarrelBenching.Checked = true;
                tbxRehabilitationDataBarrelBenching.Text = GetValueValidForCalculationsInString(manholeRehabilitationManholeDetailsGateway.GetDownBenching(assetId));
            }

            tbxRehabilitationDataBarrelSurfaceArea.Text = manholeRehabilitationManholeDetailsGateway.GetDownSurfaceArea(assetId);
            lblRoundBarrelSurfaceAreaLabel.Text = tbxRehabilitationDataBarrelSurfaceArea.Text;

            // Recalculate Top total surface area  
            decimal barrelSurfaceArea = GetValueValidForCalculations(tbxRehabilitationDataBarrelSurfaceArea.Text);
            decimal barrelFloor = GetValueValidForCalculations(tbxRehabilitationDataBarrelFloor.Text);
            decimal barrelCeiling = GetValueValidForCalculations(tbxRehabilitationDataBarrelCeiling.Text);
            decimal barrelBenching = GetValueValidForCalculations(tbxRehabilitationDataBarrelBenching.Text);

            decimal barrelTotalSurfaceArea = decimal.Round(barrelSurfaceArea + barrelFloor + barrelCeiling + barrelBenching, 2);
            Distance barrelTotalSurfaceAreaDistance = new Distance(barrelTotalSurfaceArea.ToString());
            tbxRehabilitationDataBarrelTotalSurfaceArea.Text = barrelTotalSurfaceAreaDistance.ToStringInEng3();

            tbxRehabilitationDataBarrelManholeRugs.Text = manholeRehabilitationManholeDetailsGateway.GetManholeRugs(assetId).ToString();

            // ... ... Totals
            tbxRehabilitationDataRoundTotalDepth.Text = GetValueValidForCalculationsInStringWithoutDecimals(manholeRehabilitationManholeDetailsGateway.GetTotalDepth(assetId));
            lblRoundTotalDepthLabel.Text = tbxRehabilitationDataRoundTotalDepth.Text;
            tbxRehabilitationDataRoundTotalSurfaceArea.Text = GetValueValidForCalculationsInStringWithoutDecimals(manholeRehabilitationManholeDetailsGateway.GetTotalSurfaceArea(assetId));
            lblRoundTotalSurfaceArea.Text = tbxRehabilitationDataRoundTotalSurfaceArea.Text;
        }



        private void LoadWorkData(int workId, int assetId)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);

            if (workId != 0)
            {
                ManholeRehabilitationWorkDetailsGateway manholeRehabilitationWorkDetailsGateway = new ManholeRehabilitationWorkDetailsGateway(manholeRehabilitationTDS);
                if (manholeRehabilitationWorkDetailsGateway.Table.Rows.Count > 0)
                {
                    tbxRehabilitationPreppedDate.Text = "";
                    if (manholeRehabilitationWorkDetailsGateway.GetPreppedDate(workId).HasValue)
                    {
                        DateTime preppedDate = (DateTime)manholeRehabilitationWorkDetailsGateway.GetPreppedDate(workId);
                        tbxRehabilitationPreppedDate.Text = preppedDate.Month.ToString() + "/" + preppedDate.Day.ToString() + "/" + preppedDate.Year.ToString();
                    }

                    tbxRehabilitationSprayedDate.Text = "";
                    if (manholeRehabilitationWorkDetailsGateway.GetSprayedDate(workId).HasValue)
                    {
                        DateTime sprayedDate = (DateTime)manholeRehabilitationWorkDetailsGateway.GetSprayedDate(workId);
                        tbxRehabilitationSprayedDate.Text = sprayedDate.Month.ToString() + "/" + sprayedDate.Day.ToString() + "/" + sprayedDate.Year.ToString();
                    }

                    tbxRehabilitationBatchDate.Text = "";
                    if (manholeRehabilitationWorkDetailsGateway.GetDate(workId).HasValue)
                    {
                        try
                        {
                            DateTime batchDate = (DateTime)manholeRehabilitationWorkDetailsGateway.GetDate(workId);
                            tbxRehabilitationBatchDate.Text = batchDate.Month.ToString() + "/" + batchDate.Day.ToString() + "/" + batchDate.Year.ToString();
                            hdfBatchId.Value = manholeRehabilitationWorkDetailsGateway.GetBatchID(workId).ToString();
                        }
                        catch
                        {
                        }
                    }

                    // Show Comments                
                    tbxCommentsDataComments.Text = manholeRehabilitationWorkDetailsGateway.GetComments(workId);

                    // ... ... Store datasets
                    Session["manholeRehabilitationTDS"] = manholeRehabilitationTDS;
                }
            }
            else
            {
                // Load last batch 
                MrBatchVerificationGateway mrBatchVerificationGateway = new MrBatchVerificationGateway();
                mrBatchVerificationGateway.LoadAll(companyId);
                if (mrBatchVerificationGateway.Table.Rows.Count > 0)
                {
                    WorkManholeRehabilitationBatchGateway workManholeRehabilitationBatchGateway = new WorkManholeRehabilitationBatchGateway();
                    hdfBatchId.Value = workManholeRehabilitationBatchGateway.GetLastId(companyId).ToString();
                    int batchId = Int32.Parse(hdfBatchId.Value);

                    mrBatchVerificationGateway.LoadByBatchId(batchId, companyId);
                    DateTime batchDate = mrBatchVerificationGateway.GetDate(batchId);
                    tbxRehabilitationBatchDate.Text = batchDate.Month.ToString() + "/" + batchDate.Day.ToString() + "/" + batchDate.Year.ToString();                    

                    // ... ... Store datasets
                    Session["manholeRehabilitationTDS"] = manholeRehabilitationTDS;
                }
            }
        }



        private decimal GetValueValidForCalculations(string value)
        {
            try
            {
                Distance valueDistance = new Distance(value);
                decimal valueValid = decimal.Round(Convert.ToDecimal(valueDistance.ToStringInEng3()), 2);
                return valueValid;
            }
            catch
            {
                return 0;
            }
        }



        private string GetValueValidForCalculationsInString(string value)
        {
            string valueValid = "0.00";

            try
            {
                valueValid = decimal.Round(Convert.ToDecimal(value), 2).ToString();
                return valueValid;
            }
            catch
            {
                return value;
            }
        }



        private string GetValueValidForCalculationsInStringWithoutDecimals(string value)
        {
            string valueValid = "0";

            try
            {
                valueValid = decimal.Round(Convert.ToDecimal(value), 0).ToString();
                return valueValid;
            }
            catch
            {
                return value;
            }
        }



        private void ShapeStructure()
        {
            switch (tbxShape.Text)
            {
                case "Round":
                    pnlInformationRoundMH.Visible = true;
                    pnlInformationRectangularMH.Visible = false;
                    pnlInformationMixedMH.Visible = false;
                    pnlInformationOtherMH.Visible = false;
                    break;

                case "Rectangular":
                    pnlInformationRoundMH.Visible = false;
                    pnlInformationRectangularMH.Visible = true;
                    pnlInformationMixedMH.Visible = false;
                    pnlInformationOtherMH.Visible = false;
                    break;

                case "Mixed":
                    pnlInformationRoundMH.Visible = false;
                    pnlInformationRectangularMH.Visible = false;
                    pnlInformationMixedMH.Visible = true;
                    pnlInformationOtherMH.Visible = false;
                    break;


                case "Other":
                    pnlInformationRoundMH.Visible = false;
                    pnlInformationRectangularMH.Visible = false;
                    pnlInformationMixedMH.Visible = false;
                    pnlInformationOtherMH.Visible = true;
                    break;

                default:
                    pnlInformationRoundMH.Visible = false;
                    pnlInformationRectangularMH.Visible = false;
                    pnlInformationMixedMH.Visible = false;
                    pnlInformationOtherMH.Visible = false;
                    break;
            }
        }

        #endregion

        

    }
}