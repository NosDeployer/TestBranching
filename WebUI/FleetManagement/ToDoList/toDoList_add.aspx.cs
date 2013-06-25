using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.FleetManagement.ToDoList;
using LiquiForce.LFSLive.DA.FleetManagement.ToDoList;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.WebUI.FleetManagement.ToDoList
{
    /// <summary>
    /// toDoList_add
    /// </summary>
    public partial class toDoList_add : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ToDoListAddTDS toDoListAddTDS;






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
                if (!(Convert.ToBoolean(Session["sgLFS_FLEETMANAGEMENT_TODOLIST_ADD"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["dashboard"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in toDoList_add.aspx");
                }

                // Tag Page
                TagPage();             

                // Initialize viewstate variables
                ViewState["StepFrom"] = "Out";
                Session.Remove("toDoListAddTDS");

                // If coming from 
                // ... toDoList_navigator.aspx, toDoList_navigator2.aspx, toDoList_summary.aspx or wucSRUnassigned.ascx
                if ((Request.QueryString["source_page"] == "toDoList_navigator.aspx") || (Request.QueryString["source_page"] == "toDoList_navigator2.aspx") || (Request.QueryString["source_page"] == "toDoList_summary.aspx") || (Request.QueryString["source_page"] == "wucSRUnassigned.ascx") || (Request.QueryString["source_page"] == "wucAlarms.ascx.cs"))
                {
                    // ... Initialize tables
                    toDoListAddTDS = new ToDoListAddTDS();

                    // ... Store tables
                    Session["toDoListAddTDS"] = toDoListAddTDS;
                }

                // StepSection1In
                wzToDoList.ActiveStepIndex = 0;
                StepBeginIn();
            }
            else
            {
                // Restore tables
                toDoListAddTDS = (ToDoListAddTDS)Session["toDoListAddTDS"];
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
                switch (wzToDoList.ActiveStep.Name)
                {
                    case "Begin":
                        StepBeginIn();
                        break;                                           
                        
                    case "Summary":
                        StepSummaryIn();
                        break;

                    case "Final Step":
                        StepFinalStepIn();
                        wzToDoList.ActiveStepIndex = wzToDoList.WizardSteps.IndexOf(StepFinalStep);
                        break;

                    default:
                        throw new Exception("The option for " + wzToDoList.ActiveStep.Name + " step in toDoList_add.Wizard_ActiveStepChanged function does not exist");
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzToDoList.ActiveStep.Name)
            {
                case "Begin":
                    e.Cancel = !StepBeginNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Summary";
                    }
                    break;
               
                default:
                    throw new Exception("The option for " + wzToDoList.ActiveStep.Name + " step in toDoList_add.Wizard_NextButtonClick function does not exist");
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzToDoList.ActiveStep.Name)
            {               
                case "Summary":
                    e.Cancel = !StepSummaryPrevious();
                    break;

                default:
                    throw new Exception("The option for " + wzToDoList.ActiveStep.Name + " step in toDoList_add.Wizard_PreviousButtonClick function does not exist");
            }
            if (!e.Cancel)
            {
                ViewState["StepFrom"] = wzToDoList.ActiveStep.Name;
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

        protected void cvTeamMember_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = true;
            if ((rbtnAssignToTeamMember.Checked) && (ddlAssignToTeamMember.SelectedValue == "-1"))
            {
                args.IsValid = false;
            }
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN - METHODS
        //

        private void StepBeginIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please provide Item information";                                  
        }



        private bool StepBeginNext()
        {
            Page.Validate("Begin");
            if (Page.IsValid)
            {
                // Tag values
                hdfSubject.Value = tbxSubject.Text.Trim();
                hdfComments.Value = tbxComment.Text.Trim();                              
                hdfDueDate.Value = tkrdpDueDate.SelectedDate.ToString();
                hdfUnitId.Value = ddlUnit.SelectedValue;
                hdfUnitCode.Value = ddlUnit.SelectedItem.Text;
                
                hdfAssignToMyself.Value = rbtnAssignToMyself.Checked.ToString();
                if (rbtnAssignToMyself.Checked)
                {
                    int loginId = Convert.ToInt32(Session["loginID"]);
                    EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
                    hdfTeamMemberId.Value = employeeGateway.GetEmployeIdByLoginId(loginId).ToString();
                    int employeeId = Int32.Parse(hdfTeamMemberId.Value);
                    hdfTeamMemberFullName.Value = employeeGateway.GetFullName(employeeId).ToString();
                }

                hdfAssignToTeamMember.Value = rbtnAssignToTeamMember.Checked.ToString();
                if (rbtnAssignToTeamMember.Checked)
                {
                    hdfTeamMemberId.Value = ""; if (ddlAssignToTeamMember.SelectedValue != "") hdfTeamMemberId.Value = ddlAssignToTeamMember.SelectedValue;
                    hdfTeamMemberFullName.Value = ""; if (ddlAssignToTeamMember.SelectedItem.Text != "") hdfTeamMemberFullName.Value = ddlAssignToTeamMember.SelectedItem.Text;
                }

                return true;
            }
            return false;
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

            string url = "";
            int newToDoId = Int32.Parse(hdfToDoId.Value);

            url = "./toDoList_summary.aspx?source_page=toDoList_add.aspx&dashboard=" + hdfDashboard.Value + "&toDo_id=" + newToDoId;
            lkbtnOpenService.Attributes.Add("onclick", string.Format("return lkbtnOpenToDoListClick('{0}');", url));

            url = "./toDoList_edit.aspx?source_page=toDoList_add.aspx&dashboard=" + hdfDashboard.Value + "&toDo_id=" + newToDoId;
            lkbtnEditService.Attributes.Add("onclick", string.Format("return lkbtnEditToDoListClick('{0}');", url));

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
            title.Text = "Add To Do List";
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./toDoList_add.js");
        }



        private void TagPage()
        {
            hdfDashboard.Value = (string)Request.QueryString["dashboard"];
            hdfCompanyId.Value = Convert.ToInt32(Session["companyID"]).ToString();

            // Initialize general data
            hdfSubject.Value = "";
            hdfComments.Value = "";
            hdfDueDate.Value = "";
            hdfUnitCode.Value = "";
            hdfUnitId.Value = "";
            hdfTeamMemberId.Value = "";
            hdfTeamMemberFullName.Value = "";
            hdfAssignToMyself.Value = "";
            hdfAssignToTeamMember.Value = "";
        }



        private void UpdateDatabase()
        {
            DB.Open();
            DB.BeginTransaction();
            try
            {
                int companyId = Int32.Parse(hdfCompanyId.Value);
                DateTime creationDate = DateTime.Now;

                ToDoListAddBasicInformation toDoListAddBasicInformation = new ToDoListAddBasicInformation(toDoListAddTDS);
                hdfToDoId.Value = toDoListAddBasicInformation.Save(creationDate, companyId).ToString();

                DB.CommitTransaction();

                // Store datasets
                toDoListAddTDS.AcceptChanges();
                Session["toDoListAddTDS"] = toDoListAddTDS;
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
            int companyId = Int32.Parse(hdfCompanyId.Value);
            string subject = hdfSubject.Value;
            string comments = hdfComments.Value;
            DateTime? dueDate = null; if (hdfDueDate.Value != "") dueDate = DateTime.Parse(hdfDueDate.Value);
            int? unitId = null; if (hdfUnitId.Value != "-1") unitId = Int32.Parse(hdfUnitId.Value);          
            int assignTeamMemberId = Int32.Parse(hdfTeamMemberId.Value);
            string state = "New";
            string type_ = "AssignUser";
            int loginId = Convert.ToInt32(Session["loginID"]);
            EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
            hdfTeamMemberId.Value = employeeGateway.GetEmployeIdByLoginId(loginId).ToString();
            int employeeId = Int32.Parse(hdfTeamMemberId.Value);
            
            // Insert to dataset
            ToDoListAddBasicInformation toDoListAddBasicInformation = new ToDoListAddBasicInformation(toDoListAddTDS);
            toDoListAddBasicInformation.Insert(subject, comments, dueDate, unitId, assignTeamMemberId, false, companyId, state, employeeId, type_);

            // Store session
            Session["toDoListAddTDS"] = toDoListAddTDS;
        }



        private string GetSummary()
        {            
            string summary = "GENERAL INFORMATION \n";
            summary = summary + "\n Subject: " + hdfSubject.Value + "\n";
            summary = summary + "\n Commnet: " + hdfComments.Value + "\n";
            if (hdfDueDate.Value != "")
            {
                DateTime dueDate = DateTime.Parse(hdfDueDate.Value);
                string dueDateText = dueDate.Month.ToString() + "/" + dueDate.Day.ToString() + "/" + dueDate.Year.ToString();
                summary = summary + "\n Due Date: " + dueDateText + "\n";
            }

            if (hdfUnitCode.Value != "(Select a unit)")
            {
                summary = summary + "\n Unit Code: " + hdfUnitCode.Value + "\n";
            }

            // ... Assignation information
            if ((rbtnAssignToMyself.Checked) || (rbtnAssignToTeamMember.Checked))
            {
                summary = summary + "\nASSIGMENT INFORMATION \n";

                // ... ... Assigned Personal 
                if (hdfAssignToTeamMember.Value == "True")
                {
                    summary = summary + "\n Assigned team member: " + hdfTeamMemberFullName.Value + "\n";
                }                     

                // ... ... Asssigned to myself
                if (hdfAssignToMyself.Value == "True")
                {
                    summary = summary + "\n Assigned to myself: YES \n";
                }
            }      

            return summary;
        }

              
        
           
    }
}