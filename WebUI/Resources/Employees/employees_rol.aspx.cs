using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using LiquiForce.LFSLive.Server;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.BL.Resources.Employees;

namespace LiquiForce.LFSLive.WebUI.Resources.Employees
{
    /// <summary>
    /// employees_rol
    /// </summary>
    public partial class employees_rol : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //
        protected EmployeeTDS employeeTDS;
        protected EmployeeNavigatorTDS employeeNavigatorTDS;






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
                if (!Convert.ToBoolean(Session["sgLFS_RESOURCES_EMPLOYEES_VIEW"]))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["employee_id"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in employees_rol.aspx");
                }

                // Tag Page
                hdfEmployeeId.Value = (string)Request.QueryString["employee_id"];
                hdfUpdate.Value = "no";

                // Iniciate variables
                StepBeginIn();

                // Restore dataset
                employeeNavigatorTDS = (EmployeeNavigatorTDS)Session["employeeNavigatorTDS"];
            }
            else
            {
                // Restore dataset
                employeeNavigatorTDS = (EmployeeNavigatorTDS)Session["employeeNavigatorTDS"];
            }
        }






        #region Wizard navigation events

        // ////////////////////////////////////////////////////////////////////////
        // WIZARD NAVIGATION EVENTS
        //

        protected void wzRole_ActiveStepChanged(object sender, EventArgs e)
        {
            if (ViewState["StepFrom"] != null)
            {
                switch (wzRole.ActiveStep.Name)
                {
                    case "Begin":
                        StepBeginIn();
                        break;

                    case "Remove":
                        StepRemoveIn();
                        break;

                    case "Add":
                        StepAddIn();
                        break;

                    case "Finish":
                        StepFinishIn();
                        break;

                    default:
                        throw new Exception("The option for " + wzRole.ActiveStep.Name + " step in employee_rol.Wizard_ActiveStepChanged function does not exist");
                }
            }
        }



        protected void wzRole_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzRole.ActiveStep.Name)
            {
                case "Begin":
                    ViewState["StepFrom"] = "Add";

                    if (rbtnAdd.Checked)
                    {
                        wzRole.ActiveStepIndex = 2;
                    }
                    break;

                case "Add":
                    ViewState["StepFrom"] = "Finish";

                    if (!ValidateAdd())
                    {
                        e.Cancel = true;
                    }
                    else
                    {
                        if (ckbxSalesmanAdd.Checked)
                        {
                            wzRole.ActiveStepIndex = 3;
                        }
                    }
                    break;

                default:
                    throw new Exception("The option for " + wzRole.ActiveStep.Name + " step in employee_rol.Wizard_NextButtonClick function does not exist");
            }
        }



        protected void wzRole_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            if (ValidateFinish(e))
            {
                Save();
                Response.Write("<script language='javascript'> {window.opener.location.href = window.opener.location; window.close();}</script>");
            }
            else
            {
                e.Cancel = true;
            }
        }



        protected void wzRole_CancelButtonClick(object sender, EventArgs e)
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
        // STEP1 - BEGIN - METHODS
        //

        private void StepBeginIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Do you want add or remove a role?";
        }


        #endregion






        #region STEP2 - REMOVE

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP2 - REMOVE
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - REMOVE - METHODS
        //

        private void StepRemoveIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "What role do you want to remove?";
        }



        #endregion






        #region STEP3 - ADD

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP3 - ADD
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP3 - ADD - METHODS
        //

        private void StepAddIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "What role do you want to add?";
        }


        #endregion






        #region STEP4 - FINISH

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP4 - FINISH
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - FINISH - AUXILIAR EVENTS 
        //
        protected void cvSalesmanIdForProjects_ServerValidate(object source, ServerValidateEventArgs args)
        {
            int employeeId = Int32.Parse(Request.QueryString["employee_id"]);
            SalesmanGateway salesmanGateway = new SalesmanGateway(new DataSet());
            args.IsValid = !(salesmanGateway.IsIdForProjectInUse(args.Value, employeeId));
        }



        protected void cvSalesmanIdForPrrojectsFormat_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = Salesman.ValidateIdForProjects(args.Value.ToString().Trim());
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP4 - FINISH - METHODS
        //

        private void StepFinishIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Define salesman data";

            // Insert employee if not exists
            BindSalesman();
        }


        #endregion






        // ////////////////////////////////////////////////////////////////////////
        // FINAL EVENTS 
        //
        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set wizard title
            int employeeId = Int32.Parse(hdfEmployeeId.Value);

            //... Employee
            EmployeeGateway employeeGateway = new EmployeeGateway();
            employeeGateway.LoadByEmployeeId(employeeId);

            Label title = (Label)this.Master.FindControl("lblTitle");
            title.Text = "Add Or Remove Role For " + employeeGateway.GetFullName(employeeId);
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void RegisterClientScripts()
        {
            // Register client-side events
            HtmlGenericControl body = (HtmlGenericControl)Page.Master.FindControl("myBody");
            body.Attributes.Add("onunload", "OnUnload();");

            // Register content variables
            string contentVariables = "";
            contentVariables += "var hdfUpdateId = '" + hdfUpdate.ClientID + "';";
            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./employees_rol.js");
        }



        private void BindSalesman()
        {
            // DataSet
            int employeeId = Int32.Parse(hdfEmployeeId.Value);

            SalesmanNavigator salesmanNavigator = new SalesmanNavigator(employeeNavigatorTDS);
            salesmanNavigator.LoadBySalesmanId(employeeId);

            // If salesman dont exists before
            if (salesmanNavigator.Table.Rows.Count == 0)
            {
                // Insert salesman
                salesmanNavigator.Insert(employeeId, "");
            }
            else
            {
                SalesmanNavigatorGateway salesmanNavigatorGateway = new SalesmanNavigatorGateway(employeeNavigatorTDS);
                tbxSalesmanIdForProjects.Text = salesmanNavigatorGateway.GetIdForProjects(employeeId);
            }

            // Store dataset
            Session["employeeNavigatorTDS"] = employeeNavigatorTDS;
        }



        private bool ValidateAdd()
        {
            int employeeId = Int32.Parse(hdfEmployeeId.Value);

            // Validate operation
            if (!ckbxSalesmanAdd.Checked)
            {
                return false;
            }

            // Validate data
            if (ckbxSalesmanAdd.Checked)
            {
                EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
                cvSalesmanAdd.IsValid = !employeeGateway.IsUsedInProjectsAsSalesman(employeeId);
            }

            if (Page.IsValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        private bool ValidateFinish(WizardNavigationEventArgs e)
        {
            int employeeId = Int32.Parse(hdfEmployeeId.Value);

            // Validate operation
            switch (e.CurrentStepIndex)
            {
                case 1:
                    // Remove role
                    if (!ckbxSalesmanRemove.Checked)
                    {
                        return false;
                    }
                    break;
            }

            // Validate data
            switch (e.CurrentStepIndex)
            {
                case 1:
                    // Remove role
                    if (ckbxSalesmanRemove.Checked)
                    {
                        EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
                        cvSalesmanRemove.IsValid = !employeeGateway.IsUsedInProjectsAsSalesman(employeeId);
                    }
                    break;

                case 3:
                    // Add salesman
                    Page.Validate("AddSalesman");
                    break;
            }

            if (Page.IsValid)
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        private void Save()
        {
            int employeeId = Int32.Parse(hdfEmployeeId.Value);
            hdfUpdate.Value = "yes";

            // Add salesman role
            if ((rbtnAdd.Checked) && (ckbxSalesmanAdd.Checked))
            {
                // ...Update employee
                EmployeeNavigator employeeNavigator = new EmployeeNavigator(employeeNavigatorTDS);
                employeeNavigator.UpdateSalesman(employeeId, true);

                // ...Update Salesman
                string idForProjects = tbxSalesmanIdForProjects.Text.Trim();
                SalesmanNavigator salesmanNavigator = new SalesmanNavigator(employeeNavigatorTDS);
                salesmanNavigator.Update(employeeId, idForProjects);
            }

            // Remove salesman
            if ((rbtnRemove.Checked) && (ckbxSalesmanRemove.Checked))
            {
                // ...Update employee
                EmployeeNavigator employeeNavigator = new EmployeeNavigator(employeeNavigatorTDS);
                employeeNavigator.UpdateSalesman(employeeId, false);
            }

            Session["employeeNavigatorTDS"] = employeeNavigatorTDS;

            // Save to database
            DB.Open();
            DB.BeginTransaction();

            try
            {
                EmployeeNavigator employeeNavigator = new EmployeeNavigator(employeeNavigatorTDS);
                employeeNavigator.Save();

                SalesmanNavigator salesmanNavigator = new SalesmanNavigator(employeeNavigatorTDS);
                salesmanNavigator.Save();

                DB.CommitTransaction();

                // Store datasets
                employeeNavigatorTDS.AcceptChanges();
                Session["employeeNavigatorTDS"] = employeeNavigatorTDS;
            }
            catch (Exception ex)
            {
                DB.RollbackTransaction();

                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }


        
    }
}