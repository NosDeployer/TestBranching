using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.CWP.FullLengthLining;
using LiquiForce.LFSLive.BL.CWP.ManholeRehabilitation;
using LiquiForce.LFSLive.BL.LabourHours.ProjectTime;
using LiquiForce.LFSLive.BL.LabourHours.TeamProjectTime;
using LiquiForce.LFSLive.DA.Assets.Assets;
using LiquiForce.LFSLive.DA.Company.Organization;
using LiquiForce.LFSLive.DA.CWP.FullLengthLining;
using LiquiForce.LFSLive.DA.CWP.ManholeRehabilitation;
using LiquiForce.LFSLive.DA.CWP.Works;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.DA.LabourHours.ProjectTime;
using LiquiForce.LFSLive.DA.LabourHours.TeamProjectTime;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.Tools;

namespace LiquiForce.LFSLive.WebUI.LabourHours.TeamProjectTime
{
    /// <summary>
    /// timesheet_team
    /// </summary>
    public partial class timesheet_team : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected TeamProjectTime2TDS teamProjectTime2TDS;
        protected TeamProjectTime2TDS.TemplateDataTable template; // for template's grid
        protected TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPDataTable teamProjectTimeDetailTemp;
        protected TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable teamProjectTimeSection;
        protected TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_LATERALDataTable teamProjectTimeSectionLateral;
        protected TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MHDataTable teamProjectTimeSectionMH;
        protected TeamProjectTime2TDS teamProjectTime2TDSToSave;
        protected ProjectTimeTDS projectTime2TDS;
        protected FullLengthLiningTDS fullLengthLiningTDS;
        protected ManholeRehabilitationTDS manholeRehabilitationTDS;
        protected ArrayList sectionsReinstatePostVideoSelect;






        // ////////////////////////////////////////////////////////////////////////
        // INITIAL EVENTS 
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            // Register client scripts
            this.RegisterClientScripts();

            if (!IsPostBack)
            {
                // Security check
                if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"]))
                {
                    if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_ADD"])))
                    {
                        if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT"]))
                        {
                            if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT_WED"]))
                            {
                                Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                            }
                        }
                    }
                }

                // Tag page
                Session.Remove("teamProjectTime2TDS");
                Session.Remove("sectionsReinstatePostVideoSelect");

                Session.Remove("template");
                Session.Remove("templateDummy");

                Session.Remove("teamProjectTimeDetailTemp");
                Session.Remove("teamProjectTimeDetailTempDummy");

                Session.Remove("teamProjectTimeSection");
                Session.Remove("teamProjectTimeSectionDummy");

                Session.Remove("teamProjectTimeSectionLateral");
                Session.Remove("teamProjectTimeSectionLateralDummy");

                Session.Remove("teamProjectTimeSectionMH");
                Session.Remove("teamProjectTimeSectionMHDummy");
                
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfBtnNext.Value = "False";

                // Initialize  variables
                lblMessage.Visible = false;

                // ... Initialize viewstate variables
                System.Configuration.AppSettingsReader appSettingReader = new System.Configuration.AppSettingsReader();
                ViewState["LHMode"] = appSettingReader.GetValue("LABOUR_HOURS_OPERATION_MODE", typeof(System.String)).ToString();
                ViewState["StepFrom"] = "Out";
                ViewState["teamProjectTimeId"] = 0;

                // ... Prepare initial data for template
                odsTemplate.SelectParameters.RemoveAt(0);
                odsTemplate.SelectParameters.Add("loginId", Convert.ToInt32(Session["loginID"]).ToString());
                odsTemplate.Select();

                // Store datasets
                teamProjectTime2TDS = new TeamProjectTime2TDS();
                Session["teamProjectTime2TDS"] = teamProjectTime2TDS;
                
                template = teamProjectTime2TDS.Template;
                Session["template"] = teamProjectTime2TDS.Template;
                
                teamProjectTimeDetailTemp = teamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMP;
                Session["teamProjectTimeDetailTemp"] = teamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMP;

                teamProjectTimeSection = teamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION;
                Session["teamProjectTimeSection"] = teamProjectTimeSection;

                teamProjectTimeSectionLateral = teamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_LATERAL;
                Session["teamProjectTimeSectionLateral"] = teamProjectTimeSectionLateral;

                teamProjectTimeSectionMH = teamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MH;
                Session["teamProjectTimeSectionMH"] = teamProjectTimeSectionMH;

                Session["sectionsReinstatePostVideoSelect"] = sectionsReinstatePostVideoSelect;

                // StepSection1In
                wzTeam.ActiveStepIndex = 0;
                StepBeginIn();
            }
            else
            {
                // Restore datasets
                teamProjectTime2TDS = (TeamProjectTime2TDS)Session["teamProjectTime2TDS"];
                
                template = teamProjectTime2TDS.Template;
                Session["template"] = teamProjectTime2TDS.Template;
                
                teamProjectTimeDetailTemp = teamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMP;
                Session["teamProjectTimeDetailTemp"] = teamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMP;
                
                teamProjectTimeSection = teamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION;
                Session["teamProjectTimeSection"] = teamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION;

                teamProjectTimeSectionLateral = teamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_LATERAL;
                Session["teamProjectTimeSectionLateral"] = teamProjectTimeSectionLateral;

                teamProjectTimeSectionMH = teamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MH;
                Session["teamProjectTimeSectionMH"] = teamProjectTimeSectionMH;

                sectionsReinstatePostVideoSelect = (ArrayList)Session["sectionsReinstatePostVideoSelect"];
            }
        }






        #region Wizard navigation events

        // ////////////////////////////////////////////////////////////////////////
        // WIZARD NAVIGATION EVENTS
        //

        protected void wzTeam_ActiveStepChanged(object sender, EventArgs e)
        {
            if (ViewState["StepFrom"] != null)
            {
                mWizard2 master = (mWizard2)this.Master;
                switch (wzTeam.ActiveStep.Name)
                {
                    case "Begin":
                        StepBeginIn();
                        break;

                    case "Template":
                        StepTemplateIn();
                        break;

                    case "Data":
                        StepDataIn();
                        break;

                    case "Employees":
                        StepEmployeesIn();
                        break;

                    case "End":
                        StepEndIn();
                        break;
                }
            }
        }



        protected void wzTeam_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzTeam.ActiveStep.Name)
            {
                case "Begin":
                    // Standard: Code for guider step
                    int stepBeginTo = StepBeginNext();
                    if (stepBeginTo == -1)
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        ViewState["StepFrom"] = "Begin";
                        wzTeam.ActiveStepIndex = stepBeginTo;
                    }
                    break;

                case "Template":
                    // Standard: Code for normal step
                    e.Cancel = !StepTemplateNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Template";
                    }
                    break;

                case "Data":
                    e.Cancel = !StepDataNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Data";
                    }
                    break;

                case "Employees":
                    e.Cancel = !StepEmployeesNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Employees";
                    }
                    break;
            }
        }



        protected void wzTeam_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzTeam.ActiveStep.Name)
            {
                case "Template":
                    e.Cancel = !StepTemplatePrevious();
                    break;

                case "Employees":
                    e.Cancel = !StepEmployeesPrevious();
                    break;

                case "End":
                    e.Cancel = !StepEndPrevious();
                    break;
            }

            if (!e.Cancel)
            {
                ViewState["StepFrom"] = wzTeam.ActiveStep.Name;
            }
        }



        protected void wzTeam_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            e.Cancel = !StepEndFinish();

            if (!e.Cancel)
            {
                string script = "<script language='javascript'>";
                script = script + string.Format("window.close()");
                script = script + "</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Finish", script, false);
            }
        }



        protected void wzTeam_CancelButtonClick(object sender, EventArgs e)
        {
            string script = "<script language='javascript'>";
            script = script + string.Format("window.close()");
            script = script + "</script>";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Cancel", script, false);
        }



        #endregion






        #region STEP1 - BEGIN

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP1 - BEGIN
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN - METHODS
        //

        private void StepBeginIn()
        {
            // Set instruction
            mWizard2 master = (mWizard2)this.Master;
            master.WizardInstruction = "What do you want to do?";

            if ((string)ViewState["StepFrom"] == "Out")
            {
                // Prepare initial data for the client
                TeamProjectTime2TemplateGateway teamProjectTime2TemplateGateway = new TeamProjectTime2TemplateGateway(teamProjectTime2TDS);
                teamProjectTime2TemplateGateway.LoadByLoginId(Convert.ToInt32(Session["loginID"]));

                // Store datasets
                Session["teamProjectTime2TDS"] = teamProjectTime2TDS;
                template = teamProjectTime2TDS.Template;
                Session["template"] = teamProjectTime2TDS.Template;

                // Template existing check
                if (teamProjectTime2TemplateGateway.Table.Rows.Count == 0)
                {
                    hdfNewOrTemplate.Value = "New";
                    wzTeam.ActiveStepIndex = 2;
                }
            }
        }



        private int StepBeginNext()
        {
            // Determine appropiate step
            if (rbtnBeginNew.Checked)
            {
                // Go to StepData
                hdfNewOrTemplate.Value = "New";
                return 2;
            }
            if (rbtnBeginTemplate.Checked)
            {
                // Go to StepTemplate
                hdfNewOrTemplate.Value = "Template";
                return 1;
            }

            return -1;
        }

        #endregion






        #region STEP2 - TEMPLATE

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP2 - TEMPLATE
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - TEMPLATE -  EVENTS
        //

        protected void grdTemplate_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int teamProjectTimeId = (int)e.Keys["TeamProjectTimeID"];

            // Delete template
            DeleteTemplate(teamProjectTimeId);

            // Update database
            UpdateDatabaseForTemplate();
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - TEMPLATE - AUXILIAR EVENTS
        //

        protected void grdTemplate_DataBound(object sender, EventArgs e)
        {
            AddTimesheetTemplateNewEmptyFix(grdTemplate);
        }



        public void DummyTimesheetsTemplateNew(int TeamProjectTimeID, int original_TeamProjectTimeID)
        {
        }






        // ////////////////////////////////////////////////////////////////////////
        //  STEP2 - TEMPLATE - PUBLIC METHODS
        //

        public TeamProjectTime2TDS.TemplateDataTable GetTimesheetsTemplate()
        {
            template = (TeamProjectTime2TDS.TemplateDataTable)Session["templateDummy"];
            if (template == null)
            {
                template = ((TeamProjectTime2TDS.TemplateDataTable)Session["template"]);
            }

            return template;
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - TEMPLATE - PRIVATE METHODS
        //

        private void StepTemplateIn()
        {
            // Set instruction
            mWizard2 master = (mWizard2)this.Master;
            master.WizardInstruction = "Please select a template and click next.";

            // Initialize  variables
            lblMessage.Visible = false;

            // Prepare initial data
            // ... for template
            TeamProjectTime2TemplateGateway teamProjectTime2TemplateGateway = new TeamProjectTime2TemplateGateway(teamProjectTime2TDS);
            teamProjectTime2TemplateGateway.LoadByLoginId(Convert.ToInt32(Session["loginID"]));

            // Store datasets
            Session["teamProjectTime2TDS"] = teamProjectTime2TDS;
            template = teamProjectTime2TDS.Template;
            Session["template"] = teamProjectTime2TDS.Template;
        }



        private bool StepTemplatePrevious()
        {
            return true;
        }



        private bool StepTemplateNext()
        {
            // Template election check
            if (grdTemplate.Rows.Count > 0)
            {
                // Save selected team project time for next step
                SaveSelectedId();
                int teamProjectTimeId = Int32.Parse(hdfSelectedIdTemplate.Value);
                if (teamProjectTimeId != 0)
                {
                    return true;
                }
                else
                {
                    lblMessage.Text = "At least one timesheet must be selected";
                    lblMessage.Visible = true;
                    return false;
                }
            }
            else
            {
                lblMessage.Text = "Template unavailable";
                return false;
            }
        }



        private void DeleteTemplate(int teamProjectTimeId)
        {
            // Create TDS to save
            teamProjectTime2TDSToSave = new TeamProjectTime2TDS();

            // Delete Template
            TeamProjectTime2Template teamProjectTime2Template = new TeamProjectTime2Template(teamProjectTime2TDS);
            teamProjectTime2Template.Delete(teamProjectTimeId);

            // ... Store datasets for teplate
            Session.Remove("templateDummy");
            Session["teamProjectTime2TDS"] = teamProjectTime2TDS;
            template = teamProjectTime2TDS.Template;
            Session["template"] = teamProjectTime2TDS.Template;

            // Delete associated TeamProjectTime to Template
            // ... load TeamProjectTime
            TeamProjectTime2Gateway teamProjectTime2Gateway = new TeamProjectTime2Gateway(teamProjectTime2TDSToSave);
            teamProjectTime2Gateway.LoadByTeamProjectTimeId(teamProjectTimeId);

            // ... delete TeamProjectTime
            TeamProjectTime2 teamProjectTime2 = new TeamProjectTime2(teamProjectTime2TDSToSave);
            teamProjectTime2.Delete(teamProjectTimeId);

            // Delete associated TeamProjectTimeDetails to Template
            // ... load TeamProjectTimeDetails
            TeamProjectTime2DetailGateway teamProjectTime2DetailGateway = new TeamProjectTime2DetailGateway(teamProjectTime2TDSToSave);
            teamProjectTime2DetailGateway.LoadByTeamProjectTimeId(teamProjectTimeId);

            // ... delete TeamProjectTimeDetails
            TeamProjectTime2Detail teamProjectTime2Detail = new TeamProjectTime2Detail(teamProjectTime2TDSToSave);
            teamProjectTime2Detail.Delete(teamProjectTimeId);
        }



        protected void AddTimesheetTemplateNewEmptyFix(GridView grdTemplate)
        {
            if (grdTemplate.Rows.Count == 0)
            {
                TeamProjectTime2TDS.TemplateDataTable dt = new TeamProjectTime2TDS.TemplateDataTable();
                dt.AddTemplateRow("", "", "", "", false, false);
                Session["templateDummy"] = dt;

                grdTemplate.DataBind();
            }

            // normally executes at all postbacks
            if (grdTemplate.Rows.Count == 1)
            {
                TeamProjectTime2TDS.TemplateDataTable dt = (TeamProjectTime2TDS.TemplateDataTable)Session["templateDummy"];
                if (dt != null)
                {
                    grdTemplate.Rows[0].Visible = false;
                    grdTemplate.Rows[0].Controls.Clear();
                }
            }
        }



        protected void SaveSelectedId()
        {
            int idForUpdate = 0;
            bool selected = false;
            hdfSelectedIdTemplate.Value = "0";

            TeamProjectTime2Template teamProjectTime2Template = new TeamProjectTime2Template(teamProjectTime2TDS);

            foreach (GridViewRow row in grdTemplate.Rows)
            {
                // ... Update all rows
                selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                idForUpdate = Int32.Parse(((Label)row.FindControl("lblTeamProjectTimeID")).Text.Trim());
                teamProjectTime2Template.Update(idForUpdate, selected);

                // ... Save selected project
                if (selected)
                {
                    hdfSelectedIdTemplate.Value = idForUpdate.ToString();
                }
            }
            teamProjectTime2Template.Data.AcceptChanges();

            // Store datasets
            Session["teamProjectTime2TDS"] = teamProjectTime2TDS;
            template = teamProjectTime2TDS.Template;
            Session["template"] = teamProjectTime2TDS.Template;
        }



        #endregion






        #region STEP3 - DATA

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP3 - DATA
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - DATA - AUXILIAR EVENTS
        //

        protected void grdSections_DataBound(object sender, EventArgs e)
        {
            SectionsInformationEmptyFix(grdSections);
        }



        protected void grdSectionsReinstatePostVideo_DataBound(object sender, EventArgs e)
        {
            SectionsReinstatePostVideoInformationEmptyFix(grdSectionsReinstatePostVideo);
        }



        protected void grdSectionsInstall_DataBound(object sender, EventArgs e)
        {
            SectionsInstallInformationEmptyFix(grdSectionsInstall);
        }



        protected void grdLaterals_DataBound(object sender, EventArgs e)
        {
            LateralsInformationEmptyFix(grdLaterals);
        }



        protected void grdManholesRehabPrep_DataBound(object sender, EventArgs e)
        {
            ManholesRehabPrepInformationEmptyFix(grdManholesRehabPrep);
        }



        protected void grdManholesRehabSpray_DataBound(object sender, EventArgs e)
        {
            ManholesRehabSprayInformationEmptyFix(grdManholesRehabSpray);
        }



        protected void cbxOpened_OnCheckedChanged(object sender, EventArgs e)
        {
            LateralsProcessGrid();
            upnlFullLengthReinstatePostVideo.Update();
        }



        private void SectionsReinstatePostVideoProcessGrid()
        {
            TeamProjectTime2Section model = new TeamProjectTime2Section(teamProjectTime2TDS);

            // Update rows
            foreach (GridViewRow row in grdSectionsReinstatePostVideo.Rows)
            {
                string sectionId = grdSectionsReinstatePostVideo.DataKeys[row.RowIndex].Values["SectionID"].ToString();
                string flowOrderId = ((Label)row.FindControl("lblFlowOrderID")).Text;
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                bool completed = ((CheckBox)row.FindControl("cbxCompleted")).Checked;
                int percentageOpened = Convert.ToInt32(((Label)row.FindControl("lblPercentageOpened")).Text);
                int percentageBrushed = Convert.ToInt32(((Label)row.FindControl("lblPercentageBrushed")).Text);
                DateTime? postVideo = Convert.ToDateTime(((Label)row.FindControl("lblPostVideo")).Text);

                if (selected)
                {
                    model.Update2(sectionId, completed, postVideo, selected, percentageOpened, percentageBrushed);
                }
            }

            model.Table.AcceptChanges();

            teamProjectTimeSection = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable)model.Table;
            Session["teamProjectTimeSection"] = teamProjectTimeSection;
            Session["teamProjectTime2TDS"] = teamProjectTime2TDS;
        }



        private void SectionsInstallProcessGrid()
        {
            TeamProjectTime2Section model = new TeamProjectTime2Section(teamProjectTime2TDS);
           
            // Update rows
            foreach (GridViewRow row in grdSectionsInstall.Rows)
            {
                string sectionId = grdSectionsInstall.DataKeys[row.RowIndex].Values["SectionID"].ToString();
                string flowOrderId = ((Label)row.FindControl("lblFlowOrderID")).Text;
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                DateTime? installDate = Convert.ToDateTime(((Label)row.FindControl("lblInstallDate")).Text);

                if (selected)
                {
                    if (installDate != tkrdpDate_.SelectedDate.Value)
                    {
                        installDate = tkrdpDate_.SelectedDate.Value;
                    }
                    
                    model.Update(sectionId, true, installDate, selected);
                }
            }

            model.Table.AcceptChanges();

            teamProjectTimeSection = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable)model.Table;
            Session["teamProjectTimeSection"] = teamProjectTimeSection;
            Session["teamProjectTime2TDS"] = teamProjectTime2TDS;
        }



        private void ManholesRehabPrepProcessGrid()
        {
            TeamProjectTime2Section modelSection = new TeamProjectTime2Section(teamProjectTime2TDS);
            TeamProjectTime2SectionMH model = new TeamProjectTime2SectionMH(teamProjectTime2TDS);
            
            // Update rows
            foreach (GridViewRow row in grdManholesRehabPrep.Rows)
            {
                int assetId = Convert.ToInt32(grdManholesRehabPrep.DataKeys[row.RowIndex].Values["AssetID"].ToString());
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;               

                if (selected)
                {
                    DateTime prepDate = Convert.ToDateTime(((Label)row.FindControl("lblPrepDate")).Text);

                    model.Update(assetId, prepDate, selected);
                }
            }

            model.Table.AcceptChanges();

            teamProjectTimeSectionMH = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MHDataTable)model.Table;
            Session["teamProjectTimeSection"] = teamProjectTimeSection;
            Session["teamProjectTime2TDS"] = teamProjectTime2TDS;
        }



        private void ManholesRehabSprayProcessGrid()
        {
            TeamProjectTime2SectionMH model = new TeamProjectTime2SectionMH(teamProjectTime2TDS);

            // Update rows
            foreach (GridViewRow row in grdManholesRehabSpray.Rows)
            {
                int assetId = Convert.ToInt32(grdManholesRehabSpray.DataKeys[row.RowIndex].Values["AssetID"].ToString());
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                if (selected)
                {
                    DateTime sprayDate = Convert.ToDateTime(((Label)row.FindControl("lblSprayDate")).Text);

                    model.Update(assetId, sprayDate, selected);
                }
            }

            model.Table.AcceptChanges();

            teamProjectTimeSectionMH = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MHDataTable)model.Table;
            Session["teamProjectTimeSection"] = teamProjectTimeSection;
            Session["teamProjectTime2TDS"] = teamProjectTime2TDS;
        }



        private void SectionsPrepAndMeasureProcessGrid()
        {
            TeamProjectTime2Section model = new TeamProjectTime2Section(teamProjectTime2TDS);

            // Update rows
            foreach (GridViewRow row in grdSections.Rows)
            {
                string sectionId = grdSections.DataKeys[row.RowIndex].Values["SectionID"].ToString();
                string flowOrderId = ((Label)row.FindControl("lblFlowOrderID")).Text;
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                bool completed = ((CheckBox)row.FindControl("cbxCompleted")).Checked;
                DateTime? prepDate = Convert.ToDateTime(((Label)row.FindControl("lblPrepDate")).Text);

                if (selected)
                {
                    if (completed)
                    {
                        if (prepDate != tkrdpDate_.SelectedDate.Value)
                        {
                            prepDate = tkrdpDate_.SelectedDate.Value;
                        }
                    }

                    model.Update(sectionId, completed, prepDate, selected);
                }
            }

            model.Table.AcceptChanges();

            teamProjectTimeSection = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable)model.Table;
            Session["teamProjectTimeSection"] = teamProjectTimeSection;
            Session["teamProjectTime2TDS"] = teamProjectTime2TDS;
        }



        private void LateralsProcessGrid()
        {
            TeamProjectTime2SectionLateral model = new TeamProjectTime2SectionLateral(teamProjectTime2TDS);

            foreach (GridViewRow rowSections in grdSectionsReinstatePostVideo.Rows)
            {
                int totalSelected = 0;
                int totalBrushed = 0;
                int totalOpened = 0;

                string sectionIdReinstatePostVideo = ((Label)rowSections.FindControl("lblSectionID")).Text;

                bool selectedSection = ((CheckBox)rowSections.FindControl("cbxSelected")).Checked;

                if (selectedSection)
                {
                    foreach (GridViewRow row in grdLaterals.Rows)
                    {
                        string sectionId = ((Label)row.FindControl("lblSectionID")).Text;
                        if (sectionId != "")
                        {
                            if (sectionId == sectionIdReinstatePostVideo)
                            {
                                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                                bool opened = ((CheckBox)row.FindControl("cbxOpened")).Checked;
                                bool brushed = ((CheckBox)row.FindControl("cbxBrushed")).Checked;
                                string lateralId = ((Label)row.FindControl("lblLateralID")).Text;

                                if (selected)
                                {
                                    totalSelected++;

                                    if (opened)
                                    {
                                        totalOpened++;
                                    }

                                    if (brushed)
                                    {
                                        totalBrushed++;
                                    }
                                }

                                model.Update(sectionId, lateralId, opened, brushed, selected);
                            }
                        }
                    }

                    if (totalSelected > 0)
                    {
                        if (totalOpened == totalSelected)
                        {
                            ((Label)rowSections.FindControl("lblPercentageOpened")).Text = "50";
                        }
                        else
                        {
                            double percentageOpened = ((double)totalOpened / (double)totalSelected) * 50;

                            if (percentageOpened >= 25)
                            {
                                ((Label)rowSections.FindControl("lblPercentageOpened")).Text = "25";
                            }
                            else
                            {
                                ((Label)rowSections.FindControl("lblPercentageOpened")).Text = "0";
                            }
                        }

                        if (totalBrushed == totalSelected)
                        {
                            ((Label)rowSections.FindControl("lblPercentageBrushed")).Text = "50";
                        }
                        else
                        {
                            double percentageBrushed = ((double)totalBrushed / (double)totalSelected) * 50;

                            if (percentageBrushed >= 25)
                            {
                                ((Label)rowSections.FindControl("lblPercentageBrushed")).Text = "25";
                            }
                            else
                            {
                                ((Label)rowSections.FindControl("lblPercentageBrushed")).Text = "0";
                            }
                        }

                        if ((totalOpened == totalSelected) && (totalBrushed == totalSelected))
                        {
                            ((CheckBox)rowSections.FindControl("cbxCompleted")).Checked = true;
                        }
                        else
                        {
                            ((CheckBox)rowSections.FindControl("cbxCompleted")).Checked = false;
                        }
                    }
                }
            }

            model.Table.AcceptChanges();

            teamProjectTimeSectionLateral = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_LATERALDataTable)model.Table;
            Session["teamProjectTimeSectionLateral"] = teamProjectTimeSectionLateral;
            Session["teamProjectTime2TDS"] = teamProjectTime2TDS;
        }



        public TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable GetSectionsInformation()
        {
            teamProjectTimeSection = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable)Session["teamProjectTimeSectionDummy"];

            if (teamProjectTimeSection == null)
            {
                teamProjectTimeSection = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable)Session["teamProjectTimeSection"];
            }

            return teamProjectTimeSection;
        }



        public TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable GetSectionsInstallInformation()
        {
            teamProjectTimeSection = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable)Session["teamProjectTimeSectionDummy"];

            if (teamProjectTimeSection == null)
            {
                teamProjectTimeSection = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable)Session["teamProjectTimeSection"];
            }

            return teamProjectTimeSection;
        }



        public TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable GetSectionsReinstatePostVideoInformation()
        {
            teamProjectTimeSection = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable)Session["teamProjectTimeSectionDummy"];

            if (teamProjectTimeSection == null)
            {
                teamProjectTimeSection = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable)Session["teamProjectTimeSection"];
            }

            return teamProjectTimeSection;
        }



        public TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MHDataTable GetSectionsManholesRehabPrepInformation()
        {
            teamProjectTimeSectionMH = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MHDataTable)Session["teamProjectTimeSectionMHDummy"];

            if (teamProjectTimeSectionMH == null)
            {
                teamProjectTimeSectionMH = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MHDataTable)Session["teamProjectTimeSectionMH"];
            }

            return teamProjectTimeSectionMH;
        }



        public TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MHDataTable GetSectionsManholesRehabSprayInformation()
        {
            teamProjectTimeSectionMH = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MHDataTable)Session["teamProjectTimeSectionMHDummy"];

            if (teamProjectTimeSectionMH == null)
            {
                teamProjectTimeSectionMH = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MHDataTable)Session["teamProjectTimeSectionMH"];
            }

            return teamProjectTimeSectionMH;
        }



        protected void SectionsInformationEmptyFix(GridView grdSections)
        {
            if (grdSections.Rows.Count == 0)
            {
                TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable dt = new TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable();
                dt.AddLFS_TEAM_PROJECT_TIME_SECTIONRow("1", "1", false, DateTime.Now, false, 0, 0);
                Session["teamProjectTimeSectionDummy"] = dt;

                grdSections.DataBind();
            }

            // Normally executes at all postbacks
            if (grdSections.Rows.Count == 1)
            {
                TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable dt = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable)Session["teamProjectTimeSectionDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdSections.Rows[0].Visible = false;
                    grdSections.Rows[0].Controls.Clear();
                }
            }
        }



        protected void SectionsInstallInformationEmptyFix(GridView grdSectionsInstall)
        {
            if (grdSectionsInstall.Rows.Count == 0)
            {
                TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable dt = new TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable();
                dt.AddLFS_TEAM_PROJECT_TIME_SECTIONRow("1", "1", false, DateTime.Now, false, 0, 0);
                Session["teamProjectTimeSectionDummy"] = dt;

                grdSectionsInstall.DataBind();
            }

            // Normally executes at all postbacks
            if (grdSectionsInstall.Rows.Count == 1)
            {
                TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable dt = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable)Session["teamProjectTimeSectionDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdSectionsInstall.Rows[0].Visible = false;
                    grdSectionsInstall.Rows[0].Controls.Clear();
                }
            }
        }



        protected void SectionsReinstatePostVideoInformationEmptyFix(GridView grdSectionsReinstatePostVideo)
        {
            if (grdSectionsReinstatePostVideo.Rows.Count == 0)
            {
                TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable dt = new TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable();
                dt.AddLFS_TEAM_PROJECT_TIME_SECTIONRow("1", "1", false, DateTime.Now, false, 0, 0);
                Session["teamProjectTimeSectionDummy"] = dt;

                grdSectionsReinstatePostVideo.DataBind();
            }

            // Normally executes at all postbacks
            if (grdSectionsReinstatePostVideo.Rows.Count == 1)
            {
                TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable dt = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable)Session["teamProjectTimeSectionDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdSectionsReinstatePostVideo.Rows[0].Visible = false;
                    grdSectionsReinstatePostVideo.Rows[0].Controls.Clear();
                }
            }
        }



        protected void ManholesRehabPrepInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MHDataTable dt = new TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MHDataTable();
                dt.AddLFS_TEAM_PROJECT_TIME_SECTION_MHRow(0, "", "", "", false, DateTime.Now);
                Session["teamProjectTimeSectionMHDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MHDataTable dt = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MHDataTable)Session["teamProjectTimeSectionMHDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        protected void ManholesRehabSprayInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MHDataTable dt = new TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MHDataTable();
                dt.AddLFS_TEAM_PROJECT_TIME_SECTION_MHRow(0, "", "", "", false, DateTime.Now);
                Session["teamProjectTimeSectionMHDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MHDataTable dt = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MHDataTable)Session["teamProjectTimeSectionMHDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        public TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_LATERALDataTable GetLateralsInformation()
        {
            teamProjectTimeSectionLateral = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_LATERALDataTable)Session["teamProjectTimeSectionLateralDummy"];

            if (teamProjectTimeSectionLateral == null)
            {
                teamProjectTimeSectionLateral = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_LATERALDataTable)Session["teamProjectTimeSectionLateral"];
            }

            teamProjectTimeSectionLateral.DefaultView.Sort = "SectionID ASC";

            return teamProjectTimeSectionLateral;
        }



        protected void LateralsInformationEmptyFix(GridView grdLaterals)
        {
            if (grdLaterals.Rows.Count == 0)
            {
                TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_LATERALDataTable dt = new TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_LATERALDataTable();
                dt.AddLFS_TEAM_PROJECT_TIME_SECTION_LATERALRow("A", "A", false, false, false, 1);
                Session["teamProjectTimeSectionLateralDummy"] = dt;

                grdLaterals.DataBind();
            }

            // Normally executes at all postbacks
            if (grdLaterals.Rows.Count == 1)
            {
                TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_LATERALDataTable dt = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_LATERALDataTable)Session["teamProjectTimeSectionLateralDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdLaterals.Rows[0].Visible = false;
                    grdLaterals.Rows[0].Controls.Clear();
                }
            }
        }



        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rbtnBeginTemplate.Checked)
            {
                odsProjectsInternalProjectsBallparkProjects.SelectParameters.RemoveAt(2);
                odsProjectsInternalProjectsBallparkProjects.SelectParameters.Add("ClientId", ddlClient.SelectedValue);
                odsProjectsInternalProjectsBallparkProjects.Select();
                odsProjectsInternalProjectsBallparkProjects.DataBind();

                ddlProject.DataSourceID = "odsProjectsInternalProjectsBallparkProjects";
                ddlProject.DataValueField = "ProjectID";
                ddlProject.DataTextField = "NAME";
                ddlProject.DataBind();

                ddlProject.SelectedIndex = 0;
            }
            if (rbtnBeginNew.Checked)
            {
                odsActiveProjectsActiveInternalProjectsActiveBallparkProjects.SelectParameters.RemoveAt(2);
                odsActiveProjectsActiveInternalProjectsActiveBallparkProjects.SelectParameters.Add("ClientId", ddlClient.SelectedValue);
                odsActiveProjectsActiveInternalProjectsActiveBallparkProjects.Select();
                odsActiveProjectsActiveInternalProjectsActiveBallparkProjects.DataBind();

                ddlProject.DataSourceID = "odsActiveProjectsActiveInternalProjectsActiveBallparkProjects";
                ddlProject.DataValueField = "ProjectID";
                ddlProject.DataTextField = "NAME";
                ddlProject.DataBind();

                ddlProject.SelectedIndex = 0;
            }

            rfvClient.Validate();
        }



        protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((ddlProject.SelectedValue != null) && (ddlProject.SelectedValue != "-1"))
            {
                ProjectGateway projectGateway = new ProjectGateway(new DataSet());
                projectGateway.LoadByProjectId(int.Parse(ddlProject.SelectedValue));

                switch (projectGateway.GetCountryID(int.Parse(ddlProject.SelectedValue)))
                {
                    case 1:
                        tbxWorkingDetails.Text = "Canada";
                        ddlMealsCountry.SelectedValue = "1";
                        break;
                    case 2:
                        tbxWorkingDetails.Text = "USA";
                        ddlMealsCountry.SelectedValue = "2";
                        break;
                }
            }

            rfvProject.Validate();
        }



        protected void ddlTypeOfWork_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectTimeWorkFunctionList projectTimeWorkFunctionList = new ProjectTimeWorkFunctionList();
            projectTimeWorkFunctionList.LoadActiveForAddAndAddItem("(Select a Function)", ddlTypeOfWork.SelectedValue);
            ddlFunction.DataSource = projectTimeWorkFunctionList.Table;
            ddlFunction.DataValueField = "Function_";
            ddlFunction.DataTextField = "Function_";
            ddlFunction.DataBind();
            ddlFunction.SelectedIndex = 0;

            rfvFunction.Validate();
        }



        protected void cbxSelectedSectionReinstatePostVideo_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            GridViewRow row = (GridViewRow)checkbox.NamingContainer;
            string sectionId = ((Label)row.FindControl("lblSectionID")).Text;
            TeamProjectTime2SectionLateral model = new TeamProjectTime2SectionLateral(teamProjectTime2TDS);
            
            if (sectionsReinstatePostVideoSelect == null)
            {
                sectionsReinstatePostVideoSelect = new ArrayList();
            }

            if (checkbox.Checked)
            {
                if (!sectionsReinstatePostVideoSelect.Contains(sectionId))
                {                    
                    LateralsProcessGrid();
                    model.Load(sectionId);
                    sectionsReinstatePostVideoSelect.Add(sectionId);
                }

                // Store tables
                teamProjectTimeSectionLateral = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_LATERALDataTable)model.Table;

                Session["teamProjectTimeSectionLateral"] = teamProjectTimeSectionLateral;
                Session["teamProjectTime2TDS"] = teamProjectTime2TDS;
                Session.Remove("teamProjectTimeSectionLateralDummy");

                grdLaterals.DataBind();

                upnlFullLengthReinstatePostVideo.Update();
            }
            else
            {
                if (sectionsReinstatePostVideoSelect.Contains(sectionId))
                {
                    sectionsReinstatePostVideoSelect.Remove(sectionId);

                    model.Delete(sectionId);

                    // Store tables
                    teamProjectTimeSectionLateral = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_LATERALDataTable)model.Table;

                    Session["teamProjectTimeSectionLateral"] = teamProjectTimeSectionLateral;
                    Session["teamProjectTime2TDS"] = teamProjectTime2TDS;
                    Session.Remove("teamProjectTimeSectionLateralDummy");

                    grdLaterals.DataBind();

                    upnlFullLengthReinstatePostVideo.Update();
                }
            }

            Session["sectionsReinstatePostVideoSelect"] = sectionsReinstatePostVideoSelect;
        }



        protected void ddlFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlFullLengthInstall.Visible = false;
            pnlFullLengthPrepMeasure.Visible = false;
            pnlFullLengthReinstatePostVideo.Visible = false;
            pnlSectionsManholesRehabPrep.Visible = false;
            pnlSectionsManholesRehabSpray.Visible = false;

            if (ddlTypeOfWork.SelectedValue == "Full Length")
            {
                TeamProjectTime2Section model = new TeamProjectTime2Section(teamProjectTime2TDS);

                switch (ddlFunction.SelectedValue)
                {
                    case "Install":
                        pnlFullLengthInstall.Visible = true;

                        model.LoadForFllInstall(Int32.Parse(ddlProject.SelectedValue), "Full Length Lining", tkrdpDate_.SelectedDate.Value);

                        // Store tables
                        teamProjectTimeSection = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable)model.Table;
                        Session["teamProjectTimeSection"] = teamProjectTimeSection;
                        Session["teamProjectTime2TDS"] = teamProjectTime2TDS;
                        grdSectionsInstall.DataBind();
                        break;

                    case "Prep & Measure":
                        pnlFullLengthPrepMeasure.Visible = true;

                        model.LoadForFllPrepAndMeasure(Int32.Parse(ddlProject.SelectedValue), "Full Length Lining", tkrdpDate_.SelectedDate.Value);

                        // Store tables
                        teamProjectTimeSection = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable)model.Table;
                        Session["teamProjectTimeSection"] = teamProjectTimeSection;
                        Session["teamProjectTime2TDS"] = teamProjectTime2TDS;
                        grdSections.DataBind();
                        break;

                    case "Reinstate & Post Video":
                        pnlFullLengthReinstatePostVideo.Visible = true;

                        model.LoadForFllReinstatePostVideo(Int32.Parse(ddlProject.SelectedValue), "Full Length Lining", tkrdpDate_.SelectedDate.Value);

                        // Store tables
                        teamProjectTimeSection = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTIONDataTable)model.Table;
                        Session["teamProjectTimeSection"] = teamProjectTimeSection;
                        Session["teamProjectTime2TDS"] = teamProjectTime2TDS;
                        grdSectionsReinstatePostVideo.DataBind();
                        break;
                }
            }
            else
            {
                if (ddlTypeOfWork.SelectedValue == "MH Rehab")
                {
                    TeamProjectTime2SectionMH model = new TeamProjectTime2SectionMH(teamProjectTime2TDS);
                    model.LoadByProjectIdAndUpdateDate(Convert.ToInt32(ddlProject.SelectedValue), tkrdpDate_.SelectedDate.Value, Convert.ToInt32(hdfCompanyId.Value));

                    // Store tables
                    teamProjectTimeSectionMH = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MHDataTable)model.Table;
                    Session["teamProjectTimeSectionMH"] = teamProjectTimeSectionMH;
                    Session["teamProjectTime2TDS"] = teamProjectTime2TDS;
                    Session.Remove("teamProjectTimeSectionMHDummy");

                    switch (ddlFunction.SelectedValue)
                    {
                        case "Prep":
                            pnlSectionsManholesRehabPrep.Visible = true;
                            grdManholesRehabPrep.DataBind();
                            break;

                        case "Spray":
                            pnlSectionsManholesRehabSpray.Visible = true;
                            grdManholesRehabSpray.DataBind();
                            break;
                    }
                }
            }

            upnlFullLengthInstall.Update();
            upnlFullLengthPrepMeasure.Update();
            upnlFullLengthReinstatePostVideo.Update();
            upnlManholesRehabPrep.Update();
            upnlManholesRehabSpray.Update();
        }



        protected void ddlSectionsManholesRehabPrep_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TeamProjectTime2SectionMH model = new TeamProjectTime2SectionMH(teamProjectTime2TDS);
            //model.Load(ddlSectionsManholesRehabPrep.SelectedValue, tkrdpDate_.SelectedDate.Value, Convert.ToInt32(hdfCompanyId.Value));

            //// Store tables
            //teamProjectTimeSectionMH = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MHDataTable)model.Table;
            //Session["teamProjectTimeSectionMH"] = teamProjectTimeSectionMH;
            //Session["teamProjectTime2TDS"] = teamProjectTime2TDS;
            //Session.Remove("teamProjectTimeSectionMHDummy");

            //grdManholesRehabPrep.DataBind();

            //upnlManholesRehabPrep.Update();
        }



        protected void ddlSectionsManholesRehabSpray_SelectedIndexChanged(object sender, EventArgs e)
        {
            //TeamProjectTime2SectionMH model = new TeamProjectTime2SectionMH(teamProjectTime2TDS);
            //model.Load(ddlSectionsManholesRehabSpray.SelectedValue, tkrdpDate_.SelectedDate.Value, Convert.ToInt32(hdfCompanyId.Value));

            //// Store tables
            //teamProjectTimeSectionMH = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_SECTION_MHDataTable)model.Table;
            //Session["teamProjectTimeSectionMH"] = teamProjectTimeSectionMH;
            //Session["teamProjectTime2TDS"] = teamProjectTime2TDS;
            //Session.Remove("teamProjectTimeSectionMHDummy");

            //grdManholesRehabSpray.DataBind();

            //upnlManholesRehabSpray.Update();
        }



        protected void cvLunchFormat_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = (Validator.IsValidDouble(args.Value.Trim())) ? true : false;
        }



        protected void cvPrepMeasureSections_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool isValid = false;

            foreach (GridViewRow row in grdSections.Rows)
            {
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                if (selected)
                {
                    isValid = true;
                }
            }

            args.IsValid = isValid;
        }



        protected void cvInstallSections_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool isValid = false;

            foreach (GridViewRow row in grdSectionsInstall.Rows)
            {
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                if (selected)
                {
                    isValid = true;
                }
            }

            args.IsValid = isValid;
        }



        protected void cvReinstatePostVideoSections_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool isValid = false;

            foreach (GridViewRow row in grdSectionsReinstatePostVideo.Rows)
            {
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                if (selected)
                {
                    isValid = true;
                }
            }

            args.IsValid = isValid;
        }



        protected void cvManholesRehabPrep_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool isValid = false;

            foreach (GridViewRow row in grdManholesRehabPrep.Rows)
            {
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                if (selected)
                {
                    isValid = true;
                }
            }

            args.IsValid = isValid;
        }



        protected void cvManholesRehabSpray_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool isValid = false;

            foreach (GridViewRow row in grdManholesRehabSpray.Rows)
            {
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;

                if (selected)
                {
                    isValid = true;
                }
            }

            args.IsValid = isValid;
        }



        protected void cvReinstatePostVideoLaterals_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool isValid = false;

            foreach (GridViewRow row in grdLaterals.Rows)
            {
                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                bool opened = ((CheckBox)row.FindControl("cbxOpened")).Checked;
                bool brushed = ((CheckBox)row.FindControl("cbxBrushed")).Checked;

                if (selected)
                {
                    if (opened || brushed)
                    {
                        isValid = true;
                    }
                }
            }

            args.IsValid = isValid;
        }



        protected void cvProject_ServerValidate(object source, ServerValidateEventArgs args)
        {
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(Convert.ToInt32(ddlProject.SelectedValue));

            if (projectGateway.GetProjectState(Convert.ToInt32(ddlProject.SelectedValue)) != "Active")
            {
                if (projectGateway.GetProjectType(Convert.ToInt32(ddlProject.SelectedValue)) != "Ballpark")
                {
                    cvProject.ErrorMessage = "Please select an active project or an active internal project";
                }

                if (projectGateway.GetProjectType(Convert.ToInt32(ddlProject.SelectedValue)) == "Ballpark")
                {
                    cvProject.ErrorMessage = "Please select an active ballpark";
                }

                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }



        protected void cvValidStartTime_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            if ((ddlStartTimeHour.SelectedValue.Trim() != "") && (ddlStartTimeMinute.SelectedValue.Trim() != ""))
            {
                args.IsValid = true;
            }

            if ((ddlStartTimeHour.SelectedValue.Trim() == "") && (ddlStartTimeMinute.SelectedValue.Trim() == ""))
            {
                args.IsValid = true;
            }
        }



        protected void cvValidEndTime_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            if ((ddlEndTimeHour.SelectedValue.Trim() != "") && (ddlEndTimeMinute.SelectedValue.Trim() != ""))
            {
                args.IsValid = true;
            }

            if ((ddlEndTimeHour.SelectedValue.Trim() == "") && (ddlEndTimeMinute.SelectedValue.Trim() == ""))
            {
                args.IsValid = true;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - DATA - METHODS
        //

        private void StepDataIn()
        {
            // Set instruction
            mWizard2 master = (mWizard2)this.Master;
            master.WizardInstruction = "Please define global data, it will be applied to your team members on the next step.";

            // Wizard type & step from check
            if ((hdfNewOrTemplate.Value == "New") && ((string)ViewState["StepFrom"] != "Employees"))
            {
                // Prepare initial data
                ddlClient.Enabled = true;
                ddlProject.Enabled = true;

                ProjectTimeWorkList projectTimeWorkList = new ProjectTimeWorkList(new DataSet());
                projectTimeWorkList.LoadAndAddItem("(Select a Type)");
                ddlTypeOfWork.DataSource = projectTimeWorkList.Table;
                ddlTypeOfWork.DataValueField = "Work_";
                ddlTypeOfWork.DataTextField = "Work_";
                ddlTypeOfWork.DataBind();
                ddlTypeOfWork.SelectedIndex = 0;

                ProjectTimeWorkFunctionList projectTimeWorkFunctionList = new ProjectTimeWorkFunctionList(new DataSet());
                projectTimeWorkFunctionList.LoadActiveForAddAndAddItem("(Select a Function)", "-1");
                ddlFunction.DataSource = projectTimeWorkFunctionList.Table;
                ddlFunction.DataValueField = "Function_";
                ddlFunction.DataTextField = "Function_";
                ddlFunction.DataBind();
                ddlFunction.SelectedIndex = 0;
            }
            else
            {
                TeamProjectTime2Gateway teamProjectTime2Gateway = new TeamProjectTime2Gateway(teamProjectTime2TDS);
                TeamProjectTime2DetailTemp teamProjectTime2DetailTemp = new TeamProjectTime2DetailTemp(teamProjectTime2TDS);

                // Prepare initial data
                if ((string)ViewState["StepFrom"] == "Template")
                {
                    ViewState["teamProjectTimeId"] = Int32.Parse(hdfSelectedIdTemplate.Value);

                    // ... for TeamProjectTime
                    teamProjectTime2Gateway.LoadByTeamProjectTimeId((int)ViewState["teamProjectTimeId"]);

                    // ... for TeamProjectTimeDetailTemp
                    teamProjectTime2DetailTemp.LoadAllByTeamProjectTimeId((int)ViewState["teamProjectTimeId"]);
                }

                // ... for Client
                string companiesId = teamProjectTime2Gateway.GetCompaniesId((int)ViewState["teamProjectTimeId"]).ToString();

                int companyId = Int32.Parse(hdfCompanyId.Value);
                CompaniesGateway companiesGateway = new CompaniesGateway();
                companiesGateway.LoadAllByCompaniesId(Int32.Parse(companiesId), companyId);

                // ... If Company is active
                bool deleted = companiesGateway.GetDeleted(Int32.Parse(companiesId));

                if (deleted)
                {
                    ddlClient.SelectedIndex = -1;
                }
                else
                {
                    ddlClient.SelectedValue = companiesId;
                }

                if (ddlClient.SelectedValue.Length == 0)
                {
                    odsClient.DataBind();
                    ddlClient.DataSourceID = "odsClient";
                    ddlClient.DataValueField = "COMPANIES_ID";
                    ddlClient.DataTextField = "Name";
                    ddlClient.DataBind();

                    if (deleted)
                    {
                        ddlClient.SelectedIndex = -1;
                    }
                    else
                    {
                        ddlClient.SelectedValue = companiesId;
                    }
                }

                if (!deleted)
                {
                    // ... for project
                    odsProjectsInternalProjectsBallparkProjects.SelectParameters.RemoveAt(2);
                    odsProjectsInternalProjectsBallparkProjects.SelectParameters.Add("ClientId", ddlClient.SelectedValue);
                    odsProjectsInternalProjectsBallparkProjects.Select();
                    odsProjectsInternalProjectsBallparkProjects.DataBind();

                    ddlProject.DataSourceID = "odsProjectsInternalProjectsBallparkProjects";
                    ddlProject.DataValueField = "ProjectID";
                    ddlProject.DataTextField = "NAME";
                    ddlProject.DataBind();

                    try
                    {
                        ddlProject.SelectedValue = teamProjectTime2Gateway.GetProjectId((int)ViewState["teamProjectTimeId"]).ToString();
                    }
                    catch
                    {
                        ddlProject.SelectedIndex = -1;
                    }
                }
                else
                {
                    ddlProject.SelectedIndex = -1;
                }

                // ... for Date
                if ((string)ViewState["StepFrom"] == "Employees")
                {
                    tkrdpDate_.SelectedDate = teamProjectTime2Gateway.GetDate_((int)ViewState["teamProjectTimeId"]);
                }

                // ... for Type of work
                ProjectTimeWorkList projectTimeWorkList = new ProjectTimeWorkList(new DataSet());
                projectTimeWorkList.LoadAndAddItem("(Select a Type)");
                ddlTypeOfWork.DataSource = projectTimeWorkList.Table;
                ddlTypeOfWork.DataValueField = "Work_";
                ddlTypeOfWork.DataTextField = "Work_";
                ddlTypeOfWork.DataBind();

                if (teamProjectTime2Gateway.GetWork((int)ViewState["teamProjectTimeId"]).ToString() == "")
                {
                    ddlTypeOfWork.SelectedValue = "(Select a Type)";
                }
                else
                {
                    ddlTypeOfWork.SelectedValue = (string)teamProjectTime2Gateway.GetWork((int)ViewState["teamProjectTimeId"]);
                }

                // ... for function
                ProjectTimeWorkFunctionList projectTimeWorkFunctionList = new ProjectTimeWorkFunctionList(new DataSet());
                if (teamProjectTime2Gateway.GetWork((int)ViewState["teamProjectTimeId"]).ToString() == "")
                {
                    // ... If there is no type of Work, no function should be loaded
                    projectTimeWorkFunctionList.LoadActiveForAddAndAddItem("(Select a Function)", "-1");
                }
                else
                {
                    projectTimeWorkFunctionList.LoadActiveForAddAndAddItem("(Select a Function)", teamProjectTime2Gateway.GetWork((int)ViewState["teamProjectTimeId"]));
                }

                ddlFunction.DataSource = projectTimeWorkFunctionList.Table;
                ddlFunction.DataValueField = "Function_";
                ddlFunction.DataTextField = "Function_";
                ddlFunction.DataBind();

                if (teamProjectTime2Gateway.GetWork((int)ViewState["teamProjectTimeId"]).ToString() == "")
                {
                    ddlFunction.SelectedValue = "(Select a Function)";
                }
                else
                {
                    ddlFunction.SelectedValue = (string)teamProjectTime2Gateway.GetFunction((int)ViewState["teamProjectTimeId"]);
                }

                // ... for working details
                if (!deleted)
                {
                    tbxWorkingDetails.Text = teamProjectTime2Gateway.GetWorkingDetails((int)ViewState["teamProjectTimeId"]);
                }
                else
                {
                    tbxWorkingDetails.Text = "";
                }

                // ... for start time
                if (teamProjectTime2Gateway.GetStartTime((int)ViewState["teamProjectTimeId"]).HasValue)
                {
                    string startTime = ((DateTime)teamProjectTime2Gateway.GetStartTime((int)ViewState["teamProjectTimeId"])).ToString("H:mm");
                    string[] hoursMin1 = startTime.Split(':');
                    ddlStartTimeHour.SelectedValue = hoursMin1[0].Trim();
                    ddlStartTimeMinute.SelectedValue = hoursMin1[1].Trim();
                }

                // ... for end time
                if (teamProjectTime2Gateway.GetEndTime((int)ViewState["teamProjectTimeId"]).HasValue)
                {
                    string endTime = ((DateTime)teamProjectTime2Gateway.GetEndTime((int)ViewState["teamProjectTimeId"])).ToString("H:mm");
                    string[] endHoursMin1 = endTime.Split(':');
                    ddlEndTimeHour.SelectedValue = endHoursMin1[0].Trim();
                    ddlEndTimeMinute.SelectedValue = endHoursMin1[1].Trim();
                }

                // ... for offset
                if (teamProjectTime2Gateway.GetOffset((int)ViewState["teamProjectTimeId"]).HasValue) ddlLunch.SelectedValue = Math.Round(teamProjectTime2Gateway.GetOffset((int)ViewState["teamProjectTimeId"]).Value, 2).ToString();

                // ... for meals country
                if (!deleted)
                {
                    if (teamProjectTime2Gateway.GetMealsCountry((int)ViewState["teamProjectTimeId"]).HasValue)
                    {
                        ddlMealsCountry.SelectedValue = teamProjectTime2Gateway.GetMealsCountry((int)ViewState["teamProjectTimeId"]).Value.ToString();
                    }
                    else
                    {
                        ddlMealsCountry.SelectedIndex = 0;
                    }
                }
                else
                {
                    ddlMealsCountry.SelectedIndex = -1;
                }

                // ... for meals allowance
                //if (teamProjectTime2Gateway.GetMealsAllowance((int)ViewState["teamProjectTimeId"]) > 0) cbxMealsAllowance.Checked = true;

                // ... for fair wage
                if (teamProjectTime2Gateway.GetFairWage((int)ViewState["teamProjectTimeId"])) hdfFairWage.Value = "True";

                // Store datasets
                Session["teamProjectTime2TDS"] = teamProjectTime2TDS;
                template = teamProjectTime2TDS.Template;
                Session["template"] = teamProjectTime2TDS.Template;
            }

            //cbxClearUnitAssigment.Checked = false;
        }



        private bool StepDataNext()
        {
            if (ValidateStepData())
            {
                PostStepDataChanges();

                if (ddlTypeOfWork.SelectedValue == "Full Length")
                {
                    switch (ddlFunction.SelectedValue)
                    {
                        case "Install":
                            SectionsInstallProcessGrid();
                            break;

                        case "Prep & Measure":
                            SectionsPrepAndMeasureProcessGrid();
                            break;

                        case "Reinstate & Post Video":
                            SectionsReinstatePostVideoProcessGrid();
                            break;
                    }
                }
                else
                {
                    if (ddlTypeOfWork.SelectedValue == "MH Rehab")
                    {
                        switch (ddlFunction.SelectedValue)
                        {
                            case "Prep":
                                ManholesRehabPrepProcessGrid();
                                break;

                            case "Spray":
                                ManholesRehabSprayProcessGrid();
                                break;
                        }
                    }
                }

                if ((ddlProject.SelectedValue != null) && (ddlProject.SelectedValue != "-1"))
                {
                    ProjectGateway projectGateway = new ProjectGateway(new DataSet());
                    projectGateway.LoadByProjectId(int.Parse(ddlProject.SelectedValue));

                    if (projectGateway.GetFairWageApplies(int.Parse(ddlProject.SelectedValue)))
                    {
                        if (projectGateway.GetCountryID(Int32.Parse(ddlProject.SelectedValue)) == 1) //Canada
                        {
                            odsJobClassType.SelectParameters.Clear();
                            odsJobClassType.SelectParameters.Add("countryId", "1");
                            odsJobClassType.SelectParameters.Add("jobClassType", "(Select a Job Class Type)");
                            odsJobClassType.SelectParameters.Add("companyId", "3");
                            odsJobClassType.Select();
                        }
                        else
                        {
                            odsJobClassType.SelectParameters.Clear();
                            odsJobClassType.SelectParameters.Add("countryId", "2");
                            odsJobClassType.SelectParameters.Add("jobClassType", "(Select a Job Class Type)");
                            odsJobClassType.SelectParameters.Add("companyId", "3");
                            odsJobClassType.Select();
                        }
                    }
                    else
                    {
                        odsJobClassType.SelectParameters.Clear();
                        odsJobClassType.SelectParameters.Add("countryId", "-1");
                        odsJobClassType.SelectParameters.Add("jobClassType", "");
                        odsJobClassType.SelectParameters.Add("companyId", "3");
                        odsJobClassType.Select();
                    }
                }

                return true;
            }
            else
            {
                return false;
            }
        }



        private bool ValidateStepData()
        {
            Page.Validate("generalValidData");
            if (Page.IsValid)
            {
                rfvClient.Validate();
                rfvProject.Validate();
                rfvDate.Validate();
                rfvTypeOfWork.Validate();
                rfvFunction.Validate();
                //cvLunchFormat.Validate();
                cvProject.Validate();

                if (ddlTypeOfWork.SelectedValue == "Full Length")
                {
                    switch (ddlFunction.SelectedValue)
                    {
                        case "Install":
                            Page.Validate("generalValidInstall");
                            break;

                        case "Prep & Measure":
                            Page.Validate("generalValidPrepMeasure");
                            break;

                        case "Reinstate & Post Video":
                            Page.Validate("generalValidReinstatePostVideo");
                            break;

                        case "Prep":
                            Page.Validate("generalValidManholesRehabPrep");
                            break;

                        case "Spray":
                            Page.Validate("generalValidManholesRehabPrep");
                            break;
                    }
                }
                else
                {
                    if (ddlTypeOfWork.SelectedValue == "MH Rehab")
                    {
                        switch (ddlFunction.SelectedValue)
                        {
                            case "Prep":
                                Page.Validate("generalValidManholesRehabPrep");
                                break;

                            case "Spray":
                                Page.Validate("generalValidManholesRehabSpray");
                                break;
                        }
                    }
                }

                if (Page.IsValid)
                {
                    int companyId = Convert.ToInt32(Session["companyID"]);

                    cvDatePayPeriod.IsValid = (tkrdpDate_.SelectedDate != null) ? LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateExistPayPeriod(tkrdpDate_.SelectedDate.Value) : false;

                    if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"]))
                    {
                        if (Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT"]))
                        {
                            cvDateLimitedPayPeriod.IsValid = (tkrdpDate_.SelectedDate != null) ? LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateLimitedPayPeriodToManagementEdit(tkrdpDate_.SelectedDate.Value, Int32.Parse(ddlProject.SelectedValue)) : false;
                            cvDateLimitedPayPeriodForWed.IsValid = cvDateLimitedPayPeriod.IsValid;
                        }
                        else
                        {
                            if (Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_MY_TIMESHEETS_MANAGEMENT_WED"]) || Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_OTHERS_TIMESHEETS_MANAGEMENT_WED"]))
                            {
                                cvDateLimitedPayPeriodForWed.IsValid = (tkrdpDate_.SelectedDate != null) ? LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateLimitedPayPeriodToWednesdayManagementEdit(tkrdpDate_.SelectedDate.Value, Int32.Parse(ddlProject.SelectedValue)) : false;
                                cvDateLimitedPayPeriod.IsValid = cvDateLimitedPayPeriodForWed.IsValid;
                            }
                        }
                    }

                    DateTime? startTime = null;
                    if ((ddlStartTimeHour.SelectedValue.Trim() != "") && (ddlStartTimeMinute.SelectedValue.Trim() != ""))
                    {
                        startTime = DateTime.Parse(ddlStartTimeHour.SelectedValue.Trim() + ":" + ddlStartTimeMinute.SelectedValue.Trim());
                    }

                    DateTime? endTime = null;
                    if ((ddlEndTimeHour.SelectedValue.Trim() != "") && (ddlEndTimeMinute.SelectedValue.Trim() != ""))
                    {
                        endTime = DateTime.Parse(ddlEndTimeHour.SelectedValue.Trim() + ":" + ddlEndTimeMinute.SelectedValue.Trim());
                    }

                    cvStartTimeDelete.IsValid = LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateNotExistFieldForWorkingDetails(tbxWorkingDetails.Text, startTime.ToString());
                    cvStartTimeProvide.IsValid = LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateExistFieldForWorkingDetails(tbxWorkingDetails.Text, startTime.ToString());
                    cvEndTimeDelete.IsValid = LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateNotExistFieldForWorkingDetails(tbxWorkingDetails.Text, endTime.ToString());
                    cvEndTimeProvide.IsValid = LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateExistFieldForWorkingDetails(tbxWorkingDetails.Text, endTime.ToString());
                    cvLunchDelete.IsValid = true;

                    //cvMealsCountry.IsValid = LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateMealsCountry(ddlMealsCountry.SelectedValue, cbxMealsAllowance.Checked);

                    if (rfvClient.IsValid && rfvProject.IsValid && rfvDate.IsValid && cvDatePayPeriod.IsValid && cvDateLimitedPayPeriod.IsValid && cvDateLimitedPayPeriodForWed.IsValid && cvStartTimeDelete.IsValid && cvStartTimeProvide.IsValid && cvEndTimeDelete.IsValid && cvEndTimeProvide.IsValid && cvLunchDelete.IsValid)
                    {
                        cvProjectTime.IsValid = LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateProjectTime(startTime.ToString(), endTime.ToString(), ddlLunch.SelectedValue);
                    }

                    if (rfvClient.IsValid && rfvProject.IsValid && rfvDate.IsValid && cvDatePayPeriod.IsValid && cvDateLimitedPayPeriod.IsValid && cvDateLimitedPayPeriodForWed.IsValid && cvStartTimeDelete.IsValid && cvStartTimeProvide.IsValid && cvEndTimeDelete.IsValid && cvEndTimeProvide.IsValid && cvLunchDelete.IsValid && cvProjectTime.IsValid && cvProject.IsValid)
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
            return false;
        }



        private void PostStepDataChanges()
        {
            int teamProjectTimeId = (int)ViewState["teamProjectTimeId"];
            string templateName = "";
            int companiesId = int.Parse(ddlClient.SelectedValue);
            int projectId = int.Parse(ddlProject.SelectedValue);
            DateTime date_ = tkrdpDate_.SelectedDate.Value;
            string workingDetails = ""; if (tbxWorkingDetails.Text != "(Select)") workingDetails = tbxWorkingDetails.Text;
            string work_ = ddlTypeOfWork.SelectedValue;
            string function_ = ddlFunction.SelectedValue;

            ProjectGateway projectGateway = new ProjectGateway(new DataSet());
            projectGateway.LoadByProjectId(projectId);

            CountryGateway countryGateway = new CountryGateway(new DataSet());
            countryGateway.LoadByCountryId(projectGateway.GetCountryID(projectId));

            string location = countryGateway.GetName(projectGateway.GetCountryID(projectId));

            DateTime? startTime = null;
            if ((ddlStartTimeHour.SelectedValue.Trim() != "") && (ddlStartTimeMinute.SelectedValue.Trim() != "") )
            {
                startTime = new DateTime(date_.Year, date_.Month, date_.Day, Int32.Parse(ddlStartTimeHour.SelectedValue), Int32.Parse(ddlStartTimeMinute.SelectedValue), 0);
            }

            DateTime? endTime = null;
            if ((ddlEndTimeHour.SelectedValue.Trim() != "") && (ddlEndTimeMinute.SelectedValue.Trim() != "") )
            {
                endTime = new DateTime(date_.Year, date_.Month, date_.Day, Int32.Parse(ddlEndTimeHour.SelectedValue), Int32.Parse(ddlEndTimeMinute.SelectedValue), 0);
            }
            
            double? offset = 0; if (ddlLunch.SelectedValue != "0") offset = double.Parse(ddlLunch.SelectedValue);
            Int64? mealsCountry = null; if (ddlMealsCountry.SelectedValue != "-1") mealsCountry = Int64.Parse(ddlMealsCountry.SelectedValue);
            string mealsAllowanceType = ""; //if (cbxMealsAllowance.Checked) mealsAllowanceType = "Full Day";
            decimal mealsAllowance = MealsAllowance.GetMealsAllowance(mealsCountry, false, "Full Day");
            string comments = "";
            string type = "Template";
            string state = "Done";
            int loginId = Convert.ToInt32(Session["loginID"]);
            bool deleted = false;
            int? unitId = null;
            int? towedUnitId = null;
            bool fairWage = false; if (hdfFairWage.Value == "True") fairWage = true; 

            // New template check
            TeamProjectTime2 teamProjectTime2 = new TeamProjectTime2(teamProjectTime2TDS);
            if (((int)ViewState["teamProjectTimeId"] == 0) && ((string)ViewState["StepFrom"] != "Employees"))
            {
                // ... Insert team project time
                teamProjectTime2.Insert(teamProjectTimeId, templateName, companiesId, projectId, date_, startTime, endTime, offset, workingDetails, location, mealsCountry, mealsAllowanceType, mealsAllowance, unitId, towedUnitId, comments, type, state, loginId, deleted, work_, function_, fairWage);
            }
            else
            {
                // ... Update team project time
                teamProjectTime2.Update(teamProjectTimeId, templateName, companiesId, projectId, date_, startTime, endTime, offset, workingDetails, location, mealsCountry, mealsAllowanceType, mealsAllowance, unitId, towedUnitId, comments, type, state, loginId, deleted, work_, function_, fairWage);
            }

            // Store date in date edit for employees step
            tbxDate.Text = tkrdpDate_.SelectedDate.Value.ToString();
            hdfDate.Value = tkrdpDate_.SelectedDate.Value.ToString();

            // Store data in hidden components for employees step
            hdfTeamProjectTimeID.Value = teamProjectTimeId.ToString();
            hdfCompaniesID.Value = companiesId.ToString();
            hdfProjectID.Value = projectId.ToString();

            string startTimeForNextStep = "";
            if ((ddlStartTimeHour.SelectedValue.Trim() != "") && (ddlStartTimeMinute.SelectedValue.Trim() != ""))
            {
                startTimeForNextStep = ddlStartTimeHour.SelectedValue.Trim() + ":" + ddlStartTimeMinute.SelectedValue.Trim();
            }
            hdfStartTime.Value = startTimeForNextStep;

            string endTimeForNextStep = "";
            if ((ddlEndTimeHour.SelectedValue.Trim() != "") && (ddlEndTimeMinute.SelectedValue.Trim() != ""))
            {
                endTimeForNextStep = ddlEndTimeHour.SelectedValue.Trim() + ":" + ddlEndTimeMinute.SelectedValue.Trim();
            }            

            hdfEndTime.Value = endTimeForNextStep;
            if (offset != null) hdfOffset.Value = offset.ToString(); else hdfOffset.Value = "";
            hdfWorkingDetails.Value = workingDetails.ToString();
            hdfLocation.Value = location.ToString();
            hdfMealsCountry.Value = ddlMealsCountry.SelectedValue;
            hdfIsMealsAllowance.Value = "false";// cbxMealsAllowance.Checked.ToString();
            hdfMealsAllowance.Value = mealsAllowance.ToString();
            hdfProjectTimeState.Value = "For Approval"; if ((string)ViewState["LHMode"] == "Partial") hdfProjectTimeState.Value = "Approved";
            //if (cbxClearUnitAssigment.Checked) 
            hdfClearUnitAssigment.Value = "false";

            // ... For work and function string
            hdfWork_.Value = work_;
            hdfFunction_.Value = function_;
            hdfWorkFunctionConcat.Value = work_ + " . " + function_;
            
            // Clear Unit Assigment validation
            //if (cbxClearUnitAssigment.Checked)
            //{
            //    // ... Update detail
            //    TeamProjectTime2DetailTemp teamProjectTime2DetailTemp = new TeamProjectTime2DetailTemp(teamProjectTime2TDS);
            //    teamProjectTime2DetailTemp.UpdateAll(teamProjectTimeId);
            //}
            //else
            //{
                // ... Update detail
                TeamProjectTime2DetailTemp teamProjectTime2DetailTemp = new TeamProjectTime2DetailTemp(teamProjectTime2TDS);
                teamProjectTime2DetailTemp.UpdateAll(teamProjectTimeId, false);
            //}

            // Store datasets
            Session["teamProjectTime2TDS"] = teamProjectTime2TDS;
            teamProjectTimeDetailTemp = teamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMP;
            Session["teamProjectTimeDetailTemp"] = teamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMP;
        }

        #endregion






        #region STEP4 - EMPLOYEES

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP4 - EMPLOYEES
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - EMPLOYEES - EVENTS
        //

        protected void grdProjectTime_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Project Time Gridview, if the gridview is edition mode
            if (grdProjectTime.EditIndex >= 0)
            {
                grdProjectTime.UpdateRow(grdProjectTime.EditIndex, true);
            }

            // Delete project time
            int teamProjectTimeId = (int)e.Keys["TeamProjectTimeID"];
            int detailId = (int)e.Keys["DetailID"];

            // Delete team project time details
            TeamProjectTime2DetailTemp teamProjectTime2Detail = new TeamProjectTime2DetailTemp(teamProjectTime2TDS);
            teamProjectTime2Detail.Delete(teamProjectTimeId, detailId);

            // Store dataset
            Session["teamProjectTime2TDS"] = teamProjectTime2TDS;
            Session.Remove("teamProjectTimeDetailTempDummy");
            teamProjectTimeDetailTemp = teamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMP;
            Session["teamProjectTimeDetailTemp"] = teamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMP;
        }



        protected void grdProjectTime_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Project Time Gridview, if the gridview is edition mode
                    if (grdProjectTime.EditIndex >= 0)
                    {
                        grdProjectTime.UpdateRow(grdProjectTime.EditIndex, true);
                    }

                    // Add New Project Time
                    GrdTeamProjectTimeDetailAdd();
                    break;
            }
        }



        protected void grdProjectTime_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Page.Validate("editValidData");
            if (Page.IsValid)
            {
                Page.Validate("editData");
                if (Page.IsValid)
                {
                    int teamProjectTimeId = (int)e.Keys["TeamProjectTimeID"];
                    int detailId = (int)e.Keys["DetailID"];
                    DateTime date_ = DateTime.Parse(hdfDate.Value);

                    int employeeId = Int32.Parse(((DropDownList)grdProjectTime.Rows[e.RowIndex].Cells[3].FindControl("ddlEmployeesEdit")).SelectedValue);
                    int companiesId = int.Parse(ddlClient.SelectedValue);
                    int projectId = int.Parse(ddlProject.SelectedValue);
                    Int64? mealsCountry = null; if (ddlMealsCountry.SelectedValue != "-1") mealsCountry = Int64.Parse(ddlMealsCountry.SelectedValue);
                    string startTime = "";
                    string startHoursEdit = ((DropDownList)grdProjectTime.Rows[e.RowIndex].Cells[3].FindControl("ddlStartTimeHourEdit")).SelectedValue.Trim();
                    string startMinutesEdit = ((DropDownList)grdProjectTime.Rows[e.RowIndex].Cells[3].FindControl("ddlStartTimeMinuteEdit")).SelectedValue.Trim();

                    if ((startHoursEdit != "") && (startMinutesEdit != ""))
                    {
                        startTime = startHoursEdit + ":" + startMinutesEdit;
                    }

                    string endTime = "";
                    string endHoursEdit = ((DropDownList)grdProjectTime.Rows[e.RowIndex].Cells[3].FindControl("ddlEndTimeHourEdit")).SelectedValue.Trim();
                    string endMinutesEdit = ((DropDownList)grdProjectTime.Rows[e.RowIndex].Cells[3].FindControl("ddlEndTimeMinuteEdit")).SelectedValue.Trim();

                    if ((endHoursEdit != "") && (endMinutesEdit != ""))
                    {
                        endTime = endHoursEdit + ":" + endMinutesEdit;
                    }

                    decimal? offset = 0; if (((DropDownList)grdProjectTime.Rows[e.RowIndex].Cells[3].FindControl("ddlLunchEdit")).SelectedValue != "0") offset = decimal.Round(Decimal.Parse(((DropDownList)grdProjectTime.Rows[e.RowIndex].Cells[3].FindControl("ddlLunchEdit")).SelectedValue), 2);
                    double? offsetFinal = null; if (offset.HasValue) offsetFinal = double.Parse(((decimal)offset).ToString());
                    string workingDetails = tbxWorkingDetails.Text;
                    bool isMealsAllowance = false;// ((CheckBox)grdProjectTime.Rows[e.RowIndex].Cells[3].FindControl("ckbxMealsAllowanceEdit")).Checked;
                    int? unitId = null; if (((DropDownList)grdProjectTime.Rows[e.RowIndex].Cells[3].FindControl("ddlUnitEdit")).SelectedValue != "-1") unitId = Int32.Parse(((DropDownList)grdProjectTime.Rows[e.RowIndex].Cells[3].FindControl("ddlUnitEdit")).SelectedValue);
                    int? towedUnitId = null; if (((DropDownList)grdProjectTime.Rows[e.RowIndex].Cells[3].FindControl("ddlTowedEdit")).SelectedValue != "-1") towedUnitId = Int32.Parse(((DropDownList)grdProjectTime.Rows[e.RowIndex].Cells[3].FindControl("ddlTowedEdit")).SelectedValue);
                    string comments = ((TextBox)grdProjectTime.Rows[e.RowIndex].Cells[3].FindControl("tbxCommentsEdit")).Text;
                    string workFunctionConcat = ((DropDownList)grdProjectTime.Rows[e.RowIndex].Cells[3].FindControl("ddlTypeOfWorkFunctionEdit")).SelectedValue;

                    string work_ = "";
                    string function_ = "";
                    if (workFunctionConcat != "(Select)")
                    {
                        string[] workFunction = workFunctionConcat.ToString().Trim().Split('.');
                        work_ = workFunction[0].Trim();
                        function_ = workFunction[1].Trim();
                    }

                    bool fairWage = false; if (hdfFairWage.Value == "True") fairWage = true; 
					string jobClassType = ((DropDownList)grdProjectTime.Rows[e.RowIndex].Cells[3].FindControl("ddlJobClassTypeEdit")).SelectedValue;

                    ProjectGateway projectGateway = new ProjectGateway(new DataSet());
                    projectGateway.LoadByProjectId(projectId);
                    CountryGateway countryGateway = new CountryGateway(new DataSet());
                    countryGateway.LoadByCountryId(projectGateway.GetCountryID(projectId));
                    string location = countryGateway.GetName(projectGateway.GetCountryID(projectId));

                    // Update data
                    TeamProjectTime2DetailTemp teamProjectTime2DetailTemp = new TeamProjectTime2DetailTemp(teamProjectTime2TDS);
                    teamProjectTime2DetailTemp.Update(teamProjectTimeId, detailId, employeeId, date_, startTime, endTime, offsetFinal, workingDetails, location, mealsCountry, isMealsAllowance, unitId, towedUnitId, comments, work_, function_, workFunctionConcat, fairWage, jobClassType);

                    // Store dataset
                    Session.Remove("teamProjectTimeDetailTempDummy");
                    Session["teamProjectTime2TDS"] = teamProjectTime2TDS;
                    Session["teamProjectTimeDetailTemp"] = teamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMP;
                    teamProjectTimeDetailTemp = teamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMP;
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - EMPLOYEES - AUXILIAR EVENTS
        //

        protected void ddlEmployeesFooter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(Int32.Parse(ddlProject.SelectedValue));

            DropDownList ddlEmployee = (DropDownList)sender;
            int employeeId = Int32.Parse(ddlEmployee.SelectedValue);

            if (projectGateway.GetFairWageApplies(int.Parse(ddlProject.SelectedValue)))
            {
                EmployeeInformationBasicInformationGateway employeeInformationBasicInformation = new EmployeeInformationBasicInformationGateway();
                employeeInformationBasicInformation.LoadByEmployeeId(employeeId);
                string jobClassType = employeeInformationBasicInformation.GetJobClassType(employeeId);

                if (jobClassType != "")
                {
                    ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlJobClassTypeFooter")).SelectedValue = jobClassType;
                }
            }
        }



        protected void ddlEmployeesEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(Int32.Parse(ddlProject.SelectedValue));

            DropDownList ddlEmployee = (DropDownList)sender;
            int employeeId = Int32.Parse(ddlEmployee.SelectedValue);

            if (projectGateway.GetFairWageApplies(int.Parse(ddlProject.SelectedValue)))
            {
                EmployeeInformationBasicInformationGateway employeeInformationBasicInformation = new EmployeeInformationBasicInformationGateway();
                employeeInformationBasicInformation.LoadByEmployeeId(employeeId);
                string jobClassType = employeeInformationBasicInformation.GetJobClassType(employeeId);

                if (jobClassType != "")
                {
                    ((DropDownList)grdProjectTime.Rows[grdProjectTime.EditIndex].Cells[3].FindControl("ddlJobClassTypeEdit")).SelectedValue = jobClassType;
                }
            }
        }



        protected void grdProjectTime_DataBound(object sender, EventArgs e)
        {
            AddProjectTimeNewEmptyFix(grdProjectTime);
        }



        protected void grdProjectTime_RowDataBound(object sender, GridViewRowEventArgs e)
        {            
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                // For Start Time
                if (!string.IsNullOrEmpty(hdfStartTime.Value))
                {
                    string startTime = DateTime.Parse(hdfStartTime.Value).ToString("H:mm");
                    if (startTime != "")
                    {
                        string[] hoursMin1 = startTime.Split(':');
                        ((DropDownList)e.Row.FindControl("ddlStartTimeHourFooter")).SelectedValue = hoursMin1[0].Trim();
                        ((DropDownList)e.Row.FindControl("ddlStartTimeMinuteFooter")).SelectedValue = hoursMin1[1].Trim();
                    }
                }

                // For End Time
                if (!string.IsNullOrEmpty(hdfEndTime.Value))
                {
                    string endTime = DateTime.Parse(hdfEndTime.Value).ToString("H:mm");
                    if (endTime != "")
                    {
                        string[] endHoursMin1 = endTime.Split(':');
                        ((DropDownList)e.Row.FindControl("ddlEndTimeHourFooter")).SelectedValue = endHoursMin1[0].Trim();
                        ((DropDownList)e.Row.FindControl("ddlEndTimeMinuteFooter")).SelectedValue = endHoursMin1[1].Trim();
                    }
                }

                // For Lunch
                string lunch = hdfOffset.Value;
                if (lunch != "")
                {
                    ((DropDownList)e.Row.FindControl("ddlLunchFooter")).SelectedValue = lunch;
                }

                // For Type Of Work
                string workFunctionConcat = hdfWorkFunctionConcat.Value;
                ((DropDownList)e.Row.FindControl("ddlTypeOfWorkFooter")).SelectedValue = workFunctionConcat;

                // For Meals Allowance
                //string isMealsAllowance = hdfIsMealsAllowance.Value;
                //((CheckBox)e.Row.FindControl("ckbxMealsAllowanceFooter")).Checked = Boolean.Parse(isMealsAllowance);

                // For Job Class
                ProjectGateway projectGateway = new ProjectGateway();
                projectGateway.LoadByProjectId(Int32.Parse(ddlProject.SelectedValue));

                if (projectGateway.GetFairWageApplies(int.Parse(ddlProject.SelectedValue)))
                {
                    int employeeId = Int32.Parse(((DropDownList)e.Row.FindControl("ddlEmployeesFooter")).SelectedValue);

                    EmployeeInformationBasicInformationGateway employeeInformationBasicInformation = new EmployeeInformationBasicInformationGateway();
                    employeeInformationBasicInformation.LoadByEmployeeId(employeeId);
                    string jobClassType = employeeInformationBasicInformation.GetJobClassType(employeeId);

                    if (jobClassType != "")
                    {
                        ((DropDownList)e.Row.FindControl("ddlJobClassTypeFooter")).SelectedValue = jobClassType;
                    }
                }
            }
            
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int teamProjectTimeId = Int32.Parse(((Label)e.Row.FindControl("lblTeamProjectTimeIdEdit")).Text.Trim());
                int detailId = Int32.Parse(((Label)e.Row.FindControl("lblDetailIdEdit")).Text.Trim());
                TeamProjectTime2DetailGateway teamProjectTime2DetailGateway = new TeamProjectTime2DetailGateway(teamProjectTime2TDS);

                // For employee
                int employeeId = 0; if (teamProjectTime2DetailGateway.GetEmployeeId(teamProjectTimeId, detailId) != -1) employeeId = teamProjectTime2DetailGateway.GetEmployeeId(teamProjectTimeId, detailId);
                if (employeeId != -1)
                {
                    ((DropDownList)e.Row.FindControl("ddlEmployeesEdit")).SelectedValue = employeeId.ToString();
                }

                // For Start Time
                string startTime = ""; if (teamProjectTime2DetailGateway.GetStartTime(teamProjectTimeId, detailId) != "") startTime = DateTime.Parse(teamProjectTime2DetailGateway.GetStartTime(teamProjectTimeId, detailId)).ToString("H:mm"); ;
                if (startTime != "")
                {
                    string[] hoursMin1 = startTime.Split(':');
                    ((DropDownList)e.Row.FindControl("ddlStartTimeHourEdit")).SelectedValue = hoursMin1[0].Trim();
                    ((DropDownList)e.Row.FindControl("ddlStartTimeMinuteEdit")).SelectedValue = hoursMin1[1].Trim();
                }

                // For End Time
                string endTime = ""; if (teamProjectTime2DetailGateway.GetEndTime(teamProjectTimeId, detailId) != "") endTime = DateTime.Parse(teamProjectTime2DetailGateway.GetEndTime(teamProjectTimeId, detailId)).ToString("H:mm");;
                if (endTime != "")
                {
                    string[] endHoursMin1 = endTime.Split(':');
                    ((DropDownList)e.Row.FindControl("ddlEndTimeHourEdit")).SelectedValue = endHoursMin1[0].Trim();
                    ((DropDownList)e.Row.FindControl("ddlEndTimeMinuteEdit")).SelectedValue = endHoursMin1[1].Trim();
                }

                // For Type Of Work
                string work_ = teamProjectTime2DetailGateway.GetWork(teamProjectTimeId, detailId);
                string function_ = teamProjectTime2DetailGateway.GetFunction(teamProjectTimeId, detailId);
                ((DropDownList)e.Row.FindControl("ddlTypeOfWorkFunctionEdit")).SelectedValue = work_ + " . " + function_;

                string jobClass = teamProjectTime2DetailGateway.GetJobClassType(teamProjectTimeId, detailId);
                ((DropDownList)e.Row.FindControl("ddlJobClassTypeEdit")).SelectedValue = jobClass;

                // For Unit
                int? unitId = null; if (teamProjectTime2DetailGateway.GetUnitId(teamProjectTimeId, detailId).HasValue) unitId = (int)teamProjectTime2DetailGateway.GetUnitId(teamProjectTimeId, detailId);
                if (unitId.HasValue)
                {
                    ((DropDownList)e.Row.FindControl("ddlUnitEdit")).SelectedValue = ((int)unitId).ToString();
                }

                // For Towed
                int? towedId = null; if (teamProjectTime2DetailGateway.GetTowedUnitId(teamProjectTimeId, detailId).HasValue) towedId = (int)teamProjectTime2DetailGateway.GetTowedUnitId(teamProjectTimeId, detailId);
                if (towedId.HasValue)
                {
                    ((DropDownList)e.Row.FindControl("ddlTowedEdit")).SelectedValue = ((int)towedId).ToString();
                }
            }

            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                int teamProjectTimeId = Int32.Parse(((Label)e.Row.FindControl("lblTeamProjectTimeId")).Text.Trim());
                int detailId = Int32.Parse(((Label)e.Row.FindControl("lblDetailId")).Text.Trim());
                TeamProjectTime2DetailGateway teamProjectTime2DetailGateway = new TeamProjectTime2DetailGateway(teamProjectTime2TDS);
                
                // For Start Time
                string startTime = "";
                try
                {
                    if (teamProjectTime2DetailGateway.GetStartTime(teamProjectTimeId, detailId) != "") startTime = DateTime.Parse(teamProjectTime2DetailGateway.GetStartTime(teamProjectTimeId, detailId)).ToString("H:mm"); ;
                }
                catch
                {
                }
                if (startTime != "")
                {
                    ((TextBox)e.Row.FindControl("tbxStartTime")).Text = startTime;
                }

                // For End Time
                string endTime = "";
                try
                {
                    if (teamProjectTime2DetailGateway.GetEndTime(teamProjectTimeId, detailId) != "") endTime = DateTime.Parse(teamProjectTime2DetailGateway.GetEndTime(teamProjectTimeId, detailId)).ToString("H:mm"); ;
                }
                catch
                {
                }
                if (endTime != "")
                {
                    ((TextBox)e.Row.FindControl("tbxEndTime")).Text = endTime;
                }
            }
        }



        protected void grdProjectTime_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Project Time Gridview, if the gridview is edition mode
            if (grdProjectTime.EditIndex >= 0)
            {
                grdProjectTime.UpdateRow(grdProjectTime.EditIndex, true);
            }
        }



        protected void cvValidMealsCountryFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            bool mealsAllowance = false;// ((CheckBox)grdProjectTime.FooterRow.FindControl("ckbxMealsAllowanceFooter")).Checked;
            string mealsCountry = ddlMealsCountry.SelectedValue;

            args.IsValid = true;
            if (mealsAllowance)
            {
                if (mealsCountry == "-1")
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvValidMealsCountryEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (grdProjectTime.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdProjectTime.Rows)
                {
                    if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                    {
                        bool mealsAllowance = false;// ((CheckBox)row.FindControl("ckbxMealsAllowanceEdit")).Checked;
                        string mealsCountry = ddlMealsCountry.SelectedValue;

                        if (mealsAllowance)
                        {
                            if (mealsCountry == "-1")
                            {
                                args.IsValid = false;
                            }
                        }
                    }
                }
            }
        }



        protected void cvStartTimeDeleteFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string workingDetails = tbxWorkingDetails.Text;
            string startTime = "";
            string startHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue.Trim() != "") startHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue.Trim();
            string startMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue.Trim() != "") startMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue.Trim();

            if ((startHoursFooter != "") && (startMinutesFooter != ""))
            {
                startTime = startHoursFooter + ":" + startMinutesFooter;
            }
            args.IsValid = true;
            if ((workingDetails != "USA") && (workingDetails != "Canada"))
            {
                if (startTime.Trim() != "")
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvStartTimeDeleteEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (grdProjectTime.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdProjectTime.Rows)
                {
                    if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                    {
                        string workingDetails = tbxWorkingDetails.Text;
                        string startTime = "";
                        string startHoursEdit = ""; if (((DropDownList)row.FindControl("ddlStartTimeHourEdit")).SelectedValue.Trim() != "") startHoursEdit = ((DropDownList)row.FindControl("ddlStartTimeHourEdit")).SelectedValue.Trim();
                        string startMinutesEdit = ""; if (((DropDownList)row.FindControl("ddlStartTimeMinuteEdit")).SelectedValue.Trim() != "") startMinutesEdit = ((DropDownList)row.FindControl("ddlStartTimeMinuteEdit")).SelectedValue.Trim();

                        if ((startHoursEdit != "") && (startMinutesEdit != ""))
                        {
                            startTime = startHoursEdit + ":" + startMinutesEdit;
                        }

                        if ((workingDetails != "USA") && (workingDetails != "Canada"))
                        {
                            if (startTime.Trim() != "")
                            {
                                args.IsValid = false;
                            }
                        }
                    }
                }
            }
        }



        protected void cvValidDatePayPeriod_ServerValidate(object source, ServerValidateEventArgs args)
        {            
            DateTime dateEmployees_ = DateTime.Parse(tbxDate.Text);
            bool validDatePayPeriod = LiquiForce.LFSLive.BL.LabourHours.ProjectTime.ProjectTime.ValidateExistPayPeriod(dateEmployees_);
            args.IsValid = true;

            if (!validDatePayPeriod)
            {
                args.IsValid = false;
            }            
        }



        protected void cvEndTimeDeleteFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string workingDetails = tbxWorkingDetails.Text;
            string endTime = "";
            string endHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue.Trim() != "") endHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue.Trim();
            string endMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue.Trim() != "") endMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue.Trim();

            if ((endHoursFooter != "") && (endMinutesFooter != ""))
            {
                endTime = endHoursFooter + ":" + endMinutesFooter;
            }

            args.IsValid = true;
            if ((workingDetails != "USA") && (workingDetails != "Canada"))
            {
                if (endTime.Trim() != "")
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvEndTimeDeleteEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (grdProjectTime.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdProjectTime.Rows)
                {
                    if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                    {
                        string workingDetails = tbxWorkingDetails.Text;
                        string endTime = "";
                        string endHoursEdit = ""; if (((DropDownList)row.FindControl("ddlEndTimeHourEdit")).SelectedValue.Trim() != "") endHoursEdit = ((DropDownList)row.FindControl("ddlEndTimeHourEdit")).SelectedValue.Trim();
                        string endMinutesEdit = ""; if (((DropDownList)row.FindControl("ddlEndTimeMinuteEdit")).SelectedValue.Trim() != "") endMinutesEdit = ((DropDownList)row.FindControl("ddlEndTimeMinuteEdit")).SelectedValue.Trim();

                        if ((endHoursEdit != "") && (endMinutesEdit != ""))
                        {
                            endTime = endHoursEdit + ":" + endMinutesEdit;
                        }

                        if ((workingDetails != "USA") && (workingDetails != "Canada"))
                        {
                            if (endTime.Trim() != "")
                            {
                                args.IsValid = false;
                            }
                        }
                    }
                }
            }
        }



        protected void cvLunchDeleteFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string workingDetails = tbxWorkingDetails.Text;
            string lunch = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlLunchFooter")).SelectedValue;

            args.IsValid = true;
            if ((workingDetails != "USA") && (workingDetails != "Canada"))
            {
                if (lunch.Trim() != "0")
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvLunchDeleteEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (grdProjectTime.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdProjectTime.Rows)
                {
                    if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                    {
                        string workingDetails = tbxWorkingDetails.Text;
                        string lunch = ((DropDownList)row.FindControl("ddlLunchEdit")).SelectedValue;

                        if ((workingDetails != "USA") && (workingDetails != "Canada"))
                        {
                            if (lunch.Trim() != "0")
                            {
                                args.IsValid = false;
                            }
                        }
                    }
                }
            }
        }



        protected void cvStartTimeProvideFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string workingDetails = tbxWorkingDetails.Text;
            string startTime = "";
            string startHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue.Trim() != "") startHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue.Trim();
            string startMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue.Trim() != "") startMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue.Trim();

            if ((startHoursFooter != "") && (startMinutesFooter != ""))
            {
                startTime = startHoursFooter + ":" + startMinutesFooter;
            }

            args.IsValid = true;
            if ((workingDetails == "USA") || (workingDetails == "Canada"))
            {
                if (startTime.Trim() == "")
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvStartTimeProvideEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (grdProjectTime.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdProjectTime.Rows)
                {
                    if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                    {
                        string workingDetails = tbxWorkingDetails.Text;

                        string startTime = "";
                        string startHoursEdit = ""; if (((DropDownList)row.FindControl("ddlStartTimeHourEdit")).SelectedValue.Trim() != "") startHoursEdit = ((DropDownList)row.FindControl("ddlStartTimeHourEdit")).SelectedValue.Trim();
                        string startMinutesEdit = ""; if (((DropDownList)row.FindControl("ddlStartTimeMinuteEdit")).SelectedValue.Trim() != "") startMinutesEdit = ((DropDownList)row.FindControl("ddlStartTimeMinuteEdit")).SelectedValue.Trim();

                        if ((startHoursEdit != "") && (startMinutesEdit != ""))
                        {
                            startTime = startHoursEdit + ":" + startMinutesEdit;
                        }

                        if ((workingDetails == "USA") || (workingDetails == "Canada"))
                        {
                            if (startTime.Trim() == "")
                            {
                                args.IsValid = false;
                            }
                        }
                    }
                }
            }
        }



        protected void cvProvideEndTimeFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            string workingDetails = tbxWorkingDetails.Text;
            string endTime = "";
            string endHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue.Trim() != "") endHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue.Trim();
            string endMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue.Trim() != "") endMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue.Trim();

            if ((endHoursFooter != "") && (endMinutesFooter != ""))
            {
                endTime = endHoursFooter + ":" + endMinutesFooter;
            }

            args.IsValid = true;
            if ((workingDetails == "USA") || (workingDetails == "Canada"))
            {
                if (endTime.Trim() == "")
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvProvideEndTimeEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (grdProjectTime.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdProjectTime.Rows)
                {
                    if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                    {
                        string workingDetails = tbxWorkingDetails.Text;
                        string endTime = "";
                        string endHoursEdit = ""; if (((DropDownList)row.FindControl("ddlEndTimeHourEdit")).SelectedValue.Trim() != "") endHoursEdit = ((DropDownList)row.FindControl("ddlEndTimeHourEdit")).SelectedValue.Trim();
                        string endMinutesEdit = ""; if (((DropDownList)row.FindControl("ddlEndTimeMinuteEdit")).SelectedValue.Trim() != "") endMinutesEdit = ((DropDownList)row.FindControl("ddlEndTimeMinuteEdit")).SelectedValue.Trim();

                        if ((endHoursEdit != "") && (endMinutesEdit != ""))
                        {
                            endTime = endHoursEdit + ":" + endMinutesEdit;
                        }

                        if ((workingDetails == "USA") || (workingDetails == "Canada"))
                        {
                            if (endTime.Trim() == "")
                            {
                                args.IsValid = false;
                            }
                        }
                    }
                }
            }
        }



        protected void cvDuplicateMealsAllowanceFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int employeeId = Int32.Parse(((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEmployeesFooter")).SelectedValue);
            bool isMealsAllowance = false;// ((CheckBox)grdProjectTime.FooterRow.FindControl("ckbxMealsAllowanceFooter")).Checked;

            TeamProjectTime2DetailTemp teamProjectTime2DetailTemp = new TeamProjectTime2DetailTemp(teamProjectTime2TDS);
            bool validMealsAllowance1 = teamProjectTime2DetailTemp.ValidateMealsAllowance(employeeId, isMealsAllowance);

            args.IsValid = true;
            if (!validMealsAllowance1)
            {
                args.IsValid = false;
            }
        }



        protected void cvDuplicateMealsAllowanceEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (grdProjectTime.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdProjectTime.Rows)
                {
                    if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                    {
                        int employeeId = Int32.Parse(((DropDownList)row.FindControl("ddlEmployeesEdit")).SelectedValue);
                        bool isMealsAllowance = false;// ((CheckBox)row.FindControl("ckbxMealsAllowanceEdit")).Checked;
                        int projectTimeId2 = Int32.Parse(((Label)row.FindControl("lblDetailIdEdit")).Text);

                        TeamProjectTime2DetailTemp teamProjectTime2DetailTemp = new TeamProjectTime2DetailTemp(teamProjectTime2TDS);
                        bool validMealsAllowance1 = teamProjectTime2DetailTemp.ValidateMealsAllowanceEdit(employeeId, isMealsAllowance, projectTimeId2);

                        args.IsValid = true;
                        if (!validMealsAllowance1)
                        {
                            args.IsValid = false;
                        }
                    }
                }
            }
        }



        protected void cvAlreadyRegisteredMealsAllowanceFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int employeeId = Int32.Parse(((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEmployeesFooter")).SelectedValue);
            DateTime date_ = tkrdpDate_.SelectedDate.Value;
            bool isMealsAllowance = false;// ((CheckBox)grdProjectTime.FooterRow.FindControl("ckbxMealsAllowanceFooter")).Checked;
            string mealsCountry = hdfMealsCountry.Value;
            int projectTimeId = -1;
            args.IsValid = true;

            TeamProjectTime2DetailTemp teamProjectTime2DetailTemp = new TeamProjectTime2DetailTemp(teamProjectTime2TDS);
            bool validMealsAllowance1 = teamProjectTime2DetailTemp.ValidateMealsAllowance(employeeId, isMealsAllowance);
            if (validMealsAllowance1)
            {
                if ((mealsCountry != "-1") && (isMealsAllowance))
                {
                    ProjectTimeGateway projectTimeGateway = new ProjectTimeGateway();
                    if (projectTimeId == -1)
                    {
                        if (projectTimeGateway.ExistsMealsAllowanceByEmployeIdDate(employeeId, date_, companyId))
                        {
                            args.IsValid = false;
                        }
                    }
                    else
                    {
                        if (projectTimeGateway.ExistsMealsAllowanceByProjectTimeIdEmployeIdDate(projectTimeId, employeeId, date_, companyId))
                        {
                            args.IsValid = false;
                        }
                    }
                }
            }
        }



        protected void cvAlreadyRegisteredMealsAllowanceEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (grdProjectTime.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdProjectTime.Rows)
                {
                    if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                    {
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        int employeeId = Int32.Parse(((DropDownList)row.FindControl("ddlEmployeesEdit")).SelectedValue);
                        DateTime date_ = tkrdpDate_.SelectedDate.Value;
                        bool isMealsAllowance = false;// ((CheckBox)row.FindControl("ckbxMealsAllowanceEdit")).Checked;
                        int projectTimeId2 = Int32.Parse(((Label)row.FindControl("lblDetailIdEdit")).Text);

                        string mealsCountry = hdfMealsCountry.Value;
                        int projectTimeId = -1;
                        args.IsValid = true;

                        TeamProjectTime2DetailTemp teamProjectTime2DetailTemp = new TeamProjectTime2DetailTemp(teamProjectTime2TDS);
                        bool validMealsAllowance1 = teamProjectTime2DetailTemp.ValidateMealsAllowanceEdit(employeeId, isMealsAllowance, projectTimeId2);
                        if (validMealsAllowance1)
                        {
                            if ((mealsCountry != "-1") && (isMealsAllowance))
                            {
                                ProjectTimeGateway projectTimeGateway = new ProjectTimeGateway();
                                if (projectTimeId == -1)
                                {
                                    if (projectTimeGateway.ExistsMealsAllowanceByEmployeIdDate(employeeId, date_, companyId))
                                    {
                                        args.IsValid = false;
                                    }
                                }
                                else
                                {
                                    if (projectTimeGateway.ExistsMealsAllowanceByProjectTimeIdEmployeIdDate(projectTimeId, employeeId, date_, companyId))
                                    {
                                        args.IsValid = false;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }



        protected void cvValidProjectTimeFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            string startTime = "";
            string startHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue.Trim() != "") startHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue.Trim();
            string startMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue.Trim() != "") startMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue.Trim();

            if ((startHoursFooter != "") && (startMinutesFooter != ""))
            {
                startTime = startHoursFooter + ":" + startMinutesFooter;
            }

            string endTime = "";
            string endHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue.Trim() != "") endHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue.Trim();
            string endMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue.Trim() != "") endMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue.Trim();

            if ((endHoursFooter != "") && (endMinutesFooter != ""))
            {
                endTime = endHoursFooter + ":" + endMinutesFooter;
            }

            string offset = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlLunchFooter")).SelectedValue;

            DateTime? startTimeToCalculate = null; if (startTime != "") startTimeToCalculate = DateTime.Parse(startTime);
            DateTime? endTimeToCalculate = null; if (endTime != "") endTimeToCalculate = DateTime.Parse(endTime);
            double? offsetToCalculate = 0; if (offset != "0") offsetToCalculate = double.Parse(offset);

            if (startTimeToCalculate.HasValue || endTimeToCalculate.HasValue)
            {
                args.IsValid = (CalculateProjectTime(startTimeToCalculate, endTimeToCalculate, offsetToCalculate) > 0) ? true : false;
            }
        }



        protected void cvValidProjectTimeEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            if (grdProjectTime.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdProjectTime.Rows)
                {
                    if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                    {
                        string startTime = "";
                        string startHoursEdit = ""; if (((DropDownList)row.FindControl("ddlStartTimeHourEdit")).SelectedValue.Trim() != "") startHoursEdit = ((DropDownList)row.FindControl("ddlStartTimeHourEdit")).SelectedValue.Trim();
                        string startMinutesEdit = ""; if (((DropDownList)row.FindControl("ddlStartTimeMinuteEdit")).SelectedValue.Trim() != "") startMinutesEdit = ((DropDownList)row.FindControl("ddlStartTimeMinuteEdit")).SelectedValue.Trim();

                        if ((startHoursEdit != "") && (startMinutesEdit != ""))
                        {
                            startTime = startHoursEdit + ":" + startMinutesEdit;
                        }

                        string endTime = "";
                        string endHoursEdit = ""; if (((DropDownList)row.FindControl("ddlEndTimeHourEdit")).SelectedValue.Trim() != "") endHoursEdit = ((DropDownList)row.FindControl("ddlEndTimeHourEdit")).SelectedValue.Trim();
                        string endMinutesEdit = ""; if (((DropDownList)row.FindControl("ddlEndTimeMinuteEdit")).SelectedValue.Trim() != "") endMinutesEdit = ((DropDownList)row.FindControl("ddlEndTimeMinuteEdit")).SelectedValue.Trim();

                        if ((endHoursEdit != "") && (endMinutesEdit != ""))
                        {
                            endTime = endHoursEdit + ":" + endMinutesEdit;
                        }

                        string offset = ((DropDownList)row.FindControl("ddlLunchEdit")).SelectedValue;

                        DateTime? startTimeToCalculate = null; if (startTime != "") startTimeToCalculate = DateTime.Parse(startTime);
                        DateTime? endTimeToCalculate = null; if (endTime != "") endTimeToCalculate = DateTime.Parse(endTime);
                        double? offsetToCalculate = 0; if (offset != "0") offsetToCalculate = double.Parse(offset);

                        if (startTimeToCalculate.HasValue || endTimeToCalculate.HasValue)
                        {
                            args.IsValid = (CalculateProjectTime(startTimeToCalculate, endTimeToCalculate, offsetToCalculate) > 0) ? true : false;
                        }
                    }
                }
            }
        }



        protected void cvValidStartTimeEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            foreach (GridViewRow row in grdProjectTime.Rows)
            {
                if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                {
                    string startHoursEdit = ""; if (((DropDownList)row.FindControl("ddlStartTimeHourEdit")).SelectedValue.Trim() != "") startHoursEdit = ((DropDownList)row.FindControl("ddlStartTimeHourEdit")).SelectedValue.Trim();
                    string startMinutesEdit = ""; if (((DropDownList)row.FindControl("ddlStartTimeMinuteEdit")).SelectedValue.Trim() != "") startMinutesEdit = ((DropDownList)row.FindControl("ddlStartTimeMinuteEdit")).SelectedValue.Trim();

                    if ((startHoursEdit != "") && (startMinutesEdit != ""))
                    {
                        args.IsValid = true;
                    }

                    if ((startHoursEdit == "") && (startMinutesEdit == ""))
                    {
                        args.IsValid = true;
                    }
                }
            }
        }



        protected void cvValidEndTimeEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            foreach (GridViewRow row in grdProjectTime.Rows)
            {
                if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                {
                    string endHoursEdit = ""; if (((DropDownList)row.FindControl("ddlEndTimeHourEdit")).SelectedValue.Trim() != "") endHoursEdit = ((DropDownList)row.FindControl("ddlEndTimeHourEdit")).SelectedValue.Trim();
                    string endMinutesEdit = ""; if (((DropDownList)row.FindControl("ddlEndTimeMinuteEdit")).SelectedValue.Trim() != "") endMinutesEdit = ((DropDownList)row.FindControl("ddlEndTimeMinuteEdit")).SelectedValue.Trim();

                    if ((endHoursEdit != "") && (endMinutesEdit != ""))
                    {
                        args.IsValid = true;
                    }

                    if ((endHoursEdit == "") && (endMinutesEdit == ""))
                    {
                        args.IsValid = true;
                    }
                }
            }
        }



        protected void cvValidStartTimeFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            string startHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue.Trim() != "") startHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue.Trim();
            string startMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue.Trim() != "") startMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue.Trim();

            if ((startHoursFooter != "") && (startMinutesFooter != ""))
            {
                args.IsValid = true;
            }
            if ((startHoursFooter == "") && (startMinutesFooter == ""))
            {
                args.IsValid = true;
            }
        }



        protected void cvValidEndTimeFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            string endHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue.Trim() != "") endHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue.Trim();
            string endMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue.Trim() != "") endMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue.Trim();

            if ((endHoursFooter != "") && (endMinutesFooter != ""))
            {
                args.IsValid = true;
            }
            if ((endHoursFooter == "") && (endMinutesFooter == ""))
            {
                args.IsValid = true;
            }
        }



        protected void cvValidTimesEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;

            if (grdProjectTime.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdProjectTime.Rows)
                {
                    if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Edit) || (row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
                    {
                        ProjectTimeGateway projectTimeGatewayForVerify = new ProjectTimeGateway();
                        int employeeId = 0; if (((DropDownList)row.FindControl("ddlEmployeesEdit")).SelectedValue.Trim() != "") employeeId = Int32.Parse(((DropDownList)row.FindControl("ddlEmployeesEdit")).SelectedValue.Trim());
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        DateTime date_ = DateTime.Parse(tbxDate.Text);
                        string startTime = "";
                        string startHoursEdit = ""; if (((DropDownList)row.FindControl("ddlStartTimeHourEdit")).SelectedValue.Trim() != "") startHoursEdit = ((DropDownList)row.FindControl("ddlStartTimeHourEdit")).SelectedValue.Trim();
                        string startMinutesEdit = ""; if (((DropDownList)row.FindControl("ddlStartTimeMinuteEdit")).SelectedValue.Trim() != "") startMinutesEdit = ((DropDownList)row.FindControl("ddlStartTimeMinuteEdit")).SelectedValue.Trim();

                        if ((startHoursEdit != "") && (startMinutesEdit != ""))
                        {
                            startTime = startHoursEdit + ":" + startMinutesEdit;
                        }

                        string endTime = "";
                        string endHoursEdit = ""; if (((DropDownList)row.FindControl("ddlEndTimeHourEdit")).SelectedValue.Trim() != "") endHoursEdit = ((DropDownList)row.FindControl("ddlEndTimeHourEdit")).SelectedValue.Trim();
                        string endMinutesEdit = ""; if (((DropDownList)row.FindControl("ddlEndTimeMinuteEdit")).SelectedValue.Trim() != "") endMinutesEdit = ((DropDownList)row.FindControl("ddlEndTimeMinuteEdit")).SelectedValue.Trim();

                        if ((endHoursEdit != "") && (endMinutesEdit != ""))
                        {
                            endTime = endHoursEdit + ":" + endMinutesEdit;
                        }

                        // Verify if the time not exists at DB
                        if (projectTimeGatewayForVerify.NotExistsByEmployeIdDate_StartTimeEndTime(employeeId, date_, startTime, endTime, companyId))
                        {
                            args.IsValid = true;
                        }

                        int cant = 0;
                        if (args.IsValid)
                        {
                            // Verify if it not exist at last entered rows
                            if (grdProjectTime.Rows.Count > 0)
                            {
                                foreach (GridViewRow rowTemp in grdProjectTime.Rows)
                                {
                                    if ((rowTemp.RowType == DataControlRowType.DataRow) && ((rowTemp.RowState == DataControlRowState.Normal) || (rowTemp.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
                                    {
                                        TimeSpan spanGridStartTime = TimeSpan.Parse(((TextBox)rowTemp.FindControl("tbxStartTime")).Text.Trim());
                                        TimeSpan spanGridEndTime = TimeSpan.Parse(((TextBox)rowTemp.FindControl("tbxEndTime")).Text.Trim());
                                        TimeSpan spanStartTime = TimeSpan.Parse(startTime);
                                        TimeSpan spanEndTime = TimeSpan.Parse(endTime);
                                        string twentyForHours = "23:59";
                                        TimeSpan midNight = TimeSpan.Parse(twentyForHours);

                                        int gridEmployeeId = 0; if (((HiddenField)rowTemp.FindControl("hdfEmployeeId")).Value.Trim() != "") gridEmployeeId = Int32.Parse(((HiddenField)rowTemp.FindControl("hdfEmployeeId")).Value.Trim());

                                        if (gridEmployeeId == employeeId)
                                        {
                                            // When End Time < StartTime   (when they finish work the next day)
                                            if ((spanGridEndTime < spanGridStartTime) && (spanEndTime > spanStartTime))
                                            {
                                                if (((spanStartTime >= spanGridStartTime) && (spanStartTime <= midNight)) || ((spanEndTime >= spanGridStartTime) && (spanEndTime <= midNight)))
                                                {
                                                    cant++;
                                                }
                                            }
                                            else
                                            {
                                                if ((spanEndTime < spanStartTime) && (spanGridEndTime > spanGridStartTime))
                                                {
                                                    if (((spanGridStartTime >= spanStartTime) && (midNight <= spanStartTime)) || ((spanGridStartTime >= spanEndTime) && (midNight <= spanEndTime)))
                                                    {
                                                        cant++;
                                                    }
                                                }
                                                else
                                                {
                                                    if (((spanGridEndTime < spanGridStartTime) && (spanEndTime < spanStartTime)))
                                                    {
                                                        cant++;
                                                    }
                                                    else
                                                    {
                                                        // When End Time > Start Time.  (times in the same day)
                                                        // ... If it's a valid entry
                                                        if (((spanStartTime < spanGridStartTime) && (spanEndTime <= spanGridStartTime)) || (spanStartTime >= spanGridEndTime) && (spanEndTime > spanGridEndTime))
                                                        {

                                                        }
                                                        else
                                                        {
                                                            // If the range exists
                                                            cant++;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            if (cant == 0)
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
            }
        }



        protected void cvValidTimesFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (hdfBtnNext.Value == "True")
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;

                ProjectTimeGateway projectTimeGatewayForVerify = new ProjectTimeGateway();
                int employeeId = 0; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEmployeesFooter")).SelectedValue.Trim() != "") employeeId = Int32.Parse(((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEmployeesFooter")).SelectedValue.Trim());
                int companyId = Int32.Parse(hdfCompanyId.Value);
                DateTime date_ = DateTime.Parse(tbxDate.Text);
                string startTimeFooter = "";
                string startHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue != "") startHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue.Trim();
                string startMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue != "") startMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue.Trim();

                string endTimeFooter = "";
                string endHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue != "") endHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue.Trim();
                string endMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue != "") endMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue.Trim();

                if ((startHoursFooter != "") && (startMinutesFooter != "") && (endHoursFooter != "") && (endMinutesFooter != ""))
                {
                    startTimeFooter = startHoursFooter + ":" + startMinutesFooter;
                    endTimeFooter = endHoursFooter + ":" + endMinutesFooter;

                    // Verify if the time not exists at DB
                    if (projectTimeGatewayForVerify.NotExistsByEmployeIdDate_StartTimeEndTime(employeeId, date_, startTimeFooter, endTimeFooter, companyId))
                    {
                        args.IsValid = true;
                    }

                    if (args.IsValid)
                    {
                        // Verify if it exist at last entered rows
                        TeamProjectTime2DetailTemp teamProjectTime2DetailTemp = new TeamProjectTime2DetailTemp(teamProjectTime2TDS);
                        if (teamProjectTime2DetailTemp.NotExistsByEmployeIdDate_StartTime(employeeId, date_, startTimeFooter, endTimeFooter))
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
        }



        protected void cvJobClassTypeFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            int projectId = int.Parse(ddlProject.SelectedValue);

            ProjectGateway projectGateway = new ProjectGateway(new DataSet());
            projectGateway.LoadByProjectId(int.Parse(ddlProject.SelectedValue));

            if (projectGateway.GetFairWageApplies(projectId))
            {
                string jobClass = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlJobClassTypeFooter")).SelectedValue;

                if (jobClass == "(Select a Job Class Type)")
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvJobClassTypeEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            int projectId = int.Parse(ddlProject.SelectedValue);

            ProjectGateway projectGateway = new ProjectGateway(new DataSet());
            projectGateway.LoadByProjectId(int.Parse(ddlProject.SelectedValue));

            if (projectGateway.GetFairWageApplies(projectId))
            {
                string jobClass = ((DropDownList)grdProjectTime.Rows[grdProjectTime.EditIndex].FindControl("ddlJobClassTypeEdit")).SelectedValue;

                if (jobClass == "(Select a Job Class Type)")
                {
                    args.IsValid = false;
                }
            }
        }



        protected void cvJobClassEmptyEdit_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            int employeeId = Int32.Parse(((Label)grdProjectTime.Rows[grdProjectTime.EditIndex].FindControl("lblEmployeeIdEdit")).Text);

            EmployeeGateway employee = new EmployeeGateway();
            employee.LoadByEmployeeId(employeeId);
            string jobClass = employee.GetJobClassType(employeeId);

            if (jobClass == "")
            {
                args.IsValid = false;
            }
        }



        protected void cvJobClassEmptyFooter_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            int employeeId = Int32.Parse(((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEmployeesFooter")).SelectedValue);

            EmployeeGateway employee = new EmployeeGateway();
            employee.LoadByEmployeeId(employeeId);
            string jobClass = employee.GetJobClassType(employeeId);

            if (jobClass == "")
            {
                args.IsValid = false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - EMPLOYEES - METHODS
        //

        private void StepEmployeesIn()
        {
            // Set instruction
            mWizard2 master2 = (mWizard2)this.Master;
            master2.WizardInstruction = "Add team members to the grid and, if necessary, update their data.";

            grdProjectTime.DataBind();
        }



        private bool StepEmployeesPrevious()
        {
            bool valid = ValidatePage();
            hdfBtnNext.Value = "False";
            return true;       
        }



        private bool StepEmployeesNext()
        {
            hdfBtnNext.Value = "True";
            bool valid = ValidatePage();
            if (valid)
            {
                // Project Time Gridview, if the gridview is edition mode
                if (grdProjectTime.EditIndex >= 0)
                {
                    grdProjectTime.UpdateRow(grdProjectTime.EditIndex, true);
                    grdProjectTime.DataBind();
                }
            }            

            return valid;
        }



        public TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPDataTable GetTeamProjectTimeDetail()
        {
            teamProjectTimeDetailTemp = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPDataTable)Session["teamProjectTimeDetailTempDummy"];
            if (teamProjectTimeDetailTemp == null)
            {
                teamProjectTimeDetailTemp = ((TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPDataTable)Session["teamProjectTimeDetailTemp"]);
            }

            return teamProjectTimeDetailTemp;
        }



        public void DummyTeamProjectTimeDetailNew(int TeamProjectTimeID, int original_TeamProjectTimeID, int original_DetailID)
        {
        }



        public void DummyTeamProjectTimeDetailNew(int original_TeamProjectTimeID, int original_DetailID)
        {
        }   



        protected void AddProjectTimeNewEmptyFix(GridView grdProjectTime)
        {
            if (grdProjectTime.Rows.Count == 0)
            {
                TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPDataTable dt = new TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPDataTable();
                dt.AddLFS_TEAM_PROJECT_TIME_DETAIL_TEMPRow(-1, -1, -1, -1, -1, DateTime.Now, "", "", -1, -1, "", "", -1, false, -1, -1, "", "", false, "", "", "", false, "");
                Session["teamProjectTimeDetailTempDummy"] = dt;

                grdProjectTime.DataBind();
            }

            // normally executes at all postbacks
            if (grdProjectTime.Rows.Count == 1)
            {
                TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPDataTable dt = (TeamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMPDataTable)Session["teamProjectTimeDetailTempDummy"];
                if (dt != null)
                {
                    grdProjectTime.Rows[0].Visible = false;
                    grdProjectTime.Rows[0].Controls.Clear();
                }
            }
        }



        private void GrdTeamProjectTimeDetailAdd()
        {
            Page.Validate();
            if (Page.IsValid)
            {
                Page.Validate("footerValidData");
                if (Page.IsValid)
                {
                    Page.Validate("footerData");
                    if (Page.IsValid)
                    {
                        int teamProjectTimeId = Int32.Parse(hdfTeamProjectTimeID.Value);
                        int employeeId = Int32.Parse(((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEmployeesFooter")).SelectedValue);
                        int companiesId = int.Parse(ddlClient.SelectedValue);
                        int projectId = int.Parse(ddlProject.SelectedValue);
                        DateTime date_ = tkrdpDate_.SelectedDate.Value;
                        Int64? mealsCountry = null; if (ddlMealsCountry.SelectedValue != "-1") mealsCountry = Int64.Parse(ddlMealsCountry.SelectedValue);
                        
                        string startTimeFooter = "";
                        string startHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue != "") startHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue.Trim();
                        string startMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue != "") startMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue.Trim();

                        if ((startHoursFooter != "") && (startMinutesFooter != ""))
                        {
                            startTimeFooter = startHoursFooter + ":" + startMinutesFooter;
                        }

                        string endTimeFooter = "";
                        string endHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue != "") endHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue.Trim();
                        string endMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue != "") endMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue.Trim();

                        if ((endHoursFooter != "") && (endMinutesFooter != ""))
                        {
                            endTimeFooter = endHoursFooter + ":" + endMinutesFooter;
                        }

                        decimal? offsetFooter = 0; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlLunchFooter")).SelectedValue != "0") offsetFooter = Decimal.Round(decimal.Parse(((DropDownList)grdProjectTime.FooterRow.FindControl("ddlLunchFooter")).SelectedValue), 2);
                        double? offsetFooterFinal = null; if (offsetFooter.HasValue) offsetFooterFinal = double.Parse(((decimal)offsetFooter).ToString());
                        string typeOfWorkFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlTypeOfWorkFooter")).SelectedValue;
                        int? unitIdFooter = null; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlUnitFooter")).SelectedValue != "-1") unitIdFooter = Int32.Parse(((DropDownList)grdProjectTime.FooterRow.FindControl("ddlUnitFooter")).SelectedValue);
                        int? towedIdFooter = null; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlTowedFooter")).SelectedValue != "-1") towedIdFooter = Int32.Parse(((DropDownList)grdProjectTime.FooterRow.FindControl("ddlTowedFooter")).SelectedValue);
                        string workingDetailsFooter = tbxWorkingDetails.Text;
                        bool isMealsAllowanceFooter = false;// ((CheckBox)grdProjectTime.FooterRow.FindControl("ckbxMealsAllowanceFooter")).Checked;
                        string commentsFooter = ((TextBox)grdProjectTime.FooterRow.FindControl("tbxCommentsFooter")).Text;
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        bool fairWageFooter = false; if (hdfFairWage.Value == "True") fairWageFooter = true; 

						string jobClassTypeFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlJobClassTypeFooter")).SelectedValue;

                        string projectTimeState = "For Approval"; if ((string)ViewState["LHMode"] == "Partial") projectTimeState = "Approved";

                        string work_ = "";
                        string function_ = "";
                        if (typeOfWorkFooter != "(Select)")
                        {
                            string[] workFunction = typeOfWorkFooter.ToString().Trim().Split('.');
                            work_ = workFunction[0].Trim();
                            function_ = workFunction[1].Trim();
                        }

                        ProjectGateway projectGateway = new ProjectGateway(new DataSet());
                        projectGateway.LoadByProjectId(projectId);
                        CountryGateway countryGateway = new CountryGateway(new DataSet());
                        countryGateway.LoadByCountryId(projectGateway.GetCountryID(projectId));
                        string location = countryGateway.GetName(projectGateway.GetCountryID(projectId));

                        // Insert Data
                        TeamProjectTime2DetailTemp teamProjectTime2DetailTemp = new TeamProjectTime2DetailTemp(teamProjectTime2TDS);
                        teamProjectTime2DetailTemp.Insert(teamProjectTimeId, employeeId, companiesId, projectId, date_, startTimeFooter, endTimeFooter, offsetFooterFinal, workingDetailsFooter, location, mealsCountry, isMealsAllowanceFooter, unitIdFooter, towedIdFooter, projectTimeState, commentsFooter, work_, function_, typeOfWorkFooter, fairWageFooter, jobClassTypeFooter);

                        // Store Dataset
                        Session.Remove("teamProjectTimeDetailTempDummy");
                        Session["teamProjectTime2TDS"] = teamProjectTime2TDS;
                        teamProjectTimeDetailTemp = teamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMP;
                        Session["teamProjectTimeDetailTemp"] = teamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMP; ;

                        grdProjectTime.DataBind();
                        grdProjectTime.PageIndex = grdProjectTime.PageCount - 1;
                    }
                }
            }
        }



        protected bool FooterValidate()
        {
            string startTimeFooter = "";
            string startHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue != "") startHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeHourFooter")).SelectedValue.Trim();
            string startMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue != "") startMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlStartTimeMinuteFooter")).SelectedValue.Trim();

            if ((startHoursFooter != "") && (startMinutesFooter != ""))
            {
                startTimeFooter = startHoursFooter + ":" + startMinutesFooter;
            }

            string endTimeFooter = "";
            string endHoursFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue != "") endHoursFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeHourFooter")).SelectedValue.Trim();
            string endMinutesFooter = ""; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue != "") endMinutesFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlEndTimeMinuteFooter")).SelectedValue.Trim();

            if ((endHoursFooter != "") && (endMinutesFooter != ""))
            {
                endTimeFooter = endHoursFooter + ":" + endMinutesFooter;
            } 
            
            float? offsetFooter = 0; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlLunchFooter")).SelectedValue != "0") offsetFooter = float.Parse(((DropDownList)grdProjectTime.FooterRow.FindControl("ddlLunchFooter")).SelectedValue);
            string typeOfWorkFooter = ((DropDownList)grdProjectTime.FooterRow.FindControl("ddlTypeOfWorkFooter")).SelectedValue;
            int? unitIdFooter = null; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlUnitFooter")).SelectedValue != "-1") unitIdFooter = Int32.Parse(((DropDownList)grdProjectTime.FooterRow.FindControl("ddlUnitFooter")).SelectedValue);
            int? towedIdFooter = null; if (((DropDownList)grdProjectTime.FooterRow.FindControl("ddlTowedFooter")).SelectedValue != "-1") towedIdFooter = Int32.Parse(((DropDownList)grdProjectTime.FooterRow.FindControl("ddlTowedFooter")).SelectedValue);
            bool isMealsAllowanceFooter = false;// ((CheckBox)grdProjectTime.FooterRow.FindControl("ckbxMealsAllowanceFooter")).Checked;
            string commentsFooter = ((TextBox)grdProjectTime.FooterRow.FindControl("tbxCommentsFooter")).Text;
            bool fairWageFooter = false; if (hdfFairWage.Value == "True") fairWageFooter = true; 

            if ((startTimeFooter != "") || (endTimeFooter != "") || (offsetFooter.HasValue) || (typeOfWorkFooter != "(Select)") || (unitIdFooter.HasValue) || (towedIdFooter.HasValue) || (isMealsAllowanceFooter) || (commentsFooter != "") || (fairWageFooter))
            {
                return true;
            }

            return false;
        }



        private static double CalculateProjectTime(DateTime? startTime, DateTime? endTime, double? offset)
        {
            double hours = 0;
            TimeSpan diference;

            if ((startTime.HasValue) && (endTime.HasValue))
            {
                if (!offset.HasValue)
                {
                    offset = 0;
                }

                if ((DateTime)endTime >= (DateTime)startTime)
                {
                    diference = (DateTime)endTime - (DateTime)startTime;
                    hours = (double)(((diference.Hours * 60 + diference.Minutes) - (offset * 60)) / 60);
                }
                else
                {
                    diference = (DateTime)startTime - (DateTime)endTime;
                    hours = (double)((1440 - (diference.Hours * 60 + diference.Minutes) - (offset * 60)) / 60);
                }
            }

            string hoursString = hours.ToString("f2");

            return double.Parse(hoursString);
        }



        protected string GetEmployeeName(object employeeId)
        {
            if (employeeId != DBNull.Value)
            {
                EmployeeGateway employeeGateway = new EmployeeGateway();
                employeeGateway.LoadByEmployeeId((int)employeeId);

                if (employeeGateway.Table.Rows.Count > 0)
                {
                    return employeeGateway.GetLastName((int)employeeId) + " " + employeeGateway.GetFirstName((int)employeeId);
                }

                return "";
            }

            return "";
        }



        protected string GetUnitCode(object unitId)
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);
            if (unitId != DBNull.Value)
            {
                UnitsGateway unitsGateway = new UnitsGateway();
                unitsGateway.LoadByUnitId((int)unitId, companyId);

                if (unitsGateway.Table.Rows.Count > 0)
                {
                    return unitsGateway.GetUnitCode((int)unitId);
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



        protected string GetLunch(object lunch)
        {
            if (lunch != DBNull.Value)
            {
                if ((Validator.IsValidDouble(lunch.ToString())) && (lunch.ToString() != "0.00"))
                {
                    return lunch.ToString();
                }
                else
                {
                    return "0";
                }
            }
            else
            {
                return "0";
            }
        }



        private bool ValidatePage()
        {
            bool valid = true;

            Page.Validate("teamMember");
            if (!Page.IsValid) valid = false;

            if (Page.IsValid)
            {
                Page.Validate("editValidData");
                if (Page.IsValid)
                {
                    Page.Validate("editData");
                    if (!Page.IsValid) valid = false;
                }
            }
            else
            {
                valid = false;
            }

            return valid;
        }



        #endregion






        #region STEP5 - END

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP5 - END
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP5 - END -  AUXILIAR EVENTS
        //

        protected void cvEnd_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (cbxEndConfirm.Checked || cbxEndSave.Checked)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }



        protected void cvEndSaveNew_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (cbxEndSave.Checked && rbtnEndSaveNew.Checked && (tbxEndSaveNew.Text.Trim() == ""))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }



        protected void cvEndSaveNewExist_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (cbxEndSave.Checked && rbtnEndSaveNew.Checked && (tbxEndSaveNew.Text.Trim() != ""))
            {
                TeamProjectTime2Gateway teamProjectTime2Gateway = new TeamProjectTime2Gateway(new DataSet());
                if (teamProjectTime2Gateway.IsTemplateNameInUseByTemplateNameLoginId(args.Value, Convert.ToInt32(Session["loginID"])))
                {
                    args.IsValid = false;
                }
                else
                {
                    args.IsValid = true;
                }
            }
        }



        protected void cvEndSaveTemplate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (cbxEndSave.Checked && rbtnEndSaveReplace.Checked && (luEndSaveTemplate.SelectedValue.ToString() == "0"))
            {
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP5 - END - METHODS
        //

        private void StepEndIn()
        {
            // Set instruction
            mWizard2 master2 = (mWizard2)this.Master;
            master2.WizardInstruction = "Please select your final parameters.";

            // Prepare initial data for the client
            if ((int)ViewState["teamProjectTimeId"] != 0)
            {
                rbtnEndSaveReplace.Checked = true;
            }

            luEndSaveTemplate.SelectedValue = ViewState["teamProjectTimeId"].ToString();
            lblError.Visible = false;
            lblError2.Visible = false;
        }



        private bool StepEndPrevious()
        {
            return true;
        }



        private bool StepEndFinish()
        {
            lblError.Visible = false;
            lblError2.Visible = false;
            int companyId = Int32.Parse(hdfCompanyId.Value);

            if (ValidateStepEnd())
            {
                if (cbxEndConfirm.Checked)
                {
                    // Review all times
                    if (rbtnBeginTemplate.Checked)
                    {
                        if (grdProjectTime.Rows.Count > 0)
                        {
                            foreach (GridViewRow row in grdProjectTime.Rows)
                            {
                                if ((row.RowType == DataControlRowType.DataRow) && ((row.RowState == DataControlRowState.Normal) || (row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
                                {
                                    ProjectTimeGateway projectTimeGatewayForVerify = new ProjectTimeGateway();
                                    int employeeId = 0; if (((HiddenField)row.FindControl("hdfEmployeeId")).Value.Trim() != "") employeeId = Int32.Parse(((HiddenField)row.FindControl("hdfEmployeeId")).Value.Trim());
                                    
                                    DateTime date_ = DateTime.Parse(tbxDate.Text);
                                    string startTime = ""; if (((TextBox)row.FindControl("tbxStartTime")).Text.Trim() != "") startTime = ((TextBox)row.FindControl("tbxStartTime")).Text.Trim();

                                    string endTime = ""; if (((TextBox)row.FindControl("tbxEndTime")).Text.Trim() != "") endTime = ((TextBox)row.FindControl("tbxEndTime")).Text.Trim();

                                    // Verify if the time not exists at DB
                                    if (projectTimeGatewayForVerify.NotExistsByEmployeIdDate_StartTimeEndTime(employeeId, date_, startTime, endTime, companyId))
                                    {
                                        // Verify Job Class
                                        EmployeeGateway employee = new EmployeeGateway();
                                        employee.LoadByEmployeeId(employeeId);
                                        string jobClass = employee.GetJobClassType(employeeId);

                                        if (jobClass == "")
                                        {
                                            lblError2.Visible = true;
                                            lblError2.Text = lblError2.Text + ((TextBox)row.FindControl("tbxTeamMember")).Text.Trim() + ", ";
                                        }
                                    }
                                    else
                                    {
                                        lblError.Visible = true;
                                        lblError.Text = lblError.Text + ((TextBox)row.FindControl("tbxTeamMember")).Text.Trim() + ", ";
                                    }
                                }
                            }
                        }
                    }
                }

                if ((lblError.Visible)||(lblError2.Visible))
                {
                    return false;
                }
                else
                {
                    if (PostStepEndChanges(companyId))
                    {
                        UpdateDatabase();
                        return true;
                    }
                    else
                    {
                       return false;
                    }
                }
            }
            else
            {
                return false;
            }
        }



        private bool ValidateStepEnd()
        {
            cvEnd.Validate();
            cvEndSaveNew.Validate();
            cvEndSaveNewExist.Validate();
            cvEndSaveTemplate.Validate();

            if (cvEnd.IsValid && cvEndSaveNew.IsValid && cvEndSaveNewExist.IsValid && cvEndSaveTemplate.IsValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        private bool PostStepEndChanges(int companyId)
        {
            // Update project times
            projectTime2TDS = new ProjectTimeTDS();
            if (cbxEndConfirm.Checked)
            {
                EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
                int employeeId = employeeGateway.GetEmployeIdByLoginId(Convert.ToInt32(Session["loginID"]));

                TeamProjectTime2Detail teamProjectTime2Detail = new TeamProjectTime2Detail(teamProjectTime2TDS);
                string error = teamProjectTime2Detail.MoveToProjectTime(projectTime2TDS, (string)ViewState["LHMode"], Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_FULL_EDITING"]), ddlTypeOfWork.SelectedValue, ddlFunction.SelectedValue, companyId, employeeId);

                if (error != "")
                {
                    return false;
                }
            }

            // Update team project time
            teamProjectTime2TDSToSave = new TeamProjectTime2TDS();
            if (cbxEndSave.Checked)
            {
                TeamProjectTime2 teamProjectTime2 = new TeamProjectTime2(teamProjectTime2TDS);
                if (rbtnEndSaveNew.Checked)
                {
                    teamProjectTime2.Insert((int)ViewState["teamProjectTimeId"], tbxEndSaveNew.Text.Trim(), teamProjectTime2TDSToSave);
                }
                else
                {
                    teamProjectTime2.Update((int)ViewState["teamProjectTimeId"], int.Parse(luEndSaveTemplate.SelectedValue.ToString()), teamProjectTime2TDSToSave);
                }
            }

            return true;
        }

        #endregion






        // ////////////////////////////////////////////////////////////////////////
        // FINAL EVENTS 
        //

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set wizard title
            mWizard2 master = (mWizard2)this.Master;
            master.WizardTitle = "Add Team Project Time";
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

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



        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";
            contentVariables += "var tbxDate = '" + tbxDate.UniqueID + "';";

            contentVariables += "var hdfTeamProjectTimeId = '" + hdfTeamProjectTimeID.ClientID + "';";
            contentVariables += "var hdfCompaniesId = '" + hdfCompaniesID.ClientID + "';";
            contentVariables += "var hdfProjectId = '" + hdfProjectID.ClientID + "';";
            contentVariables += "var hdfStartTimeId = '" + hdfStartTime.ClientID + "';";
            contentVariables += "var hdfEndTimeId = '" + hdfEndTime.ClientID + "';";
            contentVariables += "var hdfOffsetId = '" + hdfOffset.ClientID + "';";
            contentVariables += "var hdfWorkingDetailsId = '" + hdfWorkingDetails.ClientID + "';";
            contentVariables += "var hdfLocationId = '" + hdfLocation.ClientID + "';";
            contentVariables += "var hdfMealsCountryId = '" + hdfMealsCountry.ClientID + "';";
            contentVariables += "var hdfMealsAllowanceId = '" + hdfMealsAllowance.ClientID + "';";
            contentVariables += "var hdfProjectTimeStateId = '" + hdfProjectTimeState.ClientID + "';";
            contentVariables += "var hdfClearUnitAssigment = '" + hdfClearUnitAssigment.ClientID + "';";
            contentVariables += "var hdfWorkFunctionConcatId = '" + hdfWorkFunctionConcat.ClientID + "';";
            contentVariables += "var hdfWork_Id = '" + hdfWork_.ClientID + "';";
            contentVariables += "var hdfFunction_Id = '" + hdfFunction_.ClientID + "';";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register wizard buttons 
            Table table = (Table)wzTeam.ActiveStep.Parent.Parent.Parent.Parent;
            ControlCollection controlCollection = table.Rows[2].Cells[0].Controls;

            // ... employees step - cancel button
            Control navigationTemplate = controlCollection[2];
            ((Button)navigationTemplate.FindControl("StepNextButton")).Attributes.Add("onclick", "return btnNextButtonClick();");
            ((Button)navigationTemplate.FindControl("StepPreviousButton")).Attributes.Add("onclick", "return btnPreviousButtonClick();");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./timesheet_team.js");
        }



        private void UpdateDatabase()
        {
            try
            {
                TeamProjectTime2Gateway teamProjectTime2Gateway = new TeamProjectTime2Gateway(teamProjectTime2TDSToSave);
                teamProjectTime2Gateway.Update(projectTime2TDS);
                
                teamProjectTime2TDSToSave.AcceptChanges();
                teamProjectTime2TDS.AcceptChanges();
                projectTime2TDS.AcceptChanges();
                Session["teamProjectTime2TDS"] = teamProjectTime2TDS;
            }
            catch (Exception ex)
            {
                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }

            DB.Open();
            DB.BeginTransaction();
            try
            {
                if (ddlTypeOfWork.SelectedValue == "MH Rehab")
                {
                    int companyId = Int32.Parse(hdfCompanyId.Value);

                    // Get ids & location
                    int projectId = Int32.Parse(ddlProject.SelectedValue);
                    ProjectGateway projectGateway = new ProjectGateway();
                    projectGateway.LoadByProjectId(projectId);

                    Int64 countryId = projectGateway.GetCountryID(projectId);
                    Int64? provinceId = null; if (projectGateway.GetProvinceID(projectId).HasValue) provinceId = (Int64)projectGateway.GetProvinceID(projectId);
                    Int64? countyId = null; if (projectGateway.GetCountyID(projectId).HasValue) countyId = (Int64)projectGateway.GetCountyID(projectId);
                    Int64? cityId = null; if (projectGateway.GetCityID(projectId).HasValue) cityId = (Int64)projectGateway.GetCityID(projectId);

                    manholeRehabilitationTDS = new ManholeRehabilitationTDS();
                    ManholeRehabilitationWorkDetails manholeRehabilitationWorkDetails = new ManholeRehabilitationWorkDetails(manholeRehabilitationTDS);
                    ManholeRehabilitationWorkDetailsGateway manholeRehabilitationWorkDetailsGateway = new ManholeRehabilitationWorkDetailsGateway(manholeRehabilitationTDS);

                    switch (ddlFunction.SelectedValue)
                    {
                        case "Prep":
                            foreach (GridViewRow row in grdManholesRehabPrep.Rows)
                            {
                                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                                DateTime? prepDate = Convert.ToDateTime(((Label)row.FindControl("lblPrepDate")).Text);

                                if (selected)
                                {
                                    int assetId = Convert.ToInt32(grdManholesRehabPrep.DataKeys[row.RowIndex].Values["AssetID"].ToString());
                                    int workId = 0;

                                    workId = GetWorkId(Int32.Parse(ddlProject.SelectedValue), assetId, "Manhole Rehabilitation", companyId);
                                    
                                    manholeRehabilitationWorkDetails.LoadByWorkIdAssetId(workId, assetId, Int32.Parse(hdfCompanyId.Value));

                                    if (manholeRehabilitationWorkDetailsGateway.Table.Rows.Count > 0)
                                    {
                                        int? batchId = manholeRehabilitationWorkDetailsGateway.GetBatchID(workId);
                                        manholeRehabilitationWorkDetails.Update(workId, prepDate, manholeRehabilitationWorkDetailsGateway.GetSprayedDate(workId), batchId, manholeRehabilitationWorkDetailsGateway.GetDate(workId).Value, companyId);
                                    }
                                    else
                                    {
                                        manholeRehabilitationWorkDetails.Update(workId, prepDate, null, null, DateTime.Now, companyId);
                                    }

                                    manholeRehabilitationWorkDetails.Save2(countryId, provinceId, countyId, cityId, projectId, assetId, companyId, true);
                                }
                            }
                            break;

                        case "Spray":
                            foreach (GridViewRow row in grdManholesRehabSpray.Rows)
                            {
                                bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                                DateTime? sprayDate = Convert.ToDateTime(((Label)row.FindControl("lblSprayDate")).Text);

                                if (selected)
                                {
                                    int assetId = Convert.ToInt32(grdManholesRehabSpray.DataKeys[row.RowIndex].Values["AssetID"].ToString());
                                    int workId = 0;

                                    workId = GetWorkId(Int32.Parse(ddlProject.SelectedValue), assetId, "Manhole Rehabilitation", companyId);
                                    
                                    manholeRehabilitationWorkDetails.LoadByWorkIdAssetId(workId, assetId, Int32.Parse(hdfCompanyId.Value));

                                    if (manholeRehabilitationWorkDetailsGateway.Table.Rows.Count > 0)
                                    {
                                        int? batchId = manholeRehabilitationWorkDetailsGateway.GetBatchID(workId);
                                        manholeRehabilitationWorkDetails.Update(workId, manholeRehabilitationWorkDetailsGateway.GetPreppedDate(workId), sprayDate, batchId, manholeRehabilitationWorkDetailsGateway.GetDate(workId).Value, companyId);
                                    }
                                    else
                                    {
                                        manholeRehabilitationWorkDetails.Update(workId, null, sprayDate, null, DateTime.Now, companyId);
                                    }
                                    
                                    manholeRehabilitationWorkDetails.Save2(countryId, provinceId, countyId, cityId, projectId, assetId, companyId, true);
                                }
                            }
                            break;
                    }

                    DB.CommitTransaction();

                    // Store datasets
                    manholeRehabilitationTDS.AcceptChanges();
                }
                else
                {
                    if (ddlTypeOfWork.SelectedValue == "Full Length")
                    {
                        fullLengthLiningTDS = new FullLengthLiningTDS();
                        AssetSewerSectionGateway aass = new AssetSewerSectionGateway();
                        FullLengthLiningWorkDetails fullLengthLiningWorkDetails = new FullLengthLiningWorkDetails(fullLengthLiningTDS);
                        FullLengthLiningWorkDetailsGateway fullLengthLiningWorkDetailsGateway = new FullLengthLiningWorkDetailsGateway(fullLengthLiningTDS);

                        int assetId = 0;
                        int workId = 0;

                        // Get ids & location
                        int projectId = Int32.Parse(ddlProject.SelectedValue);
                        ProjectGateway projectGateway = new ProjectGateway();
                        projectGateway.LoadByProjectId(projectId);

                        Int64 countryId = projectGateway.GetCountryID(projectId);
                        Int64? provinceId = null; if (projectGateway.GetProvinceID(projectId).HasValue) provinceId = (Int64)projectGateway.GetProvinceID(projectId);
                        Int64? countyId = null; if (projectGateway.GetCountyID(projectId).HasValue) countyId = (Int64)projectGateway.GetCountyID(projectId);
                        Int64? cityId = null; if (projectGateway.GetCityID(projectId).HasValue) cityId = (Int64)projectGateway.GetCityID(projectId);

                        int companyId = Int32.Parse(hdfCompanyId.Value);

                        switch (ddlFunction.SelectedValue)
                        {
                            case "Install":
                                foreach (GridViewRow row in grdSectionsInstall.Rows)
                                {
                                    bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                                    DateTime? installDate = Convert.ToDateTime(((Label)row.FindControl("lblInstallDate")).Text);

                                    if (selected)
                                    {
                                        if (installDate != tkrdpDate_.SelectedDate.Value)
                                        {
                                            installDate = tkrdpDate_.SelectedDate.Value;
                                        }

                                        string sectionId = grdSectionsInstall.DataKeys[row.RowIndex].Values["SectionID"].ToString();
                                        aass.LoadBySectionId(sectionId, companyId);
                                        assetId = aass.GetAssetID(sectionId);
                                        workId = GetWorkId(Int32.Parse(ddlProject.SelectedValue), assetId, "Full Length Lining", companyId);

                                        fullLengthLiningWorkDetails.LoadByWorkIdAssetId(workId, assetId, Int32.Parse(hdfCompanyId.Value));
                                        fullLengthLiningWorkDetails.Update(workId, fullLengthLiningWorkDetailsGateway.GetP1Date(workId), fullLengthLiningWorkDetailsGateway.GetP1Completed(workId), installDate, fullLengthLiningWorkDetailsGateway.GetFinalVideoDate(workId));
                                        fullLengthLiningWorkDetails.Save(countryId, provinceId, countyId, cityId, projectId, assetId, companyId, false, false);
                                    }
                                }
                                break;

                            case "Prep & Measure":
                                foreach (GridViewRow row in grdSections.Rows)
                                {
                                    bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                                    bool completed = ((CheckBox)row.FindControl("cbxCompleted")).Checked;
                                    DateTime? prepDate = Convert.ToDateTime(((Label)row.FindControl("lblPrepDate")).Text);

                                    if (selected)
                                    {
                                        if (completed)
                                        {
                                            if (prepDate != tkrdpDate_.SelectedDate.Value)
                                            {
                                                prepDate = tkrdpDate_.SelectedDate.Value;
                                            }
                                        }
                                        else
                                        {
                                            prepDate = null;
                                        }

                                        string sectionId = grdSections.DataKeys[row.RowIndex].Values["SectionID"].ToString();
                                        aass.LoadBySectionId(sectionId, companyId);
                                        assetId = aass.GetAssetID(sectionId);
                                        workId = GetWorkId(Int32.Parse(ddlProject.SelectedValue), assetId, "Full Length Lining", companyId);

                                        fullLengthLiningWorkDetails.LoadByWorkIdAssetId(workId, assetId, Int32.Parse(hdfCompanyId.Value));
                                        fullLengthLiningWorkDetails.Update(workId, prepDate, completed, fullLengthLiningWorkDetailsGateway.GetInstallDate(workId), fullLengthLiningWorkDetailsGateway.GetFinalVideoDate(workId));
                                        fullLengthLiningWorkDetails.Save(countryId, provinceId, countyId, cityId, projectId, assetId, companyId, false, false);
                                    }
                                }
                                break;

                            case "Reinstate & Post Video":
                                FullLengthLiningLateralDetails fullLengthLiningLateralDetails = new FullLengthLiningLateralDetails(fullLengthLiningTDS);
                                FullLengthLiningLateralDetailsGateway fullLengthLiningLateralDetailsGateway = new FullLengthLiningLateralDetailsGateway(fullLengthLiningTDS);

                                foreach (GridViewRow row in grdSectionsReinstatePostVideo.Rows)
                                {
                                    bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                                    bool completed = ((CheckBox)row.FindControl("cbxCompleted")).Checked;
                                    DateTime? postVideo = Convert.ToDateTime(((Label)row.FindControl("lblPostVideo")).Text);
                                    string sectionId = grdSectionsReinstatePostVideo.DataKeys[row.RowIndex].Values["SectionID"].ToString();

                                    aass.LoadBySectionId(sectionId, companyId);
                                    assetId = aass.GetAssetID(sectionId);
                                    workId = GetWorkId(Int32.Parse(ddlProject.SelectedValue), assetId, "Full Length Lining", companyId);

                                    if (selected)
                                    {
                                        if (completed)
                                        {
                                            if (postVideo != tkrdpDate_.SelectedDate.Value)
                                            {
                                                postVideo = tkrdpDate_.SelectedDate.Value;
                                            }
                                        }
                                        else
                                        {
                                            postVideo = null;
                                        }

                                        fullLengthLiningWorkDetails.LoadByWorkIdAssetId(workId, assetId, Int32.Parse(hdfCompanyId.Value));
                                        fullLengthLiningWorkDetails.Update(workId, fullLengthLiningWorkDetailsGateway.GetP1Date(workId), fullLengthLiningWorkDetailsGateway.GetP1Completed(workId), fullLengthLiningWorkDetailsGateway.GetInstallDate(workId), postVideo);
                                        fullLengthLiningWorkDetails.Save(countryId, provinceId, countyId, cityId, projectId, assetId, companyId, false, false);
                                    }
                                }

                                foreach (GridViewRow row in grdLaterals.Rows)
                                {
                                    string sectionId = grdLaterals.DataKeys[row.RowIndex].Values["SectionID"].ToString();
                                    int assetIdLateral = Convert.ToInt32(((Label)row.FindControl("lblAssetIDLateral")).Text);
                                    bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                                    DateTime? opened = null; if (((CheckBox)row.FindControl("cbxOpened")).Checked) opened = tkrdpDate_.SelectedDate;
                                    DateTime? brushed = null; if (((CheckBox)row.FindControl("cbxBrushed")).Checked) brushed = tkrdpDate_.SelectedDate;

                                    if (selected)
                                    {
                                        aass.LoadBySectionId(sectionId, companyId);
                                        assetId = aass.GetAssetID(sectionId);
                                        workId = GetWorkId(Int32.Parse(ddlProject.SelectedValue), assetId, "Full Length Lining", companyId);

                                        fullLengthLiningLateralDetails.SaveFll(workId, assetIdLateral, companyId, opened, brushed);
                                    }
                                }
                                break;
                        }

                        DB.CommitTransaction();

                        // Store datasets
                        fullLengthLiningTDS.AcceptChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private void UpdateDatabaseForTemplate()
        {
            try
            {
                TeamProjectTime2Gateway teamProjectTime2Gateway = new TeamProjectTime2Gateway(teamProjectTime2TDSToSave);
                teamProjectTime2Gateway.UpdateForTemplate();

                teamProjectTime2TDS.AcceptChanges();
                teamProjectTime2TDSToSave.AcceptChanges();

                // Store dataset
                Session["teamProjectTime2TDS"] = teamProjectTime2TDS;
                template = teamProjectTime2TDS.Template;
                Session["template"] = teamProjectTime2TDS.Template;
                teamProjectTimeDetailTemp = teamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMP;
                Session["teamProjectTimeDetailTemp"] = teamProjectTime2TDS.LFS_TEAM_PROJECT_TIME_DETAIL_TEMP; ;
            }
            catch (Exception ex)
            {
                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }


          
    }
}