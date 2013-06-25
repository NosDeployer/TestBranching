using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.Projects.Projects;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.Server;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// project_costing_sheets_add
    /// </summary>
    public partial class project_costing_sheets_add : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ProjectCostingSheetAddTDS projectCostingSheetAddTDS;
        protected ProjectCostingSheetAddTDS.LabourHoursInformationDataTable labourHoursInformation;
        protected ProjectCostingSheetAddTDS.UnitsInformationDataTable unitsInformation;
        protected ProjectCostingSheetAddTDS.SubcontractorsInformationDataTable subcontractorsInformation;
        protected ProjectCostingSheetAddTDS.MaterialsInformationDataTable materialsInformation;
        protected ProjectCostingSheetAddTDS.OtherCostsInformationDataTable otherCostsInformation;
        protected ProjectCostingSheetAddTDS.RevenueInformationDataTable revenueInformation;
        protected ProjectCostingSheetAddTDS.TemplateInformationDataTable templateInformation;
        protected ProjectCostingSheetAddTDS.HotelsInformationDataTable hotelsInformation;
        protected ProjectCostingSheetAddTDS.BondingsInformationDataTable bondingsInformation;
        protected ProjectCostingSheetAddTDS.InsurancesInformationDataTable insurancesInformation;
        protected ProjectCostingSheetAddTDS.OtherCategoryInformationDataTable otherCategoryInformation;






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
                if (!Convert.ToBoolean(Session["sgLFS_PROJECTS_COSTINGSHEETS_ADMIN"]))
                {
                    if (!(Convert.ToBoolean(Session["sgLFS_PROJECTS_COSTINGSHEETS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_PROJECTS_COSTINGSHEETS_ADD"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["project_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in project_costing_sheets_add.aspx");
                }

                // Tag Page
                TagPage();

                // Initialize viewstate variables
                ViewState["StepFrom"] = "Out";
                Session.Remove("labourHoursInformationDummy");
                Session.Remove("labourHoursInformation");
                Session.Remove("unitsInformationDummy");
                Session.Remove("unitsInformation");
                Session.Remove("subcontractorsInformationDummy");
                Session.Remove("subcontractorsInformation");
                Session.Remove("materialsInformationDummy");
                Session.Remove("materialsInformation");
                Session.Remove("otherCostsInformationDummy");
                Session.Remove("otherCostsInformation");
                Session.Remove("revenueInformationDummy");
                Session.Remove("revenueInformation");
                Session.Remove("templateInformationDummy");
                Session.Remove("templateInformation");

                Session.Remove("hotelsInformationDummy");
                Session.Remove("hotelsInformation");

                Session.Remove("bondingsInformationDummy");
                Session.Remove("bondingsInformation");

                Session.Remove("insurancesInformationDummy");
                Session.Remove("insurancesInformation");

                Session.Remove("otherCategoryInformationDummy");
                Session.Remove("otherCategoryInformation");

                // ... Initialize tables
                projectCostingSheetAddTDS = new ProjectCostingSheetAddTDS();
                labourHoursInformation = new ProjectCostingSheetAddTDS.LabourHoursInformationDataTable();
                unitsInformation = new ProjectCostingSheetAddTDS.UnitsInformationDataTable();
                subcontractorsInformation = new ProjectCostingSheetAddTDS.SubcontractorsInformationDataTable();
                materialsInformation = new ProjectCostingSheetAddTDS.MaterialsInformationDataTable();
                otherCostsInformation = new ProjectCostingSheetAddTDS.OtherCostsInformationDataTable();
                revenueInformation = new ProjectCostingSheetAddTDS.RevenueInformationDataTable();
                templateInformation = new ProjectCostingSheetAddTDS.TemplateInformationDataTable();
                hotelsInformation = new ProjectCostingSheetAddTDS.HotelsInformationDataTable();
                bondingsInformation = new ProjectCostingSheetAddTDS.BondingsInformationDataTable();
                insurancesInformation = new ProjectCostingSheetAddTDS.InsurancesInformationDataTable();
                otherCategoryInformation = new ProjectCostingSheetAddTDS.OtherCategoryInformationDataTable();

                tbxTeamMembersTotalCostCAD.Text = "0";
                tbxTeamMembersTotalCostUSD.Text = "0";
                tbxUnitsTotalCostsCAD.Text = "0";
                tbxUnitsTotalCostsUSD.Text = "0";
                tbxSubcontractorsTotalCostsCAD.Text = "0";
                tbxSubcontractorsTotalCostsUSD.Text = "0";
                tbxMaterialsTotalCostsCAD.Text = "0";
                tbxMaterialsTotalCostsUSD.Text = "0";
                tbxOtherCostsTotalCostsCAD.Text = "0";
                tbxOtherCostsTotalCostsUSD.Text = "0";
                tbxRevenueTotal.Text = "0";
                tbxGradRevenue.Text = "0";
                tbxGrandProfit.Text = "0";
                tbxGrandGrossMargin.Text = "0";

                tbxHotelsTotalCostsCAD.Text = "0";
                tbxHotelsTotalCostsUSD.Text = "0";

                tbxBondingsTotalCostsCAD.Text = "0";
                tbxBondingsTotalCostsUSD.Text = "0";

                tbxInsurancesTotalCostsCAD.Text = "0";
                tbxInsurancesTotalCostsUSD.Text = "0";

                tbxOtherCategoryTotalCostsCAD.Text = "0";
                tbxOtherCategoryTotalCostsUSD.Text = "0";
                
                // ... Store tables
                Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;
                Session["labourHoursInformation"] = labourHoursInformation;
                Session["unitsInformation"] = unitsInformation;
                Session["subcontractorsInformation"] = subcontractorsInformation;
                Session["materialsInformation"] = materialsInformation;
                Session["otherCostsInformation"] = otherCostsInformation;
                Session["revenueInformation"] = revenueInformation;
                Session["templateInformation"] = templateInformation;

                Session["hotelsInformation"] = hotelsInformation;
                Session["bondingsInformation"] = bondingsInformation;
                Session["insurancesInformation"] = insurancesInformation;
                Session["otherCategoryInformation"] = otherCategoryInformation;

                // StepGeneralInformation
                wzProjectCostinsSheetsAdd.ActiveStepIndex = 0;
            }
            else
            {
                // Restore tables
                projectCostingSheetAddTDS = (ProjectCostingSheetAddTDS)Session["projectCostingSheetAddTDS"];
                labourHoursInformation = (ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Session["labourHoursInformation"];
                unitsInformation = (ProjectCostingSheetAddTDS.UnitsInformationDataTable)Session["unitsInformation"];
                subcontractorsInformation = (ProjectCostingSheetAddTDS.SubcontractorsInformationDataTable)Session["subcontractorsInformation"];
                materialsInformation = (ProjectCostingSheetAddTDS.MaterialsInformationDataTable)Session["materialsInformation"];
                otherCostsInformation = (ProjectCostingSheetAddTDS.OtherCostsInformationDataTable)Session["otherCostsInformation"];
                revenueInformation = (ProjectCostingSheetAddTDS.RevenueInformationDataTable)Session["revenueInformation"];
                templateInformation = (ProjectCostingSheetAddTDS.TemplateInformationDataTable)Session["templateInformation"];

                hotelsInformation = (ProjectCostingSheetAddTDS.HotelsInformationDataTable)Session["hotelsInformation"];
                bondingsInformation = (ProjectCostingSheetAddTDS.BondingsInformationDataTable)Session["bondingsInformation"];
                insurancesInformation = (ProjectCostingSheetAddTDS.InsurancesInformationDataTable)Session["insurancesInformation"];
                otherCategoryInformation = (ProjectCostingSheetAddTDS.OtherCategoryInformationDataTable)Session["otherCategoryInformation"];
            }
        }






        #region Wizard navigation events

        // ////////////////////////////////////////////////////////////////////////
        // WIZARD NAVIGATION EVENTS
        //

        protected void Wizard_ActiveStepChanged(object sender, EventArgs e)
        {
            if (ViewState["StepFrom"] != null)
            {
                switch (wzProjectCostinsSheetsAdd.ActiveStep.Name)
                {
                    case "Begin":
                        StepBeginIn();
                        break;

                    case "Template":
                        StepTemplateIn();
                        break;

                    case "GeneralInformation":
                        StepGeneralInformationIn();
                        break;

                    case "LabourHourInformation":
                        StepLabourHourInformationIn();
                        break;

                    case "TrucksEquipmentInformation":
                        StepTrucksEquipmentInformationIn();
                        break;

                    case "MaterialInformation":
                        StepMaterialInformationIn();
                        break;                    

                    case "OtherCostInformation":
                        StepOtherCostInformationIn();
                        break;

                    case "SubcontractorInformation":
                        StepSubcontractorsInformationIn();
                        break;

                    case "HotelInformation":
                        StepHotelsInformationIn();
                        break;

                    case "BondingInformation":
                        StepBondingsInformationIn();
                        break;

                    case "InsuranceInformation":
                        StepInsurancesInformationIn();
                        break;

                    case "OtherCategoryInformation":
                        StepOtherCategoryInformationIn();
                        break;

                    case "RevenueInformation":
                        StepRevenueInformationIn();
                        break;

                    case "Summary":
                        StepSummaryIn();
                        break;

                    case "FinalStep":
                        StepFinalStepIn();
                        wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepFinalStep);
                        break;

                    default:
                        throw new Exception("The option for " + wzProjectCostinsSheetsAdd.ActiveStep.Name + " step in project_costing_sheets_add.Wizard_ActiveStepChanged function does not exist");
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzProjectCostinsSheetsAdd.ActiveStep.Name)
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
                        wzProjectCostinsSheetsAdd.ActiveStepIndex = stepBeginTo;
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

                case "GeneralInformation":
                    e.Cancel = !StepGeneralInformationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "GeneralInformation";

                        if (cbxEndConfirm.Checked)
                        {
                            if (cbxLabourHour.Checked)
                            {
                                wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepLabourHourInformation);
                            }
                            else
                            {
                                if (cbxTrucksEquipment.Checked)
                                {
                                    wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepTrucksEquipmentInformation);
                                }
                                else
                                {
                                    if (cbxMaterial.Checked)
                                    {
                                        wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepMaterialInformation);
                                    }
                                    else
                                    {
                                        if (cbxSubcontractor.Checked)
                                        {
                                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepSubcontractorInformation);
                                        }
                                        else
                                        {
                                            if (cbxHotel.Checked)
                                            {
                                                wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepHotelInformation);
                                            }
                                            else
                                            {
                                                if (cbxBonding.Checked)
                                                {
                                                    wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepBondingInformation);
                                                }
                                                else
                                                {
                                                    if (cbxInsurance.Checked)
                                                    {
                                                        wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepInsuranceInformation);
                                                    }
                                                    else
                                                    {
                                                        if (cbxOtherCategory.Checked)
                                                        {
                                                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepOtherCategoryInformation);
                                                        }
                                                        else
                                                        {
                                                            if (cbxOtherCost.Checked)
                                                            {
                                                                wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepOtherCostInformation);
                                                            }
                                                            else
                                                            {

                                                                if (cbxRevenueInformation.Checked)
                                                                {
                                                                    wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(stepRevenueInformation);
                                                                }
                                                                else
                                                                {
                                                                    wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepSummary);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (cbxEndSave.Checked)
                            {
                                wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepSummary);
                            }
                        }
                    }
                    break;

                case "LabourHourInformation":
                    e.Cancel = !StepLabourHourInformationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "LabourHourInformation";

                        if (cbxTrucksEquipment.Checked)
                        {
                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepTrucksEquipmentInformation);
                        }
                        else
                        {
                            if (cbxMaterial.Checked)
                            {
                                wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepMaterialInformation);
                            }
                            else
                            {
                                if (cbxSubcontractor.Checked)
                                {
                                    wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepSubcontractorInformation);
                                }
                                else
                                {
                                    if (cbxHotel.Checked)
                                    {
                                        wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepHotelInformation);
                                    }
                                    else
                                    {
                                        if (cbxBonding.Checked)
                                        {
                                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepBondingInformation);
                                        }
                                        else
                                        {
                                            if (cbxInsurance.Checked)
                                            {
                                                wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepInsuranceInformation);
                                            }
                                            else
                                            {
                                                if (cbxOtherCategory.Checked)
                                                {
                                                    wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepOtherCategoryInformation);
                                                }
                                                else
                                                {
                                                    if (cbxOtherCost.Checked)
                                                    {
                                                        wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepOtherCostInformation);
                                                    }
                                                    else
                                                    {
                                                        if (cbxRevenueInformation.Checked)
                                                        {
                                                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(stepRevenueInformation);
                                                        }
                                                        else
                                                        {
                                                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepSummary);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;

                case "TrucksEquipmentInformation":
                    e.Cancel = !StepTrucksEquipmentInformationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "TrucksEquipmentInformation";

                        if (cbxMaterial.Checked)
                        {
                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepMaterialInformation);
                        }
                        else
                        {
                            if (cbxSubcontractor.Checked)
                            {
                                wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepSubcontractorInformation);
                            }
                            else
                            {
                                if (cbxHotel.Checked)
                                {
                                    wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepHotelInformation);
                                }
                                else
                                {
                                    if (cbxBonding.Checked)
                                    {
                                        wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepBondingInformation);
                                    }
                                    else
                                    {
                                        if (cbxInsurance.Checked)
                                        {
                                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepInsuranceInformation);
                                        }
                                        else
                                        {
                                            if (cbxOtherCategory.Checked)
                                            {
                                                wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepOtherCategoryInformation);
                                            }
                                            else
                                            {
                                                if (cbxOtherCost.Checked)
                                                {
                                                    wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepOtherCostInformation);
                                                }
                                                else
                                                {
                                                    if (cbxRevenueInformation.Checked)
                                                    {
                                                        wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(stepRevenueInformation);
                                                    }
                                                    else
                                                    {
                                                        wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepSummary);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;

                case "MaterialInformation":
                    e.Cancel = !StepMaterialInformationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "MaterialInformation";

                        if (cbxSubcontractor.Checked)
                        {
                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepSubcontractorInformation);
                        }
                        else
                        {
                            if (cbxHotel.Checked)
                            {
                                wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepHotelInformation);
                            }
                            else
                            {
                                if (cbxBonding.Checked)
                                {
                                    wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepBondingInformation);
                                }
                                else
                                {
                                    if (cbxInsurance.Checked)
                                    {
                                        wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepInsuranceInformation);
                                    }
                                    else
                                    {
                                        if (cbxOtherCategory.Checked)
                                        {
                                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepOtherCategoryInformation);
                                        }
                                        else
                                        {
                                            if (cbxOtherCost.Checked)
                                            {
                                                wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepOtherCostInformation);
                                            }
                                            else
                                            {
                                                if (cbxRevenueInformation.Checked)
                                                {
                                                    wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(stepRevenueInformation);
                                                }
                                                else
                                                {
                                                    wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepSummary);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;

                case "SubcontractorInformation":
                    e.Cancel = !StepSubcontractorsInformationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "SubcontractorInformation";

                        if (cbxHotel.Checked)
                        {
                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepHotelInformation);
                        }
                        else
                        {
                            if (cbxBonding.Checked)
                            {
                                wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepBondingInformation);
                            }
                            else
                            {
                                if (cbxInsurance.Checked)
                                {
                                    wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepInsuranceInformation);
                                }
                                else
                                {
                                    if (cbxOtherCategory.Checked)
                                    {
                                        wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepOtherCategoryInformation);
                                    }
                                    else
                                    {
                                        if (cbxOtherCost.Checked)
                                        {
                                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepOtherCostInformation);
                                        }
                                        else
                                        {
                                            if (cbxRevenueInformation.Checked)
                                            {
                                                wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(stepRevenueInformation);
                                            }
                                            else
                                            {
                                                wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepSummary);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;

                case "HotelInformation":
                    e.Cancel = !StepHotelsInformationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "HotelInformation";

                        if (cbxBonding.Checked)
                        {
                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepBondingInformation);
                        }
                        else
                        {
                            if (cbxInsurance.Checked)
                            {
                                wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepInsuranceInformation);
                            }
                            else
                            {
                                if (cbxOtherCategory.Checked)
                                {
                                    wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepOtherCategoryInformation);
                                }
                                else
                                {
                                    if (cbxOtherCost.Checked)
                                    {
                                        wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepOtherCostInformation);
                                    }
                                    else
                                    {
                                        if (cbxRevenueInformation.Checked)
                                        {
                                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(stepRevenueInformation);
                                        }
                                        else
                                        {
                                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepSummary);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    break;

                case "BondingInformation":
                    e.Cancel = !StepBondingsInformationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "BondingInformation";

                        if (cbxInsurance.Checked)
                        {
                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepInsuranceInformation);
                        }
                        else
                        {
                            if (cbxOtherCategory.Checked)
                            {
                                wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepOtherCategoryInformation);
                            }
                            else
                            {
                                if (cbxOtherCost.Checked)
                                {
                                    wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepOtherCostInformation);
                                }
                                else
                                {
                                    if (cbxRevenueInformation.Checked)
                                    {
                                        wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(stepRevenueInformation);
                                    }
                                    else
                                    {
                                        wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepSummary);
                                    }
                                }
                            }
                        }
                    }
                    break;

                case "InsuranceInformation":
                    e.Cancel = !StepInsurancesInformationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "InsuranceInformation";

                        if (cbxOtherCategory.Checked)
                        {
                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepOtherCategoryInformation);
                        }
                        else
                        {
                            if (cbxOtherCost.Checked)
                            {
                                wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepOtherCostInformation);
                            }
                            else
                            {
                                if (cbxRevenueInformation.Checked)
                                {
                                    wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(stepRevenueInformation);
                                }
                                else
                                {
                                    wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepSummary);
                                }
                            }
                        }
                    }
                    break;

                case "OtherCategoryInformation":
                    e.Cancel = !StepOtherCategoryInformationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "OtherCategoryInformation";

                        if (cbxOtherCost.Checked)
                        {
                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepOtherCostInformation);
                        }
                        else
                        {
                            if (cbxRevenueInformation.Checked)
                            {
                                wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(stepRevenueInformation);
                            }
                            else
                            {
                                wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepSummary);
                            }
                        }
                    }
                    break;

                case "OtherCostInformation":
                    e.Cancel = !StepOtherCostInformationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "OtherCostInformation";

                        if (cbxRevenueInformation.Checked)
                        {
                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(stepRevenueInformation);
                        }
                        else
                        {
                            wzProjectCostinsSheetsAdd.ActiveStepIndex = wzProjectCostinsSheetsAdd.WizardSteps.IndexOf(StepSummary);
                        }
                    }

                    break;

                case "RevenueInformation":
                    e.Cancel = !StepRevenueInformationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "RevenueInformation";
                    }
                    break;

                default:
                    throw new Exception("The option for " + wzProjectCostinsSheetsAdd.ActiveStep.Name + " step in project_costing_sheets_add.Wizard_NextButtonClick function does not exist");
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzProjectCostinsSheetsAdd.ActiveStep.Name)
            {
                case "Template":
                    e.Cancel = !StepTemplatePrevious();
                    break;

                case "GeneralInformation":
                    e.Cancel = !StepGeneralInformationPrevious();
                    break;

                case "LabourHourInformation":
                    e.Cancel = !StepLabourHourInformationPrevious();
                    break;

                case "TrucksEquipmentInformation":
                    e.Cancel = !StepTrucksEquipmentInformationPrevious();
                    break;

                case "MaterialInformation":
                    e.Cancel = !StepMaterialInformationPrevious();
                    break;

                case "OtherCostInformation":
                    e.Cancel = !StepOtherCostInformationPrevious();
                    break;

                case "SubcontractorInformation":
                    e.Cancel = !StepSubcontractorsInformationPrevious();
                    break;

                case "HotelInformation":
                    e.Cancel = false;
                    break;

                case "BondingInformation":
                    e.Cancel = false;
                    break;

                case "InsuranceInformation":
                    e.Cancel = false;
                    break;

                case "OtherCategoryInformation":
                    e.Cancel = false;
                    break;

                case "RevenueInformation":
                    e.Cancel = !StepRevenueInformationPrevious();
                    break;

                case "Summary":
                    e.Cancel = !StepSummaryPrevious();
                    break;

                default:
                    throw new Exception("The option for " + wzProjectCostinsSheetsAdd.ActiveStep.Name + " step in project_costing_sheets_add.Wizard_PreviousButtonClick function does not exist");
            }
            if (!e.Cancel)
            {
                ViewState["StepFrom"] = wzProjectCostinsSheetsAdd.ActiveStep.Name;
            }
        }



        protected void Wizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            e.Cancel = !StepSummaryFinish();
        }



        protected void Wizard_CancelButtonClick(object sender, EventArgs e)
        {
            string script = "<script language='javascript'>";
            script += "{ window.close(); }";
            script += "</script>";
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

            // Prepare initial data
            // ... for template
            ProjectCostingSheetTemplateInformation projectCostingSheetTemplateInformation = new ProjectCostingSheetTemplateInformation(projectCostingSheetAddTDS);
            projectCostingSheetTemplateInformation.LoadAll(Convert.ToInt32(hdfCompanyId.Value));

            // Store datasets
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;
            templateInformation = projectCostingSheetAddTDS.TemplateInformation;
            Session["templateInformation"] = templateInformation;
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
            int costingSheetTemplateID = (int)e.Keys["CostingSheetTemplateID"];

            ProjectCostingSheetTemplateInformation model = new ProjectCostingSheetTemplateInformation(projectCostingSheetAddTDS);
            model.Delete(costingSheetTemplateID);

            // Store tables
            Session.Remove("templateInformationDummy");
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            templateInformation = projectCostingSheetAddTDS.TemplateInformation;
            Session["templateInformation"] = templateInformation;
           
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - TEMPLATE - AUXILIAR EVENTS
        //

        protected void grdTemplate_DataBound(object sender, EventArgs e)
        {
            AddCostingSheetTemplateNewEmptyFix(grdTemplate);
        }



        public void DummyCostingSheetTemplateNew(int CostingSheetTemplateID)
        {
        }



        public void DummyCostingSheetTemplateNew(int CostingSheetTemplateID, int original_CostingSheetTemplateID)
        {
        }






        // ////////////////////////////////////////////////////////////////////////
        //  STEP2 - TEMPLATE - PUBLIC METHODS
        //

        public ProjectCostingSheetAddTDS.TemplateInformationDataTable GetCostingSheetTemplate()
        {
            templateInformation = (ProjectCostingSheetAddTDS.TemplateInformationDataTable)Session["templateInformationDummy"];
            if (templateInformation == null)
            {
                templateInformation = ((ProjectCostingSheetAddTDS.TemplateInformationDataTable)Session["templateInformation"]);
            }

            return templateInformation;
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - TEMPLATE - PRIVATE METHODS
        //

        private void StepTemplateIn()
        {
            // Set instruction
            mWizard2 master = (mWizard2)this.Master;
            master.WizardInstruction = "Please select a template and click next.";

            //// Initialize  variables
            lblMessage.Visible = false;            
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
                    lblMessage.Text = "At least one template must be selected";
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



        protected void AddCostingSheetTemplateNewEmptyFix(GridView grdTemplate)
        {
            if (grdTemplate.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectCostingSheetAddTDS.TemplateInformationDataTable dt = new ProjectCostingSheetAddTDS.TemplateInformationDataTable();
                dt.AddTemplateInformationRow("", false, false, false, false, false, false, false, false, false, false, false, false, false, false, companyId, "", "", false, 0, 0, 0, 0, 0, 0, false);
                Session["templateInformationDummy"] = dt;

                grdTemplate.DataBind();
            }

            // normally executes at all postbacks
            if (grdTemplate.Rows.Count == 1)
            {
                ProjectCostingSheetAddTDS.TemplateInformationDataTable dt = (ProjectCostingSheetAddTDS.TemplateInformationDataTable)Session["templateInformationDummy"];
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

            ProjectCostingSheetTemplateInformation projectCostingSheetTemplateInformation = new ProjectCostingSheetTemplateInformation(projectCostingSheetAddTDS);

            foreach (GridViewRow row in grdTemplate.Rows)
            {
                // ... Update all rows
                selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                idForUpdate = Int32.Parse(((Label)row.FindControl("lblCostingSheetTemplateID")).Text.Trim());
                projectCostingSheetTemplateInformation.Update(idForUpdate, selected);

                // ... Save selected project
                if (selected)
                {
                    hdfSelectedIdTemplate.Value = idForUpdate.ToString();
                }
            }

            projectCostingSheetTemplateInformation.Data.AcceptChanges();

            // Store datasets
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;
            templateInformation = projectCostingSheetAddTDS.TemplateInformation;
            Session["templateInformation"] = templateInformation;
        }



        #endregion






        #region STEP3 - GENERAL INFORMATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP3 - GENERAL INFORMATION
        //
                
        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - GENERAL INFORMATION - AUXILIAR EVENTS
        //

        protected void cvWorks_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (cbxRehabAssessmentData.Checked || cbxFullLengthLiningData.Checked || cbxPointRepairData.Checked || cbxJunctionLiningData.Checked || cbxManholeRehabData.Checked || cbxMobilizationData.Checked || cbxOtherData.Checked)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }



        protected void cvCostingArea_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (cbxLabourHour.Checked || cbxMaterial.Checked || cbxTrucksEquipment.Checked || cbxOtherCost.Checked || cbxSubcontractor.Checked || cbxHotel.Checked || cbxBonding.Checked || cbxInsurance.Checked || cbxOtherCategory.Checked)
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }



        protected void cvStartDateEndDate_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //ProjectCostingSheetGateway projectCostingSheetGateway = new ProjectCostingSheetGateway();
            //try
            //{
            //    if (projectCostingSheetGateway.ValidateDateOfCostingSheet(Int32.Parse(hdfProjectId.Value), tkrdpFrom.SelectedDate.Value, tkrdpTo.SelectedDate.Value))
            //    {
            //        args.IsValid = true;
            //    }
            //    else
            //    {
            //        args.IsValid = false;
            //    }
            //}
            //catch
            //{
            //    args.IsValid = false;
            //}
            args.IsValid = true;
        }



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
                //TeamProjectTime2Gateway teamProjectTime2Gateway = new TeamProjectTime2Gateway(new DataSet());
                //if (teamProjectTime2Gateway.IsTemplateNameInUseByTemplateNameLoginId(args.Value, Convert.ToInt32(Session["loginID"])))
                //{
                //    args.IsValid = false;
                //}
                //else
                //{
                   args.IsValid = true;
                //}
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



        private bool ValidateStepEnd()
        {
            cvEnd.Validate();
            cvEndSaveNew.Validate();
            //cvEndSaveNewExist.Validate();
            cvEndSaveTemplate.Validate();

            if (cvEnd.IsValid && cvEndSaveNew.IsValid && cvEndSaveTemplate.IsValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - GENERAL INFORMATION - METHODS
        //

        private void StepGeneralInformationIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please provide general information";

            if (rbtnBeginTemplate.Checked)
            {
                int costingSheetTemplateId = Int32.Parse(hdfSelectedIdTemplate.Value);

                if (costingSheetTemplateId != 0)
                {
                    // Prepare initial data
                    // ... for template
                    foreach (ProjectCostingSheetAddTDS.TemplateInformationRow row in (ProjectCostingSheetAddTDS.TemplateInformationDataTable)Session["templateInformation"])
                    {
                        if (row.CostingSheetTemplateID == costingSheetTemplateId)
                        {
                            tbxName.Text = row.Name;

                            cbxRehabAssessmentData.Checked = row.RAData;
                            cbxFullLengthLiningData.Checked = row.FLLData;
                            cbxPointRepairData.Checked = row.PRData; ;
                            cbxJunctionLiningData.Checked = row.JLData;
                            cbxManholeRehabData.Checked = row.MRData;
                            cbxMobilizationData.Checked = row.MOBData;
                            cbxOtherData.Checked = row.OtherData;

                            cbxLabourHour.Checked = row.LabourHourData;
                            cbxTrucksEquipment.Checked = row.UnitData;
                            cbxMaterial.Checked = row.MaterialData;
                            cbxSubcontractor.Checked = row.SubcontractorData;
                            cbxOtherCost.Checked = row.MiscData;

                            cbxRevenueInformation.Checked = row.RevenueIncluded;

                            luEndSaveTemplate.SelectedValue = row.CostingSheetTemplateID.ToString();

                            try
                            {
                                DateTime startDate = new DateTime(row.Year, row.Month, row.Day);
                                tkrdpFrom.SelectedDate = startDate;
                            }
                            catch { }

                            try
                            {
                                DateTime endDate = new DateTime(row.Year2, row.Month2, row.Day2);
                                tkrdpTo.SelectedDate = endDate;
                            }
                            catch { }
                        }
                    }
                }
            }
        }



        private bool StepGeneralInformationNext()
        {
            if (cbxEndConfirm.Checked)
            {
                Page.Validate("StepGeneralInformation");
            }
            else
            {
                ValidateStepEnd();

                PostPageChanges2();
            }

            return (Page.IsValid) ? true : false;
        }



        private bool StepGeneralInformationPrevious()
        {
            return true;
        }

        #endregion






        #region STEP4 - LABOUR HOUR INFORMATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP4 - LABOUR HOUR INFORMATION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - LABOUR HOUR INFORMATION - EVENTS
        //

        protected void grdTeamMembers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Team member Gridview, if the gridview is edition mode
                    if (grdTeamMembers.EditIndex >= 0)
                    {
                        grdTeamMembers.UpdateRow(grdTeamMembers.EditIndex, true);
                    }

                    // Add New Team Member
                    int projectId = Int32.Parse(hdfProjectId.Value);
                    ProjectGateway projectGateway = new ProjectGateway();

                    // Validate general data
                    Page.Validate("labourHoursNew");

                    if (Page.IsValid)
                    {
                        projectGateway.LoadByProjectId(projectId);

                        // Validate costs
                        if (projectGateway.GetCountryID(projectId) == 1) //Canada
                        {
                            Page.Validate("labourHoursCadNew");
                        }
                        else
                        {
                            Page.Validate("labourHoursUsdNew");
                        }
                    }

                    if (Page.IsValid)
                    {
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        string typeOfWork = ((DropDownList)grdTeamMembers.FooterRow.FindControl("ddlTypeOfWork_New")).SelectedValue;
                        int employeeId = Int32.Parse(((DropDownList)grdTeamMembers.FooterRow.FindControl("ddlTeamMemberNew")).SelectedValue);
                        string name = ((DropDownList)grdTeamMembers.FooterRow.FindControl("ddlTeamMemberNew")).SelectedItem.Text;
                        string unitOfMeasurementLH = ((DropDownList)grdTeamMembers.FooterRow.FindControl("ddlUnitOfMeasurementLHNew")).SelectedValue;
                        double lHQuantity = double.Parse(((TextBox)grdTeamMembers.FooterRow.FindControl("tbxLHQtyNew")).Text.Trim());
                        string unitOfMeasurementMeals = ((DropDownList)grdTeamMembers.FooterRow.FindControl("ddlUnitsOfMeasurementLHMealsNew")).SelectedValue;
                        int? mealsQuantity = null; if (((TextBox)grdTeamMembers.FooterRow.FindControl("tbxMealsQtyNew")).Text.Trim() != "") mealsQuantity = Int32.Parse(((TextBox)grdTeamMembers.FooterRow.FindControl("tbxMealsQtyNew")).Text.Trim());
                        string unitOfMeasurementMotel = ((DropDownList)grdTeamMembers.FooterRow.FindControl("ddlUnitsOfMeasurementLHMotelNew")).SelectedValue;
                        int? motelQuantity = null; if (((TextBox)grdTeamMembers.FooterRow.FindControl("tbxMotelQtyNew")).Text.Trim() != "") motelQuantity = Int32.Parse(((TextBox)grdTeamMembers.FooterRow.FindControl("tbxMotelQtyNew")).Text.Trim());

                        decimal lhCostCad = 0.0M;
                        decimal totalCostCad = 0.0M;
                        decimal? mealsCostCad = null;
                        decimal? motelCostCad = null;
                        decimal lhCostUsd = 0.0M;
                        decimal totalCostUsd = 0.0M;
                        decimal? mealsCostUsd = null;
                        decimal? motelCostUsd = null;

                        if (projectGateway.GetCountryID(projectId) == 1) //Canada
                        {
                            lhCostCad = Decimal.Parse(((TextBox)grdTeamMembers.FooterRow.FindControl("tbxLHCostCADNew")).Text.Trim());
                            if (((TextBox)grdTeamMembers.FooterRow.FindControl("tbxMealsCostCADNew")).Text.Trim() != "") mealsCostCad = Decimal.Parse(((TextBox)grdTeamMembers.FooterRow.FindControl("tbxMealsCostCADNew")).Text.Trim());
                            if (((TextBox)grdTeamMembers.FooterRow.FindControl("tbxMotelCostCADNew")).Text.Trim() != "") motelCostCad = Decimal.Parse(((TextBox)grdTeamMembers.FooterRow.FindControl("tbxMotelCostCADNew")).Text.Trim());
                            totalCostCad = (lhCostCad * decimal.Parse(lHQuantity.ToString()));
                            if (mealsCostCad.HasValue && mealsQuantity.HasValue) totalCostCad = totalCostCad + (mealsCostCad.Value * decimal.Parse(mealsQuantity.Value.ToString()));
                            if (motelCostCad.HasValue && motelQuantity.HasValue) totalCostCad = totalCostCad + (motelCostCad.Value * decimal.Parse(motelQuantity.Value.ToString()));
                            totalCostCad = Decimal.Round(totalCostCad, 2);
                        }
                        else
                        {
                            lhCostUsd = Decimal.Parse(((TextBox)grdTeamMembers.FooterRow.FindControl("tbxLHCostUSDNew")).Text.Trim());
                            if (((TextBox)grdTeamMembers.FooterRow.FindControl("tbxMealsCostUSDNew")).Text.Trim() != "") mealsCostUsd = Decimal.Parse(((TextBox)grdTeamMembers.FooterRow.FindControl("tbxMealsCostUSDNew")).Text.Trim());
                            if (((TextBox)grdTeamMembers.FooterRow.FindControl("tbxMotelCostUSDNew")).Text.Trim() != "") motelCostUsd = Decimal.Parse(((TextBox)grdTeamMembers.FooterRow.FindControl("tbxMotelCostUSDNew")).Text.Trim());
                            totalCostUsd = (lhCostUsd * decimal.Parse(lHQuantity.ToString()));
                            if (mealsCostUsd.HasValue && mealsQuantity.HasValue) totalCostUsd = totalCostUsd + (mealsCostUsd.Value * decimal.Parse(mealsQuantity.Value.ToString()));
                            if (motelCostUsd.HasValue && motelQuantity.HasValue) totalCostUsd = totalCostUsd + (motelCostUsd.Value * decimal.Parse(motelQuantity.Value.ToString()));
                            totalCostUsd = Decimal.Round(totalCostUsd, 2);
                        }

                        DateTime startDate = ((RadDatePicker)grdTeamMembers.FooterRow.FindControl("tkrdpStartDateNew")).SelectedDate.Value;
                        DateTime endDate = ((RadDatePicker)grdTeamMembers.FooterRow.FindControl("tkrdpEndDateNew")).SelectedDate.Value;

                        string workFunctionConcat = "";
                        string function_ = "";
                        workFunctionConcat = ((DropDownList)grdTeamMembers.FooterRow.FindControl("ddlWorkFunctionNew")).SelectedValue;
                        if (workFunctionConcat != "(Select)")
                        {
                            string[] workFunction = workFunctionConcat.ToString().Trim().Split('.');
                            function_ = workFunction[1].Trim();
                        }

                        ProjectCostingSheetAddLabourHoursInformation model = new ProjectCostingSheetAddLabourHoursInformation(projectCostingSheetAddTDS);
                        model.Insert(0, typeOfWork, employeeId, lHQuantity, unitOfMeasurementLH, unitOfMeasurementMeals, mealsQuantity, unitOfMeasurementMotel, motelQuantity, lhCostCad, mealsCostCad, motelCostCad, totalCostCad, lhCostUsd, mealsCostUsd, motelCostUsd, totalCostUsd, false, companyId, name, startDate, endDate, workFunctionConcat, function_);

                        Session.Remove("labourHoursInformationDummy");
                        labourHoursInformation = (ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)model.Table;
                        Session["labourHoursInformation"] = labourHoursInformation;
                        Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                        grdTeamMembers.DataBind();
                        StepLabourHoursInformationProcessGrid();
                    }
                    break;
            }
        }



        protected void grdTeamMembers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();

            // Validate general data
            Page.Validate("labourHoursEdit");

            if (Page.IsValid)
            {
                projectGateway.LoadByProjectId(projectId);

                // Validate costs
                if (projectGateway.GetCountryID(projectId) == 1) //Canada
                {
                    Page.Validate("labourHoursCadEdit");
                }
                else
                {
                    Page.Validate("labourHoursUsdEdit");
                }
            }

            if (Page.IsValid)
            {
                int costingSheetId = (int)e.Keys["CostingSheetID"];
                string work_ = (string)e.Keys["Work_"];
                int employeeId = (int)e.Keys["EmployeeID"];
                int refId = (int)e.Keys["RefID"];
                int companyId = Int32.Parse(hdfCompanyId.Value);

                string name = ((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxTeamMemberEdit")).Text;
                string unitOfMeasurementLH = ((DropDownList)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("ddlUnitOfMeasurementLHEdit")).SelectedValue;
                double lHQuantity = double.Parse(((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxLHQtyEdit")).Text.Trim());
                string unitOfMeasurementMeals = ((DropDownList)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("ddlUnitsOfMeasurementLHMealsEdit")).SelectedValue;
                int? mealsQuantity = null; if (((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMealsQtyEdit")).Text.Trim() != "") mealsQuantity = Int32.Parse(((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMealsQtyEdit")).Text.Trim());
                string unitOfMeasurementMotel = ((DropDownList)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("ddlUnitsOfMeasurementLHMotelEdit")).SelectedValue;
                int? motelQuantity = null; if (((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMotelQtyEdit")).Text.Trim() != "") motelQuantity = Int32.Parse(((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMotelQtyEdit")).Text.Trim());

                decimal lhCostCad = 0.0M;
                decimal totalCostCad = 0.0M;
                decimal? mealsCostCad = null;
                decimal? motelCostCad = null;
                decimal lhCostUsd = 0.0M;
                decimal totalCostUsd = 0.0M;
                decimal? mealsCostUsd = null;
                decimal? motelCostUsd = null;

                if (projectGateway.GetCountryID(projectId) == 1) //Canada
                {
                    lhCostCad = Decimal.Parse(((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxLHCostCADEdit")).Text.Trim());
                    if (((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMealsCostCADEdit")).Text.Trim() != "") mealsCostCad = Decimal.Parse(((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMealsCostCADEdit")).Text.Trim());
                    if (((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMotelCostCADEdit")).Text.Trim() != "") motelCostCad = Decimal.Parse(((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMotelCostCADEdit")).Text.Trim());
                    totalCostCad = (lhCostCad * decimal.Parse(lHQuantity.ToString()));
                    if (mealsCostCad.HasValue && mealsQuantity.HasValue) totalCostCad = totalCostCad + (mealsCostCad.Value * decimal.Parse(mealsQuantity.Value.ToString()));
                    if (motelCostCad.HasValue && motelQuantity.HasValue) totalCostCad = totalCostCad + (motelCostCad.Value * decimal.Parse(motelQuantity.Value.ToString()));
                    totalCostCad = Decimal.Round(totalCostCad, 2);
                }
                else
                {
                    lhCostUsd = Decimal.Parse(((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxLHCostUSDEdit")).Text.Trim());
                    if (((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMealsCostUSDEdit")).Text.Trim() != "") mealsCostUsd = Decimal.Parse(((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMealsCostUSDEdit")).Text.Trim());
                    if (((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMotelCostUSDEdit")).Text.Trim() != "") motelCostUsd = Decimal.Parse(((TextBox)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tbxMotelCostUSDEdit")).Text.Trim());
                    totalCostUsd = (lhCostUsd * decimal.Parse(lHQuantity.ToString()));
                    if (mealsCostUsd.HasValue && mealsQuantity.HasValue) totalCostUsd = totalCostUsd + (mealsCostUsd.Value * decimal.Parse(mealsQuantity.Value.ToString()));
                    if (motelCostUsd.HasValue && motelQuantity.HasValue) totalCostUsd = totalCostUsd + (motelCostUsd.Value * decimal.Parse(motelQuantity.Value.ToString()));
                    totalCostUsd = Decimal.Round(totalCostUsd, 2);
                }

                DateTime startDate = ((RadDatePicker)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tkrdpStartDateEdit")).SelectedDate.Value;
                DateTime endDate = ((RadDatePicker)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("tkrdpEndDateEdit")).SelectedDate.Value;

                string workFunctionConcat = "";
                string function_ = "";
                workFunctionConcat = ((DropDownList)grdTeamMembers.Rows[e.RowIndex].Cells[0].FindControl("ddlWorkFunctionEdit")).SelectedValue;
                if (workFunctionConcat != "(Select)")
                {
                    string[] workFunction = workFunctionConcat.ToString().Trim().Split('.');
                    function_ = workFunction[1].Trim();
                }

                // Update data
                ProjectCostingSheetAddLabourHoursInformation model = new ProjectCostingSheetAddLabourHoursInformation(projectCostingSheetAddTDS);
                model.Update(costingSheetId, work_, employeeId, refId, lHQuantity, unitOfMeasurementLH, unitOfMeasurementMeals, mealsQuantity, unitOfMeasurementMotel, motelQuantity, lhCostCad, mealsCostCad, motelCostCad, totalCostCad, lhCostUsd, mealsCostUsd, motelCostUsd, totalCostUsd, false, companyId, name, startDate, endDate, workFunctionConcat, function_);

                // Store dataset
                labourHoursInformation = (ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)model.Table;
                Session["labourHoursInformation"] = labourHoursInformation;
                Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                StepLabourHoursInformationProcessGrid();
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdTeamMembers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Team member Gridview, if the gridview is edition mode
            if (grdTeamMembers.EditIndex >= 0)
            {
                grdTeamMembers.UpdateRow(grdTeamMembers.EditIndex, true);
            }

            // Add New Team Member
            int costingSheetId = (int)e.Keys["CostingSheetID"];
            string work_ = (string)e.Keys["Work_"];
            int employeeId = (int)e.Keys["EmployeeID"];
            int refId = (int)e.Keys["RefID"];

            ProjectCostingSheetAddLabourHoursInformation model = new ProjectCostingSheetAddLabourHoursInformation(projectCostingSheetAddTDS);

            // Delete Team Member Cost
            model.Delete(costingSheetId, work_, employeeId, refId);

            // Store dataset            
            labourHoursInformation = (ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)model.Table;
            Session["labourHoursInformation"] = labourHoursInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            StepLabourHoursInformationProcessGrid();
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - LABOUR HOUR INFORMATION - AUXILIAR EVENTS
        //

        protected void grdTeamMembers_DataBound(object sender, EventArgs e)
        {
            LabourHoursInformationEmptyFix(grdTeamMembers);
        }



        protected void grdTeamMembers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Edit items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int costingSheetId = Int32.Parse(((Label)e.Row.FindControl("lblCostingSheetIDEdit")).Text.Trim());
                int employeeId = Int32.Parse(((Label)e.Row.FindControl("lblEmployeeIDEdit")).Text.Trim());
                int refId = Int32.Parse(((Label)e.Row.FindControl("lblRefIDEdit")).Text.Trim());
                string work_ = ((Label)e.Row.FindControl("lblWork_Edit")).Text.Trim();

                ProjectCostingSheetAddLabourHoursInformationGateway projectCostingSheetAddLabourHoursInformationGateway = new ProjectCostingSheetAddLabourHoursInformationGateway(projectCostingSheetAddTDS);
                string unitOfMeasurement = projectCostingSheetAddLabourHoursInformationGateway.GetLHUnitOfMeasurement(costingSheetId, work_, employeeId, refId);
                ((DropDownList)e.Row.FindControl("ddlUnitOfMeasurementLHEdit")).SelectedValue = unitOfMeasurement;

                string unitOfMeasurementMeals = projectCostingSheetAddLabourHoursInformationGateway.GetMealsUnitOfMeasurement(costingSheetId, work_, employeeId, refId);
                ((DropDownList)e.Row.FindControl("ddlUnitsOfMeasurementLHMealsEdit")).SelectedValue = unitOfMeasurementMeals;

                string unitOfMeasurementMotel = projectCostingSheetAddLabourHoursInformationGateway.GetMotelUnitOfMeasurement(costingSheetId, work_, employeeId, refId);
                ((DropDownList)e.Row.FindControl("ddlUnitsOfMeasurementLHMotelEdit")).SelectedValue = unitOfMeasurementMotel;

                bool fromDatabase = projectCostingSheetAddLabourHoursInformationGateway.GetFromDatabase(costingSheetId, work_, employeeId, refId);

                if (fromDatabase)
                {
                    ((RadDatePicker)e.Row.FindControl("tkrdpEndDateEdit")).Calendar.Enabled = false;
                    ((RadDatePicker)e.Row.FindControl("tkrdpEndDateEdit")).DateInput.ReadOnly = true;

                    ((RadDatePicker)e.Row.FindControl("tkrdpStartDateEdit")).Calendar.Enabled = false;
                    ((RadDatePicker)e.Row.FindControl("tkrdpStartDateEdit")).DateInput.ReadOnly = true;
                }

                ((RadDatePicker)e.Row.FindControl("hdfFrom")).SelectedDate = tkrdpFrom.SelectedDate;
                ((RadDatePicker)e.Row.FindControl("hdfTo")).SelectedDate = tkrdpTo.SelectedDate;
            }

            // Footer Item
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ((RadDatePicker)e.Row.FindControl("hdfFrom")).SelectedDate = tkrdpFrom.SelectedDate;
                ((RadDatePicker)e.Row.FindControl("hdfTo")).SelectedDate = tkrdpTo.SelectedDate;
            }
        }



        protected void grdTeamMembers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            StepLabourHoursInformationProcessGrid();
        }



        protected void grdTeamMembers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Team member Gridview, if the gridview is edition mode
            if (grdTeamMembers.EditIndex >= 0)
            {
                grdTeamMembers.UpdateRow(grdTeamMembers.EditIndex, true);
            }
        }

        




        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - LABOUR HOUR INFORMATION - METHODS
        //

        private void StepLabourHourInformationIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please verify Labour Hour information";

            // Load
            ProjectCostingSheetAddLabourHoursInformation model = new ProjectCostingSheetAddLabourHoursInformation(projectCostingSheetAddTDS);
            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);
            
            if (projectCostingSheetAddTDS.LabourHoursInformation.Rows.Count <= 0)
            {
                ArrayList works = new ArrayList();
                if (cbxRehabAssessmentData.Checked) works.Add("Rehab Assessment");
                if (cbxFullLengthLiningData.Checked) works.Add("Full Length");
                if (cbxPointRepairData.Checked) { works.Add("Point Lining"); works.Add("Grouting"); }
                if (cbxJunctionLiningData.Checked) works.Add("Junction Lining");
                if (cbxManholeRehabData.Checked) works.Add("MH Rehab");
                if (cbxMobilizationData.Checked) works.Add("Mobilization");
                if (cbxOtherData.Checked)
                {
                    works.Add("Other");
                    works.Add("Downtime");
                    works.Add("Office");
                    works.Add("Office / Shop");
                    works.Add("R & D");
                    works.Add("Special Projects");
                    works.Add("Subcontractor");
                    works.Add("Watermain Relining");
                    works.Add("SOTA");
                }

                if (!projectGateway.GetFairWageApplies(projectId))
                {
                    model.Load(works, projectId, tkrdpFrom.SelectedDate.Value, tkrdpTo.SelectedDate.Value, int.Parse(hdfCompanyId.Value), "");
                }
                else
                {
                    ArrayList jobClassType = new ArrayList();
                    jobClassType.Add("Laborer Group 2");
                    jobClassType.Add("Laborer Group 6");
                    jobClassType.Add("Operator Group 1");
                    jobClassType.Add("Operator Group 2");
                    jobClassType.Add("Regular Rate");

                    model.LoadFairWageProject(works, jobClassType, projectId, tkrdpFrom.SelectedDate.Value, tkrdpTo.SelectedDate.Value, int.Parse(hdfCompanyId.Value), "");
                }
            }

            // Store tables
            Session.Remove("labourHoursInformationDummy");            
            labourHoursInformation = (ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)model.Table;
            Session["labourHoursInformation"] = labourHoursInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            grdTeamMembers.Columns[10].Visible = false;
            grdTeamMembers.Columns[11].Visible = false;
            grdTeamMembers.Columns[12].Visible = false;
            grdTeamMembers.Columns[13].Visible = false;
            grdTeamMembers.Columns[15].Visible = false;
            grdTeamMembers.Columns[16].Visible = false;
            grdTeamMembers.Columns[19].Visible = false;
            grdTeamMembers.Columns[20].Visible = false;
            
            // Validate grid columns
            if (projectGateway.GetCountryID(projectId) == 1) //Canada
            {
                // Team Members Grid
                grdTeamMembers.Columns[14].Visible = true;
                grdTeamMembers.Columns[17].Visible = true;
                grdTeamMembers.Columns[18].Visible = false;
                grdTeamMembers.Columns[21].Visible = false;

                // Totals
                lblTeamMembersTotalCost.Text = "Total Cost (CAD) : ";
                tbxTeamMembersTotalCostCAD.Visible = true;
                tbxTeamMembersTotalCostUSD.Visible = false;
            }
            else
            {
                if (projectGateway.GetCountryID(projectId) == 2) //USA
                {
                    // Team Members Grid
                    grdTeamMembers.Columns[14].Visible = false;
                    grdTeamMembers.Columns[17].Visible = false;
                    grdTeamMembers.Columns[18].Visible = true;
                    grdTeamMembers.Columns[21].Visible = true;

                    // Totals
                    lblTeamMembersTotalCost.Text = "Total Cost (USD) : ";
                    tbxTeamMembersTotalCostCAD.Visible = false;
                    tbxTeamMembersTotalCostUSD.Visible = true;
                }
            }

            grdTeamMembers.DataBind();
            StepLabourHoursInformationProcessGrid();
        }



        private bool StepLabourHourInformationNext()
        {
            StepLabourHoursInformationProcessGrid();

            // Store tables
            Session.Remove("labourHoursInformationDummy");
            Session["labourHoursInformation"] = labourHoursInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            return true;
        }



        private bool StepLabourHourInformationPrevious()
        {
            return true;
        }        



        private void StepLabourHoursInformationProcessGrid()
        {
            decimal totalCostCadLH = 0;
            decimal totalCostUsdLH = 0;
           
            foreach (ProjectCostingSheetAddTDS.LabourHoursInformationRow row in (ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Session["labourHoursInformation"])
            {
                if (!row.Deleted)
                {
                    totalCostCadLH = totalCostCadLH + row.TotalCostCad;
                    totalCostUsdLH = totalCostUsdLH + row.TotalCostUsd;
                }
            }

            tbxTeamMembersTotalCostCAD.Text = Decimal.Round(totalCostCadLH, 2).ToString();
            tbxTeamMembersTotalCostUSD.Text = Decimal.Round(totalCostUsdLH, 2).ToString();
        }



        public ProjectCostingSheetAddTDS.LabourHoursInformationDataTable GetLabourHoursInformation()
        {
            labourHoursInformation = (ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Session["labourHoursInformationDummy"];

            if (labourHoursInformation == null)
            {
                labourHoursInformation = (ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Session["labourHoursInformation"];
            }

            return labourHoursInformation;           
        }



        protected void LabourHoursInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                ProjectCostingSheetAddTDS.LabourHoursInformationDataTable dt = new ProjectCostingSheetAddTDS.LabourHoursInformationDataTable();
                dt.AddLabourHoursInformationRow(0, "", 0, 0, 0, "", "", 0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, false, 3, false, "", DateTime.Now, DateTime.Now, false, "", "", "", "", "", 0, 0);
                Session["labourHoursInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetAddTDS.LabourHoursInformationDataTable dt = (ProjectCostingSheetAddTDS.LabourHoursInformationDataTable)Session["labourHoursInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        public void DummyTeamMembersNew(int original_CostingSheetID, string original_Work_, int original_EmployeeID)
        {
        }



        public void DummyTeamMembersNew(int original_CostingSheetID, string original_Work_, int original_EmployeeID, int original_RefID)
        {
        }



        public void DummyTeamMembersNew(int CostingSheetID, string Work_)
        {
        }



        public void DummyTeamMembersNew(int CostingSheetID, int EmployeeID)
        {
        }



        public void DummyTeamMembersNew(int CostingSheetID)
        {
        }        

        #endregion






        #region STEP5 - TRUCKS EQUIPMENT INFORMATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP5 - TRUCKS EQUIPMENT INFORMATION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP5 - TRUCKS EQUIPMENT INFORMATION - EVENTS
        //

        protected void grdUnits_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Units Gridview, if the gridview is edition mode
                    if (grdUnits.EditIndex >= 0)
                    {
                        grdUnits.UpdateRow(grdUnits.EditIndex, true);
                    }

                    // Validate general data
                    Page.Validate("unitsNew");
                    int projectId = Int32.Parse(hdfProjectId.Value);
                    ProjectGateway projectGateway = new ProjectGateway();

                    if (Page.IsValid)
                    {
                        // Validate costs                        
                        projectGateway.LoadByProjectId(projectId);

                        if (projectGateway.GetCountryID(projectId) == 1) //Canada
                        {
                            Page.Validate("unitsCadNew");
                        }
                        else
                        {
                            Page.Validate("unitsUsdNew");
                        }
                    }

                    if (Page.IsValid)
                    {
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        string typeOfWork = ((DropDownList)grdUnits.FooterRow.FindControl("ddlTypeOfWork_New")).SelectedValue;
                        int unitId = Int32.Parse(((DropDownList)grdUnits.FooterRow.FindControl("ddlUnitCodeNew")).SelectedValue);
                        string unitCode = ((DropDownList)grdUnits.FooterRow.FindControl("ddlUnitCodeNew")).SelectedItem.Text;
                        string unitOfMeasurement = ((DropDownList)grdUnits.FooterRow.FindControl("ddlUnitOfMeasurementUnitsNew")).SelectedValue;
                        double quantity = double.Parse(((TextBox)grdUnits.FooterRow.FindControl("tbxQuantityNew")).Text.Trim());

                        decimal costCad = 0.0M;
                        decimal totalCostCad = 0.0M;
                        decimal costUsd = 0.0M;
                        decimal totalCostUsd = 0.0M;

                        if (projectGateway.GetCountryID(projectId) == 1) //Canada
                        {
                            costCad = Decimal.Parse(((TextBox)grdUnits.FooterRow.FindControl("tbxCostCADNew")).Text.Trim());
                            totalCostCad = (costCad * decimal.Parse(quantity.ToString()));
                            totalCostCad = Decimal.Round(totalCostCad, 2);
                        }
                        else
                        {
                            costUsd = Decimal.Parse(((TextBox)grdUnits.FooterRow.FindControl("tbxCostUSDNew")).Text.Trim());
                            totalCostUsd = (costUsd * decimal.Parse(quantity.ToString()));
                            totalCostUsd = Decimal.Round(totalCostUsd, 2);
                        }

                        LFSLive.DA.FleetManagement.Units.UnitsGateway u = new LiquiForce.LFSLive.DA.FleetManagement.Units.UnitsGateway();
                        u.LoadByUnitId(unitId, companyId);
                        string unitDescription = u.GetDescription(unitId);

                        DateTime startDate = ((RadDatePicker)grdUnits.FooterRow.FindControl("tkrdpStartDateNew")).SelectedDate.Value;
                        DateTime endDate = ((RadDatePicker)grdUnits.FooterRow.FindControl("tkrdpEndDateNew")).SelectedDate.Value;

                        string workFunctionConcat = "";
                        string function_ = "";
                        workFunctionConcat = ((DropDownList)grdUnits.FooterRow.FindControl("ddlWorkFunctionNew")).SelectedValue;
                        if (workFunctionConcat != "(Select)")
                        {
                            string[] workFunction = workFunctionConcat.ToString().Trim().Split('.');
                            function_ = workFunction[1].Trim();
                        }

                        ProjectCostingSheetAddUnitsInformation model = new ProjectCostingSheetAddUnitsInformation(projectCostingSheetAddTDS);
                        model.Insert(0, typeOfWork, unitId, unitOfMeasurement, quantity, costCad, totalCostCad, costUsd, totalCostUsd, false, companyId, unitCode, unitDescription, startDate, endDate, workFunctionConcat, function_);

                        Session.Remove("unitsInformationDummy");
                        unitsInformation = (ProjectCostingSheetAddTDS.UnitsInformationDataTable)model.Table;
                        Session["unitsInformation"] = unitsInformation;
                        Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                        grdUnits.DataBind();

                        StepTrucksEquipmentInformationProcessGrid();
                    }
                    break;
            }
        }



        protected void grdUnits_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {           
            // Validate general data
            Page.Validate("unitsEdit");
            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();

            if (Page.IsValid)
            {                
                // Validate costs               
                projectGateway.LoadByProjectId(projectId);

                if (projectGateway.GetCountryID(projectId) == 1) //Canada
                {
                    Page.Validate("unitsCadEdit");
                }
                else
                {
                    Page.Validate("unitsUsdEdit");
                }
            }

            if (Page.IsValid)
            {
                int costingSheetId = (int)e.Keys["CostingSheetID"];
                string work_ = (string)e.Keys["Work_"];
                int unitId = (int)e.Keys["UnitID"];
                int refId = (int)e.Keys["RefID"];

                int companyId = Int32.Parse(hdfCompanyId.Value);
                string unitOfMeasurement = ((DropDownList)grdUnits.Rows[e.RowIndex].Cells[0].FindControl("ddlUnitOfMeasurementUnitsEdit")).SelectedValue;
                double quantity = double.Parse(((TextBox)grdUnits.Rows[e.RowIndex].Cells[0].FindControl("tbxQuantityEdit")).Text.Trim());

                decimal costCad = 0.0M;
                decimal totalCostCad = 0.0M;
                decimal costUsd = 0.0M;
                decimal totalCostUsd = 0.0M;

                if (projectGateway.GetCountryID(projectId) == 1) //Canada
                {
                    costCad = Decimal.Parse(((TextBox)grdUnits.Rows[e.RowIndex].Cells[0].FindControl("tbxCostCADEdit")).Text.Trim());
                    totalCostCad = (costCad * decimal.Parse(quantity.ToString()));
                    totalCostCad = Decimal.Round(totalCostCad, 2);
                }
                else
                {
                    costUsd = Decimal.Parse(((TextBox)grdUnits.Rows[e.RowIndex].Cells[0].FindControl("tbxCostUSDEdit")).Text.Trim());
                    totalCostUsd = (costUsd * decimal.Parse(quantity.ToString()));
                    totalCostUsd = Decimal.Round(totalCostUsd, 2);
                }

                LFSLive.DA.FleetManagement.Units.UnitsGateway u = new LiquiForce.LFSLive.DA.FleetManagement.Units.UnitsGateway();
                u.LoadByUnitId(unitId, companyId);
                string unitDescription = u.GetDescription(unitId);
                string unitCode = u.GetUnitCode(unitId);

                DateTime startDate = ((RadDatePicker)grdUnits.Rows[e.RowIndex].Cells[0].FindControl("tkrdpStartDateEdit")).SelectedDate.Value;
                DateTime endDate = ((RadDatePicker)grdUnits.Rows[e.RowIndex].Cells[0].FindControl("tkrdpEndDateEdit")).SelectedDate.Value;

                string workFunctionConcat = "";
                string function_ = "";
                workFunctionConcat = ((DropDownList)grdUnits.Rows[e.RowIndex].Cells[0].FindControl("ddlWorkFunctionEdit")).SelectedValue;
                if (workFunctionConcat != "(Select)")
                {
                    string[] workFunction = workFunctionConcat.ToString().Trim().Split('.');
                    function_ = workFunction[1].Trim();
                }

                // Update data
                ProjectCostingSheetAddUnitsInformation model = new ProjectCostingSheetAddUnitsInformation(projectCostingSheetAddTDS);
                model.Update(costingSheetId, work_, unitId, refId, unitOfMeasurement, quantity, costCad, totalCostCad, costUsd, totalCostUsd, false, companyId, unitCode, unitDescription, startDate, endDate, workFunctionConcat, function_);

                // Store dataset
                unitsInformation = (ProjectCostingSheetAddTDS.UnitsInformationDataTable)model.Table;
                Session["unitsInformation"] = unitsInformation;
                Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                StepTrucksEquipmentInformationProcessGrid();
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdUnits_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Units Gridview, if the gridview is edition mode
            if (grdUnits.EditIndex >= 0)
            {
                grdUnits.UpdateRow(grdUnits.EditIndex, true);
            }

            // Delete Unit Cost
            int costingSheetId = (int)e.Keys["CostingSheetID"];
            string work_ = (string)e.Keys["Work_"];
            int unitId = (int)e.Keys["UnitID"];
            int refId = (int)e.Keys["RefID"];

            ProjectCostingSheetAddUnitsInformation model = new ProjectCostingSheetAddUnitsInformation(projectCostingSheetAddTDS);
            model.Delete(costingSheetId, work_, unitId, refId);

            // Store dataset
            unitsInformation = (ProjectCostingSheetAddTDS.UnitsInformationDataTable)model.Table;
            Session["unitsInformation"] = unitsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            StepTrucksEquipmentInformationProcessGrid();
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP5 - TRUCKS EQUIPMENT INFORMATION - AUXILIAR EVENTS
        //

        protected void grdUnits_DataBound(object sender, EventArgs e)
        {
            UnitsInformationEmptyFix(grdUnits);
        }



        protected void grdUnits_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Edit items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int costingSheetId = Int32.Parse(((Label)e.Row.FindControl("lblCostingSheetIDEdit")).Text.Trim());
                int unitId = Int32.Parse(((Label)e.Row.FindControl("lblUnitIDEdit")).Text.Trim());
                int refId = Int32.Parse(((Label)e.Row.FindControl("lblRefIDEdit")).Text.Trim());
                string work_ = ((Label)e.Row.FindControl("lblWork_Edit")).Text.Trim();

                ProjectCostingSheetAddUnitsInformationGateway projectCostingSheetAddUnitsInformationGateway = new ProjectCostingSheetAddUnitsInformationGateway(projectCostingSheetAddTDS);
                string unitOfMeasurement = projectCostingSheetAddUnitsInformationGateway.GetUnitOfMeasurement(costingSheetId, work_, unitId, refId);
                ((DropDownList)e.Row.FindControl("ddlUnitOfMeasurementUnitsEdit")).SelectedValue = unitOfMeasurement;

                bool fromDatabase = projectCostingSheetAddUnitsInformationGateway.GetFromDatabase(costingSheetId, work_, unitId, refId);

                if (fromDatabase)
                {
                    ((RadDatePicker)e.Row.FindControl("tkrdpEndDateEdit")).Calendar.Enabled = false;
                    ((RadDatePicker)e.Row.FindControl("tkrdpEndDateEdit")).DateInput.ReadOnly = true;

                    ((RadDatePicker)e.Row.FindControl("tkrdpStartDateEdit")).Calendar.Enabled = false;
                    ((RadDatePicker)e.Row.FindControl("tkrdpStartDateEdit")).DateInput.ReadOnly = true;
                }

                ((RadDatePicker)e.Row.FindControl("hdfFrom")).SelectedDate = tkrdpFrom.SelectedDate;
                ((RadDatePicker)e.Row.FindControl("hdfTo")).SelectedDate = tkrdpTo.SelectedDate;
            }

            // Footer Item
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ((RadDatePicker)e.Row.FindControl("hdfFrom")).SelectedDate = tkrdpFrom.SelectedDate;
                ((RadDatePicker)e.Row.FindControl("hdfTo")).SelectedDate = tkrdpTo.SelectedDate;
            }
        }



        protected void grdUnits_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            StepTrucksEquipmentInformationProcessGrid();
        }



        protected void grdUnits_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Units Gridview, if the gridview is edition mode
            if (grdUnits.EditIndex >= 0)
            {
                grdUnits.UpdateRow(grdUnits.EditIndex, true);
            }
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // STEP5 - TRUCKS EQUIPMENT INFORMATION - METHODS
        //

        private void StepTrucksEquipmentInformationIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please verify Truck / Equipment information";

            // Load
            ProjectCostingSheetAddUnitsInformation model = new ProjectCostingSheetAddUnitsInformation(projectCostingSheetAddTDS);

            if (projectCostingSheetAddTDS.UnitsInformation.Rows.Count <= 0)
            {
                ArrayList works = new ArrayList();
                if (cbxRehabAssessmentData.Checked) works.Add("Rehab Assessment");
                if (cbxFullLengthLiningData.Checked) works.Add("Full Length");
                if (cbxPointRepairData.Checked) { works.Add("Point Lining"); works.Add("Grouting"); }
                if (cbxJunctionLiningData.Checked) works.Add("Junction Lining");
                if (cbxManholeRehabData.Checked) works.Add("MH Rehab");
                if (cbxMobilizationData.Checked) works.Add("Mobilization");
                if (cbxOtherData.Checked)
                {
                    works.Add("Other");
                    works.Add("Downtime");
                    works.Add("Office");
                    works.Add("Office / Shop");
                    works.Add("R & D");
                    works.Add("Special Projects");
                    works.Add("Subcontractor");
                    works.Add("Watermain Relining");
                    works.Add("SOTA");
                }

                model.Load(works, int.Parse(hdfProjectId.Value), tkrdpFrom.SelectedDate.Value, tkrdpTo.SelectedDate.Value, int.Parse(hdfCompanyId.Value));
            }

            // Store tables
            Session.Remove("unitsInformationDummy");
            unitsInformation = (ProjectCostingSheetAddTDS.UnitsInformationDataTable)model.Table;
            Session["unitsInformation"] = unitsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            // Validate grid columns
            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            if (projectGateway.GetCountryID(projectId) == 1) //Canada
            {
                // Units Grid
                grdUnits.Columns[11].Visible = true;
                grdUnits.Columns[12].Visible = true;
                grdUnits.Columns[13].Visible = false;
                grdUnits.Columns[14].Visible = false;

                lblUnitsTotalCosts.Text = "Total Cost (CAD) : ";
                tbxUnitsTotalCostsCAD.Visible = true;
                tbxUnitsTotalCostsUSD.Visible = false;
            }
            else
            {
                // Units Grid
                grdUnits.Columns[11].Visible = false;
                grdUnits.Columns[12].Visible = false;
                grdUnits.Columns[13].Visible = true;
                grdUnits.Columns[14].Visible = true;

                lblUnitsTotalCosts.Text = "Total Cost (USD) : ";
                tbxUnitsTotalCostsCAD.Visible = false;
                tbxUnitsTotalCostsUSD.Visible = true;
            }

            grdUnits.DataBind();
            StepTrucksEquipmentInformationProcessGrid();
        }



        private bool StepTrucksEquipmentInformationNext()
        {
            StepTrucksEquipmentInformationProcessGrid();

            // Store tables
            Session.Remove("unitsInformationDummy");
            Session["unitsInformation"] = unitsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;
            return true;
        }



        private bool StepTrucksEquipmentInformationPrevious()
        {
            return true;
        }



        private void StepTrucksEquipmentInformationProcessGrid()
        {
            decimal totalCostCadLH = 0;
            decimal totalCostUsdLH = 0;

            foreach (ProjectCostingSheetAddTDS.UnitsInformationRow row in (ProjectCostingSheetAddTDS.UnitsInformationDataTable)Session["unitsInformation"])
            {
                if (!row.Deleted)
                {
                    totalCostCadLH = totalCostCadLH + row.TotalCostCad;
                    totalCostUsdLH = totalCostUsdLH + row.TotalCostUsd;
                }
            }

            tbxUnitsTotalCostsCAD.Text = Decimal.Round(totalCostCadLH, 2).ToString();
            tbxUnitsTotalCostsUSD.Text = Decimal.Round(totalCostUsdLH, 2).ToString();
        }



        public ProjectCostingSheetAddTDS.UnitsInformationDataTable GetUnitsInformation()
        {
            unitsInformation = (ProjectCostingSheetAddTDS.UnitsInformationDataTable)Session["unitsInformationDummy"];

            if (unitsInformation == null)
            {
                unitsInformation = (ProjectCostingSheetAddTDS.UnitsInformationDataTable)Session["unitsInformation"];
            }

            return unitsInformation;
        }



        protected void UnitsInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                ProjectCostingSheetAddTDS.UnitsInformationDataTable dt = new ProjectCostingSheetAddTDS.UnitsInformationDataTable();
                dt.AddUnitsInformationRow(0, "", 0, 0, "", 0, 0, 0, 0, 0, false, 3, false, "", "", DateTime.Now, DateTime.Now, false, "", "", "", "", "", 0, 0);
                Session["unitsInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetAddTDS.UnitsInformationDataTable dt = (ProjectCostingSheetAddTDS.UnitsInformationDataTable)Session["unitsInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        public void DummyUnitsNew(int original_CostingSheetID, string original_Work_, int original_UnitID)
        {
        }



        public void DummyUnitsNew(int original_CostingSheetID, string original_Work_, int original_UnitID, int original_RefID)
        {
        }



        public void DummyUnitsNew(int CostingSheetID, string Work_)
        {
        }



        public void DummyUnitsNew(int CostingSheetID, int UnitID)
        {
        }



        public void DummyUnitsNew(int CostingSheetID)
        {
        }

        #endregion






        #region STEP6 - MATERIAL INFORMATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP6 - MATERIAL INFORMATION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP6 - MATERIAL INFORMATION - EVENTS
        //

        protected void grdMaterials_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Materials Gridview, if the gridview is edition mode
                    if (grdMaterials.EditIndex >= 0)
                    {
                        grdMaterials.UpdateRow(grdMaterials.EditIndex, true);
                    }

                    // Validate general data
                    Page.Validate("materialsNew");
                    ProjectGateway projectGateway = new ProjectGateway();
                    int projectId = Int32.Parse(hdfProjectId.Value);

                    if (Page.IsValid)
                    {
                        // Validate costs
                        projectGateway.LoadByProjectId(projectId);

                        if (projectGateway.GetCountryID(projectId) == 1) //Canada
                        {
                            Page.Validate("materialsCadNew");
                        }
                        else
                        {
                            Page.Validate("materialsUsdNew");
                        }
                    }

                    if (Page.IsValid)
                    {
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        string description = ((DropDownList)grdMaterials.FooterRow.FindControl("ddlDescriptionNew")).SelectedItem.Text;
                        int materialId = Int32.Parse(((DropDownList)grdMaterials.FooterRow.FindControl("ddlDescriptionNew")).SelectedValue);
                        string unitOfMeasurement = ((DropDownList)grdMaterials.FooterRow.FindControl("ddlUnitOfMeasurementMaterialsNew")).SelectedValue;
                        double quantity = double.Parse(((TextBox)grdMaterials.FooterRow.FindControl("tbxQuantityNew")).Text.Trim());

                        decimal costCad = 0.0M;
                        decimal totalCostCad = 0.0M;
                        decimal costUsd = 0.0M;
                        decimal totalCostUsd = 0.0M;

                        if (projectGateway.GetCountryID(projectId) == 1) //Canada
                        {
                            costCad = Decimal.Parse(((TextBox)grdMaterials.FooterRow.FindControl("tbxCostCADNew")).Text.Trim());
                            totalCostCad = (costCad * decimal.Parse(quantity.ToString()));
                            totalCostCad = Decimal.Round(totalCostCad, 2);
                        }
                        else
                        {
                            costUsd = Decimal.Parse(((TextBox)grdMaterials.FooterRow.FindControl("tbxCostUSDNew")).Text.Trim());
                            totalCostUsd = (costUsd * decimal.Parse(quantity.ToString()));
                            totalCostUsd = Decimal.Round(totalCostUsd, 2);
                        }

                        LFSLive.DA.Resources.Materials.MaterialsGateway m = new LiquiForce.LFSLive.DA.Resources.Materials.MaterialsGateway();
                        m.LoadByMaterialId(materialId, companyId);
                        string process = m.GetType(materialId);

                        DateTime startDate = ((RadDatePicker)grdMaterials.FooterRow.FindControl("tkrdpStartDateNew")).SelectedDate.Value;
                        DateTime endDate = ((RadDatePicker)grdMaterials.FooterRow.FindControl("tkrdpEndDateNew")).SelectedDate.Value;

                        string workFunctionConcat = "Full Length . Install";
                        string function_ = "Install";

                        ProjectCostingSheetAddMaterialsInformation model = new ProjectCostingSheetAddMaterialsInformation(projectCostingSheetAddTDS);
                        model.Insert(0, materialId, unitOfMeasurement, quantity, costCad, totalCostCad, costUsd, totalCostUsd, false, companyId, process, description, startDate, endDate, function_, workFunctionConcat);

                        // Store tables
                        Session.Remove("materialsInformationDummy");
                        materialsInformation = (ProjectCostingSheetAddTDS.MaterialsInformationDataTable)model.Table;
                        Session["materialsInformation"] = materialsInformation;
                        Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                        grdMaterials.DataBind();

                        StepMaterialInformationProcessGrid();
                    }
                    break;
            }
        }



        protected void grdMaterials_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Edit items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int costingSheetId = Int32.Parse(((Label)e.Row.FindControl("lblCostingSheetIDEdit")).Text.Trim());
                int materialId = Int32.Parse(((Label)e.Row.FindControl("lblMaterialIDEdit")).Text.Trim());
                int refId = Int32.Parse(((Label)e.Row.FindControl("lblRefIDEdit")).Text.Trim());

                ProjectCostingSheetAddMaterialsInformationGateway projectCostingSheetAddMaterialsInformationGateway = new ProjectCostingSheetAddMaterialsInformationGateway(projectCostingSheetAddTDS);
                string unitOfMeasurement = projectCostingSheetAddMaterialsInformationGateway.GetUnitOfMeasurement(costingSheetId, materialId, refId);
                ((DropDownList)e.Row.FindControl("ddlUnitOfMeasurementMaterialsEdit")).SelectedValue = unitOfMeasurement;

                bool fromDatabase = projectCostingSheetAddMaterialsInformationGateway.GetFromDatabase(costingSheetId, materialId, refId);

                if (fromDatabase)
                {
                    ((RadDatePicker)e.Row.FindControl("tkrdpEndDateEdit")).Calendar.Enabled = false;
                    ((RadDatePicker)e.Row.FindControl("tkrdpEndDateEdit")).DateInput.ReadOnly = true;

                    ((RadDatePicker)e.Row.FindControl("tkrdpStartDateEdit")).Calendar.Enabled = false;
                    ((RadDatePicker)e.Row.FindControl("tkrdpStartDateEdit")).DateInput.ReadOnly = true;
                }

                ((RadDatePicker)e.Row.FindControl("hdfFrom")).SelectedDate = tkrdpFrom.SelectedDate;
                ((RadDatePicker)e.Row.FindControl("hdfTo")).SelectedDate = tkrdpTo.SelectedDate;
            }

            // Footer Item
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ((RadDatePicker)e.Row.FindControl("hdfFrom")).SelectedDate = tkrdpFrom.SelectedDate;
                ((RadDatePicker)e.Row.FindControl("hdfTo")).SelectedDate = tkrdpTo.SelectedDate;
            }
        }



        protected void grdMaterials_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Validate general data
            Page.Validate("materialsEdit");
            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();

            if (Page.IsValid)
            {
                // Validate costs            
                projectGateway.LoadByProjectId(projectId);

                if (projectGateway.GetCountryID(projectId) == 1) //Canada
                {
                    Page.Validate("materialsCadEdit");
                }
                else
                {
                    Page.Validate("materialsUsdEdit");
                }
            }

            if (Page.IsValid)
            {
                int costingSheetId = (int)e.Keys["CostingSheetID"];
                int materialId = (int)e.Keys["MaterialID"];
                int refId = (int)e.Keys["RefID"];
                int companyId = Int32.Parse(hdfCompanyId.Value);

                string unitOfMeasurement = ((DropDownList)grdMaterials.Rows[e.RowIndex].Cells[0].FindControl("ddlUnitOfMeasurementMaterialsEdit")).SelectedValue;
                double quantity = double.Parse(((TextBox)grdMaterials.Rows[e.RowIndex].Cells[0].FindControl("tbxQuantityEdit")).Text.Trim());

                decimal costCad = 0.0M;
                decimal totalCostCad = 0.0M;
                decimal costUsd = 0.0M;
                decimal totalCostUsd = 0.0M;

                if (projectGateway.GetCountryID(projectId) == 1) //Canada
                {
                    costCad = Decimal.Parse(((TextBox)grdMaterials.Rows[e.RowIndex].Cells[0].FindControl("tbxCostCADEdit")).Text.Trim());
                    totalCostCad = (costCad * decimal.Parse(quantity.ToString()));
                    totalCostCad = Decimal.Round(totalCostCad, 2);
                }
                else
                {
                    costUsd = Decimal.Parse(((TextBox)grdMaterials.Rows[e.RowIndex].Cells[0].FindControl("tbxCostUSDEdit")).Text.Trim());
                    totalCostUsd = (costUsd * decimal.Parse(quantity.ToString()));
                    totalCostUsd = Decimal.Round(totalCostUsd, 2);
                }

                LFSLive.DA.Resources.Materials.MaterialsGateway m = new LiquiForce.LFSLive.DA.Resources.Materials.MaterialsGateway();
                m.LoadByMaterialId(materialId, companyId);
                string process = m.GetType(materialId);
                string description = m.GetDescription(materialId);

                DateTime startDate = ((RadDatePicker)grdMaterials.Rows[e.RowIndex].Cells[0].FindControl("tkrdpStartDateEdit")).SelectedDate.Value;
                DateTime endDate = ((RadDatePicker)grdMaterials.Rows[e.RowIndex].Cells[0].FindControl("tkrdpEndDateEdit")).SelectedDate.Value;

                string workFunctionConcat = "Full Length . Install";
                string function_ = "Install";

                // Update data
                ProjectCostingSheetAddMaterialsInformation model = new ProjectCostingSheetAddMaterialsInformation(projectCostingSheetAddTDS);
                model.Update(costingSheetId, materialId, refId, unitOfMeasurement, quantity, costCad, totalCostCad, costUsd, totalCostUsd, false, companyId, process, description, startDate, endDate, function_, workFunctionConcat);

                // Store tables
                Session.Remove("materialsInformationDummy");
                materialsInformation = (ProjectCostingSheetAddTDS.MaterialsInformationDataTable)model.Table;
                Session["materialsInformation"] = materialsInformation;
                Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                StepMaterialInformationProcessGrid();
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdMaterials_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Materials Gridview, if the gridview is edition mode
            if (grdMaterials.EditIndex >= 0)
            {
                grdMaterials.UpdateRow(grdMaterials.EditIndex, true);
            }

            // Delete material
            int costingSheetId = (int)e.Keys["CostingSheetID"];
            int materialId = (int)e.Keys["MaterialID"];
            int refId = (int)e.Keys["RefID"];

            ProjectCostingSheetAddMaterialsInformation model = new ProjectCostingSheetAddMaterialsInformation(projectCostingSheetAddTDS);
            model.Delete(costingSheetId, materialId, refId);

            // Store tables
            Session.Remove("materialsInformationDummy");
            materialsInformation = (ProjectCostingSheetAddTDS.MaterialsInformationDataTable)model.Table;
            Session["materialsInformation"] = materialsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            StepMaterialInformationProcessGrid();
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP6 - MATERIAL INFORMATION -  AUXILIAR EVENTS
        //

        protected void grdMaterials_DataBound(object sender, EventArgs e)
        {
            MaterialsInformationEmptyFix(grdMaterials);
        }



        protected void grdMaterials_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            StepMaterialInformationProcessGrid();
        }



        protected void grdMaterials_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Materials Gridview, if the gridview is edition mode
            if (grdMaterials.EditIndex >= 0)
            {
                grdMaterials.UpdateRow(grdMaterials.EditIndex, true);
            }
        }

        


              

        // ////////////////////////////////////////////////////////////////////////
        // STEP6 - MATERIAL INFORMATION - METHODS
        //

        private void StepMaterialInformationIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please verify Material information";

            // Load
            ProjectCostingSheetAddMaterialsInformation model = new ProjectCostingSheetAddMaterialsInformation(projectCostingSheetAddTDS);

            if (projectCostingSheetAddTDS.MaterialsInformation.Rows.Count <= 0)
            {
                ArrayList works = new ArrayList();
                if (cbxFullLengthLiningData.Checked) works.Add("Full Length Lining");
                if (cbxManholeRehabData.Checked) works.Add("Manhole Rehab");
                if (cbxPointRepairData.Checked) works.Add("Point Repairs");
                if (cbxJunctionLiningData.Checked) works.Add("Junction Lining");

                model.Load(works, int.Parse(hdfProjectId.Value), tkrdpFrom.SelectedDate.Value, tkrdpTo.SelectedDate.Value, int.Parse(hdfCompanyId.Value));
            }

            // Store tables
            Session.Remove("materialsInformationDummy");
            materialsInformation = (ProjectCostingSheetAddTDS.MaterialsInformationDataTable)model.Table;
            Session["materialsInformation"] = materialsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            // Validate grid columns
            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            if (projectGateway.GetCountryID(projectId) == 1) //Canada
            {
                // Materials grid
                grdMaterials.Columns[9].Visible = true;
                grdMaterials.Columns[10].Visible = true;
                grdMaterials.Columns[11].Visible = false;
                grdMaterials.Columns[12].Visible = false;
                
                lblMaterialsTotalCosts.Text = "Total Cost (CAD) : ";
                tbxMaterialsTotalCostsCAD.Visible = true;
                tbxMaterialsTotalCostsUSD.Visible = false;
            }
            else
            {
                // Materials grid
                grdMaterials.Columns[9].Visible = false;
                grdMaterials.Columns[10].Visible = false;
                grdMaterials.Columns[11].Visible = true;
                grdMaterials.Columns[12].Visible = true;

                lblMaterialsTotalCosts.Text = "Total Cost (USD) : ";
                tbxMaterialsTotalCostsCAD.Visible = false;
                tbxMaterialsTotalCostsUSD.Visible = true;
            }

            grdMaterials.DataBind();
            StepMaterialInformationProcessGrid();
        }



        private bool StepMaterialInformationNext()
        {
            StepMaterialInformationProcessGrid();

            // Store tables
            Session.Remove("materialsInformationDummy");
            Session["materialsInformation"] = materialsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            return true;
        }



        private bool StepMaterialInformationPrevious()
        {
            return true;
        }



        private void StepMaterialInformationProcessGrid()
        {
            decimal totalCostCadLH = 0;
            decimal totalCostUsdLH = 0;

            foreach (ProjectCostingSheetAddTDS.MaterialsInformationRow row in (ProjectCostingSheetAddTDS.MaterialsInformationDataTable)Session["materialsInformation"])
            {
                if (!row.Deleted)
                {
                    totalCostCadLH = totalCostCadLH + row.TotalCostCad;
                    totalCostUsdLH = totalCostUsdLH + row.TotalCostUsd;
                }
            }

            tbxMaterialsTotalCostsCAD.Text = Decimal.Round(totalCostCadLH, 2).ToString();
            tbxMaterialsTotalCostsUSD.Text = Decimal.Round(totalCostUsdLH, 2).ToString();
        }        
        


        protected void MaterialsInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                ProjectCostingSheetAddTDS.MaterialsInformationDataTable dt = new ProjectCostingSheetAddTDS.MaterialsInformationDataTable();
                dt.AddMaterialsInformationRow(0, 0, 0, 0, 0, 0, 0, 0, false, 3, false, "", "", "", DateTime.Now, DateTime.Now, false, "", "", "", "", "", 0, 0);
                Session["materialsInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetAddTDS.MaterialsInformationDataTable dt = (ProjectCostingSheetAddTDS.MaterialsInformationDataTable)Session["materialsInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        public ProjectCostingSheetAddTDS.MaterialsInformationDataTable GetMaterialsInformation()
        {
            materialsInformation = (ProjectCostingSheetAddTDS.MaterialsInformationDataTable)Session["materialsInformationDummy"];

            if (materialsInformation == null)
            {
                materialsInformation = (ProjectCostingSheetAddTDS.MaterialsInformationDataTable)Session["materialsInformation"];
            }

            return materialsInformation;
        }



        public void DummyMaterialsNew(int original_CostingSheetID, int original_MaterialID, int original_RefID)
        {
        }



        public void DummyMaterialsNew(int CostingSheetID, int MaterialID)
        {
        }



        public void DummyMaterialsNew(int CostingSheetID)
        {
        }

        #endregion






        #region STEP7 - SUBCONTRACTOR INFORMATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP7 - SUBCONTRACTOR INFORMATION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP7 - SUBCONTRACTOR INFORMATION - EVENTS
        //

        protected void grdSubcontractors_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Subcontractors Gridview, if the gridview is edition mode
                    if (grdSubcontractors.EditIndex >= 0)
                    {
                        grdSubcontractors.UpdateRow(grdSubcontractors.EditIndex, true);
                    }

                    // Validate general data
                    Page.Validate("subcontractorsNew");
                    int projectId = Int32.Parse(hdfProjectId.Value);
                    ProjectGateway projectGateway = new ProjectGateway();

                    if (Page.IsValid)
                    {
                        // Validate costs                        
                        projectGateway.LoadByProjectId(projectId);

                        if (projectGateway.GetCountryID(projectId) == 1) //Canada
                        {
                            Page.Validate("subcontractorsCadNew");
                        }
                        else
                        {
                            Page.Validate("subcontractorsUsdNew");
                        }
                    }

                    if (Page.IsValid)
                    {
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        int subcontractorId = Int32.Parse(((DropDownList)grdSubcontractors.FooterRow.FindControl("ddlSubcontractorNew")).SelectedValue);
                        string unitOfMeasurement = ((DropDownList)grdSubcontractors.FooterRow.FindControl("ddlUnitOfMeasurementSubcontractorsNew")).SelectedValue;
                        string subcontractor = ((DropDownList)grdSubcontractors.FooterRow.FindControl("ddlSubcontractorNew")).SelectedItem.Text;
                        double quantity = double.Parse(((TextBox)grdSubcontractors.FooterRow.FindControl("tbxQuantityNew")).Text.Trim());
                        string comment = ""; if (((TextBox)grdSubcontractors.FooterRow.FindControl("tbxCommentNew")).Text.Trim() != "") comment = ((TextBox)grdSubcontractors.FooterRow.FindControl("tbxCommentNew")).Text.Trim();

                        decimal costCad = 0.0M;
                        decimal totalCostCad = 0.0M;
                        decimal costUsd = 0.0M;
                        decimal totalCostUsd = 0.0M;

                        if (projectGateway.GetCountryID(projectId) == 1) //Canada
                        {
                            costCad = Decimal.Parse(((TextBox)grdSubcontractors.FooterRow.FindControl("tbxCostCADNew")).Text.Trim());
                            totalCostCad = (costCad * decimal.Parse(quantity.ToString()));
                            totalCostCad = Decimal.Round(totalCostCad, 2);
                        }
                        else
                        {
                            costUsd = Decimal.Parse(((TextBox)grdSubcontractors.FooterRow.FindControl("tbxCostUSDNew")).Text.Trim());
                            totalCostUsd = (costUsd * decimal.Parse(quantity.ToString()));
                            totalCostUsd = Decimal.Round(totalCostUsd, 2);
                        }

                        DateTime startDate = ((RadDatePicker)grdSubcontractors.FooterRow.FindControl("tkrdpStartDateNew")).SelectedDate.Value;
                        DateTime endDate = ((RadDatePicker)grdSubcontractors.FooterRow.FindControl("tkrdpEndDateNew")).SelectedDate.Value;

                        ProjectCostingSheetAddSubcontractorsInformation model = new ProjectCostingSheetAddSubcontractorsInformation(projectCostingSheetAddTDS);
                        model.Insert(0, subcontractorId, unitOfMeasurement, quantity, costCad, totalCostCad, costUsd, totalCostUsd, comment, false, companyId, startDate, endDate, subcontractor);

                        Session.Remove("subcontractorsInformationDummy");
                        subcontractorsInformation = (ProjectCostingSheetAddTDS.SubcontractorsInformationDataTable)model.Table;
                        Session["subcontractorsInformation"] = subcontractorsInformation;
                        Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                        grdSubcontractors.DataBind();

                        StepSubcontractorsInformationProcessGrid();
                    }
                    break;
            }
        }



        protected void grdSubcontractors_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Validate general data
            Page.Validate("subcontractorsEdit");
            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();

            if (Page.IsValid)
            {
                // Validate costs               
                projectGateway.LoadByProjectId(projectId);

                if (projectGateway.GetCountryID(projectId) == 1) //Canada
                {
                    Page.Validate("subcontractorsCadEdit");
                }
                else
                {
                    Page.Validate("subcontractorsUsdEdit");
                }
            }

            if (Page.IsValid)
            {
                int costingSheetId = (int)e.Keys["CostingSheetID"];
                int subcontractorId = (int)e.Keys["SubcontractorID"];
                int refId = (int)e.Keys["RefID"];

                int companyId = Int32.Parse(hdfCompanyId.Value);
                string unitOfMeasurement = ((DropDownList)grdSubcontractors.Rows[e.RowIndex].Cells[0].FindControl("ddlUnitOfMeasurementSubcontractorsEdit")).SelectedValue;
                string subcontractor = ((TextBox)grdSubcontractors.Rows[e.RowIndex].Cells[0].FindControl("tbxSubcontractorEdit")).Text;
                string comment = ((TextBox)grdSubcontractors.Rows[e.RowIndex].Cells[0].FindControl("tbxCommentEdit")).Text;
                double quantity = double.Parse(((TextBox)grdSubcontractors.Rows[e.RowIndex].Cells[0].FindControl("tbxQuantityEdit")).Text.Trim());

                decimal costCad = 0.0M;
                decimal totalCostCad = 0.0M;
                decimal costUsd = 0.0M;
                decimal totalCostUsd = 0.0M;

                if (projectGateway.GetCountryID(projectId) == 1) //Canada
                {
                    costCad = Decimal.Parse(((TextBox)grdSubcontractors.Rows[e.RowIndex].Cells[0].FindControl("tbxCostCADEdit")).Text.Trim());
                    totalCostCad = (costCad * decimal.Parse(quantity.ToString()));
                    totalCostCad = Decimal.Round(totalCostCad, 2);
                }
                else
                {
                    costUsd = Decimal.Parse(((TextBox)grdSubcontractors.Rows[e.RowIndex].Cells[0].FindControl("tbxCostUSDEdit")).Text.Trim());
                    totalCostUsd = (costUsd * decimal.Parse(quantity.ToString()));
                    totalCostUsd = Decimal.Round(totalCostUsd, 2);
                }

                DateTime startDate = ((RadDatePicker)grdSubcontractors.Rows[e.RowIndex].Cells[0].FindControl("tkrdpStartDateEdit")).SelectedDate.Value;
                DateTime endDate = ((RadDatePicker)grdSubcontractors.Rows[e.RowIndex].Cells[0].FindControl("tkrdpEndDateEdit")).SelectedDate.Value;

                // Update data
                ProjectCostingSheetAddSubcontractorsInformation model = new ProjectCostingSheetAddSubcontractorsInformation(projectCostingSheetAddTDS);
                model.Update(costingSheetId, subcontractorId, refId, unitOfMeasurement, quantity, costCad, totalCostCad, costUsd, totalCostUsd, false, companyId, comment, startDate, endDate);

                // Store dataset
                subcontractorsInformation = (ProjectCostingSheetAddTDS.SubcontractorsInformationDataTable)model.Table;
                Session["subcontractorsInformation"] = subcontractorsInformation;
                Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                StepSubcontractorsInformationProcessGrid();
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdSubcontractors_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Subcontractors Gridview, if the gridview is edition mode
            if (grdSubcontractors.EditIndex >= 0)
            {
                grdSubcontractors.UpdateRow(grdSubcontractors.EditIndex, true);
            }

            // Delete subcontractor
            int costingSheetId = (int)e.Keys["CostingSheetID"];
            int subcontractorId = (int)e.Keys["SubcontractorID"];
            int refId = (int)e.Keys["RefID"];

            ProjectCostingSheetAddSubcontractorsInformation model = new ProjectCostingSheetAddSubcontractorsInformation(projectCostingSheetAddTDS);
            model.Delete(costingSheetId, subcontractorId, refId);

            // Store dataset
            subcontractorsInformation = (ProjectCostingSheetAddTDS.SubcontractorsInformationDataTable)model.Table;
            Session["subcontractorsInformation"] = subcontractorsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            StepSubcontractorsInformationProcessGrid();
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP7 - SUBCONTRACTOR INFORMATION - AUXILIAR EVENTS
        //

        protected void grdSubcontractors_DataBound(object sender, EventArgs e)
        {
            SubcontractorsInformationEmptyFix(grdSubcontractors);
        }



        protected void grdSubcontractors_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            StepSubcontractorsInformationProcessGrid();
        }



        protected void grdSubcontractors_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Subcontractors Gridview, if the gridview is edition mode
            if (grdSubcontractors.EditIndex >= 0)
            {
                grdSubcontractors.UpdateRow(grdSubcontractors.EditIndex, true);
            }
        }





        
        // ////////////////////////////////////////////////////////////////////////
        // STEP7 - SUBCONTRACTOR INFORMATION - METHODS
        //

        private void StepSubcontractorsInformationIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please verify Subcontractors information";

            // Load
            ProjectCostingSheetAddSubcontractorsInformation model = new ProjectCostingSheetAddSubcontractorsInformation(projectCostingSheetAddTDS);

            if (projectCostingSheetAddTDS.SubcontractorsInformation.Rows.Count <= 0)
            {
                model.Load(int.Parse(hdfProjectId.Value), tkrdpFrom.SelectedDate.Value, tkrdpTo.SelectedDate.Value, int.Parse(hdfCompanyId.Value));
            }

            // Store tables
            Session.Remove("subcontractorsInformationDummy");
            subcontractorsInformation = (ProjectCostingSheetAddTDS.SubcontractorsInformationDataTable)model.Table;
            Session["subcontractorsInformation"] = subcontractorsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            // Validate grid columns
            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            if (projectGateway.GetCountryID(projectId) == 1) //Canada
            {
                // Subcontractors Grid
                grdSubcontractors.Columns[8].Visible = true;
                grdSubcontractors.Columns[9].Visible = true;
                grdSubcontractors.Columns[10].Visible = false;
                grdSubcontractors.Columns[11].Visible = false;

                lblSubcontractorsTotalCosts.Text = "Total Cost (CAD) : ";
                tbxSubcontractorsTotalCostsCAD.Visible = true;
                tbxSubcontractorsTotalCostsUSD.Visible = false;
            }
            else
            {
                // Subcontractors Grid
                grdSubcontractors.Columns[8].Visible = false;
                grdSubcontractors.Columns[9].Visible = false;
                grdSubcontractors.Columns[10].Visible = true;
                grdSubcontractors.Columns[11].Visible = true;

                lblSubcontractorsTotalCosts.Text = "Total Cost (USD) : ";
                tbxSubcontractorsTotalCostsCAD.Visible = false;
                tbxSubcontractorsTotalCostsUSD.Visible = true;
            }

            grdSubcontractors.DataBind();
            StepSubcontractorsInformationProcessGrid();
        }



        private bool StepSubcontractorsInformationNext()
        {
            StepSubcontractorsInformationProcessGrid();

            // Store tables
            Session.Remove("subcontractorsInformationDummy");
            Session["subcontractorsInformation"] = subcontractorsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;
            return true;
        }



        private bool StepSubcontractorsInformationPrevious()
        {
            return true;
        }



        private void StepSubcontractorsInformationProcessGrid()
        {
            decimal totalCostCadLH = 0;
            decimal totalCostUsdLH = 0;

            foreach (ProjectCostingSheetAddTDS.SubcontractorsInformationRow row in (ProjectCostingSheetAddTDS.SubcontractorsInformationDataTable)Session["subcontractorsInformation"])
            {
                if (!row.Deleted)
                {
                    totalCostCadLH = totalCostCadLH + row.TotalCostCad;
                    totalCostUsdLH = totalCostUsdLH + row.TotalCostUsd;
                }
            }

            tbxSubcontractorsTotalCostsCAD.Text = Decimal.Round(totalCostCadLH, 2).ToString();
            tbxSubcontractorsTotalCostsUSD.Text = Decimal.Round(totalCostUsdLH, 2).ToString();
        }



        public ProjectCostingSheetAddTDS.SubcontractorsInformationDataTable GetSubcontractorsInformation()
        {
            subcontractorsInformation = (ProjectCostingSheetAddTDS.SubcontractorsInformationDataTable)Session["subcontractorsInformationDummy"];

            if (subcontractorsInformation == null)
            {
                subcontractorsInformation = (ProjectCostingSheetAddTDS.SubcontractorsInformationDataTable)Session["subcontractorsInformation"];
            }

            return subcontractorsInformation;
        }



        protected void SubcontractorsInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                ProjectCostingSheetAddTDS.SubcontractorsInformationDataTable dt = new ProjectCostingSheetAddTDS.SubcontractorsInformationDataTable();
                dt.AddSubcontractorsInformationRow(0, 0, 0, 0, 0, 0, 0, 0, false, 3, false, "", "Hour", DateTime.Now, DateTime.Now, false, "", "", "", "", 0, 0);
                Session["subcontractorsInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetAddTDS.SubcontractorsInformationDataTable dt = (ProjectCostingSheetAddTDS.SubcontractorsInformationDataTable)Session["subcontractorsInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        public void DummySubcontractorsNew(int original_CostingSheetID, int original_SubcontractorID, int original_RefID)
        {
        }



        public void DummySubcontractorsNew(int CostingSheetID, int SubcontractorID)
        {
        }



        public void DummySubcontractorsNew(int CostingSheetID)
        {
        }

        #endregion






        #region STEP8 - OTHER COST INFORMATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP8 - OTHER COST INFORMATION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP8 - OTHER COST INFORMATION - EVENTS
        //

        protected void grdOtherCosts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Other costs Gridview, if the gridview is edition mode
                    if (grdOtherCosts.EditIndex >= 0)
                    {
                        grdOtherCosts.UpdateRow(grdOtherCosts.EditIndex, true);
                    }

                    // Validate general data
                    Page.Validate("otherCostsNew");

                    // Validate costs
                    int projectId = Int32.Parse(hdfProjectId.Value);
                    ProjectGateway projectGateway = new ProjectGateway();

                    if (Page.IsValid)
                    {
                        projectGateway.LoadByProjectId(projectId);

                        if (projectGateway.GetCountryID(projectId) == 1) //Canada
                        {
                            Page.Validate("otherCostsCadNew");
                        }
                        else
                        {
                            Page.Validate("otherCostsUsdNew");
                        }
                    }

                    if (Page.IsValid)
                    {
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        string description = ((TextBox)grdOtherCosts.FooterRow.FindControl("tbxDescriptionNew")).Text.Trim();
                        string unitOfMeasurement = ((DropDownList)grdOtherCosts.FooterRow.FindControl("ddlUnitOfMeasurementOthersNew")).SelectedValue;
                        double quantity = double.Parse(((TextBox)grdOtherCosts.FooterRow.FindControl("tbxQuantityNew")).Text.Trim());

                        decimal costCad = 0.0M;
                        decimal totalCostCad = 0.0M;
                        decimal costUsd = 0.0M;
                        decimal totalCostUsd = 0.0M;

                        if (projectGateway.GetCountryID(projectId) == 1) //Canada
                        {
                            costCad = Decimal.Parse(((TextBox)grdOtherCosts.FooterRow.FindControl("tbxCostCADNew")).Text.Trim());
                            totalCostCad = (costCad * decimal.Parse(quantity.ToString()));
                            totalCostCad = Decimal.Round(totalCostCad, 2);
                        }
                        else
                        {
                            costUsd = Decimal.Parse(((TextBox)grdOtherCosts.FooterRow.FindControl("tbxCostUSDNew")).Text.Trim());
                            totalCostUsd = (costUsd * decimal.Parse(quantity.ToString()));
                            totalCostUsd = Decimal.Round(totalCostUsd, 2);
                        }

                        string workFunctionConcat = "";
                        string work_ = "";
                        string function_ = "";
                        workFunctionConcat = ((DropDownList)grdOtherCosts.FooterRow.FindControl("ddlWorkFunctionNew")).SelectedValue;
                        if (workFunctionConcat != "(Select)")
                        {
                            string[] workFunction = workFunctionConcat.ToString().Trim().Split('.');
                            work_ = workFunction[0].Trim();
                            function_ = workFunction[1].Trim();
                        }

                        DateTime startDate = ((RadDatePicker)grdOtherCosts.FooterRow.FindControl("tkrdpStartDateNew")).SelectedDate.Value;
                        DateTime endDate = ((RadDatePicker)grdOtherCosts.FooterRow.FindControl("tkrdpEndDateNew")).SelectedDate.Value;

                        ProjectCostingSheetAddOtherCostsInformation model = new ProjectCostingSheetAddOtherCostsInformation(projectCostingSheetAddTDS);
                        model.Insert(0, work_, function_, description, unitOfMeasurement, quantity, costCad, totalCostCad, costUsd, totalCostUsd, false, companyId, workFunctionConcat, startDate, endDate);

                        Session.Remove("otherCostsInformationDummy");
                        otherCostsInformation = (ProjectCostingSheetAddTDS.OtherCostsInformationDataTable)model.Table;
                        Session["otherCostsInformation"] = otherCostsInformation;
                        Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                        grdOtherCosts.DataBind();

                        StepOtherCostsInformationProcessGrid();
                    }
                    break;
            }
        }



        protected void grdOtherCosts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Validate general data
            Page.Validate("otherCostsEdit");

            // Validate costs
            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();

            if (Page.IsValid)
            {
                projectGateway.LoadByProjectId(projectId);

                if (projectGateway.GetCountryID(projectId) == 1) //Canada
                {
                    Page.Validate("otherCostsCadEdit");
                }
                else
                {
                    Page.Validate("otherCostsUsdEdit");
                }
            }

            if (Page.IsValid)
            {
                int costingSheetId = (int)e.Keys["CostingSheetID"];
                int refId = (int)e.Keys["RefID"];
                int companyId = Int32.Parse(hdfCompanyId.Value);

                string description = ((TextBox)grdOtherCosts.Rows[e.RowIndex].Cells[0].FindControl("tbxDescriptionEdit")).Text.Trim();
                string unitOfMeasurement = ((DropDownList)grdOtherCosts.Rows[e.RowIndex].Cells[0].FindControl("ddlUnitOfMeasurementOthersEdit")).SelectedValue;
                double quantity = double.Parse(((TextBox)grdOtherCosts.Rows[e.RowIndex].Cells[0].FindControl("tbxQuantityEdit")).Text.Trim());

                decimal costCad = 0.0M;
                decimal totalCostCad = 0.0M;
                decimal costUsd = 0.0M;
                decimal totalCostUsd = 0.0M;

                if (projectGateway.GetCountryID(projectId) == 1) //Canada
                {
                    costCad = Decimal.Parse(((TextBox)grdOtherCosts.Rows[e.RowIndex].Cells[0].FindControl("tbxCostCADEdit")).Text.Trim());
                    totalCostCad = (costCad * decimal.Parse(quantity.ToString()));
                    totalCostCad = Decimal.Round(totalCostCad, 2);
                }
                else
                {
                    costUsd = Decimal.Parse(((TextBox)grdOtherCosts.Rows[e.RowIndex].Cells[0].FindControl("tbxCostUSDEdit")).Text.Trim());
                    totalCostUsd = (costUsd * decimal.Parse(quantity.ToString()));
                    totalCostUsd = Decimal.Round(totalCostUsd, 2);
                }

                string workFunctionConcat = "";
                string work_ = "";
                string function_ = "";
                workFunctionConcat = ((DropDownList)grdOtherCosts.Rows[e.RowIndex].Cells[0].FindControl("ddlWorkFunctionEdit")).SelectedValue;
                if (workFunctionConcat != "(Select)")
                {
                    string[] workFunction = workFunctionConcat.ToString().Trim().Split('.');
                    work_ = workFunction[0].Trim();
                    function_ = workFunction[1].Trim();
                }

                DateTime startDate = ((RadDatePicker)grdOtherCosts.Rows[e.RowIndex].Cells[0].FindControl("tkrdpStartDateEdit")).SelectedDate.Value;
                DateTime endDate = ((RadDatePicker)grdOtherCosts.Rows[e.RowIndex].Cells[0].FindControl("tkrdpEndDateEdit")).SelectedDate.Value;

                // Update data
                ProjectCostingSheetAddOtherCostsInformation model = new ProjectCostingSheetAddOtherCostsInformation(projectCostingSheetAddTDS);
                model.Update(costingSheetId, refId, work_, function_, description, unitOfMeasurement, quantity, costCad, totalCostCad, costUsd, totalCostUsd, false, companyId, workFunctionConcat, startDate, endDate);

                otherCostsInformation = (ProjectCostingSheetAddTDS.OtherCostsInformationDataTable)model.Table;
                Session["otherCostsInformation"] = otherCostsInformation;
                Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                StepOtherCostsInformationProcessGrid();
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdOtherCosts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Other costs Gridview, if the gridview is edition mode
            if (grdOtherCosts.EditIndex >= 0)
            {
                grdOtherCosts.UpdateRow(grdOtherCosts.EditIndex, true);
            }

            // Delete Other Cost
            int costingSheetId = (int)e.Keys["CostingSheetID"];
            int refId = (int)e.Keys["RefID"];

            ProjectCostingSheetAddOtherCostsInformation model = new ProjectCostingSheetAddOtherCostsInformation(projectCostingSheetAddTDS);
            model.Delete(costingSheetId, refId);

            // Store dataset
            otherCostsInformation = (ProjectCostingSheetAddTDS.OtherCostsInformationDataTable)model.Table;
            Session["otherCostsInformation"] = otherCostsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            StepOtherCostsInformationProcessGrid();
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP8 - OTHER COST INFORMATION - AUXILIAR EVENTS
        //

        protected void grdOtherCosts_DataBound(object sender, EventArgs e)
        {
            OtherCostsInformationEmptyFix(grdOtherCosts);
        }



        protected void grdOtherCosts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            StepOtherCostsInformationProcessGrid();
        }



        protected void grdOtherCosts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Other costs Gridview, if the gridview is edition mode
            if (grdOtherCosts.EditIndex >= 0)
            {
                grdOtherCosts.UpdateRow(grdOtherCosts.EditIndex, true);
            }
        }

        
        
        protected void grdOtherCosts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Edit items
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Edit) || (e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate))))
            {
                int costingSheetId = Int32.Parse(((Label)e.Row.FindControl("lblCostingSheetIDEdit")).Text.Trim());
                int refId = Int32.Parse(((Label)e.Row.FindControl("lblRefIDEdit")).Text.Trim());

                ProjectCostingSheetAddOtherCostsInformationGateway projectCostingSheetAddOtherCostsInformationGateway = new ProjectCostingSheetAddOtherCostsInformationGateway(projectCostingSheetAddTDS);
                string unitOfMeasurement = projectCostingSheetAddOtherCostsInformationGateway.GetUnitOfMeasurement(costingSheetId, refId);
                ((DropDownList)e.Row.FindControl("ddlUnitOfMeasurementOthersEdit")).SelectedValue = unitOfMeasurement;

                ((RadDatePicker)e.Row.FindControl("hdfFrom")).SelectedDate = tkrdpFrom.SelectedDate;
                ((RadDatePicker)e.Row.FindControl("hdfTo")).SelectedDate = tkrdpTo.SelectedDate;
            }

            // Footer Item
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                ((RadDatePicker)e.Row.FindControl("hdfFrom")).SelectedDate = tkrdpFrom.SelectedDate;
                ((RadDatePicker)e.Row.FindControl("hdfTo")).SelectedDate = tkrdpTo.SelectedDate;
            }
        }



        

        
        // ////////////////////////////////////////////////////////////////////////
        // STEP8 - OTHER COST INFORMATION - METHODS
        //

        private void StepOtherCostInformationIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please provide other costs to cost sheet";

            // Load
            ProjectCostingSheetAddOtherCostsInformation model = new ProjectCostingSheetAddOtherCostsInformation(projectCostingSheetAddTDS);

            // Store tables
            Session.Remove("otherCostsInformationDummy");
            otherCostsInformation = (ProjectCostingSheetAddTDS.OtherCostsInformationDataTable)model.Table;
            Session["otherCostsInformation"] = otherCostsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            // Validate grid columns
            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            if (projectGateway.GetCountryID(projectId) == 1) //Canada
            {
                // Other costs
                grdOtherCosts.Columns[8].Visible = true;
                grdOtherCosts.Columns[9].Visible = true;
                grdOtherCosts.Columns[10].Visible = false;
                grdOtherCosts.Columns[11].Visible = false;

                lblOtherCostsTotalCosts.Text = "Total Cost (CAD) : ";
                tbxOtherCostsTotalCostsCAD.Visible = true;
                tbxOtherCostsTotalCostsUSD.Visible = false;
            }
            else
            {
                // Other costs
                grdOtherCosts.Columns[8].Visible = false;
                grdOtherCosts.Columns[9].Visible = false;
                grdOtherCosts.Columns[10].Visible = true;
                grdOtherCosts.Columns[11].Visible = true;

                lblOtherCostsTotalCosts.Text = "Total Cost (USD) : ";
                tbxOtherCostsTotalCostsCAD.Visible = false;
                tbxOtherCostsTotalCostsUSD.Visible = true;
            }

            grdOtherCosts.DataBind();
            StepOtherCostsInformationProcessGrid();
        }



        private bool StepOtherCostInformationNext()
        {
            StepOtherCostsInformationProcessGrid();

            // Store tables
            Session.Remove("otherCostsInformationDummy");
            Session["otherCostsInformation"] = otherCostsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;
            return true;
        }



        private bool StepOtherCostInformationPrevious()
        {
            return true;
        }



        private void StepOtherCostsInformationProcessGrid()
        {
            decimal totalCostCadLH = 0;
            decimal totalCostUsdLH = 0;

            foreach (ProjectCostingSheetAddTDS.OtherCostsInformationRow row in (ProjectCostingSheetAddTDS.OtherCostsInformationDataTable)Session["otherCostsInformation"])
            {
                if (!row.Deleted)
                {
                    totalCostCadLH = totalCostCadLH + row.TotalCostCad;
                    totalCostUsdLH = totalCostUsdLH + row.TotalCostUsd;
                }
            }

            tbxOtherCostsTotalCostsCAD.Text = Decimal.Round(totalCostCadLH, 2).ToString();
            tbxOtherCostsTotalCostsUSD.Text = Decimal.Round(totalCostUsdLH, 2).ToString();
        }



        protected void OtherCostsInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                ProjectCostingSheetAddTDS.OtherCostsInformationDataTable dt = new ProjectCostingSheetAddTDS.OtherCostsInformationDataTable();
                dt.AddOtherCostsInformationRow(0, 0, "", "", "", "", 0, 0, 0, 0, 0, false, 3, false, "", DateTime.Now, DateTime.Now, "", "", "", 0, 0);
                Session["otherCostsInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetAddTDS.OtherCostsInformationDataTable dt = (ProjectCostingSheetAddTDS.OtherCostsInformationDataTable)Session["otherCostsInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        public ProjectCostingSheetAddTDS.OtherCostsInformationDataTable GetOtherCostsInformation()
        {
            otherCostsInformation = (ProjectCostingSheetAddTDS.OtherCostsInformationDataTable)Session["otherCostsInformationDummy"];

            if (otherCostsInformation == null)
            {
                otherCostsInformation = (ProjectCostingSheetAddTDS.OtherCostsInformationDataTable)Session["otherCostsInformation"];
            }

            return otherCostsInformation;
        }



        public void DummyOtherCostsNew(int original_CostingSheetID, int original_RefID)
        {
        }



        public void DummyOtherCostsNew(int CostingSheetID)
        {
        }

        #endregion






        #region STEP9 - REVENUE INFORMATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP9 - REVENUE INFORMATION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP9 - REVENUE INFORMATION - EVENTS
        //

        protected void grdRevenue_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Revenue Gridview, if the gridview is edition mode
                    if (grdRevenue.EditIndex >= 0)
                    {
                        grdRevenue.UpdateRow(grdRevenue.EditIndex, true);
                    }

                    // Validate general data
                    Page.Validate("revenueNew");
                    
                    if (Page.IsValid)
                    {
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        string comment = ""; if (((TextBox)grdRevenue.FooterRow.FindControl("tbxCommentNew")).Text.Trim() != "") comment = ((TextBox)grdRevenue.FooterRow.FindControl("tbxCommentNew")).Text.Trim();

                        decimal revenue = 0.0M;
                        revenue = Decimal.Parse(((TextBox)grdRevenue.FooterRow.FindControl("tbxRevenueNew")).Text.Trim());
                        revenue = Decimal.Round(revenue, 2);

                        DateTime startDate = ((RadDatePicker)grdRevenue.FooterRow.FindControl("tkrdpStartDateNew")).SelectedDate.Value;
                        DateTime endDate = startDate;

                        ProjectCostingSheetAddRevenueInformation model = new ProjectCostingSheetAddRevenueInformation(projectCostingSheetAddTDS);
                        model.Insert(0, revenue, false, companyId, startDate, endDate, comment);

                        Session.Remove("revenueInformationDummy");
                        revenueInformation = (ProjectCostingSheetAddTDS.RevenueInformationDataTable)model.Table;
                        Session["revenueInformation"] = revenueInformation;
                        Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                        grdRevenue.DataBind();

                        StepRevenueInformationProcessGrid();
                    }
                    break;
            }
        }



        protected void grdRevenue_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Validate general data
            Page.Validate("revenueEdit");
            
            if (Page.IsValid)
            {
                int costingSheetId = (int)e.Keys["CostingSheetID"];
                int refIdRevenue = (int)e.Keys["RefIDRevenue"];

                int companyId = Int32.Parse(hdfCompanyId.Value);
                string comment = ((TextBox)grdRevenue.Rows[e.RowIndex].Cells[0].FindControl("tbxCommentEdit")).Text;

                decimal revenue = 0.0M;
                revenue = Decimal.Parse(((TextBox)grdRevenue.Rows[e.RowIndex].Cells[0].FindControl("tbxRevenueEdit")).Text.Trim());
                revenue = Decimal.Round(revenue, 2);

                DateTime startDate = ((RadDatePicker)grdRevenue.Rows[e.RowIndex].Cells[0].FindControl("tkrdpStartDateEdit")).SelectedDate.Value;
                DateTime endDate = startDate;

                // Update data
                ProjectCostingSheetAddRevenueInformation model = new ProjectCostingSheetAddRevenueInformation(projectCostingSheetAddTDS);
                model.Update(costingSheetId, refIdRevenue, revenue, false, companyId, startDate, endDate, comment);

                // Store dataset
                revenueInformation = (ProjectCostingSheetAddTDS.RevenueInformationDataTable)model.Table;
                Session["revenueInformation"] = revenueInformation;
                Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                StepRevenueInformationProcessGrid();
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdRevenue_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Revenue Gridview, if the gridview is edition mode
            if (grdRevenue.EditIndex >= 0)
            {
                grdRevenue.UpdateRow(grdRevenue.EditIndex, true);
            }

            // Delete revenue
            int costingSheetId = (int)e.Keys["CostingSheetID"];
            int refIdRevenue = (int)e.Keys["RefIDRevenue"];

            ProjectCostingSheetAddRevenueInformation model = new ProjectCostingSheetAddRevenueInformation(projectCostingSheetAddTDS);
            model.Delete(costingSheetId, refIdRevenue);

            // Store dataset
            revenueInformation = (ProjectCostingSheetAddTDS.RevenueInformationDataTable)model.Table;
            Session["revenueInformation"] = revenueInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            StepRevenueInformationProcessGrid();
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP9 - REVENUE INFORMATION - AUXILIAR EVENTS
        //

        protected void grdRevenue_DataBound(object sender, EventArgs e)
        {
            RevenueInformationEmptyFix(grdRevenue);
        }



        protected void grdRevenue_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            StepRevenueInformationProcessGrid();
        }



        protected void grdRevenue_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Revenue Gridview, if the gridview is edition mode
            if (grdRevenue.EditIndex >= 0)
            {
                grdRevenue.UpdateRow(grdRevenue.EditIndex, true);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP9 - REVENUE INFORMATION - METHODS
        //

        private void StepRevenueInformationIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please verify Revenue information";

            // Load
            ProjectCostingSheetAddRevenueInformation model = new ProjectCostingSheetAddRevenueInformation(projectCostingSheetAddTDS);

            if (projectCostingSheetAddTDS.RevenueInformation.Rows.Count <= 0)
            {
                model.Load(int.Parse(hdfProjectId.Value), tkrdpFrom.SelectedDate.Value, tkrdpTo.SelectedDate.Value, int.Parse(hdfCompanyId.Value));
            }

            // Store tables
            Session.Remove("revenueInformationDummy");
            revenueInformation = (ProjectCostingSheetAddTDS.RevenueInformationDataTable)model.Table;
            Session["revenueInformation"] = revenueInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            // Validate grid columns
            //int projectId = Int32.Parse(hdfProjectId.Value);
            //ProjectGateway projectGateway = new ProjectGateway();
            //projectGateway.LoadByProjectId(projectId);

            //if (projectGateway.GetCountryID(projectId) == 1) //Canada
            //{
            //    lblRevenueTotal.Text = "Total Revenue (CAD) : ";
            //}
            //else
            //{
            //    lblRevenueTotal.Text = "Total Revenue (USD) : ";
            //}

            grdRevenue.DataBind();
            StepRevenueInformationProcessGrid();

            GetRevenueSummary();
        }



        private bool StepRevenueInformationNext()
        {
            StepRevenueInformationProcessGrid();

            // Store tables
            Session.Remove("revenueInformationDummy");
            Session["revenueInformation"] = revenueInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;
            return true;
        }



        private bool StepRevenueInformationPrevious()
        {
            return true;
        }



        private void StepRevenueInformationProcessGrid()
        {
            decimal totalRevenue = 0;

            foreach (ProjectCostingSheetAddTDS.RevenueInformationRow row in (ProjectCostingSheetAddTDS.RevenueInformationDataTable)Session["revenueInformation"])
            {
                if (!row.Deleted)
                {
                    totalRevenue = totalRevenue + row.Revenue;
                }
            }

            tbxRevenueTotal.Text = Decimal.Round(totalRevenue, 2).ToString();
        }



        private void GetRevenueSummary()
        {
            decimal grandTotalCad = Decimal.Round(decimal.Parse(tbxTeamMembersTotalCostCAD.Text) + decimal.Parse(tbxUnitsTotalCostsCAD.Text) + decimal.Parse(tbxMaterialsTotalCostsCAD.Text) + decimal.Parse(tbxOtherCostsTotalCostsCAD.Text) + decimal.Parse(tbxSubcontractorsTotalCostsCAD.Text) + decimal.Parse(tbxHotelsTotalCostsCAD.Text) + decimal.Parse(tbxBondingsTotalCostsCAD.Text) + decimal.Parse(tbxInsurancesTotalCostsCAD.Text) + decimal.Parse(tbxOtherCategoryTotalCostsCAD.Text), 2);
            decimal grandTotalUsd = Decimal.Round(decimal.Parse(tbxTeamMembersTotalCostUSD.Text) + decimal.Parse(tbxUnitsTotalCostsUSD.Text) + decimal.Parse(tbxMaterialsTotalCostsUSD.Text) + decimal.Parse(tbxOtherCostsTotalCostsUSD.Text) + decimal.Parse(tbxSubcontractorsTotalCostsUSD.Text) + decimal.Parse(tbxHotelsTotalCostsCAD.Text) + decimal.Parse(tbxBondingsTotalCostsCAD.Text) + decimal.Parse(tbxInsurancesTotalCostsCAD.Text) + decimal.Parse(tbxOtherCategoryTotalCostsCAD.Text), 2);
            decimal grandTotal = 0.0M;
            decimal grandRevenue = decimal.Round(decimal.Parse(tbxRevenueTotal.Text),2);
            decimal grandProfit = 0.0M;
            decimal grandGrossMargin = 0.0M;

            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            if (projectGateway.GetCountryID(projectId) == 1) //Canada
            {
                lblGrandTotal.Text = "Grand Total (CAD)";
                grandTotal = grandTotalCad;
            }
            else
            {
                lblGrandTotal.Text = "Grand Total (USD)";
                grandTotal = grandTotalUsd;
            }

            grandProfit = grandRevenue - grandTotal;

            if (grandRevenue > 0)
            {
                grandGrossMargin = (grandProfit / grandRevenue) * 100;
            }
            else
            {
                grandGrossMargin = 0;
            }

            tbxGrandTotal.Text = grandTotal.ToString();
            tbxGradRevenue.Text = tbxRevenueTotal.Text;
            tbxGrandProfit.Text = grandProfit.ToString();
            tbxGrandGrossMargin.Text = decimal.Round(grandGrossMargin, 2).ToString();
        }       



        protected void RevenueInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectCostingSheetAddTDS.RevenueInformationDataTable dt = new ProjectCostingSheetAddTDS.RevenueInformationDataTable();
                dt.AddRevenueInformationRow(0, 0, 0, "", companyId, DateTime.Now, DateTime.Now, false,false,false);
                Session["revenueInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetAddTDS.RevenueInformationDataTable dt = (ProjectCostingSheetAddTDS.RevenueInformationDataTable)Session["revenueInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        public ProjectCostingSheetAddTDS.RevenueInformationDataTable GetRevenueInformation()
        {
            revenueInformation = (ProjectCostingSheetAddTDS.RevenueInformationDataTable)Session["revenueInformationDummy"];

            if (revenueInformation == null)
            {
                revenueInformation = (ProjectCostingSheetAddTDS.RevenueInformationDataTable)Session["revenueInformation"];
            }

            return revenueInformation;
        }



        public void DummyRevenueNew(int original_CostingSheetID, int original_RefIDRevenue)
        {
        }

        #endregion






        #region STEP10 - SUMMARY

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP10 - SUMMARY
        //


        // ////////////////////////////////////////////////////////////////////////
        // STEP10 - SUMMARY - METHODS
        //

        private void StepSummaryIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Summary";

            // Initialize summary
            tbxSummary.Text = GetSummary();
        }



        private bool StepSummaryPrevious()
        {
            return true;
        }



        protected bool StepSummaryFinish()
        {
            Page.Validate("");
            if (Page.IsValid)
            {
                PostPageChanges();
                UpdateDatabase();

                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion






        #region STEP11 - FINISH OPTIONS
        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP11 - FINISH OPTIONS
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP11 - FINISH OPTIONS - METHODS
        //

        private void StepFinalStepIn()
        {
            // Set instruction
            mWizard2 master2 = (mWizard2)this.Master;
            master2.WizardInstruction = "What would you like to do?";

            lkbtnClose.Attributes.Add("onclick", "return lkbtnCloseClick();");

            if (cbxEndConfirm.Checked)
            {
                string url = "";
                int newCostingSheetId = Int32.Parse(hdfCostingSheetId.Value);

                url = "./project_costing_sheets_summary.aspx?source_page=project_costing_sheets_add.aspx&project_id=" + hdfProjectId.Value + "&costing_sheet_id=" + newCostingSheetId;
                lkbtnOpenCostingSheet.Attributes.Add("onclick", string.Format("return lkbtnOpenServiceClick('{0}');", url));

                url = "./project_costing_sheets_edit.aspx?source_page=project_costing_sheets_add.aspx&&project_id=" + hdfProjectId.Value + "&costing_sheet_id=" + newCostingSheetId;
                lkbtnEditCostingSheet.Attributes.Add("onclick", string.Format("return lkbtnEditServiceClick('{0}');", url));                
            }
            else
            {
                lkbtnOpenCostingSheet.Visible = false;
                lkbtnEditCostingSheet.Visible = false;
            }
        }

        #endregion






        // ////////////////////////////////////////////////////////////////////////
        // FINAL EVENTS 
        //

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set wizard title
            Label title = (Label)this.Master.FindControl("lblTitle");
            title.Text = "Add Costing Sheet";
        }






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //
        
        private void RegisterClientScripts()
        {
            // Resolve timeout problem
            ScriptManager scriptManager = (ScriptManager)this.Page.Master.FindControl("ScriptManager1");
            if (scriptManager != null)
            {
                scriptManager.AsyncPostBackTimeout = 1200;
            }

            // Register content variables
            string contentVariables = "";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./project_costing_sheets_add.js");
        }



        private void TagPage()
        {
            hdfProjectId.Value = (string)Request.QueryString["project_Id"];
            hdfCompanyId.Value = Convert.ToInt32(Session["companyID"]).ToString();
        }



        private void UpdateDatabase()
        {
            DB.Open();
            DB.BeginTransaction();
            try
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                int loginId = Convert.ToInt32(Session["loginID"]);

                if (cbxEndConfirm.Checked)
                {
                    ProjectCostingSheetAddBasicInformation projectCostingSheetAddBasicInformation = new ProjectCostingSheetAddBasicInformation(projectCostingSheetAddTDS);
                    int costingSheetId = projectCostingSheetAddBasicInformation.Save(companyId);
                    hdfCostingSheetId.Value = costingSheetId.ToString();

                    // Save costs information
                    ProjectCostingSheetAddLabourHoursInformation projectCostingSheetAddLabourHoursInformation = new ProjectCostingSheetAddLabourHoursInformation(projectCostingSheetAddTDS);
                    projectCostingSheetAddLabourHoursInformation.Save(companyId, costingSheetId);

                    ProjectCostingSheetAddUnitsInformation projectCostingSheetAddUnitsInformation = new ProjectCostingSheetAddUnitsInformation(projectCostingSheetAddTDS);
                    projectCostingSheetAddUnitsInformation.Save(companyId, costingSheetId);

                    ProjectCostingSheetAddMaterialsInformation projectCostingSheetAddMaterialsInformation = new ProjectCostingSheetAddMaterialsInformation(projectCostingSheetAddTDS);
                    projectCostingSheetAddMaterialsInformation.Save(companyId, costingSheetId);

                    ProjectCostingSheetAddSubcontractorsInformation projectCostingSheetAddSubcontractorsInformation = new ProjectCostingSheetAddSubcontractorsInformation(projectCostingSheetAddTDS);
                    projectCostingSheetAddSubcontractorsInformation.Save(companyId, costingSheetId);

                    ProjectCostingSheetAddOtherCostsInformation projectCostingSheetAddOtherCostsInformation = new ProjectCostingSheetAddOtherCostsInformation(projectCostingSheetAddTDS);
                    projectCostingSheetAddOtherCostsInformation.Save(companyId, costingSheetId);

                    ProjectCostingSheetAddHotelsInformation projectCostingSheetAddHotelsInformation = new ProjectCostingSheetAddHotelsInformation(projectCostingSheetAddTDS);
                    projectCostingSheetAddHotelsInformation.Save(companyId, costingSheetId);

                    ProjectCostingSheetAddBondingsInformation projectCostingSheetAddBondingsInformation = new ProjectCostingSheetAddBondingsInformation(projectCostingSheetAddTDS);
                    projectCostingSheetAddBondingsInformation.Save(companyId, costingSheetId);

                    ProjectCostingSheetAddInsurancesInformation projectCostingSheetAddInsurancesInformation = new ProjectCostingSheetAddInsurancesInformation(projectCostingSheetAddTDS);
                    projectCostingSheetAddInsurancesInformation.Save(companyId, costingSheetId);

                    ProjectCostingSheetAddOtherCategoryInformation projectCostingSheetAddOtherCategoryInformation = new ProjectCostingSheetAddOtherCategoryInformation(projectCostingSheetAddTDS);
                    projectCostingSheetAddOtherCategoryInformation.Save(companyId, costingSheetId);

                    ProjectCostingSheetAddRevenueInformation projectCostingSheetAddRevenueInformation = new ProjectCostingSheetAddRevenueInformation(projectCostingSheetAddTDS);
                    projectCostingSheetAddRevenueInformation.Save(companyId, costingSheetId);
                    
                    if (rbtnBeginTemplate.Checked)
                    {
                        ProjectCostingSheetTemplateInformation projectCostingSheetTemplateInformation = new ProjectCostingSheetTemplateInformation(projectCostingSheetAddTDS);
                        projectCostingSheetTemplateInformation.Save(companyId);
                    }
                }
                else
                {
                    if (cbxEndSave.Checked)
                    {
                        ProjectCostingSheetTemplateInformation projectCostingSheetTemplateInformation = new ProjectCostingSheetTemplateInformation(projectCostingSheetAddTDS);
                        projectCostingSheetTemplateInformation.Save(companyId);
                    }
                    else
                    {
                        if (rbtnBeginTemplate.Checked)
                        {
                            ProjectCostingSheetTemplateInformation projectCostingSheetTemplateInformation = new ProjectCostingSheetTemplateInformation(projectCostingSheetAddTDS);
                            projectCostingSheetTemplateInformation.Save(companyId);
                        }
                    }
                }
                                
                DB.CommitTransaction();

                // Store datasets
                projectCostingSheetAddTDS.AcceptChanges();
                Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private void PostPageChanges()
        {
            if (cbxEndConfirm.Checked)
            {
                ProjectCostingSheetAddBasicInformation model = new ProjectCostingSheetAddBasicInformation(projectCostingSheetAddTDS);
                model.Insert(Int32.Parse(hdfProjectId.Value), tbxName.Text, tkrdpFrom.SelectedDate.Value, tkrdpTo.SelectedDate.Value, decimal.Parse(tbxTeamMembersTotalCostCAD.Text), decimal.Parse(tbxTeamMembersTotalCostUSD.Text), decimal.Parse(tbxMaterialsTotalCostsCAD.Text), decimal.Parse(tbxMaterialsTotalCostsUSD.Text), decimal.Parse(tbxUnitsTotalCostsCAD.Text), decimal.Parse(tbxUnitsTotalCostsUSD.Text), decimal.Parse(tbxOtherCostsTotalCostsCAD.Text), decimal.Parse(tbxOtherCostsTotalCostsUSD.Text), 0, 0, "In Progress", false, Int32.Parse(hdfCompanyId.Value), decimal.Parse(tbxSubcontractorsTotalCostsCAD.Text), decimal.Parse(tbxSubcontractorsTotalCostsUSD.Text), decimal.Parse(tbxRevenueTotal.Text), decimal.Parse(tbxGrandProfit.Text), decimal.Parse(tbxGrandGrossMargin.Text), decimal.Parse(tbxHotelsTotalCostsCAD.Text), decimal.Parse(tbxBondingsTotalCostsCAD.Text), decimal.Parse(tbxInsurancesTotalCostsCAD.Text), decimal.Parse(tbxOtherCategoryTotalCostsCAD.Text), "");

                Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;
            }           
        }



        private void PostPageChanges2()
        {
            if (cbxEndSave.Checked)
            {
                int? month = null;
                int? day = null;
                int? year = null;

                int? month2 = null;
                int? day2 = null;
                int? year2 = null;

                if (tkrdpFrom.SelectedDate.HasValue)
                {
                    month = tkrdpFrom.SelectedDate.Value.Month;
                    day = tkrdpFrom.SelectedDate.Value.Day;
                    year = tkrdpFrom.SelectedDate.Value.Year;
                }

                if (tkrdpTo.SelectedDate.HasValue)
                {
                    month2 = tkrdpTo.SelectedDate.Value.Month;
                    day2 = tkrdpTo.SelectedDate.Value.Day;
                    year2 = tkrdpTo.SelectedDate.Value.Year;
                }

                if (rbtnEndSaveNew.Checked)
                {
                    if (tbxEndSaveNew.Text != "")
                    {
                        ProjectCostingSheetTemplateInformation projectCostingSheetTemplateInformation = new ProjectCostingSheetTemplateInformation(projectCostingSheetAddTDS);
                        projectCostingSheetTemplateInformation.Insert(tbxEndSaveNew.Text, cbxRehabAssessmentData.Checked, cbxFullLengthLiningData.Checked, cbxPointRepairData.Checked, cbxJunctionLiningData.Checked, cbxManholeRehabData.Checked, cbxMobilizationData.Checked, cbxOtherData.Checked, cbxLabourHour.Checked, cbxTrucksEquipment.Checked, cbxMaterial.Checked, cbxSubcontractor.Checked, cbxOtherCost.Checked, cbxRevenueInformation.Checked, false, Convert.ToInt32(hdfCompanyId.Value), month, day, year, month2, day2, year2);
                    }
                }

                if (rbtnEndSaveReplace.Checked)
                {
                    if (luEndSaveTemplate.SelectedIndex > 0)
                    {
                        ProjectCostingSheetTemplateInformation projectCostingSheetTemplateInformation = new ProjectCostingSheetTemplateInformation(projectCostingSheetAddTDS);
                        projectCostingSheetTemplateInformation.Update(Convert.ToInt32(luEndSaveTemplate.SelectedValue), luEndSaveTemplate.SelectedItem.Text, cbxRehabAssessmentData.Checked, cbxFullLengthLiningData.Checked, cbxPointRepairData.Checked, cbxJunctionLiningData.Checked, cbxManholeRehabData.Checked, cbxMobilizationData.Checked, cbxOtherData.Checked, cbxLabourHour.Checked, cbxTrucksEquipment.Checked, cbxMaterial.Checked, cbxSubcontractor.Checked, cbxOtherCost.Checked, cbxRevenueInformation.Checked, false, Convert.ToInt32(hdfCompanyId.Value), month, day, year, month2, day2, year2);
                    }
                }

                Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;
                templateInformation = projectCostingSheetAddTDS.TemplateInformation;
                Session["templateInformation"] = templateInformation;
            }
        }



        private string GetSummary()
        {
            string summary = "";

            if (cbxEndConfirm.Checked)
            {
                decimal grandTotalCad = Decimal.Round(decimal.Parse(tbxTeamMembersTotalCostCAD.Text) + decimal.Parse(tbxUnitsTotalCostsCAD.Text) + decimal.Parse(tbxMaterialsTotalCostsCAD.Text) + decimal.Parse(tbxOtherCostsTotalCostsCAD.Text) + decimal.Parse(tbxSubcontractorsTotalCostsCAD.Text) + decimal.Parse(tbxHotelsTotalCostsCAD.Text) + decimal.Parse(tbxBondingsTotalCostsCAD.Text) + decimal.Parse(tbxInsurancesTotalCostsCAD.Text) + decimal.Parse(tbxOtherCategoryTotalCostsCAD.Text), 2);
                decimal grandTotalUsd = Decimal.Round(decimal.Parse(tbxTeamMembersTotalCostUSD.Text) + decimal.Parse(tbxUnitsTotalCostsUSD.Text) + decimal.Parse(tbxMaterialsTotalCostsUSD.Text) + decimal.Parse(tbxOtherCostsTotalCostsUSD.Text) + decimal.Parse(tbxSubcontractorsTotalCostsUSD.Text) + decimal.Parse(tbxHotelsTotalCostsCAD.Text) + decimal.Parse(tbxBondingsTotalCostsCAD.Text) + decimal.Parse(tbxInsurancesTotalCostsCAD.Text) + decimal.Parse(tbxOtherCategoryTotalCostsCAD.Text), 2);
                summary = "GENERAL INFORMATION \n";
                summary += "Name: \t" + tbxName.Text + "\n";
                summary += "Date Range: \t" + "From " + tkrdpFrom.SelectedDate.Value.ToShortDateString() + " To " + tkrdpTo.SelectedDate.Value.ToShortDateString() + "\n";
                summary += "Labour Hours: \t Total Cost (CAD) = " + tbxTeamMembersTotalCostCAD.Text + "\t (USD) = " + tbxTeamMembersTotalCostUSD.Text + "\n";
                summary += "Trucks / Equipment Costs: \t Total Cost (CAD) = " + tbxUnitsTotalCostsCAD.Text + "\t (USD) = " + tbxUnitsTotalCostsUSD.Text + "\n";
                summary += "Materials Costs: \t Total Cost (CAD) = " + tbxMaterialsTotalCostsCAD.Text + "\t (USD) = " + tbxMaterialsTotalCostsUSD.Text + "\n";
                summary += "Subcontractors Costs: \t Total Cost (CAD) = " + tbxSubcontractorsTotalCostsCAD.Text + "\t (USD) = " + tbxSubcontractorsTotalCostsUSD.Text + "\n";
                summary += "Hotels Costs: \t Total Cost (CAD) = " + tbxHotelsTotalCostsCAD.Text + "\t (USD) = " + tbxHotelsTotalCostsUSD.Text + "\n";
                summary += "Bondings Costs: \t Total Cost (CAD) = " + tbxBondingsTotalCostsCAD.Text + "\t (USD) = " + tbxBondingsTotalCostsUSD.Text + "\n";
                summary += "Insurances Costs: \t Total Cost (CAD) = " + tbxInsurancesTotalCostsCAD.Text + "\t (USD) = " + tbxInsurancesTotalCostsUSD.Text + "\n";
                summary += "Other Category Costs: \t Total Cost (CAD) = " + tbxOtherCategoryTotalCostsCAD.Text + "\t (USD) = " + tbxOtherCategoryTotalCostsUSD.Text + "\n";
                summary += "Other Costs: \t Total Cost (CAD) = " + tbxOtherCostsTotalCostsCAD.Text + "\t (USD) = " + tbxOtherCostsTotalCostsUSD.Text + "\n";
                summary += "Grand Total (CAD) = " + grandTotalCad.ToString() + "\t (USD) = " + grandTotalUsd.ToString() + "\n";
            }
            else
            {
                if (cbxEndSave.Checked)
                {
                    summary = "GENERAL INFORMATION \n";

                    if (rbtnEndSaveNew.Checked) summary += "Name: \t" + tbxEndSaveNew.Text + "\n";
                    if (rbtnEndSaveReplace.Checked) summary += "Name: \t" + luEndSaveTemplate.SelectedItem.Text + "\n";

                    string typeOfWork = "";
                    if (cbxRehabAssessmentData.Checked) typeOfWork = "RA";
                    if (cbxFullLengthLiningData.Checked) { if (typeOfWork.Length > 0) typeOfWork = typeOfWork + "- FLL"; else typeOfWork = "FLL"; }
                    if (cbxPointRepairData.Checked) { if (typeOfWork.Length > 0) typeOfWork = typeOfWork + "- PR"; else typeOfWork = "PR"; }
                    if (cbxJunctionLiningData.Checked) { if (typeOfWork.Length > 0) typeOfWork = typeOfWork + "- JL"; else typeOfWork = "JL"; }
                    if (cbxManholeRehabData.Checked) { if (typeOfWork.Length > 0) typeOfWork = typeOfWork + "- MR"; else typeOfWork = "MR"; }
                    if (cbxMobilizationData.Checked) { if (typeOfWork.Length > 0) typeOfWork = typeOfWork + "- MOB"; else typeOfWork = "MOB"; }
                    if (cbxOtherData.Checked) { if (typeOfWork.Length > 0) typeOfWork = typeOfWork + "- Other"; else typeOfWork = "Other"; }
                    summary += "Type of Work: \t" + typeOfWork + "\n";

                    string costingArea = "";
                    if (cbxLabourHour.Checked) costingArea = "Labour Hour";
                    if (cbxTrucksEquipment.Checked) { if (costingArea.Length > 0) costingArea = costingArea + "- Unit"; else costingArea = "Unit"; }
                    if (cbxMaterial.Checked) { if (costingArea.Length > 0) costingArea = costingArea + "- Material"; else costingArea = "Material"; }                   
                    if (cbxSubcontractor.Checked) { if (costingArea.Length > 0) costingArea = costingArea + "- Subcontractor"; else costingArea = "Subcontractor"; }
                    if (cbxHotel.Checked) { if (costingArea.Length > 0) costingArea = costingArea + "- Hotel"; else costingArea = "Hotel"; }
                    if (cbxBonding.Checked) { if (costingArea.Length > 0) costingArea = costingArea + "- Bonding"; else costingArea = "Bonding"; }
                    if (cbxInsurance.Checked) { if (costingArea.Length > 0) costingArea = costingArea + "- Insurance"; else costingArea = "Insurance"; }
                    if (cbxOtherCategory.Checked) { if (costingArea.Length > 0) costingArea = costingArea + "- Other Category"; else costingArea = "Other Category"; }
                    if (cbxOtherCost.Checked) { if (costingArea.Length > 0) costingArea = costingArea + "- Misc."; else costingArea = "Misc."; }
                    summary += "Costing Area: \t" + costingArea + "\n";
                }
            }

            return summary;
        }



        //////////////////////////////////////////////////////
        #region STEP7 - HOTEL INFORMATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP7 - HOTEL INFORMATION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP7 - HOTEL INFORMATION - EVENTS
        //

        protected void grdHotels_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Hotels Gridview, if the gridview is edition mode
                    if (grdHotels.EditIndex >= 0)
                    {
                        grdHotels.UpdateRow(grdHotels.EditIndex, true);
                    }

                    // Validate general data
                    Page.Validate("hotelNew");
                    
                    if (Page.IsValid)
                    {
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        int hotelId = Int32.Parse(((DropDownList)grdHotels.FooterRow.FindControl("ddlHotelNew")).SelectedValue);
                        string hotel = ((DropDownList)grdHotels.FooterRow.FindControl("ddlHotelNew")).SelectedItem.Text;
                        decimal rate = Decimal.Parse(((TextBox)grdHotels.FooterRow.FindControl("tbxRateNew")).Text.Trim());
                       
                        DateTime startDate = ((RadDatePicker)grdHotels.FooterRow.FindControl("tkrdpStartDateNew")).SelectedDate.Value;
                        DateTime endDate = ((RadDatePicker)grdHotels.FooterRow.FindControl("tkrdpEndDateNew")).SelectedDate.Value;

                        ProjectCostingSheetAddHotelsInformation model = new ProjectCostingSheetAddHotelsInformation(projectCostingSheetAddTDS);
                        model.Insert(0, hotelId, rate, false, companyId, startDate, endDate, hotel);

                        Session.Remove("hotelsInformationDummy");
                        hotelsInformation = (ProjectCostingSheetAddTDS.HotelsInformationDataTable)model.Table;
                        Session["hotelsInformation"] = hotelsInformation;
                        Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                        grdHotels.DataBind();

                        StepHotelsInformationProcessGrid();
                    }
                    break;
            }
        }



        protected void grdHotels_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Validate general data
            Page.Validate("hotelEdit");
            
            if (Page.IsValid)
            {
                int costingSheetId = (int)e.Keys["CostingSheetID"];
                int hotelId = (int)e.Keys["HotelID"];
                int refId = (int)e.Keys["RefID"];

                int companyId = Int32.Parse(hdfCompanyId.Value);
                decimal rate = Decimal.Parse(((TextBox)grdHotels.Rows[e.RowIndex].Cells[0].FindControl("tbxRateEdit")).Text.Trim());
                DateTime startDate = ((RadDatePicker)grdHotels.Rows[e.RowIndex].Cells[0].FindControl("tkrdpStartDateEdit")).SelectedDate.Value;
                DateTime endDate = ((RadDatePicker)grdHotels.Rows[e.RowIndex].Cells[0].FindControl("tkrdpEndDateEdit")).SelectedDate.Value;

                // Update data
                ProjectCostingSheetAddHotelsInformation model = new ProjectCostingSheetAddHotelsInformation(projectCostingSheetAddTDS);
                model.Update(costingSheetId, hotelId, refId, rate, false, companyId, startDate, endDate);

                // Store dataset
                hotelsInformation = (ProjectCostingSheetAddTDS.HotelsInformationDataTable)model.Table;
                Session["hotelsInformation"] = hotelsInformation;
                Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                StepHotelsInformationProcessGrid();
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdHotels_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Hotels Gridview, if the gridview is edition mode
            if (grdHotels.EditIndex >= 0)
            {
                grdHotels.UpdateRow(grdHotels.EditIndex, true);
            }

            // Delete hotel
            int costingSheetId = (int)e.Keys["CostingSheetID"];
            int hotelId = (int)e.Keys["HotelID"];
            int refId = (int)e.Keys["RefID"];

            ProjectCostingSheetAddHotelsInformation model = new ProjectCostingSheetAddHotelsInformation(projectCostingSheetAddTDS);
            model.Delete(costingSheetId, hotelId, refId);

            // Store dataset
            hotelsInformation = (ProjectCostingSheetAddTDS.HotelsInformationDataTable)model.Table;
            Session["hotelsInformation"] = hotelsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            StepHotelsInformationProcessGrid();
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP7 - HOTEL INFORMATION - AUXILIAR EVENTS
        //

        protected void grdHotels_DataBound(object sender, EventArgs e)
        {
            HotelsInformationEmptyFix(grdHotels);
        }



        protected void grdHotels_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            StepHotelsInformationProcessGrid();
        }



        protected void grdHotels_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Hotels Gridview, if the gridview is edition mode
            if (grdHotels.EditIndex >= 0)
            {
                grdHotels.UpdateRow(grdHotels.EditIndex, true);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP7 - HOTEL INFORMATION - METHODS
        //

        private void StepHotelsInformationIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please verify Hotels information";

            // Load
            ProjectCostingSheetAddHotelsInformation model = new ProjectCostingSheetAddHotelsInformation(projectCostingSheetAddTDS);

            if (projectCostingSheetAddTDS.HotelsInformation.Rows.Count <= 0)
            {
                model.Load(int.Parse(hdfProjectId.Value), tkrdpFrom.SelectedDate.Value, tkrdpTo.SelectedDate.Value, int.Parse(hdfCompanyId.Value));
            }

            // Store tables
            Session.Remove("hotelsInformationDummy");
            hotelsInformation = (ProjectCostingSheetAddTDS.HotelsInformationDataTable)model.Table;
            Session["hotelsInformation"] = hotelsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            // Validate grid columns
            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            if (projectGateway.GetCountryID(projectId) == 1) //Canada
            {
                // Hotels Grid
                lblHotelsTotalCosts.Text = "Total Cost (CAD) : ";
                tbxHotelsTotalCostsCAD.Visible = true;
                tbxHotelsTotalCostsUSD.Visible = false;
            }
            else
            {
                // Hotels Grid
                lblHotelsTotalCosts.Text = "Total Cost (USD) : ";
                tbxHotelsTotalCostsCAD.Visible = false;
                tbxHotelsTotalCostsUSD.Visible = true;
            }

            grdHotels.DataBind();
            StepHotelsInformationProcessGrid();
        }



        private bool StepHotelsInformationNext()
        {
            StepHotelsInformationProcessGrid();

            // Store tables
            Session.Remove("hotelsInformationDummy");
            Session["hotelsInformation"] = hotelsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;
            return true;
        }



        private bool StepHotelsInformationPrevious()
        {
            return true;
        }



        private void StepHotelsInformationProcessGrid()
        {
            decimal totalCostCadLH = 0;
            decimal totalCostUsdLH = 0;

            foreach (ProjectCostingSheetAddTDS.HotelsInformationRow row in (ProjectCostingSheetAddTDS.HotelsInformationDataTable)Session["hotelsInformation"])
            {
                if (!row.Deleted)
                {
                    totalCostCadLH = totalCostCadLH + row.Rate;
                    totalCostUsdLH = totalCostUsdLH + row.Rate;
                }
            }

            tbxHotelsTotalCostsCAD.Text = Decimal.Round(totalCostCadLH, 2).ToString();
            tbxHotelsTotalCostsUSD.Text = Decimal.Round(totalCostUsdLH, 2).ToString();
        }



        public ProjectCostingSheetAddTDS.HotelsInformationDataTable GetHotelsInformation()
        {
            hotelsInformation = (ProjectCostingSheetAddTDS.HotelsInformationDataTable)Session["hotelsInformationDummy"];

            if (hotelsInformation == null)
            {
                hotelsInformation = (ProjectCostingSheetAddTDS.HotelsInformationDataTable)Session["hotelsInformation"];
            }

            return hotelsInformation;
        }



        protected void HotelsInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                ProjectCostingSheetAddTDS.HotelsInformationDataTable dt = new ProjectCostingSheetAddTDS.HotelsInformationDataTable();
                dt.AddHotelsInformationRow(0, 0, 0, 0, false, 0, false, DateTime.Now, DateTime.Now, false, "", "");
                Session["hotelsInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetAddTDS.HotelsInformationDataTable dt = (ProjectCostingSheetAddTDS.HotelsInformationDataTable)Session["hotelsInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        public void DummyHotelsNew(int original_CostingSheetID, int original_HotelID, int original_RefID)
        {
        }



        public void DummyHotelsNew(int CostingSheetID, int HotelID)
        {
        }



        public void DummyHotelsNew(int CostingSheetID)
        {
        }

        #endregion

        #region STEP7 - BONDING INFORMATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP7 - BONDING INFORMATION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP7 - BONDING INFORMATION - EVENTS
        //

        protected void grdBondings_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Bondings Gridview, if the gridview is edition mode
                    if (grdBondings.EditIndex >= 0)
                    {
                        grdBondings.UpdateRow(grdBondings.EditIndex, true);
                    }

                    // Validate general data
                    Page.Validate("bondingNew");
                    
                    if (Page.IsValid)
                    {
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        int bondingCompanyId = Int32.Parse(((DropDownList)grdBondings.FooterRow.FindControl("ddlBondingNew")).SelectedValue);
                        string bonding = ((DropDownList)grdBondings.FooterRow.FindControl("ddlBondingNew")).SelectedItem.Text;
                        decimal rate = Decimal.Parse(((TextBox)grdBondings.FooterRow.FindControl("tbxRateNew")).Text.Trim());
                            
                        DateTime startDate = ((RadDatePicker)grdBondings.FooterRow.FindControl("tkrdpStartDateNew")).SelectedDate.Value;
                        DateTime endDate = ((RadDatePicker)grdBondings.FooterRow.FindControl("tkrdpEndDateNew")).SelectedDate.Value;

                        ProjectCostingSheetAddBondingsInformation model = new ProjectCostingSheetAddBondingsInformation(projectCostingSheetAddTDS);
                        model.Insert(0, bondingCompanyId, rate, false, companyId, startDate, endDate, bonding);

                        Session.Remove("bondingsInformationDummy");
                        bondingsInformation = (ProjectCostingSheetAddTDS.BondingsInformationDataTable)model.Table;
                        Session["bondingsInformation"] = bondingsInformation;
                        Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                        grdBondings.DataBind();

                        StepBondingsInformationProcessGrid();
                    }
                    break;
            }
        }



        protected void grdBondings_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Validate general data
            Page.Validate("bondingEdit");
            
            if (Page.IsValid)
            {
                int costingSheetId = (int)e.Keys["CostingSheetID"];
                int bondingCompanyId = (int)e.Keys["BondingCompanyID"];
                int refId = (int)e.Keys["RefID"];

                int companyId = Int32.Parse(hdfCompanyId.Value);
                decimal rate = Decimal.Parse(((TextBox)grdBondings.Rows[e.RowIndex].Cells[0].FindControl("tbxRateEdit")).Text.Trim());
                DateTime startDate = ((RadDatePicker)grdBondings.Rows[e.RowIndex].Cells[0].FindControl("tkrdpStartDateEdit")).SelectedDate.Value;
                DateTime endDate = ((RadDatePicker)grdBondings.Rows[e.RowIndex].Cells[0].FindControl("tkrdpEndDateEdit")).SelectedDate.Value;

                // Update data
                ProjectCostingSheetAddBondingsInformation model = new ProjectCostingSheetAddBondingsInformation(projectCostingSheetAddTDS);
                model.Update(costingSheetId, bondingCompanyId, refId, rate, false, companyId, startDate, endDate);

                // Store dataset
                bondingsInformation = (ProjectCostingSheetAddTDS.BondingsInformationDataTable)model.Table;
                Session["bondingsInformation"] = bondingsInformation;
                Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                StepBondingsInformationProcessGrid();
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdBondings_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Bondings Gridview, if the gridview is edition mode
            if (grdBondings.EditIndex >= 0)
            {
                grdBondings.UpdateRow(grdBondings.EditIndex, true);
            }

            // Delete bonding
            int costingSheetId = (int)e.Keys["CostingSheetID"];
            int bondingCompanyId = (int)e.Keys["BondingCompanyID"];
            int refId = (int)e.Keys["RefID"];

            ProjectCostingSheetAddBondingsInformation model = new ProjectCostingSheetAddBondingsInformation(projectCostingSheetAddTDS);
            model.Delete(costingSheetId, bondingCompanyId, refId);

            // Store dataset
            bondingsInformation = (ProjectCostingSheetAddTDS.BondingsInformationDataTable)model.Table;
            Session["bondingsInformation"] = bondingsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            StepBondingsInformationProcessGrid();
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP7 - BONDING INFORMATION - AUXILIAR EVENTS
        //

        protected void grdBondings_DataBound(object sender, EventArgs e)
        {
            BondingsInformationEmptyFix(grdBondings);
        }



        protected void grdBondings_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            StepBondingsInformationProcessGrid();
        }



        protected void grdBondings_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Bondings Gridview, if the gridview is edition mode
            if (grdBondings.EditIndex >= 0)
            {
                grdBondings.UpdateRow(grdBondings.EditIndex, true);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP7 - BONDING INFORMATION - METHODS
        //

        private void StepBondingsInformationIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please verify Bondings information";

            // Load
            ProjectCostingSheetAddBondingsInformation model = new ProjectCostingSheetAddBondingsInformation(projectCostingSheetAddTDS);

            if (projectCostingSheetAddTDS.BondingsInformation.Rows.Count <= 0)
            {
                model.Load(int.Parse(hdfProjectId.Value), tkrdpFrom.SelectedDate.Value, tkrdpTo.SelectedDate.Value, int.Parse(hdfCompanyId.Value));
            }

            // Store tables
            Session.Remove("bondingsInformationDummy");
            bondingsInformation = (ProjectCostingSheetAddTDS.BondingsInformationDataTable)model.Table;
            Session["bondingsInformation"] = bondingsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            // Validate grid columns
            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            if (projectGateway.GetCountryID(projectId) == 1) //Canada
            {
                // Bondings Grid
                lblBondingsTotalCosts.Text = "Total Cost (CAD) : ";
                tbxBondingsTotalCostsCAD.Visible = true;
                tbxBondingsTotalCostsUSD.Visible = false;
            }
            else
            {
                // Bondings Grid
                lblBondingsTotalCosts.Text = "Total Cost (USD) : ";
                tbxBondingsTotalCostsCAD.Visible = false;
                tbxBondingsTotalCostsUSD.Visible = true;
            }

            grdBondings.DataBind();
            StepBondingsInformationProcessGrid();
        }



        private bool StepBondingsInformationNext()
        {
            StepBondingsInformationProcessGrid();

            // Store tables
            Session.Remove("bondingsInformationDummy");
            Session["bondingsInformation"] = bondingsInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;
            return true;
        }



        private bool StepBondingsInformationPrevious()
        {
            return true;
        }



        private void StepBondingsInformationProcessGrid()
        {
            decimal totalCostCadLH = 0;
            decimal totalCostUsdLH = 0;

            foreach (ProjectCostingSheetAddTDS.BondingsInformationRow row in (ProjectCostingSheetAddTDS.BondingsInformationDataTable)Session["bondingsInformation"])
            {
                if (!row.Deleted)
                {
                    totalCostCadLH = totalCostCadLH + row.Rate;
                    totalCostUsdLH = totalCostUsdLH + row.Rate;
                }
            }

            tbxBondingsTotalCostsCAD.Text = Decimal.Round(totalCostCadLH, 2).ToString();
            tbxBondingsTotalCostsUSD.Text = Decimal.Round(totalCostUsdLH, 2).ToString();
        }



        public ProjectCostingSheetAddTDS.BondingsInformationDataTable GetBondingsInformation()
        {
            bondingsInformation = (ProjectCostingSheetAddTDS.BondingsInformationDataTable)Session["bondingsInformationDummy"];

            if (bondingsInformation == null)
            {
                bondingsInformation = (ProjectCostingSheetAddTDS.BondingsInformationDataTable)Session["bondingsInformation"];
            }

            return bondingsInformation;
        }



        protected void BondingsInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                ProjectCostingSheetAddTDS.BondingsInformationDataTable dt = new ProjectCostingSheetAddTDS.BondingsInformationDataTable();
                dt.AddBondingsInformationRow(0, 0, 0, 0, false, 0, false, DateTime.Now, DateTime.Now, false, "", "");
                Session["bondingsInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetAddTDS.BondingsInformationDataTable dt = (ProjectCostingSheetAddTDS.BondingsInformationDataTable)Session["bondingsInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        public void DummyBondingsNew(int original_CostingSheetID, int original_BondingCompanyID, int original_RefID)
        {
        }



        public void DummyBondingsNew(int CostingSheetID, int BondingCompanyID)
        {
        }



        public void DummyBondingsNew(int CostingSheetID)
        {
        }

        #endregion

        #region STEP7 - INSURANCE INFORMATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP7 - INSURANCE INFORMATION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP7 - INSURANCE INFORMATION - EVENTS
        //

        protected void grdInsurances_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // Insurances Gridview, if the gridview is edition mode
                    if (grdInsurances.EditIndex >= 0)
                    {
                        grdInsurances.UpdateRow(grdInsurances.EditIndex, true);
                    }

                    // Validate general data
                    Page.Validate("insuranceNew");
                    
                    if (Page.IsValid)
                    {
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        int insuranceCompanyId = Int32.Parse(((DropDownList)grdInsurances.FooterRow.FindControl("ddlInsuranceNew")).SelectedValue);
                        string insurance = ((DropDownList)grdInsurances.FooterRow.FindControl("ddlInsuranceNew")).SelectedItem.Text;
                        decimal rate = Decimal.Parse(((TextBox)grdInsurances.FooterRow.FindControl("tbxRateNew")).Text.Trim());

                        DateTime startDate = ((RadDatePicker)grdInsurances.FooterRow.FindControl("tkrdpStartDateNew")).SelectedDate.Value;
                        DateTime endDate = ((RadDatePicker)grdInsurances.FooterRow.FindControl("tkrdpEndDateNew")).SelectedDate.Value;

                        ProjectCostingSheetAddInsurancesInformation model = new ProjectCostingSheetAddInsurancesInformation(projectCostingSheetAddTDS);
                        model.Insert(0, insuranceCompanyId, rate, false, companyId, startDate, endDate, insurance);

                        Session.Remove("insurancesInformationDummy");
                        insurancesInformation = (ProjectCostingSheetAddTDS.InsurancesInformationDataTable)model.Table;
                        Session["insurancesInformation"] = insurancesInformation;
                        Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                        grdInsurances.DataBind();

                        StepInsurancesInformationProcessGrid();
                    }
                    break;
            }
        }



        protected void grdInsurances_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Validate general data
            Page.Validate("insuranceEdit");
            
            if (Page.IsValid)
            {
                int costingSheetId = (int)e.Keys["CostingSheetID"];
                int insuranceCompanyId = (int)e.Keys["InsuranceCompanyID"];
                int refId = (int)e.Keys["RefID"];

                int companyId = Int32.Parse(hdfCompanyId.Value);
                decimal rate = Decimal.Parse(((TextBox)grdInsurances.Rows[e.RowIndex].Cells[0].FindControl("tbxRateEdit")).Text.Trim());
                DateTime startDate = ((RadDatePicker)grdInsurances.Rows[e.RowIndex].Cells[0].FindControl("tkrdpStartDateEdit")).SelectedDate.Value;
                DateTime endDate = ((RadDatePicker)grdInsurances.Rows[e.RowIndex].Cells[0].FindControl("tkrdpEndDateEdit")).SelectedDate.Value;

                // Update data
                ProjectCostingSheetAddInsurancesInformation model = new ProjectCostingSheetAddInsurancesInformation(projectCostingSheetAddTDS);
                model.Update(costingSheetId, insuranceCompanyId, refId, rate, false, companyId, startDate, endDate);

                // Store dataset
                insurancesInformation = (ProjectCostingSheetAddTDS.InsurancesInformationDataTable)model.Table;
                Session["insurancesInformation"] = insurancesInformation;
                Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                StepInsurancesInformationProcessGrid();
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdInsurances_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Insurances Gridview, if the gridview is edition mode
            if (grdInsurances.EditIndex >= 0)
            {
                grdInsurances.UpdateRow(grdInsurances.EditIndex, true);
            }

            // Delete insurance
            int costingSheetId = (int)e.Keys["CostingSheetID"];
            int insuranceCompanyId = (int)e.Keys["InsuranceCompanyID"];
            int refId = (int)e.Keys["RefID"];

            ProjectCostingSheetAddInsurancesInformation model = new ProjectCostingSheetAddInsurancesInformation(projectCostingSheetAddTDS);
            model.Delete(costingSheetId, insuranceCompanyId, refId);

            // Store dataset
            insurancesInformation = (ProjectCostingSheetAddTDS.InsurancesInformationDataTable)model.Table;
            Session["insurancesInformation"] = insurancesInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            StepInsurancesInformationProcessGrid();
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP7 - INSURANCE INFORMATION - AUXILIAR EVENTS
        //

        protected void grdInsurances_DataBound(object sender, EventArgs e)
        {
            InsurancesInformationEmptyFix(grdInsurances);
        }



        protected void grdInsurances_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            StepInsurancesInformationProcessGrid();
        }



        protected void grdInsurances_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Insurances Gridview, if the gridview is edition mode
            if (grdInsurances.EditIndex >= 0)
            {
                grdInsurances.UpdateRow(grdInsurances.EditIndex, true);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP7 - INSURANCE INFORMATION - METHODS
        //

        private void StepInsurancesInformationIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please verify Insurances information";

            // Load
            ProjectCostingSheetAddInsurancesInformation model = new ProjectCostingSheetAddInsurancesInformation(projectCostingSheetAddTDS);

            if (projectCostingSheetAddTDS.InsurancesInformation.Rows.Count <= 0)
            {
                model.Load(int.Parse(hdfProjectId.Value), tkrdpFrom.SelectedDate.Value, tkrdpTo.SelectedDate.Value, int.Parse(hdfCompanyId.Value));
            }

            // Store tables
            Session.Remove("insurancesInformationDummy");
            insurancesInformation = (ProjectCostingSheetAddTDS.InsurancesInformationDataTable)model.Table;
            Session["insurancesInformation"] = insurancesInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            // Validate grid columns
            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            if (projectGateway.GetCountryID(projectId) == 1) //Canada
            {
                // Insurances Grid
                lblInsurancesTotalCosts.Text = "Total Cost (CAD) : ";
                tbxInsurancesTotalCostsCAD.Visible = true;
                tbxInsurancesTotalCostsUSD.Visible = false;
            }
            else
            {
                // Insurances Grid
                lblInsurancesTotalCosts.Text = "Total Cost (USD) : ";
                tbxInsurancesTotalCostsCAD.Visible = false;
                tbxInsurancesTotalCostsUSD.Visible = true;
            }

            grdInsurances.DataBind();
            StepInsurancesInformationProcessGrid();
        }



        private bool StepInsurancesInformationNext()
        {
            StepInsurancesInformationProcessGrid();

            // Store tables
            Session.Remove("insurancesInformationDummy");
            Session["insurancesInformation"] = insurancesInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;
            return true;
        }



        private bool StepInsurancesInformationPrevious()
        {
            return true;
        }



        private void StepInsurancesInformationProcessGrid()
        {
            decimal totalCostCadLH = 0;
            decimal totalCostUsdLH = 0;

            foreach (ProjectCostingSheetAddTDS.InsurancesInformationRow row in (ProjectCostingSheetAddTDS.InsurancesInformationDataTable)Session["insurancesInformation"])
            {
                if (!row.Deleted)
                {
                    totalCostCadLH = totalCostCadLH + row.Rate;
                    totalCostUsdLH = totalCostUsdLH + row.Rate;
                }
            }

            tbxInsurancesTotalCostsCAD.Text = Decimal.Round(totalCostCadLH, 2).ToString();
            tbxInsurancesTotalCostsUSD.Text = Decimal.Round(totalCostUsdLH, 2).ToString();
        }



        public ProjectCostingSheetAddTDS.InsurancesInformationDataTable GetInsurancesInformation()
        {
            insurancesInformation = (ProjectCostingSheetAddTDS.InsurancesInformationDataTable)Session["insurancesInformationDummy"];

            if (insurancesInformation == null)
            {
                insurancesInformation = (ProjectCostingSheetAddTDS.InsurancesInformationDataTable)Session["insurancesInformation"];
            }

            return insurancesInformation;
        }



        protected void InsurancesInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                ProjectCostingSheetAddTDS.InsurancesInformationDataTable dt = new ProjectCostingSheetAddTDS.InsurancesInformationDataTable();
                dt.AddInsurancesInformationRow(0, 0, 0, 0, false, 0, false, DateTime.Now, DateTime.Now, false, "", "");
                Session["insurancesInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetAddTDS.InsurancesInformationDataTable dt = (ProjectCostingSheetAddTDS.InsurancesInformationDataTable)Session["insurancesInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        public void DummyInsurancesNew(int original_CostingSheetID, int original_InsuranceCompanyID, int original_RefID)
        {
        }



        public void DummyInsurancesNew(int CostingSheetID, int InsuranceCompanyID)
        {
        }



        public void DummyInsurancesNew(int CostingSheetID)
        {
        }

        #endregion

        #region STEP7 - OTHER CATEGORY INFORMATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP7 - OTHER CATEGORY INFORMATION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP7 - OTHER CATEGORY INFORMATION - EVENTS
        //

        protected void grdOtherCategory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Add":
                    // OtherCategory Gridview, if the gridview is edition mode
                    if (grdOtherCategory.EditIndex >= 0)
                    {
                        grdOtherCategory.UpdateRow(grdOtherCategory.EditIndex, true);
                    }

                    // Validate general data
                    Page.Validate("otherCategoryNew");
                    
                    if (Page.IsValid)
                    {
                        int companyId = Int32.Parse(hdfCompanyId.Value);
                        string category = ((DropDownList)grdOtherCategory.FooterRow.FindControl("ddlOtherCategoryNew")).SelectedItem.Text;
                        decimal rate = decimal.Parse(((TextBox)grdOtherCategory.FooterRow.FindControl("tbxRateNew")).Text.Trim());
                        
                        DateTime startDate = ((RadDatePicker)grdOtherCategory.FooterRow.FindControl("tkrdpStartDateNew")).SelectedDate.Value;
                        DateTime endDate = ((RadDatePicker)grdOtherCategory.FooterRow.FindControl("tkrdpEndDateNew")).SelectedDate.Value;

                        ProjectCostingSheetAddOtherCategoryInformation model = new ProjectCostingSheetAddOtherCategoryInformation(projectCostingSheetAddTDS);
                        model.Insert(0, category, rate, false, companyId, startDate, endDate);

                        Session.Remove("otherCategoryInformationDummy");
                        otherCategoryInformation = (ProjectCostingSheetAddTDS.OtherCategoryInformationDataTable)model.Table;
                        Session["otherCategoryInformation"] = otherCategoryInformation;
                        Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                        grdOtherCategory.DataBind();

                        StepOtherCategoryInformationProcessGrid();
                    }
                    break;
            }
        }



        protected void grdOtherCategory_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            // Validate general data
            Page.Validate("bondingEdit");
            
            if (Page.IsValid)
            {
                int costingSheetId = (int)e.Keys["CostingSheetID"];
                string category = (string)e.Keys["Category"];
                int refId = (int)e.Keys["RefID"];

                int companyId = Int32.Parse(hdfCompanyId.Value);
                decimal rate = Decimal.Parse(((TextBox)grdOtherCategory.Rows[e.RowIndex].Cells[0].FindControl("tbxRateEdit")).Text.Trim());
                DateTime startDate = ((RadDatePicker)grdOtherCategory.Rows[e.RowIndex].Cells[0].FindControl("tkrdpStartDateEdit")).SelectedDate.Value;
                DateTime endDate = ((RadDatePicker)grdOtherCategory.Rows[e.RowIndex].Cells[0].FindControl("tkrdpEndDateEdit")).SelectedDate.Value;

                // Update data
                ProjectCostingSheetAddOtherCategoryInformation model = new ProjectCostingSheetAddOtherCategoryInformation(projectCostingSheetAddTDS);
                model.Update(costingSheetId, category, refId, rate, false, companyId, startDate, endDate);

                // Store dataset
                otherCategoryInformation = (ProjectCostingSheetAddTDS.OtherCategoryInformationDataTable)model.Table;
                Session["otherCategoryInformation"] = otherCategoryInformation;
                Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

                StepOtherCategoryInformationProcessGrid();
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void grdOtherCategory_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // OtherCategory Gridview, if the gridview is edition mode
            if (grdOtherCategory.EditIndex >= 0)
            {
                grdOtherCategory.UpdateRow(grdOtherCategory.EditIndex, true);
            }

            // Delete bonding
            int costingSheetId = (int)e.Keys["CostingSheetID"];
            string category = (string)e.Keys["Category"];
            int refId = (int)e.Keys["RefID"];

            ProjectCostingSheetAddOtherCategoryInformation model = new ProjectCostingSheetAddOtherCategoryInformation(projectCostingSheetAddTDS);
            model.Delete(costingSheetId, category, refId);

            // Store dataset
            otherCategoryInformation = (ProjectCostingSheetAddTDS.OtherCategoryInformationDataTable)model.Table;
            Session["otherCategoryInformation"] = otherCategoryInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            StepOtherCategoryInformationProcessGrid();
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP7 - OTHER CATEGORY INFORMATION - AUXILIAR EVENTS
        //

        protected void grdOtherCategory_DataBound(object sender, EventArgs e)
        {
            OtherCategoryInformationEmptyFix(grdOtherCategory);
        }



        protected void grdOtherCategory_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            StepOtherCategoryInformationProcessGrid();
        }



        protected void grdOtherCategory_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // OtherCategory Gridview, if the gridview is edition mode
            if (grdOtherCategory.EditIndex >= 0)
            {
                grdOtherCategory.UpdateRow(grdOtherCategory.EditIndex, true);
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP7 - OTHER CATEGORY INFORMATION - METHODS
        //

        private void StepOtherCategoryInformationIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please verify Other Category information";

            // Load
            ProjectCostingSheetAddOtherCategoryInformation model = new ProjectCostingSheetAddOtherCategoryInformation(projectCostingSheetAddTDS);

            if (projectCostingSheetAddTDS.OtherCategoryInformation.Rows.Count <= 0)
            {
                model.Load(int.Parse(hdfProjectId.Value), tkrdpFrom.SelectedDate.Value, tkrdpTo.SelectedDate.Value, int.Parse(hdfCompanyId.Value));
            }

            // Store tables
            Session.Remove("otherCategoryInformationDummy");
            otherCategoryInformation = (ProjectCostingSheetAddTDS.OtherCategoryInformationDataTable)model.Table;
            Session["otherCategoryInformation"] = otherCategoryInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;

            // Validate grid columns
            int projectId = Int32.Parse(hdfProjectId.Value);
            ProjectGateway projectGateway = new ProjectGateway();
            projectGateway.LoadByProjectId(projectId);

            if (projectGateway.GetCountryID(projectId) == 1) //Canada
            {
                // OtherCategory Grid
                lblOtherCategoryTotalCosts.Text = "Total Cost (CAD) : ";
                tbxOtherCategoryTotalCostsCAD.Visible = true;
                tbxOtherCategoryTotalCostsUSD.Visible = false;
            }
            else
            {
                // OtherCategory Grid
                lblOtherCategoryTotalCosts.Text = "Total Cost (USD) : ";
                tbxOtherCategoryTotalCostsCAD.Visible = false;
                tbxOtherCategoryTotalCostsUSD.Visible = true;
            }

            grdOtherCategory.DataBind();
            StepOtherCategoryInformationProcessGrid();
        }



        private bool StepOtherCategoryInformationNext()
        {
            StepOtherCategoryInformationProcessGrid();

            // Store tables
            Session.Remove("otherCategoryInformationDummy");
            Session["otherCategoryInformation"] = otherCategoryInformation;
            Session["projectCostingSheetAddTDS"] = projectCostingSheetAddTDS;
            return true;
        }



        private bool StepOtherCategoryInformationPrevious()
        {
            return true;
        }



        private void StepOtherCategoryInformationProcessGrid()
        {
            decimal totalCostCadLH = 0;
            decimal totalCostUsdLH = 0;

            foreach (ProjectCostingSheetAddTDS.OtherCategoryInformationRow row in (ProjectCostingSheetAddTDS.OtherCategoryInformationDataTable)Session["otherCategoryInformation"])
            {
                if (!row.Deleted)
                {
                    totalCostCadLH = totalCostCadLH + row.Rate;
                    totalCostUsdLH = totalCostUsdLH + row.Rate;
                }
            }

            tbxOtherCategoryTotalCostsCAD.Text = Decimal.Round(totalCostCadLH, 2).ToString();
            tbxOtherCategoryTotalCostsUSD.Text = Decimal.Round(totalCostUsdLH, 2).ToString();
        }



        public ProjectCostingSheetAddTDS.OtherCategoryInformationDataTable GetOtherCategoryInformation()
        {
            otherCategoryInformation = (ProjectCostingSheetAddTDS.OtherCategoryInformationDataTable)Session["otherCategoryInformationDummy"];

            if (otherCategoryInformation == null)
            {
                otherCategoryInformation = (ProjectCostingSheetAddTDS.OtherCategoryInformationDataTable)Session["otherCategoryInformation"];
            }

            return otherCategoryInformation;
        }



        protected void OtherCategoryInformationEmptyFix(GridView grdView)
        {
            if (grdView.Rows.Count == 0)
            {
                ProjectCostingSheetAddTDS.OtherCategoryInformationDataTable dt = new ProjectCostingSheetAddTDS.OtherCategoryInformationDataTable();
                dt.AddOtherCategoryInformationRow(0, "", 0, 0, false, 0, false, DateTime.Now, DateTime.Now, false, "");
                Session["otherCategoryInformationDummy"] = dt;

                grdView.DataBind();
            }

            // Normally executes at all postbacks
            if (grdView.Rows.Count == 1)
            {
                ProjectCostingSheetAddTDS.OtherCategoryInformationDataTable dt = (ProjectCostingSheetAddTDS.OtherCategoryInformationDataTable)Session["otherCategoryInformationDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdView.Rows[0].Visible = false;
                    grdView.Rows[0].Controls.Clear();
                }
            }
        }



        public void DummyOtherCategoryNew(int original_CostingSheetID, string original_Category, int original_RefID)
        {
        }



        public void DummyOtherCategoryNew(int CostingSheetID, string Category)
        {
        }



        public void DummyOtherCategoryNew(int CostingSheetID)
        {
        }

        #endregion


                   
    }
}