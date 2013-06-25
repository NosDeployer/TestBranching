using System;
using LiquiForce.LFSLive.DA.RAF;
using CrystalDecisions.Shared;
using LiquiForce.LFSLive.DA.LabourHours.ActualCosts;
using CrystalDecisions.CrystalReports.Engine;

namespace LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts
{
    /// <summary>
    /// actual_costs_print_search_results_report
    /// </summary>
    public partial class actual_costs_print_search_results_report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_ACTUAL_COSTS_ADMIN"])))
            {
                // Security check
                if (!(Convert.ToBoolean(Session["sgLFS_LABOUR_HOURS_ACTUAL_COSTS_VIEW"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }
            }

            // Register delegates
            this.RegisterDelegates();
        }



        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set title & criteria width
            mReport1 master = (mReport1)this.Master;
            master.Title = "Actual Costs Search Results";
            master.ShowTitle = false;
            master.ShowToolBar = false;
            master.ShowCriteria = false;
            master.CriteriaWidth = "0px";

            if (!IsPostBack)
            {
                if (Request.QueryString["format"] == "pdf")
                {
                    master.PrintDirectly = true;
                }
                else
                {
                    master.ExportDirectly = true;
                }
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterDelegates()
        {
            mReport1 master = (mReport1)this.Master;
            master.GenerateMethod = new mReport1.ReportMethod(Generate);
        }



        private void Generate()
        {
            mReport1 master = (mReport1)this.Master;

            string category = Request.QueryString["category"];
            ActualCostsNavigatorTDS actualCostsNavigatorTDS = (ActualCostsNavigatorTDS)Session["actualCostsNavigatorTDS"];

            // Load Data
            if (category == "All")
            {
                // ... subcontractors
                LoadForSubcontractors(master, actualCostsNavigatorTDS);

                // ... hotels
                LoadForHotel(master, actualCostsNavigatorTDS);

                // ... insurance
                LoadForInsurance(master, actualCostsNavigatorTDS);

                // ... bonding
                LoadForBonding(master, actualCostsNavigatorTDS);

                // ... other                 
                LoadForOther(master, actualCostsNavigatorTDS);
            }
            else
            {
                if (category == "Subcontractors")
                {
                    LoadForSubcontractors(master, actualCostsNavigatorTDS);
                }
                else
                {
                    if (category == "Hotels")
                    {
                        LoadForHotel(master, actualCostsNavigatorTDS);
                    }
                    else
                    {
                        if (category == "Insurance")
                        {
                            LoadForInsurance(master, actualCostsNavigatorTDS);
                        }
                        else
                        {
                            if (category == "Bonding")
                            {
                                LoadForBonding(master, actualCostsNavigatorTDS);
                            }
                            else
                            {
                                LoadForOther(master, actualCostsNavigatorTDS);
                            }
                        }
                    }
                }
            }
        }



        private void LoadForSubcontractors(mReport1 master, ActualCostsNavigatorTDS actualCostsNavigatorTDS)
        {
            LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsNavigatorSubcontractorCosts actualCostsNavigatorSubcontractorCosts = new LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsNavigatorSubcontractorCosts(actualCostsNavigatorTDS);
            if (actualCostsNavigatorSubcontractorCosts.Table.Rows.Count > 0)
            {
                // ... Set properties to master page
                master.Data = actualCostsNavigatorSubcontractorCosts.Data;
                master.Table = actualCostsNavigatorSubcontractorCosts.TableName;

                /*if (master.Format == "pdf")
                {*/
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts.ActualCostsPrintSearchResultsReport();

                    LoginGateway loginGateway = new LoginGateway();
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    int companyId = Convert.ToInt32(Session["companyID"]);

                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());

                    // Report format
                    master.Report.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                    master.Report.PrintOptions.PaperSize = PaperSize.PaperLegal;

                    // Make sections visible
                    string category = Request.QueryString["category"];
            
                    // Load Data
                    if (category == "All")
                    {
                        ((Section)master.Report.ReportDefinition.Sections["sDetailSubcontractorCosts"]).SectionFormat.EnableSuppress = false;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailHotelCosts"]).SectionFormat.EnableSuppress = false;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailsInsuranceCosts"]).SectionFormat.EnableSuppress = false;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailBondingCosts"]).SectionFormat.EnableSuppress = false;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailOtherCosts"]).SectionFormat.EnableSuppress = false;
                    }
                    else
                    {
                        ((Section)master.Report.ReportDefinition.Sections["sDetailSubcontractorCosts"]).SectionFormat.EnableSuppress = false;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailHotelCosts"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailsInsuranceCosts"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailBondingCosts"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailOtherCosts"]).SectionFormat.EnableSuppress = true;
                    }
                /*
                else
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts.ActualCostsPrintSearchResultsReportExport();
                }*/
            }
        }



        private void LoadForHotel(mReport1 master, ActualCostsNavigatorTDS actualCostsNavigatorTDS)
        {
            LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsNavigatorHotelCosts actualCostsNavigatorHotelrCosts = new LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsNavigatorHotelCosts(actualCostsNavigatorTDS);

            if (actualCostsNavigatorHotelrCosts.Table.Rows.Count > 0)
            {
                // ... Set properties to master page
                master.Data = actualCostsNavigatorHotelrCosts.Data;
                master.Table = actualCostsNavigatorHotelrCosts.TableName;

                /*if (master.Format == "pdf")
                {*/
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts.ActualCostsPrintSearchResultsReport();

                    LoginGateway loginGateway = new LoginGateway();
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    int companyId = Convert.ToInt32(Session["companyID"]);

                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());

                    // Report format
                    master.Report.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                    master.Report.PrintOptions.PaperSize = PaperSize.PaperLegal;

                    // Make sections visible
                    string category = Request.QueryString["category"];
            
                    // Load Data
                    if (category == "All")
                    {
                        ((Section)master.Report.ReportDefinition.Sections["sDetailSubcontractorCosts"]).SectionFormat.EnableSuppress = false;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailHotelCosts"]).SectionFormat.EnableSuppress = false;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailsInsuranceCosts"]).SectionFormat.EnableSuppress = false;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailBondingCosts"]).SectionFormat.EnableSuppress = false;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailOtherCosts"]).SectionFormat.EnableSuppress = false;
                    }
                    else
                    {
                        // Make sections visible                     
                        ((Section)master.Report.ReportDefinition.Sections["sDetailSubcontractorCosts"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailHotelCosts"]).SectionFormat.EnableSuppress = false;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailsInsuranceCosts"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailBondingCosts"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailOtherCosts"]).SectionFormat.EnableSuppress = true;
                    }
                /*}
                else
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts.ActualCostsPrintSearchResultsReportExport();
                }*/
            }
        }



        private void LoadForInsurance(mReport1 master, ActualCostsNavigatorTDS actualCostsNavigatorTDS)
        {
            LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsNavigatorInsuranceCompaniesCosts actualCostsNavigatorInsuranceCompaniesCosts = new LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsNavigatorInsuranceCompaniesCosts(actualCostsNavigatorTDS);

            if (actualCostsNavigatorInsuranceCompaniesCosts.Table.Rows.Count > 0)
            {
                // ... Set properties to master page
                master.Data = actualCostsNavigatorInsuranceCompaniesCosts.Data;
                master.Table = actualCostsNavigatorInsuranceCompaniesCosts.TableName;

                /*if (master.Format == "pdf")
                {*/
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts.ActualCostsPrintSearchResultsReport();

                    LoginGateway loginGateway = new LoginGateway();
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    int companyId = Convert.ToInt32(Session["companyID"]);

                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());

                    // Report format
                    master.Report.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                    master.Report.PrintOptions.PaperSize = PaperSize.PaperLegal;

                    // Make sections visible
                    string category = Request.QueryString["category"];
            
                    // Load Data
                    if (category == "All")
                    {
                        ((Section)master.Report.ReportDefinition.Sections["sDetailSubcontractorCosts"]).SectionFormat.EnableSuppress = false;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailHotelCosts"]).SectionFormat.EnableSuppress = false;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailsInsuranceCosts"]).SectionFormat.EnableSuppress = false;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailBondingCosts"]).SectionFormat.EnableSuppress = false;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailOtherCosts"]).SectionFormat.EnableSuppress = false;
                    }
                    else
                    {
                        // Make sections visible                                         
                        ((Section)master.Report.ReportDefinition.Sections["sDetailSubcontractorCosts"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailHotelCosts"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailsInsuranceCosts"]).SectionFormat.EnableSuppress = false;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailBondingCosts"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailOtherCosts"]).SectionFormat.EnableSuppress = true;
                    }
                /*}
                else
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts.ActualCostsPrintSearchResultsReportExport();
                }*/
            }
        }



        private void LoadForBonding(mReport1 master, ActualCostsNavigatorTDS actualCostsNavigatorTDS)
        {
            LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsNavigatorBondingCompaniesCosts actualCostsNavigatorBondingCompaniesCosts = new LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsNavigatorBondingCompaniesCosts(actualCostsNavigatorTDS);

            if (actualCostsNavigatorBondingCompaniesCosts.Table.Rows.Count > 0)
            {
                // ... Set properties to master page
                master.Data = actualCostsNavigatorBondingCompaniesCosts.Data;
                master.Table = actualCostsNavigatorBondingCompaniesCosts.TableName;

                /*if (master.Format == "pdf")
                {*/
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts.ActualCostsPrintSearchResultsReport();

                    LoginGateway loginGateway = new LoginGateway();
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    int companyId = Convert.ToInt32(Session["companyID"]);

                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());

                    // Report format
                    master.Report.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                    master.Report.PrintOptions.PaperSize = PaperSize.PaperLegal;

                    // Make sections visible
                    string category = Request.QueryString["category"];
            
                    // Load Data
                    if (category == "All")
                    {
                        ((Section)master.Report.ReportDefinition.Sections["sDetailSubcontractorCosts"]).SectionFormat.EnableSuppress = false;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailHotelCosts"]).SectionFormat.EnableSuppress = false;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailsInsuranceCosts"]).SectionFormat.EnableSuppress = false;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailBondingCosts"]).SectionFormat.EnableSuppress = false;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailOtherCosts"]).SectionFormat.EnableSuppress = false;
                    }
                    else
                    {
                        // Make sections visible
                        ((Section)master.Report.ReportDefinition.Sections["sDetailSubcontractorCosts"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailHotelCosts"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailsInsuranceCosts"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailBondingCosts"]).SectionFormat.EnableSuppress = false;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailOtherCosts"]).SectionFormat.EnableSuppress = true;
                    }
                /*}
                else
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts.ActualCostsPrintSearchResultsReportExport();
                }*/
            }
        }



        private void LoadForOther(mReport1 master, ActualCostsNavigatorTDS actualCostsNavigatorTDS)
        {
            LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsNavigatorOtherCosts actualCostsNavigatorOtherCosts = new LiquiForce.LFSLive.BL.LabourHours.ActualCosts.ActualCostsNavigatorOtherCosts(actualCostsNavigatorTDS);

            if (actualCostsNavigatorOtherCosts.Table.Rows.Count > 0)
            {
                // ... Set properties to master page
                master.Data = actualCostsNavigatorOtherCosts.Data;
                master.Table = actualCostsNavigatorOtherCosts.TableName;

                /*if (master.Format == "pdf")
                {*/
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts.ActualCostsPrintSearchResultsReport();

                    LoginGateway loginGateway = new LoginGateway();
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    int companyId = Convert.ToInt32(Session["companyID"]);

                    loginGateway.LoadByLoginId(loginId, companyId);
                    string user = loginGateway.GetLastName(loginId, companyId) + " " + loginGateway.GetFirstName(loginId, companyId);
                    master.SetParameter("User", user.Trim());

                    // Report format
                    master.Report.PrintOptions.PaperOrientation = PaperOrientation.Landscape;
                    master.Report.PrintOptions.PaperSize = PaperSize.PaperLegal;

                    // Make sections visible
                    string category = Request.QueryString["category"];
            
                    // Load Data
                    if (category == "All")
                    {
                        ((Section)master.Report.ReportDefinition.Sections["sDetailSubcontractorCosts"]).SectionFormat.EnableSuppress = false;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailHotelCosts"]).SectionFormat.EnableSuppress = false;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailsInsuranceCosts"]).SectionFormat.EnableSuppress = false;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailBondingCosts"]).SectionFormat.EnableSuppress = false;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailOtherCosts"]).SectionFormat.EnableSuppress = false;
                    }
                    else
                    {
                        // Make sections visible
                        ((Section)master.Report.ReportDefinition.Sections["sDetailSubcontractorCosts"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailHotelCosts"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailsInsuranceCosts"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailBondingCosts"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["sDetailOtherCosts"]).SectionFormat.EnableSuppress = false;
                    }
                /*}
                else
                {
                    master.Report = new LiquiForce.LFSLive.WebUI.LabourHours.ActualCosts.ActualCostsPrintSearchResultsReportExport();
                }*/
            }
        }



    }
}