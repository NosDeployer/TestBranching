using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.CWP.PointRepairs;
using LiquiForce.LFSLive.BL.CWP.PointRepairs;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.BL.Assets.Assets;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.Tools;
using LiquiForce.LFSLive.Server;
using Telerik.Web.UI;  

namespace LiquiForce.LFSLive.WebUI.CWP.PointRepairs
{
    /// <summary>
    /// pr_edit
    /// </summary>
    public partial class pr_edit : System.Web.UI.Page
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
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["client_id"] == null) || ((string)Request.QueryString["project_id"] == null) || ((string)Request.QueryString["asset_id"] == null) || ((string)Request.QueryString["active_tab"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in pr_edit.aspx");
                }

                // Tag Page
                TagPage();

                // If coming from 
                int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
                int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());
                int assetId = Int32.Parse(hdfAssetId.Value.Trim());
                string workType = hdfWorkType.Value;
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

                    Session["filterExpression"] = "Deleted = 0";

                    // Store dataset
                    Session["pointRepairsTDS"] = pointRepairsTDS;
                    Session["pointRepairsRepairsTemp"] = pointRepairsRepairsTemp;
                    Session["pointRepairsCommentsTemp"] = pointRepairsCommentsTemp;
                }

                // ... pr_summary.aspx or pr_edit.aspx 
                if ((Request.QueryString["source_page"] == "pr_summary.aspx") || (Request.QueryString["source_page"] == "pr_edit.aspx"))
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

                    if (ViewState["update"].ToString().Trim() == "yes")
                    {
                        PointRepairsSectionDetails pointRepairsSectionDetails = new PointRepairsSectionDetails(pointRepairsTDS);
                        pointRepairsSectionDetails.LoadByWorkId(workId, companyId);

                        PointRepairsWorkDetails pointRepairsWorkDetails = new PointRepairsWorkDetails(pointRepairsTDS);
                        pointRepairsWorkDetails.LoadByWorkIdAssetId(workId, assetId, companyId);

                        PointRepairsRepairDetails pointRepairsRepairDetails = new PointRepairsRepairDetails(pointRepairsTDS);
                        pointRepairsRepairDetails.LoadAllByWorkId(workId, companyId);

                        PointRepairsCommentDetails pointRepairsCommentDetails = new PointRepairsCommentDetails(pointRepairsTDS);
                        pointRepairsCommentDetails.LoadAllByWorkIdWorkType(workId, companyId, "Point Repairs");

                        Session["filterExpression"] = "Deleted = 0";

                        // Store dataset
                        Session["pointRepairsTDS"] = pointRepairsTDS;
                        Session["pointRepairsRepairsTemp"] = pointRepairsRepairsTemp;
                        Session["pointRepairsCommentsTemp"] = pointRepairsCommentsTemp;
                    }

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
                // Set initial tab
                int activeTab = Int32.Parse(hdfActiveTab.Value);
                tcPrDetails.ActiveTabIndex = activeTab;

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

                // For usmh, dsmh autocomplete
                string provinceId_ = "0"; if (hdfProvinceId.Value != "") provinceId_ = hdfProvinceId.Value;
                string countyId_ = "0"; if (hdfCountyId.Value != "") countyId_ = hdfCountyId.Value;
                string cityId_ = "0"; if (hdfCityId.Value != "") cityId_ = hdfCityId.Value;

                aceUsmh.ContextKey = hdfCountryId.Value + "," + provinceId_ + "," + countyId_ + "," + cityId_ + "," + hdfCompanyId.Value;
                aceDsmh.ContextKey = hdfCountryId.Value + "," + provinceId_ + "," + countyId_ + "," + cityId_ + "," + hdfCompanyId.Value;                
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



        protected void grdRepairs_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Repair Gridview, if the gridview is edition mode
            if (grdRepairs.EditIndex >= 0)
            {
                grdRepairs.UpdateRow(grdRepairs.EditIndex, true);
            }

            // Delete repairs
            int workId = (int)e.Keys["WorkID"];
            string repairPointId = e.Keys["RepairPointID"].ToString();

            PointRepairsRepairDetails model = new PointRepairsRepairDetails(pointRepairsTDS);

            // Delete repair
            model.Delete(workId, repairPointId);

            // Store dataset
            Session["pointRepairsTDS"] = pointRepairsTDS;
        }



        protected void grdRepairs_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Add")
            {
                // Repair Gridview, if the gridview is edition mode
                if (grdRepairs.EditIndex >= 0)
                {
                    grdRepairs.UpdateRow(grdRepairs.EditIndex, true);
                }

                // Add New Repair
                GrdRepairsAdd();
                mForm8 master = (mForm8)this.Master;
                ScriptManager scriptManager = (ScriptManager)master.FindControl("ScriptManagerMaster8");
                scriptManager.SetFocus(grdRepairs.FooterRow.FindControl("tbxRmCommentsNew"));
            }
        }



        protected void grdRepairs_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("repairsDataEdit");

            if (Page.IsValid)
            {
                PointRepairsRepairDetails model = new PointRepairsRepairDetails(pointRepairsTDS);

                int workId = (int)e.Keys["WorkID"];
                string repairPointId = e.Keys["RepairPointID"].ToString();
                string type = ((Label)grdRepairs.Rows[e.RowIndex].Cells[2].FindControl("lblRepairType")).Text.Trim();

                switch (type)
                {
                    case "Robotic Reaming":
                        string rmReamDistance = ((TextBox)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("tbxRmReamDistanceEdit")).Text.Trim();
                        DateTime? rmReamDate = null; if (((RadDatePicker)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("tkrdpRmReamDateEdit")).SelectedDate.HasValue) rmReamDate = ((RadDatePicker)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("tkrdpRmReamDateEdit")).SelectedDate.Value;
                        bool rmExtraRepair = ((CheckBox)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("cbxRmExtraRepairEdit")).Checked;
                        bool rmCancelled = ((CheckBox)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("cbxRmCancelledEdit")).Checked;
                        string rmApproval = ((DropDownList)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("ddlRmApprovalEdit")).SelectedValue.ToString().Trim();
                        string rmComments = ((TextBox)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("tbxRmCommentsEdit")).Text.Trim();
                        string rmDefectQualifier = ((DropDownList)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("ddlRmDefectQualifierEdit")).SelectedValue;
                        string rmDefectDetails = ((DropDownList)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("ddlRmDefectDetailsEdit")).SelectedValue;
                        DateTime? rmReinstateDate = null; if (((RadDatePicker)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("tkrdpRmReinstateDateEdit")).SelectedDate.HasValue) rmReinstateDate = ((RadDatePicker)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("tkrdpRmReinstateDateEdit")).SelectedDate.Value;

                        model.UpdateRoboticReaming(workId, repairPointId, rmReamDistance, rmReamDate, rmExtraRepair, rmCancelled, rmApproval, rmComments, rmDefectQualifier, rmDefectDetails, rmReinstateDate);
                        break;

                    case "Point Lining":
                        string plLinerDistance = ((TextBox)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("tbxPlLinerDistanceEdit")).Text.Trim();
                        string plDirection = ((DropDownList)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("ddlPlDirectionEdit")).SelectedValue.ToString().Trim();
                        int? plReinstates = null; if (((TextBox)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("tbxPlReinstatesEdit")).Text.Trim() != "") plReinstates = Int32.Parse(((TextBox)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("tbxPlReinstatesEdit")).Text.Trim());
                        string plLtmh = ((DropDownList)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("ddlPlLtmhEdit")).SelectedValue;
                        string plVtmh = "";
                        if (plLtmh != "")
                        {
                            int selectedIndex = ((DropDownList)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("ddlPlLtmhEdit")).SelectedIndex;

                            if (selectedIndex == 1)
                            {
                                plVtmh = hdfDSMH.Value;
                            }
                            else
                            {
                                plVtmh = hdfUSMH.Value;
                            }
                        }
                        string plDistance = ((TextBox)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("tbxPlDistanceEdit")).Text.Trim();
                        string plSize_ = ((DropDownList)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("ddlPlSize_Edit")).SelectedValue.ToString().Trim();
                        DateTime? plInstallDate = null; if (((RadDatePicker)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("tkrdpPlInstallDateEdit")).SelectedDate.HasValue) plInstallDate = ((RadDatePicker)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("tkrdpPlInstallDateEdit")).SelectedDate.Value;
                        string plMhShot = ((DropDownList)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("ddlPlMhShotEdit")).SelectedValue.ToString().Trim();
                        bool plExtraRepair = ((CheckBox)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("cbxPlExtraRepairEdit")).Checked;
                        bool plCancelled = ((CheckBox)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("cbxPlCancelledEdit")).Checked;
                        string plApproval = ((DropDownList)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("ddlPlAprovalEdit")).SelectedValue.ToString().Trim();
                        string plComments = ((TextBox)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("tbxPlCommentsEdit")).Text.Trim();
                        string plDefectQualifier = ((DropDownList)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("ddlPlDefectQualifierEdit")).SelectedValue;
                        string plDefectDetails = ((DropDownList)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("ddlPlDefectDetailsEdit")).SelectedValue;
                        string plLength = ((DropDownList)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("ddlPlLengthEdit")).SelectedValue.ToString().Trim();
                        DateTime? plReinstateDate = null; if (((RadDatePicker)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("tkrdpPlReinstateDateEdit")).SelectedDate.HasValue) plReinstateDate = ((RadDatePicker)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("tkrdpPlReinstateDateEdit")).SelectedDate.Value;

                        model.UpdatePointLining(workId, repairPointId, plLinerDistance, plDirection, plReinstates, plLtmh, plVtmh, plDistance, plSize_, plInstallDate, plMhShot, plExtraRepair, plCancelled, plApproval, plComments, plDefectQualifier, plDefectDetails, plLength, plReinstateDate);
                        break;

                    case "Grouting":
                        string gtGroutDistance = ((TextBox)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("tbxGtGroutDistanceEdit")).Text.Trim();
                        DateTime? gtInstallDate = null;
                        DateTime? gtGroutDate = null; if (((RadDatePicker)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("tkrdpGtGroutDateEdit")).SelectedDate.HasValue) gtGroutDate = ((RadDatePicker)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("tkrdpGtGroutDateEdit")).SelectedDate.Value;
                        bool gtExtraRepair = ((CheckBox)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("cbxGtExtraRepairEdit")).Checked;
                        bool gtCancelled = ((CheckBox)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("cbxGtCancelledEdit")).Checked;
                        string gtApproval = ((DropDownList)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("ddlGtApprovalEdit")).SelectedValue.ToString().Trim();
                        string gtComments = ((TextBox)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("tbxGtCommentsEdit")).Text.Trim();
                        string gtDefectQualifier = ((DropDownList)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("ddlGtDefectQualifierEdit")).SelectedValue;
                        string gtDefectDetails = ((DropDownList)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("ddlGtDefectDetailsEdit")).SelectedValue;
                        DateTime? gtReinstateDate = null; if (((RadDatePicker)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("tkrdpGtReinstateDateEdit")).SelectedDate.HasValue) gtReinstateDate = ((RadDatePicker)grdRepairs.Rows[e.RowIndex].Cells[3].FindControl("tkrdpGtReinstateDataEdit")).SelectedDate.Value;

                        model.UpdateGrouting(workId, repairPointId, gtGroutDistance, gtInstallDate, gtGroutDate, gtExtraRepair, gtCancelled, gtApproval, gtComments, gtDefectQualifier, gtDefectDetails, gtReinstateDate);
                        break;
                }

                // Store dataset
                Session["pointRepairsTDS"] = pointRepairsTDS;
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdComments_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Comments Gridview, if the gridview is edition mode
            if (grdComments.EditIndex >= 0)
            {
                grdComments.UpdateRow(grdComments.EditIndex, true);
            }

            // Delete comments
            int workId = (int)e.Keys["WorkID"];
            int refId = (int)e.Keys["RefID"];

            PointRepairsCommentDetails model = new PointRepairsCommentDetails(pointRepairsTDS);

            // Delete note
            model.Delete(workId, refId);

            // Store dataset
            Session["pointRepairsTDS"] = pointRepairsTDS;
        }



        protected void grdComments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Comments Gridview, if the gridview is edition mode
                    if (grdComments.EditIndex >= 0)
                    {
                        grdComments.UpdateRow(grdComments.EditIndex, true);
                    }

                    // Add New Comment
                    GrdCommentsAdd();
                    mForm8 master = (mForm8)this.Master;
                    ScriptManager scriptManager = (ScriptManager)master.FindControl("ScriptManagerMaster8");
                    scriptManager.SetFocus(grdComments.FooterRow.FindControl("tbxCommentCommentNew"));
                    break;
            }
        }



        protected void grdComments_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("commentsDataEdit");
            if (Page.IsValid)
            {
                int workId = (int)e.Keys["WorkID"];
                int refId = (int)e.Keys["RefID"];

                string subject = ((TextBox)grdComments.Rows[e.RowIndex].Cells[2].FindControl("tbxCommentSubjectEdit")).Text.Trim();
                string comment = ((TextBox)grdComments.Rows[e.RowIndex].Cells[3].FindControl("tbxCommentCommentEdit")).Text.Trim();

                // Update data
                PointRepairsCommentDetails model = new PointRepairsCommentDetails(pointRepairsTDS);
                model.Update(workId, refId, subject, comment);

                // Store dataset
                Session["pointRepairsTDS"] = pointRepairsTDS;
            }
            else
            {
                e.Cancel = true;
            }
        }
                  

        
        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set active toolbar
            mForm8 master = (mForm8)this.Master;
            master.ActiveToolbar = "eSewers";

            // For error message
            hdfErrorFieldList.Value = "";

            int companyId = Int32.Parse(hdfCompanyId.Value);
            int assetId = Int32.Parse(hdfAssetId.Value);
            int currentProjectId = Int32.Parse(hdfCurrentProjectId.Value.ToString());

            MaterialInformationGateway materialInformationGateway = new MaterialInformationGateway();
            materialInformationGateway.LoadLastMaterialByAssetId(assetId, companyId);

            if (materialInformationGateway.Table.Rows.Count > 0)
            {
                try
                {
                    ddlGeneralDataMaterial.SelectedValue = materialInformationGateway.GetLastMaterialType(assetId);
                }
                catch
                {
                    ddlGeneralDataMaterial.SelectedIndex = 0;
                }
            }                       
            
            if (tbxFlowOrderId.Text == "")
            {
                LoadPointRepairsData(currentProjectId, assetId, companyId);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

       
        protected void cvMapSize_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvDistance = (CustomValidator)source;
                args.IsValid = true;

                // Control of format
                if (!Distance.IsValidDistance(args.Value))
                {
                    cvDistance.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Map Size";                    
                }

                // Control of distance > 0
                if (args.IsValid)
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvDistance.Text = "Invalid distance. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Map Size";
                    }
                }
            }
        }



        protected void cvSize_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvDistance = (CustomValidator)source;
                args.IsValid = true;

                // Control of format
                if (!Distance.IsValidDistance(args.Value))
                {
                    cvDistance.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Size";
                }

                // Control of distance > 0
                if (args.IsValid)
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvDistance.Text = "Invalid distance. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Size";
                    }
                }
            }
        }



        protected void cvVideoLength_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvDistanceFromUsmh = (CustomValidator)source;
                args.IsValid = true;

                // Control of format
                if (!Distance.IsValidDistance(args.Value))
                {
                    cvDistanceFromUsmh.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Video Length";
                }

                // Control of distance > 0
                if (args.IsValid)
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvDistanceFromUsmh.Text = "Invalid distance. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Video Length";
                    }
                }
            }
        }



        protected void cvMapLength_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvDistance = (CustomValidator)source;
                args.IsValid = true;

                // Control of format
                if (!Distance.IsValidDistance(args.Value))
                {
                    cvDistance.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Map Length";
                }

                // Control of distance > 0
                if (args.IsValid)
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvDistance.Text = "Invalid distance. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Map Length";
                    }
                }
            }
        }



        protected void cvSteelTapeThroughSewer_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvDistance = (CustomValidator)source;
                args.IsValid = true;

                // Control of format
                if (!Distance.IsValidDistance(args.Value))
                {
                    cvDistance.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Steel Tape Through Sewer";
                }

                // Control of distance > 0
                if (args.IsValid)
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvDistance.Text = "Invalid distance. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Steel Tape Through Sewer";
                    }
                }
            }
        }



        protected void cvGeneralDataRoboticDistances_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvDistance = (CustomValidator)source;
                args.IsValid = true;

                // Control of format
                if (!Distance.IsValidDistance(args.Value))
                {
                    cvDistance.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Robotic Distances (General Data)";
                }

                // Control of distance > 0
                if (args.IsValid)
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvDistance.Text = "Invalid distance. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Robotic Distances (General Data)";
                    }
                }
            }
        }



        protected void cvDistance_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (args.Value.Trim() != "")
            {
                // Initialize 
                CustomValidator cvDistance = (CustomValidator)source;
                args.IsValid = true;

                // Control of format
                if (!Distance.IsValidDistance(args.Value))
                {
                    cvDistance.Text = "Invalid format. (please use X'Y\", or Xft Yin, or X.Y, or X.Ym, or X.Ymm)";
                    args.IsValid = false;
                    hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Distance";
                }

                // Control of distance > 0
                if (args.IsValid)
                {
                    Distance distance = new Distance(args.Value);
                    if (distance.ToDoubleInEng3() < 0)
                    {
                        cvDistance.Text = "Invalid distance. (must be equal or greater than 0)";
                        args.IsValid = false;
                        hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Distance";
                    }
                }
            }
        }



        protected void cvNoUsmh_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (tbxUSMH.Text == "")
            {
                args.IsValid = false;
                hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", USMH";
            }
            else
            {
                args.IsValid = true;
            }
        }



        protected void cvNoDsmh_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (tbxDSMH.Text == "")
            {
                args.IsValid = false;
                hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", DSMH";
            }
            else
            {
                args.IsValid = true;
            }
        }



        protected void cvValidLength_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int assetId = Int32.Parse(hdfAssetId.Value);
            int companyId = Int32.Parse(hdfCompanyId.Value);
            AssetSewerSection assetSewerSection = new AssetSewerSection();

            if (assetSewerSection.VerifyNewLengthByAssetId(tbxVideoLength.Text, assetId, companyId))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
                hdfErrorFieldList.Value = hdfErrorFieldList.Value + ", Length";
            }
        }



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



        protected void ddlRepairTypeNew_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = grdRepairs.FooterRow;

            Panel pnlRoboticReaming = ((Panel)row.FindControl("pnlRoboticReamingNew"));
            Panel pnlPointLining = ((Panel)row.FindControl("pnlPointLiningNew"));
            Panel pnlGrouting = ((Panel)row.FindControl("pnlGroutingNew"));

            switch (((DropDownList)row.FindControl("ddlRepairTypeNew")).SelectedValue)
            {
                case "Robotic Reaming":
                    pnlRoboticReaming.Visible = true;
                    pnlPointLining.Visible = false;
                    pnlGrouting.Visible = false;
                    break;

                case "Point Lining":
                    pnlRoboticReaming.Visible = false;
                    pnlPointLining.Visible = true;
                    pnlGrouting.Visible = false;
                    break;

                case "Grouting":
                    pnlRoboticReaming.Visible = false;
                    pnlPointLining.Visible = false;
                    pnlGrouting.Visible = true;
                    break;
            }
        }



        protected void grdRepairs_DataBound(object sender, EventArgs e)
        {
            AddRepairsNewEmptyFix(grdRepairs);
        }



        protected void grdRepairs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Control of footer row
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                // For LT @ MH and VT @ MH
                DropDownList ddlPlLtmh = (DropDownList)e.Row.FindControl("ddlPlLtmhNew");
                DropDownList ddlPlVtmh = (DropDownList)e.Row.FindControl("ddlPlVtmhNew");

                ddlPlLtmh.Items.Add("");
                ddlPlLtmh.Items.Add(hdfUSMH.Value);
                ddlPlLtmh.Items.Add(hdfDSMH.Value);
                ddlPlLtmh.SelectedIndex = 0;

                ddlPlVtmh.Items.Add("");
                ddlPlVtmh.Items.Add(hdfUSMH.Value);
                ddlPlVtmh.Items.Add(hdfDSMH.Value);
                ddlPlVtmh.SelectedIndex = 0;
            }

            // Control of edit rows
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                // For LT @ MH and VT @ MH
                DropDownList ddlPlLtmh = (DropDownList)e.Row.FindControl("ddlPlLtmhEdit");
                DropDownList ddlPlVtmh = (DropDownList)e.Row.FindControl("ddlPlVtmhEdit");

                ddlPlLtmh.Items.Add("");
                ddlPlLtmh.Items.Add(hdfUSMH.Value);
                ddlPlLtmh.Items.Add(hdfDSMH.Value);
                ddlPlLtmh.SelectedValue = ((HiddenField)e.Row.FindControl("hdfPlLtmhEdit")).Value;

                ddlPlVtmh.Items.Add("");
                ddlPlVtmh.Items.Add(hdfUSMH.Value);
                ddlPlVtmh.Items.Add(hdfDSMH.Value);
                ddlPlVtmh.SelectedValue = ((HiddenField)e.Row.FindControl("hdfPlVtmhEdit")).Value;

                // For Defect qualifier and defect details
                string repairType = ((Label)e.Row.FindControl("lblRepairType")).Text;
                int workId = Int32.Parse(((Label)e.Row.FindControl("lblWorkID")).Text);
                string repairPointId = ((Label)e.Row.FindControl("lblRepairPointID")).Text;
                
                PointRepairsRepairDetailsGateway pointRepairsRepairDetailsGateway = new PointRepairsRepairDetailsGateway(pointRepairsTDS);                

                switch (repairType)
                {
                    case "Robotic Reaming":
                        ((DropDownList)e.Row.FindControl("ddlRmDefectQualifierEdit")).SelectedValue = pointRepairsRepairDetailsGateway.GetDefectQualifier(workId, repairPointId);
                        ((DropDownList)e.Row.FindControl("ddlRmDefectDetailsEdit")).SelectedValue = pointRepairsRepairDetailsGateway.GetDefectDetails(workId, repairPointId);
                        ((DropDownList)e.Row.FindControl("ddlPlDefectQualifierEdit")).SelectedValue = "";
                        ((DropDownList)e.Row.FindControl("ddlPlDefectDetailsEdit")).SelectedValue = "";
                        ((DropDownList)e.Row.FindControl("ddlGtDefectQualifierEdit")).SelectedValue = "";
                        ((DropDownList)e.Row.FindControl("ddlGtDefectDetailsEdit")).SelectedValue = "";
                        break;

                    case "Point Lining":
                        ((DropDownList)e.Row.FindControl("ddlPlDefectQualifierEdit")).SelectedValue = pointRepairsRepairDetailsGateway.GetDefectQualifier(workId, repairPointId);
                        ((DropDownList)e.Row.FindControl("ddlPlLengthEdit")).SelectedValue = pointRepairsRepairDetailsGateway.GetLength(workId, repairPointId);
                        ((DropDownList)e.Row.FindControl("ddlPlSize_Edit")).SelectedValue = pointRepairsRepairDetailsGateway.GetSize_(workId, repairPointId);
                        ((DropDownList)e.Row.FindControl("ddlPlDefectDetailsEdit")).SelectedValue = pointRepairsRepairDetailsGateway.GetDefectDetails(workId, repairPointId);
                        ((DropDownList)e.Row.FindControl("ddlRmDefectQualifierEdit")).SelectedValue = "";
                        ((DropDownList)e.Row.FindControl("ddlRmDefectDetailsEdit")).SelectedValue = "";
                        ((DropDownList)e.Row.FindControl("ddlGtDefectQualifierEdit")).SelectedValue = "";
                        ((DropDownList)e.Row.FindControl("ddlGtDefectDetailsEdit")).SelectedValue = "";
                        break;

                    case "Grouting":
                        ((DropDownList)e.Row.FindControl("ddlGtDefectQualifierEdit")).SelectedValue = pointRepairsRepairDetailsGateway.GetDefectQualifier(workId, repairPointId);
                        ((DropDownList)e.Row.FindControl("ddlGtDefectDetailsEdit")).SelectedValue = pointRepairsRepairDetailsGateway.GetDefectDetails(workId, repairPointId);
                        ((DropDownList)e.Row.FindControl("ddlRmDefectQualifierEdit")).SelectedValue = "";
                        ((DropDownList)e.Row.FindControl("ddlRmDefectDetailsEdit")).SelectedValue = "";
                        ((DropDownList)e.Row.FindControl("ddlPlDefectQualifierEdit")).SelectedValue = "";
                        ((DropDownList)e.Row.FindControl("ddlPlDefectDetailsEdit")).SelectedValue = "";
                        break;
                }
            }
        }        



        protected void grdRepairs_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Repairs Gridview, if the gridview is edition mode
            if (grdRepairs.EditIndex >= 0)
            {
                grdRepairs.UpdateRow(grdRepairs.EditIndex, true);
            }
        }


        
        protected void grdComments_DataBound(object sender, EventArgs e)
        {
            AddCommentsNewEmptyFix(grdComments);
        }



        protected void grdComments_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Comments Gridview, if the gridview is edition mode
            if (grdComments.EditIndex >= 0)
            {
                grdComments.UpdateRow(grdComments.EditIndex, true);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // NAVIGATION EVENTS
        //

        protected void btnChange_Click(object sender, EventArgs e)
        {
            Response.Redirect("./../Common/select_project.aspx?source_page=pr_edit.aspx&work_type=" + hdfWorkType.Value.Trim());
        }



        protected void tkrmTop_ItemClick(object sender, RadMenuEventArgs e)
        {
            // Store active tab for postback
            Session["activeTabPr"] = "0";
            Session["dialogOpenedPr"] = "0";

            string url = "";
            string activeTab = hdfActiveTab.Value;

            switch (e.Item.Value)
            {
                case "mSave":
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
                    this.Save();                    
                    break;

                case "mApply":
                    this.Apply();
                    break;

                case "mCancel":
                    pointRepairsTDS.RejectChanges();
                    Session["pointRepairsTDS"] = pointRepairsTDS;                    
                    
                    if (Request.QueryString["source_page"] == "pr_navigator2.aspx")
                    {
                        url = "./pr_navigator2.aspx?source_page=pr_edit.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=" + (string)ViewState["update"];
                    }

                    if (Request.QueryString["source_page"] == "pr_summary.aspx")
                    {                        
                        url = "./pr_summary.aspx?source_page=pr_edit.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=yes" + "&asset_id=" + hdfAssetId.Value + "&active_tab=" + activeTab;
                    }

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

                        this.Apply();

                        // Redirect
                        url = "./pr_edit.aspx?source_page=" + Request.QueryString["source_page"] + "&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + previousId.ToString() + "&active_tab=" + activeTab + GetNavigatorState() + "&update=yes";
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

                        this.Apply();

                        // Redirect
                        url = "./pr_edit.aspx?source_page=" + Request.QueryString["source_page"] + "&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + nextId.ToString() + "&active_tab=" + activeTab + GetNavigatorState() + "&update=yes";
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
                    url = "./pr_navigator.aspx?source_page=lm&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&work_type=" + hdfWorkType.Value;
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
            contentVariables += "var hdfWorkIdId = '" + hdfWorkId.ClientID + "';";
            contentVariables += "var hdfWorkTypeId = '" + hdfWorkType.ClientID + "';";
            contentVariables += "var hdfCurrentClientIdId = '" + hdfCurrentClientId.ClientID + "';";
            contentVariables += "var hdfCurrentProjectIdId = '" + hdfCurrentProjectId.ClientID + "';";
            contentVariables += "var hdfActiveTabId = '" + hdfActiveTab.ClientID + "';";
            contentVariables += "var tkrmTopId = '" + tkrmTop.ClientID + "';";  
            
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./pr_edit.js");
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
            hdfWorkType.Value = "Point Repairs";
            hdfAssetId.Value = Request.QueryString["asset_id"].ToString();
            hdfActiveTab.Value = Request.QueryString["active_tab"].ToString();
            hdfErrorFieldList.Value = "";

            // Get ids & location
            int projectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            // Get ids
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
            hdfWorkIdRa.Value = GetWorkId(projectId, assetId, "Rehab Assessment", companyId).ToString();
        }



        private void LoadPointRepairsData(int projectId, int assetId, int companyId)
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
                hdfUSMH.Value = pointRepairsSectionDetailsGateway.GetUsmhDescription(workId);
                tbxUSMHMN.Text = pointRepairsSectionDetailsGateway.GetUsmhAddress(workId);
                tbxDSMH.Text = pointRepairsSectionDetailsGateway.GetDsmhDescription(workId);
                hdfDSMH.Value = pointRepairsSectionDetailsGateway.GetDsmhDescription(workId);
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
                if (pointRepairsWorkDetailsGateway.GetPreFlushDate(workId).HasValue)
                {
                    DateTime preFlushDate = (DateTime)pointRepairsWorkDetailsGateway.GetPreFlushDate(workId);
                    tkrdpGeneralDataPreFlushDate.SelectedDate = (DateTime)pointRepairsWorkDetailsGateway.GetPreFlushDate(workId);
                }

                if (pointRepairsWorkDetailsGateway.GetPreVideoDate(workId).HasValue)
                {
                    DateTime preVideoDate = (DateTime)pointRepairsWorkDetailsGateway.GetPreVideoDate(workId);
                    tkrdpGeneralDataPreVideoDate.SelectedDate = (DateTime)pointRepairsWorkDetailsGateway.GetPreVideoDate(workId);
                }

                // For FLL data
                if (pointRepairsWorkDetailsGateway.GetP1Date(workId).HasValue)
                {
                    DateTime p1Date = (DateTime)pointRepairsWorkDetailsGateway.GetP1Date(workId);
                    tkrdpGeneralDataP1Date.SelectedDate = (DateTime)pointRepairsWorkDetailsGateway.GetP1Date(workId);
                }

                if (pointRepairsWorkDetailsGateway.GetRepairConfirmationDate(workId).HasValue)
                {
                    tkrdpGeneralDataRepairConfirmationDate.SelectedDate = (DateTime)pointRepairsWorkDetailsGateway.GetRepairConfirmationDate(workId);
                }

                // For FLL M1 data
                try
                {
                    ddlGeneralDataTrafficControl.SelectedValue = pointRepairsWorkDetailsGateway.GetTrafficControl(workId);
                }
                catch
                {
                    ddlGeneralDataTrafficControl.SelectedIndex = 0;
                }

                try
                {
                    ddlGeneralDataMaterial.SelectedValue = pointRepairsWorkDetailsGateway.GetMaterial(workId);
                }
                catch
                {
                    ddlGeneralDataMaterial.SelectedIndex = 0;
                }

                // For FLL P1 data
                tbxGeneralDataCXIsRemoved.Text = ""; if (pointRepairsWorkDetailsGateway.GetCxisRemoved(workId).HasValue) tbxGeneralDataCXIsRemoved.Text = pointRepairsWorkDetailsGateway.GetCxisRemoved(workId).ToString();

                ckbxGeneralDataBypassRequired.Checked = pointRepairsWorkDetailsGateway.GetBypassRequired(workId);
                tbxGeneralDataRoboticDistances.Text = pointRepairsWorkDetailsGateway.GetRoboticDistances(workId);
                
                if (pointRepairsWorkDetailsGateway.GetProposedLiningDate(workId).HasValue)
                {
                    tkrdpGeneralDataProposedLiningDate.SelectedDate = (DateTime)pointRepairsWorkDetailsGateway.GetProposedLiningDate(workId);
                }

                if (pointRepairsWorkDetailsGateway.GetDeadlineLiningDate(workId).HasValue)
                {
                    tkrdpGeneralDataDeadlineLiningDate.SelectedDate = (DateTime)pointRepairsWorkDetailsGateway.GetDeadlineLiningDate(workId);
                }

                if (pointRepairsWorkDetailsGateway.GetFinalVideoDate(workId).HasValue)
                {
                    tkrdpGeneralDataFinalVideo.SelectedDate = (DateTime)pointRepairsWorkDetailsGateway.GetFinalVideoDate(workId);
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



        private void Save()
        {
            // Validate data
            bool validData = true;

            validData = ValidatePage();

            if (validData)
            {
                // If the gridview is edition mode
                if (grdRepairs.EditIndex >= 0)
                {
                    grdRepairs.UpdateRow(grdRepairs.EditIndex, true);
                }

                GrdRepairsAdd();

                // Save data
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int assetId = Int32.Parse(hdfAssetId.Value);
                int workId = Int32.Parse(hdfWorkId.Value);
                int workIdRa = Int32.Parse(hdfWorkIdRa.Value);
                int workIdFll = Int32.Parse(hdfWorkIdFll.Value);
                            
                // Get Section Details
                string newStreet = ""; if (tbxStreet.Text != "") newStreet = tbxStreet.Text.Trim();
                string newUsmh = ""; if (tbxUSMH.Text != "") newUsmh = tbxUSMH.Text.Trim();
                string newUsmhAddress = ""; if (tbxUSMHMN.Text != "") newUsmhAddress = tbxUSMHMN.Text.Trim();
                string newDsmh = ""; if (tbxDSMH.Text != "") newDsmh = tbxDSMH.Text.Trim();
                string newDsmhAddress = ""; if (tbxDSMHMN.Text != "") newDsmhAddress = tbxDSMHMN.Text.Trim();
                string newMapSize = ""; if (tbxMapSize.Text != "") newMapSize = tbxMapSize.Text.Trim();
                string newSize = ""; if (tbxConfirmedSize.Text != "") newSize = tbxConfirmedSize.Text.Trim();
                string newMapLength = ""; if (tbxMapLength.Text != "") newMapLength = tbxMapLength.Text.Trim();
                string newSteelTapeThroughSewer = tbxSteelTapeLength.Text.Trim();
                string newVideoLength = ""; if (tbxVideoLength.Text != "") newVideoLength = tbxVideoLength.Text.Trim();
                int? newLaterals = null; if (tbxLaterals.Text != "") newLaterals = Int32.Parse(tbxLaterals.Text.Trim());
                int? newLiveLaterals = null; if (tbxLiveLaterals.Text != "") newLiveLaterals = Int32.Parse(tbxLiveLaterals.Text.Trim());
                string newSubArea = ""; if (tbxGeneralDataSubArea.Text != "") newSubArea = tbxGeneralDataSubArea.Text.Trim();

                // Update section details
                PointRepairsSectionDetails pointRepairsSectionDetails = new PointRepairsSectionDetails(pointRepairsTDS);
                pointRepairsSectionDetails.Update(workId, assetId, newStreet, newMapSize, newSize, newMapLength, newSteelTapeThroughSewer, newLaterals, newLiveLaterals, newSteelTapeThroughSewer, newUsmh, newDsmh, newUsmhAddress, newDsmhAddress, newSubArea);

                // Get Work Details
                string newGeneralClientId = ""; if (tbxGeneralDataClientId.Text != "") newGeneralClientId = tbxGeneralDataClientId.Text.Trim();
                string newMeasurementsTakenBy = ""; if (tbxGeneralDataMeasurementsTakenBy.Text != "") newMeasurementsTakenBy = tbxGeneralDataMeasurementsTakenBy.Text.Trim();
                DateTime? newRepairConfirmationDate = null; if (tkrdpGeneralDataRepairConfirmationDate.SelectedDate.HasValue) newRepairConfirmationDate = tkrdpGeneralDataRepairConfirmationDate.SelectedDate.Value;
                bool newByPassRequired = ckbxGeneralDataBypassRequired.Checked;
                string newRoboticDistances = ""; if (tbxGeneralDataRoboticDistances.Text != "") newRoboticDistances = tbxGeneralDataRoboticDistances.Text.Trim();
                DateTime? newGeneralProposedLiningDate = null; if (tkrdpGeneralDataProposedLiningDate.SelectedDate.HasValue) newGeneralProposedLiningDate = tkrdpGeneralDataProposedLiningDate.SelectedDate.Value;
                DateTime? newGeneralDeadlineLiningDate = null; if (tkrdpGeneralDataDeadlineLiningDate.SelectedDate.HasValue) newGeneralDeadlineLiningDate = tkrdpGeneralDataDeadlineLiningDate.SelectedDate.Value;
                DateTime? newGeneralFinalVideo = null; if (tkrdpGeneralDataFinalVideo.SelectedDate.HasValue) newGeneralFinalVideo = tkrdpGeneralDataFinalVideo.SelectedDate.Value;
                int? newEstimatedJoints = null; if (tbxGeneralDataEstimatedJoints.Text != "") newEstimatedJoints = Int32.Parse(tbxGeneralDataEstimatedJoints.Text.Trim());
                int? newJointsTestSealed = null; if (tbxGeneralDataJointsTestSealed.Text != "") newJointsTestSealed = Int32.Parse(tbxGeneralDataJointsTestSealed.Text.Trim());
                bool newGeneralIssueIdentified = ckbxGeneralDataIssueIdentified.Checked;
                bool newGeneralLfsIssue = ckbxGeneralDataLfsIssue.Checked;
                bool newGeneralClientIssue = ckbxGeneralDataClientIssue.Checked;
                bool newGeneralSalesIssue = ckbxGeneralDataSalesIssue.Checked;
                bool newGeneralIssueGivenToClient = ckbxGeneralDataIssueGivenToClient.Checked;
                bool newGeneralIssueResolved = ckbxGeneralDataIssueResolved.Checked;
                bool newGeneralIssueInvestigation = ckbxGeneralDataIssueInvestigation.Checked;

                // FLL
                // ... P1 Data
                DateTime? newPrepDataP1Date = null; if (tkrdpGeneralDataP1Date.SelectedDate.HasValue) newPrepDataP1Date = tkrdpGeneralDataP1Date.SelectedDate.Value;

                // ... Prep Data
                int? newPrepDataCXIsRemoved = null; if (tbxGeneralDataCXIsRemoved.Text != "") newPrepDataCXIsRemoved = Int32.Parse(tbxGeneralDataCXIsRemoved.Text.Trim());

                // ... M1 Data
                string newTrafficControl = ddlGeneralDataTrafficControl.SelectedValue;

                // RA
                // ... Rehab Assessment Data
                DateTime? newPreFlushDate = null; if (tkrdpGeneralDataPreFlushDate.SelectedDate.HasValue) newPreFlushDate = tkrdpGeneralDataPreFlushDate.SelectedDate.Value;
                DateTime? newPreVideoDate = null; if (tkrdpGeneralDataPreVideoDate.SelectedDate.HasValue) newPreVideoDate = tkrdpGeneralDataPreVideoDate.SelectedDate.Value;

                // Material
                string newMaterial = ddlGeneralDataMaterial.SelectedValue;

                // ... Update work details
                PointRepairsWorkDetails pointRepairsWorkDetails = new PointRepairsWorkDetails(pointRepairsTDS);
                pointRepairsWorkDetails.Update(workId, newGeneralClientId, newMeasurementsTakenBy, newRepairConfirmationDate, newByPassRequired, newRoboticDistances, newGeneralProposedLiningDate, newGeneralDeadlineLiningDate, newGeneralFinalVideo, newEstimatedJoints, newJointsTestSealed, newGeneralIssueIdentified, newGeneralLfsIssue, newGeneralClientIssue, newGeneralSalesIssue, newGeneralIssueGivenToClient, newGeneralIssueResolved, newGeneralIssueInvestigation, newPrepDataP1Date, newPrepDataCXIsRemoved, newTrafficControl, newMaterial, newVideoLength, newPreVideoDate, newPreFlushDate);

                // Store datasets
                Session["pointRepairsTDS"] = pointRepairsTDS;

                // Update database
                UpdateDatabase();

                ViewState["update"] = "yes";

                // Redirect
                string url = "";
                if (Request.QueryString["source_page"] == "pr_navigator2.aspx")
                {
                    url = "./pr_navigator2.aspx?source_page=pr_edit.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + GetNavigatorState() + "&update=yes";
                }

                if (Request.QueryString["source_page"] == "pr_summary.aspx")
                {
                    string activeTab = hdfActiveTab.Value;
                    url = "./pr_summary.aspx?source_page=pr_edit.aspx&client_id=" + hdfCurrentClientId.Value + "&project_id=" + hdfCurrentProjectId.Value + "&asset_id=" + hdfAssetId.Value + "&active_tab=" + activeTab + GetNavigatorState() + "&update=yes";
                }

                Response.Redirect(url);
            }
        }



        private void Apply()
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
                int workIdRa = Int32.Parse(hdfWorkIdRa.Value);
                int workIdFll = Int32.Parse(hdfWorkIdFll.Value);

                // Get Section Details
                string newStreet = ""; if (tbxStreet.Text != "") newStreet = tbxStreet.Text.Trim();
                string newUsmh = ""; if (tbxUSMH.Text != "") newUsmh = tbxUSMH.Text.Trim();
                string newUsmhAddress = ""; if (tbxUSMHMN.Text != "") newUsmhAddress = tbxUSMHMN.Text.Trim();
                string newDsmh = ""; if (tbxDSMH.Text != "") newDsmh = tbxDSMH.Text.Trim();
                string newDsmhAddress = ""; if (tbxDSMHMN.Text != "") newDsmhAddress = tbxDSMHMN.Text.Trim();
                string newMapSize = ""; if (tbxMapSize.Text != "") newMapSize = tbxMapSize.Text.Trim();
                string newSize = ""; if (tbxConfirmedSize.Text != "") newSize = tbxConfirmedSize.Text.Trim();
                string newMapLength = ""; if (tbxMapLength.Text != "") newMapLength = tbxMapLength.Text.Trim();
                string newSteelTapeThroughSewer = tbxSteelTapeLength.Text.Trim();
                string newVideoLength = ""; if (tbxVideoLength.Text != "") newVideoLength = tbxVideoLength.Text.Trim();
                int? newLaterals = null; if (tbxLaterals.Text != "") newLaterals = Int32.Parse(tbxLaterals.Text.Trim());
                int? newLiveLaterals = null; if (tbxLiveLaterals.Text != "") newLiveLaterals = Int32.Parse(tbxLiveLaterals.Text.Trim());
                string newSubArea = ""; if (tbxGeneralDataSubArea.Text != "") newSubArea = tbxGeneralDataSubArea.Text.Trim();

                // Update section details
                PointRepairsSectionDetails pointRepairsSectionDetails = new PointRepairsSectionDetails(pointRepairsTDS);
                pointRepairsSectionDetails.Update(workId, assetId, newStreet, newMapSize, newSize, newMapLength, newSteelTapeThroughSewer, newLaterals, newLiveLaterals, newSteelTapeThroughSewer, newUsmh, newDsmh, newUsmhAddress, newDsmhAddress, newSubArea);

                // Get Work Details
                string newGeneralClientId = ""; if (tbxGeneralDataClientId.Text != "") newGeneralClientId = tbxGeneralDataClientId.Text.Trim();
                string newMeasurementsTakenBy = ""; if (tbxGeneralDataMeasurementsTakenBy.Text != "") newMeasurementsTakenBy = tbxGeneralDataMeasurementsTakenBy.Text.Trim();
                DateTime? newRepairConfirmationDate = null; if (tkrdpGeneralDataRepairConfirmationDate.SelectedDate.HasValue) newRepairConfirmationDate = tkrdpGeneralDataRepairConfirmationDate.SelectedDate.Value;
                bool newByPassRequired = ckbxGeneralDataBypassRequired.Checked;
                string newRoboticDistances = ""; if (tbxGeneralDataRoboticDistances.Text != "") newRoboticDistances = tbxGeneralDataRoboticDistances.Text.Trim();
                DateTime? newGeneralProposedLiningDate = null; if (tkrdpGeneralDataProposedLiningDate.SelectedDate.HasValue) newGeneralProposedLiningDate = tkrdpGeneralDataProposedLiningDate.SelectedDate.Value;
                DateTime? newGeneralDeadlineLiningDate = null; if (tkrdpGeneralDataDeadlineLiningDate.SelectedDate.HasValue) newGeneralDeadlineLiningDate = tkrdpGeneralDataDeadlineLiningDate.SelectedDate.Value;
                DateTime? newGeneralFinalVideo = null; if (tkrdpGeneralDataFinalVideo.SelectedDate.HasValue) newGeneralFinalVideo = tkrdpGeneralDataFinalVideo.SelectedDate.Value;
                int? newEstimatedJoints = null; if (tbxGeneralDataEstimatedJoints.Text != "") newEstimatedJoints = Int32.Parse(tbxGeneralDataEstimatedJoints.Text.Trim());
                int? newJointsTestSealed = null; if (tbxGeneralDataJointsTestSealed.Text != "") newJointsTestSealed = Int32.Parse(tbxGeneralDataJointsTestSealed.Text.Trim());
                bool newGeneralIssueIdentified = ckbxGeneralDataIssueIdentified.Checked;
                bool newGeneralLfsIssue = ckbxGeneralDataLfsIssue.Checked;
                bool newGeneralClientIssue = ckbxGeneralDataClientIssue.Checked;
                bool newGeneralSalesIssue = ckbxGeneralDataSalesIssue.Checked;
                bool newGeneralIssueGivenToClient = ckbxGeneralDataIssueGivenToClient.Checked;
                bool newGeneralIssueResolved = ckbxGeneralDataIssueResolved.Checked;
                bool newGeneralIssueInvestigation = ckbxGeneralDataIssueInvestigation.Checked;

                // FLL
                // ... P1 Data
                DateTime? newPrepDataP1Date = null; if (tkrdpGeneralDataP1Date.SelectedDate.HasValue) newPrepDataP1Date = tkrdpGeneralDataP1Date.SelectedDate.Value;

                // ... Prep Data
                int? newPrepDataCXIsRemoved = null; if (tbxGeneralDataCXIsRemoved.Text != "") newPrepDataCXIsRemoved = Int32.Parse(tbxGeneralDataCXIsRemoved.Text.Trim());

                // ... M1 Data
                string newTrafficControl = ddlGeneralDataTrafficControl.SelectedValue;

                // RA
                // ... Rehab Assessment Data
                DateTime? newPreFlushDate = null; if (tkrdpGeneralDataPreFlushDate.SelectedDate.HasValue) newPreFlushDate = tkrdpGeneralDataPreFlushDate.SelectedDate.Value;
                DateTime? newPreVideoDate = null; if (tkrdpGeneralDataPreVideoDate.SelectedDate.HasValue) newPreVideoDate = tkrdpGeneralDataPreVideoDate.SelectedDate.Value;

                // Material
                string newMaterial = ddlGeneralDataMaterial.SelectedValue;

                // ... Update work details
                PointRepairsWorkDetails pointRepairsWorkDetails = new PointRepairsWorkDetails(pointRepairsTDS);
                pointRepairsWorkDetails.Update(workId, newGeneralClientId, newMeasurementsTakenBy, newRepairConfirmationDate, newByPassRequired, newRoboticDistances, newGeneralProposedLiningDate, newGeneralDeadlineLiningDate, newGeneralFinalVideo, newEstimatedJoints, newJointsTestSealed, newGeneralIssueIdentified, newGeneralLfsIssue, newGeneralClientIssue, newGeneralSalesIssue, newGeneralIssueGivenToClient, newGeneralIssueResolved, newGeneralIssueInvestigation, newPrepDataP1Date, newPrepDataCXIsRemoved, newTrafficControl, newMaterial, newVideoLength, newPreVideoDate, newPreFlushDate);

                // Store datasets
                Session["pointRepairsTDS"] = pointRepairsTDS;

                // Update database
                UpdateDatabase();

                ViewState["update"] = "yes";
            }
        }



        private bool ValidatePage()
        {
            bool validData = true;

            // Validate general data
            Page.Validate("generalData");

            if (Page.IsValid)
            {
                // Validate repairs tab
                if (ValidateRepairsFooter())
                {
                    Page.Validate("repairsDataAdd");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }
                }

                // Validate comments tab
                if (ValidateCommentsFooter())
                {
                    Page.Validate("commentsDataAdd");
                    if (!Page.IsValid)
                    {
                        validData = false;
                    }
                }
            }
            else
            {
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
                // If it's not valid
                lblMissingData.Visible = true;
                string errorText = "Invalid or missing data. Please check";
                lblMissingData.Text = errorText + hdfErrorFieldList.Value.ToString();
            }

            return validData;
        }



        private void UpdateDatabase()
        {
            // Get ids & location
            int projectId = Int32.Parse(hdfCurrentProjectId.Value.Trim());
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            Int64 countryId = projectGateway.GetCountryID(projectId);
            Int64? provinceId = null; if (projectGateway.GetProvinceID(projectId).HasValue) provinceId = (Int64)projectGateway.GetProvinceID(projectId);
            Int64? countyId = null; if (projectGateway.GetCountyID(projectId).HasValue) countyId = (Int64)projectGateway.GetCountyID(projectId);
            Int64? cityId = null; if (projectGateway.GetCityID(projectId).HasValue) cityId = (Int64)projectGateway.GetCityID(projectId);

            string workType = hdfWorkType.Value.Trim();
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int workId = Int32.Parse(hdfWorkId.Value);
            int workIdFll = Int32.Parse(hdfWorkIdFll.Value);
            int sectionAssetId = Int32.Parse(hdfAssetId.Value);

            DB.Open();
            DB.BeginTransaction();
            try
            {
                // Save repair details
                PointRepairsRepairDetails pointRepairsRepairDetails = new PointRepairsRepairDetails(pointRepairsTDS);
                pointRepairsRepairDetails.Save(companyId);

                // Save comment details
                PointRepairsCommentDetails pointRepairsCommentDetails = new PointRepairsCommentDetails(pointRepairsTDS);
                pointRepairsCommentDetails.Save(companyId);

                // Save section details
                PointRepairsSectionDetails pointRepairsSectionDetails = new PointRepairsSectionDetails(pointRepairsTDS);
                pointRepairsSectionDetails.Save(countryId, provinceId, countyId, cityId, projectId, companyId);

                // Save work details
                PointRepairsWorkDetails pointRepairsWorkDetails = new PointRepairsWorkDetails(pointRepairsTDS);
                pointRepairsWorkDetails.Save(countryId, provinceId, countyId, cityId, projectId, sectionAssetId, companyId);
                
                DB.CommitTransaction();

                // Store datasets
                pointRepairsTDS.AcceptChanges();
                Session["pointRepairsTDS"] = pointRepairsTDS;
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
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



        protected void AddRepairsNewEmptyFix(GridView grdRepairs)
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



        protected void AddCommentsNewEmptyFix(GridView grdComments)
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



        private void GrdRepairsAdd()
        {
            if (ValidateRepairsFooter())
            {
                Page.Validate("repairsDataAdd");

                if (Page.IsValid)
                {
                    PointRepairsRepairDetails model = new PointRepairsRepairDetails(pointRepairsTDS);

                    // static values
                    int workId = Int32.Parse(hdfWorkId.Value);
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    bool inDatabase = false;

                    // Repair Type
                    string repairType = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlRepairTypeNew")).SelectedValue;

                    // Auto-generate value
                    string repairPointId = GetRepairPointIdIncrement(repairType);

                    switch (repairType)
                    {
                        case "Robotic Reaming":
                            string rmReamDistance = ((TextBox)grdRepairs.FooterRow.FindControl("tbxRmReamDistanceNew")).Text.Trim();
                            DateTime? rmReamDate = null; if (((RadDatePicker)grdRepairs.FooterRow.FindControl("tkrdpRmReamDateNew")).SelectedDate.HasValue) rmReamDate = ((RadDatePicker)grdRepairs.FooterRow.FindControl("tkrdpRmReamDateNew")).SelectedDate.Value;
                            bool rmExtraRepair = ((CheckBox)grdRepairs.FooterRow.FindControl("cbxRmExtraRepairNew")).Checked;
                            bool rmCancelled = ((CheckBox)grdRepairs.FooterRow.FindControl("cbxRmCancelledNew")).Checked;
                            string rmApproval = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlRmApprovalNew")).SelectedValue.ToString().Trim();
                            string rmComments = ((TextBox)grdRepairs.FooterRow.FindControl("tbxRmCommentsNew")).Text.Trim();
                            string rmDefectQualifier = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlRmDefectQualifierNew")).SelectedValue;
                            string rmDefectDetails = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlRmDefectDetailsNew")).SelectedValue;
                            DateTime? rmReinstateDate = null; if (((RadDatePicker)grdRepairs.FooterRow.FindControl("tkrdpRmReinstateDateNew")).SelectedDate.HasValue) rmReinstateDate = ((RadDatePicker)grdRepairs.FooterRow.FindControl("tkrdpRmReinstateDateNew")).SelectedDate.Value;

                            model.Insert(workId, repairPointId, repairType, rmReamDistance, rmReamDate, "", null, null, "", "", "", "", null, "", "", null, rmApproval, rmExtraRepair, rmCancelled, rmComments, false, companyId, inDatabase, rmDefectQualifier, rmDefectDetails, "", rmReinstateDate);
                            break;

                        case "Point Lining":
                            string plLinerDistance = ((TextBox)grdRepairs.FooterRow.FindControl("tbxPlLinerDistanceNew")).Text.Trim();
                            string plDirection = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlPlDirectionNew")).SelectedValue.ToString().Trim();
                            int? plReinstates = null; if (((TextBox)grdRepairs.FooterRow.FindControl("tbxPlReinstatesNew")).Text.Trim() != "") plReinstates = Int32.Parse(((TextBox)grdRepairs.FooterRow.FindControl("tbxPlReinstatesNew")).Text.Trim());
                            string plLtmh = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlPlLtmhNew")).SelectedValue;
                            string plVtmh = "";
                            if (plLtmh != "")
                            {
                                int selectedIndex = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlPlLtmhNew")).SelectedIndex;

                                if (selectedIndex == 1)
                                {
                                    plVtmh = hdfDSMH.Value;
                                }
                                else
                                {
                                    plVtmh = hdfUSMH.Value;
                                }
                            }
                            string plDistance = ((TextBox)grdRepairs.FooterRow.FindControl("tbxPlDistanceNew")).Text.Trim();
                            string plSize_ = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlPlSize_New")).SelectedValue.ToString().Trim();
                            DateTime? plInstallDate = null; if (((RadDatePicker)grdRepairs.FooterRow.FindControl("tkrdpPlInstallDateNew")).SelectedDate.HasValue) plInstallDate = ((RadDatePicker)grdRepairs.FooterRow.FindControl("tkrdpPlInstallDateNew")).SelectedDate.Value;
                            string plMhShot = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlPlMhShotNew")).SelectedValue.ToString().Trim();
                            bool plExtraRepair = ((CheckBox)grdRepairs.FooterRow.FindControl("cbxPlExtraRepairNew")).Checked;
                            bool plCancelled = ((CheckBox)grdRepairs.FooterRow.FindControl("cbxPlCancelledNew")).Checked;
                            string plApproval = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlPlAprovalNew")).SelectedValue.ToString().Trim();
                            string plComments = ((TextBox)grdRepairs.FooterRow.FindControl("tbxPlCommentsNew")).Text.Trim();
                            string plDefectQualifier = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlPlDefectQualifierNew")).SelectedValue;
                            string plDefectDetails = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlPlDefectDetailsNew")).SelectedValue;
                            string plLength = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlPlLengthNew")).SelectedValue;
                            DateTime? plReinstateDate = null; if (((RadDatePicker)grdRepairs.FooterRow.FindControl("tkrdpPlReinstateDateNew")).SelectedDate.HasValue) plReinstateDate = ((RadDatePicker)grdRepairs.FooterRow.FindControl("tkrdpPlReinstateDateNew")).SelectedDate.Value;

                            model.Insert(workId, repairPointId, repairType, "", null, plLinerDistance, plDirection, plReinstates, plLtmh, plVtmh, plDistance, plSize_, plInstallDate, plMhShot, "", null, plApproval, plExtraRepair, plCancelled, plComments, false, companyId, inDatabase, plDefectQualifier, plDefectDetails, plLength, plReinstateDate);
                            break;

                        case "Grouting":
                            string gtGroutDistance = ((TextBox)grdRepairs.FooterRow.FindControl("tbxGtGroutDistanceNew")).Text.Trim();
                            DateTime? gtInstallDate = null;
                            DateTime? gtGroutDate = null; if (((RadDatePicker)grdRepairs.FooterRow.FindControl("tkrdpGtGroutDateNew")).SelectedDate.HasValue) gtGroutDate = ((RadDatePicker)grdRepairs.FooterRow.FindControl("tkrdpGtGroutDateNew")).SelectedDate.Value;
                            bool gtExtraRepair = ((CheckBox)grdRepairs.FooterRow.FindControl("cbxGtExtraRepairNew")).Checked;
                            bool gtCancelled = ((CheckBox)grdRepairs.FooterRow.FindControl("cbxGtCancelledNew")).Checked;
                            string gtApproval = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlGtApprovalNew")).SelectedValue.ToString().Trim();
                            string gtComments = ((TextBox)grdRepairs.FooterRow.FindControl("tbxGtCommentsNew")).Text.Trim();
                            string gtDefectQualifier = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlGtDefectQualifierNew")).SelectedValue;
                            string gtDefectDetails = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlGtDefectDetailsNew")).SelectedValue;
                            DateTime? gtReinstateDate = null; if (((RadDatePicker)grdRepairs.FooterRow.FindControl("tkrdpGtReinstateDateNew")).SelectedDate.HasValue) gtReinstateDate = ((RadDatePicker)grdRepairs.FooterRow.FindControl("tkrdpGtReinstateDateNew")).SelectedDate.Value;

                            model.Insert(workId, repairPointId, repairType, "", null, "", "", null, "", "", "", "", gtInstallDate, "", gtGroutDistance, gtGroutDate, gtApproval, gtExtraRepair, gtCancelled, gtComments, false, companyId, inDatabase, gtDefectQualifier, gtDefectDetails, "", gtReinstateDate);
                            break;
                    }

                    Session.Remove("pointRepairsRepairsTempDummy");
                    Session["pointRepairsTDS"] = pointRepairsTDS;

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

                    grdRepairs.DataBind();
                }
            }
        }



        private void GrdCommentsAdd()
        {
            if (ValidateCommentsFooter())
            {
                Page.Validate("commentsDataAdd");
                if (Page.IsValid)
                {
                    int workId = Int32.Parse(hdfWorkId.Value);
                    int companyId = Int32.Parse(hdfCompanyId.Value);
                    string newSubject = ((TextBox)grdComments.FooterRow.FindControl("tbxCommentSubjectNew")).Text.Trim();
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    DateTime dateTime_ = DateTime.Now;
                    string newComment = ((TextBox)grdComments.FooterRow.FindControl("tbxCommentCommentNew")).Text.Trim();
                    bool inDatabase = false;
                    string workType = hdfWorkType.Value;

                    PointRepairsCommentDetails model = new PointRepairsCommentDetails(pointRepairsTDS);

                    model.Insert(workId, "Point Repairs", newSubject, loginId, dateTime_, newComment, null, false, companyId, inDatabase, workType);

                    Session.Remove("pointRepairsCommentsTempDummy");
                    Session["pointRepairsTDS"] = pointRepairsTDS;

                    grdComments.DataBind();
                }
            }
        }



        private string GetRepairPointIdIncrement(string type)
        {
            string repairPointIdIncrement = "";

            switch (type)
            {
                case "Robotic Reaming":
                    repairPointIdIncrement = "RM-";
                    break;

                case "Point Lining":
                    repairPointIdIncrement = "PL-";
                    break;

                case "Grouting":
                    repairPointIdIncrement = "GT-";
                    break;
            }

            // Generate increment
            PointRepairsRepairDetails pointRepairsRepairDetails = new PointRepairsRepairDetails(pointRepairsTDS);

            repairPointIdIncrement += Convert.ToChar(pointRepairsRepairDetails.GetMaxRepairPointId(type) + 1).ToString();

            return repairPointIdIncrement;
        }



        private string GetLastRepairPointIdIncrement(string type)
        {
            string repairPointIdIncrement = "";

            switch (type)
            {
                case "Robotic Reaming":
                    repairPointIdIncrement = "RM-";
                    break;

                case "Point Lining":
                    repairPointIdIncrement = "PL-";
                    break;

                case "Grouting":
                    repairPointIdIncrement = "GT-";
                    break;
            }

            // Generate increment
            PointRepairsRepairDetails pointRepairsRepairDetails = new PointRepairsRepairDetails(pointRepairsTDS);

            repairPointIdIncrement += Convert.ToChar(pointRepairsRepairDetails.GetMaxRepairPointId(type)).ToString();

            return repairPointIdIncrement;
        }



        private bool ValidateRepairsFooter()
        {
            bool validFooter = false;
            string repairType = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlRepairTypeNew")).SelectedValue;

            switch (repairType)
            {
                case "Robotic Reaming":
                    string rmReamDistance = ((TextBox)grdRepairs.FooterRow.FindControl("tbxRmReamDistanceNew")).Text.Trim();
                    bool rmExtraRepair = ((CheckBox)grdRepairs.FooterRow.FindControl("cbxRmExtraRepairNew")).Checked;
                    bool rmCancelled = ((CheckBox)grdRepairs.FooterRow.FindControl("cbxRmCancelledNew")).Checked;
                    string rmApproval = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlRmApprovalNew")).SelectedValue.Trim();
                    string rmComments = ((TextBox)grdRepairs.FooterRow.FindControl("tbxRmCommentsNew")).Text.Trim();
                    string rmDefectQualifier = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlRmDefectQualifierNew")).SelectedValue;
                    string rmDefectDetails = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlRmDefectDetailsNew")).SelectedValue;

                    if ((rmReamDistance != "") || (((RadDatePicker)grdRepairs.FooterRow.FindControl("tkrdpRmReamDateNew")).SelectedDate.HasValue) || (rmApproval != "") || (rmComments != "") || (rmExtraRepair) || (rmCancelled) || (rmDefectQualifier != "") || (rmDefectDetails != "(Select a defect details)"))
                    {
                        return true;
                    }
                    break;

                case "Point Lining":
                    string plLinerDistance = ((TextBox)grdRepairs.FooterRow.FindControl("tbxPlLinerDistanceNew")).Text.Trim();
                    string plDirection = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlPlDirectionNew")).SelectedValue.Trim();
                    string plReinstates = ((TextBox)grdRepairs.FooterRow.FindControl("tbxPlReinstatesNew")).Text.Trim();
                    string plLtmh = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlPlLtmhNew")).SelectedValue;
                    string plVtmh = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlPlVtmhNew")).SelectedValue;
                    string plDistance = ((TextBox)grdRepairs.FooterRow.FindControl("tbxPlDistanceNew")).Text.Trim();
                    string plSize_ = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlPlSize_New")).SelectedValue.Trim();
                    string plMhShot = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlPlMhShotNew")).SelectedValue.Trim();
                    bool plExtraRepair = ((CheckBox)grdRepairs.FooterRow.FindControl("cbxPlExtraRepairNew")).Checked;
                    bool plCancelled = ((CheckBox)grdRepairs.FooterRow.FindControl("cbxPlCancelledNew")).Checked;
                    string plApproval = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlPlAprovalNew")).SelectedValue.Trim();
                    string plComments = ((TextBox)grdRepairs.FooterRow.FindControl("tbxPlCommentsNew")).Text.Trim();
                    string plDefectQualifier = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlPlDefectQualifierNew")).SelectedValue;
                    string plDefectDetails = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlPlDefectDetailsNew")).SelectedValue;
                    string plLength = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlPlLengthNew")).SelectedValue;
                    
                    if ((plLinerDistance != "") || (plDirection != "") || (plReinstates != "") || (plLtmh != "") || (plVtmh != "") || (plDistance != "") || (plSize_ != "") || (((RadDatePicker)grdRepairs.FooterRow.FindControl("tkrdpPlInstallDateNew")).SelectedDate.HasValue) || (plMhShot != "") || (plApproval != "") || (plComments != "") || (plExtraRepair) || (plCancelled) || (plDefectQualifier != "") || (plDefectDetails != "(Select a defect details)") || (plLength != ""))
                    {
                        validFooter = true;
                    }
                    break;

                case "Grouting":
                    string gtGroutDistance = ((TextBox)grdRepairs.FooterRow.FindControl("tbxGtGroutDistanceNew")).Text.Trim();
                    bool gtExtraRepair = ((CheckBox)grdRepairs.FooterRow.FindControl("cbxGtExtraRepairNew")).Checked;
                    bool gtCancelled = ((CheckBox)grdRepairs.FooterRow.FindControl("cbxGtCancelledNew")).Checked;
                    string gtApproval = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlGtApprovalNew")).SelectedValue.Trim();
                    string gtComments = ((TextBox)grdRepairs.FooterRow.FindControl("tbxGtCommentsNew")).Text.Trim();
                    string gtDefectQualifier = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlGtDefectQualifierNew")).SelectedValue;
                    string gtDefectDetails = ((DropDownList)grdRepairs.FooterRow.FindControl("ddlGtDefectDetailsNew")).SelectedValue;

                    if ((gtGroutDistance != "") || (((RadDatePicker)grdRepairs.FooterRow.FindControl("tkrdpGtGroutDateNew")).SelectedDate.HasValue) || (gtApproval != "") || (gtComments != "") || (gtExtraRepair) || (gtCancelled) || (gtDefectQualifier != "") || (gtDefectDetails != "(Select a defect details)"))
                    {
                        validFooter = true;
                    }
                    break;
            }

            return validFooter;
        }



        private bool ValidateCommentsFooter()
        {
            string subject = ((TextBox)grdComments.FooterRow.FindControl("tbxCommentSubjectNew")).Text.Trim();
            string comment = ((TextBox)grdComments.FooterRow.FindControl("tbxCommentCommentNew")).Text.Trim();

            if ((subject != "") || (comment != ""))
            {
                return true;
            }

            return false;
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // PUBLIC METHODS
        //

        public PointRepairsTDS.RepairDetailsDataTable GetRepairsNew()
        {
            pointRepairsRepairsTemp = (PointRepairsTDS.RepairDetailsDataTable)Session["pointRepairsRepairsTempDummy"];

            if (pointRepairsRepairsTemp == null)
            {
                pointRepairsRepairsTemp = ((PointRepairsTDS)Session["pointRepairsTDS"]).RepairDetails;
            }

            return pointRepairsRepairsTemp;
        }



        public void DummyRepairsNew(int WorkID, string RepairPointID)
        {
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



        public void DummyCommentsNew(int WorkID, int RefID)
        {
        }



    }
}