using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.BL.Resources.Common;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.BL.Resources.Employees;
using LiquiForce.LFSLive.DA.RAF;
using LiquiForce.LFSLive.BL.LabourHours.ProjectTime;

namespace LiquiForce.LFSLive.WebUI.Resources.Employees
{
    /// <summary>
    /// employees_add
    /// </summary>
    public partial class employees_add : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected EmployeesAddTDS employeesAddTDS;






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
                if (!(Convert.ToBoolean(Session["sgLFS_RESOURCES_EMPLOYEES_ADD"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if ((string)Request.QueryString["source_page"] == null) 
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in employees_add.aspx");
                }

                // Tag Page
                hdfCompanyId.Value = Convert.ToInt32(Session["companyID"]).ToString();

                // If coming from 
                // ... employee_navigator.aspx
                if (Request.QueryString["source_page"] == "lm")
                {
                    // ... Initialize tables
                    employeesAddTDS = new EmployeesAddTDS();

                    EmployeeAddGateway employeeAddGateway = new EmployeeAddGateway();
                    employeeAddGateway.LoadAll();

                    // ... Store tables
                    Session["employeesAddTDS"] = employeesAddTDS;
                }

                int companyId = Int32.Parse(hdfCompanyId.Value);
                ProjectTimeJobClassTypeList projectTimeJobClassTypeList = new ProjectTimeJobClassTypeList();
                projectTimeJobClassTypeList.LoadAndAddItem(1, companyId, "");
                ddlJobClassType.DataSource = projectTimeJobClassTypeList.Table;
                ddlJobClassType.DataValueField = "JobClassType";
                ddlJobClassType.DataTextField = "JobClassType";
                ddlJobClassType.DataBind();
                ddlJobClassType.SelectedIndex = 0;

                // StepSection1In
                wzTeamMember.ActiveStepIndex = 0;
                lblUserErrorMessage.Visible = false;
                StepBeginIn();
            }
            else
            {
                // Restore tables
                employeesAddTDS = (EmployeesAddTDS)Session["employeesAddTDS"];  
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
                switch (wzTeamMember.ActiveStep.Name)
                {
                    case "Begin":
                        StepBeginIn();
                        break;

                    case "General Data":
                        StepGeneralDataIn();
                        break;

                    case "Summary":
                        StepSummaryIn();
                        break;

                    case "Final Step":
                        StepFinalStepIn();
                        wzTeamMember.ActiveStepIndex = wzTeamMember.WizardSteps.IndexOf(StepFinalStep);
                        break;

                    default:
                        throw new Exception("The option for " + wzTeamMember.ActiveStep.Name + " step in employees_add.Wizard_ActiveStepChanged function does not exist");
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzTeamMember.ActiveStep.Name)
            {
                case "Begin":
                    e.Cancel = !StepBeginNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Begin";
                    }
                    break;

                case "General Data":
                    e.Cancel = !StepGeneralDataNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "General Information";
                    }
                    break; 

                default:
                    throw new Exception("The option for " + wzTeamMember.ActiveStep.Name + " step in employees_add.Wizard_NextButtonClick function does not exist");
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzTeamMember.ActiveStep.Name)
            {
                case "General Data":
                    e.Cancel = !StepGeneralDataPrevious();
                    break;
                
                case "Summary":
                    e.Cancel = !StepSummaryPrevious();
                    break;

                default:
                    throw new Exception("The option for " + wzTeamMember.ActiveStep.Name + " step in employees_add.Wizard_PreviousButtonClick function does not exist");
            }
            if (!e.Cancel)
            {
                ViewState["StepFrom"] = wzTeamMember.ActiveStep.Name;
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






        #region STEP1 - BEGIN

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP1 - BEGIN
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN - AUXILIAR EVENTS
        //

        protected void ddlUsersFooter_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["selectedLoginId"] = ddlUsers.SelectedValue;
            lblUserErrorMessage.Visible = false;
            lblUserErrorMessage.DataBind();
        }



        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectTimeJobClassTypeList projectTimeJobClassTypeList = new ProjectTimeJobClassTypeList();

            if (ddlType.SelectedItem.Text.Contains("Canada"))
            {
                projectTimeJobClassTypeList.LoadAndAddItem(1, 3, "");
                ddlJobClassType.DataSource = projectTimeJobClassTypeList.Table;
                ddlJobClassType.DataValueField = "JobClassType";
                ddlJobClassType.DataTextField = "JobClassType";
                ddlJobClassType.DataBind();
            }
            else
            {
                projectTimeJobClassTypeList.LoadAndAddItem(2, 3, "");
                ddlJobClassType.DataSource = projectTimeJobClassTypeList.Table;
                ddlJobClassType.DataValueField = "JobClassType";
                ddlJobClassType.DataTextField = "JobClassType";
                ddlJobClassType.DataBind();
            }

            upnlJobClassType.Update();
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN - METHODS
        //

        private void StepBeginIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please select a Team Member";
        }



        private bool StepBeginNext()
        {
            int selectedLoginId = Int32.Parse(ddlUsers.SelectedValue);
            EmployeeAddGateway employeeAddGateway = new EmployeeAddGateway();

            if (employeeAddGateway.IsInLfs(selectedLoginId))
            {
                lblUserErrorMessage.Visible = true;
                return false;
            }
            else
            {
                lblUserErrorMessage.Visible = false;
                return true;
            }
        }        



        #endregion






        #region STEP2 - GENERAL DATA

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP2 - GENERAL DATA
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - GENERAL DATA - METHODS
        //

        private void StepGeneralDataIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please provide the following information for the new team member";
        }



        private bool StepGeneralDataPrevious()
        {
            return true;
        }



        private bool StepGeneralDataNext()
        {
            Page.Validate("General");

            if (Page.IsValid)
            {
                int loginId = Int32.Parse(Session["selectedLoginId"].ToString());                
                int companyId = Convert.ToInt32(Session["companyID"]);

                LoginGateway loginGateway = new LoginGateway();
                loginGateway.LoadByLoginId((int)loginId, companyId);

                hdfFirstName.Value = loginGateway.GetFirstName((int)loginId, companyId);
                hdfLastName.Value = loginGateway.GetLastName((int)loginId, companyId);
                hdfMail.Value = loginGateway.GetEmail((int)loginId, companyId);
                hdfType.Value = ddlType.SelectedValue;
                hdfState.Value = ddlState.SelectedValue;
                hdfRequestTimesheet.Value = ckbxRequestTimesheet.Checked.ToString();
                hdfSalaried.Value = ckbxSalaried.Checked.ToString();
                hdfAssignableSrs.Value = ckbxAssignableSrs.Checked.ToString();

                return true;
            }
            else
            {
                return false;
            }
        }
      
        #endregion






        #region STEP3 - SUMMARY

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP3 - SUMMARY
        //
        
        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - SUMMARY - METHODS
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
            Page.Validate("StepSummary");
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






        #region STEP4 - FINISH OPTIONS
        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP4 - FINISH OPTIONS
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - FINISH OPTIONS - METHODS
        //

        private void StepFinalStepIn()
        {
            // Set instruction
            mWizard2 master2 = (mWizard2)this.Master;
            master2.WizardInstruction = "What would you like to do?";

            // Store active tab for postback
            Session["activeTabEmployees"] = "0";
            Session["dialogOpenedEmployees"] = "0";

            string url = "";

            url = "./employees_summary.aspx?source_page=employees_add.aspx&employee_id=" + hdfEmployeeId.Value + "&active_tab=0" + GetNavigatorState();
            lkbtnOpenTeamMember.Attributes.Add("onclick", string.Format("return lkbtnOpenClick('{0}');", url));

            url = "./employees_edit.aspx?source_page=employees_add.aspx&employee_id=" + hdfEmployeeId.Value + "&active_tab=0" + GetNavigatorState();
            lkbtnEditTeamMember.Attributes.Add("onclick", string.Format("return lkbtnEditClick('{0}');", url));

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
            title.Text = "Add Team Member";
        }

        




        // ////////////////////////////////////////////////////////////////////////
        // PRIVATE METHODS
        //

        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./employees_add.js");
        }



        private void UpdateDatabase()
        {
            DB.Open();
            DB.BeginTransaction();
            try
            {
                EmployeeAdd employeeAdd = new EmployeeAdd(employeesAddTDS);
                int employeeId = employeeAdd.Save();

                EmployeeAddTypeHistory employeeAddTypeHistory = new EmployeeAddTypeHistory(employeesAddTDS);
                employeeAddTypeHistory.Save(employeeId);
                hdfEmployeeId.Value = employeeId.ToString();

                DB.CommitTransaction();

                // Store datasets
                employeesAddTDS.AcceptChanges();
                Session["employeesAddTDS"] = employeesAddTDS;

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
            // Load user data
            int loginId = Int32.Parse(Session["selectedLoginId"].ToString());
            int companyId = Convert.ToInt32(Session["companyID"]);

            LoginGateway loginGateway = new LoginGateway();
            loginGateway.LoadByLoginId((int)loginId, companyId);

            int? contactsId = loginGateway.GetContactsId((int)loginId, companyId);
            string fullName = loginGateway.GetRealName((int)loginId, companyId);
            string firstName = hdfFirstName.Value;
            string middleInitial = "";
            string lastName = hdfLastName.Value;
            string type = hdfType.Value;
            string state = hdfState.Value;
            bool isSalesman = false;
            bool requestProjectTime = bool.Parse(hdfRequestTimesheet.Value);
            bool deleted = false;
            bool salaried = bool.Parse(hdfSalaried.Value); ;
            string eMail =  hdfMail.Value;
            bool assignableSrs = bool.Parse(hdfAssignableSrs.Value);
            bool inDataBase = false;
            string jobClass = ddlJobClassType.SelectedValue;
            string category = ddlCategory.SelectedValue;
            bool isVacationsManager = ckbxVacationsManager.Checked;
            string personalAgency = ddlPersonalAgency.SelectedValue;
            bool approveTimesheets = ckbxApproveTimesheets.Checked;
            decimal? bourdenFactor = null;
            decimal? usHealthBenefitFactor = null;
            decimal? benefitFactorCad = null;
            decimal? benefitFactorUsd = null;

            int newEmployeeId = 0;
            EmployeeAdd model = new EmployeeAdd(employeesAddTDS);
            newEmployeeId = model.Insert(loginId, contactsId, fullName, firstName, middleInitial, lastName, type, state, isSalesman, requestProjectTime, deleted, salaried, eMail, assignableSrs, inDataBase, jobClass, category, personalAgency, isVacationsManager, approveTimesheets, bourdenFactor, usHealthBenefitFactor, benefitFactorCad, benefitFactorUsd);
            
            // Add type history
            if (contactsId.HasValue)
            {                                            
                EmployeeAddTypeHistory modelEmployeeAddTypeHistory = new EmployeeAddTypeHistory(employeesAddTDS);
                modelEmployeeAddTypeHistory.Insert(newEmployeeId, DateTime.Now, type, deleted, companyId, false);
            }
                     
            // Store session
            Session["employeesAddTDS"] = employeesAddTDS;
        }



        private string GetSummary()
        {
            string summary = "NEW TEAM MEMBER \n";
            summary = summary + "First Name: " + hdfFirstName.Value + "\n";
            summary = summary + "Last Name: " + hdfLastName.Value + "\n";
            summary = summary + "eMail: " + hdfMail.Value + "\n";

            EmployeeTypeGateway employeeTypeGateway = new EmployeeTypeGateway();
            employeeTypeGateway.LoadByType(hdfType.Value);
            summary = summary + "Type: " + employeeTypeGateway.GetDescription(hdfType.Value) + "\n";

            EmployeeStateGateway employeeStateGateway = new EmployeeStateGateway();
            employeeStateGateway.LoadByState(hdfState.Value);
            summary = summary + "State: " + employeeStateGateway.GetDescription(hdfState.Value) +"\n";

            summary = summary + "Category: " + ddlCategory.SelectedValue + "\n";

            summary = summary + "Job Class: " + ddlJobClassType.SelectedValue + "\n";

            summary = summary + "\n";

            string approveTimesheets = "";
            if (ckbxApproveTimesheets.Checked) approveTimesheets = "Yes"; else approveTimesheets = "No";
            summary = summary + "Approve Timesheets?: " + approveTimesheets + "\n";

            string requestTimesheet = "";
            if (hdfRequestTimesheet.Value == "True") requestTimesheet = "Yes"; else requestTimesheet = "No";
            summary = summary + "Request Timesheet?: " + requestTimesheet + "\n";

            string salaried = "";
            if (hdfSalaried.Value == "True") salaried = "Yes"; else salaried = "No";
            summary = summary + "Salaried: " + salaried + "\n";            

            string assignableSrs = "";
            if (hdfAssignableSrs.Value == "True") assignableSrs = "Yes"; else assignableSrs = "No";
            summary = summary + "Assignable SR's: " + assignableSrs + "\n";

            string isVacationsManager = "";
            if (ckbxVacationsManager.Checked) isVacationsManager = "Yes"; else isVacationsManager = "No";
            summary = summary + "Vacations Manager?: " + isVacationsManager + "\n";

            string personalAgency = "";
            if (ddlPersonalAgency.SelectedIndex > 0)
            {
                personalAgency = ddlPersonalAgency.SelectedValue;
            }
            summary = summary + "Personnel Agency: " + personalAgency + "\n";
            
            return summary;
        }



        private string GetNavigatorState()
        {
            // Columns to display
            int companyId = Int32.Parse(hdfCompanyId.Value.Trim());
            string resourceType = "Employee";
            string columnsToDisplay = "&columns_to_display=";

            ResourceTypeViewDisplay resourceTypeViewDisplay = new ResourceTypeViewDisplay();
            columnsToDisplay = columnsToDisplay + resourceTypeViewDisplay.GetColumnsByDefault(resourceType, companyId, true);
            
            // SearchOptions for condition 1
            string searchOptions = "";
            searchOptions = searchOptions + "&search_ddlCondition1=1";
            searchOptions = searchOptions + "&search_tbxCondition1=%";

            // Other values
            searchOptions = searchOptions + "&search_state=1";            
            searchOptions = searchOptions + "&btn_origin=Search";

            // Return
            return columnsToDisplay + searchOptions;
        }



    }
}