using System;
using CrystalDecisions.CrystalReports.Engine;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.BL.Resources.Companies;
using LiquiForce.LFSLive.DA.LabourHours.ActualCosts;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.DA.Resources.Companies;
using LiquiForce.LFSLive.DA.RAF;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts
{
    /// <summary>
    /// actual_costs_report
    /// </summary>
    public partial class actual_costs_report : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Access to this page
                if (!Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_ACTUAL_COSTS_VIEW"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Tag Page
                hdfCompanyId.Value = Session["companyID"].ToString();

                // Prepare initial data                 
                // ... For Client            
                int companyId = Int32.Parse(hdfCompanyId.Value);
                CompaniesList companiesList = new CompaniesList();
                companiesList.LoadAndAddItem(-1, "(All)", companyId);
                ddlClient.DataSource = companiesList.Table;
                ddlClient.DataValueField = "COMPANIES_ID";
                ddlClient.DataTextField = "Name";
                ddlClient.DataBind();

                // ... for project
                ProjectList projectList = new ProjectList();
                projectList.LoadProjectsAndAddItem(-1, "(All)", int.Parse(ddlClient.SelectedValue));
                ddlProject.DataSource = projectList.Table;
                ddlProject.DataValueField = "ProjectID";
                ddlProject.DataTextField = "Name";
                ddlProject.DataBind();

                tkrdpStartDate.SelectedDate = DateTime.Now;
                tkrdpEndDate.SelectedDate = DateTime.Now;

                // Register delegates
                this.RegisterDelegates();
            }
            else
            {
                // Register delegates
                this.RegisterDelegates();
            }
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set title & criteria width
            mReport1 master = (mReport1)this.Master;
            master.Title = "Actual Costs Report";

            master.ShowTitle = true;
            master.ShowToolBar = true;
            master.ShowCriteria = true;
            master.CriteriaWidth = "200px";

            if (!IsPostBack)
            {
                master.PrintDirectly = false;
                master.ExportDirectly = false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // AUXILIAR EVENTS
        //

        protected void ddlClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectList projectList = new ProjectList();
            projectList.LoadProjectsAndAddItem(-1, "(All)", int.Parse(ddlClient.SelectedValue));
            ddlProject.DataSource = projectList.Table;
            ddlProject.DataValueField = "ProjectID";
            ddlProject.DataTextField = "Name";
            ddlProject.DataBind();
            ddlProject.SelectedIndex = 0;
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterDelegates()
        {
            mReport1 master = (mReport1)this.Master;
            master.GenerateMethod = new mReport1.ReportMethod(Generate);
        }



        private void GenerateAll()
        {
            mReport1 master = (mReport1)this.Master;

            // Get Data
            string category = ddlCategory.SelectedValue;
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int clientId = Int32.Parse(ddlClient.SelectedValue);
            int projectId = Int32.Parse(ddlProject.SelectedValue);
            DateTime startDate = DateTime.Parse(tkrdpStartDate.SelectedDate.Value.ToShortDateString());
            DateTime endDate = DateTime.Parse(tkrdpEndDate.SelectedDate.Value.ToShortDateString());
            ActualCostsReportTDS actualCostsReportTDS = new ActualCostsReportTDS();
            bool withDates = ckbxDates.Checked;

            LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportGeneral actualCostsReportGeneral = new LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportGeneral(actualCostsReportTDS);

            int rows = actualCostsReportGeneral.LoadAll(category, clientId, projectId, startDate, endDate, companyId, withDates);

            // ... set properties to master page
            master.Data = actualCostsReportGeneral.Data;
            master.Table = actualCostsReportGeneral.TableName;

            // Get report
            if (rows > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new ActualCostsReport();
                    masterParameters(master);
                }
                else
                {
                    master.Report = new ActualCostsReportExport();
                }

                // Make sections visible
                ((Section)master.Report.ReportDefinition.Sections["sDetailSubcontractorCosts"]).SectionFormat.EnableSuppress = false;
                ((Section)master.Report.ReportDefinition.Sections["sDetailHotelCosts"]).SectionFormat.EnableSuppress = false;
                ((Section)master.Report.ReportDefinition.Sections["sDetailsInsuranceCosts"]).SectionFormat.EnableSuppress = false;
                ((Section)master.Report.ReportDefinition.Sections["sDetailBondingCosts"]).SectionFormat.EnableSuppress = false;
                ((Section)master.Report.ReportDefinition.Sections["sDetailOtherCosts"]).SectionFormat.EnableSuppress = false;
            }
        }



        private void Generate()
        {
            mReport1 master = (mReport1)this.Master;

            // Get Data
            string category = ddlCategory.SelectedValue;
            int companyId = Int32.Parse(hdfCompanyId.Value);
            int clientId = Int32.Parse(ddlClient.SelectedValue);
            int projectId = Int32.Parse(ddlProject.SelectedValue);
            DateTime startDate = DateTime.Parse(tkrdpStartDate.SelectedDate.Value.ToShortDateString());
            DateTime endDate = DateTime.Parse(tkrdpEndDate.SelectedDate.Value.ToShortDateString());
            ActualCostsReportTDS actualCostsReportTDS = new ActualCostsReportTDS();
            
            // Load Data
            if (category == "All")
            {
                GenerateAll();
            }
            else
            {
                if (category == "Subcontractors")
                {
                    LoadForSubcontractors(master, category, clientId, projectId, companyId, startDate, endDate, actualCostsReportTDS);
                }
                else
                {
                    if (category == "Hotels")
                    {
                        LoadForHotel(master, category, clientId, projectId, companyId, startDate, endDate, actualCostsReportTDS);
                    }
                    else
                    {
                        if (category == "Insurance")
                        {
                            LoadForInsurance(master, category, clientId, projectId, companyId, startDate, endDate, actualCostsReportTDS);
                        }
                        else
                        {
                            if (category == "Bonding")
                            {
                                LoadForBonding(master, category, clientId, projectId, companyId, startDate, endDate, actualCostsReportTDS);                                
                            }
                            else
                            {
                                LoadForOther(master, category, clientId, projectId, companyId, startDate, endDate, actualCostsReportTDS);                                                                
                            }
                        }
                    }
                }
            }
        }



        private void masterParameters(mReport1 master)
        {
            DateTime startDate = DateTime.Parse(tkrdpStartDate.SelectedDate.Value.ToShortDateString());
            DateTime endDate = DateTime.Parse(tkrdpEndDate.SelectedDate.Value.ToShortDateString());
            int companyId = Int32.Parse(hdfCompanyId.Value);

            // ... set parameters to report
            if (master.Format == "pdf")
            {
                // ... ... client
                if (ddlClient.SelectedValue != "-1")
                {
                    int currentClientId = Int32.Parse(ddlClient.SelectedValue);
                    CompaniesGateway companiesGateway = new CompaniesGateway();
                    companiesGateway.LoadByCompaniesId(currentClientId, companyId);
                    master.SetParameter("Client", companiesGateway.GetName(currentClientId));
                }
                else
                {
                    master.SetParameter("Client", "All");
                }

                // ... ...  project
                if (ddlProject.SelectedValue != "-1")
                {
                    int currentProjectId = Int32.Parse(ddlProject.SelectedValue);
                    ProjectGateway projectGateway = new ProjectGateway();
                    projectGateway.LoadByProjectId(currentProjectId);
                    string name = projectGateway.GetName(currentProjectId);
                    master.SetParameter("Project", name);
                }
                else
                {
                    master.SetParameter("Project", "All");
                }

                // ... ... category
                if (ddlCategory.SelectedValue != "-1")
                {
                    string currentCategory = ddlCategory.SelectedValue;
                    master.SetParameter("Category", currentCategory);
                }
                else
                {
                    master.SetParameter("Category", "All");
                }

                // ... ... user
                LoginGateway loginGateway = new LoginGateway();
                loginGateway.LoadByLoginId(Convert.ToInt32(Session["loginID"]), companyId);
                string user = loginGateway.GetLastName(Convert.ToInt32(Session["loginID"]), companyId) + " " + loginGateway.GetFirstName(Convert.ToInt32(Session["loginID"]), companyId);
                master.SetParameter("User", user.Trim());

                // ... for start date                                                
                string startDateParameter = startDate.Month.ToString() + "/" + startDate.Day.ToString() + "/" + startDate.Year.ToString();
                master.SetParameter("StartDate", startDateParameter);

                // ... for end date           
                string endDateParameter = endDate.Month.ToString() + "/" + endDate.Day.ToString() + "/" + endDate.Year.ToString();
                master.SetParameter("EndDate", endDateParameter);
            }
        }



        private void LoadForSubcontractors(mReport1 master, string category, int clientId, int projectId, int companyId, DateTime startDate, DateTime endDate, ActualCostsReportTDS actualCostsReportTDS)
        {
            LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportGeneral actualCostsReportGeneral = new LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportGeneral(actualCostsReportTDS);
            actualCostsReportGeneral.LoadForSubcontractors(category, clientId, projectId, startDate, endDate, companyId, ckbxDates.Checked);
            LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportSubcontractorCosts actualCostsReportSubcontractorCosts = new LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportSubcontractorCosts(actualCostsReportTDS);
            
            // Set properties to master page
            master.Data = actualCostsReportSubcontractorCosts.Data;
            master.Table = actualCostsReportSubcontractorCosts.TableName;

            // Get report
            if (actualCostsReportSubcontractorCosts.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new ActualCostsReport();
                    masterParameters(master);
                }
                else
                {
                    master.Report = new ActualCostsReportExport();
                }

                // Make sections visible
                ((Section)master.Report.ReportDefinition.Sections["sDetailSubcontractorCosts"]).SectionFormat.EnableSuppress = false;
                ((Section)master.Report.ReportDefinition.Sections["sDetailHotelCosts"]).SectionFormat.EnableSuppress = true;
                ((Section)master.Report.ReportDefinition.Sections["sDetailsInsuranceCosts"]).SectionFormat.EnableSuppress = true;
                ((Section)master.Report.ReportDefinition.Sections["sDetailBondingCosts"]).SectionFormat.EnableSuppress = true;
                ((Section)master.Report.ReportDefinition.Sections["sDetailOtherCosts"]).SectionFormat.EnableSuppress = true;
            }
        }



        private void LoadForHotel(mReport1 master, string category, int clientId, int projectId, int companyId, DateTime startDate, DateTime endDate, ActualCostsReportTDS actualCostsReportTDS)
        {
            LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportGeneral actualCostsReportGeneral = new LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportGeneral(actualCostsReportTDS);
            LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportHotelCosts actualCostsReportHotelCosts = new LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportHotelCosts(actualCostsReportTDS);
            actualCostsReportGeneral.LoadForHotels(category, clientId, projectId, startDate, endDate, companyId, ckbxDates.Checked);           

            // Set properties to master page
            master.Data = actualCostsReportHotelCosts.Data;
            master.Table = actualCostsReportHotelCosts.TableName;

            // Get report
            if (actualCostsReportHotelCosts.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new ActualCostsReport();
                    masterParameters(master); 
                }
                else
                {
                    master.Report = new ActualCostsReportExport();
                }

                // Make sections visible
                ((Section)master.Report.ReportDefinition.Sections["sDetailSubcontractorCosts"]).SectionFormat.EnableSuppress = true;
                ((Section)master.Report.ReportDefinition.Sections["sDetailHotelCosts"]).SectionFormat.EnableSuppress = false;
                ((Section)master.Report.ReportDefinition.Sections["sDetailsInsuranceCosts"]).SectionFormat.EnableSuppress = true;
                ((Section)master.Report.ReportDefinition.Sections["sDetailBondingCosts"]).SectionFormat.EnableSuppress = true;
                ((Section)master.Report.ReportDefinition.Sections["sDetailOtherCosts"]).SectionFormat.EnableSuppress = true;
            }
        }



        private void LoadForInsurance(mReport1 master, string category, int clientId, int projectId, int companyId, DateTime startDate, DateTime endDate, ActualCostsReportTDS actualCostsReportTDS)
        {
            LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportGeneral actualCostsReportGeneral = new LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportGeneral(actualCostsReportTDS);
            actualCostsReportGeneral.LoadForInsuranceCompanies(category, clientId, projectId, startDate, endDate, companyId, ckbxDates.Checked);
            LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportInsuranceCosts actualCostsReportInsuranceCosts = new LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportInsuranceCosts(actualCostsReportTDS);

            // Set properties to master page
            master.Data = actualCostsReportInsuranceCosts.Data;
            master.Table = actualCostsReportInsuranceCosts.TableName;

            // Get report
            if (actualCostsReportInsuranceCosts.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new ActualCostsReport();
                    masterParameters(master); 
                }
                else
                {
                    master.Report = new ActualCostsReportExport();
                }        

                // Make sections visible
                ((Section)master.Report.ReportDefinition.Sections["sDetailSubcontractorCosts"]).SectionFormat.EnableSuppress = true;
                ((Section)master.Report.ReportDefinition.Sections["sDetailHotelCosts"]).SectionFormat.EnableSuppress = true;
                ((Section)master.Report.ReportDefinition.Sections["sDetailsInsuranceCosts"]).SectionFormat.EnableSuppress = false;
                ((Section)master.Report.ReportDefinition.Sections["sDetailBondingCosts"]).SectionFormat.EnableSuppress = true;
                ((Section)master.Report.ReportDefinition.Sections["sDetailOtherCosts"]).SectionFormat.EnableSuppress = true;
             }
        }



        private void LoadForBonding(mReport1 master, string category, int clientId, int projectId, int companyId, DateTime startDate, DateTime endDate, ActualCostsReportTDS actualCostsReportTDS)
        {
            LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportGeneral actualCostsReportGeneral = new LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportGeneral(actualCostsReportTDS);
            actualCostsReportGeneral.LoadForBondingCompanies(category, clientId, projectId, startDate, endDate, companyId, ckbxDates.Checked);
            LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportBondingCosts actualCostsReportBondingCosts = new LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportBondingCosts(actualCostsReportTDS);

            // Set properties to master page
            master.Data = actualCostsReportBondingCosts.Data;
            master.Table = actualCostsReportBondingCosts.TableName;

            // Get report
            if (actualCostsReportBondingCosts.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new ActualCostsReport();
                    masterParameters(master);
                }
                else
                {
                    master.Report = new ActualCostsReportExport();
                }
            
                // Make sections visible
                ((Section)master.Report.ReportDefinition.Sections["sDetailSubcontractorCosts"]).SectionFormat.EnableSuppress = true;
                ((Section)master.Report.ReportDefinition.Sections["sDetailHotelCosts"]).SectionFormat.EnableSuppress = true;
                ((Section)master.Report.ReportDefinition.Sections["sDetailsInsuranceCosts"]).SectionFormat.EnableSuppress = true;
                ((Section)master.Report.ReportDefinition.Sections["sDetailBondingCosts"]).SectionFormat.EnableSuppress = false;
                ((Section)master.Report.ReportDefinition.Sections["sDetailOtherCosts"]).SectionFormat.EnableSuppress = true;
            }
        }



        private void LoadForOther(mReport1 master, string category, int clientId, int projectId, int companyId, DateTime startDate, DateTime endDate, ActualCostsReportTDS actualCostsReportTDS)
        {
            LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportGeneral actualCostsReportGeneral = new LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportGeneral(actualCostsReportTDS);
            actualCostsReportGeneral.LoadForOtherCosts(category, clientId, projectId, startDate, endDate, companyId, ckbxDates.Checked);
            LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportOtherCosts actualCostsReportOtherCosts = new LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsReportOtherCosts(actualCostsReportTDS);

            // Set properties to master page
            master.Data = actualCostsReportOtherCosts.Data;
            master.Table = actualCostsReportOtherCosts.TableName;

            // Get report
            if (actualCostsReportOtherCosts.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new ActualCostsReport();
                    masterParameters(master);
                }
                else
                {
                    master.Report = new ActualCostsReportExport();
                }

                // Make sections visible
                ((Section)master.Report.ReportDefinition.Sections["sDetailSubcontractorCosts"]).SectionFormat.EnableSuppress = true;
                ((Section)master.Report.ReportDefinition.Sections["sDetailHotelCosts"]).SectionFormat.EnableSuppress = true;
                ((Section)master.Report.ReportDefinition.Sections["sDetailsInsuranceCosts"]).SectionFormat.EnableSuppress = true;
                ((Section)master.Report.ReportDefinition.Sections["sDetailBondingCosts"]).SectionFormat.EnableSuppress = true;
                ((Section)master.Report.ReportDefinition.Sections["sDetailOtherCosts"]).SectionFormat.EnableSuppress = false;
            }        
        }



    }
}