using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.BL.ITTechSupportTicket.SupportTicket;
using LiquiForce.LFSLive.DA.ITTechSupportTicket.SupportTicket;
using LiquiForce.LFSLive.DA.Resources.Employees;
using LiquiForce.LFSLive.Server;

namespace LiquiForce.LFSLive.WebUI.ITTechSupportTicket.SupportTicket
{
    /// <summary>
    /// supportTicket_add
    /// </summary>
    public partial class supportTicket_add : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected SupportTicketAddTDS supportTicketAddTDS;
        protected SupportTicketCategoriesTDS supportTicketCategoriesTDS;
        protected ArrayList arrayCategoriesSelectedForAdd;






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
                if (!(Convert.ToBoolean(Session["sgLFS_ITTST_SUPPORTTICKET_ADMIN"])))
                {
                    if (!(Convert.ToBoolean(Session["sgLFS_ITTST_SUPPORTTICKET_VIEW"])))
                    {
                        Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                    }
                }

                // Validate query string
                if (((string)Request.QueryString["source_page"] == null) || ((string)Request.QueryString["dashboard"] == null))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "Invalid query string in supportTicket_add.aspx");
                }

                // Tag Page
                TagPage();

                // Initialize viewstate variables
                ViewState["StepFrom"] = "Out";
                Session.Remove("supportTicketAddTDS");
                arrayCategoriesSelectedForAdd = new ArrayList();
                Session["arrayCategoriesSelectedForAdd"] = arrayCategoriesSelectedForAdd;

                // If coming from 
                // ... supportTicket_navigator.aspx, supportTicket_navigator2.aspx, supportTicket_summary.aspx or wucSRUnassigned.ascx
                if ((Request.QueryString["source_page"] == "supportTicket_navigator.aspx") || (Request.QueryString["source_page"] == "supportTicket_navigator2.aspx") || (Request.QueryString["source_page"] == "supportTicket_summary.aspx") || (Request.QueryString["source_page"] == "wucSRUnassigned.ascx") || (Request.QueryString["source_page"] == "wucAlarms.ascx.cs"))
                {
                    // ... Initialize tables
                    supportTicketAddTDS = new SupportTicketAddTDS();

                    // ... For Categories
                    supportTicketCategoriesTDS = new SupportTicketCategoriesTDS();
                    SupportTicketCategory supportTicketCategory = new SupportTicketCategory(supportTicketCategoriesTDS);
                    supportTicketCategory.Load(int.Parse(hdfCompanyId.Value));

                    // ... Store tables
                    Session["supportTicketAddTDS"] = supportTicketAddTDS;
                    Session["supportTicketCategoriesTDS"] = supportTicketCategoriesTDS;
                }

                // StepSection1In
                wzSupportTicket.ActiveStepIndex = 0;
                StepBeginIn();
            }
            else
            {
                // Restore tables
                arrayCategoriesSelectedForAdd = (ArrayList)Session["arrayCategoriesSelectedForAdd"];
                supportTicketAddTDS = (SupportTicketAddTDS)Session["supportTicketAddTDS"];
                supportTicketCategoriesTDS = (SupportTicketCategoriesTDS)Session["supportTicketCategoriesTDS"];
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
                switch (wzSupportTicket.ActiveStep.Name)
                {
                    case "Begin":
                        StepBeginIn();
                        break;

                    case "Summary":
                        StepSummaryIn();
                        break;

                    case "Final Step":
                        StepFinalStepIn();
                        wzSupportTicket.ActiveStepIndex = wzSupportTicket.WizardSteps.IndexOf(StepFinalStep);
                        break;

                    default:
                        throw new Exception("The option for " + wzSupportTicket.ActiveStep.Name + " step in supportTicket_add.Wizard_ActiveStepChanged function does not exist");
                }
            }
        }



        protected void Wizard_NextButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzSupportTicket.ActiveStep.Name)
            {
                case "Begin":
                    e.Cancel = !StepBeginNext();
                    if (!e.Cancel)
                    {
                        ViewState["StepFrom"] = "Summary";
                    }
                    break;

                default:
                    throw new Exception("The option for " + wzSupportTicket.ActiveStep.Name + " step in supportTicket_add.Wizard_NextButtonClick function does not exist");
            }
        }



        protected void Wizard_PreviousButtonClick(object sender, WizardNavigationEventArgs e)
        {
            switch (wzSupportTicket.ActiveStep.Name)
            {
                case "Summary":
                    e.Cancel = !StepSummaryPrevious();
                    break;

                default:
                    throw new Exception("The option for " + wzSupportTicket.ActiveStep.Name + " step in supportTicket_add.Wizard_PreviousButtonClick function does not exist");
            }
            if (!e.Cancel)
            {
                ViewState["StepFrom"] = wzSupportTicket.ActiveStep.Name;
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
            //args.IsValid = true;
            //if ((rbtnAssignToTeamMember.Checked) && (ddlAssignToTeamMember.SelectedValue == "-1"))
            //{
            //    args.IsValid = false;
            //}
        }



        protected void cvCategories_ServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = false;
            arrayCategoriesSelectedForAdd.Clear();

            foreach (TreeNode nodes in tvCategoriesRoot.Nodes)
            {
                GetCategoriesSelected(nodes);
            }

            if (tvCategoriesRoot.Nodes.Count > 0)
            {
                if (arrayCategoriesSelectedForAdd.Count > 0)
                {
                    if (arrayCategoriesSelectedForAdd.Count < 2)
                    {
                        args.IsValid = true;
                    }
                    else
                    {
                        cvCategories.ErrorMessage = "You can select only one company level leave";
                    }
                }
                else
                {
                    cvCategories.ErrorMessage = "You must select at least one company level";
                }
            }
            else
            {
                cvCategories.ErrorMessage = "There are no company levels available. Contact your system administrator";
            }

            Session["arrayCategoriesSelectedForAdd"] = arrayCategoriesSelectedForAdd;
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - BEGIN - METHODS
        //

        private void StepBeginIn()
        {
            // Set instruction
            Label instruction = (Label)this.Master.FindControl("lblInstruction");
            instruction.Text = "Please provide support ticket information";

            // For companies
            GetNodeForCategories(tvCategoriesRoot.Nodes, 0);

            foreach (TreeNode nodes in tvCategoriesRoot.Nodes)
            {
                GetCategoriesParent(nodes);
            }
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

                // Assign Dan Anzovino
                int loginId = 115;
                EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
                hdfTeamMemberId.Value = employeeGateway.GetEmployeIdByLoginId(loginId).ToString();
                int employeeId = Int32.Parse(hdfTeamMemberId.Value);
                hdfTeamMemberFullName.Value = employeeGateway.GetFullName(employeeId).ToString();


                //hdfAssignToMyself.Value = rbtnAssignToMyself.Checked.ToString();
                //if (rbtnAssignToMyself.Checked)
                //{
                //    int loginId = Convert.ToInt32(Session["loginID"]);
                //    EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
                //    hdfTeamMemberId.Value = employeeGateway.GetEmployeIdByLoginId(loginId).ToString();
                //    int employeeId = Int32.Parse(hdfTeamMemberId.Value);
                //    hdfTeamMemberFullName.Value = employeeGateway.GetFullName(employeeId).ToString();
                //}

                //hdfAssignToTeamMember.Value = rbtnAssignToTeamMember.Checked.ToString();
                //if (rbtnAssignToTeamMember.Checked)
                //{
                //    hdfTeamMemberId.Value = ""; if (ddlAssignToTeamMember.SelectedValue != "") hdfTeamMemberId.Value = ddlAssignToTeamMember.SelectedValue;
                //    hdfTeamMemberFullName.Value = ""; if (ddlAssignToTeamMember.SelectedItem.Text != "") hdfTeamMemberFullName.Value = ddlAssignToTeamMember.SelectedItem.Text;
                //}

                foreach (int categoriesId in arrayCategoriesSelectedForAdd)
                {
                    hdfCategoriesSelected.Value = categoriesId.ToString();
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
            int newSupportTicketId = Int32.Parse(hdfSupportTicketId.Value);

            url = "./supportTicket_summary.aspx?source_page=supportTicket_add.aspx&dashboard=" + hdfDashboard.Value + "&supportTicket_id=" + newSupportTicketId;
            lkbtnOpenTicketSupport.Attributes.Add("onclick", string.Format("return lkbtnOpenSupportTicketClick('{0}');", url));

            url = "./supportTicket_edit.aspx?source_page=supportTicket_add.aspx&dashboard=" + hdfDashboard.Value + "&supportTicket_id=" + newSupportTicketId;
            lkbtnEditTicketSupport.Attributes.Add("onclick", string.Format("return lkbtnEditSupportTicketClick('{0}');", url));

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
            title.Text = "Add Support Ticket";
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
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./supportTicket_add.js");
        }



        private void TagPage()
        {
            hdfDashboard.Value = (string)Request.QueryString["dashboard"];
            hdfCompanyId.Value = Convert.ToInt32(Session["companyID"]).ToString();

            // Initialize general data
            hdfSubject.Value = "";
            hdfComments.Value = "";
            hdfDueDate.Value = "";
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

                SupportTicketAddBasicInformation supportTicketAddBasicInformation = new SupportTicketAddBasicInformation(supportTicketAddTDS);
                hdfSupportTicketId.Value = supportTicketAddBasicInformation.Save(creationDate, companyId).ToString();

                // Send mail
                SendMailForNewTicket();

                DB.CommitTransaction();

                // Store datasets
                supportTicketAddTDS.AcceptChanges();
                Session["supportTicketAddTDS"] = supportTicketAddTDS;
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
            int assignTeamMemberId = Int32.Parse(hdfTeamMemberId.Value);
            string state = "New";
            string type_ = "AssignUser";
            int loginId = Convert.ToInt32(Session["loginID"]);
            EmployeeGateway employeeGateway = new EmployeeGateway(new DataSet());
            hdfTeamMemberId.Value = employeeGateway.GetEmployeIdByLoginId(loginId).ToString();
            int employeeId = Int32.Parse(hdfTeamMemberId.Value);
            int categoryId = Int32.Parse(hdfCategoriesSelected.Value);
            SupportTicketCategoryGateway supportTicketCategoryGateway = new SupportTicketCategoryGateway();
            supportTicketCategoryGateway.LoadByCategoryId(categoryId, companyId);
            string categoryName = supportTicketCategoryGateway.GetName(categoryId);

            // Insert to dataset
            SupportTicketAddBasicInformation supportTicketAddBasicInformation = new SupportTicketAddBasicInformation(supportTicketAddTDS);
            supportTicketAddBasicInformation.Insert(categoryId, subject, comments, dueDate, assignTeamMemberId, false, companyId, state, employeeId, type_, categoryName);

            // Store session
            Session["supportTicketAddTDS"] = supportTicketAddTDS;
        }



        private string GetSummary()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);

            string summary = "GENERAL INFORMATION \n";
            summary = summary + "\n Subject: " + hdfSubject.Value + "\n";
            summary = summary + "\n Commnet: " + hdfComments.Value + "\n";
            if (hdfDueDate.Value != "")
            {
                DateTime dueDate = DateTime.Parse(hdfDueDate.Value);
                string dueDateText = dueDate.Month.ToString() + "/" + dueDate.Day.ToString() + "/" + dueDate.Year.ToString();
                summary = summary + "\n Due Date: " + dueDateText + "\n";
            }

            int categoryId = Int32.Parse(hdfCategoriesSelected.Value);
            SupportTicketCategoryGateway supportTicketCategoryGateway = new SupportTicketCategoryGateway();
            supportTicketCategoryGateway.LoadByCategoryId(categoryId, companyId);            
            summary = summary + "\n Category: " + supportTicketCategoryGateway.GetName(categoryId) + "\n";

            // Assign Dan Anzovino
            summary = summary + "\nASSIGMENT INFORMATION \n";
            summary = summary + "\n Assigned team member: Dan Anzovino \n";

            // ... Assignation information
            //if ((rbtnAssignToMyself.Checked) || (rbtnAssignToTeamMember.Checked))
            //{
            //    summary = summary + "\nASSIGMENT INFORMATION \n";

            //    // ... ... Assigned Personal 
            //    if (hdfAssignToTeamMember.Value == "True")
            //    {
            //        summary = summary + "\n Assigned team member: " + hdfTeamMemberFullName.Value + "\n";
            //    }

            //    // ... ... Asssigned to myself
            //    if (hdfAssignToMyself.Value == "True")
            //    {
            //        summary = summary + "\n Assigned to myself: YES \n";
            //    }
            //}

            return summary;
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



        private void GetCategoriesSelected(TreeNode node)
        {
            if (node.ChildNodes.Count == 0)
            {
                if (node.Checked)
                {
                    arrayCategoriesSelectedForAdd.Add(int.Parse(node.Value));
                }
            }
            else
            {
                if (node.Checked)
                {
                    arrayCategoriesSelectedForAdd.Add(int.Parse(node.Value));
                }

                foreach (TreeNode node2 in node.ChildNodes)
                {
                    GetCategoriesSelected(node2);
                }
            }
        }



        private void GetNodeForCategories(TreeNodeCollection nodes, int parentId)
        {
            Int32 thisId;
            String thisName;
            SupportTicketCategoryGateway supportTicketCategoryGateway = new SupportTicketCategoryGateway(null);

            DataRow[] children = supportTicketCategoriesTDS.Tables["LFS_ITTST_CATEGORY"].Select("ParentID='" + parentId + "'");

            //no child nodes, exit function
            if (children.Length == 0) return;

            foreach (DataRow child in children)
            {
                // step 1
                thisId = Convert.ToInt32(child.ItemArray[0]);

                // step 2
                thisName = Convert.ToString(child.ItemArray[1]);

                // step 3
                TreeNode newNode = new TreeNode(thisName, thisId.ToString());
                newNode.ShowCheckBox = true;
                newNode.SelectAction = TreeNodeSelectAction.None;

                //step 4
                //if (supportTicketCategoryGateway.IsUsedInUnitCategory(Int32.Parse(hdfUnitId.Value), thisId))
                //{
                //    newNode.Checked = true;
                //}

                // step 5
                nodes.Add(newNode);
                newNode.ToggleExpandState();

                // step 6
                GetNodeForCategories(newNode.ChildNodes, thisId);
            }
        }



        public void SendMailForNewTicket()
        {
            int companyId = Int32.Parse(hdfCompanyId.Value);

            // Get mail information
            string mailTo = "";
            string nameTo = "";
            string subject = "A support ticket was created.";
            string body = "";

            // MailtTo, nameTo            
            int createdBy = Int32.Parse(hdfTeamMemberId.Value);
            EmployeeGateway employeeGateway = new EmployeeGateway();
            employeeGateway.LoadByEmployeeId(createdBy);

            mailTo = employeeGateway.GetEMail(createdBy);
            nameTo = employeeGateway.GetFullName(createdBy);

            // Mails body
            body = body + "\nHi " + nameTo + ",\n\nThe following support ticket was created. \n";
            body = body + "\n Subject: " + hdfSubject.Value;
            body = body + "\n Comment: " + hdfComments.Value;
            body = body + "\n Created By: " + employeeGateway.GetFullName(createdBy);

            if (hdfDueDate.Value != "")
            {
                DateTime dueDate = DateTime.Parse(hdfDueDate.Value);
                string dueDateText = dueDate.Month.ToString() + "/" + dueDate.Day.ToString() + "/" + dueDate.Year.ToString();
                body = body + "\n Due Date: " + dueDateText;
            }

            int categoryId = Int32.Parse(hdfCategoriesSelected.Value);
            SupportTicketCategoryGateway supportTicketCategoryGateway = new SupportTicketCategoryGateway();
            supportTicketCategoryGateway.LoadByCategoryId(categoryId, companyId);
            body = body + "\n Category: " + supportTicketCategoryGateway.GetName(categoryId);

            //int assignTeamMemberId = Int32.Parse(hdfTeamMemberId.Value);
            //EmployeeGateway employeeGatewayForAssignment = new EmployeeGateway();
            //employeeGatewayForAssignment.LoadByEmployeeId(assignTeamMemberId);

            //body = body + "\n Assigned team member: " + employeeGatewayForAssignment.GetFullName(assignTeamMemberId) + "\n";

            body = body + "\n Assigned team member: Anzovino Dan \n";

            //Send Mail
            SendMail(mailTo, subject, body);
        }



        private void SendMail(string mailTo, string subject, string body)
        {
            SendMailLiveSite(mailTo, subject, body);
            //SendMailTestSite(mailTo, subject, body);//TODO EMAIL
        }



        private void SendMailLiveSite(string mailTo, string subject, string body)
        {
            string error;

            // For live site
            string entireBody = "";

            if ((mailTo != "") && (subject != "") && (body != ""))
            {
                entireBody = entireBody + body + "\n\n\n\n\nRegards,\n\n" + "LFS Admin Team.\n\n";
                LiquiForce.LFSLive.WebUI.Common.Tools.Mail.SendMailSupportTicketSystem(mailTo, "danzovino@liquiforce.com, sussel@nerdsonsite.com", subject, entireBody, false, out error);
            }
        }



        private void SendMailTestSite(string mailTo, string subject, string body)
        {
            string error;

            // For Test Site
            string entireBody = "--- SENT FROM THE TEST SITE --- \n";

            if ((mailTo != "") && (subject != "") && (body != ""))
            {
                entireBody = entireBody + body + "\n\n\n\n\nRegards,\n\n" + "LFS Admin Team.\n\n";
                LiquiForce.LFSLive.WebUI.Common.Tools.Mail.SendMailSupportTicketSystem("humberto@nerdsonsite.com", "sussel@nerdsonsite.com, humberto@nerdsonsite.com, humberto@nerdsonsite.com", subject, entireBody, false, out error);
            }
        }

              
                   
    }
}