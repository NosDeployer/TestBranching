using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.Resources.Hotels;
using LiquiForce.LFSLive.DA.Resources.Hotels;
using LiquiForce.LFSLive.BL.Resources.InsuranceCompanies;
using LiquiForce.LFSLive.DA.Resources.InsuranceCompanies;
using LiquiForce.LFSLive.BL.Resources.BondingCompanies;
using LiquiForce.LFSLive.DA.Resources.BondingCompanies;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.BL.Resources.Subcontractors;
using LiquiForce.LFSLive.DA.Resources.Subcontractors;
using LiquiForce.LFSLive.Server;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.LabourHours.Common
{
    /// <summary>
    /// category_items_add
    /// </summary>
    public partial class category_items_add : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected BondingCompaniesAddTDS bondingCompaniesAddTDS;
        protected BondingCompaniesAddTDS.BondingCompaniesDataTable bondingCompanies;        
        protected HotelsAddTDS hotelsAddTDS;
        protected HotelsAddTDS.HotelsDataTable hotels;
        protected InsuranceCompaniesAddTDS insuranceCompaniesAddTDS;
        protected InsuranceCompaniesAddTDS.InsuranceCompaniesDataTable insuranceCompanies;
        protected SubcontractorsAddTDS subcontractorsAddTDS;
        protected SubcontractorsAddTDS.SubcontractorsDataTable subcontractors;





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
                if (!(Convert.ToBoolean(Session["sgLFS_RESOURCES_HOTELS_ADD"])) || !(Convert.ToBoolean(Session["sgLFS_RESOURCES_BONDINGCOMPANIES_ADD"])) || !(Convert.ToBoolean(Session["sgLFS_RESOURCES_INSURANCECOMPANIES_ADD"])) || !(Convert.ToBoolean(Session["sgLFS_RESOURCES_SUBCONTRACTORS_ADD"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in category_items_add.aspx");
                }
                

                // Tag Page                
                hdfCompanyIdForSubcontractors.Value = Session["companyID"].ToString();
                hdfCompanyIdForHotels.Value = Session["companyID"].ToString();
                hdfCompanyIdForBondingCompanies.Value = Session["companyID"].ToString();
                hdfCompanyIdForInsuranceCompanies.Value = Session["companyID"].ToString(); 
               
                // Store datasets
                subcontractorsAddTDS = new SubcontractorsAddTDS();
                Session["subcontractorsAddTDS"] = subcontractorsAddTDS;
                Session["subcontractors"] = subcontractorsAddTDS.Subcontractors;
                hotelsAddTDS = new HotelsAddTDS();
                Session["hotelsAddTDS"] = hotelsAddTDS;
                Session["hotels"] = hotelsAddTDS.Hotels;
                bondingCompaniesAddTDS = new BondingCompaniesAddTDS();
                Session["bondingCompaniesAddTDS"] = bondingCompaniesAddTDS;
                Session["bondingCompanies"] = bondingCompaniesAddTDS.BondingCompanies;
                insuranceCompaniesAddTDS = new InsuranceCompaniesAddTDS();
                Session["insuranceCompaniesAddTDS"] = insuranceCompaniesAddTDS;
                Session["insuranceCompanies"] = insuranceCompaniesAddTDS.InsuranceCompanies;                

                StoreNavigatorState();

                // StepSection1In
                wzCategories.ActiveStepIndex = 0;
                StepBeginIn();
            }
            else
            {
                // Restore datasets
                subcontractorsAddTDS = (SubcontractorsAddTDS)Session["subcontractorsAddTDS"];
                subcontractors = subcontractorsAddTDS.Subcontractors;
                hotelsAddTDS = (HotelsAddTDS)Session["hotelsAddTDS"];
                hotels = hotelsAddTDS.Hotels;
                bondingCompaniesAddTDS = (BondingCompaniesAddTDS)Session["bondingCompaniesAddTDS"];
                bondingCompanies = bondingCompaniesAddTDS.BondingCompanies;
                insuranceCompaniesAddTDS = (InsuranceCompaniesAddTDS)Session["insuranceCompaniesAddTDS"];
                insuranceCompanies = insuranceCompaniesAddTDS.InsuranceCompanies;
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
                switch (wzCategories.ActiveStep.Name)
                {
                    case "Begin":
                        StepBeginIn();
                        break;

                    case "Subcontractors":
                        StepSubcontractorsIn();
                        break;                   

                    case "Hotels":
                        StepHotelIn();
                        break;

                    case "BondingCompanies":
                        StepBondingCompaniesIn();
                        break;

                    case "InsuranceCompanies":
                        StepInsuranceCompaniesIn();
                        break;                 

                    case "Summary":
                        StepSummaryIn();
                        break;

                    default:
                        throw new Exception("The option for " + wzCategories.ActiveStep.Name + " step in project_costing_sheets_add.Wizard_ActiveStepChanged function does not exist");
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzCategories.ActiveStep.Name)
            {
                case "Begin":
                    // Standard: Code for guider step
                    e.Cancel = !StepBeginNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Begin";
                        if (cbxSubcontractor.Checked)
                        {                            
                            wzCategories.ActiveStepIndex = wzCategories.WizardSteps.IndexOf(StepSubcontractors);                                                       
                        }
                        else
                        {
                            if (cbxHotels.Checked)
                            {
                                wzCategories.ActiveStepIndex = wzCategories.WizardSteps.IndexOf(StepHotel);
                            }
                            else
                            {
                                if (cbxBondingCompanies.Checked)
                                {
                                    wzCategories.ActiveStepIndex = wzCategories.WizardSteps.IndexOf(StepBondingCompanies);
                                }
                                else
                                {
                                    if (cbxInsuranceCompanies.Checked)
                                    {
                                        wzCategories.ActiveStepIndex = wzCategories.WizardSteps.IndexOf(StepInsuranceCompanies);
                                    }
                                    else
                                    {                                        
                                        wzCategories.ActiveStepIndex = wzCategories.WizardSteps.IndexOf(StepSummary);                                        
                                    }
                                }
                            }
                        }
                    }
                    break;

                case "Subcontractors":
                    // Standard: Code for normal step
                    e.Cancel = !StepSubcontractorsNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Subcontractors";
                        if (cbxHotels.Checked)
                        {
                            wzCategories.ActiveStepIndex = wzCategories.WizardSteps.IndexOf(StepHotel);
                        }
                        else
                        {
                            if (cbxBondingCompanies.Checked)
                            {
                                wzCategories.ActiveStepIndex = wzCategories.WizardSteps.IndexOf(StepBondingCompanies);
                            }
                            else
                            {
                                if (cbxInsuranceCompanies.Checked)
                                {
                                    wzCategories.ActiveStepIndex = wzCategories.WizardSteps.IndexOf(StepInsuranceCompanies);
                                }
                                else
                                {                                    
                                    wzCategories.ActiveStepIndex = wzCategories.WizardSteps.IndexOf(StepSummary);                                   
                                }
                            }
                        }
                    }
                    break;
               
                case "Hotels":
                    e.Cancel = !StepHotelNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Hotels";
                        if (cbxBondingCompanies.Checked)
                        {
                            wzCategories.ActiveStepIndex = wzCategories.WizardSteps.IndexOf(StepBondingCompanies);
                        }
                        else
                        {
                            if (cbxInsuranceCompanies.Checked)
                            {
                                wzCategories.ActiveStepIndex = wzCategories.WizardSteps.IndexOf(StepInsuranceCompanies);
                            }
                            else
                            {                                
                                wzCategories.ActiveStepIndex = wzCategories.WizardSteps.IndexOf(StepSummary);                                
                            }
                        }
                    }
                    break;

                case "BondingCompanies":
                    e.Cancel = !StepBondingCompaniesNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "BondingCompanies";
                        if (cbxInsuranceCompanies.Checked)
                        {
                            wzCategories.ActiveStepIndex = wzCategories.WizardSteps.IndexOf(StepInsuranceCompanies);
                        }
                        else
                        {                            
                            wzCategories.ActiveStepIndex = wzCategories.WizardSteps.IndexOf(StepSummary);                            
                        }
                    }
                    break;

                case "InsuranceCompanies":
                    e.Cancel = !StepInsuranceCompaniesNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "InsuranceCompanies";                        
                        wzCategories.ActiveStepIndex = wzCategories.WizardSteps.IndexOf(StepSummary);                        
                    }
                    break;              

                default:
                    throw new Exception("The option for " + wzCategories.ActiveStep.Name + " step in category_items_add.Wizard_NextButtonClick function does not exist");
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzCategories.ActiveStep.Name)
            {
                case "Subcontractors":
                    e.Cancel = !StepSubcontractorsPrevious();
                    break;

                case "Hotels":
                    e.Cancel = !StepHotelPrevious();
                    break;

                case "BondingCompanies":
                    e.Cancel = !StepBondingCompaniesPrevious();
                    break;

                case "InsuranceCompanies":
                    e.Cancel = !StepInsuranceCompaniesPrevious();
                    break;               

                case "Summary":
                    e.Cancel = !StepSummaryPrevious();
                    break;

                default:
                    throw new Exception("The option for " + wzCategories.ActiveStep.Name + " step in category_items_add.Wizard_PreviousButtonClick function does not exist");
            }
            if (!e.Cancel)
            {
                ViewState["StepFrom"] = wzCategories.ActiveStep.Name;
            }
        }



        protected void Wizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {            
            e.Cancel = (!StepSummaryFinish());

            if (!e.Cancel)
            {
                string script = "<script language='javascript'>";
                script += "{ window.close(); }";
                script += "</script>";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Cancel", script, false);
            }
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
        }



        private bool StepBeginNext()
        {
            if ((cbxSubcontractor.Checked) || (cbxHotels.Checked) || (cbxInsuranceCompanies.Checked) || (cbxBondingCompanies.Checked))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        #endregion






        #region STEP2 - SUBCONTRACTORS

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP2 - SUBCONTRACTORS
        //

       
        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - SUBCONTRACTORS - AUXILIAR EVENTS
        //            

        protected void ddlCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["selectedCompaniesId"] = ddlCompanies.SelectedValue;
            lblUserErrorMessage.Visible = false;
            lblUserErrorMessage.DataBind();
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - SUBCONTRACTORS - PRIVATE METHODS
        //

        private void StepSubcontractorsIn()
        {
            // Set instruction
            Label title = (Label)this.Master.FindControl("lblInstruction");
            title.Text = "Please select a subcontractor";
            lblUserErrorMessage.Visible = false;                     
        }



        private bool StepSubcontractorsPrevious()
        {
            return true;
        }



        private bool StepSubcontractorsNext()
        {
            int selectedCompaniesId = Int32.Parse(ddlCompanies.SelectedValue);
            int companyIdForSubcontractors = Int32.Parse(hdfCompanyIdForSubcontractors.Value);

            SubcontractorsAddSubcontractorsGateway subcontractorsAddSubcontractorsGateway = new SubcontractorsAddSubcontractorsGateway();

            if (subcontractorsAddSubcontractorsGateway.IsInLfs(selectedCompaniesId, companyIdForSubcontractors))
            {
                lblUserErrorMessage.Visible = true;                
            }
            else
            {
                lblUserErrorMessage.Visible = false;

                // Get name
                int companiesId = Int32.Parse(ddlCompanies.SelectedValue);
                DateTime date = DateTime.Now;

                // Insert subcontractor
                CompaniesGatewayRAF companiesGatewayRAF = new CompaniesGatewayRAF();
                companiesGatewayRAF.LoadByCompaniesId(companiesId, companyIdForSubcontractors);
                hdfNameForSubcontractors.Value = GetCompanyName(companiesId, companyIdForSubcontractors);

                SubcontractorsAddSubcontractors model = new SubcontractorsAddSubcontractors(subcontractorsAddTDS);
                model.Insert(companiesId, date, hdfNameForSubcontractors.Value, true, companiesGatewayRAF.GetActive(companiesId), false, companyIdForSubcontractors);

                // ... Store tables
                Session["subcontractorsAddTDS"] = subcontractorsAddTDS;
            }
            return true;
        }       

        #endregion       






        #region STEP3 - HOTEL COST

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP3 - HOTEL COST
        //       

        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - HOTEL COST - AUXILIAR EVENTS
        //                  

        protected void ddlCompaniesForHotels_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["selectedCompaniesId"] = ddlCompaniesForHotels.SelectedValue;
            lblUserErrorMessageForHotels.Visible = false;
            lblUserErrorMessageForHotels.DataBind();
        }
              
       




        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - HOTEL COST - PRIVATE METHODS
        //

        private void StepHotelIn()
        {
            // Set instruction
            Label title = (Label)this.Master.FindControl("lblInstruction");
            title.Text = "Please select a Hotel.";
            lblUserErrorMessageForHotels.Visible = false;
        }



        private bool StepHotelPrevious()
        {
            return true;
        }



        private bool StepHotelNext()
        {
            int selectedCompaniesIdForHotels = Int32.Parse(ddlCompaniesForHotels.SelectedValue);
            int companyIdForHotels = Int32.Parse(hdfCompanyIdForHotels.Value);

            HotelsAddHotelsGateway hotelsAddHotelsGateway = new HotelsAddHotelsGateway();

            if (hotelsAddHotelsGateway.IsInLfs(selectedCompaniesIdForHotels, companyIdForHotels))
            {
                lblUserErrorMessageForHotels.Visible = true;                
            }
            else
            {
                lblUserErrorMessageForHotels.Visible = false;

                // Get name
                int companiesIdForHotels = Int32.Parse(ddlCompaniesForHotels.SelectedValue);
                DateTime dateForHotels = DateTime.Now;

                // Insert subcontractor                
                hdfNameForHotels.Value = GetCompanyName(companiesIdForHotels, companyIdForHotels);

                HotelsAddHotels model = new HotelsAddHotels(hotelsAddTDS);
                model.Insert(companiesIdForHotels, dateForHotels, hdfNameForHotels.Value, false, companyIdForHotels);

                // ... Store tables
                Session["hotelsAddTDS"] = hotelsAddTDS;
            }
            return true;
        }


        #endregion






        #region STEP4 - BONDING COMPANIES COST

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP4 - BONDING COMPANIES COST
        //        

        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - BONDING COMPANIES COST - AUXILIAR EVENTS
        //        

        protected void ddlCompaniesForBondingCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["selectedCompaniesIdForBondingCompanies"] = ddlCompaniesForBondingCompanies.SelectedValue;
            lblUserErrorMessageForBondingCompanies.Visible = false;
            lblUserErrorMessageForBondingCompanies.DataBind();
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - BONDING COMPANIES COST - PRIVATE METHODS
        //

        private void StepBondingCompaniesIn()
        {
            // Set instruction
            Label title = (Label)this.Master.FindControl("lblInstruction");
            title.Text = "Please select a Bonding Company.";
            lblUserErrorMessageForBondingCompanies.Visible = false;
        }



        private bool StepBondingCompaniesPrevious()
        {
            return true;
        }



        private bool StepBondingCompaniesNext()
        {
            int selectedCompaniesIdForBondingCompanies = Int32.Parse(ddlCompaniesForBondingCompanies.SelectedValue);
            int companyIdForBondingCompanies = Int32.Parse(hdfCompanyIdForBondingCompanies.Value);

            BondingCompaniesAddBondingCompaniesGateway bondingCompaniesAddBondingCompaniesGateway = new BondingCompaniesAddBondingCompaniesGateway();

            if (bondingCompaniesAddBondingCompaniesGateway.IsInLfs(selectedCompaniesIdForBondingCompanies, companyIdForBondingCompanies))
            {
                lblUserErrorMessageForBondingCompanies.Visible = true;                
            }
            else
            {
                lblUserErrorMessageForBondingCompanies.Visible = false;

                // Get name
                int companiesIdForBondingCompanies = Int32.Parse(ddlCompaniesForBondingCompanies.SelectedValue);
                DateTime dateForBondingCompanies = DateTime.Now;

                // Insert subcontractor
                hdfNameForBondingCompanies.Value = GetCompanyName(companiesIdForBondingCompanies, companyIdForBondingCompanies);

                BondingCompaniesAddBondingCompanies model = new BondingCompaniesAddBondingCompanies(bondingCompaniesAddTDS);
                model.Insert(companiesIdForBondingCompanies, dateForBondingCompanies, hdfNameForBondingCompanies.Value, false, companyIdForBondingCompanies);

                // ... Store tables
                Session["bondingCompaniesAddTDS"] = bondingCompaniesAddTDS;
            }
            return true;
        }
        #endregion






        #region STEP5 - INSURANCE COMPANIES

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP5 - INSURANCE COMPANIES COST
        //
     
        // ////////////////////////////////////////////////////////////////////////
        // STEP5 - INSURANCE COMPANIES COST - AUXILIAR EVENTS
        //

        protected void ddlCompaniesrForInsuranceCompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["selectedCompaniesIdForInsuranceCompanies"] = ddlCompaniesForInsuranceCompanies.SelectedValue;
            lblUserErrorMessageForInsuranceCompanies.Visible = false;
            lblUserErrorMessageForInsuranceCompanies.DataBind();
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP5 - INSURANCE COMPANIES - PRIVATE METHODS
        //

        private void StepInsuranceCompaniesIn()
        {
            // Set instruction
            Label title = (Label)this.Master.FindControl("lblInstruction");
            title.Text = "Please select an Insurance company.";
            lblUserErrorMessageForInsuranceCompanies.Visible = false;
        }



        private bool StepInsuranceCompaniesPrevious()
        {
            return true;
        }



        private bool StepInsuranceCompaniesNext()
        {
            int selectedCompaniesIdForInsuranceCompanies = Int32.Parse(ddlCompaniesForInsuranceCompanies.SelectedValue);
            int companyIdForInsuranceCompanies = Int32.Parse(hdfCompanyIdForInsuranceCompanies.Value);

            InsuranceCompaniesAddInsuranceCompaniesGateway insuranceCompaniesAddInsuranceCompaniesGateway = new InsuranceCompaniesAddInsuranceCompaniesGateway();

            if (insuranceCompaniesAddInsuranceCompaniesGateway.IsInLfs(selectedCompaniesIdForInsuranceCompanies, companyIdForInsuranceCompanies))
            {
                lblUserErrorMessageForInsuranceCompanies.Visible = true;                
            }
            else
            {
                lblUserErrorMessageForInsuranceCompanies.Visible = false;

                // Get name
                int companiesIdForInsuranceCompanies = Int32.Parse(ddlCompaniesForInsuranceCompanies.SelectedValue);
                DateTime dateForInsuranceCompanies = DateTime.Now;

                // Insert subcontractor
                hdfNameForInsuranceCompanies.Value = GetCompanyName(companiesIdForInsuranceCompanies, companyIdForInsuranceCompanies);

                InsuranceCompaniesAddInsuranceCompanies model = new InsuranceCompaniesAddInsuranceCompanies(insuranceCompaniesAddTDS);
                model.Insert(companiesIdForInsuranceCompanies, dateForInsuranceCompanies, hdfNameForInsuranceCompanies.Value, false, companyIdForInsuranceCompanies);

                // ... Store tables
                Session["insuranceCompaniesAddTDS"] = insuranceCompaniesAddTDS;
            }
            return true;

        }



        #endregion






        #region STEP7 - SUMMARY

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP7 - SUMMARY
        //


        // ////////////////////////////////////////////////////////////////////////
        // STEP7 - SUMMARY - METHODS
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
            UpdateDatabase();
            return true;
        }

        #endregion






        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set wizard title
            Label title = (Label)this.Master.FindControl("lblTitle");
            title.Text = "Add Categories ";
        }



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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./category_items_add.js");
        }



        private void UpdateDatabase()
        {
            DB.Open();
            DB.BeginTransaction();
            try
            {
                // For Subcontractors
                if ((cbxSubcontractor.Checked) && (hdfNameForSubcontractors .Value !=""))               
                {
                    int companyIdForSubcontractors = Int32.Parse(hdfCompanyIdForSubcontractors.Value);

                    SubcontractorsAddSubcontractors subcontractorsAddSubcontractors = new SubcontractorsAddSubcontractors(subcontractorsAddTDS);
                    subcontractorsAddSubcontractors.Save(companyIdForSubcontractors);                    

                    // Store datasets
                    subcontractorsAddTDS.AcceptChanges();
                    Session["subcontractorsAddTDS"] = subcontractorsAddTDS;
                }

                // For Hotels
                if ((cbxHotels.Checked) && (hdfNameForHotels .Value !=""))               
                {
                    int companyIdForHotels = Int32.Parse(hdfCompanyIdForHotels.Value);

                    HotelsAddHotels hotelsAddHotels = new HotelsAddHotels(hotelsAddTDS);
                    hotelsAddHotels.Save(companyIdForHotels);                    

                    // Store datasets
                    hotelsAddTDS.AcceptChanges();
                    Session["hotelsAddTDS"] = hotelsAddTDS;
                }

                // For bonding Companies
                if ((cbxBondingCompanies.Checked) && (hdfNameForBondingCompanies .Value !=""))               
                {
                    int companyIdForBondingCompanies = Int32.Parse(hdfCompanyIdForBondingCompanies.Value);

                    BondingCompaniesAddBondingCompanies bondingCompaniesAddBondingCompanies = new BondingCompaniesAddBondingCompanies(bondingCompaniesAddTDS);
                    bondingCompaniesAddBondingCompanies.Save(companyIdForBondingCompanies);                    

                    // Store datasets
                    bondingCompaniesAddTDS.AcceptChanges();
                    Session["bondingCompaniesAddTDS"] = bondingCompaniesAddTDS;
                }

                // For insurance Companies
                if ((cbxInsuranceCompanies.Checked) && (hdfNameForInsuranceCompanies .Value !=""))               
                {
                    int companyIdForInsuranceCompanies = Int32.Parse(hdfCompanyIdForInsuranceCompanies.Value);

                    InsuranceCompaniesAddInsuranceCompanies insuranceCompaniesAddInsuranceCompanies = new InsuranceCompaniesAddInsuranceCompanies(insuranceCompaniesAddTDS);
                    insuranceCompaniesAddInsuranceCompanies.Save(companyIdForInsuranceCompanies);                    

                    // Store datasets
                    insuranceCompaniesAddTDS.AcceptChanges();
                    Session["insuranceCompaniesAddTDS"] = insuranceCompaniesAddTDS;
                }
                
                DB.CommitTransaction();
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private string GetSummary()
        {
            string summary = "";                       
            if (cbxSubcontractor.Checked)
            {
                if (hdfNameForSubcontractors.Value == "")
                {
                    int companiesId = Int32.Parse(ddlCompanies.SelectedValue);
                    int companyId = Int32.Parse(hdfCompanyIdForSubcontractors.Value);
                    summary = summary + "New Subcontractor Name: " + GetCompanyName(companiesId, companyId) + " Is already registered in LFS Live. \n\n";
                }
                else
                {
                    summary = summary + "New Subcontractor Name: " + hdfNameForSubcontractors.Value + "\n\n ";
                }
            }

            if (cbxHotels.Checked)
            {      
                if (hdfNameForHotels.Value =="")
                {
                    int companiesIdForHotels = Int32.Parse(ddlCompaniesForHotels.SelectedValue);
                    int companyIdForHotels = Int32.Parse(hdfCompanyIdForHotels.Value);
                    summary = summary + "New Subcontractor Name: " + GetCompanyName(companiesIdForHotels, companyIdForHotels) + " Is already registered in LFS Live. \n\n";
                }
                else
                {
                    summary = summary + "New Hotel Name: " + hdfNameForHotels.Value + "\n\n";                
                }
            }        

            if (cbxBondingCompanies.Checked)
            {    
                if (hdfNameForBondingCompanies .Value =="")
                {
                    int companiesIdForBondingCompanies = Int32.Parse(ddlCompaniesForBondingCompanies.SelectedValue);
                    int companyIdForBondingCompanies = Int32.Parse(hdfCompanyIdForBondingCompanies.Value);
                    summary = summary + "New Bonding Companies Name: " + GetCompanyName(companiesIdForBondingCompanies, companyIdForBondingCompanies) + " Is already registered in LFS Live. \n\n";
                }
                else
                {
                    summary = summary + "New Bonding Company Name: " + hdfNameForBondingCompanies.Value + "\n\n";                
                }
            }

            if (cbxInsuranceCompanies.Checked)
            {    
                if (hdfNameForInsuranceCompanies.Value =="")
                {
                    int companiesIdForInsuranceCompanies = Int32.Parse(ddlCompaniesForInsuranceCompanies.SelectedValue);
                    int companyIdForInsuranceCompanies = Int32.Parse(hdfCompanyIdForInsuranceCompanies.Value);
                    summary = summary + "New Insurance Name: " + GetCompanyName(companiesIdForInsuranceCompanies, companyIdForInsuranceCompanies) + " Is already registered in LFS Live. \n\n";
                }
                else
                {
                    summary = summary + "New Insurance Company Name: " + hdfNameForInsuranceCompanies.Value + "\n\n";                
                }
            }           

            return summary;
        }



        private void StoreNavigatorState()
        {
            ViewState["navigatorState"] = "&search_ddlClient=" + Request.QueryString["search_ddlClient"] + "&search_ddlProject=" + Request.QueryString["search_ddlProject"] + "&search_ddlSubcontractor=" + Request.QueryString["search_ddlSubcontractor"] + "&search_ddlHotels=" + Request.QueryString["search_ddlHotels"] + "&search_ddlInsurance=" + Request.QueryString["search_ddlInsurance"] + "&search_ddlBonding=" + Request.QueryString["search_ddlBonding"] + "&search_sort_by=" + Request.QueryString["search_sort_by"] + "&search_tkrdpStartDate=" + Request.QueryString["search_tkrdpStartDate"] + "&search_tkrdpEndDate=" + Request.QueryString["search_tkrdpEndDate"] + "&search_cbxFilterByDateSelected=" + Request.QueryString["search_cbxFilterByDateSelected"] + "&search_category=" + Request.QueryString["search_category"] + "&search_textForSearch=" + Request.QueryString["search_textForSearch"];
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private string GetCompanyName(int companiesId, int companyId)
        {
            string companyName = "";

            CompaniesGatewayRAF companiesGatewayRAF = new CompaniesGatewayRAF();
            companiesGatewayRAF.LoadByCompaniesId(companiesId, companyId);

            companyName = companiesGatewayRAF.GetName(companiesId);

            return companyName;
        }






    }
}