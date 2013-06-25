using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.BL.CWP.ManholeRehabilitation;
using LiquiForce.LFSLive.BL.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.ManholeRehabilitation;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.Tools;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.CWP.ManholeRehabilitation
{
    /// <summary>
    /// mr_edit
    /// </summary>
    public partial class mr_edit : System.Web.UI.Page
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

            bool isFromTabClick = false;

            if (!IsPostBack)
            {
                if (!isFromTabClick)
                {     
                    // Security check
                    if (!(Convert.ToBoolean(Session["sgLFS_CWP_MANHOLEREHABILITATION_VIEW"]) && Convert.ToBoolean(Session["sgLFS_CWP_MANHOLEREHABILITATION_EDIT"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }

                    // Validate query string
                    if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["asset_id"] == null) || ((string)Request.QueryString["active_tab"] == null) || ((string)Request.QueryString["in_project"] == null))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in mr_edit.aspx");
                    }

                    // Tag Page
                    TagPage();                                                            
                   
                    // If coming from 
                    int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                    int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());
                    int assetId = Int32.Parse(hdfAssetId.Value.Trim());
                    int workId = Int32.Parse(hdfWorkId.Value.Trim());
                    string workType = hdfWorkType.Value;
                    lblNotLastBatch.Visible = false;

                    // ... mr_navigator2.aspx
                    if (Request.QueryString["source_page"] == "mr_navigator2.aspx")
                    {
                        StoreNavigatorState();
                        ViewState["update"] = "no";

                        // ... Set initial tab
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

                        // ... Store dataset
                        Session["manholeRehabilitationTDS"] = manholeRehabilitationTDS;
                    }

                    // ... mr_summary.aspx or mr_edit.aspx
                    if ((Request.QueryString["source_page"] == "mr_summary.aspx") || (Request.QueryString["source_page"] == "mr_edit.aspx"))
                    {
                        StoreNavigatorState();
                        ViewState["update"] = Request.QueryString["update"];

                        // ... Restore dataset
                        manholeRehabilitationTDS = (ManholeRehabilitationTDS)Session["manholeRehabilitationTDS"];

                        // ... Set initial tab
                        if ((string)Session["dialogOpenedMr"] != "1")
                        {
                            hdfActiveTab.Value = Request.QueryString["active_tab"];
                        }
                        else
                        {
                            hdfActiveTab.Value = (string)Session["activeTabMr"];
                        }

                        if (ViewState["update"].ToString().Trim() == "yes")
                        {
                            ManholeRehabilitationManholeDetails manholeRehabilitationManholeDetails = new ManholeRehabilitationManholeDetails(manholeRehabilitationTDS);
                            manholeRehabilitationManholeDetails.LoadByAssetId(assetId, companyId);

                            ManholeRehabilitationWorkDetails fullLengthLiningWorkDetails = new ManholeRehabilitationWorkDetails(manholeRehabilitationTDS);
                            fullLengthLiningWorkDetails.LoadByWorkIdAssetId(workId, assetId, companyId);

                            // ... Store dataset
                            Session["manholeRehabilitationTDS"] = manholeRehabilitationTDS;
                        }
                    }

                    // Set initial data
                    int activeTab = Int32.Parse(hdfActiveTab.Value);
                    tcMrDetails.ActiveTabIndex = activeTab;
                    lblBatchDateRequired.Visible = false;

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
                        lblTitleProjectName.Text = " > Project: " + name + " (" + projectGateway.GetProjectNumber(currentProjectId) + ") > Selected Manhole";
                    }
                    else
                    {
                        lblTitleClientName.Text = "";
                        lblTitleProjectName.Text = "";
                    }
                                        
                    // ... For batch dates
                    WorkManholeRehabilitationBatchList workManholeRehabilitationBatchList = new WorkManholeRehabilitationBatchList();
                    workManholeRehabilitationBatchList.LoadAndAddItem(-1, "(Select a batch)", companyId);
                    ddlRehabilitationBatchDate.DataSource = workManholeRehabilitationBatchList.Table;
                    ddlRehabilitationBatchDate.DataValueField = "BatchID";
                    ddlRehabilitationBatchDate.DataTextField = "Description";
                    ddlRehabilitationBatchDate.DataBind();                                       

                    // ... ... Data for current manhole rehabilitation work                
                    LoadManholeRehabilitationData(currentProjectId, assetId, companyId);
                    
                    // ... ... Make panels visible
                    ShapeStructure();                    

                    // Databind
                    Page.DataBind();

                    // For usmh, dsmh autocomplete
                    string provinceId_ = "0"; if (hdfProvinceId.Value != "") provinceId_ = hdfProvinceId.Value;
                    string countyId_ = "0"; if (hdfCountyId.Value != "") countyId_ = hdfCountyId.Value;
                    string cityId_ = "0"; if (hdfCityId.Value != "") cityId_ = hdfCityId.Value;                
                }
            }
            else
            {    
                // Restore datasets
                manholeRehabilitationTDS = (ManholeRehabilitationTDS)Session["manholeRehabilitationTDS"];

                // Set initial tab
                int activeTab = Int32.Parse(hdfActiveTab.Value);
                tcMrDetails.ActiveTabIndex = activeTab;                
            }
        }

      
                 
        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm8 master = (mForm8)this.Master;
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
            Session["dialogOpenedMr"] = "1";

            if (Apply()) 
            {
                // Open Dialog
                int assetId = Int32.Parse(hdfAssetId.Value);
                int workId = Int32.Parse(hdfWorkId.Value);
                int currentClientId = Int32.Parse(hdfCurrentClientId.Value);
                int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value);

                string script = "<script language='javascript'>";
                string url = "./mr_comments.aspx?source_page=mr_edit.aspx&asset_id=" + hdfAssetId.Value + "&client_id=" + hdfCurrentClientId.Value + "&work_id=" + hdfWorkId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&in_project=" + hdfInProject.Value;
                script = script + string.Format("window.open('{0}', '_blank', 'toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=no, resizable=no, copyhistory=no, width=795, height=640')", url);
                script = script + "</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Comments", script, false);
            }
        }        



        protected void btnRoundShapeOnClick(object sender, EventArgs e)
        {
            Page.Validate("mrRoundShape");
            if (Page.IsValid)
            {
                if (ckbxRehabilitationDataImperial.Checked)
                {
                    Distance distanceRoundChimneyDiameter = new Distance(tbxRehabilitationDataChimneyDiameter.Text);
                    decimal chimneyDiameter = GetValueInEng3With2Decimals(distanceRoundChimneyDiameter.ToStringInEng3());
                    tbxRehabilitationDataChimneyDiameter.Text = chimneyDiameter.ToString();

                    Distance distanceRoundChimneyDepth = new Distance(tbxRehabilitationDataChimneyDepth.Text);
                    decimal chimneyDepth = GetValueInEng3With2Decimals(distanceRoundChimneyDepth.ToStringInEng3());
                    tbxRehabilitationDataChimneyDepth.Text = chimneyDepth.ToString();

                    Distance distanceRoundBarrelDiameter = new Distance(tbxRehabilitationDataBarrelDiameter.Text);
                    decimal barrelDiameter = GetValueInEng3With2Decimals(distanceRoundBarrelDiameter.ToStringInEng3());
                    tbxRehabilitationDataBarrelDiameter.Text = barrelDiameter.ToString();

                    Distance distanceRoundBarrelDepth = new Distance(tbxRehabilitationDataBarrelDepth.Text);
                    decimal barrelDepth = GetValueInEng3With2Decimals(distanceRoundBarrelDepth.ToStringInEng3());
                    tbxRehabilitationDataBarrelDepth.Text = barrelDepth.ToString();

                    decimal pi = Decimal.Round(decimal.Parse(Math.PI.ToString()), 4);
                    double chimneyRadius = double.Parse(distanceRoundChimneyDiameter.ToStringInEng3()) / 2;
                    decimal chimneyRadiusSquare = decimal.Parse(Math.Pow(chimneyRadius, 2).ToString());
                    double barrelRadius = double.Parse(distanceRoundBarrelDiameter.ToStringInEng3()) / 2;
                    decimal barrelRadiusSquare = decimal.Parse(Math.Pow(barrelRadius, 2).ToString());

                    // Recalculate chimmney Floor   
                    decimal chimneyFloor = 0;
                    tbxRehabilitationDataChimneyFloor.Text = "";
                    if (ckbxRehabilitationDataChimneyFloor.Checked)
                    {
                        chimneyFloor = Decimal.Round(pi * (chimneyRadiusSquare), 2);
                        Distance floorDistance = new Distance(chimneyFloor.ToString());
                        tbxRehabilitationDataChimneyFloor.Text = floorDistance.ToStringInEng3();
                    }

                    // Recalculate Chimney Ceiling
                    decimal chimneyCeiling = 0;
                    tbxRehabilitationDataChimneyCeiling.Text = "";
                    if (ckbxRehabilitationDataChimneyCeiling.Checked)
                    {
                        chimneyCeiling = Decimal.Round(pi * (chimneyRadiusSquare), 2);
                        Distance ceilingDistance = new Distance(chimneyCeiling.ToString());
                        tbxRehabilitationDataChimneyCeiling.Text = ceilingDistance.ToStringInEng3();

                        //Graphic
                        lblRoudChimneyCeilingLabel.Text = tbxRehabilitationDataChimneyCeiling.Text;
                    }

                    // Recalculate chimney Benching
                    decimal chimneyBenching = 0;
                    tbxRehabilitationDataChimneyBenching.Text = "";
                    if (ckbxRehabilitationDataChimneyBenching.Checked)
                    {
                        chimneyBenching = Decimal.Round((pi * (chimneyRadiusSquare)) * decimal.Parse("0.06"), 2);
                        Distance benchingDistance = new Distance(chimneyBenching.ToString());
                        tbxRehabilitationDataChimneyBenching.Text = benchingDistance.ToStringInEng3();
                    }

                    // Recalculate chimney surface area          
                    decimal chimneyArea = Decimal.Round((2 * pi * (decimal.Parse("0.5") * chimneyDiameter) * chimneyDepth), 2);
                    Distance chimneyAreaDistance = new Distance(chimneyArea.ToString());
                    tbxRehabilitationDataChimneySurfaceArea.Text = chimneyAreaDistance.ToStringInEng3(); 

                    // Recalculate Barrel Floor   
                    decimal barrelFloor = 0;
                    tbxRehabilitationDataBarrelFloor.Text = "";
                   
                    if (ckbxRehabilitationDataBarrelFloor.Checked)
                    {
                        barrelFloor = Decimal.Round(pi * (barrelRadiusSquare), 2);
                        Distance floorDistance = new Distance(barrelFloor.ToString());
                        tbxRehabilitationDataBarrelFloor.Text = floorDistance.ToStringInEng3(); 
                    }

                    // Recalculate Barrel Ceiling
                    decimal barrelCeiling = 0;
                    tbxRehabilitationDataBarrelCeiling.Text = "";
                    if (ckbxRehabilitationDataBarrelCeiling.Checked)
                    {
                        barrelCeiling = Decimal.Round(pi * (barrelRadiusSquare), 2);
                        Distance ceilingDistance = new Distance(barrelCeiling.ToString());
                        tbxRehabilitationDataBarrelCeiling.Text = ceilingDistance.ToStringInEng3();

                        // Graphic
                        lblRoundBarrelCeilingLabel.Text = tbxRehabilitationDataBarrelCeiling.Text;
                    }

                    // Recalculate Barrel Benching
                    decimal barrelBenching = 0;
                    tbxRehabilitationDataBarrelBenching.Text = "";
                    if (ckbxRehabilitationDataBarrelBenching.Checked)
                    {
                        barrelBenching = Decimal.Round((pi * (barrelRadiusSquare)) * decimal.Parse("0.06"), 2);
                        Distance benchingDistance = new Distance(barrelBenching.ToString());
                        tbxRehabilitationDataBarrelBenching.Text = benchingDistance.ToStringInEng3();
                    }

                    // Recalculate Barrel surface area 
                    decimal barrelArea = Decimal.Round((2 * pi * (decimal.Parse("0.5") * barrelDiameter) * barrelDepth), 2);
                    Distance barrelAreaDistance = new Distance(barrelArea.ToString());
                    tbxRehabilitationDataBarrelSurfaceArea.Text = barrelAreaDistance.ToStringInEng3();

                    // Recalculte total depth 
                    decimal totalDepth = decimal.Round(chimneyDepth + barrelDepth, 0);
                    Distance totalDepthDistance = new Distance(totalDepth.ToString());
                    tbxRehabilitationDataRoundTotalDepth.Text = totalDepthDistance.ToStringInEng3();

                    // Recalculate total surface area                
                    decimal totalSurfaceArea = decimal.Round((chimneyArea + barrelArea + chimneyFloor + chimneyCeiling + chimneyBenching + barrelFloor + barrelCeiling + barrelBenching), 0);
                    Distance totalSurfaceAreaDistance = new Distance(totalSurfaceArea.ToString());
                    tbxRehabilitationDataRoundTotalSurfaceArea.Text = totalSurfaceAreaDistance.ToStringInEng3();

                    // For Graphic
                    lblRoudChimneyDiameterLabel.Text = tbxRehabilitationDataChimneyDiameter.Text;
                    lblRoudChimneyDepthLabel.Text = tbxRehabilitationDataChimneyDepth.Text;
                    lblRoundChimneySurfaceAreaLabel.Text = tbxRehabilitationDataChimneySurfaceArea.Text;

                    lblRoudBarrelDiameterLabel.Text = tbxRehabilitationDataBarrelDiameter.Text;
                    lblRoudBarrelDepthLabel.Text = tbxRehabilitationDataBarrelDepth.Text;
                    lblRoundBarrelSurfaceAreaLabel.Text = tbxRehabilitationDataBarrelSurfaceArea.Text;

                    lblRoundTotalDepthLabel.Text = tbxRehabilitationDataRoundTotalDepth.Text;
                    lblRoundTotalSurfaceArea.Text = "Total Surface Area: " + tbxRehabilitationDataRoundTotalSurfaceArea.Text;

                    decimal chimneyTotalSurfaceArea = decimal.Round(chimneyArea + chimneyFloor + chimneyCeiling + chimneyBenching, 2);
                    Distance chimneyTotalSurfaceAreaDistance = new Distance(chimneyTotalSurfaceArea.ToString());
                    tbxRehabilitationDataChimneyTotalSurfaceArea.Text = chimneyTotalSurfaceAreaDistance.ToStringInEng3();

                    decimal barrelTotalSurfaceArea = decimal.Round(barrelArea + barrelFloor + barrelCeiling + barrelBenching, 2);
                    Distance barrelTotalSurfaceAreaDistance = new Distance(barrelTotalSurfaceArea.ToString());
                    tbxRehabilitationDataBarrelTotalSurfaceArea.Text = barrelTotalSurfaceAreaDistance.ToStringInEng3();
                }
                else
                {
                    Distance distanceRoundChimneyDiameter = new Distance(tbxRehabilitationDataChimneyDiameter.Text);
                    decimal chimneyDiameter = decimal.Parse(distanceRoundChimneyDiameter.ToStringInEng3());
                    tbxRehabilitationDataChimneyDiameter.Text = distanceRoundChimneyDiameter.ToStringInMet2();

                    Distance distanceRoundChimneyDepth = new Distance(tbxRehabilitationDataChimneyDepth.Text);
                    decimal chimneyDepth = decimal.Parse(distanceRoundChimneyDepth.ToStringInEng3());
                    tbxRehabilitationDataChimneyDepth.Text = distanceRoundChimneyDepth.ToStringInMet2();

                    Distance distanceRoundBarrelDiameter = new Distance(tbxRehabilitationDataBarrelDiameter.Text);
                    decimal barrelDiameter = decimal.Parse(distanceRoundBarrelDiameter.ToStringInEng3());
                    tbxRehabilitationDataBarrelDiameter.Text = distanceRoundBarrelDiameter.ToStringInMet2();

                    Distance distanceRoundBarrelDepth = new Distance(tbxRehabilitationDataBarrelDepth.Text);
                    decimal barrelDepth = decimal.Parse(distanceRoundBarrelDepth.ToStringInEng3());
                    tbxRehabilitationDataBarrelDepth.Text = distanceRoundBarrelDepth.ToStringInMet2();

                    decimal pi = Decimal.Round(decimal.Parse(Math.PI.ToString()), 4);
                    double chimneyRadius = double.Parse(distanceRoundChimneyDiameter.ToStringInEng3()) / 2;
                    decimal chimneyRadiusSquare = decimal.Parse(Math.Pow(chimneyRadius, 2).ToString());
                    double barrelRadius = double.Parse(distanceRoundBarrelDiameter.ToStringInEng3()) / 2;
                    decimal barrelRadiusSquare = decimal.Parse(Math.Pow(barrelRadius, 2).ToString());

                    // Recalculate chimmney Floor   
                    decimal chimneyFloor = 0;
                    tbxRehabilitationDataChimneyFloor.Text = "";
                    if (ckbxRehabilitationDataChimneyFloor.Checked)
                    {
                        chimneyFloor = Decimal.Round(pi * (chimneyRadiusSquare), 2);
                        Distance floorDistance = new Distance(chimneyFloor.ToString());
                        tbxRehabilitationDataChimneyFloor.Text = floorDistance.ToStringInMet2();
                    }

                    // Recalculate Chimney Ceiling
                    decimal chimneyCeiling = 0;
                    tbxRehabilitationDataChimneyCeiling.Text = "";
                    if (ckbxRehabilitationDataChimneyCeiling.Checked)
                    {
                        chimneyCeiling = Decimal.Round(pi * (chimneyRadiusSquare), 2);
                        Distance ceilingDistance = new Distance(chimneyCeiling.ToString());
                        tbxRehabilitationDataChimneyCeiling.Text = ceilingDistance.ToStringInMet2();

                        //Graphic
                        lblRoudChimneyCeilingLabel.Text = tbxRehabilitationDataChimneyCeiling.Text;
                    }

                    // Recalculate chimney Benching
                    decimal chimneyBenching = 0;
                    tbxRehabilitationDataChimneyBenching.Text = "";
                    if (ckbxRehabilitationDataChimneyBenching.Checked)
                    {
                        chimneyBenching = Decimal.Round((pi * (chimneyRadiusSquare)) * decimal.Parse("0.06"), 2);
                        Distance benchingDistance = new Distance(chimneyBenching.ToString());
                        tbxRehabilitationDataChimneyBenching.Text = benchingDistance.ToStringInMet2();
                    }

                    // Recalculate chimney surface area          
                    decimal chimneyArea = Decimal.Round((2 * pi * (decimal.Parse("0.5") * chimneyDiameter) * chimneyDepth), 2);
                    Distance chimneyAreaDistance = new Distance(chimneyArea.ToString());
                    tbxRehabilitationDataChimneySurfaceArea.Text = chimneyAreaDistance.ToStringInMet2();

                    // Recalculate Barrel Floor   
                    decimal barrelFloor = 0;
                    tbxRehabilitationDataBarrelFloor.Text = "";
                    if (ckbxRehabilitationDataBarrelFloor.Checked)
                    {
                        barrelFloor = Decimal.Round(pi * (barrelRadiusSquare), 2);
                        Distance floorDistance = new Distance(barrelFloor.ToString());
                        tbxRehabilitationDataBarrelFloor.Text = floorDistance.ToStringInMet2();
                    }

                    // Recalculate Barrel Ceiling
                    decimal barrelCeiling = 0;
                    tbxRehabilitationDataBarrelCeiling.Text = "";
                    if (ckbxRehabilitationDataBarrelCeiling.Checked)
                    {
                        barrelCeiling = Decimal.Round(pi * (barrelRadiusSquare), 2);
                        Distance ceilingDistance = new Distance(barrelCeiling.ToString());
                        tbxRehabilitationDataBarrelCeiling.Text = ceilingDistance.ToStringInMet2();

                        // Graphic
                        lblRoundBarrelCeilingLabel.Text = tbxRehabilitationDataBarrelCeiling.Text;
                    }

                    // Recalculate Barrel Benching
                    decimal barrelBenching = 0;
                    tbxRehabilitationDataBarrelBenching.Text = "";
                    if (ckbxRehabilitationDataBarrelBenching.Checked)
                    {
                        barrelBenching = Decimal.Round((pi * (barrelRadiusSquare)) * decimal.Parse("0.06"), 2);
                        Distance benchingDistance = new Distance(barrelBenching.ToString());
                        tbxRehabilitationDataBarrelBenching.Text = benchingDistance.ToStringInMet2();
                    }

                    // Recalculate Barrel surface area 
                    decimal barrelArea = Decimal.Round((2 * pi * (decimal.Parse("0.5") * barrelDiameter) * barrelDepth), 2);
                    Distance barrelAreaDistance = new Distance(barrelArea.ToString());
                    tbxRehabilitationDataBarrelSurfaceArea.Text = barrelAreaDistance.ToStringInMet2();

                    // Recalculte total depth 
                    decimal totalDepth = decimal.Round(chimneyDepth + barrelDepth, 0);
                    Distance totalDepthDistance = new Distance(totalDepth.ToString());
                    tbxRehabilitationDataRoundTotalDepth.Text = totalDepthDistance.ToStringInMet2();

                    // Recalculate total surface area                
                    decimal totalSurfaceArea = decimal.Round((chimneyArea + barrelArea + chimneyFloor + chimneyCeiling + chimneyBenching + barrelFloor + barrelCeiling + barrelBenching), 0);
                    Distance totalSurfaceAreaDistance = new Distance(totalSurfaceArea.ToString());
                    tbxRehabilitationDataRoundTotalSurfaceArea.Text = totalSurfaceAreaDistance.ToStringInEng3();

                    // For Graphic
                    lblRoudChimneyDiameterLabel.Text = tbxRehabilitationDataChimneyDiameter.Text;
                    lblRoudChimneyDepthLabel.Text = tbxRehabilitationDataChimneyDepth.Text;
                    lblRoundChimneySurfaceAreaLabel.Text = tbxRehabilitationDataChimneySurfaceArea.Text;

                    lblRoudBarrelDiameterLabel.Text = tbxRehabilitationDataBarrelDiameter.Text;
                    lblRoudBarrelDepthLabel.Text = tbxRehabilitationDataBarrelDepth.Text;
                    lblRoundBarrelSurfaceAreaLabel.Text = tbxRehabilitationDataBarrelSurfaceArea.Text;

                    lblRoundTotalDepthLabel.Text = tbxRehabilitationDataRoundTotalDepth.Text;
                    lblRoundTotalSurfaceArea.Text = "Total Surface Area: " + tbxRehabilitationDataRoundTotalSurfaceArea.Text;

                    decimal chimneyTotalSurfaceArea = decimal.Round(chimneyArea + chimneyFloor + chimneyCeiling + chimneyBenching, 2);
                    Distance chimneyTotalSurfaceAreaDistance = new Distance(chimneyTotalSurfaceArea.ToString());
                    tbxRehabilitationDataChimneyTotalSurfaceArea.Text = chimneyTotalSurfaceAreaDistance.ToStringInEng3();

                    decimal barrelTotalSurfaceArea = decimal.Round(barrelArea + barrelFloor + barrelCeiling + barrelBenching, 2);
                    Distance barrelTotalSurfaceAreaDistance = new Distance(barrelTotalSurfaceArea.ToString());
                    tbxRehabilitationDataBarrelTotalSurfaceArea.Text = barrelTotalSurfaceAreaDistance.ToStringInEng3();
                }
            }                
        }



        protected void btnRectangularShapeOnClick(object sender, EventArgs e)
        {
            Page.Validate("mrRectangularShape");
            if (Page.IsValid)
            {
                if (ckbxRehabilitationDataImperial.Checked)
                {
                    Distance distanceRectangularRectangle1LongSide = new Distance(tbxRehabilitationDataRectangle1LongSide.Text);
                    decimal rectangle1LongSide = GetValueInEng3With2Decimals(distanceRectangularRectangle1LongSide.ToStringInEng3());
                    tbxRehabilitationDataRectangle1LongSide.Text = rectangle1LongSide.ToString();

                    Distance distanceRectangularRectangle1ShortSide = new Distance(tbxRehabilitationDataRectangle1ShortSide.Text);
                    decimal rectangle1ShortSide = GetValueInEng3With2Decimals(distanceRectangularRectangle1ShortSide.ToStringInEng3());
                    tbxRehabilitationDataRectangle1ShortSide.Text = rectangle1ShortSide.ToString();

                    Distance distanceRectangularRectangle1Depth = new Distance(tbxRehabilitationDataRectangle1Depth.Text);
                    decimal rectangle1Depth = GetValueInEng3With2Decimals(distanceRectangularRectangle1Depth.ToStringInEng3());
                    tbxRehabilitationDataRectangle1Depth.Text = rectangle1Depth.ToString();

                    Distance distanceRectangularRectangle2LongSide = new Distance(tbxRehabilitationDataRectangle2LongSide.Text);
                    decimal rectangle2LongSide = GetValueInEng3With2Decimals(distanceRectangularRectangle2LongSide.ToStringInEng3());
                    tbxRehabilitationDataRectangle2LongSide.Text = rectangle2LongSide.ToString();

                    Distance distanceRectangularRectangle2ShortSide = new Distance(tbxRehabilitationDataRectangle2ShortSide.Text);
                    decimal rectangle2ShortSide = GetValueInEng3With2Decimals(distanceRectangularRectangle2ShortSide.ToStringInEng3());
                    tbxRehabilitationDataRectangle2ShortSide.Text = rectangle2ShortSide.ToString();

                    Distance distanceRectangularRectangle2Depth = new Distance(tbxRehabilitationDataRectangle2Depth.Text);
                    decimal rectangle2Depth = GetValueInEng3With2Decimals(distanceRectangularRectangle2Depth.ToStringInEng3());
                    tbxRehabilitationDataRectangle2Depth.Text = rectangle2Depth.ToString();

                    // Recalculate Rectangle1 floor
                    decimal rectangle1Floor = 0;
                    tbxRehabilitationDataRectangle1Floor.Text = "";
                    if (ckbxRehabilitationDataRectangle1Floor.Checked)
                    {
                        rectangle1Floor = Decimal.Round((rectangle1LongSide * rectangle1ShortSide), 2);
                        Distance floorDistance = new Distance(rectangle1Floor.ToString());
                        tbxRehabilitationDataRectangle1Floor.Text = floorDistance.ToStringInEng3();
                    }

                    // Recalculate Rectangle1 ceiling
                    decimal rectangle1Ceiling = 0;
                    tbxRehabilitationDataRectangle1Ceiling.Text = "";
                    if (ckbxRehabilitationDataRectangle1Ceiling.Checked)
                    {
                        rectangle1Ceiling = Decimal.Round((rectangle1LongSide * rectangle1ShortSide), 2);
                        Distance ceilingDistance = new Distance(rectangle1Ceiling.ToString());
                        tbxRehabilitationDataRectangle1Ceiling.Text = ceilingDistance.ToStringInEng3();

                        //Graphic
                        lblRectangular1CeilingLabel.Text = tbxRehabilitationDataRectangle1Ceiling.Text;
                    }

                    // Recalculate Rectangle1 benching
                    decimal rectangle1Benching = 0;
                    tbxRehabilitationDataRectangle1Benching.Text = "";
                    if (ckbxRehabilitationDataRectangle1Benching.Checked)
                    {
                        rectangle1Benching = Decimal.Round(((rectangle1LongSide * rectangle1ShortSide) * decimal.Parse("0.06")), 2);
                        Distance benchingDistance = new Distance(rectangle1Benching.ToString());
                        tbxRehabilitationDataRectangle1Benching.Text = benchingDistance.ToStringInEng3();
                    }

                    // Recalculate rectangle 1 surface area
                    decimal rectangle1SurfaceArea = decimal.Round(((rectangle1LongSide * 2) + (rectangle1ShortSide * 2)) * rectangle1Depth, 2);
                    Distance rectangle1SurfaceAreaDistance = new Distance(rectangle1SurfaceArea.ToString());
                    tbxRehabilitationDataRectangle1SurfaceArea.Text = rectangle1SurfaceAreaDistance.ToStringInEng3();

                    // Recalculate Rectangle2 floor
                    decimal rectangle2Floor = 0;
                    tbxRehabilitationDataRectangle2Floor.Text = "";
                    if (ckbxRehabilitationDataRectangle2Floor.Checked)
                    {
                        rectangle2Floor = Decimal.Round((rectangle2LongSide * rectangle2ShortSide), 2);
                        Distance floorDistance = new Distance(rectangle2Floor.ToString());
                        tbxRehabilitationDataRectangle2Floor.Text = floorDistance.ToStringInEng3();
                    }

                    // Recalculate Rectangle2 ceiling
                    decimal rectangle2Ceiling = 0;
                    tbxRehabilitationDataRectangle2Ceiling.Text = "";
                    if (ckbxRehabilitationDataRectangle2Ceiling.Checked)
                    {
                        rectangle2Ceiling = Decimal.Round((rectangle2LongSide * rectangle2ShortSide), 2);
                        Distance ceilingDistance = new Distance(rectangle2Ceiling.ToString());
                        tbxRehabilitationDataRectangle2Ceiling.Text = ceilingDistance.ToStringInEng3();

                        //Graphic
                        lblRectangular2CeilingLabel.Text = tbxRehabilitationDataRectangle2Ceiling.Text;
                    }

                    // Recalculate Rectangle2 benching
                    decimal rectangle2Benching = 0;
                    tbxRehabilitationDataRectangle2Benching.Text = "";
                    if (ckbxRehabilitationDataRectangle2Benching.Checked)
                    {
                        rectangle2Benching = Decimal.Round(((rectangle2LongSide * rectangle2ShortSide) * decimal.Parse("0.06")), 2);
                        Distance benchingDistance = new Distance(rectangle2Benching.ToString());
                        tbxRehabilitationDataRectangle2Benching.Text = benchingDistance.ToStringInEng3();
                    }

                    // Recalculate rectangle 2 surface area
                    decimal rectangle2SurfaceArea = decimal.Round(((rectangle2LongSide * 2) + (rectangle2ShortSide * 2)) * rectangle2Depth, 2);
                    Distance rectangle2SurfaceAreaDistance = new Distance(rectangle2SurfaceArea.ToString());
                    tbxRehabilitationDataRectangle2SurfaceArea.Text = rectangle2SurfaceAreaDistance.ToStringInEng3();

                    // Recalculate total depth   
                    decimal totalDepth = decimal.Round(rectangle1Depth + rectangle2Depth, 0);
                    Distance totalDepthDistance = new Distance(totalDepth.ToString());
                    tbxRehabilitationDataRectangularTotalDepth.Text = totalDepthDistance.ToStringInEng3();

                    // Recalculate rectangle total surface area                                                   
                    decimal totalSurfaceArea = decimal.Round(rectangle1SurfaceArea + rectangle2SurfaceArea + rectangle1Floor + rectangle1Ceiling + rectangle1Benching + rectangle2Floor + rectangle2Ceiling + rectangle2Benching, 0);
                    Distance totalSurfaceAreaDistance = new Distance(totalSurfaceArea.ToString());
                    tbxRehabilitationDataRectangularTotalSurfaceArea.Text = totalSurfaceAreaDistance.ToStringInEng3();

                    // Graphic 
                    lblRectangular1LongSideLabel.Text = tbxRehabilitationDataRectangle1LongSide.Text;
                    lblRectangular1ShortSideLabel.Text = tbxRehabilitationDataRectangle1ShortSide.Text;
                    lblRectangular1DephtLabel.Text = tbxRehabilitationDataRectangle1Depth.Text;
                    lblRectangle1SurfaceAreaLabel.Text = tbxRehabilitationDataRectangle1SurfaceArea.Text;

                    lblRectangle2LongSideLabel.Text = tbxRehabilitationDataRectangle2LongSide.Text;
                    lblRectangular2ShortSideLabel.Text = tbxRehabilitationDataRectangle2ShortSide.Text;
                    lblRectangular2Depth.Text = tbxRehabilitationDataRectangle2Depth.Text;
                    lblRectangle2SurfaceAreaLabel.Text = tbxRehabilitationDataRectangle2SurfaceArea.Text;

                    lblRectangularTotalDepthLabel.Text = tbxRehabilitationDataRectangularTotalDepth.Text;
                    lblRectangularTotalSurfaceAreaLabel.Text = "Total Surface Area: " + tbxRehabilitationDataRectangularTotalSurfaceArea.Text;

                    // Recalculate Top total surface area  
                    decimal rectangle1TotalSurfaceArea = decimal.Round(rectangle1SurfaceArea + rectangle1Floor + rectangle1Ceiling + rectangle1Benching, 2);
                    Distance rectangle1TotalSurfaceAreaDistance = new Distance(rectangle1TotalSurfaceArea.ToString());
                    tbxRehabilitationDataRectangle1TotalSurfaceArea.Text = rectangle1TotalSurfaceAreaDistance.ToStringInEng3();

                    // Recalculate Down total surface area  
                    decimal rectangle2TotalSurfaceArea = decimal.Round(rectangle2SurfaceArea + rectangle2Floor + rectangle2Ceiling + rectangle2Benching, 2);
                    Distance rectangle2TotalSurfaceAreaDistance = new Distance(rectangle2TotalSurfaceArea.ToString());
                    tbxRehabilitationDataRectangle2TotalSurfaceArea.Text = rectangle2TotalSurfaceAreaDistance.ToStringInEng3();
                }
                else
                {
                    Distance distanceRectangularRectangle1LongSide = new Distance(tbxRehabilitationDataRectangle1LongSide.Text);
                    decimal rectangle1LongSide = GetValueInEng3With2Decimals(distanceRectangularRectangle1LongSide.ToStringInEng3());
                    tbxRehabilitationDataRectangle1LongSide.Text = distanceRectangularRectangle1LongSide.ToStringInMet2();

                    Distance distanceRectangularRectangle1ShortSide = new Distance(tbxRehabilitationDataRectangle1ShortSide.Text);
                    decimal rectangle1ShortSide = GetValueInEng3With2Decimals(distanceRectangularRectangle1ShortSide.ToStringInEng3());
                    tbxRehabilitationDataRectangle1ShortSide.Text = distanceRectangularRectangle1ShortSide.ToStringInMet2();

                    Distance distanceRectangularRectangle1Depth = new Distance(tbxRehabilitationDataRectangle1Depth.Text);
                    decimal rectangle1Depth = GetValueInEng3With2Decimals(distanceRectangularRectangle1Depth.ToStringInEng3());
                    tbxRehabilitationDataRectangle1Depth.Text = distanceRectangularRectangle1Depth.ToStringInMet2();

                    Distance distanceRectangularRectangle2LongSide = new Distance(tbxRehabilitationDataRectangle2LongSide.Text);
                    decimal rectangle2LongSide = GetValueInEng3With2Decimals(distanceRectangularRectangle2LongSide.ToStringInEng3());
                    tbxRehabilitationDataRectangle2LongSide.Text = distanceRectangularRectangle2LongSide.ToStringInMet2();

                    Distance distanceRectangularRectangle2ShortSide = new Distance(tbxRehabilitationDataRectangle2ShortSide.Text);
                    decimal rectangle2ShortSide = GetValueInEng3With2Decimals(distanceRectangularRectangle2ShortSide.ToStringInEng3());
                    tbxRehabilitationDataRectangle2ShortSide.Text = distanceRectangularRectangle2ShortSide.ToStringInMet2();

                    Distance distanceRectangularRectangle2Depth = new Distance(tbxRehabilitationDataRectangle2Depth.Text);
                    decimal rectangle2Depth = GetValueInEng3With2Decimals(distanceRectangularRectangle2Depth.ToStringInEng3());
                    tbxRehabilitationDataRectangle2Depth.Text = distanceRectangularRectangle2Depth.ToStringInMet2();

                    // Recalculate Rectangle1 floor
                    decimal rectangle1Floor = 0;
                    tbxRehabilitationDataRectangle1Floor.Text = "";
                    if (ckbxRehabilitationDataRectangle1Floor.Checked)
                    {
                        rectangle1Floor = Decimal.Round((rectangle1LongSide * rectangle1ShortSide), 2);
                        Distance floorDistance = new Distance(rectangle1Floor.ToString());
                        tbxRehabilitationDataRectangle1Floor.Text = floorDistance.ToStringInMet2();
                    }

                    // Recalculate Rectangle1 ceiling
                    decimal rectangle1Ceiling = 0;
                    tbxRehabilitationDataRectangle1Ceiling.Text = "";
                    if (ckbxRehabilitationDataRectangle1Ceiling.Checked)
                    {
                        rectangle1Ceiling = Decimal.Round((rectangle1LongSide * rectangle1ShortSide), 2);
                        Distance ceilingDistance = new Distance(rectangle1Ceiling.ToString());
                        tbxRehabilitationDataRectangle1Ceiling.Text = ceilingDistance.ToStringInMet2();

                        //Graphic
                        lblRectangular1CeilingLabel.Text = tbxRehabilitationDataRectangle1Ceiling.Text;
                    }

                    // Recalculate Rectangle1 benching
                    decimal rectangle1Benching = 0;
                    tbxRehabilitationDataRectangle1Benching.Text = "";
                    if (ckbxRehabilitationDataRectangle1Benching.Checked)
                    {
                        rectangle1Benching = Decimal.Round(((rectangle1LongSide * rectangle1ShortSide) * decimal.Parse("0.06")), 2);
                        Distance benchingDistance = new Distance(rectangle1Benching.ToString());
                        tbxRehabilitationDataRectangle1Benching.Text = benchingDistance.ToStringInMet2();
                    }

                    // Recalculate rectangle 1 surface area
                    decimal rectangle1SurfaceArea = decimal.Round(((rectangle1LongSide * 2) + (rectangle1ShortSide * 2)) * rectangle1Depth, 2);
                    Distance rectangle1SurfaceAreaDistance = new Distance(rectangle1SurfaceArea.ToString());
                    tbxRehabilitationDataRectangle1SurfaceArea.Text = rectangle1SurfaceAreaDistance.ToStringInMet2();

                    // Recalculate Rectangle2 floor
                    decimal rectangle2Floor = 0;
                    tbxRehabilitationDataRectangle2Floor.Text = "";
                    if (ckbxRehabilitationDataRectangle2Floor.Checked)
                    {
                        rectangle2Floor  = Decimal.Round((rectangle2LongSide * rectangle2ShortSide), 2);
                        Distance floorDistance = new Distance(rectangle2Floor.ToString());
                        tbxRehabilitationDataRectangle2Floor.Text = floorDistance.ToStringInMet2();

                    }

                    // Recalculate Rectangle2 ceiling
                    decimal rectangle2Ceiling = 0;
                    tbxRehabilitationDataRectangle2Ceiling.Text = "";
                    if (ckbxRehabilitationDataRectangle2Ceiling.Checked)
                    {
                        rectangle2Ceiling = Decimal.Round((rectangle2LongSide * rectangle2ShortSide), 2);
                        Distance ceilingDistance = new Distance(rectangle2Ceiling.ToString());
                        tbxRehabilitationDataRectangle2Ceiling.Text = ceilingDistance.ToStringInMet2();

                        //Graphic
                        lblRectangular2CeilingLabel.Text = tbxRehabilitationDataRectangle2Ceiling.Text;
                    }

                    // Recalculate Rectangle2 benching
                    decimal rectangle2Benching = 0;
                    tbxRehabilitationDataRectangle2Benching.Text = "";
                    if (ckbxRehabilitationDataRectangle2Benching.Checked)
                    {
                        rectangle2Benching = Decimal.Round(((rectangle2LongSide * rectangle2ShortSide) * decimal.Parse("0.06")), 2);
                        Distance benchingDistance = new Distance(rectangle2Benching.ToString());
                        tbxRehabilitationDataRectangle2Benching.Text = benchingDistance.ToStringInMet2();
                    }

                    // Recalculate rectangle 2 surface area
                    decimal rectangle2SurfaceArea = decimal.Round(((rectangle2LongSide * 2) + (rectangle2ShortSide * 2)) * rectangle2Depth, 2);
                    Distance rectangle2SurfaceAreaDistance = new Distance(rectangle2SurfaceArea.ToString());
                    tbxRehabilitationDataRectangle2SurfaceArea.Text = rectangle2SurfaceAreaDistance.ToStringInMet2();

                    // Recalculate total depth   
                    decimal totalDepth = decimal.Round(rectangle1Depth + rectangle2Depth, 0);
                    Distance totalDepthDistance = new Distance(totalDepth.ToString());
                    tbxRehabilitationDataRectangularTotalDepth.Text = totalDepthDistance.ToStringInMet2();

                    // Recalculate rectangle total surface area                                                   
                    decimal totalSurfaceArea = decimal.Round(rectangle1SurfaceArea + rectangle2SurfaceArea + rectangle1Floor + rectangle1Ceiling + rectangle1Benching + rectangle2Floor + rectangle2Ceiling + rectangle2Benching, 0);
                    Distance totalSurfaceAreaDistance = new Distance(totalSurfaceArea.ToString());
                    tbxRehabilitationDataRectangularTotalSurfaceArea.Text = totalSurfaceAreaDistance.ToStringInEng3();

                    // Graphic 
                    lblRectangular1LongSideLabel.Text = tbxRehabilitationDataRectangle1LongSide.Text;
                    lblRectangular1ShortSideLabel.Text = tbxRehabilitationDataRectangle1ShortSide.Text;
                    lblRectangular1DephtLabel.Text = tbxRehabilitationDataRectangle1Depth.Text;
                    lblRectangle1SurfaceAreaLabel.Text = tbxRehabilitationDataRectangle1SurfaceArea.Text;

                    lblRectangle2LongSideLabel.Text = tbxRehabilitationDataRectangle2LongSide.Text;
                    lblRectangular2ShortSideLabel.Text = tbxRehabilitationDataRectangle2ShortSide.Text;
                    lblRectangular2Depth.Text = tbxRehabilitationDataRectangle2Depth.Text;
                    lblRectangle2SurfaceAreaLabel.Text = tbxRehabilitationDataRectangle2SurfaceArea.Text;

                    lblRectangularTotalDepthLabel.Text = tbxRehabilitationDataRectangularTotalDepth.Text;
                    lblRectangularTotalSurfaceAreaLabel.Text = "Total Surface Area: " + tbxRehabilitationDataRectangularTotalSurfaceArea.Text;

                    // Recalculate Top total surface area  
                    decimal rectangle1TotalSurfaceArea = decimal.Round(rectangle1SurfaceArea + rectangle1Floor + rectangle1Ceiling + rectangle1Benching, 2);
                    Distance rectangle1TotalSurfaceAreaDistance = new Distance(rectangle1TotalSurfaceArea.ToString());
                    tbxRehabilitationDataRectangle1TotalSurfaceArea.Text = rectangle1TotalSurfaceAreaDistance.ToStringInEng3();

                    // Recalculate Down total surface area  
                    decimal rectangle2TotalSurfaceArea = decimal.Round(rectangle2SurfaceArea + rectangle2Floor + rectangle2Ceiling + rectangle2Benching, 2);
                    Distance rectangle2TotalSurfaceAreaDistance = new Distance(rectangle2TotalSurfaceArea.ToString());
                    tbxRehabilitationDataRectangle2TotalSurfaceArea.Text = rectangle2TotalSurfaceAreaDistance.ToStringInEng3();
                }
            }
        }



        protected void btnMixedShapeOnClick(object sender, EventArgs e)
        {
            Page.Validate("mrMixedShape");
            if (Page.IsValid)
            {
                if (ckbxRehabilitationDataImperial.Checked)
                {
                    Distance distanceMixedRoundDiameter = new Distance(tbxRehabilitationDataRoundDiameter.Text);
                    decimal roundDiameter = GetValueInEng3With2Decimals(distanceMixedRoundDiameter.ToStringInEng3());
                    tbxRehabilitationDataRoundDiameter.Text = roundDiameter.ToString();

                    Distance distanceMixedRoundDepth = new Distance(tbxRehabilitationDataRoundDepth.Text);
                    decimal roundDepth = GetValueInEng3With2Decimals(distanceMixedRoundDepth.ToStringInEng3());
                    tbxRehabilitationDataRoundDepth.Text = roundDepth.ToString();

                    Distance distanceMixedRectangleLongSid = new Distance(tbxRehabilitationDataRectangleLongSide.Text);
                    decimal rectangleLongSide = GetValueInEng3With2Decimals(distanceMixedRectangleLongSid.ToStringInEng3());
                    tbxRehabilitationDataRectangleLongSide.Text = rectangleLongSide.ToString();

                    Distance distanceMixedShortSide = new Distance(tbxRehabilitationDataRectangleShortSide.Text);
                    decimal rectangleShortSide = GetValueInEng3With2Decimals(distanceMixedShortSide.ToStringInEng3());
                    tbxRehabilitationDataRectangleShortSide.Text = rectangleShortSide.ToString();

                    Distance distanceMixedRectangleDepth = new Distance(tbxRehabilitationDataRectangleDepth.Text);
                    decimal rectangleDepth = GetValueInEng3With2Decimals(distanceMixedRectangleDepth.ToStringInEng3());
                    tbxRehabilitationDataRectangleDepth.Text = rectangleDepth.ToString();

                    decimal pi = Decimal.Round(decimal.Parse(Math.PI.ToString()), 4);
                    double radius = double.Parse(distanceMixedRoundDiameter.ToStringInEng3()) / 2;
                    decimal radiusSquare = decimal.Parse(Math.Pow(radius, 2).ToString());

                    // Recalculate Round Floor   
                    decimal roundFloor = 0;
                    tbxRehabilitationDataRoundFloor.Text = "";
                    if (ckbxRehabilitationDataRoundFloor.Checked)
                    {
                        roundFloor = Decimal.Round(pi * (radiusSquare), 2);
                        Distance floorDistance = new Distance(roundFloor.ToString());
                        tbxRehabilitationDataRoundFloor.Text = floorDistance.ToStringInEng3();
                    }

                    // Recalculate Round Ceiling
                    decimal roundCeiling = 0;
                    tbxRehabilitationDataRoundCeiling.Text = "";
                    if (ckbxRehabilitationDataRoundCeiling.Checked)
                    {
                        roundCeiling = Decimal.Round(pi * (radiusSquare), 2);
                        Distance ceilingDistance = new Distance(roundCeiling.ToString());
                        tbxRehabilitationDataRoundCeiling.Text = ceilingDistance.ToStringInEng3(); ;

                        // Graphic                    
                        lblDataRoundCeilingLabel.Text = tbxRehabilitationDataRoundCeiling.Text;
                    }

                    // Recalculate Round Benching
                    decimal roundBenching = 0;
                    tbxRehabilitationDataRoundBenching.Text = "";
                    if (ckbxRehabilitationDataRoundBenching.Checked)
                    {
                        roundBenching = Decimal.Round((pi * (radiusSquare)) * decimal.Parse("0.06"), 2);
                        Distance benchingDistance = new Distance(roundBenching.ToString());
                        tbxRehabilitationDataRoundBenching.Text = benchingDistance.ToStringInEng3();
                    }

                    // Recalculate round surface area            
                    decimal roundSurfaceArea = Decimal.Round((2 * pi * (decimal.Parse("0.5") * roundDiameter) * roundDepth), 2);
                    Distance roundSurfaceAreaDistance = new Distance(roundSurfaceArea.ToString());
                    tbxRehabilitationDataRoundSurfaceArea.Text = roundSurfaceAreaDistance.ToStringInEng3();

                    // Recalculate Rectangle floor
                    decimal rectangleFloor = 0;
                    tbxRehabilitationDataRectangleFloor.Text = "";
                    if (ckbxRehabilitationDataRectangleFloor.Checked)
                    {
                        rectangleFloor = Decimal.Round((rectangleLongSide * rectangleShortSide), 2);
                        Distance ceilingDistance = new Distance(rectangleFloor.ToString());
                        tbxRehabilitationDataRectangleFloor.Text = ceilingDistance.ToStringInEng3();
                    }

                    // Recalculate Rectangle ceiling
                    decimal rectangleCeiling = 0;
                    tbxRehabilitationDataRectangleCeiling.Text = "";
                    if (ckbxRehabilitationDataRectangleCeiling.Checked)
                    {
                        rectangleCeiling = Decimal.Round((rectangleLongSide * rectangleShortSide), 2);
                        Distance ceilingDistance = new Distance(rectangleCeiling.ToString());
                        tbxRehabilitationDataRectangleCeiling.Text = ceilingDistance.ToStringInEng3();

                        //Graphic
                        lblRectangleCeilingLabel.Text = tbxRehabilitationDataRectangleCeiling.Text;
                    }

                    // Recalculate Rectangle benching
                    decimal rectangleBenching = 0;
                    tbxRehabilitationDataRectangleBenching.Text = "";
                    if (ckbxRehabilitationDataRectangleBenching.Checked)
                    {
                        rectangleBenching = Decimal.Round(((rectangleLongSide * rectangleShortSide) * decimal.Parse("0.06")), 2);
                        Distance benchingDistance = new Distance(rectangleBenching.ToString());
                        tbxRehabilitationDataRectangleBenching.Text = benchingDistance.ToStringInEng3();
                    }

                    // Recalculate rectangle  surface area  
                    decimal rectangleSurfaceArea = decimal.Round(((rectangleLongSide * 2) + (rectangleShortSide * 2)) * rectangleDepth, 2);
                    Distance rectangleSurfaceAreaDistance = new Distance(rectangleSurfaceArea.ToString());
                    tbxRehabilitationDataRectangleSufaceArea.Text = rectangleSurfaceAreaDistance.ToStringInEng3();
                    
                    // Recalculte total depth
                    decimal totalDetph = decimal.Round((roundDepth + rectangleDepth), 0);
                    Distance totalDetphDistance = new Distance(totalDetph.ToString());
                    tbxRehabilitationDataMixedTotalDepth.Text = totalDetphDistance.ToStringInEng3();

                    // Recalculate total surface area   
                    decimal totalSurfaceArea = decimal.Round(rectangleSurfaceArea + roundSurfaceArea + roundFloor + roundCeiling + roundBenching + rectangleFloor + rectangleCeiling + rectangleBenching, 0);
                    Distance totalSurfaceAreaDistance = new Distance(totalSurfaceArea.ToString());
                    tbxRehabilitationDataMixedTotalSurfaceArea.Text = totalSurfaceAreaDistance.ToStringInEng3();

                    // Graphic
                    lblDataRoundDiameterLabel.Text = tbxRehabilitationDataRoundDiameter.Text;
                    lblDataRoundDepthLabel.Text = tbxRehabilitationDataRoundDepth.Text;
                    lblDataRoundSurfaceAreaLabel.Text = tbxRehabilitationDataRoundSurfaceArea.Text;

                    lblRectangleLongSideLabel.Text = tbxRehabilitationDataRectangleLongSide.Text;
                    lblRectangleShortSideLabel.Text = tbxRehabilitationDataRectangleShortSide.Text;
                    lblRectangleDephtLabel.Text = tbxRehabilitationDataRectangleDepth.Text;
                    lblRectangleSurfaceAreaLabel.Text = tbxRehabilitationDataRectangleSufaceArea.Text;

                    lblMixedTotalDepthLabel.Text = tbxRehabilitationDataMixedTotalDepth.Text;
                    lblTotalMixedSurfaceAreaLabel.Text = "Total Surface Area: " + tbxRehabilitationDataMixedTotalSurfaceArea.Text;

                    // Recalculate Top total surface area  
                    decimal roundTotalSurfaceArea = decimal.Round(roundSurfaceArea + roundFloor + roundCeiling + roundBenching, 2);
                    Distance roundTotalSurfaceAreaDistance = new Distance(roundTotalSurfaceArea.ToString());
                    tbxRehabilitationDataMixedRoundTotalSurfaceArea.Text = roundTotalSurfaceAreaDistance.ToStringInEng3();

                    // Recalculate Down total surface area  
                    decimal mixesRectangleTotalSurfaceArea = decimal.Round(rectangleSurfaceArea + rectangleFloor + rectangleCeiling + rectangleBenching, 2);
                    Distance mixesRectangleTotalSurfaceAreaDistance = new Distance(mixesRectangleTotalSurfaceArea.ToString());
                    tbxRehabilitationDataMixedRectangleTotalSurfaceArea.Text = mixesRectangleTotalSurfaceAreaDistance.ToStringInEng3();
                }
                else
                {
                    Distance distanceMixedRoundDiameter = new Distance(tbxRehabilitationDataRoundDiameter.Text);
                    decimal roundDiameter = GetValueInEng3With2Decimals(distanceMixedRoundDiameter.ToStringInEng3());
                    tbxRehabilitationDataRoundDiameter.Text = distanceMixedRoundDiameter.ToStringInMet2();

                    Distance distanceMixedRoundDepth = new Distance(tbxRehabilitationDataRoundDepth.Text);
                    decimal roundDepth = GetValueInEng3With2Decimals(distanceMixedRoundDepth.ToStringInEng3());
                    tbxRehabilitationDataRoundDepth.Text = distanceMixedRoundDepth.ToStringInMet2();

                    Distance distanceMixedRectangleLongSid = new Distance(tbxRehabilitationDataRectangleLongSide.Text);
                    decimal rectangleLongSide = GetValueInEng3With2Decimals(distanceMixedRectangleLongSid.ToStringInEng3());
                    tbxRehabilitationDataRectangleLongSide.Text = distanceMixedRectangleLongSid.ToStringInMet2();

                    Distance distanceMixedShortSide = new Distance(tbxRehabilitationDataRectangleShortSide.Text);
                    decimal rectangleShortSide = GetValueInEng3With2Decimals(distanceMixedShortSide.ToStringInEng3());
                    tbxRehabilitationDataRectangleShortSide.Text = distanceMixedShortSide.ToStringInMet2();

                    Distance distanceMixedRectangleDepth = new Distance(tbxRehabilitationDataRectangleDepth.Text);
                    decimal rectangleDepth = decimal.Parse(distanceMixedRectangleDepth.ToStringInEng3());
                    tbxRehabilitationDataRectangleDepth.Text = distanceMixedRectangleDepth.ToStringInMet2();

                    decimal pi = Decimal.Round(decimal.Parse(Math.PI.ToString()), 4);
                    double radius = double.Parse(distanceMixedRoundDiameter.ToStringInEng3()) / 2;
                    decimal radiusSquare = decimal.Parse(Math.Pow(radius, 2).ToString());

                    // Recalculate Round Floor   
                    decimal roundFloor = 0;
                    tbxRehabilitationDataRoundFloor.Text = "";
                    if (ckbxRehabilitationDataRoundFloor.Checked)
                    {
                        roundFloor = Decimal.Round(pi * (radiusSquare), 2);
                        Distance floorDistance = new Distance(roundFloor.ToString());
                        tbxRehabilitationDataRoundFloor.Text = floorDistance.ToStringInMet2();
                    }

                    // Recalculate Round Ceiling
                    decimal roundCeiling = 0;
                    tbxRehabilitationDataRoundCeiling.Text = "";
                    if (ckbxRehabilitationDataRoundCeiling.Checked)
                    {
                        roundCeiling = Decimal.Round(pi * (radiusSquare), 2);
                        Distance ceilingDistance = new Distance(roundCeiling.ToString());
                        tbxRehabilitationDataRoundCeiling.Text = ceilingDistance.ToStringInMet2(); ;

                        // Graphic                    
                        lblDataRoundCeilingLabel.Text = tbxRehabilitationDataRoundCeiling.Text;
                    }

                    // Recalculate Round Benching
                    decimal roundBenching = 0;
                    tbxRehabilitationDataRoundBenching.Text = "";
                    if (ckbxRehabilitationDataRoundBenching.Checked)
                    {
                        roundBenching = Decimal.Round((pi * (radiusSquare)) * decimal.Parse("0.06"), 2);
                        Distance benchingDistance = new Distance(roundBenching.ToString());
                        tbxRehabilitationDataRoundBenching.Text = benchingDistance.ToStringInMet2();
                    }

                    // Recalculate round surface area            
                    decimal roundSurfaceArea = Decimal.Round((2 * pi * (decimal.Parse("0.5") * roundDiameter) * roundDepth), 2);
                    Distance roundSurfaceAreaDistance = new Distance(roundSurfaceArea.ToString());
                    tbxRehabilitationDataRoundSurfaceArea.Text = roundSurfaceAreaDistance.ToStringInMet2();

                    // Recalculate Rectangle floor
                    decimal rectangleFloor = 0;
                    tbxRehabilitationDataRectangleFloor.Text = "";
                    if (ckbxRehabilitationDataRectangleFloor.Checked)
                    {
                        rectangleFloor = Decimal.Round((rectangleLongSide * rectangleShortSide), 2);
                        Distance ceilingDistance = new Distance(rectangleFloor.ToString());
                        tbxRehabilitationDataRectangleFloor.Text = ceilingDistance.ToStringInMet2();
                    }

                    // Recalculate Rectangle ceiling
                    decimal rectangleCeiling = 0;
                    tbxRehabilitationDataRectangleCeiling.Text = "";
                    if (ckbxRehabilitationDataRectangleCeiling.Checked)
                    {
                        rectangleCeiling = Decimal.Round((rectangleLongSide * rectangleShortSide), 2);
                        Distance ceilingDistance = new Distance(rectangleCeiling.ToString());
                        tbxRehabilitationDataRectangleCeiling.Text = ceilingDistance.ToStringInMet2();

                        //Graphic
                        lblRectangleCeilingLabel.Text = tbxRehabilitationDataRectangleCeiling.Text;
                    }

                    // Recalculate Rectangle benching
                    decimal rectangleBenching = 0;
                    tbxRehabilitationDataRectangleBenching.Text = "";
                    if (ckbxRehabilitationDataRectangleBenching.Checked)
                    {
                        rectangleBenching = Decimal.Round(((rectangleLongSide * rectangleShortSide) * decimal.Parse("0.06")), 2);
                        Distance benchingDistance = new Distance(rectangleBenching.ToString());
                        tbxRehabilitationDataRectangleBenching.Text = benchingDistance.ToStringInMet2();
                    }

                    // Recalculate rectangle  surface area  
                    decimal rectangleSurfaceArea = decimal.Round(((rectangleLongSide * 2) + (rectangleShortSide * 2)) * rectangleDepth, 2);
                    Distance rectangleSurfaceAreaDistance = new Distance(rectangleSurfaceArea.ToString());
                    tbxRehabilitationDataRectangleSufaceArea.Text = rectangleSurfaceAreaDistance.ToStringInMet2();

                    // Recalculte total depth
                    decimal totalDetph = decimal.Round((roundDepth + rectangleDepth), 0);
                    Distance totalDetphDistance = new Distance(totalDetph.ToString());
                    tbxRehabilitationDataMixedTotalDepth.Text = totalDetphDistance.ToStringInMet2();
                    
                    // Recalculate total surface area
                    decimal totalSurfaceArea = decimal.Round(rectangleSurfaceArea + roundSurfaceArea + roundFloor + roundCeiling + roundBenching + rectangleFloor + rectangleCeiling + rectangleBenching, 0);
                    Distance totalSurfaceAreaDistance = new Distance(totalSurfaceArea.ToString());
                    tbxRehabilitationDataMixedTotalSurfaceArea.Text = totalSurfaceAreaDistance.ToStringInEng3();

                    // Graphic
                    lblDataRoundDiameterLabel.Text = tbxRehabilitationDataRoundDiameter.Text;
                    lblDataRoundDepthLabel.Text = tbxRehabilitationDataRoundDepth.Text;
                    lblDataRoundSurfaceAreaLabel.Text = tbxRehabilitationDataRoundSurfaceArea.Text;

                    lblRectangleLongSideLabel.Text = tbxRehabilitationDataRectangleLongSide.Text;
                    lblRectangleShortSideLabel.Text = tbxRehabilitationDataRectangleShortSide.Text;
                    lblRectangleDephtLabel.Text = tbxRehabilitationDataRectangleDepth.Text;
                    lblRectangleSurfaceAreaLabel.Text = tbxRehabilitationDataRectangleSufaceArea.Text;

                    lblMixedTotalDepthLabel.Text = tbxRehabilitationDataMixedTotalDepth.Text;
                    lblTotalMixedSurfaceAreaLabel.Text = "Total Surface Area: " + tbxRehabilitationDataMixedTotalSurfaceArea.Text;

                    // Recalculate Top total surface area  
                    decimal roundTotalSurfaceArea = decimal.Round(roundSurfaceArea + roundFloor + roundCeiling + roundBenching, 2);
                    Distance roundTotalSurfaceAreaDistance = new Distance(roundTotalSurfaceArea.ToString());
                    tbxRehabilitationDataMixedRoundTotalSurfaceArea.Text = roundTotalSurfaceAreaDistance.ToStringInEng3();

                    // Recalculate Down total surface area  
                    decimal mixesRectangleTotalSurfaceArea = decimal.Round(rectangleSurfaceArea + rectangleFloor + rectangleCeiling + rectangleBenching, 2);
                    Distance mixesRectangleTotalSurfaceAreaDistance = new Distance(mixesRectangleTotalSurfaceArea.ToString());
                    tbxRehabilitationDataMixedRectangleTotalSurfaceArea.Text = mixesRectangleTotalSurfaceAreaDistance.ToStringInEng3();
                }
            }
        }

        

        private decimal GetValueInEng3With2Decimals(string value)
        {
            try
            {
                decimal valueValid = decimal.Round(Convert.ToDecimal(value), 2);
                return valueValid;
            }
            catch
            {
                return 0;
            }
        }



        private decimal GetValueValidForCalculations(string value)
        {
            decimal valueValid = decimal.Round(0, 2);

            try
            {
                valueValid = decimal.Round(Convert.ToDecimal(value), 2);
                return valueValid;
            }
            catch
            {
                return valueValid;
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
                return valueValid;
            }
        }



        private string GetValueValidForCalculationsInStringWithoutDecimals(string value)
        {
            string valueValid = "0.00";

            try
            {
                valueValid = decimal.Round(Convert.ToDecimal(value), 0).ToString();
                return valueValid;
            }
            catch
            {
                return valueValid;
            }
        }



        protected void cvRehabilitationDataChimneyDiameter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataChimneyDiameter = (CustomValidator)source;
                string shape = ddlShape.SelectedValue;
                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shape == "Round"))
                {
                    cvRehabilitationDataChimneyDiameter.Text = "Invalid format. (please use X'Y\", or X\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Chimney Diameter";
                }

                // Control of distance > 0
                if ((args.IsValid) && (shape == "Round"))                
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataChimneyDiameter.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Chimney Diameter";
                    }
                }
            }
        }



        protected void cvRehabilitationDataChimneyDepth_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataChimneyDepth = (CustomValidator)source;
                string shape = ddlShape.SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shape == "Round"))
                {
                    cvRehabilitationDataChimneyDepth.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Chimney Depth";
                }

                // Control of distance > 0
                if ((args.IsValid) && (shape == "Round"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataChimneyDepth.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Chimney Depth";
                    }
                }
            }
        }



        protected void cvRehabilitationDataBarrelDiameter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataBarrelDiameter = (CustomValidator)source;
                string shape = ddlShape.SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shape == "Round"))
                {
                    cvRehabilitationDataBarrelDiameter.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Barrel Diameter";
                }

                // Control of distance > 0
                if ((args.IsValid) && (shape == "Round"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataBarrelDiameter.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Barrel Diameter";
                    }
                }
            }
        }



        protected void cvRehabilitationDataBarrelDepth_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataBarrelDepth = (CustomValidator)source;
                string shape = ddlShape.SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shape == "Round"))
                {
                    cvRehabilitationDataBarrelDepth.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Barrel Depth";
                }

                // Control of distance > 0
                if ((args.IsValid) && (shape == "Round"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataBarrelDepth.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Barrel Depth";
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangle1LongSide_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangle1LongSide = (CustomValidator)source;
                string shape = ddlShape.SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shape == "Rectangular"))
                {
                    cvRehabilitationDataRectangle1LongSide.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Rectangle 1 long side";
                }

                // Control of distance > 0
                if ((args.IsValid) && (shape == "Rectangular"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangle1LongSide.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Rectangle 1 long side";
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangle1ShortSide_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangle1ShortSide = (CustomValidator)source;
                string shape = ddlShape.SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shape == "Rectangular"))
                {
                    cvRehabilitationDataRectangle1ShortSide.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Rectangle 1 short side";
                }

                // Control of distance > 0
                if ((args.IsValid) && (shape == "Rectangular"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangle1ShortSide.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Rectangle 1 short side";
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangle1Depth_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangle1Depth = (CustomValidator)source;
                string shape = ddlShape.SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shape == "Rectangular"))
                {
                    cvRehabilitationDataRectangle1Depth.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Rectangle 1 depth";
                }

                // Control of distance > 0
                if ((args.IsValid) && (shape == "Rectangular"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangle1Depth.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Rectangle 1 depth";
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangle2LongSide_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangle2LongSide = (CustomValidator)source;
                string shape = ddlShape.SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shape == "Rectangular"))
                {
                    cvRehabilitationDataRectangle2LongSide.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Rectangle 2 long side";
                }

                // Control of distance > 0
                if ((args.IsValid) && (shape == "Rectangular"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangle2LongSide.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Rectangle 2 long side";
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangle2ShortSide_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangle2ShortSide = (CustomValidator)source;
                string shape = ddlShape.SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shape == "Rectangular"))
                {
                    cvRehabilitationDataRectangle2ShortSide.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Rectangle 2 short side";
                }

                // Control of distance > 0
                if ((args.IsValid) && (shape == "Rectangular"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangle2ShortSide.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Rectangle 2 short side";
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangle2Depth_ServerValidate(object source, ServerValidateEventArgs args)                       
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangle2Depth = (CustomValidator)source;
                string shape = ddlShape.SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shape == "Rectangular"))
                {
                    cvRehabilitationDataRectangle2Depth.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Rectangle 2 depth";
                }

                // Control of distance > 0
                if ((args.IsValid) && (shape == "Rectangular"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangle2Depth.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Rectangle 2 depth";
                    }
                }
            }
        }



        protected void cvRehabilitationDataRoundDiameter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRoundDiameter = (CustomValidator)source;
                string shape = ddlShape.SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shape == "Mixed"))
                {
                    cvRehabilitationDataRoundDiameter.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Round Diameter";
                }

                // Control of distance > 0
                if ((args.IsValid) && (shape == "Mixed"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRoundDiameter.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Round Diameter";
                    }
                }
            }
        }



        protected void cvRehabilitationDataRoundDepth_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRoundDepth = (CustomValidator)source;
                string shape = ddlShape.SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shape == "Mixed"))
                {
                    cvRehabilitationDataRoundDepth.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Round Depth";
                }

                // Control of distance > 0
                if ((args.IsValid) && (shape == "Mixed"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRoundDepth.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Round Depth";
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangleLongSide_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangleLongSide = (CustomValidator)source;
                string shape = ddlShape.SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shape == "Mixed"))
                {
                    cvRehabilitationDataRectangleLongSide.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Rectangle Long Side";
                }

                // Control of distance > 0
                if ((args.IsValid) && (shape == "Mixed"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangleLongSide.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Rectangle Long Side";
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangleShortSide_ServerValidate(object source, ServerValidateEventArgs args)                       
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangleShortSide = (CustomValidator)source;
                string shape = ddlShape.SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shape == "Mixed"))
                {
                    cvRehabilitationDataRectangleShortSide.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Rectangle Short Side";
                }

                // Control of distance > 0
                if ((args.IsValid) && (shape == "Mixed"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangleShortSide.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Rectangle Short Side";
                    }
                }
            }
        }



        protected void cvRehabilitationDataRectangleDepth_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataRectangleDepth = (CustomValidator)source;
                string shape = ddlShape.SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shape == "Mixed"))
                {
                    cvRehabilitationDataRectangleDepth.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Rectangle Depth";
                }

                // Control of distance > 0
                if ((args.IsValid) && (shape == "Mixed"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataRectangleDepth.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Rectangle Depth";
                    }
                }
            }
        }



        protected void cvRehabilitationDataOtherStructure_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvRehabilitationDataOtherStructure = (CustomValidator)source;
                string shape = ddlShape.SelectedValue;

                args.IsValid = true;

                // Control of format
                if ((!Distance.IsValidDistance(args.Value)) && (shape == "Other"))
                {
                    cvRehabilitationDataOtherStructure.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Total Surface Area";
                }

                // Control of distance > 0
                if ((args.IsValid) && (shape == "Other"))
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvRehabilitationDataOtherStructure.Text = "Invalid measurement. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Total Surface Area";
                    }
                }
            }
        }

                               

        protected void ddlShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            int assetId = Int32.Parse(hdfAssetId.Value);
            LoadManholeStructureDataForChange(assetId);

            ShapeStructure();
        }



        protected void ddlRehabilitationBatchDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get last batch id
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int lastBatchId = 0;
            MrBatchVerificationGateway mrBatchVerificationForLastBatch = new MrBatchVerificationGateway();
            mrBatchVerificationForLastBatch.LoadLastBatch(companyId);

            if (mrBatchVerificationForLastBatch.Table.Rows.Count > 0)
            {
                WorkManholeRehabilitationBatchGateway workManholeRehabilitationBatchGateway = new WorkManholeRehabilitationBatchGateway();
                lastBatchId = workManholeRehabilitationBatchGateway.GetLastId(companyId);
            }


            lblNotLastBatch.Visible = false;
            if (ddlRehabilitationBatchDate.SelectedValue != lastBatchId.ToString())
            {
                lblNotLastBatch.Visible = true;
            }
        }



        protected void tkrdpRehabilitationSprayedDate_SelectedDateChanged(object sender, Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs e)
        {
            if (hdfExistBatchId.Value == "False")
            {
                if (tkrdpRehabilitationSprayedDate.SelectedDate.HasValue)
                {
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    MrBatchVerificationGateway mrBatchVerificationForLastBatch = new MrBatchVerificationGateway();
                    mrBatchVerificationForLastBatch.LoadLastBatch(companyId);

                    if (mrBatchVerificationForLastBatch.Table.Rows.Count > 0)
                    {
                        WorkManholeRehabilitationBatchGateway workManholeRehabilitationBatchGateway = new WorkManholeRehabilitationBatchGateway();
                        ddlRehabilitationBatchDate.SelectedValue = workManholeRehabilitationBatchGateway.GetLastId(companyId).ToString();
                    }
                }
                else
                {
                    ddlRehabilitationBatchDate.SelectedValue = "0";
                }
            }
        }

        
        

         
                       
        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("./../Common/select_project.aspx?source_page=mr_edit.aspx&work_type=" + hdfWorkType.Value.Trim());
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
                case "mSave":
                    this.Save();
                    break;

                case "mApply":
                    this.Apply();
                    break;

                case "mCancel":
                    manholeRehabilitationTDS.RejectChanges();
                    Session["manholeRehabilitationTDS"] = manholeRehabilitationTDS;
                    if (Request.QueryString["source_page"] == "mr_navigator2.aspx")
                    {
                        url = "./mr_navigator2.aspx?source_page=mr_edit.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&in_project=" + hdfInProject.Value + GetNavigatorState() + "&update=yes";
                    }

                    if (Request.QueryString["source_page"] == "mr_summary.aspx")
                    {
                        url = "./mr_summary.aspx?source_page=mr_edit.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&in_project=" + hdfInProject.Value + GetNavigatorState() + "&update=yes" + "&asset_id=" + hdfAssetId.Value + "&active_tab=" + activeTab;
                    }
                    break;

                case "mPrevious":
                    // Get previous record
                    int previousId = MrNavigator.GetPreviousId((MrNavigatorTDS)Session["mrNavigatorTDS"], Int32.Parse(hdfAssetId.Value));
                    if (previousId != Int32.Parse(hdfAssetId.Value))
                    {
                        if (this.Apply())
                        {
                            // Redirect
                            url = "./mr_edit.aspx?source_page=" + Request.QueryString["source_page"] + "&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + previousId.ToString() + "&active_tab=" + activeTab + "&in_project=" + hdfInProject.Value + GetNavigatorState() + "&update=yes";
                        }
                    }
                    break;

                case "mNext":
                    // Get next record
                    int nextId = MrNavigator.GetNextId((MrNavigatorTDS)Session["mrNavigatorTDS"], Int32.Parse(hdfAssetId.Value));
                    if (nextId != Int32.Parse(hdfAssetId.Value))
                    {
                        if (this.Apply())
                        {
                            // Redirect
                            url = "./mr_edit.aspx?source_page=" + Request.QueryString["source_page"] + "&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + nextId.ToString() + "&active_tab=" + activeTab + "&in_project=" + hdfInProject.Value + GetNavigatorState() + "&update=yes";
                        }
                    }
                    break;
            }

            if (url != "") Response.Redirect(url);
        }



        protected void tkrpbLeftMenu_ItemClick(object sender, RadPanelBarEventArgs e)
        {
            string url = "";

            // Store active tab for postback
            Session["activeTabMr"] = "0";
            Session["dialogOpenedMr"] = "0";

            switch (e.Item.Value)
            {
                case "mSearch":
                    url = "./mr_navigator.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&in_project=" + hdfInProject.Value + "&work_type=" + hdfWorkType.Value;
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
            contentVariables += "var hdfAssetIdId = '" + hdfAssetId.ClientID + "';";
            contentVariables += "var hdfWorkIdId = '" + hdfWorkId.ClientID + "';";
            contentVariables += "var hdfWorkTypeId = '" + hdfWorkType.ClientID + "';";
            contentVariables += "var hdfCurrentClientIdId = '" + hdfCurrentClientId.ClientID + "';";
            contentVariables += "var hdfCurrentProjectIdId = '" + hdfCurrentProjectId.ClientID + "';";
            contentVariables += "var hdfActiveTabId = '" + hdfActiveTab.ClientID + "';";
            contentVariables += "var tkrmTopId = '" + tkrmTop.ClientID + "';";  
            
                        
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./mr_edit.js");
        }


        
        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&columns_to_display=" + Request.QueryString["columns_to_display"] + "&columns_to_display2=" + Request.QueryString["columns_to_display2"] + "&search_ddlCondition1=" + Request.QueryString["search_ddlCondition1"] + "&search_ddlCondition2=" + Request.QueryString["search_ddlCondition2"] + "&search_tbxCondition1=" + Request.QueryString["search_tbxCondition1"] + "&search_tbxCondition2=" + Request.QueryString["search_tbxCondition2"] + "&search_ddlOperator1=" + Request.QueryString["search_ddlOperator1"] + "&search_ddlOperator2=" + Request.QueryString["search_ddlOperator2"] + "&search_ddlView=" + Request.QueryString["search_ddlView"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&btn_origin=" + Request.QueryString["btn_origin"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
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
            hdfExistBatchId.Value = "False";

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
                hdfCountryId.Value = "";
                hdfProvinceId.Value = "";
                hdfCountyId.Value = "";
                hdfCityId.Value = "";
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
            LoadManholeStructureData(assetId);
            LoadWorkData(workId, assetId);            
        }



        private void LoadManholeData(int assetId)
        {
            ManholeRehabilitationManholeDetailsGateway manholeRehabilitationManholeDetailsGateway = new ManholeRehabilitationManholeDetailsGateway(manholeRehabilitationTDS);
            if (manholeRehabilitationManholeDetailsGateway.Table.Rows.Count > 0)
            {
                // Load Manhole Details for header
                tbxManholeNumber.Text = manholeRehabilitationManholeDetailsGateway.GetMHID(assetId);

                tbxStreet.Text = manholeRehabilitationManholeDetailsGateway.GetAddress(assetId);
                tbxLongitude.Text = manholeRehabilitationManholeDetailsGateway.GetLongitude(assetId);
                tbxLatitude.Text = manholeRehabilitationManholeDetailsGateway.GetLatitud(assetId);

                if (manholeRehabilitationManholeDetailsGateway.GetManholeShape(assetId) == "")
                {
                    ddlShape.SelectedValue = "";
                    hdfSavedShape.Value = "";
                }
                else
                {
                    ddlShape.SelectedValue = manholeRehabilitationManholeDetailsGateway.GetManholeShape(assetId);
                    hdfSavedShape.Value = manholeRehabilitationManholeDetailsGateway.GetManholeShape(assetId);
                }

                if (manholeRehabilitationManholeDetailsGateway.GetMaterialID(assetId).HasValue)
                {
                    int? materialId = manholeRehabilitationManholeDetailsGateway.GetMaterialID(assetId);
                    int materialsId = (int)materialId;
                    ddlMaterial.SelectedValue = materialsId.ToString();
                }
                else
                {
                    ddlMaterial.SelectedIndex = 0;
                }

                if (manholeRehabilitationManholeDetailsGateway.GetLocation(assetId) == "")
                {
                    ddlLocation.SelectedValue = "";
                }
                else
                {
                    ddlLocation.SelectedValue = manholeRehabilitationManholeDetailsGateway.GetLocation(assetId);
                }

                if (manholeRehabilitationManholeDetailsGateway.GetConditionRating(assetId).HasValue)
                {
                    ddlConditioningRating.SelectedValue = manholeRehabilitationManholeDetailsGateway.GetConditionRating(assetId).ToString();
                }
                else
                {
                    ddlConditioningRating.SelectedValue = "-1";
                }
            }
        }



        private void LoadManholeStructureData(int assetId)
        {
            ManholeRehabilitationManholeDetailsGateway manholeRehabilitationManholeDetailsGateway = new ManholeRehabilitationManholeDetailsGateway(manholeRehabilitationTDS);
            if (manholeRehabilitationManholeDetailsGateway.Table.Rows.Count > 0)
        {   
                // ... Round shape
                // ... ... Chimney                
                tbxRehabilitationDataChimneyDiameter.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetTopDiameter(assetId)));
                lblRoudChimneyDiameterLabel.Text = tbxRehabilitationDataChimneyDiameter.Text;
                tbxRehabilitationDataChimneyDepth.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetTopDepth(assetId)));
                lblRoudChimneyDepthLabel.Text = tbxRehabilitationDataChimneyDepth.Text;

                ckbxRehabilitationDataChimneyFloor.Checked = false;
                tbxRehabilitationDataChimneyFloor.Text = "";
                if (manholeRehabilitationManholeDetailsGateway.GetTopFloor(assetId) != "")
                {
                    ckbxRehabilitationDataChimneyFloor.Checked = true;
                    tbxRehabilitationDataChimneyFloor.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetTopFloor(assetId)));
                }

                ckbxRehabilitationDataChimneyCeiling.Checked = false;
                tbxRehabilitationDataChimneyCeiling.Text = "";
                if (manholeRehabilitationManholeDetailsGateway.GetTopCeiling(assetId) != "")
                {
                    ckbxRehabilitationDataChimneyCeiling.Checked = true;
                    tbxRehabilitationDataChimneyCeiling.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetTopCeiling(assetId)));
                    lblRoudChimneyCeilingLabel.Text = tbxRehabilitationDataChimneyCeiling.Text;
                }

                ckbxRehabilitationDataChimneyBenching.Checked = false;
                tbxRehabilitationDataChimneyBenching.Text = "";
                if (manholeRehabilitationManholeDetailsGateway.GetTopBenching(assetId) != "")
                {
                    ckbxRehabilitationDataChimneyBenching.Checked = true;
                    tbxRehabilitationDataChimneyBenching.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetTopBenching(assetId)));
                }

                tbxRehabilitationDataChimneySurfaceArea.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetTopSurfaceArea(assetId)));
                lblRoundChimneySurfaceAreaLabel.Text = tbxRehabilitationDataChimneySurfaceArea.Text;

                // ... ... Barrel
                tbxRehabilitationDataBarrelDiameter.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetDownDiameter(assetId)));
                lblRoudBarrelDiameterLabel.Text = tbxRehabilitationDataBarrelDiameter.Text;
                tbxRehabilitationDataBarrelDepth.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetDownDepth(assetId)));
                lblRoudBarrelDepthLabel.Text = tbxRehabilitationDataBarrelDepth.Text;

                ckbxRehabilitationDataBarrelFloor.Checked = false;
                tbxRehabilitationDataBarrelFloor.Text = "";
                if (manholeRehabilitationManholeDetailsGateway.GetDownFloor(assetId) != "")
                {
                    ckbxRehabilitationDataBarrelFloor.Checked = true;
                    tbxRehabilitationDataBarrelFloor.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetDownFloor(assetId)));
                }

                ckbxRehabilitationDataBarrelCeiling.Checked = false;
                tbxRehabilitationDataBarrelCeiling.Text = "";
                if (manholeRehabilitationManholeDetailsGateway.GetDownCeiling(assetId) != "")
                {
                    ckbxRehabilitationDataBarrelCeiling.Checked = true;
                    tbxRehabilitationDataBarrelCeiling.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetDownCeiling(assetId)));
                    lblRoundBarrelCeilingLabel.Text = tbxRehabilitationDataBarrelCeiling.Text;
                }

                ckbxRehabilitationDataBarrelBenching.Checked = false;
                tbxRehabilitationDataBarrelBenching.Text = "";
                if (manholeRehabilitationManholeDetailsGateway.GetDownBenching(assetId) != "")
                {
                    ckbxRehabilitationDataBarrelBenching.Checked = true;
                    tbxRehabilitationDataBarrelBenching.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetDownBenching(assetId)));
                }

                tbxRehabilitationDataBarrelSurfaceArea.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetDownSurfaceArea(assetId)));
                lblRoundBarrelSurfaceAreaLabel.Text = tbxRehabilitationDataBarrelSurfaceArea.Text;

                if (manholeRehabilitationManholeDetailsGateway.GetManholeRugs(assetId).HasValue)
                {
                    ddlRehabilitationDataRoundManholeRugs.SelectedValue = manholeRehabilitationManholeDetailsGateway.GetManholeRugs(assetId).ToString();
                }
                else
                {
                    ddlRehabilitationDataRoundManholeRugs.SelectedIndex = 1;
                }

                // ... ... Totals
                tbxRehabilitationDataRoundTotalDepth.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetTotalDepth(assetId)));
                lblRoundTotalDepthLabel.Text = tbxRehabilitationDataRoundTotalDepth.Text;
                tbxRehabilitationDataRoundTotalSurfaceArea.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetTotalSurfaceArea(assetId)));
                lblRoundTotalSurfaceArea.Text = tbxRehabilitationDataRoundTotalSurfaceArea.Text;

                // ... Rectangular Shape
                // ... ... Rectangular 1
                tbxRehabilitationDataRectangle1LongSide.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetRectangle1LongSide(assetId)));
                lblRectangular1LongSideLabel.Text = tbxRehabilitationDataRectangle1LongSide.Text;
                tbxRehabilitationDataRectangle1ShortSide.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetRectangle1ShortSide(assetId)));
                lblRectangular1ShortSideLabel.Text = tbxRehabilitationDataRectangle1ShortSide.Text;
                tbxRehabilitationDataRectangle1Depth.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetTopDepth(assetId)));
                lblRectangular1DephtLabel.Text = tbxRehabilitationDataRectangle1Depth.Text;

                ckbxRehabilitationDataRectangle1Floor.Checked = false;
                tbxRehabilitationDataRectangle1Floor.Text = "";
                if (manholeRehabilitationManholeDetailsGateway.GetTopFloor(assetId) != "")
                {
                    ckbxRehabilitationDataRectangle1Floor.Checked = true;
                    tbxRehabilitationDataRectangle1Floor.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetTopFloor(assetId)));
                }

                ckbxRehabilitationDataRectangle1Ceiling.Checked = false;
                tbxRehabilitationDataRectangle1Ceiling.Text = "";
                if (manholeRehabilitationManholeDetailsGateway.GetTopCeiling(assetId) != "")
                {
                    ckbxRehabilitationDataRectangle1Ceiling.Checked = true;
                    tbxRehabilitationDataRectangle1Ceiling.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetTopCeiling(assetId)));
                    lblRectangular1CeilingLabel.Text = tbxRehabilitationDataRectangle1Ceiling.Text;
                }

                ckbxRehabilitationDataRectangle1Benching.Checked = false;
                tbxRehabilitationDataRectangle1Benching.Text = "";
                if (manholeRehabilitationManholeDetailsGateway.GetTopBenching(assetId) != "")
                {
                    ckbxRehabilitationDataRectangle1Benching.Checked = true;
                    tbxRehabilitationDataRectangle1Benching.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetTopBenching(assetId)));
                }

                tbxRehabilitationDataRectangle1SurfaceArea.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetTopSurfaceArea(assetId)));
                lblRectangle1SurfaceAreaLabel.Text = tbxRehabilitationDataRectangle1SurfaceArea.Text;

                // ... ... Rectangular 2
                tbxRehabilitationDataRectangle2LongSide.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetRectangle2LongSide(assetId)));
                lblRectangle2LongSideLabel.Text = tbxRehabilitationDataRectangle2LongSide.Text;
                tbxRehabilitationDataRectangle2ShortSide.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetRectangle2ShortSide(assetId)));
                lblRectangular2ShortSideLabel.Text = tbxRehabilitationDataRectangle2ShortSide.Text;
                tbxRehabilitationDataRectangle2Depth.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetDownDepth(assetId)));
                lblRectangular2Depth.Text = tbxRehabilitationDataRectangle2Depth.Text;

                ckbxRehabilitationDataRectangle2Floor.Checked = false;
                tbxRehabilitationDataRectangle2Floor.Text = "";
                if (manholeRehabilitationManholeDetailsGateway.GetDownFloor(assetId) != "")
                {
                    ckbxRehabilitationDataRectangle2Floor.Checked = true;
                    tbxRehabilitationDataRectangle2Floor.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetDownFloor(assetId)));
                }

                ckbxRehabilitationDataRectangle2Ceiling.Checked = false;
                tbxRehabilitationDataRectangle2Ceiling.Text = "";
                if (manholeRehabilitationManholeDetailsGateway.GetDownCeiling(assetId) != "")
                {
                    ckbxRehabilitationDataRectangle2Ceiling.Checked = true;
                    tbxRehabilitationDataRectangle2Ceiling.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetDownCeiling(assetId)));
                    lblRectangular2CeilingLabel.Text = tbxRehabilitationDataRectangle2Ceiling.Text;
                }

                ckbxRehabilitationDataRectangle2Benching.Checked = false;
                tbxRehabilitationDataRectangle2Benching.Text = "";
                if (manholeRehabilitationManholeDetailsGateway.GetDownBenching(assetId) != "")
                {
                    ckbxRehabilitationDataRectangle2Benching.Checked = true;
                    tbxRehabilitationDataRectangle2Benching.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetDownBenching(assetId)));
                }

                tbxRehabilitationDataRectangle2SurfaceArea.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetDownSurfaceArea(assetId)));
                lblRectangle2SurfaceAreaLabel.Text = tbxRehabilitationDataRectangle2SurfaceArea.Text;

                if (manholeRehabilitationManholeDetailsGateway.GetManholeRugs(assetId).HasValue)
                {
                    ddlRehabilitationDataRectangularManholeRugs.SelectedValue = manholeRehabilitationManholeDetailsGateway.GetManholeRugs(assetId).ToString();
                }
                else
                {
                    ddlRehabilitationDataRectangularManholeRugs.SelectedIndex = 1;
                }

                // ... ... Totals
                tbxRehabilitationDataRectangularTotalDepth.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetTotalDepth(assetId)));
                lblRectangularTotalDepthLabel.Text = tbxRehabilitationDataRectangularTotalDepth.Text;
                tbxRehabilitationDataRectangularTotalSurfaceArea.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetTotalSurfaceArea(assetId)));
                lblRectangularTotalSurfaceAreaLabel.Text = tbxRehabilitationDataRectangularTotalSurfaceArea.Text;

                // ... Mix Shape
                // ... ... Top
                tbxRehabilitationDataRoundDiameter.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetTopDiameter(assetId)));
                lblDataRoundDiameterLabel.Text = tbxRehabilitationDataRoundDiameter.Text;
                tbxRehabilitationDataRoundDepth.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetTopDepth(assetId)));
                lblDataRoundDepthLabel.Text = tbxRehabilitationDataRoundDepth.Text;

                ckbxRehabilitationDataRoundFloor.Checked = false;
                tbxRehabilitationDataRoundFloor.Text = "";
                if (manholeRehabilitationManholeDetailsGateway.GetTopFloor(assetId) != "")
                {
                    ckbxRehabilitationDataRoundFloor.Checked = true;
                    tbxRehabilitationDataRoundFloor.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetTopFloor(assetId)));
                }

                ckbxRehabilitationDataRoundCeiling.Checked = false;
                tbxRehabilitationDataRoundCeiling.Text = "";
                if (manholeRehabilitationManholeDetailsGateway.GetTopCeiling(assetId) != "")
                {
                    ckbxRehabilitationDataRoundCeiling.Checked = true;
                    tbxRehabilitationDataRoundCeiling.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetTopCeiling(assetId)));
                    lblDataRoundCeilingLabel.Text = tbxRehabilitationDataRoundCeiling.Text;
                }

                ckbxRehabilitationDataRoundBenching.Checked = false;
                tbxRehabilitationDataRoundBenching.Text = "";
                if (manholeRehabilitationManholeDetailsGateway.GetTopBenching(assetId) != "")
                {
                    ckbxRehabilitationDataRoundBenching.Checked = true;
                    tbxRehabilitationDataRoundBenching.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetTopBenching(assetId)));
                }

                tbxRehabilitationDataRoundSurfaceArea.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetTopSurfaceArea(assetId)));
                lblDataRoundSurfaceAreaLabel.Text = tbxRehabilitationDataRoundSurfaceArea.Text;

                // ... ... Down
                tbxRehabilitationDataRectangleLongSide.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetRectangle2LongSide(assetId)));
                lblRectangleLongSideLabel.Text = tbxRehabilitationDataRectangleLongSide.Text;
                tbxRehabilitationDataRectangleShortSide.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetRectangle2ShortSide(assetId)));
                lblRectangleShortSideLabel.Text = tbxRehabilitationDataRectangleShortSide.Text;
                tbxRehabilitationDataRectangleDepth.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetDownDepth(assetId)));
                lblRectangleDephtLabel.Text = tbxRehabilitationDataRectangleDepth.Text;

                ckbxRehabilitationDataRectangleFloor.Checked = false;
                tbxRehabilitationDataRectangleFloor.Text = "";
                if (manholeRehabilitationManholeDetailsGateway.GetDownFloor(assetId) != "")
                {
                    ckbxRehabilitationDataRectangleFloor.Checked = true;
                    tbxRehabilitationDataRectangleFloor.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetDownFloor(assetId)));
                }

                ckbxRehabilitationDataRectangleCeiling.Checked = false;
                tbxRehabilitationDataRectangleCeiling.Text = "";
                if (manholeRehabilitationManholeDetailsGateway.GetDownCeiling(assetId) != "")
                {
                    ckbxRehabilitationDataRectangleCeiling.Checked = true;
                    tbxRehabilitationDataRectangleCeiling.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetDownCeiling(assetId)));
                    lblRectangleCeilingLabel.Text = tbxRehabilitationDataRectangleCeiling.Text;
                }

                ckbxRehabilitationDataRectangleBenching.Checked = false;
                tbxRehabilitationDataRectangleBenching.Text = "";
                if (manholeRehabilitationManholeDetailsGateway.GetDownBenching(assetId) != "")
                {
                    ckbxRehabilitationDataRectangleBenching.Checked = true;
                    tbxRehabilitationDataRectangleBenching.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetDownBenching(assetId)));
                }

                tbxRehabilitationDataRectangleSufaceArea.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetDownSurfaceArea(assetId)));
                lblRectangleSurfaceAreaLabel.Text = tbxRehabilitationDataRectangleSufaceArea.Text;

                if (manholeRehabilitationManholeDetailsGateway.GetManholeRugs(assetId).HasValue)
                {
                    ddlRehabilitationDataMixManholeRugs.SelectedValue = manholeRehabilitationManholeDetailsGateway.GetManholeRugs(assetId).ToString();
                }
                else
                {
                    ddlRehabilitationDataMixManholeRugs.SelectedIndex = 1;
                }

                // ... ... Totals
                tbxRehabilitationDataMixedTotalDepth.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetTotalDepth(assetId)));
                lblMixedTotalDepthLabel.Text = tbxRehabilitationDataMixedTotalDepth.Text;
                tbxRehabilitationDataMixedTotalSurfaceArea.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetTotalSurfaceArea(assetId)));
                lblTotalMixedSurfaceAreaLabel.Text = tbxRehabilitationDataMixedTotalSurfaceArea.Text;

                // ... Other shape
                tbxRehabilitationDataOtherStructure.Text = GetDistance(new Distance(manholeRehabilitationManholeDetailsGateway.GetTotalSurfaceArea(assetId)));                
            }
        }



        private void LoadManholeStructureDataForChange(int assetId)
        {
            ManholeRehabilitationManholeDetailsGateway manholeRehabilitationManholeDetailsGateway = new ManholeRehabilitationManholeDetailsGateway(manholeRehabilitationTDS);
            if (manholeRehabilitationManholeDetailsGateway.Table.Rows.Count > 0)
            {
                // Load manhole structure information   
                if (hdfSavedShape.Value == ddlShape.SelectedValue)
                {
                    LoadManholeStructureData(assetId);
                }
                else
                {
                    // ... Round shape
                    // ... ... Chimney                
                    tbxRehabilitationDataChimneyDiameter.Text = "";
                    tbxRehabilitationDataChimneyDepth.Text = "";
                    ckbxRehabilitationDataChimneyFloor.Checked = false;
                    tbxRehabilitationDataChimneyFloor.Text = "";
                    ckbxRehabilitationDataChimneyCeiling.Checked = false;
                    tbxRehabilitationDataChimneyCeiling.Text = "";
                    ckbxRehabilitationDataChimneyBenching.Checked = false;
                    tbxRehabilitationDataChimneyBenching.Text = "";
                    tbxRehabilitationDataChimneySurfaceArea.Text = "";

                    // ... ... Barrel
                    tbxRehabilitationDataBarrelDiameter.Text = "";
                    tbxRehabilitationDataBarrelDepth.Text = "";
                    ckbxRehabilitationDataBarrelFloor.Checked = false;
                    tbxRehabilitationDataBarrelFloor.Text = "";
                    ckbxRehabilitationDataBarrelCeiling.Checked = false;
                    tbxRehabilitationDataBarrelCeiling.Text = "";
                    ckbxRehabilitationDataBarrelBenching.Checked = false;
                    tbxRehabilitationDataBarrelBenching.Text = "";
                    tbxRehabilitationDataBarrelSurfaceArea.Text = "";
                    ddlRehabilitationDataRoundManholeRugs.SelectedIndex = 1;

                    // ... ... Totals
                    tbxRehabilitationDataRoundTotalDepth.Text = "";
                    tbxRehabilitationDataRoundTotalSurfaceArea.Text = "";

                    // ... Rectangular Shape
                    // ... ... Rectangular 1
                    tbxRehabilitationDataRectangle1LongSide.Text = "";
                    tbxRehabilitationDataRectangle1ShortSide.Text = "";
                    tbxRehabilitationDataRectangle1Depth.Text = "";
                    ckbxRehabilitationDataRectangle1Floor.Checked = false;
                    tbxRehabilitationDataRectangle1Floor.Text = "";
                    ckbxRehabilitationDataRectangle1Ceiling.Checked = false;
                    tbxRehabilitationDataRectangle1Ceiling.Text = "";
                    ckbxRehabilitationDataRectangle1Benching.Checked = false;
                    tbxRehabilitationDataRectangle1Benching.Text = "";
                    tbxRehabilitationDataRectangle1SurfaceArea.Text = "";

                    // ... ... Rectangular 2
                    tbxRehabilitationDataRectangle2LongSide.Text = "";
                    tbxRehabilitationDataRectangle2ShortSide.Text = "";
                    tbxRehabilitationDataRectangle2Depth.Text = "";
                    ckbxRehabilitationDataRectangle2Floor.Checked = false;
                    tbxRehabilitationDataRectangle2Floor.Text = "";
                    ckbxRehabilitationDataRectangle2Ceiling.Checked = false;
                    tbxRehabilitationDataRectangle2Ceiling.Text = "";
                    ckbxRehabilitationDataRectangle2Benching.Checked = false;
                    tbxRehabilitationDataRectangle2Benching.Text = "";
                    tbxRehabilitationDataRectangle2SurfaceArea.Text = "";
                    ddlRehabilitationDataRectangularManholeRugs.SelectedIndex = 1;

                    // ... ... Totals
                    tbxRehabilitationDataRectangularTotalDepth.Text = "";
                    tbxRehabilitationDataRectangularTotalSurfaceArea.Text = "";

                    // ... Mix Shape
                    // ... ... Top
                    tbxRehabilitationDataRoundDiameter.Text = "";
                    tbxRehabilitationDataRoundDepth.Text = "";
                    ckbxRehabilitationDataRoundFloor.Checked = false;
                    tbxRehabilitationDataRoundFloor.Text = "";
                    ckbxRehabilitationDataRoundCeiling.Checked = false;
                    tbxRehabilitationDataRoundCeiling.Text = "";
                    ckbxRehabilitationDataRoundBenching.Checked = false;
                    tbxRehabilitationDataRoundBenching.Text = "";
                    tbxRehabilitationDataRoundSurfaceArea.Text = "";

                    // ... ... Down
                    tbxRehabilitationDataRectangleLongSide.Text = "";
                    tbxRehabilitationDataRectangleShortSide.Text = "";
                    tbxRehabilitationDataRectangleDepth.Text = "";
                    ckbxRehabilitationDataRectangleFloor.Checked = false;
                    tbxRehabilitationDataRectangleFloor.Text = "";
                    ckbxRehabilitationDataRectangleCeiling.Checked = false;
                    tbxRehabilitationDataRectangleCeiling.Text = "";
                    ckbxRehabilitationDataRectangleBenching.Checked = false;
                    tbxRehabilitationDataRectangleBenching.Text = "";
                    tbxRehabilitationDataRectangleSufaceArea.Text = "";
                    ddlRehabilitationDataMixManholeRugs.SelectedIndex = 1;

                    // ... ... Totals
                    tbxRehabilitationDataMixedTotalDepth.Text = "";
                    tbxRehabilitationDataMixedTotalSurfaceArea.Text = "";

                    // ... Other shape
                    tbxRehabilitationDataOtherStructure.Text = "";

                    // ... graphic
                    lblRoudChimneyDiameterLabel.Text = "";
                    lblRoudChimneyCeilingLabel.Text = "";
                    lblRoudChimneyDepthLabel.Text = "";
                    lblRoundChimneySurfaceAreaLabel.Text = "";
                    lblRoundTotalDepthLabel.Text = "";
                    lblRoundBarrelCeilingLabel.Text = "";
                    lblRoudBarrelDepthLabel.Text = "";
                    lblRoundBarrelSurfaceAreaLabel.Text = "";
                    lblRoudBarrelDiameterLabel.Text = "";
                    lblRoundTotalSurfaceArea.Text = "";

                    lblRectangular1ShortSideLabel.Text = "";
                    lblRectangular1CeilingLabel.Text = "";
                    lblRectangular1LongSideLabel.Text = "";
                    lblRectangle1SurfaceAreaLabel.Text = "";
                    lblRectangular1DephtLabel.Text = "";
                    lblRectangularTotalDepthLabel.Text = "";
                    lblRectangular2CeilingLabel.Text = "";
                    lblRectangular2Depth.Text = "";
                    lblRectangle2LongSideLabel.Text = "";
                    lblRectangle2SurfaceAreaLabel.Text = "";
                    lblRectangular2ShortSideLabel.Text = "";
                    lblRectangularTotalSurfaceAreaLabel.Text = "";

                    lblRectangleShortSideLabel.Text = "";
                    lblRectangleCeilingLabel.Text = "";
                    lblRectangleLongSideLabel.Text = "";
                    lblRectangleSurfaceAreaLabel.Text = "";
                    lblRectangleDephtLabel.Text = "";
                    lblMixedTotalDepthLabel.Text = "";
                    lblDataRoundCeilingLabel.Text = "";
                    lblDataRoundDepthLabel.Text = "";
                    lblDataRoundSurfaceAreaLabel.Text = "";
                    lblDataRoundDiameterLabel.Text = "";
                    lblTotalMixedSurfaceAreaLabel.Text = "";
                }
            }
        }



        private void LoadWorkData(int workId, int assetId)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);

            if (workId != 0)
            {
                ManholeRehabilitationWorkDetailsGateway manholeRehabilitationWorkDetailsGateway = new ManholeRehabilitationWorkDetailsGateway(manholeRehabilitationTDS);
                if (manholeRehabilitationWorkDetailsGateway.Table.Rows.Count > 0)
                {
                    if (manholeRehabilitationWorkDetailsGateway.GetPreppedDate(workId).HasValue)
                    {
                        DateTime preppedDate = (DateTime)manholeRehabilitationWorkDetailsGateway.GetPreppedDate(workId);
                        tkrdpRehabilitationPreppedDate.SelectedDate = DateTime.Parse(preppedDate.Month.ToString() + "/" + preppedDate.Day.ToString() + "/" + preppedDate.Year.ToString());
                    }

                    if (manholeRehabilitationWorkDetailsGateway.GetSprayedDate(workId).HasValue)
                    {
                        DateTime sprayedDate = (DateTime)manholeRehabilitationWorkDetailsGateway.GetSprayedDate(workId);
                        tkrdpRehabilitationSprayedDate.SelectedDate = DateTime.Parse(sprayedDate.Month.ToString() + "/" + sprayedDate.Day.ToString() + "/" + sprayedDate.Year.ToString());
                    }

                    if (manholeRehabilitationWorkDetailsGateway.GetDate(workId).HasValue)
                    {
                        //Load saved batch
                        int batchId = (manholeRehabilitationWorkDetailsGateway.GetBatchID(workId));
                        ddlRehabilitationBatchDate.SelectedValue = batchId.ToString();
                        hdfExistBatchId.Value = "True";
                        hdfBatchId.Value = batchId.ToString();
                    }
                    else
                    {
                        ddlRehabilitationBatchDate.SelectedValue = "0";
                        hdfExistBatchId.Value = "False";
                    }

                    // Show Comments                
                    tbxCommentsDataComments.Text = manholeRehabilitationWorkDetailsGateway.GetComments(workId);

                    // ... ... Store datasets
                    Session["manholeRehabilitationTDS"] = manholeRehabilitationTDS;
                }               
            }
             
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
                tbxLastRehabilitationBatchDate.Text = batchDate.Month.ToString() + "/" + batchDate.Day.ToString() + "/" + batchDate.Year.ToString();
                lblBatchDateRequired.Visible = false;

                // ... ... Store datasets
                Session["manholeRehabilitationTDS"] = manholeRehabilitationTDS;
            }
            else
            {
                lblBatchDateRequired.Visible = true;
            }
        }

        #endregion



        private void Save()
        {
            // Validate data
            bool validData = true;

            validData = ValidatePage();

            if (validData)
            {               
                // Save data
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int assetId = Int32.Parse(hdfAssetId.Value);
                int workId = Int32.Parse(hdfWorkId.Value);
                int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());

                // Get Manhole information
                // ... ManholeRehabilitationManholeDetails data
                string newAddress = ""; if (tbxStreet.Text != "") newAddress = tbxStreet.Text.Trim();
                string newLatitude = ""; if (tbxLatitude.Text != "") newLatitude = tbxLatitude.Text.Trim();
                string newLongitude = ""; if (tbxLongitude.Text != "") newLongitude = tbxLongitude.Text.Trim();
                string newShape = ""; if (ddlShape.SelectedValue != "") newShape = ddlShape.SelectedValue;
                int? newConditionRating = null; if (ddlConditioningRating.SelectedValue != "-1") newConditionRating = int.Parse(ddlConditioningRating.SelectedValue);
                int? newMaterialId = null; if (ddlMaterial.SelectedValue != "-1") newMaterialId = int.Parse(ddlMaterial.SelectedValue);
                string newMaterialDescription = ""; if (ddlMaterial.SelectedValue != "") newMaterialDescription = ddlMaterial.Text;
                string newLocation = ""; if (ddlLocation.SelectedValue != "") newLocation = ddlLocation.SelectedValue;
                                      
                string newTopDiameter = "";  
                string newTopDepth = ""; 
                string newTopFloor = "";   
                string newTopCeiling = "";  
                string newTopBenching = "";   
                string newDownDiameter = "";   
                string newDownDepth = "";   
                string newDownFloor = "";   
                string newDownCeiling = "";  
                string newDownBenching = "";  
                string newRectangle1LongSide = "";  
                string newRectangle1ShortSide = "";   
                string newRectangle2LongSide = "";   
                string newRectangle2ShortSide = "";   
                string newTopSurfaceArea = "";  
                string newDownSurfaceArea = "";   
                int? newManholeRugs = null;  
                string newTotalDepth = "";    
                string newTotalSurfaceArea = "";   
                
                // ... Structure Details
                if (newShape == "Round")
                {
                    if (tbxRehabilitationDataChimneyDiameter.Text != "") newTopDiameter = tbxRehabilitationDataChimneyDiameter.Text.Trim();
                    if (tbxRehabilitationDataChimneyDepth.Text != "") newTopDepth = tbxRehabilitationDataChimneyDepth.Text.Trim();
                    if (tbxRehabilitationDataChimneyFloor.Text != "") newTopFloor = tbxRehabilitationDataChimneyFloor.Text.Trim();
                    if (tbxRehabilitationDataChimneyCeiling.Text != "") newTopCeiling = tbxRehabilitationDataChimneyCeiling.Text.Trim();
                    if (tbxRehabilitationDataChimneyBenching.Text != "") newTopBenching = tbxRehabilitationDataChimneyBenching.Text.Trim();
                    if (tbxRehabilitationDataChimneySurfaceArea.Text != "") newTopSurfaceArea = tbxRehabilitationDataChimneySurfaceArea.Text.Trim();

                    if (tbxRehabilitationDataBarrelDiameter.Text != "") newDownDiameter = tbxRehabilitationDataBarrelDiameter.Text.Trim();
                    if (tbxRehabilitationDataBarrelDepth.Text != "") newDownDepth = tbxRehabilitationDataBarrelDepth.Text.Trim();
                    if (tbxRehabilitationDataBarrelFloor.Text != "") newDownFloor = tbxRehabilitationDataBarrelFloor.Text.Trim();
                    if (tbxRehabilitationDataBarrelCeiling.Text != "") newDownCeiling = tbxRehabilitationDataBarrelCeiling.Text.Trim();
                    if (tbxRehabilitationDataBarrelBenching.Text != "") newDownBenching = tbxRehabilitationDataBarrelBenching.Text.Trim();
                    if (tbxRehabilitationDataBarrelSurfaceArea.Text !="") newDownSurfaceArea = tbxRehabilitationDataBarrelSurfaceArea.Text.Trim();

                    if (ddlRehabilitationDataRoundManholeRugs.SelectedValue != "-1")  newManholeRugs = int.Parse( ddlRehabilitationDataRoundManholeRugs.SelectedValue);
                    if (tbxRehabilitationDataRoundTotalDepth.Text != "") newTotalDepth = tbxRehabilitationDataRoundTotalDepth.Text.Trim();    
                    if (tbxRehabilitationDataRoundTotalSurfaceArea.Text !="") newTotalSurfaceArea = tbxRehabilitationDataRoundTotalSurfaceArea.Text.Trim();   
                }

                if (newShape == "Rectangular")
                {
                    if (tbxRehabilitationDataRectangle1LongSide.Text != "") newRectangle1LongSide = tbxRehabilitationDataRectangle1LongSide.Text.Trim();
                    if (tbxRehabilitationDataRectangle1ShortSide.Text != "") newRectangle1ShortSide = tbxRehabilitationDataRectangle1ShortSide.Text.Trim();
                    if (tbxRehabilitationDataRectangle1Depth.Text !="") newTopDepth = tbxRehabilitationDataRectangle1Depth.Text.Trim();
                    if (tbxRehabilitationDataRectangle1Floor.Text !="") newTopFloor = tbxRehabilitationDataRectangle1Floor.Text.Trim();
                    if (tbxRehabilitationDataRectangle1Ceiling.Text !="") newTopCeiling = tbxRehabilitationDataRectangle1Ceiling.Text.Trim();
                    if (tbxRehabilitationDataRectangle1Benching.Text !="")newTopBenching = tbxRehabilitationDataRectangle1Benching.Text.Trim();
                    if (tbxRehabilitationDataRectangle1SurfaceArea.Text != "")  newTopSurfaceArea = tbxRehabilitationDataRectangle1SurfaceArea.Text.Trim();

                    if (tbxRehabilitationDataRectangle2LongSide.Text != "") newRectangle2LongSide = tbxRehabilitationDataRectangle2LongSide.Text.Trim();
                    if (tbxRehabilitationDataRectangle2ShortSide.Text != "") newRectangle2ShortSide = tbxRehabilitationDataRectangle2ShortSide.Text.Trim();
                    if (tbxRehabilitationDataRectangle2Depth.Text !="") newDownDepth = tbxRehabilitationDataRectangle2Depth.Text.Trim();
                    if (tbxRehabilitationDataRectangle2Floor.Text !="") newDownFloor = tbxRehabilitationDataRectangle2Floor.Text.Trim();
                    if (tbxRehabilitationDataRectangle2Ceiling.Text !="") newDownCeiling = tbxRehabilitationDataRectangle2Ceiling.Text.Trim();
                    if (tbxRehabilitationDataRectangle2Benching.Text != "") newDownBenching = tbxRehabilitationDataRectangle2Benching.Text.Trim();
                    if (tbxRehabilitationDataRectangle2SurfaceArea.Text != "")  newDownSurfaceArea = tbxRehabilitationDataRectangle2SurfaceArea.Text.Trim();
                    
                    if (ddlRehabilitationDataRectangularManholeRugs.SelectedValue != "-1")  newManholeRugs = int.Parse( ddlRehabilitationDataRectangularManholeRugs.SelectedValue);
                    if (tbxRehabilitationDataRectangularTotalDepth.Text != "") newTotalDepth = tbxRehabilitationDataRectangularTotalDepth.Text.Trim();    
                    if (tbxRehabilitationDataRectangularTotalSurfaceArea.Text !="") newTotalSurfaceArea = tbxRehabilitationDataRectangularTotalSurfaceArea.Text.Trim();   
                 }
       
                if (newShape == "Mixed")
                {
                    if (tbxRehabilitationDataRoundDiameter.Text != "") newTopDiameter = tbxRehabilitationDataRoundDiameter.Text.Trim();
                    if (tbxRehabilitationDataRoundDepth.Text != "") newTopDepth = tbxRehabilitationDataRoundDepth.Text.Trim();
                    if (tbxRehabilitationDataRoundFloor.Text != "") newTopFloor = tbxRehabilitationDataRoundFloor.Text.Trim();
                    if (tbxRehabilitationDataRoundCeiling.Text != "") newTopCeiling = tbxRehabilitationDataRoundCeiling.Text.Trim();
                    if (tbxRehabilitationDataRoundBenching.Text != "") newTopBenching = tbxRehabilitationDataRoundBenching.Text.Trim();
                    if (tbxRehabilitationDataRoundSurfaceArea.Text != "") newTopSurfaceArea = tbxRehabilitationDataRoundSurfaceArea.Text.Trim();

                    if (tbxRehabilitationDataRectangleLongSide.Text != "") newRectangle2LongSide = tbxRehabilitationDataRectangleLongSide.Text.Trim();
                    if (tbxRehabilitationDataRectangleShortSide.Text != "") newRectangle2ShortSide = tbxRehabilitationDataRectangleShortSide.Text.Trim();
                    if (tbxRehabilitationDataRectangleDepth.Text != "") newDownDepth = tbxRehabilitationDataRectangleDepth.Text.Trim();
                    if (tbxRehabilitationDataRectangleFloor.Text != "") newDownFloor = tbxRehabilitationDataRectangleFloor.Text.Trim();
                    if (tbxRehabilitationDataRectangleCeiling.Text != "") newDownCeiling = tbxRehabilitationDataRectangleCeiling.Text.Trim();
                    if (tbxRehabilitationDataRectangleBenching.Text != "") newDownBenching = tbxRehabilitationDataRectangleBenching.Text.Trim();
                    if (tbxRehabilitationDataRectangleSufaceArea.Text != "") newDownSurfaceArea = tbxRehabilitationDataRectangleSufaceArea.Text.Trim();

                    if (ddlRehabilitationDataMixManholeRugs.SelectedValue != "-1") newManholeRugs = int.Parse(ddlRehabilitationDataMixManholeRugs.SelectedValue);
                    if (tbxRehabilitationDataMixedTotalDepth.Text != "") newTotalDepth = tbxRehabilitationDataMixedTotalDepth.Text.Trim();
                    if (tbxRehabilitationDataMixedTotalSurfaceArea.Text != "") newTotalSurfaceArea = tbxRehabilitationDataMixedTotalSurfaceArea.Text.Trim();   
                 }

                if (newShape == "Other")
                {
                    if (tbxRehabilitationDataOtherStructure.Text !="") newTotalSurfaceArea = tbxRehabilitationDataOtherStructure.Text.Trim();   
                }

                // Update manhole details
                ManholeRehabilitationManholeDetails manholeRehabilitationManholeDetails = new ManholeRehabilitationManholeDetails(manholeRehabilitationTDS);
                manholeRehabilitationManholeDetails.Update(assetId, newLongitude, newLatitude, newAddress, newShape, newLocation, newMaterialId, newTopDiameter, newTopDepth, newTopFloor, newTopCeiling, newTopBenching, newDownDiameter, newDownDepth, newDownFloor, newDownCeiling, newDownBenching, newRectangle1LongSide, newRectangle1ShortSide, newRectangle2LongSide, newRectangle2ShortSide, newTopSurfaceArea, newDownSurfaceArea, newManholeRugs, newTotalDepth, newTotalSurfaceArea, newConditionRating, newMaterialDescription);

                // Get manhole work inforamtion
                DateTime? newPreppedDate = null; if (tkrdpRehabilitationPreppedDate.SelectedDate.HasValue) newPreppedDate = (DateTime)tkrdpRehabilitationPreppedDate.SelectedDate;
                DateTime? newSprayedDate = null; if (tkrdpRehabilitationSprayedDate.SelectedDate.HasValue) newSprayedDate = (DateTime)tkrdpRehabilitationSprayedDate.SelectedDate;

                int newBatchId = Int32.Parse(ddlRehabilitationBatchDate.SelectedValue);//TODO MH
                MrBatchVerificationGateway mrBatchVerificationGateway = new MrBatchVerificationGateway();
                mrBatchVerificationGateway.LoadByBatchId(newBatchId, companyId);
                DateTime newBatchDate = mrBatchVerificationGateway.GetDate(newBatchId);

                hdfBatchId.Value = newBatchId.ToString();

                // ... Update work details
                ManholeRehabilitationWorkDetails manholeRehabilitationWorkDetails = new ManholeRehabilitationWorkDetails(manholeRehabilitationTDS);
                manholeRehabilitationWorkDetails.Update(workId, newPreppedDate, newSprayedDate, newBatchId , newBatchDate, companyId);
                               
                // Store datasets
                Session["manholeRehabilitationTDS"] = manholeRehabilitationTDS;

                // Update database
                UpdateDatabase();

                ViewState["update"] = "yes";

                // Redirect
                string url = "";
                if (Request.QueryString["source_page"] == "mr_navigator2.aspx")
                {
                    url = "./mr_navigator2.aspx?source_page=mr_edit.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&in_project=" + hdfInProject.Value + GetNavigatorState() + "&update=yes";
                }

                if (Request.QueryString["source_page"] == "mr_summary.aspx")
                {
                    string activeTab = hdfActiveTab.Value;
                    url = "./mr_summary.aspx?source_page=mr_edit.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + hdfAssetId.Value + "&in_project=" + hdfInProject.Value + "&active_tab=" + activeTab + GetNavigatorState() + "&update=yes";
                }
                Response.Redirect(url);
            }
        }



        private void Save2()
        {
            //Save changes without validate
                
            // Save data
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int assetId = Int32.Parse(hdfAssetId.Value);
            int workId = Int32.Parse(hdfWorkId.Value);
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());

            // Get Manhole information
            // ... ManholeRehabilitationManholeDetails data
            string newAddress = ""; if (tbxStreet.Text != "") newAddress = tbxStreet.Text.Trim();
            string newLatitude = ""; if (tbxLatitude.Text != "") newLatitude = tbxLatitude.Text.Trim();
            string newLongitude = ""; if (tbxLongitude.Text != "") newLongitude = tbxLongitude.Text.Trim();
            string newShape = ""; if (ddlShape.SelectedValue != "") newShape = ddlShape.SelectedValue;
            int? newConditionRating = null; if (ddlConditioningRating.SelectedValue != "-1") newConditionRating = int.Parse(ddlConditioningRating.SelectedValue);
            int? newMaterialId = null; if (ddlMaterial.SelectedValue != "-1") newMaterialId = int.Parse(ddlMaterial.SelectedValue);
            string newMaterialDescription = ""; if (ddlMaterial.Text != "") newMaterialDescription = ddlMaterial.Text;
            string newLocation = ""; if (ddlLocation.SelectedValue != "") newLocation = ddlLocation.SelectedValue;

            string newTopDiameter = "";
            string newTopDepth = "";
            string newTopFloor = "";
            string newTopCeiling = "";
            string newTopBenching = "";
            string newDownDiameter = "";
            string newDownDepth = "";
            string newDownFloor = "";
            string newDownCeiling = "";
            string newDownBenching = "";
            string newRectangle1LongSide = "";
            string newRectangle1ShortSide = "";
            string newRectangle2LongSide = "";
            string newRectangle2ShortSide = "";
            string newTopSurfaceArea = "";
            string newDownSurfaceArea = "";
            int? newManholeRugs = null;
            string newTotalDepth = "";
            string newTotalSurfaceArea = "";

            // ... Structure Details
            if (newShape == "Round")
            {
                if (tbxRehabilitationDataChimneyDiameter.Text != "") newTopDiameter = tbxRehabilitationDataChimneyDiameter.Text.Trim();
                if (tbxRehabilitationDataChimneyDepth.Text != "") newTopDepth = tbxRehabilitationDataChimneyDepth.Text.Trim();
                if (tbxRehabilitationDataChimneyFloor.Text != "") newTopFloor = tbxRehabilitationDataChimneyFloor.Text.Trim();
                if (tbxRehabilitationDataChimneyCeiling.Text != "") newTopCeiling = tbxRehabilitationDataChimneyCeiling.Text.Trim();
                if (tbxRehabilitationDataChimneyBenching.Text != "") newTopBenching = tbxRehabilitationDataChimneyBenching.Text.Trim();
                if (tbxRehabilitationDataChimneySurfaceArea.Text != "") newTopSurfaceArea = tbxRehabilitationDataChimneySurfaceArea.Text.Trim();

                if (tbxRehabilitationDataBarrelDiameter.Text != "") newDownDiameter = tbxRehabilitationDataBarrelDiameter.Text.Trim();
                if (tbxRehabilitationDataBarrelDepth.Text != "") newDownDepth = tbxRehabilitationDataBarrelDepth.Text.Trim();
                if (tbxRehabilitationDataBarrelFloor.Text != "") newDownFloor = tbxRehabilitationDataBarrelFloor.Text.Trim();
                if (tbxRehabilitationDataBarrelCeiling.Text != "") newDownCeiling = tbxRehabilitationDataBarrelCeiling.Text.Trim();
                if (tbxRehabilitationDataBarrelBenching.Text != "") newDownBenching = tbxRehabilitationDataBarrelBenching.Text.Trim();
                if (tbxRehabilitationDataBarrelSurfaceArea.Text != "") newDownSurfaceArea = tbxRehabilitationDataBarrelSurfaceArea.Text.Trim();

                if (ddlRehabilitationDataRoundManholeRugs.SelectedValue != "-1") newManholeRugs = int.Parse(ddlRehabilitationDataRoundManholeRugs.SelectedValue);
                if (tbxRehabilitationDataRoundTotalDepth.Text != "") newTotalDepth = tbxRehabilitationDataRoundTotalDepth.Text.Trim();
                if (tbxRehabilitationDataRoundTotalSurfaceArea.Text != "") newTotalSurfaceArea = tbxRehabilitationDataRoundTotalSurfaceArea.Text.Trim();
            }

            if (newShape == "Rectangular")
            {
                if (tbxRehabilitationDataRectangle1LongSide.Text != "") newRectangle1LongSide = tbxRehabilitationDataRectangle1LongSide.Text.Trim();
                if (tbxRehabilitationDataRectangle1ShortSide.Text != "") newRectangle1ShortSide = tbxRehabilitationDataRectangle1ShortSide.Text.Trim();
                if (tbxRehabilitationDataRectangle1Depth.Text != "") newTopDepth = tbxRehabilitationDataRectangle1Depth.Text.Trim();
                if (tbxRehabilitationDataRectangle1Floor.Text != "") newTopFloor = tbxRehabilitationDataRectangle1Floor.Text.Trim();
                if (tbxRehabilitationDataRectangle1Ceiling.Text != "") newTopCeiling = tbxRehabilitationDataRectangle1Ceiling.Text.Trim();
                if (tbxRehabilitationDataRectangle1Benching.Text != "") newTopBenching = tbxRehabilitationDataRectangle1Benching.Text.Trim();
                if (tbxRehabilitationDataRectangle1SurfaceArea.Text != "") newTopSurfaceArea = tbxRehabilitationDataRectangle1SurfaceArea.Text.Trim();

                if (tbxRehabilitationDataRectangle2LongSide.Text != "") newRectangle2LongSide = tbxRehabilitationDataRectangle2LongSide.Text.Trim();
                if (tbxRehabilitationDataRectangle2ShortSide.Text != "") newRectangle2ShortSide = tbxRehabilitationDataRectangle2ShortSide.Text.Trim();
                if (tbxRehabilitationDataRectangle2Depth.Text != "") newDownDepth = tbxRehabilitationDataRectangle2Depth.Text.Trim();
                if (tbxRehabilitationDataRectangle2Floor.Text != "") newDownFloor = tbxRehabilitationDataRectangle2Floor.Text.Trim();
                if (tbxRehabilitationDataRectangle2Ceiling.Text != "") newDownCeiling = tbxRehabilitationDataRectangle2Ceiling.Text.Trim();
                if (tbxRehabilitationDataRectangle2Benching.Text != "") newDownBenching = tbxRehabilitationDataRectangle2Benching.Text.Trim();
                if (tbxRehabilitationDataRectangle2SurfaceArea.Text != "") newDownSurfaceArea = tbxRehabilitationDataRectangle2SurfaceArea.Text.Trim();

                if (ddlRehabilitationDataRectangularManholeRugs.SelectedValue != "-1") newManholeRugs = int.Parse(ddlRehabilitationDataRectangularManholeRugs.SelectedValue);
                if (tbxRehabilitationDataRectangularTotalDepth.Text != "") newTotalDepth = tbxRehabilitationDataRectangularTotalDepth.Text.Trim();
                if (tbxRehabilitationDataRectangularTotalSurfaceArea.Text != "") newTotalSurfaceArea = tbxRehabilitationDataRectangularTotalSurfaceArea.Text.Trim();
            }

            if (newShape == "Mixed")
            {
                if (tbxRehabilitationDataRoundDiameter.Text != "") newTopDiameter = tbxRehabilitationDataRoundDiameter.Text.Trim();
                if (tbxRehabilitationDataRoundDepth.Text != "") newTopDepth = tbxRehabilitationDataRoundDepth.Text.Trim();
                if (tbxRehabilitationDataRoundFloor.Text != "") newTopFloor = tbxRehabilitationDataRoundFloor.Text.Trim();
                if (tbxRehabilitationDataRoundCeiling.Text != "") newTopCeiling = tbxRehabilitationDataRoundCeiling.Text.Trim();
                if (tbxRehabilitationDataRoundBenching.Text != "") newTopBenching = tbxRehabilitationDataRoundBenching.Text.Trim();
                if (tbxRehabilitationDataRoundSurfaceArea.Text != "") newTopSurfaceArea = tbxRehabilitationDataRoundSurfaceArea.Text.Trim();

                if (tbxRehabilitationDataRectangleLongSide.Text != "") newRectangle2LongSide = tbxRehabilitationDataRectangleLongSide.Text.Trim();
                if (tbxRehabilitationDataRectangleShortSide.Text != "") newRectangle2ShortSide = tbxRehabilitationDataRectangleShortSide.Text.Trim();
                if (tbxRehabilitationDataRectangleDepth.Text != "") newDownDepth = tbxRehabilitationDataRectangleDepth.Text.Trim();
                if (tbxRehabilitationDataRectangleFloor.Text != "") newDownFloor = tbxRehabilitationDataRectangleFloor.Text.Trim();
                if (tbxRehabilitationDataRectangleCeiling.Text != "") newDownCeiling = tbxRehabilitationDataRectangleCeiling.Text.Trim();
                if (tbxRehabilitationDataRectangleBenching.Text != "") newDownBenching = tbxRehabilitationDataRectangleBenching.Text.Trim();
                if (tbxRehabilitationDataRectangleSufaceArea.Text != "") newDownSurfaceArea = tbxRehabilitationDataRectangleSufaceArea.Text.Trim();

                if (ddlRehabilitationDataMixManholeRugs.SelectedValue != "-1") newManholeRugs = int.Parse(ddlRehabilitationDataRectangularManholeRugs.SelectedValue);
                if (tbxRehabilitationDataRectangularTotalDepth.Text != "") newTotalDepth = tbxRehabilitationDataRectangularTotalDepth.Text.Trim();
                if (tbxRehabilitationDataRectangularTotalSurfaceArea.Text != "") newTotalSurfaceArea = tbxRehabilitationDataRectangularTotalSurfaceArea.Text.Trim();
            }

            if (newShape == "Other")
            {
                if (tbxRehabilitationDataOtherStructure.Text != "") newTotalSurfaceArea = tbxRehabilitationDataOtherStructure.Text.Trim();
            }

            // Update manhole details
            ManholeRehabilitationManholeDetails manholeRehabilitationManholeDetails = new ManholeRehabilitationManholeDetails(manholeRehabilitationTDS);
            manholeRehabilitationManholeDetails.Update(assetId, newLongitude, newLatitude, newAddress, newShape, newLocation, newMaterialId, newTopDiameter, newTopDepth, newTopFloor, newTopCeiling, newTopBenching, newDownDiameter, newDownDepth, newDownFloor, newDownCeiling, newDownBenching, newRectangle1LongSide, newRectangle1ShortSide, newRectangle2LongSide, newRectangle2ShortSide, newTopSurfaceArea, newDownSurfaceArea, newManholeRugs, newTotalDepth, newTotalSurfaceArea, newConditionRating, newMaterialDescription);

            // Get manhole work inforamtion
            DateTime? newPreppedDate = null; if (tkrdpRehabilitationPreppedDate.SelectedDate.HasValue) newPreppedDate = (DateTime)tkrdpRehabilitationPreppedDate.SelectedDate;
            DateTime? newSprayedDate = null; if (tkrdpRehabilitationSprayedDate.SelectedDate.HasValue) newSprayedDate = (DateTime)tkrdpRehabilitationSprayedDate.SelectedDate;

            int newBatchId = Int32.Parse(ddlRehabilitationBatchDate.SelectedValue);///TODO MH
            MrBatchVerificationGateway mrBatchVerificationGateway = new MrBatchVerificationGateway();
            mrBatchVerificationGateway.LoadByBatchId(newBatchId, companyId);
            DateTime newBatchDate = mrBatchVerificationGateway.GetDate(newBatchId);

            hdfBatchId.Value = newBatchId.ToString();

            // ... Update work details
            ManholeRehabilitationWorkDetails manholeRehabilitationWorkDetails = new ManholeRehabilitationWorkDetails(manholeRehabilitationTDS);
            manholeRehabilitationWorkDetails.Update(workId, newPreppedDate, newSprayedDate, newBatchId, newBatchDate, companyId);

            // Store datasets
            Session["manholeRehabilitationTDS"] = manholeRehabilitationTDS;

            ViewState["update"] = "no";
        }



        private bool Apply()
        {
            // Validate data
            bool validData = true;
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int assetId = Int32.Parse(hdfAssetId.Value);
            int workId = Int32.Parse(hdfWorkId.Value);
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());

            validData = ValidatePage();

            if (validData)
            {
                // Get Manhole information
                // ... ManholeRehabilitationManholeDetails data
                string newAddress = ""; if (tbxStreet.Text != "") newAddress = tbxStreet.Text.Trim();
                string newLatitude = ""; if (tbxLatitude.Text != "") newLatitude = tbxLatitude.Text.Trim();
                string newLongitude = ""; if (tbxLongitude.Text != "") newLongitude = tbxLongitude.Text.Trim();
                string newShape = ""; if (ddlShape.SelectedValue != "") newShape = ddlShape.SelectedValue;
                int? newConditionRating = null; if (ddlConditioningRating.SelectedValue != "-1") newConditionRating = int.Parse(ddlConditioningRating.SelectedValue);
                int? newMaterialId = null; if (ddlMaterial.SelectedValue != "-1") newMaterialId = int.Parse(ddlMaterial.SelectedValue);
                string newMaterialDescription = ""; if (ddlMaterial.Text != "") newMaterialDescription = ddlMaterial.Text;
                string newLocation = ""; if (ddlLocation.SelectedValue != "") newLocation = ddlLocation.SelectedValue;

                string newTopDiameter = "";
                string newTopDepth = "";
                string newTopFloor = "";
                string newTopCeiling = "";
                string newTopBenching = "";
                string newDownDiameter = "";
                string newDownDepth = "";
                string newDownFloor = "";
                string newDownCeiling = "";
                string newDownBenching = "";
                string newRectangle1LongSide = "";
                string newRectangle1ShortSide = "";
                string newRectangle2LongSide = "";
                string newRectangle2ShortSide = "";
                string newTopSurfaceArea = "";
                string newDownSurfaceArea = "";
                int? newManholeRugs = null;
                string newTotalDepth = "";
                string newTotalSurfaceArea = "";

                // ... Structure Details
                if (newShape == "Round")
                {
                    if (tbxRehabilitationDataChimneyDiameter.Text != "") newTopDiameter = tbxRehabilitationDataChimneyDiameter.Text.Trim();
                    if (tbxRehabilitationDataChimneyDepth.Text != "") newTopDepth = tbxRehabilitationDataChimneyDepth.Text.Trim();
                    if (tbxRehabilitationDataChimneyFloor.Text != "") newTopFloor = tbxRehabilitationDataChimneyFloor.Text.Trim();
                    if (tbxRehabilitationDataChimneyCeiling.Text != "") newTopCeiling = tbxRehabilitationDataChimneyCeiling.Text.Trim();
                    if (tbxRehabilitationDataChimneyBenching.Text != "") newTopBenching = tbxRehabilitationDataChimneyBenching.Text.Trim();
                    if (tbxRehabilitationDataChimneySurfaceArea.Text != "") newTopSurfaceArea = tbxRehabilitationDataChimneySurfaceArea.Text.Trim();

                    if (tbxRehabilitationDataBarrelDiameter.Text != "") newDownDiameter = tbxRehabilitationDataBarrelDiameter.Text.Trim();
                    if (tbxRehabilitationDataBarrelDepth.Text != "") newDownDepth = tbxRehabilitationDataBarrelDepth.Text.Trim();
                    if (tbxRehabilitationDataBarrelFloor.Text != "") newDownFloor = tbxRehabilitationDataBarrelFloor.Text.Trim();
                    if (tbxRehabilitationDataBarrelCeiling.Text != "") newDownCeiling = tbxRehabilitationDataBarrelCeiling.Text.Trim();
                    if (tbxRehabilitationDataBarrelBenching.Text != "") newDownBenching = tbxRehabilitationDataBarrelBenching.Text.Trim();
                    if (tbxRehabilitationDataBarrelSurfaceArea.Text != "") newDownSurfaceArea = tbxRehabilitationDataBarrelSurfaceArea.Text.Trim();

                    if (ddlRehabilitationDataRoundManholeRugs.SelectedValue != "-1") newManholeRugs = int.Parse(ddlRehabilitationDataRoundManholeRugs.SelectedValue);
                    if (tbxRehabilitationDataRoundTotalDepth.Text != "") newTotalDepth = tbxRehabilitationDataRoundTotalDepth.Text.Trim();
                    if (tbxRehabilitationDataRoundTotalSurfaceArea.Text != "") newTotalSurfaceArea = tbxRehabilitationDataRoundTotalSurfaceArea.Text.Trim();
                }

                if (newShape == "Rectangular")
                {
                    if (tbxRehabilitationDataRectangle1LongSide.Text != "") newRectangle1LongSide = tbxRehabilitationDataRectangle1LongSide.Text.Trim();
                    if (tbxRehabilitationDataRectangle1ShortSide.Text != "") newRectangle1ShortSide = tbxRehabilitationDataRectangle1ShortSide.Text.Trim();
                    if (tbxRehabilitationDataRectangle1Depth.Text != "") newTopDepth = tbxRehabilitationDataRectangle1Depth.Text.Trim();
                    if (tbxRehabilitationDataRectangle1Floor.Text != "") newTopFloor = tbxRehabilitationDataRectangle1Floor.Text.Trim();
                    if (tbxRehabilitationDataRectangle1Ceiling.Text != "") newTopCeiling = tbxRehabilitationDataRectangle1Ceiling.Text.Trim();
                    if (tbxRehabilitationDataRectangle1Benching.Text != "") newTopBenching = tbxRehabilitationDataRectangle1Benching.Text.Trim();
                    if (tbxRehabilitationDataRectangle1SurfaceArea.Text != "") newTopSurfaceArea = tbxRehabilitationDataRectangle1SurfaceArea.Text.Trim();

                    if (tbxRehabilitationDataRectangle2LongSide.Text != "") newRectangle2LongSide = tbxRehabilitationDataRectangle2LongSide.Text.Trim();
                    if (tbxRehabilitationDataRectangle2ShortSide.Text != "") newRectangle2ShortSide = tbxRehabilitationDataRectangle2ShortSide.Text.Trim();
                    if (tbxRehabilitationDataRectangle2Depth.Text != "") newDownDepth = tbxRehabilitationDataRectangle2Depth.Text.Trim();
                    if (tbxRehabilitationDataRectangle2Floor.Text != "") newDownFloor = tbxRehabilitationDataRectangle2Floor.Text.Trim();
                    if (tbxRehabilitationDataRectangle2Ceiling.Text != "") newDownCeiling = tbxRehabilitationDataRectangle2Ceiling.Text.Trim();
                    if (tbxRehabilitationDataRectangle2Benching.Text != "") newDownBenching = tbxRehabilitationDataRectangle2Benching.Text.Trim();
                    if (tbxRehabilitationDataRectangle2SurfaceArea.Text != "") newDownSurfaceArea = tbxRehabilitationDataRectangle2SurfaceArea.Text.Trim();

                    if (ddlRehabilitationDataRectangularManholeRugs.SelectedValue != "-1") newManholeRugs = int.Parse(ddlRehabilitationDataRectangularManholeRugs.SelectedValue);
                    if (tbxRehabilitationDataRectangularTotalDepth.Text != "") newTotalDepth = tbxRehabilitationDataRectangularTotalDepth.Text.Trim();
                    if (tbxRehabilitationDataRectangularTotalSurfaceArea.Text != "") newTotalSurfaceArea = tbxRehabilitationDataRectangularTotalSurfaceArea.Text.Trim();
                }

                if (newShape == "Mixed")
                {
                    if (tbxRehabilitationDataRoundDiameter.Text != "") newTopDiameter = tbxRehabilitationDataRoundDiameter.Text.Trim();
                    if (tbxRehabilitationDataRoundDepth.Text != "") newTopDepth = tbxRehabilitationDataRoundDepth.Text.Trim();
                    if (tbxRehabilitationDataRoundFloor.Text != "") newTopFloor = tbxRehabilitationDataRoundFloor.Text.Trim();
                    if (tbxRehabilitationDataRoundCeiling.Text != "") newTopCeiling = tbxRehabilitationDataRoundCeiling.Text.Trim();
                    if (tbxRehabilitationDataRoundBenching.Text != "") newTopBenching = tbxRehabilitationDataRoundBenching.Text.Trim();
                    if (tbxRehabilitationDataRoundSurfaceArea.Text != "") newTopSurfaceArea = tbxRehabilitationDataRoundSurfaceArea.Text.Trim();

                    if (tbxRehabilitationDataRectangleLongSide.Text != "") newRectangle2LongSide = tbxRehabilitationDataRectangleLongSide.Text.Trim();
                    if (tbxRehabilitationDataRectangleShortSide.Text != "") newRectangle2ShortSide = tbxRehabilitationDataRectangleShortSide.Text.Trim();
                    if (tbxRehabilitationDataRectangleDepth.Text != "") newDownDepth = tbxRehabilitationDataRectangleDepth.Text.Trim();
                    if (tbxRehabilitationDataRectangleFloor.Text != "") newDownFloor = tbxRehabilitationDataRectangleFloor.Text.Trim();
                    if (tbxRehabilitationDataRectangleCeiling.Text != "") newDownCeiling = tbxRehabilitationDataRectangleCeiling.Text.Trim();
                    if (tbxRehabilitationDataRectangleBenching.Text != "") newDownBenching = tbxRehabilitationDataRectangleBenching.Text.Trim();
                    if (tbxRehabilitationDataRectangleSufaceArea.Text != "") newDownSurfaceArea = tbxRehabilitationDataRectangleSufaceArea.Text.Trim();

                    if (ddlRehabilitationDataMixManholeRugs.SelectedValue != "-1") newManholeRugs = int.Parse(ddlRehabilitationDataRectangularManholeRugs.SelectedValue);
                    if (tbxRehabilitationDataRectangularTotalDepth.Text != "") newTotalDepth = tbxRehabilitationDataRectangularTotalDepth.Text.Trim();
                    if (tbxRehabilitationDataRectangularTotalSurfaceArea.Text != "") newTotalSurfaceArea = tbxRehabilitationDataRectangularTotalSurfaceArea.Text.Trim();
                }

                if (newShape == "Other")
                {
                    if (tbxRehabilitationDataOtherStructure.Text != "") newTotalSurfaceArea = tbxRehabilitationDataOtherStructure.Text.Trim();
                }

                // Update manhole details
                ManholeRehabilitationManholeDetails manholeRehabilitationManholeDetails = new ManholeRehabilitationManholeDetails(manholeRehabilitationTDS);
                manholeRehabilitationManholeDetails.Update(assetId, newLongitude, newLatitude, newAddress, newShape, newLocation, newMaterialId, newTopDiameter, newTopDepth, newTopFloor, newTopCeiling, newTopBenching, newDownDiameter, newDownDepth, newDownFloor, newDownCeiling, newDownBenching, newRectangle1LongSide, newRectangle1ShortSide, newRectangle2LongSide, newRectangle2ShortSide, newTopSurfaceArea, newDownSurfaceArea, newManholeRugs, newTotalDepth, newTotalSurfaceArea, newConditionRating, newMaterialDescription);

                // Get manhole work inforamtion
                DateTime? newPreppedDate = null; if (tkrdpRehabilitationPreppedDate.SelectedDate.HasValue) newPreppedDate = (DateTime)tkrdpRehabilitationPreppedDate.SelectedDate;
                DateTime? newSprayedDate = null; if (tkrdpRehabilitationSprayedDate.SelectedDate.HasValue) newSprayedDate = (DateTime)tkrdpRehabilitationSprayedDate.SelectedDate;

                int newBatchId = Int32.Parse(ddlRehabilitationBatchDate.SelectedValue);//TODO MH
                MrBatchVerificationGateway mrBatchVerificationGateway = new MrBatchVerificationGateway();
                mrBatchVerificationGateway.LoadByBatchId(newBatchId, companyId);
                DateTime newBatchDate = mrBatchVerificationGateway.GetDate(newBatchId);

                hdfBatchId.Value = newBatchId.ToString();

                // ... Update work details
                ManholeRehabilitationWorkDetails manholeRehabilitationWorkDetails = new ManholeRehabilitationWorkDetails(manholeRehabilitationTDS);
                manholeRehabilitationWorkDetails.Update(workId, newPreppedDate, newSprayedDate, newBatchId, newBatchDate, companyId);

                // Store datasets
                Session["manholeRehabilitationTDS"] = manholeRehabilitationTDS;

                // Update database
                workId = UpdateDatabase();
                hdfWorkId.Value = workId.ToString();

                ManholeRehabilitationManholeDetails manholeRehabilitationManholeDetails2 = new ManholeRehabilitationManholeDetails(manholeRehabilitationTDS);
                manholeRehabilitationManholeDetails2.LoadByAssetId(assetId, companyId);

                ManholeRehabilitationWorkDetails fullLengthLiningWorkDetails = new ManholeRehabilitationWorkDetails(manholeRehabilitationTDS);
                fullLengthLiningWorkDetails.LoadByWorkIdAssetId(workId, assetId, companyId);

                // Restore datasets
                manholeRehabilitationTDS = (ManholeRehabilitationTDS)Session["manholeRehabilitationTDS"];

                // ... Store dataset
                Session["manholeRehabilitationTDS"] = manholeRehabilitationTDS;

                ViewState["update"] = "yes";
            }

            return validData;
        }



        private bool ValidatePage()
        {
            bool validData = true;

            // Validate general data
            Page.Validate("rehabilitationData");

            if (Page.IsValid)
            {
                if (ddlShape.SelectedValue == "Round")
                {
                    // Validate info
                    Page.Validate("mrRoundChimneyDiameter");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }

                    Page.Validate("mrRoundChimneyDepth");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }

                    Page.Validate("mrRoundBarrelDiameter");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }

                    Page.Validate("mrRoundBarrelDepth");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }
                }

                if (ddlShape.SelectedValue == "Rentangular")
                {
                    // Validate info
                    Page.Validate("mrRectangle1LongSide");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }

                    Page.Validate("mrRectangle1ShortSide");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }

                    Page.Validate("mrRectangle1Depth");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }

                    Page.Validate("mrRectangle2LongSide");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }

                    Page.Validate("mrRectangle2ShortSide");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }

                    Page.Validate("mrRectangle2Depth");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }
                }

                if (ddlShape.SelectedValue == "Mixed")
                {
                    // Validate info
                    Page.Validate("mrRoundDiameter");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }

                    Page.Validate("mrRoundDepth");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }

                    Page.Validate("mrRectangleLongSide");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }

                    Page.Validate("mRectangleShortSide");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }

                    Page.Validate("mrRectangleDepth");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }
                }

                if (ddlShape.SelectedValue == "Other")
                {
                    // Validate info
                    Page.Validate("mrOtherStructure");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }
                }
            }
            else
            {
                // If it's not valid
                validData = false;
            }

            // Show error message
            if (validData)
            {
                // If it's valid
                lblMissingData.Visible = false;
            }
            else
            {
                lblMissingData.Visible = true;
                string errorText = "Invalid or missing data. Please check";
                lblMissingData.Text = errorText + hdfErrorFieldList.Value.ToString();
            }

            return validData;
        }



        private int UpdateDatabase()
        {
            // Get ids & location
            int projectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            Int64? countryId = null;
            Int64? provinceId = null;
            Int64? countyId = null;
            Int64? cityId = null; 

            if (projectGateway.Table.Rows.Count > 0)
            {
                // ... Get ids
                try
                {//TODO MH
                    countryId = projectGateway.GetCountryID(projectId);
                }
                catch
                {
                }
                if (projectGateway.GetProvinceID(projectId).HasValue) provinceId = (Int64)projectGateway.GetProvinceID(projectId);
                if (projectGateway.GetCountyID(projectId).HasValue) countyId = (Int64)projectGateway.GetCountyID(projectId);
                if (projectGateway.GetCityID(projectId).HasValue) cityId = (Int64)projectGateway.GetCityID(projectId);
            }
            
            string workType = hdfWorkType.Value.Trim();
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int workId = Int32.Parse(hdfWorkId.Value);
            int assetId = Int32.Parse(hdfAssetId.Value);
            bool inProject = bool.Parse(hdfInProject.Value);

            DB.Open();
            DB.BeginTransaction();
            try
            {
                // Save section details
                ManholeRehabilitationManholeDetails manholeRehabilitationManholeDetails = new ManholeRehabilitationManholeDetails(manholeRehabilitationTDS);
                manholeRehabilitationManholeDetails.Save(countryId, provinceId, countyId, cityId, projectId, companyId);

                // Save work details
                ManholeRehabilitationWorkDetails fullLengthLiningWorkDetails = new ManholeRehabilitationWorkDetails(manholeRehabilitationTDS);
                workId = fullLengthLiningWorkDetails.Save(countryId, provinceId, countyId, cityId, projectId, assetId, companyId, inProject);               

                DB.CommitTransaction();

                // Store datasets
                manholeRehabilitationTDS.AcceptChanges();
                Session["manholeRehabilitationTDS"] = manholeRehabilitationTDS;
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }

            return workId;
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



        protected string GetDistance(object distance)
        {
            if (distance != DBNull.Value)
            {
                Distance distanceInch = new Distance(distance.ToString());
                return distanceInch.ToStringInEng3();
            }
            else
            {
                return "";
            }
        }



        void ShapeStructure()
        {           
            switch (ddlShape.SelectedValue)
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

        

        

        

        

        

        

    }
}
