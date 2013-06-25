using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.BL.Projects.Projects;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// project_synopsis_report
    /// </summary>
    public partial class project_synopsis_report : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // EVENTS
        //

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Security check
                if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_VIEW"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Tag page
                hdfCompanyId.Value = Convert.ToInt32(Session["companyID"]).ToString();

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
            master.Title = "Project Synopsis Report";

            master.ShowTitle = false;
            master.ShowToolBar = false;
            master.ShowCriteria = false;
            master.CriteriaWidth = "200px";

            if (!IsPostBack)
            {
                master.PrintDirectly = true;
                master.ExportDirectly = false;
            }
        }






        /// ////////////////////////////////////////////////////////////////////////
        /// METHODS
        ///

        private void RegisterDelegates()
        {
            mReport1 master = (mReport1)this.Master;
            master.GenerateMethod = new mReport1.ReportMethod(Generate);
        }



        private void Generate()
        {
            mReport1 master = (mReport1)this.Master;
            int projectId = Int32.Parse(Request.QueryString["project_id"]);

            // Get Data
            // ... For SubContractorName
            int companyId = Int32.Parse(hdfCompanyId.Value);

            LiquiForce.LFSLive.BL.Projects.Projects.ProjectSynopsisReport projectSynopsisReport = new LiquiForce.LFSLive.BL.Projects.Projects.ProjectSynopsisReport();
            projectSynopsisReport.Load(projectId, companyId);

            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            // ... set properties to master page
            master.Data = projectSynopsisReport.Data;
            master.Table = projectSynopsisReport.TableName;

            // Get report
            if (projectSynopsisReport.Table.Rows.Count > 0)
            {
                if (master.Format == "pdf")
                {
                    master.Report = new ProjectSynopsisReport();

                    // Report format
                    master.Report.PrintOptions.PaperOrientation = PaperOrientation.Portrait;
                    master.Report.PrintOptions.PaperSize = PaperSize.PaperLegal;

                    // Security check
                    if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_ADMIN"]))
                    {
                        ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails1Section"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails2Section"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails3Section"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails4Section"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails5Section"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails6Section"]).SectionFormat.EnableSuppress = true;

                        ((Section)master.Report.ReportDefinition.Sections["ServicesDetailSection1"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["ServicesDetailsSection"]).SectionFormat.EnableSuppress = true;

                        ((Section)master.Report.ReportDefinition.Sections["ServicesTotalAveragePriceDetailsSection"]).SectionFormat.EnableSuppress = true;

                        ReportObject subServiceReport = master.Report.ReportDefinition.ReportObjects["subService"];
                        ReportDocument ee = master.Report.OpenSubreport(subServiceReport.Name);
                        ((Section)ee.ReportDefinition.Sections["ServicesAveragePriceDetailsSection"]).SectionFormat.EnableSuppress = true;
                    }

                    if (projectGateway.GetProjectType(projectId) == "Ballpark")
                    {
                        // ... Header of Ballpark
                        ((Section)master.Report.ReportDefinition.Sections["ReportHeaderProjectProposal"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["ReportHeaderBallpark"]).SectionFormat.EnableSuppress = false;
                        ((Section)master.Report.ReportDefinition.Sections["ReportHeaderInternalProjects"]).SectionFormat.EnableSuppress = true;

                        // ... Hide Section
                        ((Section)master.Report.ReportDefinition.Sections["ContactInfoDetailSection1"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["ContactInfoDetailSection2"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["ContactInfoDetailSection3"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["ContactInfoDetailSection4"]).SectionFormat.EnableSuppress = true;

                        ((Section)master.Report.ReportDefinition.Sections["ChargesDetailSection1"]).SectionFormat.EnableSuppress = true;

                        ((Section)master.Report.ReportDefinition.Sections["ServicesDetailSection1"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["ServicesTotalAveragePriceDetailsSection"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["ServicesDetailsSection"]).SectionFormat.EnableSuppress = true;

                        ((Section)master.Report.ReportDefinition.Sections["TermsPurchaseOrderDetailSection1"]).SectionFormat.EnableSuppress = true;

                        ((Section)master.Report.ReportDefinition.Sections["ClientLfsRelationshipDetailSection1"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["ClientLfsRelationshipDetailSection2"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["ClientLfsRelationshipDetailSection3"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["ClientLfsRelationshipDetailSection4"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["ClientLfsRelationshipDetailSection5"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["ClientLfsRelationshipDetailSection6"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["ClientLfsRelationshipDetailSection7"]).SectionFormat.EnableSuppress = true;

                        ((Section)master.Report.ReportDefinition.Sections["PurchaseOrderDetailSection1"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["PurchaseOrderDetailSection2"]).SectionFormat.EnableSuppress = true;

                        ((Section)master.Report.ReportDefinition.Sections["TechnicalDetailSection1"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["TechnicalDetailSection2"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["TechnicalDetailSection3"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["TechnicalDetailSection4"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["TechnicalDetailSection5"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["TechnicalDetailSection6"]).SectionFormat.EnableSuppress = true;

                        ((Section)master.Report.ReportDefinition.Sections["EngineerSubcontractorsDetailSection1"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["subContractorsDetailSection1"]).SectionFormat.EnableSuppress = true;

                        ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails1Section"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails2Section"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails3Section"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails4Section"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails5Section"]).SectionFormat.EnableSuppress = true;
                        ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails6Section"]).SectionFormat.EnableSuppress = true;

                        // Security check
                        if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_ADMIN"]))
                        {
                            ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails1Section"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails2Section"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails3Section"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails4Section"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails5Section"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails6Section"]).SectionFormat.EnableSuppress = true;

                            ((Section)master.Report.ReportDefinition.Sections["ServicesDetailSection1"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["ServicesDetailsSection"]).SectionFormat.EnableSuppress = true;

                            ((Section)master.Report.ReportDefinition.Sections["ServicesTotalAveragePriceDetailsSection"]).SectionFormat.EnableSuppress = true;

                            ReportObject subServiceReport = master.Report.ReportDefinition.ReportObjects["subService"];
                            ReportDocument ee = master.Report.OpenSubreport(subServiceReport.Name);
                            ((Section)ee.ReportDefinition.Sections["ServicesAveragePriceDetailsSection"]).SectionFormat.EnableSuppress = true;
                        }

                    }

                    else
                    {
                        if (projectGateway.GetProjectType(projectId) == "Internal")
                        {
                            // ... Header of Internal Project
                            ((Section)master.Report.ReportDefinition.Sections["ReportHeaderProjectProposal"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["ReportHeaderBallpark"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["ReportHeaderInternalProjects"]).SectionFormat.EnableSuppress = false;

                            // ... Hide Section
                            ((Section)master.Report.ReportDefinition.Sections["ContactInfoDetailSection1"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["ContactInfoDetailSection2"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["ContactInfoDetailSection3"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["ContactInfoDetailSection4"]).SectionFormat.EnableSuppress = true;

                            ((Section)master.Report.ReportDefinition.Sections["ChargesDetailSection1"]).SectionFormat.EnableSuppress = true;

                            ((Section)master.Report.ReportDefinition.Sections["ServicesDetailSection1"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["ServicesTotalAveragePriceDetailsSection"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["ServicesDetailsSection"]).SectionFormat.EnableSuppress = true;

                            ((Section)master.Report.ReportDefinition.Sections["TermsPurchaseOrderDetailSection1"]).SectionFormat.EnableSuppress = true;

                            ((Section)master.Report.ReportDefinition.Sections["ClientLfsRelationshipDetailSection1"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["ClientLfsRelationshipDetailSection2"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["ClientLfsRelationshipDetailSection3"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["ClientLfsRelationshipDetailSection4"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["ClientLfsRelationshipDetailSection5"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["ClientLfsRelationshipDetailSection6"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["ClientLfsRelationshipDetailSection7"]).SectionFormat.EnableSuppress = true;

                            ((Section)master.Report.ReportDefinition.Sections["PurchaseOrderDetailSection1"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["PurchaseOrderDetailSection2"]).SectionFormat.EnableSuppress = true;

                            ((Section)master.Report.ReportDefinition.Sections["TechnicalDetailSection1"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["TechnicalDetailSection2"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["TechnicalDetailSection3"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["TechnicalDetailSection4"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["TechnicalDetailSection5"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["TechnicalDetailSection6"]).SectionFormat.EnableSuppress = true;

                            ((Section)master.Report.ReportDefinition.Sections["EngineerSubcontractorsDetailSection1"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["subContractorsDetailSection1"]).SectionFormat.EnableSuppress = true;

                            ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails1Section"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails2Section"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails3Section"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails4Section"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails5Section"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails6Section"]).SectionFormat.EnableSuppress = true;

                            // Security check
                            if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_ADMIN"]))
                            {
                                ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails1Section"]).SectionFormat.EnableSuppress = true;
                                ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails2Section"]).SectionFormat.EnableSuppress = true;
                                ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails3Section"]).SectionFormat.EnableSuppress = true;
                                ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails4Section"]).SectionFormat.EnableSuppress = true;
                                ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails5Section"]).SectionFormat.EnableSuppress = true;
                                ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails6Section"]).SectionFormat.EnableSuppress = true;

                                ((Section)master.Report.ReportDefinition.Sections["ServicesDetailSection1"]).SectionFormat.EnableSuppress = true;
                                ((Section)master.Report.ReportDefinition.Sections["ServicesDetailsSection"]).SectionFormat.EnableSuppress = true;

                                ((Section)master.Report.ReportDefinition.Sections["ServicesTotalAveragePriceDetailsSection"]).SectionFormat.EnableSuppress = true;

                                ReportObject subServiceReport = master.Report.ReportDefinition.ReportObjects["subService"];
                                ReportDocument ee = master.Report.OpenSubreport(subServiceReport.Name);
                                ((Section)ee.ReportDefinition.Sections["ServicesAveragePriceDetailsSection"]).SectionFormat.EnableSuppress = true;
                            }

                        }
                        else
                        {
                            // ... Header of Internal Project
                            ((Section)master.Report.ReportDefinition.Sections["ReportHeaderProjectProposal"]).SectionFormat.EnableSuppress = false;
                            ((Section)master.Report.ReportDefinition.Sections["ReportHeaderBallpark"]).SectionFormat.EnableSuppress = true;
                            ((Section)master.Report.ReportDefinition.Sections["ReportHeaderInternalProjects"]).SectionFormat.EnableSuppress = true;

                            // Security check
                            if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_ADMIN"]))
                            {
                                ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails1Section"]).SectionFormat.EnableSuppress = true;
                                ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails2Section"]).SectionFormat.EnableSuppress = true;
                                ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails3Section"]).SectionFormat.EnableSuppress = true;
                                ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails4Section"]).SectionFormat.EnableSuppress = true;
                                ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails5Section"]).SectionFormat.EnableSuppress = true;
                                ((Section)master.Report.ReportDefinition.Sections["SaleBillingPricingDetails6Section"]).SectionFormat.EnableSuppress = true;

                                ((Section)master.Report.ReportDefinition.Sections["ServicesDetailSection1"]).SectionFormat.EnableSuppress = true;
                                ((Section)master.Report.ReportDefinition.Sections["ServicesDetailsSection"]).SectionFormat.EnableSuppress = true;

                                ((Section)master.Report.ReportDefinition.Sections["ServicesTotalAveragePriceDetailsSection"]).SectionFormat.EnableSuppress = true;

                                ReportObject subServiceReport = master.Report.ReportDefinition.ReportObjects["subService"];
                                ReportDocument ee = master.Report.OpenSubreport(subServiceReport.Name);
                                ((Section)ee.ReportDefinition.Sections["ServicesAveragePriceDetailsSection"]).SectionFormat.EnableSuppress = true;
                            }
                        }
                    }
                }
                else
                {
                }

                // ... set parameters to report
                if (master.Format == "pdf")
                {
                }
            }
        }
    }
}
