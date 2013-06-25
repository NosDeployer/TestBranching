using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.Company.Organization;
using LiquiForce.LFSLive.BL.FleetManagement.Categories;
using LiquiForce.LFSLive.BL.FleetManagement.Common;
using LiquiForce.LFSLive.BL.FleetManagement.CompanyLevels;
using LiquiForce.LFSLive.BL.FleetManagement.Units;
using LiquiForce.LFSLive.DA.FleetManagement.Categories;
using LiquiForce.LFSLive.DA.FleetManagement.CompanyLevels;
using LiquiForce.LFSLive.DA.FleetManagement.Units;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.Tools;
using Telerik.Web.UI;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.Units
{
    /// <summary>
    /// units_add
    /// </summary>
    public partial class units_add : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //
        protected UnitsAddTDS unitsAddTDS;
        protected UnitsAddTDS.UnitsAddNewDataTable unitsAddNew;
        protected UnitsAddTDS.UnitsChecklistRulesTempDataTable unitsChecklistRulesTempForAdd;
        protected CategoriesTDS categoriesTDS;
        protected CompanyLevelsTDS companyLevelsTDS;
        protected ArrayList arrayCategoriesSelected;
        protected ArrayList arrayCompanyLevelsSelected;






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
                if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_UNITS_ADD"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null)
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in units_add.aspx");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                hdfUpdate.Value = "no";

                // ... Remove sessions
                Session.Remove("arrayCategoriesSelected");
                Session.Remove("arrayCompanyLevelsSelected");
                Session.Remove("unitsAddNew");
                Session.Remove("unitsChecklistRulesTempForAdd");
                Session.Remove("unitsChecklistRulesTempForAddDummy");
                Session.Remove("arrayCategoriesSelectedChanged");
                Session.Remove("arrayCompanyLevelsSelectedChanged");

                // Initialize viewstate variables
                ViewState["StepFrom"] = "Out";
                                
                // ... Initialize tables
                unitsAddTDS = new UnitsAddTDS();
                arrayCategoriesSelected = new ArrayList();
                arrayCompanyLevelsSelected = new ArrayList();
                unitsAddNew = new UnitsAddTDS.UnitsAddNewDataTable();
                unitsChecklistRulesTempForAdd = new UnitsAddTDS.UnitsChecklistRulesTempDataTable();

                // ... Store arrays
                Session["arrayCategoriesSelected"] = arrayCategoriesSelected;
                Session["arrayCompanyLevelsSelected"] = arrayCompanyLevelsSelected;
                Session["arrayCategoriesSelectedChanged"] = false;
                Session["arrayCompanyLevelsSelectedChanged"] = false;

                // ... Store tables
                Session["unitsAddTDS"] = unitsAddTDS;
                Session["unitsAddNew"] = unitsAddNew;
                Session["unitsChecklistRulesTempForAdd"] = unitsChecklistRulesTempForAdd;                

                // ... For Categories
                categoriesTDS = new CategoriesTDS();
                Session["categoriesTDSForUnitsAdd"] = categoriesTDS;
                
                // .. For Company Levels
                companyLevelsTDS = new CompanyLevelsTDS();
                CompanyLevel companyLevel = new CompanyLevel(companyLevelsTDS);
                companyLevel.Load(int.Parse(hdfCompanyId.Value));
                GetNodeForCompanyLevels(tvCompanyLevelsRoot.Nodes, 0);
                                
                // StepTypeIn
                wzUnitAdd.ActiveStepIndex = 0;
                StepTypeIn();
            }
            else
            {
                // Restore arrays
                arrayCategoriesSelected = (ArrayList)Session["arrayCategoriesSelected"];
                arrayCompanyLevelsSelected = (ArrayList)Session["arrayCompanyLevelsSelected"];
                
                // Restore tables
                categoriesTDS = (CategoriesTDS)Session["categoriesTDSForUnitsAdd"];
                unitsAddTDS = (UnitsAddTDS)Session["unitsAddTDS"];
                unitsAddNew = (UnitsAddTDS.UnitsAddNewDataTable)Session["unitsAddNew"];
                unitsChecklistRulesTempForAdd = (UnitsAddTDS.UnitsChecklistRulesTempDataTable)Session["unitsChecklistRulesTempForAdd"];
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
                switch (wzUnitAdd.ActiveStep.Name)
                {
                    case "Type":
                        StepTypeIn();
                        break;

                    case "General Information":
                        StepGeneralInformationIn();
                        break;

                    case "Vehicle Information":
                        StepVehicleInformationIn();
                        break;

                    case "Checklist Rules Information":
                        StepChecklistRulesInformationIn();
                        break;

                    case "Summary":
                        StepSummaryIn();
                        break;

                    case "Final Step":
                        StepFinalStepIn();
                        wzUnitAdd.ActiveStepIndex = wzUnitAdd.WizardSteps.IndexOf(StepFinalStep);
                        break;

                    default:
                        throw new Exception("Not exist the option for " + wzUnitAdd.ActiveStep.Name + " step in units_add.Wizard_ActiveStepChanged function");
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzUnitAdd.ActiveStep.Name)
            {
                case "Type":
                    e.Cancel = !StepTypeNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Type";
                    }
                    break;

                case "General Information":
                    e.Cancel = !StepGeneralInformationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "General Information";
                                                
                        if (rbtnVehicle.Checked)
                        {
                            wzUnitAdd.ActiveStepIndex = wzUnitAdd.WizardSteps.IndexOf(StepVehicleInformation);
                        }
                        else
                        {
                            wzUnitAdd.ActiveStepIndex = wzUnitAdd.WizardSteps.IndexOf(StepChecklistRulesInformation);
                        }
                    }
                    break;

                case "Vehicle Information":
                    e.Cancel = !StepVehicleInformationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Vehicle Information";
                    }
                    break;

                case "Checklist Rules Information":
                    e.Cancel = !StepChecklistRulesInformationNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Checklist Rules Information";
                    }
                    break;               

                default:
                    throw new Exception("Not exists the option for " + wzUnitAdd.ActiveStep.Name + " step in units_add.Wizard_NextButtonClick function");
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzUnitAdd.ActiveStep.Name)
            {
                case "General Information":
                    e.Cancel = !StepGeneralInformationPrevious();
                    break;

                case "Vehicle Information":
                    e.Cancel = !StepVehicleInformationPrevious();
                    break;

                case "Checklist Rules Information":
                    e.Cancel = !StepChecklistRulesInformationPrevious();
                    break;

                case "Summary":
                    e.Cancel = !StepSummaryPrevious();
                    break;

                default:
                    throw new Exception("Not exists the option for " + wzUnitAdd.ActiveStep.Name + " step in units_add.Wizard_PreviousButtonClick function");
            }
            if (!e.Cancel)
            {
                ViewState["StepFrom"] = wzUnitAdd.ActiveStep.Name;
            }
        }



        protected void Wizard_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            e.Cancel = !StepSummaryFinish();
        }



        protected void Wizard_CancelButtonClick(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'> { window.close();}</script>");
        }

        #endregion






        #region STEP1 - TYPE

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP1 - TYPE
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - TYPE - METHODS
        //

        private void StepTypeIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please select a unit type";
        }



        private bool StepTypeNext()
        {
            Category category = new Category(categoriesTDS);

            if (rbtnVehicle.Checked)
            {
                category.LoadByUnitType("Vehicle", int.Parse(hdfCompanyId.Value));
            }
            else
            {
                category.LoadByUnitType("Equipment", int.Parse(hdfCompanyId.Value));
            }

            Session["categoriesTDSForUnitsAdd"] = categoriesTDS;

            tvCategoriesRoot.Nodes.Clear();
            GetNodeForCategory(tvCategoriesRoot.Nodes, 0);
            
            return true;
        }



        #endregion






        #region STEP2 - GENERAL INFORMATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP2 - GENERAL INFORMATION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - GENERAL INFORMATION - AUXILIAR EVENTS
        //

        protected void cvForDateRange_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // For dates before 1900
            string[] date = (args.Value.Trim()).Split('/');

            if (((Validator.IsValidDate(args.Value.Trim())) && (Int32.Parse(date[2]) >= 1900)) || ((args.Value.Trim().Length == 4) && (Validator.IsValidInt32(args.Value.Trim())) && (Int32.Parse(args.Value.Trim()) >= 1900)) || (args.Value.Trim() == "%") || (args.Value.Trim() == ""))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }



        protected void cvCategories_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;

            ArrayList arrayTemp = new ArrayList();
            arrayCategoriesSelected = (ArrayList)Session["arrayCategoriesSelected"];
            arrayTemp = (ArrayList)arrayCategoriesSelected.Clone();
            Session["arrayCategoriesSelectedChanged"] = false;

            arrayCategoriesSelected.Clear();

            foreach (TreeNode nodes in tvCategoriesRoot.Nodes)
            {
                GetCategoriesSelected(nodes);
            }

            if (tvCategoriesRoot.Nodes.Count > 0)
            {
                if (arrayCategoriesSelected.Count > 0)
                {
                    args.IsValid = true;
                }
                else
                {
                    cvCategories.ErrorMessage = "You must select at least one category";
                }
            }
            else
            {
                cvCategories.ErrorMessage = "There are no categories available. Contact your system administrator";
            }

            if (args.IsValid)
            {
                if (!CompareArrayList(arrayTemp, arrayCategoriesSelected))
                {
                    Session["arrayCategoriesSelectedChanged"] = true;
                }
            }

            Session["arrayCategoriesSelected"] = arrayCategoriesSelected;
        }



        protected void cvCompanyLevels_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;

            ArrayList arrayTemp = new ArrayList();
            arrayCompanyLevelsSelected = (ArrayList)Session["arrayCompanyLevelsSelected"];
            arrayTemp = (ArrayList)arrayCompanyLevelsSelected.Clone();
            Session["arrayCompanyLevelsSelectedChanged"] = false;

            arrayCompanyLevelsSelected.Clear();

            foreach (TreeNode nodes in tvCompanyLevelsRoot.Nodes)
            {
                GetCompanyLevelsSelected(nodes);
            }

            if (tvCompanyLevelsRoot.Nodes.Count > 0)
            {
                if (arrayCompanyLevelsSelected.Count > 0)
                {
                    if (arrayCompanyLevelsSelected.Count < 2)
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        cvCompanyLevels.ErrorMessage = "You can select only one company level leave";
                    }
                }
                else
                {
                    cvCompanyLevels.ErrorMessage = "You must select at least one company level";
                }
            }
            else
            {
                cvCompanyLevels.ErrorMessage = "There are no company levels available. Contact your system administrator";
            }

            if (args.IsValid)
            {
                if (!CompareArrayList(arrayTemp, arrayCompanyLevelsSelected))
                {
                    Session["arrayCompanyLevelsSelectedChanged"] = true;
                }
            }

            Session["arrayCompanyLevelsSelected"] = arrayCompanyLevelsSelected;
        }




        protected void cvCode_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;

            UnitsGateway unitsGateway = new UnitsGateway(null);

            if (unitsGateway.IsUnitCodeInUse(tbxCode.Text))
            {
                args.IsValid = false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - GENERAL INFORMATION - METHODS
        //

        private void StepGeneralInformationIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please define general information";

            if (rbtnVehicle.Checked)
            {
                lblVinSerialNumber.Text = "VIN";
            }
            else
            {
                lblVinSerialNumber.Text = "Serial Number";
            }

            aceManufacturer.ContextKey = hdfCompanyId.Value;

            foreach (TreeNode nodes in tvCategoriesRoot.Nodes)
            {
                GetCategoriesParent(nodes);
            }

            foreach (TreeNode nodes in tvCompanyLevelsRoot.Nodes)
            {
                GetCompanyLevelsParent(nodes);
            }
        }



        private bool StepGeneralInformationNext()
        {
            Page.Validate("StepGeneralInformation");

            return (Page.IsValid) ? true : false;
        }



        private bool StepGeneralInformationPrevious()
        {
            return true;
        }



        private void GetCategoriesSelected(TreeNode node)
        {
            if (node.ChildNodes.Count == 0)
            {
                if (node.Checked)
                {
                    arrayCategoriesSelected.Add(int.Parse(node.Value));
                }
            }
            else
            {
                if (node.Checked)
                {
                    arrayCategoriesSelected.Add(int.Parse(node.Value));
                }

                foreach (TreeNode node2 in node.ChildNodes)
                {
                    GetCategoriesSelected(node2);
                }
            }
        }



        private void GetCompanyLevelsSelected(TreeNode node)
        {
            if (node.ChildNodes.Count == 0)
            {
                if (node.Checked)
                {
                    arrayCompanyLevelsSelected.Add(int.Parse(node.Value));
                }
            }
            else
            {
                if (node.Checked)
                {
                    arrayCompanyLevelsSelected.Add(int.Parse(node.Value));
                }

                foreach (TreeNode node2 in node.ChildNodes)
                {
                    GetCompanyLevelsSelected(node2);
                }
            }
        }



        private void GetCategoriesParent(TreeNode node)
        {
            if (node.ChildNodes.Count > 0)
            {
                node.ShowCheckBox = false;

                foreach (TreeNode node2 in node.ChildNodes)
                {
                    GetCategoriesParent(node2);
                }
            }
        }



        private void GetCompanyLevelsParent(TreeNode node)
        {
            if (node.ChildNodes.Count > 0)
            {
                node.ShowCheckBox = false;

                foreach (TreeNode node2 in node.ChildNodes)
                {
                    GetCompanyLevelsParent(node2);
                }
            }
        }

                

        #endregion






        #region STEP3 - VEHICLE INFORMATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP3 - VEHICLE INFORMATION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - VEHICLE INFORMATION - AUXILIAR EVENTS
        //  

        protected void ddlLicenseCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProvinceList provinceList = new ProvinceList();
            provinceList.LoadByCountryIdAndAddItem(-1, "(Select a state)", int.Parse(ddlLicenseCountry.SelectedValue));
            ddlLicenseState.DataSource = provinceList.Table;
            ddlLicenseState.DataValueField = "ProvinceID";
            ddlLicenseState.DataTextField = "Name";
            ddlLicenseState.DataBind();
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - VEHICLE INFORMATION - METHODS
        //

        private void StepVehicleInformationIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please define license plate information";

            // ... For country
            CountryList countryList = new CountryList();
            countryList.LoadAndAddItem(-1, "(Select a country)");
            ddlLicenseCountry.DataSource = countryList.Table;
            ddlLicenseCountry.DataValueField = "CountryID";
            ddlLicenseCountry.DataTextField = "Name";
            ddlLicenseCountry.DataBind();

            foreach (int companyLevelId in arrayCompanyLevelsSelected)
            {
                if (companyLevelId == 2)
                {
                    ddlLicenseCountry.SelectedIndex = 1;
                }

                if (companyLevelId == 3)
                {
                    ddlLicenseCountry.SelectedIndex = 2;
                }
            }

            ProvinceList provinceList = new ProvinceList();
            provinceList.LoadByCountryIdAndAddItem(-1, "(Select a state)", int.Parse(ddlLicenseCountry.SelectedValue));
            ddlLicenseState.DataSource = provinceList.Table;
            ddlLicenseState.DataValueField = "ProvinceID";
            ddlLicenseState.DataTextField = "Name";
            ddlLicenseState.DataBind();
            ddlLicenseState.SelectedIndex = 0;
        }



        private bool StepVehicleInformationNext()
        {
            Page.Validate("StepVehicleInformation");

            return (Page.IsValid) ? true : false;
        }



        private bool StepVehicleInformationPrevious()
        {
            return true;
        }

        

        #endregion






        #region STEP4 - CHECKLIST RULES INFORMATION

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP4 - CHECKLIST RULES INFORMATION
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - CHECKLIST RULES INFORMATION - AUXILIAR EVENTS
        //

        protected void grdChecklistRulesInformation_DataBound(object sender, EventArgs e)
        {
            ChecklistRulesInformationEmptyFix(grdChecklistRulesInformation);
        }


        
        protected void grdChecklistRulesInformation_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow) && ((e.Row.RowState == DataControlRowState.Normal) || (e.Row.RowState == (DataControlRowState.Normal | DataControlRowState.Alternate))))
            {
                if (((Label)e.Row.FindControl("lblFrequency")).Text != "Only once")
                {
                    CheckBox cbxDone = ((CheckBox)e.Row.FindControl("cbxDone"));
                    cbxDone.Visible = false;
                }
            }
        }



        protected void grdChecklistRulesInformation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            StepChecklistRulesInformationProcessGrid();
        }



        protected void cvGrdChecklistRulesInformation_ServerValidate(object source, ServerValidateEventArgs args)
        {
            // Initialize 
            CustomValidator cvChecklistRules = (CustomValidator)source;
            args.IsValid = true;
            string messageError = "";
            
            if (grdChecklistRulesInformation.Rows.Count > 0)
            {
                foreach (GridViewRow row in grdChecklistRulesInformation.Rows)
                {
                    string ChecklistRuleName = ((Label)row.FindControl("lblColumn")).Text;
                    
                    try
                    {
                        if (!((CheckBox)row.FindControl("cbxSelected")).Checked)
                        {
                            if ((((RadDatePicker)row.FindControl("tkrdpLastService")).SelectedDate.HasValue) || (((RadDatePicker)row.FindControl("tkrdpNextDue")).SelectedDate.HasValue) || (((CheckBox)row.FindControl("cbxDone")).Checked))
                            {
                                args.IsValid = false;
                                messageError += String.Format("The state in {0} is inactive, insert data not allowed<br>", ChecklistRuleName);
                            }
                        }
                        else
                        {
                            if (((Label)row.FindControl("lblFrequency")).Text == "Only once")
                            {
                                if (((RadDatePicker)row.FindControl("tkrdpLastService")).SelectedDate.HasValue)
                                {
                                    if (!((CheckBox)row.FindControl("cbxDone")).Checked)
                                    {
                                        args.IsValid = false;
                                        messageError += String.Format("Done should be checked since {0} has a Last Service<br>", ChecklistRuleName);
                                    }

                                    if (((RadDatePicker)row.FindControl("tkrdpNextDue")).SelectedDate.HasValue)
                                    {
                                        args.IsValid = false;
                                        messageError += String.Format("The Next Due date in {0} must be empty<br>", ChecklistRuleName);
                                    }
                                }
                                else
                                {
                                    if (((RadDatePicker)row.FindControl("tkrdpNextDue")).SelectedDate.HasValue)
                                    {
                                        if (((CheckBox)row.FindControl("cbxDone")).Checked)
                                        {
                                            args.IsValid = false;
                                            messageError += String.Format("Done should be un-checked since {0} has a Next Due<br>", ChecklistRuleName);
                                        }
                                    }
                                    else
                                    {
                                        if (!((CheckBox)row.FindControl("cbxDone")).Checked)
                                        {
                                            args.IsValid = false;
                                            messageError += String.Format("The Next Due date in {0} must be inserted<br>", ChecklistRuleName);
                                        }
                                        else
                                        {
                                            args.IsValid = false;
                                            messageError += String.Format("The Last Service date in {0} must be inserted<br>", ChecklistRuleName);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (((RadDatePicker)row.FindControl("tkrdpLastService")).SelectedDate.HasValue)
                                {
                                    if (((RadDatePicker)row.FindControl("tkrdpNextDue")).SelectedDate.HasValue)
                                    {
                                        args.IsValid = false;
                                        messageError += String.Format("The Next Due date in {0} must be empty<br>", ChecklistRuleName);
                                    }
                                }
                                else
                                {
                                    if (!((RadDatePicker)row.FindControl("tkrdpNextDue")).SelectedDate.HasValue)
                                    {
                                        args.IsValid = false;
                                        messageError += String.Format("The Last Service date or Next Due date in {0} must be inserted<br>", ChecklistRuleName);
                                    }                                    
                                }
                            }
                        }
                    }
                    catch
                    {                        
                    }
                }
            }
            
            cvGrdChecklistRulesInformation.Text = messageError;
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - CHECKLIST RULES INFORMATION - METHODS
        //

        private void StepChecklistRulesInformationIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please review the checklist rules data that will be applied to the unit";

            // Load
            UnitsAddTDS dataSet = new UnitsAddTDS();
            dataSet.UnitsChecklistRulesTemp.Merge(unitsChecklistRulesTempForAdd, true);
            UnitsChecklistRulesTemp model = new UnitsChecklistRulesTemp(dataSet);
            int companyLevelIdSelected = 0;

            if (dataSet.UnitsChecklistRulesTemp.Rows.Count <= 0)
            {
                foreach (int companyLevelId in arrayCompanyLevelsSelected)
                {
                    companyLevelIdSelected = companyLevelId;
                }

                model.Load(arrayCategoriesSelected, companyLevelIdSelected, int.Parse(hdfCompanyId.Value));
            }
            else
            {
                if (Convert.ToBoolean(Session["arrayCategoriesSelectedChanged"]) || Convert.ToBoolean(Session["arrayCompanyLevelsSelectedChanged"]))
                {
                    model.Data.Clear();
                    foreach (int companyLevelId in arrayCompanyLevelsSelected)
                    {
                        companyLevelIdSelected = companyLevelId;
                    }
                    
                    model.Load(arrayCategoriesSelected, companyLevelIdSelected, int.Parse(hdfCompanyId.Value));
                }                
            }

            // Store tables
            unitsChecklistRulesTempForAdd = (UnitsAddTDS.UnitsChecklistRulesTempDataTable)model.Table;
            Session["unitsChecklistRulesTempForAdd"] = unitsChecklistRulesTempForAdd;

            grdChecklistRulesInformation.DataBind();
        }



        private bool StepChecklistRulesInformationNext()
        {
            Page.Validate("StepChecklistRulesInformation");

            if (Page.IsValid)
            {
                StepChecklistRulesInformationProcessGrid();
                                                              
                // Store tables
                Session.Remove("unitsChecklistRulesTempForAddDummy");
                Session["unitsChecklistRulesTempForAdd"] = unitsChecklistRulesTempForAdd;
                Session["arrayCategoriesSelectedChanged"] = false;
                Session["arrayCompanyLevelsSelectedChanged"] = false;
                return true;
            }
            else
            {
                return false;
            }
        }



        private bool StepChecklistRulesInformationPrevious()
        {
            return true;
        }



        private void StepChecklistRulesInformationProcessGrid()
        {
            UnitsAddTDS dataSet = new UnitsAddTDS();
            dataSet.UnitsChecklistRulesTemp.Merge(unitsChecklistRulesTempForAdd, true);
            UnitsChecklistRulesTemp model = new UnitsChecklistRulesTemp(dataSet);

            // Update rows
            if (Session["unitsChecklistRulesTempForAddDummy"] == null)
            {
                foreach (GridViewRow row in grdChecklistRulesInformation.Rows)
                {
                    int ruleId = int.Parse(grdChecklistRulesInformation.DataKeys[row.RowIndex].Values["RuleID"].ToString());
                    int count = int.Parse(grdChecklistRulesInformation.DataKeys[row.RowIndex].Values["Count"].ToString());                                        
                    DateTime? lastService = null;
                    DateTime? nextDue = null;
                    bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                    bool done = ((CheckBox)row.FindControl("cbxDone")).Checked;
                    string state = "Healthy";

                    if (((RadDatePicker)row.FindControl("tkrdpLastService")).SelectedDate.HasValue)
                    {
                        lastService = ((RadDatePicker)row.FindControl("tkrdpLastService")).SelectedDate.Value;
                    }

                    if (((RadDatePicker)row.FindControl("tkrdpNextDue")).SelectedDate.HasValue)
                    {
                        nextDue = ((RadDatePicker)row.FindControl("tkrdpNextDue")).SelectedDate.Value;
                    }                  
                    
                    model.Update(ruleId, count, lastService, nextDue, state, done, selected);
                }

                model.Table.AcceptChanges();

                unitsChecklistRulesTempForAdd = (UnitsAddTDS.UnitsChecklistRulesTempDataTable)model.Table;
                Session["unitsChecklistRulesTempForAdd"] = unitsChecklistRulesTempForAdd;
            }
        }



        public UnitsAddTDS.UnitsChecklistRulesTempDataTable GetChecklistRulesInformation()
        {
            unitsChecklistRulesTempForAdd = (UnitsAddTDS.UnitsChecklistRulesTempDataTable)Session["unitsChecklistRulesTempForAddDummy"];
            
            if (unitsChecklistRulesTempForAdd == null)
            {
                unitsChecklistRulesTempForAdd = (UnitsAddTDS.UnitsChecklistRulesTempDataTable)Session["unitsChecklistRulesTempForAdd"];
            }

            return unitsChecklistRulesTempForAdd;
        }



        protected void ChecklistRulesInformationEmptyFix(GridView grdChecklistRulesInformation)
        {
            if (grdChecklistRulesInformation.Rows.Count == 0)
            {
                UnitsAddTDS.UnitsChecklistRulesTempDataTable dt = new UnitsAddTDS.UnitsChecklistRulesTempDataTable();
                dt.AddUnitsChecklistRulesTempRow(0, 0, "", "", DateTime.Now, DateTime.Now, false, "Active", false);
                Session["unitsChecklistRulesTempForAddDummy"] = dt;

                grdChecklistRulesInformation.DataBind();
            }

            // Normally executes at all postbacks
            if (grdChecklistRulesInformation.Rows.Count == 1)
            {
                UnitsAddTDS.UnitsChecklistRulesTempDataTable dt = (UnitsAddTDS.UnitsChecklistRulesTempDataTable)Session["unitsChecklistRulesTempForAddDummy"];
                if (dt != null)
                {
                    // Hide row
                    grdChecklistRulesInformation.Rows[0].Visible = false;
                    grdChecklistRulesInformation.Rows[0].Controls.Clear();
                }
            }
        }

        #endregion






        #region STEP5 - SUMMARY

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP5 - SUMMARY
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP5 - SUMMARY - METHODS
        //

        private void StepSummaryIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Summary";
            hdfUpdate.Value = "yes";

            string isTowable = "No"; if (cbxIsTowable.Checked) isTowable = "Yes"; else isTowable = "No";
            string unitType = (rbtnVehicle.Checked) ? unitType = "Vehicle" : unitType = "Equipment";
            string vinOrSerialNumber = (rbtnVehicle.Checked) ? vinOrSerialNumber = "VIN" : vinOrSerialNumber = "Serial Number";

            string categoriesSelected = "";
            foreach (int categoryId in arrayCategoriesSelected)
            {
                CategoryGateway categoryGateway = new CategoryGateway();
                categoryGateway.LoadByCategoryId(categoryId, Int32.Parse(hdfCompanyId.Value));
                categoriesSelected += categoryGateway.GetName(categoryId) + ", ";
            }

            if (categoriesSelected.Length > 2)
            {
                categoriesSelected = categoriesSelected.Substring(0, categoriesSelected.Length - 2);
            }

            string companyLevelsSelected = "";
            foreach (int companyLevelId in arrayCompanyLevelsSelected)
            {
                CompanyLevelGateway companyLevelGateway = new CompanyLevelGateway();
                companyLevelGateway.LoadByCompanyLevelId(companyLevelId, Int32.Parse(hdfCompanyId.Value));
                companyLevelsSelected += companyLevelGateway.GetName(companyLevelId) + ", ";
            }

            if (companyLevelsSelected.Length > 2)
            {
                companyLevelsSelected = companyLevelsSelected.Substring(0, companyLevelsSelected.Length - 2);
            }

            tbxSummary.Text = "Unit Type: " + unitType + "\nCode: " + tbxCode.Text + "\nDescription: " + tbxDescription.Text + "\n" + vinOrSerialNumber + ": " + tbxVinSerialNumber.Text + "\nManufacturer: " + tbxManufacturer.Text + "\nModel: " + tbxModel.Text + "\nYear: " + tbxYear.Text + "\nIs Towable?: " + isTowable + "\nCategories: " + categoriesSelected + "\nCompany Levels: " + companyLevelsSelected;

            if (rbtnVehicle.Checked)
            {
                string licenseCountry = "";
                string licenceState = "";

                if (ddlLicenseCountry.SelectedValue != "-1")
                {
                    licenseCountry = ddlLicenseCountry.SelectedItem.Text;

                    if (ddlLicenseState.SelectedValue != "-1" && ddlLicenseState.SelectedValue != "")
                    {
                        licenceState = ddlLicenseState.SelectedItem.Text;
                    }
                }
                
                tbxSummary.Text += "\nLicense Country: " + licenseCountry + "\nLicense State: " + licenceState + "\nLicense Plate Number: " + tbxLicensePlateNumber.Text + "\nApportioned Tag Number: " + tbxApportionedTagNumber.Text;
            }
        }



        private bool StepSummaryPrevious()
        {
            return true;
        }



        private bool StepSummaryFinish()
        {
            if (Page.IsValid)
            {
                string type = (rbtnVehicle.Checked) ? type = "Vehicle" : type = "Equipment";
                string code = tbxCode.Text;
                string description = ""; if (tbxDescription.Text != "") description = tbxDescription.Text;
                string vin = ""; if (tbxVinSerialNumber.Text != "") vin = tbxVinSerialNumber.Text;
                string manufacturer = ""; if (tbxManufacturer.Text != "") manufacturer = tbxManufacturer.Text;
                string model = ""; if (tbxModel.Text != "") model = tbxModel.Text;
                string year = ""; if (tbxYear.Text != "") year =tbxYear.Text;
                bool isTowable = (cbxIsTowable.Checked) ? isTowable = true : isTowable = false;

                Int64? licenseCountry = null;
                Int64? licenceState = null;

                if (type == "Vehicle")
                {
                    if (ddlLicenseCountry.SelectedValue != "-1")
                    {
                        licenseCountry = Int64.Parse(ddlLicenseCountry.SelectedValue);

                        if (ddlLicenseState.SelectedValue != "-1" && ddlLicenseState.SelectedValue != "")
                        {
                            licenceState = Int64.Parse(ddlLicenseState.SelectedValue);
                        }
                    }
                }
                
                string licensePlateNumber = ""; if (tbxLicensePlateNumber.Text != "") licensePlateNumber = tbxLicensePlateNumber.Text;
                string apportionedTagNumber = ""; if (tbxApportionedTagNumber.Text != "") apportionedTagNumber = tbxApportionedTagNumber.Text;
                int companyLevelIdSelected = 0;
                
                foreach (int companyLevelId in arrayCompanyLevelsSelected)
                {
                    companyLevelIdSelected = companyLevelId;    
                }

                UnitsAddTDS dataSet = new UnitsAddTDS();
                dataSet.UnitsAddNew.Merge(unitsAddNew, true);
                UnitsAddNew modelU = new UnitsAddNew(dataSet);
                modelU.Insert(type, code, description, vin, manufacturer, model, year, isTowable, licenseCountry, licenceState, licensePlateNumber, apportionedTagNumber, companyLevelIdSelected);

                unitsAddNew.Rows.Clear();
                unitsAddNew.Merge(modelU.Table);
                
                // Store database
                Session["unitsAddTDS"] = unitsAddTDS;
                Session["unitsAddNew"] = unitsAddNew;

                Save();

                hdfUpdate.Value = "yes";

                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion






        #region STEP6 - FINISH OPTIONS
        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP6 - FINISH OPTIONS
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP6 - FINISH OPTIONS - METHODS
        //

        private void StepFinalStepIn()
        {
            // Set instruction
            mWizard2 master2 = (mWizard2)this.Master;
            master2.WizardInstruction = "What would you like to do?";

            string url = "";

            UnitsGateway unitsGateway = new UnitsGateway(null);
            int unitId = unitsGateway.GetLastUnitId();

            UnitsGateway unitsGatewayForLoad = new UnitsGateway();
            unitsGatewayForLoad.LoadByUnitId(unitId, int.Parse(hdfCompanyId.Value));
            string unitType = unitsGatewayForLoad.GetType(unitId);
            string unitState = unitsGatewayForLoad.GetState(unitId);

            hdfUpdate.Value = "yes";

            // Store active tab for postback
            Session["activeTabUnits"] = "0";
            Session["dialogOpenedUnits"] = "0";

            url = "./units_summary.aspx?source_page=units_add.aspx&unit_id=" + unitId.ToString() + "&unit_type=" + unitType + "&unit_state=" + unitState + "&active_tab=0" + GetNavigatorState();
            lkbtnOpenUnit.Attributes.Add("onclick", string.Format("return lkbtnOpenServiceClick('{0}');", url));

            url = "./units_edit.aspx?source_page=units_add.aspx&unit_id=" + unitId.ToString() + "&unit_type=" + unitType + "&unit_state=" + unitState + "&active_tab=0" + GetNavigatorState();
            lkbtnEditUnit.Attributes.Add("onclick", string.Format("return lkbtnEditServiceClick('{0}');", url));

            lkbtnClose.Attributes.Add("onclick", "return lkbtnCloseClick();");
        }

        #endregion






        // ////////////////////////////////////////////////////////////////////////
        // FINAL EVENTS 
        //

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set wizard title
            Label title = (Label)this.Master.FindControl("lblTitle");
            title.Text = "Add Unit";
        }






        // ////////////////////////////////////////////////////////////////////////
        // FINAL METHODS 
        //

        private void GetNodeForCategory(TreeNodeCollection nodes, int parentId)
        {
            Int32 thisId;
            String thisName;

            DataRow[] children = categoriesTDS.Tables["LFS_FM_CATEGORY"].Select("ParentID='" + parentId + "'");

            // No child nodes, exit function
            if (children.Length == 0) return;

            foreach (DataRow child in children)
            {
                // Step 1
                thisId = Convert.ToInt32(child.ItemArray[0]);

                // Step 2
                thisName = Convert.ToString(child.ItemArray[2]);

                // Step 3
                TreeNode newNode = new TreeNode(thisName, thisId.ToString());
                newNode.ShowCheckBox = true;             
                newNode.SelectAction = TreeNodeSelectAction.None;

                // Step 4
                nodes.Add(newNode);
                newNode.ToggleExpandState();

                // Step 5
                GetNodeForCategory(newNode.ChildNodes, thisId);
            }
        }



        private void GetNodeForCompanyLevels(TreeNodeCollection nodes, int parentId)
        {
            Int32 thisId;
            String thisName;

            DataRow[] children = companyLevelsTDS.Tables["LFS_FM_COMPANYLEVEL"].Select("ParentID='" + parentId + "'");

            // No child nodes, exit function
            if (children.Length == 0) return;

            foreach (DataRow child in children)
            {
                // Step 1
                thisId = Convert.ToInt32(child.ItemArray[0]);

                // Step 2
                thisName = Convert.ToString(child.ItemArray[1]);

                // Step 3
                TreeNode newNode = new TreeNode(thisName, thisId.ToString());
                newNode.ShowCheckBox = true;
                newNode.SelectAction = TreeNodeSelectAction.None;

                // Step 4
                nodes.Add(newNode);
                newNode.ToggleExpandState();

                // Step 5
                GetNodeForCompanyLevels(newNode.ChildNodes, thisId);
            }
        }



        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./units_add.js");
        }



        private string GetNavigatorState()
        {
            // Columns to display
            int companyId = Int32.Parse(Session["companyID"].ToString());
            string fmType = "Units";
            string columnsToDisplay = "&columns_to_display=";

            FmTypeViewDisplay fmTypeViewDisplay = new FmTypeViewDisplay();
            columnsToDisplay = columnsToDisplay + fmTypeViewDisplay.GetColumnsByDefault(fmType, companyId, true);

            // SearchOptions for condition 1
            string searchOptions = "";
            searchOptions = searchOptions + "&search_ddlCondition1=1";
            searchOptions = searchOptions + "&search_tbxCondition1=%";

            // For Views
            searchOptions = searchOptions + "&search_ddlView=-2";

            // Other values
            searchOptions = searchOptions + "&search_sort_by=1";
            searchOptions = searchOptions + "&btn_origin=Search";

            // Return
            return columnsToDisplay + searchOptions;
        }



        private void Save()
        {
            // Save to database
            DB.Open();
            DB.BeginTransaction();
            try
            {
                int companyId = Convert.ToInt32(Session["companyID"]);

                // Process view
                UnitsAddTDS dataset = new UnitsAddTDS();
                dataset.UnitsAddNew.Merge(unitsAddNew, true);
                dataset.UnitsChecklistRulesTemp.Merge(unitsChecklistRulesTempForAdd, true);

                UnitsAddNew modelUnitsAddNew = new UnitsAddNew(dataset);
                modelUnitsAddNew.Save(arrayCategoriesSelected, companyId);
                
                DB.CommitTransaction();

                // Store datasets
                unitsAddTDS.AcceptChanges();
                Session["unitsAddTDS"] = unitsAddTDS;
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private bool CompareArrayList(ArrayList arraylistOld, ArrayList arrayListNew)
        {
            if (arraylistOld.Count != arrayListNew.Count)
            {
                return false;
            }
                        
            for(int i=0;i<arraylistOld.Count;i++)
            {
                if (!arraylistOld[i].Equals(arrayListNew[i]))
                {
                    return false;
                }
            }

            return true;         
        }


        
    }
}
