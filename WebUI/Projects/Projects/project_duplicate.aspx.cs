using System;
using System.Web.UI.WebControls;
using LiquiForce.LFSLive.DA.Projects.Projects;
using LiquiForce.LFSLive.BL.Projects.Projects;

namespace LiquiForce.LFSLive.WebUI.Projects.Projects
{
    /// <summary>
    /// project_duplicate
    /// </summary>
    public partial class project_duplicate : System.Web.UI.Page
    {
        // ////////////////////////////////////////////////////////////////////////
        // FIELDS
        //

        protected ProjectNavigatorTDS duplicateProjectNavigatorTDS;
        protected ProjectNavigatorTDS.LFS_PROJECT_NAVIGATORDataTable addDuplicateProjectNavigator;
        protected ProjectTDS projectTDS;






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
                if (!(Convert.ToBoolean(Session["sgLFS_PROJECTS_VIEW"]) && Convert.ToBoolean(Session["sgLFS_PROJECTS_ADD"])))
                {
                    Response.Redirect("./../../error_page.aspx?error=" + "You are not authorized to view this page. Contact your system administrator.");
                }

                // Tag page
                hdfCompanyId.Value = Session["companyID"].ToString();
                Session.Remove("projectNavigatorNewDummy");
                Session.Remove("addDuplicateProjectNavigator");

                // Initialize viewstate variables
                ViewState["StepFrom"] = "Out";

                // Store navigator state
                StoreNavigatorState();

                // Store datasets
                duplicateProjectNavigatorTDS = new ProjectNavigatorTDS();
                Session["duplicateProjectNavigatorTDS"] = duplicateProjectNavigatorTDS;

                // StepProposalsIn
                StepProposalsIn();
            }
            else
            {
                //Restore datasets
                duplicateProjectNavigatorTDS = (ProjectNavigatorTDS)Session["duplicateProjectNavigatorTDS"];
            }
        }






        #region Wizard navigation events

        // ////////////////////////////////////////////////////////////////////////
        // WIZARD NAVIGATION EVENTS
        //

        protected void wzProjectDuplicate_ActiveStepChanged(object sender, EventArgs e)
        {
            if (ViewState["StepFrom"] != null)
            {
                mWizard2 master2 = (mWizard2)this.Master;
                switch (wzProjectDuplicate.ActiveStep.Name)
                {
                    case "Finish Options":
                        StepFinishOptionsIn();
                        break;
                }
            }
        }



        protected void wzProjectDuplicate_CancelButtonClick(object sender, EventArgs e)
        {
            Response.Write("<script language='javascript'> { window.close();}</script>");
        }



        protected void wzProjectDuplicate_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            e.Cancel = !StepProposalsFinish();
        }

        #endregion






        #region STEP1 - PROPOSALS

        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // 
        // STEP1 - PROPOSALS
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - PROPOSALS - EVENTS
        //

        protected void grdProposals_DataBound(object sender, EventArgs e)
        {
            AddProposalsNewEmptyFix(grdProposals);
        }






        // ////////////////////////////////////////////////////////////////////////
        // STEP1 - PROPOSALS - METHODS
        //
        public ProjectNavigatorTDS.LFS_PROJECT_NAVIGATORDataTable GetProposals()
        {
            addDuplicateProjectNavigator = (ProjectNavigatorTDS.LFS_PROJECT_NAVIGATORDataTable)Session["projectNavigatorNewDummy"];
            if (addDuplicateProjectNavigator == null)
            {
                addDuplicateProjectNavigator = ((ProjectNavigatorTDS.LFS_PROJECT_NAVIGATORDataTable)Session["addDuplicateProjectNavigator"]);
            }

            return addDuplicateProjectNavigator;
        }



        private void StepProposalsIn()
        {
            // Set instruction
            mWizard2 master2 = (mWizard2)this.Master;
            master2.WizardInstruction = "Please select the proposal you would like to duplicate.";

            // Set grid to initial state
            lblError.Visible = false;

            // Prepare initial data
            // ... Load data
            ProjectNavigatorGateway projectNavigatorGateway = new ProjectNavigatorGateway(duplicateProjectNavigatorTDS);
            projectNavigatorGateway.LoadByProjectType("Proposal");

            //... for the total rows
            if (projectNavigatorGateway.Table.Rows.Count > 0)
            {
                lblTotalRows.Text = "Total Rows: " + projectNavigatorGateway.Table.Rows.Count;
                lblTotalRows.Visible = true;
            }
            else
            {
                lblTotalRows.Visible = false;
            }

            // ... Store datasets
            Session["duplicateProjectNavigatorTDS"] = duplicateProjectNavigatorTDS;
            Session["addDuplicateProjectNavigator"] = duplicateProjectNavigatorTDS.LFS_PROJECT_NAVIGATOR;
        }



        private bool StepProposalsFinish()
        {
            // Proposal election check
            if (grdProposals.Rows.Count > 0)
            {
                int projectId = 0;

                ProjectNavigator model = new ProjectNavigator(duplicateProjectNavigatorTDS);
                foreach (GridViewRow row in grdProposals.Rows)
                {
                    int projectIdForUpdate = Int32.Parse(((Label)row.FindControl("lblProjectID")).Text.Trim());
                    bool selected = ((CheckBox)row.FindControl("cbxSelected")).Checked;
                    if (selected)
                    {
                        projectId = projectIdForUpdate;
                    }

                    model.Update(projectIdForUpdate, selected);
                }
                model.Data.AcceptChanges();

                // ... Store datasets
                Session["duplicateProjectNavigatorTDS"] = duplicateProjectNavigatorTDS;

                if (projectId == 0)
                {
                    lblError.Visible = true;
                    lblError.Text = "At least one proposal must be selected";
                    return false;
                }
                else
                {
                    PostPageChanges(projectId);
                    UpdateDatabase();
                    return true;
                }
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Proposal unavailable";
                return false;
            }
        }



        protected void AddProposalsNewEmptyFix(GridView grdProposals)
        {
            if (grdProposals.Rows.Count == 0)
            {
                ProjectNavigatorTDS.LFS_PROJECT_NAVIGATORDataTable dt = new ProjectNavigatorTDS.LFS_PROJECT_NAVIGATORDataTable();
                dt.AddLFS_PROJECT_NAVIGATORRow("", "", "", "", -1, "", false, -1, false, "");
                Session["projectNavigatorNewDummy"] = dt;

                grdProposals.DataBind();
            }

            // normally executes at all postbacks
            if (grdProposals.Rows.Count == 1)
            {
                ProjectNavigatorTDS.LFS_PROJECT_NAVIGATORDataTable dt = (ProjectNavigatorTDS.LFS_PROJECT_NAVIGATORDataTable)Session["projectNavigatorNewDummy"];
                if (dt != null)
                {
                    grdProposals.Rows[0].Visible = false;
                    grdProposals.Rows[0].Controls.Clear();
                }
            }
        }

        #endregion






        #region STEP2 - FINISH OPTIONS
        // /////////////////////////////////////////////////////////////////////////////////////////////////////
        // STEP2 - FINISH OPTIONS
        //

        // ////////////////////////////////////////////////////////////////////////
        // STEP2 - FINISH OPTIONS - METHODS
        //

        private void StepFinishOptionsIn()
        {
            // Set instruction
            mWizard2 master2 = (mWizard2)this.Master;
            master2.WizardInstruction = "What would you like to do?";

            ProjectGateway projectGateway = new ProjectGateway(projectTDS);

            string url = "";
            int projectId = projectGateway.GetLastProjectId();

            url = "./project_summary.aspx?source_page=project_add.aspx&project_id=" + projectId.ToString() + "&active_tab=0&" + GetNavigatorState();
            lkbtnOpenProject.Attributes.Add("onclick", string.Format("return lkbtnOpenProjectClick('{0}');", url));

            url = "./project_edit.aspx?source_page=project_add.aspx&project_id=" + projectId.ToString() + "&active_tab=0&" + GetNavigatorState() + "&origin=navigator";
            lkbtnEditProject.Attributes.Add("onclick", string.Format("return lkbtnEditProjectClick('{0}');", url));

            lkbtnClose.Attributes.Add("onclick", "return lkbtnCloseClick();");
        }

        #endregion






        // ////////////////////////////////////////////////////////////////////////
        // FINAL EVENTS
        //

        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Set title for new project
            mWizard2 master2 = (mWizard2)this.Master;
            master2.WizardTitle = "Duplicate Proposal";
        }






        // ////////////////////////////////////////////////////////////////////////
        // METHODS
        //

        private void StoreNavigatorState()
        {
            if (Session["navigatorState"] != null)
            {
                ViewState["navigatorState"] = Session["navigatorState"].ToString();
            }
            else
            {
                ViewState["navigatorState"] = "&search_projectnumber=&search_projectname=&search_client=&search_type=%&search_state=%";
            }
        }



        private string GetNavigatorState()
        {
            return (string)ViewState["navigatorState"];
        }



        private void PostPageChanges(int originalProjectId)
        {
            // Definition of general variables
            projectTDS = new ProjectTDS();

            // ... Insert project_general
            InsertProject(originalProjectId);

            // ... Get newProjectId
            Project project = new Project(projectTDS);

            // ... Insert project_costing_updates
            InsertProjectCostingUpdates(originalProjectId);

            // ... Insert project_engineer_subcontractors
            InsertProjectEngineerSubcontractors(originalProjectId);

            // ...Insert project_subcontractor
            InsertProjectSubcontractor(originalProjectId);

            // ... Insert project_notes
            InsertProjectNote(originalProjectId);

            // ... Insert project_sale_billing_pricing
            InsertProjectSaleBillingPricing(originalProjectId);

            // ... Insert project_service
            InsertProjectService(originalProjectId);

            // ... Insert project_technical
            InsertProjectTechnical(originalProjectId);

            // ... Insert Terms
            InsertProjectTerms(originalProjectId);
        }



        private void UpdateDatabase()
        {
            try
            {
                ProjectGateway projectGateway = new ProjectGateway(projectTDS);
                projectGateway.Update4();
                projectTDS.AcceptChanges();
            }
            catch (Exception ex)
            {
                string url = string.Format("./../../error_page.aspx?error={0}", ex.Message.Replace('\n', ' '));
                Response.Redirect(url);
            }
        }



        private void InsertProject(int projectId)
        {
            // ... Data for current project
            ProjectGateway projectGateway = new ProjectGateway(projectTDS);
            projectGateway.LoadByProjectId(projectId);

            // ... Definition of general variables
            Int64 countryId = projectGateway.GetCountryID(projectId);
            int officeId = projectGateway.GetOfficeID(projectId);
            Int64? provinceId = projectGateway.GetProvinceID(projectId);
            Int64? cityId = projectGateway.GetCityID(projectId);
            Int64? countyId = projectGateway.GetCountyID(projectId);
            int? projectLeadId = null; if (projectGateway.GetProjectLeadID(projectId).HasValue) projectLeadId = (int)projectGateway.GetProjectLeadID(projectId);
            int salesmanId = projectGateway.GetSalesmanID(projectId);
            bool deleted = false;
            int? clientPrimaryContactID = null; if (projectGateway.GetClientPrimaryContactID(projectId).HasValue) clientPrimaryContactID = (int)projectGateway.GetClientPrimaryContactID(projectId);
            int? clientSecondaryContactID = null; if (projectGateway.GetClientSecondaryContactID(projectId).HasValue) clientSecondaryContactID = (int)projectGateway.GetClientSecondaryContactID(projectId);
            int? OriginalProjectID = projectId;
            int? projectNumberCopy = null; if (projectGateway.GetLastProjectNumberCopy(projectId).HasValue) projectNumberCopy = (int)projectGateway.GetLastProjectNumberCopy(projectId) + 1; else projectNumberCopy = 1;
            string projectNumber = projectGateway.GetProjectNumber(projectId) + "-" + projectNumberCopy.ToString();
            string projectType = "Proposal";
            string projectState = projectGateway.GetProjectState(projectId);
            string name = projectGateway.GetName(projectId);
            string description = projectGateway.GetDescription(projectId);
            DateTime? proposalDate = null; if (projectGateway.GetProposalDate(projectId).HasValue) proposalDate = projectGateway.GetProposalDate(projectId);
            DateTime? startDate = null; if (projectGateway.GetStartDate(projectId).HasValue) startDate = projectGateway.GetStartDate(projectId);
            DateTime? endDate = null; if (projectGateway.GetEndDate(projectId).HasValue) endDate = projectGateway.GetEndDate(projectId);
            int clientId = projectGateway.GetClientID(projectId);
            string clientProjectNumber = projectGateway.GetClientProjectNumber(projectId);
            int? libraryCategoriesId = null; if (projectGateway.GetLibraryCategoriesId(projectId).HasValue) libraryCategoriesId = (int)projectGateway.GetLibraryCategoriesId(projectId);
            bool fairWageApplies = projectGateway.GetFairWageApplies(projectId);

            // ... Insert Project
            Project project = new Project(projectTDS);
            project.Insert(countryId, officeId, projectLeadId, salesmanId, projectNumber, projectType, projectState, name, description, proposalDate, startDate, endDate, clientId, clientPrimaryContactID, clientSecondaryContactID, clientProjectNumber, deleted, OriginalProjectID, projectNumberCopy, libraryCategoriesId, provinceId, cityId, Int32.Parse(hdfCompanyId.Value.Trim()), countyId, fairWageApplies);

            // ... Insert History
            ProjectHistory projectHistory = new ProjectHistory(projectTDS);
            projectHistory.Insert(0, 1, projectState, DateTime.Now, Convert.ToInt32(Session["loginID"]), Int32.Parse(hdfCompanyId.Value.Trim()));
        }



        private void InsertProjectCostingUpdates(int originalProjectId)
        {
            // ... Data for current project
            ProjectCostingUpdatesGateway projectCostingUpdatesGateway = new ProjectCostingUpdatesGateway(projectTDS);
            projectCostingUpdatesGateway.LoadByProjectId(originalProjectId);

            if (projectCostingUpdatesGateway.Table.Rows.Count > 0)
            {
                // ... Definition of general variables
                decimal? extrasToDate = null; if (projectCostingUpdatesGateway.GetExtrasToDate(originalProjectId).HasValue) extrasToDate = (decimal)projectCostingUpdatesGateway.GetExtrasToDate(originalProjectId);
                decimal? costsIncurred = null; if (projectCostingUpdatesGateway.GetCostsIncurred(originalProjectId).HasValue) costsIncurred = (decimal)projectCostingUpdatesGateway.GetCostsIncurred(originalProjectId);
                decimal? costToComplete = null; if (projectCostingUpdatesGateway.GetCostToComplete(originalProjectId).HasValue) costToComplete = (decimal)projectCostingUpdatesGateway.GetCostToComplete(originalProjectId);
                decimal? originalProfitEstimated = null; if (projectCostingUpdatesGateway.GetOriginalProfitEstimated(originalProjectId).HasValue) originalProfitEstimated = (decimal)projectCostingUpdatesGateway.GetOriginalProfitEstimated(originalProjectId);
                decimal? invoicedToDate = null; if (projectCostingUpdatesGateway.GetInvoicedToDate(originalProjectId).HasValue) invoicedToDate = (decimal)projectCostingUpdatesGateway.GetInvoicedToDate(originalProjectId);

                // ... Insert Costing Updates
                ProjectCostingUpdates projectCostingUpdates = new ProjectCostingUpdates(projectTDS);
                projectCostingUpdates.Insert(0, extrasToDate, costsIncurred, costToComplete, originalProfitEstimated, invoicedToDate, Int32.Parse(hdfCompanyId.Value.Trim()));
            }
        }



        private void InsertProjectEngineerSubcontractors(int originalProjectId)
        {
            // ... Data for current project
            ProjectEngineerSubcontractorsGateway projectEngineerSubcontractorsGateway = new ProjectEngineerSubcontractorsGateway(projectTDS);
            projectEngineerSubcontractorsGateway.LoadAllByProjectId(originalProjectId);

            if (projectEngineerSubcontractorsGateway.Table.Rows.Count > 0)
            {
                // ... Definition of general variables
                bool generalContractor = projectEngineerSubcontractorsGateway.GetGeneralContractor(originalProjectId);
                bool generalWSIB = projectEngineerSubcontractorsGateway.GetGeneralWSIB(originalProjectId);
                bool generalInsuranceCertificate = projectEngineerSubcontractorsGateway.GetGeneralInsuranceCertificate(originalProjectId);
                string generalBondingSupplied = projectEngineerSubcontractorsGateway.GetGeneralBondingSupplied(originalProjectId);
                string generalMOLForm = projectEngineerSubcontractorsGateway.GetGeneralMOLForm(originalProjectId);
                bool generalNoticeProject = projectEngineerSubcontractorsGateway.GetGeneralNoticeProject(originalProjectId);
                bool generalForm1000 = projectEngineerSubcontractorsGateway.GetGeneralForm1000(originalProjectId);
                int? engineeringFirmId = null; if (projectEngineerSubcontractorsGateway.GetEngineeringFirmId(originalProjectId).HasValue) engineeringFirmId = (int)projectEngineerSubcontractorsGateway.GetEngineeringFirmId(originalProjectId);
                int? engineerId = null; if (projectEngineerSubcontractorsGateway.GetEngineerId(originalProjectId).HasValue) engineerId = (int)projectEngineerSubcontractorsGateway.GetEngineerId(originalProjectId);
                string engineerNumber = projectEngineerSubcontractorsGateway.GetEngineerNumber(originalProjectId);
                bool subcontractorUsed = projectEngineerSubcontractorsGateway.GetSubcontractorUsed(originalProjectId);
                string bondNumber = projectEngineerSubcontractorsGateway.GetBondNumber(originalProjectId);

                // ... insert Engineer Subcontractors
                ProjectEngineerSubcontractors projectEngineerSubcontractors = new ProjectEngineerSubcontractors(projectTDS);
                projectEngineerSubcontractors.Insert(0, generalContractor, generalWSIB, generalInsuranceCertificate, generalBondingSupplied, generalMOLForm, generalNoticeProject, generalForm1000, engineeringFirmId, engineerId, engineerNumber, subcontractorUsed, Int32.Parse(hdfCompanyId.Value.Trim()), bondNumber);
            }
        }



        private void InsertProjectNote(int originalProjectId)
        {
            // ... Data for current project
            ProjectTDS projectTDSTemp = new ProjectTDS();
            ProjectNotesGateway projectNotesGatewayTemp = new ProjectNotesGateway(projectTDSTemp);
            projectNotesGatewayTemp.LoadAllByProjectId(originalProjectId);

            ProjectNotesGateway projectNotesGateway = new ProjectNotesGateway(projectTDS);
            projectNotesGateway.LoadAllByProjectId(originalProjectId);

            ProjectNotes projectNotes = new ProjectNotes(projectTDS);

            // ... Definition of general variables
            int refId;
            string subject;
            DateTime dateTime;
            int loginId;
            string note;
            bool deleted;
            int? libraryFilesId;

            foreach (ProjectTDS.LFS_PROJECT_NOTERow row in projectTDSTemp.Tables["LFS_PROJECT_NOTE"].Rows)
            {
                // ... Definition of general variables
                refId = row.RefID;
                subject = row.Subject;
                dateTime = row.DateTime;
                loginId = row.LoginID;
                try { note = row.Note; }
                catch { note = ""; }
                deleted = row.Deleted;
                try { libraryFilesId = row.LIBRARY_FILES_ID; }
                catch { libraryFilesId = null; }

                // ... Insert Notes
                projectNotes.Insert(0, subject, dateTime, loginId, note, deleted, libraryFilesId, Int32.Parse(hdfCompanyId.Value.Trim()));
            }
        }



        private void InsertProjectSaleBillingPricing(int originalProjectId)
        {
            // ... Data for current project
            ProjectTDS projectTDSTemp = new ProjectTDS();
            ProjectSaleBillingPricingGateway projectSaleBillingPricingGatewayTemp = new ProjectSaleBillingPricingGateway(projectTDSTemp);
            projectSaleBillingPricingGatewayTemp.LoadAllByProjectId(originalProjectId);

            ProjectSaleBillingPricingGateway projectSaleBillingPricingGateway = new ProjectSaleBillingPricingGateway(projectTDS);
            projectSaleBillingPricingGateway.LoadAllByProjectId(originalProjectId);

            if (projectSaleBillingPricingGateway.Table.Rows.Count > 0)
            {
                // ... Definition of general variables
                bool saleBidProject = projectSaleBillingPricingGateway.GetSaleBidProject(originalProjectId);
                bool saleRFP = projectSaleBillingPricingGateway.GetSaleRFP(originalProjectId);
                bool saleSoleSource = projectSaleBillingPricingGateway.GetSaleSoleSource(originalProjectId);
                bool saleTermContract = projectSaleBillingPricingGateway.GetSaleTermContract(originalProjectId);
                string saleTermContractDetail = projectSaleBillingPricingGateway.GetSaleTermContractDetail(originalProjectId);
                bool saleOther = projectSaleBillingPricingGateway.GetSaleOther(originalProjectId);
                string saleOtherDetail = projectSaleBillingPricingGateway.GetSaleOtherDetail(originalProjectId);
                int? saleGettingJob = null; if (projectSaleBillingPricingGateway.GetSaleGettingJob(originalProjectId).HasValue) saleGettingJob = (int)projectSaleBillingPricingGateway.GetSaleGettingJob(originalProjectId);
                decimal? billPrice = null; if (projectSaleBillingPricingGateway.GetBillPrice(originalProjectId).HasValue) billPrice = (decimal)projectSaleBillingPricingGateway.GetBillPrice(originalProjectId);
                string billMoney = projectSaleBillingPricingGateway.GetBillMoney(originalProjectId);
                decimal? billSubcontractorAmount = null; if (projectSaleBillingPricingGateway.GetBillSubcontractorAmount(originalProjectId).HasValue) billSubcontractorAmount = (decimal)projectSaleBillingPricingGateway.GetBillSubcontractorAmount(originalProjectId);
                string billBidHardDollar = projectSaleBillingPricingGateway.GetBillBidHardDollar(originalProjectId);
                bool billPerUnit = projectSaleBillingPricingGateway.GetBillPerUnit(originalProjectId);
                bool billHourly = projectSaleBillingPricingGateway.GetBillHourly(originalProjectId);
                string billExpectExtras = projectSaleBillingPricingGateway.GetBillExpectExtras(originalProjectId);
                bool chargesWater = projectSaleBillingPricingGateway.GetChargesWater(originalProjectId);
                decimal? chargesWaterAmount = null; if (projectSaleBillingPricingGateway.GetChargesWaterAmount(originalProjectId).HasValue) chargesWaterAmount = (decimal)projectSaleBillingPricingGateway.GetChargesWaterAmount(originalProjectId);
                bool chargesDisposal = projectSaleBillingPricingGateway.GetChargesDisposal(originalProjectId);
                decimal? chargesDisposalAmount = null; if (projectSaleBillingPricingGateway.GetChargesDisposalAmount(originalProjectId).HasValue) chargesDisposalAmount = (decimal)projectSaleBillingPricingGateway.GetChargesDisposalAmount(originalProjectId);

                // ... Insert Sale/Billing/Pricing
                ProjectSaleBillingPricing projectSaleBillingPricing = new ProjectSaleBillingPricing(projectTDS);
                projectSaleBillingPricing.Insert(0, saleBidProject, saleRFP, saleSoleSource, saleTermContract, saleTermContractDetail, saleOther, saleOtherDetail, saleGettingJob, billPrice, billMoney, billBidHardDollar, billPerUnit, billHourly, billExpectExtras, billSubcontractorAmount, chargesWater, chargesWaterAmount, chargesDisposal, chargesDisposalAmount, Int32.Parse(hdfCompanyId.Value.Trim()));
            }
        }



        private void InsertProjectSubcontractor(int originalProjectId)
        {
            // ... Data for current project
            ProjectTDS projectTDSTemp = new ProjectTDS();
            ProjectSubcontractorGateway projectSubcontractorGatewayTemp = new ProjectSubcontractorGateway(projectTDSTemp);
            projectSubcontractorGatewayTemp.LoadAllByProjectId(originalProjectId);

            ProjectSubcontractorGateway projectSubcontractorGateway = new ProjectSubcontractorGateway(projectTDS);
            projectSubcontractorGateway.LoadAllByProjectId(originalProjectId);

            // ... Definition of general variables
            ProjectSubcontractor projectSubcontractor = new ProjectSubcontractor(projectTDS);

            int refId;
            int subcontractorId;
            bool writtenQuote;
            bool surveyedSite;
            bool workedBefore;
            string role;
            bool agreement;
            string issues;
            bool purchaseOrder;
            bool insuranceCertificate;
            bool wsib;
            string molForm1000;
            bool deleted;
            int? royalties;

            foreach (ProjectTDS.LFS_PROJECT_SUBCONTRACTORRow row in projectTDSTemp.Tables["LFS_PROJECT_SUBCONTRACTOR"].Rows)
            {
                refId = row.RefID;
                subcontractorId = row.SubcontractorID;
                writtenQuote = row.WrittenQuote;
                surveyedSite = row.SurveyedSite;
                workedBefore = row.WorkedBefore;
                try { role = row.Role; }
                catch { role = ""; }
                agreement = row.Agreement;
                try { issues = row.Issues; }
                catch { issues = ""; }
                purchaseOrder = row.PurchaseOrder;
                insuranceCertificate = row.InsuranceCertificate;
                wsib = row.WSIB;
                try { molForm1000 = row.MOLForm1000; }
                catch { molForm1000 = ""; }
                deleted = row.Deleted;
                try {royalties = row.Royalties;}
                catch { royalties = null; }

                // ... Insert Subcontractors
                projectSubcontractor.Insert(0, refId, subcontractorId, writtenQuote, surveyedSite, workedBefore, role, agreement, issues, purchaseOrder, insuranceCertificate, wsib, molForm1000, deleted, Int32.Parse(hdfCompanyId.Value.Trim()), royalties);
            }
        }



        private void InsertProjectService(int originalProjectId)
        {
            // ... Data for current project
            ProjectTDS projectTDSTemp = new ProjectTDS();
            ProjectServiceGateway projectServiceGatewayTemp = new ProjectServiceGateway(projectTDSTemp);
            projectServiceGatewayTemp.LoadAllByProjectId(originalProjectId);

            ProjectServiceGateway projectServiceGateway = new ProjectServiceGateway(projectTDS);
            projectServiceGateway.LoadAllByProjectId(originalProjectId);


            // ... Definition of general variables
            int refId;
            int? serviceId = null;
            string description;
            string averageSize;
            decimal? averagePrice = null;
            int quantity;
            bool deleted;
            decimal total;

            foreach (ProjectTDS.LFS_PROJECT_SERVICERow row in projectTDSTemp.Tables["LFS_PROJECT_SERVICE"].Rows)
            {
                refId = row.RefID;
                try { serviceId = row.ServiceID; }
                catch { serviceId = null; }
                try { description = row.Description; }
                catch { description = ""; }
                try { averageSize = row.AverageSize; }
                catch { averageSize = ""; }
                try { averagePrice = row.AveragePrice; }
                catch { averagePrice = null; }
                quantity = row.Quantity;
                deleted = row.Deleted;
                try { total = row.AveragePrice * row.Quantity; }
                catch { total = 0; }

                // ... Insert Service
                ProjectService projectService = new ProjectService(projectTDS);
                projectService.Insert(0, refId, serviceId, description, averageSize, averagePrice, quantity, deleted, total, Int32.Parse(hdfCompanyId.Value.Trim()));
            }
        }



        private void InsertProjectTechnical(int originalProjectId)
        {
            // ... Data for current project
            ProjectTechnicalGateway projectTechnicalGateway = new ProjectTechnicalGateway(projectTDS);
            projectTechnicalGateway.LoadByProjectId(originalProjectId);

            if (projectTechnicalGateway.Table.Rows.Count > 0)
            {
                // ... Definition of general variables
                bool availableDrawings = projectTechnicalGateway.GetDrawings(originalProjectId);
                bool availableVideo = projectTechnicalGateway.GetVideo(originalProjectId);
                bool groundConditions = projectTechnicalGateway.GetGroundConditions(originalProjectId);
                string grounConditionNotes = null; if (projectTechnicalGateway.GetGrounConditionsNotes(originalProjectId) != "") grounConditionNotes = projectTechnicalGateway.GetGrounConditionsNotes(originalProjectId);
                bool reviewVideoInspections = projectTechnicalGateway.GetReviewVideo(originalProjectId);
                bool strangeConfigurations = projectTechnicalGateway.GetStrangeConfigurations(originalProjectId);
                string strangeConfigurationsNotes = null; if (projectTechnicalGateway.GetStrangeConfigurationsNotes(originalProjectId) != "") strangeConfigurationsNotes = projectTechnicalGateway.GetStrangeConfigurationsNotes(originalProjectId);
                string furtherObservations = null; if (projectTechnicalGateway.GetFurtherObservations(originalProjectId) != "") furtherObservations = projectTechnicalGateway.GetFurtherObservations(originalProjectId);
                string restrictiveFactors = null; if (projectTechnicalGateway.GetRestrictiveFactors(originalProjectId) != "") restrictiveFactors = projectTechnicalGateway.GetRestrictiveFactors(originalProjectId);

                // ... Insert Technical
                ProjectTechnical projectTechnical = new ProjectTechnical(projectTDS);
                projectTechnical.Insert(0, availableDrawings, availableVideo, groundConditions, grounConditionNotes, reviewVideoInspections, strangeConfigurations, strangeConfigurationsNotes, furtherObservations, restrictiveFactors, Int32.Parse(hdfCompanyId.Value.Trim()));
            }
        }



        private void InsertProjectTerms(int originalProjectId)
        {
            // ... Data for current project
            ProjectTermsPOGateway projectTermsPOGateway = new ProjectTermsPOGateway(projectTDS);
            projectTermsPOGateway.LoadByProjectId(originalProjectId);

            if (projectTermsPOGateway.Table.Rows.Count > 0)
            {
                // ... Definition of general variables
                bool liquidatedDamage = projectTermsPOGateway.GetLiquidatedDamage(originalProjectId);
                decimal? liquidatedRate = null; if (projectTermsPOGateway.GetLiquidatedRate(originalProjectId).HasValue) liquidatedRate = (decimal)projectTermsPOGateway.GetLiquidatedRate(originalProjectId);
                string liquidatedUnit = projectTermsPOGateway.GetLiquidatedUnit(originalProjectId);
                bool clientWorkedBefore = projectTermsPOGateway.GetRelationshipClientWorkedBefore(originalProjectId);
                string clientQuirks = projectTermsPOGateway.GetRelationshipClientQuirks(originalProjectId);
                bool clientPromises = projectTermsPOGateway.GetRelationshipClientPromises(originalProjectId);
                string clientPromisesNotes = projectTermsPOGateway.GetRelationshipClientPromisesNotes(originalProjectId);
                string waterObtain = projectTermsPOGateway.GetRelationshipWaterObtain(originalProjectId);
                string materialDispose = projectTermsPOGateway.GetRelationshipMaterialDispose(originalProjectId);
                bool requireRPZ = projectTermsPOGateway.GetRelationshipRequireRPZ(originalProjectId);
                string standardHydrantFitting = projectTermsPOGateway.GetRelationshipStandardHydrantFitting(originalProjectId);
                bool preConstructionMeeting = projectTermsPOGateway.GetRelationshipPreConstructionMeeting(originalProjectId);
                bool specificMeetingLocation = projectTermsPOGateway.GetRelationshipSpecificMeetingLocation(originalProjectId);
                string specificMeetingLocationNotes = projectTermsPOGateway.GetRelationshipSpecificMeetingLocationNotes(originalProjectId);
                string vehicleAccess = "Fair"; if (projectTermsPOGateway.GetRelationshipVehicleAccess(originalProjectId) != "") vehicleAccess = projectTermsPOGateway.GetRelationshipVehicleAccess(originalProjectId);
                string vehicleAccessNotes = projectTermsPOGateway.GetRelationshipVehicleAccessNotes(originalProjectId);
                string projectOutcome = projectTermsPOGateway.GetRelationshipProjectOutcome(originalProjectId);
                string specificReportingNeeds = projectTermsPOGateway.GetRelationshipSpecificReportingNeeds(originalProjectId);
                bool orderAttached = projectTermsPOGateway.GetPurchaseOrderAttached(originalProjectId);
                string orderNumber = projectTermsPOGateway.GetPurchaseOrderNumber(originalProjectId);
                string orderNotes = projectTermsPOGateway.GetPurchaseOrderNotes(originalProjectId);
                bool vehicleAccessRoad = projectTermsPOGateway.GetVehicleAccessRoad(originalProjectId);
                bool vehicleAccessEasement = projectTermsPOGateway.GetVehicleAccessEasement(originalProjectId);
                bool vehicleAccessOther = projectTermsPOGateway.GetVehicleAccessOther(originalProjectId);                               

                // ... Insert Terms/PO
                ProjectTermsPO projectTermsPO = new ProjectTermsPO(projectTDS);
                projectTermsPO.Insert(0, liquidatedDamage, liquidatedRate, liquidatedUnit, clientWorkedBefore, clientQuirks, clientPromises, clientPromisesNotes, waterObtain, materialDispose, requireRPZ, standardHydrantFitting, preConstructionMeeting, specificMeetingLocation, specificMeetingLocationNotes, vehicleAccess, vehicleAccessNotes, projectOutcome, specificReportingNeeds, orderNumber, orderAttached, orderNotes, Int32.Parse(hdfCompanyId.Value.Trim()), vehicleAccessRoad, vehicleAccessEasement, vehicleAccessOther);
            }
        }



        private void RegisterClientScripts()
        {
            // Register content variables
            string contentVariables = "";

            this.ClientScript.RegisterClientScriptBlock(GetType(), "contentVariables", "<script type='text/javascript'> " + contentVariables + " </script>");

            // Register client-side code
            this.ClientScript.RegisterClientScriptInclude("clientSideCode", "./project_duplicate.js");
        }




    }
}
